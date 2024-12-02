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


        [ProtoMember(13)] private string _PreparedByName;
        [ProtoMember(14)] private string _PreparedByPosition;
        [ProtoMember(15)] private Guid _PreparedByPositionID;

        [ProtoMember(18)] private string _ShortRemarks;  //used for task forces, strike teams, groups
        [ProtoMember(19)] private string _Comments; //used for task forces, strike teams, groups
        [ProtoMember(20)] private string _TacticalAssignment;//used for branches, divisions
        [ProtoMember(21)] private string _SpecialInstructions;//used for branches, divisions
        [ProtoMember(22)] private List<Guid> _CommsPlanItemIDs; //used for branches, divisions
        [ProtoMember(23)] private string _ResourceID;
        [ProtoMember(24)] private string _BoxText;

        [ProtoMember(25)] private List<OperationalGroupResourceListing> _ResourceListing = new List<OperationalGroupResourceListing>();


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
                if (GroupType.Equals("Branch") && (Name != null && Name.Length > 3)) { return Name + " Branch"; }
                if (GroupType.Equals("Branch") && (Name == null || !Name.Contains("Branch"))) { return "Branch " + Name; }
                if (GroupType.Equals("Division") && (Name == null || !Name.Contains("Division"))) { return "Division " + Name; }
                if (GroupType.Equals("Group") && (Name == null || !Name.Contains("Group"))) { return Name + " Group"; }
                if (GroupType.Equals("Strike Team") && (Name == null || !Name.Contains("Strike Team"))) { return GroupType + " " + Name; }
                if (GroupType.Equals("Task Force") && (Name == null || !Name.Contains("Task Force"))) { return GroupType + " " + Name; }
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
        public bool IsBranchOrDiv { get { if (GroupType.Equals("Branch") || GroupType.Equals("Division") || GroupType.Equals("Group")) { return true; }  return false; } }
        public Guid LeaderICSRoleID { get => _LeaderICSRoleID; set => _LeaderICSRoleID = value; }
        public string LeaderICSRoleName { get => _LeaderICSRoleName; set => _LeaderICSRoleName = value; }

        public Guid LeaderID { get => _LeaderID; set => _LeaderID = value; }
        public string PreparedByName { get => _PreparedByName; set => _PreparedByName = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public Guid PreparedByPositionID { get => _PreparedByPositionID; set => _PreparedByPositionID = value; }
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
