namespace Wildfire_ICS_Assist
{
    partial class OrganizationChartAssignRole
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
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.cboSavedComms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.editTeamMemberControl1 = new Wildfire_ICS_Assist.CustomControls.EditTeamMemberControl();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(828, 671);
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
            this.panel1.Controls.Add(this.btnAddSaved);
            this.panel1.Controls.Add(this.cboSavedComms);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(30, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 91);
            this.panel1.TabIndex = 1;
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAddSaved.Location = new System.Drawing.Point(655, 33);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 46);
            this.btnAddSaved.TabIndex = 4;
            this.btnAddSaved.Text = "Assign";
            this.btnAddSaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSaved.UseVisualStyleBackColor = true;
            // 
            // cboSavedComms
            // 
            this.cboSavedComms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedComms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedComms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedComms.DisplayMember = "IDWithFrequency";
            this.cboSavedComms.FormattingEnabled = true;
            this.cboSavedComms.Location = new System.Drawing.Point(8, 41);
            this.cboSavedComms.Name = "cboSavedComms";
            this.cboSavedComms.Size = new System.Drawing.Size(638, 32);
            this.cboSavedComms.TabIndex = 1;
            this.cboSavedComms.ValueMember = "ItemID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Team Members";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 473);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(30, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 461);
            this.panel2.TabIndex = 98;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(509, 415);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(137, 28);
            this.chkSaveForLater.TabIndex = 12;
            this.chkSaveForLater.Text = "Save for later";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New Member";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAddNew.Location = new System.Drawing.Point(655, 405);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(123, 46);
            this.btnAddNew.TabIndex = 13;
            this.btnAddNew.Text = "Assign";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // editTeamMemberControl1
            // 
            this.editTeamMemberControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTeamMemberControl1.Location = new System.Drawing.Point(8, 43);
            this.editTeamMemberControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editTeamMemberControl1.Name = "editTeamMemberControl1";
            this.editTeamMemberControl1.Size = new System.Drawing.Size(759, 354);
            this.editTeamMemberControl1.TabIndex = 100;
            this.editTeamMemberControl1.teamMember = null;
            // 
            // OrganizationChartAssignRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(828, 671);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OrganizationChartAssignRole";
            this.Text = "OrganizationChartAssignRole";
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
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSavedComms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNew;
        private CustomControls.EditTeamMemberControl editTeamMemberControl1;
    }
}