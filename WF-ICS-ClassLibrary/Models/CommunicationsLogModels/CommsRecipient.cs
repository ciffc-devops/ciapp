using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CommsRecipient
    {
        [ProtoMember(1)]
        public Guid RecipientID { get; set; }
        [ProtoMember(2)]
        public string RecipientName { get; set; }
        public CommsRecipient() { }
        public CommsRecipient(Guid id, string name) { RecipientID = id; RecipientName = name; }
    }
}
