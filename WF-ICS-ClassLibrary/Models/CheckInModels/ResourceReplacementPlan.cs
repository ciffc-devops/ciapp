using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class ResourceReplacementPlan : SyncableItem, ICloneable
    {

        [ProtoMember(1)] private string _ResourceName;
        [ProtoMember(2)] private string _Kind;
        [ProtoMember(3)] private string _Assignment;
        [ProtoMember(4)] private DateTime _EstimatedArrival;
        [ProtoMember(5)] private string _HomeArea;
        [ProtoMember(6)] private string _Transportation;
        [ProtoMember(7)] private string _OrderNumber;
        [ProtoMember(8)] private string _CheckInLocation;
        [ProtoMember(9)] private string _Comments;
        [ProtoMember(10)] private Guid _ReplacementForCheckInID;
        [ProtoMember(11)] private string _ReplacedResourceName;
        [ProtoMember(12)] private string _ResourceVariety;


        public string ResourceName { get => _ResourceName; set => _ResourceName = value; }
        public string Kind { get => _Kind; set => _Kind = value; }
        public string Assignment { get => _Assignment; set => _Assignment = value; }
        public DateTime EstimatedArrival { get => _EstimatedArrival; set => _EstimatedArrival = value; }
        public string HomeArea { get => _HomeArea; set => _HomeArea = value; }
        public string Transportation { get => _Transportation; set => _Transportation = value; }
        public string OrderNumber { get => _OrderNumber; set => _OrderNumber = value; }
        public string CheckInLocation { get => _CheckInLocation; set => _CheckInLocation = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public Guid ReplacementForCheckInID { get => _ReplacementForCheckInID; set => _ReplacementForCheckInID = value; }
        public string ReplacedResourceName { get => _ReplacedResourceName; set => _ReplacedResourceName = value; }
        public string ResourceVariety { get => _ResourceVariety; set => _ResourceVariety = value; }


        public ResourceReplacementPlan Clone()
        {
            ResourceReplacementPlan cloneTo = this.MemberwiseClone() as ResourceReplacementPlan;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
