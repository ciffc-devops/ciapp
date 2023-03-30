namespace Wildfire_ICS_Assist
{
    partial class PersonnelEditCheckInOutForm
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
            this.chkLDW = new System.Windows.Forms.CheckBox();
            this.chkCheckIn = new System.Windows.Forms.CheckBox();
            this.lblNames = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.datLDW = new System.Windows.Forms.DateTimePicker();
            this.datCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.chkIsCheckedOut = new System.Windows.Forms.CheckBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.chkLDW);
            this.splitContainer1.Panel1.Controls.Add(this.chkCheckIn);
            this.splitContainer1.Panel1.Controls.Add(this.lblNames);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.datLDW);
            this.splitContainer1.Panel1.Controls.Add(this.datCheckInTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkIsCheckedOut);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveChanges);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(566, 621);
            this.splitContainer1.SplitterDistance = 553;
            this.splitContainer1.TabIndex = 34;
            // 
            // chkLDW
            // 
            this.chkLDW.AutoSize = true;
            this.chkLDW.Location = new System.Drawing.Point(19, 120);
            this.chkLDW.Name = "chkLDW";
            this.chkLDW.Size = new System.Drawing.Size(189, 28);
            this.chkLDW.TabIndex = 163;
            this.chkLDW.Text = "Last Day at Incident";
            this.chkLDW.UseVisualStyleBackColor = true;
            // 
            // chkCheckIn
            // 
            this.chkCheckIn.AutoSize = true;
            this.chkCheckIn.Location = new System.Drawing.Point(13, 80);
            this.chkCheckIn.Name = "chkCheckIn";
            this.chkCheckIn.Size = new System.Drawing.Size(195, 28);
            this.chkCheckIn.TabIndex = 162;
            this.chkCheckIn.Text = "Check-In Date/Time";
            this.chkCheckIn.UseVisualStyleBackColor = true;
            // 
            // lblNames
            // 
            this.lblNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNames.Location = new System.Drawing.Point(12, 33);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(542, 47);
            this.lblNames.TabIndex = 161;
            this.lblNames.Text = "label1";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(551, 24);
            this.label9.TabIndex = 160;
            this.label9.Text = "Name(s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datLDW
            // 
            this.datLDW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datLDW.CustomFormat = "yyyy-MMM-dd";
            this.datLDW.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLDW.Location = new System.Drawing.Point(214, 118);
            this.datLDW.Name = "datLDW";
            this.datLDW.Size = new System.Drawing.Size(305, 29);
            this.datLDW.TabIndex = 36;
            this.datLDW.ValueChanged += new System.EventHandler(this.datLDW_ValueChanged);
            this.datLDW.Leave += new System.EventHandler(this.datLDW_Leave);
            // 
            // datCheckInTime
            // 
            this.datCheckInTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datCheckInTime.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInTime.Location = new System.Drawing.Point(214, 83);
            this.datCheckInTime.Name = "datCheckInTime";
            this.datCheckInTime.Size = new System.Drawing.Size(305, 29);
            this.datCheckInTime.TabIndex = 35;
            this.datCheckInTime.ValueChanged += new System.EventHandler(this.datCheckInTime_ValueChanged);
            this.datCheckInTime.Leave += new System.EventHandler(this.datCheckInTime_Leave);
            // 
            // chkIsCheckedOut
            // 
            this.chkIsCheckedOut.AutoSize = true;
            this.chkIsCheckedOut.Location = new System.Drawing.Point(283, 22);
            this.chkIsCheckedOut.Name = "chkIsCheckedOut";
            this.chkIsCheckedOut.Size = new System.Drawing.Size(158, 28);
            this.chkIsCheckedOut.TabIndex = 166;
            this.chkIsCheckedOut.Text = "Is Checked Out";
            this.chkIsCheckedOut.UseVisualStyleBackColor = true;
            this.chkIsCheckedOut.Visible = false;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSaveChanges.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSaveChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanges.Location = new System.Drawing.Point(450, 9);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(110, 47);
            this.btnSaveChanges.TabIndex = 172;
            this.btnSaveChanges.Text = "Save";
            this.btnSaveChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(10, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 171;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PersonnelEditCheckInOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 621);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(582, 660);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(582, 660);
            this.Name = "PersonnelEditCheckInOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Check-In/Out";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DateTimePicker datLDW;
        private System.Windows.Forms.DateTimePicker datCheckInTime;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkLDW;
        private System.Windows.Forms.CheckBox chkCheckIn;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkIsCheckedOut;
    }
}