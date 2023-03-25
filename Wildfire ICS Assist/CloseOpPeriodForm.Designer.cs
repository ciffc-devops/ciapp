namespace Wildfire_ICS_Assist
{
    partial class CloseOpPeriodForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpObjectives = new System.Windows.Forms.TabPage();
            this.dgvObjectives = new System.Windows.Forms.DataGridView();
            this.colObjectivePriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectiveCompleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTransferObjective = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tpResources = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tpOrgChart = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblCurrentOrgTitle = new System.Windows.Forms.Label();
            this.chkCopyOrgAssignments = new System.Windows.Forms.CheckBox();
            this.btnCopyOrgChart = new System.Windows.Forms.Button();
            this.treeOrgChart = new System.Windows.Forms.TreeView();
            this.lblNextOrgTitle = new System.Windows.Forms.Label();
            this.treeOrgChart2 = new System.Windows.Forms.TreeView();
            this.tpSafety = new System.Windows.Forms.TabPage();
            this.dgvSafety = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSafetyCopyToNext = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.lblAirOpsCopyStatus = new System.Windows.Forms.Label();
            this.lblMedPlanCopyStatus = new System.Windows.Forms.Label();
            this.lblCommsPlanCopyStatus = new System.Windows.Forms.Label();
            this.btnCopyAirOps = new System.Windows.Forms.Button();
            this.btnCopyMedPlan = new System.Windows.Forms.Button();
            this.btnCopyCommsPlan = new System.Windows.Forms.Button();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.datOpsStart = new System.Windows.Forms.DateTimePicker();
            this.datOpsEnd = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.numOpPeriod = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tpObjectives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).BeginInit();
            this.tpResources.SuspendLayout();
            this.tpOrgChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tpSafety.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSafety)).BeginInit();
            this.tpOther.SuspendLayout();
            this.tpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpObjectives);
            this.tabControl1.Controls.Add(this.tpResources);
            this.tabControl1.Controls.Add(this.tpOrgChart);
            this.tabControl1.Controls.Add(this.tpSafety);
            this.tabControl1.Controls.Add(this.tpOther);
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 29);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tpObjectives
            // 
            this.tpObjectives.Controls.Add(this.dgvObjectives);
            this.tpObjectives.Location = new System.Drawing.Point(4, 33);
            this.tpObjectives.Name = "tpObjectives";
            this.tpObjectives.Padding = new System.Windows.Forms.Padding(3);
            this.tpObjectives.Size = new System.Drawing.Size(976, 501);
            this.tpObjectives.TabIndex = 0;
            this.tpObjectives.Text = "Objectives";
            this.tpObjectives.UseVisualStyleBackColor = true;
            // 
            // dgvObjectives
            // 
            this.dgvObjectives.AllowUserToAddRows = false;
            this.dgvObjectives.AllowUserToDeleteRows = false;
            this.dgvObjectives.AllowUserToResizeColumns = false;
            this.dgvObjectives.AllowUserToResizeRows = false;
            this.dgvObjectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObjectivePriority,
            this.colObjective,
            this.colObjectiveCompleted,
            this.colTransferObjective});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvObjectives.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvObjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObjectives.Location = new System.Drawing.Point(3, 3);
            this.dgvObjectives.MultiSelect = false;
            this.dgvObjectives.Name = "dgvObjectives";
            this.dgvObjectives.RowHeadersVisible = false;
            this.dgvObjectives.RowTemplate.Height = 35;
            this.dgvObjectives.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvObjectives.Size = new System.Drawing.Size(970, 495);
            this.dgvObjectives.TabIndex = 1;
            this.dgvObjectives.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellContentClick);
            this.dgvObjectives.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellValueChanged);
            // 
            // colObjectivePriority
            // 
            this.colObjectivePriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colObjectivePriority.DataPropertyName = "Priority";
            this.colObjectivePriority.HeaderText = "Priority";
            this.colObjectivePriority.Name = "colObjectivePriority";
            this.colObjectivePriority.ReadOnly = true;
            this.colObjectivePriority.Width = 91;
            // 
            // colObjective
            // 
            this.colObjective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObjective.DataPropertyName = "Objective";
            this.colObjective.HeaderText = "Objective";
            this.colObjective.MinimumWidth = 200;
            this.colObjective.Name = "colObjective";
            this.colObjective.ReadOnly = true;
            // 
            // colObjectiveCompleted
            // 
            this.colObjectiveCompleted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colObjectiveCompleted.DataPropertyName = "Completed";
            this.colObjectiveCompleted.HeaderText = "Completed";
            this.colObjectiveCompleted.Name = "colObjectiveCompleted";
            this.colObjectiveCompleted.Width = 108;
            // 
            // colTransferObjective
            // 
            this.colTransferObjective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTransferObjective.DataPropertyName = "CopyNextOpText";
            this.colTransferObjective.HeaderText = "Copy to selected op";
            this.colTransferObjective.Name = "colTransferObjective";
            this.colTransferObjective.Text = "Copy to selected Op";
            this.colTransferObjective.Width = 148;
            // 
            // tpResources
            // 
            this.tpResources.Controls.Add(this.textBox2);
            this.tpResources.Location = new System.Drawing.Point(4, 33);
            this.tpResources.Name = "tpResources";
            this.tpResources.Size = new System.Drawing.Size(876, 501);
            this.tpResources.TabIndex = 1;
            this.tpResources.Text = "Resources";
            this.tpResources.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(44, 68);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(482, 122);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "-list of resources by type\r\n-filter for those whose last day on incident is today" +
    "\r\n-quick access to demob screen";
            // 
            // tpOrgChart
            // 
            this.tpOrgChart.Controls.Add(this.splitContainer2);
            this.tpOrgChart.Location = new System.Drawing.Point(4, 33);
            this.tpOrgChart.Name = "tpOrgChart";
            this.tpOrgChart.Size = new System.Drawing.Size(876, 501);
            this.tpOrgChart.TabIndex = 2;
            this.tpOrgChart.Text = "Org Chart";
            this.tpOrgChart.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblCurrentOrgTitle);
            this.splitContainer2.Panel1.Controls.Add(this.chkCopyOrgAssignments);
            this.splitContainer2.Panel1.Controls.Add(this.btnCopyOrgChart);
            this.splitContainer2.Panel1.Controls.Add(this.treeOrgChart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblNextOrgTitle);
            this.splitContainer2.Panel2.Controls.Add(this.treeOrgChart2);
            this.splitContainer2.Size = new System.Drawing.Size(876, 501);
            this.splitContainer2.SplitterDistance = 426;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblCurrentOrgTitle
            // 
            this.lblCurrentOrgTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentOrgTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.lblCurrentOrgTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentOrgTitle.Location = new System.Drawing.Point(8, 10);
            this.lblCurrentOrgTitle.Name = "lblCurrentOrgTitle";
            this.lblCurrentOrgTitle.Size = new System.Drawing.Size(414, 32);
            this.lblCurrentOrgTitle.TabIndex = 35;
            this.lblCurrentOrgTitle.Text = "Incident Information";
            this.lblCurrentOrgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkCopyOrgAssignments
            // 
            this.chkCopyOrgAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCopyOrgAssignments.AutoSize = true;
            this.chkCopyOrgAssignments.Location = new System.Drawing.Point(7, 410);
            this.chkCopyOrgAssignments.Name = "chkCopyOrgAssignments";
            this.chkCopyOrgAssignments.Size = new System.Drawing.Size(411, 28);
            this.chkCopyOrgAssignments.TabIndex = 1;
            this.chkCopyOrgAssignments.Text = "Copy Org Chart Assignments (when possible)";
            this.chkCopyOrgAssignments.UseVisualStyleBackColor = true;
            // 
            // btnCopyOrgChart
            // 
            this.btnCopyOrgChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyOrgChart.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnCopyOrgChart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyOrgChart.Location = new System.Drawing.Point(136, 444);
            this.btnCopyOrgChart.Name = "btnCopyOrgChart";
            this.btnCopyOrgChart.Size = new System.Drawing.Size(282, 54);
            this.btnCopyOrgChart.TabIndex = 2;
            this.btnCopyOrgChart.Text = "Copy Org Chart to Next Op";
            this.btnCopyOrgChart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyOrgChart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyOrgChart.UseVisualStyleBackColor = true;
            this.btnCopyOrgChart.Click += new System.EventHandler(this.btnCopyOrgChart_Click);
            // 
            // treeOrgChart
            // 
            this.treeOrgChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeOrgChart.HideSelection = false;
            this.treeOrgChart.Location = new System.Drawing.Point(8, 45);
            this.treeOrgChart.Name = "treeOrgChart";
            this.treeOrgChart.Size = new System.Drawing.Size(410, 359);
            this.treeOrgChart.TabIndex = 1;
            // 
            // lblNextOrgTitle
            // 
            this.lblNextOrgTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNextOrgTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.lblNextOrgTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNextOrgTitle.Location = new System.Drawing.Point(3, 10);
            this.lblNextOrgTitle.Name = "lblNextOrgTitle";
            this.lblNextOrgTitle.Size = new System.Drawing.Size(432, 32);
            this.lblNextOrgTitle.TabIndex = 36;
            this.lblNextOrgTitle.Text = "Incident Information";
            this.lblNextOrgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeOrgChart2
            // 
            this.treeOrgChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeOrgChart2.HideSelection = false;
            this.treeOrgChart2.Location = new System.Drawing.Point(8, 45);
            this.treeOrgChart2.Name = "treeOrgChart2";
            this.treeOrgChart2.Size = new System.Drawing.Size(421, 453);
            this.treeOrgChart2.TabIndex = 1;
            // 
            // tpSafety
            // 
            this.tpSafety.Controls.Add(this.dgvSafety);
            this.tpSafety.Location = new System.Drawing.Point(4, 33);
            this.tpSafety.Name = "tpSafety";
            this.tpSafety.Size = new System.Drawing.Size(876, 501);
            this.tpSafety.TabIndex = 5;
            this.tpSafety.Text = "Safety";
            this.tpSafety.UseVisualStyleBackColor = true;
            // 
            // dgvSafety
            // 
            this.dgvSafety.AllowUserToAddRows = false;
            this.dgvSafety.AllowUserToDeleteRows = false;
            this.dgvSafety.AllowUserToResizeColumns = false;
            this.dgvSafety.AllowUserToResizeRows = false;
            this.dgvSafety.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSafety.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.colSafetyCopyToNext});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSafety.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSafety.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSafety.Location = new System.Drawing.Point(0, 0);
            this.dgvSafety.MultiSelect = false;
            this.dgvSafety.Name = "dgvSafety";
            this.dgvSafety.RowHeadersVisible = false;
            this.dgvSafety.RowTemplate.Height = 35;
            this.dgvSafety.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSafety.Size = new System.Drawing.Size(876, 501);
            this.dgvSafety.TabIndex = 2;
            this.dgvSafety.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSafety_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SummaryLine";
            this.dataGridViewTextBoxColumn2.HeaderText = "Safety Message";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // colSafetyCopyToNext
            // 
            this.colSafetyCopyToNext.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSafetyCopyToNext.DataPropertyName = "CopyNextOpText";
            this.colSafetyCopyToNext.HeaderText = "Copy to selected op";
            this.colSafetyCopyToNext.Name = "colSafetyCopyToNext";
            this.colSafetyCopyToNext.Text = "Copy to selected Op";
            this.colSafetyCopyToNext.Width = 148;
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.lblAirOpsCopyStatus);
            this.tpOther.Controls.Add(this.lblMedPlanCopyStatus);
            this.tpOther.Controls.Add(this.lblCommsPlanCopyStatus);
            this.tpOther.Controls.Add(this.btnCopyAirOps);
            this.tpOther.Controls.Add(this.btnCopyMedPlan);
            this.tpOther.Controls.Add(this.btnCopyCommsPlan);
            this.tpOther.Location = new System.Drawing.Point(4, 33);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(876, 501);
            this.tpOther.TabIndex = 8;
            this.tpOther.Text = "Other";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // lblAirOpsCopyStatus
            // 
            this.lblAirOpsCopyStatus.AutoSize = true;
            this.lblAirOpsCopyStatus.Location = new System.Drawing.Point(361, 151);
            this.lblAirOpsCopyStatus.Name = "lblAirOpsCopyStatus";
            this.lblAirOpsCopyStatus.Size = new System.Drawing.Size(60, 24);
            this.lblAirOpsCopyStatus.TabIndex = 8;
            this.lblAirOpsCopyStatus.Text = "label3";
            // 
            // lblMedPlanCopyStatus
            // 
            this.lblMedPlanCopyStatus.AutoSize = true;
            this.lblMedPlanCopyStatus.Location = new System.Drawing.Point(361, 91);
            this.lblMedPlanCopyStatus.Name = "lblMedPlanCopyStatus";
            this.lblMedPlanCopyStatus.Size = new System.Drawing.Size(60, 24);
            this.lblMedPlanCopyStatus.TabIndex = 7;
            this.lblMedPlanCopyStatus.Text = "label2";
            // 
            // lblCommsPlanCopyStatus
            // 
            this.lblCommsPlanCopyStatus.AutoSize = true;
            this.lblCommsPlanCopyStatus.Location = new System.Drawing.Point(361, 31);
            this.lblCommsPlanCopyStatus.Name = "lblCommsPlanCopyStatus";
            this.lblCommsPlanCopyStatus.Size = new System.Drawing.Size(60, 24);
            this.lblCommsPlanCopyStatus.TabIndex = 6;
            this.lblCommsPlanCopyStatus.Text = "label1";
            // 
            // btnCopyAirOps
            // 
            this.btnCopyAirOps.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnCopyAirOps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyAirOps.Location = new System.Drawing.Point(8, 136);
            this.btnCopyAirOps.Name = "btnCopyAirOps";
            this.btnCopyAirOps.Size = new System.Drawing.Size(347, 54);
            this.btnCopyAirOps.TabIndex = 5;
            this.btnCopyAirOps.Text = "Copy Air Ops Plan to Next Op";
            this.btnCopyAirOps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyAirOps.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyAirOps.UseVisualStyleBackColor = true;
            this.btnCopyAirOps.Click += new System.EventHandler(this.btnCopyAirOps_Click);
            // 
            // btnCopyMedPlan
            // 
            this.btnCopyMedPlan.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnCopyMedPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyMedPlan.Location = new System.Drawing.Point(8, 76);
            this.btnCopyMedPlan.Name = "btnCopyMedPlan";
            this.btnCopyMedPlan.Size = new System.Drawing.Size(347, 54);
            this.btnCopyMedPlan.TabIndex = 4;
            this.btnCopyMedPlan.Text = "Copy Medical Plan to Next Op";
            this.btnCopyMedPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyMedPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyMedPlan.UseVisualStyleBackColor = true;
            this.btnCopyMedPlan.Click += new System.EventHandler(this.btnCopyMedPlan_Click);
            // 
            // btnCopyCommsPlan
            // 
            this.btnCopyCommsPlan.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnCopyCommsPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopyCommsPlan.Location = new System.Drawing.Point(8, 16);
            this.btnCopyCommsPlan.Name = "btnCopyCommsPlan";
            this.btnCopyCommsPlan.Size = new System.Drawing.Size(347, 54);
            this.btnCopyCommsPlan.TabIndex = 3;
            this.btnCopyCommsPlan.Text = "Copy Comms Plan to Next Op";
            this.btnCopyCommsPlan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyCommsPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCopyCommsPlan.UseVisualStyleBackColor = true;
            this.btnCopyCommsPlan.Click += new System.EventHandler(this.btnCopyCommsPlan_Click);
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.textBox1);
            this.tpSummary.Location = new System.Drawing.Point(4, 33);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(876, 501);
            this.tpSummary.TabIndex = 7;
            this.tpSummary.Text = "Summary Stats";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(391, 268);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(482, 122);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "-total number of people, vehicles, equipment, visitors\r\n-total number of people i" +
    "n the IMT, and per section\r\n-total person hours for the op period\r\n-running tota" +
    "l person hours for the incident";
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.numOpPeriod);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.datOpsStart);
            this.splitContainer1.Panel2.Controls.Add(this.datOpsEnd);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Size = new System.Drawing.Size(984, 606);
            this.splitContainer1.SplitterDistance = 538;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(2, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 66);
            this.label1.TabIndex = 21;
            this.label1.Text = "Move to this Operational Period:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(659, 22);
            this.label18.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 24);
            this.label18.TabIndex = 20;
            this.label18.Text = "To";
            // 
            // datOpsStart
            // 
            this.datOpsStart.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datOpsStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsStart.Location = new System.Drawing.Point(451, 20);
            this.datOpsStart.Name = "datOpsStart";
            this.datOpsStart.Size = new System.Drawing.Size(187, 26);
            this.datOpsStart.TabIndex = 17;
            this.datOpsStart.ValueChanged += new System.EventHandler(this.datOpsStart_ValueChanged);
            this.datOpsStart.Leave += new System.EventHandler(this.datOpsStart_Leave);
            // 
            // datOpsEnd
            // 
            this.datOpsEnd.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datOpsEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datOpsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsEnd.Location = new System.Drawing.Point(714, 20);
            this.datOpsEnd.Name = "datOpsEnd";
            this.datOpsEnd.Size = new System.Drawing.Size(187, 26);
            this.datOpsEnd.TabIndex = 18;
            this.datOpsEnd.Leave += new System.EventHandler(this.datOpsEnd_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(396, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 24);
            this.label15.TabIndex = 19;
            this.label15.Text = "From";
            // 
            // numOpPeriod
            // 
            this.numOpPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOpPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.numOpPeriod.Location = new System.Drawing.Point(268, 7);
            this.numOpPeriod.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
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
            this.numOpPeriod.Size = new System.Drawing.Size(110, 50);
            this.numOpPeriod.TabIndex = 22;
            this.numOpPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numOpPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpPeriod.ValueChanged += new System.EventHandler(this.numOpPeriod_ValueChanged);
            // 
            // CloseOpPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 606);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CloseOpPeriodForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operational Period Review";
            this.Load += new System.EventHandler(this.CloseOpPeriodForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpObjectives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).EndInit();
            this.tpResources.ResumeLayout(false);
            this.tpResources.PerformLayout();
            this.tpOrgChart.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tpSafety.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSafety)).EndInit();
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.tpSummary.ResumeLayout(false);
            this.tpSummary.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpObjectives;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvObjectives;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectivePriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjective;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colObjectiveCompleted;
        private System.Windows.Forms.DataGridViewButtonColumn colTransferObjective;
        private System.Windows.Forms.TabPage tpResources;
        private System.Windows.Forms.TabPage tpOrgChart;
        private System.Windows.Forms.TabPage tpSafety;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCopyOrgChart;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.TreeView treeOrgChart2;
        private System.Windows.Forms.Label lblCurrentOrgTitle;
        private System.Windows.Forms.Label lblNextOrgTitle;
        private System.Windows.Forms.DataGridView dgvSafety;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewButtonColumn colSafetyCopyToNext;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.Button btnCopyMedPlan;
        private System.Windows.Forms.Button btnCopyCommsPlan;
        private System.Windows.Forms.Button btnCopyAirOps;
        private System.Windows.Forms.Label lblAirOpsCopyStatus;
        private System.Windows.Forms.Label lblMedPlanCopyStatus;
        private System.Windows.Forms.Label lblCommsPlanCopyStatus;
        private System.Windows.Forms.CheckBox chkCopyOrgAssignments;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker datOpsStart;
        private System.Windows.Forms.DateTimePicker datOpsEnd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.NumericUpDown numOpPeriod;
    }
}