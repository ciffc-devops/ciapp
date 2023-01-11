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
    public class SafetyPlan :  ICloneable
    {
        public SafetyPlan()
        {
            SafetyPlanTemplateID = System.Guid.NewGuid(); 
            PlanID = System.Guid.NewGuid();
            Active = true;
        }

        [ProtoMember(1)] private Guid _SafetyPlanTemplateID;
        [ProtoMember(2)] private string _HazardName;
        [ProtoMember(3)] private string _Description;
        [ProtoMember(4)] private string _Precautions;
        [ProtoMember(5)] private string _SpecialInstructions;


        [ProtoMember(8)] private bool _isUniversal;
        [ProtoMember(9)] private DateTime _LastUpdatedUTC;
        [ProtoMember(10)] private bool _active;
        [ProtoMember(11)] private Guid _OrganizationID;

        [ProtoMember(12)] private Guid _PlanID;
        [ProtoMember(13)] private string _TaskNumber;
        [ProtoMember(14)] private string _TaskName;
        [ProtoMember(15)] private string _TeamName;
        [ProtoMember(16)] private int _OpPeriod;
        [ProtoMember(17)] private DateTime _DatePrepared;
        [ProtoMember(18)] private string _PreparedBy;
        [ProtoMember(19)] private int _HazardNumber;
        [ProtoMember(20)] private Guid _TaskID;

      




        public Guid SafetyPlanTemplateID { get => _SafetyPlanTemplateID; set => _SafetyPlanTemplateID = value; }
        public string HazardName { get => _HazardName; set => _HazardName = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string Precautions { get => _Precautions; set => _Precautions = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }


        public bool Active { get { return _active; } set { _active = value; } }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }


        public Guid PlanID { get => _PlanID; set => _PlanID = value; }
        public string TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public string TaskName { get => _TaskName; set => _TaskName = value; }
        public string TeamName { get => _TeamName; set => _TeamName = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public int HazardNumber { get => _HazardNumber; set => _HazardNumber = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }


        public SafetyPlan Clone()
        {
            return this.MemberwiseClone() as SafetyPlan;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }



    }


    [ProtoContract]
    [Serializable]
    public class SafetyMessage
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(3)] private int _OpPeriod;
        [ProtoMember(4)] private string _Message;
        [ProtoMember(5)] private bool _SitePlanRequired;
        [ProtoMember(6)] private string _SitePlanLocation;
        [ProtoMember(7)] private string _ApprovedByName;
        [ProtoMember(8)] private string _ApprovedByRoleName;
        [ProtoMember(9)] private Guid _ApprovedByRoleID;
        [ProtoMember(10)] private Guid _SafetyTemplateID; 

        public SafetyMessage() { ID = Guid.NewGuid(); }


        public Guid ID { get => _ID; set => _ID = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string Message { get => _Message; set => _Message = value; }
        public bool SitePlanRequired { get => _SitePlanRequired; set => _SitePlanRequired = value; }
        public string SitePlanLocation { get => _SitePlanLocation; set => _SitePlanLocation = value; }
        public string ApprovedByName { get => _ApprovedByName; set => _ApprovedByName = value; }
        public string ApprovedByRoleName { get => _ApprovedByRoleName; set => _ApprovedByRoleName = value; }
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }
        public Guid SafetyTemplateID { get => _SafetyTemplateID; set => _SafetyTemplateID = value; }
    }
}
