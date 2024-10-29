namespace Wildfire_ICS_Assist
{
    partial class CheckedInResourcesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckedInResourcesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.progBuildList = new System.Windows.Forms.ProgressBar();
            this.dgvResources = new System.Windows.Forms.DataGridView();
            this.colVariety = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInitialRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCheckInInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUniqueIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demobilizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cpFilters = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboExpandCrews = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFilter3ShowHelp = new System.Windows.Forms.Button();
            this.cboAssignedFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTimeOutFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboResourceVariety = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cpPNumbers = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.btnPNumHelp = new System.Windows.Forms.Button();
            this.numCNumMax = new System.Windows.Forms.NumericUpDown();
            this.numCNumMin = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCNumTitle = new System.Windows.Forms.Label();
            this.numENumMax = new System.Windows.Forms.NumericUpDown();
            this.numENumMin = new System.Windows.Forms.NumericUpDown();
            this.numVNumMax = new System.Windows.Forms.NumericUpDown();
            this.numVNumMin = new System.Windows.Forms.NumericUpDown();
            this.numPNumMax = new System.Windows.Forms.NumericUpDown();
            this.numPNumMin = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.lblENumTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVNumTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPNumTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnResourcePlanning = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnLogisticsOverview = new System.Windows.Forms.Button();
            this.btnDietaryAndAllergy = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeID = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditResource = new System.Windows.Forms.Button();
            this.btnEditCheckIn = new System.Windows.Forms.Button();
            this.btnDemob = new System.Windows.Forms.Button();
            this.pnlSignIn = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStartCheckIn = new System.Windows.Forms.Button();
            this.btnCheckInByManifest = new System.Windows.Forms.Button();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.cmsPrint211 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printNewICS211sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllICS211sToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.checkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCheckInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementPlanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSavedRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importSavedVehiclesEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSavedVehiclesEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editSavedAircraftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLogisticsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printDietaryAndAllergySummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printNewICS211sToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.printAllICS211sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportCheckInDataToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResources)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.cpFilters.SuspendLayout();
            this.cpPNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMin)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSignIn.SuspendLayout();
            this.cmsPrint211.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.pnlSignIn);
            this.splitContainer1.Panel2.Controls.Add(this.btnCheckInByManifest);
            this.splitContainer1.Size = new System.Drawing.Size(1348, 571);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvResources);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.progBuildList);
            this.splitContainer2.Panel2.Controls.Add(this.btnRefresh);
            this.splitContainer2.Panel2.Controls.Add(this.cpFilters);
            this.splitContainer2.Panel2.Controls.Add(this.cpPNumbers);
            this.splitContainer2.Size = new System.Drawing.Size(1348, 409);
            this.splitContainer2.SplitterDistance = 1042;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer2_SplitterMoving);
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // progBuildList
            // 
            this.progBuildList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBuildList.Location = new System.Drawing.Point(2, 60);
            this.progBuildList.Name = "progBuildList";
            this.progBuildList.Size = new System.Drawing.Size(299, 16);
            this.progBuildList.TabIndex = 2;
            this.progBuildList.Value = 50;
            this.progBuildList.Visible = false;
            // 
            // dgvResources
            // 
            this.dgvResources.AllowUserToAddRows = false;
            this.dgvResources.AllowUserToDeleteRows = false;
            this.dgvResources.AllowUserToOrderColumns = true;
            this.dgvResources.AllowUserToResizeColumns = false;
            this.dgvResources.AllowUserToResizeRows = false;
            this.dgvResources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResources.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVariety,
            this.colID,
            this.colName,
            this.colKind,
            this.colType,
            this.colInitialRole,
            this.colLeader,
            this.colNumberOfPeople,
            this.colNumberOfEquipment,
            this.colCheckIn,
            this.colLastDay,
            this.colStatus});
            this.dgvResources.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResources.Location = new System.Drawing.Point(0, 0);
            this.dgvResources.Name = "dgvResources";
            this.dgvResources.ReadOnly = true;
            this.dgvResources.RowHeadersVisible = false;
            this.dgvResources.RowTemplate.Height = 30;
            this.dgvResources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResources.Size = new System.Drawing.Size(1042, 409);
            this.dgvResources.TabIndex = 1;
            this.dgvResources.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResources_CellFormatting);
            this.dgvResources.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResources_ColumnHeaderMouseClick);
            this.dgvResources.SelectionChanged += new System.EventHandler(this.dgvResources_SelectionChanged);
            this.dgvResources.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvResources_MouseUp);
            // 
            // colVariety
            // 
            this.colVariety.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariety.DataPropertyName = "ResourceType";
            this.colVariety.HeaderText = "Variety";
            this.colVariety.Name = "colVariety";
            this.colVariety.ReadOnly = true;
            this.colVariety.Width = 92;
            // 
            // colID
            // 
            this.colID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colID.DataPropertyName = "UniqueIDNumWithPrefix";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Width = 52;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.HeaderText = "Resource";
            this.colName.MinimumWidth = 200;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colKind
            // 
            this.colKind.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colKind.DataPropertyName = "Kind";
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            this.colKind.Width = 73;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 78;
            // 
            // colInitialRole
            // 
            this.colInitialRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colInitialRole.DataPropertyName = "InitialRoleAcronym";
            this.colInitialRole.HeaderText = "Initial Role";
            this.colInitialRole.Name = "colInitialRole";
            this.colInitialRole.ReadOnly = true;
            this.colInitialRole.Width = 120;
            // 
            // colLeader
            // 
            this.colLeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLeader.DataPropertyName = "LeaderName";
            this.colLeader.HeaderText = "Leader";
            this.colLeader.Name = "colLeader";
            this.colLeader.ReadOnly = true;
            this.colLeader.Width = 94;
            // 
            // colNumberOfPeople
            // 
            this.colNumberOfPeople.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNumberOfPeople.DataPropertyName = "NumberOfPeople";
            this.colNumberOfPeople.HeaderText = "# Ppl";
            this.colNumberOfPeople.Name = "colNumberOfPeople";
            this.colNumberOfPeople.ReadOnly = true;
            this.colNumberOfPeople.Width = 77;
            // 
            // colNumberOfEquipment
            // 
            this.colNumberOfEquipment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNumberOfEquipment.DataPropertyName = "NumberOfVehicles";
            this.colNumberOfEquipment.HeaderText = "# Equip";
            this.colNumberOfEquipment.Name = "colNumberOfEquipment";
            this.colNumberOfEquipment.ReadOnly = true;
            // 
            // colCheckIn
            // 
            this.colCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCheckIn.DataPropertyName = "CheckInDate";
            dataGridViewCellStyle3.Format = "MMM-dd-yyyy";
            dataGridViewCellStyle3.NullValue = null;
            this.colCheckIn.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCheckIn.HeaderText = "Check In";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.ReadOnly = true;
            this.colCheckIn.Width = 109;
            // 
            // colLastDay
            // 
            this.colLastDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastDay.DataPropertyName = "LastDayOnIncidentStr";
            dataGridViewCellStyle4.Format = "MMM-dd-yyyy";
            dataGridViewCellStyle4.NullValue = null;
            this.colLastDay.DefaultCellStyle = dataGridViewCellStyle4;
            this.colLastDay.HeaderText = "Last Day";
            this.colLastDay.Name = "colLastDay";
            this.colLastDay.ReadOnly = true;
            this.colLastDay.Width = 105;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 85;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.editCheckInInfoToolStripMenuItem,
            this.changeUniqueIDToolStripMenuItem,
            this.demobilizeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(262, 116);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.editToolStripMenuItem.Text = "Edit Resource";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // editCheckInInfoToolStripMenuItem
            // 
            this.editCheckInInfoToolStripMenuItem.Name = "editCheckInInfoToolStripMenuItem";
            this.editCheckInInfoToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.editCheckInInfoToolStripMenuItem.Text = "Edit Check-In Info";
            this.editCheckInInfoToolStripMenuItem.Click += new System.EventHandler(this.editCheckInInfoToolStripMenuItem_Click);
            // 
            // changeUniqueIDToolStripMenuItem
            // 
            this.changeUniqueIDToolStripMenuItem.Name = "changeUniqueIDToolStripMenuItem";
            this.changeUniqueIDToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.changeUniqueIDToolStripMenuItem.Text = "Change Unique ID #";
            this.changeUniqueIDToolStripMenuItem.Click += new System.EventHandler(this.changeUniqueIDToolStripMenuItem_Click);
            // 
            // demobilizeToolStripMenuItem
            // 
            this.demobilizeToolStripMenuItem.Name = "demobilizeToolStripMenuItem";
            this.demobilizeToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.demobilizeToolStripMenuItem.Text = "Demobilize Resource";
            this.demobilizeToolStripMenuItem.Click += new System.EventHandler(this.demobilizeToolStripMenuItem_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_82_refresh;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRefresh.Location = new System.Drawing.Point(15, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(272, 48);
            this.btnRefresh.TabIndex = 57;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cpFilters
            // 
            this.cpFilters.BackColor = System.Drawing.Color.White;
            this.cpFilters.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFilters.HeightWhenCollapsed = 40;
            this.cpFilters.WidthWhenCollapsed = 290;
            this.cpFilters.ExpandsRight = true;
            this.cpFilters.Controls.Add(this.cboExpandCrews);
            this.cpFilters.Controls.Add(this.label4);
            this.cpFilters.Controls.Add(this.btnFilter3ShowHelp);
            this.cpFilters.Controls.Add(this.cboAssignedFilter);
            this.cpFilters.Controls.Add(this.label3);
            this.cpFilters.Controls.Add(this.cboTimeOutFilter);
            this.cpFilters.Controls.Add(this.label2);
            this.cpFilters.Controls.Add(this.cboResourceVariety);
            this.cpFilters.Controls.Add(this.label1);
            this.cpFilters.Collapsed = false;
            this.cpFilters.HeightWhenExpanded = 322;
            this.cpFilters.WidthWhenExpanded = 290;
            this.cpFilters.ExpandsUpward = false;
            this.cpFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpFilters.Location = new System.Drawing.Point(6, 81);
            this.cpFilters.Margin = new System.Windows.Forms.Padding(6);
            this.cpFilters.Name = "cpFilters";
            this.cpFilters.Size = new System.Drawing.Size(290, 322);
            this.cpFilters.TabIndex = 0;
            this.cpFilters.TitleText = "Filter List";
            // 
            // cboExpandCrews
            // 
            this.cboExpandCrews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExpandCrews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpandCrews.DropDownWidth = 500;
            this.cboExpandCrews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboExpandCrews.FormattingEnabled = true;
            this.cboExpandCrews.Items.AddRange(new object[] {
            "Show Crew and Vehicle/Equipment entries only",
            "Show all resources assigned to crews individually"});
            this.cboExpandCrews.Location = new System.Drawing.Point(7, 281);
            this.cboExpandCrews.Name = "cboExpandCrews";
            this.cboExpandCrews.Size = new System.Drawing.Size(276, 32);
            this.cboExpandCrews.TabIndex = 95;
            this.cboExpandCrews.SelectedIndexChanged += new System.EventHandler(this.cboExpandCrews_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(3, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 24);
            this.label4.TabIndex = 94;
            this.label4.Text = "Crews and Equipment Operators";
            // 
            // btnFilter3ShowHelp
            // 
            this.btnFilter3ShowHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter3ShowHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFilter3ShowHelp.BackgroundImage")));
            this.btnFilter3ShowHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter3ShowHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnFilter3ShowHelp.Location = new System.Drawing.Point(256, 171);
            this.btnFilter3ShowHelp.Name = "btnFilter3ShowHelp";
            this.btnFilter3ShowHelp.Size = new System.Drawing.Size(26, 26);
            this.btnFilter3ShowHelp.TabIndex = 93;
            this.btnFilter3ShowHelp.TabStop = false;
            this.btnFilter3ShowHelp.UseVisualStyleBackColor = true;
            // 
            // cboAssignedFilter
            // 
            this.cboAssignedFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssignedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssignedFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboAssignedFilter.FormattingEnabled = true;
            this.cboAssignedFilter.Items.AddRange(new object[] {
            "All resources",
            "Unassigned Only"});
            this.cboAssignedFilter.Location = new System.Drawing.Point(7, 203);
            this.cboAssignedFilter.Name = "cboAssignedFilter";
            this.cboAssignedFilter.Size = new System.Drawing.Size(276, 32);
            this.cboAssignedFilter.TabIndex = 38;
            this.cboAssignedFilter.SelectedIndexChanged += new System.EventHandler(this.cboAssignedFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(3, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Resource Assigned";
            // 
            // cboTimeOutFilter
            // 
            this.cboTimeOutFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTimeOutFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeOutFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboTimeOutFilter.FormattingEnabled = true;
            this.cboTimeOutFilter.Location = new System.Drawing.Point(7, 133);
            this.cboTimeOutFilter.Name = "cboTimeOutFilter";
            this.cboTimeOutFilter.Size = new System.Drawing.Size(276, 32);
            this.cboTimeOutFilter.TabIndex = 36;
            this.cboTimeOutFilter.SelectedIndexChanged += new System.EventHandler(this.cboTimeOutFilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(3, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "By Last Day on Incident";
            // 
            // cboResourceVariety
            // 
            this.cboResourceVariety.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResourceVariety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResourceVariety.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboResourceVariety.FormattingEnabled = true;
            this.cboResourceVariety.Items.AddRange(new object[] {
            "All Resources",
            "Personnel",
            "Visitor",
            "Equipment",
            "Operator",
            "Crew",
            "Heavy Equipment Crew",
            "Aircraft"});
            this.cboResourceVariety.Location = new System.Drawing.Point(7, 71);
            this.cboResourceVariety.Name = "cboResourceVariety";
            this.cboResourceVariety.Size = new System.Drawing.Size(276, 32);
            this.cboResourceVariety.TabIndex = 34;
            this.cboResourceVariety.SelectedIndexChanged += new System.EventHandler(this.cboResourceVariety_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Resource Variety";
            // 
            // cpPNumbers
            // 
            this.cpPNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpPNumbers.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpPNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpPNumbers.HeightWhenCollapsed = 40;
            this.cpPNumbers.WidthWhenCollapsed = 290;
            this.cpPNumbers.ExpandsRight = true;
            this.cpPNumbers.Controls.Add(this.btnPNumHelp);
            this.cpPNumbers.Controls.Add(this.numCNumMax);
            this.cpPNumbers.Controls.Add(this.numCNumMin);
            this.cpPNumbers.Controls.Add(this.label10);
            this.cpPNumbers.Controls.Add(this.lblCNumTitle);
            this.cpPNumbers.Controls.Add(this.numENumMax);
            this.cpPNumbers.Controls.Add(this.numENumMin);
            this.cpPNumbers.Controls.Add(this.numVNumMax);
            this.cpPNumbers.Controls.Add(this.numVNumMin);
            this.cpPNumbers.Controls.Add(this.numPNumMax);
            this.cpPNumbers.Controls.Add(this.numPNumMin);
            this.cpPNumbers.Controls.Add(this.label9);
            this.cpPNumbers.Controls.Add(this.lblENumTitle);
            this.cpPNumbers.Controls.Add(this.label7);
            this.cpPNumbers.Controls.Add(this.lblVNumTitle);
            this.cpPNumbers.Controls.Add(this.label5);
            this.cpPNumbers.Controls.Add(this.lblPNumTitle);
            this.cpPNumbers.Collapsed = true;
            this.cpPNumbers.HeightWhenExpanded = 357;
            this.cpPNumbers.WidthWhenExpanded = 290;
            this.cpPNumbers.ExpandsUpward = true;
            this.cpPNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPNumbers.Location = new System.Drawing.Point(278, 399);
            this.cpPNumbers.Margin = new System.Windows.Forms.Padding(6);
            this.cpPNumbers.Name = "cpPNumbers";
            this.cpPNumbers.Size = new System.Drawing.Size(275, 30);
            this.cpPNumbers.TabIndex = 2;
            this.cpPNumbers.TitleText = "Resource Numbers";
            this.cpPNumbers.Visible = false;
            // 
            // btnPNumHelp
            // 
            this.btnPNumHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPNumHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPNumHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnPNumHelp.Image")));
            this.btnPNumHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPNumHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPNumHelp.Location = new System.Drawing.Point(-3, 48);
            this.btnPNumHelp.Name = "btnPNumHelp";
            this.btnPNumHelp.Size = new System.Drawing.Size(245, 49);
            this.btnPNumHelp.TabIndex = 88;
            this.btnPNumHelp.TabStop = false;
            this.btnPNumHelp.Text = "Help";
            this.btnPNumHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPNumHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPNumHelp.UseVisualStyleBackColor = true;
            this.btnPNumHelp.Click += new System.EventHandler(this.btnPNumHelp_Click);
            // 
            // numCNumMax
            // 
            this.numCNumMax.Location = new System.Drawing.Point(142, 318);
            this.numCNumMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCNumMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCNumMax.Name = "numCNumMax";
            this.numCNumMax.Size = new System.Drawing.Size(85, 29);
            this.numCNumMax.TabIndex = 48;
            this.numCNumMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCNumMax.ValueChanged += new System.EventHandler(this.numCNumMax_ValueChanged);
            // 
            // numCNumMin
            // 
            this.numCNumMin.Location = new System.Drawing.Point(12, 318);
            this.numCNumMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numCNumMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCNumMin.Name = "numCNumMin";
            this.numCNumMin.Size = new System.Drawing.Size(85, 29);
            this.numCNumMin.TabIndex = 47;
            this.numCNumMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCNumMin.ValueChanged += new System.EventHandler(this.numCNumMin_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 24);
            this.label10.TabIndex = 46;
            this.label10.Text = "To";
            // 
            // lblCNumTitle
            // 
            this.lblCNumTitle.AutoSize = true;
            this.lblCNumTitle.Location = new System.Drawing.Point(12, 289);
            this.lblCNumTitle.Name = "lblCNumTitle";
            this.lblCNumTitle.Size = new System.Drawing.Size(208, 24);
            this.lblCNumTitle.TabIndex = 45;
            this.lblCNumTitle.Text = "Crew Numbers (CNum)";
            // 
            // numENumMax
            // 
            this.numENumMax.Location = new System.Drawing.Point(142, 255);
            this.numENumMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numENumMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numENumMax.Name = "numENumMax";
            this.numENumMax.Size = new System.Drawing.Size(85, 29);
            this.numENumMax.TabIndex = 44;
            this.numENumMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numENumMax.ValueChanged += new System.EventHandler(this.numENumMax_ValueChanged);
            // 
            // numENumMin
            // 
            this.numENumMin.Location = new System.Drawing.Point(12, 255);
            this.numENumMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numENumMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numENumMin.Name = "numENumMin";
            this.numENumMin.Size = new System.Drawing.Size(85, 29);
            this.numENumMin.TabIndex = 43;
            this.numENumMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numENumMin.ValueChanged += new System.EventHandler(this.numENumMin_ValueChanged);
            // 
            // numVNumMax
            // 
            this.numVNumMax.Location = new System.Drawing.Point(142, 192);
            this.numVNumMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numVNumMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVNumMax.Name = "numVNumMax";
            this.numVNumMax.Size = new System.Drawing.Size(85, 29);
            this.numVNumMax.TabIndex = 42;
            this.numVNumMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numVNumMax.ValueChanged += new System.EventHandler(this.numVNumMax_ValueChanged);
            // 
            // numVNumMin
            // 
            this.numVNumMin.Location = new System.Drawing.Point(12, 192);
            this.numVNumMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numVNumMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVNumMin.Name = "numVNumMin";
            this.numVNumMin.Size = new System.Drawing.Size(85, 29);
            this.numVNumMin.TabIndex = 41;
            this.numVNumMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVNumMin.ValueChanged += new System.EventHandler(this.numVNumMin_ValueChanged);
            // 
            // numPNumMax
            // 
            this.numPNumMax.Location = new System.Drawing.Point(142, 129);
            this.numPNumMax.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPNumMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPNumMax.Name = "numPNumMax";
            this.numPNumMax.Size = new System.Drawing.Size(85, 29);
            this.numPNumMax.TabIndex = 40;
            this.numPNumMax.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPNumMax.ValueChanged += new System.EventHandler(this.numPNumMax_ValueChanged);
            // 
            // numPNumMin
            // 
            this.numPNumMin.Location = new System.Drawing.Point(12, 129);
            this.numPNumMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPNumMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPNumMin.Name = "numPNumMin";
            this.numPNumMin.Size = new System.Drawing.Size(85, 29);
            this.numPNumMin.TabIndex = 39;
            this.numPNumMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPNumMin.ValueChanged += new System.EventHandler(this.numPNumMin_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 24);
            this.label9.TabIndex = 38;
            this.label9.Text = "To";
            // 
            // lblENumTitle
            // 
            this.lblENumTitle.AutoSize = true;
            this.lblENumTitle.Location = new System.Drawing.Point(12, 226);
            this.lblENumTitle.Name = "lblENumTitle";
            this.lblENumTitle.Size = new System.Drawing.Size(256, 24);
            this.lblENumTitle.TabIndex = 37;
            this.lblENumTitle.Text = "Equipment Numbers (ENum)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 24);
            this.label7.TabIndex = 36;
            this.label7.Text = "To";
            // 
            // lblVNumTitle
            // 
            this.lblVNumTitle.AutoSize = true;
            this.lblVNumTitle.Location = new System.Drawing.Point(12, 163);
            this.lblVNumTitle.Name = "lblVNumTitle";
            this.lblVNumTitle.Size = new System.Drawing.Size(228, 24);
            this.lblVNumTitle.TabIndex = 35;
            this.lblVNumTitle.Text = "Vehicle Numbers (VNum)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "To";
            // 
            // lblPNumTitle
            // 
            this.lblPNumTitle.AutoSize = true;
            this.lblPNumTitle.Location = new System.Drawing.Point(12, 100);
            this.lblPNumTitle.Name = "lblPNumTitle";
            this.lblPNumTitle.Size = new System.Drawing.Size(249, 24);
            this.lblPNumTitle.TabIndex = 33;
            this.lblPNumTitle.Text = "Personnel Numbers (PNum)";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.btnResourcePlanning);
            this.panel4.Location = new System.Drawing.Point(594, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(243, 145);
            this.panel4.TabIndex = 63;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(235, 29);
            this.label13.TabIndex = 7;
            this.label13.Text = "Resource Planning";
            // 
            // btnResourcePlanning
            // 
            this.btnResourcePlanning.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_46_calendar;
            this.btnResourcePlanning.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResourcePlanning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnResourcePlanning.Location = new System.Drawing.Point(8, 32);
            this.btnResourcePlanning.Name = "btnResourcePlanning";
            this.btnResourcePlanning.Size = new System.Drawing.Size(215, 105);
            this.btnResourcePlanning.TabIndex = 51;
            this.btnResourcePlanning.Text = "Replacement Plan";
            this.btnResourcePlanning.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResourcePlanning.UseVisualStyleBackColor = true;
            this.btnResourcePlanning.Click += new System.EventHandler(this.btnResourcePlanning_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.btnExportSignInToCSV);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Location = new System.Drawing.Point(1106, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 145);
            this.panel3.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(225, 29);
            this.label12.TabIndex = 7;
            this.label12.Text = "Output";
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(8, 86);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(214, 48);
            this.btnExportSignInToCSV.TabIndex = 50;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            this.btnExportSignInToCSV.Click += new System.EventHandler(this.btnExportSignInToCSV_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(8, 32);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(214, 48);
            this.btnPrint.TabIndex = 49;
            this.btnPrint.Text = "Print new ICS-211";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnLogisticsOverview);
            this.panel2.Controls.Add(this.btnDietaryAndAllergy);
            this.panel2.Location = new System.Drawing.Point(843, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 145);
            this.panel2.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(249, 29);
            this.label11.TabIndex = 7;
            this.label11.Text = "Logistics";
            // 
            // btnLogisticsOverview
            // 
            this.btnLogisticsOverview.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnLogisticsOverview.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogisticsOverview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogisticsOverview.Location = new System.Drawing.Point(9, 32);
            this.btnLogisticsOverview.Name = "btnLogisticsOverview";
            this.btnLogisticsOverview.Size = new System.Drawing.Size(240, 48);
            this.btnLogisticsOverview.TabIndex = 51;
            this.btnLogisticsOverview.Text = "Logistics Overview";
            this.btnLogisticsOverview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsOverview.UseVisualStyleBackColor = true;
            this.btnLogisticsOverview.Click += new System.EventHandler(this.btnLogisticsOverview_Click);
            // 
            // btnDietaryAndAllergy
            // 
            this.btnDietaryAndAllergy.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnDietaryAndAllergy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDietaryAndAllergy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDietaryAndAllergy.Location = new System.Drawing.Point(9, 86);
            this.btnDietaryAndAllergy.Name = "btnDietaryAndAllergy";
            this.btnDietaryAndAllergy.Size = new System.Drawing.Size(240, 48);
            this.btnDietaryAndAllergy.TabIndex = 58;
            this.btnDietaryAndAllergy.Text = "Dietary / Allergy Details";
            this.btnDietaryAndAllergy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDietaryAndAllergy.UseVisualStyleBackColor = true;
            this.btnDietaryAndAllergy.Click += new System.EventHandler(this.btnDietaryAndAllergy_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnChangeID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnEditResource);
            this.panel1.Controls.Add(this.btnEditCheckIn);
            this.panel1.Controls.Add(this.btnDemob);
            this.panel1.Location = new System.Drawing.Point(202, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 145);
            this.panel1.TabIndex = 60;
            // 
            // btnChangeID
            // 
            this.btnChangeID.Enabled = false;
            this.btnChangeID.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_740_hash;
            this.btnChangeID.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangeID.Location = new System.Drawing.Point(214, 89);
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(163, 48);
            this.btnChangeID.TabIndex = 134;
            this.btnChangeID.Text = "Change ID #";
            this.btnChangeID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeID.UseVisualStyleBackColor = true;
            this.btnChangeID.Click += new System.EventHandler(this.btnChangeID_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(378, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "Selected Resource(s)";
            // 
            // btnEditResource
            // 
            this.btnEditResource.Enabled = false;
            this.btnEditResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditResource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditResource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditResource.Location = new System.Drawing.Point(8, 35);
            this.btnEditResource.Name = "btnEditResource";
            this.btnEditResource.Size = new System.Drawing.Size(200, 48);
            this.btnEditResource.TabIndex = 56;
            this.btnEditResource.Text = "Edit Resource";
            this.btnEditResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditResource.UseVisualStyleBackColor = true;
            this.btnEditResource.Click += new System.EventHandler(this.btnEditResource_Click);
            // 
            // btnEditCheckIn
            // 
            this.btnEditCheckIn.Enabled = false;
            this.btnEditCheckIn.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditCheckIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditCheckIn.Location = new System.Drawing.Point(8, 89);
            this.btnEditCheckIn.Name = "btnEditCheckIn";
            this.btnEditCheckIn.Size = new System.Drawing.Size(200, 48);
            this.btnEditCheckIn.TabIndex = 57;
            this.btnEditCheckIn.Text = "Edit Check-In Info";
            this.btnEditCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditCheckIn.UseVisualStyleBackColor = true;
            this.btnEditCheckIn.Click += new System.EventHandler(this.btnEditCheckIn_Click);
            // 
            // btnDemob
            // 
            this.btnDemob.Enabled = false;
            this.btnDemob.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_432_log_out;
            this.btnDemob.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDemob.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDemob.Location = new System.Drawing.Point(214, 35);
            this.btnDemob.Name = "btnDemob";
            this.btnDemob.Size = new System.Drawing.Size(163, 48);
            this.btnDemob.TabIndex = 48;
            this.btnDemob.Text = "Demobilize";
            this.btnDemob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDemob.UseVisualStyleBackColor = true;
            this.btnDemob.Click += new System.EventHandler(this.btnDemob_Click);
            // 
            // pnlSignIn
            // 
            this.pnlSignIn.BackColor = System.Drawing.Color.White;
            this.pnlSignIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSignIn.Controls.Add(this.label6);
            this.pnlSignIn.Controls.Add(this.btnStartCheckIn);
            this.pnlSignIn.Location = new System.Drawing.Point(7, 7);
            this.pnlSignIn.Name = "pnlSignIn";
            this.pnlSignIn.Size = new System.Drawing.Size(189, 145);
            this.pnlSignIn.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "New Check In";
            // 
            // btnStartCheckIn
            // 
            this.btnStartCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnStartCheckIn.Image")));
            this.btnStartCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartCheckIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartCheckIn.Location = new System.Drawing.Point(3, 35);
            this.btnStartCheckIn.Name = "btnStartCheckIn";
            this.btnStartCheckIn.Size = new System.Drawing.Size(181, 99);
            this.btnStartCheckIn.TabIndex = 46;
            this.btnStartCheckIn.Text = "Check-In";
            this.btnStartCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartCheckIn.UseVisualStyleBackColor = true;
            this.btnStartCheckIn.Click += new System.EventHandler(this.btnStartCheckIn_Click);
            // 
            // btnCheckInByManifest
            // 
            this.btnCheckInByManifest.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckInByManifest.Image")));
            this.btnCheckInByManifest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckInByManifest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheckInByManifest.Location = new System.Drawing.Point(1230, 131);
            this.btnCheckInByManifest.Name = "btnCheckInByManifest";
            this.btnCheckInByManifest.Size = new System.Drawing.Size(187, 53);
            this.btnCheckInByManifest.TabIndex = 52;
            this.btnCheckInByManifest.Text = "Check-In from Manifest";
            this.btnCheckInByManifest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckInByManifest.UseVisualStyleBackColor = true;
            this.btnCheckInByManifest.Visible = false;
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // cmsPrint211
            // 
            this.cmsPrint211.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsPrint211.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printNewICS211sToolStripMenuItem,
            this.printAllICS211sToToolStripMenuItem});
            this.cmsPrint211.Name = "cmsPrint211";
            this.cmsPrint211.Size = new System.Drawing.Size(281, 60);
            // 
            // printNewICS211sToolStripMenuItem
            // 
            this.printNewICS211sToolStripMenuItem.Name = "printNewICS211sToolStripMenuItem";
            this.printNewICS211sToolStripMenuItem.Size = new System.Drawing.Size(280, 28);
            this.printNewICS211sToolStripMenuItem.Text = "Print New ICS-211s";
            this.printNewICS211sToolStripMenuItem.Click += new System.EventHandler(this.printNewICS211sToolStripMenuItem_Click);
            // 
            // printAllICS211sToToolStripMenuItem
            // 
            this.printAllICS211sToToolStripMenuItem.Name = "printAllICS211sToToolStripMenuItem";
            this.printAllICS211sToToolStripMenuItem.Size = new System.Drawing.Size(280, 28);
            this.printAllICS211sToToolStripMenuItem.Text = "Print all ICS-211s to date";
            this.printAllICS211sToToolStripMenuItem.Click += new System.EventHandler(this.printAllICS211sToToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkInToolStripMenuItem,
            this.replacementPlanToolStripMenuItem,
            this.importToolStripMenuItem,
            this.logisticsToolStripMenuItem,
            this.outputToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1348, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // checkInToolStripMenuItem
            // 
            this.checkInToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCheckInToolStripMenuItem});
            this.checkInToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.checkInToolStripMenuItem.Name = "checkInToolStripMenuItem";
            this.checkInToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.checkInToolStripMenuItem.Text = "Check In";
            this.checkInToolStripMenuItem.Click += new System.EventHandler(this.checkInToolStripMenuItem_Click);
            // 
            // newCheckInToolStripMenuItem
            // 
            this.newCheckInToolStripMenuItem.Name = "newCheckInToolStripMenuItem";
            this.newCheckInToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.newCheckInToolStripMenuItem.Text = "New Check In";
            this.newCheckInToolStripMenuItem.Click += new System.EventHandler(this.newCheckInToolStripMenuItem_Click);
            // 
            // replacementPlanToolStripMenuItem
            // 
            this.replacementPlanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replacementPlanToolStripMenuItem1});
            this.replacementPlanToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_46_calendar;
            this.replacementPlanToolStripMenuItem.Name = "replacementPlanToolStripMenuItem";
            this.replacementPlanToolStripMenuItem.Size = new System.Drawing.Size(228, 29);
            this.replacementPlanToolStripMenuItem.Text = "Replacement Planning";
            // 
            // replacementPlanToolStripMenuItem1
            // 
            this.replacementPlanToolStripMenuItem1.Name = "replacementPlanToolStripMenuItem1";
            this.replacementPlanToolStripMenuItem1.Size = new System.Drawing.Size(234, 30);
            this.replacementPlanToolStripMenuItem1.Text = "Replacement Plan";
            this.replacementPlanToolStripMenuItem1.Click += new System.EventHandler(this.replacementPlanToolStripMenuItem1_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importResourcesToolStripMenuItem,
            this.editSavedRToolStripMenuItem,
            this.toolStripSeparator2,
            this.importSavedVehiclesEquipmentToolStripMenuItem,
            this.editSavedVehiclesEquipmentToolStripMenuItem,
            this.toolStripSeparator3,
            this.editSavedAircraftToolStripMenuItem});
            this.importToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_399_import;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(96, 29);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // importResourcesToolStripMenuItem
            // 
            this.importResourcesToolStripMenuItem.Name = "importResourcesToolStripMenuItem";
            this.importResourcesToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.importResourcesToolStripMenuItem.Text = "Import Personnel";
            this.importResourcesToolStripMenuItem.Click += new System.EventHandler(this.importResourcesToolStripMenuItem_Click);
            // 
            // editSavedRToolStripMenuItem
            // 
            this.editSavedRToolStripMenuItem.Name = "editSavedRToolStripMenuItem";
            this.editSavedRToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.editSavedRToolStripMenuItem.Text = "Edit Saved Personnel";
            this.editSavedRToolStripMenuItem.Click += new System.EventHandler(this.editSavedRToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(340, 6);
            // 
            // importSavedVehiclesEquipmentToolStripMenuItem
            // 
            this.importSavedVehiclesEquipmentToolStripMenuItem.Name = "importSavedVehiclesEquipmentToolStripMenuItem";
            this.importSavedVehiclesEquipmentToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.importSavedVehiclesEquipmentToolStripMenuItem.Text = "Import Vehicles / Equipment";
            this.importSavedVehiclesEquipmentToolStripMenuItem.Visible = false;
            this.importSavedVehiclesEquipmentToolStripMenuItem.Click += new System.EventHandler(this.importSavedVehiclesEquipmentToolStripMenuItem_Click);
            // 
            // editSavedVehiclesEquipmentToolStripMenuItem
            // 
            this.editSavedVehiclesEquipmentToolStripMenuItem.Name = "editSavedVehiclesEquipmentToolStripMenuItem";
            this.editSavedVehiclesEquipmentToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.editSavedVehiclesEquipmentToolStripMenuItem.Text = "Edit Saved Vehicles/Equipment";
            this.editSavedVehiclesEquipmentToolStripMenuItem.Click += new System.EventHandler(this.editSavedVehiclesEquipmentToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(340, 6);
            // 
            // editSavedAircraftToolStripMenuItem
            // 
            this.editSavedAircraftToolStripMenuItem.Name = "editSavedAircraftToolStripMenuItem";
            this.editSavedAircraftToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.editSavedAircraftToolStripMenuItem.Text = "Edit Saved Aircraft";
            this.editSavedAircraftToolStripMenuItem.Click += new System.EventHandler(this.editSavedAircraftToolStripMenuItem_Click);
            // 
            // logisticsToolStripMenuItem
            // 
            this.logisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLogisticsOverviewToolStripMenuItem,
            this.printDietaryAndAllergySummaryToolStripMenuItem});
            this.logisticsToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_876_palette_package;
            this.logisticsToolStripMenuItem.Name = "logisticsToolStripMenuItem";
            this.logisticsToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.logisticsToolStripMenuItem.Text = "Logistics";
            // 
            // printLogisticsOverviewToolStripMenuItem
            // 
            this.printLogisticsOverviewToolStripMenuItem.Name = "printLogisticsOverviewToolStripMenuItem";
            this.printLogisticsOverviewToolStripMenuItem.Size = new System.Drawing.Size(374, 30);
            this.printLogisticsOverviewToolStripMenuItem.Text = "Print Logistics Overview";
            this.printLogisticsOverviewToolStripMenuItem.Click += new System.EventHandler(this.printLogisticsOverviewToolStripMenuItem_Click);
            // 
            // printDietaryAndAllergySummaryToolStripMenuItem
            // 
            this.printDietaryAndAllergySummaryToolStripMenuItem.Name = "printDietaryAndAllergySummaryToolStripMenuItem";
            this.printDietaryAndAllergySummaryToolStripMenuItem.Size = new System.Drawing.Size(374, 30);
            this.printDietaryAndAllergySummaryToolStripMenuItem.Text = "Print Dietary and Allergy Summary";
            this.printDietaryAndAllergySummaryToolStripMenuItem.Click += new System.EventHandler(this.printDietaryAndAllergySummaryToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printNewICS211sToolStripMenuItem1,
            this.printAllICS211sToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportCheckInDataToCSVToolStripMenuItem});
            this.outputToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(141, 29);
            this.outputToolStripMenuItem.Text = "Print/Export";
            // 
            // printNewICS211sToolStripMenuItem1
            // 
            this.printNewICS211sToolStripMenuItem1.Name = "printNewICS211sToolStripMenuItem1";
            this.printNewICS211sToolStripMenuItem1.Size = new System.Drawing.Size(318, 30);
            this.printNewICS211sToolStripMenuItem1.Text = "Print new ICS-211s";
            this.printNewICS211sToolStripMenuItem1.Click += new System.EventHandler(this.printNewICS211sToolStripMenuItem1_Click);
            // 
            // printAllICS211sToolStripMenuItem
            // 
            this.printAllICS211sToolStripMenuItem.Name = "printAllICS211sToolStripMenuItem";
            this.printAllICS211sToolStripMenuItem.Size = new System.Drawing.Size(318, 30);
            this.printAllICS211sToolStripMenuItem.Text = "Print all ICS-211s";
            this.printAllICS211sToolStripMenuItem.Click += new System.EventHandler(this.printAllICS211sToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(315, 6);
            // 
            // exportCheckInDataToCSVToolStripMenuItem
            // 
            this.exportCheckInDataToCSVToolStripMenuItem.Name = "exportCheckInDataToCSVToolStripMenuItem";
            this.exportCheckInDataToCSVToolStripMenuItem.Size = new System.Drawing.Size(318, 30);
            this.exportCheckInDataToCSVToolStripMenuItem.Text = "Export Check In data to CSV";
            this.exportCheckInDataToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportCheckInDataToCSVToolStripMenuItem_Click);
            // 
            // CheckedInResourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 604);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(1364, 635);
            this.Name = "CheckedInResourcesForm";
            this.Text = "Checked In Resources";
            this.Load += new System.EventHandler(this.CheckedInResourcesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResources)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.cpFilters.ResumeLayout(false);
            this.cpFilters.PerformLayout();
            this.cpPNumbers.ResumeLayout(false);
            this.cpPNumbers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMin)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlSignIn.ResumeLayout(false);
            this.cmsPrint211.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvResources;
        private System.Windows.Forms.Button btnStartCheckIn;
        private CustomControls.CollapsiblePanel cpFilters;
        private System.Windows.Forms.Button btnDemob;
        private System.Windows.Forms.ComboBox cboResourceVariety;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cboTimeOutFilter;
        private System.Windows.Forms.Label label2;
        private CustomControls.CollapsiblePanel cpPNumbers;
        private System.Windows.Forms.ComboBox cboAssignedFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilter3ShowHelp;
        private System.Windows.Forms.NumericUpDown numCNumMax;
        private System.Windows.Forms.NumericUpDown numCNumMin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCNumTitle;
        private System.Windows.Forms.NumericUpDown numENumMax;
        private System.Windows.Forms.NumericUpDown numENumMin;
        private System.Windows.Forms.NumericUpDown numVNumMax;
        private System.Windows.Forms.NumericUpDown numVNumMin;
        private System.Windows.Forms.NumericUpDown numPNumMax;
        private System.Windows.Forms.NumericUpDown numPNumMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblENumTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVNumTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPNumTitle;
        private System.Windows.Forms.Button btnPNumHelp;
        private System.Windows.Forms.ComboBox cboExpandCrews;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUniqueIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem demobilizeToolStripMenuItem;
        private System.Windows.Forms.Button btnLogisticsOverview;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.Button btnCheckInByManifest;
        private System.Windows.Forms.Button btnEditCheckIn;
        private System.Windows.Forms.Button btnEditResource;
        private System.Windows.Forms.Button btnDietaryAndAllergy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnlSignIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnResourcePlanning;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem editCheckInInfoToolStripMenuItem;
        private System.Windows.Forms.Button btnChangeID;
        private System.Windows.Forms.ContextMenuStrip cmsPrint211;
        private System.Windows.Forms.ToolStripMenuItem printNewICS211sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printAllICS211sToToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem checkInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLogisticsOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printDietaryAndAllergySummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printNewICS211sToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printAllICS211sToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportCheckInDataToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importResourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSavedRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSavedVehiclesEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importSavedVehiclesEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCheckInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementPlanToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInitialRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem editSavedAircraftToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ProgressBar progBuildList;
    }
}