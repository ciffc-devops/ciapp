namespace Wildfire_ICS_Assist
{
    partial class OrganizationChartAssignRoleForm
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
            this.lblRoleName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAssignSaved = new System.Windows.Forms.Button();
            this.cboSavedMembers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearAssignment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editTeamMemberControl1 = new Wildfire_ICS_Assist.CustomControls.PersonnelEditControl();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAssignNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblRoleName);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearAssignment);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(828, 1085);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblRoleName
            // 
            this.lblRoleName.AutoSize = true;
            this.lblRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleName.Location = new System.Drawing.Point(12, 8);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(288, 29);
            this.lblRoleName.TabIndex = 2;
            this.lblRoleName.Text = "Chief of doing cool stuff";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAssignSaved);
            this.panel1.Controls.Add(this.cboSavedMembers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(30, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 91);
            this.panel1.TabIndex = 1;
            // 
            // btnAssignSaved
            // 
            this.btnAssignSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignSaved.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAssignSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAssignSaved.Location = new System.Drawing.Point(655, 33);
            this.btnAssignSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAssignSaved.Name = "btnAssignSaved";
            this.btnAssignSaved.Size = new System.Drawing.Size(123, 46);
            this.btnAssignSaved.TabIndex = 4;
            this.btnAssignSaved.Text = "Assign";
            this.btnAssignSaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssignSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignSaved.UseVisualStyleBackColor = true;
            this.btnAssignSaved.Click += new System.EventHandler(this.btnAssignSaved_Click);
            // 
            // cboSavedMembers
            // 
            this.cboSavedMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedMembers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedMembers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedMembers.DisplayMember = "Name";
            this.cboSavedMembers.FormattingEnabled = true;
            this.cboSavedMembers.Location = new System.Drawing.Point(8, 41);
            this.cboSavedMembers.Name = "cboSavedMembers";
            this.cboSavedMembers.Size = new System.Drawing.Size(638, 32);
            this.cboSavedMembers.TabIndex = 1;
            this.cboSavedMembers.ValueMember = "PersonID";
            this.cboSavedMembers.Leave += new System.EventHandler(this.cboSavedMembers_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Checked-In Personnel";
            // 
            // btnClearAssignment
            // 
            this.btnClearAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearAssignment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearAssignment.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnClearAssignment.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_250_eraser;
            this.btnClearAssignment.Location = new System.Drawing.Point(142, 887);
            this.btnClearAssignment.Margin = new System.Windows.Forms.Padding(6);
            this.btnClearAssignment.Name = "btnClearAssignment";
            this.btnClearAssignment.Size = new System.Drawing.Size(217, 51);
            this.btnClearAssignment.TabIndex = 99;
            this.btnClearAssignment.Text = "Clear Assignment";
            this.btnClearAssignment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearAssignment.UseVisualStyleBackColor = true;
            this.btnClearAssignment.Click += new System.EventHandler(this.btnClearAssignment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 887);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.editTeamMemberControl1);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAssignNew);
            this.panel2.Location = new System.Drawing.Point(30, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 875);
            this.panel2.TabIndex = 98;
            // 
            // editTeamMemberControl1
            // 
            this.editTeamMemberControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editTeamMemberControl1.BackColor = System.Drawing.Color.Transparent;
            this.editTeamMemberControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTeamMemberControl1.Location = new System.Drawing.Point(8, 43);
            this.editTeamMemberControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editTeamMemberControl1.MinimumSize = new System.Drawing.Size(442, 769);
            this.editTeamMemberControl1.Name = "editTeamMemberControl1";
            this.editTeamMemberControl1.Size = new System.Drawing.Size(759, 769);
            this.editTeamMemberControl1.TabIndex = 100;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(417, 829);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveForLater.TabIndex = 12;
            this.chkSaveForLater.Text = "Save for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New Personnel";
            // 
            // btnAssignNew
            // 
            this.btnAssignNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignNew.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAssignNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAssignNew.Location = new System.Drawing.Point(655, 819);
            this.btnAssignNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAssignNew.Name = "btnAssignNew";
            this.btnAssignNew.Size = new System.Drawing.Size(123, 46);
            this.btnAssignNew.TabIndex = 13;
            this.btnAssignNew.Text = "Assign";
            this.btnAssignNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAssignNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignNew.UseVisualStyleBackColor = true;
            this.btnAssignNew.Click += new System.EventHandler(this.btnAssignNew_Click);
            // 
            // OrganizationChartAssignRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(828, 1085);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizationChartAssignRoleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Role";
            this.Load += new System.EventHandler(this.OrganizationChartAssignRole_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAssignSaved;
        private System.Windows.Forms.ComboBox cboSavedMembers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAssignNew;
        private CustomControls.PersonnelEditControl editTeamMemberControl1;
        private System.Windows.Forms.Button btnClearAssignment;
    }
}