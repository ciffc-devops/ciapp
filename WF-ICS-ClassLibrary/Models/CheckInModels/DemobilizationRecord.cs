using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class DemobilizationRecord : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private Guid _SignInRecordID;
        [ProtoMember(3)] private Guid _ResourceID;
        [ProtoMember(4)] private DateTime _DemobDate;
        [ProtoMember(5)] private string _DemobLocation;
        [ProtoMember(6)] private DateTime _DebriefDate;
        [ProtoMember(7)] private string _DebriefLocation;
        [ProtoMember(8)] private bool _InventoryReconciled;
        [ProtoMember(9)] private bool _DiscrepanciesWithSupply;
        [ProtoMember(10)] private bool _DiscrepanciesWithFacilities;
        [ProtoMember(11)] private bool _DiscrepanciesWithFinance;
        [ProtoMember(12)] private bool _ICS211Completed;
        [ProtoMember(13)] private string _TravelTimeToHomeUnit;
        [ProtoMember(14)] private bool _Active;
        [ProtoMember(15)] private int _OpPeriod;
        [ProtoMember(16)] private DateTime _LastUpdatedUTC;
        [ProtoMember(17)] private bool _PerformanceRatingCompleted;


        public DemobilizationRecord() { ID = Guid.NewGuid(); Active = true; }


        public Guid ID { get => _ID; set => _ID = value; }
        public Guid SignInRecordID { get => _SignInRecordID; set => _SignInRecordID = value; }
        public Guid ResourceID { get => _ResourceID; set => _ResourceID = value; }
        public DateTime DemobDate { get => _DemobDate; set => _DemobDate = value; }
        public string DemobLocation { get => _DemobLocation; set => _DemobLocation = value; }
        public DateTime DebriefDate { get => _DebriefDate; set => _DebriefDate = value; }
        public string DebriefLocation { get => _DebriefLocation; set => _DebriefLocation = value; }
        public bool InventoryReconciled { get => _InventoryReconciled; set => _InventoryReconciled = value; }
        public bool DiscrepanciesWithSupply { get => _DiscrepanciesWithSupply; set => _DiscrepanciesWithSupply = value; }
        public bool DiscrepanciesWithFacilities { get => _DiscrepanciesWithFacilities; set => _DiscrepanciesWithFacilities = value; }
        public bool DiscrepanciesWithFinance { get => _DiscrepanciesWithFinance; set => _DiscrepanciesWithFinance = value; }
        public bool ICS211Completed { get => _ICS211Completed; set => _ICS211Completed = value; }
        public string TravelTimeToHomeUnit { get => _TravelTimeToHomeUnit; set => _TravelTimeToHomeUnit = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool PerformanceRatingCompleted { get => _PerformanceRatingCompleted; set => _PerformanceRatingCompleted = value; }


        public DemobilizationRecord Clone()
        {
            DemobilizationRecord cloneTo = this.MemberwiseClone() as DemobilizationRecord;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
