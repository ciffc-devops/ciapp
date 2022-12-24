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

        public NetworkService() { }
        public NetworkService(string serverIP, string portToUse, bool IsClient, bool IsHost) { ServerIP = serverIP; ServerPortStr = portToUse; ThisMachineIsClient = IsClient; ThisMachineIsServer = IsHost; }

        public string EncryptionKey { get => _encryptionKey; set => _encryptionKey = value; }
        public bool ThisMachineIsStandAlone { get => _thisMachineIsStandAlone; set => _thisMachineIsStandAlone = value; }

        public bool ThisMachineIsClient { get => _ThisMachineIsClient; set => _ThisMachineIsClient = value; }
        public bool ThisMachineIsServer { get => _ThisMachineIsServer; set => _ThisMachineIsServer = value; }

        public string ServerIP { get => _ServerIP; set => _ServerIP = value; }
        public string ServerPortStr { get => _ServerPortStr; set => _ServerPortStr = value; }
        public int ServerPort { get { int port = -1; if (!string.IsNullOrEmpty(ServerPortStr) && int.TryParse(ServerPortStr, out port)) { return port; } else return 0; } }
        public List<string> AllIPs { get => _allIPs; set => _allIPs = value; }




        public Dictionary<ShortGuid, NetworkSendObject> lastPeerSendObjectDict = new Dictionary<ShortGuid, NetworkSendObject>();

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
                   
                    case List<TeamMember> memberList:
                        List<TeamMember> toAdd = new List<TeamMember>();
                        foreach (TeamMember member in memberList) { toAdd.Add(member.Clone()); }
                        networkSendObject.memberList = toAdd;
                        break;
                   
                    case GeneralOptions options:
                        networkSendObject.generalOptions = options;
                        networkSendObject.TaskID = Guid.Empty;
                        break;
                   
                    case TaskBasics taskBasics:
                        networkSendObject.taskBasics = taskBasics;
                        break;
                   
                    case TaskUpdate taskUpdate:
                        networkSendObject.taskUpdate = taskUpdate.Clone();
                        networkSendObject.taskUpdate.ProcessedLocally = false;
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
                        //MessageBox.Show("A CommsException occurred while trying to send a " + networkSendObject.GetType() + " to " + serverConnectionInfo + "\r\n\r\n" + ce.ToString(), "Network Comms Exception", MessageBoxButtons.OK);
                        //MessageBox.Show("A CommsException occurred while trying to send message to " + serverConnectionInfo, "CommsException", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " Error - " + ex.ToString() + "\r\n\r\n");
                        // MessageBox.Show("A CommsException occurred while trying to send a " + networkSendObject.GetType() + " to " + ex.ToString(), "CommsException", MessageBoxButtons.OK);
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

                            //MessageBox.Show("A CommsException occurred while trying to send message to " + info + "\r\n\r\n" + ce.ToString(), "Network Comms Exception", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        results.Errors.Add(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " A CommsException occurred while trying to send message to " + ex.ToString() + "\r\n\r\n");
                        //MessageBox.Show("A CommsException occurred while trying to send message to " + ex.ToString(), "CommsException", MessageBoxButtons.OK);

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
                            //server.Append("IP Address: "); server.Append(listenEndPoint.Address); server.Append("\r\nPort Number: "); server.Append(listenEndPoint.Port);
                            result.TempServerIP = listenEndPoint.Address.ToString();
                            // ips.Add(listenEndPoint.Address.ToString());
                            result.TempPort = listenEndPoint.Port.ToString();
                        }
                    }

                    RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, EncryptionKey);
                    if (!NetworkComms.DefaultSendReceiveOptions.DataProcessors.Contains(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()))
                    {
                        NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
                    }
                }
                /*
                if (ips.Count > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Warning: your computer may be connected in more than one way to a network.  The following IP addresses were detected."); sb.Append(Environment.NewLine);
                    foreach (string s in ips) { sb.Append(s); sb.Append(Environment.NewLine); }
                    sb.Append("If the first one displayed doesn't work when connecting from another computer, try the other(s).");
                    result.Message = sb.ToString();
                }*/
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
