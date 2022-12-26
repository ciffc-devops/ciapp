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
            InitializeComponent();
            System.Windows.Forms.Application.EnableVisualStyles();
            LastAutoBackup = DateTime.Now;
            populateCollapsiblePanelList();

        }
        private void IncidentDetailsForm_Load(object sender, EventArgs e)
        {
            SetVersionNumber();
            collapseAllPanels();
        }

        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
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

        CommunicationsListForm communicationsList = null;


        /* Event Handlers!*/

        public event ShortcutEventHandler ShortcutButtonClicked;



        List<CollapsiblePanel> collapsiblePanels= new List<CollapsiblePanel>();


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

        private void displayIncidentDetails()
        {
            if (!string.IsNullOrEmpty(CurrentIncident.ICPCallSign)) { txtICPCallsign.Text = CurrentIncident.ICPCallSign; }
            else { txtICPCallsign.Text = "BASE"; CurrentIncident.ICPCallSign = txtICPCallsign.Text; }
            txtTaskName.Text = CurrentIncident.TaskName;
            txtTaskNumber.Text = CurrentIncident.TaskNumber;
            cboICSRole.SelectedValue = Program.CurrentRole.RoleID; DisplayCurrentICSRole();

            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { this.Text = Globals.ProgramName + " - " + CurrentIncident.FileName; }
            else { this.Text = Globals.ProgramName; }

            numOpPeriod.Value = CurrentIncident.highestOpsPeriod;
            if (!CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber == CurrentOpPeriod).Any()) { CurrentIncident.AllOperationalPeriods = CurrentIncident.InferOperationalPeriods(); }
            datOpsStart.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentIncident.highestOpsPeriod).PeriodStart;
            datOpsEnd.Value = CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentIncident.highestOpsPeriod).PeriodEnd;


            if (!string.IsNullOrEmpty(CurrentIncident.FileName)) { tmrAutoSave.Enabled = Program.generalOptionsService.GetOptionsBoolValue("AutoSave"); }

        }

        private void DisplayCurrentICSRole()
        {
            if (Program.CurrentRole != null)
            {
                ICSRole command = new ICSRole(); command.loadByName("SAR Manager");
                ICSRole ops = new ICSRole(); ops.loadByName("Operations Section Chief");
                ICSRole plans = new ICSRole(); plans.loadByName("Planning Section Chief");
                ICSRole logistics = new ICSRole(); logistics.loadByName("Logistics Section Chief");
                ICSRole admin = new ICSRole(); admin.loadByName("Admin/Finance Section Chief");


                List<Guid> CommandStaffRoles = new List<Guid>();
                CommandStaffRoles.Add(new Guid("CE7166AF-9432-4F7A-B942-1250AF0B7C31"));
                CommandStaffRoles.Add(new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"));
                CommandStaffRoles.Add(new Guid("91C6C1B6-92F2-4959-8A01-198240340571"));

                pnlTeamStatus.BackColor = Color.White;
                //pnlTeamAssignments.BackColor = Color.White;
                pnlPlanning.BackColor = Color.White;
                pnlLogistics.BackColor = Color.White;

                collapseAllPanels();
                //resizeGroup("Assignments", false, true);

                if (CommandStaffRoles.Contains(Program.CurrentRole.RoleID))
                {
                    pnlTaskInfo.BackColor = Color.IndianRed;
                    cpIncidentActionPlan.Expand();
                }
                else if (Program.CurrentRole.BranchID == command.RoleID)
                {
                    pnlTaskInfo.BackColor = Color.LimeGreen;
                //    pnlCommandTeam.BackColor = Color.LimeGreen;
                }
                else if (Program.CurrentRole.BranchID == ops.RoleID)
                {
                    pnlTaskInfo.BackColor = Color.Orange;
                    pnlTeamStatus.BackColor = Color.Orange;
                    //resizeGroup("Ops", false, true);
                }
                else if (Program.CurrentRole.BranchID == plans.RoleID)
                {
                    pnlTaskInfo.BackColor = Color.CornflowerBlue;
/*
                    pnlIAP.BackColor = Color.CornflowerBlue;
                    pnlCommandTeam.BackColor = Color.CornflowerBlue;
                    pnlPlanning.BackColor = Color.CornflowerBlue;
                    tcStatus.SelectedIndex = 1;
                    resizeGroup("Planning", false, true);*/

                }
                else if (Program.CurrentRole.BranchID == logistics.RoleID)
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
                else if (Program.CurrentRole.BranchID == admin.RoleID)
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

        private bool initialDetailsSet(bool checkOpPeriod = true, bool promptOnerror = true)
        {
            bool set = false;
            List<string> errors = new List<string>();
            if (!string.IsNullOrEmpty(txtTaskName.Text) || !string.IsNullOrEmpty(txtTaskNumber.Text)) { set = true; }
            else { set = false;  errors.Add("You must set either an incident name or number to begin."); }
            
            if (string.IsNullOrEmpty(txtTaskName.Text)) {  txtTaskName.BackColor = Color.LightCoral; }
            else { txtTaskName.BackColor = Color.LightSkyBlue; ; }

            if (string.IsNullOrEmpty(txtTaskNumber.Text)) {  txtTaskNumber.BackColor = Color.LightCoral; }
            else { txtTaskNumber.BackColor = Color.LightSkyBlue; ; }


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
            else if (checkOpPeriod && !incorrectOpAcknowledged &&CurrentIncident.allAssignments.Count > 0 && CurrentOpPeriod < CurrentTask.allAssignments.OrderByDescending(o => o.OpPeriod).First().OpPeriod)
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
                    path = Path.Combine(path, "Incident " + CurrentIncident.TaskNumber + " - " + CurrentIncident.TaskName);
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
                        svdTaskFile.FileName = "ICS Forms - Incident " + CurrentIncident.TaskNumber + " - " + CurrentIncident.TaskName + ".xml";
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
            initialDetailsSet(true, false);

        }

        private void txtTaskNumber_Leave(object sender, EventArgs e)
        {
            validateTaskNumber();
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
            if (string.IsNullOrEmpty(txtTaskNumber.Text)) { txtTaskNumber.BackColor = Color.LightCoral; }
            else if (!validateTaskNumber()) { txtTaskNumber.BackColor = Color.LightCoral; }
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
    }
}
