using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class Crew : IncidentResource, ICloneable
    {
        [ProtoMember(1)] private Guid _OperationalGroupID;
        [ProtoMember(2)] private Guid _LeaderID;
        [ProtoMember(4)] private string _Transport;
        [ProtoMember(5)] private string _Email;
        [ProtoMember(6)] private string _Phone;
        [ProtoMember(7)] private List<OperationalGroupResourceListing> _ResourceListing = new List<OperationalGroupResourceListing>();
        [ProtoMember(8)] private bool _IsEquipmentCrew;

        public Crew() { this.ResourceType = "Crew"; this.Type = "Type 1"; }

        public Guid OperationalGroupID { get => _OperationalGroupID; set => _OperationalGroupID = value; }
        public Guid LeaderID { get => _LeaderID; set => _LeaderID = value; }
        public string Transport { get => _Transport; set => _Transport = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public List<OperationalGroupResourceListing> ResourceListing { get => _ResourceListing; set => _ResourceListing = value; }
        public List<OperationalGroupResourceListing> ActiveResourceListing { get => _ResourceListing.Where(o => o.Active).ToList(); }
        public bool IsEquipmentCrew { get => _IsEquipmentCrew; set { _IsEquipmentCrew = value; if (value) { this.ResourceType = "Heavy Equipment Crew"; } else { this.ResourceType = "Crew"; } } }


        public void UpsertResourceListing(OperationalGroupResourceListing listing)
        {
            ResourceListing = ResourceListing.Where(o => o.ID != listing.ID).ToList();
            ResourceListing.Add(listing);
            NumberOfPeople = ResourceListing.Count(o => o.Active && (o.ResourceType.Equals("Personnel") || o.ResourceType.Equals("Operator")));
            NumberOfVehicles = ResourceListing.Count(o => o.Active && (o.ResourceType.Equals("Vehicle") || o.ResourceType.Equals("Equipment")));
            if (listing.IsLeader) { LeaderName = listing.LeaderName; LeaderID = listing.ResourceID; }
        }

        public Crew Clone()
        {
            Crew cloneTo = this.MemberwiseClone() as Crew;
            cloneTo.ResourceListing = new List<OperationalGroupResourceListing>();
            foreach (OperationalGroupResourceListing item in ResourceListing) { cloneTo.ResourceListing.Add(item.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
