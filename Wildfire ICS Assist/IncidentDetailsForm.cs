using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Interfaces;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.OptionsForms;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class IncidentDetailsForm : Form
    {
        public IncidentDetailsForm()
        {
            //Test french language
            /* 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
            */
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
            this.BackColor = Program.FormBackground;
            menuStrip1.BackColor = Program.FormAccent;
            System.Windows.Forms.Application.EnableVisualStyles();
            LastAutoBackup = DateTime.Now;
            populateCollapsiblePanelList();

        }
        private void IncidentDetailsForm_Load(object sender, EventArgs e)
        {
            SetVersionNumber();
            setRecentFiles();

            collapseAllPanels();

            //debug
            cpIncidentActionPlan.CurrentlyCollapsed = false;

            CreateNewIncident();
            displayIncidentDetails();

            WireWFIncidentServiceEvents();

            ICSRole defaultRole = (ICSRole)Program.generalOptionsService.GetOptionsValue("DefaultICSRole");
            if (defaultRole != null && defaultRole.RoleID != Guid.Empty) { cboICSRole.SelectedValue = defaultRole.RoleID; }

        }

        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o=>o.OpPeriod == Program.CurrentOpPeriod); }

        public bool ThisMachineStandAlone { get { return Program.networkService.ThisMachineIsStandAlone; } set { Program.networkService.ThisMachineIsStandAlone = value; } }
        public bool ThisMachineIsServer { get { return Program.networkService.ThisMachineIsServer; } set { Program.networkService.ThisMachineIsServer = value; } }
        public bool ThisMachineIsClient { get { return Program.networkService.ThisMachineIsClient; } set { Program.networkService.ThisMachineIsClient = value; } }

        public string ServerIP { get { return Program.networkService.ServerIP; } set { Program.networkService.ServerIP = value; } }
        public string ServerPort { get { return Program.networkService.ServerPortStr; } set { Program.networkService.ServerPortStr = value; } }
        public string encryptionKey { get => Program.networkService.EncryptionKey; set { Program.networkService.EncryptionKey = value; } }





        bool checkForSave = false; //should be set true when a change is made, and false when a save is finished
        private bool formIsClosing = false; //set true when the process of closing the form begins, so network stuff doesn't keep trying to happen in its midst
        private bool PauseNetworkSend = false; //used to prevent changes from network updates form triggering new network updates
        private DateTime LastAutoBackup = DateTime.MinValue;
        private bool askedForInitialSave = false;
        bool incorrectOpAcknowledged = false;
        bool lastSaveSuccessful = true;
        private DateTime lastSuccessfulSaveTime = DateTime.MinValue;
        bool saveAsPromptShown = false;


        //These hold a reference to the various forms so that only one of each can be open at a time.
        List<Form> ActiveForms = new List<Form>();
        HospitalsForm hospitalsForm = null;
        MedivacsForm medivacsForm = null;
        SavedContactsForm savedContactsForm = null;
        SavedCommsItemsForm savedCommsItemsForm= null;
        SavedVehiclesForm savedVehiclesForm= null;
        SavedIncidentObjectivesForm savedObjectivesForm = null;
        SavedSafetyNotesForm savedSafetyNotesForm = null;
        SavedTeamMembersForm savedTeamMembersForm = null;
        SavedAircraftsForm savedAircraftForm = null;


        CommunicationsListForm communicationsList = null;
        CommunicationsPlanForm commsPlanForm = null;
        OrganizationalChartForm orgChartForm = null;
        PositionLogForm _positionLogForm = null;
        PositionLogAllOutstandingForm _positionLogAllOutstandingForm = null;
        IncidentObjectivesForm objectivesForm = null;
        GeneralMessagesForm generalMessagesForm = null;
        MedicalPlanForm medicalPlanForm = null;
        NotesForm notesForm = null;
        SafetyMessagesForm safetyMessagesForm = null;
        VehiclesForm vehiclesForm = null;
        PrintIncidentForm printIAPForm = null;
        AirOperationsForm airOperationsForm = null;

        /* Event Handlers!*/

        public event ShortcutEventHandler ShortcutButtonClicked;



        List<CollapsiblePanel> collapsiblePanels= new List<CollapsiblePanel>();


        private void WireWFIncidentServiceEvents()
        {
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.wfIncidentService.PositionLogChanged += Program_PositionLogChanged;
            Program.wfIncidentService.IncidentObjectiveChanged += Program_IncidentObjectiveChanged;
            Program.wfIncidentService.IncidentObjectivesSheetChanged+= Program_IncidentObjectivesSheetChanged;
            Program.wfIncidentService.GeneralMessageChanged += Program_GeneralMessageChanged;
            Program.wfIncidentService.MedicalPlanChanged += Program_MedicalPlanChanged;
            Program.wfIncidentService.NoteChanged += Program_NoteChanged;
            Program.wfIncidentService.SafetyMessageChanged += Program_SafetyMessageChanged;
            Program.wfIncidentService.VehicleChanged += Program_VehicleChanged;
            Program.wfIncidentService.CommsPlanChanged+= Program_CommsPlanChanged;
            Program.wfIncidentService.CommsPlanItemChanged+= Program_CommsPlanItemChanged;
            Program.wfIncidentService.AircraftChanged+= Program_AircraftChanged;
            Program.wfIncidentService.AircraftsOperationsSummaryChanged += Program_AirOpsSummaryChanged;
            Program.wfIncidentService.TaskBasicsChanged += Program_TaskBasicsChanged;
            Program.wfIncidentService.OperationalPeriodChanged += Program_OperationalPeriodChanged;
        }


        private void CloseActiveForms()
        {
            foreach (Form form in ActiveForms)
            {
                if (form != null) { form.Close(); }
            }
        }
        private void RemoveActiveForm(Form form)
        {
            if (form != null) { ActiveForms = ActiveForms.Where(o => o.GetType() != form.GetType()).ToList(); }
        }

        private void setButtonCheckboxes()
        {

            if (CurrentIncident.hasMeangfulCommsPlan(CurrentOpPeriod)) { btnCommsPlan.Image = Properties.Resources.glyphicons_basic_739_check; communicationsPlanICS205ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnCommsPlan.Image = null; communicationsPlanICS205ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulOrgChart(CurrentOpPeriod)) { btnPrintOrgChart.Image = Properties.Resources.glyphicons_basic_739_check; organizationChartICS207ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnPrintOrgChart.Image = null; organizationChartICS207ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulMedicalPlan(CurrentOpPeriod)) { btnMedicalPlan.Image = Properties.Resources.glyphicons_basic_739_check; medicalPlanICS206ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnMedicalPlan.Image = null; medicalPlanICS206ToolStripMenuItem.Image = null; }


            if (CurrentIncident.hasMeaningfulObjectives(CurrentOpPeriod)) { btnIncidentObjectives.Image = Properties.Resources.glyphicons_basic_739_check; incidentObjectivesICS202ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnIncidentObjectives.Image = null; incidentObjectivesICS202ToolStripMenuItem.Image = null; }


            
            if (CurrentIncident.hasAnySafetyMessages(CurrentOpPeriod)) { btnSafetyPlans.Image = Properties.Resources.glyphicons_basic_739_check; safetyMessageICS208ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnSafetyPlans.Image = null; safetyMessageICS208ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulAirOps(CurrentOpPeriod))
            {
                btnAirOpsSummary.Image = Properties.Resources.glyphicons_basic_739_check; airOperationsSummaryICS220ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check;
            }
            else { btnAirOpsSummary.Image = null; airOperationsSummaryICS220ToolStripMenuItem.Image = null; }


            //                    

        }

        private void SetVersionNumber()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            decimal d_version = Convert.ToDecimal(fileVersionInfo.ProductMajorPart + "." + fileVersionInfo.FileMinorPart, System.Globalization.CultureInfo.InvariantCulture);
            decimal d_build = Convert.ToDecimal(fileVersionInfo.FileBuildPart);
            lblVersionNumber.Text = Globals.ProgramName + " ver " + string.Format(CultureInfo.InvariantCulture, "{0:0.0#}", d_version) + "." + d_build;

        }

        private void populateCollapsiblePanelList()
        {
            collapsiblePanels.Clear();
            collapsiblePanels.Add(cpIncidentActionPlan);
            collapsiblePanels.Add(cpPlanning);
            collapsiblePanels.Add(cpOperations);
            collapsiblePanels.Add(cpLogistics);
        }

        private void collapseAllPanels()
        {
            foreach(CollapsiblePanel panel in collapsiblePanels) { panel.Collapse(); }
        }

        private void llProgramURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = Globals.ProgramURL;
            if (null != target)
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {
                MessageBox.Show("Item clicked: " + target);
            }
        }

        private object OptionValue(string TagName)
        {
            return Program.generalOptionsService.GetOptionsValue(TagName);
        }


        private void aboutCIAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UtilityForms.AboutProgramForm aboutForm = new UtilityForms.AboutProgramForm();
            aboutForm.ShowDialog();
        }

        private void hospitalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == hospitalsForm)
            {
                hospitalsForm = new HospitalsForm();
                hospitalsForm.FormClosed += HospitalsForm_Closed;
                hospitalsForm.Show(this);
                ActiveForms.Add(hospitalsForm);
            }

            hospitalsForm.BringToFront();
        }

        void HospitalsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(hospitalsForm);
            hospitalsForm = null;

        }

        private void medivacServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == medivacsForm)
            {
                medivacsForm = new MedivacsForm();
                medivacsForm.FormClosed += MedivacsForm_Closed;
                medivacsForm.Show(this);
                ActiveForms.Add(medivacsForm);
            }

            medivacsForm.BringToFront();
        }

        void MedivacsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(medivacsForm);
            medivacsForm = null;

        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (null == savedContactsForm)
            {
                savedContactsForm = new SavedContactsForm();
                savedContactsForm.FormClosed += SavedContactsForm_Closed;
                savedContactsForm.Show(this);
                ActiveForms.Add(savedContactsForm);
            }

            savedContactsForm.BringToFront();
        }

        void SavedContactsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedContactsForm);
            savedContactsForm = null;

        }

        private void communicationsSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedCommsItemsForm)
            {
                savedCommsItemsForm = new SavedCommsItemsForm();
                savedCommsItemsForm.FormClosed += SavedCommsPlanItemsForm_Closed;
                savedCommsItemsForm.Show(this);
                ActiveForms.Add(savedCommsItemsForm);
            }

            savedCommsItemsForm.BringToFront();
        }

        void SavedCommsPlanItemsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedCommsItemsForm);
            savedCommsItemsForm = null;

        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedVehiclesForm)
            {
                savedVehiclesForm = new SavedVehiclesForm();
                savedVehiclesForm.FormClosed += SavedVehiclesForm_Closed;
                savedVehiclesForm.Show(this);
                ActiveForms.Add(savedVehiclesForm);
            }

            savedVehiclesForm.BringToFront();
        }

        void SavedVehiclesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedVehiclesForm);
            savedVehiclesForm = null;

        }

        private void teamMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedTeamMembersForm)
            {
                savedTeamMembersForm = new SavedTeamMembersForm();
                savedTeamMembersForm.FormClosed += SavedTeamMembersForm_Closed;
                savedTeamMembersForm.Show(this);
                ActiveForms.Add(savedTeamMembersForm);
            }

            savedTeamMembersForm.BringToFront();
        }

        void SavedTeamMembersForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedTeamMembersForm);
            savedTeamMembersForm = null;

        }

        private void incidentObjectivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedObjectivesForm)
            {
                savedObjectivesForm = new SavedIncidentObjectivesForm();
                savedObjectivesForm.FormClosed += SavedObjectivesForm_Closed;
                savedObjectivesForm.Show(this);
                ActiveForms.Add(savedObjectivesForm);
            }

            savedObjectivesForm.BringToFront();
        }

        void SavedObjectivesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedObjectivesForm);
            savedObjectivesForm = null;

        }

        private void safetyNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedSafetyNotesForm)
            {
                savedSafetyNotesForm = new SavedSafetyNotesForm();
                savedSafetyNotesForm.FormClosed += SavedSafetyNotesForm_Closed;
                savedSafetyNotesForm.Show(this);
                ActiveForms.Add(savedSafetyNotesForm);
            }

            savedSafetyNotesForm.BringToFront();
        }

        void SavedSafetyNotesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedSafetyNotesForm);
            savedSafetyNotesForm = null;

        }

        private void browseToIncidentFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentIncident.FileName) && !string.IsNullOrEmpty(CurrentIncident.DocumentPath))
            {
                Process.Start(CurrentIncident.DocumentPath);
            }
        }

        private void newIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewIncident();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkForSave && MessageBox.Show("Would you like to save the current incident before opening another?", "Save current incdient?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveFile();
                openTask();
            }
            else
            {
                openTask();
            }

        }

        private void recentIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile(true);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void IncidentDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void IncidentDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool proceed = true;
            if (ThisMachineIsServer)
            {
                DialogResult closeServer = MessageBox.Show("Are you sure you want to close this program?  You are currently acting as a network server and other machines may be connected to you.", "Close server?", MessageBoxButtons.YesNo);
                if (closeServer == DialogResult.No)
                {
                    proceed = false;
                }
            }

            if (proceed && checkForSave)
            {
                DialogResult saveExisting = MessageBox.Show("Would you like to save the current Incident before closing?", "Save Incident?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (saveExisting == DialogResult.Yes)
                {
                    saveFile();
                    formIsClosing = true;
                }
                else if (saveExisting == DialogResult.No)
                {
                    formIsClosing = true;
                }
                else { proceed = false; }
            }

            if (!proceed) { e.Cancel = true; }
        }

        private void buildICSRoleDropdown()
        {
            ICSRole role = Program.CurrentRole.Clone();

            cboICSRole.DataSource = null;
            cboICSRole.DataSource = CurrentOrgChart.AllRoles;
            cboICSRole.DisplayMember = "RoleNameForDropdown";
            cboICSRole.ValueMember = "RoleID";
            if (role != null && CurrentOrgChart.AllRoles.Any(o=>o.RoleID == role.RoleID)) { cboICSRole.SelectedValue = role.RoleID; }

        }

        private void displayIncidentDetails()
        {
            //cboICSRole.Items.Clear();
            CurrentIncident.createOrgChartAsNeeded(CurrentOpPeriod);
            buildICSRoleDropdown();


            if (!string.IsNullOrEmpty(CurrentIncident.ICPCallSign)) { txtICPCallsign.Text = CurrentIncident.ICPCallSign; }
            else { txtICPCallsign.Text = "BASE"; CurrentIncident.ICPCallSign = txtICPCallsign.Text; }
            txtTaskName.Text = CurrentIncident.TaskName;
            txtTaskNumber.Text = CurrentIncident.TaskNumber;
            if (CurrentOrgChart.AllRoles.Any(o => o.RoleID == Program.CurrentRole.RoleID))
            {
                cboICSRole.SelectedValue = Program.CurrentRole.RoleID; DisplayCurrentICSRole();
            } else { cboICSRole.SelectedIndex = 0; }

            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { this.Text = Globals.ProgramName + " - " + CurrentIncident.FileName; }
            else { this.Text = Globals.ProgramName; }

            numOpPeriod.Value = CurrentIncident.highestOpsPeriod;
            if (!CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber == CurrentOpPeriod).Any()) { CurrentIncident.AllOperationalPeriods = CurrentIncident.InferOperationalPeriods(); }
            datOpsStart.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentIncident.highestOpsPeriod).PeriodStart;
            datOpsEnd.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentIncident.highestOpsPeriod).PeriodEnd;


            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { tmrAutoSave.Enabled = Program.generalOptionsService.GetOptionsBoolValue("AutoSave"); }
            setButtonCheckboxes();
            browseToIncidentFolderToolStripMenuItem.Enabled = true;
        }

        private void DisplayCurrentICSRole()
        {
            if (Program.CurrentRole != null)
            {
                List<Guid> ChiefIDs = new List<Guid>();
                ChiefIDs.Add(Globals.OpsChiefID); ChiefIDs.Add(Globals.PlanningChiefID); ChiefIDs.Add(Globals.LogisticsChiefID); ChiefIDs.Add(Globals.FinanceChiefID);ChiefIDs.Add(Globals.DeputyIncidentCommanderID);
                List<Guid> ICRoles = new List<Guid>();
                ICRoles.Add(Globals.IncidentCommanderID); ICRoles.Add(Globals.DeputyIncidentCommanderID); ICRoles.Add(Globals.UnifiedCommand1ID); ICRoles.Add(Globals.UnifiedCommand2ID); ICRoles.Add(Globals.UnifiedCommand3ID);

                List<Guid> CommandStaffRoles = new List<Guid>();
                foreach(ICSRole role in CurrentOrgChart.AllRoles.Where(o=>o.ReportsTo == Globals.IncidentCommanderID && !ChiefIDs.Contains(o.RoleID)))
                {
                    CommandStaffRoles.Add(role.RoleID);
                }

                foreach (CollapsiblePanel panel in collapsiblePanels) { panel.BackColor = Color.White; }
                collapseAllPanels();
                //resizeGroup("Assignments", false, true);
                if (ICRoles.Contains(Program.CurrentRole.RoleID))
                {
                    pnlTaskInfo.BackColor = Color.LimeGreen;
                    cpIncidentActionPlan.Expand();
                    //    pnlCommandTeam.BackColor = Color.LimeGreen;
                }
                else if (CommandStaffRoles.Contains(Program.CurrentRole.RoleID))
                {
                    pnlTaskInfo.BackColor = Color.IndianRed;
                    cpIncidentActionPlan.Expand();
                }
                else if (Program.CurrentRole.BranchID == Globals.OpsChiefID)
                {
                    pnlTaskInfo.BackColor = Color.Orange;
                    cpOperations.Expand();
                    //resizeGroup("Ops", false, true);
                }
                else if (Program.CurrentRole.BranchID == Globals.PlanningChiefID)
                {
                    pnlTaskInfo.BackColor = Color.CornflowerBlue;
                    cpPlanning.Expand();
/*
                    pnlIAP.BackColor = Color.CornflowerBlue;
                    pnlCommandTeam.BackColor = Color.CornflowerBlue;
                    pnlPlanning.BackColor = Color.CornflowerBlue;
                    tcStatus.SelectedIndex = 1;
                    resizeGroup("Planning", false, true);*/

                }
                else if (Program.CurrentRole.BranchID == Globals.LogisticsChiefID)
                {
                    pnlTaskInfo.BackColor = Color.Khaki;
                    cpLogistics.Expand();
                    /*
                    pnlCommsPlan.BackColor = Color.Khaki;
                    pnlIAP.BackColor = Color.Khaki;
                    pnlLogistics.BackColor = Color.Khaki;
                    tcStatus.SelectedIndex = 3;
                    resizeGroup("Logistics", false, true);
                    */
                }
                else if (Program.CurrentRole.BranchID == Globals.FinanceChiefID)
                {
                    pnlTaskInfo.BackColor = Color.LightGray;
                }


                else
                {
                    pnlTaskInfo.BackColor = Color.White;
                }
                CheckForPositionLogReminders();
            }
        }

        private void TriggerAutoSave()
        {
            if (!saveAsPromptShown)
            {
                if (Program.generalOptionsService.GetOptionsBoolValue("AutoSave") && lastSaveSuccessful) { if (initialDetailsSet(false, false)) { if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { saveFile(false, false); } } }
            }

        }

        private void Program_AircraftChanged(AircraftEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();

        }

        private void Program_AirOpsSummaryChanged(AirOperationsSummaryEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();

        }


        private void Program_OperationalPeriodChanged(OperationalPeriodEventArgs e)
        {
            if(e.item.PeriodNumber == Program.CurrentOpPeriod)
            {
                datOpsStart.Value = e.item.PeriodStart;
                datOpsEnd.Value = e.item.PeriodEnd;
            }
            TriggerAutoSave();
        }

        private void Program_TaskBasicsChanged(TaskBasicsEventArgs e)
        {
            txtTaskName.Text = e.item.TaskName;
            txtTaskNumber.Text = e.item.TaskNumber;
            txtICPCallsign.Text = e.item.ICPCallSign;


            TriggerAutoSave();
        }

        private void Program_CommsPlanChanged(CommsPlanEventArgs e)
        {
            if(e.item.OpsPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();
        }

        private void Program_CommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if (e.item.OpsPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();

        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                buildICSRoleDropdown();
                setButtonCheckboxes();

            }
            TriggerAutoSave();

        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                buildICSRoleDropdown();
                setButtonCheckboxes();


            }
            TriggerAutoSave();

        }
        private void Program_PositionLogChanged(PositionLogEventArgs e)
        {
            if (!PauseNetworkSend && CurrentIncident.allPositionLogEntries.Any(o => o.LogID == e.item.LogID) && (ThisMachineIsServer || ThisMachineIsClient))
            {
                //don't send it again if we just received it
                /*
                if (!Program.networkSendLog.ObjectAlreadySent(e.item))
                {
                    SendNetworkObject(e.item);
                }
                */
            }
            TriggerAutoSave();
        }


        private bool initialDetailsSet(bool checkOpPeriod = true, bool promptOnerror = true)
        {
            bool set = false;
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(txtTaskName.Text.Trim()) || !string.IsNullOrEmpty(txtTaskNumber.Text.Trim())) { set = true; }
            else { set = false; errors.Add("You must set either an incident name or number to begin."); }

            if (string.IsNullOrEmpty(txtTaskName.Text.Trim())) { txtTaskName.BackColor = Program.ErrorColor; }
            else { txtTaskName.BackColor = Program.GoodColor; ; }

            if (string.IsNullOrEmpty(txtTaskNumber.Text.Trim())) { txtTaskNumber.BackColor = Program.ErrorColor; }
            else { txtTaskNumber.BackColor = Program.GoodColor; ; }


            bool tasknamechanged = !CurrentIncident.TaskName.EqualsWithNull(txtTaskName.Text.Trim());
            if (tasknamechanged) { CurrentIncident.TaskName = txtTaskName.Text.Trim(); }

            bool tasknumberchanged = !CurrentIncident.TaskNumber.EqualsWithNull(txtTaskNumber.Text.Trim());
            if (tasknumberchanged && validateTaskNumber()) { CurrentIncident.TaskNumber = txtTaskNumber.Text.Trim(); }

            if (tasknamechanged || tasknumberchanged)
            {
                TaskBasics basics = new TaskBasics(CurrentIncident);
                Program.wfIncidentService.UpdateTaskBasics(basics, "local");
            }






            if (!set)
            {
                StringBuilder err = new StringBuilder();
                err.Append("This app works best if you enter some basic information first:\r\n");
                foreach (string s in errors)
                {
                    err.Append(" -"); err.Append(s); err.Append("\r\n");
                }
                if (promptOnerror) { MessageBox.Show(err.ToString(), "Errors"); }
            }
            /*
            else if (checkOpPeriod && !incorrectOpAcknowledged &&CurrentIncident.allAssignments.Count > 0 && CurrentOpPeriod < CurrentIncident.allAssignments.OrderByDescending(o => o.OpPeriod).First().OpPeriod)
            {
                DialogResult dr = MessageBox.Show("This op period is ealier than that used on some assignments, are you sure it is correct?", "Confirm Op Period", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    set = false;
                }
                else { incorrectOpAcknowledged = true; }
            }*/
            return set;
        }

        private void CheckForPositionLogReminders()
        {
            bool reminders = Program.CurrentIncident.allPositionLogEntries.Any(o => o != null && o.Role.RoleID == Program.CurrentRole.RoleID && o.OpPeriod == CurrentOpPeriod && !o.IsInfoOnly && !o.IsComplete && o.ReminderTime > DateTime.MinValue && o.ReminderTime < DateTime.MaxValue);
            if (reminders)
            {
                tmrPositionLogReminders.Enabled = true;
            }
        }

        private bool validateTaskNumber()
        {
            if (!Program.generalOptionsService.GetOptionsBoolValue("AllowStringTaskNumber"))
            {
                return (System.Text.RegularExpressions.Regex.IsMatch(txtTaskNumber.Text, "^[0-9]+$"));
            }
            else
            {
                return !string.IsNullOrEmpty(txtTaskNumber.Text);
            }
        }

        private void CreateNewIncident()
        {
            browseToIncidentFolderToolStripMenuItem.Enabled = false;
            CurrentIncident = new WFIncident();
            OperationalPeriod period = CurrentIncident.GenerateFirstOpPeriod();
            if (period != null) { Program.wfIncidentService.UpsertOperationalPeriod(period); }

            CurrentIncident.createOrgChartAsNeeded(period.PeriodNumber);
            

            if (Program.generalOptionsService.GetGuidOptionValue("OrganizationID") != Guid.Empty) { CurrentIncident.OrganizationID = Program.generalOptionsService.GetGuidOptionValue("OrganizationID"); }
            CurrentIncident.ICPCallSign = txtICPCallsign.Text;

            CurrentIncident.DocumentPath = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation");
            checkForSave = false;
            //setSavedFlag(false);
            LastAutoBackup = DateTime.Now;

            //AddDefaultEquipment(CurrentOpPeriod);

            PauseNetworkSend = true;
            PauseNetworkSend = false;

        }


        private void openTask(string filename = null)
        {
            if (filename == null)
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!string.IsNullOrEmpty(Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation")))
                {
                    folder = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation");
                }
                else
                {
                    folder = Path.Combine(folder, "CIAPPO");
                    System.IO.Directory.CreateDirectory(folder);
                }
                ofdOpenTaskFile.InitialDirectory = folder;
                ofdOpenTaskFile.ShowDialog();
                filename = ofdOpenTaskFile.FileName;
            }
            if (!string.IsNullOrEmpty(filename))
            {
                //they've chosen a file, try to open it.
                CloseActiveForms();
                PauseNetworkSend = true;
                try
                {
                    XmlSerializer reader = new XmlSerializer(typeof(WFIncident));
                    using (StreamReader file = new StreamReader(filename))
                    {
                        using (XmlReader xr = XmlReader.Create(file, new XmlReaderSettings() { DtdProcessing = DtdProcessing.Prohibit }))
                        {
                            WFIncident testTaskDeserialize = (WFIncident)reader.Deserialize(xr);
                            CurrentIncident = testTaskDeserialize;
                            CurrentOpPeriod = testTaskDeserialize.highestOpsPeriod;

                            List<string> recentFilePaths = (List<string>)OptionValue("RecentFiles");
                            Program.generalOptionsService.UpserOptionValue(filename, "RecentFileName");
                            setRecentFiles();
                        }
                        file.Close();
                        CurrentIncident.currentFilePath = Path.GetDirectoryName(filename);
                        CurrentIncident.DocumentPath = Path.GetDirectoryName(filename);
                        CurrentIncident.FileName = filename;
                        askedForInitialSave = true;
                        if (!CurrentIncident.AllOperationalPeriods.Any()) { CurrentIncident.AllOperationalPeriods = CurrentIncident.InferOperationalPeriods(); }

                        LastAutoBackup = DateTime.Now;
                        displayIncidentDetails();

                        //setSavedFlag(true);

                        browseToIncidentFolderToolStripMenuItem.Enabled = true;
                        // minimiseAllCollapsablePanels();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error loading the Incident: " + ex.ToString());
                }

                PauseNetworkSend = false;
            }
        }



        private void saveFile(bool forceBrowseForFile = false, bool notifyOnSave = true)
        {
            if (initialDetailsSet(false))
            {
                CurrentIncident.TaskName = txtTaskName.Text;
                if (validateTaskNumber())
                {
                    CurrentIncident.TaskNumber = txtTaskNumber.Text;
                }

                //saveSelectedCommsPlanItems("Save File");

                if (!string.IsNullOrEmpty(txtICPCallsign.Text)) { CurrentIncident.ICPCallSign = txtICPCallsign.Text; }
                else { CurrentIncident.ICPCallSign = "BASE"; }
                string fileName = CurrentIncident.FileName;
                bool proceed = true;
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName) || forceBrowseForFile)
                {
                    string path = "";
                    if (!string.IsNullOrEmpty(Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation"))) { path = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation"); }
                    else
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        path = Path.Combine(path, "CIAPPO");

                    }
                    path = Path.Combine(path, "Incident " + CurrentIncident.IncidentIdentifier);
                    try
                    {
                        System.IO.Directory.CreateDirectory(path);


                    }
                    catch (IOException ioex)
                    {
                        MessageBox.Show("There was an error creating the folder for this Incident.  Please verify that the current user has access to the folder specified, and it is not in the process of syncronizing with a cloud service.");
                        proceed = false;
                    }
                    if (proceed)
                    {
                        svdTaskFile.InitialDirectory = path;
                        svdTaskFile.DefaultExt = "xml";
                        svdTaskFile.FileName = "ICS Forms - Incident " + CurrentIncident.IncidentIdentifier + ".xml";
                        svdTaskFile.Filter = "Extensible Markup Language|*.xml";
                        svdTaskFile.Title = "Save Incident Information";
                        DialogResult sv = svdTaskFile.ShowDialog();

                        if (sv == DialogResult.Cancel)
                        {
                            fileName = null;
                            //txtFileName.Text = "";
                            Text = Globals.ProgramName + " - Unsaved Incident";
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(svdTaskFile.FileName)) { fileName = svdTaskFile.FileName; this.Text = Globals.ProgramName + " - " + svdTaskFile.FileName; }
                            else { this.Text = Globals.ProgramName; }


                            //txtFileName.Text = svdTaskFile.FileName;
                        }
                    }
                }

                if (proceed && !string.IsNullOrEmpty(fileName))
                {
                    try
                    {

                        System.Xml.XmlWriterSettings ws = new System.Xml.XmlWriterSettings();
                        ws.NewLineHandling = System.Xml.NewLineHandling.Entitize;

                        var path = fileName;
                        XmlSerializer ser = new XmlSerializer(typeof(WFIncident));
                        using (System.Xml.XmlWriter wr = System.Xml.XmlWriter.Create(path, ws))
                        {
                            ser.Serialize(wr, CurrentIncident);
                        }

                        //System.IO.FileStream file = System.IO.File.Create(path);

                        //writer.Serialize(file, CurrentIncident);
                        //file.Close();
                        if (notifyOnSave) { MessageBox.Show("Save Complete"); }
                        CurrentIncident.FileName = path;
                        CurrentIncident.DocumentPath = null;
                        CurrentIncident.DocumentPath = FileAccessClasses.getWritablePath(CurrentIncident);

                        //displayTaskDetails();
                        askedForInitialSave = true;
                        checkForSave = false;
                        lastSaveSuccessful = true;
                        lastSuccessfulSaveTime = DateTime.Now;

                        List<string> recentFilePaths = (List<string>)OptionValue("RecentFiles");
                        Program.generalOptionsService.UpserOptionValue(fileName, "RecentFileName");


                        setRecentFiles();
                        //setSavedFlag(true);
                        //tmrAutoSave.Enabled = options.AutoSave;

                        browseToIncidentFolderToolStripMenuItem.Enabled = true;
                        CreateAutomaticSubFolders();
                    }
                    catch (IOException)
                    {
                        lastSaveSuccessful = false;
                        if (notifyOnSave)
                        {
                            MessageBox.Show("The file has NOT been saved.  It may be open in another program, or the disk may be full.");

                        }
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        lastSaveSuccessful = false;
                        if (notifyOnSave)
                        {
                            MessageBox.Show("A program on your system, typically a virus scanner, is prevening files from being saved to " + fileName + ". Please select a different folder to save to.");
                        }
                        saveFile(true);
                    }
                    catch (Exception ex)
                    {
                        lastSaveSuccessful = false;
                        if (notifyOnSave)
                        {
                            MessageBox.Show("The file has NOT been saved.  An error has been encountered, please report the following:" + ex.Message);

                        }

                    }
                }
            }
        }

        private void CreateAutomaticSubFolders()
        {
            if (OptionValue("AutomaticSubFolders") != null)
            {
                List<string> folders = (List<string>)OptionValue("AutomaticSubFolders");
                foreach (string s in folders)
                {
                    string path = CurrentIncident.DocumentPath;
                    path = Path.Combine(path, s);
                    System.IO.Directory.CreateDirectory(path);

                }

            }
        }

        private void setRecentFiles()
        {
            recentIncidentsToolStripMenuItem.DropDownItems.Clear();
            List<string> recentFilePaths = (List<string>)OptionValue("RecentFiles");
            if (recentFilePaths.Any())
            {
                foreach (string s in recentFilePaths)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = s.shortenFileName();
                    item.Tag = s;
                    item.Click += new EventHandler(recent_file_Click);
                    recentIncidentsToolStripMenuItem.DropDownItems.Add(item);
                }
            }
        }

        void recent_file_Click(object sender, EventArgs e)
        {
            if (checkForSave && MessageBox.Show("Would you like to save the current incident before opening another?", "Save current incident?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tag = ((ToolStripMenuItem)sender).Tag.ToString();
                //MessageBox.Show(tag);
                openTask(tag);
            }
            else
            {
                string tag = ((ToolStripMenuItem)sender).Tag.ToString();
                //MessageBox.Show(tag);
                openTask(tag);
            }
        }

        private void txtTaskName_Leave(object sender, EventArgs e)
        {
            /*
            if (!PauseNetworkSend)
            {
                bool changed = (string.IsNullOrEmpty(CurrentIncident.TaskName) || !CurrentIncident.TaskName.Equals(((TextBox)sender).Text));
                CurrentIncident.TaskName = txtTaskName.Text;
                checkForSave = true;
                if (changed)
                {
                    TaskBasics basics = new TaskBasics(CurrentIncident);
                    Program.wfIncidentService.UpdateTaskBasics(basics, "local");
                }
            }
            */
            initialDetailsSet(true, false);

        }

        private void txtTaskNumber_Leave(object sender, EventArgs e)
        {
            /*
            if (!PauseNetworkSend)
            {
                
                bool changed = (string.IsNullOrEmpty(CurrentIncident.TaskNumber) || !CurrentIncident.TaskNumber.Equals(((TextBox)sender).Text));
                CurrentIncident.TaskNumber = ((TextBox)sender).Text;
                checkForSave = true;
                if (changed)
                {
                    TaskBasics basics = new TaskBasics(CurrentIncident);
                    Program.wfIncidentService.UpdateTaskBasics(basics, "local");
                }
            }*/
            initialDetailsSet(true, false);

        }

        private void txtTaskNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Program.generalOptionsService.GetOptionsBoolValue("AllowStringTaskNumber"))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) //&&        (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTaskNumber_Validating(object sender, CancelEventArgs e)
        {
            if(initialDetailsSet(false, false) && !askedForInitialSave && !ThisMachineIsClient && Program.generalOptionsService.GetOptionsBoolValue("PromptForInitialSave"))
            {
                askedForInitialSave = true;
                DialogResult result = MessageBox.Show("Would you like to save this task now? (you can always select File > Save As... in the future)", "Save Task", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    saveFile();
                }

            }
            /*
            if (string.IsNullOrEmpty(txtTaskNumber.Text)) { txtTaskNumber.BackColor = Program.ErrorColor; }
            else if (!validateTaskNumber()) { txtTaskNumber.BackColor = Program.ErrorColor; }
            else { txtTaskNumber.BackColor = Color.LightGreen; }
            */
        }

        private void communicationsListICS205AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCommunicationsList();
        }

        private void openCommunicationsList()
        {
            if (initialDetailsSet())
            {
                if (null == communicationsList)
                {
                    communicationsList = new CommunicationsListForm();
                    communicationsList.FormClosed += CommunicationsListForm_Closed;
                    communicationsList.Show(this);
                    ActiveForms.Add(communicationsList);
                }

                communicationsList.BringToFront();
            }

           
        
        }
        void CommunicationsListForm_Closed(object sender, FormClosedEventArgs e)
        {
           
            RemoveActiveForm(communicationsList);
            communicationsList = null;

        }

        private void txtTaskName_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cboICSRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboICSRole.SelectedItem != null)
            {
                Program.CurrentRole = (ICSRole)(cboICSRole.SelectedItem);
                DisplayCurrentICSRole();
            }

        }

        private void organizationChartICS207ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openOrganizationChart();
        }

        private void openOrganizationChart()
        {
            if (initialDetailsSet())
            {
                if (null == orgChartForm)
                {
                    orgChartForm = new OrganizationalChartForm();
                    orgChartForm.FormClosed += OrganizationChartForm_Closed;
                    orgChartForm.Show(this);
                    ActiveForms.Add(orgChartForm);
                }

                orgChartForm.BringToFront();
            }



        }
        void OrganizationChartForm_Closed(object sender, FormClosedEventArgs e)
        {

            RemoveActiveForm(orgChartForm);
            orgChartForm = null;

        }

        private void btnPrintOrgChart_Click(object sender, EventArgs e)
        {
            openOrganizationChart();

        }


        private void openCommsPlan()
        {
            if (initialDetailsSet())
            {
                if (null == commsPlanForm)
                {
                    commsPlanForm = new CommunicationsPlanForm();
                    commsPlanForm.FormClosed += CommunicationsPlanForm_Closed;
                    commsPlanForm.Show(this);
                    ActiveForms.Add(commsPlanForm);
                }

                commsPlanForm.BringToFront();
            }



        }
        void CommunicationsPlanForm_Closed(object sender, FormClosedEventArgs e)
        {

            RemoveActiveForm(commsPlanForm);
            commsPlanForm = null;

        }

        private void cboICSRole_Leave(object sender, EventArgs e)
        {
            /*
            if(cboICSRole.SelectedValue != null)
            {
                Program.CurrentRole = (ICSRole)(cboICSRole.SelectedItem);
                DisplayCurrentICSRole();
            }*/
        }

        private void btnAddToPositionLog_Click(object sender, EventArgs e)
        {
            if (initialDetailsSet())
            {
                PositionLogEntry entry = new PositionLogEntry();
                entry.DateCreated = DateTime.Now;
                entry.TimeDue = CurrentIncident.getOpPeriodEnd(CurrentOpPeriod);
                entry.ReminderTime = entry.TimeDue;
                entry.IsInfoOnly = true;
                entry.Role = Program.CurrentRole;
                entry.OpPeriod = CurrentOpPeriod;

                PositionLogAddForm _positionLogAddForm = new PositionLogAddForm();
                _positionLogAddForm.thisEntry = entry;
                DialogResult dr = _positionLogAddForm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertPositionLogEntry(entry);


                }
            }
        }


        private void OpenPositionLog()
        {
            if (initialDetailsSet())
            {
                if (_positionLogForm == null)
                {
                    _positionLogForm = new PositionLogForm();
                    _positionLogForm.FormClosed += new FormClosedEventHandler(PositionLogForm_Closed);
                    ActiveForms.Add(_positionLogForm);
                    _positionLogForm.Show(this);
                }

                _positionLogForm.BringToFront();
            }
        }
        private void btnViewPositionLog_Click(object sender, EventArgs e)
        {
            OpenPositionLog();
        }
        void PositionLogForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_positionLogForm);
            _positionLogForm = null;


        }
        private void btnOutstandingLogItems_Click(object sender, EventArgs e)
        {
            if (initialDetailsSet())
            {
                if (_positionLogAllOutstandingForm == null)
                {
                    _positionLogAllOutstandingForm = new PositionLogAllOutstandingForm();
                    _positionLogAllOutstandingForm.FormClosed += new FormClosedEventHandler(PositionLogOutstandingForm_Closed);
                    ActiveForms.Add(_positionLogAllOutstandingForm);
                    _positionLogAllOutstandingForm.Show(this);
                }
                _positionLogAllOutstandingForm.BringToFront();
            }
        }

        void PositionLogOutstandingForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_positionLogAllOutstandingForm);
            _positionLogAllOutstandingForm = null;


        }

        private void positionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPositionLog();
        }

        private void positionLogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenPositionLog();
        }

        private void positionLogToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenPositionLog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OptionsForm editOptions = new OptionsForm())
            {
                DialogResult result = editOptions.ShowDialog();
                
            }
        }

        private void communicationsPlanICS205ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCommsPlan();
        }

        private void btnCommsPlan_Click(object sender, EventArgs e)
        {
            openCommsPlan();
        }

        private void incidentObjectivesICS202ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenIncidentObjectivesForm();
        }

        private void OpenIncidentObjectivesForm()
        {
            if (initialDetailsSet())
            {
                if (objectivesForm == null)
                {
                    objectivesForm = new IncidentObjectivesForm();
                    objectivesForm.FormClosed += new FormClosedEventHandler(IncidentObjectivesForm_Closed);
                    ActiveForms.Add(objectivesForm);
                    objectivesForm.Show(this);
                }

                objectivesForm.BringToFront();
            }
        }
        void IncidentObjectivesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(objectivesForm);
            objectivesForm = null;


        }

        private void btnIncidentObjectives_Click(object sender, EventArgs e)
        {
            OpenIncidentObjectivesForm();
        }

        private void Program_IncidentObjectivesSheetChanged(IncidentObjectivesSheetEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }

        private void Program_MedicalPlanChanged(MedicalPlanEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }

        private void Program_SafetyMessageChanged(SafetyMessageEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }

        private void Program_VehicleChanged(VehicleEventArgs e)
        {
            TriggerAutoSave();
        }

        private void Program_NoteChanged(NoteEventArgs e)
        {
            TriggerAutoSave();
        }

        private void Program_GeneralMessageChanged(GeneralMessageEventArgs e)
        {
            TriggerAutoSave();
        }

        private void Program_IncidentObjectiveChanged(IncidentObjectiveEventArgs e)
        {
            if (e.item.OpPeriod == CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }

        private void generalMessageICS213ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenGeneralMessagesForm();

        }

        private void OpenGeneralMessagesForm()
        {
            if (initialDetailsSet())
            {
                if (generalMessagesForm == null)
                {
                    generalMessagesForm = new GeneralMessagesForm();
                    generalMessagesForm.FormClosed += new FormClosedEventHandler(GeneralMessagesForm_Closed);
                    ActiveForms.Add(generalMessagesForm);
                    generalMessagesForm.Show(this);
                }

                generalMessagesForm.BringToFront();
            }
        }
        void GeneralMessagesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(generalMessagesForm);
            generalMessagesForm = null;


        }

        private void pnlTaskInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void positionLogToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenPositionLog();

        }

        private void btnMedicalPlan_Click(object sender, EventArgs e)
        {
            OpenMedicalPlanForm();
        }

        private void medicalPlanICS206ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMedicalPlanForm();
        }


        private void OpenMedicalPlanForm()
        {
            if (initialDetailsSet())
            {
                if (medicalPlanForm == null)
                {
                    medicalPlanForm = new MedicalPlanForm();
                    medicalPlanForm.FormClosed += new FormClosedEventHandler(MedicalPlanForm_Closed);
                    ActiveForms.Add(medicalPlanForm);
                    medicalPlanForm.Show(this);
                }

                medicalPlanForm.BringToFront();
            }
        }
        void MedicalPlanForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(medicalPlanForm);
            medicalPlanForm = null;


        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNotesForm();
        }

        private void OpenNotesForm()
        {
            if (initialDetailsSet())
            {
                if (notesForm == null)
                {
                    notesForm = new NotesForm();
                    notesForm.FormClosed += new FormClosedEventHandler(NotesForm_Closed);
                    ActiveForms.Add(notesForm);
                    notesForm.Show(this);
                }

                notesForm.BringToFront();
            }
        }
        void NotesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(notesForm);
            notesForm = null;


        }

        private void safetyMessageICS208ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSafetyMessageForm();
        }

        private void btnSafetyPlans_Click(object sender, EventArgs e)
        {
            OpenSafetyMessageForm();
        }

        private void OpenSafetyMessageForm()
        {
            if (initialDetailsSet())
            {
                if (safetyMessagesForm == null)
                {
                    safetyMessagesForm = new SafetyMessagesForm();
                    safetyMessagesForm.FormClosed += new FormClosedEventHandler(SafetyMessagesForm_Closed);
                    ActiveForms.Add(safetyMessagesForm);
                    safetyMessagesForm.Show(this);
                }

                safetyMessagesForm.BringToFront();
            }
        }
        void SafetyMessagesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(safetyMessagesForm);
            safetyMessagesForm = null;


        }

        private void vehiclesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenVehiclesForm();
        }

        private void OpenVehiclesForm()
        {
            if (initialDetailsSet())
            {
                if (vehiclesForm == null)
                {
                    vehiclesForm = new VehiclesForm();
                    vehiclesForm.FormClosed += new FormClosedEventHandler(VehiclesForm_Closed);
                    ActiveForms.Add(vehiclesForm);
                    vehiclesForm.Show(this);
                }

                vehiclesForm.BringToFront();
            }
        }
        void VehiclesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(vehiclesForm);
            vehiclesForm = null;


        }

        private void btnPrintIAP_Click(object sender, EventArgs e)
        {
            OpenPrintIAPForm(false, true);
        }

        private void OpenPrintIAPForm(bool PrintCompleteIncident = false, bool DefaultJustIAP = false)
        {
            if (initialDetailsSet())
            {
                if (printIAPForm == null)
                {
                    printIAPForm = new PrintIncidentForm();
                    printIAPForm.PrintIAPByDefault = DefaultJustIAP;
                    printIAPForm.PrintIncidentToDate = PrintCompleteIncident;
                    printIAPForm.FormClosed += new FormClosedEventHandler(PrintIAPForm_Closed);
                    ActiveForms.Add(printIAPForm);
                    printIAPForm.Show(this);
                }

                printIAPForm.BringToFront();
            }
        }
        void PrintIAPForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(printIAPForm);
            printIAPForm = null;


        }


            private void OpenSavedAircraftForm()
        {
           
                if (savedAircraftForm == null)
                {
                    savedAircraftForm = new SavedAircraftsForm();
                    savedAircraftForm.FormClosed += new FormClosedEventHandler(SavedAircraftForm_Closed);
                    ActiveForms.Add(savedAircraftForm);
                    savedAircraftForm.Show(this);
                }

                savedAircraftForm.BringToFront();
            
        }
        void SavedAircraftForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedAircraftForm);
            savedAircraftForm = null;


        }

        private void additionalContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openCommunicationsList();
        }

        private void printThisOperationalPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPrintIAPForm(false, false);
        }

        private void printThisIncidentToDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPrintIAPForm(true, false);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenVehiclesForm();
        }

        private void btnAdditionalContacts_Click(object sender, EventArgs e)
        {
            openCommunicationsList();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            OpenNotesForm();
        }

        private void aircraftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSavedAircraftForm();
        }


        private void OpenAirOpsForm()
        {
            if (initialDetailsSet())
            {
                if (airOperationsForm == null)
                {
                    airOperationsForm = new AirOperationsForm();
                    airOperationsForm.FormClosed += new FormClosedEventHandler(AirOpsSummaryForm_Closed);
                    ActiveForms.Add(airOperationsForm);
                    airOperationsForm.Show(this);
                }

                airOperationsForm.BringToFront();
            }
        }
        void AirOpsSummaryForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(airOperationsForm);
            airOperationsForm = null;


        }

        private void airOperationsSummaryICS220ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAirOpsForm();
        }

        private void btnAirOpsSummary_Click(object sender, EventArgs e)
        {
            OpenAirOpsForm();
        }

        private void btnICSRoleHelp_Click(object sender, EventArgs e)
        {

            HelpInfo info = new HelpInfo(Program.CurrentRole.RoleName, Program.CurrentRole.RoleDescription);

            using (HelpInfoForm help = new HelpInfoForm())
            {
                help.Title = info.Title;
                help.Body = info.Body;
                help.ShowDialog();
            }

        }

        private void datOpsStart_Leave(object sender, EventArgs e)
        {
            OperationalPeriod per = Program.CurrentIncident.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == Program.CurrentOpPeriod);
            if (per != null)
            {
                per.PeriodStart = datOpsStart.Value;
                Program.wfIncidentService.UpsertOperationalPeriod(per);
            }
        }

        private void datOpsEnd_Leave(object sender, EventArgs e)
        {
            OperationalPeriod per = Program.CurrentIncident.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == Program.CurrentOpPeriod);
            if (per != null)
            {
                per.PeriodEnd = datOpsEnd.Value;
                Program.wfIncidentService.UpsertOperationalPeriod(per);
            }

        }
    }
}
