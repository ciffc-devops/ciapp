namespace Wildfire_ICS_Assist
{
    partial class PersonnelSignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelSignInForm));
            this.pnlSavedPersonnel = new System.Windows.Forms.Panel();
            this.btnSelectSaved = new System.Windows.Forms.Button();
            this.cboSavedPersonnel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlNewPersonnel = new System.Windows.Forms.Panel();
            this.btnSelectNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.editTeamMemberControl1 = new Wildfire_ICS_Assist.CustomControls.EditTeamMemberControl();
            this.pnlCheckInInfo = new System.Windows.Forms.Panel();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.cboMethodOfTravel = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLastDayWorking = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeparturePoint = new System.Windows.Forms.TextBox();
            this.datLDW = new System.Windows.Forms.DateTimePicker();
            this.datCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlSavedPersonnel.SuspendLayout();
            this.pnlNewPersonnel.SuspendLayout();
            this.pnlCheckInInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSavedPersonnel
            // 
            this.pnlSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedPersonnel.BackColor = System.Drawing.Color.White;
            this.pnlSavedPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedPersonnel.Controls.Add(this.btnSelectSaved);
            this.pnlSavedPersonnel.Controls.Add(this.cboSavedPersonnel);
            this.pnlSavedPersonnel.Controls.Add(this.label6);
            this.pnlSavedPersonnel.Location = new System.Drawing.Point(51, 12);
            this.pnlSavedPersonnel.Name = "pnlSavedPersonnel";
            this.pnlSavedPersonnel.Size = new System.Drawing.Size(547, 80);
            this.pnlSavedPersonnel.TabIndex = 1;
            // 
            // btnSelectSaved
            // 
            this.btnSelectSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectSaved.Location = new System.Drawing.Point(406, 27);
            this.btnSelectSaved.Name = "btnSelectSaved";
            this.btnSelectSaved.Size = new System.Drawing.Size(130, 40);
            this.btnSelectSaved.TabIndex = 10;
            this.btnSelectSaved.Text = "Select";
            this.btnSelectSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectSaved.UseVisualStyleBackColor = true;
            this.btnSelectSaved.Click += new System.EventHandler(this.btnSelectSaved_Click);
            // 
            // cboSavedPersonnel
            // 
            this.cboSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedPersonnel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedPersonnel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedPersonnel.DisplayMember = "NameWithAgency";
            this.cboSavedPersonnel.FormattingEnabled = true;
            this.cboSavedPersonnel.Location = new System.Drawing.Point(8, 32);
            this.cboSavedPersonnel.Name = "cboSavedPersonnel";
            this.cboSavedPersonnel.Size = new System.Drawing.Size(392, 32);
            this.cboSavedPersonnel.TabIndex = 9;
            this.cboSavedPersonnel.ValueMember = "PersonID";
            this.cboSavedPersonnel.Leave += new System.EventHandler(this.cboSavedPersonnel_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(539, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Saved Personnel";
            // 
            // pnlNewPersonnel
            // 
            this.pnlNewPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNewPersonnel.BackColor = System.Drawing.Color.White;
            this.pnlNewPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewPersonnel.Controls.Add(this.btnSelectNew);
            this.pnlNewPersonnel.Controls.Add(this.label1);
            this.pnlNewPersonnel.Controls.Add(this.editTeamMemberControl1);
            this.pnlNewPersonnel.Location = new System.Drawing.Point(51, 98);
            this.pnlNewPersonnel.Name = "pnlNewPersonnel";
            this.pnlNewPersonnel.Size = new System.Drawing.Size(547, 448);
            this.pnlNewPersonnel.TabIndex = 2;
            // 
            // btnSelectNew
            // 
            this.btnSelectNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectNew.Location = new System.Drawing.Point(412, 403);
            this.btnSelectNew.Name = "btnSelectNew";
            this.btnSelectNew.Size = new System.Drawing.Size(130, 40);
            this.btnSelectNew.TabIndex = 11;
            this.btnSelectNew.Text = "Select";
            this.btnSelectNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectNew.UseVisualStyleBackColor = true;
            this.btnSelectNew.Click += new System.EventHandler(this.btnSelectNew_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Personnel";
            // 
            // editTeamMemberControl1
            // 
            this.editTeamMemberControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editTeamMemberControl1.BackColor = System.Drawing.Color.Transparent;
            this.editTeamMemberControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTeamMemberControl1.Location = new System.Drawing.Point(6, 35);
            this.editTeamMemberControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editTeamMemberControl1.Name = "editTeamMemberControl1";
            this.editTeamMemberControl1.Size = new System.Drawing.Size(536, 364);
            this.editTeamMemberControl1.TabIndex = 0;
            this.editTeamMemberControl1.teamMember = ((WF_ICS_ClassLibrary.Models.TeamMember)(resources.GetObject("editTeamMemberControl1.teamMember")));
            // 
            // pnlCheckInInfo
            // 
            this.pnlCheckInInfo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlCheckInInfo.BackColor = System.Drawing.Color.White;
            this.pnlCheckInInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckInInfo.Controls.Add(this.btnCheckIn);
            this.pnlCheckInInfo.Controls.Add(this.cboMethodOfTravel);
            this.pnlCheckInInfo.Controls.Add(this.label8);
            this.pnlCheckInInfo.Controls.Add(this.label7);
            this.pnlCheckInInfo.Controls.Add(this.lblLastDayWorking);
            this.pnlCheckInInfo.Controls.Add(this.label4);
            this.pnlCheckInInfo.Controls.Add(this.txtDeparturePoint);
            this.pnlCheckInInfo.Controls.Add(this.datLDW);
            this.pnlCheckInInfo.Controls.Add(this.datCheckInTime);
            this.pnlCheckInInfo.Controls.Add(this.label3);
            this.pnlCheckInInfo.Controls.Add(this.txtSelectedName);
            this.pnlCheckInInfo.Controls.Add(this.pictureBox1);
            this.pnlCheckInInfo.Controls.Add(this.label2);
            this.pnlCheckInInfo.Enabled = false;
            this.pnlCheckInInfo.Location = new System.Drawing.Point(662, 140);
            this.pnlCheckInInfo.Name = "pnlCheckInInfo";
            this.pnlCheckInInfo.Size = new System.Drawing.Size(433, 296);
            this.pnlCheckInInfo.TabIndex = 3;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckIn.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckIn.Location = new System.Drawing.Point(266, 221);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(159, 59);
            this.btnCheckIn.TabIndex = 23;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // cboMethodOfTravel
            // 
            this.cboMethodOfTravel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMethodOfTravel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMethodOfTravel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMethodOfTravel.FormattingEnabled = true;
            this.cboMethodOfTravel.Items.AddRange(new object[] {
            "Fixed Wing",
            "Rotary Wing",
            "Bus / Shuttle",
            "Personal Vehicle"});
            this.cboMethodOfTravel.Location = new System.Drawing.Point(200, 183);
            this.cboMethodOfTravel.Name = "cboMethodOfTravel";
            this.cboMethodOfTravel.Size = new System.Drawing.Size(225, 32);
            this.cboMethodOfTravel.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 186);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 22;
            this.label8.Text = "Method of Travel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-1, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 29);
            this.label7.TabIndex = 21;
            this.label7.Text = "Departure Point";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastDayWorking
            // 
            this.lblLastDayWorking.Location = new System.Drawing.Point(6, 115);
            this.lblLastDayWorking.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastDayWorking.Name = "lblLastDayWorking";
            this.lblLastDayWorking.Size = new System.Drawing.Size(187, 29);
            this.lblLastDayWorking.TabIndex = 20;
            this.lblLastDayWorking.Text = "Last Day Working*";
            this.lblLastDayWorking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 19;
            this.label4.Text = "Check-In Date/Time";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeparturePoint
            // 
            this.txtDeparturePoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeparturePoint.Location = new System.Drawing.Point(200, 150);
            this.txtDeparturePoint.Name = "txtDeparturePoint";
            this.txtDeparturePoint.Size = new System.Drawing.Size(225, 29);
            this.txtDeparturePoint.TabIndex = 17;
            // 
            // datLDW
            // 
            this.datLDW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datLDW.CustomFormat = "yyyy-MMM-dd";
            this.datLDW.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLDW.Location = new System.Drawing.Point(200, 115);
            this.datLDW.Name = "datLDW";
            this.datLDW.Size = new System.Drawing.Size(225, 29);
            this.datLDW.TabIndex = 16;
            this.datLDW.ValueChanged += new System.EventHandler(this.datLDW_ValueChanged);
            // 
            // datCheckInTime
            // 
            this.datCheckInTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datCheckInTime.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInTime.Location = new System.Drawing.Point(200, 80);
            this.datCheckInTime.Name = "datCheckInTime";
            this.datCheckInTime.Size = new System.Drawing.Size(225, 29);
            this.datCheckInTime.TabIndex = 15;
            this.datCheckInTime.ValueChanged += new System.EventHandler(this.datCheckInTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSelectedName
            // 
            this.txtSelectedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedName.Enabled = false;
            this.txtSelectedName.Location = new System.Drawing.Point(200, 42);
            this.txtSelectedName.Margin = new System.Windows.Forms.Padding(6);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.Size = new System.Drawing.Size(225, 29);
            this.txtSelectedName.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_55_clock;
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Check-In Information";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(607, 142);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 39);
            this.label15.TabIndex = 147;
            this.label15.Text = "2)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(-4, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 39);
            this.label14.TabIndex = 146;
            this.label14.Text = "1)";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(9, 556);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 148;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PersonnelSignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 612);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.pnlCheckInInfo);
            this.Controls.Add(this.pnlNewPersonnel);
            this.Controls.Add(this.pnlSavedPersonnel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1069, 589);
            this.Name = "PersonnelSignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check In Form";
            this.Load += new System.EventHandler(this.PersonnelSignInForm_Load);
            this.pnlSavedPersonnel.ResumeLayout(false);
            this.pnlNewPersonnel.ResumeLayout(false);
            this.pnlCheckInInfo.ResumeLayout(false);
            this.pnlCheckInInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.EditTeamMemberControl editTeamMemberControl1;
        private System.Windows.Forms.Panel pnlSavedPersonnel;
        private System.Windows.Forms.Panel pnlNewPersonnel;
        private System.Windows.Forms.Panel pnlCheckInInfo;
        private System.Windows.Forms.ComboBox cboSavedPersonnel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSaved;
        private System.Windows.Forms.Button btnSelectNew;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.ComboBox cboMethodOfTravel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLastDayWorking;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeparturePoint;
        private System.Windows.Forms.DateTimePicker datLDW;
        private System.Windows.Forms.DateTimePicker datCheckInTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
    }
}