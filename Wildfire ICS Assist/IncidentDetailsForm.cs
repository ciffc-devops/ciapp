using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet;
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
using WF_ICS_ClassLibrary.Networking;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.OptionsForms;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.DPSBase;
using Wildfire_ICS_Assist.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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
            
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;

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
            cpIncidentActionPlan.Expand();
            cpOtherTools.Expand();
            //collapseAllPanels();

            //debug
            cpIncidentActionPlan.CurrentlyCollapsed = false;

            CreateNewIncident();
            displayIncidentDetails();

            WireWFIncidentServiceEvents();

            ICSRole defaultRole = (ICSRole)Program.generalOptionsService.GetOptionsValue("DefaultICSRole");
            if (defaultRole != null && defaultRole.RoleID != Guid.Empty) { cboICSRole.SelectedValue = defaultRole.RoleID; }

            Program.networkService.CurrentIncidentID = Program.CurrentIncident.TaskID;
            //Default status for networking
            if (Program.generalOptionsService.GetOptionsBoolValue("DefaultToNetworkServer"))
            {

                StartAsServer();

            }
            setServerStatusDisplay();

            datOpsEnd.CustomFormat = Program.DateFormat + " HH:mm";
            datOpsStart.CustomFormat = Program.DateFormat + " HH:mm";

            NetworkComms.AppendGlobalIncomingPacketHandler<WFIncident>("WFIncident", Program.networkService.HandleIncomingIncident);




        }

        private void StartAsServer()
        {
            int defaultPortNumber = 42999;
            if (Program.generalOptionsService.GetOptionsValue("DefaultPort") != null) { defaultPortNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("DefaultPort")); }

            string tempServerIP = null;
            if (Program.generalOptionsService.GetStringOptionValue("LastIpUsedWhenMachineIsServer") != null) { tempServerIP = Program.generalOptionsService.GetStringOptionValue("LastIpUsedWhenMachineIsServer"); }

            List<string> allIPs = Program.networkService.GetAllIPs(false);
            if (allIPs.Count == 0)
            {
                //no dnsable ips were found, broaden the search
                allIPs = Program.networkService.GetAllIPs(true);
            }


            if (allIPs.Count == 1)
            {
                tempServerIP = allIPs[0];
            }
            else if (allIPs.Count > 1 && !allIPs.Contains(tempServerIP))
            {


                using (NetworkSelectIPForm selectIPForm = new NetworkSelectIPForm())
                {
                    selectIPForm.ipAddresses = allIPs;
                    DialogResult dr = selectIPForm.ShowDialog();
                    tempServerIP = selectIPForm.SelectedAddress;
                    Program.generalOptionsService.UpserOptionValue(tempServerIP, "LastIpUsedWhenMachineIsServer");
                }
            }

            bool firewallEnabled = Program.networkService.GetIsFirewallEnabled();
            bool portAvailable = Program.networkService.GetIsPortAvailable(defaultPortNumber);
            if (firewallEnabled && !portAvailable)
            {
                MessageBox.Show("A firewall may be blocking this application. Please try an alternate port, or make an exception in your firewall to allow this program to operate over a network.");
            }
            else if (Program.networkService.StartAsServer(defaultPortNumber, tempServerIP))
            {

            }
            else
            {
                MessageBox.Show("A firewall may be blocking this application. Please try an alternate port, or make an exception in your firewall to allow this program to operate over a network.");

            }
        }

        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }

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
        SavedCommsItemsForm savedCommsItemsForm = null;
        SavedVehiclesForm savedVehiclesForm = null;
        SavedIncidentObjectivesForm savedObjectivesForm = null;
        SavedSafetyNotesForm savedSafetyNotesForm = null;
        SavedPersonnelForm savedTeamMembersForm = null;
        SavedAircraftsForm savedAircraftForm = null;


        CommunicationsListForm _communicationsListForm = null;
        CommunicationsPlanForm _commsPlanForm = null;
        OrganizationalChartForm _orgChartForm = null;
        PositionLogForm _positionLogForm = null;
        PositionLogAllOutstandingForm _positionLogAllOutstandingForm = null;
        IncidentObjectivesForm _objectivesForm = null;
        GeneralMessagesForm _generalMessagesForm = null;
        MedicalPlanForm _medicalPlanForm = null;
        NotesForm _notesForm = null;
        SafetyMessagesForm _safetyMessagesForm = null;
        PrintIncidentForm _printIAPForm = null;
        AirOperationsForm _airOperationsForm = null;
        //TeamAssignmentsForm _teamAssignmentsForm = null;
        OperationalGroupsForm _operationalGroupsForm = null;
        PositionLogReminderForm _positionLogReminderForm = null;
        CheckedInResourcesForm _checkedInresourcesForm = null;
        CloseOpPeriodForm _closeOpPeriodForm = null;

        public event ShortcutEventHandler ShortcutButtonClicked;


        //Network Stuff
        Guid NetworkTestGuidValue = Guid.Empty;
        bool silentNetworkTest = true;
        bool initialConnectionTest = false;
        private bool lostConnectionShowing = false;
        private bool networkTaskRequested = false;
        private bool networkOptionsRequested = false;




        List<CollapsiblePanel> collapsiblePanels = new List<CollapsiblePanel>();


        private void WireWFIncidentServiceEvents()
        {
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.wfIncidentService.PositionLogChanged += Program_PositionLogChanged;
            Program.wfIncidentService.IncidentObjectiveChanged += Program_IncidentObjectiveChanged;
            Program.wfIncidentService.IncidentObjectivesSheetChanged += Program_IncidentObjectivesSheetChanged;
            Program.wfIncidentService.GeneralMessageChanged += Program_GeneralMessageChanged;
            Program.wfIncidentService.MedicalPlanChanged += Program_MedicalPlanChanged;
            Program.wfIncidentService.MedicalAidStationChanged += Program_AidStationChanged;
            Program.wfIncidentService.AmbulanceServiceChanged += Program_MedivacChanged;
            Program.wfIncidentService.HospitalChanged += Program_HospitalChanged;
            Program.wfIncidentService.NoteChanged += Program_NoteChanged;
            Program.wfIncidentService.SafetyMessageChanged += Program_SafetyMessageChanged;
            Program.wfIncidentService.VehicleChanged += Program_VehicleChanged;
            Program.wfIncidentService.CommsPlanChanged += Program_CommsPlanChanged;
            Program.wfIncidentService.CommsPlanItemChanged += Program_CommsPlanItemChanged;
            Program.wfIncidentService.AircraftChanged += Program_AircraftChanged;
            Program.wfIncidentService.AircraftsOperationsSummaryChanged += Program_AirOpsSummaryChanged;
            Program.wfIncidentService.TaskBasicsChanged += Program_TaskBasicsChanged;
            Program.wfIncidentService.OperationalPeriodChanged += Program_OperationalPeriodChanged;
            Program.wfIncidentService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
            Program.wfIncidentService.OperationalGroupChanged += Program_OperationalGroupChanged;
            Program.wfIncidentService.MemberSignInChanged += Program_CheckInChanged;
            //Program.wfIncidentService.TeamAssignmentChanged += Program_TeamAssignmentChanged;


            //network stuff
            Program.networkService.localNetworkIncidentRequestEvent += answerRequestForNetworkSARTask;
            Program.networkService.localNetworkClosedEvent += Program_LocalConnectionClosed;
            Program.networkService.localNetworkIncomingIncidentEvent += replaceCurrentIncidentWithNetworkIncident;
            Program.networkService.localNetworkIncomingObjectEvent += Program_HandleIncomingNetworkObject;
            Program.wfIncidentService.TaskUpdateChanged += Program_TaskUpdateChanged;
            Program.wfIncidentService.OpPeriodChanged += changeOpPeriod;
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
            if (CurrentIncident.ActiveAssignments.Any(o => o.OpPeriod == Program.CurrentOpPeriod)) { btnAssignmentList.Image = Properties.Resources.glyphicons_basic_739_check; teamMembersToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnAssignmentList.Image = null; teamMembersToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeangfulCommsPlan(CurrentOpPeriod)) { btnCommsPlan.Image = Properties.Resources.glyphicons_basic_739_check; communicationsPlanICS205ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnCommsPlan.Image = null; communicationsPlanICS205ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulOrgChart(CurrentOpPeriod)) { btnPrintOrgChart.Image = Properties.Resources.glyphicons_basic_739_check; organizationChartICS207ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnPrintOrgChart.Image = null; organizationChartICS207ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulMedicalPlan(CurrentOpPeriod)) { btnMedicalPlan.Image = Properties.Resources.glyphicons_basic_739_check; medicalPlanICS206ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnMedicalPlan.Image = null; medicalPlanICS206ToolStripMenuItem.Image = null; }


            if (CurrentIncident.hasMeaningfulObjectives(CurrentOpPeriod)) { btnIncidentObjectives.Image = Properties.Resources.glyphicons_basic_739_check; incidentObjectivesICS202ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnIncidentObjectives.Image = null; incidentObjectivesICS202ToolStripMenuItem.Image = null; }

            if (CurrentIncident.hasMeaningfulTeamAssignments(CurrentOpPeriod)) { btnAssignmentList.Image = Properties.Resources.glyphicons_basic_739_check; teamAssignmentsICS204ToolStripMenuItem.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnAssignmentList.Image = null; teamAssignmentsICS204ToolStripMenuItem.Image = null; }

            
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
            //collapsiblePanels.Add(cpPlanning);
            collapsiblePanels.Add(cpOtherTools);
            //collapsiblePanels.Add(cpLogistics);
        }

        private void collapseAllPanels()
        {
            foreach (CollapsiblePanel panel in collapsiblePanels) { panel.Collapse(); }
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
                savedTeamMembersForm = new SavedPersonnelForm();
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
            if (checkForSave)
            {
                DialogResult dr = MessageBox.Show("Would you like to save the current incident before creating a new one?", "Save current incdient?", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveFile();
                    CreateNewIncident();
                }
                else if (dr == DialogResult.No)
                {
                    CreateNewIncident();
                }

            }
            else
            {
                CreateNewIncident();
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkForSave)
            {
                DialogResult dr = MessageBox.Show("Would you like to save the current incident before opening another?", "Save current incdient?", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveFile();
                    openTask();
                }
                else if (dr == DialogResult.No)
                {
                    openTask();
                }

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
            cboICSRole.DataSource = CurrentOrgChart.ActiveRoles;
            cboICSRole.DisplayMember = "RoleNameForDropdown";
            cboICSRole.ValueMember = "RoleID";
            if (role != null && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == role.RoleID)) { cboICSRole.SelectedValue = role.RoleID; }

        }

        private void displayIncidentDetails()
        {
            //cboICSRole.Items.Clear();
            CurrentIncident.createOrgChartAsNeeded(CurrentOpPeriod);
            buildICSRoleDropdown();

            /*
            if (!string.IsNullOrEmpty(CurrentIncident.ICPCallSign)) { txtICPCallsign.Text = CurrentIncident.ICPCallSign; }
            else { txtICPCallsign.Text = "BASE"; CurrentIncident.ICPCallSign = txtICPCallsign.Text; }*/
            txtTaskName.Text = CurrentIncident.TaskName;
            txtTaskNumber.Text = CurrentIncident.TaskNumber;
            if (CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == Program.CurrentRole.RoleID))
            {
                cboICSRole.SelectedValue = Program.CurrentRole.RoleID; DisplayCurrentICSRole();
            }
            else { cboICSRole.SelectedIndex = 0; }

            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { this.Text = Globals.ProgramName + " - " + CurrentIncident.FileName; }
            else { this.Text = Globals.ProgramName; }

            if (!CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber == CurrentOpPeriod).Any()) { CurrentIncident.AllOperationalPeriods = CurrentIncident.InferOperationalPeriods(); }

            int highestOpNum = 1; if (CurrentIncident.AllOperationalPeriodsWithContent.Any()) { highestOpNum = CurrentIncident.AllOperationalPeriodsWithContent.OrderByDescending(o => o.PeriodNumber).First().PeriodNumber; }
            numOpPeriod.Value = highestOpNum;
            datOpsStart.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == highestOpNum).PeriodStart;
            datOpsEnd.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == highestOpNum).PeriodEnd;


            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { tmrAutoSave.Enabled = Program.generalOptionsService.GetOptionsBoolValue("AutoSave"); }
            setButtonCheckboxes();
            browseToIncidentFolderToolStripMenuItem.Enabled = true;

            //List<Personnel> savedMembers = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            //Program.CurrentIncident.IncidentPersonnel = Program.CurrentIncident.getTaskTeamMembers(savedMembers, false, false, Program.CurrentOpPeriod);
        }

        private void DisplayCurrentICSRole()
        {
            if (Program.CurrentRole != null)
            {
                List<Guid> ChiefIDs = new List<Guid>();
                ChiefIDs.Add(Globals.OpsChiefID); ChiefIDs.Add(Globals.PlanningChiefID); ChiefIDs.Add(Globals.LogisticsChiefID); ChiefIDs.Add(Globals.FinanceChiefID); ChiefIDs.Add(Globals.DeputyIncidentCommanderID);
                List<Guid> ICRoles = new List<Guid>();
                ICRoles.Add(Globals.IncidentCommanderID); ICRoles.Add(Globals.DeputyIncidentCommanderID); ICRoles.Add(Globals.UnifiedCommand1ID); ICRoles.Add(Globals.UnifiedCommand2ID); ICRoles.Add(Globals.UnifiedCommand3ID);

                List<Guid> CommandStaffRoles = new List<Guid>();
                foreach (ICSRole role in CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == Globals.IncidentCommanderID && !ChiefIDs.Contains(o.RoleID)))
                {
                    CommandStaffRoles.Add(role.RoleID);
                }

                foreach (CollapsiblePanel panel in collapsiblePanels) { panel.BackColor = Color.White; }
                //resizeGroup("Assignments", false, true);
                if (ICRoles.Contains(Program.CurrentRole.RoleID))
                {
                    pnlTaskInfo.BackColor = Color.LimeGreen;
                    //    pnlCommandTeam.BackColor = Color.LimeGreen;
                }
                else if (CommandStaffRoles.Contains(Program.CurrentRole.RoleID))
                {
                    pnlTaskInfo.BackColor = Color.IndianRed;
                }
                else if (Program.CurrentRole.SectionID == Globals.OpsChiefID)
                {
                    pnlTaskInfo.BackColor = Color.Orange;
                    //resizeGroup("Ops", false, true);
                }
                else if (Program.CurrentRole.SectionID == Globals.PlanningChiefID)
                {
                    pnlTaskInfo.BackColor = Color.CornflowerBlue;
                    /*
                                        pnlIAP.BackColor = Color.CornflowerBlue;
                                        pnlCommandTeam.BackColor = Color.CornflowerBlue;
                                        pnlPlanning.BackColor = Color.CornflowerBlue;
                                        tcStatus.SelectedIndex = 1;
                                        resizeGroup("Planning", false, true);*/

                }
                else if (Program.CurrentRole.SectionID == Globals.LogisticsChiefID)
                {
                    pnlTaskInfo.BackColor = Color.Khaki;
                    /*
                    pnlCommsPlan.BackColor = Color.Khaki;
                    pnlIAP.BackColor = Color.Khaki;
                    pnlLogistics.BackColor = Color.Khaki;
                    tcStatus.SelectedIndex = 3;
                    resizeGroup("Logistics", false, true);
                    */
                }
                else if (Program.CurrentRole.SectionID == Globals.FinanceChiefID)
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
                if (Program.generalOptionsService.GetOptionsBoolValue("AutoSave") && lastSaveSuccessful)
                {
                    if (initialDetailsSet(false, false))
                    {
                        if (!string.IsNullOrEmpty(CurrentIncident.FileName))
                        {
                            saveFile(false, false);
                        }
                        else { checkForSave = true; }
                    }
                    else { checkForSave = true; }
                }
                else { checkForSave = true; }
            }
            else { checkForSave = true; }

        }

        private void Program_OperationalGroupChanged(OperationalGroupEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();

        }
        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
            TriggerAutoSave();

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

        private void Program_CheckInChanged(CheckInEventArgs e)
        {
            TriggerAutoSave();

        }

        private void Program_OperationalPeriodChanged(OperationalPeriodEventArgs e)
        {
            if (e.item.PeriodNumber == Program.CurrentOpPeriod)
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
            //txtICPCallsign.Text = e.item.ICPCallSign;


            TriggerAutoSave();
        }

        private void Program_CommsPlanChanged(CommsPlanEventArgs e)
        {
            if (e.item.OpsPeriod == Program.CurrentOpPeriod) { setButtonCheckboxes(); }
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
            CheckForPositionLogReminders();

            TriggerAutoSave();
        }


        private bool initialDetailsSet(bool checkOpPeriod = true, bool promptOnerror = true)
        {
            bool set = false;
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(txtTaskName.Text.Trim()) || !string.IsNullOrEmpty(txtTaskNumber.Text.Trim())) { set = true; txtTaskName.BackColor = Program.GoodColor; txtTaskNumber.BackColor = Program.GoodColor; }
            else { set = false; errors.Add("You must set either an incident name or number to begin."); txtTaskName.BackColor = Program.ErrorColor; txtTaskNumber.BackColor = Program.ErrorColor; }

        

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
           
            CloseActiveForms();

            browseToIncidentFolderToolStripMenuItem.Enabled = false;
            CurrentIncident = new WFIncident();
            txtTaskName.Text = string.Empty;
            txtTaskNumber.Text = string.Empty;

            OperationalPeriod period = CurrentIncident.GenerateFirstOpPeriod();
            if (period != null) { Program.wfIncidentService.UpsertOperationalPeriod(period); }

            CurrentIncident.createOrgChartAsNeeded(period.PeriodNumber);


            if (Program.generalOptionsService.GetGuidOptionValue("OrganizationID") != Guid.Empty) { CurrentIncident.OrganizationID = Program.generalOptionsService.GetGuidOptionValue("OrganizationID"); }
          //  CurrentIncident.ICPCallSign = txtICPCallsign.Text;

            CurrentIncident.DocumentPath = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation");
            checkForSave = false;
            //setSavedFlag(false);
            LastAutoBackup = DateTime.Now;
            displayIncidentDetails();

            //AddDefaultEquipment(CurrentOpPeriod);


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
                    folder = Path.Combine(folder, "CIAPP");
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
                        Program.networkService.CurrentIncidentID = Program.CurrentIncident.TaskID;
                        displayIncidentDetails();
                        tmrAutoSave.Enabled = true;
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

               /* if (!string.IsNullOrEmpty(txtICPCallsign.Text)) { CurrentIncident.ICPCallSign = txtICPCallsign.Text; }
                else { CurrentIncident.ICPCallSign = "BASE"; }*/
                string fileName = CurrentIncident.FileName;
                bool proceed = true;
                if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName) || forceBrowseForFile)
                {
                    string path = "";
                    if (!string.IsNullOrEmpty(Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation"))) { path = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation"); }
                    else
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        path = Path.Combine(path, "CIAPP");

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

                        tmrAutoSave.Enabled = true;
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
            if (checkForSave)
            {
                DialogResult dr = MessageBox.Show("Would you like to save the current incident before opening another?", "Save current incdient?", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveFile();
                    string tag = ((ToolStripMenuItem)sender).Tag.ToString();
                    openTask(tag);
                }
                else if (dr == DialogResult.No)
                {
                    string tag = ((ToolStripMenuItem)sender).Tag.ToString();
                    openTask(tag);
                }

            }
            else
            {
                string tag = ((ToolStripMenuItem)sender).Tag.ToString();
                openTask(tag);
            }

        }

        private void txtTaskName_Leave(object sender, EventArgs e)
        {
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
            if (initialDetailsSet(false, false) && !askedForInitialSave && !ThisMachineIsClient && Program.generalOptionsService.GetOptionsBoolValue("PromptForInitialSave"))
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
                if (null == _communicationsListForm)
                {
                    _communicationsListForm = new CommunicationsListForm();
                    _communicationsListForm.FormClosed += CommunicationsListForm_Closed;
                    _communicationsListForm.Show(this);
                    ActiveForms.Add(_communicationsListForm);
                }

                _communicationsListForm.BringToFront();
            }



        }
        void CommunicationsListForm_Closed(object sender, FormClosedEventArgs e)
        {

            RemoveActiveForm(_communicationsListForm);
            _communicationsListForm = null;

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
                if (null == _orgChartForm)
                {
                    _orgChartForm = new OrganizationalChartForm();
                    _orgChartForm.FormClosed += OrganizationChartForm_Closed;
                    _orgChartForm.Show(this);
                    ActiveForms.Add(_orgChartForm);
                }

                _orgChartForm.BringToFront();
            }



        }
        void OrganizationChartForm_Closed(object sender, FormClosedEventArgs e)
        {

            RemoveActiveForm(_orgChartForm);
            _orgChartForm = null;

        }

        private void btnPrintOrgChart_Click(object sender, EventArgs e)
        {
            openOrganizationChart();

        }


        private void openCommsPlan()
        {
            if (initialDetailsSet())
            {
                if (null == _commsPlanForm)
                {
                    _commsPlanForm = new CommunicationsPlanForm();
                    _commsPlanForm.FormClosed += CommunicationsPlanForm_Closed;
                    _commsPlanForm.Show(this);
                    ActiveForms.Add(_commsPlanForm);
                }

                _commsPlanForm.BringToFront();
            }



        }
        void CommunicationsPlanForm_Closed(object sender, FormClosedEventArgs e)
        {

            RemoveActiveForm(_commsPlanForm);
            _commsPlanForm = null;

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
                if(result == DialogResult.OK)
                {
                    tmrAutoSave.Enabled = true;
                }
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
                if (_objectivesForm == null)
                {
                    _objectivesForm = new IncidentObjectivesForm();
                    _objectivesForm.FormClosed += new FormClosedEventHandler(IncidentObjectivesForm_Closed);
                    ActiveForms.Add(_objectivesForm);
                    _objectivesForm.Show(this);
                }

                _objectivesForm.BringToFront();
            }
        }
        void IncidentObjectivesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_objectivesForm);
            _objectivesForm = null;


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
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }
        private void Program_AidStationChanged(MedicalAidStationEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }
        private void Program_MedivacChanged(AmbulanceServiceEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }
        private void Program_HospitalChanged(HospitalEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                setButtonCheckboxes();
            }
            TriggerAutoSave();
        }

        private void Program_TeamAssignmentChanged(TeamAssignmentEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
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
                if (_generalMessagesForm == null)
                {
                    _generalMessagesForm = new GeneralMessagesForm();
                    _generalMessagesForm.FormClosed += new FormClosedEventHandler(GeneralMessagesForm_Closed);
                    ActiveForms.Add(_generalMessagesForm);
                    _generalMessagesForm.Show(this);
                }

                _generalMessagesForm.BringToFront();
            }
        }
        void GeneralMessagesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_generalMessagesForm);
            _generalMessagesForm = null;


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
                if (_medicalPlanForm == null)
                {
                    _medicalPlanForm = new MedicalPlanForm();
                    _medicalPlanForm.FormClosed += new FormClosedEventHandler(MedicalPlanForm_Closed);
                    ActiveForms.Add(_medicalPlanForm);
                    _medicalPlanForm.Show(this);
                }

                _medicalPlanForm.BringToFront();
            }
        }
        void MedicalPlanForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_medicalPlanForm);
            _medicalPlanForm = null;


        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNotesForm();
        }

        private void OpenNotesForm()
        {
            if (initialDetailsSet())
            {
                if (_notesForm == null)
                {
                    _notesForm = new NotesForm();
                    _notesForm.FormClosed += new FormClosedEventHandler(NotesForm_Closed);
                    ActiveForms.Add(_notesForm);
                    _notesForm.Show(this);
                }

                _notesForm.BringToFront();
            }
        }
        void NotesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_notesForm);
            _notesForm = null;


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
                if (_safetyMessagesForm == null)
                {
                    _safetyMessagesForm = new SafetyMessagesForm();
                    _safetyMessagesForm.FormClosed += new FormClosedEventHandler(SafetyMessagesForm_Closed);
                    ActiveForms.Add(_safetyMessagesForm);
                    _safetyMessagesForm.Show(this);
                }

                _safetyMessagesForm.BringToFront();
            }
        }
        void SafetyMessagesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_safetyMessagesForm);
            _safetyMessagesForm = null;


        }


        private void btnPrintIAP_Click(object sender, EventArgs e)
        {
            OpenPrintIAPForm(false, true);
        }

        private void OpenPrintIAPForm(bool PrintCompleteIncident = false, bool DefaultJustIAP = false)
        {
            if (initialDetailsSet())
            {
                if (_printIAPForm == null)
                {
                    _printIAPForm = new PrintIncidentForm();
                    _printIAPForm.PrintIAPByDefault = DefaultJustIAP;
                    _printIAPForm.PrintIncidentToDate = PrintCompleteIncident;
                    _printIAPForm.FormClosed += new FormClosedEventHandler(PrintIAPForm_Closed);
                    ActiveForms.Add(_printIAPForm);
                    _printIAPForm.Show(this);
                }

                _printIAPForm.BringToFront();
            }
        }
        void PrintIAPForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_printIAPForm);
            _printIAPForm = null;


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
                if (_airOperationsForm == null)
                {
                    _airOperationsForm = new AirOperationsForm();
                    _airOperationsForm.FormClosed += new FormClosedEventHandler(AirOpsSummaryForm_Closed);
                    ActiveForms.Add(_airOperationsForm);
                    _airOperationsForm.Show(this);
                }

                _airOperationsForm.BringToFront();
            }
        }
        void AirOpsSummaryForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_airOperationsForm);
            _airOperationsForm = null;


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

        private void btnAssignmentList_Click(object sender, EventArgs e)
        {
            OpenOperationalGroupsForm();
        }

        private void OpenOperationalGroupsForm()
        {
            if (initialDetailsSet())
            {
                if (_operationalGroupsForm == null)
                {
                    _operationalGroupsForm = new OperationalGroupsForm();
                    _operationalGroupsForm.FormClosed += new FormClosedEventHandler(OperationalGroupsForm_Closed);
                    ActiveForms.Add(_operationalGroupsForm);
                    _operationalGroupsForm.Show(this);
                }

                _operationalGroupsForm.BringToFront();
            }
        }
        void OperationalGroupsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_operationalGroupsForm);
            _operationalGroupsForm = null;


        }

        private void btnOpsAssignments_Click(object sender, EventArgs e)
        {
            OpenOperationalGroupsForm();
        }

        private void btnTeamAssignments_Click(object sender, EventArgs e)
        {
            OpenOperationalGroupsForm();
        }

        private void teamAssignmentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }


      
        private void tmrAutoSave_Tick(object sender, EventArgs e)
        {
            CheckForAutoBackup();
        }

        private void tmrPositionLogReminders_Tick(object sender, EventArgs e)
        {
            List<PositionLogEntry> Reminders = Program.CurrentTask.allPositionLogEntries.Where(o => o != null && o.Role.RoleID == Program.CurrentRole.RoleID && o.OpPeriod == CurrentOpPeriod && !o.IsInfoOnly && !o.IsComplete && o.ReminderTime > DateTime.MinValue && o.ReminderTime < DateTime.MaxValue).ToList();
            if (Reminders.Any())
            {
                DateTime now = DateTime.Now;
                Reminders = Reminders.Where(o => o.ReminderTime < now).ToList();
                if (Reminders.Any())
                {
                    ShowPositionLogReminder(Reminders[0]);
                    tmrPositionLogReminders.Enabled = false;
                }
            }

        }



        private void ShowPositionLogReminder(PositionLogEntry entry)
        {

            if (_positionLogReminderForm == null)
            {
                _positionLogReminderForm = new PositionLogReminderForm();
                _positionLogReminderForm.Entry = entry;
                _positionLogReminderForm.FormClosed += new FormClosedEventHandler(PositionLogReminderForm_Closed);
                ActiveForms.Add(_positionLogReminderForm);
                _positionLogReminderForm.ShowDialog(this);
            }

            // _positionLogReminderForm.BringToFront();

        }

        void PositionLogReminderForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_positionLogReminderForm);
            _positionLogReminderForm = null;
            CheckForPositionLogReminders();


        }

        private void CheckForAutoBackup(bool forceBackup = false)
        {
            if (Program.generalOptionsService.GetOptionsBoolValue("AutoBackup") && !string.IsNullOrEmpty(CurrentIncident.FileName))
            {
                TimeSpan ts = DateTime.Now - LastAutoBackup;
                int AutomaticBackupIntervalMinutes = 120;
                if (Program.generalOptionsService.GetOptionsValue("AutoBackupInterval") != null)
                {
                    AutomaticBackupIntervalMinutes = (int)Program.generalOptionsService.GetOptionsValue("AutoBackupInterval");
                }

                if (ts.TotalMinutes > AutomaticBackupIntervalMinutes || (forceBackup && ts.TotalMinutes > 1))
                {

                    if (PerformAutoBackup()) { LastAutoBackup = DateTime.Now; }
                }
            } else
            {
                tmrAutoSave.Enabled = false;
            }
        }

        private bool PerformAutoBackup()
        {
            string path = "";
            string defaultBackupLocation = Program.generalOptionsService.GetStringOptionValue("DefaultBackupLocation");
            string defaultSaveLocation = Program.generalOptionsService.GetStringOptionValue("DefaultSaveLocation");

            if (!string.IsNullOrEmpty(defaultBackupLocation)) { path = defaultBackupLocation; }
            else if (!string.IsNullOrEmpty(defaultSaveLocation)) { path = defaultSaveLocation; }
            else
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path, "CIAPP");



            }
            path = Path.Combine(path, "Incident " + CurrentIncident.IncidentIdentifier);

            System.IO.Directory.CreateDirectory(path);


            string fn = DateTime.Now.ToString("yyyy-MMM-dd HH-mm") + " - BACKUP Incident " + CurrentIncident.IncidentNameOrNumber + ".xml";
            path = Path.Combine(path, fn);

            if (!string.IsNullOrEmpty(path))
            {
                try
                {

                    System.Xml.XmlWriterSettings ws = new System.Xml.XmlWriterSettings();
                    ws.NewLineHandling = System.Xml.NewLineHandling.Entitize;


                    XmlSerializer ser = new XmlSerializer(typeof(WFIncident));
                    using (System.Xml.XmlWriter wr = System.Xml.XmlWriter.Create(path, ws))
                    {
                        ser.Serialize(wr, CurrentIncident);
                    }
                    return true;
                    //System.IO.FileStream file = System.IO.File.Create(path);

                    //writer.Serialize(file, CurrentTask);
                    //file.Close();



                }
                catch (IOException)
                {
                    lastSaveSuccessful = false;
                    return false;
                }
                catch (System.UnauthorizedAccessException)
                {
                    lastSaveSuccessful = false;
                    return false;
                }
                catch (Exception ex)
                {
                    lastSaveSuccessful = false;
                    return false;

                }
               
            }

            return false;

        }


        private async void Program_TaskUpdateChanged(TaskUpdateEventArgs e)
        {
            Program.wfIncidentService.ProcessTaskUpdate(e.item);
            if (Program.InternetSyncEnabled && !e.item.UploadedSuccessfully)
            {

                e.item.UploadedSuccessfully = await Program.wfIncidentService.uploadTaskUpdateToServer(e.item);

            }
            if (Program.networkService.ThisMachineIsServer || Program.networkService.ThisMachineIsClient)
            {
                if (!e.item.Source.EqualsWithNull("Network"))
                {
                    Program.networkService.SendNetworkObject(e.item, CurrentIncident.TaskID);
                }

            }
        }



        private async void tmrInternetSync_Tick(object sender, EventArgs e)
        {
            if (PingTool.TestPing())
            {
                //tmrInternetSync.Enabled = false;
                var send = SendPendingInternetUpdates();
                var get = GetPendingInternetUpdates();

                await Task.WhenAll(send, get);
                //tmrInternetSync.Enabled = true;

                /*
                this.BeginInvoke((Action)delegate ()
                {
                    lblServerStatus.Text = "Last Internet Check " + DateTime.Now.ToString("HH:mm:ss");
                });
                */
            }
        }

        private async Task<bool> SendPendingInternetUpdates()
        {
            List<TaskUpdate> pendingUpdates = CurrentIncident.allTaskUpdates.Where(o => !o.UploadedSuccessfully).ToList();
            foreach (TaskUpdate update in pendingUpdates)
            {

                update.UploadedSuccessfully = await Program.wfIncidentService.uploadTaskUpdateToServer(update);

                addToNetworkLog(DateTime.Now.ToLongTimeString() + " - Uploaded a pending change to a(n) " + update.ObjectType + Environment.NewLine);


            }
            return true;
        }

        private async Task<bool> GetPendingInternetUpdates()
        {
            TaskUpdateService service = new TaskUpdateService();
            Task<List<TaskUpdate>> internetUpdates = service.DownloadTaskUpdateDetails(CurrentIncident.TaskID, Program.MachineID, DateTime.MinValue);
            List<TaskUpdate> updates = await internetUpdates;

            foreach (TaskUpdate update in updates)
            {
                update.UploadedSuccessfully = true;
                update.Source = "Internet";
                //Program.sarTaskService.ProcessTaskUpdate(update);
                Program.wfIncidentService.InsertIfUniqueTaskUpdate(update);

            }

            while (CurrentIncident.allTaskUpdates.Any(o => !o.ProcessedLocally))
            {

                TaskUpdate firstUnprocessed = CurrentIncident.allTaskUpdates.First(o => !o.ProcessedLocally);
                addToNetworkLog(DateTime.Now.ToLongTimeString() + " - Received a change to a(n) " + firstUnprocessed.ObjectType + Environment.NewLine);
                Program.wfIncidentService.ApplyTaskUpdate(firstUnprocessed, true);
                if (Program.networkService.ThisMachineIsClient || Program.networkService.ThisMachineIsServer)
                {
                    Program.networkService.SendNetworkObject(firstUnprocessed, CurrentIncident.TaskID, null, null, null, true);
                }
            }


            return true;

        }



        private void setServerStatusDisplay()
        {
            this.BeginInvoke((Action)delegate ()
            {
                StringBuilder serverStatusText = new StringBuilder();

                if (Program.InternetSyncEnabled)
                {
                    serverStatusText.Append("Internet sync enabled | ");
                    tmrInternetSync.Enabled = true;
                } else
                {
                    serverStatusText.Append("Internet sync NOT enabled | ");
                }

                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() && ThisMachineIsServer)
                {
                    serverStatusText.Append("This computer is acting as a local network server. IP: "); serverStatusText.Append(ServerIP); serverStatusText.Append(" Port "); serverStatusText.Append(ServerPort);
                    requestIncidentFromServerToolStripMenuItem.Enabled = false;
                    //downloadMembersFromServerToolStripMenuItem.Enabled = false;
                    requestOptionsFromServerToolStripMenuItem.Enabled = false;
                    networkTestToolStripMenuItem.Enabled = false;

                }
                else if (ThisMachineIsClient)
                {
                    serverStatusText.Append("Connected to "); serverStatusText.Append(ServerIP); serverStatusText.Append(" Port "); serverStatusText.Append(ServerPort);
                    requestIncidentFromServerToolStripMenuItem.Enabled = true;
                    ///downloadMembersFromServerToolStripMenuItem.Enabled = true;
                    requestOptionsFromServerToolStripMenuItem.Enabled = true;
                    networkTestToolStripMenuItem.Enabled = true;

                }
                else
                {
                    serverStatusText.Append("Not connected to another local computer");
                    requestIncidentFromServerToolStripMenuItem.Enabled = false;
                    networkTestToolStripMenuItem.Enabled = false;
                    requestOptionsFromServerToolStripMenuItem.Enabled = false;
                    // downloadMembersFromServerToolStripMenuItem.Enabled = false;

                }

                lblServerStatus.Text = serverStatusText.ToString();
            });
        }
        public void addToNetworkLog(string item)
        {
            this.BeginInvoke((Action)delegate ()
            {
                txtNetworkLog.AppendText(item);
            });
        }



        private void tmrNetwork_Tick(object sender, EventArgs e)
        {
            if (initialConnectionTest)
            {
                lblNetworkSyncStatus.Text = "FAILED - could not make a connection.  Please verify the IP and port and try again.";
                lblNetworkShareMoreInfoMsg.Text = "If it still isn't working, please investigate any firewalls that may be blocking the connection.";
                lblNetworkShareMoreInfoMsg.Visible = true;
                btnNetworkSyncDone.Visible = true;
                btnCloseNetworkSyncInProgress.Visible = !btnNetworkSyncDone.Visible;
                ThisMachineIsClient = false;
                ThisMachineIsServer = false;
                ThisMachineStandAlone = true;
                lostConnectionShowing = false;
                setServerStatusDisplay();
            }
        }


        public void sendTestConnection(string ip = null, string port = null)
        {
            this.BeginInvoke((Action)delegate ()
            {
                silentNetworkTest = false;
                pnlNetworkSyncInProgress.Visible = true;
                pnlNetworkSyncInProgress.BringToFront();
                btnNetworkSyncDone.Visible = false;
                btnCloseNetworkSyncInProgress.Visible = !btnNetworkSyncDone.Visible;



                /*
                pnlNetworkSyncInProgress.Location = new Point(0, 0);
                pnlNetworkSyncInProgress.Height = this.Height;
                pnlNetworkSyncInProgress.Width = this.Width;
                */


                pnlNetworkSyncInProgress.Dock = DockStyle.Fill;
                pnlNetworkSyncInProgress.BringToFront();
                lblNetworkSyncStatus.Text = "Beginning Network Status Check";
                lblNetworkShareMoreInfoMsg.Visible = false;
                pbNetworkSyncInProgress.Value = 1;
                NetworkTestGuidValue = Program.networkService.sendTestConnection(CurrentIncident.TaskID, ip, port);

                if (initialConnectionTest)
                {
                    tmrNetwork.Enabled = true;
                }
            });
        }




        private void replyToTestConnection(NetworkSendObject incomingMessage)
        {
            if (ThisMachineIsServer)
            {
                //MessageBox.Show("Test connection from " + incomingMessage.SourceIdentifier + " received, sending reply");
                Program.networkService.SendNetworkObject(incomingMessage.GuidValue, CurrentIncident.TaskID, "success");
            }
        }



        private void networkTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initialConnectionTest = false;
            silentNetworkTest = false;
            sendTestConnection();
        }

        private void btnCloseNetworkSyncInProgress_Click(object sender, EventArgs e)
        {
            pnlNetworkSyncInProgress.Visible = false;
            ThisMachineIsClient = false;
            ThisMachineIsServer = false;
            ThisMachineStandAlone = true;
            lostConnectionShowing = false;
            setServerStatusDisplay();
        }

        private void btnNetworkSyncDone_Click(object sender, EventArgs e)
        {
            pnlNetworkSyncInProgress.Visible = false;

        }

        private void Program_HandleIncomingNetworkObject(NetworkSendObject incomingMessage)
        {
            this.BeginInvoke((Action)delegate ()
            {
                string taskUpdateName = new TaskUpdate().GetType().ToString();
                if (incomingMessage.objectType == taskUpdateName)
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        Program.wfIncidentService.ProcessTaskUpdate(incomingMessage.taskUpdate);
                    });
                }

                else if (incomingMessage.objectType == new GeneralOptions().GetType().ToString())
                {
                    replaceOptionsFromNetwork(incomingMessage.generalOptions);
                }
                else if (incomingMessage.objectType == Guid.Empty.GetType().ToString())
                {
                    if (incomingMessage.comment == "test" && ThisMachineIsServer)
                    {
                        replyToTestConnection(incomingMessage);
                    }
                    else if (incomingMessage.comment == "success" && NetworkTestGuidValue != Guid.Empty)
                    {
                        receiveTestConnectionResult(incomingMessage);
                    }
                }
            });
        }

        private void replaceOptionsFromNetwork(GeneralOptions options)
        {
            this.BeginInvoke((Action)delegate ()
            {
                if (networkOptionsRequested)
                {
                    networkOptionsRequested = false;
                    GeneralOptions currentOptions = Program.generalOptionsService.GetGeneralOptions();
                    string baseFileName = "myCIAPP_Options" + DateTime.Now.ToString("yyyy-MMM-dd-HH-mm");
                    int i = 0;
                    string backupFileName = baseFileName + ".xml";
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPP");
                    while (File.Exists(Path.Combine(path, backupFileName)))
                    {
                        i += 1;
                        backupFileName = baseFileName + " (" + i + ").xml";
                    }

                    Program.generalOptionsService.SaveGeneralOptions(currentOptions, backupFileName);
                    //maintain some of the options from the current system.
                    options.DefaultToServer = false;
                    options.LastServerIP = currentOptions.LastServerIP;
                    options.RecentFilePaths = currentOptions.RecentFilePaths;
                    options.DefaultSaveLocation = currentOptions.DefaultSaveLocation;
                    options.DefaultICSRole = currentOptions.DefaultICSRole;

                    Program.generalOptionsService.SaveGeneralOptions(options);
                    MessageBox.Show("Your options have been replaced with the options from the server.  A backup copy of your previous options has been saved as " + backupFileName);

                }
            });
        }

        private void receiveTestConnectionResult(NetworkSendObject incomingMessage)
        {
            this.BeginInvoke((Action)delegate ()
            {


                if (incomingMessage.GuidValue == NetworkTestGuidValue && NetworkTestGuidValue != Guid.Empty)
                {
                    if (initialConnectionTest)
                    {
                        tmrNetwork.Enabled = false;
                    }

                    lblNetworkSyncStatus.Text = "Network Satus Check Successful, Requesting Task";
                    lblNetworkShareMoreInfoMsg.Text = "Someone on the main computer may need to press \"Yes\" to share the task. If this takes too long, go ask them.";
                    lblNetworkShareMoreInfoMsg.Visible = true;
                    pbNetworkSyncInProgress.Value = 2;

                    if (!silentNetworkTest && !initialConnectionTest) { MessageBox.Show("Connected successfully to host"); }
                    else if (initialConnectionTest)
                    {
                        //if (MessageBox.Show("Connected successfully!\r\n\r\nWould you like to download the current task from the server? This will replace whatever you have open now.", "Download server task?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        // {
                        networkTaskRequested = true;
                        NetworkSARTaskRequest request = new NetworkSARTaskRequest();
                        request.RequestDate = DateTime.Now;
                        request.SourceName = HostInfo.HostName;
                        request.SourceIdentifier = NetworkComms.NetworkIdentifier;
                        request.RequestIP = Program.networkService.GetLocalIPAddress();
                        Program.networkService.SendNetworkSarTaskRequest(request);

                        //  }
                        /*
                          else
                          {
                              MessageBox.Show("You can request the current server task from the Network menu later.");
                          }*/
                    }
                    silentNetworkTest = true;
                    NetworkTestGuidValue = Guid.Empty;
                    initialConnectionTest = false;
                }
            });
        }

        private void Program_LocalConnectionClosed(Connection connection)
        {
            if (ThisMachineIsClient && !formIsClosing)
            {
                DateTime today = DateTime.Now;
                tmrNetwork.Enabled = false;

                addToNetworkLog(string.Format(Globals.cultureInfo, "{0:HH:mm:ss}", today) + " - handling a closed connection" + "\r\n");
                if (!lostConnectionShowing && !initialConnectionTest)
                {
                    lostConnectionShowing = true;
                    DialogResult dr = MessageBox.Show("You have lost your connection to the server.  Would you like to try to reconnect?", "Connection Lost", MessageBoxButtons.YesNo);

                    if (dr == DialogResult.Yes)
                    {
                        RijndaelPSKEncrypter.AddPasswordToOptions(NetworkComms.DefaultSendReceiveOptions.Options, encryptionKey);
                        if (!NetworkComms.DefaultSendReceiveOptions.DataProcessors.Contains(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>()))
                        {
                            NetworkComms.DefaultSendReceiveOptions.DataProcessors.Add(DPSManager.GetDataProcessor<RijndaelPSKEncrypter>());
                        }
                        initialConnectionTest = false;
                        silentNetworkTest = false;
                        lostConnectionShowing = false;
                        sendTestConnection();
                    }
                    else
                    {
                        ThisMachineIsClient = false;
                        ThisMachineIsServer = false;
                        ThisMachineStandAlone = true;
                        lostConnectionShowing = false;
                        setServerStatusDisplay();
                    }
                }
            }
        }

        private void replaceCurrentIncidentWithNetworkIncident(WFIncident task)
        {
            if (networkTaskRequested)
            {
                this.BeginInvoke((Action)delegate ()
                {
                    PauseNetworkSend = true;

                    lblNetworkSyncStatus.Text = "Incoming Incident received, loading now";
                    lblNetworkShareMoreInfoMsg.Visible = false;

                    pbNetworkSyncInProgress.Value = 3;

                    if (CurrentIncident.TaskID != task.TaskID)
                    {
                        task.FileName = string.Empty;
                    }
                    else
                    {
                        task.FileName = CurrentIncident.FileName;
                    }
                    CloseActiveForms();
                    CurrentIncident = task;

                    displayIncidentDetails();
                    networkTaskRequested = false;
                    DateTime today = DateTime.Now;
                    addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - received full incident " + task.IncidentIdentifier + "\r\n");

                    if (pnlNetworkSyncInProgress.Visible)
                    {
                        pnlNetworkSyncInProgress.BringToFront();
                        lblNetworkSyncStatus.Text = "Incident loaded successfully from the network!";
                        pbNetworkSyncInProgress.Value = 4;

                        btnNetworkSyncDone.Visible = true;
                        btnCloseNetworkSyncInProgress.Visible = !btnNetworkSyncDone.Visible;
                    }
                    else { pnlNetworkSyncInProgress.BringToFront(); MessageBox.Show("Netowrk incident downloaded successfully!"); }
                    //pnlNetworkSyncInProgress.Visible = false;
                    PauseNetworkSend = false;
                    //MessageBox.Show("Task loaded from server");
                });

            }
        }



        private void answerRequestForNetworkSARTask(NetworkSARTaskRequest incomingMessage)
        {
            if (ThisMachineIsServer)
            {
                this.BeginInvoke((Action)delegate ()
                {
                    //MessageBox.Show("Your request has been sent to the server computer.  A user there will need to confirm it.  In the interim, please do not attempt any work - it will be overwritten.");


                    DateTime today = DateTime.Now;
                    addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - received a request for the current incident" + "\r\n");
                    DeviceInformation requester = new DeviceInformation();
                    requester.DeviceIP = incomingMessage.RequestIP;
                    requester.DeviceName = incomingMessage.SourceName;
                    List<DeviceInformation> savedNetworkDevices = (List<DeviceInformation>)Program.generalOptionsService.GetOptionsValue("SavedNetworkDeviceList");

                    //if the device appears in the list of trusted devices, send automatically
                    if (!string.IsNullOrEmpty(requester.DeviceIP) && !string.IsNullOrEmpty(requester.DeviceName) && savedNetworkDevices.Where(o => o.DeviceName.Equals(requester.DeviceName, StringComparison.InvariantCulture) && o.DeviceIP.Equals(requester.DeviceIP, StringComparison.InvariantCulture) && o.TrustDevice).Any())
                    {

                        Program.networkService.SendTaskData(CurrentIncident);
                        today = DateTime.Now;
                        addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - sent current incident to trusted device " + requester.DeviceIP + "\r\n");
                    }
                    else
                    {
                        //otherwise prompt the user


                        using (AuthorizeNetworkIncidentRequestForm handleRequest = new AuthorizeNetworkIncidentRequestForm())
                        {
                            //handleRequest.parent = this;
                            handleRequest.Owner = this;
                            handleRequest.StartPosition = FormStartPosition.CenterParent;
                            handleRequest.incomingMessage = incomingMessage;

                            //MessageBox.Show("Your request has been sent to the server computer.  A user there will need to confirm it.  In the interim, please do not attempt any work - it will be overwritten.");

                            handleRequest.Activate();

                            DialogResult result = handleRequest.ShowDialog();

                            if (result == DialogResult.Yes)
                            {
                                if (handleRequest.TrustDevice)
                                {

                                    if (savedNetworkDevices.Any(o => o.DeviceName.Equals(requester.DeviceName, StringComparison.InvariantCulture) && o.DeviceIP.Equals(requester.DeviceIP, StringComparison.InvariantCulture) && !o.TrustDevice))
                                    {
                                        DeviceInformation info = savedNetworkDevices.First(o => o.DeviceName.Equals(requester.DeviceName, StringComparison.InvariantCulture) && o.DeviceIP.Equals(requester.DeviceIP, StringComparison.InvariantCulture) && !o.TrustDevice);
                                        info.TrustDevice = true;
                                        Program.generalOptionsService.UpserOptionValue(info, "NetworkDevice");

                                    }
                                    else
                                    {
                                        requester.TrustDevice = true;
                                        Program.generalOptionsService.UpserOptionValue(requester, "NetworkDevice");

                                    }
                                }

                                Program.networkService.SendTaskData(CurrentIncident);
                                today = DateTime.Now;
                                addToNetworkLog(string.Format("{0:HH:mm:ss}", today) + " - sent current incident" + "\r\n");
                            }

                        }
                    }
                });
            }

        }

        private void localNetworkSharingSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NetworkSettingsForm settings = new NetworkSettingsForm())
            {
                if (settings.ShowDialog(this) == DialogResult.OK)
                {
                    if (ThisMachineIsClient)
                    {
                        initialConnectionTest = true;
                        silentNetworkTest = false;
                        sendTestConnection();
                    }

                    setServerStatusDisplay();
                }
            }
        }

        private void memberStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCheckedInResourcesForm();
        }

       


        private void OpenCheckedInResourcesForm()
        {
            if (initialDetailsSet())
            {
                if (_checkedInresourcesForm == null)
                {
                    _checkedInresourcesForm = new CheckedInResourcesForm();
                    _checkedInresourcesForm.FormClosed += new FormClosedEventHandler(CheckedInResourcesForm_Closed);
                    ActiveForms.Add(_checkedInresourcesForm);
                    _checkedInresourcesForm.Show(this);
                }

                _checkedInresourcesForm.BringToFront();
            }
        }
        void CheckedInResourcesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_checkedInresourcesForm);
            _checkedInresourcesForm = null;


        }


        private void OpenCloseOpPeriodForm()
        {
            if (initialDetailsSet())
            {
                if (_closeOpPeriodForm == null)
                {
                    _closeOpPeriodForm = new CloseOpPeriodForm();
                    _closeOpPeriodForm.FormClosed += new FormClosedEventHandler(CloseOpPeriodForm_Closed);
                    ActiveForms.Add(_closeOpPeriodForm);
                    _closeOpPeriodForm.Show(this);
                }

                _closeOpPeriodForm.BringToFront();
            }
        }
        void CloseOpPeriodForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(_closeOpPeriodForm);
            _closeOpPeriodForm = null;


        }



        private void btnLogisticsMemberStatus_Click(object sender, EventArgs e)
        {
            //OpenPersonnelListForm();
            OpenCheckedInResourcesForm();
        }

        private void btnLogisticsSignIn_Click(object sender, EventArgs e)
        {
            if (initialDetailsSet())
            {
                while (StartCheckIn())
                {

                }
            }
        }

        private bool StartCheckIn()
        {
            bool autoStartNextCheckin = false;
            using (CheckInForm signInForm = new CheckInForm())
            {
                DialogResult dr = signInForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //get the resource and add it to the appropriate place
                    CheckInRecord record = signInForm.checkInRecord;
                    IncidentResource resource = signInForm.selectedResource;
                    switch (record.ResourceType)
                    {
                        case "Personnel":
                            Personnel p = resource as Personnel;
                            Program.wfIncidentService.UpsertPersonnel(p);
                            break;
                        case "Visitor":
                            Personnel vis = resource as Personnel;
                            Program.wfIncidentService.UpsertPersonnel(vis);
                            break;
                        case "Vehicle":
                            Vehicle v = resource as Vehicle;
                            Program.wfIncidentService.UpsertVehicle(v);
                            break;
                        case "Equipment":
                            Vehicle ve = resource as Vehicle;
                            Program.wfIncidentService.UpsertVehicle(ve);
                            break;
                        case "Crew":
                            OperationalSubGroup group = resource as OperationalSubGroup;
                            Program.wfIncidentService.UpsertOperationalSubGroup(group);
                            foreach(IncidentResource subres in signInForm.SubResources)
                            {
                                if(subres.GetType().Name.Equals("Personnel"))
                                {
                                    subres.OpPeriod = Program.CurrentOpPeriod;
                                    Program.wfIncidentService.UpsertPersonnel(subres as Personnel);
                                    CheckInRecord prec = signInForm.checkInRecord.Clone();
                                    prec.ResourceID = subres.ID;
                                    prec.SignInRecordID = Guid.NewGuid();
                                    prec.ParentRecordID = record.SignInRecordID;
                                    prec.ResourceType = "Personnel";
                                    Program.wfIncidentService.UpsertCheckInRecord(prec);
                                } else if (subres.GetType().Name.Equals("Vehicle"))
                                {
                                    Vehicle vh = subres as Vehicle;
                                    vh.OperatorName = group.ResourceName;
                                    Program.wfIncidentService.UpsertVehicle(vh);
                                    CheckInRecord vrec = signInForm.checkInRecord.Clone();
                                    vrec.ResourceID = subres.ID;
                                    vrec.SignInRecordID = Guid.NewGuid();
                                    vrec.ParentRecordID = record.SignInRecordID;
                                    if (vh.IsEquipment) { vrec.ResourceType = "Equipment"; }
                                    else { vrec.ResourceType = "Vehicle"; }
                                    Program.wfIncidentService.UpsertCheckInRecord(vrec);
                                }
                            }
                            break;
                    }

                    
                    Program.wfIncidentService.UpsertCheckInRecord(record);

                    autoStartNextCheckin = signInForm.AutoStartNextCheckin;
                }
            }
            return autoStartNextCheckin;
        }

     

        private void checkInMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (initialDetailsSet())
            {
                StartCheckIn();
            }
        }

        private void teamAssignmentsICS204ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenOperationalGroupsForm();
        }

        private void teamAssignmentsICS204ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenOperationalGroupsForm();
        }

        private void requestIncidentFromServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ThisMachineIsClient)
            {
                DialogResult result = MessageBox.Show(Properties.Resources.RequestIncidentFromServer, Properties.Resources.ProceedTitle, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    networkTaskRequested = true;
                    NetworkSARTaskRequest request = new NetworkSARTaskRequest();
                    request.RequestDate = DateTime.Now;
                    request.SourceName = HostInfo.HostName;
                    request.RequestIP = Program.networkService.GetLocalIPAddress();
                    request.SourceIdentifier = NetworkComms.NetworkIdentifier;
                    Program.networkService.SendNetworkSarTaskRequest(request);

                }

            }
            else { MessageBox.Show("This function only works when you have connected to a computer asking as the server. See Network Settings."); }
        }

        private void requestOptionsFromServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string warning = Properties.Resources.RequestOptionsFromServer;
            DialogResult dr = MessageBox.Show(warning, Properties.Resources.ProceedTitle, MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //send a request to the server for options
                networkOptionsRequested = true;
                NetworkOptionsRequest request = new NetworkOptionsRequest();
                request.RequestDate = DateTime.Now;
                request.SourceName = HostInfo.HostName;
                request.RequestIP = Program.networkService.GetLocalIPAddress();
                request.SourceIdentifier = NetworkComms.NetworkIdentifier;
                Program.networkService.SendNetworkOptionsRequest(request);

            }
        }

        private void numOpPeriod_ValueChanged(object sender, EventArgs e)
        {
            int newOpNumber = Convert.ToInt32(numOpPeriod.Value);
            if (newOpNumber != Program.CurrentOpPeriod)
            {
                IncidentOpPeriodChangedEventArgs args = new IncidentOpPeriodChangedEventArgs();
                args.NewOpPeriod = newOpNumber;


                if (!Program.CurrentIncident.AllOperationalPeriods.Any(o => o.PeriodNumber == newOpNumber))
                {
                    OperationalPeriod per = Program.CurrentIncident.createOpPeriodAsNeeded(newOpNumber);

                    Program.wfIncidentService.UpsertOperationalPeriod(per);

                    Program.CurrentIncident.createOrgChartAsNeeded(newOpNumber);
                    Program.CurrentIncident.createObjectivesSheetAsNeeded(newOpNumber);

                }
                Program.CurrentOpPeriod = newOpNumber;
                Program.wfIncidentService.OnOpPeriodChanged(args);

            }
        }


        private void colorOpsPeriodPanel()
        {
            DateTime today = DateTime.Now;
            DateTime OpsStart = Program.CurrentOpPeriodDetails.PeriodStart;
            DateTime OpsEnd = Program.CurrentOpPeriodDetails.PeriodEnd;

            if (today > OpsStart && today < OpsEnd)
            {
                pnlOpsPeriod.BackColor = Color.LightGoldenrodYellow;
            }
            else if (today > OpsEnd)
            {
                pnlOpsPeriod.BackColor = Color.LightGray;
            }
            else
            {
                pnlOpsPeriod.BackColor = Color.CornflowerBlue;
            }
        }

        private void changeOpPeriod(IncidentOpPeriodChangedEventArgs e)
        {

            datOpsStart.Value = Program.CurrentOpPeriodDetails.PeriodStart;
            datOpsEnd.Value = Program.CurrentOpPeriodDetails.PeriodEnd;
            colorOpsPeriodPanel();
            setButtonCheckboxes();

        }

        private void CloseAllOpenWindows()
        {
            foreach(Form f in ActiveForms)
            {
                f.Close();
            }
        }

        private void btnIncidentSummary_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet supported");
        }

        private void btnCloseOpPeriod_Click(object sender, EventArgs e)
        {
            
                OpenCloseOpPeriodForm();
            
        }

        private void btnPlanningAddAssignment_Click(object sender, EventArgs e)
        {

        }

        private void internetSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InternetSyncForm settings = new InternetSyncForm())
            {
                if (settings.ShowDialog(this) == DialogResult.OK)
                {
                    PauseNetworkSend = true;
                    if (settings.InternetSyncEnabled)
                    {
                        try
                        {
                            //pnlInternetSyncStart.Visible = true;
                            pnlInternetSyncStart.Dock = DockStyle.Fill;
                            pnlInternetSyncStart.BringToFront();
                            if (settings.CreateNewSync)
                            {
                                StartInternetSync(CurrentIncident.TaskID, CurrentIncident.TaskEncryptionKey, true);
                            }
                            else
                            {
                                Guid JoinTaskID = new Guid(settings.JoinTaskID);
                                StartInternetSync(JoinTaskID, settings.JoinEncryptionKey, false);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else { Program.InternetSyncEnabled = false; }
                    PauseNetworkSend = false;
                }
                pnlInternetSyncStart.Visible = false;
                setServerStatusDisplay();
            }
        }

        private void StartInternetSync(Guid TaskID, string EncryptionKey, bool IsNewSync)
        {
            //do stuff to sync the task
            PauseNetworkSend = true;
            if (IsNewSync)
            {
                Program.wfIncidentService.SendInitialTaskUpdate();
            }
            else
            {
                try
                {
                    TaskUpdateService service = new TaskUpdateService();
                    if (TaskID != CurrentIncident.TaskID)
                    {
                        Program.wfIncidentService.LoadNewTaskFromServer(TaskID, EncryptionKey);
                    }
                    else
                    {
                        Program.wfIncidentService.ConnectToServerTask(TaskID, EncryptionKey);
                    }
                }
                catch (Exception)
                {

                }

            }
            PauseNetworkSend = false;
            Program.InternetSyncEnabled = true;
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ciapp.icscanada.ca/Support");
        }

        private void btnShowResources_Click(object sender, EventArgs e)
        {
            OpenCheckedInResourcesForm();
        }
    }


}
