using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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




        /// <summary>
        /// This method will create all operational groups as needed for the given OpPeriod based on the ICS roles that exist in the org chart for that period.
        /// </summary>
        /// <param name="incident"></param>
        /// <param name="OpPeriodNumber"></param>
        public static void CreateAllOperationalGroupsAsNeeded(this Incident incident, int OpPeriodNumber)
        {
            if (incident.activeOrgCharts.Any(o => o.OpPeriod == OpPeriodNumber))
            {
                ICSRole OSC = incident.activeOrgCharts.FirstOrDefault(o => o.OpPeriod == OpPeriodNumber).ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.OpsChiefGenericID);

                if (OSC != null && !incident.ActiveOperationalGroups.Any(o => o.OpPeriod == OpPeriodNumber && o.LeaderICSRoleID == OSC.ID))
                {
                    OperationalGroup ops = OSC.CreateOpGroupFromRole("Operations Section");
                    OSC.OperationalGroupID = ops.ID;
                    ops.LeaderICSRoleID = OSC.ID;
                    ops.ParentID = Guid.Empty;   
                    Globals.incidentService.UpsertOperationalGroup(ops);

                    CreateAllOperationalGroupsAsNeeded(incident, OpPeriodNumber, OSC);

                }

            }
        }
        public static void CreateAllOperationalGroupsAsNeeded(this Incident incident, int OpPeriodNumber, ICSRole parentRole)
        {
            OperationalGroup parentGroup = incident.ActiveOperationalGroups.FirstOrDefault(o => o.ID == parentRole.OperationalGroupID);
            foreach (ICSRole role in incident.activeOrgCharts.FirstOrDefault(o => o.OpPeriod == OpPeriodNumber).ActiveRoles.Where(o => o.RequiresOperationalGroup && o.ReportsTo == parentRole.ID))
            {
                if (!incident.ActiveOperationalGroups.Any(o => o.OpPeriod == OpPeriodNumber && o.LeaderICSRoleID == role.ID))
                {
                    OperationalGroup grp = CreateOpGroupFromRole(role, string.Empty);
                    grp.ParentID = parentGroup.ID;
                    grp.ParentName = parentGroup.ResourceName;
                    Globals.incidentService.UpsertOperationalGroup(grp);

                    CreateAllOperationalGroupsAsNeeded(incident, OpPeriodNumber, role);
                }
            }

        }


        /// <summary>
        /// This function takes an ICS role and makes the corresponding operational group.  Note it doesn't currently set the op group ID that the new group will report to
        /// </summary>
        /// <param name="role"></param>
        /// <param name="OperationalGroupName"></param>
        /// <returns></returns>
        public static OperationalGroup CreateOpGroupFromRole(this ICSRole role, string OperationalGroupName)
        {
            OperationalGroup operationalGroup = new OperationalGroup();
            operationalGroup.OpPeriod = role.OpPeriod;
            operationalGroup.Active = true;
            operationalGroup.GroupType = role.GetOperationalGroupTypeFromICSRole();
            if (operationalGroup.GroupType.Equals("Section")) { operationalGroup.Name = "Operations Section"; }
            else if (string.IsNullOrEmpty(OperationalGroupName))
            {
                operationalGroup.Name = role.RoleName.RemoveGenericRoleTitle();
            }
            else { operationalGroup.Name = OperationalGroupName; }
            operationalGroup.LeaderICSRoleID = role.RoleID;
            operationalGroup.LeaderID = role.IndividualID;
            operationalGroup.LeaderICSRoleName = role.RoleName;
            operationalGroup.LeaderName = role.IndividualName;
           
            return operationalGroup;
        }

        private static string RemoveGenericRoleTitle(this string roleName)
        {
            if(roleName != null)
            {
                roleName = roleName.Replace("Branch Director", "");
                roleName = roleName.Replace("Group Supervisor", "");
                roleName = roleName.Replace("Division Supervisor", "");
                return roleName;
            }
            return string.Empty;
        }

        public static string GetOperationalGroupTypeFromICSRole(this ICSRole role)
        {
            if(role.GenericRoleID == Globals.OpsChiefGenericID) { return "Section"; }
            if (role.GenericRoleID == Globals.BranchDirectorGenericID || role.GenericRoleID == Globals.AirOpsDirectorGenericID) { return "Branch"; }
            if (role.GenericRoleID == Globals.DivisionSupervisorGenericID) { return "Division"; }
            if (role.GenericRoleID == Globals.GroupSupervisorGenericID) { return "Group"; }
            if (role.GenericRoleID == Globals.StrikeTeamLeaderGenericID) { return "Strike Team"; }
            if (role.GenericRoleID == Globals.TaskForceLeaderGenericID) { return "Task Force"; }

            if(role.RoleName.Contains("Branch")) { return "Branch"; }
            if (role.RoleName.Contains("Division")) { return "Division"; }
            if (role.RoleName.Contains("Group")) { return "Group"; }
            if (role.RoleName.Contains("Strike Team")) { return "Strike Team"; }
            if (role.RoleName.Contains("Task Force")) { return "Task Force"; }

            return null;
        }

        public static Guid GetOpGroupParentIDThroughOrgChart(this Incident incident, OperationalGroup opGroup)
        {

            if (opGroup != null && opGroup.LeaderICSRoleID != Guid.Empty)
            {
                OrganizationChart orgChart = incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod && o.Active);
                if (orgChart != null)
                {
                    ICSRole leader = orgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == opGroup.LeaderICSRoleID);
                    if (leader != null && leader.ReportsTo != Guid.Empty)
                    {
                        OperationalGroup parentGroup = incident.ActiveOperationalGroups.FirstOrDefault(o => o.LeaderICSRoleID == leader.ReportsTo);
                        if (parentGroup != null)
                        {
                            return parentGroup.ID;
                        }
                    }
                }
            }
            return Guid.Empty;
        }
        public static Guid GetICSReportsToThroughOpGroup(this Incident incident, ICSRole role)
        {
            if(role != null && role.OperationalGroupID != Guid.Empty)
            {
                OperationalGroup opGroup = incident.ActiveOperationalGroups.FirstOrDefault(o => o.ID == role.OperationalGroupID);
                if (opGroup != null)
                {
                    OperationalGroup ParentGroup = incident.ActiveOperationalGroups.FirstOrDefault(o => o.ID == opGroup.ParentID);
                    if (ParentGroup != null)
                    {
                        return ParentGroup.LeaderICSRoleID;
                    }
                }
            }
            /*
            if (opGroup != null && opGroup.LeaderICSRoleID != Guid.Empty)
            {
                OrganizationChart orgChart = incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod && o.Active);
                if (orgChart != null)
                {
                    ICSRole leader = orgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == opGroup.LeaderICSRoleID);
                    if (leader != null && leader.ReportsTo != Guid.Empty)
                    {
                        OperationalGroup parentGroup = incident.ActiveOperationalGroups.FirstOrDefault(o => o.LeaderICSRoleID == leader.ReportsTo);
                        if (parentGroup != null)
                        {
                            return parentGroup.ID;
                        }
                    }
                }
            }*/
            return Guid.Empty;
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
            if (group.GroupType == "Section") { depth = 1; }
            else if (incident.AllOperationalGroups.Any(o => o.ID == group.ParentID))
            {
                OperationalGroup parent = incident.AllOperationalGroups.First(o => o.ID == group.ParentID);
                depth += 1;
                while (parent.ParentID != Globals.OpsChiefGenericID && incident.AllOperationalGroups.Any(o => o.ID == parent.ParentID))
                {
                    depth += 1;
                    parent = incident.AllOperationalGroups.First(o => o.ID == parent.ParentID);

                }

            }
            return depth;
        }
    }
}
