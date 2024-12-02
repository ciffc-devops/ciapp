using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using WF_ICS_ClassLibrary.Models.OrganizationalChartModels;
using WF_ICS_ClassLibrary.Utilities;
using static System.Collections.Specialized.BitVector32;

namespace WF_ICS_ClassLibrary.Models
{
    public static class OrganizationalChartTools
    {
        private static List<GenericICSRole> _GenericRolesCache = null;
        public static List<GenericICSRole> GenericRolesCache
        {
            get
            {
                if (_GenericRolesCache == null) { _GenericRolesCache = GetGenericICSRoles(); }
                return _GenericRolesCache;
            }
        }


        /// <summary>
        /// This function takes an ICS role and makes the corresponding operational group.  Note it doesn't currently set the op group ID that the new group will report to
        /// </summary>
        /// <param name="role"></param>
        /// <param name="OperationalGroupName"></param>
        /// <returns></returns>
        public static ICSRole CreateRoleFromOperationalGroup(this OperationalGroup group, Guid OrganizationalChartID)
        {
            ICSRole role = new ICSRole();

            if (group.GroupType.Equals("Branch") && group.Name.Contains("Air")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.AirOpsDirectorGenericID));  }
            if (group.GroupType.Equals("Branch")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.BranchDirectorGenericID)); }
            if (group.GroupType.Equals("Division")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.DivisionSupervisorGenericID)); }
            if (group.GroupType.Equals("Group")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.GroupSupervisorGenericID)); }
            if (group.GroupType.Equals("Strike Team")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.StrikeTeamLeaderGenericID)); }
            if (group.GroupType.Equals("Task Force")) { role.FillFromGenericRole(GetGenericRoleByID(Globals.TaskForceLeaderGenericID)); }
            role.OpPeriod = group.OpPeriod;
            role.Active = true;
            role.OperationalGroupID = group.ID;
            role.OrganizationalChartID = OrganizationalChartID;
            role.OperationalGroupName = group.Name;
            role.IndividualID = group.LeaderID;
            role.IndividualName = group.LeaderName;
            return role;
        }


        public static void FillFromGenericRole(this ICSRole role, GenericICSRole genericRole)
        {
            role.BaseRoleName = genericRole.RoleName;
            role.SectionID = genericRole.SectionID;
            role.GenericRoleID = genericRole.GenericRoleID;
            role.ReportsTo = Guid.Empty;
            role.RoleDescription = genericRole.RoleDescription;
            role.MnemonicAbrv = genericRole.MnemonicAbrv;
            role.RoleNameWithPlaceholder = genericRole.RoleNameWithPlaceholder;
            role.OnInitialOrgChart = genericRole.OnInitialOrgChart;
            role.RequiresOperationalGroup = genericRole.RequiresOperationalGroup;
            role.ReportsToGenericRoleID = genericRole.ReportsToGenericRoleID;
            role.Depth = genericRole.Depth;
            role.ManualSortOrder = genericRole.ManualSortOrder;
        }
        public static void UnassignThisAndSubordinateRoles(this OrganizationChart chart, ICSRole roleToClear, bool sendUpsertCommands = true)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            roleToClear.IndividualID = Guid.Empty;
           // roleToClear.teamMember = blankMember;
            roleToClear.IndividualName = null;
            if (sendUpsertCommands) { Globals.incidentService.UpsertICSRole(roleToClear); }
            foreach (ICSRole role in chart.FilledActiveRoles.Where(o => o.ReportsTo == roleToClear.RoleID))
            {
                chart.UnassignThisAndSubordinateRoles(role, sendUpsertCommands);
            }
        }

        public static bool FilledOrHasFilledChildRoles(this OrganizationChart chart, ICSRole role)
        {
            if (role.IndividualID != Guid.Empty) { return true; }
            foreach(ICSRole childRole in chart.ActiveRoles.Where(o=>o.ReportsTo == role.RoleID))
            {
                if (chart.FilledOrHasFilledChildRoles(childRole))
                {
                    return true;
                }
            }
            return false;
        }



        public static List<ICSRole> GetRolesForAssignmentList(this OrganizationChart org, Guid BranchID, int maxDepth = 0, int MaxCount = 0)
        {

            List<ICSRole> roles = new List<ICSRole>();
            roles.Add(org.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == BranchID));

            foreach (ICSRole role in org.ActiveRoles.Where(o => o.ReportsTo == roles.First().RoleID))
            {
                if (!roles.Any(o => o.RoleID == role.RoleID))
                {
                    roles.Add(role);
                }
                List<ICSRole> childRoles = org.GetChildRoles(role.RoleID, true, true);
                if (maxDepth > 0) { childRoles = childRoles.Where(o => o.Depth <= maxDepth).ToList(); }
                roles.AddRange(childRoles);
            }

            if (MaxCount > 0 && roles.Count > MaxCount && (maxDepth > 1))
            {
                int newDepth = roles.Max(o => o.Depth) - 1;
                roles = org.GetRolesForAssignmentList(BranchID, newDepth, MaxCount);
            }


            return roles;
        }



        public static List<ICSRole> GetUnifiedCommandRoles(this List<ICSRole> list)
        {
            List<ICSRole> ucRoles = new List<ICSRole>();


            Personnel blankPerson = new Personnel();
            blankPerson.PersonID = Guid.Empty;

            if (list.Any(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID && !o.Active))
            {
                ucRoles.Add(list.First(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID));
                ucRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID).Active = true;

            }
            else { ucRoles.Add(new ICSRole(Globals.UnifiedCommand2GenericID, "Unified Command", Globals.IncidentCommanderGenericID, Globals.IncidentCommanderGenericID, "UCName2", "UCTitle2", blankPerson, 0, 0)); }
            if (list.Any(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID && !o.Active))
            {
                ucRoles.Add(list.First(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID));
                ucRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID).Active = true;
            }
            else { ucRoles.Add(new ICSRole(Globals.UnifiedCommand3GenericID, "Unified Command", Globals.IncidentCommanderGenericID, Globals.IncidentCommanderGenericID, "UCName3", "UCTitle3", blankPerson, 0, 0)); }



            return ucRoles;
        }


        public static void SwitchToUnifiedCommand(this OrganizationChart org)
        {
            if (!org.IsUnifiedCommand)
            {
               
                ICSRole ic = org.ActiveRoles.First(o => o.GenericRoleID == Globals.IncidentCommanderGenericID);
                ic.BaseRoleName = "Unified Command";
                List<ICSRole> ucRoles = org.AllRoles.GetUnifiedCommandRoles();

                Globals.incidentService.UpsertICSRole(ic);
                org.IsUnifiedCommand = true;
                foreach (ICSRole role in ucRoles)
                {
                    role.OpPeriod = ic.OpPeriod;
                    role.OrganizationalChartID = ic.OrganizationalChartID;
                    role.ReportsTo = Guid.Empty;
                    org.AllRoles = org.AllRoles.Where(o=>o.RoleID != role.RoleID).ToList();
                    org.AllRoles.Add(role);
                    Globals.incidentService.UpsertICSRole(role);

                }
            }
        }

        public static void SwitchToSingleIC(this OrganizationChart org)
        {
            if (org.IsUnifiedCommand)
            {
                ICSRole ic = org.ActiveRoles.First(o => o.GenericRoleID == Globals.IncidentCommanderGenericID);
                //ICSRole uc1 = org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand1GenericID);
                //if (uc1.IndividualID == Guid.Empty && org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID).IndividualID != Guid.Empty) { uc1 = org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID); }
                //if (uc1.IndividualID == Guid.Empty && org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID).IndividualID != Guid.Empty) { uc1 = org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID); }

                ic.BaseRoleName = "Incident Commander";

                Globals.incidentService.UpsertICSRole(ic);
                //if (org.ActiveRoles.Any(o => o.GenericRoleID == Globals.UnifiedCommand1GenericID)) { Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand1GenericID), org.OpPeriod); }
                if (org.ActiveRoles.Any(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID))
                {
                    Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID), org.OpPeriod);
                }
                if (org.ActiveRoles.Any(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID))
                {
                    Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID), org.OpPeriod);
                }





                org.IsUnifiedCommand = false;
            }
        }

   

        public static List<ICSRole> GetBlankRolesBasedOnThisChart(OrganizationChart ogOrgChart, int newOpPeriod, Guid newChartID, bool copyAssignments)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;
            List<Tuple<Guid, Guid>> IDCorrespondance = new List<Tuple<Guid, Guid>>();

            List<ICSRole> AllRoles = new List<ICSRole>();

            foreach(ICSRole role in ogOrgChart.ActiveRoles)
            {
                ICSRole newRole = role.Clone();
                if (!copyAssignments)
                {
                    newRole.IndividualName = string.Empty; newRole.IndividualID = Guid.Empty;
                }
                newRole.OrganizationalChartID = newChartID;
                newRole.OpPeriod = newOpPeriod;

                newRole.ID = Guid.NewGuid();
                IDCorrespondance.Add(new Tuple<Guid, Guid>(role.RoleID, newRole.RoleID));
                AllRoles.Add(newRole);
            }

            //fix the report-to links
            foreach (ICSRole role in AllRoles.Where(o=>o.ReportsTo != Guid.Empty))
            {
                //get the new reports to value
                Tuple<Guid, Guid> reportsTo = IDCorrespondance.FirstOrDefault(o=>o.Item1 == role.ReportsTo);
                if (reportsTo != null)
                {
                    role.ReportsTo = reportsTo.Item2;
                }
            }

            return AllRoles;
        }

        public static GenericICSRole GetGenericRoleByID(Guid id)
        {
            List<GenericICSRole> roles = GetGenericICSRoles();
            if (roles.Any(o => o.GenericRoleID == id)) { return roles.FirstOrDefault(o => o.GenericRoleID == id); }
            else { return null; }
        }

        public static List<ICSRole> GetChildRoles(this OrganizationChart orgChart, Guid ParentRoleID, bool getAllDecendants = true, bool ExcludeAgencyReps = true)
        {
            List<ICSRole> roles = new List<ICSRole>();
            foreach(ICSRole ro in orgChart.ActiveRoles.Where(o => o.ReportsTo == ParentRoleID))
            {
                roles.Add(ro);
                if (getAllDecendants)
                {
                    roles.AddRange(orgChart.GetChildRoles(ro.RoleID, getAllDecendants, ExcludeAgencyReps));
                }
            }

            if (ExcludeAgencyReps) { roles = roles.Where(o => !o.RoleName.Equals("Agency Representative")).ToList(); }
            return roles;
        }

        

        public static bool RoleIsEmpty(this ICSRole role)
        {
            if (role.IndividualID == Guid.Empty) { return true; }
            else { return false; }
        }

        public static List<GenericICSRole> GetGenericICSRoles(Guid SectionID = new Guid())
        {
            List<GenericICSRole> roles = new List<GenericICSRole>();
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("b641b761-70d1-4e72-a680-6437f1243797"), RoleName = "Claims Specialist", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "CLMS", RoleDescription = "The person who is responsible to manage all claims related activities (other than injury) for an incident", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("09c6dda0-a7d3-4f37-a1c0-71f9a53d3958"), RoleName = "Compensation/Claims Unit Leader", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "COMP", RoleDescription = "The person responsible for the overall management and direction of all administrative matters pertaining to compensation-for-injury and claims-related activities related to an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("59502c17-7626-47e4-aa6d-6bc21e5daa12"), RoleName = "Cost Unit Leader", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "COST", RoleDescription = "The person responsible for collecting all cost data, performing cost-effectiveness analyses, and providing cost estimates and cost-saving recommendations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("50eab15d-a087-400c-8044-892b8376f77a"), RoleName = "Commissary Manager", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "CMSY", RoleDescription = "The person responsible for commissary operations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("06321e4a-dd11-4210-932d-faf26bd94bdf"), RoleName = "Equipment time recorder", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "EQTR", RoleDescription = "The Equipment Time Recorder is responsible for tracking and posting equipment time on an incident", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("33805F34-CD3A-49AF-94FA-DA4058577B9B"), RoleName = "Finance/Administration Section Chief", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "FSC", RoleDescription = "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 7 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("b1bd1029-7ed2-420f-8256-1aaf26a3b10f"), RoleName = "Procurement Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "PROC", RoleDescription = "The person responsible for administering all financial matters pertaining to vendor contracts, leases, and fiscal agreements.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("c7ce5853-2b90-491f-99f3-b9e602408d32"), RoleName = "Personnel Time Recorder", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "PTRC", RoleDescription = "The person responsible for overseeing the recording of time for all personnel assigned to an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e125ec8e-b5d4-48d8-bc07-fc3aec30ef80"), RoleName = "Time Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.FinanceChiefGenericID, MnemonicAbrv = "TIME", RoleDescription = "The person responsible for recording personnel time.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("c128c464-396f-4a49-825c-e3f32deb827d"), RoleName = "Area Commander", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "ACDR", RoleDescription = "The person responsible to manage a very large incident that has multiple IMTs assigned. These teams may be established any time the incidents are close enough that oversight direction is required.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("9bff36ae-073b-41e1-a974-6b1f80059d41"), RoleName = "Agency Representative", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "AREP", RoleDescription = "The person assigned by a primary, assisting, or cooperating agency to an incident who has been delegated authority to make decisions affecting that agency’s participation at the incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("1096905E-A726-41D8-A8BC-2EAD61CCB2F7"), RoleName = "Incident Commander", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "ICT", RoleDescription = "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 0 });





            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("154d3e0f-02df-4ca6-a648-9a7a4767451f"), RoleName = "International Liaison Officer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "INLO", RoleDescription = "The person of the Sending Participants based at the Receiving Participants’ Coordinating Authority or a Receiving Participant’s Fire Centre who has been delegated authority to make decisions on matters affecting all the Sending Participants’ resources in the Receiving Participants’ country. The INLO reports directly to the Sending Participants’ Coordinating Authority.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("ad9ff46e-b1f1-4327-8303-2cbdd22322a5"), RoleName = "Information Officer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "IOF", RoleDescription = "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 1 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("9ba31b81-84c0-49f5-bf19-49973ff0e972"), RoleName = "Liaison Officer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "LOFR", RoleDescription = "A member of the Command Staff responsible for coordinating with representatives from cooperating and assisting agencies or organizations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 2 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("CE7166AF-9432-4F7A-B942-1250AF0B7C31"), RoleName = "Safety Officer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "SOF", RoleDescription = "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 3 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("51fe1a66-e0a6-41e4-885f-30edde6535c4"), RoleName = "Senior Agency Representative", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.IncidentCommanderGenericID, MnemonicAbrv = "SREP", RoleDescription = "The person representative of the Sending Participant based at a Receiving Participant’s Fire Centre, who has been delegated authority to make decisions on matters affecting the Sending Participant’s resources at an incident or within that jurisdiction.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d9f60716-1a32-4e93-9af3-d0a2a292c5ed"), RoleName = "Assistant Area Commander, Logistics", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "ACLC", RoleDescription = "The person responsible for providing facilities, services, and material at the Area Command level, and for ensuring effective use of critical resources and supplies among the incident management teams.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("45781e40-9c3a-4c8c-88c2-3fc526fc8f3c"), RoleName = "Base/Camp Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "BCMG", RoleDescription = "The person responsible for appropriate sanitation and facility management services in the assigned Base or Camp.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("34cba211-a779-4921-bce8-31712cd2c97a"), RoleName = "Communications Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "COML", RoleDescription = "The person responsible for developing plans for the effective use of incident communications equipment and facilities; installing and testing communications equipment; supervising the Incident Communications Center; distributing communications equipment to incident personnel; and maintaining and repairing communications equipment.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("aa0bd058-8176-426d-9183-80296471d306"), RoleName = "Communications Technician", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "COMT", RoleDescription = "The person responsible for installing, maintaining, and tracking communications equipment.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("5ba29bd0-0c6d-4fdd-b190-b9dab804295b"), RoleName = "Dispatcher", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "DISP", RoleDescription = "The person responsible for notifying resources to assigned incidents.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("54a24d38-708f-4c0c-a827-4b9c61c54014"), RoleName = "Facilities Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "FACL", RoleDescription = "The person responsible for laying out and operating incident facilities (Base, Camp(s), and ICP) and managing Base and Camp(s) operations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("7f5bbf49-65e3-4a0b-8145-d4194295d7ed"), RoleName = "Fire Cache Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "FCMG", RoleDescription = "The person responsible for supervision of the supply of fire equipment assembled in planned quantities or at a strategic location.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("0b99b816-98bd-4344-97c4-1a9cc1ed8edb"), RoleName = "Food Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "FDUL", RoleDescription = "The person responsible for determining feeding requirements at all incident facilities and for menu planning, determining cooking facilities required, food preparation, serving, providing potable water, and general maintenance of the food service areas.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("6b9456c9-3b96-454d-a605-eac1db2a72c6"), RoleName = "Ground Support Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "GSUL", RoleDescription = "The person responsible for the fueling, maintaining, and repairing of vehicles, and the transportation of personnel and supplies.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("B641C5D6-91FE-41DA-962E-9FEB7A7300A2"), RoleName = "Logistics Section Chief", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "LSC", RoleDescription = "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 6 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e7342ac9-e8e6-4820-90f2-60e861f91f3a"), RoleName = "Medical Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "MEDL", RoleDescription = "The person primarily responsible for developing the Medical Plan, obtaining medical aid and transportation for injured or ill incident personnel, and preparing reports and records.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e3550fff-57c6-4864-ae97-a0340d58cb6c"), RoleName = "Radio Operator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "RADO", RoleDescription = "The person responsible for passing accurate and timely information via incident radio communications. May also be required to document all communications and ensure regular check-ins by resources are completed.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d25302bb-f792-46cd-8418-59dcfd9a2f74"), RoleName = "Receiving/Distribution Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "RCDM", RoleDescription = "The person responsible for receiving and distributing all supplies and equipment (other than primary resources) and the service and repair of tools and equipment.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("9d227381-ca68-46b2-8b03-c9ab7e8e2929"), RoleName = "Small Engine Mechanic", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "SMEC", RoleDescription = "The person responsible for the repair and maintenance of small engines powering firefighting equipment, such as portable pumps, chainsaws etc.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("c97f5be4-dcac-4057-b0e0-842504619cce"), RoleName = "Supply Unit Clerk", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "SPUC", RoleDescription = "The person responsible for support to the Supply Unit", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("5d537d18-f32a-4880-9657-d3d63e33825e"), RoleName = "Supply Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "SPUL", RoleDescription = "The person responsible for ordering personnel, equipment, and supplies; receiving and storing all supplies for the incident; maintaining an inventory of supplies; and servicing nonexpendable supplies and equipment.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("33f9d378-f400-4eb6-b445-c7da824073c9"), RoleName = "Support Branch Director", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "SUBD", RoleDescription = "The person responsible for developing and implementing logistics plans in support of the Incident Action Plan. The Support Branch Director supervises the operations of the Supply, Facilities, and Ground Support Units.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("18e7d7fe-ba83-429b-99fe-074259b0a8ee"), RoleName = "Service Branch Director", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "SVBD", RoleDescription = "The person responsible for managing all service activities at the incident. The Service Branch Director supervises the operations of the Communications, Medical, and Food Unit Leaders.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("f219c981-8963-4b86-ab4a-47b05a5b1174"), RoleName = "Ordering Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.LogisticsChiefGenericID, MnemonicAbrv = "", RoleDescription = "", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("959f0c39-efcb-451b-a4d9-777de7d83173"), RoleName = "Air Attack Officer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "AAON", RoleDescription = "The person responsible for directing, coordinating, and supervising a fire suppression operation involving the use of aircraft to deliver retardants or suppressants on a fire.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("b97d020e-608e-4ea0-9df7-63b2b7680f0e"), RoleName = "Air Operations Branch Director", ReportsToGenericRoleID = Globals.OpsChiefGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "AOBD", RoleDescription = "The person primarily responsible for managing the resources within the air operations branch, as well as preparing and implementing the air operations portion of the Incident Action Plan. Also responsible for providing logistical support to helicopters operating on the incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("3ee30239-afa6-4fbb-b187-1755e3a84f02"), RoleName = "Air Support Group Supervisor", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "ASGS", RoleDescription = "The person responsible for planning and oversight of incident aircraft support functions (helibase, helispot and Fixed Wing Air Bases).", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("94a21d86-3358-4976-bf1b-1c1e74d1ccf7"), RoleName = "Air Tactical Group Supervisor", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "ATGS", RoleDescription = "The person primarily responsible for the coordination of all tactical missions of fixed and/or rotary wing aircraft operating in incident airspace.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("449cdd3c-5bac-4b0b-ab34-54cb9b44bb2f"), RoleName = "Crew Leader 1 ", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRL1", RoleDescription = "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("1165d6b3-4b89-4b76-b2d4-3ae0e5a73a13"), RoleName = "Crew Leader 2", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRL2", RoleDescription = "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("28f70e30-bf6f-46cd-aa7e-7062f1dfccf9"), RoleName = "Crew Leader 3", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRL3", RoleDescription = "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d675c3bb-f8c2-4037-b74f-8c7f60c4b2b5"), RoleName = "Crew Member 1", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRM1", RoleDescription = "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("fbb221f2-e85c-41a7-a789-7fa10972365f"), RoleName = "Crew Member 2", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRM2", RoleDescription = "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("eb181283-c732-4feb-8aea-9e736dbe176b"), RoleName = "Crew Member 3", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRM3", RoleDescription = "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("48a9c50e-625f-44b5-abca-efd2024e74dc"), RoleName = "Crew - Type 1", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRW1", RoleDescription = "The primary fire response force consisting of 3 to 21 persons and meet all requirements of the Interagency Exchange Standards. Defined as Initial Attack Crews (IAC) or Sustained Action Crews (SAC).", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("9a01a396-fd8c-4c11-ac2e-ec1961c8308c"), RoleName = "Crew - Type 2", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRW2", RoleDescription = "Crews intended for utilization on low to moderate complexity sustained action operations and meet all requirements of the Interagency Exchange Standards.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("fed66e7b-1500-4bbd-8cfc-09a64223e502"), RoleName = "Crew - Type 3", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "CRW3", RoleDescription = "Generally made up of temporary firefighter forces used for mop up situations that have received some type of basic agency firefighting training.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("738957c1-1214-43aa-aa63-d74639397aad"), RoleName = "Division Supervisor", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "DIVS", RoleDescription = "The person responsible for supervising equipment and personnel assigned to a division. Reports to a Branch Director or Operations Section Chief.", RoleNameWithPlaceholder = "Division [OpGroupName] Supervisor", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("37f3c7ec-38e2-4b33-9ad9-b7b6bf14ac6a"), RoleName = "Dozer Boss", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "DOZB", RoleDescription = "The person responsible to lead a single bulldozer and attached personnel and is responsible for their safety on wildland and prescribed fire incidents.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("4e6dc284-2aa5-4b3c-bc7a-2066ce48737f"), RoleName = "Engine Boss", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "ENGB", RoleDescription = "The person that leads a single fire engine and attached personnel and is responsible for their safety on wildland and prescribed fire incidents.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("0c3155cc-4ac7-44e9-89ec-0aa03740d6db"), RoleName = "Engine Operator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "ENOP", RoleDescription = "The person responsible for the safe and efficient use of a wildland fire engine on an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d84fbe7b-16cc-48b9-b4b7-bde7f5f1f90e"), RoleName = "Faller", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "FALL", RoleDescription = "A person who is qualified under workplace regulations to fall non danger trees on an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("4ffbc8e5-cc32-432c-96cc-0213246fb90d"), RoleName = "Firing Boss", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "FIRB", RoleDescription = "The person responsible for ground and/or aerial ignition operations and coordinates with resources on wildland and prescribed fire incidents.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("a5271541-2cf0-4302-a1fa-45ac92192c30"), RoleName = "Field Observer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "FOBS", RoleDescription = "The person responsible for collecting incident status information from personal observations at the incident and providing this information to the activated function, or other resources.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("8f9e390f-481a-4ba1-b39c-95abdbd4bdf5"), RoleName = "Fixed Wing Base Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "FWBM", RoleDescription = "The person responsible for supervision and coordination at a fixed-wing base.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("39779979-7959-4a9a-9932-35983f747828"), RoleName = "Heavy Equipment Branch Director", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HEBD", RoleDescription = "The person responsible to supervise and manage the overall operations for all heavy equipment on an incident. This person will prioritize the need and allocation of heavy equipment for the incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("7b6e802c-e6a6-429c-bfaa-b79fc59e77c8"), RoleName = "Helibase Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HEBM", RoleDescription = "The person responsible for controlling helicopter take-offs and landings at a helibase, managing helibase assigned helicopters, supplies, fire retardant mixing and loading.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("ea90c0ab-4b9f-42ad-9b1f-fc668c207bd7"), RoleName = "Heavy Equipment Group Supervisor", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HEGS", RoleDescription = "The person responsible for supervising and directing operations of assigned heavy equipment, including heavy equipment strike teams/task forces or single resources.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("c7793e37-addb-4add-b286-e7813596f11a"), RoleName = "Helicopter engineer", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HENG", RoleDescription = "The person responsible for the maintenance of a helicopter.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("500180a7-10c9-439a-9ecc-8e8516dd6269"), RoleName = "Heavy Equipment Operator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HEOP", RoleDescription = "The person responsible for the safe and efficient operation of a single piece of heavy equipment on an incident", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("dbabe1e3-d1c9-4f1d-83c9-5295e0c26933"), RoleName = "Helispot Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HESM", RoleDescription = "The person responsible for managing all resources assigned to a helispot.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("a8088ec1-a930-4340-9591-2b87c7a6c8ef"), RoleName = "Helicopter Coordinator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HLCO", RoleDescription = "The person responsible for coordinating tactical or logistical helicopter mission(s) at an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("1f9b70b1-3526-4829-a142-398b2566c926"), RoleName = "Helitorch Mixmaster", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "HTMM", RoleDescription = "The person responsible to supervise mixing/filling operation and manages time frames to maintain availability of helitorch fuel.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("3e406b19-c317-489f-b99c-d5973217352a"), RoleName = "Ignition Specialist", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "IGSP", RoleDescription = "The person responsible for directing and supervising all aspects of an ignition team in the performance of tactical ignition operational assignments on wildfires and prescribed burns.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("0df3d767-2352-4daa-be19-b3ed03341ce4"), RoleName = "Loadmaster", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "LOAD", RoleDescription = "The person responsible for the safe loading and unloading of personnel and or cargo from aircraft.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d4853492-a7f3-4eb0-93bd-648f7ebef818"), RoleName = "Line scout", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "LSCT", RoleDescription = "A person responsible to determine the location of a fire line.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("8fda3297-4665-4726-809d-a70ba1452c18"), RoleName = "Mixmaster", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "MXMS", RoleDescription = "The person in charge of fire retardant mixing operations, with responsibility for quantity and quality of retardant and for the loading of aircraft in land based operations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("2b6670c1-1252-44ab-b6c7-2d095c7dddc0"), RoleName = "Operations Branch Director", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "OPBD", RoleDescription = "The person responsible for implementing the portion of the Incident Action Plan applicable to the assigned Branch of the Operations Section.", RoleNameWithPlaceholder = "Operations Branch [OpGroupName] Director", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("CFE4C7DE-BD61-421C-8167-1B55E4151CFC"), RoleName = "Operations Section Chief", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "OSC", RoleDescription = "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 4 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("23fb0371-67fd-452e-8a7e-8fa3778d7903"), RoleName = "Prescribed Fire Specialist", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "PBSP", RoleDescription = "The person responsible for creating burn plans for prescribed fire, to ensure the best ecological results in the safest procedure.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("ac1b9c06-cff3-4da9-ac14-f97a95e254db"), RoleName = "Plastic Sphere Dispenser Operator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "PLDO", RoleDescription = "The person responsible to utilize the Plastic Sphere Dispenser for aerial ignition operations.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("536d964f-8b91-40fb-8080-d127582dd9df"), RoleName = "Sector Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "SCLD", RoleDescription = "The person responsible for directing a combination of personnel, crews, or other types of equipment in performing tactical missions on a sector (specific piece of fire line).", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e7ac2b14-3eaa-4665-b7d7-2e539a25ff98"), RoleName = "Smoke Jumper", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "SMKJ", RoleDescription = "A firefighter who travels to wildland fires by fixed wing aircraft and parachute.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("2b675f60-9d69-4ea5-aceb-17e25e937914"), RoleName = "Staging Area Manager", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "STAM", RoleDescription = "The person responsible for managing all activities within a Staging Area.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("fe51d017-0be6-4547-b38c-3851492cbf9e"), RoleName = "Strike Team Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "STLD", RoleDescription = "The individual responsible for supervising a strike team (usually dozers, engines, or crews), and reports to a Division/Group Supervisor or Operations Section Chief.", RoleNameWithPlaceholder = "Strike Team [OpGroupName] Leader", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("5f427013-15d9-480b-9cdf-31247af0451e"), RoleName = "Task Force Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "TFLD", RoleDescription = "The individual responsible for supervising a task force. Reports to a Division/Group Supervisor or Operations Section Chief.", RoleNameWithPlaceholder = "Task Force [OpGroupName] Leader", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("504b6131-411b-451d-a92a-2ed59d27b492"), RoleName = "Operational Group Supervisor", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.OpsChiefGenericID, MnemonicAbrv = "DIVS", RoleDescription = "", RoleNameWithPlaceholder = "[OpGroupName] Group Supervisor", OnInitialOrgChart = false, RequiresOperationalGroup = true, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("d77074cf-f4af-4f7e-a5fa-761daa12fd0e"), RoleName = "Demobilization Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "DMOB", RoleDescription = "The person is responsible for preparing the Demobilization Plan and schedule ensuring an orderly, safe, and efficient movement of personnel and equipment from the incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("5bea1a1c-6963-4b16-af1d-3e9e11bd5b8a"), RoleName = "Documentation Unit Leader", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "DOCL", RoleDescription = "The person responsible for maintaining accurate and complete incident files, providing duplication services to incident personnel, and packing and storing incident files.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("39c1ff35-566d-4c9c-ae87-d84d3991de84"), RoleName = "Fire Behaviour Analyst", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "FBAN", RoleDescription = "A specialist position under the plans function of a fire incident management team responsible for making predictions of probable fire behaviour based on an analysis of the current and forecasted state of the fire environment.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("6e6e9e9a-1dd9-4521-922e-489ec018efde"), RoleName = "Fire Investigator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "FINV", RoleDescription = "The person responsible to determine the origin, cause, and development of a wildland fire.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("b810c3ad-e0d9-4724-8663-df27484a5685"), RoleName = "Geographic Information System Specialist", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "GISS", RoleDescription = "The person responsible for providing timely and accurate spatial information to be used by all facets of the IMT.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("5ddad851-f218-4d7a-873c-e1563ffceb8e"), RoleName = "Incident Meteorologist", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "IMET", RoleDescription = "The person responsible for on-site meteorological support to an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("37f9ce0b-5b41-41a1-b176-bde81a2fcf04"), RoleName = "Infrared Interpreter", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "IRIN", RoleDescription = "The person responsible for directing infrared mapping operations when assigned.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("515732e5-7df2-4645-a8f6-7e5d0187b4d9"), RoleName = "Infrared Operator", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "IROP", RoleDescription = "The person responsible for infrared scanning and mapping operations when assigned to an incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("A0B226FA-33FA-45C7-91AE-7D4F498FD31B"), RoleName = "Planning Section Chief", ReportsToGenericRoleID = Globals.IncidentCommanderGenericID, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "PSC", RoleDescription = "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned.", RoleNameWithPlaceholder = "", OnInitialOrgChart = true, RequiresOperationalGroup = false, ManualSortOrder = 5 });


            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("98cc41e2-a1b3-41c0-9ec8-d8976324846e"), RoleName = "Resource Clerk", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "RESC", RoleDescription = "The person responsible for support to the Resource Unit.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("a5d6ea6d-f938-454d-bc4c-37e35b2d6f62"), RoleName = "Resources Unit Leader", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "RESL", RoleDescription = "The person responsible for establishing all incident check-in activities; preparing and processing resource status information; preparing and maintaining displays, charts, and lists that reflect the current status and location of suppression resources, transportation, and support vehicles; and maintaining a master check-in list of resources assigned to the incident.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("4ab2901e-dc27-45a4-9a82-f5addbc298de"), RoleName = "Status/Check-in Recorders", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "SCKN", RoleDescription = "The person responsible, at each check in location, to ensure that all resources assigned to an incident are accounted for.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("b4eb6db0-c976-4a75-b2fc-a4387b77da29"), RoleName = "Situation Unit Leader", ReportsToGenericRoleID = Guid.Empty, SectionID = Globals.PlanningChiefGenericID, MnemonicAbrv = "SITL", RoleDescription = "The person responsible for collecting and organizing incident status and information and evaluating, analyzing, and displaying that information.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e6932687-cbed-4863-ad9e-aa27a94cf847"), RoleName = "Clerk", ReportsToGenericRoleID = Guid.Empty, SectionID = Guid.Empty, MnemonicAbrv = "CLRK", RoleDescription = "The person who is responsible to provide administrative support to any Section as assigned.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("4cf96e9b-9a07-489e-8289-5b71463d94e9"), RoleName = "Technical Specialist", ReportsToGenericRoleID = Guid.Empty, SectionID = Guid.Empty, MnemonicAbrv = "THSP", RoleDescription = "Personnel with special skills that can be used anywhere within the Incident Command System organization.", RoleNameWithPlaceholder = "", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });
            roles.Add(new GenericICSRole() { GenericRoleID = new Guid("e30cdf2c-5b0f-4836-8c55-00544d43b476"), RoleName = "Deputy", ReportsToGenericRoleID = Guid.Empty, SectionID = Guid.Empty, MnemonicAbrv = "", RoleDescription = "", RoleNameWithPlaceholder = "Deputy [ReportsToName]", OnInitialOrgChart = false, RequiresOperationalGroup = false, ManualSortOrder = 0 });

            if (SectionID != Guid.Empty) { roles = roles.Where(o => o.SectionID == SectionID || o.SectionID == Guid.Empty).ToList(); }

            foreach(GenericICSRole role in roles.Where(o=>o.ReportsToGenericRoleID == Globals.IncidentCommanderGenericID && o.GenericRoleID != Globals.IncidentCommanderGenericID))
            {
                role.Depth = 1;
                foreach(GenericICSRole subrole in roles.Where(o=>o.ReportsToGenericRoleID == role.GenericRoleID))
                {
                    subrole.Depth = role.Depth + 1;
                }
            }
            return roles;
        }

        /*
        public static List<ICSRole> GetAllRoles()
        {
            //This is an exhuastive list of all possible ics role names from CIFFC and includes mnemonic and description 
            List<ICSRole> allRoles = new List<ICSRole>();
            allRoles.Add(new ICSRole("Air Attack Officer", Globals.OpsChiefID, "AAON", "The person responsible for directing, coordinating, and supervising a fire suppression operation involving the use of aircraft to deliver retardants or suppressants on a fire."));
            allRoles.Add(new ICSRole("Area Commander", Globals.IncidentCommanderID, "ACDR", "The person responsible to manage a very large incident that has multiple IMTs assigned. These teams may be established any time the incidents are close enough that oversight direction is required."));
            allRoles.Add(new ICSRole("Assistant Area Commander, Logistics", Globals.LogisticsChiefID, "ACLC", "The person responsible for providing facilities, services, and material at the Area Command level, and for ensuring effective use of critical resources and supplies among the incident management teams."));

            allRoles.Add(new ICSRole("Agency Representative", Globals.IncidentCommanderID, "AREP", "The person assigned by a primary, assisting, or cooperating agency to an incident who has been delegated authority to make decisions affecting that agency’s participation at the incident."));
            allRoles.Add(new ICSRole("Base/Camp Manager", Globals.LogisticsChiefID, "BCMG", "The person responsible for appropriate sanitation and facility management services in the assigned Base or Camp."));
            allRoles.Add(new ICSRole("Claims Specialist", Globals.FinanceChiefID, "CLMS", "The person who is responsible to manage all claims related activities (other than injury) for an incident"));
            allRoles.Add(new ICSRole("Clerk", Guid.Empty, "CLRK", "The person who is responsible to provide administrative support to any Section as assigned."));
            allRoles.Add(new ICSRole("Communications Unit Leader", Globals.LogisticsChiefID, "COML", "The person responsible for developing plans for the effective use of incident communications equipment and facilities; installing and testing communications equipment; supervising the Incident Communications Center; distributing communications equipment to incident personnel; and maintaining and repairing communications equipment."));
            allRoles.Add(new ICSRole("Compensation/Claims Unit Leader", Globals.FinanceChiefID, "COMP", "The person responsible for the overall management and direction of all administrative matters pertaining to compensation-for-injury and claims-related activities related to an incident."));
            allRoles.Add(new ICSRole("Communications Technician", Globals.LogisticsChiefID, "COMT", "The person responsible for installing, maintaining, and tracking communications equipment."));
            allRoles.Add(new ICSRole("Cost Unit Leader", Globals.FinanceChiefID, "COST", "The person responsible for collecting all cost data, performing cost-effectiveness analyses, and providing cost estimates and cost-saving recommendations."));
            allRoles.Add(new ICSRole("Crew Leader 1 ", Globals.OpsChiefID, "CRL1", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Leader 2", Globals.OpsChiefID, "CRL2", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Leader 3", Globals.OpsChiefID, "CRL3", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 1", Globals.OpsChiefID, "CRM1", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 2", Globals.OpsChiefID, "CRM2", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 3", Globals.OpsChiefID, "CRM3", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew - Type 1", Globals.OpsChiefID, "CRW1", "The primary fire response force consisting of 3 to 21 persons and meet all requirements of the Interagency Exchange Standards. Defined as Initial Attack Crews (IAC) or Sustained Action Crews (SAC)."));
            allRoles.Add(new ICSRole("Crew - Type 2", Globals.OpsChiefID, "CRW2", "Crews intended for utilization on low to moderate complexity sustained action operations and meet all requirements of the Interagency Exchange Standards."));
            allRoles.Add(new ICSRole("Crew - Type 3", Globals.OpsChiefID, "CRW3", "Generally made up of temporary firefighter forces used for mop up situations that have received some type of basic agency firefighting training."));
            allRoles.Add(new ICSRole("Commissary Manager", Globals.FinanceChiefID, "CMSY", "The person responsible for commissary operations."));
            allRoles.Add(new ICSRole("Dispatcher", Globals.LogisticsChiefID, "DISP", "The person responsible for notifying resources to assigned incidents."));

            //these roles need expanded features 
            allRoles.Add(new ICSRole("Division Supervisor", Globals.OpsChiefID, "DIVS", "The person responsible for supervising equipment and personnel assigned to a division. Reports to a Branch Director or Operations Section Chief."));
            allRoles.Where(o => o.MnemonicAbrv.Equals("DIVS")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Operations Branch Director", Globals.OpsChiefID, "OPBD", "The person responsible for implementing the portion of the Incident Action Plan applicable to the assigned Branch of the Operations Section."));
            allRoles.Where(o => o.MnemonicAbrv.Equals("OPBD")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Heavy Equipment Branch Director", Globals.OpsChiefID, "HEBD", "The person responsible to supervise and manage the overall operations for all heavy equipment on an incident. This person will prioritize the need and allocation of heavy equipment for the incident."));
            allRoles.Where(o => o.MnemonicAbrv.Equals("HEBD")).First().IsOpGroupSup = true;


            allRoles.Add(new ICSRole("Strike Team Leader", Globals.OpsChiefID, "STLD", "The individual responsible for supervising a strike team (usually dozers, engines, or crews), and reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Where(o => o.MnemonicAbrv.Equals("STLD")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Task Force Leader", Globals.OpsChiefID, "TFLD", "The individual responsible for supervising a task force. Reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Where(o => o.MnemonicAbrv.Equals("TFLD")).First().IsOpGroupSup = true;

            allRoles.Add(new ICSRole("Air Operations Branch Director", Globals.OpsChiefID, "AOBD", "The person primarily responsible for managing the resources within the air operations branch, as well as preparing and implementing the air operations portion of the Incident Action Plan. Also responsible for providing logistical support to helicopters operating on the incident.")); allRoles.Where(o => o.MnemonicAbrv.Equals("AOBD")).First().IsOpGroupSup = true;


            allRoles.Add(new ICSRole("Air Support Group Supervisor", Globals.OpsChiefID, "ASGS", "The person responsible for planning and oversight of incident aircraft support functions (helibase, helispot and Fixed Wing Air Bases).")); allRoles.Where(o => o.MnemonicAbrv.Equals("ASGS")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Air Tactical Group Supervisor", Globals.OpsChiefID, "ATGS", "The person primarily responsible for the coordination of all tactical missions of fixed and/or rotary wing aircraft operating in incident airspace.")); allRoles.Where(o => o.MnemonicAbrv.Equals("ATGS")).First().IsOpGroupSup = true;


            //Does this one need a group?
            allRoles.Add(new ICSRole("Heavy Equipment Group Supervisor", Globals.OpsChiefID, "HEGS", "The person responsible for supervising and directing operations of assigned heavy equipment, including heavy equipment strike teams/task forces or single resources."));
            allRoles.Add(new ICSRole("Sector Leader", Globals.OpsChiefID, "SCLD", "The person responsible for directing a combination of personnel, crews, or other types of equipment in performing tactical missions on a sector (specific piece of fire line)."));



            allRoles.Add(new ICSRole("Demobilization Unit Leader", Globals.PlanningChiefID, "DMOB", "The person is responsible for preparing the Demobilization Plan and schedule ensuring an orderly, safe, and efficient movement of personnel and equipment from the incident."));
            allRoles.Add(new ICSRole("Documentation Unit Leader", Globals.PlanningChiefID, "DOCL", "The person responsible for maintaining accurate and complete incident files, providing duplication services to incident personnel, and packing and storing incident files."));
            allRoles.Add(new ICSRole("Dozer Boss", Globals.OpsChiefID, "DOZB", "The person responsible to lead a single bulldozer and attached personnel and is responsible for their safety on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Engine Boss", Globals.OpsChiefID, "ENGB", "The person that leads a single fire engine and attached personnel and is responsible for their safety on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Engine Operator", Globals.OpsChiefID, "ENOP", "The person responsible for the safe and efficient use of a wildland fire engine on an incident."));
            allRoles.Add(new ICSRole("Equipment time recorder", Globals.FinanceChiefID, "EQTR", "The Equipment Time Recorder is responsible for tracking and posting equipment time on an incident"));
            allRoles.Add(new ICSRole("Facilities Unit Leader", Globals.LogisticsChiefID, "FACL", "The person responsible for laying out and operating incident facilities (Base, Camp(s), and ICP) and managing Base and Camp(s) operations."));
            allRoles.Add(new ICSRole("Faller", Globals.OpsChiefID, "FALL", "A person who is qualified under workplace regulations to fall non danger trees on an incident."));
            allRoles.Add(new ICSRole("Fire Behaviour Analyst", Globals.PlanningChiefID, "FBAN", "A specialist position under the plans function of a fire incident management team responsible for making predictions of probable fire behaviour based on an analysis of the current and forecasted state of the fire environment."));
            allRoles.Add(new ICSRole("Fire Cache Manager", Globals.LogisticsChiefID, "FCMG", "The person responsible for supervision of the supply of fire equipment assembled in planned quantities or at a strategic location."));
            allRoles.Add(new ICSRole("Food Unit Leader", Globals.LogisticsChiefID, "FDUL", "The person responsible for determining feeding requirements at all incident facilities and for menu planning, determining cooking facilities required, food preparation, serving, providing potable water, and general maintenance of the food service areas."));
            allRoles.Add(new ICSRole("Fire Investigator", Globals.PlanningChiefID, "FINV", "The person responsible to determine the origin, cause, and development of a wildland fire."));
            allRoles.Add(new ICSRole("Firing Boss", Globals.OpsChiefID, "FIRB", "The person responsible for ground and/or aerial ignition operations and coordinates with resources on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Field Observer", Globals.OpsChiefID, "FOBS", "The person responsible for collecting incident status information from personal observations at the incident and providing this information to the activated function, or other resources."));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief", Globals.FinanceChiefID, "FSC", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief 1", Globals.FinanceChiefID, "FSC1", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief 2", Globals.FinanceChiefID, "FSC2", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Fixed Wing Base Manager", Globals.OpsChiefID, "FWBM", "The person responsible for supervision and coordination at a fixed-wing base."));
            allRoles.Add(new ICSRole("Geographic Information System Specialist", Globals.PlanningChiefID, "GISS", "The person responsible for providing timely and accurate spatial information to be used by all facets of the IMT."));
            allRoles.Add(new ICSRole("Ground Support Unit Leader", Globals.LogisticsChiefID, "GSUL", "The person responsible for the fueling, maintaining, and repairing of vehicles, and the transportation of personnel and supplies."));

            allRoles.Add(new ICSRole("Helibase Manager", Globals.OpsChiefID, "HEBM", "The person responsible for controlling helicopter take-offs and landings at a helibase, managing helibase assigned helicopters, supplies, fire retardant mixing and loading."));
            allRoles.Add(new ICSRole("Helicopter engineer", Globals.OpsChiefID, "HENG", "The person responsible for the maintenance of a helicopter."));
            allRoles.Add(new ICSRole("Heavy Equipment Operator", Globals.OpsChiefID, "HEOP", "The person responsible for the safe and efficient operation of a single piece of heavy equipment on an incident"));
            allRoles.Add(new ICSRole("Helispot Manager", Globals.OpsChiefID, "HESM", "The person responsible for managing all resources assigned to a helispot."));
            allRoles.Add(new ICSRole("Helicopter Coordinator", Globals.OpsChiefID, "HLCO", "The person responsible for coordinating tactical or logistical helicopter mission(s) at an incident."));
            allRoles.Add(new ICSRole("Helitorch Mixmaster", Globals.OpsChiefID, "HTMM", "The person responsible to supervise mixing/filling operation and manages time frames to maintain availability of helitorch fuel."));
            allRoles.Add(new ICSRole("Incident Commander", Globals.IncidentCommanderID, "ICT", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 1", Globals.IncidentCommanderID, "ICT1", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 2", Globals.IncidentCommanderID, "ICT2", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 3", Globals.IncidentCommanderID, "ICT3", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 4", Globals.IncidentCommanderID, "ICT4", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 5", Globals.IncidentCommanderID, "ICT5", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Ignition Specialist", Globals.OpsChiefID, "IGSP", "The person responsible for directing and supervising all aspects of an ignition team in the performance of tactical ignition operational assignments on wildfires and prescribed burns."));
            allRoles.Add(new ICSRole("Incident Meteorologist", Globals.PlanningChiefID, "IMET", "The person responsible for on-site meteorological support to an incident."));
            allRoles.Add(new ICSRole("International Liaison Officer", Globals.IncidentCommanderID, "INLO", "The person of the Sending Participants based at the Receiving Participants’ Coordinating Authority or a Receiving Participant’s Fire Centre who has been delegated authority to make decisions on matters affecting all the Sending Participants’ resources in the Receiving Participants’ country. The INLO reports directly to the Sending Participants’ Coordinating Authority."));
            allRoles.Add(new ICSRole("Information Officer", Globals.IncidentCommanderID, "IOF", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Information Officer 1", Globals.IncidentCommanderID, "IOF1", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Information Officer 2", Globals.IncidentCommanderID, "IOF2", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Infrared Interpreter", Globals.PlanningChiefID, "IRIN", "The person responsible for directing infrared mapping operations when assigned."));
            allRoles.Add(new ICSRole("Infrared Operator", Globals.PlanningChiefID, "IROP", "The person responsible for infrared scanning and mapping operations when assigned to an incident."));
            allRoles.Add(new ICSRole("Loadmaster", Globals.OpsChiefID, "LOAD", "The person responsible for the safe loading and unloading of personnel and or cargo from aircraft."));
            allRoles.Add(new ICSRole("Liaison Officer", Globals.IncidentCommanderID, "LOFR", "A member of the Command Staff responsible for coordinating with representatives from cooperating and assisting agencies or organizations."));
            allRoles.Add(new ICSRole("Logistics Section Chief", Globals.LogisticsChiefID, "LSC", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Logistics Section Chief 1", Globals.LogisticsChiefID, "LSC1", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Logistics Section Chief 2", Globals.LogisticsChiefID, "LSC2", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Line scout", Globals.OpsChiefID, "LSCT", "A person responsible to determine the location of a fire line."));
            allRoles.Add(new ICSRole("Medical Unit Leader", Globals.LogisticsChiefID, "MEDL", "The person primarily responsible for developing the Medical Plan, obtaining medical aid and transportation for injured or ill incident personnel, and preparing reports and records."));
            allRoles.Add(new ICSRole("Mixmaster", Globals.OpsChiefID, "MXMS", "The person in charge of fire retardant mixing operations, with responsibility for quantity and quality of retardant and for the loading of aircraft in land based operations."));

            allRoles.Add(new ICSRole("Operations Section Chief", Globals.OpsChiefID, "OSC", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Operations Section Chief 1", Globals.OpsChiefID, "OSC1", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Operations Section Chief 2", Globals.OpsChiefID, "OSC2", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Prescribed Fire Specialist", Globals.OpsChiefID, "PBSP", "The person responsible for creating burn plans for prescribed fire, to ensure the best ecological results in the safest procedure."));
            allRoles.Add(new ICSRole("Plastic Sphere Dispenser Operator", Globals.OpsChiefID, "PLDO", "The person responsible to utilize the Plastic Sphere Dispenser for aerial ignition operations."));
            allRoles.Add(new ICSRole("Procurement Unit Leader", Globals.FinanceChiefID, "PROC", "The person responsible for administering all financial matters pertaining to vendor contracts, leases, and fiscal agreements."));
            allRoles.Add(new ICSRole("Planning Section Chief", Globals.PlanningChiefID, "PSC", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Planning Section Chief 1", Globals.PlanningChiefID, "PSC1", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Planning Section Chief 2", Globals.PlanningChiefID, "PSC2", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Personnel Time Recorder", Globals.FinanceChiefID, "PTRC", "The person responsible for overseeing the recording of time for all personnel assigned to an incident."));
            allRoles.Add(new ICSRole("Radio Operator", Globals.LogisticsChiefID, "RADO", "The person responsible for passing accurate and timely information via incident radio communications. May also be required to document all communications and ensure regular check-ins by resources are completed."));
            allRoles.Add(new ICSRole("Receiving/Distribution Manager", Globals.LogisticsChiefID, "RCDM", "The person responsible for receiving and distributing all supplies and equipment (other than primary resources) and the service and repair of tools and equipment."));
            allRoles.Add(new ICSRole("Resource Clerk", Globals.PlanningChiefID, "RESC", "The person responsible for support to the Resource Unit."));
            allRoles.Add(new ICSRole("Resources Unit Leader", Globals.PlanningChiefID, "RESL", "The person responsible for establishing all incident check-in activities; preparing and processing resource status information; preparing and maintaining displays, charts, and lists that reflect the current status and location of suppression resources, transportation, and support vehicles; and maintaining a master check-in list of resources assigned to the incident."));
            allRoles.Add(new ICSRole("Status/Check-in Recorders", Globals.PlanningChiefID, "SCKN", "The person responsible, at each check in location, to ensure that all resources assigned to an incident are accounted for."));

            allRoles.Add(new ICSRole("Situation Unit Leader", Globals.PlanningChiefID, "SITL", "The person responsible for collecting and organizing incident status and information and evaluating, analyzing, and displaying that information."));
            allRoles.Add(new ICSRole("Small Engine Mechanic", Globals.LogisticsChiefID, "SMEC", "The person responsible for the repair and maintenance of small engines powering firefighting equipment, such as portable pumps, chainsaws etc."));
            allRoles.Add(new ICSRole("Smoke Jumper", Globals.OpsChiefID, "SMKJ", "A firefighter who travels to wildland fires by fixed wing aircraft and parachute."));
            allRoles.Add(new ICSRole("Safety Officer", Globals.IncidentCommanderID, "SOF", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Safety Officer 1", Globals.IncidentCommanderID, "SOF1", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Safety Officer 2", Globals.IncidentCommanderID, "SOF2", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Supply Unit Clerk", Globals.LogisticsChiefID, "SPUC", "The person responsible for support to the Supply Unit"));
            allRoles.Add(new ICSRole("Supply Unit Leader", Globals.LogisticsChiefID, "SPUL", "The person responsible for ordering personnel, equipment, and supplies; receiving and storing all supplies for the incident; maintaining an inventory of supplies; and servicing nonexpendable supplies and equipment."));
            allRoles.Add(new ICSRole("Senior Agency Representative", Globals.IncidentCommanderID, "SREP", "The person representative of the Sending Participant based at a Receiving Participant’s Fire Centre, who has been delegated authority to make decisions on matters affecting the Sending Participant’s resources at an incident or within that jurisdiction."));
            allRoles.Add(new ICSRole("Staging Area Manager", Globals.OpsChiefID, "STAM", "The person responsible for managing all activities within a Staging Area."));
            allRoles.Add(new ICSRole("Support Branch Director", Globals.LogisticsChiefID, "SUBD", "The person responsible for developing and implementing logistics plans in support of the Incident Action Plan. The Support Branch Director supervises the operations of the Supply, Facilities, and Ground Support Units."));
            allRoles.Add(new ICSRole("Service Branch Director", Globals.LogisticsChiefID, "SVBD", "The person responsible for managing all service activities at the incident. The Service Branch Director supervises the operations of the Communications, Medical, and Food Unit Leaders."));
            allRoles.Add(new ICSRole("Technical Specialist", Guid.Empty, "THSP", "Personnel with special skills that can be used anywhere within the Incident Command System organization."));
            allRoles.Add(new ICSRole("Time Unit Leader", Globals.FinanceChiefID, "TIME", "The person responsible for recording personnel time."));
            allRoles.Add(new ICSRole("Ordering Manager", Globals.LogisticsChiefID, "", ""));

            allRoles.Add(new ICSRole("Deputy", Guid.Empty, "", "", true));
            allRoles.Add(new ICSRole("Trainee", Guid.Empty, "", "", true));
            allRoles.Add(new ICSRole("Assistant", Guid.Empty, "", "", true));


            return allRoles;
        }
        */

        public static List<ICSRole> GetBlankPrimaryRoles(bool UnifiedCommand = false)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();
            List<GenericICSRole> InitialGenericRoles = GetGenericICSRoles().Where(o=>o.OnInitialOrgChart).ToList();
            foreach(GenericICSRole role in InitialGenericRoles)
            {
                AllRoles.Add(new ICSRole(role));
            }
            //AllRoles.Add(new ICSRole(new Guid("98649093-2C0D-4D23-9EC1-2AF16ED83B2A"), "SAR Commander", Guid.Empty, "Text1", blankMember));
           
            if (UnifiedCommand)
            {
                AllRoles = AllRoles.GetUnifiedCommandRoles();
            }

            AllRoles = AllRoles.OrderBy(o => o.Depth).ThenBy(o => o.RoleName).ToList();

            return AllRoles;
        }


        /*
        public static List<ICSRole> GetBlankPrimaryRoles(bool UnifiedCommand = false)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();
            //AllRoles.Add(new ICSRole(new Guid("98649093-2C0D-4D23-9EC1-2AF16ED83B2A"), "SAR Commander", Guid.Empty, "Text1", blankMember));
            AllRoles.Add(new ICSRole(Globals.IncidentCommanderID, "Incident Commander", Guid.Empty, Globals.IncidentCommanderID, "IncidentCommander", blankMember, 0, 0));
            if (UnifiedCommand)
            {
                AllRoles = AllRoles.AddUnifiedCommandRoles();
            }

            AllRoles.Add(new ICSRole(new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA"), "Deputy", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "DeputyIC", "TitleDeputyIC", blankMember, 1, 1, true));
            AllRoles.FirstOrDefault(o => o.RoleID == new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA")).RoleName = "Deputy Incident Commander";

            AllRoles.Add(new ICSRole(Globals.SafetyOfficerID, "Safety Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "SafetyOfficer", blankMember, 2, 1));
            AllRoles.Add(new ICSRole(new Guid("8428ed1e-80de-4b5d-a7ab-ae48ad5f1bce"), "Clerk", Globals.SafetyOfficerID, Globals.IncidentCommanderID, "NameSafety1", "TitleSafety1", blankMember, 2, 1));

            AllRoles.Add(new ICSRole(new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), "Liaison Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "LiaisonOfficer", blankMember, 3, 1));
            AllRoles.Add(new ICSRole(new Guid("63394cb1-443c-4492-9e7b-d15e22226b6b"), "Clerk", new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), Globals.IncidentCommanderID, "NameLiaison1", "TitleLiaison1", blankMember, 3, 1));
            
            AllRoles.Add(new ICSRole(new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), "Information Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "Text2", blankMember, 4, 1));
            AllRoles.Add(new ICSRole(new Guid("f4975464-ed47-43ee-a229-47fd9997ebd9"), "Clerk", new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), Globals.IncidentCommanderID, "NameInfo1", "TitleInfo1", blankMember, 4, 1));

            //Ops
            AllRoles.Add(new ICSRole(Globals.OpsChiefID, "Operations Section Chief", Globals.IncidentCommanderID, Globals.OpsChiefID, "Text3", blankMember, 5, 1)); AllRoles.Where(o => o.RoleID == Globals.OpsChiefID).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(Globals.AirOpsDirector, "Air Operations Branch Director", Globals.OpsChiefID, Globals.OpsChiefID, "AirOpsDirector", blankMember, 98, 2));
            AllRoles.Where(o => o.RoleID == Globals.AirOpsDirector).First().IsOpGroupSup = true;

            AllRoles.Add(new ICSRole(new Guid("0da445fe-99d5-4cfe-b746-cbe46b20e314"), "Air Support Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3)); AllRoles.Where(o => o.RoleID == new Guid("0da445fe-99d5-4cfe-b746-cbe46b20e314")).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(new Guid("f16d6d47-a334-4c88-9bbc-8034ee9c2a32"), "Air Tactical Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3)); AllRoles.Where(o => o.RoleID == new Guid("f16d6d47-a334-4c88-9bbc-8034ee9c2a32")).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(new Guid("b1fd775b-7311-4d9d-a1bf-a7d32c4d7ed2"), "Helicopter Coordinator", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("803955a6-973f-470e-a8a4-bd86197700c0"), "Helibase Manager", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));


            AllRoles.Add(new ICSRole(new Guid("3A79ED80-9B06-4923-95F7-BE1B8B554FFD"), "Staging Area Manager", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps1", "TitleOps1", blankMember, 97, 2));
            AllRoles.Add(new ICSRole(new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c"), "Branch/Division/Group1", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps2", "TitleOps2", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c")).First().IsPlaceholder = true;
            AllRoles.Add(new ICSRole(new Guid("9727f016-aed9-4f34-99db-910a06b97f2e"), "Branch/Division/Group2", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps3", "TitleOps3", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("9727f016-aed9-4f34-99db-910a06b97f2e")).First().IsPlaceholder = true;
            AllRoles.Add(new ICSRole(new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9"), "Branch/Division/Group3", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps4", "TitleOps4", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9")).First().IsPlaceholder = true;





            //Planning
            AllRoles.Add(new ICSRole(Globals.PlanningChiefID, "Planning Section Chief", Globals.IncidentCommanderID, Globals.PlanningChiefID, "Text8", blankMember, 6, 1));
            AllRoles.Add(new ICSRole(new Guid("A3891929-6FA4-4A21-BE33-F37DE24B779E"), "Situation Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans1", "TitlePlans1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("A7C2F2FB-3C96-4E60-83A1-3E97A6FE8BAA"), "Resources Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans2", "TitlePlans2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("3CB459EC-2C6B-40F8-9C5A-E59A393BA632"), "Demobilization Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans3", "TitlePlans3", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("B87A1F9C-FDE8-4671-BF06-4E275C62099F"), "Documentation Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans4", "TitlePlans4", blankMember, 99, 2));

            //Logistics
            AllRoles.Add(new ICSRole(Globals.LogisticsChiefID, "Logistics Section Chief", Globals.IncidentCommanderID, Globals.LogisticsChiefID, "Text9", blankMember, 7, 1));

            AllRoles.Add(new ICSRole(new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), "Service Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "NameLogistics1", "TitleLogistics1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("04FB00EB-97BA-4744-AB00-54D4D224ABAD"), "Communications Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics3", "TitleLogistics3", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("F214D2B3-9268-432F-84BF-848E80C53635"), "Medical Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics4", "TitleLogistics4", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("83BB316B-42A7-4238-A647-1B9C94EA6B5A"), "Food Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics5", "TitleLogistics5", blankMember, 99, 3));

            AllRoles.Add(new ICSRole(new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), "Support Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "NameLogistics2", "TitleLogistics2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9ABA549D-BA86-46D3-9C62-EC2F3FEC36F8"), "Facilities Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics6", "TitleLogistics6", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("CC4CC189-B92B-4DD6-87CC-5CD3200F600D"), "Supply Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics7", "TitleLogistics7", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("EDF0C322-76EE-448A-8D58-0820AAB9791B"), "Ground Support Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics8", "TitleLogistics8", blankMember, 99, 3));

            //Admin
            AllRoles.Add(new ICSRole(Globals.FinanceChiefID, "Finance/Administration Section Chief", Globals.IncidentCommanderID, Globals.FinanceChiefID, "Text10", blankMember, 8, 1));
            AllRoles.Add(new ICSRole(new Guid("2AD6BDAC-1AE2-47EF-AEE5-B8820B674C90"), "Procurement Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance1", "TitleFinance1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("E2B66759-A290-459A-B96F-3B8FE7B3D883"), "Time Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance2", "TitleFinance2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Cost Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance3", "TitleFinance3", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Compensation/Claims Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance4", "TitleFinance4", blankMember, 99, 2));

            foreach(ICSRole role in AllRoles)
            {
               

                if(AllRoles.Any(o=>o.RoleID == role.ReportsTo))
                {
                    role.ReportsToRoleName = AllRoles.First(o => o.RoleID == role.ReportsTo).RoleName;
                }
            }

            return AllRoles;
        }
        */

        public static string GetSectionName(Guid SectionID)
        {
            if(SectionID == Globals.IncidentCommanderGenericID) { return "Incident Command"; }
            if (SectionID == Globals.OpsChiefGenericID) { return "Operations"; }
            if (SectionID == Globals.PlanningChiefGenericID) { return "Planning"; }
            if (SectionID == Globals.LogisticsChiefGenericID) { return "Logistics"; }
            if (SectionID == Globals.FinanceChiefGenericID) { return "Finance / Admin"; }
            return null;
        }

        public static GenericICSRole GetGenericRoleByName(string name)
        {
            List<GenericICSRole> roles = GetGenericICSRoles();
            if(roles.Any(o=>o.RoleName.Equals(name, StringComparison.OrdinalIgnoreCase))) { return roles.First(o => o.RoleName.Equals(name, StringComparison.OrdinalIgnoreCase)); }
            return null;
        }

     
      

        public static ICSRole GetRoleByID(this OrganizationChart orgChart, Guid id, bool defaultUpChain = true)
        {
            if (orgChart.ActiveRoles.Any(o => o.RoleID == id))
            {
                ICSRole role = orgChart.GetAllRoles().First(o => o.RoleID == id);
                if(defaultUpChain && (role.IndividualID == Guid.Empty) && role.ReportsTo != Guid.Empty)
                {
                    role = orgChart.GetRoleByID(role.ReportsTo, true);
                }
                return role;
            }
            return null;
        }

        public static ICSRole GetRoleByName(this OrganizationChart orgChart, string name)
        {
            List<ICSRole> roles = orgChart.ActiveRoles;
            if (roles.Any(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return roles.First(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else { return null; }
        }

        public static List<ICSRole> GetAllRoles(this OrganizationChart orgChart)
        {
            return orgChart.ActiveRoles;
        }

        public static void SortRoles(this OrganizationChart orgChart)
        {
            List<ICSRole> sortedRoles = new List<ICSRole>();

            if (!orgChart.IsUnifiedCommand)
            {
                ICSRole ic = orgChart.AllRoles.First(o => o.GenericRoleID == Globals.IncidentCommanderGenericID);
                ic.Depth = 0;
                sortedRoles.Add(ic);
                sortedRoles = AddChildRoles(orgChart, sortedRoles, ic);
            }
            else
            {
              

                ICSRole ic2 = orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID);
                if (ic2 != null) { ic2.Depth = 0; sortedRoles.Add(ic2); }
                ICSRole ic3 = orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID);
                if (ic3 != null) { ic3.Depth = 0; sortedRoles.Add(ic3); }
                ICSRole ic = orgChart.ActiveRoles.First(o => o.GenericRoleID == Globals.IncidentCommanderGenericID);
                ic.Depth = 0;
                sortedRoles.Add(ic);
                sortedRoles = AddChildRoles(orgChart, sortedRoles, ic);
            }
            orgChart.AllRoles = sortedRoles;
        }

        private static List<ICSRole> AddChildRoles(OrganizationChart sourceChart, List<ICSRole> baseList, ICSRole parentRole)
        {
            List<ICSRole> children = sourceChart.ActiveRoles.Where(o => o.RoleID != parentRole.RoleID && (o.ReportsTo == parentRole.RoleID || ( o.ReportsToGenericRoleID == parentRole.GenericRoleID && o.ReportsTo == Guid.Empty))).ToList();
            children = children.OrderBy(o => o.ManualSortOrder).ThenBy(o => o.RoleName).ToList();
            foreach(ICSRole child in children)
            {
                child.Depth = parentRole.Depth + 1;
                if (child.ReportsTo == Guid.Empty) { child.ReportsTo = parentRole.ID; }
                baseList.Add(child);
                baseList = AddChildRoles(sourceChart, baseList, child);
            }
            return baseList;
        }


        public static int CalculateOrgChartPageCount(this OrganizationChart currentChart)
        {
            int pageCount = 1;

            foreach (ICSRole role in currentChart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
            {
                List<ICSRole> childRoles = currentChart.GetChildRoles(role.RoleID, false);
                if (childRoles.Any(o => string.IsNullOrEmpty(o.PDFFieldName)))
                {
                    //Every 4 of these will generate an extra page, as 4 is the number of direct children per page
                    //Within those children, there may be grand or great grand children that cause yet more pages

                    pageCount += currentChart.PagesThisBranch(role);
                }

            }

            return pageCount;
        }

        private static int PagesThisBranch(this OrganizationChart currentChart, ICSRole parentRole)
        {
            int pageCount = 0;

            int childrenPerExtPage = 4;
            int grandChildrenPerPage = 5;

            List<ICSRole> childRoles = currentChart.GetChildRoles(parentRole.RoleID, false);
            childRoles = childRoles.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();

            double pagesForChildren = Math.Ceiling((double)childRoles.Count() / (double)childrenPerExtPage);
            pageCount += Convert.ToInt32(pagesForChildren);

            foreach(ICSRole child in childRoles)
            {
                List<ICSRole> grandChildren = currentChart.GetChildRoles(child.RoleID, false);
                grandChildren = grandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();
                double pagesForGrandChildren = Math.Ceiling((double)grandChildren.Count() / (double)grandChildrenPerPage);
                if (pagesForGrandChildren >= 1) { pagesForGrandChildren = pagesForGrandChildren - 1; }
                pageCount += (Int32)pagesForGrandChildren;

                foreach(ICSRole grandChild in grandChildren)
                {
                    List<ICSRole> greatGrandChildren = currentChart.GetChildRoles(grandChild.RoleID, false);
                    greatGrandChildren = greatGrandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();
                    if (greatGrandChildren.Any())
                    {
                        pageCount += currentChart.PagesThisBranch(grandChild);
                    }
                }
            }


            return pageCount;
        }

        public static string GetBranchNameFromID (Guid id)
        {
            if(id == Globals.OpsChiefGenericID) { return "Operations"; }
            if (id == Globals.PlanningChiefGenericID) { return "Planning"; }
            if (id == Globals.LogisticsChiefGenericID) { return "Logistics"; }
            if (id == Globals.FinanceChiefGenericID) { return "Finance/Admin"; }

            return "Command"; 

        }

        public static string OrgChartToCSV(List<ICSRole> roles, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("Branch"); csv.Append(delimiter);
            csv.Append("Role Name"); csv.Append(delimiter);
            csv.Append("Reports To"); csv.Append(delimiter);
            csv.Append("Individual Name"); csv.Append(delimiter);
           // csv.Append("Phone"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);

            foreach (ICSRole item in roles)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                string branch = GetBranchNameFromID(item.SectionID);
                csv.Append("\""); csv.Append(branch.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.ReportsToRoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.IndividualName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                //csv.Append("\""); if (item.teamMember != null) { csv.Append(item.teamMember.CellphoneNumber.EscapeQuotes()); } csv.Append("\""); csv.Append(delimiter);

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }
    }
}