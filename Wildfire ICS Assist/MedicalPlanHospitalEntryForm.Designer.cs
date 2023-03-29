namespace Wildfire_ICS_Assist
{
    partial class MedicalPlanHospitalEntryForm
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
            this.pnlSavedHospital = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numSavedTravelGround = new System.Windows.Forms.NumericUpDown();
            this.numSavedTravelAir = new System.Windows.Forms.NumericUpDown();
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSaved = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.numTravelGround = new System.Windows.Forms.NumericUpDown();
            this.numTravelAir = new System.Windows.Forms.NumericUpDown();
            this.lblCoordinateStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkHelipad = new System.Windows.Forms.CheckBox();
            this.chkBurnUnit = new System.Windows.Forms.CheckBox();
            this.txtCoordinates = new System.Windows.Forms.TextBox();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSavedHospital.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSavedTravelGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSavedTravelAir)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelAir)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlSavedHospital);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(590, 630);
            this.splitContainer1.SplitterDistance = 133;
            this.splitContainer1.TabIndex = 1;
            // 
            // pnlSavedHospital
            // 
            this.pnlSavedHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedHospital.BackColor = System.Drawing.Color.White;
            this.pnlSavedHospital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedHospital.Controls.Add(this.label2);
            this.pnlSavedHospital.Controls.Add(this.numSavedTravelGround);
            this.pnlSavedHospital.Controls.Add(this.numSavedTravelAir);
            this.pnlSavedHospital.Controls.Add(this.btnAddSaved);
            this.pnlSavedHospital.Controls.Add(this.label8);
            this.pnlSavedHospital.Controls.Add(this.cboSaved);
            this.pnlSavedHospital.Controls.Add(this.label7);
            this.pnlSavedHospital.Controls.Add(this.label1);
            this.pnlSavedHospital.Location = new System.Drawing.Point(6, 7);
            this.pnlSavedHospital.Name = "pnlSavedHospital";
            this.pnlSavedHospital.Size = new System.Drawing.Size(572, 120);
            this.pnlSavedHospital.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Travel Time (Minutes)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numSavedTravelGround
            // 
            this.numSavedTravelGround.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSavedTravelGround.Location = new System.Drawing.Point(360, 74);
            this.numSavedTravelGround.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSavedTravelGround.Name = "numSavedTravelGround";
            this.numSavedTravelGround.Size = new System.Drawing.Size(72, 29);
            this.numSavedTravelGround.TabIndex = 3;
            // 
            // numSavedTravelAir
            // 
            this.numSavedTravelAir.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSavedTravelAir.Location = new System.Drawing.Point(202, 74);
            this.numSavedTravelAir.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSavedTravelAir.Name = "numSavedTravelAir";
            this.numSavedTravelAir.Size = new System.Drawing.Size(72, 29);
            this.numSavedTravelAir.TabIndex = 2;
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSaved.Location = new System.Drawing.Point(441, 26);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 80);
            this.btnAddSaved.TabIndex = 4;
            this.btnAddSaved.Text = "Add to Incident";
            this.btnAddSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSaved.UseVisualStyleBackColor = true;
            this.btnAddSaved.Click += new System.EventHandler(this.btnAddSaved_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ground";
            // 
            // cboSaved
            // 
            this.cboSaved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSaved.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSaved.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSaved.DisplayMember = "name";
            this.cboSaved.FormattingEnabled = true;
            this.cboSaved.Location = new System.Drawing.Point(8, 36);
            this.cboSaved.Name = "cboSaved";
            this.cboSaved.Size = new System.Drawing.Size(424, 32);
            this.cboSaved.TabIndex = 1;
            this.cboSaved.ValueMember = "HospitalID";
            this.cboSaved.Leave += new System.EventHandler(this.cboSaved_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Air";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Hospital";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 436);
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
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.numTravelGround);
            this.panel2.Controls.Add(this.numTravelAir);
            this.panel2.Controls.Add(this.lblCoordinateStatus);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtHospitalName);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.txtPhone);
            this.panel2.Controls.Add(this.chkHelipad);
            this.panel2.Controls.Add(this.chkBurnUnit);
            this.panel2.Controls.Add(this.txtCoordinates);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 424);
            this.panel2.TabIndex = 98;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(36, 292);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 26);
            this.label13.TabIndex = 10;
            this.label13.Text = "Travel Time (Minutes)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numTravelGround
            // 
            this.numTravelGround.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTravelGround.Location = new System.Drawing.Point(426, 288);
            this.numTravelGround.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTravelGround.Name = "numTravelGround";
            this.numTravelGround.Size = new System.Drawing.Size(84, 29);
            this.numTravelGround.TabIndex = 3;
            // 
            // numTravelAir
            // 
            this.numTravelAir.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTravelAir.Location = new System.Drawing.Point(240, 288);
            this.numTravelAir.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTravelAir.Name = "numTravelAir";
            this.numTravelAir.Size = new System.Drawing.Size(84, 29);
            this.numTravelAir.TabIndex = 2;
            // 
            // lblCoordinateStatus
            // 
            this.lblCoordinateStatus.AutoSize = true;
            this.lblCoordinateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinateStatus.Location = new System.Drawing.Point(201, 250);
            this.lblCoordinateStatus.Name = "lblCoordinateStatus";
            this.lblCoordinateStatus.Size = new System.Drawing.Size(101, 15);
            this.lblCoordinateStatus.TabIndex = 112;
            this.lblCoordinateStatus.Text = "Coordinates okay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ground";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Air";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(36, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 53);
            this.label5.TabIndex = 111;
            this.label5.Text = "Coordinates (Lat/Lng, UTM)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(36, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 26);
            this.label6.TabIndex = 110;
            this.label6.Text = "Capabilities";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(36, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 26);
            this.label9.TabIndex = 109;
            this.label9.Text = "Contact # or Frq.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(36, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 26);
            this.label11.TabIndex = 108;
            this.label11.Text = "Address";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(36, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 26);
            this.label12.TabIndex = 107;
            this.label12.Text = "Hospital Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHospitalName.Location = new System.Drawing.Point(204, 45);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(360, 29);
            this.txtHospitalName.TabIndex = 101;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(204, 80);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(360, 29);
            this.txtAddress.TabIndex = 102;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(204, 115);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(360, 29);
            this.txtPhone.TabIndex = 103;
            // 
            // chkHelipad
            // 
            this.chkHelipad.AutoSize = true;
            this.chkHelipad.Location = new System.Drawing.Point(204, 150);
            this.chkHelipad.Name = "chkHelipad";
            this.chkHelipad.Size = new System.Drawing.Size(94, 28);
            this.chkHelipad.TabIndex = 104;
            this.chkHelipad.Text = "Helipad";
            this.chkHelipad.UseVisualStyleBackColor = true;
            // 
            // chkBurnUnit
            // 
            this.chkBurnUnit.AutoSize = true;
            this.chkBurnUnit.Location = new System.Drawing.Point(204, 184);
            this.chkBurnUnit.Name = "chkBurnUnit";
            this.chkBurnUnit.Size = new System.Drawing.Size(106, 28);
            this.chkBurnUnit.TabIndex = 105;
            this.chkBurnUnit.Text = "Burn Unit";
            this.chkBurnUnit.UseVisualStyleBackColor = true;
            // 
            // txtCoordinates
            // 
            this.txtCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoordinates.Location = new System.Drawing.Point(204, 218);
            this.txtCoordinates.Name = "txtCoordinates";
            this.txtCoordinates.Size = new System.Drawing.Size(360, 29);
            this.txtCoordinates.TabIndex = 106;
            this.txtCoordinates.Leave += new System.EventHandler(this.txtLatitude_Leave);
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(122, 379);
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
            this.label10.Size = new System.Drawing.Size(169, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New Hospital";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.Location = new System.Drawing.Point(360, 368);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 13;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // MedicalPlanHospitalEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 630);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(606, 646);
            this.Name = "MedicalPlanHospitalEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a Hospital";
            this.Load += new System.EventHandler(this.MedicalPlanHospitalEntryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSavedHospital.ResumeLayout(false);
            this.pnlSavedHospital.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSavedTravelGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSavedTravelAir)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelAir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSavedHospital;
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSaved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.NumericUpDown numSavedTravelGround;
        private System.Windows.Forms.NumericUpDown numSavedTravelAir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numTravelGround;
        private System.Windows.Forms.NumericUpDown numTravelAir;
        private System.Windows.Forms.Label lblCoordinateStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkHelipad;
        private System.Windows.Forms.CheckBox chkBurnUnit;
        private System.Windows.Forms.TextBox txtCoordinates;
    }
}