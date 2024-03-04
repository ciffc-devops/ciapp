namespace Wildfire_ICS_Assist
{
    partial class ResourceReplacementPlanningForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOutgoing = new System.Windows.Forms.DataGridView();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.lblReplacementResourceRed = new System.Windows.Forms.Label();
            this.lblLegendResourceYellow = new System.Windows.Forms.Label();
            this.lblLegendReplacementPlanned = new System.Windows.Forms.Label();
            this.lblLegendNoReplacementNeeded = new System.Windows.Forms.Label();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.cpFilters = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboLastDayAsOf = new System.Windows.Forms.ComboBox();
            this.cboReplacementReqdFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datLastDayFilter = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboResourceVariety = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOutgoing = new System.Windows.Forms.TabPage();
            this.tpIncoming = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.collapsiblePanel3 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboIncomingToAsOf = new System.Windows.Forms.ComboBox();
            this.cboReplacementIdentified = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.datArrivalAsOf = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cboIncomingVariety = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.collapsiblePanel2 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new Wildfire_ICS_Assist.CustomControls.CalendarColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collapsiblePanel4 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboOutgoingOutputFilters = new System.Windows.Forms.ComboBox();
            this.cboOutgoingOutputInclude = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDayCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHomeArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacementRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDateRequired = new Wildfire_ICS_Assist.CustomControls.CalendarColumn();
            this.colReplacementOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReplacementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIncomingArrivalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutgoing)).BeginInit();
            this.collapsiblePanel1.SuspendLayout();
            this.cpFilters.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpOutgoing.SuspendLayout();
            this.tpIncoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.collapsiblePanel3.SuspendLayout();
            this.collapsiblePanel2.SuspendLayout();
            this.collapsiblePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOutgoing);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.collapsiblePanel4);
            this.splitContainer1.Panel2.Controls.Add(this.collapsiblePanel1);
            this.splitContainer1.Panel2.Controls.Add(this.cpFilters);
            this.splitContainer1.Size = new System.Drawing.Size(1422, 677);
            this.splitContainer1.SplitterDistance = 1078;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvOutgoing
            // 
            this.dgvOutgoing.AllowUserToAddRows = false;
            this.dgvOutgoing.AllowUserToDeleteRows = false;
            this.dgvOutgoing.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvOutgoing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutgoing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colKind,
            this.colAssignment,
            this.colLastDay,
            this.colDayCount,
            this.colHomeArea,
            this.colTransport,
            this.colReplacementRequired,
            this.colDateRequired,
            this.colReplacementOrder,
            this.colReplacementName,
            this.colEdit,
            this.colComments});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOutgoing.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutgoing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutgoing.Location = new System.Drawing.Point(0, 0);
            this.dgvOutgoing.MultiSelect = false;
            this.dgvOutgoing.Name = "dgvOutgoing";
            this.dgvOutgoing.RowHeadersVisible = false;
            this.dgvOutgoing.RowTemplate.Height = 30;
            this.dgvOutgoing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutgoing.Size = new System.Drawing.Size(1078, 677);
            this.dgvOutgoing.TabIndex = 0;
            this.dgvOutgoing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutgoing_CellContentClick);
            this.dgvOutgoing.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutgoing_CellEndEdit);
            this.dgvOutgoing.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOutgoing_CellFormatting);
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel1.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.CollapsedHeight = 40;
            this.collapsiblePanel1.CollapsedWidth = 326;
            this.collapsiblePanel1.CollapseLeft = true;
            this.collapsiblePanel1.Controls.Add(this.lblReplacementResourceRed);
            this.collapsiblePanel1.Controls.Add(this.lblLegendResourceYellow);
            this.collapsiblePanel1.Controls.Add(this.lblLegendReplacementPlanned);
            this.collapsiblePanel1.Controls.Add(this.lblLegendNoReplacementNeeded);
            this.collapsiblePanel1.CurrentlyCollapsed = false;
            this.collapsiblePanel1.ExpandedHeight = 196;
            this.collapsiblePanel1.ExpandedWidth = 326;
            this.collapsiblePanel1.ExpandUp = false;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(6, 327);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(326, 196);
            this.collapsiblePanel1.TabIndex = 56;
            this.collapsiblePanel1.TitleText = "Legend";
            // 
            // lblReplacementResourceRed
            // 
            this.lblReplacementResourceRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplacementResourceRed.BackColor = System.Drawing.Color.Red;
            this.lblReplacementResourceRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReplacementResourceRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblReplacementResourceRed.Location = new System.Drawing.Point(15, 157);
            this.lblReplacementResourceRed.Name = "lblReplacementResourceRed";
            this.lblReplacementResourceRed.Size = new System.Drawing.Size(290, 31);
            this.lblReplacementResourceRed.TabIndex = 55;
            this.lblReplacementResourceRed.Text = "red";
            this.lblReplacementResourceRed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLegendResourceYellow
            // 
            this.lblLegendResourceYellow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLegendResourceYellow.BackColor = System.Drawing.Color.Yellow;
            this.lblLegendResourceYellow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendResourceYellow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblLegendResourceYellow.Location = new System.Drawing.Point(15, 119);
            this.lblLegendResourceYellow.Name = "lblLegendResourceYellow";
            this.lblLegendResourceYellow.Size = new System.Drawing.Size(290, 31);
            this.lblLegendResourceYellow.TabIndex = 54;
            this.lblLegendResourceYellow.Text = "yellow";
            this.lblLegendResourceYellow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLegendReplacementPlanned
            // 
            this.lblLegendReplacementPlanned.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLegendReplacementPlanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendReplacementPlanned.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblLegendReplacementPlanned.Location = new System.Drawing.Point(15, 43);
            this.lblLegendReplacementPlanned.Name = "lblLegendReplacementPlanned";
            this.lblLegendReplacementPlanned.Size = new System.Drawing.Size(290, 31);
            this.lblLegendReplacementPlanned.TabIndex = 52;
            this.lblLegendReplacementPlanned.Text = "A replacement is planned";
            this.lblLegendReplacementPlanned.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLegendNoReplacementNeeded
            // 
            this.lblLegendNoReplacementNeeded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLegendNoReplacementNeeded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegendNoReplacementNeeded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblLegendNoReplacementNeeded.Location = new System.Drawing.Point(15, 81);
            this.lblLegendNoReplacementNeeded.Name = "lblLegendNoReplacementNeeded";
            this.lblLegendNoReplacementNeeded.Size = new System.Drawing.Size(290, 31);
            this.lblLegendNoReplacementNeeded.TabIndex = 53;
            this.lblLegendNoReplacementNeeded.Text = "No replacement needed";
            this.lblLegendNoReplacementNeeded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(8, 83);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(311, 48);
            this.btnExportSignInToCSV.TabIndex = 51;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            this.btnExportSignInToCSV.Click += new System.EventHandler(this.btnExportSignInToCSV_Click);
            // 
            // cpFilters
            // 
            this.cpFilters.BackColor = System.Drawing.Color.White;
            this.cpFilters.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFilters.CollapsedHeight = 40;
            this.cpFilters.CollapsedWidth = 326;
            this.cpFilters.CollapseLeft = true;
            this.cpFilters.Controls.Add(this.cboLastDayAsOf);
            this.cpFilters.Controls.Add(this.cboReplacementReqdFilter);
            this.cpFilters.Controls.Add(this.label3);
            this.cpFilters.Controls.Add(this.datLastDayFilter);
            this.cpFilters.Controls.Add(this.label2);
            this.cpFilters.Controls.Add(this.cboResourceVariety);
            this.cpFilters.Controls.Add(this.label1);
            this.cpFilters.CurrentlyCollapsed = false;
            this.cpFilters.ExpandedHeight = 300;
            this.cpFilters.ExpandedWidth = 326;
            this.cpFilters.ExpandUp = false;
            this.cpFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpFilters.Location = new System.Drawing.Point(6, 15);
            this.cpFilters.Margin = new System.Windows.Forms.Padding(6);
            this.cpFilters.Name = "cpFilters";
            this.cpFilters.Size = new System.Drawing.Size(326, 300);
            this.cpFilters.TabIndex = 1;
            this.cpFilters.TitleText = "Filter List";
            // 
            // cboLastDayAsOf
            // 
            this.cboLastDayAsOf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLastDayAsOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLastDayAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboLastDayAsOf.FormattingEnabled = true;
            this.cboLastDayAsOf.Items.AddRange(new object[] {
            "As of...",
            "On..."});
            this.cboLastDayAsOf.Location = new System.Drawing.Point(3, 144);
            this.cboLastDayAsOf.Name = "cboLastDayAsOf";
            this.cboLastDayAsOf.Size = new System.Drawing.Size(316, 32);
            this.cboLastDayAsOf.TabIndex = 97;
            this.cboLastDayAsOf.SelectedIndexChanged += new System.EventHandler(this.cboLastDayAsOf_SelectedIndexChanged);
            // 
            // cboReplacementReqdFilter
            // 
            this.cboReplacementReqdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReplacementReqdFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReplacementReqdFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboReplacementReqdFilter.FormattingEnabled = true;
            this.cboReplacementReqdFilter.Items.AddRange(new object[] {
            "All Resources",
            "All Replacement Required",
            "Replacements Outstanding"});
            this.cboReplacementReqdFilter.Location = new System.Drawing.Point(8, 252);
            this.cboReplacementReqdFilter.Name = "cboReplacementReqdFilter";
            this.cboReplacementReqdFilter.Size = new System.Drawing.Size(312, 32);
            this.cboReplacementReqdFilter.TabIndex = 96;
            this.cboReplacementReqdFilter.SelectedIndexChanged += new System.EventHandler(this.cboReplacementReqdFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(4, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 24);
            this.label3.TabIndex = 95;
            this.label3.Text = "Replacement Req\'d";
            // 
            // datLastDayFilter
            // 
            this.datLastDayFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datLastDayFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datLastDayFilter.Location = new System.Drawing.Point(3, 182);
            this.datLastDayFilter.Name = "datLastDayFilter";
            this.datLastDayFilter.Size = new System.Drawing.Size(316, 29);
            this.datLastDayFilter.TabIndex = 94;
            this.datLastDayFilter.ValueChanged += new System.EventHandler(this.datLastDayFilter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(3, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "Last Day on Incident";
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
            "Vehicle",
            "Equipment",
            "Operator",
            "Crew"});
            this.cboResourceVariety.Location = new System.Drawing.Point(7, 71);
            this.cboResourceVariety.Name = "cboResourceVariety";
            this.cboResourceVariety.Size = new System.Drawing.Size(312, 32);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpOutgoing);
            this.tabControl1.Controls.Add(this.tpIncoming);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1436, 720);
            this.tabControl1.TabIndex = 1;
            // 
            // tpOutgoing
            // 
            this.tpOutgoing.Controls.Add(this.splitContainer1);
            this.tpOutgoing.Location = new System.Drawing.Point(4, 33);
            this.tpOutgoing.Name = "tpOutgoing";
            this.tpOutgoing.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutgoing.Size = new System.Drawing.Size(1428, 683);
            this.tpOutgoing.TabIndex = 0;
            this.tpOutgoing.Text = "Outgoing Resources";
            this.tpOutgoing.UseVisualStyleBackColor = true;
            // 
            // tpIncoming
            // 
            this.tpIncoming.Controls.Add(this.splitContainer2);
            this.tpIncoming.Location = new System.Drawing.Point(4, 33);
            this.tpIncoming.Name = "tpIncoming";
            this.tpIncoming.Padding = new System.Windows.Forms.Padding(3);
            this.tpIncoming.Size = new System.Drawing.Size(1428, 683);
            this.tpIncoming.TabIndex = 1;
            this.tpIncoming.Text = "Incoming Resources";
            this.tpIncoming.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel3);
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel2);
            this.splitContainer2.Size = new System.Drawing.Size(1422, 677);
            this.splitContainer2.SplitterDistance = 1117;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.colIncomingArrivalDate,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewButtonColumn2,
            this.dataGridViewTextBoxColumn20});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1117, 677);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(6, 532);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 48);
            this.button1.TabIndex = 51;
            this.button1.Text = "Export to CSV";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // collapsiblePanel3
            // 
            this.collapsiblePanel3.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel3.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel3.CollapsedHeight = 40;
            this.collapsiblePanel3.CollapsedWidth = 290;
            this.collapsiblePanel3.CollapseLeft = true;
            this.collapsiblePanel3.Controls.Add(this.cboIncomingToAsOf);
            this.collapsiblePanel3.Controls.Add(this.cboReplacementIdentified);
            this.collapsiblePanel3.Controls.Add(this.label8);
            this.collapsiblePanel3.Controls.Add(this.datArrivalAsOf);
            this.collapsiblePanel3.Controls.Add(this.label9);
            this.collapsiblePanel3.Controls.Add(this.cboIncomingVariety);
            this.collapsiblePanel3.Controls.Add(this.label10);
            this.collapsiblePanel3.CurrentlyCollapsed = false;
            this.collapsiblePanel3.ExpandedHeight = 300;
            this.collapsiblePanel3.ExpandedWidth = 290;
            this.collapsiblePanel3.ExpandUp = false;
            this.collapsiblePanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel3.Location = new System.Drawing.Point(6, 15);
            this.collapsiblePanel3.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel3.Name = "collapsiblePanel3";
            this.collapsiblePanel3.Size = new System.Drawing.Size(290, 300);
            this.collapsiblePanel3.TabIndex = 1;
            this.collapsiblePanel3.TitleText = "Filter List";
            // 
            // cboIncomingToAsOf
            // 
            this.cboIncomingToAsOf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIncomingToAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboIncomingToAsOf.FormattingEnabled = true;
            this.cboIncomingToAsOf.Items.AddRange(new object[] {
            "As of...",
            "On..."});
            this.cboIncomingToAsOf.Location = new System.Drawing.Point(3, 144);
            this.cboIncomingToAsOf.Name = "cboIncomingToAsOf";
            this.cboIncomingToAsOf.Size = new System.Drawing.Size(280, 32);
            this.cboIncomingToAsOf.TabIndex = 97;
            // 
            // cboReplacementIdentified
            // 
            this.cboReplacementIdentified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReplacementIdentified.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReplacementIdentified.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboReplacementIdentified.FormattingEnabled = true;
            this.cboReplacementIdentified.Items.AddRange(new object[] {
            "All Incoming Resources",
            "Resources Without Replacement",
            "Resources With Replacement"});
            this.cboReplacementIdentified.Location = new System.Drawing.Point(8, 252);
            this.cboReplacementIdentified.Name = "cboReplacementIdentified";
            this.cboReplacementIdentified.Size = new System.Drawing.Size(276, 32);
            this.cboReplacementIdentified.TabIndex = 96;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label8.Location = new System.Drawing.Point(4, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 24);
            this.label8.TabIndex = 95;
            this.label8.Text = "Replacement Identified";
            // 
            // datArrivalAsOf
            // 
            this.datArrivalAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datArrivalAsOf.Location = new System.Drawing.Point(3, 182);
            this.datArrivalAsOf.Name = "datArrivalAsOf";
            this.datArrivalAsOf.Size = new System.Drawing.Size(280, 29);
            this.datArrivalAsOf.TabIndex = 94;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label9.Location = new System.Drawing.Point(3, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 24);
            this.label9.TabIndex = 35;
            this.label9.Text = "Est Arrival Date";
            // 
            // cboIncomingVariety
            // 
            this.cboIncomingVariety.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIncomingVariety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIncomingVariety.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboIncomingVariety.FormattingEnabled = true;
            this.cboIncomingVariety.Items.AddRange(new object[] {
            "All Resources",
            "Personnel",
            "Visitor",
            "Vehicle",
            "Equipment",
            "Operator",
            "Crew"});
            this.cboIncomingVariety.Location = new System.Drawing.Point(7, 71);
            this.cboIncomingVariety.Name = "cboIncomingVariety";
            this.cboIncomingVariety.Size = new System.Drawing.Size(276, 32);
            this.cboIncomingVariety.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label10.Location = new System.Drawing.Point(3, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 24);
            this.label10.TabIndex = 33;
            this.label10.Text = "Resource Variety";
            // 
            // collapsiblePanel2
            // 
            this.collapsiblePanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel2.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel2.CollapsedHeight = 40;
            this.collapsiblePanel2.CollapsedWidth = 290;
            this.collapsiblePanel2.CollapseLeft = true;
            this.collapsiblePanel2.Controls.Add(this.label4);
            this.collapsiblePanel2.Controls.Add(this.label5);
            this.collapsiblePanel2.Controls.Add(this.label6);
            this.collapsiblePanel2.Controls.Add(this.label7);
            this.collapsiblePanel2.CurrentlyCollapsed = true;
            this.collapsiblePanel2.ExpandedHeight = 196;
            this.collapsiblePanel2.ExpandedWidth = 290;
            this.collapsiblePanel2.ExpandUp = false;
            this.collapsiblePanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel2.Location = new System.Drawing.Point(6, 327);
            this.collapsiblePanel2.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel2.Name = "collapsiblePanel2";
            this.collapsiblePanel2.Size = new System.Drawing.Size(290, 40);
            this.collapsiblePanel2.TabIndex = 56;
            this.collapsiblePanel2.TitleText = "Legend";
            this.collapsiblePanel2.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(15, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 31);
            this.label4.TabIndex = 55;
            this.label4.Text = "red";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(15, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 31);
            this.label5.TabIndex = 54;
            this.label5.Text = "yellow";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label6.Location = new System.Drawing.Point(15, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 31);
            this.label6.TabIndex = 52;
            this.label6.Text = "A replacement is planned";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label7.Location = new System.Drawing.Point(15, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 31);
            this.label7.TabIndex = 53;
            this.label7.Text = "No replacement needed";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ResourceName";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Kind";
            this.dataGridViewTextBoxColumn2.HeaderText = "Kind";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Assignment";
            this.dataGridViewTextBoxColumn3.HeaderText = "Assignment";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LastDayOnIncident";
            this.dataGridViewTextBoxColumn4.HeaderText = "Last Day";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DaysTillTimeOut";
            this.dataGridViewTextBoxColumn5.HeaderText = "Day #";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "HomeUnit";
            this.dataGridViewTextBoxColumn6.HeaderText = "Home";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 130;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Transport";
            this.dataGridViewTextBoxColumn7.HeaderText = "Transport";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.DataPropertyName = "DateReplacementRequired";
            this.calendarColumn1.HeaderText = "Date Req\'d";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ReplacementOrderNumber";
            this.dataGridViewTextBoxColumn8.HeaderText = "Order #";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ReplacementResourceName";
            this.dataGridViewTextBoxColumn9.HeaderText = "Replacement";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewButtonColumn1.DataPropertyName = "ResourceReplacementEditButtonText";
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn1.Text = "Edit";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "ReplacementComment";
            this.dataGridViewTextBoxColumn10.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // collapsiblePanel4
            // 
            this.collapsiblePanel4.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel4.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel4.CollapsedHeight = 40;
            this.collapsiblePanel4.CollapsedWidth = 326;
            this.collapsiblePanel4.CollapseLeft = true;
            this.collapsiblePanel4.Controls.Add(this.splitContainer3);
            this.collapsiblePanel4.Controls.Add(this.btnExportSignInToCSV);
            this.collapsiblePanel4.CurrentlyCollapsed = false;
            this.collapsiblePanel4.ExpandedHeight = 300;
            this.collapsiblePanel4.ExpandedWidth = 326;
            this.collapsiblePanel4.ExpandUp = false;
            this.collapsiblePanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel4.Location = new System.Drawing.Point(6, 535);
            this.collapsiblePanel4.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel4.Name = "collapsiblePanel4";
            this.collapsiblePanel4.Size = new System.Drawing.Size(326, 136);
            this.collapsiblePanel4.TabIndex = 2;
            this.collapsiblePanel4.TitleText = "Output";
            // 
            // cboOutgoingOutputFilters
            // 
            this.cboOutgoingOutputFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOutgoingOutputFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutgoingOutputFilters.FormattingEnabled = true;
            this.cboOutgoingOutputFilters.Items.AddRange(new object[] {
            "Displayed Resources",
            "All Resources"});
            this.cboOutgoingOutputFilters.Location = new System.Drawing.Point(3, 3);
            this.cboOutgoingOutputFilters.Name = "cboOutgoingOutputFilters";
            this.cboOutgoingOutputFilters.Size = new System.Drawing.Size(149, 32);
            this.cboOutgoingOutputFilters.TabIndex = 52;
            // 
            // cboOutgoingOutputInclude
            // 
            this.cboOutgoingOutputInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOutgoingOutputInclude.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutgoingOutputInclude.FormattingEnabled = true;
            this.cboOutgoingOutputInclude.Items.AddRange(new object[] {
            "Outgoing Resources",
            "Incoming Resources",
            "Both"});
            this.cboOutgoingOutputInclude.Location = new System.Drawing.Point(3, 3);
            this.cboOutgoingOutputInclude.Name = "cboOutgoingOutputInclude";
            this.cboOutgoingOutputInclude.Size = new System.Drawing.Size(146, 32);
            this.cboOutgoingOutputInclude.TabIndex = 53;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(8, 41);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cboOutgoingOutputFilters);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cboOutgoingOutputInclude);
            this.splitContainer3.Size = new System.Drawing.Size(311, 36);
            this.splitContainer3.SplitterDistance = 155;
            this.splitContainer3.TabIndex = 54;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.Frozen = true;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 86;
            // 
            // colKind
            // 
            this.colKind.DataPropertyName = "Kind";
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            // 
            // colAssignment
            // 
            this.colAssignment.DataPropertyName = "Assignment";
            this.colAssignment.HeaderText = "Assignment";
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.ReadOnly = true;
            this.colAssignment.Width = 150;
            // 
            // colLastDay
            // 
            this.colLastDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colLastDay.DataPropertyName = "LastDayOnIncident";
            this.colLastDay.HeaderText = "Last Day";
            this.colLastDay.Name = "colLastDay";
            this.colLastDay.ReadOnly = true;
            this.colLastDay.Width = 105;
            // 
            // colDayCount
            // 
            this.colDayCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDayCount.DataPropertyName = "DaysTillTimeOut";
            this.colDayCount.HeaderText = "Day #";
            this.colDayCount.Name = "colDayCount";
            this.colDayCount.ReadOnly = true;
            this.colDayCount.Width = 82;
            // 
            // colHomeArea
            // 
            this.colHomeArea.DataPropertyName = "HomeUnit";
            this.colHomeArea.HeaderText = "Home";
            this.colHomeArea.Name = "colHomeArea";
            this.colHomeArea.ReadOnly = true;
            this.colHomeArea.Width = 130;
            // 
            // colTransport
            // 
            this.colTransport.DataPropertyName = "Transport";
            this.colTransport.HeaderText = "Transport";
            this.colTransport.Name = "colTransport";
            this.colTransport.ReadOnly = true;
            this.colTransport.Width = 150;
            // 
            // colReplacementRequired
            // 
            this.colReplacementRequired.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colReplacementRequired.DataPropertyName = "ReplacementRequired";
            this.colReplacementRequired.HeaderText = "Req\'d";
            this.colReplacementRequired.MinimumWidth = 75;
            this.colReplacementRequired.Name = "colReplacementRequired";
            this.colReplacementRequired.Width = 75;
            // 
            // colDateRequired
            // 
            this.colDateRequired.DataPropertyName = "DateReplacementRequired";
            this.colDateRequired.HeaderText = "Date Req\'d";
            this.colDateRequired.Name = "colDateRequired";
            this.colDateRequired.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDateRequired.Width = 160;
            // 
            // colReplacementOrder
            // 
            this.colReplacementOrder.DataPropertyName = "ReplacementOrderNumber";
            this.colReplacementOrder.HeaderText = "Order #";
            this.colReplacementOrder.Name = "colReplacementOrder";
            this.colReplacementOrder.ReadOnly = true;
            this.colReplacementOrder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReplacementOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colReplacementOrder.Width = 80;
            // 
            // colReplacementName
            // 
            this.colReplacementName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReplacementName.DataPropertyName = "ReplacementResourceName";
            this.colReplacementName.HeaderText = "Replacement";
            this.colReplacementName.Name = "colReplacementName";
            this.colReplacementName.ReadOnly = true;
            this.colReplacementName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReplacementName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colReplacementName.Width = 128;
            // 
            // colEdit
            // 
            this.colEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colEdit.DataPropertyName = "ResourceReplacementEditButtonText";
            this.colEdit.HeaderText = "Replacement";
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "Edit";
            this.colEdit.Width = 147;
            // 
            // colComments
            // 
            this.colComments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComments.DataPropertyName = "ReplacementComment";
            this.colComments.HeaderText = "Comments";
            this.colComments.MinimumWidth = 150;
            this.colComments.Name = "colComments";
            this.colComments.ReadOnly = true;
            this.colComments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colComments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ResourceName";
            this.dataGridViewTextBoxColumn11.Frozen = true;
            this.dataGridViewTextBoxColumn11.HeaderText = "Name";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 86;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Kind";
            this.dataGridViewTextBoxColumn12.HeaderText = "Kind";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Assignment";
            this.dataGridViewTextBoxColumn13.HeaderText = "Assignment";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 150;
            // 
            // colIncomingArrivalDate
            // 
            this.colIncomingArrivalDate.HeaderText = "Est. Arrival Date";
            this.colIncomingArrivalDate.Name = "colIncomingArrivalDate";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "HomeUnit";
            this.dataGridViewTextBoxColumn16.HeaderText = "Home";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 130;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Transport";
            this.dataGridViewTextBoxColumn17.HeaderText = "Transport";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 150;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ReplacementResourceName";
            this.dataGridViewTextBoxColumn19.HeaderText = "Replacement For";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn19.Width = 146;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "ReplacementOrderNumber";
            this.dataGridViewTextBoxColumn18.HeaderText = "Order #";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn18.Width = 80;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewButtonColumn2.DataPropertyName = "ResourceReplacementEditButtonText";
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn2.Text = "Edit";
            this.dataGridViewButtonColumn2.Width = 19;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ReplacementComment";
            this.dataGridViewTextBoxColumn20.HeaderText = "Comments";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ResourceReplacementPlanningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 720);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ResourceReplacementPlanningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resource Replacement Planning";
            this.Load += new System.EventHandler(this.ResourceReplacementPlanningForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutgoing)).EndInit();
            this.collapsiblePanel1.ResumeLayout(false);
            this.cpFilters.ResumeLayout(false);
            this.cpFilters.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpOutgoing.ResumeLayout(false);
            this.tpIncoming.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.collapsiblePanel3.ResumeLayout(false);
            this.collapsiblePanel3.PerformLayout();
            this.collapsiblePanel2.ResumeLayout(false);
            this.collapsiblePanel4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomControls.CollapsiblePanel cpFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboResourceVariety;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOutgoing;
        private System.Windows.Forms.DateTimePicker datLastDayFilter;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOutgoing;
        private System.Windows.Forms.TabPage tpIncoming;
        private System.Windows.Forms.ComboBox cboReplacementReqdFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private CustomControls.CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label lblLegendNoReplacementNeeded;
        private System.Windows.Forms.Label lblLegendReplacementPlanned;
        private System.Windows.Forms.Label lblReplacementResourceRed;
        private System.Windows.Forms.Label lblLegendResourceYellow;
        private CustomControls.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.ComboBox cboLastDayAsOf;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.CollapsiblePanel collapsiblePanel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private CustomControls.CollapsiblePanel collapsiblePanel3;
        private System.Windows.Forms.ComboBox cboIncomingToAsOf;
        private System.Windows.Forms.ComboBox cboReplacementIdentified;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker datArrivalAsOf;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboIncomingVariety;
        private System.Windows.Forms.Label label10;
        private CustomControls.CollapsiblePanel collapsiblePanel4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox cboOutgoingOutputFilters;
        private System.Windows.Forms.ComboBox cboOutgoingOutputInclude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDayCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHomeArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colReplacementRequired;
        private CustomControls.CalendarColumn colDateRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReplacementName;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIncomingArrivalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
    }
}