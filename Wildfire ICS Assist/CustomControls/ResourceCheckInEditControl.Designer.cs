namespace Wildfire_ICS_Assist.CustomControls
{
    partial class ResourceCheckInEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblLastDayCount = new System.Windows.Forms.Label();
            this.lblScrollHint = new System.Windows.Forms.Label();
            this.pnlCheckInFields = new System.Windows.Forms.Panel();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.datLDW = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastDayWorking = new System.Windows.Forms.Label();
            this.lblDaysSinceLastDayOfRest = new System.Windows.Forms.Label();
            this.datLastDayOfRest = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboICSRole = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chkAutoAssign = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUniqueIDLetter = new System.Windows.Forms.ComboBox();
            this.numUniqueIDNumber = new System.Windows.Forms.NumericUpDown();
            this.btnGetNextID = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlPersonnelDetails = new System.Windows.Forms.Panel();
            this.datFirstDayOnIncident = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlOtherResourceDetails = new System.Windows.Forms.Panel();
            this.datFirstDayOnIncidentOtherResource = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datLDWOtherResource = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.datCheckInTimeOtherResource = new System.Windows.Forms.DateTimePicker();
            this.pnlRoleOnTask = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numUniqueIDNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlPersonnelDetails.SuspendLayout();
            this.pnlOtherResourceDetails.SuspendLayout();
            this.pnlRoleOnTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLastDayCount
            // 
            this.lblLastDayCount.AutoSize = true;
            this.lblLastDayCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDayCount.Location = new System.Drawing.Point(462, 112);
            this.lblLastDayCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastDayCount.Name = "lblLastDayCount";
            this.lblLastDayCount.Size = new System.Drawing.Size(278, 17);
            this.lblLastDayCount.TabIndex = 129;
            this.lblLastDayCount.Text = "25 days since rest / 25 days since check in";
            this.lblLastDayCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScrollHint
            // 
            this.lblScrollHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrollHint.BackColor = System.Drawing.Color.Maroon;
            this.lblScrollHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScrollHint.ForeColor = System.Drawing.Color.White;
            this.lblScrollHint.Location = new System.Drawing.Point(491, 41);
            this.lblScrollHint.Name = "lblScrollHint";
            this.lblScrollHint.Size = new System.Drawing.Size(231, 34);
            this.lblScrollHint.TabIndex = 128;
            this.lblScrollHint.Text = "Be sure to scroll the area below";
            this.lblScrollHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCheckInFields
            // 
            this.pnlCheckInFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckInFields.AutoScroll = true;
            this.pnlCheckInFields.BackColor = System.Drawing.Color.Transparent;
            this.pnlCheckInFields.Location = new System.Drawing.Point(7, 424);
            this.pnlCheckInFields.Name = "pnlCheckInFields";
            this.pnlCheckInFields.Size = new System.Drawing.Size(715, 170);
            this.pnlCheckInFields.TabIndex = 9;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResourceType.Location = new System.Drawing.Point(452, 6);
            this.txtResourceType.Margin = new System.Windows.Forms.Padding(6);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.ReadOnly = true;
            this.txtResourceType.Size = new System.Drawing.Size(267, 29);
            this.txtResourceType.TabIndex = 126;
            this.txtResourceType.TabStop = false;
            // 
            // txtSelectedName
            // 
            this.txtSelectedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedName.Location = new System.Drawing.Point(202, 6);
            this.txtSelectedName.Margin = new System.Windows.Forms.Padding(6);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.ReadOnly = true;
            this.txtSelectedName.Size = new System.Drawing.Size(238, 29);
            this.txtSelectedName.TabIndex = 120;
            this.txtSelectedName.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 29);
            this.label3.TabIndex = 122;
            this.label3.Text = "Resource";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datCheckInTime
            // 
            this.datCheckInTime.CustomFormat = "yyyy-MMMM-dd";
            this.datCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInTime.Location = new System.Drawing.Point(199, 73);
            this.datCheckInTime.Name = "datCheckInTime";
            this.datCheckInTime.Size = new System.Drawing.Size(254, 29);
            this.datCheckInTime.TabIndex = 5;
            this.datCheckInTime.ValueChanged += new System.EventHandler(this.datCheckInTime_ValueChanged);
            // 
            // datLDW
            // 
            this.datLDW.CustomFormat = "yyyy-MMMM-dd";
            this.datLDW.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLDW.Location = new System.Drawing.Point(199, 106);
            this.datLDW.Name = "datLDW";
            this.datLDW.Size = new System.Drawing.Size(254, 29);
            this.datLDW.TabIndex = 6;
            this.datLDW.ValueChanged += new System.EventHandler(this.datLDW_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 124;
            this.label4.Text = "Check-In at Incident*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastDayWorking
            // 
            this.lblLastDayWorking.Location = new System.Drawing.Point(3, 106);
            this.lblLastDayWorking.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastDayWorking.Name = "lblLastDayWorking";
            this.lblLastDayWorking.Size = new System.Drawing.Size(187, 29);
            this.lblLastDayWorking.TabIndex = 125;
            this.lblLastDayWorking.Text = "Last Day at Incident*";
            this.lblLastDayWorking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDaysSinceLastDayOfRest
            // 
            this.lblDaysSinceLastDayOfRest.AutoSize = true;
            this.lblDaysSinceLastDayOfRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysSinceLastDayOfRest.Location = new System.Drawing.Point(462, 79);
            this.lblDaysSinceLastDayOfRest.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDaysSinceLastDayOfRest.Name = "lblDaysSinceLastDayOfRest";
            this.lblDaysSinceLastDayOfRest.Size = new System.Drawing.Size(50, 17);
            this.lblDaysSinceLastDayOfRest.TabIndex = 132;
            this.lblDaysSinceLastDayOfRest.Text = "5 days";
            this.lblDaysSinceLastDayOfRest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datLastDayOfRest
            // 
            this.datLastDayOfRest.CustomFormat = "yyyy-MMMM-dd";
            this.datLastDayOfRest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLastDayOfRest.Location = new System.Drawing.Point(199, 3);
            this.datLastDayOfRest.Name = "datLastDayOfRest";
            this.datLastDayOfRest.Size = new System.Drawing.Size(254, 29);
            this.datLastDayOfRest.TabIndex = 3;
            this.datLastDayOfRest.ValueChanged += new System.EventHandler(this.datLastDayOfRest_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 131;
            this.label2.Text = "Last Day of Rest*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboICSRole
            // 
            this.cboICSRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboICSRole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboICSRole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboICSRole.DisplayMember = "RoleName";
            this.cboICSRole.FormattingEnabled = true;
            this.cboICSRole.Location = new System.Drawing.Point(202, 3);
            this.cboICSRole.Name = "cboICSRole";
            this.cboICSRole.Size = new System.Drawing.Size(362, 32);
            this.cboICSRole.TabIndex = 2;
            this.cboICSRole.ValueMember = "GenericRoleID";
            this.cboICSRole.SelectedIndexChanged += new System.EventHandler(this.cboICSRole_SelectedIndexChanged);
            this.cboICSRole.Leave += new System.EventHandler(this.cboICSRole_Leave);
            // 
            // label17
            // 
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(14, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(179, 24);
            this.label17.TabIndex = 134;
            this.label17.Text = "Incident Role";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAutoAssign
            // 
            this.chkAutoAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoAssign.AutoSize = true;
            this.chkAutoAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoAssign.Location = new System.Drawing.Point(572, 8);
            this.chkAutoAssign.Name = "chkAutoAssign";
            this.chkAutoAssign.Size = new System.Drawing.Size(150, 24);
            this.chkAutoAssign.TabIndex = 135;
            this.chkAutoAssign.Text = "Assign if possible";
            this.chkAutoAssign.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 136;
            this.label1.Text = "Unique ID*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboUniqueIDLetter
            // 
            this.cboUniqueIDLetter.Enabled = false;
            this.cboUniqueIDLetter.FormattingEnabled = true;
            this.cboUniqueIDLetter.Items.AddRange(new object[] {
            "P",
            "V",
            "C",
            "E",
            "A"});
            this.cboUniqueIDLetter.Location = new System.Drawing.Point(202, 44);
            this.cboUniqueIDLetter.Name = "cboUniqueIDLetter";
            this.cboUniqueIDLetter.Size = new System.Drawing.Size(59, 32);
            this.cboUniqueIDLetter.TabIndex = 137;
            // 
            // numUniqueIDNumber
            // 
            this.numUniqueIDNumber.Location = new System.Drawing.Point(267, 47);
            this.numUniqueIDNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUniqueIDNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUniqueIDNumber.Name = "numUniqueIDNumber";
            this.numUniqueIDNumber.Size = new System.Drawing.Size(120, 29);
            this.numUniqueIDNumber.TabIndex = 1;
            this.numUniqueIDNumber.ThousandsSeparator = true;
            this.numUniqueIDNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUniqueIDNumber.ValueChanged += new System.EventHandler(this.numUniqueIDNumber_ValueChanged);
            // 
            // btnGetNextID
            // 
            this.btnGetNextID.Location = new System.Drawing.Point(393, 46);
            this.btnGetNextID.Name = "btnGetNextID";
            this.btnGetNextID.Size = new System.Drawing.Size(75, 32);
            this.btnGetNextID.TabIndex = 139;
            this.btnGetNextID.Text = "Get";
            this.btnGetNextID.UseVisualStyleBackColor = true;
            this.btnGetNextID.Click += new System.EventHandler(this.btnGetNextID_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlPersonnelDetails
            // 
            this.pnlPersonnelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPersonnelDetails.Controls.Add(this.datFirstDayOnIncident);
            this.pnlPersonnelDetails.Controls.Add(this.label7);
            this.pnlPersonnelDetails.Controls.Add(this.datLastDayOfRest);
            this.pnlPersonnelDetails.Controls.Add(this.lblLastDayWorking);
            this.pnlPersonnelDetails.Controls.Add(this.lblDaysSinceLastDayOfRest);
            this.pnlPersonnelDetails.Controls.Add(this.label4);
            this.pnlPersonnelDetails.Controls.Add(this.datLDW);
            this.pnlPersonnelDetails.Controls.Add(this.label2);
            this.pnlPersonnelDetails.Controls.Add(this.datCheckInTime);
            this.pnlPersonnelDetails.Controls.Add(this.lblLastDayCount);
            this.pnlPersonnelDetails.Location = new System.Drawing.Point(3, 158);
            this.pnlPersonnelDetails.Name = "pnlPersonnelDetails";
            this.pnlPersonnelDetails.Size = new System.Drawing.Size(725, 138);
            this.pnlPersonnelDetails.TabIndex = 140;
            // 
            // datFirstDayOnIncident
            // 
            this.datFirstDayOnIncident.CustomFormat = "yyyy-MMMM-dd";
            this.datFirstDayOnIncident.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFirstDayOnIncident.Location = new System.Drawing.Point(199, 38);
            this.datFirstDayOnIncident.Name = "datFirstDayOnIncident";
            this.datFirstDayOnIncident.Size = new System.Drawing.Size(254, 29);
            this.datFirstDayOnIncident.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 29);
            this.label7.TabIndex = 134;
            this.label7.Text = "First day on incident";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlOtherResourceDetails
            // 
            this.pnlOtherResourceDetails.Controls.Add(this.datFirstDayOnIncidentOtherResource);
            this.pnlOtherResourceDetails.Controls.Add(this.label8);
            this.pnlOtherResourceDetails.Controls.Add(this.label6);
            this.pnlOtherResourceDetails.Controls.Add(this.datLDWOtherResource);
            this.pnlOtherResourceDetails.Controls.Add(this.label5);
            this.pnlOtherResourceDetails.Controls.Add(this.datCheckInTimeOtherResource);
            this.pnlOtherResourceDetails.Location = new System.Drawing.Point(0, 302);
            this.pnlOtherResourceDetails.Name = "pnlOtherResourceDetails";
            this.pnlOtherResourceDetails.Size = new System.Drawing.Size(719, 107);
            this.pnlOtherResourceDetails.TabIndex = 141;
            // 
            // datFirstDayOnIncidentOtherResource
            // 
            this.datFirstDayOnIncidentOtherResource.CustomFormat = "yyyy-MMMM-dd";
            this.datFirstDayOnIncidentOtherResource.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datFirstDayOnIncidentOtherResource.Location = new System.Drawing.Point(202, 3);
            this.datFirstDayOnIncidentOtherResource.Name = "datFirstDayOnIncidentOtherResource";
            this.datFirstDayOnIncidentOtherResource.Size = new System.Drawing.Size(254, 29);
            this.datFirstDayOnIncidentOtherResource.TabIndex = 135;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 136;
            this.label8.Text = "First day on incident";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 74);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 29);
            this.label6.TabIndex = 128;
            this.label6.Text = "Last Day at Incident";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datLDWOtherResource
            // 
            this.datLDWOtherResource.Checked = false;
            this.datLDWOtherResource.CustomFormat = "yyyy-MMMM-dd";
            this.datLDWOtherResource.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLDWOtherResource.Location = new System.Drawing.Point(202, 73);
            this.datLDWOtherResource.Name = "datLDWOtherResource";
            this.datLDWOtherResource.ShowCheckBox = true;
            this.datLDWOtherResource.Size = new System.Drawing.Size(254, 29);
            this.datLDWOtherResource.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 29);
            this.label5.TabIndex = 126;
            this.label5.Text = "Check-In at Incident*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datCheckInTimeOtherResource
            // 
            this.datCheckInTimeOtherResource.CustomFormat = "yyyy-MMMM-dd";
            this.datCheckInTimeOtherResource.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInTimeOtherResource.Location = new System.Drawing.Point(202, 38);
            this.datCheckInTimeOtherResource.Name = "datCheckInTimeOtherResource";
            this.datCheckInTimeOtherResource.Size = new System.Drawing.Size(254, 29);
            this.datCheckInTimeOtherResource.TabIndex = 7;
            // 
            // pnlRoleOnTask
            // 
            this.pnlRoleOnTask.Controls.Add(this.cboICSRole);
            this.pnlRoleOnTask.Controls.Add(this.label17);
            this.pnlRoleOnTask.Controls.Add(this.chkAutoAssign);
            this.pnlRoleOnTask.Location = new System.Drawing.Point(0, 84);
            this.pnlRoleOnTask.Name = "pnlRoleOnTask";
            this.pnlRoleOnTask.Size = new System.Drawing.Size(722, 40);
            this.pnlRoleOnTask.TabIndex = 142;
            // 
            // ResourceCheckInEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRoleOnTask);
            this.Controls.Add(this.pnlOtherResourceDetails);
            this.Controls.Add(this.pnlPersonnelDetails);
            this.Controls.Add(this.btnGetNextID);
            this.Controls.Add(this.numUniqueIDNumber);
            this.Controls.Add(this.cboUniqueIDLetter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblScrollHint);
            this.Controls.Add(this.pnlCheckInFields);
            this.Controls.Add(this.txtResourceType);
            this.Controls.Add(this.txtSelectedName);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(716, 300);
            this.Name = "ResourceCheckInEditControl";
            this.Size = new System.Drawing.Size(725, 597);
            this.Load += new System.EventHandler(this.ResourceCheckInEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUniqueIDNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlPersonnelDetails.ResumeLayout(false);
            this.pnlPersonnelDetails.PerformLayout();
            this.pnlOtherResourceDetails.ResumeLayout(false);
            this.pnlRoleOnTask.ResumeLayout(false);
            this.pnlRoleOnTask.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastDayCount;
        private System.Windows.Forms.Label lblScrollHint;
        private System.Windows.Forms.Panel pnlCheckInFields;
        private System.Windows.Forms.TextBox txtResourceType;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datCheckInTime;
        private System.Windows.Forms.DateTimePicker datLDW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastDayWorking;
        private System.Windows.Forms.Label lblDaysSinceLastDayOfRest;
        private System.Windows.Forms.DateTimePicker datLastDayOfRest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboICSRole;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkAutoAssign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUniqueIDLetter;
        private System.Windows.Forms.NumericUpDown numUniqueIDNumber;
        private System.Windows.Forms.Button btnGetNextID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlPersonnelDetails;
        private System.Windows.Forms.Panel pnlOtherResourceDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datCheckInTimeOtherResource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datLDWOtherResource;
        private System.Windows.Forms.Panel pnlRoleOnTask;
        private System.Windows.Forms.DateTimePicker datFirstDayOnIncident;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker datFirstDayOnIncidentOtherResource;
        private System.Windows.Forms.Label label8;
    }
}
