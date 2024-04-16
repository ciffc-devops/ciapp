using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.BackColor = Program.FormBackground;
        }

        List<CheckBox> checkboxes = new List<CheckBox>();

        private void TestForm_Load(object sender, EventArgs e)
        {
            buildCheckboxList();

        }

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
                    Program.wfIncidentService.UpsertAirOperationsSummary(airOps);
                    log.Append("Saved air ops summary"); log.Append(Environment.NewLine);
                }
                if (checkboxes[1].Checked)
                {
                    Contact contact = TestTools.createContactTest(seed);
                    log.Append("Created contact"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertContact(contact);
                    log.Append("Saved contact"); log.Append(Environment.NewLine);
                }

                if (checkboxes[2].Checked)
                {
                    MedicalPlan medplan = TestTools.createTestMedicalPlan(seed);
                    medplan.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created MedicalPlan"); log.Append(Environment.NewLine);
                    foreach (MedicalAidStation aidStation in medplan.MedicalAidStations) { Program.wfIncidentService.UpsertMedicalAidStation(aidStation); }
                    foreach (AmbulanceService item in medplan.Ambulances) { Program.wfIncidentService.UpsertAmbulance(item); }
                    foreach (Hospital item in medplan.Hospitals) { Program.wfIncidentService.UpsertHospital(item); }
                    Program.wfIncidentService.UpsertMedicalPlan(medplan);
                    log.Append("Saved MedicalPlan"); log.Append(Environment.NewLine);
                }
                if (checkboxes[3].Checked)
                {
                    Note testnote = TestTools.createTestNote(seed);
                    testnote.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created Note"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertNote(testnote);
                    log.Append("Saved Note"); log.Append(Environment.NewLine);
                }
                if (checkboxes[4].Checked)
                {
                    //Position log
                    PositionLogEntry testPositionLogEntry = TestTools.createTestPositionLogEntry(seed);
                    testPositionLogEntry.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created PositionLogEntry"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertPositionLogEntry(testPositionLogEntry);
                    log.Append("Saved PositionLogEntry"); log.Append(Environment.NewLine);
                }
                if (checkboxes[5].Checked)
                {
                    //SafetyMessage
                    SafetyMessage testSafetyMessage = TestTools.createTestSafetyMessage(seed);
                    testSafetyMessage.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created SafetyMessage"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertSafetyMessage(testSafetyMessage);
                    log.Append("Saved SafetyMessage"); log.Append(Environment.NewLine);
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
                        Program.wfIncidentService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckInPersonnel.Record);
                        log.Append("Saved Check in for Personnel"); log.Append(Environment.NewLine);


                        if (!string.IsNullOrEmpty(testCheckInPersonnel.Record.InitialRoleAcronym)
                            && Program.CurrentOrgChart.ActiveRoles.Any(o => !string.IsNullOrEmpty(o.Mnemonic)
                            && o.Mnemonic.Equals(testCheckInPersonnel.Record.InitialRoleAcronym)))
                        {
                            ICSRole role = Program.CurrentOrgChart.ActiveRoles.OrderBy(o => Guid.NewGuid()).Where(o => o.IndividualID == Guid.Empty).First();
                            testCheckInPersonnel.Record.InitialRoleName = role.RoleName;

                            //Assign them
                            Personnel p = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == testCheckInPersonnel.Record.ResourceID);
                            role.IndividualID = p.ID;
                            role.IndividualName = p.Name;
                            //role.teamMember = p.Clone();
                            Program.wfIncidentService.UpsertICSRole(role);
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
                        Program.wfIncidentService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckInPersonnel.Record);
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
                        Program.wfIncidentService.UpsertVehicle(testCheckIn.Resource as Vehicle);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckIn.Record);
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
                        Program.wfIncidentService.UpsertVehicle(testCheckIn.Resource as Vehicle);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckIn.Record);
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
                            Program.wfIncidentService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }


                        CheckInRecordWithResource testCheckin = TestTools.createTestCheckIn(seed + x, "Crew", crewResources);
                        testCheckin.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckin.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckin.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Crew"); log.Append(Environment.NewLine);
                        Program.wfIncidentService.UpsertOperationalSubGroup(testCheckin.Resource as OperationalSubGroup);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckin.Record);
                        log.Append("Saved Check in for Crew"); log.Append(Environment.NewLine);

                      
                       foreach(CheckInRecordWithResource resource in resources)
                        {
                            resource.Record.ParentRecordID = testCheckin.Record.SignInRecordID;
                            resource.Resource.ParentResourceID = testCheckin.Resource.ID;
                            Program.wfIncidentService.UpsertPersonnel(resource.Resource as Personnel);
                            Program.wfIncidentService.UpsertCheckInRecord(resource.Record);

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
                            Program.wfIncidentService.UpsertPersonnel(testCheckInPersonnel.Resource as Personnel);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            CheckInRecordWithResource testCheckInPersonnel = TestTools.createTestCheckIn(seed + i, "Equipment");
                            testCheckInPersonnel.Record.OpPeriod = Program.CurrentOpPeriod;
                            testCheckInPersonnel.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckInPersonnel.Record.ResourceType, 1, 10000);

                            (testCheckInPersonnel.Resource as Vehicle).IsEquipment = true;
                            Program.wfIncidentService.UpsertVehicle(testCheckInPersonnel.Resource as Vehicle);
                            crewResources.Add(testCheckInPersonnel.Resource);
                            resources.Add(testCheckInPersonnel);
                        }

                        CheckInRecordWithResource testCheckin = TestTools.createTestCheckIn(seed + x, "Heavy Equipment Crew", crewResources);
                        testCheckin.Record.OpPeriod = Program.CurrentOpPeriod;
                        testCheckin.Resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(testCheckin.Record.ResourceType, 1, 1000);


                        log.Append("Created Check in for Crew"); log.Append(Environment.NewLine);
                        Program.wfIncidentService.UpsertOperationalSubGroup(testCheckin.Resource as OperationalSubGroup);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckin.Record);
                        log.Append("Saved Check in for Crew"); log.Append(Environment.NewLine);


                        foreach (CheckInRecordWithResource resource in resources)
                        {
                            resource.Record.ParentRecordID = testCheckin.Record.SignInRecordID;
                            resource.Resource.ParentResourceID = testCheckin.Resource.ID;
                            Program.wfIncidentService.UpsertPersonnel(resource.Resource as Personnel);
                            Program.wfIncidentService.UpsertCheckInRecord(resource.Record);

                        }




                    }

                }



                if (checkboxes[12].Checked)
                {
                    //comms plan
                    CommsPlan commsPlan = TestTools.createTestCommsPlan(seed);
                    commsPlan.OpsPeriod = Program.CurrentOpPeriod;
                    log.Append("Created CommsPlan"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertCommsPlan(commsPlan);
                    log.Append("Saved CommsPlan"); log.Append(Environment.NewLine);


                }
                if (checkboxes[13].Checked)
                {
                    //comms plan
                    GeneralMessage test = TestTools.createTestGeneralMessage(seed);
                    test.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created GeneralMessage"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertGeneralMessage(test);
                    log.Append("Saved GeneralMessage"); log.Append(Environment.NewLine);


                }
                if (checkboxes[14].Checked)
                {
                    IncidentObjectivesSheet tesIncidentObjectivesSheet = TestTools.createTestObjectiveSheet(seed);
                    tesIncidentObjectivesSheet.OpPeriod = Program.CurrentOpPeriod;
                    log.Append("Created IncidentObjectivesSheet"); log.Append(Environment.NewLine);
                    Program.wfIncidentService.UpsertIncidentObjectivesSheet(tesIncidentObjectivesSheet);
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
                        Program.wfIncidentService.UpsertAircraft(testCheckInPersonnel.Resource as Aircraft);
                        Program.wfIncidentService.UpsertCheckInRecord(testCheckInPersonnel.Record);
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


            CheckBox chkContact = new CheckBox();
            checkboxes.Add(chkContact);
            checkboxes.Last().Text = "Contact";

            CheckBox chkMedPlan = new CheckBox();
            checkboxes.Add(chkMedPlan);
            checkboxes.Last().Text = "Medical Plan";

            CheckBox chkNote = new CheckBox();
            checkboxes.Add(chkNote);
            checkboxes.Last().Text = "Note";

            CheckBox chkPositionLog = new CheckBox();
            checkboxes.Add(chkPositionLog);
            checkboxes.Last().Text = "Position Log";


            CheckBox chkSafetyMessage = new CheckBox();
            checkboxes.Add(chkSafetyMessage);
            checkboxes.Last().Text = "Safety Message";


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

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "General Message";

            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Objectives";


            checkboxes.Add(new CheckBox());
            checkboxes.Last().Text = "Aircraft Check In";

            for (int x = 0; x < checkboxes.Count; x++)
            {
                checkboxes[x].Width = panel1.Width;
                checkboxes[x].Location = new Point(0, x * 24);
                checkboxes[x].Height = 30;
                panel1.Controls.Add(checkboxes[x]);
            }

        }
    }
}
