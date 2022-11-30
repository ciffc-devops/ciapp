using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Networking
{
    public static class PingTool
    {
        public static bool TestPing(string url = "8.8.8.8")
        {
            try
            {
                Ping myPing = new Ping();
                String host = url;
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
