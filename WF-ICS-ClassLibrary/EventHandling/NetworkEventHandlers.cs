using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Networking;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void LocalNetworkEventHandler(LocalNetworkEventArgs e);

    public class LocalNetworkEventArgs
    {
        public string message { get; set; }
        public int EventType { get; set; }
        public bool Successful { get; set; }
        public LocalNetworkEventArgs() {  }
    }

    public delegate void LocalNetworkClosedEventHandler(Connection connection);



    public delegate void LocalNetworkIncidentRequestHandler(NetworkSARTaskRequest e);

    public delegate void LocalNetworkIncomingIncidentEventHandler(WFIncident incident);

    public delegate void LocalNetworkIncomingSendObjectEventHandler(NetworkSendObject obj);

    

}
