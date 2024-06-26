﻿namespace Wildfire_ICS_Assist
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblRoleName);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearAssignment);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(514, 206);
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
            this.panel1.Location = new System.Drawing.Point(6, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 91);
            this.panel1.TabIndex = 1;
            // 
            // btnAssignSaved
            // 
            this.btnAssignSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAssignSaved.Location = new System.Drawing.Point(365, 33);
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
            this.cboSavedMembers.DisplayMember = "NameWithInitialRoleAcronym";
            this.cboSavedMembers.FormattingEnabled = true;
            this.cboSavedMembers.Location = new System.Drawing.Point(8, 41);
            this.cboSavedMembers.Name = "cboSavedMembers";
            this.cboSavedMembers.Size = new System.Drawing.Size(348, 32);
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
            this.btnClearAssignment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearAssignment.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_250_eraser;
            this.btnClearAssignment.Location = new System.Drawing.Point(142, 6);
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
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OrganizationChartAssignRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(514, 206);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 245);
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
        private System.Windows.Forms.Button btnClearAssignment;
    }
}