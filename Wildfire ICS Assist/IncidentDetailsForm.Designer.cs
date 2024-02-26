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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvMembersOnTask = new System.Windows.Forms.DataGridView();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberSARGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSignInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignmentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberAssignmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAMember = new System.Windows.Forms.Button();
            this.btnBulkSignIn = new System.Windows.Forms.Button();
            this.btnMembersOnTaskNewWindow = new System.Windows.Forms.Button();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.dgvTaskEquipment = new System.Windows.Forms.DataGridView();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferenceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipmentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAssignEquipment = new System.Windows.Forms.Button();
            this.btnViewEquipment = new System.Windows.Forms.Button();
            this.btnReturnEquipment = new System.Windows.Forms.Button();
            this.pnlOpsPeriod = new System.Windows.Forms.Panel();
            this.btnCloseOpPeriod = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.datOpsEnd = new System.Windows.Forms.DateTimePicker();
            this.datOpsStart = new System.Windows.Forms.DateTimePicker();
            this.numOpPeriod = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTaskInfo = new System.Windows.Forms.Panel();
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
            this.tcStatus = new System.Windows.Forms.TabControl();
            this.tpMembersOnTask = new System.Windows.Forms.TabPage();
            this.tpEquipment = new System.Windows.Forms.TabPage();
            this.tpNetworkLog = new System.Windows.Forms.TabPage();
            this.txtNetworkLog = new System.Windows.Forms.TextBox();
            this.imglTabIcons = new System.Windows.Forms.ImageList(this.components);
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentIncidentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToIncidentFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.airOperationsSummaryICS220ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printTheIncidentActionPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.additionalDocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationsListICS205AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalMessageICS213ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.printingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printThisOperationalPeriodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printThisIncidentToDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.teamAssignmentsICS204ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.memberStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalContactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLogToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.notesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminFinanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLogToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localNetworkSharingSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestIncidentFromServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.internetSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.requestOptionsFromServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCIAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picOrgLogo = new System.Windows.Forms.PictureBox();
            this.svdTaskFile = new System.Windows.Forms.SaveFileDialog();
            this.ofdOpenTaskFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdSaveLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.tmrPositionLogReminders = new System.Windows.Forms.Timer(this.components);
            this.tmrInternetSync = new System.Windows.Forms.Timer(this.components);
            this.tmrNetwork = new System.Windows.Forms.Timer(this.components);
            this.cpOtherTools = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.btnGeneralMessage = new System.Windows.Forms.Button();
            this.btnReplacementResources = new System.Windows.Forms.Button();
            this.btnAdditionalContacts = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnShowResources = new System.Windows.Forms.Button();
            this.cpIncidentActionPlan = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.btnAssignmentList = new System.Windows.Forms.Button();
            this.btnAirOpsSummary = new System.Windows.Forms.Button();
            this.btnSafetyPlans = new System.Windows.Forms.Button();
            this.btnIncidentObjectives = new System.Windows.Forms.Button();
            this.btnMedicalPlan = new System.Windows.Forms.Button();
            this.btnPrintIAP = new System.Windows.Forms.Button();
            this.btnPrintOrgChart = new System.Windows.Forms.Button();
            this.btnCommsPlan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembersOnTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskEquipment)).BeginInit();
            this.pnlOpsPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).BeginInit();
            this.pnlTaskInfo.SuspendLayout();
            this.tcStatus.SuspendLayout();
            this.tpMembersOnTask.SuspendLayout();
            this.tpEquipment.SuspendLayout();
            this.tpNetworkLog.SuspendLayout();
            this.pnlInternetSyncStart.SuspendLayout();
            this.pnlNetworkSyncInProgress.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrgLogo)).BeginInit();
            this.cpOtherTools.SuspendLayout();
            this.cpIncidentActionPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvMembersOnTask);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnAddAMember);
            this.splitContainer4.Panel2.Controls.Add(this.btnBulkSignIn);
            this.splitContainer4.Panel2.Controls.Add(this.btnMembersOnTaskNewWindow);
            // 
            // dgvMembersOnTask
            // 
            this.dgvMembersOnTask.AllowUserToAddRows = false;
            this.dgvMembersOnTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembersOnTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberName,
            this.colMemberSARGroup,
            this.colSignInTime,
            this.colAssignmentNumber,
            this.colMemberAssignmentStatus});
            resources.ApplyResources(this.dgvMembersOnTask, "dgvMembersOnTask");
            this.dgvMembersOnTask.MultiSelect = false;
            this.dgvMembersOnTask.Name = "dgvMembersOnTask";
            this.dgvMembersOnTask.ReadOnly = true;
            this.dgvMembersOnTask.RowHeadersVisible = false;
            this.dgvMembersOnTask.RowTemplate.Height = 30;
            this.dgvMembersOnTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colMemberName
            // 
            this.colMemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemberName.DataPropertyName = "MemberName";
            resources.ApplyResources(this.colMemberName, "colMemberName");
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            // 
            // colMemberSARGroup
            // 
            this.colMemberSARGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMemberSARGroup.DataPropertyName = "OrganizationName";
            resources.ApplyResources(this.colMemberSARGroup, "colMemberSARGroup");
            this.colMemberSARGroup.Name = "colMemberSARGroup";
            this.colMemberSARGroup.ReadOnly = true;
            // 
            // colSignInTime
            // 
            this.colSignInTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSignInTime.DataPropertyName = "SignInTimeAsText";
            dataGridViewCellStyle2.Format = "HH:mm yyyy-MMM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.colSignInTime.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colSignInTime, "colSignInTime");
            this.colSignInTime.Name = "colSignInTime";
            this.colSignInTime.ReadOnly = true;
            // 
            // colAssignmentNumber
            // 
            this.colAssignmentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAssignmentNumber.DataPropertyName = "getCurrentActivityName";
            resources.ApplyResources(this.colAssignmentNumber, "colAssignmentNumber");
            this.colAssignmentNumber.Name = "colAssignmentNumber";
            this.colAssignmentNumber.ReadOnly = true;
            // 
            // colMemberAssignmentStatus
            // 
            this.colMemberAssignmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMemberAssignmentStatus.DataPropertyName = "AssignmentStatus";
            resources.ApplyResources(this.colMemberAssignmentStatus, "colMemberAssignmentStatus");
            this.colMemberAssignmentStatus.Name = "colMemberAssignmentStatus";
            this.colMemberAssignmentStatus.ReadOnly = true;
            // 
            // btnAddAMember
            // 
            resources.ApplyResources(this.btnAddAMember, "btnAddAMember");
            this.btnAddAMember.Name = "btnAddAMember";
            this.btnAddAMember.UseVisualStyleBackColor = true;
            // 
            // btnBulkSignIn
            // 
            resources.ApplyResources(this.btnBulkSignIn, "btnBulkSignIn");
            this.btnBulkSignIn.Name = "btnBulkSignIn";
            this.btnBulkSignIn.UseVisualStyleBackColor = true;
            // 
            // btnMembersOnTaskNewWindow
            // 
            resources.ApplyResources(this.btnMembersOnTaskNewWindow, "btnMembersOnTaskNewWindow");
            this.btnMembersOnTaskNewWindow.Name = "btnMembersOnTaskNewWindow";
            this.btnMembersOnTaskNewWindow.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            resources.ApplyResources(this.splitContainer5, "splitContainer5");
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.dgvTaskEquipment);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.btnAssignEquipment);
            this.splitContainer5.Panel2.Controls.Add(this.btnViewEquipment);
            this.splitContainer5.Panel2.Controls.Add(this.btnReturnEquipment);
            // 
            // dgvTaskEquipment
            // 
            this.dgvTaskEquipment.AllowUserToAddRows = false;
            this.dgvTaskEquipment.AllowUserToDeleteRows = false;
            this.dgvTaskEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colSubCategory,
            this.colName,
            this.colReferenceID,
            this.colEquipmentStatus,
            this.colAssignee});
            resources.ApplyResources(this.dgvTaskEquipment, "dgvTaskEquipment");
            this.dgvTaskEquipment.Name = "dgvTaskEquipment";
            this.dgvTaskEquipment.ReadOnly = true;
            this.dgvTaskEquipment.RowHeadersVisible = false;
            this.dgvTaskEquipment.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaskEquipment.RowTemplate.Height = 30;
            this.dgvTaskEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategory.DataPropertyName = "ParentCategoryName";
            resources.ApplyResources(this.colCategory, "colCategory");
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colSubCategory
            // 
            this.colSubCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSubCategory.DataPropertyName = "CategoryName";
            resources.ApplyResources(this.colSubCategory, "colSubCategory");
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "EquipmentName";
            resources.ApplyResources(this.colName, "colName");
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colReferenceID
            // 
            this.colReferenceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReferenceID.DataPropertyName = "ReferenceID";
            resources.ApplyResources(this.colReferenceID, "colReferenceID");
            this.colReferenceID.Name = "colReferenceID";
            this.colReferenceID.ReadOnly = true;
            // 
            // colEquipmentStatus
            // 
            this.colEquipmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEquipmentStatus.DataPropertyName = "StatusName";
            resources.ApplyResources(this.colEquipmentStatus, "colEquipmentStatus");
            this.colEquipmentStatus.Name = "colEquipmentStatus";
            this.colEquipmentStatus.ReadOnly = true;
            // 
            // colAssignee
            // 
            this.colAssignee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssignee.DataPropertyName = "AssigneeName";
            resources.ApplyResources(this.colAssignee, "colAssignee");
            this.colAssignee.Name = "colAssignee";
            this.colAssignee.ReadOnly = true;
            // 
            // btnAssignEquipment
            // 
            resources.ApplyResources(this.btnAssignEquipment, "btnAssignEquipment");
            this.btnAssignEquipment.Name = "btnAssignEquipment";
            this.btnAssignEquipment.UseVisualStyleBackColor = true;
            // 
            // btnViewEquipment
            // 
            resources.ApplyResources(this.btnViewEquipment, "btnViewEquipment");
            this.btnViewEquipment.Name = "btnViewEquipment";
            this.btnViewEquipment.UseVisualStyleBackColor = true;
            // 
            // btnReturnEquipment
            // 
            resources.ApplyResources(this.btnReturnEquipment, "btnReturnEquipment");
            this.btnReturnEquipment.Name = "btnReturnEquipment";
            this.btnReturnEquipment.UseVisualStyleBackColor = true;
            // 
            // pnlOpsPeriod
            // 
            resources.ApplyResources(this.pnlOpsPeriod, "pnlOpsPeriod");
            this.pnlOpsPeriod.BackColor = System.Drawing.Color.White;
            this.pnlOpsPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpsPeriod.Controls.Add(this.btnCloseOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.label18);
            this.pnlOpsPeriod.Controls.Add(this.label15);
            this.pnlOpsPeriod.Controls.Add(this.datOpsEnd);
            this.pnlOpsPeriod.Controls.Add(this.datOpsStart);
            this.pnlOpsPeriod.Controls.Add(this.numOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.label1);
            this.pnlOpsPeriod.Name = "pnlOpsPeriod";
            // 
            // btnCloseOpPeriod
            // 
            resources.ApplyResources(this.btnCloseOpPeriod, "btnCloseOpPeriod");
            this.btnCloseOpPeriod.Name = "btnCloseOpPeriod";
            this.btnCloseOpPeriod.TabStop = false;
            this.btnCloseOpPeriod.UseVisualStyleBackColor = true;
            this.btnCloseOpPeriod.Click += new System.EventHandler(this.btnCloseOpPeriod_Click);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // datOpsEnd
            // 
            resources.ApplyResources(this.datOpsEnd, "datOpsEnd");
            this.datOpsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsEnd.Name = "datOpsEnd";
            this.datOpsEnd.Leave += new System.EventHandler(this.datOpsEnd_Leave);
            // 
            // datOpsStart
            // 
            resources.ApplyResources(this.datOpsStart, "datOpsStart");
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsStart.Name = "datOpsStart";
            this.datOpsStart.Leave += new System.EventHandler(this.datOpsStart_Leave);
            // 
            // numOpPeriod
            // 
            resources.ApplyResources(this.numOpPeriod, "numOpPeriod");
            this.numOpPeriod.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numOpPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpPeriod.Name = "numOpPeriod";
            this.numOpPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpPeriod.ValueChanged += new System.EventHandler(this.numOpPeriod_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pnlTaskInfo
            // 
            resources.ApplyResources(this.pnlTaskInfo, "pnlTaskInfo");
            this.pnlTaskInfo.BackColor = System.Drawing.Color.White;
            this.pnlTaskInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.pnlTaskInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTaskInfo_Paint);
            // 
            // txtTaskName
            // 
            resources.ApplyResources(this.txtTaskName, "txtTaskName");
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskName_Validating);
            this.txtTaskName.Child = new System.Windows.Controls.TextBox();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Name = "panel1";
            // 
            // btnOutstandingLogItems
            // 
            resources.ApplyResources(this.btnOutstandingLogItems, "btnOutstandingLogItems");
            this.btnOutstandingLogItems.Name = "btnOutstandingLogItems";
            this.btnOutstandingLogItems.TabStop = false;
            this.btnOutstandingLogItems.UseVisualStyleBackColor = true;
            this.btnOutstandingLogItems.Click += new System.EventHandler(this.btnOutstandingLogItems_Click);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // btnViewPositionLog
            // 
            resources.ApplyResources(this.btnViewPositionLog, "btnViewPositionLog");
            this.btnViewPositionLog.Name = "btnViewPositionLog";
            this.btnViewPositionLog.TabStop = false;
            this.btnViewPositionLog.UseVisualStyleBackColor = true;
            this.btnViewPositionLog.Click += new System.EventHandler(this.btnViewPositionLog_Click);
            // 
            // btnAddToPositionLog
            // 
            resources.ApplyResources(this.btnAddToPositionLog, "btnAddToPositionLog");
            this.btnAddToPositionLog.Name = "btnAddToPositionLog";
            this.btnAddToPositionLog.TabStop = false;
            this.btnAddToPositionLog.UseVisualStyleBackColor = true;
            this.btnAddToPositionLog.Click += new System.EventHandler(this.btnAddToPositionLog_Click);
            // 
            // txtTaskNumber
            // 
            resources.ApplyResources(this.txtTaskNumber, "txtTaskNumber");
            this.txtTaskNumber.Name = "txtTaskNumber";
            this.txtTaskNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaskNumber_KeyPress);
            this.txtTaskNumber.Leave += new System.EventHandler(this.txtTaskNumber_Leave);
            this.txtTaskNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtTaskNumber_Validating);
            // 
            // btnICSRoleHelp
            // 
            resources.ApplyResources(this.btnICSRoleHelp, "btnICSRoleHelp");
            this.btnICSRoleHelp.Name = "btnICSRoleHelp";
            this.btnICSRoleHelp.TabStop = false;
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
            this.cboICSRole.ValueMember = "RoleID";
            this.cboICSRole.SelectedIndexChanged += new System.EventHandler(this.cboICSRole_SelectedIndexChanged);
            this.cboICSRole.Leave += new System.EventHandler(this.cboICSRole_Leave);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // lblTaskName
            // 
            resources.ApplyResources(this.lblTaskName, "lblTaskName");
            this.lblTaskName.Name = "lblTaskName";
            // 
            // lblTaskNumber
            // 
            resources.ApplyResources(this.lblTaskNumber, "lblTaskNumber");
            this.lblTaskNumber.Name = "lblTaskNumber";
            // 
            // lblServerStatus
            // 
            resources.ApplyResources(this.lblServerStatus, "lblServerStatus");
            this.lblServerStatus.Name = "lblServerStatus";
            // 
            // lblVersionNumber
            // 
            resources.ApplyResources(this.lblVersionNumber, "lblVersionNumber");
            this.lblVersionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersionNumber.Name = "lblVersionNumber";
            // 
            // tcStatus
            // 
            resources.ApplyResources(this.tcStatus, "tcStatus");
            this.tcStatus.Controls.Add(this.tpMembersOnTask);
            this.tcStatus.Controls.Add(this.tpEquipment);
            this.tcStatus.Controls.Add(this.tpNetworkLog);
            this.tcStatus.ImageList = this.imglTabIcons;
            this.tcStatus.Multiline = true;
            this.tcStatus.Name = "tcStatus";
            this.tcStatus.SelectedIndex = 0;
            // 
            // tpMembersOnTask
            // 
            resources.ApplyResources(this.tpMembersOnTask, "tpMembersOnTask");
            this.tpMembersOnTask.Controls.Add(this.splitContainer4);
            this.tpMembersOnTask.Name = "tpMembersOnTask";
            this.tpMembersOnTask.UseVisualStyleBackColor = true;
            // 
            // tpEquipment
            // 
            this.tpEquipment.Controls.Add(this.splitContainer5);
            resources.ApplyResources(this.tpEquipment, "tpEquipment");
            this.tpEquipment.Name = "tpEquipment";
            this.tpEquipment.UseVisualStyleBackColor = true;
            // 
            // tpNetworkLog
            // 
            this.tpNetworkLog.Controls.Add(this.txtNetworkLog);
            resources.ApplyResources(this.tpNetworkLog, "tpNetworkLog");
            this.tpNetworkLog.Name = "tpNetworkLog";
            this.tpNetworkLog.UseVisualStyleBackColor = true;
            // 
            // txtNetworkLog
            // 
            resources.ApplyResources(this.txtNetworkLog, "txtNetworkLog");
            this.txtNetworkLog.Name = "txtNetworkLog";
            this.txtNetworkLog.ReadOnly = true;
            // 
            // imglTabIcons
            // 
            this.imglTabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTabIcons.ImageStream")));
            this.imglTabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imglTabIcons.Images.SetKeyName(0, "glyphicons-basic-532-user-family.png");
            this.imglTabIcons.Images.SetKeyName(1, "glyphicons-basic-849-computer-network.png");
            this.imglTabIcons.Images.SetKeyName(2, "glyphicons-basic-876-palette-package.png");
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
            // 
            // btnCancelInternetSync
            // 
            resources.ApplyResources(this.btnCancelInternetSync, "btnCancelInternetSync");
            this.btnCancelInternetSync.Name = "btnCancelInternetSync";
            this.btnCancelInternetSync.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label22.Name = "label22";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Name = "label21";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
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
            // 
            // lblNetworkShareMoreInfoMsg
            // 
            resources.ApplyResources(this.lblNetworkShareMoreInfoMsg, "lblNetworkShareMoreInfoMsg");
            this.lblNetworkShareMoreInfoMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNetworkShareMoreInfoMsg.Name = "lblNetworkShareMoreInfoMsg";
            // 
            // btnNetworkSyncDone
            // 
            resources.ApplyResources(this.btnNetworkSyncDone, "btnNetworkSyncDone");
            this.btnNetworkSyncDone.Name = "btnNetworkSyncDone";
            this.btnNetworkSyncDone.UseVisualStyleBackColor = true;
            this.btnNetworkSyncDone.Click += new System.EventHandler(this.btnNetworkSyncDone_Click);
            // 
            // pbNetworkSyncInProgress
            // 
            resources.ApplyResources(this.pbNetworkSyncInProgress, "pbNetworkSyncInProgress");
            this.pbNetworkSyncInProgress.Maximum = 4;
            this.pbNetworkSyncInProgress.Name = "pbNetworkSyncInProgress";
            this.pbNetworkSyncInProgress.Step = 1;
            // 
            // btnCloseNetworkSyncInProgress
            // 
            resources.ApplyResources(this.btnCloseNetworkSyncInProgress, "btnCloseNetworkSyncInProgress");
            this.btnCloseNetworkSyncInProgress.Name = "btnCloseNetworkSyncInProgress";
            this.btnCloseNetworkSyncInProgress.UseVisualStyleBackColor = true;
            this.btnCloseNetworkSyncInProgress.Click += new System.EventHandler(this.btnCloseNetworkSyncInProgress_Click);
            // 
            // lblNetworkSyncStatus
            // 
            resources.ApplyResources(this.lblNetworkSyncStatus, "lblNetworkSyncStatus");
            this.lblNetworkSyncStatus.ForeColor = System.Drawing.Color.White;
            this.lblNetworkSyncStatus.Name = "lblNetworkSyncStatus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.iAPToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.logisticsToolStripMenuItem,
            this.planningToolStripMenuItem,
            this.adminFinanceToolStripMenuItem,
            this.networkInternetToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.tESTToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newIncidentToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentIncidentsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.browseToIncidentFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newIncidentToolStripMenuItem
            // 
            this.newIncidentToolStripMenuItem.Name = "newIncidentToolStripMenuItem";
            resources.ApplyResources(this.newIncidentToolStripMenuItem, "newIncidentToolStripMenuItem");
            this.newIncidentToolStripMenuItem.Click += new System.EventHandler(this.newIncidentToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // recentIncidentsToolStripMenuItem
            // 
            this.recentIncidentsToolStripMenuItem.Name = "recentIncidentsToolStripMenuItem";
            resources.ApplyResources(this.recentIncidentsToolStripMenuItem, "recentIncidentsToolStripMenuItem");
            this.recentIncidentsToolStripMenuItem.Click += new System.EventHandler(this.recentIncidentsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // browseToIncidentFolderToolStripMenuItem
            // 
            resources.ApplyResources(this.browseToIncidentFolderToolStripMenuItem, "browseToIncidentFolderToolStripMenuItem");
            this.browseToIncidentFolderToolStripMenuItem.Name = "browseToIncidentFolderToolStripMenuItem";
            this.browseToIncidentFolderToolStripMenuItem.Click += new System.EventHandler(this.browseToIncidentFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
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
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_137_cogwheel;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // savedValuesToolStripMenuItem
            // 
            this.savedValuesToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.savedValuesToolStripMenuItem, "savedValuesToolStripMenuItem");
            this.savedValuesToolStripMenuItem.Name = "savedValuesToolStripMenuItem";
            // 
            // aircraftToolStripMenuItem
            // 
            this.aircraftToolStripMenuItem.Name = "aircraftToolStripMenuItem";
            resources.ApplyResources(this.aircraftToolStripMenuItem, "aircraftToolStripMenuItem");
            this.aircraftToolStripMenuItem.Click += new System.EventHandler(this.aircraftToolStripMenuItem_Click);
            // 
            // communicationsSystemsToolStripMenuItem
            // 
            this.communicationsSystemsToolStripMenuItem.Name = "communicationsSystemsToolStripMenuItem";
            resources.ApplyResources(this.communicationsSystemsToolStripMenuItem, "communicationsSystemsToolStripMenuItem");
            this.communicationsSystemsToolStripMenuItem.Click += new System.EventHandler(this.communicationsSystemsToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            resources.ApplyResources(this.contactsToolStripMenuItem, "contactsToolStripMenuItem");
            this.contactsToolStripMenuItem.Click += new System.EventHandler(this.contactsToolStripMenuItem_Click);
            // 
            // hospitalsToolStripMenuItem
            // 
            this.hospitalsToolStripMenuItem.Name = "hospitalsToolStripMenuItem";
            resources.ApplyResources(this.hospitalsToolStripMenuItem, "hospitalsToolStripMenuItem");
            this.hospitalsToolStripMenuItem.Click += new System.EventHandler(this.hospitalsToolStripMenuItem_Click);
            // 
            // medivacServicesToolStripMenuItem
            // 
            this.medivacServicesToolStripMenuItem.Name = "medivacServicesToolStripMenuItem";
            resources.ApplyResources(this.medivacServicesToolStripMenuItem, "medivacServicesToolStripMenuItem");
            this.medivacServicesToolStripMenuItem.Click += new System.EventHandler(this.medivacServicesToolStripMenuItem_Click);
            // 
            // teamMembersToolStripMenuItem
            // 
            this.teamMembersToolStripMenuItem.Name = "teamMembersToolStripMenuItem";
            resources.ApplyResources(this.teamMembersToolStripMenuItem, "teamMembersToolStripMenuItem");
            this.teamMembersToolStripMenuItem.Click += new System.EventHandler(this.teamMembersToolStripMenuItem_Click);
            // 
            // vehiclesToolStripMenuItem
            // 
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            resources.ApplyResources(this.vehiclesToolStripMenuItem, "vehiclesToolStripMenuItem");
            this.vehiclesToolStripMenuItem.Click += new System.EventHandler(this.vehiclesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // templatesToolStripMenuItem
            // 
            resources.ApplyResources(this.templatesToolStripMenuItem, "templatesToolStripMenuItem");
            this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
            // 
            // incidentObjectivesToolStripMenuItem
            // 
            this.incidentObjectivesToolStripMenuItem.Name = "incidentObjectivesToolStripMenuItem";
            resources.ApplyResources(this.incidentObjectivesToolStripMenuItem, "incidentObjectivesToolStripMenuItem");
            this.incidentObjectivesToolStripMenuItem.Click += new System.EventHandler(this.incidentObjectivesToolStripMenuItem_Click);
            // 
            // safetyNotesToolStripMenuItem
            // 
            this.safetyNotesToolStripMenuItem.Name = "safetyNotesToolStripMenuItem";
            resources.ApplyResources(this.safetyNotesToolStripMenuItem, "safetyNotesToolStripMenuItem");
            this.safetyNotesToolStripMenuItem.Click += new System.EventHandler(this.safetyNotesToolStripMenuItem_Click);
            // 
            // iAPToolStripMenuItem
            // 
            this.iAPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incidentActionPlanToolStripMenuItem,
            this.incidentObjectivesICS202ToolStripMenuItem,
            this.organizationChartICS207ToolStripMenuItem,
            this.teamAssignmentsICS204ToolStripMenuItem,
            this.communicationsPlanICS205ToolStripMenuItem,
            this.medicalPlanICS206ToolStripMenuItem,
            this.safetyMessageICS208ToolStripMenuItem,
            this.airOperationsSummaryICS220ToolStripMenuItem,
            this.printTheIncidentActionPlanToolStripMenuItem,
            this.toolStripSeparator5,
            this.additionalDocumentsToolStripMenuItem,
            this.communicationsListICS205AToolStripMenuItem,
            this.generalMessageICS213ToolStripMenuItem,
            this.toolStripSeparator9,
            this.printingToolStripMenuItem,
            this.printThisOperationalPeriodToolStripMenuItem,
            this.printThisIncidentToDateToolStripMenuItem});
            this.iAPToolStripMenuItem.Name = "iAPToolStripMenuItem";
            resources.ApplyResources(this.iAPToolStripMenuItem, "iAPToolStripMenuItem");
            // 
            // incidentActionPlanToolStripMenuItem
            // 
            resources.ApplyResources(this.incidentActionPlanToolStripMenuItem, "incidentActionPlanToolStripMenuItem");
            this.incidentActionPlanToolStripMenuItem.Name = "incidentActionPlanToolStripMenuItem";
            // 
            // incidentObjectivesICS202ToolStripMenuItem
            // 
            this.incidentObjectivesICS202ToolStripMenuItem.Name = "incidentObjectivesICS202ToolStripMenuItem";
            resources.ApplyResources(this.incidentObjectivesICS202ToolStripMenuItem, "incidentObjectivesICS202ToolStripMenuItem");
            this.incidentObjectivesICS202ToolStripMenuItem.Click += new System.EventHandler(this.incidentObjectivesICS202ToolStripMenuItem_Click);
            // 
            // organizationChartICS207ToolStripMenuItem
            // 
            this.organizationChartICS207ToolStripMenuItem.Name = "organizationChartICS207ToolStripMenuItem";
            resources.ApplyResources(this.organizationChartICS207ToolStripMenuItem, "organizationChartICS207ToolStripMenuItem");
            this.organizationChartICS207ToolStripMenuItem.Click += new System.EventHandler(this.organizationChartICS207ToolStripMenuItem_Click);
            // 
            // teamAssignmentsICS204ToolStripMenuItem
            // 
            this.teamAssignmentsICS204ToolStripMenuItem.Name = "teamAssignmentsICS204ToolStripMenuItem";
            resources.ApplyResources(this.teamAssignmentsICS204ToolStripMenuItem, "teamAssignmentsICS204ToolStripMenuItem");
            this.teamAssignmentsICS204ToolStripMenuItem.Click += new System.EventHandler(this.teamAssignmentsICS204ToolStripMenuItem_Click);
            // 
            // communicationsPlanICS205ToolStripMenuItem
            // 
            this.communicationsPlanICS205ToolStripMenuItem.Name = "communicationsPlanICS205ToolStripMenuItem";
            resources.ApplyResources(this.communicationsPlanICS205ToolStripMenuItem, "communicationsPlanICS205ToolStripMenuItem");
            this.communicationsPlanICS205ToolStripMenuItem.Click += new System.EventHandler(this.communicationsPlanICS205ToolStripMenuItem_Click);
            // 
            // medicalPlanICS206ToolStripMenuItem
            // 
            this.medicalPlanICS206ToolStripMenuItem.Name = "medicalPlanICS206ToolStripMenuItem";
            resources.ApplyResources(this.medicalPlanICS206ToolStripMenuItem, "medicalPlanICS206ToolStripMenuItem");
            this.medicalPlanICS206ToolStripMenuItem.Click += new System.EventHandler(this.medicalPlanICS206ToolStripMenuItem_Click);
            // 
            // safetyMessageICS208ToolStripMenuItem
            // 
            this.safetyMessageICS208ToolStripMenuItem.Name = "safetyMessageICS208ToolStripMenuItem";
            resources.ApplyResources(this.safetyMessageICS208ToolStripMenuItem, "safetyMessageICS208ToolStripMenuItem");
            this.safetyMessageICS208ToolStripMenuItem.Click += new System.EventHandler(this.safetyMessageICS208ToolStripMenuItem_Click);
            // 
            // airOperationsSummaryICS220ToolStripMenuItem
            // 
            this.airOperationsSummaryICS220ToolStripMenuItem.Name = "airOperationsSummaryICS220ToolStripMenuItem";
            resources.ApplyResources(this.airOperationsSummaryICS220ToolStripMenuItem, "airOperationsSummaryICS220ToolStripMenuItem");
            this.airOperationsSummaryICS220ToolStripMenuItem.Click += new System.EventHandler(this.airOperationsSummaryICS220ToolStripMenuItem_Click);
            // 
            // printTheIncidentActionPlanToolStripMenuItem
            // 
            this.printTheIncidentActionPlanToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printTheIncidentActionPlanToolStripMenuItem.Name = "printTheIncidentActionPlanToolStripMenuItem";
            resources.ApplyResources(this.printTheIncidentActionPlanToolStripMenuItem, "printTheIncidentActionPlanToolStripMenuItem");
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // additionalDocumentsToolStripMenuItem
            // 
            resources.ApplyResources(this.additionalDocumentsToolStripMenuItem, "additionalDocumentsToolStripMenuItem");
            this.additionalDocumentsToolStripMenuItem.Name = "additionalDocumentsToolStripMenuItem";
            // 
            // communicationsListICS205AToolStripMenuItem
            // 
            this.communicationsListICS205AToolStripMenuItem.Name = "communicationsListICS205AToolStripMenuItem";
            resources.ApplyResources(this.communicationsListICS205AToolStripMenuItem, "communicationsListICS205AToolStripMenuItem");
            this.communicationsListICS205AToolStripMenuItem.Click += new System.EventHandler(this.communicationsListICS205AToolStripMenuItem_Click);
            // 
            // generalMessageICS213ToolStripMenuItem
            // 
            this.generalMessageICS213ToolStripMenuItem.Name = "generalMessageICS213ToolStripMenuItem";
            resources.ApplyResources(this.generalMessageICS213ToolStripMenuItem, "generalMessageICS213ToolStripMenuItem");
            this.generalMessageICS213ToolStripMenuItem.Click += new System.EventHandler(this.generalMessageICS213ToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // printingToolStripMenuItem
            // 
            resources.ApplyResources(this.printingToolStripMenuItem, "printingToolStripMenuItem");
            this.printingToolStripMenuItem.Name = "printingToolStripMenuItem";
            // 
            // printThisOperationalPeriodToolStripMenuItem
            // 
            this.printThisOperationalPeriodToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printThisOperationalPeriodToolStripMenuItem.Name = "printThisOperationalPeriodToolStripMenuItem";
            resources.ApplyResources(this.printThisOperationalPeriodToolStripMenuItem, "printThisOperationalPeriodToolStripMenuItem");
            this.printThisOperationalPeriodToolStripMenuItem.Click += new System.EventHandler(this.printThisOperationalPeriodToolStripMenuItem_Click);
            // 
            // printThisIncidentToDateToolStripMenuItem
            // 
            this.printThisIncidentToDateToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printThisIncidentToDateToolStripMenuItem.Name = "printThisIncidentToDateToolStripMenuItem";
            resources.ApplyResources(this.printThisIncidentToDateToolStripMenuItem, "printThisIncidentToDateToolStripMenuItem");
            this.printThisIncidentToDateToolStripMenuItem.Click += new System.EventHandler(this.printThisIncidentToDateToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionLogToolStripMenuItem,
            this.toolStripSeparator8,
            this.teamAssignmentsICS204ToolStripMenuItem1});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            resources.ApplyResources(this.operationsToolStripMenuItem, "operationsToolStripMenuItem");
            // 
            // positionLogToolStripMenuItem
            // 
            this.positionLogToolStripMenuItem.Name = "positionLogToolStripMenuItem";
            resources.ApplyResources(this.positionLogToolStripMenuItem, "positionLogToolStripMenuItem");
            this.positionLogToolStripMenuItem.Click += new System.EventHandler(this.positionLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // teamAssignmentsICS204ToolStripMenuItem1
            // 
            this.teamAssignmentsICS204ToolStripMenuItem1.Name = "teamAssignmentsICS204ToolStripMenuItem1";
            resources.ApplyResources(this.teamAssignmentsICS204ToolStripMenuItem1, "teamAssignmentsICS204ToolStripMenuItem1");
            this.teamAssignmentsICS204ToolStripMenuItem1.Click += new System.EventHandler(this.teamAssignmentsICS204ToolStripMenuItem1_Click);
            // 
            // logisticsToolStripMenuItem
            // 
            this.logisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionLogToolStripMenuItem1,
            this.toolStripSeparator7,
            this.memberStatusToolStripMenuItem,
            this.additionalContactsToolStripMenuItem});
            this.logisticsToolStripMenuItem.Name = "logisticsToolStripMenuItem";
            resources.ApplyResources(this.logisticsToolStripMenuItem, "logisticsToolStripMenuItem");
            // 
            // positionLogToolStripMenuItem1
            // 
            this.positionLogToolStripMenuItem1.Name = "positionLogToolStripMenuItem1";
            resources.ApplyResources(this.positionLogToolStripMenuItem1, "positionLogToolStripMenuItem1");
            this.positionLogToolStripMenuItem1.Click += new System.EventHandler(this.positionLogToolStripMenuItem1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // memberStatusToolStripMenuItem
            // 
            this.memberStatusToolStripMenuItem.Name = "memberStatusToolStripMenuItem";
            resources.ApplyResources(this.memberStatusToolStripMenuItem, "memberStatusToolStripMenuItem");
            this.memberStatusToolStripMenuItem.Click += new System.EventHandler(this.memberStatusToolStripMenuItem_Click);
            // 
            // additionalContactsToolStripMenuItem
            // 
            this.additionalContactsToolStripMenuItem.Name = "additionalContactsToolStripMenuItem";
            resources.ApplyResources(this.additionalContactsToolStripMenuItem, "additionalContactsToolStripMenuItem");
            this.additionalContactsToolStripMenuItem.Click += new System.EventHandler(this.additionalContactsToolStripMenuItem_Click);
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionLogToolStripMenuItem2,
            this.toolStripSeparator6,
            this.notesToolStripMenuItem});
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            resources.ApplyResources(this.planningToolStripMenuItem, "planningToolStripMenuItem");
            // 
            // positionLogToolStripMenuItem2
            // 
            this.positionLogToolStripMenuItem2.Name = "positionLogToolStripMenuItem2";
            resources.ApplyResources(this.positionLogToolStripMenuItem2, "positionLogToolStripMenuItem2");
            this.positionLogToolStripMenuItem2.Click += new System.EventHandler(this.positionLogToolStripMenuItem2_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // notesToolStripMenuItem
            // 
            this.notesToolStripMenuItem.Name = "notesToolStripMenuItem";
            resources.ApplyResources(this.notesToolStripMenuItem, "notesToolStripMenuItem");
            this.notesToolStripMenuItem.Click += new System.EventHandler(this.notesToolStripMenuItem_Click);
            // 
            // adminFinanceToolStripMenuItem
            // 
            this.adminFinanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionLogToolStripMenuItem3});
            this.adminFinanceToolStripMenuItem.Name = "adminFinanceToolStripMenuItem";
            resources.ApplyResources(this.adminFinanceToolStripMenuItem, "adminFinanceToolStripMenuItem");
            // 
            // positionLogToolStripMenuItem3
            // 
            this.positionLogToolStripMenuItem3.Name = "positionLogToolStripMenuItem3";
            resources.ApplyResources(this.positionLogToolStripMenuItem3, "positionLogToolStripMenuItem3");
            this.positionLogToolStripMenuItem3.Click += new System.EventHandler(this.positionLogToolStripMenuItem3_Click);
            // 
            // networkInternetToolStripMenuItem
            // 
            this.networkInternetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localNetworkSharingSyncToolStripMenuItem,
            this.requestIncidentFromServerToolStripMenuItem,
            this.toolStripSeparator11,
            this.internetSyncToolStripMenuItem,
            this.toolStripSeparator12,
            this.requestOptionsFromServerToolStripMenuItem,
            this.networkTestToolStripMenuItem});
            this.networkInternetToolStripMenuItem.Name = "networkInternetToolStripMenuItem";
            resources.ApplyResources(this.networkInternetToolStripMenuItem, "networkInternetToolStripMenuItem");
            // 
            // localNetworkSharingSyncToolStripMenuItem
            // 
            this.localNetworkSharingSyncToolStripMenuItem.Name = "localNetworkSharingSyncToolStripMenuItem";
            resources.ApplyResources(this.localNetworkSharingSyncToolStripMenuItem, "localNetworkSharingSyncToolStripMenuItem");
            this.localNetworkSharingSyncToolStripMenuItem.Click += new System.EventHandler(this.localNetworkSharingSyncToolStripMenuItem_Click);
            // 
            // requestIncidentFromServerToolStripMenuItem
            // 
            this.requestIncidentFromServerToolStripMenuItem.Name = "requestIncidentFromServerToolStripMenuItem";
            resources.ApplyResources(this.requestIncidentFromServerToolStripMenuItem, "requestIncidentFromServerToolStripMenuItem");
            this.requestIncidentFromServerToolStripMenuItem.Click += new System.EventHandler(this.requestIncidentFromServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // internetSyncToolStripMenuItem
            // 
            this.internetSyncToolStripMenuItem.Name = "internetSyncToolStripMenuItem";
            resources.ApplyResources(this.internetSyncToolStripMenuItem, "internetSyncToolStripMenuItem");
            this.internetSyncToolStripMenuItem.Click += new System.EventHandler(this.internetSyncToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // requestOptionsFromServerToolStripMenuItem
            // 
            this.requestOptionsFromServerToolStripMenuItem.Name = "requestOptionsFromServerToolStripMenuItem";
            resources.ApplyResources(this.requestOptionsFromServerToolStripMenuItem, "requestOptionsFromServerToolStripMenuItem");
            this.requestOptionsFromServerToolStripMenuItem.Click += new System.EventHandler(this.requestOptionsFromServerToolStripMenuItem_Click);
            // 
            // networkTestToolStripMenuItem
            // 
            this.networkTestToolStripMenuItem.Name = "networkTestToolStripMenuItem";
            resources.ApplyResources(this.networkTestToolStripMenuItem, "networkTestToolStripMenuItem");
            this.networkTestToolStripMenuItem.Click += new System.EventHandler(this.networkTestToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem,
            this.aboutCIAPPToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            resources.ApplyResources(this.supportToolStripMenuItem, "supportToolStripMenuItem");
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.supportToolStripMenuItem_Click);
            // 
            // aboutCIAPPToolStripMenuItem
            // 
            this.aboutCIAPPToolStripMenuItem.Name = "aboutCIAPPToolStripMenuItem";
            resources.ApplyResources(this.aboutCIAPPToolStripMenuItem, "aboutCIAPPToolStripMenuItem");
            this.aboutCIAPPToolStripMenuItem.Click += new System.EventHandler(this.aboutCIAPPToolStripMenuItem_Click);
            // 
            // tESTToolStripMenuItem
            // 
            this.tESTToolStripMenuItem.BackColor = System.Drawing.Color.Fuchsia;
            this.tESTToolStripMenuItem.Name = "tESTToolStripMenuItem";
            resources.ApplyResources(this.tESTToolStripMenuItem, "tESTToolStripMenuItem");
            this.tESTToolStripMenuItem.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // picOrgLogo
            // 
            this.picOrgLogo.Image = global::Wildfire_ICS_Assist.Properties.Resources.CIAPP_LOGO_v3_transparent;
            resources.ApplyResources(this.picOrgLogo, "picOrgLogo");
            this.picOrgLogo.Name = "picOrgLogo";
            this.picOrgLogo.TabStop = false;
            this.picOrgLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ofdOpenTaskFile
            // 
            this.ofdOpenTaskFile.DefaultExt = "xml";
            resources.ApplyResources(this.ofdOpenTaskFile, "ofdOpenTaskFile");
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
            // cpOtherTools
            // 
            this.cpOtherTools.BackColor = System.Drawing.Color.White;
            this.cpOtherTools.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpOtherTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpOtherTools.CollapsedHeight = 40;
            this.cpOtherTools.CollapsedWidth = 349;
            this.cpOtherTools.CollapseLeft = true;
            this.cpOtherTools.Controls.Add(this.btnGeneralMessage);
            this.cpOtherTools.Controls.Add(this.btnReplacementResources);
            this.cpOtherTools.Controls.Add(this.btnAdditionalContacts);
            this.cpOtherTools.Controls.Add(this.btnNotes);
            this.cpOtherTools.Controls.Add(this.btnShowResources);
            this.cpOtherTools.CurrentlyCollapsed = false;
            this.cpOtherTools.ExpandedHeight = 180;
            this.cpOtherTools.ExpandedWidth = 349;
            this.cpOtherTools.ExpandUp = false;
            resources.ApplyResources(this.cpOtherTools, "cpOtherTools");
            this.cpOtherTools.Name = "cpOtherTools";
            this.cpOtherTools.TitleText = "Other Tools";
            // 
            // btnGeneralMessage
            // 
            resources.ApplyResources(this.btnGeneralMessage, "btnGeneralMessage");
            this.btnGeneralMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnGeneralMessage.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_11_envelope;
            this.btnGeneralMessage.Name = "btnGeneralMessage";
            this.btnGeneralMessage.UseVisualStyleBackColor = true;
            this.btnGeneralMessage.Click += new System.EventHandler(this.btnGeneralMessage_Click);
            // 
            // btnReplacementResources
            // 
            resources.ApplyResources(this.btnReplacementResources, "btnReplacementResources");
            this.btnReplacementResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnReplacementResources.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_46_calendar;
            this.btnReplacementResources.Name = "btnReplacementResources";
            this.btnReplacementResources.UseVisualStyleBackColor = true;
            this.btnReplacementResources.Click += new System.EventHandler(this.btnReplacementResources_Click);
            // 
            // btnAdditionalContacts
            // 
            resources.ApplyResources(this.btnAdditionalContacts, "btnAdditionalContacts");
            this.btnAdditionalContacts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAdditionalContacts.Name = "btnAdditionalContacts";
            this.btnAdditionalContacts.UseVisualStyleBackColor = true;
            this.btnAdditionalContacts.Click += new System.EventHandler(this.btnAdditionalContacts_Click);
            // 
            // btnNotes
            // 
            resources.ApplyResources(this.btnNotes, "btnNotes");
            this.btnNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.UseVisualStyleBackColor = true;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnShowResources
            // 
            resources.ApplyResources(this.btnShowResources, "btnShowResources");
            this.btnShowResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnShowResources.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_893_user_worker;
            this.btnShowResources.Name = "btnShowResources";
            this.btnShowResources.UseVisualStyleBackColor = true;
            this.btnShowResources.Click += new System.EventHandler(this.btnShowResources_Click);
            // 
            // cpIncidentActionPlan
            // 
            this.cpIncidentActionPlan.BackColor = System.Drawing.Color.White;
            this.cpIncidentActionPlan.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpIncidentActionPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpIncidentActionPlan.CollapsedHeight = 40;
            this.cpIncidentActionPlan.CollapsedWidth = 485;
            this.cpIncidentActionPlan.CollapseLeft = true;
            this.cpIncidentActionPlan.Controls.Add(this.btnAssignmentList);
            this.cpIncidentActionPlan.Controls.Add(this.btnAirOpsSummary);
            this.cpIncidentActionPlan.Controls.Add(this.btnSafetyPlans);
            this.cpIncidentActionPlan.Controls.Add(this.btnIncidentObjectives);
            this.cpIncidentActionPlan.Controls.Add(this.btnMedicalPlan);
            this.cpIncidentActionPlan.Controls.Add(this.btnPrintIAP);
            this.cpIncidentActionPlan.Controls.Add(this.btnPrintOrgChart);
            this.cpIncidentActionPlan.Controls.Add(this.btnCommsPlan);
            this.cpIncidentActionPlan.CurrentlyCollapsed = false;
            this.cpIncidentActionPlan.ExpandedHeight = 331;
            this.cpIncidentActionPlan.ExpandedWidth = 722;
            this.cpIncidentActionPlan.ExpandUp = false;
            resources.ApplyResources(this.cpIncidentActionPlan, "cpIncidentActionPlan");
            this.cpIncidentActionPlan.Name = "cpIncidentActionPlan";
            this.cpIncidentActionPlan.TitleText = "Incident Action Plan";
            // 
            // btnAssignmentList
            // 
            resources.ApplyResources(this.btnAssignmentList, "btnAssignmentList");
            this.btnAssignmentList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAssignmentList.Name = "btnAssignmentList";
            this.btnAssignmentList.UseVisualStyleBackColor = true;
            this.btnAssignmentList.Click += new System.EventHandler(this.btnAssignmentList_Click);
            // 
            // btnAirOpsSummary
            // 
            resources.ApplyResources(this.btnAirOpsSummary, "btnAirOpsSummary");
            this.btnAirOpsSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnAirOpsSummary.Name = "btnAirOpsSummary";
            this.btnAirOpsSummary.UseVisualStyleBackColor = true;
            this.btnAirOpsSummary.Click += new System.EventHandler(this.btnAirOpsSummary_Click);
            // 
            // btnSafetyPlans
            // 
            resources.ApplyResources(this.btnSafetyPlans, "btnSafetyPlans");
            this.btnSafetyPlans.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnSafetyPlans.Name = "btnSafetyPlans";
            this.btnSafetyPlans.UseVisualStyleBackColor = true;
            this.btnSafetyPlans.Click += new System.EventHandler(this.btnSafetyPlans_Click);
            // 
            // btnIncidentObjectives
            // 
            resources.ApplyResources(this.btnIncidentObjectives, "btnIncidentObjectives");
            this.btnIncidentObjectives.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnIncidentObjectives.Name = "btnIncidentObjectives";
            this.btnIncidentObjectives.UseVisualStyleBackColor = true;
            this.btnIncidentObjectives.Click += new System.EventHandler(this.btnIncidentObjectives_Click);
            // 
            // btnMedicalPlan
            // 
            resources.ApplyResources(this.btnMedicalPlan, "btnMedicalPlan");
            this.btnMedicalPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnMedicalPlan.Name = "btnMedicalPlan";
            this.btnMedicalPlan.UseVisualStyleBackColor = true;
            this.btnMedicalPlan.Click += new System.EventHandler(this.btnMedicalPlan_Click);
            // 
            // btnPrintIAP
            // 
            resources.ApplyResources(this.btnPrintIAP, "btnPrintIAP");
            this.btnPrintIAP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnPrintIAP.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrintIAP.Name = "btnPrintIAP";
            this.btnPrintIAP.UseVisualStyleBackColor = true;
            this.btnPrintIAP.Click += new System.EventHandler(this.btnPrintIAP_Click);
            // 
            // btnPrintOrgChart
            // 
            resources.ApplyResources(this.btnPrintOrgChart, "btnPrintOrgChart");
            this.btnPrintOrgChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnPrintOrgChart.Name = "btnPrintOrgChart";
            this.btnPrintOrgChart.UseVisualStyleBackColor = true;
            this.btnPrintOrgChart.Click += new System.EventHandler(this.btnPrintOrgChart_Click);
            // 
            // btnCommsPlan
            // 
            resources.ApplyResources(this.btnCommsPlan, "btnCommsPlan");
            this.btnCommsPlan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnCommsPlan.Name = "btnCommsPlan";
            this.btnCommsPlan.UseVisualStyleBackColor = true;
            this.btnCommsPlan.Click += new System.EventHandler(this.btnCommsPlan_Click);
            // 
            // IncidentDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.cpOtherTools);
            this.Controls.Add(this.cpIncidentActionPlan);
            this.Controls.Add(this.picOrgLogo);
            this.Controls.Add(this.pnlInternetSyncStart);
            this.Controls.Add(this.pnlNetworkSyncInProgress);
            this.Controls.Add(this.pnlOpsPeriod);
            this.Controls.Add(this.pnlTaskInfo);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.tcStatus);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IncidentDetailsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IncidentDetailsForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IncidentDetailsForm_FormClosed);
            this.Load += new System.EventHandler(this.IncidentDetailsForm_Load);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembersOnTask)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskEquipment)).EndInit();
            this.pnlOpsPeriod.ResumeLayout(false);
            this.pnlOpsPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).EndInit();
            this.pnlTaskInfo.ResumeLayout(false);
            this.pnlTaskInfo.PerformLayout();
            this.tcStatus.ResumeLayout(false);
            this.tpMembersOnTask.ResumeLayout(false);
            this.tpEquipment.ResumeLayout(false);
            this.tpNetworkLog.ResumeLayout(false);
            this.tpNetworkLog.PerformLayout();
            this.pnlInternetSyncStart.ResumeLayout(false);
            this.pnlNetworkSyncInProgress.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOrgLogo)).EndInit();
            this.cpOtherTools.ResumeLayout(false);
            this.cpIncidentActionPlan.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOpsPeriod;
        private System.Windows.Forms.Button btnCloseOpPeriod;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker datOpsEnd;
        private System.Windows.Forms.DateTimePicker datOpsStart;
        private System.Windows.Forms.NumericUpDown numOpPeriod;
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
        private System.Windows.Forms.TabControl tcStatus;
        private System.Windows.Forms.TabPage tpMembersOnTask;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvMembersOnTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberSARGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSignInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignmentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberAssignmentStatus;
        private System.Windows.Forms.Button btnAddAMember;
        private System.Windows.Forms.Button btnBulkSignIn;
        private System.Windows.Forms.Button btnMembersOnTaskNewWindow;
        private System.Windows.Forms.TabPage tpEquipment;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.DataGridView dgvTaskEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipmentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee;
        private System.Windows.Forms.Button btnAssignEquipment;
        private System.Windows.Forms.Button btnViewEquipment;
        private System.Windows.Forms.Button btnReturnEquipment;
        private System.Windows.Forms.TabPage tpNetworkLog;
        private System.Windows.Forms.TextBox txtNetworkLog;
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
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem positionLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionLogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem positionLogToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem safetyMessageICS208ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalMessageICS213ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem printThisOperationalPeriodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printThisIncidentToDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memberStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalContactsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminFinanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionLogToolStripMenuItem3;
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
        private System.Windows.Forms.ToolStripMenuItem teamAssignmentsICS204ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printTheIncidentActionPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Button btnShowResources;
        private SpellBox txtTaskName;
        private System.Windows.Forms.ToolStripMenuItem tESTToolStripMenuItem;
        private System.Windows.Forms.Button btnGeneralMessage;
        private System.Windows.Forms.Button btnReplacementResources;
    }
}

