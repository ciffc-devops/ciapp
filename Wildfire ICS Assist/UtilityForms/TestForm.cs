using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Properties;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackgroundColor;
        }

        List<CheckBox> checkboxes = new List<CheckBox>();

        private void TestForm_Load(object sender, EventArgs e)
        {
            buildCheckboxList();

        }

        List<int> nonResourceCheckboxIndexes = new List<int>();

        private void btnTest_Click(object sender, EventArgs e)
        {
            //This tool will create an example version of every type of thing and save it. If you're connected to the lan or internet sync it will also send it there
            DateTime today = DateTime.Now;
            StringBuilder log = new StringBuilder();
            int seed = Convert.ToInt32(numericUpDown1.Value);

            try
            {



                if (checkboxes[0].Checked)
                {
                    AirOperationsSummary airOps = TestTools.CreateAirOpsTest(seed);
                    airOps.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created air ops summary"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertAirOperationsSummary(airOps);
                    log.Append("Saved air ops summary"); log.Append(Environment.NewLine);
                }
                if (checkboxes[1].Checked)
                {
                    Contact contact = TestTools.createContactTest(seed);
                    log.Append("Created contact"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertContact(contact);
                    log.Append("Saved contact"); log.Append(Environment.NewLine);
                }

                if (checkboxes[2].Checked)
                {
                    MedicalPlan medplan = TestTools.createTestMedicalPlan(seed);
                    medplan.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created MedicalPlan"); log.Append(Environment.NewLine);
                    foreach (MedicalAidStation aidStation in medplan.MedicalAidStations) { aidStation.OpPeriod = Program.CurrentOpPeriod; Program.incidentDataService.UpsertMedicalAidStation(aidStation); }
                    foreach (AmbulanceService item in medplan.Ambulances) { item.OpPeriod = Program.CurrentOpPeriod; Program.incidentDataService.UpsertAmbulance(item); }
                    foreach (Hospital item in medplan.Hospitals) { item.OpPeriod = Program.CurrentOpPeriod; Program.incidentDataService.UpsertHospital(item); }
                    Program.incidentDataService.UpsertMedicalPlan(medplan);
                    log.Append("Saved MedicalPlan"); log.Append(Environment.NewLine);
                }
                if (checkboxes[3].Checked)
                {
                    Note testnote = TestTools.createTestNote(seed);
                    testnote.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created Note"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertNote(testnote);
                    log.Append("Saved Note"); log.Append(Environment.NewLine);
                }
                if (checkboxes[4].Checked)
                {
                    //Position log
                    PositionLogEntry testPositionLogEntry = TestTools.createTestPositionLogEntry(seed);
                    testPositionLogEntry.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created PositionLogEntry"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertPositionLogEntry(testPositionLogEntry);
                    log.Append("Saved PositionLogEntry"); log.Append(Environment.NewLine);
                }
                if (checkboxes[5].Checked)
                {
                    //SafetyMessage
                    SafetyMessage testSafetyMessage = TestTools.createTestSafetyMessage(seed);
                    testSafetyMessage.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created SafetyMessage"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertSafetyMessage(testSafetyMessage);
                    log.Append("Saved SafetyMessage"); log.Append(Environment.NewLine);
                }

                if (checkboxes[16].Checked)
                {
                    OperationalGroup FirstOpGroup = Program.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.ParentID == Guid.Empty && o.OpPeriod == Program.CurrentOpPeriod);

                    //add some branches
                    for (int x = 0; x < 2; x++)
                    {
                        CreateTestOpGroup("Branch", FirstOpGroup, x);   
                    }
                    foreach(OperationalGroup branch in Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.GroupType.Equals("Branch")))
                    {
                        for (int x = 0; x < 2; x++)
                        {
                            CreateTestOpGroup("Division", branch, x);
                        }
                    }

                    foreach (OperationalGroup divis in Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.GroupType.Equals("Division")))
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            bool isST = RandomBooleanGenerator.GetRandomBoolean();
                            if (isST) { CreateTestOpGroup("Strike Team", divis, x); }
                            else { CreateTestOpGroup("Task Force", divis, x); }
                            
                        }
                    }


                    log.Append("Saved Operational Groups"); log.Append(Environment.NewLine);


                }




                if (checkboxes[6].Checked)
                {
                    //check in
                    for (int x = 0; x < 30; x++)
                    {
                        CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + x, "Personnel");
                        testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 1000);

                        

                        log.Append("Created Check in for Personnel"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckInPersonnel.Record);
                        log.Append("Saved Check in for Personnel"); log.Append(Environment.NewLine);


                        if (!string.IsNullOrEmpty(testCheckInPersonnel.Record.InitialRoleAcronym)
                            && Program.CurrentOrgChart.ActiveRoles.Any(o => !string.IsNullOrEmpty(o.MnemonicAbrv)
                            && o.MnemonicAbrv.Equals(testCheckInPersonnel.Record.InitialRoleAcronym)))
                        {
                            ICSRole role = Program.CurrentOrgChart.ActiveRoles.OrderBy(o => Guid.NewGuid()).FirstOrDefault(o => o.IndividualID == Guid.Empty);
                            if (role != null)
                            {
                                testCheckInPersonnel.Record.InitialRoleName = role.RoleName;

                                //Assign them
                                Personnel p = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == testCheckInPersonnel.Record.ResourceID);
                                role.IndividualID = p.ID;
                                role.IndividualName = p.Name;
                                //role.teamMember = p.Clone();
                                if (role.GenericRoleID == WF_ICS_ClassLibrary.Globals.AirOpsDirectorGenericID)
                                {
                                    ;
                                }

                                Program.incidentDataService.UpsertICSRole(role);
                            }
                        }

                    }
                }
                if (checkboxes[7].Checked)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + x, "Visitor");
                        testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckInPersonnel.Record.ReplacementRequired = false;
                        testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Visitor"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckInPersonnel.Record);
                        log.Append("Saved Check in for Visitor"); log.Append(Environment.NewLine);

                    }
                }
                if (checkboxes[8].Checked)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        CheckInRecordWithResource testCheckIn = TestTools.createTestCheckIn(seed + x, "Vehicle");
                        testCheckIn.Record.OpPeriod = Program.CurrentOpPeriod;
                        //testCheckIn.Record.DailyCheckInRecords.First().OpPeriod = Program.CurrentOpPeriod;
                        testCheckIn.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckIn.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Vehicle"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertVehicle(testCheckIn.Resource as Vehicle);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckIn.Record);
                        log.Append("Saved Check in for Vehicle"); log.Append(Environment.NewLine);

                    }
                }
                if (checkboxes[9].Checked)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        CheckInRecordWithResource testCheckIn = TestTools.createTestCheckIn(seed + x, "Equipment");
                        testCheckIn.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckIn.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckIn.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Equipment"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertVehicle(testCheckIn.Resource as Vehicle);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckIn.Record);
                        log.Append("Saved Check in for Equipment"); log.Append(Environment.NewLine);

                    }
                }
                if (checkboxes[10].Checked)
                {
                    //crews
                    for (int x = 0; x < 3; x++)
                    {
                        List<CheckInRecordWithResource> resources = new List<CheckInRecordWithResource>();
                        List<IncidentResource> crewResources = new List<IncidentResource>();
                        for(int i = 0; i < 8; i++)
                        {
                            CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + i, "Personnel");
                            testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                            testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 10000);
                            Program.incidentDataService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }


                        CheckInRecordWithResource testCheckin = TestTools.createTestCheckIn(seed + x, "Crew", crewResources);
                        testCheckin.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckin.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckin.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Crew"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertCrew(testCheckin.Resource as Crew);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckin.Record);
                        log.Append("Saved Check in for Crew"); log.Append(Environment.NewLine);

                      
                       foreach(CheckInRecordWithResource resource in resources)
                        {
                            resource.Record.ParentRecordID = testCheckin.Record.SignInRecordID;
                            resource.Resource.ParentResourceID = testCheckin.Resource.ID;
                            Program.incidentDataService.UpsertPersonnel(resource.Resource as Personnel);
                            Program.incidentDataService.UpsertCheckInRecord(resource.Record);

                        }




                    }

                }
                if (checkboxes[11].Checked)
                {
                    //crews
                    for (int x = 0; x < 3; x++)
                    {
                        List<CheckInRecordWithResource> resources = new List<CheckInRecordWithResource>();
                        List<IncidentResource> crewResources = new List<IncidentResource>();
                        for (int i = 0; i < 8; i++)
                        {
                            CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + i, "Personnel");
                            testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                            testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 10000);
                            Program.incidentDataService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + i, "Equipment");
                            testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                            testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 10000);

                            (testCheckInPersonnel.Resource as Vehicle).IsEquipment = true;
                            Program.incidentDataService.UpsertVehicle(testCheckInPersonnel.Resource as Vehicle);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }

                        CheckInRecordWithResource testCheckin = TestTools.createTestCheckIn(seed + x, "Heavy Equipment Crew", crewResources);
                        testCheckin.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckin.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckin.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Crew"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertCrew(testCheckin.Resource as Crew);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckin.Record);
                        log.Append("Saved Check in for Crew"); log.Append(Environment.NewLine);


                        foreach (CheckInRecordWithResource resource in resources)
                        {
                            resource.Record.ParentRecordID = testCheckin.Record.SignInRecordID;
                            resource.Resource.ParentResourceID = testCheckin.Resource.ID;
                            Program.incidentDataService.UpsertPersonnel(resource.Resource as Personnel);
                            Program.incidentDataService.UpsertCheckInRecord(resource.Record);

                        }




                    }

                }



                if (checkboxes[12].Checked)
                {

                    //comms plan
                    CommsPlan commsPlan = null;
                    if(Program.CurrentIncident.allCommsPlans.Any(o=>o.OpPeriod == Program.CurrentOpPeriod && o.Active))
                    {
                        commsPlan = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod && o.Active);
                        for(int x = 0; x < 6; x++)
                        {
                            CommsPlanItem item = TestTools.createTestCommsPlanItem(x);
                            commsPlan.allCommsItems.Add(item);
                        }
                    }
                    if (commsPlan == null)
                    {
                        commsPlan = TestTools.createTestCommsPlan(seed);
                        commsPlan.OpPeriod = Program.CurrentOpPeriod;
                        log.Append("Created CommsPlan"); log.Append(Environment.NewLine);

                    }
                    Program.incidentDataService.UpsertCommsPlan(commsPlan);

                    log.Append("Saved CommsPlan"); log.Append(Environment.NewLine);


                }
                if (checkboxes[13].Checked)
                {
                    //general messages
                    GeneralMessage test = TestTools.createTestGeneralMessage(seed);
                    test.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created GeneralMessage"); log.Append(Environment.NewLine);
                    Program.incidentDataService.UpsertGeneralMessage(test);
                    log.Append("Saved GeneralMessage"); log.Append(Environment.NewLine);


                }
                if (checkboxes[14].Checked)
                {
                    IncidentObjectivesSheet testIncidentObjectivesSheet = null;
                    if (Program.CurrentIncident.ActiveIncidentObjectiveSheets.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
                    {
                        testIncidentObjectivesSheet = Program.CurrentIncident.ActiveIncidentObjectiveSheets.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod);
                        for (int x = 0; x < 5; x++)
                        {
                            testIncidentObjectivesSheet.Objectives.Add(TestTools.createTestIncidentObjective(x));
                            testIncidentObjectivesSheet.Objectives[x].OpPeriod = Program.CurrentOpPeriod;
                        }
                    }
                    else
                    {
                        testIncidentObjectivesSheet  = TestTools.createTestObjectiveSheet(seed);
                        testIncidentObjectivesSheet.OpPeriod = Program.CurrentOpPeriod;
                        log.Append("Created IncidentObjectivesSheet"); log.Append(Environment.NewLine);
                    }
                    Program.incidentDataService.UpsertIncidentObjectivesSheet(testIncidentObjectivesSheet);



                    log.Append("Saved IncidentObjectivesSheet"); log.Append(Environment.NewLine);


                }

                if (checkboxes[15].Checked)
                {
                    //check in
                    for (int x = 0; x < 8; x++)
                    {
                        CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + x, "Aircraft");
                        testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckInPersonnel.Resource.OpPeriod = Program.CurrentOpPeriod;
                        testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 1000);



                        log.Append("Created Check in for Aircraft"); log.Append(Environment.NewLine);
                        Program.incidentDataService.UpsertAircraft(testCheckInPersonnel.Resource as Aircraft);
                        Program.incidentDataService.UpsertCheckInRecord(testCheckInPersonnel.Record);
                        log.Append("Saved Check in for Aircraft"); log.Append(Environment.NewLine);

                    }
                }
            }
            catch (Exception ex)
            {
                log.Append(Environment.NewLine);
                log.Append(ex.ToString());

            }
            txtLog.Text = log.ToString();

        }

        private void CreateTestOpGroup(string GroupType, OperationalGroup parentGroup, int index = 0)
        {
            OperationalGroup op = new OperationalGroup();
            op.GroupType = GroupType;
            if (op.GroupType.Equals("Branch")) { op.Name = (index + 1).ToString(); }
            else if (op.GroupType.Equals("Division")) {
                int branchNumber = 0;
                int.TryParse(parentGroup.Name, out branchNumber);
                
                op.Name = ((char)(65 + index + (branchNumber * 2))).ToString(); }
            else { op.Name = StringExt.LoremIpsum(1, 3, 1, 1, 1); }
            op.OpPeriod = Program.CurrentOpPeriod;
            op.ParentID = parentGroup.ID;
            op.ParentName = parentGroup.ResourceName;

            Program.incidentDataService.UpsertOperationalGroup(op);
            if (op.LeaderICSRoleID == Guid.Empty)
            {
                ICSRole role = op.CreateRoleFromOperationalGroup(Program.incidentDataService.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == op.OpPeriod).ID);
                role.OperationalGroupName = op.ResourceName;
                Guid ReportsToRoleID = Program.CurrentIncident.GetICSReportsToThroughOpGroup(role);
                if (ReportsToRoleID != Guid.Empty)
                {
                    ICSRole reportsToRole = Program.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == op.OpPeriod).AllRoles.FirstOrDefault(o => o.RoleID == ReportsToRoleID);
                    role.ReportsTo = reportsToRole.RoleID;
                    role.ReportsToGenericRoleID = reportsToRole.GenericRoleID;
                    role.ReportsToRoleName = reportsToRole.RoleName;
                }
                Program.incidentDataService.UpsertICSRole(role);
                op.LeaderICSRoleID = role.RoleID;
                op.LeaderICSRoleName = role.RoleName;

                Program.incidentDataService.UpsertOperationalGroup(op);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in checkboxes) { chk.Checked = true; }

        }

        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chk in checkboxes) { chk.Checked = false; }

        }

        private void buildCheckboxList()
        {


            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Air Ops Summary";
            nonResourceCheckboxIndexes.Add(checkboxes.Count-1);


            CheckBox chkContact = new CheckBox();
            checkboxes.Add(chkContact);
            checkboxes.Last().Text = "Contact";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);


            CheckBox chkMedPlan = new CheckBox();
            checkboxes.Add(chkMedPlan);
            checkboxes.Last().Text = "Medical Plan";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);

            CheckBox chkNote = new CheckBox();
            checkboxes.Add(chkNote);
            checkboxes.Last().Text = "Note";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);

            CheckBox chkPositionLog = new CheckBox();
            checkboxes.Add(chkPositionLog);
            checkboxes.Last().Text = "Position Log";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);


            CheckBox chkSafetyMessage = new CheckBox();
            checkboxes.Add(chkSafetyMessage);
            checkboxes.Last().Text = "Safety Message";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);


            CheckBox chkCheckInPersonnel = new CheckBox();
            checkboxes.Add(chkCheckInPersonnel);
            checkboxes.Last().Text = "Personnel Check In";

            CheckBox chkCheckInVisitor = new CheckBox();
            checkboxes.Add(chkCheckInVisitor);
            checkboxes.Last().Text = "Visitor Check In";

            CheckBox chkCheckInVehicle = new CheckBox();
            checkboxes.Add(chkCheckInVehicle);
            checkboxes.Last().Text = "Vehicle Check In";

            CheckBox chkCheckInEquipment = new CheckBox();
            checkboxes.Add(chkCheckInEquipment);
            checkboxes.Last().Text = "Equipment Check In";

            
            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Crew Check In";


            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "HE Crew Check In";

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Comms Plan";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "General Message";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Objectives";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);


            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Aircraft Check In";

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Operational Groups";
            nonResourceCheckboxIndexes.Add(checkboxes.Count - 1);


            for (int x = 0; x < checkboxes.Count; x++)
            {
                checkboxes[x].Width = panel1.Width;
                checkboxes[x].Location = new Point(0, x * 24);
                checkboxes[x].Height = 30;
                panel1.Controls.Add(checkboxes[x]);
            }

        }

        private void btnAllNonResource_Click(object sender, EventArgs e)
        {
            for(int x = 0; x < checkboxes.Count; x++)
            {
                if (nonResourceCheckboxIndexes.Contains(x)) { checkboxes[x].Checked = true; }
            }


        }
    }
}
