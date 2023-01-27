using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.UtilityForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Wildfire_ICS_Assist
{
    public partial class NetworkSettingsForm : Form
    {
        private string tempServerIP = null; private string tempPort = null;
        int preferredPort = 42999;

        public NetworkSettingsForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void NetworkSettingsForm_Load(object sender, EventArgs e)
        {
          
            preferredPort = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("DefaultPort"));


            txtServerPort.Text = preferredPort.ToString();

            rbStandalone.Checked = !(Program.networkService.ThisMachineIsServer || Program.networkService.ThisMachineIsClient);
            if (Program.networkService.ThisMachineIsServer) { tempPort = Program.networkService.ServerPort.ToString(); tempServerIP = Program.networkService.ServerIP; }
            rbServer.Checked = Program.networkService.ThisMachineIsServer;

            rbClient.Checked = Program.networkService.ThisMachineIsClient;
            if (rbClient.Checked)
            {
                if (!string.IsNullOrEmpty(Program.networkService.ServerIP))
                {
                    txtServerIP.Text = Program.networkService.ServerIP;

                }
                else { txtServerIP.Text = "127.0.0.1"; }
                txtServerPort.Text = Program.networkService.ServerPort.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Program.networkService.ThisMachineIsServer = rbServer.Checked;
            Program.networkService.ThisMachineIsClient = rbClient.Checked;
            Program.networkService.ThisMachineIsStandAlone = rbStandalone.Checked;
            if (rbServer.Checked)
            {
                Program.networkService.ServerIP = tempServerIP;
                Program.networkService.ServerPortStr = tempPort;
                Program.networkService.startListening(Program.networkService.ServerPort, Program.networkService.ServerIP);
            }
            else if (rbClient.Checked)
            {
                int port = 0;
                _ = int.TryParse(txtServerPort.Text, out port);
                bool firewallEnabled = Program.networkService.GetIsFirewallEnabled();
                bool portAvailable = Program.networkService.GetIsPortAvailable(port);
                RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, Program.networkService.EncryptionKey);
                if (!NetworkComms.DefaultSendReceiveOptions.DataProcessors.Contains(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()))
                {
                    NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
                }

                if (firewallEnabled && !portAvailable)
                {
                    MessageBox.Show("A firewall may be blocking this application. Please try an alternate port, or make an exception in your firewall to allow this program to operate over a network.");
                }

                NetworkComms.Shutdown();
                Program.networkService.ServerIP = txtServerIP.Text;
                Program.networkService.ServerPortStr = txtServerPort.Text;
                Program.generalOptionsService.UpserOptionValue(Program.networkService.ServerIP, "LastServerIP");
                Program.generalOptionsService.UpserOptionValue(Program.networkService.ServerPortStr, "LastPort");

                DateTime today = DateTime.Now;
                //parent.addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - Attempting to connect to server " + Program.networkService.ServerIP + "\r\n");
            }
            else
            {
                DateTime today = DateTime.Now;
                //parent.addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - end network communications and work stand-alone" + "\r\n");
                NetworkComms.Shutdown();
                Program.networkService.ServerIP = null;
                Program.networkService.ServerPortStr = null;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!Program.networkService.ThisMachineIsServer) { NetworkComms.Shutdown(); }

            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            pnlClientSettings.Enabled = true; pnlClientSettings.BackColor = Color.White;
            pnlServerInfo.Enabled = false; pnlServerInfo.BackColor = SystemColors.Control;
            lblServerInfo.Text = "--";

            string lastIP = Program.generalOptionsService.GetStringOptionValue("LastServerIP").ToString();
            string lastPort = Program.generalOptionsService.GetStringOptionValue("LastPort").ToString();
            txtServerIP.Text = lastIP;
            txtServerPort.Text = lastPort;
            txtServerIP.Focus();
        }

        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            pnlClientSettings.Enabled = false; pnlClientSettings.BackColor = SystemColors.Control;
            pnlServerInfo.Enabled = true; pnlServerInfo.BackColor = Color.White;

            if (rbServer.Checked)
            {
                int port = 0; int.TryParse(tempPort, out port);

                if (string.IsNullOrEmpty(tempServerIP)) { SetIPAsNeeded(); }
                if (string.IsNullOrEmpty(tempPort))
                {
                    tempPort = Program.generalOptionsService.GetOptionsValue("DefaultPort").ToString();
                    port = Convert.ToInt32(tempPort);
                }


                /*
                if (string.IsNullOrEmpty(tempServerIP) || tempPort == null)
                {
                    
                    startListening(port);
                    DateTime today = DateTime.Now;
                    parent.addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - began listening for incoming messages as the server" + "\r\n");
                }
                */

                StringBuilder server = new StringBuilder();
                server.Append("Give the following information to users wanting to connect:\n");
                server.Append("IP Address: "); server.Append(tempServerIP); server.Append("\r\nPort Number: "); server.Append(tempPort);
                lblServerInfo.Text = server.ToString();
            }
            else { tempServerIP = null; }

        }

        private void rbStandalone_CheckedChanged(object sender, EventArgs e)
        {
            tempServerIP = null;
            pnlClientSettings.Enabled = false; pnlClientSettings.BackColor = SystemColors.Control;
            pnlServerInfo.Enabled = false; pnlServerInfo.BackColor = SystemColors.Control;
            lblServerInfo.Text = "--";

        }

        private void btnImportCoordinatesHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("NetworkSettings"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void SetIPAsNeeded()
        {
            List<string> allIPs = Program.networkService.GetAllIPs(false);
            if (allIPs.Count == 0)
            {
                //no dnsable ips were found, broaden the search
                allIPs = Program.networkService.GetAllIPs(true);
            }


            if (allIPs.Count == 1)
            {
                tempServerIP = allIPs[0];
            }
            else if (allIPs.Count > 1)
            {


                using (NetworkSelectIPForm selectIPForm = new NetworkSelectIPForm())
                {
                    selectIPForm.ipAddresses = allIPs;
                    DialogResult dr = selectIPForm.ShowDialog();
                    tempServerIP = selectIPForm.SelectedAddress;
                    Program.generalOptionsService.UpserOptionValue(tempServerIP, "LastIpUsedWhenMachineIsServer");
                }
            }
        }

        private bool CheckIP(string ip)
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


    }
}
