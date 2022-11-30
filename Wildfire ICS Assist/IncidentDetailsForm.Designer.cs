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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidentDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tpCommsLog = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvCommsLog = new System.Windows.Forms.DataGridView();
            this.colCritical = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationCalled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThisIs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddCommsLog = new System.Windows.Forms.Button();
            this.chkECCReminderThisDevice = new System.Windows.Forms.CheckBox();
            this.btnViewCommsInNewWindow = new System.Windows.Forms.Button();
            this.lblLastECC = new System.Windows.Forms.Label();
            this.tpAssignmentList = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvTeamAssignments = new System.Windows.Forms.DataGridView();
            this.colPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMembers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstimatedSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAssignmentsTabPlanningDash = new System.Windows.Forms.Button();
            this.btnAssignmentsTabOpsDash = new System.Windows.Forms.Button();
            this.btnAssignmentsTabAssignments = new System.Windows.Forms.Button();
            this.tpTeamStatus = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvTeamStatus = new System.Windows.Forms.DataGridView();
            this.colAssignmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastCheckin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewTeamStatusInNewWindow = new System.Windows.Forms.Button();
            this.chkIncludeInactiveInStatusList = new System.Windows.Forms.CheckBox();
            this.tpMembersOnTask = new System.Windows.Forms.TabPage();
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
            this.tpEquipment = new System.Windows.Forms.TabPage();
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
            this.tpWhiteBoard = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvWhiteboard = new System.Windows.Forms.DataGridView();
            this.colOutstanding = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colWhiteboardItemText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNewWhiteboard = new System.Windows.Forms.TextBox();
            this.btnOpenWhiteboard = new System.Windows.Forms.Button();
            this.btnAddWhiteboard = new System.Windows.Forms.Button();
            this.tpNetworkLog = new System.Windows.Forms.TabPage();
            this.txtNetworkLog = new System.Windows.Forms.TextBox();
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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llProgramURL = new System.Windows.Forms.LinkLabel();
            this.pnlOpsPeriod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).BeginInit();
            this.pnlTaskInfo.SuspendLayout();
            this.tcStatus.SuspendLayout();
            this.tpCommsLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsLog)).BeginInit();
            this.tpAssignmentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamAssignments)).BeginInit();
            this.tpTeamStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamStatus)).BeginInit();
            this.tpMembersOnTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembersOnTask)).BeginInit();
            this.tpEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskEquipment)).BeginInit();
            this.tpWhiteBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhiteboard)).BeginInit();
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
            // pnlOpsPeriod
            // 
            this.pnlOpsPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOpsPeriod.BackColor = System.Drawing.Color.White;
            this.pnlOpsPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOpsPeriod.Controls.Add(this.btnCloseOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.label18);
            this.pnlOpsPeriod.Controls.Add(this.label15);
            this.pnlOpsPeriod.Controls.Add(this.datOpsEnd);
            this.pnlOpsPeriod.Controls.Add(this.datOpsStart);
            this.pnlOpsPeriod.Controls.Add(this.numOpPeriod);
            this.pnlOpsPeriod.Controls.Add(this.label1);
            this.pnlOpsPeriod.Location = new System.Drawing.Point(823, 36);
            this.pnlOpsPeriod.Name = "pnlOpsPeriod";
            this.pnlOpsPeriod.Size = new System.Drawing.Size(262, 213);
            this.pnlOpsPeriod.TabIndex = 46;
            // 
            // btnCloseOpPeriod
            // 
            this.btnCloseOpPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseOpPeriod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloseOpPeriod.Location = new System.Drawing.Point(10, 156);
            this.btnCloseOpPeriod.Name = "btnCloseOpPeriod";
            this.btnCloseOpPeriod.Size = new System.Drawing.Size(241, 48);
            this.btnCloseOpPeriod.TabIndex = 92;
            this.btnCloseOpPeriod.TabStop = false;
            this.btnCloseOpPeriod.Text = "Review / Close Op Period";
            this.btnCloseOpPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCloseOpPeriod.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(5, 126);
            this.label18.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 24);
            this.label18.TabIndex = 16;
            this.label18.Text = "To";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 90);
            this.label15.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 24);
            this.label15.TabIndex = 15;
            this.label15.Text = "From";
            // 
            // datOpsEnd
            // 
            this.datOpsEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datOpsEnd.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datOpsEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datOpsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsEnd.Location = new System.Drawing.Point(60, 124);
            this.datOpsEnd.Name = "datOpsEnd";
            this.datOpsEnd.Size = new System.Drawing.Size(191, 26);
            this.datOpsEnd.TabIndex = 12;
            // 
            // datOpsStart
            // 
            this.datOpsStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datOpsStart.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datOpsStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsStart.Location = new System.Drawing.Point(60, 88);
            this.datOpsStart.Name = "datOpsStart";
            this.datOpsStart.Size = new System.Drawing.Size(191, 26);
            this.datOpsStart.TabIndex = 6;
            // 
            // numOpPeriod
            // 
            this.numOpPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOpPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numOpPeriod.Location = new System.Drawing.Point(159, 20);
            this.numOpPeriod.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.numOpPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpPeriod.Name = "numOpPeriod";
            this.numOpPeriod.Size = new System.Drawing.Size(96, 50);
            this.numOpPeriod.TabIndex = 5;
            this.numOpPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 66);
            this.label1.TabIndex = 11;
            this.label1.Text = "Operational Period";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTaskInfo
            // 
            this.pnlTaskInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlTaskInfo.Location = new System.Drawing.Point(162, 36);
            this.pnlTaskInfo.Name = "pnlTaskInfo";
            this.pnlTaskInfo.Size = new System.Drawing.Size(655, 213);
            this.pnlTaskInfo.TabIndex = 42;
            // 
            // btnOutstandingLogItems
            // 
            this.btnOutstandingLogItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOutstandingLogItems.Image = ((System.Drawing.Image)(resources.GetObject("btnOutstandingLogItems.Image")));
            this.btnOutstandingLogItems.Location = new System.Drawing.Point(479, 167);
            this.btnOutstandingLogItems.Name = "btnOutstandingLogItems";
            this.btnOutstandingLogItems.Size = new System.Drawing.Size(166, 37);
            this.btnOutstandingLogItems.TabIndex = 91;
            this.btnOutstandingLogItems.TabStop = false;
            this.btnOutstandingLogItems.Text = "Outstanding";
            this.btnOutstandingLogItems.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOutstandingLogItems.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 173);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 24);
            this.label19.TabIndex = 90;
            this.label19.Text = "Position Log";
            // 
            // btnViewPositionLog
            // 
            this.btnViewPositionLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewPositionLog.Image = ((System.Drawing.Image)(resources.GetObject("btnViewPositionLog.Image")));
            this.btnViewPositionLog.Location = new System.Drawing.Point(331, 167);
            this.btnViewPositionLog.Name = "btnViewPositionLog";
            this.btnViewPositionLog.Size = new System.Drawing.Size(142, 37);
            this.btnViewPositionLog.TabIndex = 89;
            this.btnViewPositionLog.TabStop = false;
            this.btnViewPositionLog.Text = "View Log";
            this.btnViewPositionLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewPositionLog.UseVisualStyleBackColor = true;
            // 
            // btnAddToPositionLog
            // 
            this.btnAddToPositionLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddToPositionLog.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToPositionLog.Image")));
            this.btnAddToPositionLog.Location = new System.Drawing.Point(165, 167);
            this.btnAddToPositionLog.Name = "btnAddToPositionLog";
            this.btnAddToPositionLog.Size = new System.Drawing.Size(154, 37);
            this.btnAddToPositionLog.TabIndex = 88;
            this.btnAddToPositionLog.TabStop = false;
            this.btnAddToPositionLog.Text = "Add Entry";
            this.btnAddToPositionLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddToPositionLog.UseVisualStyleBackColor = true;
            // 
            // txtTaskNumber
            // 
            this.txtTaskNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskNumber.Location = new System.Drawing.Point(165, 88);
            this.txtTaskNumber.Name = "txtTaskNumber";
            this.txtTaskNumber.Size = new System.Drawing.Size(479, 29);
            this.txtTaskNumber.TabIndex = 2;
            // 
            // btnICSRoleHelp
            // 
            this.btnICSRoleHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnICSRoleHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnICSRoleHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnICSRoleHelp.Image")));
            this.btnICSRoleHelp.Location = new System.Drawing.Point(507, 126);
            this.btnICSRoleHelp.Name = "btnICSRoleHelp";
            this.btnICSRoleHelp.Size = new System.Drawing.Size(137, 37);
            this.btnICSRoleHelp.TabIndex = 87;
            this.btnICSRoleHelp.TabStop = false;
            this.btnICSRoleHelp.Text = "Role Help";
            this.btnICSRoleHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnICSRoleHelp.UseVisualStyleBackColor = true;
            // 
            // cboICSRole
            // 
            this.cboICSRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboICSRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboICSRole.FormattingEnabled = true;
            this.cboICSRole.Location = new System.Drawing.Point(165, 129);
            this.cboICSRole.Name = "cboICSRole";
            this.cboICSRole.Size = new System.Drawing.Size(332, 32);
            this.cboICSRole.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 133);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(150, 24);
            this.label17.TabIndex = 35;
            this.label17.Text = "Current ICS Role";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(637, 32);
            this.label16.TabIndex = 34;
            this.label16.Text = "Incident Information";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskName.Location = new System.Drawing.Point(165, 48);
            this.txtTaskName.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(479, 29);
            this.txtTaskName.TabIndex = 1;
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskName.Location = new System.Drawing.Point(9, 50);
            this.lblTaskName.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(132, 24);
            this.lblTaskName.TabIndex = 8;
            this.lblTaskName.Text = "Incident Name";
            // 
            // lblTaskNumber
            // 
            this.lblTaskNumber.AutoSize = true;
            this.lblTaskNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskNumber.Location = new System.Drawing.Point(9, 90);
            this.lblTaskNumber.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblTaskNumber.Name = "lblTaskNumber";
            this.lblTaskNumber.Size = new System.Drawing.Size(150, 24);
            this.lblTaskNumber.TabIndex = 6;
            this.lblTaskNumber.Text = "Incident Number";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.Location = new System.Drawing.Point(347, 682);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(738, 20);
            this.lblServerStatus.TabIndex = 44;
            this.lblServerStatus.Text = "This computer is acting as a server.  IP 123.123.123.123 Port 505050";
            this.lblServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVersionNumber.Location = new System.Drawing.Point(8, 682);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(345, 20);
            this.lblVersionNumber.TabIndex = 43;
            this.lblVersionNumber.Text = "label13";
            this.lblVersionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcStatus
            // 
            this.tcStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcStatus.Controls.Add(this.tpCommsLog);
            this.tcStatus.Controls.Add(this.tpAssignmentList);
            this.tcStatus.Controls.Add(this.tpTeamStatus);
            this.tcStatus.Controls.Add(this.tpMembersOnTask);
            this.tcStatus.Controls.Add(this.tpEquipment);
            this.tcStatus.Controls.Add(this.tpWhiteBoard);
            this.tcStatus.Controls.Add(this.tpNetworkLog);
            this.tcStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcStatus.ItemSize = new System.Drawing.Size(148, 40);
            this.tcStatus.Location = new System.Drawing.Point(0, 385);
            this.tcStatus.Multiline = true;
            this.tcStatus.Name = "tcStatus";
            this.tcStatus.SelectedIndex = 0;
            this.tcStatus.Size = new System.Drawing.Size(1095, 294);
            this.tcStatus.TabIndex = 45;
            // 
            // tpCommsLog
            // 
            this.tpCommsLog.AutoScroll = true;
            this.tpCommsLog.Controls.Add(this.splitContainer2);
            this.tpCommsLog.ImageIndex = 0;
            this.tpCommsLog.Location = new System.Drawing.Point(4, 44);
            this.tpCommsLog.Name = "tpCommsLog";
            this.tpCommsLog.Size = new System.Drawing.Size(1087, 246);
            this.tpCommsLog.TabIndex = 2;
            this.tpCommsLog.Text = "Comms Log";
            this.tpCommsLog.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvCommsLog);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAddCommsLog);
            this.splitContainer2.Panel2.Controls.Add(this.chkECCReminderThisDevice);
            this.splitContainer2.Panel2.Controls.Add(this.btnViewCommsInNewWindow);
            this.splitContainer2.Panel2.Controls.Add(this.lblLastECC);
            this.splitContainer2.Size = new System.Drawing.Size(1087, 246);
            this.splitContainer2.SplitterDistance = 194;
            this.splitContainer2.TabIndex = 39;
            // 
            // dgvCommsLog
            // 
            this.dgvCommsLog.AllowUserToAddRows = false;
            this.dgvCommsLog.AllowUserToDeleteRows = false;
            this.dgvCommsLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommsLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCritical,
            this.colTime,
            this.colStationCalled,
            this.colThisIs,
            this.colSubject});
            this.dgvCommsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommsLog.Location = new System.Drawing.Point(0, 0);
            this.dgvCommsLog.Name = "dgvCommsLog";
            this.dgvCommsLog.ReadOnly = true;
            this.dgvCommsLog.RowHeadersVisible = false;
            this.dgvCommsLog.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCommsLog.RowTemplate.Height = 29;
            this.dgvCommsLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommsLog.Size = new System.Drawing.Size(1087, 194);
            this.dgvCommsLog.TabIndex = 26;
            // 
            // colCritical
            // 
            this.colCritical.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCritical.DataPropertyName = "Starred";
            this.colCritical.HeaderText = "Critical";
            this.colCritical.Name = "colCritical";
            this.colCritical.ReadOnly = true;
            this.colCritical.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colCritical.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colCritical.Width = 104;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTime.DataPropertyName = "LogDate";
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 85;
            // 
            // colStationCalled
            // 
            this.colStationCalled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStationCalled.DataPropertyName = "ToName";
            this.colStationCalled.HeaderText = "Station Called";
            this.colStationCalled.Name = "colStationCalled";
            this.colStationCalled.ReadOnly = true;
            this.colStationCalled.Width = 173;
            // 
            // colThisIs
            // 
            this.colThisIs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colThisIs.DataPropertyName = "FromName";
            this.colThisIs.HeaderText = "This Is";
            this.colThisIs.Name = "colThisIs";
            this.colThisIs.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSubject.DataPropertyName = "Message";
            this.colSubject.HeaderText = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            this.colSubject.Width = 110;
            // 
            // btnAddCommsLog
            // 
            this.btnAddCommsLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCommsLog.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCommsLog.Image")));
            this.btnAddCommsLog.Location = new System.Drawing.Point(6, 6);
            this.btnAddCommsLog.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAddCommsLog.Name = "btnAddCommsLog";
            this.btnAddCommsLog.Size = new System.Drawing.Size(195, 38);
            this.btnAddCommsLog.TabIndex = 36;
            this.btnAddCommsLog.Text = "Add Log Entry";
            this.btnAddCommsLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCommsLog.UseVisualStyleBackColor = true;
            // 
            // chkECCReminderThisDevice
            // 
            this.chkECCReminderThisDevice.AutoSize = true;
            this.chkECCReminderThisDevice.Location = new System.Drawing.Point(901, 10);
            this.chkECCReminderThisDevice.Name = "chkECCReminderThisDevice";
            this.chkECCReminderThisDevice.Size = new System.Drawing.Size(143, 30);
            this.chkECCReminderThisDevice.TabIndex = 38;
            this.chkECCReminderThisDevice.Text = "Remind Me";
            this.chkECCReminderThisDevice.UseVisualStyleBackColor = true;
            this.chkECCReminderThisDevice.Visible = false;
            // 
            // btnViewCommsInNewWindow
            // 
            this.btnViewCommsInNewWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewCommsInNewWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCommsInNewWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnViewCommsInNewWindow.Image")));
            this.btnViewCommsInNewWindow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewCommsInNewWindow.Location = new System.Drawing.Point(204, 6);
            this.btnViewCommsInNewWindow.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnViewCommsInNewWindow.Name = "btnViewCommsInNewWindow";
            this.btnViewCommsInNewWindow.Size = new System.Drawing.Size(228, 38);
            this.btnViewCommsInNewWindow.TabIndex = 35;
            this.btnViewCommsInNewWindow.Text = "View in new window";
            this.btnViewCommsInNewWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewCommsInNewWindow.UseVisualStyleBackColor = true;
            // 
            // lblLastECC
            // 
            this.lblLastECC.Location = new System.Drawing.Point(436, 6);
            this.lblLastECC.Name = "lblLastECC";
            this.lblLastECC.Size = new System.Drawing.Size(452, 38);
            this.lblLastECC.TabIndex = 37;
            this.lblLastECC.Text = "Last ECC check 120 minutes ago";
            this.lblLastECC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpAssignmentList
            // 
            this.tpAssignmentList.AutoScroll = true;
            this.tpAssignmentList.Controls.Add(this.splitContainer3);
            this.tpAssignmentList.ImageIndex = 2;
            this.tpAssignmentList.Location = new System.Drawing.Point(4, 44);
            this.tpAssignmentList.Name = "tpAssignmentList";
            this.tpAssignmentList.Padding = new System.Windows.Forms.Padding(3);
            this.tpAssignmentList.Size = new System.Drawing.Size(1087, 246);
            this.tpAssignmentList.TabIndex = 0;
            this.tpAssignmentList.Text = "Assignments";
            this.tpAssignmentList.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvTeamAssignments);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnAssignmentsTabPlanningDash);
            this.splitContainer3.Panel2.Controls.Add(this.btnAssignmentsTabOpsDash);
            this.splitContainer3.Panel2.Controls.Add(this.btnAssignmentsTabAssignments);
            this.splitContainer3.Size = new System.Drawing.Size(1081, 240);
            this.splitContainer3.SplitterDistance = 189;
            this.splitContainer3.TabIndex = 39;
            // 
            // dgvTeamAssignments
            // 
            this.dgvTeamAssignments.AllowUserToAddRows = false;
            this.dgvTeamAssignments.AllowUserToDeleteRows = false;
            this.dgvTeamAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTeamAssignments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTeamAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPriority,
            this.colTeamName,
            this.colMembers,
            this.colEstimatedSpeed,
            this.colArea,
            this.colCurrentStatus});
            this.dgvTeamAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeamAssignments.Location = new System.Drawing.Point(0, 0);
            this.dgvTeamAssignments.MultiSelect = false;
            this.dgvTeamAssignments.Name = "dgvTeamAssignments";
            this.dgvTeamAssignments.RowHeadersVisible = false;
            this.dgvTeamAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTeamAssignments.Size = new System.Drawing.Size(1081, 189);
            this.dgvTeamAssignments.TabIndex = 1;
            // 
            // colPriority
            // 
            this.colPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPriority.DataPropertyName = "Priority";
            this.colPriority.HeaderText = "Priority";
            this.colPriority.Name = "colPriority";
            this.colPriority.ReadOnly = true;
            this.colPriority.Width = 105;
            // 
            // colTeamName
            // 
            this.colTeamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTeamName.DataPropertyName = "TeamNameWithAssignmentName";
            this.colTeamName.HeaderText = "Team";
            this.colTeamName.Name = "colTeamName";
            this.colTeamName.ReadOnly = true;
            this.colTeamName.Width = 92;
            // 
            // colMembers
            // 
            this.colMembers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMembers.DataPropertyName = "MembersRequired";
            this.colMembers.HeaderText = "Members";
            this.colMembers.Name = "colMembers";
            this.colMembers.ReadOnly = true;
            this.colMembers.Width = 128;
            // 
            // colEstimatedSpeed
            // 
            this.colEstimatedSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEstimatedSpeed.DataPropertyName = "EstimatedSpeed";
            this.colEstimatedSpeed.HeaderText = "Speed (km/hr)";
            this.colEstimatedSpeed.Name = "colEstimatedSpeed";
            this.colEstimatedSpeed.ReadOnly = true;
            this.colEstimatedSpeed.Width = 175;
            // 
            // colArea
            // 
            this.colArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colArea.DataPropertyName = "AreaOfAssignment";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colArea.DefaultCellStyle = dataGridViewCellStyle1;
            this.colArea.HeaderText = "Area (KM²)";
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            this.colArea.Width = 143;
            // 
            // colCurrentStatus
            // 
            this.colCurrentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCurrentStatus.DataPropertyName = "currentStatusName";
            this.colCurrentStatus.HeaderText = "Status";
            this.colCurrentStatus.Name = "colCurrentStatus";
            this.colCurrentStatus.ReadOnly = true;
            // 
            // btnAssignmentsTabPlanningDash
            // 
            this.btnAssignmentsTabPlanningDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentsTabPlanningDash.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignmentsTabPlanningDash.Image")));
            this.btnAssignmentsTabPlanningDash.Location = new System.Drawing.Point(245, 5);
            this.btnAssignmentsTabPlanningDash.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAssignmentsTabPlanningDash.Name = "btnAssignmentsTabPlanningDash";
            this.btnAssignmentsTabPlanningDash.Size = new System.Drawing.Size(226, 38);
            this.btnAssignmentsTabPlanningDash.TabIndex = 37;
            this.btnAssignmentsTabPlanningDash.Text = "Planning Dashboard";
            this.btnAssignmentsTabPlanningDash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignmentsTabPlanningDash.UseVisualStyleBackColor = true;
            // 
            // btnAssignmentsTabOpsDash
            // 
            this.btnAssignmentsTabOpsDash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentsTabOpsDash.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignmentsTabOpsDash.Image")));
            this.btnAssignmentsTabOpsDash.Location = new System.Drawing.Point(483, 5);
            this.btnAssignmentsTabOpsDash.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAssignmentsTabOpsDash.Name = "btnAssignmentsTabOpsDash";
            this.btnAssignmentsTabOpsDash.Size = new System.Drawing.Size(226, 38);
            this.btnAssignmentsTabOpsDash.TabIndex = 38;
            this.btnAssignmentsTabOpsDash.Text = "Ops Dashboard";
            this.btnAssignmentsTabOpsDash.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignmentsTabOpsDash.UseVisualStyleBackColor = true;
            // 
            // btnAssignmentsTabAssignments
            // 
            this.btnAssignmentsTabAssignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentsTabAssignments.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignmentsTabAssignments.Image")));
            this.btnAssignmentsTabAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssignmentsTabAssignments.Location = new System.Drawing.Point(7, 5);
            this.btnAssignmentsTabAssignments.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAssignmentsTabAssignments.Name = "btnAssignmentsTabAssignments";
            this.btnAssignmentsTabAssignments.Size = new System.Drawing.Size(226, 38);
            this.btnAssignmentsTabAssignments.TabIndex = 36;
            this.btnAssignmentsTabAssignments.Text = "Assignments";
            this.btnAssignmentsTabAssignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignmentsTabAssignments.UseVisualStyleBackColor = true;
            // 
            // tpTeamStatus
            // 
            this.tpTeamStatus.AutoScroll = true;
            this.tpTeamStatus.Controls.Add(this.splitContainer1);
            this.tpTeamStatus.ImageIndex = 5;
            this.tpTeamStatus.Location = new System.Drawing.Point(4, 44);
            this.tpTeamStatus.Name = "tpTeamStatus";
            this.tpTeamStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpTeamStatus.Size = new System.Drawing.Size(1087, 246);
            this.tpTeamStatus.TabIndex = 1;
            this.tpTeamStatus.Text = "Team Status";
            this.tpTeamStatus.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvTeamStatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnViewTeamStatusInNewWindow);
            this.splitContainer1.Panel2.Controls.Add(this.chkIncludeInactiveInStatusList);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 240);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 36;
            // 
            // dgvTeamStatus
            // 
            this.dgvTeamStatus.AllowUserToAddRows = false;
            this.dgvTeamStatus.AllowUserToDeleteRows = false;
            this.dgvTeamStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeamStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssignmentName,
            this.colLastCheckin,
            this.colStatus,
            this.colLastMessage});
            this.dgvTeamStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTeamStatus.Location = new System.Drawing.Point(0, 0);
            this.dgvTeamStatus.MultiSelect = false;
            this.dgvTeamStatus.Name = "dgvTeamStatus";
            this.dgvTeamStatus.ReadOnly = true;
            this.dgvTeamStatus.RowHeadersVisible = false;
            this.dgvTeamStatus.RowTemplate.Height = 28;
            this.dgvTeamStatus.Size = new System.Drawing.Size(1081, 187);
            this.dgvTeamStatus.TabIndex = 3;
            // 
            // colAssignmentName
            // 
            this.colAssignmentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAssignmentName.DataPropertyName = "TeamNameWithAssignmentName";
            this.colAssignmentName.HeaderText = "Assignment";
            this.colAssignmentName.Name = "colAssignmentName";
            this.colAssignmentName.ReadOnly = true;
            this.colAssignmentName.Width = 152;
            // 
            // colLastCheckin
            // 
            this.colLastCheckin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastCheckin.DataPropertyName = "LastRadioLogTime";
            dataGridViewCellStyle2.Format = "HH:mm:ss";
            this.colLastCheckin.DefaultCellStyle = dataGridViewCellStyle2;
            this.colLastCheckin.HeaderText = "Last Comms";
            this.colLastCheckin.Name = "colLastCheckin";
            this.colLastCheckin.ReadOnly = true;
            this.colLastCheckin.Width = 161;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.DataPropertyName = "currentStatusName";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 99;
            // 
            // colLastMessage
            // 
            this.colLastMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLastMessage.DataPropertyName = "LastMessage";
            this.colLastMessage.HeaderText = "Last Message";
            this.colLastMessage.Name = "colLastMessage";
            this.colLastMessage.ReadOnly = true;
            // 
            // btnViewTeamStatusInNewWindow
            // 
            this.btnViewTeamStatusInNewWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTeamStatusInNewWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnViewTeamStatusInNewWindow.Image")));
            this.btnViewTeamStatusInNewWindow.Location = new System.Drawing.Point(6, 7);
            this.btnViewTeamStatusInNewWindow.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnViewTeamStatusInNewWindow.Name = "btnViewTeamStatusInNewWindow";
            this.btnViewTeamStatusInNewWindow.Size = new System.Drawing.Size(226, 38);
            this.btnViewTeamStatusInNewWindow.TabIndex = 34;
            this.btnViewTeamStatusInNewWindow.Text = "View in new window";
            this.btnViewTeamStatusInNewWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewTeamStatusInNewWindow.UseVisualStyleBackColor = true;
            // 
            // chkIncludeInactiveInStatusList
            // 
            this.chkIncludeInactiveInStatusList.AutoSize = true;
            this.chkIncludeInactiveInStatusList.Location = new System.Drawing.Point(241, 11);
            this.chkIncludeInactiveInStatusList.Name = "chkIncludeInactiveInStatusList";
            this.chkIncludeInactiveInStatusList.Size = new System.Drawing.Size(314, 30);
            this.chkIncludeInactiveInStatusList.TabIndex = 35;
            this.chkIncludeInactiveInStatusList.Text = "Include Inactive Assignments";
            this.chkIncludeInactiveInStatusList.UseVisualStyleBackColor = true;
            // 
            // tpMembersOnTask
            // 
            this.tpMembersOnTask.AutoScroll = true;
            this.tpMembersOnTask.Controls.Add(this.splitContainer4);
            this.tpMembersOnTask.ImageIndex = 1;
            this.tpMembersOnTask.Location = new System.Drawing.Point(4, 44);
            this.tpMembersOnTask.Name = "tpMembersOnTask";
            this.tpMembersOnTask.Padding = new System.Windows.Forms.Padding(3);
            this.tpMembersOnTask.Size = new System.Drawing.Size(1087, 246);
            this.tpMembersOnTask.TabIndex = 5;
            this.tpMembersOnTask.Text = "Members";
            this.tpMembersOnTask.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.splitContainer4.Size = new System.Drawing.Size(1081, 240);
            this.splitContainer4.SplitterDistance = 190;
            this.splitContainer4.TabIndex = 40;
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
            this.dgvMembersOnTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembersOnTask.Location = new System.Drawing.Point(0, 0);
            this.dgvMembersOnTask.MultiSelect = false;
            this.dgvMembersOnTask.Name = "dgvMembersOnTask";
            this.dgvMembersOnTask.ReadOnly = true;
            this.dgvMembersOnTask.RowHeadersVisible = false;
            this.dgvMembersOnTask.RowTemplate.Height = 30;
            this.dgvMembersOnTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembersOnTask.Size = new System.Drawing.Size(1081, 190);
            this.dgvMembersOnTask.TabIndex = 0;
            // 
            // colMemberName
            // 
            this.colMemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMemberName.DataPropertyName = "MemberName";
            this.colMemberName.HeaderText = "Member Name";
            this.colMemberName.MinimumWidth = 150;
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            // 
            // colMemberSARGroup
            // 
            this.colMemberSARGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colMemberSARGroup.DataPropertyName = "OrganizationName";
            this.colMemberSARGroup.HeaderText = "SAR Team";
            this.colMemberSARGroup.Name = "colMemberSARGroup";
            this.colMemberSARGroup.ReadOnly = true;
            this.colMemberSARGroup.Width = 132;
            // 
            // colSignInTime
            // 
            this.colSignInTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSignInTime.DataPropertyName = "SignInTimeAsText";
            dataGridViewCellStyle3.Format = "HH:mm yyyy-MMM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.colSignInTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSignInTime.HeaderText = "Sign In";
            this.colSignInTime.Name = "colSignInTime";
            this.colSignInTime.ReadOnly = true;
            this.colSignInTime.Width = 97;
            // 
            // colAssignmentNumber
            // 
            this.colAssignmentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAssignmentNumber.DataPropertyName = "getCurrentActivityName";
            this.colAssignmentNumber.HeaderText = "Assignment";
            this.colAssignmentNumber.Name = "colAssignmentNumber";
            this.colAssignmentNumber.ReadOnly = true;
            this.colAssignmentNumber.Width = 152;
            // 
            // colMemberAssignmentStatus
            // 
            this.colMemberAssignmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMemberAssignmentStatus.DataPropertyName = "AssignmentStatus";
            this.colMemberAssignmentStatus.HeaderText = "Status";
            this.colMemberAssignmentStatus.Name = "colMemberAssignmentStatus";
            this.colMemberAssignmentStatus.ReadOnly = true;
            this.colMemberAssignmentStatus.Width = 99;
            // 
            // btnAddAMember
            // 
            this.btnAddAMember.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAMember.Image")));
            this.btnAddAMember.Location = new System.Drawing.Point(3, 3);
            this.btnAddAMember.Name = "btnAddAMember";
            this.btnAddAMember.Size = new System.Drawing.Size(318, 38);
            this.btnAddAMember.TabIndex = 38;
            this.btnAddAMember.Text = "Add a Member / Sign In";
            this.btnAddAMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAMember.UseVisualStyleBackColor = true;
            // 
            // btnBulkSignIn
            // 
            this.btnBulkSignIn.Image = ((System.Drawing.Image)(resources.GetObject("btnBulkSignIn.Image")));
            this.btnBulkSignIn.Location = new System.Drawing.Point(327, 3);
            this.btnBulkSignIn.Name = "btnBulkSignIn";
            this.btnBulkSignIn.Size = new System.Drawing.Size(170, 38);
            this.btnBulkSignIn.TabIndex = 39;
            this.btnBulkSignIn.Text = "Bulk Sign In";
            this.btnBulkSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBulkSignIn.UseVisualStyleBackColor = true;
            // 
            // btnMembersOnTaskNewWindow
            // 
            this.btnMembersOnTaskNewWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembersOnTaskNewWindow.Image = ((System.Drawing.Image)(resources.GetObject("btnMembersOnTaskNewWindow.Image")));
            this.btnMembersOnTaskNewWindow.Location = new System.Drawing.Point(506, 3);
            this.btnMembersOnTaskNewWindow.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnMembersOnTaskNewWindow.Name = "btnMembersOnTaskNewWindow";
            this.btnMembersOnTaskNewWindow.Size = new System.Drawing.Size(244, 38);
            this.btnMembersOnTaskNewWindow.TabIndex = 37;
            this.btnMembersOnTaskNewWindow.Text = "View in new window";
            this.btnMembersOnTaskNewWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMembersOnTaskNewWindow.UseVisualStyleBackColor = true;
            // 
            // tpEquipment
            // 
            this.tpEquipment.Controls.Add(this.splitContainer5);
            this.tpEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpEquipment.ImageIndex = 6;
            this.tpEquipment.Location = new System.Drawing.Point(4, 44);
            this.tpEquipment.Name = "tpEquipment";
            this.tpEquipment.Size = new System.Drawing.Size(1087, 246);
            this.tpEquipment.TabIndex = 6;
            this.tpEquipment.Text = "Equipment";
            this.tpEquipment.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.splitContainer5.Size = new System.Drawing.Size(1087, 246);
            this.splitContainer5.SplitterDistance = 196;
            this.splitContainer5.TabIndex = 39;
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
            this.dgvTaskEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaskEquipment.Location = new System.Drawing.Point(0, 0);
            this.dgvTaskEquipment.Name = "dgvTaskEquipment";
            this.dgvTaskEquipment.ReadOnly = true;
            this.dgvTaskEquipment.RowHeadersVisible = false;
            this.dgvTaskEquipment.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaskEquipment.RowTemplate.Height = 30;
            this.dgvTaskEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskEquipment.Size = new System.Drawing.Size(1087, 196);
            this.dgvTaskEquipment.TabIndex = 1;
            // 
            // colCategory
            // 
            this.colCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCategory.DataPropertyName = "ParentCategoryName";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 110;
            // 
            // colSubCategory
            // 
            this.colSubCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSubCategory.DataPropertyName = "CategoryName";
            this.colSubCategory.HeaderText = "Sub-Category";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            this.colSubCategory.Width = 150;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "EquipmentName";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 86;
            // 
            // colReferenceID
            // 
            this.colReferenceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReferenceID.DataPropertyName = "ReferenceID";
            this.colReferenceID.HeaderText = "Reference ID";
            this.colReferenceID.Name = "colReferenceID";
            this.colReferenceID.ReadOnly = true;
            this.colReferenceID.Width = 145;
            // 
            // colEquipmentStatus
            // 
            this.colEquipmentStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEquipmentStatus.DataPropertyName = "StatusName";
            this.colEquipmentStatus.HeaderText = "Status";
            this.colEquipmentStatus.Name = "colEquipmentStatus";
            this.colEquipmentStatus.ReadOnly = true;
            this.colEquipmentStatus.Width = 85;
            // 
            // colAssignee
            // 
            this.colAssignee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssignee.DataPropertyName = "AssigneeName";
            this.colAssignee.HeaderText = "Assignee";
            this.colAssignee.Name = "colAssignee";
            this.colAssignee.ReadOnly = true;
            // 
            // btnAssignEquipment
            // 
            this.btnAssignEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignEquipment.Image")));
            this.btnAssignEquipment.Location = new System.Drawing.Point(3, 3);
            this.btnAssignEquipment.Name = "btnAssignEquipment";
            this.btnAssignEquipment.Size = new System.Drawing.Size(207, 38);
            this.btnAssignEquipment.TabIndex = 6;
            this.btnAssignEquipment.Text = "Issue Equipment";
            this.btnAssignEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignEquipment.UseVisualStyleBackColor = true;
            // 
            // btnViewEquipment
            // 
            this.btnViewEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnViewEquipment.Image")));
            this.btnViewEquipment.Location = new System.Drawing.Point(439, 3);
            this.btnViewEquipment.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnViewEquipment.Name = "btnViewEquipment";
            this.btnViewEquipment.Size = new System.Drawing.Size(244, 38);
            this.btnViewEquipment.TabIndex = 38;
            this.btnViewEquipment.Text = "View in new window";
            this.btnViewEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewEquipment.UseVisualStyleBackColor = true;
            // 
            // btnReturnEquipment
            // 
            this.btnReturnEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnReturnEquipment.Image")));
            this.btnReturnEquipment.Location = new System.Drawing.Point(216, 3);
            this.btnReturnEquipment.Name = "btnReturnEquipment";
            this.btnReturnEquipment.Size = new System.Drawing.Size(214, 38);
            this.btnReturnEquipment.TabIndex = 7;
            this.btnReturnEquipment.Text = "Return Equipment";
            this.btnReturnEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReturnEquipment.UseVisualStyleBackColor = true;
            // 
            // tpWhiteBoard
            // 
            this.tpWhiteBoard.AutoScroll = true;
            this.tpWhiteBoard.Controls.Add(this.splitContainer6);
            this.tpWhiteBoard.ImageIndex = 3;
            this.tpWhiteBoard.Location = new System.Drawing.Point(4, 44);
            this.tpWhiteBoard.Name = "tpWhiteBoard";
            this.tpWhiteBoard.Padding = new System.Windows.Forms.Padding(3);
            this.tpWhiteBoard.Size = new System.Drawing.Size(1087, 246);
            this.tpWhiteBoard.TabIndex = 4;
            this.tpWhiteBoard.Text = "Whiteboard";
            this.tpWhiteBoard.UseVisualStyleBackColor = true;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer6.IsSplitterFixed = true;
            this.splitContainer6.Location = new System.Drawing.Point(3, 3);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvWhiteboard);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.txtNewWhiteboard);
            this.splitContainer6.Panel2.Controls.Add(this.btnOpenWhiteboard);
            this.splitContainer6.Panel2.Controls.Add(this.btnAddWhiteboard);
            this.splitContainer6.Size = new System.Drawing.Size(1081, 240);
            this.splitContainer6.SplitterDistance = 190;
            this.splitContainer6.TabIndex = 37;
            // 
            // dgvWhiteboard
            // 
            this.dgvWhiteboard.AllowUserToAddRows = false;
            this.dgvWhiteboard.AllowUserToDeleteRows = false;
            this.dgvWhiteboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWhiteboard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOutstanding,
            this.colWhiteboardItemText,
            this.colDateAdded});
            this.dgvWhiteboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWhiteboard.Location = new System.Drawing.Point(0, 0);
            this.dgvWhiteboard.MultiSelect = false;
            this.dgvWhiteboard.Name = "dgvWhiteboard";
            this.dgvWhiteboard.RowHeadersVisible = false;
            this.dgvWhiteboard.RowTemplate.Height = 30;
            this.dgvWhiteboard.Size = new System.Drawing.Size(1081, 190);
            this.dgvWhiteboard.TabIndex = 0;
            // 
            // colOutstanding
            // 
            this.colOutstanding.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOutstanding.DataPropertyName = "Outstanding";
            this.colOutstanding.HeaderText = "Outstanding";
            this.colOutstanding.Name = "colOutstanding";
            this.colOutstanding.Width = 135;
            // 
            // colWhiteboardItemText
            // 
            this.colWhiteboardItemText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colWhiteboardItemText.DataPropertyName = "ItemText";
            this.colWhiteboardItemText.HeaderText = "Item";
            this.colWhiteboardItemText.Name = "colWhiteboardItemText";
            this.colWhiteboardItemText.Width = 80;
            // 
            // colDateAdded
            // 
            this.colDateAdded.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDateAdded.DataPropertyName = "DateAdded";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colDateAdded.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDateAdded.HeaderText = "Added";
            this.colDateAdded.Name = "colDateAdded";
            this.colDateAdded.ReadOnly = true;
            // 
            // txtNewWhiteboard
            // 
            this.txtNewWhiteboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewWhiteboard.Location = new System.Drawing.Point(7, 6);
            this.txtNewWhiteboard.Name = "txtNewWhiteboard";
            this.txtNewWhiteboard.Size = new System.Drawing.Size(673, 32);
            this.txtNewWhiteboard.TabIndex = 1;
            // 
            // btnOpenWhiteboard
            // 
            this.btnOpenWhiteboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenWhiteboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenWhiteboard.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenWhiteboard.Image")));
            this.btnOpenWhiteboard.Location = new System.Drawing.Point(848, 4);
            this.btnOpenWhiteboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOpenWhiteboard.Name = "btnOpenWhiteboard";
            this.btnOpenWhiteboard.Size = new System.Drawing.Size(227, 38);
            this.btnOpenWhiteboard.TabIndex = 36;
            this.btnOpenWhiteboard.Text = "View in new window";
            this.btnOpenWhiteboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpenWhiteboard.UseVisualStyleBackColor = true;
            // 
            // btnAddWhiteboard
            // 
            this.btnAddWhiteboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWhiteboard.Image = ((System.Drawing.Image)(resources.GetObject("btnAddWhiteboard.Image")));
            this.btnAddWhiteboard.Location = new System.Drawing.Point(717, 4);
            this.btnAddWhiteboard.Name = "btnAddWhiteboard";
            this.btnAddWhiteboard.Size = new System.Drawing.Size(122, 38);
            this.btnAddWhiteboard.TabIndex = 2;
            this.btnAddWhiteboard.Text = "Add";
            this.btnAddWhiteboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddWhiteboard.UseVisualStyleBackColor = true;
            // 
            // tpNetworkLog
            // 
            this.tpNetworkLog.Controls.Add(this.txtNetworkLog);
            this.tpNetworkLog.ImageIndex = 4;
            this.tpNetworkLog.Location = new System.Drawing.Point(4, 44);
            this.tpNetworkLog.Name = "tpNetworkLog";
            this.tpNetworkLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpNetworkLog.Size = new System.Drawing.Size(1087, 246);
            this.tpNetworkLog.TabIndex = 3;
            this.tpNetworkLog.Text = "Network Log";
            this.tpNetworkLog.UseVisualStyleBackColor = true;
            // 
            // txtNetworkLog
            // 
            this.txtNetworkLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetworkLog.Location = new System.Drawing.Point(0, 0);
            this.txtNetworkLog.Multiline = true;
            this.txtNetworkLog.Name = "txtNetworkLog";
            this.txtNetworkLog.ReadOnly = true;
            this.txtNetworkLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNetworkLog.Size = new System.Drawing.Size(1062, 157);
            this.txtNetworkLog.TabIndex = 0;
            // 
            // pnlInternetSyncStart
            // 
            this.pnlInternetSyncStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlInternetSyncStart.Controls.Add(this.btnCancelInternetSync);
            this.pnlInternetSyncStart.Controls.Add(this.label22);
            this.pnlInternetSyncStart.Controls.Add(this.label21);
            this.pnlInternetSyncStart.Controls.Add(this.progressBar1);
            this.pnlInternetSyncStart.Location = new System.Drawing.Point(366, 349);
            this.pnlInternetSyncStart.Name = "pnlInternetSyncStart";
            this.pnlInternetSyncStart.Size = new System.Drawing.Size(126, 27);
            this.pnlInternetSyncStart.TabIndex = 48;
            this.pnlInternetSyncStart.Visible = false;
            // 
            // btnCancelInternetSync
            // 
            this.btnCancelInternetSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelInternetSync.Location = new System.Drawing.Point(76, 12);
            this.btnCancelInternetSync.Name = "btnCancelInternetSync";
            this.btnCancelInternetSync.Size = new System.Drawing.Size(40, 38);
            this.btnCancelInternetSync.TabIndex = 6;
            this.btnCancelInternetSync.Text = "X";
            this.btnCancelInternetSync.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label22.Location = new System.Drawing.Point(5, 265);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(113, 40);
            this.label22.TabIndex = 5;
            this.label22.Text = "This may take a few moments, please wait";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label22.Visible = false;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(18, 113);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 85);
            this.label21.TabIndex = 1;
            this.label21.Text = "Syncronizing internet task data";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(154, 198);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(0, 68);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // pnlNetworkSyncInProgress
            // 
            this.pnlNetworkSyncInProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(130)))), ((int)(((byte)(236)))));
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkShareMoreInfoMsg);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnNetworkSyncDone);
            this.pnlNetworkSyncInProgress.Controls.Add(this.pbNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.btnCloseNetworkSyncInProgress);
            this.pnlNetworkSyncInProgress.Controls.Add(this.lblNetworkSyncStatus);
            this.pnlNetworkSyncInProgress.Location = new System.Drawing.Point(366, 318);
            this.pnlNetworkSyncInProgress.Name = "pnlNetworkSyncInProgress";
            this.pnlNetworkSyncInProgress.Size = new System.Drawing.Size(83, 25);
            this.pnlNetworkSyncInProgress.TabIndex = 47;
            this.pnlNetworkSyncInProgress.Visible = false;
            // 
            // lblNetworkShareMoreInfoMsg
            // 
            this.lblNetworkShareMoreInfoMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkShareMoreInfoMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkShareMoreInfoMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNetworkShareMoreInfoMsg.Location = new System.Drawing.Point(13, 279);
            this.lblNetworkShareMoreInfoMsg.Name = "lblNetworkShareMoreInfoMsg";
            this.lblNetworkShareMoreInfoMsg.Size = new System.Drawing.Size(57, 40);
            this.lblNetworkShareMoreInfoMsg.TabIndex = 4;
            this.lblNetworkShareMoreInfoMsg.Text = "Someone on the main computer may need to press \"Yes\" to share the task. If this t" +
    "akes too long, go ask them.";
            this.lblNetworkShareMoreInfoMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNetworkShareMoreInfoMsg.Visible = false;
            // 
            // btnNetworkSyncDone
            // 
            this.btnNetworkSyncDone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnNetworkSyncDone.Location = new System.Drawing.Point(-78, 322);
            this.btnNetworkSyncDone.Name = "btnNetworkSyncDone";
            this.btnNetworkSyncDone.Size = new System.Drawing.Size(212, 66);
            this.btnNetworkSyncDone.TabIndex = 3;
            this.btnNetworkSyncDone.Text = "OK";
            this.btnNetworkSyncDone.UseVisualStyleBackColor = true;
            this.btnNetworkSyncDone.Visible = false;
            // 
            // pbNetworkSyncInProgress
            // 
            this.pbNetworkSyncInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNetworkSyncInProgress.Location = new System.Drawing.Point(15, 253);
            this.pbNetworkSyncInProgress.Maximum = 4;
            this.pbNetworkSyncInProgress.Name = "pbNetworkSyncInProgress";
            this.pbNetworkSyncInProgress.Size = new System.Drawing.Size(54, 23);
            this.pbNetworkSyncInProgress.Step = 1;
            this.pbNetworkSyncInProgress.TabIndex = 2;
            // 
            // btnCloseNetworkSyncInProgress
            // 
            this.btnCloseNetworkSyncInProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseNetworkSyncInProgress.Location = new System.Drawing.Point(-7, 12);
            this.btnCloseNetworkSyncInProgress.Name = "btnCloseNetworkSyncInProgress";
            this.btnCloseNetworkSyncInProgress.Size = new System.Drawing.Size(40, 38);
            this.btnCloseNetworkSyncInProgress.TabIndex = 1;
            this.btnCloseNetworkSyncInProgress.Text = "X";
            this.btnCloseNetworkSyncInProgress.UseVisualStyleBackColor = true;
            // 
            // lblNetworkSyncStatus
            // 
            this.lblNetworkSyncStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkSyncStatus.ForeColor = System.Drawing.Color.White;
            this.lblNetworkSyncStatus.Location = new System.Drawing.Point(13, 161);
            this.lblNetworkSyncStatus.Name = "lblNetworkSyncStatus";
            this.lblNetworkSyncStatus.Size = new System.Drawing.Size(57, 85);
            this.lblNetworkSyncStatus.TabIndex = 0;
            this.lblNetworkSyncStatus.Text = "Network Satus Check Successful, Requesting Task";
            this.lblNetworkSyncStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.iAPToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.logisticsToolStripMenuItem,
            this.planningToolStripMenuItem,
            this.networkInternetToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 33);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // iAPToolStripMenuItem
            // 
            this.iAPToolStripMenuItem.Name = "iAPToolStripMenuItem";
            this.iAPToolStripMenuItem.Size = new System.Drawing.Size(52, 29);
            this.iAPToolStripMenuItem.Text = "IAP";
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(117, 29);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // logisticsToolStripMenuItem
            // 
            this.logisticsToolStripMenuItem.Name = "logisticsToolStripMenuItem";
            this.logisticsToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.logisticsToolStripMenuItem.Text = "Logistics";
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.planningToolStripMenuItem.Text = "Planning";
            // 
            // networkInternetToolStripMenuItem
            // 
            this.networkInternetToolStripMenuItem.Name = "networkInternetToolStripMenuItem";
            this.networkInternetToolStripMenuItem.Size = new System.Drawing.Size(178, 29);
            this.networkInternetToolStripMenuItem.Text = "Network / Internet";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.helpToolStripMenuItem.Text = "Help";
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
            this.pnlIAP.Location = new System.Drawing.Point(12, 255);
            this.pnlIAP.Name = "pnlIAP";
            this.pnlIAP.Size = new System.Drawing.Size(510, 36);
            this.pnlIAP.TabIndex = 50;
            // 
            // lblIAP
            // 
            this.lblIAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIAP.Location = new System.Drawing.Point(3, 2);
            this.lblIAP.Name = "lblIAP";
            this.lblIAP.Size = new System.Drawing.Size(468, 29);
            this.lblIAP.TabIndex = 30;
            this.lblIAP.Text = "Incident Action Plan";
            this.lblIAP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTransportPlan
            // 
            this.btnTransportPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransportPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnTransportPlan.Image")));
            this.btnTransportPlan.Location = new System.Drawing.Point(481, 175);
            this.btnTransportPlan.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTransportPlan.Name = "btnTransportPlan";
            this.btnTransportPlan.Size = new System.Drawing.Size(227, 61);
            this.btnTransportPlan.TabIndex = 9;
            this.btnTransportPlan.Text = "Transportation Plan (307)";
            this.btnTransportPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTransportPlan.UseVisualStyleBackColor = true;
            // 
            // btnBriefings2
            // 
            this.btnBriefings2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBriefings2.Image = ((System.Drawing.Image)(resources.GetObject("btnBriefings2.Image")));
            this.btnBriefings2.Location = new System.Drawing.Point(8, 36);
            this.btnBriefings2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnBriefings2.Name = "btnBriefings2";
            this.btnBriefings2.Size = new System.Drawing.Size(227, 61);
            this.btnBriefings2.TabIndex = 8;
            this.btnBriefings2.Text = "SMEAC Briefings";
            this.btnBriefings2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBriefings2.UseVisualStyleBackColor = true;
            // 
            // btnExpandIAP
            // 
            this.btnExpandIAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandIAP.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandIAP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandIAP.BackgroundImage")));
            this.btnExpandIAP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpandIAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandIAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandIAP.Location = new System.Drawing.Point(480, 4);
            this.btnExpandIAP.Name = "btnExpandIAP";
            this.btnExpandIAP.Size = new System.Drawing.Size(25, 25);
            this.btnExpandIAP.TabIndex = 29;
            this.btnExpandIAP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandIAP.UseVisualStyleBackColor = false;
            // 
            // btnSafetyPlans
            // 
            this.btnSafetyPlans.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSafetyPlans.Image = ((System.Drawing.Image)(resources.GetObject("btnSafetyPlans.Image")));
            this.btnSafetyPlans.Location = new System.Drawing.Point(245, 175);
            this.btnSafetyPlans.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSafetyPlans.Name = "btnSafetyPlans";
            this.btnSafetyPlans.Size = new System.Drawing.Size(227, 61);
            this.btnSafetyPlans.TabIndex = 6;
            this.btnSafetyPlans.Text = "Safety Plans (305)";
            this.btnSafetyPlans.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSafetyPlans.UseVisualStyleBackColor = true;
            // 
            // btnMedicalPlan
            // 
            this.btnMedicalPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMedicalPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicalPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicalPlan.Image")));
            this.btnMedicalPlan.Location = new System.Drawing.Point(8, 105);
            this.btnMedicalPlan.Name = "btnMedicalPlan";
            this.btnMedicalPlan.Size = new System.Drawing.Size(227, 61);
            this.btnMedicalPlan.TabIndex = 28;
            this.btnMedicalPlan.Text = "Medical Plan (206)";
            this.btnMedicalPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMedicalPlan.UseVisualStyleBackColor = true;
            // 
            // btnPrintOrgChart
            // 
            this.btnPrintOrgChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPrintOrgChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOrgChart.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintOrgChart.Image")));
            this.btnPrintOrgChart.Location = new System.Drawing.Point(245, 105);
            this.btnPrintOrgChart.Name = "btnPrintOrgChart";
            this.btnPrintOrgChart.Size = new System.Drawing.Size(227, 61);
            this.btnPrintOrgChart.TabIndex = 25;
            this.btnPrintOrgChart.Text = "Organization Chart (207)";
            this.btnPrintOrgChart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnPrintOrgChart.UseVisualStyleBackColor = true;
            // 
            // btnCommsPlan
            // 
            this.btnCommsPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCommsPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommsPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnCommsPlan.Image")));
            this.btnCommsPlan.Location = new System.Drawing.Point(481, 36);
            this.btnCommsPlan.Name = "btnCommsPlan";
            this.btnCommsPlan.Size = new System.Drawing.Size(227, 61);
            this.btnCommsPlan.TabIndex = 27;
            this.btnCommsPlan.Text = "Communications Plan (205)";
            this.btnCommsPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCommsPlan.UseVisualStyleBackColor = true;
            // 
            // btnSubjectProfile
            // 
            this.btnSubjectProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjectProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnSubjectProfile.Image")));
            this.btnSubjectProfile.Location = new System.Drawing.Point(8, 175);
            this.btnSubjectProfile.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSubjectProfile.Name = "btnSubjectProfile";
            this.btnSubjectProfile.Size = new System.Drawing.Size(227, 61);
            this.btnSubjectProfile.TabIndex = 11;
            this.btnSubjectProfile.Text = "Subject Profile (301)";
            this.btnSubjectProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSubjectProfile.UseVisualStyleBackColor = true;
            // 
            // btnPrintIAP
            // 
            this.btnPrintIAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintIAP.Location = new System.Drawing.Point(8, 244);
            this.btnPrintIAP.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnPrintIAP.Name = "btnPrintIAP";
            this.btnPrintIAP.Size = new System.Drawing.Size(700, 64);
            this.btnPrintIAP.TabIndex = 26;
            this.btnPrintIAP.Text = "Print Incident Action Plan";
            this.btnPrintIAP.UseVisualStyleBackColor = true;
            // 
            // btnIncidentObjectives
            // 
            this.btnIncidentObjectives.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncidentObjectives.Image = ((System.Drawing.Image)(resources.GetObject("btnIncidentObjectives.Image")));
            this.btnIncidentObjectives.Location = new System.Drawing.Point(245, 36);
            this.btnIncidentObjectives.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnIncidentObjectives.Name = "btnIncidentObjectives";
            this.btnIncidentObjectives.Size = new System.Drawing.Size(227, 61);
            this.btnIncidentObjectives.TabIndex = 12;
            this.btnIncidentObjectives.Text = "Incident Objectives (202)";
            this.btnIncidentObjectives.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnIncidentObjectives.UseVisualStyleBackColor = true;
            // 
            // btnOpsPlan
            // 
            this.btnOpsPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpsPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnOpsPlan.Image")));
            this.btnOpsPlan.Location = new System.Drawing.Point(481, 105);
            this.btnOpsPlan.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOpsPlan.Name = "btnOpsPlan";
            this.btnOpsPlan.Size = new System.Drawing.Size(227, 61);
            this.btnOpsPlan.TabIndex = 10;
            this.btnOpsPlan.Text = "Operations Plan (215)";
            this.btnOpsPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOpsPlan.UseVisualStyleBackColor = true;
            // 
            // pnlTeamStatus
            // 
            this.pnlTeamStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTeamStatus.BackColor = System.Drawing.Color.White;
            this.pnlTeamStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeamStatus.Controls.Add(this.btnOpsAssignments);
            this.pnlTeamStatus.Controls.Add(this.btnOpsMemberStatus);
            this.pnlTeamStatus.Controls.Add(this.btnOpsDashboard);
            this.pnlTeamStatus.Controls.Add(this.btnTeamStatus);
            this.pnlTeamStatus.Controls.Add(this.btnExpandTeamStatus);
            this.pnlTeamStatus.Controls.Add(this.btnCommsLog);
            this.pnlTeamStatus.Controls.Add(this.label14);
            this.pnlTeamStatus.Location = new System.Drawing.Point(528, 255);
            this.pnlTeamStatus.Name = "pnlTeamStatus";
            this.pnlTeamStatus.Size = new System.Drawing.Size(557, 36);
            this.pnlTeamStatus.TabIndex = 51;
            // 
            // btnOpsAssignments
            // 
            this.btnOpsAssignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpsAssignments.Image = ((System.Drawing.Image)(resources.GetObject("btnOpsAssignments.Image")));
            this.btnOpsAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpsAssignments.Location = new System.Drawing.Point(210, 105);
            this.btnOpsAssignments.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOpsAssignments.Name = "btnOpsAssignments";
            this.btnOpsAssignments.Size = new System.Drawing.Size(229, 59);
            this.btnOpsAssignments.TabIndex = 46;
            this.btnOpsAssignments.Text = "Team Assignments";
            this.btnOpsAssignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpsAssignments.UseVisualStyleBackColor = true;
            // 
            // btnOpsMemberStatus
            // 
            this.btnOpsMemberStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpsMemberStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnOpsMemberStatus.Image")));
            this.btnOpsMemberStatus.Location = new System.Drawing.Point(210, 172);
            this.btnOpsMemberStatus.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOpsMemberStatus.Name = "btnOpsMemberStatus";
            this.btnOpsMemberStatus.Size = new System.Drawing.Size(229, 59);
            this.btnOpsMemberStatus.TabIndex = 33;
            this.btnOpsMemberStatus.Text = "Member Status";
            this.btnOpsMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpsMemberStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpsMemberStatus.UseVisualStyleBackColor = true;
            // 
            // btnOpsDashboard
            // 
            this.btnOpsDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpsDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnOpsDashboard.Image")));
            this.btnOpsDashboard.Location = new System.Drawing.Point(6, 38);
            this.btnOpsDashboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOpsDashboard.Name = "btnOpsDashboard";
            this.btnOpsDashboard.Size = new System.Drawing.Size(543, 59);
            this.btnOpsDashboard.TabIndex = 32;
            this.btnOpsDashboard.Text = "Operations Dashboard";
            this.btnOpsDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpsDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOpsDashboard.UseVisualStyleBackColor = true;
            // 
            // btnTeamStatus
            // 
            this.btnTeamStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnTeamStatus.Image")));
            this.btnTeamStatus.Location = new System.Drawing.Point(6, 105);
            this.btnTeamStatus.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTeamStatus.Name = "btnTeamStatus";
            this.btnTeamStatus.Size = new System.Drawing.Size(192, 59);
            this.btnTeamStatus.TabIndex = 31;
            this.btnTeamStatus.Text = "Team Status";
            this.btnTeamStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTeamStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTeamStatus.UseVisualStyleBackColor = true;
            // 
            // btnExpandTeamStatus
            // 
            this.btnExpandTeamStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandTeamStatus.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandTeamStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandTeamStatus.BackgroundImage")));
            this.btnExpandTeamStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpandTeamStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandTeamStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandTeamStatus.Location = new System.Drawing.Point(527, 4);
            this.btnExpandTeamStatus.Name = "btnExpandTeamStatus";
            this.btnExpandTeamStatus.Size = new System.Drawing.Size(25, 25);
            this.btnExpandTeamStatus.TabIndex = 30;
            this.btnExpandTeamStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandTeamStatus.UseVisualStyleBackColor = false;
            // 
            // btnCommsLog
            // 
            this.btnCommsLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommsLog.Image = ((System.Drawing.Image)(resources.GetObject("btnCommsLog.Image")));
            this.btnCommsLog.Location = new System.Drawing.Point(6, 172);
            this.btnCommsLog.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnCommsLog.Name = "btnCommsLog";
            this.btnCommsLog.Size = new System.Drawing.Size(192, 59);
            this.btnCommsLog.TabIndex = 10;
            this.btnCommsLog.Text = "Comms Log";
            this.btnCommsLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCommsLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCommsLog.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 2);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(515, 29);
            this.label14.TabIndex = 0;
            this.label14.Text = "Operations";
            // 
            // pnlLogistics
            // 
            this.pnlLogistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlLogistics.Location = new System.Drawing.Point(528, 297);
            this.pnlLogistics.Name = "pnlLogistics";
            this.pnlLogistics.Size = new System.Drawing.Size(557, 36);
            this.pnlLogistics.TabIndex = 52;
            // 
            // btnLogisticsBulkSignIn
            // 
            this.btnLogisticsBulkSignIn.Image = ((System.Drawing.Image)(resources.GetObject("btnLogisticsBulkSignIn.Image")));
            this.btnLogisticsBulkSignIn.Location = new System.Drawing.Point(476, 172);
            this.btnLogisticsBulkSignIn.Name = "btnLogisticsBulkSignIn";
            this.btnLogisticsBulkSignIn.Size = new System.Drawing.Size(187, 57);
            this.btnLogisticsBulkSignIn.TabIndex = 46;
            this.btnLogisticsBulkSignIn.Text = "Bulk Sign In";
            this.btnLogisticsBulkSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsBulkSignIn.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsSignIn
            // 
            this.btnLogisticsSignIn.Image = ((System.Drawing.Image)(resources.GetObject("btnLogisticsSignIn.Image")));
            this.btnLogisticsSignIn.Location = new System.Drawing.Point(211, 172);
            this.btnLogisticsSignIn.Name = "btnLogisticsSignIn";
            this.btnLogisticsSignIn.Size = new System.Drawing.Size(259, 57);
            this.btnLogisticsSignIn.TabIndex = 45;
            this.btnLogisticsSignIn.Text = "Add a Member / Sign In";
            this.btnLogisticsSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsSignIn.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsMemberStatus
            // 
            this.btnLogisticsMemberStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogisticsMemberStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnLogisticsMemberStatus.Image")));
            this.btnLogisticsMemberStatus.Location = new System.Drawing.Point(6, 172);
            this.btnLogisticsMemberStatus.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnLogisticsMemberStatus.Name = "btnLogisticsMemberStatus";
            this.btnLogisticsMemberStatus.Size = new System.Drawing.Size(192, 57);
            this.btnLogisticsMemberStatus.TabIndex = 44;
            this.btnLogisticsMemberStatus.Text = "Member Status";
            this.btnLogisticsMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogisticsMemberStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsMemberStatus.UseVisualStyleBackColor = true;
            // 
            // btnAdditionalContacts
            // 
            this.btnAdditionalContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdditionalContacts.Image = ((System.Drawing.Image)(resources.GetObject("btnAdditionalContacts.Image")));
            this.btnAdditionalContacts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdditionalContacts.Location = new System.Drawing.Point(486, 105);
            this.btnAdditionalContacts.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAdditionalContacts.Name = "btnAdditionalContacts";
            this.btnAdditionalContacts.Size = new System.Drawing.Size(177, 60);
            this.btnAdditionalContacts.TabIndex = 43;
            this.btnAdditionalContacts.Text = "Additional Contacts";
            this.btnAdditionalContacts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdditionalContacts.UseVisualStyleBackColor = true;
            // 
            // btnMemberNeeds
            // 
            this.btnMemberNeeds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberNeeds.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberNeeds.Image")));
            this.btnMemberNeeds.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMemberNeeds.Location = new System.Drawing.Point(331, 105);
            this.btnMemberNeeds.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnMemberNeeds.Name = "btnMemberNeeds";
            this.btnMemberNeeds.Size = new System.Drawing.Size(143, 60);
            this.btnMemberNeeds.TabIndex = 42;
            this.btnMemberNeeds.Text = "Member Needs";
            this.btnMemberNeeds.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMemberNeeds.UseVisualStyleBackColor = true;
            // 
            // btnEquipment
            // 
            this.btnEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipment.Image = ((System.Drawing.Image)(resources.GetObject("btnEquipment.Image")));
            this.btnEquipment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEquipment.Location = new System.Drawing.Point(6, 105);
            this.btnEquipment.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnEquipment.Name = "btnEquipment";
            this.btnEquipment.Size = new System.Drawing.Size(159, 60);
            this.btnEquipment.TabIndex = 41;
            this.btnEquipment.Text = "Equipment";
            this.btnEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEquipment.UseVisualStyleBackColor = true;
            // 
            // btnVehicles
            // 
            this.btnVehicles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVehicles.Image = ((System.Drawing.Image)(resources.GetObject("btnVehicles.Image")));
            this.btnVehicles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVehicles.Location = new System.Drawing.Point(177, 105);
            this.btnVehicles.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(142, 60);
            this.btnVehicles.TabIndex = 40;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVehicles.UseVisualStyleBackColor = true;
            // 
            // btnLogisticsDashboard
            // 
            this.btnLogisticsDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogisticsDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnLogisticsDashboard.Image")));
            this.btnLogisticsDashboard.Location = new System.Drawing.Point(6, 38);
            this.btnLogisticsDashboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnLogisticsDashboard.Name = "btnLogisticsDashboard";
            this.btnLogisticsDashboard.Size = new System.Drawing.Size(657, 59);
            this.btnLogisticsDashboard.TabIndex = 32;
            this.btnLogisticsDashboard.Text = "Logistics Dashboard";
            this.btnLogisticsDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogisticsDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsDashboard.UseVisualStyleBackColor = true;
            // 
            // btnExpandLogistics
            // 
            this.btnExpandLogistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandLogistics.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandLogistics.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandLogistics.BackgroundImage")));
            this.btnExpandLogistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpandLogistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandLogistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandLogistics.Location = new System.Drawing.Point(527, 4);
            this.btnExpandLogistics.Name = "btnExpandLogistics";
            this.btnExpandLogistics.Size = new System.Drawing.Size(25, 25);
            this.btnExpandLogistics.TabIndex = 30;
            this.btnExpandLogistics.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandLogistics.UseVisualStyleBackColor = false;
            // 
            // lblLogisticsTitle
            // 
            this.lblLogisticsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogisticsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogisticsTitle.Location = new System.Drawing.Point(3, 2);
            this.lblLogisticsTitle.Name = "lblLogisticsTitle";
            this.lblLogisticsTitle.Size = new System.Drawing.Size(515, 29);
            this.lblLogisticsTitle.TabIndex = 0;
            this.lblLogisticsTitle.Text = "Logistics";
            // 
            // pnlPlanning
            // 
            this.pnlPlanning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.pnlPlanning.Location = new System.Drawing.Point(528, 339);
            this.pnlPlanning.Name = "pnlPlanning";
            this.pnlPlanning.Size = new System.Drawing.Size(557, 36);
            this.pnlPlanning.TabIndex = 53;
            // 
            // btnPlanningAddAssignment
            // 
            this.btnPlanningAddAssignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanningAddAssignment.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanningAddAssignment.Image")));
            this.btnPlanningAddAssignment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanningAddAssignment.Location = new System.Drawing.Point(253, 115);
            this.btnPlanningAddAssignment.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnPlanningAddAssignment.Name = "btnPlanningAddAssignment";
            this.btnPlanningAddAssignment.Size = new System.Drawing.Size(186, 64);
            this.btnPlanningAddAssignment.TabIndex = 45;
            this.btnPlanningAddAssignment.Text = "Add Team Assignment";
            this.btnPlanningAddAssignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlanningAddAssignment.UseVisualStyleBackColor = true;
            // 
            // btnTeamAssignments
            // 
            this.btnTeamAssignments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeamAssignments.Image = ((System.Drawing.Image)(resources.GetObject("btnTeamAssignments.Image")));
            this.btnTeamAssignments.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTeamAssignments.Location = new System.Drawing.Point(8, 115);
            this.btnTeamAssignments.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTeamAssignments.Name = "btnTeamAssignments";
            this.btnTeamAssignments.Size = new System.Drawing.Size(233, 64);
            this.btnTeamAssignments.TabIndex = 43;
            this.btnTeamAssignments.Text = "Team Assignments";
            this.btnTeamAssignments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTeamAssignments.UseVisualStyleBackColor = true;
            // 
            // btnReflexTasking
            // 
            this.btnReflexTasking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReflexTasking.Image = ((System.Drawing.Image)(resources.GetObject("btnReflexTasking.Image")));
            this.btnReflexTasking.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReflexTasking.Location = new System.Drawing.Point(451, 115);
            this.btnReflexTasking.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnReflexTasking.Name = "btnReflexTasking";
            this.btnReflexTasking.Size = new System.Drawing.Size(146, 64);
            this.btnReflexTasking.TabIndex = 44;
            this.btnReflexTasking.Text = "Reflex Tasking";
            this.btnReflexTasking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReflexTasking.UseVisualStyleBackColor = true;
            // 
            // btnTimeline
            // 
            this.btnTimeline.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeline.Image = ((System.Drawing.Image)(resources.GetObject("btnTimeline.Image")));
            this.btnTimeline.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimeline.Location = new System.Drawing.Point(492, 185);
            this.btnTimeline.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTimeline.Name = "btnTimeline";
            this.btnTimeline.Size = new System.Drawing.Size(127, 64);
            this.btnTimeline.TabIndex = 39;
            this.btnTimeline.Text = "Timeline";
            this.btnTimeline.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimeline.UseVisualStyleBackColor = true;
            // 
            // btnNotes
            // 
            this.btnNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotes.Image = ((System.Drawing.Image)(resources.GetObject("btnNotes.Image")));
            this.btnNotes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNotes.Location = new System.Drawing.Point(631, 185);
            this.btnNotes.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(113, 64);
            this.btnNotes.TabIndex = 38;
            this.btnNotes.Text = "Notes";
            this.btnNotes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNotes.UseVisualStyleBackColor = true;
            // 
            // btnSegmentation
            // 
            this.btnSegmentation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSegmentation.Image = ((System.Drawing.Image)(resources.GetObject("btnSegmentation.Image")));
            this.btnSegmentation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSegmentation.Location = new System.Drawing.Point(8, 187);
            this.btnSegmentation.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSegmentation.Name = "btnSegmentation";
            this.btnSegmentation.Size = new System.Drawing.Size(167, 64);
            this.btnSegmentation.TabIndex = 42;
            this.btnSegmentation.Text = "Segmentation";
            this.btnSegmentation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSegmentation.UseVisualStyleBackColor = true;
            // 
            // btnPlanningDashboard
            // 
            this.btnPlanningDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanningDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanningDashboard.Image")));
            this.btnPlanningDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanningDashboard.Location = new System.Drawing.Point(6, 45);
            this.btnPlanningDashboard.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnPlanningDashboard.Name = "btnPlanningDashboard";
            this.btnPlanningDashboard.Size = new System.Drawing.Size(738, 62);
            this.btnPlanningDashboard.TabIndex = 37;
            this.btnPlanningDashboard.Text = "Planning Dashboard";
            this.btnPlanningDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlanningDashboard.UseVisualStyleBackColor = true;
            // 
            // btnAssignmentStats
            // 
            this.btnAssignmentStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentStats.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignmentStats.Image")));
            this.btnAssignmentStats.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssignmentStats.Location = new System.Drawing.Point(323, 187);
            this.btnAssignmentStats.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAssignmentStats.Name = "btnAssignmentStats";
            this.btnAssignmentStats.Size = new System.Drawing.Size(157, 64);
            this.btnAssignmentStats.TabIndex = 41;
            this.btnAssignmentStats.Text = "Assignment Stats";
            this.btnAssignmentStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignmentStats.UseVisualStyleBackColor = true;
            // 
            // btnClues
            // 
            this.btnClues.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClues.Image = ((System.Drawing.Image)(resources.GetObject("btnClues.Image")));
            this.btnClues.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClues.Location = new System.Drawing.Point(610, 115);
            this.btnClues.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnClues.Name = "btnClues";
            this.btnClues.Size = new System.Drawing.Size(135, 64);
            this.btnClues.TabIndex = 36;
            this.btnClues.Text = "Clues";
            this.btnClues.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClues.UseVisualStyleBackColor = true;
            // 
            // btnMattson
            // 
            this.btnMattson.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMattson.Image = ((System.Drawing.Image)(resources.GetObject("btnMattson.Image")));
            this.btnMattson.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMattson.Location = new System.Drawing.Point(188, 187);
            this.btnMattson.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnMattson.Name = "btnMattson";
            this.btnMattson.Size = new System.Drawing.Size(123, 64);
            this.btnMattson.TabIndex = 40;
            this.btnMattson.Text = "Mattson";
            this.btnMattson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMattson.UseVisualStyleBackColor = true;
            // 
            // btnExpandPlanning
            // 
            this.btnExpandPlanning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandPlanning.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandPlanning.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandPlanning.BackgroundImage")));
            this.btnExpandPlanning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpandPlanning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandPlanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpandPlanning.Location = new System.Drawing.Point(527, 4);
            this.btnExpandPlanning.Name = "btnExpandPlanning";
            this.btnExpandPlanning.Size = new System.Drawing.Size(25, 25);
            this.btnExpandPlanning.TabIndex = 34;
            this.btnExpandPlanning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandPlanning.UseVisualStyleBackColor = false;
            // 
            // lblPlanningTitle
            // 
            this.lblPlanningTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlanningTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanningTitle.Location = new System.Drawing.Point(4, 0);
            this.lblPlanningTitle.Name = "lblPlanningTitle";
            this.lblPlanningTitle.Size = new System.Drawing.Size(517, 32);
            this.lblPlanningTitle.TabIndex = 33;
            this.lblPlanningTitle.Text = "Planning";
            this.lblPlanningTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.ics_canada_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // llProgramURL
            // 
            this.llProgramURL.AutoSize = true;
            this.llProgramURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llProgramURL.Location = new System.Drawing.Point(12, 141);
            this.llProgramURL.Name = "llProgramURL";
            this.llProgramURL.Size = new System.Drawing.Size(139, 20);
            this.llProgramURL.TabIndex = 55;
            this.llProgramURL.TabStop = true;
            this.llProgramURL.Text = "www.icscanada.ca";
            this.llProgramURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llProgramURL_LinkClicked);
            // 
            // IncidentDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1095, 711);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "IncidentDetailsForm";
            this.Text = "Wildfire ICS Assist - Incident Details";
            this.pnlOpsPeriod.ResumeLayout(false);
            this.pnlOpsPeriod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).EndInit();
            this.pnlTaskInfo.ResumeLayout(false);
            this.pnlTaskInfo.PerformLayout();
            this.tcStatus.ResumeLayout(false);
            this.tpCommsLog.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsLog)).EndInit();
            this.tpAssignmentList.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamAssignments)).EndInit();
            this.tpTeamStatus.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeamStatus)).EndInit();
            this.tpMembersOnTask.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembersOnTask)).EndInit();
            this.tpEquipment.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskEquipment)).EndInit();
            this.tpWhiteBoard.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWhiteboard)).EndInit();
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
        private System.Windows.Forms.TabPage tpCommsLog;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvCommsLog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCritical;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationCalled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThisIs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.Button btnAddCommsLog;
        private System.Windows.Forms.CheckBox chkECCReminderThisDevice;
        private System.Windows.Forms.Button btnViewCommsInNewWindow;
        private System.Windows.Forms.Label lblLastECC;
        private System.Windows.Forms.TabPage tpAssignmentList;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvTeamAssignments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstimatedSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStatus;
        private System.Windows.Forms.Button btnAssignmentsTabPlanningDash;
        private System.Windows.Forms.Button btnAssignmentsTabOpsDash;
        private System.Windows.Forms.Button btnAssignmentsTabAssignments;
        private System.Windows.Forms.TabPage tpTeamStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvTeamStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastCheckin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastMessage;
        private System.Windows.Forms.Button btnViewTeamStatusInNewWindow;
        private System.Windows.Forms.CheckBox chkIncludeInactiveInStatusList;
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
        private System.Windows.Forms.TabPage tpWhiteBoard;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dgvWhiteboard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOutstanding;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWhiteboardItemText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateAdded;
        private System.Windows.Forms.TextBox txtNewWhiteboard;
        private System.Windows.Forms.Button btnOpenWhiteboard;
        private System.Windows.Forms.Button btnAddWhiteboard;
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
    }
}

