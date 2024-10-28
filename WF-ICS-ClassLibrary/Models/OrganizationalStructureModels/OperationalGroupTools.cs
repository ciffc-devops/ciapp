using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
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
                    
                        NewRole.RoleName = NewRole.BaseRoleName.Replace("Branch", record.ResourceName);
                    
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


        public static List<IncidentResource> GetUncommittedResources(this Incident incident, int OpPeriod)
        {
            List<IncidentResource> resources = new List<IncidentResource>();
            OperationalPeriod op = incident.AllOperationalPeriods.First(o=>o.PeriodNumber == OpPeriod);
            foreach (CheckInRecord rec in incident.AllCheckInRecords.Where(o => o.CheckedInThisTime(op.PeriodMid) && !o.IsVisitor))
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

        public static bool GetIsResourceCurrentlyAssigned(this Incident incident, int OpPeriod, Guid ResourceID)
        {
            if (ResourceID == Guid.Empty) { return false; }
            if (incident.ActiveOperationalSubGroups.Any(o => o.ActiveResourceListing.Count(r => r.ResourceID == ResourceID) > 0 && o.OpPeriod == OpPeriod)) { return true; }
            if (incident.ActiveOperationalGroups.Any(o => o.ActiveResourceListing.Count(r => r.ResourceID == ResourceID) > 0 && o.OpPeriod == OpPeriod)) { return true; }
            if (incident.allOrgCharts.Any(o => o.OpPeriod == OpPeriod) && incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod).ActiveRoles.Any(o => o.IndividualID == ResourceID)) { return true; }
            if (incident.ActiveIncidentVehicles.Any(o => o.OperatorID == ResourceID)) { return true; }
            return false;
        }

        public static void UpdateOperationalGroupCounts(this Incident incident, int OpPeriod)
        {
            incident.SetOpGroupDepths(OpPeriod);
            foreach (Crew sub in incident.AllOperationalSubGroups)
            {
                incident.UpdateThisGroupCount(sub);
            }
            foreach (OperationalGroup grp in incident.ActiveOperationalGroups.OrderByDescending(o => o.Depth))
            {
                incident.UpdateThisGroupCount(grp);
            }
        }

        public static void UpdateThisGroupCount(this Incident incident, OperationalGroup grp)
        {
            grp.NumberOfPeople = grp.ActiveResourceListing.Sum(o => o.NumberOfPeople);
            grp.NumberOfPeople += incident.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == grp.ID).Sum(o => o.NumberOfPeople);
            grp.NumberOfPeople += incident.ActiveOperationalGroups.Where(o => o.ParentID == grp.LeaderICSRoleID).Sum(o => o.NumberOfPeople);

            grp.NumberOfVehicles = grp.ActiveResourceListing.Sum(o => o.NumberOfVehicles);
            grp.NumberOfVehicles += incident.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == grp.ID).Sum(o => o.NumberOfVehicles);
            grp.NumberOfVehicles += incident.ActiveOperationalGroups.Where(o => o.ParentID == grp.LeaderICSRoleID).Sum(o => o.NumberOfVehicles);
        }
        public static void UpdateThisGroupCount(this Incident incident, Crew sub)
        {
            sub.NumberOfPeople = sub.ActiveResourceListing.Count(o => (o.ResourceType.Equals("Personnel") || o.ResourceType.Equals("Operator")));
            sub.NumberOfVehicles = sub.ActiveResourceListing.Count(o => (o.ResourceType.Equals("Vehicle") || o.ResourceType.Equals("Equipment")));

        }

        public static List<IncidentResource> GetReportingResources(this Incident incident, Guid OpGroupID, bool expandSubResources = false)
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


        public static ICSRole GetICSRoleByOpGroupID(this Incident incident, Guid OpGroupID)
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
        public static OperationalGroup GetOpGroupByID(this Incident incident, Guid OpGroupID)
        {
            if (incident.ActiveOperationalGroups.Any(o => o.ID == OpGroupID)) { return incident.ActiveOperationalGroups.First(o => o.ID == OpGroupID); }
            return null;
        }


        public static void SetOpGroupDepths(this Incident incident, int OpPeriod)
        {
            foreach (OperationalGroup grp in incident.ActiveOperationalGroups.Where(o => o.OpPeriod == OpPeriod))
            {
                grp.Depth = grp.GetOpGroupDepth(incident);
                grp.SpanOfControl = incident.ActiveOperationalGroups.Count(o => o.OpPeriod == OpPeriod && o.ParentID == grp.LeaderICSRoleID);
            }
        }

        public static int GetOpGroupDepth(this OperationalGroup group, Incident incident)
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
