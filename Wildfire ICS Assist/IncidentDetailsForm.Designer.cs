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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnOutstandingLogItems = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnViewPositionLog = new System.Windows.Forms.Button();
            this.btnAddToPositionLog = new System.Windows.Forms.Button();
            this.txtTaskNumber = new System.Windows.Forms.TextBox();
            this.btnICSRoleHelp = new System.Windows.Forms.Button();
            this.cboICSRole = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
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
            this.communicationsSystemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentObjectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForTemplateUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForAppUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCIAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlIAP = new System.Windows.Forms.Panel();
            this.lblIAP = new System.Windows.Forms.Label();
            this.btnTransportPlan = new System.Windows.Forms.Button();
            this.btnBriefings2 = new System.Windows.Forms.Button();
            this.btnExpandIAP = new System.Windows.Forms.Button();
            this.btnSafetyPlans = new System.Windows.Forms.Button();
            this.btnMedicalPlan = new System.Windows.Forms.Button();
            this.btnPrintOrgChart = new System.Windows.Forms.Button();
            this.btnCommsPlan = new System.Windows.Forms.Button();
            this.btnSubjectProfile = new System.Windows.Forms.Button();
            this.btnPrintIAP = new System.Windows.Forms.Button();
            this.btnIncidentObjectives = new System.Windows.Forms.Button();
            this.btnOpsPlan = new System.Windows.Forms.Button();
            this.pnlTeamStatus = new System.Windows.Forms.Panel();
            this.btnOpsAssignments = new System.Windows.Forms.Button();
            this.btnOpsMemberStatus = new System.Windows.Forms.Button();
            this.btnOpsDashboard = new System.Windows.Forms.Button();
            this.btnTeamStatus = new System.Windows.Forms.Button();
            this.btnExpandTeamStatus = new System.Windows.Forms.Button();
            this.btnCommsLog = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlLogistics = new System.Windows.Forms.Panel();
            this.btnLogisticsBulkSignIn = new System.Windows.Forms.Button();
            this.btnLogisticsSignIn = new System.Windows.Forms.Button();
            this.btnLogisticsMemberStatus = new System.Windows.Forms.Button();
            this.btnAdditionalContacts = new System.Windows.Forms.Button();
            this.btnMemberNeeds = new System.Windows.Forms.Button();
            this.btnEquipment = new System.Windows.Forms.Button();
            this.btnVehicles = new System.Windows.Forms.Button();
            this.btnLogisticsDashboard = new System.Windows.Forms.Button();
            this.btnExpandLogistics = new System.Windows.Forms.Button();
            this.lblLogisticsTitle = new System.Windows.Forms.Label();
            this.pnlPlanning = new System.Windows.Forms.Panel();
            this.btnPlanningAddAssignment = new System.Windows.Forms.Button();
            this.btnTeamAssignments = new System.Windows.Forms.Button();
            this.btnReflexTasking = new System.Windows.Forms.Button();
            this.btnTimeline = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnSegmentation = new System.Windows.Forms.Button();
            this.btnPlanningDashboard = new System.Windows.Forms.Button();
            this.btnAssignmentStats = new System.Windows.Forms.Button();
            this.btnClues = new System.Windows.Forms.Button();
            this.btnMattson = new System.Windows.Forms.Button();
            this.btnExpandPlanning = new System.Windows.Forms.Button();
            this.lblPlanningTitle = new System.Windows.Forms.Label();
            this.llProgramURL = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.pnlIAP.SuspendLayout();
            this.pnlTeamStatus.SuspendLayout();
            this.pnlLogistics.SuspendLayout();
            this.pnlPlanning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            dataGridViewCellStyle1.Format = "HH:mm yyyy-MMM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.colSignInTime.DefaultCellStyle = dataGridViewCellStyle1;
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
            // 
            // datOpsStart
            // 
            resources.ApplyResources(this.datOpsStart, "datOpsStart");
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsStart.Name = "datOpsStart";
            // 
            // numOpPeriod
            // 
            resources.ApplyResources(this.numOpPeriod, "numOpPeriod");
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
            this.pnlTaskInfo.Controls.Add(this.btnOutstandingLogItems);
            this.pnlTaskInfo.Controls.Add(this.label19);
            this.pnlTaskInfo.Controls.Add(this.btnViewPositionLog);
            this.pnlTaskInfo.Controls.Add(this.btnAddToPositionLog);
            this.pnlTaskInfo.Controls.Add(this.txtTaskNumber);
            this.pnlTaskInfo.Controls.Add(this.btnICSRoleHelp);
            this.pnlTaskInfo.Controls.Add(this.cboICSRole);
            this.pnlTaskInfo.Controls.Add(this.label17);
            this.pnlTaskInfo.Controls.Add(this.label16);
            this.pnlTaskInfo.Controls.Add(this.txtTaskName);
            this.pnlTaskInfo.Controls.Add(this.lblTaskName);
            this.pnlTaskInfo.Controls.Add(this.lblTaskNumber);
            this.pnlTaskInfo.Name = "pnlTaskInfo";
            // 
            // btnOutstandingLogItems
            // 
            resources.ApplyResources(this.btnOutstandingLogItems, "btnOutstandingLogItems");
            this.btnOutstandingLogItems.Name = "btnOutstandingLogItems";
            this.btnOutstandingLogItems.TabStop = false;
            this.btnOutstandingLogItems.UseVisualStyleBackColor = true;
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
            // 
            // btnAddToPositionLog
            // 
            resources.ApplyResources(this.btnAddToPositionLog, "btnAddToPositionLog");
            this.btnAddToPositionLog.Name = "btnAddToPositionLog";
            this.btnAddToPositionLog.TabStop = false;
            this.btnAddToPositionLog.UseVisualStyleBackColor = true;
            // 
            // txtTaskNumber
            // 
            resources.ApplyResources(this.txtTaskNumber, "txtTaskNumber");
            this.txtTaskNumber.Name = "txtTaskNumber";
            // 
            // btnICSRoleHelp
            // 
            resources.ApplyResources(this.btnICSRoleHelp, "btnICSRoleHelp");
            this.btnICSRoleHelp.Name = "btnICSRoleHelp";
            this.btnICSRoleHelp.TabStop = false;
            this.btnICSRoleHelp.UseVisualStyleBackColor = true;
            // 
            // cboICSRole
            // 
            resources.ApplyResources(this.cboICSRole, "cboICSRole");
            this.cboICSRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboICSRole.FormattingEnabled = true;
            this.cboICSRole.Name = "cboICSRole";
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
            // txtTaskName
            // 
            resources.ApplyResources(this.txtTaskName, "txtTaskName");
            this.txtTaskName.Name = "txtTaskName";
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
            this.pnlInternetSyncStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlInternetSyncStart.Controls.Add(this.btnCancelInternetSync);
            this.pnlInternetSyncStart.Controls.Add(this.label22);
            this.pnlInternetSyncStart.Controls.Add(this.label21);
            this.pnlInternetSyncStart.Controls.Add(this.progressBar1);
            resources.ApplyResources(this.pnlInternetSyncStart, "pnlInternetSyncStart");
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
            this.pnlNetworkSyncInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkShareMoreInfoMsg);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnNetworkSyncDone);
            this.pnlNetworkSyncInProgress.Controls.Add(this.pbNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnCloseNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkSyncStatus);
            resources.ApplyResources(this.pnlNetworkSyncInProgress, "pnlNetworkSyncInProgress");
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
            this.networkInternetToolStripMenuItem,
            this.helpToolStripMenuItem});
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
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            // 
            // recentIncidentsToolStripMenuItem
            // 
            this.recentIncidentsToolStripMenuItem.Name = "recentIncidentsToolStripMenuItem";
            resources.ApplyResources(this.recentIncidentsToolStripMenuItem, "recentIncidentsToolStripMenuItem");
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            // 
            // browseToIncidentFolderToolStripMenuItem
            // 
            this.browseToIncidentFolderToolStripMenuItem.Name = "browseToIncidentFolderToolStripMenuItem";
            resources.ApplyResources(this.browseToIncidentFolderToolStripMenuItem, "browseToIncidentFolderToolStripMenuItem");
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
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator3,
            this.savedValuesToolStripMenuItem,
            this.communicationsSystemsToolStripMenuItem,
            this.hospitalsToolStripMenuItem,
            this.contactsToolStripMenuItem,
            this.equipmentToolStripMenuItem,
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
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
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
            // communicationsSystemsToolStripMenuItem
            // 
            this.communicationsSystemsToolStripMenuItem.Name = "communicationsSystemsToolStripMenuItem";
            resources.ApplyResources(this.communicationsSystemsToolStripMenuItem, "communicationsSystemsToolStripMenuItem");
            // 
            // hospitalsToolStripMenuItem
            // 
            this.hospitalsToolStripMenuItem.Name = "hospitalsToolStripMenuItem";
            resources.ApplyResources(this.hospitalsToolStripMenuItem, "hospitalsToolStripMenuItem");
            this.hospitalsToolStripMenuItem.Click += new System.EventHandler(this.hospitalsToolStripMenuItem_Click);
            // 
            // contactsToolStripMenuItem
            // 
            this.contactsToolStripMenuItem.Name = "contactsToolStripMenuItem";
            resources.ApplyResources(this.contactsToolStripMenuItem, "contactsToolStripMenuItem");
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            resources.ApplyResources(this.equipmentToolStripMenuItem, "equipmentToolStripMenuItem");
            // 
            // teamMembersToolStripMenuItem
            // 
            this.teamMembersToolStripMenuItem.Name = "teamMembersToolStripMenuItem";
            resources.ApplyResources(this.teamMembersToolStripMenuItem, "teamMembersToolStripMenuItem");
            // 
            // vehiclesToolStripMenuItem
            // 
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            resources.ApplyResources(this.vehiclesToolStripMenuItem, "vehiclesToolStripMenuItem");
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
            // 
            // safetyNotesToolStripMenuItem
            // 
            this.safetyNotesToolStripMenuItem.Name = "safetyNotesToolStripMenuItem";
            resources.ApplyResources(this.safetyNotesToolStripMenuItem, "safetyNotesToolStripMenuItem");
            // 
            // iAPToolStripMenuItem
            // 
            this.iAPToolStripMenuItem.Name = "iAPToolStripMenuItem";
            resources.ApplyResources(this.iAPToolStripMenuItem, "iAPToolStripMenuItem");
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            resources.ApplyResources(this.operationsToolStripMenuItem, "operationsToolStripMenuItem");
            // 
            // logisticsToolStripMenuItem
            // 
            this.logisticsToolStripMenuItem.Name = "logisticsToolStripMenuItem";
            resources.ApplyResources(this.logisticsToolStripMenuItem, "logisticsToolStripMenuItem");
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            resources.ApplyResources(this.planningToolStripMenuItem, "planningToolStripMenuItem");
            // 
            // networkInternetToolStripMenuItem
            // 
            this.networkInternetToolStripMenuItem.Name = "networkInternetToolStripMenuItem";
            resources.ApplyResources(this.networkInternetToolStripMenuItem, "networkInternetToolStripMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForTemplateUpdatesToolStripMenuItem,
            this.checkForAppUpdatesToolStripMenuItem,
            this.toolStripSeparator2,
            this.supportToolStripMenuItem,
            this.aboutCIAPPToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // checkForTemplateUpdatesToolStripMenuItem
            // 
            this.checkForTemplateUpdatesToolStripMenuItem.Name = "checkForTemplateUpdatesToolStripMenuItem";
            resources.ApplyResources(this.checkForTemplateUpdatesToolStripMenuItem, "checkForTemplateUpdatesToolStripMenuItem");
            // 
            // checkForAppUpdatesToolStripMenuItem
            // 
            this.checkForAppUpdatesToolStripMenuItem.Name = "checkForAppUpdatesToolStripMenuItem";
            resources.ApplyResources(this.checkForAppUpdatesToolStripMenuItem, "checkForAppUpdatesToolStripMenuItem");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            resources.ApplyResources(this.supportToolStripMenuItem, "supportToolStripMenuItem");
            // 
            // aboutCIAPPToolStripMenuItem
            // 
            this.aboutCIAPPToolStripMenuItem.Name = "aboutCIAPPToolStripMenuItem";
            resources.ApplyResources(this.aboutCIAPPToolStripMenuItem, "aboutCIAPPToolStripMenuItem");
            this.aboutCIAPPToolStripMenuItem.Click += new System.EventHandler(this.aboutCIAPPToolStripMenuItem_Click);
            // 
            // pnlIAP
            // 
            this.pnlIAP.BackColor = System.Drawing.Color.White;
            this.pnlIAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIAP.Controls.Add(this.lblIAP);
            this.pnlIAP.Controls.Add(this.btnTransportPlan);
            this.pnlIAP.Controls.Add(this.btnBriefings2);
            this.pnlIAP.Controls.Add(this.btnExpandIAP);
            this.pnlIAP.Controls.Add(this.btnSafetyPlans);
            this.pnlIAP.Controls.Add(this.btnMedicalPlan);
            this.pnlIAP.Controls.Add(this.btnPrintOrgChart);
            this.pnlIAP.Controls.Add(this.btnCommsPlan);
            this.pnlIAP.Controls.Add(this.btnSubjectProfile);
            this.pnlIAP.Controls.Add(this.btnPrintIAP);
            this.pnlIAP.Controls.Add(this.btnIncidentObjectives);
            this.pnlIAP.Controls.Add(this.btnOpsPlan);
            resources.ApplyResources(this.pnlIAP, "pnlIAP");
            this.pnlIAP.Name = "pnlIAP";
            // 
            // lblIAP
            // 
            resources.ApplyResources(this.lblIAP, "lblIAP");
            this.lblIAP.Name = "lblIAP";
            // 
            // btnTransportPlan
            // 
            resources.ApplyResources(this.btnTransportPlan, "btnTransportPlan");
            this.btnTransportPlan.Name = "btnTransportPlan";
            this.btnTransportPlan.UseVisualStyleBackColor = true;
            // 
            // btnBriefings2
            // 
            resources.ApplyResources(this.btnBriefings2, "btnBriefings2");
            this.btnBriefings2.Name = "btnBriefings2";
            this.btnBriefings2.UseVisualStyleBackColor = true;
            // 
            // btnExpandIAP
            // 
            resources.ApplyResources(this.btnExpandIAP, "btnExpandIAP");
            this.btnExpandIAP.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandIAP.Name = "btnExpandIAP";
            this.btnExpandIAP.UseVisualStyleBackColor = false;
            // 
            // btnSafetyPlans
            // 
            resources.ApplyResources(this.btnSafetyPlans, "btnSafetyPlans");
            this.btnSafetyPlans.Name = "btnSafetyPlans";
            this.btnSafetyPlans.UseVisualStyleBackColor = true;
            // 
            // btnMedicalPlan
            // 
            resources.ApplyResources(this.btnMedicalPlan, "btnMedicalPlan");
            this.btnMedicalPlan.Name = "btnMedicalPlan";
            this.btnMedicalPlan.UseVisualStyleBackColor = true;
            // 
            // btnPrintOrgChart
            // 
            resources.ApplyResources(this.btnPrintOrgChart, "btnPrintOrgChart");
            this.btnPrintOrgChart.Name = "btnPrintOrgChart";
            this.btnPrintOrgChart.UseVisualStyleBackColor = true;
            // 
            // btnCommsPlan
            // 
            resources.ApplyResources(this.btnCommsPlan, "btnCommsPlan");
            this.btnCommsPlan.Name = "btnCommsPlan";
            this.btnCommsPlan.UseVisualStyleBackColor = true;
            // 
            // btnSubjectProfile
            // 
            resources.ApplyResources(this.btnSubjectProfile, "btnSubjectProfile");
            this.btnSubjectProfile.Name = "btnSubjectProfile";
            this.btnSubjectProfile.UseVisualStyleBackColor = true;
            // 
            // btnPrintIAP
            // 
            resources.ApplyResources(this.btnPrintIAP, "btnPrintIAP");
            this.btnPrintIAP.Name = "btnPrintIAP";
            this.btnPrintIAP.UseVisualStyleBackColor = true;
            // 
            // btnIncidentObjectives
            // 
            resources.ApplyResources(this.btnIncidentObjectives, "btnIncidentObjectives");
            this.btnIncidentObjectives.Name = "btnIncidentObjectives";
            this.btnIncidentObjectives.UseVisualStyleBackColor = true;
            // 
            // btnOpsPlan
            // 
            resources.ApplyResources(this.btnOpsPlan, "btnOpsPlan");
            this.btnOpsPlan.Name = "btnOpsPlan";
            this.btnOpsPlan.UseVisualStyleBackColor = true;
            // 
            // pnlTeamStatus
            // 
            resources.ApplyResources(this.pnlTeamStatus, "pnlTeamStatus");
            this.pnlTeamStatus.BackColor = System.Drawing.Color.White;
            this.pnlTeamStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeamStatus.Controls.Add(this.btnOpsAssignments);
            this.pnlTeamStatus.Controls.Add(this.btnOpsMemberStatus);
            this.pnlTeamStatus.Controls.Add(this.btnOpsDashboard);
            this.pnlTeamStatus.Controls.Add(this.btnTeamStatus);
            this.pnlTeamStatus.Controls.Add(this.btnExpandTeamStatus);
            this.pnlTeamStatus.Controls.Add(this.btnCommsLog);
            this.pnlTeamStatus.Controls.Add(this.label14);
            this.pnlTeamStatus.Name = "pnlTeamStatus";
            // 
            // btnOpsAssignments
            // 
            resources.ApplyResources(this.btnOpsAssignments, "btnOpsAssignments");
            this.btnOpsAssignments.Name = "btnOpsAssignments";
            this.btnOpsAssignments.UseVisualStyleBackColor = true;
            // 
            // btnOpsMemberStatus
            // 
            resources.ApplyResources(this.btnOpsMemberStatus, "btnOpsMemberStatus");
            this.btnOpsMemberStatus.Name = "btnOpsMemberStatus";
            this.btnOpsMemberStatus.UseVisualStyleBackColor = true;
            // 
            // btnOpsDashboard
            // 
            resources.ApplyResources(this.btnOpsDashboard, "btnOpsDashboard");
            this.btnOpsDashboard.Name = "btnOpsDashboard";
            this.btnOpsDashboard.UseVisualStyleBackColor = true;
            // 
            // btnTeamStatus
            // 
            resources.ApplyResources(this.btnTeamStatus, "btnTeamStatus");
            this.btnTeamStatus.Name = "btnTeamStatus";
            this.btnTeamStatus.UseVisualStyleBackColor = true;
            // 
            // btnExpandTeamStatus
            // 
            resources.ApplyResources(this.btnExpandTeamStatus, "btnExpandTeamStatus");
            this.btnExpandTeamStatus.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandTeamStatus.Name = "btnExpandTeamStatus";
            this.btnExpandTeamStatus.UseVisualStyleBackColor = false;
            // 
            // btnCommsLog
            // 
            resources.ApplyResources(this.btnCommsLog, "btnCommsLog");
            this.btnCommsLog.Name = "btnCommsLog";
            this.btnCommsLog.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // pnlLogistics
            // 
            resources.ApplyResources(this.pnlLogistics, "pnlLogistics");
            this.pnlLogistics.BackColor = System.Drawing.Color.White;
            this.pnlLogistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogistics.Controls.Add(this.btnLogisticsBulkSignIn);
            this.pnlLogistics.Controls.Add(this.btnLogisticsSignIn);
            this.pnlLogistics.Controls.Add(this.btnLogisticsMemberStatus);
            this.pnlLogistics.Controls.Add(this.btnAdditionalContacts);
            this.pnlLogistics.Controls.Add(this.btnMemberNeeds);
            this.pnlLogistics.Controls.Add(this.btnEquipment);
            this.pnlLogistics.Controls.Add(this.btnVehicles);
            this.pnlLogistics.Controls.Add(this.btnLogisticsDashboard);
            this.pnlLogistics.Controls.Add(this.btnExpandLogistics);
            this.pnlLogistics.Controls.Add(this.lblLogisticsTitle);
            this.pnlLogistics.Name = "pnlLogistics";
            // 
            // btnLogisticsBulkSignIn
            // 
            resources.ApplyResources(this.btnLogisticsBulkSignIn, "btnLogisticsBulkSignIn");
            this.btnLogisticsBulkSignIn.Name = "btnLogisticsBulkSignIn";
            this.btnLogisticsBulkSignIn.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsSignIn
            // 
            resources.ApplyResources(this.btnLogisticsSignIn, "btnLogisticsSignIn");
            this.btnLogisticsSignIn.Name = "btnLogisticsSignIn";
            this.btnLogisticsSignIn.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsMemberStatus
            // 
            resources.ApplyResources(this.btnLogisticsMemberStatus, "btnLogisticsMemberStatus");
            this.btnLogisticsMemberStatus.Name = "btnLogisticsMemberStatus";
            this.btnLogisticsMemberStatus.UseVisualStyleBackColor = true;
            // 
            // btnAdditionalContacts
            // 
            resources.ApplyResources(this.btnAdditionalContacts, "btnAdditionalContacts");
            this.btnAdditionalContacts.Name = "btnAdditionalContacts";
            this.btnAdditionalContacts.UseVisualStyleBackColor = true;
            // 
            // btnMemberNeeds
            // 
            resources.ApplyResources(this.btnMemberNeeds, "btnMemberNeeds");
            this.btnMemberNeeds.Name = "btnMemberNeeds";
            this.btnMemberNeeds.UseVisualStyleBackColor = true;
            // 
            // btnEquipment
            // 
            resources.ApplyResources(this.btnEquipment, "btnEquipment");
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.UseVisualStyleBackColor = true;
            // 
            // btnVehicles
            // 
            resources.ApplyResources(this.btnVehicles, "btnVehicles");
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsDashboard
            // 
            resources.ApplyResources(this.btnLogisticsDashboard, "btnLogisticsDashboard");
            this.btnLogisticsDashboard.Name = "btnLogisticsDashboard";
            this.btnLogisticsDashboard.UseVisualStyleBackColor = true;
            // 
            // btnExpandLogistics
            // 
            resources.ApplyResources(this.btnExpandLogistics, "btnExpandLogistics");
            this.btnExpandLogistics.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandLogistics.Name = "btnExpandLogistics";
            this.btnExpandLogistics.UseVisualStyleBackColor = false;
            // 
            // lblLogisticsTitle
            // 
            resources.ApplyResources(this.lblLogisticsTitle, "lblLogisticsTitle");
            this.lblLogisticsTitle.Name = "lblLogisticsTitle";
            // 
            // pnlPlanning
            // 
            resources.ApplyResources(this.pnlPlanning, "pnlPlanning");
            this.pnlPlanning.BackColor = System.Drawing.Color.White;
            this.pnlPlanning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlanning.Controls.Add(this.btnPlanningAddAssignment);
            this.pnlPlanning.Controls.Add(this.btnTeamAssignments);
            this.pnlPlanning.Controls.Add(this.btnReflexTasking);
            this.pnlPlanning.Controls.Add(this.btnTimeline);
            this.pnlPlanning.Controls.Add(this.btnNotes);
            this.pnlPlanning.Controls.Add(this.btnSegmentation);
            this.pnlPlanning.Controls.Add(this.btnPlanningDashboard);
            this.pnlPlanning.Controls.Add(this.btnAssignmentStats);
            this.pnlPlanning.Controls.Add(this.btnClues);
            this.pnlPlanning.Controls.Add(this.btnMattson);
            this.pnlPlanning.Controls.Add(this.btnExpandPlanning);
            this.pnlPlanning.Controls.Add(this.lblPlanningTitle);
            this.pnlPlanning.Name = "pnlPlanning";
            // 
            // btnPlanningAddAssignment
            // 
            resources.ApplyResources(this.btnPlanningAddAssignment, "btnPlanningAddAssignment");
            this.btnPlanningAddAssignment.Name = "btnPlanningAddAssignment";
            this.btnPlanningAddAssignment.UseVisualStyleBackColor = true;
            // 
            // btnTeamAssignments
            // 
            resources.ApplyResources(this.btnTeamAssignments, "btnTeamAssignments");
            this.btnTeamAssignments.Name = "btnTeamAssignments";
            this.btnTeamAssignments.UseVisualStyleBackColor = true;
            // 
            // btnReflexTasking
            // 
            resources.ApplyResources(this.btnReflexTasking, "btnReflexTasking");
            this.btnReflexTasking.Name = "btnReflexTasking";
            this.btnReflexTasking.UseVisualStyleBackColor = true;
            // 
            // btnTimeline
            // 
            resources.ApplyResources(this.btnTimeline, "btnTimeline");
            this.btnTimeline.Name = "btnTimeline";
            this.btnTimeline.UseVisualStyleBackColor = true;
            // 
            // btnNotes
            // 
            resources.ApplyResources(this.btnNotes, "btnNotes");
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.UseVisualStyleBackColor = true;
            // 
            // btnSegmentation
            // 
            resources.ApplyResources(this.btnSegmentation, "btnSegmentation");
            this.btnSegmentation.Name = "btnSegmentation";
            this.btnSegmentation.UseVisualStyleBackColor = true;
            // 
            // btnPlanningDashboard
            // 
            resources.ApplyResources(this.btnPlanningDashboard, "btnPlanningDashboard");
            this.btnPlanningDashboard.Name = "btnPlanningDashboard";
            this.btnPlanningDashboard.UseVisualStyleBackColor = true;
            // 
            // btnAssignmentStats
            // 
            resources.ApplyResources(this.btnAssignmentStats, "btnAssignmentStats");
            this.btnAssignmentStats.Name = "btnAssignmentStats";
            this.btnAssignmentStats.UseVisualStyleBackColor = true;
            // 
            // btnClues
            // 
            resources.ApplyResources(this.btnClues, "btnClues");
            this.btnClues.Name = "btnClues";
            this.btnClues.UseVisualStyleBackColor = true;
            // 
            // btnMattson
            // 
            resources.ApplyResources(this.btnMattson, "btnMattson");
            this.btnMattson.Name = "btnMattson";
            this.btnMattson.UseVisualStyleBackColor = true;
            // 
            // btnExpandPlanning
            // 
            resources.ApplyResources(this.btnExpandPlanning, "btnExpandPlanning");
            this.btnExpandPlanning.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandPlanning.Name = "btnExpandPlanning";
            this.btnExpandPlanning.UseVisualStyleBackColor = false;
            // 
            // lblPlanningTitle
            // 
            resources.ApplyResources(this.lblPlanningTitle, "lblPlanningTitle");
            this.lblPlanningTitle.Name = "lblPlanningTitle";
            // 
            // llProgramURL
            // 
            resources.ApplyResources(this.llProgramURL, "llProgramURL");
            this.llProgramURL.Name = "llProgramURL";
            this.llProgramURL.TabStop = true;
            this.llProgramURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llProgramURL_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.ics_canada_logo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // IncidentDetailsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.llProgramURL);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlIAP);
            this.Controls.Add(this.pnlTeamStatus);
            this.Controls.Add(this.pnlLogistics);
            this.Controls.Add(this.pnlPlanning);
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
            this.pnlIAP.ResumeLayout(false);
            this.pnlTeamStatus.ResumeLayout(false);
            this.pnlLogistics.ResumeLayout(false);
            this.pnlPlanning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TextBox txtTaskName;
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
        private System.Windows.Forms.Panel pnlIAP;
        private System.Windows.Forms.Label lblIAP;
        private System.Windows.Forms.Button btnTransportPlan;
        private System.Windows.Forms.Button btnBriefings2;
        private System.Windows.Forms.Button btnExpandIAP;
        private System.Windows.Forms.Button btnSafetyPlans;
        private System.Windows.Forms.Button btnMedicalPlan;
        private System.Windows.Forms.Button btnPrintOrgChart;
        private System.Windows.Forms.Button btnCommsPlan;
        private System.Windows.Forms.Button btnSubjectProfile;
        private System.Windows.Forms.Button btnPrintIAP;
        private System.Windows.Forms.Button btnIncidentObjectives;
        private System.Windows.Forms.Button btnOpsPlan;
        private System.Windows.Forms.Panel pnlTeamStatus;
        private System.Windows.Forms.Button btnOpsAssignments;
        private System.Windows.Forms.Button btnOpsMemberStatus;
        private System.Windows.Forms.Button btnOpsDashboard;
        private System.Windows.Forms.Button btnTeamStatus;
        private System.Windows.Forms.Button btnExpandTeamStatus;
        private System.Windows.Forms.Button btnCommsLog;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlLogistics;
        private System.Windows.Forms.Button btnLogisticsBulkSignIn;
        private System.Windows.Forms.Button btnLogisticsSignIn;
        private System.Windows.Forms.Button btnLogisticsMemberStatus;
        private System.Windows.Forms.Button btnAdditionalContacts;
        private System.Windows.Forms.Button btnMemberNeeds;
        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnLogisticsDashboard;
        private System.Windows.Forms.Button btnExpandLogistics;
        private System.Windows.Forms.Label lblLogisticsTitle;
        private System.Windows.Forms.Panel pnlPlanning;
        private System.Windows.Forms.Button btnPlanningAddAssignment;
        private System.Windows.Forms.Button btnTeamAssignments;
        private System.Windows.Forms.Button btnReflexTasking;
        private System.Windows.Forms.Button btnTimeline;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.Button btnSegmentation;
        private System.Windows.Forms.Button btnPlanningDashboard;
        private System.Windows.Forms.Button btnAssignmentStats;
        private System.Windows.Forms.Button btnClues;
        private System.Windows.Forms.Button btnMattson;
        private System.Windows.Forms.Button btnExpandPlanning;
        private System.Windows.Forms.Label lblPlanningTitle;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkInternetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llProgramURL;
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
        private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamMembersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentObjectivesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safetyNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForTemplateUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForAppUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ImageList imglTabIcons;
    }
}

