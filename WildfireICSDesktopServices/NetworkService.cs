using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static iTextSharp.text.TabStop;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Networking;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Interfaces;

namespace WildfireICSDesktopServices
{
    public class NetworkService
    {
        private static string _encryptionKey = "9155a5c8-36da-45b8-8a25-9b299405cf39";
        private static bool _thisMachineIsStandAlone = false;
        private static bool _ThisMachineIsClient = false;
        private static bool _ThisMachineIsServer = false;
        private static string _ServerIP;
        private static string _ServerPortStr;
        private static List<string> _allIPs;
        public Guid CurrentIncidentID { get; set; } = Guid.Empty;
        private NetworkSendLog networkSendLog;

        public event LocalNetworkEventHandler localNetworkEvent;
        public event LocalNetworkClosedEventHandler localNetworkClosedEvent;
        public event LocalNetworkIncidentRequestHandler localNetworkIncidentRequestEvent;
        public event LocalNetworkIncomingIncidentEventHandler localNetworkIncomingIncidentEvent;
        public event LocalNetworkIncomingSendObjectEventHandler localNetworkIncomingObjectEvent;


        public NetworkService() { networkSendLog = new NetworkSendLog(); }
        public NetworkService(string serverIP, string portToUse, bool IsClient, bool IsHost) { ServerIP = serverIP; ServerPortStr = portToUse; ThisMachineIsClient = IsClient; ThisMachineIsServer = IsHost; networkSendLog = new NetworkSendLog(); }

        public string EncryptionKey { get => _encryptionKey; set => _encryptionKey = value; }
        public bool ThisMachineIsStandAlone { get => _thisMachineIsStandAlone; set => _thisMachineIsStandAlone = value; }

        public bool ThisMachineIsClient { get => _ThisMachineIsClient; set => _ThisMachineIsClient = value; }
        public bool ThisMachineIsServer { get => _ThisMachineIsServer; set => _ThisMachineIsServer = value; }

        public string ServerIP { get => _ServerIP; set => _ServerIP = value; }
        public string ServerPortStr { get => _ServerPortStr; set => _ServerPortStr = value; }
        public int ServerPort { get { int port = -1; if (!string.IsNullOrEmpty(ServerPortStr) && int.TryParse(ServerPortStr, out port)) { return port; } else return 0; } }
        public List<string> AllIPs { get => _allIPs; set => _allIPs = value; }

        /// <summary>
        /// The maximum number of times a chat message will be relayed
        /// </summary>
        int relayMaximum = 3;
        private bool PauseNetworkSend = false;



        public Dictionary<ShortGuid, NetworkSendObject> lastPeerSendObjectDict = new Dictionary<ShortGuid, NetworkSendObject>();
        public Dictionary<ShortGuid, CommsLogEntry> lastPeerCommsMessageDict = new Dictionary<ShortGuid, CommsLogEntry>();
        Dictionary<ShortGuid, WFIncident> lastPeerSarTaskDict = new Dictionary<ShortGuid, WFIncident>();
        Dictionary<ShortGuid, NetworkSARTaskRequest> lastPeerNetworkSarTaskRequestDict = new Dictionary<ShortGuid, NetworkSARTaskRequest>();
        Dictionary<ShortGuid, NetworkOptionsRequest> lastPeerNetworkOptionsRequestDict = new Dictionary<ShortGuid, NetworkOptionsRequest>();
        //Dictionary<ShortGuid, NetworkMemberRequest> lastPeerNetworkMemberRequestDict = new Dictionary<ShortGuid, NetworkMemberRequest>();
        Dictionary<ShortGuid, NetworkDeleteOrder> lastPeerNetworkDeleteOrderDict = new Dictionary<ShortGuid, NetworkDeleteOrder>();


