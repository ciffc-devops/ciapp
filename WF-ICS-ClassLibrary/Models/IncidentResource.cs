using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class IncidentResource
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private bool _Active;
        [ProtoMember(3)] private int _OpPeriod;
        [ProtoMember(4)] private DateTime _LastUpatedUTC;
        [ProtoMember(5)] private string _ResourceName;
        [ProtoMember(6)] private string _Kind;
        [ProtoMember(7)] private string _Type;
        [ProtoMember(8)] private string _ResourceIdentifier;

        public Guid ID { get { return _ID; } set => _ID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }
        public string ResourceName { get => _ResourceName; set => _ResourceName = value; }
        public string Kind { get => _Kind; set => _Kind = value; }
        public string Type { get => _Type; set => _Type = value; }
        public string ResourceIdentifier { get => _ResourceIdentifier; set => _ResourceIdentifier = value; }

        public IncidentResource()
        {
            ID = Guid.NewGuid();
            Active = true;
            LastUpdatedUTC = DateTime.UtcNow;
        }

    }
}
