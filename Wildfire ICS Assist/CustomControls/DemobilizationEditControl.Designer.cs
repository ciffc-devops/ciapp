namespace Wildfire_ICS_Assist.CustomControls
{
    partial class DemobilizationEditControl
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
            this.datCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.datLastDayOfRest = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTaskNumber = new System.Windows.Forms.Label();
            this.cboDemobLocation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDebriefLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.datDebriefDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkInventory = new System.Windows.Forms.CheckBox();
            this.chkWithSupply = new System.Windows.Forms.CheckBox();
            this.chkWithFacilities = new System.Windows.Forms.CheckBox();
            this.chkWithFinance = new System.Windows.Forms.CheckBox();
            this.chk211 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTravelTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkPerformanceRating = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datCheckInDate
            // 
            this.datCheckInDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datCheckInDate.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckInDate.Enabled = false;
            this.datCheckInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInDate.Location = new System.Drawing.Point(248, 79);
            this.datCheckInDate.Name = "datCheckInDate";
            this.datCheckInDate.Size = new System.Drawing.Size(195, 29);
            this.datCheckInDate.TabIndex = 132;
            this.datCheckInDate.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 29);
            this.label2.TabIndex = 136;
            this.label2.Text = "Check In Date / Time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSelectedName
            // 
            this.txtSelectedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedName.Location = new System.Drawing.Point(197, 6);
            this.txtSelectedName.Margin = new System.Windows.Forms.Padding(6);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.ReadOnly = true;
            this.txtSelectedName.Size = new System.Drawing.Size(246, 29);
            this.txtSelectedName.TabIndex = 133;
            this.txtSelectedName.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 29);
            this.label3.TabIndex = 134;
            this.label3.Text = "Resource";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datCheckOutDate
            // 
            this.datCheckOutDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datCheckOutDate.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckOutDate.Location = new System.Drawing.Point(248, 114);
            this.datCheckOutDate.Name = "datCheckOutDate";
            this.datCheckOutDate.Size = new System.Drawing.Size(195, 29);
            this.datCheckOutDate.TabIndex = 1;
            this.datCheckOutDate.ValueChanged += new System.EventHandler(this.datCheckOutDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 29);
            this.label1.TabIndex = 138;
            this.label1.Text = "Check Out Date / Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datLastDayOfRest
            // 
            this.datLastDayOfRest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datLastDayOfRest.CustomFormat = "yyyy-MMM-dd";
            this.datLastDayOfRest.Enabled = false;
            this.datLastDayOfRest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLastDayOfRest.Location = new System.Drawing.Point(248, 44);
            this.datLastDayOfRest.Name = "datLastDayOfRest";
            this.datLastDayOfRest.Size = new System.Drawing.Size(195, 29);
            this.datLastDayOfRest.TabIndex = 139;
            this.datLastDayOfRest.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(54, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 140;
            this.label4.Text = "Last Day of Rest";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTaskNumber
            // 
            this.lblTaskNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTaskNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTaskNumber.Location = new System.Drawing.Point(86, 151);
            this.lblTaskNumber.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.lblTaskNumber.Name = "lblTaskNumber";
            this.lblTaskNumber.Size = new System.Drawing.Size(150, 24);
            this.lblTaskNumber.TabIndex = 142;
            this.lblTaskNumber.Text = "Demob Location";
            this.lblTaskNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDemobLocation
            // 
            this.cboDemobLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDemobLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDemobLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDemobLocation.FormattingEnabled = true;
            this.cboDemobLocation.Items.AddRange(new object[] {
            "ICP",
            "Base",
            "Camp",
            "Staging",
            "Heli-Base"});
            this.cboDemobLocation.Location = new System.Drawing.Point(248, 149);
            this.cboDemobLocation.Name = "cboDemobLocation";
            this.cboDemobLocation.Size = new System.Drawing.Size(195, 32);
            this.cboDemobLocation.TabIndex = 2;
            this.cboDemobLocation.SelectedIndexChanged += new System.EventHandler(this.cboDemobLocation_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(22, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(421, 31);
            this.label5.TabIndex = 144;
            this.label5.Text = "Debrief";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboDebriefLocation
            // 
            this.cboDebriefLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDebriefLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDebriefLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDebriefLocation.FormattingEnabled = true;
            this.cboDebriefLocation.Items.AddRange(new object[] {
            "ICP",
            "Base",
            "Camp",
            "Staging",
            "Heli-Base"});
            this.cboDebriefLocation.Location = new System.Drawing.Point(248, 305);
            this.cboDebriefLocation.Name = "cboDebriefLocation";
            this.cboDebriefLocation.Size = new System.Drawing.Size(195, 32);
            this.cboDebriefLocation.TabIndex = 5;
            this.cboDebriefLocation.SelectedIndexChanged += new System.EventHandler(this.cboDebriefLocation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(86, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 24);
            this.label6.TabIndex = 147;
            this.label6.Text = "Location";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datDebriefDate
            // 
            this.datDebriefDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datDebriefDate.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datDebriefDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datDebriefDate.Location = new System.Drawing.Point(248, 270);
            this.datDebriefDate.Name = "datDebriefDate";
            this.datDebriefDate.Size = new System.Drawing.Size(195, 29);
            this.datDebriefDate.TabIndex = 4;
            this.datDebriefDate.ValueChanged += new System.EventHandler(this.datDebriefDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 270);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 29);
            this.label7.TabIndex = 146;
            this.label7.Text = "Date / Time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(7, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(360, 31);
            this.label8.TabIndex = 149;
            this.label8.Text = "Reconciliation";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkInventory
            // 
            this.chkInventory.AutoSize = true;
            this.chkInventory.Location = new System.Drawing.Point(309, 41);
            this.chkInventory.Name = "chkInventory";
            this.chkInventory.Size = new System.Drawing.Size(61, 28);
            this.chkInventory.TabIndex = 6;
            this.chkInventory.Text = "Yes";
            this.chkInventory.UseVisualStyleBackColor = true;
            this.chkInventory.CheckedChanged += new System.EventHandler(this.chkInventory_CheckedChanged);
            // 
            // chkWithSupply
            // 
            this.chkWithSupply.AutoSize = true;
            this.chkWithSupply.Location = new System.Drawing.Point(309, 75);
            this.chkWithSupply.Name = "chkWithSupply";
            this.chkWithSupply.Size = new System.Drawing.Size(61, 28);
            this.chkWithSupply.TabIndex = 7;
            this.chkWithSupply.Text = "Yes";
            this.chkWithSupply.UseVisualStyleBackColor = true;
            this.chkWithSupply.CheckedChanged += new System.EventHandler(this.chkWithSupply_CheckedChanged);
            // 
            // chkWithFacilities
            // 
            this.chkWithFacilities.AutoSize = true;
            this.chkWithFacilities.Location = new System.Drawing.Point(309, 109);
            this.chkWithFacilities.Name = "chkWithFacilities";
            this.chkWithFacilities.Size = new System.Drawing.Size(61, 28);
            this.chkWithFacilities.TabIndex = 8;
            this.chkWithFacilities.Text = "Yes";
            this.chkWithFacilities.UseVisualStyleBackColor = true;
            this.chkWithFacilities.CheckedChanged += new System.EventHandler(this.chkWithFacilities_CheckedChanged);
            // 
            // chkWithFinance
            // 
            this.chkWithFinance.AutoSize = true;
            this.chkWithFinance.Location = new System.Drawing.Point(309, 143);
            this.chkWithFinance.Name = "chkWithFinance";
            this.chkWithFinance.Size = new System.Drawing.Size(61, 28);
            this.chkWithFinance.TabIndex = 9;
            this.chkWithFinance.Text = "Yes";
            this.chkWithFinance.UseVisualStyleBackColor = true;
            this.chkWithFinance.CheckedChanged += new System.EventHandler(this.chkWithFinance_CheckedChanged);
            // 
            // chk211
            // 
            this.chk211.AutoSize = true;
            this.chk211.Location = new System.Drawing.Point(309, 177);
            this.chk211.Name = "chk211";
            this.chk211.Size = new System.Drawing.Size(61, 28);
            this.chk211.TabIndex = 10;
            this.chk211.Text = "Yes";
            this.chk211.UseVisualStyleBackColor = true;
            this.chk211.CheckedChanged += new System.EventHandler(this.chk211_CheckedChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(64, 41);
            this.label9.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 24);
            this.label9.TabIndex = 155;
            this.label9.Text = "Inventory Reconciled";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(64, 75);
            this.label10.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 24);
            this.label10.TabIndex = 156;
            this.label10.Text = "Discrepancies with Supply";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(64, 109);
            this.label11.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 24);
            this.label11.TabIndex = 157;
            this.label11.Text = "Discrepencies w/ Facilities";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(64, 142);
            this.label12.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 24);
            this.label12.TabIndex = 158;
            this.label12.Text = "Discrepancies w/ Finance";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(64, 177);
            this.label13.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(233, 24);
            this.label13.TabIndex = 159;
            this.label13.Text = "ICS 211 Completed";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(11, 187);
            this.label14.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(225, 24);
            this.label14.TabIndex = 160;
            this.label14.Text = "Travel Time to Home Unit";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTravelTime
            // 
            this.txtTravelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTravelTime.Location = new System.Drawing.Point(248, 187);
            this.txtTravelTime.Name = "txtTravelTime";
            this.txtTravelTime.Size = new System.Drawing.Size(195, 29);
            this.txtTravelTime.TabIndex = 3;
            this.txtTravelTime.TextChanged += new System.EventHandler(this.txtTravelTime_TextChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(9, 211);
            this.label15.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(288, 24);
            this.label15.TabIndex = 162;
            this.label15.Text = "Performance Rating Completed";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPerformanceRating
            // 
            this.chkPerformanceRating.AutoSize = true;
            this.chkPerformanceRating.Location = new System.Drawing.Point(309, 211);
            this.chkPerformanceRating.Name = "chkPerformanceRating";
            this.chkPerformanceRating.Size = new System.Drawing.Size(61, 28);
            this.chkPerformanceRating.TabIndex = 161;
            this.chkPerformanceRating.Text = "Yes";
            this.chkPerformanceRating.UseVisualStyleBackColor = true;
            this.chkPerformanceRating.CheckedChanged += new System.EventHandler(this.chkPerformanceRating_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSelectedName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTravelTime);
            this.panel1.Controls.Add(this.datCheckInDate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.datCheckOutDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.datLastDayOfRest);
            this.panel1.Controls.Add(this.lblTaskNumber);
            this.panel1.Controls.Add(this.cboDemobLocation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.datDebriefDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboDebriefLocation);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 344);
            this.panel1.TabIndex = 163;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chkInventory);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.chkWithSupply);
            this.panel2.Controls.Add(this.chkPerformanceRating);
            this.panel2.Controls.Add(this.chkWithFacilities);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.chkWithFinance);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.chk211);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(486, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 250);
            this.panel2.TabIndex = 164;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(875, 371);
            this.flowLayoutPanel1.TabIndex = 165;
            // 
            // DemobilizationEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DemobilizationEditControl";
            this.Size = new System.Drawing.Size(875, 371);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datCheckInDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datCheckOutDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datLastDayOfRest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTaskNumber;
        private System.Windows.Forms.ComboBox cboDemobLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDebriefLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datDebriefDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkInventory;
        private System.Windows.Forms.CheckBox chkWithSupply;
        private System.Windows.Forms.CheckBox chkWithFacilities;
        private System.Windows.Forms.CheckBox chkWithFinance;
        private System.Windows.Forms.CheckBox chk211;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTravelTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkPerformanceRating;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
