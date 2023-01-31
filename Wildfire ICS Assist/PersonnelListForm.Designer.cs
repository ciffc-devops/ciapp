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
            this.btnTotalByTeam = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSelectedMember = new System.Windows.Forms.Panel();
            this.btnViewEquipment = new System.Windows.Forms.Button();
            this.btnSignInSelected = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateTimes = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnViewAssignment = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.dgvTotalByAgency = new System.Windows.Forms.DataGridView();
            this.colTotalsAgencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.collapsiblePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalByAgency)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(1347, 793);
            this.splitContainer1.SplitterDistance = 595;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvPersonnel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1347, 595);
            this.splitContainer2.SplitterDistance = 1067;
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
            this.dgvPersonnel.Size = new System.Drawing.Size(1067, 595);
            this.dgvPersonnel.TabIndex = 0;
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
            this.btnBulkSignIn.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnBulkSignIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBulkSignIn.Location = new System.Drawing.Point(11, 104);
            this.btnBulkSignIn.Name = "btnBulkSignIn";
            this.btnBulkSignIn.Size = new System.Drawing.Size(160, 66);
            this.btnBulkSignIn.TabIndex = 12;
            this.btnBulkSignIn.Text = "Bulk Sign In";
            this.btnBulkSignIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBulkSignIn.UseVisualStyleBackColor = true;
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
            this.pnlBulkOps.Controls.Add(this.btnTotalByTeam);
            this.pnlBulkOps.Controls.Add(this.label4);
            this.pnlBulkOps.Location = new System.Drawing.Point(690, 3);
            this.pnlBulkOps.Name = "pnlBulkOps";
            this.pnlBulkOps.Size = new System.Drawing.Size(370, 185);
            this.pnlBulkOps.TabIndex = 44;
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(208, 34);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(152, 66);
            this.btnExportSignInToCSV.TabIndex = 40;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Location = new System.Drawing.Point(13, 106);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(347, 66);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnTotalByTeam
            // 
            this.btnTotalByTeam.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_532_user_family;
            this.btnTotalByTeam.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTotalByTeam.Location = new System.Drawing.Point(13, 34);
            this.btnTotalByTeam.Name = "btnTotalByTeam";
            this.btnTotalByTeam.Size = new System.Drawing.Size(189, 66);
            this.btnTotalByTeam.TabIndex = 10;
            this.btnTotalByTeam.Text = "Totals by Team";
            this.btnTotalByTeam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTotalByTeam.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Other Functions";
            // 
            // pnlSelectedMember
            // 
            this.pnlSelectedMember.BackColor = System.Drawing.Color.White;
            this.pnlSelectedMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectedMember.Controls.Add(this.btnViewEquipment);
            this.pnlSelectedMember.Controls.Add(this.btnSignInSelected);
            this.pnlSelectedMember.Controls.Add(this.label3);
            this.pnlSelectedMember.Controls.Add(this.btnUpdateTimes);
            this.pnlSelectedMember.Controls.Add(this.btnEdit);
            this.pnlSelectedMember.Controls.Add(this.btnViewAssignment);
            this.pnlSelectedMember.Controls.Add(this.btnSignOut);
            this.pnlSelectedMember.Enabled = false;
            this.pnlSelectedMember.Location = new System.Drawing.Point(198, 3);
            this.pnlSelectedMember.Name = "pnlSelectedMember";
            this.pnlSelectedMember.Size = new System.Drawing.Size(486, 185);
            this.pnlSelectedMember.TabIndex = 43;
            // 
            // btnViewEquipment
            // 
            this.btnViewEquipment.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_876_palette_package;
            this.btnViewEquipment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewEquipment.Location = new System.Drawing.Point(319, 34);
            this.btnViewEquipment.Name = "btnViewEquipment";
            this.btnViewEquipment.Size = new System.Drawing.Size(157, 66);
            this.btnViewEquipment.TabIndex = 14;
            this.btnViewEquipment.Text = "View Equipment";
            this.btnViewEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewEquipment.UseVisualStyleBackColor = true;
            // 
            // btnSignInSelected
            // 
            this.btnSignInSelected.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnSignInSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignInSelected.Location = new System.Drawing.Point(8, 104);
            this.btnSignInSelected.Name = "btnSignInSelected";
            this.btnSignInSelected.Size = new System.Drawing.Size(160, 66);
            this.btnSignInSelected.TabIndex = 13;
            this.btnSignInSelected.Text = "Sign In Selected";
            this.btnSignInSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignInSelected.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(478, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected Personnel";
            // 
            // btnUpdateTimes
            // 
            this.btnUpdateTimes.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_55_clock;
            this.btnUpdateTimes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateTimes.Location = new System.Drawing.Point(174, 104);
            this.btnUpdateTimes.Name = "btnUpdateTimes";
            this.btnUpdateTimes.Size = new System.Drawing.Size(139, 66);
            this.btnUpdateTimes.TabIndex = 6;
            this.btnUpdateTimes.Text = "Update Times";
            this.btnUpdateTimes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateTimes.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(8, 32);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 66);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "View Details";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnViewAssignment
            // 
            this.btnViewAssignment.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_30_clipboard;
            this.btnViewAssignment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewAssignment.Location = new System.Drawing.Point(153, 32);
            this.btnViewAssignment.Name = "btnViewAssignment";
            this.btnViewAssignment.Size = new System.Drawing.Size(157, 66);
            this.btnViewAssignment.TabIndex = 4;
            this.btnViewAssignment.Text = "View Assignment";
            this.btnViewAssignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewAssignment.UseVisualStyleBackColor = true;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_432_log_out;
            this.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSignOut.Location = new System.Drawing.Point(319, 104);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(157, 66);
            this.btnSignOut.TabIndex = 5;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.CollapsedHeight = 40;
            this.collapsiblePanel1.CollapsedWidth = 265;
            this.collapsiblePanel1.CollapseLeft = true;
            this.collapsiblePanel1.Controls.Add(this.dgvTotalByAgency);
            this.collapsiblePanel1.CurrentlyCollapsed = false;
            this.collapsiblePanel1.ExpandedHeight = 300;
            this.collapsiblePanel1.ExpandedWidth = 265;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(5, 6);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(265, 300);
            this.collapsiblePanel1.TabIndex = 34;
            this.collapsiblePanel1.TitleText = "Agency Totals";
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
            // PersonnelListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 793);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1085, 526);
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
            this.collapsiblePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalByAgency)).EndInit();
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
        private System.Windows.Forms.Button btnTotalByTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSelectedMember;
        private System.Windows.Forms.Button btnViewEquipment;
        private System.Windows.Forms.Button btnSignInSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateTimes;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnViewAssignment;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.DataGridView dgvTotalByAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLDW;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignment;
        private CustomControls.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalsAgencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalsCount;
    }
}