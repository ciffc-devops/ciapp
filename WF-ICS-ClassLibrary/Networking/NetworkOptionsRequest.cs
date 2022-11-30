using NetworkCommsDotNet.Tools;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Networking
{
    [ProtoContract]
    public class NetworkOptionsRequest
    {

        public NetworkOptionsRequest() { RequestID = Guid.NewGuid(); }
        [ProtoMember(1)]
        public DateTime RequestDate { get; set; }
        [ProtoMember(2)]
        public Guid RequestID { get; set; }

        //for network reasons
        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        [ProtoMember(3)]
        string _sourceIdentifier;
        [ProtoMember(4)]
        public int RelayCount { get; set; }
        [ProtoMember(5)]
        public string SourceName { get; set; }
        [ProtoMember(6)]
        private string _RequestID;
        public string RequestIP { get => _RequestID; set => _RequestID = value; }
    }
}