        public void SetUpEvents()
        {
            NetworkComms.AppendGlobalConnectionCloseHandler(HandleConnectionClosed);
            NetworkComms.AppendGlobalIncomingPacketHandler<NetworkSARTaskRequest>("NetworkSARTaskRequest", HandleIncomingNetworkSarTaskRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<NetworkOptionsRequest>("NetworkOptionsRequest", HandleIncomingNetworkOptionsRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<WFIncident>("WFIncident", HandleIncomingIncident);
            NetworkComms.AppendGlobalIncomingPacketHandler<NetworkSendObject>("NetworkSendObject", HandleIncomingInformation);
            //NetworkComms.AppendGlobalIncomingPacketHandler<NetworkDeleteOrder>("NetworkDeleteOrder", HandleIncomingNetworkDeleteorder);

        }


        private void HandleIncomingInformation(PacketHeader header, Connection connection, NetworkSendObject incomingMessage)
        {
            lock (lastPeerSendObjectDict)
            {
                bool acceptInfo = false;
                if (lastPeerSendObjectDict.ContainsKey(incomingMessage.SourceIdentifier))
                {
                    if (lastPeerSendObjectDict[incomingMessage.SourceIdentifier].RequestID != incomingMessage.RequestID)
                    {
                        acceptInfo = true;
                        lastPeerSendObjectDict[incomingMessage.SourceIdentifier] = incomingMessage;
                    }
                }
                else if (incomingMessage.SourceIdentifier != NetworkComms.NetworkIdentifier)
                {
                    lastPeerSendObjectDict.Add(incomingMessage.SourceIdentifier, incomingMessage);
                    acceptInfo = true;
                }

                //Reject network send objects from a different task.  This should mitigate issues of multiple tasks running on the same network.
                if (acceptInfo && incomingMessage.TaskID != Guid.Empty && incomingMessage.TaskID != CurrentIncidentID) { acceptInfo = false; }

                if (acceptInfo)
                {
                    DateTime today = DateTime.Now;
                    //addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - received incoming item: " + incomingMessage.objectType + "\r\n");

                    if (!networkSendLog.ObjectAlreadySentOrReceived(incomingMessage))
                    {
                        PauseNetworkSend = true;

                        networkSendLog.AddToReceived(incomingMessage, DateTime.UtcNow, true);

                        string source = "network";
                        if (!incomingMessage.UploadedToInternet) { source = "networkNoInternet"; }

                        OnLocalNetworkIncomingObject(incomingMessage);

                        PauseNetworkSend = false;

                    }
                }

                if (incomingMessage.RelayCount < relayMaximum)
                {
                    var allRelayConnections = (from current in NetworkComms.GetExistingConnection() where current != connection select current).ToArray();
                    incomingMessage.RelayCount += 1;
                    foreach (var relayConnection in allRelayConnections)
                    {
                        try { relayConnection.SendObject("NetworkSendObject", incomingMessage); }
                        catch (CommsException) { /* Catch the comms exception, ignore and continue */ }
                    }
                }
            }
        }
        protected virtual void OnLocalNetworkIncomingObject(NetworkSendObject sendObject)
        {
            LocalNetworkIncomingSendObjectEventHandler handler = localNetworkIncomingObjectEvent;
            if (handler != null)
            {
                handler(sendObject);
            }
        }


        /// <summary>
        /// Performs whatever functions we might so desire when we receive an incoming ChatMessage
        /// </summary>
        /// <param name="header">The PacketHeader corresponding with the received object</param>
        /// <param name="connection">The Connection from which this object was received</param>
        /// <param name="incomingMessage">The incoming ChatMessage we are after</param>
        private void HandleIncomingIncident(PacketHeader header, Connection connection, WFIncident incomingMessage)
        {

            lock (lastPeerSarTaskDict)
            {
                if (lastPeerSarTaskDict.ContainsKey(incomingMessage.SourceIdentifier))
                {
                    if (lastPeerSarTaskDict[incomingMessage.SourceIdentifier].RequestID != incomingMessage.RequestID)
                    {
                        //If this message index is greater than the last seen from this source we can safely
                        //write the message to the txtChat
                        //replaceCurrentTaskWithNetworkTask(incomingMessage);
                        OnLocalNetworkIncomingIncident(incomingMessage);


                        //We now replace the last received message with the current one
                        lastPeerSarTaskDict[incomingMessage.SourceIdentifier] = incomingMessage;
                    }
                }
                else
                {
                    //If we have never had a message from this source before then it has to be new
                    //by definition
                    lastPeerSarTaskDict.Add(incomingMessage.SourceIdentifier, incomingMessage);
                    OnLocalNetworkIncomingIncident(incomingMessage);
                    //replaceCurrentTaskWithNetworkTask(incomingMessage);
                    //AppendLineTotxtChat(incomingMessage.SourceName + " - " + incomingMessage.Message);
                }
            }


            //Once we have written to the txtChat we refresh the txtConnectedUsersWindow
            //RefreshtxtConnectedUsersBox();

            //This last section of the method is the relay function
            //We start by checking to see if this message has already been relayed
            //the maximum number of times
            if (incomingMessage.RelayCount < relayMaximum)
            {
                //If we are going to relay this message we need an array of
                //all other known connections
                var allRelayConnections = (from current in NetworkComms.GetExistingConnection() where current != connection select current).ToArray();

                //We increment the relay count before we send
                incomingMessage.RelayCount += 1;

                //We will now send the message to every other connection
                foreach (var relayConnection in allRelayConnections)
                {
                    //We ensure we perform the send within a try catch
                    //To ensure a single failed send will not prevent the
                    //relay to all working connections.
                    try { relayConnection.SendObject("SARTask", incomingMessage); }
                    catch (CommsException) { /* Catch the comms exception, ignore and continue */ }
                }
            }
        }

        protected virtual void OnLocalNetworkIncomingIncident(WFIncident incident)
        {
            LocalNetworkIncomingIncidentEventHandler handler = localNetworkIncomingIncidentEvent;
            if (handler != null)
            {
                handler(incident);
            }
        }



        private void HandleIncomingNetworkOptionsRequest(PacketHeader header, Connection connection, NetworkOptionsRequest incomingMessage)
        {
            //We only want to write a message once to the chat window
            //Because we allow relaying and may receive the same message twice
            //we use our history and message indexes to ensure we have a new message

            lock (lastPeerNetworkSarTaskRequestDict)
            {
                if (lastPeerNetworkOptionsRequestDict.ContainsKey(incomingMessage.SourceIdentifier))
                {
                    if (lastPeerNetworkOptionsRequestDict[incomingMessage.SourceIdentifier].RequestID != incomingMessage.RequestID)
                    {
                        //If this message index is greater than the last seen from this source we can safely
                        //write the message to the txtChat
                        answerRequestForNetworkOptions(incomingMessage);

                        //We now replace the last received message with the current one
                        lastPeerNetworkOptionsRequestDict[incomingMessage.SourceIdentifier] = incomingMessage;
                    }
                }
                else
                {
                    //If we have never had a message from this source before then it has to be new
                    //by definition
                    lastPeerNetworkOptionsRequestDict.Add(incomingMessage.SourceIdentifier, incomingMessage);
                    answerRequestForNetworkOptions(incomingMessage);
                    //AppendLineTotxtChat(incomingMessage.SourceName + " - " + incomingMessage.Message);
                }
            }




            //Once we have written to the txtChat we refresh the txtConnectedUsersWindow
            //RefreshtxtConnectedUsersBox();

            //This last section of the method is the relay function
            //We start by checking to see if this message has already been relayed
            //the maximum number of times
            if (incomingMessage.RelayCount < relayMaximum)
            {
                //If we are going to relay this message we need an array of
                //all other known connections
                var allRelayConnections = (from current in NetworkComms.GetExistingConnection() where current != connection select current).ToArray();

                //We increment the relay count before we send
                incomingMessage.RelayCount += 1;


                //We will now send the message to every other connection
                foreach (var relayConnection in allRelayConnections)
                {
                    //We ensure we perform the send within a try catch
                    //To ensure a single failed send will not prevent the
                    //relay to all working connections.
                    try { relayConnection.SendObject("NetworkOptionsRequest", incomingMessage); }
                    catch (CommsException) { /* Catch the comms exception, ignore and continue */ }
                }
            }
        }

        private void answerRequestForNetworkOptions(NetworkOptionsRequest incomingMessage)
        {
            if (ThisMachineIsServer)
            {
                GeneralOptionsService service = new GeneralOptionsService(true);
                GeneralOptions options = service.GetGeneralOptions();
                SendNetworkObject(options, Guid.Empty);
            }

        }


        public bool CheckIP(string ip)
        {
            bool ipGood = false;
            using (Ping pingSender = new Ping())
            {


                //a little regex to check if the texbox contains a valid ip adress (ipv4 only).
                //This way you limit the number of useless calls to ping.
                Regex rgx = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$");
                if (rgx.IsMatch(ip))
                {
                    int timeout = 120;
                    try
                    {
                        var reply = pingSender.SendPingAsync(ip, timeout);
                        //textBlock.Text = reply.Status == IPStatus.Success ? "OK" : "KO";
                        ipGood = true;
                    }
                    catch (Exception ex) when (ex is TimeoutException || ex is PingException)
                    {
                        ipGood = false;
                    }
                }
                else
                {
                    ipGood = false;
                }
            }
            return ipGood;
        }

        public bool GetIsFirewallEnabled()
        {
            // Create the firewall type.
            Type FWManagerType = Type.GetTypeFromProgID("HNetCfg.FwMgr");

            // Use the firewall type to create a firewall manager object.
            dynamic FWManager = Activator.CreateInstance(FWManagerType);

            // Check the status of the firewall.
            return FWManager.LocalPolicy.CurrentProfile.FirewallEnabled;

        }

        public bool GetIsPortAvailable(int port)
        {
            bool isAvailable = true;

            // Evaluate current system tcp connections. This is the same information provided
            // by the netstat command line application, just in .Net strongly-typed object
            // form.  We will look through the list, and if our port we would like to use
            // in our TcpClient is occupied, we will set isAvailable to false.
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            foreach (TcpConnectionInformation tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == port)
                {
                    isAvailable = false;
                    break;
                }
            }
            return isAvailable;
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public List<string> SendNetworkSarTaskRequest(NetworkSARTaskRequest request)
        {

            List<string> log = new List<string>();

            //We may or may not have entered some server connection information
            ConnectionInfo serverConnectionInfo = null;
            if (!string.IsNullOrEmpty(ServerIP))
            {
                try { serverConnectionInfo = new ConnectionInfo(ServerIP, int.Parse(ServerPortStr)); }
                catch (Exception)
                {
                    log.Add("Failed to parse the server IP and port. Please ensure it is correct and try again");
                    return log;
                }
            }

            //If we provided server information we send to the server first
            if (serverConnectionInfo != null)
            {
                //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                try
                {
                    TCPConnection.GetConnection(serverConnectionInfo).SendObject("NetworkSARTaskRequest", request);
                    DateTime today = DateTime.Now;
                    //addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - sent task request" + "\r\n");
                }
                catch (CommsException) { log.Add("A Network CommsException occurred while trying to send a task request (001) to " + serverConnectionInfo); }
            }

            //If we have any other connections we now send the message to those as well
            //This ensures that if we are the server everyone who is connected to us gets our message
            var otherConnectionInfos = (from current in NetworkComms.AllConnectionInfo() where current != serverConnectionInfo select current).ToArray();
            foreach (ConnectionInfo info in otherConnectionInfos)
            {
                //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                try { TCPConnection.GetConnection(info).SendObject("NetworkSARTaskRequest", request); }
                catch (CommsException) { log.Add("A Network CommsException occurred while trying to send a task request (002) to " + info); }
                catch (Exception ex) { log.Add("A Network CommsException occurred while trying to send a task request (003) to " + ex.ToString()); }
            }

            /*
            this.BeginInvoke((Action)delegate ()
            {
                MessageBox.Show("Your request has been sent to the server computer.  A user there will need to confirm it.  In the interim, please do not attempt any work - it will be overwritten.");

            });*/
            return log;
        }



        

        public NetworkSendResults SendNetworkObject(object objToSend, Guid TaskID, string comment = null, string ip = null, string port = null, bool sentByInternet = false)
        {
            NetworkSendResults results = new NetworkSendResults();
            results.Errors = new List<string>();

            if (objToSend != null)
            {
                NetworkSendObject networkSendObject = new NetworkSendObject(TaskID);
                networkSendObject.UploadedToInternet = sentByInternet;

                switch (objToSend)
                {

                    
                    case Guid g:
                        networkSendObject.GuidValue = g;
                        networkSendObject.TaskID = Guid.Empty;
                        break;
                   
                   
                    case GeneralOptions options:
                        networkSendObject.generalOptions = options;
                        networkSendObject.TaskID = Guid.Empty;
                        break;
                   
                  
                    case TaskUpdate taskUpdate:
                        networkSendObject.taskUpdate = taskUpdate.Clone();
                        networkSendObject.taskUpdate.ProcessedLocally = false;
                        networkSendObject.taskUpdate.Source = "Network";

                        break;
                    case null:
                        break;
                    default:
                        break;
                }
                networkSendObject.RequestID = Guid.NewGuid();
                networkSendObject.objectType = objToSend.GetType().ToString();
                //for 6.13 support
                networkSendObject.objectType = networkSendObject.objectType.Replace(".Models", "");

                networkSendObject.SourceName = HostInfo.HostName;
                networkSendObject.SourceIdentifier = NetworkComms.NetworkIdentifier;
                networkSendObject.comment = comment;

                results.ObjectSent = networkSendObject;

                string iptouse = ServerIP;
                int porttouse = int.Parse(ServerPortStr);
                if (ip != null) { iptouse = ip; }
                if (port != null)
                {
                    int.TryParse(port, out porttouse);
                }
                DateTime today = DateTime.Now;

                //We may or may not have entered some server connection information
                ConnectionInfo serverConnectionInfo = null;


                if (!string.IsNullOrEmpty(iptouse))
                {
                    try { serverConnectionInfo = new ConnectionInfo(iptouse, porttouse); }
                    catch (Exception)
                    {
                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " Error - Failed to parse the server IP and port. Please ensure it is correct and try again\r\n\r\n");
                        //MessageBox.Show("Failed to parse the server IP and port. Please ensure it is correct and try again", "Server IP & Port Parse Error", MessageBoxButtons.OK);
                    }
                }

                lock (lastPeerSendObjectDict) lastPeerSendObjectDict[NetworkComms.NetworkIdentifier] = networkSendObject;

                //If we provided server information we send to the server first
                if (serverConnectionInfo != null)
                {
                    //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                    try
                    {
                        //SendReceiveOptions customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
                        //ConnectionInfo connectionInfo = new ConnectionInfo("192.168.1.105", 5614);
                        //TCPConnection serverConnection = TCPConnection.GetConnection(serverConnectionInfo, customSendReceiveOptions);


                        TCPConnection serverConnection = TCPConnection.GetConnection(serverConnectionInfo);
                        serverConnection.SendObject("NetworkSendObject", networkSendObject);
                        results.SentSuccessfully = true;
                        //errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " - sent " + networkSendObject.objectType + " - " + networkSendObject.comment + "\r\n");
                    }
                    catch (CommsException ce)
                    {

                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " Error - " + ce.ToString() + "\r\n\r\n");
                    }
                    catch (Exception ex)
                    {
                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " Error - " + ex.ToString() + "\r\n\r\n");
                    }

                }

                //If we have any other connections we now send the message to those as well
                //This ensures that if we are the server everyone who is connected to us gets our message
                var otherConnectionInfos = (from current in NetworkComms.AllConnectionInfo() where current != serverConnectionInfo select current).ToArray();
                foreach (ConnectionInfo info in otherConnectionInfos)
                {
                    //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                    try { TCPConnection.GetConnection(info).SendObject("NetworkSendObject", networkSendObject); }
                    catch (CommsException)
                    {
                        if (ThisMachineIsClient || ThisMachineIsServer)
                        {
                            results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " Error -  CommsException occurred while trying to send message to " + info + "\r\n\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " A CommsException occurred while trying to send message to " + ex.ToString() + "\r\n\r\n");
                    }
                }
            }
            return results;
        }

