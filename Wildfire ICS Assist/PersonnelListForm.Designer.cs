namespace Wildfire_ICS_Assist
{
    partial class PersonnelListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelListForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.colAgency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLDW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSignIn = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBulkSignIn = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.pnlBulkOps = new System.Windows.Forms.Panel();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSelectedMember = new System.Windows.Forms.Panel();
            this.btnSignInSelected = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateTimes = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.collapsiblePanel2 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.lblLDWLessThan48 = new System.Windows.Forms.Label();
            this.lblLDWLessThan24 = new System.Windows.Forms.Label();
            this.cpnlAgencyTotals = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.dgvTotalByAgency = new System.Windows.Forms.DataGridView();
            this.colTotalsAgencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.chkLDWSoon = new System.Windows.Forms.CheckBox();
            this.chkNotSignedInOnly = new System.Windows.Forms.CheckBox();
            this.chkUnassignedOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.pnlSignIn.SuspendLayout();
            this.pnlBulkOps.SuspendLayout();
            this.pnlSelectedMember.SuspendLayout();
            this.collapsiblePanel2.SuspendLayout();
            this.cpnlAgencyTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalByAgency)).BeginInit();
            this.collapsiblePanel1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.pnlSignIn);
            this.splitContainer1.Panel2.Controls.Add(this.pnlBulkOps);
            this.splitContainer1.Panel2.Controls.Add(this.pnlSelectedMember);
            this.splitContainer1.Size = new System.Drawing.Size(924, 741);
            this.splitContainer1.SplitterDistance = 543;
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
            this.splitContainer2.Panel1.Controls.Add(this.dgvPersonnel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel2);
            this.splitContainer2.Panel2.Controls.Add(this.cpnlAgencyTotals);
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel1);
            this.splitContainer2.Size = new System.Drawing.Size(924, 543);
            this.splitContainer2.SplitterDistance = 642;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.AllowUserToAddRows = false;
            this.dgvPersonnel.AllowUserToDeleteRows = false;
            this.dgvPersonnel.AllowUserToResizeColumns = false;
            this.dgvPersonnel.AllowUserToResizeRows = false;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAgency,
            this.colName,
            this.colCheckIn,
            this.colLDW,
            this.colAssignment});
            this.dgvPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonnel.Location = new System.Drawing.Point(0, 0);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.RowHeadersVisible = false;
            this.dgvPersonnel.RowTemplate.Height = 30;
            this.dgvPersonnel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.Size = new System.Drawing.Size(642, 543);
            this.dgvPersonnel.TabIndex = 0;
            this.dgvPersonnel.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonnel_CellDoubleClick);
            this.dgvPersonnel.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPersonnel_CellFormatting);
            this.dgvPersonnel.SelectionChanged += new System.EventHandler(this.dgvPersonnel_SelectionChanged);
            // 
            // colAgency
            // 
            this.colAgency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAgency.DataPropertyName = "OrganizationName";
            this.colAgency.HeaderText = "Agency";
            this.colAgency.Name = "colAgency";
            this.colAgency.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "MemberName";
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 150;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colCheckIn
            // 
            this.colCheckIn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCheckIn.DataPropertyName = "SignInTimeAsText";
            this.colCheckIn.HeaderText = "Check-In";
            this.colCheckIn.Name = "colCheckIn";
            this.colCheckIn.ReadOnly = true;
            this.colCheckIn.Width = 110;
            // 
            // colLDW
            // 
            this.colLDW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLDW.DataPropertyName = "LastDayWorkedAsStr";
            this.colLDW.HeaderText = "LDW";
            this.colLDW.Name = "colLDW";
            this.colLDW.ReadOnly = true;
            this.colLDW.Width = 76;
            // 
            // colAssignment
            // 
            this.colAssignment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAssignment.DataPropertyName = "getCurrentActivityName";
            this.colAssignment.HeaderText = "Assignment";
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.ReadOnly = true;
            this.colAssignment.Width = 134;
            // 
            // pnlSignIn
            // 
            this.pnlSignIn.BackColor = System.Drawing.Color.White;
            this.pnlSignIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSignIn.Controls.Add(this.label6);
            this.pnlSignIn.Controls.Add(this.btnBulkSignIn);
            this.pnlSignIn.Controls.Add(this.btnSignIn);
            this.pnlSignIn.Location = new System.Drawing.Point(12, 3);
            this.pnlSignIn.Name = "pnlSignIn";
            this.pnlSignIn.Size = new System.Drawing.Size(180, 185);
            this.pnlSignIn.TabIndex = 45;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "New Sign In";
            // 
            // btnBulkSignIn
            // 
            this.btnBulkSignIn.Image = ((System.Drawing.Image)(resources.GetObject("btnBulkSignIn.Image")));
            this.btnBulkSignIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBulkSignIn.Location = new System.Drawing.Point(11, 104);
            this.btnBulkSignIn.Name = "btnBulkSignIn";
            this.btnBulkSignIn.Size = new System.Drawing.Size(160, 66);
            this.btnBulkSignIn.TabIndex = 12;
            this.btnBulkSignIn.Text = "Bulk Sign In";
            this.btnBulkSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBulkSignIn.UseVisualStyleBackColor = true;
            this.btnBulkSignIn.Click += new System.EventHandler(this.btnBulkSignIn_Click);
            // 
            // btnSignIn
            // 
            this.btnSignIn.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnSignIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignIn.Location = new System.Drawing.Point(11, 32);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(160, 66);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // pnlBulkOps
            // 
            this.pnlBulkOps.BackColor = System.Drawing.Color.White;
            this.pnlBulkOps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBulkOps.Controls.Add(this.btnExportSignInToCSV);
            this.pnlBulkOps.Controls.Add(this.btnPrint);
            this.pnlBulkOps.Controls.Add(this.label4);
            this.pnlBulkOps.Location = new System.Drawing.Point(531, 3);
            this.pnlBulkOps.Name = "pnlBulkOps";
            this.pnlBulkOps.Size = new System.Drawing.Size(224, 185);
            this.pnlBulkOps.TabIndex = 44;
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(13, 34);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(197, 66);
            this.btnExportSignInToCSV.TabIndex = 40;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            this.btnExportSignInToCSV.Click += new System.EventHandler(this.btnExportSignInToCSV_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(13, 106);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(197, 66);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Output";
            // 
            // pnlSelectedMember
            // 
            this.pnlSelectedMember.BackColor = System.Drawing.Color.White;
            this.pnlSelectedMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedMember.Controls.Add(this.btnSignInSelected);
            this.pnlSelectedMember.Controls.Add(this.label3);
            this.pnlSelectedMember.Controls.Add(this.btnUpdateTimes);
            this.pnlSelectedMember.Controls.Add(this.btnViewDetails);
            this.pnlSelectedMember.Controls.Add(this.btnSignOut);
            this.pnlSelectedMember.Enabled = false;
            this.pnlSelectedMember.Location = new System.Drawing.Point(198, 3);
            this.pnlSelectedMember.Name = "pnlSelectedMember";
            this.pnlSelectedMember.Size = new System.Drawing.Size(327, 185);
            this.pnlSelectedMember.TabIndex = 43;
            // 
            // btnSignInSelected
            // 
            this.btnSignInSelected.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnSignInSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignInSelected.Location = new System.Drawing.Point(8, 32);
            this.btnSignInSelected.Name = "btnSignInSelected";
            this.btnSignInSelected.Size = new System.Drawing.Size(160, 66);
            this.btnSignInSelected.TabIndex = 13;
            this.btnSignInSelected.Text = "Sign In Selected";
            this.btnSignInSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignInSelected.UseVisualStyleBackColor = true;
            this.btnSignInSelected.Click += new System.EventHandler(this.btnSignInSelected_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected Personnel";
            // 
            // btnUpdateTimes
            // 
            this.btnUpdateTimes.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_55_clock;
            this.btnUpdateTimes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateTimes.Location = new System.Drawing.Point(8, 104);
            this.btnUpdateTimes.Name = "btnUpdateTimes";
            this.btnUpdateTimes.Size = new System.Drawing.Size(139, 66);
            this.btnUpdateTimes.TabIndex = 6;
            this.btnUpdateTimes.Text = "Update Times";
            this.btnUpdateTimes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateTimes.UseVisualStyleBackColor = true;
            this.btnUpdateTimes.Click += new System.EventHandler(this.btnUpdateTimes_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewDetails.Location = new System.Drawing.Point(174, 32);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(139, 66);
            this.btnViewDetails.TabIndex = 3;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_432_log_out;
            this.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignOut.Location = new System.Drawing.Point(153, 104);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(157, 66);
            this.btnSignOut.TabIndex = 5;
            this.btnSignOut.Text = "Check Out Selected";
            this.btnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Visible = false;
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // collapsiblePanel2
            // 
            this.collapsiblePanel2.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel2.CollapsedHeight = 40;
            this.collapsiblePanel2.CollapsedWidth = 265;
            this.collapsiblePanel2.CollapseLeft = true;
            this.collapsiblePanel2.Controls.Add(this.lblLDWLessThan48);
            this.collapsiblePanel2.Controls.Add(this.lblLDWLessThan24);
            this.collapsiblePanel2.CurrentlyCollapsed = false;
            this.collapsiblePanel2.ExpandedHeight = 132;
            this.collapsiblePanel2.ExpandedWidth = 265;
            this.collapsiblePanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel2.Location = new System.Drawing.Point(5, 106);
            this.collapsiblePanel2.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel2.Name = "collapsiblePanel2";
            this.collapsiblePanel2.Size = new System.Drawing.Size(265, 132);
            this.collapsiblePanel2.TabIndex = 36;
            this.collapsiblePanel2.TitleText = "Summary Stats";
            // 
            // lblLDWLessThan48
            // 
            this.lblLDWLessThan48.Location = new System.Drawing.Point(0, 78);
            this.lblLDWLessThan48.Name = "lblLDWLessThan48";
            this.lblLDWLessThan48.Size = new System.Drawing.Size(257, 28);
            this.lblLDWLessThan48.TabIndex = 34;
            this.lblLDWLessThan48.Text = "label1";
            // 
            // lblLDWLessThan24
            // 
            this.lblLDWLessThan24.Location = new System.Drawing.Point(0, 50);
            this.lblLDWLessThan24.Name = "lblLDWLessThan24";
            this.lblLDWLessThan24.Size = new System.Drawing.Size(257, 28);
            this.lblLDWLessThan24.TabIndex = 33;
            this.lblLDWLessThan24.Text = "label1";
            // 
            // cpnlAgencyTotals
            // 
            this.cpnlAgencyTotals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpnlAgencyTotals.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpnlAgencyTotals.CollapsedHeight = 40;
            this.cpnlAgencyTotals.CollapsedWidth = 265;
            this.cpnlAgencyTotals.CollapseLeft = true;
            this.cpnlAgencyTotals.Controls.Add(this.dgvTotalByAgency);
            this.cpnlAgencyTotals.CurrentlyCollapsed = true;
            this.cpnlAgencyTotals.ExpandedHeight = 300;
            this.cpnlAgencyTotals.ExpandedWidth = 265;
            this.cpnlAgencyTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpnlAgencyTotals.Location = new System.Drawing.Point(5, 58);
            this.cpnlAgencyTotals.Margin = new System.Windows.Forms.Padding(6);
            this.cpnlAgencyTotals.Name = "cpnlAgencyTotals";
            this.cpnlAgencyTotals.Size = new System.Drawing.Size(265, 40);
            this.cpnlAgencyTotals.TabIndex = 34;
            this.cpnlAgencyTotals.TitleText = "Agency Totals";
            // 
            // dgvTotalByAgency
            // 
            this.dgvTotalByAgency.AllowUserToAddRows = false;
            this.dgvTotalByAgency.AllowUserToDeleteRows = false;
            this.dgvTotalByAgency.AllowUserToResizeColumns = false;
            this.dgvTotalByAgency.AllowUserToResizeRows = false;
            this.dgvTotalByAgency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalByAgency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTotalsAgencyName,
            this.colTotalsCount});
            this.dgvTotalByAgency.Location = new System.Drawing.Point(4, 47);
            this.dgvTotalByAgency.Name = "dgvTotalByAgency";
            this.dgvTotalByAgency.ReadOnly = true;
            this.dgvTotalByAgency.RowHeadersVisible = false;
            this.dgvTotalByAgency.RowTemplate.Height = 30;
            this.dgvTotalByAgency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotalByAgency.Size = new System.Drawing.Size(256, 248);
            this.dgvTotalByAgency.TabIndex = 33;
            // 
            // colTotalsAgencyName
            // 
            this.colTotalsAgencyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalsAgencyName.DataPropertyName = "AgencyName";
            this.colTotalsAgencyName.HeaderText = "Agency";
            this.colTotalsAgencyName.Name = "colTotalsAgencyName";
            this.colTotalsAgencyName.ReadOnly = true;
            // 
            // colTotalsCount
            // 
            this.colTotalsCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTotalsCount.DataPropertyName = "Count";
            this.colTotalsCount.HeaderText = "#";
            this.colTotalsCount.Name = "colTotalsCount";
            this.colTotalsCount.ReadOnly = true;
            this.colTotalsCount.Width = 45;
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.CollapsedHeight = 40;
            this.collapsiblePanel1.CollapsedWidth = 265;
            this.collapsiblePanel1.CollapseLeft = true;
            this.collapsiblePanel1.Controls.Add(this.chkLDWSoon);
            this.collapsiblePanel1.Controls.Add(this.chkNotSignedInOnly);
            this.collapsiblePanel1.Controls.Add(this.chkUnassignedOnly);
            this.collapsiblePanel1.CurrentlyCollapsed = true;
            this.collapsiblePanel1.ExpandedHeight = 161;
            this.collapsiblePanel1.ExpandedWidth = 265;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(5, 6);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(265, 40);
            this.collapsiblePanel1.TabIndex = 35;
            this.collapsiblePanel1.TitleText = "List Filters";
            // 
            // chkLDWSoon
            // 
            this.chkLDWSoon.AutoSize = true;
            this.chkLDWSoon.Location = new System.Drawing.Point(13, 119);
            this.chkLDWSoon.Name = "chkLDWSoon";
            this.chkLDWSoon.Size = new System.Drawing.Size(216, 28);
            this.chkLDWSoon.TabIndex = 35;
            this.chkLDWSoon.Text = "LDW is in the next 24h";
            this.chkLDWSoon.UseVisualStyleBackColor = true;
            this.chkLDWSoon.CheckedChanged += new System.EventHandler(this.chkLDWSoon_CheckedChanged);
            // 
            // chkNotSignedInOnly
            // 
            this.chkNotSignedInOnly.AutoSize = true;
            this.chkNotSignedInOnly.Location = new System.Drawing.Point(13, 85);
            this.chkNotSignedInOnly.Name = "chkNotSignedInOnly";
            this.chkNotSignedInOnly.Size = new System.Drawing.Size(247, 28);
            this.chkNotSignedInOnly.TabIndex = 34;
            this.chkNotSignedInOnly.Text = "Show not checked-in only";
            this.chkNotSignedInOnly.UseVisualStyleBackColor = true;
            this.chkNotSignedInOnly.CheckedChanged += new System.EventHandler(this.chkNotSignedInOnly_CheckedChanged);
            // 
            // chkUnassignedOnly
            // 
            this.chkUnassignedOnly.AutoSize = true;
            this.chkUnassignedOnly.Location = new System.Drawing.Point(13, 51);
            this.chkUnassignedOnly.Name = "chkUnassignedOnly";
            this.chkUnassignedOnly.Size = new System.Drawing.Size(220, 28);
            this.chkUnassignedOnly.TabIndex = 33;
            this.chkUnassignedOnly.Text = "Show unassigned only";
            this.chkUnassignedOnly.UseVisualStyleBackColor = true;
            this.chkUnassignedOnly.CheckedChanged += new System.EventHandler(this.chkUnassignedOnly_CheckedChanged);
            // 
            // PersonnelListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 741);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(940, 524);
            this.Name = "PersonnelListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personnel List Form";
            this.Load += new System.EventHandler(this.PersonnelListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.pnlSignIn.ResumeLayout(false);
            this.pnlBulkOps.ResumeLayout(false);
            this.pnlSelectedMember.ResumeLayout(false);
            this.collapsiblePanel2.ResumeLayout(false);
            this.cpnlAgencyTotals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalByAgency)).EndInit();
            this.collapsiblePanel1.ResumeLayout(false);
            this.collapsiblePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSignIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBulkSignIn;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Panel pnlBulkOps;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSelectedMember;
        private System.Windows.Forms.Button btnSignInSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateTimes;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.DataGridView dgvTotalByAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLDW;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignment;
        private CustomControls.CollapsiblePanel cpnlAgencyTotals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalsAgencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalsCount;
        private CustomControls.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.CheckBox chkNotSignedInOnly;
        private System.Windows.Forms.CheckBox chkUnassignedOnly;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.CheckBox chkLDWSoon;
        private CustomControls.CollapsiblePanel collapsiblePanel2;
        private System.Windows.Forms.Label lblLDWLessThan48;
        private System.Windows.Forms.Label lblLDWLessThan24;
    }
}