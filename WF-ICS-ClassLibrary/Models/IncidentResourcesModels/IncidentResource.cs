using ProtoBuf;
using System;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class IncidentResource : SyncableItem, ICloneable
    {
        [ProtoMember(5)] private string _ResourceName;
        [ProtoMember(6)] private string _Kind;
        [ProtoMember(7)] private string _Type;
        [ProtoMember(8)] private string _ResourceIdentifier;
        [ProtoMember(9)] private int _NumberOfPeople;
        [ProtoMember(10)] private int _NumberOfVehicles;
        [ProtoMember(11)] private string _LeaderName;
        [ProtoMember(12)] private string _Contact;
        [ProtoMember(13)] private int _UniqueIDNum;
        [ProtoMember(14)] private string _ResourceType;
        [ProtoMember(15)] private Guid _ParentResourceID;
        [ProtoMember(16)] private string _AgencyName;

        public string ResourceName { get => _ResourceName; set => _ResourceName = value; }
        public string Kind { get => _Kind; set => _Kind = value; }
        public string Type { get => _Type; set => _Type = value; }
        public string ResourceIdentifier { get => _ResourceIdentifier; set => _ResourceIdentifier = value; }
        public int NumberOfPeople { get => _NumberOfPeople; set => _NumberOfPeople = value; }
        public int NumberOfVehicles { get => _NumberOfVehicles; set => _NumberOfVehicles = value; }

        public string LeaderName { get => _LeaderName; set => _LeaderName = value; }
        public string Contact { get => _Contact; set => _Contact = value; }
        public int UniqueIDNum { get => _UniqueIDNum; set => _UniqueIDNum = value; }
        public string ResourceType { get => _ResourceType; set => _ResourceType = value; }
        public Guid ParentResourceID { get => _ParentResourceID; set => _ParentResourceID = value; }

        public string UniqueIDNumWithPrefix
        {
            get
            {
                switch (ResourceType)
                {
                    case "Personnel": return "P" + UniqueIDNum;
                    case "Vehicle": return "V" + UniqueIDNum;
                    case "Equipment": return "E" + UniqueIDNum;
                    case "Crew": return "C" + UniqueIDNum;
                    case "Heavy Equipment Crew": return "C" + UniqueIDNum;
                    case "Aircraft": return "A" + UniqueIDNum;
                    default: return UniqueIDNum.ToString();
                }
            }
        }
        public string NameWithKindAndType
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ResourceName);
                if (!string.IsNullOrEmpty(Kind) || !string.IsNullOrEmpty(Type)) { sb.Append(" - "); }
                if (!string.IsNullOrEmpty(Kind))
                {
                    sb.Append(Kind);
                    if (!string.IsNullOrEmpty(Type)) { sb.Append(" / "); }
                }
                if (!string.IsNullOrEmpty(Type)) { sb.Append(Type); }

                return sb.ToString();
            }
        }

        public string AgencyName { get => _AgencyName; set => _AgencyName = value; }

        public IncidentResource()
        {
            ID = Guid.NewGuid();
            Active = true;
            LastUpdatedUTC = DateTime.UtcNow;
        }
        public IncidentResource Clone()
        {
            IncidentResource cloneTo = this.MemberwiseClone() as IncidentResource;

            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
