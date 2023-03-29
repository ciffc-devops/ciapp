using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class OperationalGroup : IncidentResource, ICloneable
    {

        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private Guid _ParentID;
        [ProtoMember(4)] private string _ParentName;
        [ProtoMember(5)] private string _GroupType; //could be: Branch, Division, Task Force, Strike Team, Group, Single Resource    
        [ProtoMember(7)] private Guid _LeaderICSRoleID;
        [ProtoMember(8)] private string _LeaderICSRoleName;
        [ProtoMember(9)] private Guid _LeaderID;


        [ProtoMember(13)] private string _PreparedByName;
        [ProtoMember(14)] private string _PreparedByPosition;
        [ProtoMember(15)] private Guid _PreparedByPositionID;

        [ProtoMember(18)] private string _ShortRemarks;  //used for task forces, strike teams, groups
        [ProtoMember(19)] private string _Comments; //used for task forces, strike teams, groups
        [ProtoMember(20)] private string _TacticalAssignment;//used for branches, divisions
        [ProtoMember(21)] private string _SpecialInstructions;//used for branches, divisions
        [ProtoMember(22)] private List<Guid> _CommsPlanItemIDs; //used for branches, divisions
        [ProtoMember(23)] private string _ResourceID;

        [ProtoMember(24)] private List<OperationalGroupResourceListing> _ResourceListing = new List<OperationalGroupResourceListing>();


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


    [Serializable]
    [ProtoContract]
    public class OperationalSubGroup : IncidentResource, ICloneable
    {
        [ProtoMember(1)] private Guid _OperationalGroupID;
        [ProtoMember(2)] private Guid _LeaderID;
        [ProtoMember(4)] private string _Transport;
        [ProtoMember(5)] private string _Email;
        [ProtoMember(6)] private string _Phone;
        [ProtoMember(7)] private List<OperationalGroupResourceListing> _ResourceListing = new List<OperationalGroupResourceListing>();
        [ProtoMember(8)] private bool _IsEquipmentCrew;

        public OperationalSubGroup() { this.ResourceType = "Crew"; }

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

        public OperationalSubGroup Clone()
        {
            OperationalSubGroup cloneTo = this.MemberwiseClone() as OperationalSubGroup;
            cloneTo.ResourceListing = new List<OperationalGroupResourceListing>();
            foreach (OperationalGroupResourceListing item in ResourceListing) { cloneTo.ResourceListing.Add(item.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


    [ProtoContract]
    [Serializable]
    public class OperationalGroupResourceListing : IncidentResource, ICloneable
    {
        [ProtoMember(1)] private Guid _SubGroupID;
        [ProtoMember(2)] private Guid _OperationalGroupID;
        [ProtoMember(3)] private Guid _ResourceID; //References a person or equipment/vehicle
        [ProtoMember(4)] private string _ResourceType; //Personnel or Vehicle/Equipment
        [ProtoMember(5)] private string _Role; //the role this resource plays within its sub group e.g. leader, crew


        public OperationalGroupResourceListing() { Active = true; ResourceID = Guid.NewGuid(); }

        public Guid SubGroupID { get => _SubGroupID; set => _SubGroupID = value; }
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



    public static class OperationalGroupTools
    {

        public static string OperationalGroupsToCSV(List<ICSRole> roles, List<OperationalGroup> groups, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("Reports To"); csv.Append(delimiter);
            csv.Append("Name"); csv.Append(delimiter);
            csv.Append("Individual Name"); csv.Append(delimiter);
            csv.Append("Contact"); csv.Append(delimiter);
            csv.Append("Number of People"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);



            foreach (ICSRole item in roles)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 

                csv.Append("\""); csv.Append(item.ReportsToRoleName); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.IndividualName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                if (groups.Any(o => o.LeaderICSRoleID == item.RoleID))
                {
                    csv.Append("\""); csv.Append(groups.First(o => o.LeaderICSRoleID == item.RoleID).Contact.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(groups.First(o => o.LeaderICSRoleID == item.RoleID).NumberOfPeople); csv.Append("\""); csv.Append(delimiter);


                }
                else
                {
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);

                }
               

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

        public static string GetRoleNameFromGroup(this OperationalGroup record)
        {
            ICSRole NewRole = new ICSRole();



            if (record.GroupType.Equals("Branch"))
            {
                if (!string.IsNullOrEmpty(record.Name) && record.Name.Equals("Heavy Equipment"))
                {
                    NewRole = OrgChartTools.getGenericRoleByName("Heavy Equipment Branch Director");
                }
                else
                {
                    NewRole = OrgChartTools.getGenericRoleByName("Operations Branch Director");
                }
            }
            else if (record.GroupType.Equals("Division"))
            {
                NewRole = OrgChartTools.getGenericRoleByName("Division Supervisor");
            }
            else if (record.GroupType.Equals("Strike Team"))
            {
                NewRole = OrgChartTools.getGenericRoleByName("Strike Team Leader");
            }
            else if (record.GroupType.Equals("Task Force"))
            {
                NewRole = OrgChartTools.getGenericRoleByName("Task Force Leader");
            }
            else
            {
                NewRole.BaseRoleName = "Group Supervisor";
                NewRole.RoleName = "Group Supervisor";
                NewRole.SectionID = Globals.OpsChiefID;
                NewRole.IsOpGroupSup = true;
            }


            NewRole.OperationalGroupID = record.ID;

            switch (record.GroupType)
            {
                case "Branch":
                    if (record.Name.Length < 4)
                    {
                        NewRole.RoleName = NewRole.BaseRoleName.Replace("Branch", record.ResourceName);
                    }
                    NewRole.IsOpGroupSup = true;
                    break;
                case "Division":
                    NewRole.RoleName = NewRole.BaseRoleName.Replace("Division", record.ResourceName);
                    NewRole.IsOpGroupSup = true;
                    break;
                case "Task Force":
                    NewRole.RoleName = NewRole.BaseRoleName.Replace("Task Force", record.ResourceName);
                    NewRole.IsOpGroupSup = true;
                    break;
                case "Strike Team":
                    NewRole.RoleName = NewRole.BaseRoleName.Replace("Strike Team", record.ResourceName);
                    NewRole.IsOpGroupSup = true;
                    break;
                default:
                    NewRole.RoleName = record.ResourceName + " Supervisor";
                    break;
            }
            return NewRole.RoleName;
        }


        public static List<IncidentResource> GetUncommittedResources(this WFIncident incident, int OpPeriod)
        {
            List<IncidentResource> resources = new List<IncidentResource>();
            foreach (CheckInRecord rec in incident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod == OpPeriod && !o.IsVisitor))
            {
                if (rec.ParentRecordID == Guid.Empty && !incident.GetIsResourceCurrentlyAssigned(OpPeriod, rec.ResourceID))
                {
                    if (incident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resources.Add(incident.AllIncidentResources.First(o => o.ID == rec.ResourceID));

                    }

                    /*
                    if (rec.IsPerson && incident.IncidentPersonnel.Any(o => o.ID == rec.ResourceID && o.Active))
                    {
                        resources.Add(incident.IncidentPersonnel.First(o => o.ID == rec.ResourceID && o.Active));
                    }
                    else if (rec.IsCrew && incident.ActiveOperationalSubGroups.Any(o => o.ID == rec.ResourceID))
                    {
                        resources.Add(incident.ActiveOperationalSubGroups.First(o => o.ID == rec.ResourceID));
                    }
                    else if (rec.IsVehicle && incident.allVehicles.Any(o => o.ID == rec.ResourceID && o.Active))
                    {
                        resources.Add(incident.allVehicles.First(o => o.ID == rec.ResourceID && o.Active));
                    }*/
                }
            }
            resources = resources.OrderBy(o => o.Kind).ThenBy(o => o.Type).ThenBy(o => o.ResourceName).ToList();


            return resources;
        }

        public static bool GetIsResourceCurrentlyAssigned(this WFIncident incident, int OpPeriod, Guid ResourceID)
        {
            if (ResourceID == Guid.Empty) { return false; }
            if (incident.ActiveOperationalSubGroups.Any(o => o.ActiveResourceListing.Count(r => r.ResourceID == ResourceID) > 0 && o.OpPeriod == OpPeriod)) { return true; }
            if (incident.ActiveOperationalGroups.Any(o => o.ActiveResourceListing.Count(r => r.ResourceID == ResourceID) > 0 && o.OpPeriod == OpPeriod)) { return true; }
            if (incident.allOrgCharts.Any(o => o.OpPeriod == OpPeriod) && incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod).ActiveRoles.Any(o => o.IndividualID == ResourceID)) { return true; }
            if (incident.ActiveIncidentVehicles.Any(o => o.OperatorID == ResourceID)) { return true; }
            return false;
        }

        public static void UpdateOperationalGroupCounts(this WFIncident incident, int OpPeriod)
        {
            incident.SetOpGroupDepths(OpPeriod);
            foreach (OperationalSubGroup sub in incident.AllOperationalSubGroups)
            {
                incident.UpdateThisGroupCount(sub);
            }
            foreach (OperationalGroup grp in incident.ActiveOperationalGroups.OrderByDescending(o => o.Depth))
            {
                incident.UpdateThisGroupCount(grp);
            }
        }

        public static void UpdateThisGroupCount(this WFIncident incident, OperationalGroup grp)
        {
            grp.NumberOfPeople = grp.ActiveResourceListing.Sum(o => o.NumberOfPeople);
            grp.NumberOfPeople += incident.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == grp.ID).Sum(o => o.NumberOfPeople);
            grp.NumberOfPeople += incident.ActiveOperationalGroups.Where(o => o.ParentID == grp.LeaderICSRoleID).Sum(o => o.NumberOfPeople);

            grp.NumberOfVehicles = grp.ActiveResourceListing.Sum(o => o.NumberOfVehicles);
            grp.NumberOfVehicles += incident.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == grp.ID).Sum(o => o.NumberOfVehicles);
            grp.NumberOfVehicles += incident.ActiveOperationalGroups.Where(o => o.ParentID == grp.LeaderICSRoleID).Sum(o => o.NumberOfVehicles);
        }
        public static void UpdateThisGroupCount(this WFIncident incident, OperationalSubGroup sub)
        {
            sub.NumberOfPeople = sub.ActiveResourceListing.Count(o => (o.ResourceType.Equals("Personnel") || o.ResourceType.Equals("Operator")));
            sub.NumberOfVehicles = sub.ActiveResourceListing.Count(o => (o.ResourceType.Equals("Vehicle") || o.ResourceType.Equals("Equipment")));

        }

        public static List<IncidentResource> GetReportingResources(this WFIncident incident, Guid OpGroupID, bool expandSubResources = false)
        {

            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(incident.AllOperationalSubGroups.Where(o => o.Active && o.OperationalGroupID == OpGroupID));
            if (incident.AllOperationalGroups.Any(o => o.ID == OpGroupID)) { resources.AddRange(incident.AllOperationalGroups.First(o => o.ID == OpGroupID).ResourceListing); }
            if (incident.AllOperationalSubGroups.Any(o => o.ID == OpGroupID))
            {
                foreach (OperationalGroupResourceListing listing in incident.AllOperationalSubGroups.First(o => o.ID == OpGroupID).ResourceListing)
                {
                    if (incident.AllIncidentResources.Any(o => o.ID == listing.ResourceID))
                    {
                        resources.Add(incident.AllIncidentResources.First(o => o.ID == listing.ResourceID));
                    }
                }
            }

           
            return resources;
        }


        public static ICSRole GetICSRoleByOpGroupID(this WFIncident incident, Guid OpGroupID)
        {
            if (incident.ActiveOperationalGroups.Any(o => o.ID == OpGroupID))
            {
                OperationalGroup opGroup = incident.ActiveOperationalGroups.First(o => o.ID == OpGroupID);
                if (incident.allOrgCharts.Any(o => o.OpPeriod == opGroup.OpPeriod) && incident.allOrgCharts.First(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.Any(o => o.OperationalGroupID == OpGroupID))
                {
                    return incident.allOrgCharts.First(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.First(o => o.OperationalGroupID == OpGroupID);
                }

            }
            return null;
        }
        public static OperationalGroup GetOpGroupByID(this WFIncident incident, Guid OpGroupID)
        {
            if (incident.ActiveOperationalGroups.Any(o => o.ID == OpGroupID)) { return incident.ActiveOperationalGroups.First(o => o.ID == OpGroupID); }
            return null;
        }


        public static void SetOpGroupDepths(this WFIncident incident, int OpPeriod)
        {
            foreach (OperationalGroup grp in incident.ActiveOperationalGroups.Where(o => o.OpPeriod == OpPeriod))
            {
                grp.Depth = grp.GetOpGroupDepth(incident);
                grp.SpanOfControl = incident.ActiveOperationalGroups.Count(o => o.OpPeriod == OpPeriod && o.ParentID == grp.LeaderICSRoleID);
            }
        }

        public static int GetOpGroupDepth(this OperationalGroup group, WFIncident incident)
        {
            int depth = 1;
            if (group.ParentID == Globals.OpsChiefID) { depth = 1; }
            else if (incident.AllOperationalGroups.Any(o => o.LeaderICSRoleID == group.ParentID))
            {
                OperationalGroup parent = incident.AllOperationalGroups.First(o => o.LeaderICSRoleID == group.ParentID);
                depth += 1;
                while (parent.ParentID != Globals.OpsChiefID && incident.AllOperationalGroups.Any(o => o.LeaderICSRoleID == parent.ParentID))
                {
                    depth += 1;
                    parent = incident.AllOperationalGroups.First(o => o.LeaderICSRoleID == parent.ParentID);

                }

            }
            return depth;
        }
    }
}
