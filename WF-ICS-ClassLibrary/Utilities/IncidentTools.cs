using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class IncidentTools
    {
      
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
        public static TeamMember getMemberByRoleName(this WFIncident task, int Ops, string roleName, bool defaultUpChain = true)
        {
            TeamMember member = new TeamMember();
            OrganizationChart chart = new OrganizationChart();
            if (task.allOrgCharts.Any(o => o.OpPeriod == Ops))
            {
                chart = task.allOrgCharts.First(o => o.OpPeriod == Ops);
            }
            member = chart.getTeamMemberByRoleName(roleName, defaultUpChain);
            return member;
        }


        public static List<TeamMember> getTaskTeamMembers(this WFIncident task, List<TeamMember> orgMembers, bool useDatabase = true, bool includeBlank = false, int OpPeriod = 0)
        {
            List<TeamMember> members = new List<TeamMember>();

            foreach (TeamMember member in task.TaskTeamMembers)
            {
                if (!members.Any(o => o.PersonID == member.PersonID) && !listAlreadyContainsMember(members, member)) { members.Add(member); }
            }

           
            foreach (OrganizationChart orgchart in task.allOrgCharts)
            {
                foreach (ICSRole role in orgchart.AllRoles)
                {
                    if (role.teamMember != null && !members.Any(o => o.PersonID == role.teamMember.PersonID) && !listAlreadyContainsMember(members, role.teamMember)) { members.Add(role.teamMember); }
                }
            }

            foreach (SignInRecord record in task.AllSignInRecords)
            {
                if (!members.Any(o => o.PersonID == record.teamMember.PersonID) && !listAlreadyContainsMember(members, record.teamMember)) { members.Add(record.teamMember); }

            }



            foreach (TeamMember member in orgMembers)
            {
                if (member != null && !string.IsNullOrEmpty(member.Name) && !listAlreadyContainsMember(members, member)) { members.Add(member); }
            }

            //set signed in to task status
            if (OpPeriod > 0)
            {
                foreach (TeamMember member in members)
                {
                    if (task.AllSignInRecords.Where(o => o.MemberID == member.PersonID && o.OpPeriod == OpPeriod).Any())
                    {
                        SignInRecord record = task.AllSignInRecords.Where(o => o.MemberID == member.PersonID && o.OpPeriod == OpPeriod).OrderByDescending(o => o.StatusChangeTime).First();
                        member.SignedInToTask = record.IsSignIn;
                    }
                    else { member.SignedInToTask = false; }
                }
            }

            //update status
            foreach (TeamMember member in members)
            {
                member.CurrentStatus = task.getMemberStatus(member, OpPeriod);
            }

            members = members.Where(o => !string.IsNullOrEmpty(o.Name)).OrderByDescending(o => o.OrganizationID == task.OrganizationID).ThenBy(o => o.Group).ThenBy(o => o.Name).ToList();

            if (includeBlank)
            {
                TeamMember blank = new TeamMember();
                blank.PersonID = Guid.Empty;
                blank.Name = "";
                members.Insert(0, blank);
            }

            task.TaskTeamMembers = members;
            return members;
        }

        private static bool listAlreadyContainsMember(List<TeamMember> members, TeamMember newMember)
        {

            if (newMember == null) { return false; }
            if (string.IsNullOrEmpty(newMember.Name)) { return false; }
            if (members.Any(o => o.PersonID == newMember.PersonID)) { return true; }
            if (members.Contains(newMember)) { return true; }
            if (string.IsNullOrEmpty(newMember.Email))
            {
                return members.Any(o => !string.IsNullOrEmpty(o.Name) && o.OrganizationID == newMember.OrganizationID && o.Name.Equals(newMember.Name, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                return members.Any(o => !string.IsNullOrEmpty(o.Email) && o.Email.Equals(newMember.Email, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public static void UpsertTaskTeamMember(this WFIncident task, TeamMember member)
        {
            if (member != null)
            {
                if (task.TaskTeamMembers.Any(o => o.PersonID == member.PersonID))
                {
                    task.TaskTeamMembers = task.TaskTeamMembers.Where(o => o.PersonID != member.PersonID).ToList();
                }
                task.TaskTeamMembers.Add(member);
            }
        }

        public static List<TeamMember> MembersSignedIn(this WFIncident task, int opPeriod)
        {
            List<TeamMember> members = new List<TeamMember>();
            foreach (SignInRecord record in task.AllSignInRecords.Where(o => o.OpPeriod == opPeriod))
            {
                if (!members.Where(o => o.PersonID == record.teamMember.PersonID).Any())
                {
                    members.Add(record.teamMember);
                }

                if (members.Where(o => o.PersonID == record.teamMember.PersonID).Any())
                {
                    if (record.IsSignIn) { members.Where(o => o.PersonID == record.teamMember.PersonID).First().SignedInToTask = true; }
                    else { members.Where(o => o.PersonID == record.teamMember.PersonID).First().SignedInToTask = false; }
                }
                /*
                if (TaskTeamMembers.Where(o => o.PersonID == record.MemberID).Any() && !members.Where(o=>o.PersonID == record.teamMember.PersonID).Any())
                {
                    members.AddRange(TaskTeamMembers.Where(o => o.PersonID == record.MemberID));
                }*/
            }
            return members;
        }

        public static List<MemberStatus> getAllMemberStatus(this WFIncident task, int opPeriod, DateTime date = new DateTime(), bool getMultipleLinesAsNeeded = false)
        {
            List<MemberStatus> statuses = new List<MemberStatus>();
            List<TeamMember> members = task.MembersSignedIn(opPeriod);
            //Add members who are on teams or in ICS roles currently
            if (task.allOrgCharts.Any(o => o.OpPeriod == opPeriod) && task.allOrgCharts.First(o => o.OpPeriod == opPeriod).AllRoles.Any(o => o.teamMember != null))
            {
                foreach (ICSRole role in task.allOrgCharts.First(o => o.OpPeriod == opPeriod).AllRoles.Where(o => o.teamMember != null))
                {
                    if (role.teamMember.PersonID != Guid.Empty && !string.IsNullOrEmpty(role.teamMember.Name) && !members.Any(o => o.PersonID == role.teamMember.PersonID))
                    {
                        members.Add(role.teamMember);
                    }
                }
            }
         
            foreach (TeamMember member in members)
            {
                int signInCount = task.AllSignInRecords.Where(o => o.IsSignIn && o.teamMember.PersonID == member.PersonID && o.OpPeriod == opPeriod).Count();
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
                    foreach (SignInRecord record in task.AllSignInRecords.Where(o => o.IsSignIn && o.teamMember.PersonID == member.PersonID && o.OpPeriod == opPeriod))
                    {

                        MemberStatus status = task.getMemberStatus(member, opPeriod, date, record);
                        statuses.Add(status);
                    }

                }
            }
            return statuses;
        }

        public static MemberStatus getMemberStatus(this WFIncident task, TeamMember member, int opPeriod, DateTime end_date = new DateTime(), SignInRecord signIn = null)
        {
            MemberStatus status = new MemberStatus();
            status.setTeamMember(member);
            if (signIn == null)
            {
                if (task.AllSignInRecords.Where(o => o.OpPeriod == opPeriod && o.MemberID == member.PersonID && (o.StatusChangeTime <= end_date || end_date == DateTime.MinValue) && o.IsSignIn).Any())
                {
                    signIn = task.AllSignInRecords.Where(o => o.OpPeriod == opPeriod && o.MemberID == member.PersonID && (o.StatusChangeTime <= end_date || end_date == DateTime.MinValue) && o.IsSignIn).OrderByDescending(o => o.StatusChangeTime).First();

                    status.SignInTime = signIn.StatusChangeTime;
                    if (signIn.TimeOutRequest > DateTime.MinValue) { status.TimeOutRequest = signIn.TimeOutRequest; }
                    status.KMs = signIn.KMs;
                }
                else { status.SignInTime = DateTime.MinValue; }
            }
            else { status.SignInTime = signIn.StatusChangeTime; status.KMs = signIn.KMs; }

            if (task.AllSignInRecords.Where(o => o.OpPeriod == opPeriod && o.MemberID == member.PersonID && (o.StatusChangeTime <= end_date || end_date == DateTime.MinValue) && o.StatusChangeTime > status.SignInTime && !o.IsSignIn).Any())
            {
                SignInRecord signOut = task.AllSignInRecords.Where(o => o.OpPeriod == opPeriod && o.MemberID == member.PersonID && (o.StatusChangeTime <= end_date || end_date == DateTime.MinValue) && o.StatusChangeTime > status.SignInTime && !o.IsSignIn).OrderBy(o => o.StatusChangeTime).First();
                status.SignOutTime = signOut.StatusChangeTime;
                if (status.KMs <= 0m)
                {
                    status.KMs = signOut.KMs;
                }
            }
            else { status.SignOutTime = DateTime.MaxValue; }




            DateTime lastDate = DateTime.MinValue;

            DateTime today = DateTime.Now;
            /*
            if (status.SignOutTime < DateTime.MaxValue && status.SignOutTime > status.SignInTime && status.SignOutTime <= today)
            {
                Assignment signedout = new Assignment();
                signedout.AssignmentName = "Signed Out";
                signedout.currentStatus = new TeamStatus(38, "", false);
                status.currentAssignment = signedout;
            }
            else if (status.SignOutTime < DateTime.MaxValue && status.SignOutTime > status.SignInTime)
            {
                Assignment signedout = new Assignment();
                signedout.AssignmentName = "Travelling Home";
                signedout.currentStatus = new TeamStatus(39, "", false);
                status.currentAssignment = signedout;
            }
            else if (status.AssignmentID == Guid.Empty)
            {
                Assignment unassigned = new Assignment();
                unassigned.AssignmentName = "Unassigned";
                unassigned.currentStatus = new TeamStatus(99, "", false);
                status.currentAssignment = unassigned;
            }
            */
            //ics roles
            if (task.allOrgCharts.Any(o => o.OpPeriod == opPeriod))
            {
                foreach (ICSRole role in task.allOrgCharts.First(o => o.OpPeriod == opPeriod).AllRoles)
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

                if (task.allMedicalPlans.Count > 0)
                {
                    MedicalPlan old = task.allMedicalPlans.OrderByDescending(o => o.OpPeriod).First();
                    plan.Ambulances.AddRange(old.Ambulances);
                    plan.Hospitals.AddRange(old.Hospitals);
                }


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

        public static void createOrgChartAsNeeded(this WFIncident task, int ops)
        {
            if (!task.allOrgCharts.Any(o => o.OpPeriod == ops))
            {
                OrganizationChart chart = new OrganizationChart();
                chart.OpPeriod = ops;

                if (task.allOrgCharts.Any())
                {
                    OrganizationChart lastOrg = task.allOrgCharts.OrderByDescending(o => o.OpPeriod).FirstOrDefault();
                    chart.AllRoles = OrgChartTools.GetBlankRolesBasedOnThisChart(lastOrg, ops, chart.OrganizationalChartID );
                }
                else
                {
                    chart.AllRoles = OrgChartTools.GetBlankPrimaryRoles();
                    foreach(ICSRole role in chart.AllRoles) { role.OpPeriod = ops; role.OrganizationalChartID = chart.OrganizationalChartID; }
                }


                //chart.DatePrepared = DateTime.Now;


                DateTime today = DateTime.Now;
                chart.DatePrepared = today;
                if (task.getOpPeriodStart(ops).DayOfYear != today.DayOfYear)
                {
                    DateTime opStart = task.getOpPeriodStart(ops);
                    DateTime newDate = new DateTime(opStart.Year, opStart.Month, opStart.Day, today.Hour, today.Minute, today.Second);
                    chart.DatePrepared = newDate;
                }


                //task.allOrgCharts.Add(chart);
                Globals.incidentService.UpsertOrganizationalChart(chart);
            }
        }


        public static int getNextObjectivePriority(this WFIncident task, int thisOpPeriod)
        {
            if(task.allIncidentObjectives.First(o=>o.OpPeriod == thisOpPeriod).Objectives.Any())
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
                    commsRecipients.Add(new CommsRecipient(vehicle.VehicleID, vehicle.IncidentIDNo));

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
                csv.Append(entry.LogDate.ToString("HH:mm yyyy-MMM-dd")); csv.Append(delimiter);
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
