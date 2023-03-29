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
            this.changeUniqueIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demobilizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogisticsOverview = new System.Windows.Forms.Button();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDemob = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnStartCheckIn = new System.Windows.Forms.Button();
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
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
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
            this.cpPNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCNumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numENumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVNumMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNumMin)).BeginInit();
            this.cpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnLogisticsOverview);
            this.splitContainer1.Panel2.Controls.Add(this.btnExportSignInToCSV);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnDemob);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnStartCheckIn);
            this.splitContainer1.Size = new System.Drawing.Size(1439, 658);
            this.splitContainer1.SplitterDistance = 580;
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
            this.splitContainer2.Panel2.Controls.Add(this.cpPNumbers);
            this.splitContainer2.Panel2.Controls.Add(this.cpFilters);
            this.splitContainer2.Size = new System.Drawing.Size(1439, 580);
            this.splitContainer2.SplitterDistance = 1134;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(this.splitContainer2_SplitterMoving);
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // dgvResources
            // 
            this.dgvResources.AllowUserToAddRows = false;
            this.dgvResources.AllowUserToDeleteRows = false;
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
            this.dgvResources.Size = new System.Drawing.Size(1134, 580);
            this.dgvResources.TabIndex = 1;
            this.dgvResources.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResources_CellFormatting);
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
            this.colLastDay.DataPropertyName = "LastDayOnIncident";
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
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.changeUniqueIDToolStripMenuItem,
            this.demobilizeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(261, 94);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // changeUniqueIDToolStripMenuItem
            // 
            this.changeUniqueIDToolStripMenuItem.Name = "changeUniqueIDToolStripMenuItem";
            this.changeUniqueIDToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.changeUniqueIDToolStripMenuItem.Text = "Change Unique ID #";
            this.changeUniqueIDToolStripMenuItem.Click += new System.EventHandler(this.changeUniqueIDToolStripMenuItem_Click);
            // 
            // demobilizeToolStripMenuItem
            // 
            this.demobilizeToolStripMenuItem.Name = "demobilizeToolStripMenuItem";
            this.demobilizeToolStripMenuItem.Size = new System.Drawing.Size(260, 30);
            this.demobilizeToolStripMenuItem.Text = "Demobilize Resource";
            this.demobilizeToolStripMenuItem.Click += new System.EventHandler(this.demobilizeToolStripMenuItem_Click);
            // 
            // btnLogisticsOverview
            // 
            this.btnLogisticsOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogisticsOverview.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnLogisticsOverview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogisticsOverview.Location = new System.Drawing.Point(522, 3);
            this.btnLogisticsOverview.Name = "btnLogisticsOverview";
            this.btnLogisticsOverview.Size = new System.Drawing.Size(150, 66);
            this.btnLogisticsOverview.TabIndex = 51;
            this.btnLogisticsOverview.Text = "Logistics Overview";
            this.btnLogisticsOverview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogisticsOverview.UseVisualStyleBackColor = true;
            this.btnLogisticsOverview.Click += new System.EventHandler(this.btnLogisticsOverview_Click);
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSignInToCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(1055, 2);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(197, 66);
            this.btnExportSignInToCSV.TabIndex = 50;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            this.btnExportSignInToCSV.Click += new System.EventHandler(this.btnExportSignInToCSV_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(1258, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(169, 66);
            this.btnPrint.TabIndex = 49;
            this.btnPrint.Text = "Print ICS-211";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnDemob
            // 
            this.btnDemob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDemob.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_432_log_out;
            this.btnDemob.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDemob.Location = new System.Drawing.Point(307, 3);
            this.btnDemob.Name = "btnDemob";
            this.btnDemob.Size = new System.Drawing.Size(150, 66);
            this.btnDemob.TabIndex = 48;
            this.btnDemob.Text = "Demob Selected";
            this.btnDemob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDemob.UseVisualStyleBackColor = true;
            this.btnDemob.Click += new System.EventHandler(this.btnDemob_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit.Location = new System.Drawing.Point(152, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 66);
            this.btnEdit.TabIndex = 47;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnStartCheckIn
            // 
            this.btnStartCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartCheckIn.Image = ((System.Drawing.Image)(resources.GetObject("btnStartCheckIn.Image")));
            this.btnStartCheckIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStartCheckIn.Location = new System.Drawing.Point(3, 3);
            this.btnStartCheckIn.Name = "btnStartCheckIn";
            this.btnStartCheckIn.Size = new System.Drawing.Size(143, 66);
            this.btnStartCheckIn.TabIndex = 46;
            this.btnStartCheckIn.Text = "Check-In";
            this.btnStartCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStartCheckIn.UseVisualStyleBackColor = true;
            this.btnStartCheckIn.Click += new System.EventHandler(this.btnStartCheckIn_Click);
            // 
            // cpPNumbers
            // 
            this.cpPNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpPNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpPNumbers.CollapsedHeight = 40;
            this.cpPNumbers.CollapsedWidth = 290;
            this.cpPNumbers.CollapseLeft = true;
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
            this.cpPNumbers.CurrentlyCollapsed = true;
            this.cpPNumbers.ExpandedHeight = 357;
            this.cpPNumbers.ExpandedWidth = 290;
            this.cpPNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPNumbers.Location = new System.Drawing.Point(5, 67);
            this.cpPNumbers.Margin = new System.Windows.Forms.Padding(6);
            this.cpPNumbers.Name = "cpPNumbers";
            this.cpPNumbers.Size = new System.Drawing.Size(290, 40);
            this.cpPNumbers.TabIndex = 2;
            this.cpPNumbers.TitleText = "Resource Numbers";
            // 
            // btnPNumHelp
            // 
            this.btnPNumHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPNumHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPNumHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnPNumHelp.Image")));
            this.btnPNumHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPNumHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPNumHelp.Location = new System.Drawing.Point(12, 48);
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
            // cpFilters
            // 
            this.cpFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFilters.CollapsedHeight = 40;
            this.cpFilters.CollapsedWidth = 290;
            this.cpFilters.CollapseLeft = true;
            this.cpFilters.Controls.Add(this.cboExpandCrews);
            this.cpFilters.Controls.Add(this.label4);
            this.cpFilters.Controls.Add(this.btnFilter3ShowHelp);
            this.cpFilters.Controls.Add(this.cboAssignedFilter);
            this.cpFilters.Controls.Add(this.label3);
            this.cpFilters.Controls.Add(this.cboTimeOutFilter);
            this.cpFilters.Controls.Add(this.label2);
            this.cpFilters.Controls.Add(this.cboResourceVariety);
            this.cpFilters.Controls.Add(this.label1);
            this.cpFilters.CurrentlyCollapsed = true;
            this.cpFilters.ExpandedHeight = 322;
            this.cpFilters.ExpandedWidth = 290;
            this.cpFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpFilters.Location = new System.Drawing.Point(6, 15);
            this.cpFilters.Margin = new System.Windows.Forms.Padding(6);
            this.cpFilters.Name = "cpFilters";
            this.cpFilters.Size = new System.Drawing.Size(290, 40);
            this.cpFilters.TabIndex = 0;
            this.cpFilters.TitleText = "Filter List";
            // 
            // cboExpandCrews
            // 
            this.cboExpandCrews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExpandCrews.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExpandCrews.DropDownWidth = 500;
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
            this.cboResourceVariety.FormattingEnabled = true;
            this.cboResourceVariety.Items.AddRange(new object[] {
            "All Resources",
            "Personnel",
            "Visitor",
            "Vehicle",
            "Equipment",
            "Operator",
            "Crew"});
            this.cboResourceVariety.Location = new System.Drawing.Point(7, 71);
            this.cboResourceVariety.Name = "cboResourceVariety";
            this.cboResourceVariety.Size = new System.Drawing.Size(276, 32);
            this.cboResourceVariety.TabIndex = 34;
            this.cboResourceVariety.SelectedIndexChanged += new System.EventHandler(this.cboResourceVariety_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 33;
            this.label1.Text = "Resource Variety";
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // CheckedInResourcesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 658);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(865, 523);
            this.Name = "CheckedInResourcesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
            this.cpFilters.ResumeLayout(false);
            this.cpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvResources;
        private System.Windows.Forms.Button btnStartCheckIn;
        private System.Windows.Forms.Button btnEdit;
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
        private System.Windows.Forms.SaveFileDialog svdExport;
    }
}