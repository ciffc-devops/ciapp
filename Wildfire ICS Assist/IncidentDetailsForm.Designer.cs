namespace Wildfire_ICS_Assist
{
    partial class IncidentDetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidentDetailsForm));
            this.imglTabIcons = new System.Windows.Forms.ImageList(this.components);
            this.svdTaskFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenTaskFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdSaveLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.tmrPositionLogReminders = new System.Windows.Forms.Timer(this.components);
            this.tmrInternetSync = new System.Windows.Forms.Timer(this.components);
            this.tmrNetwork = new System.Windows.Forms.Timer(this.components);
            this.tmrLock = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnMoveToOpNow = new System.Windows.Forms.Button();
            this.picOrgLogo = new System.Windows.Forms.PictureBox();
            this.pnlInternetSyncStart = new System.Windows.Forms.Panel();
            this.btnCancelInternetSync = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlNetworkSyncInProgress = new System.Windows.Forms.Panel();
            this.lblNetworkShareMoreInfoMsg = new System.Windows.Forms.Label();
            this.btnNetworkSyncDone = new System.Windows.Forms.Button();
            this.pbNetworkSyncInProgress = new System.Windows.Forms.ProgressBar();
            this.btnCloseNetworkSyncInProgress = new System.Windows.Forms.Button();
            this.lblNetworkSyncStatus = new System.Windows.Forms.Label();
            this.pnlOpsPeriod = new System.Windows.Forms.Panel();
            this.btnReviewOpPeriod = new System.Windows.Forms.Button();
            this.btnEditOpPeriod = new System.Windows.Forms.Button();
            this.btnNewOpPeriod = new System.Windows.Forms.Button();
            this.cboCurrentOperationalPeriod = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTaskInfo = new System.Windows.Forms.Panel();
            this.btnLockTaskInfo = new System.Windows.Forms.Button();
            this.txtTaskName = new SpellBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOutstandingLogItems = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnViewPositionLog = new System.Windows.Forms.Button();
            this.btnAddToPositionLog = new System.Windows.Forms.Button();
            this.txtTaskNumber = new System.Windows.Forms.TextBox();
            this.btnICSRoleHelp = new System.Windows.Forms.Button();
            this.cboICSRole = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblTaskNumber = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentIncidentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.browseToIncidentFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDeletedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.savedValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aircraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationsSystemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medivacServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentObjectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentActionPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentObjectivesICS202ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationChartICS207ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamAssignmentsICS204ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationsPlanICS205ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalPlanICS206ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyMessageICS208ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentStatusSummaryICS209ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airOperationsSummaryICS220ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.additionalDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationsListICS205AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalMessageICS213ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.printingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printThisOperationalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printThisIncidentToDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localNetworkSharingSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestIncidentFromServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.internetSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.requestOptionsFromServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCIAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cpOtherTools = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.btnGeneralMessage = new System.Windows.Forms.Button();
            this.btnReplacementResources = new System.Windows.Forms.Button();
            this.btnAdditionalContacts = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnShowResources = new System.Windows.Forms.Button();
            this.cpIncidentActionPlan = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.btnIncidentStatusSummary = new System.Windows.Forms.Button();
            this.btnAssignmentList = new System.Windows.Forms.Button();
            this.btnAirOpsSummary = new System.Windows.Forms.Button();
            this.btnSafetyPlans = new System.Windows.Forms.Button();
            this.btnIncidentObjectives = new System.Windows.Forms.Button();
            this.btnMedicalPlan = new System.Windows.Forms.Button();
            this.btnPrintIAP = new System.Windows.Forms.Button();
            this.btnPrintOrgChart = new System.Windows.Forms.Button();
            this.btnCommsPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOrgLogo)).BeginInit();
            this.pnlInternetSyncStart.SuspendLayout();
            this.pnlNetworkSyncInProgress.SuspendLayout();
            this.pnlOpsPeriod.SuspendLayout();
            this.pnlTaskInfo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.cpOtherTools.SuspendLayout();
            this.cpIncidentActionPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // imglTabIcons
            // 
            this.imglTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTabIcons.ImageStream")));
            this.imglTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imglTabIcons.Images.SetKeyName(0, "glyphicons-basic-532-user-family.png");
            this.imglTabIcons.Images.SetKeyName(1, "glyphicons-basic-849-computer-network.png");
            this.imglTabIcons.Images.SetKeyName(2, "glyphicons-basic-876-palette-package.png");
            // 
            // svdTaskFile
            // 
            resources.ApplyResources(this.svdTaskFile, "svdTaskFile");
            // 
            // ofdOpenTaskFile
            // 
            this.ofdOpenTaskFile.DefaultExt = "xml";
            resources.ApplyResources(this.ofdOpenTaskFile, "ofdOpenTaskFile");
            // 
            // fbdSaveLocation
            // 
            resources.ApplyResources(this.fbdSaveLocation, "fbdSaveLocation");
            // 
            // tmrAutoSave
            // 
            this.tmrAutoSave.Interval = 10000;
            this.tmrAutoSave.Tick += new System.EventHandler(this.tmrAutoSave_Tick);
            // 
            // tmrPositionLogReminders
            // 
            this.tmrPositionLogReminders.Interval = 60000;
            this.tmrPositionLogReminders.Tick += new System.EventHandler(this.tmrPositionLogReminders_Tick);
            // 
            // tmrInternetSync
            // 
            this.tmrInternetSync.Interval = 2000;
            this.tmrInternetSync.Tick += new System.EventHandler(this.tmrInternetSync_Tick);
            // 
            // tmrNetwork
            // 
            this.tmrNetwork.Interval = 10000;
            this.tmrNetwork.Tick += new System.EventHandler(this.tmrNetwork_Tick);
            // 
            // tmrLock
            // 
            this.tmrLock.Interval = 30000;
            this.tmrLock.Tick += new System.EventHandler(this.tmrLock_Tick);
            // 
            // btnMoveToOpNow
            // 
            resources.ApplyResources(this.btnMoveToOpNow, "btnMoveToOpNow");
            this.btnMoveToOpNow.Name = "btnMoveToOpNow";
            this.btnMoveToOpNow.TabStop = false;
            this.toolTip1.SetToolTip(this.btnMoveToOpNow, resources.GetString("btnMoveToOpNow.ToolTip"));
            this.btnMoveToOpNow.UseVisualStyleBackColor = true;
            this.btnMoveToOpNow.Click += new System.EventHandler(this.btnMoveToOpNow_Click);
            // 
            // picOrgLogo
            // 
            resources.ApplyResources(this.picOrgLogo, "picOrgLogo");
            this.picOrgLogo.Image = global::Wildfire_ICS_Assist.Properties.Resources.CIAPP_LOGO_v3_transparent;
            this.picOrgLogo.Name = "picOrgLogo";
            this.picOrgLogo.TabStop = false;
            this.toolTip1.SetToolTip(this.picOrgLogo, resources.GetString("picOrgLogo.ToolTip"));
            this.picOrgLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlInternetSyncStart
            // 
            resources.ApplyResources(this.pnlInternetSyncStart, "pnlInternetSyncStart");
            this.pnlInternetSyncStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlInternetSyncStart.Controls.Add(this.btnCancelInternetSync);
            this.pnlInternetSyncStart.Controls.Add(this.label22);
            this.pnlInternetSyncStart.Controls.Add(this.label21);
            this.pnlInternetSyncStart.Controls.Add(this.progressBar1);
            this.pnlInternetSyncStart.Name = "pnlInternetSyncStart";
            this.toolTip1.SetToolTip(this.pnlInternetSyncStart, resources.GetString("pnlInternetSyncStart.ToolTip"));
            // 
            // btnCancelInternetSync
            // 
            resources.ApplyResources(this.btnCancelInternetSync, "btnCancelInternetSync");
            this.btnCancelInternetSync.Name = "btnCancelInternetSync";
            this.toolTip1.SetToolTip(this.btnCancelInternetSync, resources.GetString("btnCancelInternetSync.ToolTip"));
            this.btnCancelInternetSync.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label22.Name = "label22";
            this.toolTip1.SetToolTip(this.label22, resources.GetString("label22.ToolTip"));
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Name = "label21";
            this.toolTip1.SetToolTip(this.label21, resources.GetString("label21.ToolTip"));
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolTip1.SetToolTip(this.progressBar1, resources.GetString("progressBar1.ToolTip"));
            // 
            // pnlNetworkSyncInProgress
            // 
            resources.ApplyResources(this.pnlNetworkSyncInProgress, "pnlNetworkSyncInProgress");
            this.pnlNetworkSyncInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkShareMoreInfoMsg);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnNetworkSyncDone);
            this.pnlNetworkSyncInProgress.Controls.Add(this.pbNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnCloseNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkSyncStatus);
            this.pnlNetworkSyncInProgress.Name = "pnlNetworkSyncInProgress";
            this.toolTip1.SetToolTip(this.pnlNetworkSyncInProgress, resources.GetString("pnlNetworkSyncInProgress.ToolTip"));
            // 
            // lblNetworkShareMoreInfoMsg
            // 
            resources.ApplyResources(this.lblNetworkShareMoreInfoMsg, "lblNetworkShareMoreInfoMsg");
            this.lblNetworkShareMoreInfoMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNetworkShareMoreInfoMsg.Name = "lblNetworkShareMoreInfoMsg";
            this.toolTip1.SetToolTip(this.lblNetworkShareMoreInfoMsg, resources.GetString("lblNetworkShareMoreInfoMsg.ToolTip"));
            // 
            // btnNetworkSyncDone
            // 
            resources.ApplyResources(this.btnNetworkSyncDone, "btnNetworkSyncDone");
            this.btnNetworkSyncDone.Name = "btnNetworkSyncDone";
            this.toolTip1.SetToolTip(this.btnNetworkSyncDone, resources.GetString("btnNetworkSyncDone.ToolTip"));
            this.btnNetworkSyncDone.UseVisualStyleBackColor = true;
            this.btnNetworkSyncDone.Click += new System.EventHandler(this.btnNetworkSyncDone_Click);
            // 
            // pbNetworkSyncInProgress
            // 
            resources.ApplyResources(this.pbNetworkSyncInProgress, "pbNetworkSyncInProgress");
            this.pbNetworkSyncInProgress.Maximum = 4;
            this.pbNetworkSyncInProgress.Name = "pbNetworkSyncInProgress";
            this.pbNetworkSyncInProgress.Step = 1;
            this.toolTip1.SetToolTip(this.pbNetworkSyncInProgress, resources.GetString("pbNetworkSyncInProgress.ToolTip"));
            // 
            // btnCloseNetworkSyncInProgress
            // 
            resources.ApplyResources(this.btnCloseNetworkSyncInProgress, "btnCloseNetworkSyncInProgress");
            this.btnCloseNetworkSyncInProgress.Name = "btnCloseNetworkSyncInProgress";
            this.toolTip1.SetToolTip(this.btnCloseNetworkSyncInProgress, resources.GetString("btnCloseNetworkSyncInProgress.ToolTip"));
            this.btnCloseNetworkSyncInProgress.UseVisualStyleBackColor = true;
            this.btnCloseNetworkSyncInProgress.Click += new System.EventHandler(this.btnCloseNetworkSyncInProgress_Click);
            // 
            // lblNetworkSyncStatus
            // 
            resources.ApplyResources(this.lblNetworkSyncStatus, "lblNetworkSyncStatus");
            this.lblNetworkSyncStatus.ForeColor = System.Drawing.Color.White;
            this.lblNetworkSyncStatus.Name = "lblNetworkSyncStatus";
            this.toolTip1.SetToolTip(this.lblNetworkSyncStatus, resources.GetString("lblNetworkSyncStatus.ToolTip"));
            // 
            // pnlOpsPeriod
            // 
            resources.ApplyResources(this.pnlOpsPeriod, "pnlOpsPeriod");
            this.pnlOpsPeriod.BackColor = System.Drawing.Color.White;
            this.pnlOpsPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpsPeriod.Controls.Add(this.btnMoveToOpNow);
            this.pnlOpsPeriod.Controls.Add(this.btnReviewOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.btnEditOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.btnNewOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.cboCurrentOperationalPeriod);
            this.pnlOpsPeriod.Controls.Add(this.label1);
            this.pnlOpsPeriod.Name = "pnlOpsPeriod";
            this.toolTip1.SetToolTip(this.pnlOpsPeriod, resources.GetString("pnlOpsPeriod.ToolTip"));
            // 
            // btnReviewOpPeriod
            // 
            resources.ApplyResources(this.btnReviewOpPeriod, "btnReviewOpPeriod");
            this.btnReviewOpPeriod.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_41_stats;
            this.btnReviewOpPeriod.Name = "btnReviewOpPeriod";
            this.btnReviewOpPeriod.TabStop = false;
            this.toolTip1.SetToolTip(this.btnReviewOpPeriod, resources.GetString("btnReviewOpPeriod.ToolTip"));
            this.btnReviewOpPeriod.UseVisualStyleBackColor = true;
            this.btnReviewOpPeriod.Click += new System.EventHandler(this.btnReviewOpPeriod_Click);
            // 
            // btnEditOpPeriod
            // 
            resources.ApplyResources(this.btnEditOpPeriod, "btnEditOpPeriod");
            this.btnEditOpPeriod.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditOpPeriod.Name = "btnEditOpPeriod";
            this.btnEditOpPeriod.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditOpPeriod, resources.GetString("btnEditOpPeriod.ToolTip"));
            this.btnEditOpPeriod.UseVisualStyleBackColor = true;
            this.btnEditOpPeriod.Click += new System.EventHandler(this.btnEditOpPeriod_Click);
            // 
            // btnNewOpPeriod
            // 
            resources.ApplyResources(this.btnNewOpPeriod, "btnNewOpPeriod");
            this.btnNewOpPeriod.Name = "btnNewOpPeriod";
            this.btnNewOpPeriod.TabStop = false;
            this.toolTip1.SetToolTip(this.btnNewOpPeriod, resources.GetString("btnNewOpPeriod.ToolTip"));
            this.btnNewOpPeriod.UseVisualStyleBackColor = true;
            this.btnNewOpPeriod.Click += new System.EventHandler(this.btnNewOpPeriod_Click);
            // 
            // cboCurrentOperationalPeriod
            // 
            resources.ApplyResources(this.cboCurrentOperationalPeriod, "cboCurrentOperationalPeriod");
            this.cboCurrentOperationalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentOperationalPeriod.FormattingEnabled = true;
            this.cboCurrentOperationalPeriod.Name = "cboCurrentOperationalPeriod";
            this.toolTip1.SetToolTip(this.cboCurrentOperationalPeriod, resources.GetString("cboCurrentOperationalPeriod.ToolTip"));
            this.cboCurrentOperationalPeriod.SelectedIndexChanged += new System.EventHandler(this.cboCurrentOperationalPeriod_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // pnlTaskInfo
            // 
            resources.ApplyResources(this.pnlTaskInfo, "pnlTaskInfo");
            this.pnlTaskInfo.BackColor = System.Drawing.Color.White;
            this.pnlTaskInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTaskInfo.Controls.Add(this.btnLockTaskInfo);
            this.pnlTaskInfo.Controls.Add(this.txtTaskName);
            this.pnlTaskInfo.Controls.Add(this.panel1);
            this.pnlTaskInfo.Controls.Add(this.btnOutstandingLogItems);
            this.pnlTaskInfo.Controls.Add(this.label19);
            this.pnlTaskInfo.Controls.Add(this.btnViewPositionLog);
            this.pnlTaskInfo.Controls.Add(this.btnAddToPositionLog);
            this.pnlTaskInfo.Controls.Add(this.txtTaskNumber);
            this.pnlTaskInfo.Controls.Add(this.btnICSRoleHelp);
            this.pnlTaskInfo.Controls.Add(this.cboICSRole);
            this.pnlTaskInfo.Controls.Add(this.label17);
            this.pnlTaskInfo.Controls.Add(this.label16);
            this.pnlTaskInfo.Controls.Add(this.lblTaskName);
            this.pnlTaskInfo.Controls.Add(this.lblTaskNumber);
            this.pnlTaskInfo.Name = "pnlTaskInfo";
            this.toolTip1.SetToolTip(this.pnlTaskInfo, resources.GetString("pnlTaskInfo.ToolTip"));
            this.pnlTaskInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTaskInfo_Paint);
            // 
            // btnLockTaskInfo
            // 
            resources.ApplyResources(this.btnLockTaskInfo, "btnLockTaskInfo");
            this.btnLockTaskInfo.Name = "btnLockTaskInfo";
            this.toolTip1.SetToolTip(this.btnLockTaskInfo, resources.GetString("btnLockTaskInfo.ToolTip"));
            this.btnLockTaskInfo.UseVisualStyleBackColor = true;
            this.btnLockTaskInfo.Click += new System.EventHandler(this.btnLockTaskInfo_Click);
            // 
            // txtTaskName
            // 
            resources.ApplyResources(this.txtTaskName, "txtTaskName");
            this.txtTaskName.Name = "txtTaskName";
            this.toolTip1.SetToolTip(this.txtTaskName, resources.GetString("txtTaskName.ToolTip"));
            this.txtTaskName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskName_Validating);
            this.txtTaskName.Child = new System.Windows.Controls.TextBox();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Name = "panel1";
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // btnOutstandingLogItems
            // 
            resources.ApplyResources(this.btnOutstandingLogItems, "btnOutstandingLogItems");
            this.btnOutstandingLogItems.Name = "btnOutstandingLogItems";
            this.btnOutstandingLogItems.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOutstandingLogItems, resources.GetString("btnOutstandingLogItems.ToolTip"));
            this.btnOutstandingLogItems.UseVisualStyleBackColor = true;
            this.btnOutstandingLogItems.Click += new System.EventHandler(this.btnOutstandingLogItems_Click);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            this.toolTip1.SetToolTip(this.label19, resources.GetString("label19.ToolTip"));
            // 
            // btnViewPositionLog
            // 
            resources.ApplyResources(this.btnViewPositionLog, "btnViewPositionLog");
            this.btnViewPositionLog.Name = "btnViewPositionLog";
            this.btnViewPositionLog.TabStop = false;
            this.toolTip1.SetToolTip(this.btnViewPositionLog, resources.GetString("btnViewPositionLog.ToolTip"));
            this.btnViewPositionLog.UseVisualStyleBackColor = true;
            this.btnViewPositionLog.Click += new System.EventHandler(this.btnViewPositionLog_Click);
            // 
            // btnAddToPositionLog
            // 
            resources.ApplyResources(this.btnAddToPositionLog, "btnAddToPositionLog");
            this.btnAddToPositionLog.Name = "btnAddToPositionLog";
            this.btnAddToPositionLog.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAddToPositionLog, resources.GetString("btnAddToPositionLog.ToolTip"));
            this.btnAddToPositionLog.UseVisualStyleBackColor = true;
            this.btnAddToPositionLog.Click += new System.EventHandler(this.btnAddToPositionLog_Click);
            // 
            // txtTaskNumber
            // 
            resources.ApplyResources(this.txtTaskNumber, "txtTaskNumber");
            this.txtTaskNumber.Name = "txtTaskNumber";
            this.toolTip1.SetToolTip(this.txtTaskNumber, resources.GetString("txtTaskNumber.ToolTip"));
            this.txtTaskNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaskNumber_KeyPress);
            this.txtTaskNumber.Leave += new System.EventHandler(this.txtTaskNumber_Leave);
            this.txtTaskNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskNumber_Validating);
            // 
            // btnICSRoleHelp
            // 
            resources.ApplyResources(this.btnICSRoleHelp, "btnICSRoleHelp");
            this.btnICSRoleHelp.Name = "btnICSRoleHelp";
            this.btnICSRoleHelp.TabStop = false;
            this.btnICSRoleHelp.Tag = "Help";
            this.toolTip1.SetToolTip(this.btnICSRoleHelp, resources.GetString("btnICSRoleHelp.ToolTip"));
            this.btnICSRoleHelp.UseVisualStyleBackColor = true;
            this.btnICSRoleHelp.Click += new System.EventHandler(this.btnICSRoleHelp_Click);
            // 
            // cboICSRole
            // 
            resources.ApplyResources(this.cboICSRole, "cboICSRole");
            this.cboICSRole.DisplayMember = "RoleNameForDropdown";
            this.cboICSRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboICSRole.FormattingEnabled = true;
            this.cboICSRole.Name = "cboICSRole";
            this.toolTip1.SetToolTip(this.cboICSRole, resources.GetString("cboICSRole.ToolTip"));
            this.cboICSRole.ValueMember = "RoleID";
            this.cboICSRole.SelectedIndexChanged += new System.EventHandler(this.cboICSRole_SelectedIndexChanged);
            this.cboICSRole.Leave += new System.EventHandler(this.cboICSRole_Leave);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            this.toolTip1.SetToolTip(this.label17, resources.GetString("label17.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            this.toolTip1.SetToolTip(this.label16, resources.GetString("label16.ToolTip"));
            // 
            // lblTaskName
            // 
            resources.ApplyResources(this.lblTaskName, "lblTaskName");
            this.lblTaskName.Name = "lblTaskName";
            this.toolTip1.SetToolTip(this.lblTaskName, resources.GetString("lblTaskName.ToolTip"));
            // 
            // lblTaskNumber
            // 
            resources.ApplyResources(this.lblTaskNumber, "lblTaskNumber");
            this.lblTaskNumber.Name = "lblTaskNumber";
            this.toolTip1.SetToolTip(this.lblTaskNumber, resources.GetString("lblTaskNumber.ToolTip"));
            // 
            // lblServerStatus
            // 
            resources.ApplyResources(this.lblServerStatus, "lblServerStatus");
            this.lblServerStatus.Name = "lblServerStatus";
            this.toolTip1.SetToolTip(this.lblServerStatus, resources.GetString("lblServerStatus.ToolTip"));
            // 
            // lblVersionNumber
            // 
            resources.ApplyResources(this.lblVersionNumber, "lblVersionNumber");
            this.lblVersionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.toolTip1.SetToolTip(this.lblVersionNumber, resources.GetString("lblVersionNumber.ToolTip"));
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.iAPToolStripMenuItem,
            this.networkInternetToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.TestToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.toolTip1.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIncidentToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentIncidentsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.browseToIncidentFolderToolStripMenuItem,
            this.restoreDeletedItemsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // newIncidentToolStripMenuItem
            // 
            resources.ApplyResources(this.newIncidentToolStripMenuItem, "newIncidentToolStripMenuItem");
            this.newIncidentToolStripMenuItem.Name = "newIncidentToolStripMenuItem";
            this.newIncidentToolStripMenuItem.Click += new System.EventHandler(this.newIncidentToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentIncidentsToolStripMenuItem
            // 
            resources.ApplyResources(this.recentIncidentsToolStripMenuItem, "recentIncidentsToolStripMenuItem");
            this.recentIncidentsToolStripMenuItem.Name = "recentIncidentsToolStripMenuItem";
            this.recentIncidentsToolStripMenuItem.Click += new System.EventHandler(this.recentIncidentsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // browseToIncidentFolderToolStripMenuItem
            // 
            resources.ApplyResources(this.browseToIncidentFolderToolStripMenuItem, "browseToIncidentFolderToolStripMenuItem");
            this.browseToIncidentFolderToolStripMenuItem.Name = "browseToIncidentFolderToolStripMenuItem";
            this.browseToIncidentFolderToolStripMenuItem.Click += new System.EventHandler(this.browseToIncidentFolderToolStripMenuItem_Click);
            // 
            // restoreDeletedItemsToolStripMenuItem
            // 
            resources.ApplyResources(this.restoreDeletedItemsToolStripMenuItem, "restoreDeletedItemsToolStripMenuItem");
            this.restoreDeletedItemsToolStripMenuItem.Name = "restoreDeletedItemsToolStripMenuItem";
            this.restoreDeletedItemsToolStripMenuItem.Click += new System.EventHandler(this.restoreDeletedItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.savedValuesToolStripMenuItem,
            this.aircraftToolStripMenuItem,
            this.communicationsSystemsToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.hospitalsToolStripMenuItem,
            this.medivacServicesToolStripMenuItem,
            this.teamMembersToolStripMenuItem,
            this.vehiclesToolStripMenuItem,
            this.toolStripSeparator4,
            this.templatesToolStripMenuItem,
            this.incidentObjectivesToolStripMenuItem,
            this.safetyNotesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_137_cogwheel;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // savedValuesToolStripMenuItem
            // 
            resources.ApplyResources(this.savedValuesToolStripMenuItem, "savedValuesToolStripMenuItem");
            this.savedValuesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.savedValuesToolStripMenuItem.Name = "savedValuesToolStripMenuItem";
            // 
            // aircraftToolStripMenuItem
            // 
            resources.ApplyResources(this.aircraftToolStripMenuItem, "aircraftToolStripMenuItem");
            this.aircraftToolStripMenuItem.Name = "aircraftToolStripMenuItem";
            this.aircraftToolStripMenuItem.Click += new System.EventHandler(this.aircraftToolStripMenuItem_Click);
            // 
            // communicationsSystemsToolStripMenuItem
            // 
            resources.ApplyResources(this.communicationsSystemsToolStripMenuItem, "communicationsSystemsToolStripMenuItem");
            this.communicationsSystemsToolStripMenuItem.Name = "communicationsSystemsToolStripMenuItem";
            this.communicationsSystemsToolStripMenuItem.Click += new System.EventHandler(this.communicationsSystemsToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            resources.ApplyResources(this.contactsToolStripMenuItem, "contactsToolStripMenuItem");
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // hospitalsToolStripMenuItem
            // 
            resources.ApplyResources(this.hospitalsToolStripMenuItem, "hospitalsToolStripMenuItem");
            this.hospitalsToolStripMenuItem.Name = "hospitalsToolStripMenuItem";
            this.hospitalsToolStripMenuItem.Click += new System.EventHandler(this.hospitalsToolStripMenuItem_Click);
            // 
            // medivacServicesToolStripMenuItem
            // 
            resources.ApplyResources(this.medivacServicesToolStripMenuItem, "medivacServicesToolStripMenuItem");
            this.medivacServicesToolStripMenuItem.Name = "medivacServicesToolStripMenuItem";
            this.medivacServicesToolStripMenuItem.Click += new System.EventHandler(this.medivacServicesToolStripMenuItem_Click);
            // 
            // teamMembersToolStripMenuItem
            // 
            resources.ApplyResources(this.teamMembersToolStripMenuItem, "teamMembersToolStripMenuItem");
            this.teamMembersToolStripMenuItem.Name = "teamMembersToolStripMenuItem";
            this.teamMembersToolStripMenuItem.Click += new System.EventHandler(this.teamMembersToolStripMenuItem_Click);
            // 
            // vehiclesToolStripMenuItem
            // 
            resources.ApplyResources(this.vehiclesToolStripMenuItem, "vehiclesToolStripMenuItem");
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            this.vehiclesToolStripMenuItem.Click += new System.EventHandler(this.vehiclesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // templatesToolStripMenuItem
            // 
            resources.ApplyResources(this.templatesToolStripMenuItem, "templatesToolStripMenuItem");
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            // 
            // incidentObjectivesToolStripMenuItem
            // 
            resources.ApplyResources(this.incidentObjectivesToolStripMenuItem, "incidentObjectivesToolStripMenuItem");
            this.incidentObjectivesToolStripMenuItem.Name = "incidentObjectivesToolStripMenuItem";
            this.incidentObjectivesToolStripMenuItem.Click += new System.EventHandler(this.incidentObjectivesToolStripMenuItem_Click);
            // 
            // safetyNotesToolStripMenuItem
            // 
            resources.ApplyResources(this.safetyNotesToolStripMenuItem, "safetyNotesToolStripMenuItem");
            this.safetyNotesToolStripMenuItem.Name = "safetyNotesToolStripMenuItem";
            this.safetyNotesToolStripMenuItem.Click += new System.EventHandler(this.safetyNotesToolStripMenuItem_Click);
            // 
            // iAPToolStripMenuItem
            // 
            resources.ApplyResources(this.iAPToolStripMenuItem, "iAPToolStripMenuItem");
            this.iAPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incidentActionPlanToolStripMenuItem,
            this.incidentObjectivesICS202ToolStripMenuItem,
            this.organizationChartICS207ToolStripMenuItem,
            this.teamAssignmentsICS204ToolStripMenuItem,
            this.communicationsPlanICS205ToolStripMenuItem,
            this.medicalPlanICS206ToolStripMenuItem,
            this.safetyMessageICS208ToolStripMenuItem,
            this.incidentStatusSummaryICS209ToolStripMenuItem,
            this.airOperationsSummaryICS220ToolStripMenuItem,
            this.toolStripSeparator5,
            this.additionalDocumentsToolStripMenuItem,
            this.communicationsListICS205AToolStripMenuItem,
            this.generalMessageICS213ToolStripMenuItem,
            this.toolStripSeparator9,
            this.printingToolStripMenuItem,
            this.printThisOperationalPeriodToolStripMenuItem,
            this.printThisIncidentToDateToolStripMenuItem});
            this.iAPToolStripMenuItem.Name = "iAPToolStripMenuItem";
            // 
            // incidentActionPlanToolStripMenuItem
            // 
            resources.ApplyResources(this.incidentActionPlanToolStripMenuItem, "incidentActionPlanToolStripMenuItem");
            this.incidentActionPlanToolStripMenuItem.Name = "incidentActionPlanToolStripMenuItem";
            // 
            // incidentObjectivesICS202ToolStripMenuItem
            // 
            resources.ApplyResources(this.incidentObjectivesICS202ToolStripMenuItem, "incidentObjectivesICS202ToolStripMenuItem");
            this.incidentObjectivesICS202ToolStripMenuItem.Name = "incidentObjectivesICS202ToolStripMenuItem";
            this.incidentObjectivesICS202ToolStripMenuItem.Click += new System.EventHandler(this.incidentObjectivesICS202ToolStripMenuItem_Click);
            // 
            // organizationChartICS207ToolStripMenuItem
            // 
            resources.ApplyResources(this.organizationChartICS207ToolStripMenuItem, "organizationChartICS207ToolStripMenuItem");
            this.organizationChartICS207ToolStripMenuItem.Name = "organizationChartICS207ToolStripMenuItem";
            this.organizationChartICS207ToolStripMenuItem.Click += new System.EventHandler(this.organizationChartICS207ToolStripMenuItem_Click);
            // 
            // teamAssignmentsICS204ToolStripMenuItem
            // 
            resources.ApplyResources(this.teamAssignmentsICS204ToolStripMenuItem, "teamAssignmentsICS204ToolStripMenuItem");
            this.teamAssignmentsICS204ToolStripMenuItem.Name = "teamAssignmentsICS204ToolStripMenuItem";
            this.teamAssignmentsICS204ToolStripMenuItem.Click += new System.EventHandler(this.teamAssignmentsICS204ToolStripMenuItem_Click);
            // 
            // communicationsPlanICS205ToolStripMenuItem
            // 
            resources.ApplyResources(this.communicationsPlanICS205ToolStripMenuItem, "communicationsPlanICS205ToolStripMenuItem");
            this.communicationsPlanICS205ToolStripMenuItem.Name = "communicationsPlanICS205ToolStripMenuItem";
            this.communicationsPlanICS205ToolStripMenuItem.Click += new System.EventHandler(this.communicationsPlanICS205ToolStripMenuItem_Click);
            // 
            // medicalPlanICS206ToolStripMenuItem
            // 
            resources.ApplyResources(this.medicalPlanICS206ToolStripMenuItem, "medicalPlanICS206ToolStripMenuItem");
            this.medicalPlanICS206ToolStripMenuItem.Name = "medicalPlanICS206ToolStripMenuItem";
            this.medicalPlanICS206ToolStripMenuItem.Click += new System.EventHandler(this.medicalPlanICS206ToolStripMenuItem_Click);
            // 
            // safetyMessageICS208ToolStripMenuItem
            // 
            resources.ApplyResources(this.safetyMessageICS208ToolStripMenuItem, "safetyMessageICS208ToolStripMenuItem");
            this.safetyMessageICS208ToolStripMenuItem.Name = "safetyMessageICS208ToolStripMenuItem";
            this.safetyMessageICS208ToolStripMenuItem.Click += new System.EventHandler(this.safetyMessageICS208ToolStripMenuItem_Click);
            // 
            // incidentStatusSummaryICS209ToolStripMenuItem
            // 
            resources.ApplyResources(this.incidentStatusSummaryICS209ToolStripMenuItem, "incidentStatusSummaryICS209ToolStripMenuItem");
            this.incidentStatusSummaryICS209ToolStripMenuItem.Name = "incidentStatusSummaryICS209ToolStripMenuItem";
            // 
            // airOperationsSummaryICS220ToolStripMenuItem
            // 
            resources.ApplyResources(this.airOperationsSummaryICS220ToolStripMenuItem, "airOperationsSummaryICS220ToolStripMenuItem");
            this.airOperationsSummaryICS220ToolStripMenuItem.Name = "airOperationsSummaryICS220ToolStripMenuItem";
            this.airOperationsSummaryICS220ToolStripMenuItem.Click += new System.EventHandler(this.airOperationsSummaryICS220ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // additionalDocumentsToolStripMenuItem
            // 
            resources.ApplyResources(this.additionalDocumentsToolStripMenuItem, "additionalDocumentsToolStripMenuItem");
            this.additionalDocumentsToolStripMenuItem.Name = "additionalDocumentsToolStripMenuItem";
            // 
            // communicationsListICS205AToolStripMenuItem
            // 
            resources.ApplyResources(this.communicationsListICS205AToolStripMenuItem, "communicationsListICS205AToolStripMenuItem");
            this.communicationsListICS205AToolStripMenuItem.Name = "communicationsListICS205AToolStripMenuItem";
            this.communicationsListICS205AToolStripMenuItem.Click += new System.EventHandler(this.communicationsListICS205AToolStripMenuItem_Click);
            // 
            // generalMessageICS213ToolStripMenuItem
            // 
            resources.ApplyResources(this.generalMessageICS213ToolStripMenuItem, "generalMessageICS213ToolStripMenuItem");
            this.generalMessageICS213ToolStripMenuItem.Name = "generalMessageICS213ToolStripMenuItem";
            this.generalMessageICS213ToolStripMenuItem.Click += new System.EventHandler(this.generalMessageICS213ToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // printingToolStripMenuItem
            // 
            resources.ApplyResources(this.printingToolStripMenuItem, "printingToolStripMenuItem");
            this.printingToolStripMenuItem.Name = "printingToolStripMenuItem";
            // 
            // printThisOperationalPeriodToolStripMenuItem
            // 
            resources.ApplyResources(this.printThisOperationalPeriodToolStripMenuItem, "printThisOperationalPeriodToolStripMenuItem");
            this.printThisOperationalPeriodToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printThisOperationalPeriodToolStripMenuItem.Name = "printThisOperationalPeriodToolStripMenuItem";
            this.printThisOperationalPeriodToolStripMenuItem.Click += new System.EventHandler(this.printThisOperationalPeriodToolStripMenuItem_Click);
            // 
            // printThisIncidentToDateToolStripMenuItem
            // 
            resources.ApplyResources(this.printThisIncidentToDateToolStripMenuItem, "printThisIncidentToDateToolStripMenuItem");
            this.printThisIncidentToDateToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printThisIncidentToDateToolStripMenuItem.Name = "printThisIncidentToDateToolStripMenuItem";
            this.printThisIncidentToDateToolStripMenuItem.Click += new System.EventHandler(this.printThisIncidentToDateToolStripMenuItem_Click);
            // 
            // networkInternetToolStripMenuItem
            // 
            resources.ApplyResources(this.networkInternetToolStripMenuItem, "networkInternetToolStripMenuItem");
            this.networkInternetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localNetworkSharingSyncToolStripMenuItem,
            this.requestIncidentFromServerToolStripMenuItem,
            this.toolStripSeparator11,
            this.internetSyncToolStripMenuItem,
            this.toolStripSeparator12,
            this.requestOptionsFromServerToolStripMenuItem,
            this.networkTestToolStripMenuItem});
            this.networkInternetToolStripMenuItem.Name = "networkInternetToolStripMenuItem";
            // 
            // localNetworkSharingSyncToolStripMenuItem
            // 
            resources.ApplyResources(this.localNetworkSharingSyncToolStripMenuItem, "localNetworkSharingSyncToolStripMenuItem");
            this.localNetworkSharingSyncToolStripMenuItem.Name = "localNetworkSharingSyncToolStripMenuItem";
            this.localNetworkSharingSyncToolStripMenuItem.Click += new System.EventHandler(this.localNetworkSharingSyncToolStripMenuItem_Click);
            // 
            // requestIncidentFromServerToolStripMenuItem
            // 
            resources.ApplyResources(this.requestIncidentFromServerToolStripMenuItem, "requestIncidentFromServerToolStripMenuItem");
            this.requestIncidentFromServerToolStripMenuItem.Name = "requestIncidentFromServerToolStripMenuItem";
            this.requestIncidentFromServerToolStripMenuItem.Click += new System.EventHandler(this.requestIncidentFromServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            // 
            // internetSyncToolStripMenuItem
            // 
            resources.ApplyResources(this.internetSyncToolStripMenuItem, "internetSyncToolStripMenuItem");
            this.internetSyncToolStripMenuItem.Name = "internetSyncToolStripMenuItem";
            this.internetSyncToolStripMenuItem.Click += new System.EventHandler(this.internetSyncToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            // 
            // requestOptionsFromServerToolStripMenuItem
            // 
            resources.ApplyResources(this.requestOptionsFromServerToolStripMenuItem, "requestOptionsFromServerToolStripMenuItem");
            this.requestOptionsFromServerToolStripMenuItem.Name = "requestOptionsFromServerToolStripMenuItem";
            this.requestOptionsFromServerToolStripMenuItem.Click += new System.EventHandler(this.requestOptionsFromServerToolStripMenuItem_Click);
            // 
            // networkTestToolStripMenuItem
            // 
            resources.ApplyResources(this.networkTestToolStripMenuItem, "networkTestToolStripMenuItem");
            this.networkTestToolStripMenuItem.Name = "networkTestToolStripMenuItem";
            this.networkTestToolStripMenuItem.Click += new System.EventHandler(this.networkTestToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newsToolStripMenuItem,
            this.viewLogFileToolStripMenuItem,
            this.toolStripSeparator6,
            this.supportToolStripMenuItem,
            this.aboutCIAPPToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.RedExclaimSq;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // newsToolStripMenuItem
            // 
            resources.ApplyResources(this.newsToolStripMenuItem, "newsToolStripMenuItem");
            this.newsToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.RedExclaimSq;
            this.newsToolStripMenuItem.Name = "newsToolStripMenuItem";
            this.newsToolStripMenuItem.Click += new System.EventHandler(this.newsToolStripMenuItem_Click);
            // 
            // viewLogFileToolStripMenuItem
            // 
            resources.ApplyResources(this.viewLogFileToolStripMenuItem, "viewLogFileToolStripMenuItem");
            this.viewLogFileToolStripMenuItem.Name = "viewLogFileToolStripMenuItem";
            this.viewLogFileToolStripMenuItem.Click += new System.EventHandler(this.viewLogFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // supportToolStripMenuItem
            // 
            resources.ApplyResources(this.supportToolStripMenuItem, "supportToolStripMenuItem");
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // aboutCIAPPToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutCIAPPToolStripMenuItem, "aboutCIAPPToolStripMenuItem");
            this.aboutCIAPPToolStripMenuItem.Name = "aboutCIAPPToolStripMenuItem";
            this.aboutCIAPPToolStripMenuItem.Click += new System.EventHandler(this.aboutCIAPPToolStripMenuItem_Click);
            // 
            // TestToolStripMenuItem
            // 
            resources.ApplyResources(this.TestToolStripMenuItem, "TestToolStripMenuItem");
            this.TestToolStripMenuItem.BackColor = System.Drawing.Color.Fuchsia;
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.frenchToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // frenchToolStripMenuItem
            // 
            resources.ApplyResources(this.frenchToolStripMenuItem, "frenchToolStripMenuItem");
            this.frenchToolStripMenuItem.Name = "frenchToolStripMenuItem";
            this.frenchToolStripMenuItem.Click += new System.EventHandler(this.frenchToolStripMenuItem_Click);
            // 
            // cpOtherTools
            // 
            resources.ApplyResources(this.cpOtherTools, "cpOtherTools");
            this.cpOtherTools.BackColor = System.Drawing.Color.White;
            this.cpOtherTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpOtherTools.Collapsed = false;
            this.cpOtherTools.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpOtherTools.Controls.Add(this.btnGeneralMessage);
            this.cpOtherTools.Controls.Add(this.btnReplacementResources);
            this.cpOtherTools.Controls.Add(this.btnAdditionalContacts);
            this.cpOtherTools.Controls.Add(this.btnNotes);
            this.cpOtherTools.Controls.Add(this.btnShowResources);
            this.cpOtherTools.EnableExpandCollapse = false;
            this.cpOtherTools.ExpandsRight = true;
            this.cpOtherTools.ExpandsUpward = false;
            this.cpOtherTools.Name = "cpOtherTools";
            this.cpOtherTools.SizeWhenCollapsed = new System.Drawing.Size(485, 40);
            this.cpOtherTools.SizeWhenExpanded = new System.Drawing.Size(485, 300);
            this.cpOtherTools.TitleText = "Other Tools";
            this.toolTip1.SetToolTip(this.cpOtherTools, resources.GetString("cpOtherTools.ToolTip"));
            // 
            // btnGeneralMessage
            // 
            resources.ApplyResources(this.btnGeneralMessage, "btnGeneralMessage");
            this.btnGeneralMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnGeneralMessage.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_11_envelope;
            this.btnGeneralMessage.Name = "btnGeneralMessage";
            this.toolTip1.SetToolTip(this.btnGeneralMessage, resources.GetString("btnGeneralMessage.ToolTip"));
            this.btnGeneralMessage.UseVisualStyleBackColor = true;
            this.btnGeneralMessage.Click += new System.EventHandler(this.btnGeneralMessage_Click);
            // 
            // btnReplacementResources
            // 
            resources.ApplyResources(this.btnReplacementResources, "btnReplacementResources");
            this.btnReplacementResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnReplacementResources.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_46_calendar;
            this.btnReplacementResources.Name = "btnReplacementResources";
            this.toolTip1.SetToolTip(this.btnReplacementResources, resources.GetString("btnReplacementResources.ToolTip"));
            this.btnReplacementResources.UseVisualStyleBackColor = true;
            this.btnReplacementResources.Click += new System.EventHandler(this.btnReplacementResources_Click);
            // 
            // btnAdditionalContacts
            // 
            resources.ApplyResources(this.btnAdditionalContacts, "btnAdditionalContacts");
            this.btnAdditionalContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAdditionalContacts.Name = "btnAdditionalContacts";
            this.toolTip1.SetToolTip(this.btnAdditionalContacts, resources.GetString("btnAdditionalContacts.ToolTip"));
            this.btnAdditionalContacts.UseVisualStyleBackColor = true;
            this.btnAdditionalContacts.Click += new System.EventHandler(this.btnAdditionalContacts_Click);
            // 
            // btnNotes
            // 
            resources.ApplyResources(this.btnNotes, "btnNotes");
            this.btnNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnNotes.Name = "btnNotes";
            this.toolTip1.SetToolTip(this.btnNotes, resources.GetString("btnNotes.ToolTip"));
            this.btnNotes.UseVisualStyleBackColor = true;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnShowResources
            // 
            resources.ApplyResources(this.btnShowResources, "btnShowResources");
            this.btnShowResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnShowResources.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_893_user_worker;
            this.btnShowResources.Name = "btnShowResources";
            this.toolTip1.SetToolTip(this.btnShowResources, resources.GetString("btnShowResources.ToolTip"));
            this.btnShowResources.UseVisualStyleBackColor = true;
            this.btnShowResources.Click += new System.EventHandler(this.btnShowResources_Click);
            // 
            // cpIncidentActionPlan
            // 
            resources.ApplyResources(this.cpIncidentActionPlan, "cpIncidentActionPlan");
            this.cpIncidentActionPlan.BackColor = System.Drawing.Color.White;
            this.cpIncidentActionPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpIncidentActionPlan.Collapsed = false;
            this.cpIncidentActionPlan.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpIncidentActionPlan.Controls.Add(this.btnIncidentStatusSummary);
            this.cpIncidentActionPlan.Controls.Add(this.btnAssignmentList);
            this.cpIncidentActionPlan.Controls.Add(this.btnAirOpsSummary);
            this.cpIncidentActionPlan.Controls.Add(this.btnSafetyPlans);
            this.cpIncidentActionPlan.Controls.Add(this.btnIncidentObjectives);
            this.cpIncidentActionPlan.Controls.Add(this.btnMedicalPlan);
            this.cpIncidentActionPlan.Controls.Add(this.btnPrintIAP);
            this.cpIncidentActionPlan.Controls.Add(this.btnPrintOrgChart);
            this.cpIncidentActionPlan.Controls.Add(this.btnCommsPlan);
            this.cpIncidentActionPlan.EnableExpandCollapse = false;
            this.cpIncidentActionPlan.ExpandsRight = true;
            this.cpIncidentActionPlan.ExpandsUpward = false;
            this.cpIncidentActionPlan.Name = "cpIncidentActionPlan";
            this.cpIncidentActionPlan.SizeWhenCollapsed = new System.Drawing.Size(485, 40);
            this.cpIncidentActionPlan.SizeWhenExpanded = new System.Drawing.Size(485, 300);
            this.cpIncidentActionPlan.TitleText = "Incident Action Plan";
            this.toolTip1.SetToolTip(this.cpIncidentActionPlan, resources.GetString("cpIncidentActionPlan.ToolTip"));
            // 
            // btnIncidentStatusSummary
            // 
            resources.ApplyResources(this.btnIncidentStatusSummary, "btnIncidentStatusSummary");
            this.btnIncidentStatusSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnIncidentStatusSummary.Name = "btnIncidentStatusSummary";
            this.toolTip1.SetToolTip(this.btnIncidentStatusSummary, resources.GetString("btnIncidentStatusSummary.ToolTip"));
            this.btnIncidentStatusSummary.UseVisualStyleBackColor = true;
            this.btnIncidentStatusSummary.Click += new System.EventHandler(this.btnIncidentStatusSummary_Click);
            // 
            // btnAssignmentList
            // 
            resources.ApplyResources(this.btnAssignmentList, "btnAssignmentList");
            this.btnAssignmentList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAssignmentList.Name = "btnAssignmentList";
            this.toolTip1.SetToolTip(this.btnAssignmentList, resources.GetString("btnAssignmentList.ToolTip"));
            this.btnAssignmentList.UseVisualStyleBackColor = true;
            this.btnAssignmentList.Click += new System.EventHandler(this.btnAssignmentList_Click);
            // 
            // btnAirOpsSummary
            // 
            resources.ApplyResources(this.btnAirOpsSummary, "btnAirOpsSummary");
            this.btnAirOpsSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAirOpsSummary.Name = "btnAirOpsSummary";
            this.toolTip1.SetToolTip(this.btnAirOpsSummary, resources.GetString("btnAirOpsSummary.ToolTip"));
            this.btnAirOpsSummary.UseVisualStyleBackColor = true;
            this.btnAirOpsSummary.Click += new System.EventHandler(this.btnAirOpsSummary_Click);
            // 
            // btnSafetyPlans
            // 
            resources.ApplyResources(this.btnSafetyPlans, "btnSafetyPlans");
            this.btnSafetyPlans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnSafetyPlans.Name = "btnSafetyPlans";
            this.toolTip1.SetToolTip(this.btnSafetyPlans, resources.GetString("btnSafetyPlans.ToolTip"));
            this.btnSafetyPlans.UseVisualStyleBackColor = true;
            this.btnSafetyPlans.Click += new System.EventHandler(this.btnSafetyPlans_Click);
            // 
            // btnIncidentObjectives
            // 
            resources.ApplyResources(this.btnIncidentObjectives, "btnIncidentObjectives");
            this.btnIncidentObjectives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnIncidentObjectives.Name = "btnIncidentObjectives";
            this.toolTip1.SetToolTip(this.btnIncidentObjectives, resources.GetString("btnIncidentObjectives.ToolTip"));
            this.btnIncidentObjectives.UseVisualStyleBackColor = true;
            this.btnIncidentObjectives.Click += new System.EventHandler(this.btnIncidentObjectives_Click);
            // 
            // btnMedicalPlan
            // 
            resources.ApplyResources(this.btnMedicalPlan, "btnMedicalPlan");
            this.btnMedicalPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMedicalPlan.Name = "btnMedicalPlan";
            this.toolTip1.SetToolTip(this.btnMedicalPlan, resources.GetString("btnMedicalPlan.ToolTip"));
            this.btnMedicalPlan.UseVisualStyleBackColor = true;
            this.btnMedicalPlan.Click += new System.EventHandler(this.btnMedicalPlan_Click);
            // 
            // btnPrintIAP
            // 
            resources.ApplyResources(this.btnPrintIAP, "btnPrintIAP");
            this.btnPrintIAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnPrintIAP.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrintIAP.Name = "btnPrintIAP";
            this.btnPrintIAP.Tag = "ViewPDF";
            this.toolTip1.SetToolTip(this.btnPrintIAP, resources.GetString("btnPrintIAP.ToolTip"));
            this.btnPrintIAP.UseVisualStyleBackColor = true;
            this.btnPrintIAP.Click += new System.EventHandler(this.btnPrintIAP_Click);
            // 
            // btnPrintOrgChart
            // 
            resources.ApplyResources(this.btnPrintOrgChart, "btnPrintOrgChart");
            this.btnPrintOrgChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnPrintOrgChart.Name = "btnPrintOrgChart";
            this.toolTip1.SetToolTip(this.btnPrintOrgChart, resources.GetString("btnPrintOrgChart.ToolTip"));
            this.btnPrintOrgChart.UseVisualStyleBackColor = true;
            this.btnPrintOrgChart.Click += new System.EventHandler(this.btnPrintOrgChart_Click);
            // 
            // btnCommsPlan
            // 
            resources.ApplyResources(this.btnCommsPlan, "btnCommsPlan");
            this.btnCommsPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnCommsPlan.Name = "btnCommsPlan";
            this.toolTip1.SetToolTip(this.btnCommsPlan, resources.GetString("btnCommsPlan.ToolTip"));
            this.btnCommsPlan.UseVisualStyleBackColor = true;
            this.btnCommsPlan.Click += new System.EventHandler(this.btnCommsPlan_Click);
            // 
            // IncidentDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cpOtherTools);
            this.Controls.Add(this.cpIncidentActionPlan);
            this.Controls.Add(this.picOrgLogo);
            this.Controls.Add(this.pnlInternetSyncStart);
            this.Controls.Add(this.pnlNetworkSyncInProgress);
            this.Controls.Add(this.pnlOpsPeriod);
            this.Controls.Add(this.pnlTaskInfo);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IncidentDetailsForm";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IncidentDetailsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IncidentDetailsForm_FormClosed);
            this.Load += new System.EventHandler(this.IncidentDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOrgLogo)).EndInit();
            this.pnlInternetSyncStart.ResumeLayout(false);
            this.pnlNetworkSyncInProgress.ResumeLayout(false);
            this.pnlOpsPeriod.ResumeLayout(false);
            this.pnlTaskInfo.ResumeLayout(false);
            this.pnlTaskInfo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cpOtherTools.ResumeLayout(false);
            this.cpIncidentActionPlan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpsPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTaskInfo;
        private System.Windows.Forms.Button btnOutstandingLogItems;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnViewPositionLog;
        private System.Windows.Forms.Button btnAddToPositionLog;
        private System.Windows.Forms.TextBox txtTaskNumber;
        private System.Windows.Forms.Button btnICSRoleHelp;
        private System.Windows.Forms.ComboBox cboICSRole;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblTaskNumber;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.Panel pnlInternetSyncStart;
        private System.Windows.Forms.Button btnCancelInternetSync;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel pnlNetworkSyncInProgress;
        private System.Windows.Forms.Label lblNetworkShareMoreInfoMsg;
        private System.Windows.Forms.Button btnNetworkSyncDone;
        private System.Windows.Forms.ProgressBar pbNetworkSyncInProgress;
        private System.Windows.Forms.Button btnCloseNetworkSyncInProgress;
        private System.Windows.Forms.Label lblNetworkSyncStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnSafetyPlans;
        private System.Windows.Forms.Button btnMedicalPlan;
        private System.Windows.Forms.Button btnPrintOrgChart;
        private System.Windows.Forms.Button btnCommsPlan;
        private System.Windows.Forms.Button btnPrintIAP;
        private System.Windows.Forms.Button btnIncidentObjectives;
        private System.Windows.Forms.Button btnAdditionalContacts;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkInternetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox picOrgLogo;
        private System.Windows.Forms.ToolStripMenuItem newIncidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentIncidentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToIncidentFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationsSystemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCIAPPToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem savedValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hospitalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentObjectivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safetyNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ImageList imglTabIcons;
        private System.Windows.Forms.ToolStripMenuItem medivacServicesToolStripMenuItem;
        private CustomControls.CollapsiblePanel cpIncidentActionPlan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog svdTaskFile;
        private System.Windows.Forms.OpenFileDialog ofdOpenTaskFile;
        private System.Windows.Forms.FolderBrowserDialog fbdSaveLocation;
        private System.Windows.Forms.Timer tmrAutoSave;
        private System.Windows.Forms.Timer tmrPositionLogReminders;
        private System.Windows.Forms.Timer tmrInternetSync;
        private System.Windows.Forms.Timer tmrNetwork;
        private System.Windows.Forms.ToolStripMenuItem incidentActionPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentObjectivesICS202ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationsPlanICS205ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalPlanICS206ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem additionalDocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationsListICS205AToolStripMenuItem;
        private CustomControls.CollapsiblePanel cpOtherTools;
        private System.Windows.Forms.ToolStripMenuItem organizationChartICS207ToolStripMenuItem;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.ToolStripMenuItem safetyMessageICS208ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalMessageICS213ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem printThisOperationalPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printThisIncidentToDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localNetworkSharingSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestIncidentFromServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem internetSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem requestOptionsFromServerToolStripMenuItem;
        private System.Windows.Forms.Button btnAssignmentList;
        private System.Windows.Forms.Button btnAirOpsSummary;
        private System.Windows.Forms.ToolStripMenuItem aircraftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airOperationsSummaryICS220ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamAssignmentsICS204ToolStripMenuItem;
        private System.Windows.Forms.Button btnShowResources;
        private SpellBox txtTaskName;
        private System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
        private System.Windows.Forms.Button btnGeneralMessage;
        private System.Windows.Forms.Button btnReplacementResources;
        private System.Windows.Forms.Button btnIncidentStatusSummary;
        private System.Windows.Forms.ToolStripMenuItem incidentStatusSummaryICS209ToolStripMenuItem;
        private System.Windows.Forms.Button btnLockTaskInfo;
        private System.Windows.Forms.Timer tmrLock;
        private System.Windows.Forms.ComboBox cboCurrentOperationalPeriod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem restoreDeletedItemsToolStripMenuItem;
        private System.Windows.Forms.Button btnReviewOpPeriod;
        private System.Windows.Forms.Button btnEditOpPeriod;
        private System.Windows.Forms.Button btnNewOpPeriod;
        private System.Windows.Forms.Button btnMoveToOpNow;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem viewLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchToolStripMenuItem;
    }
}

