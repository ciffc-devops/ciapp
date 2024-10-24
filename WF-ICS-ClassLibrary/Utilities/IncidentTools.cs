using CoordinateSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class IncidentTools
    {

        public static List<Aircraft> GetActiveAircraft(this WFIncident incident, DateTime Date)
        {
            List<Aircraft> aircraft = new List<Aircraft>();

            aircraft.AddRange(incident.AllAircraft.Where(o => o.Active && incident.ResourceIsCheckedIn(o.ID, Date)));
            aircraft = aircraft.OrderBy(o => o.CompanyName).ThenBy(o => o.Registration).ToList();
            return aircraft;
        }
        public static List<Aircraft> GetActiveAircraft(this WFIncident incident, int OpPeriodNumber)
        {
            OperationalPeriod op = new OperationalPeriod();
            if (incident.AllOperationalPeriods.Any(o => o.PeriodNumber == OpPeriodNumber)) { op = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriodNumber); }
            else { op.PeriodStart = DateTime.Now; op.PeriodEnd = op.PeriodStart.AddHours(12); }
            return incident.GetActiveAircraft(op.PeriodMid);

        }


        public static List<TaskUpdate> MostRecentTaskUpdates(this WFIncident task, bool localOnly = false)
        {
            List<TaskUpdate> updatesToKeep = new List<TaskUpdate>();

            List<TaskUpdate> updatesToInspect = task.allTaskUpdates.OrderByDescending(o => o.LastUpdatedUTC).ToList();
            if (localOnly) { updatesToInspect = updatesToInspect.Where(o => string.IsNullOrEmpty(o.Source) || o.Source.Equals("local")).ToList(); }
            //filter as needed

            updatesToKeep = updatesToInspect.GroupBy(o => o.ItemID).Select(g => g.OrderByDescending(y => y.LastUpdatedUTC).FirstOrDefault()).ToList();
            return updatesToKeep;
        }

        public static DateTime LastNetworkTaskUpdate(this WFIncident task)
        {
            if (task.allTaskUpdates != null && task.allTaskUpdates.Any(o => !string.IsNullOrEmpty(o.Source) && o.Source.Equals("network")))
            {
                TaskUpdate lastNetwork = task.allTaskUpdates.Where(o => !string.IsNullOrEmpty(o.Source) && o.Source.Equals("network")).OrderByDescending(o => o.LastUpdatedUTC).FirstOrDefault();
                return lastNetwork.LastUpdatedUTC;
            }

            return DateTime.MinValue;

        }

        public static WFIncident CompressTaskUpdates(this WFIncident task)
        {
            WFIncident compressed = task.Clone();

            List<TaskUpdate> updatesToKeep = new List<TaskUpdate>();
            List<TaskUpdate> updatesToRemove = new List<TaskUpdate>();

            List<TaskUpdate> updatesToInspect = compressed.allTaskUpdates.OrderByDescending(o => o.LastUpdatedUTC).ToList();
            //filter as needed

            updatesToKeep = updatesToInspect.GroupBy(o => o.ItemID).Select(g => g.OrderByDescending(y => y.LastUpdatedUTC).FirstOrDefault()).ToList();
            compressed.allTaskUpdates = updatesToKeep;
            return compressed;
        }

      

        public static string getNameByRoleName(this WFIncident task, int Ops, string roleName, bool defaultUpChain = true)
        {
            string name = null;
            OrganizationChart chart = new OrganizationChart();
            if (task.allOrgCharts.Any(o => o.OpPeriod == Ops))
            {
                chart = task.allOrgCharts.First(o => o.OpPeriod == Ops);
            }
            name = chart.getNameByRoleName(roleName, defaultUpChain);
            return name;
        }

        public static string getNameByRoleID(this WFIncident task, int Ops, Guid RoleID, bool defaultUpChain = true)
        {
            string name = null;
            OrganizationChart chart = new OrganizationChart();
            if (task.allOrgCharts.Any(o => o.OpPeriod == Ops))
            {
                chart = task.allOrgCharts.First(o => o.OpPeriod == Ops);
            }
            name = chart.getNameByRoleID(RoleID, defaultUpChain);
            return name;
        }
        public static Personnel getMemberByRoleName(this WFIncident task, int Ops, string roleName, bool defaultUpChain = true)
        {
            Personnel member = new Personnel();
            OrganizationChart chart = new OrganizationChart();
            if (task.allOrgCharts.Any(o => o.OpPeriod == Ops))
            {
                chart = task.allOrgCharts.First(o => o.OpPeriod == Ops);
            }
            Guid personID = chart.getPersonnelIDByRoleName(roleName, defaultUpChain);
            if(task.IncidentPersonnel.Any(o=>o.ID == personID)) { return task.IncidentPersonnel.First(o=>o.ID==personID); }
            else { return null; }
            //member = chart.getTeamMemberByRoleName(roleName, defaultUpChain);
            
        }


       

        private static bool listAlreadyContainsMember(List<Personnel> members, Personnel newMember)
        {

            if (newMember == null) { return false; }
            if (string.IsNullOrEmpty(newMember.Name)) { return false; }
            if (members.Any(o => o.PersonID == newMember.PersonID)) { return true; }
            if (members.Contains(newMember)) { return true; }
            if (string.IsNullOrEmpty(newMember.Email))
            {
                return members.Any(o => !string.IsNullOrEmpty(o.Name) && o.Agency.EqualsWithNull(newMember.Agency) && o.Name.Equals(newMember.Name, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return members.Any(o => !string.IsNullOrEmpty(o.Email) && o.Email.Equals(newMember.Email, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public static void UpsertTaskTeamMember(this WFIncident task, Personnel member)
        {
            if (member != null && member.PersonID != Guid.Empty && !string.IsNullOrEmpty(member.Name))
            {
                if (task.AllIncidentResources.Any(o => o.ID == member.PersonID))
                {
                    task.AllIncidentResources = task.AllIncidentResources.Where(o => o.ID != member.PersonID).ToList();
                }
                task.AllIncidentResources.Add(member);

                if(member.ParentResourceID != Guid.Empty && task.AllIncidentResources.Any(o=>o.ID == member.ParentResourceID))
                {
                    IncidentResource parent = task.AllIncidentResources.First(o => o.ID == member.ParentResourceID);
                    if (parent.GetType().Name.Equals("OperationalSubGroup"))
                    {
                        Crew opsub = parent as Crew;
                        if(opsub.ResourceListing.Any(o=>o.ResourceID == member.ID))
                        {
                            opsub.ResourceListing.First(o => o.ResourceID == member.ID).ResourceName = member.Name;
                            opsub.ResourceListing.First(o => o.ResourceID == member.ID).Type = member.Type;
                            opsub.ResourceListing.First(o => o.ResourceID == member.ID).Kind = member.Kind;
                            Globals.incidentService.UpsertOperationalSubGroup(opsub);
                        }
                    }
                }

            }
        }

        public static List<Personnel> MembersSignedIn(this WFIncident task, int opPeriod)
        {
            return task.GetCurrentlySignedInPersonnel(opPeriod);
        }

        public static List<MemberStatus> getAllMemberStatus(this WFIncident task, int opPeriod, DateTime date = new DateTime(), bool getMultipleLinesAsNeeded = false)
        {
            List<MemberStatus> statuses = new List<MemberStatus>();
            List<Personnel> members = task.MembersSignedIn(opPeriod);
            //Add members who are on teams or in ICS roles currently
            if (task.allOrgCharts.Any(o => o.OpPeriod == opPeriod) && task.allOrgCharts.First(o => o.OpPeriod == opPeriod).ActiveRoles.Any(o => o.IndividualID != Guid.Empty))
            {
                foreach (ICSRole role in task.allOrgCharts.First(o => o.OpPeriod == opPeriod).ActiveRoles.Where(o => o.IndividualID != Guid.Empty))
                {
                    if (role.IndividualID != Guid.Empty && members.Any(o => o.PersonID == role.IndividualID))
                    {
                        members.Add(members.First(o=>o.ID == role.IndividualID));
                    }
                }
            }
         
      


            foreach (Personnel member in members)
            {
                int signInCount = task.AllCheckInRecords.Count(o => o.ResourceID == member.PersonID && o.OpPeriod == opPeriod);
                if (signInCount == 1 || !getMultipleLinesAsNeeded)
                {

                    MemberStatus status = task.getMemberStatus(member, opPeriod, date);
                    statuses.Add(status);
                }
                else if (signInCount == 0 && member.PersonID != Guid.Empty)
                {
                    //Member hasn't been signed in, but should still be displayed right?
                    MemberStatus status = new MemberStatus();
                    status.SignInTime = DateTime.MinValue;
                    status.setTeamMember(member);
                    statuses.Add(status);
                }
                else
                {
                    foreach (CheckInRecord record in task.AllCheckInRecords.Where(o => o.ResourceID == member.PersonID && o.OpPeriod == opPeriod))
                    {

                        MemberStatus status = task.getMemberStatus(member, opPeriod, date, record);
                        statuses.Add(status);
                    }

                }
            }
            return statuses;
        }

        public static MemberStatus getMemberStatus(this WFIncident task, Personnel member, int opPeriod, DateTime end_date = new DateTime(), CheckInRecord signIn = null)
        {
            MemberStatus status = new MemberStatus();
            status.setTeamMember(member);
            if (signIn == null)
            {
                if (task.AllCheckInRecords.Any(o => o.OpPeriod == opPeriod && o.ResourceID == member.PersonID && (o.CheckInDate <= end_date || end_date == DateTime.MinValue)))
                {
                    signIn = task.AllCheckInRecords.OrderByDescending(o => o.CheckInDate).First(o => o.OpPeriod == opPeriod && o.ResourceID == member.PersonID && (o.CheckInDate <= end_date || end_date == DateTime.MinValue) );
                    status.CheckInRecordID = signIn.SignInRecordID;
                    status.SignInTime = signIn.CheckInDate;
                    if (signIn.LastDayOnIncident > DateTime.MinValue) { status.LastDayWorked = signIn.LastDayOnIncident; }
                }
                else { status.SignInTime = DateTime.MinValue; }
            }
            else { status.SignInTime = signIn.CheckInDate; status.CheckInRecordID = signIn.SignInRecordID; }

            if (task.AllCheckInRecords.Any(o => o.OpPeriod == opPeriod && o.ResourceID == member.PersonID && (o.CheckOutDate <= end_date || end_date == DateTime.MinValue) && o.CheckOutDate > status.SignInTime))
            {
                CheckInRecord signOut = task.AllCheckInRecords.First(o => o.OpPeriod == opPeriod && o.ResourceID == member.PersonID && (o.CheckOutDate <= end_date || end_date == DateTime.MinValue) && o.CheckOutDate > status.SignInTime);
                status.SignOutTime = signOut.CheckOutDate;
                status.CheckOutRecordID = signOut.SignInRecordID;
            }
            else { status.SignOutTime = DateTime.MaxValue; }




            DateTime lastDate = DateTime.MinValue;

            DateTime today = DateTime.Now;

            //ics roles
            if (task.allOrgCharts.Any(o => o.OpPeriod == opPeriod))
            {
                foreach (ICSRole role in task.allOrgCharts.First(o => o.OpPeriod == opPeriod).ActiveRoles)
                {
                    if (role.IndividualID == member.PersonID)
                    {
                        //status.currentICSRole = role; 
                        status.ICSRoleID = role.RoleID;
                        status.ICSRoleName = role.RoleName;
                        break;
                    }
                }
            }
           
            return status;
        }

        public static List<PositionLogEntry> GetPositionLog(this WFIncident task, ICSRole role, int opPeriod)
        {
            return task.allPositionLogEntries.Where(o => o.Role.RoleID == role.RoleID && o.OpPeriod == opPeriod).ToList();
        }


        public static void UpsertPositionLogEntry(this WFIncident task, PositionLogEntry entry)
        {
            task.allPositionLogEntries = task.allPositionLogEntries.Where(o => o.LogID != entry.LogID).ToList();
            task.allPositionLogEntries.Add(entry);
            task.allPositionLogEntries = task.allPositionLogEntries.OrderBy(o => o.DateCreated).ToList();
        }


        public static List<string> GetPositionNamesWithLogs(this WFIncident task, int opPeriod)
        {
            List<string> names = new List<string>();
            foreach (PositionLogEntry entry in task.allPositionLogEntries.Where(o => o.OpPeriod == opPeriod))
            {
                if (!names.Contains(entry.Role.RoleName)) { names.Add(entry.Role.RoleName); }
            }

            return names;
        }



        public static void renumberObjectives(this WFIncident task, int currentOpPeriod)
        {
            int priority = 1;
            IncidentObjectivesSheet incidentObjectives = task.allIncidentObjectives.First(o => o.OpPeriod == currentOpPeriod);

            foreach (IncidentObjective objective in incidentObjectives.Objectives.OrderBy(o => o.Priority))
            {
                objective.Priority = priority;
                priority += 1;
            }
        }


        /*
        public static void saveOrgRole(this WFIncident task, string roleName, int opsPeriod, TeamMember member)
        {
            
            if (!task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).Any())
            {
                task.createOrgChartAsNeeded(opsPeriod);
                OrganizationChart chart = task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First();
            }
            else if (task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().AllRoles.Count <= 0)
            {
                task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().loadRoles();
            }

            ICSRole role = task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().getRoleByName(roleName);
            role.teamMember = member;
            role.OrganizationalChartID = task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().OrganizationalChartID;
         

    }  */
        public static void createCommsPlanAsNeeded(this WFIncident task, int Ops)
        {
            if (task.allCommsPlans.Where(o => o.OpsPeriod == Ops).Count() <= 0)
            {
                CommsPlan cp = new CommsPlan();
                cp.OpsPeriod = Ops;


                DateTime today = DateTime.Now;
                cp.DatePrepared = today;
                if (task.getOpPeriodStart(Ops).DayOfYear != today.DayOfYear)
                {
                    DateTime opStart = task.getOpPeriodStart(Ops);
                    DateTime newDate = new DateTime(opStart.Year, opStart.Month, opStart.Day, today.Hour, today.Minute, today.Second);
                    cp.DatePrepared = newDate;
                }

                //task.allCommsPlans.Add(cp);
                Globals.incidentService.UpsertCommsPlan(cp);

            }
        }

        public static void createMedicalPlanAsNeeded(this WFIncident task, int ops)
        {
            if (!task.allMedicalPlans.Any(o => o.OpPeriod == ops))
            {
                MedicalPlan plan = new MedicalPlan();
                plan.OpPeriod = ops;
                if (task.allOrgCharts.Any(o => o.OpPeriod == ops))
                {
                    OrganizationChart currentChart = task.allOrgCharts.First(o => o.OpPeriod == ops);
                    plan.PreparedBy = currentChart.getNameByRoleName("Logistics Section Chief");
                }

                /*
                if (task.allMedicalPlans.Count > 0)
                {
                    MedicalPlan old = task.allMedicalPlans.OrderByDescending(o => o.OpPeriod).First();
                    plan.Ambulances.AddRange(old.Ambulances);
                    plan.Hospitals.AddRange(old.Hospitals);
                }
                */

                DateTime today = DateTime.Now;
                plan.DatePrepared = today;
                if (task.getOpPeriodStart(ops).DayOfYear != today.DayOfYear)
                {
                    DateTime opStart = task.getOpPeriodStart(ops);
                    DateTime newDate = new DateTime(opStart.Year, opStart.Month, opStart.Day, today.Hour, today.Minute, today.Second);
                    plan.DatePrepared = newDate;
                }

                //task.allMedicalPlans.Add(plan);
                Globals.incidentService.UpsertMedicalPlan(plan);

            }
        }

        public static OperationalPeriod createOpPeriodAsNeeded(this WFIncident incident, int newOpNumber)
        {
            if (!incident.AllOperationalPeriods.Any(o => o.PeriodNumber == newOpNumber))
            {
                OperationalPeriod prevOp = incident.AllOperationalPeriods.OrderByDescending(o => o.PeriodEnd).First();
                if (prevOp == null)
                {
                    incident.GenerateFirstOpPeriod();
                    prevOp = incident.AllOperationalPeriods.OrderByDescending(o => o.PeriodEnd).First();

                }
                OperationalPeriod period = new OperationalPeriod();
                period.TaskID = incident.TaskID;
                period.PeriodNumber = newOpNumber;
                period.PeriodStart = prevOp.PeriodEnd.AddMinutes(1);
                period.PeriodEnd = period.PeriodStart.AddHours(12);
                return period;
            }
            else
            {
                return incident.AllOperationalPeriods.First(o => o.PeriodNumber == newOpNumber);
            }
        }

        public static void createObjectivesSheetAsNeeded(this WFIncident incident, int ops)
        {
            if (!incident.allIncidentObjectives.Any(o => o.OpPeriod == ops))
            {
                IncidentObjectivesSheet sheet = new IncidentObjectivesSheet();
                sheet.OpPeriod = ops;
                sheet.TaskID = incident.TaskID;
                DateTime today = DateTime.Now;
                sheet.DatePrepared = today;
                if (incident.getOpPeriodStart(ops).DayOfYear != today.DayOfYear)
                {
                    DateTime opStart = incident.getOpPeriodStart(ops);
                    DateTime newDate = new DateTime(opStart.Year, opStart.Month, opStart.Day, today.Hour, today.Minute, today.Second);
                    sheet.DatePrepared = newDate;
                }

                Globals.incidentService.UpsertIncidentObjectivesSheet(sheet);
            }
        }

        public static void createAirOpsSummaryAsNeeded(this WFIncident incident, int ops)
        {
            if(!incident.allAirOperationsSummaries.Any(o=>o.OpPeriod == ops))
            {
                AirOperationsSummary summary = new AirOperationsSummary();
                summary.OpPeriod = ops;
                DateTime opMid = DateTime.Now;
                if(incident.AllOperationalPeriods.Any(o=>o.PeriodNumber == ops)) { opMid = incident.AllOperationalPeriods.First(o=>o.PeriodNumber ==ops).PeriodMid; }

              

                Globals.incidentService.UpsertAirOperationsSummary(summary);
            }
        }

        public static void createOrgChartAsNeeded(this WFIncident task, int ops, bool addRolesFromLastOps = true)
        {
            if (!task.allOrgCharts.Any(o => o.OpPeriod == ops))
            {
               OrganizationChart chart = task.createOrgChartFromPrevious(0, ops);
                if(chart != null)
                {
                    chart.CreateOpGroupsForOrgRoles(task);

                    Globals.incidentService.UpsertOrganizationalChart(chart);
                }
            }
        }

        public static OrganizationChart createOrgChartFromPrevious(this WFIncident incident, int oldOps, int newOps)
        {
            OrganizationChart chart = new OrganizationChart();
            chart.OpPeriod = newOps;


            if (incident.allOrgCharts.Any(o=>o.OpPeriod == oldOps))
            {
                OrganizationChart lastOrg = incident.allOrgCharts.First(o=>o.OpPeriod == oldOps);
                chart.AllRoles = OrgChartTools.GetBlankRolesBasedOnThisChart(lastOrg, newOps, chart.OrganizationalChartID);
            } else if (oldOps == 0 && incident.allOrgCharts.Any(o=>o.OpPeriod != newOps))
            {
                OrganizationChart lastOrg = incident.allOrgCharts.OrderByDescending(o => o.OpPeriod).First();
                chart.AllRoles = OrgChartTools.GetBlankRolesBasedOnThisChart(lastOrg, newOps, chart.OrganizationalChartID);
            }
            else
            {
                chart.AllRoles = OrgChartTools.GetBlankPrimaryRoles();
                foreach (ICSRole role in chart.AllRoles) { role.OpPeriod = newOps; role.OrganizationalChartID = chart.OrganizationalChartID; }


            }

          


            //chart.DatePrepared = DateTime.Now;


            DateTime today = DateTime.Now;
            chart.DatePrepared = today;
            if (incident.getOpPeriodStart(newOps).DayOfYear != today.DayOfYear)
            {
                DateTime opStart = incident.getOpPeriodStart(newOps);
                DateTime newDate = new DateTime(opStart.Year, opStart.Month, opStart.Day, today.Hour, today.Minute, today.Second);
                chart.DatePrepared = newDate;
            }


            //task.allOrgCharts.Add(chart);
            //Globals.incidentService.UpsertOrganizationalChart(chart);
            return chart;
        }

        public static void CreateOpGroupsForOrgRoles(this OrganizationChart chart, WFIncident incident)
        {
            foreach (ICSRole role in chart.ActiveRoles.Where(o => o.IsOpGroupSup && !o.IsPlaceholder))
            {
                if (role.OperationalGroupID == Guid.Empty)
                {
                    OperationalGroup group = incident.createOperationalGroupFromRole(role);
                    role.OperationalGroupID = group.ID;
                    Globals.incidentService.UpsertOperationalGroup(group);
                }
            }
        }

        public static OperationalGroup createOperationalGroupFromRole(this WFIncident incident, ICSRole role)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = role.OpPeriod;
            group.ParentID = role.ReportsTo;
            group.ParentName = role.ReportsToRoleName;
            group.LeaderICSRoleID = role.RoleID;
            group.LeaderICSRoleName = role.RoleName;
            if (role.IsOpGroupSup)
            {
                if (role.Mnemonic.Equals("OPBD") || role.RoleID == Globals.AirOpsDirector || role.Mnemonic.Equals("HEBD")) { 
                    group.GroupType = "Branch";
                    group.Name = role.RoleName.Replace(" Director", "");
                }
                else if (role.Mnemonic.Equals("DIVS"))
                {
                    group.GroupType = "Division";
                    group.Name = role.RoleName.Replace(" Supervisor", "");
                }
                else if (role.Mnemonic.Equals("STLD"))
                {
                    group.GroupType = "Strike Team";
                    group.Name = role.RoleName.Replace(" Leader", "");
                }
                else if (role.Mnemonic.Equals("TFLD"))
                {
                    group.GroupType = "Task Force";
                    group.Name = role.RoleName.Replace(" Leader", "");
                }

                else
                {
                    group.GroupType = "Group";
                    group.Name = role.RoleName.Replace(" Supervisor", "");
                }
            }
            return group;
        }


        public static int getNextObjectivePriority(this WFIncident task, int thisOpPeriod)
        {
            task.createObjectivesSheetAsNeeded(thisOpPeriod);

            if (task.allIncidentObjectives.First(o=>o.OpPeriod == thisOpPeriod).Objectives.Any())
            {
                return task.allIncidentObjectives.First(o => o.OpPeriod == thisOpPeriod).Objectives.Max(o => o.Priority) + 1;
            }
            return 1;
        }

        /*
        public static void saveCommsPlanItem(this WFIncident task, CommsPlanItem item, string function, int OpsPeriod)
        {
            task.createCommsPlanAsNeeded(OpsPeriod);
            CommsPlan thisPlan = task.allCommsPlans.Where(o => o.OpsPeriod == OpsPeriod).First();

            if (!thisPlan.allCommsItems.Where(o => o.ItemID == item.ItemID).Any())
            {
                thisPlan.allCommsItems.Add(item);
            }

            if (thisPlan.allItemLinks.Where(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)).Any())
            {
                thisPlan.allItemLinks = thisPlan.allItemLinks.Where(o => !o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            thisPlan.allItemLinks.Add(new CommsPlanItemLink(item.ItemID, function));
        }

        */





        public static List<CommsRecipient> GetCommsRecipients(this WFIncident task, int ops)
        {


            List<CommsRecipient> commsRecipients = new List<CommsRecipient>();

            Guid ICPID = task.TaskID;
            Guid ECCID = new Guid("8e8ade8d-eb79-4280-8cf8-1a926d6a8200");
            Guid TaskingID = new Guid("9ababbb3-1f29-400c-a2c0-d9963c565dcb");

            /*
            foreach (Assignment team in task.allAssignments.Where(o => o.OpPeriod == ops))
            {
                commsRecipients.Add(new CommsRecipient(team.AssignmentID, team.TeamNameWithNumber));
            }
            */
            if (task.allVehicles != null)
            {
                foreach (Vehicle vehicle in task.allVehicles.Where(o => o.OpPeriod == ops))
                {
                    commsRecipients.Add(new CommsRecipient(vehicle.ID, vehicle.IncidentIDNo));

                }
            }

            foreach (CommsLogEntry entry in task.allCommsLogEntries)
            {
                //the From entry

                CommsRecipient from = new CommsRecipient(entry.FromTeamID, entry.FromName);
                if (from.RecipientID != ICPID && from.RecipientID != ECCID && from.RecipientID != TaskingID && !string.IsNullOrEmpty(from.RecipientName))
                {
                    from.RecipientName = from.RecipientName.Trim();
                    if (task.CheckAddCommsRecipient(from, commsRecipients))
                    {
                        commsRecipients.Add(from);
                    }

                }


                //the To entry
                CommsRecipient to = new CommsRecipient(entry.ToTeamID, entry.ToName);
                if (to.RecipientID != ICPID && to.RecipientID != ECCID && to.RecipientID != TaskingID && !string.IsNullOrEmpty(to.RecipientName))
                {
                    to.RecipientName = to.RecipientName.Trim();
                    if (task.CheckAddCommsRecipient(to, commsRecipients))
                    {
                        commsRecipients.Add(to);
                    }
                }
            }

            commsRecipients = commsRecipients.OrderBy(o => o.RecipientID != ICPID).ThenBy(o => o.RecipientName).ToList();


            if (!commsRecipients.Where(o => o.RecipientID == ICPID).Any())
            {
                commsRecipients.Insert(0, new CommsRecipient(ICPID, task.ICPCallSign));
            }


            if (commsRecipients.Where(o => o.RecipientID == ECCID).Count() <= 0)
            {
                commsRecipients.Add(new CommsRecipient(ECCID, "ECC / EMBC"));
            }


            if (!commsRecipients.Where(o => o.RecipientID == TaskingID).Any())
            {
                commsRecipients.Add(new CommsRecipient(TaskingID, "Tasking Agency"));
            }



            return commsRecipients;
        }

        private static bool CheckAddCommsRecipient(this WFIncident task, CommsRecipient com, List<CommsRecipient> commsRecipients)
        {
            Guid ICPID = task.TaskID;
            Guid ECCID = new Guid("8e8ade8d-eb79-4280-8cf8-1a926d6a8200");
            Guid TaskingID = new Guid("9ababbb3-1f29-400c-a2c0-d9963c565dcb");

            if (com.RecipientID == ICPID) { return false; }
            if (com.RecipientID == ECCID) { return false; }
            if (com.RecipientID == TaskingID) { return false; }
           // if (task.allAssignments.Any(o => o.AssignmentID == com.RecipientID)) { return false; }
            if (commsRecipients.Any(o => o.RecipientID == com.RecipientID)) { return false; }
            if (com.RecipientName.Equals(task.ICPCallSign, StringComparison.InvariantCultureIgnoreCase)) { return false; }
           // if (task.allAssignments.Any(o => o.AssignmentName.Equals(com.RecipientName, StringComparison.InvariantCultureIgnoreCase))) { return false; }
           // if (task.allAssignments.Any(o => o.TeamName.Equals(com.RecipientName, StringComparison.InvariantCultureIgnoreCase))) { return false; }
            if (commsRecipients.Any(o => o.RecipientName.Equals(com.RecipientName, StringComparison.InvariantCultureIgnoreCase))) { return false; }
            return true;
        }


   
       
        //Exports the communications log for the selected op period into a CSV format with tab delimiters
        public static string exportCommsLogToCSV(this WFIncident task, int op_period, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            //header row
            csv.Append("CRITICAL"); csv.Append(delimiter);
            csv.Append("TIME"); csv.Append(delimiter);
            csv.Append("STN. CALLED"); csv.Append(delimiter);
            csv.Append("THIS IS"); csv.Append(delimiter);
            csv.Append("SUBJECT"); csv.Append(delimiter);
            csv.Append("STATUS");
            csv.Append(Environment.NewLine);
            foreach (CommsLogEntry entry in task.allCommsLogEntries.Where(o => o.Active && o.OperationalPeriod == op_period))
            {
                if (entry.Starred) { csv.Append("TRUE"); } else { csv.Append("FALSE"); }
                csv.Append(delimiter);
                csv.Append(entry.LogDate.ToString("HH:mm " + Globals.DateFormat)); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.ToName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.FromName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.Message.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                if (entry.status != null) { csv.Append("\""); csv.Append(entry.status.StatusName); csv.Append("\""); }
                else { csv.Append("\""); csv.Append("\""); }
                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }


        public static OperationalPeriod GenerateFirstOpPeriod(this WFIncident task)
        {
            if (!task.AllOperationalPeriods.Any())
            {
                OperationalPeriod period = new OperationalPeriod();
                period.TaskID = task.TaskID;
                period.PeriodNumber = 1;
                period.PeriodStart = DateTime.Now;
                period.PeriodEnd = period.PeriodStart.AddHours(12);
                return period;
                //task.AllOperationalPeriods.Add(period);
            }
            return null;
        }


        //RefreshAutomatedTimelineEvents
        public static List<TimelineEvent> GetAutomatedTimelineEvents(this WFIncident task)
        {
            DateTime today = DateTime.Now;
            List<TimelineEvent> events = new List<TimelineEvent>();

            //task.taskTimeline.AllTimelineEvents = task.taskTimeline.AllTimelineEvents.Where(o => !o.EventType.Equals("OpPeriodStart") && !o.EventType.Equals("OpPeriodEnd")).ToList();
            foreach (OperationalPeriod ops in task.AllOperationalPeriodsWithContent)
            {

                //This bit is to check for op periods missing a correct start or end date. This will be the case when opening older files created in verison 6.13 or lower of ICA.
                if (ops.PeriodEnd < ops.PeriodStart)
                {
                    if (task.AllOperationalPeriodsWithContent.Any(o => o.PeriodNumber > ops.PeriodNumber))
                    {
                        ops.PeriodEnd = task.AllOperationalPeriodsWithContent.Where(o => o.PeriodNumber > ops.PeriodNumber).OrderBy(o => o.PeriodNumber).First().PeriodStart.AddMinutes(-1);
                    }
                }


                TimeSpan opLength = ops.PeriodEnd - ops.PeriodStart;
                if (Math.Abs(opLength.TotalDays) > 20)
                {

                    DateTime orignalStart = ops.PeriodStart;
                    DateTime originalEnd = ops.PeriodEnd;

                    int lowYear = 1753;

                    int startDay = ops.PeriodStart.Day;
                    int startMonth = ops.PeriodStart.Month;
                    int startYear = ops.PeriodStart.Year;

                    int endDay = ops.PeriodEnd.Day;
                    int endMonth = ops.PeriodEnd.Month;
                    int endYear = ops.PeriodEnd.Year;


                    if ((startYear == DateTime.MinValue.Year || startYear == lowYear) && endYear != DateTime.MinValue.Year)
                    {
                        startYear = endYear;
                        ops.PeriodStart = new DateTime(startYear, startMonth, startDay);
                    }

                    if ((endYear == DateTime.MinValue.Year || endYear == lowYear) && startYear != DateTime.MinValue.Year)
                    {
                        endYear = startYear;
                        ops.PeriodEnd = new DateTime(endYear, endMonth, endDay);
                    }


                }


                if (today > ops.PeriodStart)
                {
                    TimelineEvent ev = new TimelineEvent(ops, true, false); ev.IsAuto = true;
                    events.Add(ev);
                }
                if (today > ops.PeriodEnd)
                {
                    TimelineEvent ev = new TimelineEvent(ops, false, true); ev.IsAuto = true;
                    events.Add(ev);
                }
            }

            //task.taskTimeline.AllTimelineEvents = task.taskTimeline.AllTimelineEvents.Where(o => !o.EventType.Equals("CommsEntry")).ToList();
            foreach (CommsLogEntry entry in task.allCommsLogEntries.Where(o => o.Starred && o.Active))
            {
                TimelineEvent ev = new TimelineEvent(entry);
                ev.IsAuto = true;
                events.Add(ev);
            }

            //task.taskTimeline.AllTimelineEvents = task.taskTimeline.AllTimelineEvents.OrderBy(o => o.EventDateTime).ToList();
            return events;

        }

        
    }
}
