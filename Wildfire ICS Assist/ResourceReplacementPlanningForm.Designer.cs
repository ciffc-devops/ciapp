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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOutgoing = new System.Windows.Forms.DataGridView();
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
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.cpFilters = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboReplacementReqdFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datLastDayFilter = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboResourceVariety = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOutgoing = new System.Windows.Forms.TabPage();
            this.tpIncoming = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutgoing)).BeginInit();
            this.cpFilters.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpOutgoing.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnExportSignInToCSV);
            this.splitContainer1.Panel2.Controls.Add(this.cpFilters);
            this.splitContainer1.Size = new System.Drawing.Size(1903, 491);
            this.splitContainer1.SplitterDistance = 1598;
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
            this.dgvOutgoing.Size = new System.Drawing.Size(1598, 491);
            this.dgvOutgoing.TabIndex = 0;
            this.dgvOutgoing.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutgoing_CellContentClick);
            this.dgvOutgoing.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutgoing_CellEndEdit);
            this.dgvOutgoing.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOutgoing_CellFormatting);
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
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = "Edit";
            this.colEdit.Width = 19;
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
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(14, 438);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(214, 48);
            this.btnExportSignInToCSV.TabIndex = 51;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            // 
            // cpFilters
            // 
            this.cpFilters.BackColor = System.Drawing.Color.White;
            this.cpFilters.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFilters.CollapsedHeight = 40;
            this.cpFilters.CollapsedWidth = 290;
            this.cpFilters.CollapseLeft = true;
            this.cpFilters.Controls.Add(this.cboReplacementReqdFilter);
            this.cpFilters.Controls.Add(this.label3);
            this.cpFilters.Controls.Add(this.datLastDayFilter);
            this.cpFilters.Controls.Add(this.label2);
            this.cpFilters.Controls.Add(this.cboResourceVariety);
            this.cpFilters.Controls.Add(this.label1);
            this.cpFilters.CurrentlyCollapsed = false;
            this.cpFilters.ExpandedHeight = 322;
            this.cpFilters.ExpandedWidth = 290;
            this.cpFilters.ExpandUp = false;
            this.cpFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpFilters.Location = new System.Drawing.Point(6, 15);
            this.cpFilters.Margin = new System.Windows.Forms.Padding(6);
            this.cpFilters.Name = "cpFilters";
            this.cpFilters.Size = new System.Drawing.Size(290, 322);
            this.cpFilters.TabIndex = 1;
            this.cpFilters.TitleText = "Filter List";
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
            this.cboReplacementReqdFilter.Location = new System.Drawing.Point(7, 204);
            this.cboReplacementReqdFilter.Name = "cboReplacementReqdFilter";
            this.cboReplacementReqdFilter.Size = new System.Drawing.Size(276, 32);
            this.cboReplacementReqdFilter.TabIndex = 96;
            this.cboReplacementReqdFilter.SelectedIndexChanged += new System.EventHandler(this.cboReplacementReqdFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(3, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 24);
            this.label3.TabIndex = 95;
            this.label3.Text = "Replacement Req\'d";
            // 
            // datLastDayFilter
            // 
            this.datLastDayFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datLastDayFilter.Location = new System.Drawing.Point(3, 133);
            this.datLastDayFilter.Name = "datLastDayFilter";
            this.datLastDayFilter.Size = new System.Drawing.Size(280, 29);
            this.datLastDayFilter.TabIndex = 94;
            this.datLastDayFilter.ValueChanged += new System.EventHandler(this.datLastDayFilter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(3, 106);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpOutgoing);
            this.tabControl1.Controls.Add(this.tpIncoming);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1917, 534);
            this.tabControl1.TabIndex = 1;
            // 
            // tpOutgoing
            // 
            this.tpOutgoing.Controls.Add(this.splitContainer1);
            this.tpOutgoing.Location = new System.Drawing.Point(4, 33);
            this.tpOutgoing.Name = "tpOutgoing";
            this.tpOutgoing.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutgoing.Size = new System.Drawing.Size(1909, 497);
            this.tpOutgoing.TabIndex = 0;
            this.tpOutgoing.Text = "Outgoing";
            this.tpOutgoing.UseVisualStyleBackColor = true;
            // 
            // tpIncoming
            // 
            this.tpIncoming.Location = new System.Drawing.Point(4, 33);
            this.tpIncoming.Name = "tpIncoming";
            this.tpIncoming.Padding = new System.Windows.Forms.Padding(3);
            this.tpIncoming.Size = new System.Drawing.Size(1909, 497);
            this.tpIncoming.TabIndex = 1;
            this.tpIncoming.Text = "Incoming";
            this.tpIncoming.UseVisualStyleBackColor = true;
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
            // ResourceReplacementPlanningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1917, 534);
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
            this.cpFilters.ResumeLayout(false);
            this.cpFilters.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpOutgoing.ResumeLayout(false);
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
    }
}