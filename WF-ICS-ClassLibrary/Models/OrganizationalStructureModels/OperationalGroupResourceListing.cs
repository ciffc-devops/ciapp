using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class OperationalGroupResourceListing : IncidentResource, ICloneable
    {
        [ProtoMember(2)] private Guid _OperationalGroupID;
        [ProtoMember(3)] private Guid _ResourceID; //References a person or equipment/vehicle
        [ProtoMember(4)] private string _ResourceType; //Personnel or Vehicle/Equipment
        [ProtoMember(5)] private string _Role; //the role this resource plays within its sub group e.g. leader, crew


        public OperationalGroupResourceListing() { Active = true; ResourceID = Guid.NewGuid(); }

        public Guid OperationalGroupID { get => _OperationalGroupID; set => _OperationalGroupID = value; }
        public Guid ResourceID { get => _ResourceID; set => _ResourceID = value; }
     /*
        public string ResourceType
        {
            get => _ResourceType;
            set
            {
                _ResourceType = value;
                if (ResourceType.Equals("Vehicle") || ResourceType.Equals("Equipment")) { NumberOfVehicles = 1; NumberOfPeople = 0; }
                else if (ResourceType.Equals("Personnel") || ResourceType.Equals("Operator")) { NumberOfPeople = 1; NumberOfVehicles = 0; }
            }
        }*/
        public string Role { get => _Role; set => _Role = value; }
        public bool IsLeader { get { if (!string.IsNullOrEmpty(Role)) { return Role.Contains("Leader"); } else { return false; } } }



        public OperationalGroupResourceListing Clone()
        {
            OperationalGroupResourceListing cloneTo = this.MemberwiseClone() as OperationalGroupResourceListing;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