        public async Task<bool> CheckForInternetConnectionAsync()
        {
            HttpClient _httpClient = new HttpClient();

            using (var tokSource = new CancellationTokenSource(5000))
            {
                try
                {
                    await _httpClient.GetAsync("https://www.sarassist.ca", tokSource.Token);
                }
                catch (OperationCanceledException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> GetAllIPs(bool allowDNSInEligable = false)
        {
            List<string> ips = new List<string>();
            List<string> dnsEligableIPs = new List<string>();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.IsDnsEligible || allowDNSInEligable)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                ips.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
            }


            return ips;

        }

        public static IPEndPoint CreateIPEndPoint(string endPoint)
        {
            if (!string.IsNullOrEmpty(endPoint))
            {
                string[] ep = endPoint.Split(':');
                if (ep.Length < 2) throw new FormatException("Invalid endpoint format");
                IPAddress ip;
                if (ep.Length > 2)
                {
                    if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
                    {
                        throw new FormatException("Invalid ip-adress");
                    }
                }
                else
                {
                    if (!IPAddress.TryParse(ep[0], out ip))
                    {
                        throw new FormatException("Invalid ip-adress");
                    }
                }
                int port;
                if (!int.TryParse(ep[ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out port))
                {
                    throw new FormatException("Invalid port");
                }
                return new IPEndPoint(ip, port);
            }
            else { return null; }
        }

        Guid NetworkTestGuidValue = Guid.Empty;
        
        public void sendTestConnection(Guid IncidentID, string ip = null, string port = null)
        {
            NetworkTestGuidValue = Guid.NewGuid();
            SendNetworkObject(NetworkTestGuidValue, IncidentID,  "test", ip, port);
        }

      

        public bool StartAsServer(int Port, string ip)
        {
            try
            {

                startListening(Port, ip);
                DateTime today = DateTime.Now;
                ThisMachineIsServer = true;
                ThisMachineIsClient = false;
                ServerIP = ip;
                ServerPortStr = Port.ToString();
                return true;
            }
            catch (Exception)
            {
                ThisMachineIsServer = false;
                ThisMachineIsClient = false;
                

                ServerIP = null;
                ServerPortStr = null;


                return false;
            }
        }



        public NetworkListenResult startListening(int port, string selectedIP)
        {
            NetworkListenResult result = new NetworkListenResult();

            try
            {
                IPEndPoint endPoint = CreateIPEndPoint(selectedIP + ":" + port);
                if (endPoint != null)
                {
                    Connection.StartListening(ConnectionType.TCP, endPoint);



                    // List<String> ips = new List<String>();


                    foreach (IPEndPoint listenEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
                    {
                        if (listenEndPoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && listenEndPoint.Address.ToString() != "127.0.0.1")
                        {
                            result.TempServerIP = listenEndPoint.Address.ToString();
                            result.TempPort = listenEndPoint.Port.ToString();
                        }
                    }

                    RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, EncryptionKey);
                    if (!NetworkComms.DefaultSendReceiveOptions.DataProcessors.Contains(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()))
                    {
                        NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
                    }
                }
              
            }
            catch (CommsSetupShutdownException SdEx)
            {
                result.Message = SdEx.ToString();
            }

            return result;
        }

        public List<string> SendNetworkDeleteOrder(NetworkDeleteOrder order)
        {
            List<string> errors = new List<string>();

            //We may or may not have entered some server connection information
            ConnectionInfo serverConnectionInfo = null;
            if (ServerIP != "")
            {
                try { serverConnectionInfo = new ConnectionInfo(ServerIP, ServerPort); }
                catch (Exception)
                {
                    errors.Add("Failed to parse the server IP and port. Please ensure it is correct and try again");
                }
            }

            //If we provided server information we send to the server first
            if (serverConnectionInfo != null)
            {
                //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                try
                {
                    TCPConnection.GetConnection(serverConnectionInfo).SendObject("NetworkDeleteOrder", order);
                    DateTime today = DateTime.Now;
                    //errors.Add(string.Format("{0:HH:mm:ss}", today) + " - sent delete order for" + order.objectType + "\r\n");
                }
                catch (CommsException) { errors.Add("A CommsException occurred while trying to send a delete message to " + serverConnectionInfo); }
            }

            //If we have any other connections we now send the message to those as well
            //This ensures that if we are the server everyone who is connected to us gets our message
            var otherConnectionInfos = (from current in NetworkComms.AllConnectionInfo() where current != serverConnectionInfo select current).ToArray();
            foreach (ConnectionInfo info in otherConnectionInfos)
            {
                //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                try { TCPConnection.GetConnection(info).SendObject("NetworkDeleteOrder", order); }
                catch (CommsException) { errors.Add("A CommsException occurred while trying to send message to " + info); }
                catch (Exception ex) { errors.Add("A CommsException occurred while trying to send a delete message to " + ex.ToString()); }
            }

            return errors;

        }

        protected virtual void OnLocalNetworkClosed(Connection connection)
        {
            LocalNetworkClosedEventHandler handler = this.localNetworkClosedEvent;
            if (handler != null)
            {
                handler(connection);
            }
        }

        private void HandleConnectionClosed(Connection connection)
        {
            OnLocalNetworkClosed(connection);
        }




        protected virtual void OnLocalNetworkIncidentRequest(NetworkSARTaskRequest request)
        {
            LocalNetworkIncidentRequestHandler handler = localNetworkIncidentRequestEvent;
            if(handler != null)
            {
                handler(request);
            }
        }


        private void HandleIncomingNetworkSarTaskRequest(PacketHeader header, Connection connection, NetworkSARTaskRequest incomingMessage)
        {
            //We only want to write a message once to the chat window
            //Because we allow relaying and may receive the same message twice
            //we use our history and message indexes to ensure we have a new message

            lock (lastPeerNetworkSarTaskRequestDict)
            {
                if (lastPeerNetworkSarTaskRequestDict.ContainsKey(incomingMessage.SourceIdentifier))
                {
                    if (lastPeerNetworkSarTaskRequestDict[incomingMessage.SourceIdentifier].RequestID != incomingMessage.RequestID)
                    {
                        //If this message index is greater than the last seen from this source we can safely
                        //write the message to the txtChat
                        OnLocalNetworkIncidentRequest(incomingMessage);
                        

                        //We now replace the last received message with the current one
                        lastPeerNetworkSarTaskRequestDict[incomingMessage.SourceIdentifier] = incomingMessage;
                    }
                }
                else
                {
                    //If we have never had a message from this source before then it has to be new
                    //by definition
                    lastPeerNetworkSarTaskRequestDict.Add(incomingMessage.SourceIdentifier, incomingMessage);
                    OnLocalNetworkIncidentRequest(incomingMessage);
                    //AppendLineTotxtChat(incomingMessage.SourceName + " - " + incomingMessage.Message);
                }
            }


            //Once we have written to the txtChat we refresh the txtConnectedUsersWindow
            //RefreshtxtConnectedUsersBox();

            //This last section of the method is the relay function
            //We start by checking to see if this message has already been relayed
            //the maximum number of times
            if (incomingMessage.RelayCount < relayMaximum)
            {
                //If we are going to relay this message we need an array of
                //all other known connections
                var allRelayConnections = (from current in NetworkComms.GetExistingConnection() where current != connection select current).ToArray();

                //We increment the relay count before we send
                incomingMessage.RelayCount += 1;

                string localip = GetLocalIPAddress();
                //We will now send the message to every other connection
                foreach (var relayConnection in allRelayConnections)
                {
                    if (!relayConnection.ConnectionInfo.LocalEndPoint.ToString().Contains(incomingMessage.RequestIP)
                        && !relayConnection.ConnectionInfo.LocalEndPoint.ToString().Contains(localip))
                    {
                        //We ensure we perform the send within a try catch
                        //To ensure a single failed send will not prevent the
                        //relay to all working connections.
                        try { relayConnection.SendObject("NetworkSARTaskRequest", incomingMessage); }
                        catch (CommsException) { /* Catch the comms exception, ignore and continue */ }
                    }
                }
            }
        }


        public LocalNetworkEventArgs SendTaskData(WFIncident task)
        {
            LocalNetworkEventArgs args = new LocalNetworkEventArgs();
            //We may or may not have entered some server connection information
            ConnectionInfo serverConnectionInfo = null;
            if (!string.IsNullOrEmpty(ServerIP))
            {
                try { serverConnectionInfo = new ConnectionInfo(ServerIP, ServerPort); }
                catch (Exception)
                {
                    args.message = "Failed to parse the server IP and port. Please ensure it is correct and try again";
                    args.Successful = false;
                    
                    return args;
                }
            }

            //If we provided server information we send to the server first
            if (serverConnectionInfo != null)
            {
                lock (lastPeerSarTaskDict) lastPeerSarTaskDict[NetworkComms.NetworkIdentifier] = task;

                task.RequestID = Guid.NewGuid();
                //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                try
                {
                    TCPConnection.GetConnection(serverConnectionInfo).SendObject("SARTask", task);
                    DateTime today = DateTime.Now;
                    args.message += string.Format("{0:HH:mm:ss}", today) + " - sent full task" + "\r\n";
                    args.Successful = true;
                }
                catch (CommsException)
                {
                    args.message = "A Network CommsException occurred while trying to send task data (001) to " + serverConnectionInfo;
                    args.Successful = false;
                }
                catch (Exception ex)
                {
                    args.message = "There was an error: " + ex.ToString();
                    args.Successful = false;
                }
            }

            return args;
        }


    }

    public class NetworkListenResult
    {
        public string TempServerIP { get; set; }
        public string TempPort { get; set; }
        public string Message { get; set; }
    }

    public class NetworkTestResult
    {
        public Guid TestID { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
