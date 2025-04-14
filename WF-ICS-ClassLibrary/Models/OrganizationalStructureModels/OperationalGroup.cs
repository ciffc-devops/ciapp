using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class OperationalGroup : IncidentResource, ICloneable
    {

        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private Guid _ParentID; //Refers to the ID of the operational group this reports to
        [ProtoMember(4)] private string _ParentName;
        [ProtoMember(5)] private string _GroupType; //could be: Branch, Division, Task Force, Strike Team, Group, Single Resource    
        [ProtoMember(7)] private Guid _LeaderICSRoleID;
        [ProtoMember(8)] private string _LeaderICSRoleName;
        [ProtoMember(9)] private Guid _LeaderID; //Individual ID



        [ProtoMember(18)] private string _ShortRemarks;  //used for task forces, strike teams, groups
        [ProtoMember(19)] private string _Comments; //used for task forces, strike teams, groups
        [ProtoMember(20)] private string _TacticalAssignment;//used for branches, divisions
        [ProtoMember(21)] private string _SpecialInstructions;//used for branches, divisions
        [ProtoMember(22)] private List<Guid> _CommsPlanItemIDs; //used for branches, divisions
        [ProtoMember(23)] private string _ResourceID;
        [ProtoMember(24)] private string _BoxText;

        [ProtoMember(25)] private List<OperationalGroupResourceListing> _ResourceListing = new List<OperationalGroupResourceListing>();



        [ProtoMember(26)] private Guid _PreparedByRoleID;
        [ProtoMember(27)] private Guid _PreparedByResourceID;
        [ProtoMember(28)] private string _PreparedByResourceName;
        [ProtoMember(29)] private string _PreparedByRoleName;
        [ProtoMember(30)] private Guid _ApprovedByRoleID;
        [ProtoMember(31)] private Guid _ApprovedByResourceID;
        [ProtoMember(32)] private string _ApprovedByResourceName;
        [ProtoMember(33)] private string _ApprovedByRoleName;
        [ProtoMember(34)] private DateTime _DatePrepared;
        [ProtoMember(35)] private DateTime _DateApproved;


        private int _Depth;
        private int _SpanOfControl;


        public OperationalGroup() { ID = Guid.NewGuid(); CommsPlanItemIDs = new List<Guid>(); Active = true; }
        public OperationalGroup(Guid id) { ID = id; CommsPlanItemIDs = new List<Guid>(); Active = true; }


        public string ResourceID { get => _ResourceID; set => _ResourceID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public new string ResourceName
        {
            get
            {
                if (IsBranch && (Name != null && Name.Length > 3)) { return Name + " Branch"; }
                if (IsBranch && (Name == null || !Name.Contains("Branch"))) { return "Branch " + Name; }
                if (IsDivision && (Name == null || !Name.Contains("Division"))) { return "Division " + Name; }
                if (IsGroup && (Name == null || !Name.Contains("Group"))) { return Name + " Group"; }
                if (IsStrikeTeam && (Name == null || !Name.Contains("Strike Team"))) { return GroupType + " " + Name; }
                if (IsTaskForce && (Name == null || !Name.Contains("Task Force"))) { return GroupType + " " + Name; }
                else { return Name; }
            }
        }
        public string ResourceNameWithDepth
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < Depth - 1; x++) { sb.Append(" .. "); }
                sb.Append(ResourceName);
                return sb.ToString();
            }
        }


        public Guid ParentID { get => _ParentID; set => _ParentID = value; }
        public string ParentName { get => _ParentName; set => _ParentName = value; }
        public string ParentNameWithDepth
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < Depth - 1; x++) { sb.Append(" .. "); }
                sb.Append(ParentName);
                return sb.ToString();
            }
        }
        public string GroupType { get => _GroupType; set => _GroupType = value; }
        public bool IsBranchOrDiv { get => IsBranch || IsDivision || IsGroup;                }
        public bool IsBranch { get => GroupType.Equals("Branch"); }
        public bool IsDivision { get => GroupType.Equals("Division"); }
        public bool IsStrikeTeam { get => GroupType.Equals("Strike Team"); }
        public bool IsTaskForce { get => GroupType.Equals("Task Force"); }
        public bool IsGroup { get => GroupType.Equals("Group"); }


        public Guid LeaderICSRoleID { get => _LeaderICSRoleID; set => _LeaderICSRoleID = value; }
        public string LeaderICSRoleName { get => _LeaderICSRoleName; set => _LeaderICSRoleName = value; }

        public Guid LeaderID { get => _LeaderID; set => _LeaderID = value; }
        public List<Guid> CommsPlanItemIDs { get => _CommsPlanItemIDs; set => _CommsPlanItemIDs = value; }

        public string ShortRemarks { get => _ShortRemarks; set => _ShortRemarks = value; }
        public string TacticalAssignment { get => _TacticalAssignment; set => _TacticalAssignment = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public string BoxText { get => _BoxText; set => _BoxText = value; }

        public int Depth { get => _Depth; set => _Depth = value; }
        public int SpanOfControl { get => _SpanOfControl; set => _SpanOfControl = value; }

        public List<OperationalGroupResourceListing> ResourceListing { get => _ResourceListing; set => _ResourceListing = value; }
        public List<OperationalGroupResourceListing> ActiveResourceListing { get => _ResourceListing.Where(o => o.Active).ToList(); }



        public Guid PreparedByRoleID { get => _PreparedByRoleID; set => _PreparedByRoleID = value; }
        public Guid PreparedByResourceID { get => _PreparedByResourceID; set => _PreparedByResourceID = value; }
        public string PreparedByResourceName { get => _PreparedByResourceName; set => _PreparedByResourceName = value; }
        public string PreparedByRoleName { get => _PreparedByRoleName; set => _PreparedByRoleName = value; }
        public string PreparedByNameWithRole
        {
            get
            {
                StringBuilder from = new StringBuilder();
                if (!string.IsNullOrEmpty(PreparedByResourceName))
                {
                    from.Append(PreparedByResourceName);
                    if (!string.IsNullOrEmpty(PreparedByRoleName)) { from.Append(" - "); }
                }
                if (!string.IsNullOrEmpty(PreparedByRoleName)) { from.Append(PreparedByRoleName); }
                return from.ToString();
            }
        }


        //This content is a duplicate of that found in ICSFormData, needed here because OpGroups are both resources and the basis of 204 forms
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }
        public Guid ApprovedByResourceID { get => _ApprovedByResourceID; set => _ApprovedByResourceID = value; }
        public string ApprovedByResourceName { get => _ApprovedByResourceName; set => _ApprovedByResourceName = value; }
        public string ApprovedByRoleName { get => _ApprovedByRoleName; set => _ApprovedByRoleName = value; }

        public string ApprovedByNameWithRole
        {
            get
            {
                StringBuilder from = new StringBuilder();
                if (!string.IsNullOrEmpty(ApprovedByResourceName))
                {
                    from.Append(ApprovedByResourceName);
                    if (!string.IsNullOrEmpty(ApprovedByRoleName)) { from.Append(" - "); }
                }
                if (!string.IsNullOrEmpty(ApprovedByRoleName)) { from.Append(ApprovedByRoleName); }
                return from.ToString();
            }
        }

        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public DateTime DateApproved { get => _DateApproved; set => _DateApproved = value; }


        public void SetApprovedBy(ICSRole role)
        {
            if (role != null)
            {
                ApprovedByRoleID = role.ID;
                ApprovedByResourceID = role.IndividualID;
                ApprovedByResourceName = role.IndividualName;
                ApprovedByRoleName = role.RoleName;
            }
        }

        public void SetPreparedBy(ICSRole role)
        {
            if (role != null)
            {
                PreparedByRoleID = role.ID;
                PreparedByResourceID = role.IndividualID;
                PreparedByResourceName = role.IndividualName;
                PreparedByRoleName = role.RoleName;
            }
        }


        public OperationalGroup Clone()
        {
            OperationalGroup cloneTo = this.MemberwiseClone() as OperationalGroup;
            cloneTo.ResourceListing = new List<OperationalGroupResourceListing>();
            foreach (OperationalGroupResourceListing listing in ResourceListing) { cloneTo.ResourceListing.Add(listing.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
