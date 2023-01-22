using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class TeamAssignment : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _ResourceName;
        [ProtoMember(3)] private string _LeaderName;
        [ProtoMember(4)] private Guid _LeaderPersonID;
        [ProtoMember(5)] private int _NumberOfPersons;
        [ProtoMember(6)] private List<Guid> _AssignedMemberIDs;
        [ProtoMember(7)] private string _Contact;
        [ProtoMember(8)] private string _ReportingLocation;
        [ProtoMember(9)] private string _SpecialEquipment;
        [ProtoMember(10)] private string _Remarks;
        [ProtoMember(11)] private string _TacticalAssignment;
        [ProtoMember(12)] private string _SpecialInstructions;
        [ProtoMember(13)] private Guid _ReportsToRoleID;
        [ProtoMember(14)] private int _ResourceIDNumber;
        [ProtoMember(15)] private List<Guid> _CommsPlanItemIDs;
        [ProtoMember(16)] private TeamStatus _currentStatus;
        [ProtoMember(17)] private List<Guid> _AssignedToolIDs;
        [ProtoMember(18)] private string _AssignmentType;
        [ProtoMember(19)] private DateTime _LastUpatedUTC;
        [ProtoMember(20)] private int _OpPeriod;
        [ProtoMember(21)] private bool _Active;




        public TeamAssignment() { 
            ID = Guid.NewGuid();
            Active = true;
            currentStatus = TeamAssignmentTools.GetStatusByID(0);
            AssignedMemberIDs= new List<Guid>();
            _CommsPlanItemIDs = new List<Guid>();
            _AssignedToolIDs = new List<Guid>();

        }

        public Guid ID { get => _ID; set => _ID = value; }
        public string ResourceName { get => _ResourceName; set => _ResourceName = value; }
        public string LeaderName { get => _LeaderName; set => _LeaderName = value; }
        public Guid LeaderPersonID { get => _LeaderPersonID; set => _LeaderPersonID = value; }
        public int NumberOfPersons { get => _NumberOfPersons; set => _NumberOfPersons = value; }
        public List<Guid> AssignedMemberIDs { get => _AssignedMemberIDs; set => _AssignedMemberIDs = value; }
        public string Contact { get => _Contact; set => _Contact = value; }
        public string ReportingLocation { get => _ReportingLocation; set => _ReportingLocation = value; }
        public string SpecialEquipment { get => _SpecialEquipment; set => _SpecialEquipment = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public string TacticalAssignment { get => _TacticalAssignment; set => _TacticalAssignment = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public Guid ReportsToRoleID { get => _ReportsToRoleID; set => _ReportsToRoleID = value; }
        public int ResourceIDNumber { get => _ResourceIDNumber; set => _ResourceIDNumber = value; }
        public List<Guid> CommsPlanItemIDs { get => _CommsPlanItemIDs; set => _CommsPlanItemIDs = value; }
        public TeamStatus currentStatus { get => _currentStatus; set {  _currentStatus = value; } }
        public string currentStatusName { get { if (currentStatus != null) { return currentStatus.StatusName; } else { return null; } } }
        public List<Guid> AssignedToolIDs { get => _AssignedToolIDs; set => _AssignedToolIDs = value; }
        public string AssignmentType { get => _AssignmentType; set => _AssignmentType = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        
        public string FullResourceID { get => ResourceIDNumber + " " + ResourceName; }
        public bool Active { get => _Active; set => _Active = value; }



        public TeamAssignment Clone()
        {
            TeamAssignment cloneTo = this.MemberwiseClone() as TeamAssignment;
            cloneTo.currentStatus = currentStatus.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }

    [ProtoContract]
    [Serializable]
    public class TeamStatus : ICloneable
    {

        [ProtoMember(1)] private int _StatusID;
        [ProtoMember(2)] private string _StatusName;
        [ProtoMember(3)] private bool _Active;

        public int StatusID { get => _StatusID; set => _StatusID = value; }
        public string StatusName { get => _StatusName; set => _StatusName = value; }
        public bool Active { get => _Active; set => _Active = value; }


        public TeamStatus() { }
        public TeamStatus(int id, string name, bool active) { StatusID = id; StatusName = name; Active = active; }


       

        public TeamStatus Clone()
        {
            return this.MemberwiseClone() as TeamStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }



    public static class TeamAssignmentTools
    {
        public static TeamStatus GetStatusByID(int id)
        {
            List<TeamStatus> allStatuses = GetAllTeamStatuses();
            if (allStatuses.Where(o => o.StatusID == id).Any())
            {
                return allStatuses.Where(o => o.StatusID == id).First();
            }
            else { return new TeamStatus(); }
        }

        public static List<TeamStatus> GetAllTeamStatuses()
        {
            List<TeamStatus> statuses = new List<TeamStatus>();
            statuses.Add(new TeamStatus(0, "Planned", false));
            statuses.Add(new TeamStatus(1, "Pre-mission prep", true));
            statuses.Add(new TeamStatus(2, "Travel to assignment", true));
            statuses.Add(new TeamStatus(3, "Execution", true));
            statuses.Add(new TeamStatus(4, "Returning from assignment", true));
            statuses.Add(new TeamStatus(5, "Post-mission procedures", true));
            statuses.Add(new TeamStatus(6, "Needs Transport", true));
            statuses.Add(new TeamStatus(8, "Needs Attention", true));
            statuses.Add(new TeamStatus(7, "Complete", false));

            return statuses;
        }

        public static List<TeamStatus> GetMemberAvailableStatuses()
        {
            int[] ids = { 4, 5, 7 };
            List<TeamStatus> statuses = GetAllTeamStatuses();
            statuses = statuses.Where(o => ids.Contains(o.StatusID)).ToList();

            return statuses;
        }

    }
}
