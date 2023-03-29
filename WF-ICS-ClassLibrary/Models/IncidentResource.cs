using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
        [ProtoMember(9)] private int _NumberOfPeople;
        [ProtoMember(10)] private int _NumberOfVehicles;
        [ProtoMember(11)] private string _LeaderName;
        [ProtoMember(12)] private string _Contact;
        [ProtoMember(13)] private int _UniqueIDNum;
        [ProtoMember(14)] private string _ResourceType;
        [ProtoMember(15)] private Guid _ParentResourceID;

        public Guid ID { get { return _ID; } set => _ID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }
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

        public IncidentResource()
        {
            ID = Guid.NewGuid();
            Active = true;
            LastUpdatedUTC = DateTime.UtcNow;
        }

    }

    public static class IncidentResourceTools
    {
        public static List<IncidentResource> GetAllResources(this WFIncident incident, int OpPeriod)
        {
            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(incident.GetCurrentlySignedInPersonnel(OpPeriod));
            resources.AddRange(incident.allVehicles.Where(o=>o.Active && o.OpPeriod == OpPeriod));
            resources.AddRange(incident.AllOperationalSubGroups.Where(o => o.Active && o.OpPeriod == OpPeriod));
            return resources;
        }
    }
}
