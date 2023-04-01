namespace Wildfire_ICS_Assist.OptionsForms
{
    partial class EditHosptalForm
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
            this.lblCoordinateStatus = new System.Windows.Forms.Label();
            this.grpTravelTime = new System.Windows.Forms.GroupBox();
            this.numTravelGround = new System.Windows.Forms.NumericUpDown();
            this.numTravelAir = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.chkHelipad = new System.Windows.Forms.CheckBox();
            this.chkBurnUnit = new System.Windows.Forms.CheckBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTravelTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelAir)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblCoordinateStatus);
            this.splitContainer1.Panel1.Controls.Add(this.grpTravelTime);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtHospitalName);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddress);
            this.splitContainer1.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel1.Controls.Add(this.chkHelipad);
            this.splitContainer1.Panel1.Controls.Add(this.chkBurnUnit);
            this.splitContainer1.Panel1.Controls.Add(this.txtLatitude);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(495, 462);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblCoordinateStatus
            // 
            this.lblCoordinateStatus.AutoSize = true;
            this.lblCoordinateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinateStatus.Location = new System.Drawing.Point(168, 213);
            this.lblCoordinateStatus.Name = "lblCoordinateStatus";
            this.lblCoordinateStatus.Size = new System.Drawing.Size(101, 15);
            this.lblCoordinateStatus.TabIndex = 14;
            this.lblCoordinateStatus.Text = "Coordinates okay";
            // 
            // grpTravelTime
            // 
            this.grpTravelTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpTravelTime.Controls.Add(this.numTravelGround);
            this.grpTravelTime.Controls.Add(this.numTravelAir);
            this.grpTravelTime.Controls.Add(this.label8);
            this.grpTravelTime.Controls.Add(this.label7);
            this.grpTravelTime.Location = new System.Drawing.Point(72, 271);
            this.grpTravelTime.Name = "grpTravelTime";
            this.grpTravelTime.Size = new System.Drawing.Size(347, 86);
            this.grpTravelTime.TabIndex = 1;
            this.grpTravelTime.TabStop = false;
            this.grpTravelTime.Text = "Travel Time (Minutes)";
            // 
            // numTravelGround
            // 
            this.numTravelGround.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTravelGround.Location = new System.Drawing.Point(252, 38);
            this.numTravelGround.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTravelGround.Name = "numTravelGround";
            this.numTravelGround.Size = new System.Drawing.Size(84, 29);
            this.numTravelGround.TabIndex = 3;
            this.numTravelGround.ValueChanged += new System.EventHandler(this.numTravelGround_ValueChanged);
            // 
            // numTravelAir
            // 
            this.numTravelAir.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numTravelAir.Location = new System.Drawing.Point(66, 38);
            this.numTravelAir.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTravelAir.Name = "numTravelAir";
            this.numTravelAir.Size = new System.Drawing.Size(84, 29);
            this.numTravelAir.TabIndex = 2;
            this.numTravelAir.ValueChanged += new System.EventHandler(this.numTravelAir_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ground";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Air";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 53);
            this.label5.TabIndex = 12;
            this.label5.Text = "Coordinates (Lat/Lng, UTM)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "Capabilities";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Contact # or Frq.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hospital Name*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHospitalName.Location = new System.Drawing.Point(171, 8);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(306, 29);
            this.txtHospitalName.TabIndex = 1;
            this.txtHospitalName.TextChanged += new System.EventHandler(this.txtHospitalName_TextChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(171, 43);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(306, 29);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(171, 78);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(306, 29);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // chkHelipad
            // 
            this.chkHelipad.AutoSize = true;
            this.chkHelipad.Location = new System.Drawing.Point(171, 113);
            this.chkHelipad.Name = "chkHelipad";
            this.chkHelipad.Size = new System.Drawing.Size(94, 28);
            this.chkHelipad.TabIndex = 4;
            this.chkHelipad.Text = "Helipad";
            this.chkHelipad.UseVisualStyleBackColor = true;
            this.chkHelipad.CheckedChanged += new System.EventHandler(this.chkHelipad_CheckedChanged);
            // 
            // chkBurnUnit
            // 
            this.chkBurnUnit.AutoSize = true;
            this.chkBurnUnit.Location = new System.Drawing.Point(171, 147);
            this.chkBurnUnit.Name = "chkBurnUnit";
            this.chkBurnUnit.Size = new System.Drawing.Size(106, 28);
            this.chkBurnUnit.TabIndex = 5;
            this.chkBurnUnit.Text = "Burn Unit";
            this.chkBurnUnit.UseVisualStyleBackColor = true;
            this.chkBurnUnit.CheckedChanged += new System.EventHandler(this.chkBurnUnit_CheckedChanged);
            // 
            // txtLatitude
            // 
            this.txtLatitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLatitude.Location = new System.Drawing.Point(171, 181);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(306, 29);
            this.txtLatitude.TabIndex = 6;
            this.txtLatitude.Leave += new System.EventHandler(this.txtLatitude_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(358, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(12, 13);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 51);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EditHosptalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(495, 462);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 478);
            this.Name = "EditHosptalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Hospital";
            this.Load += new System.EventHandler(this.EditHosptalForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpTravelTime.ResumeLayout(false);
            this.grpTravelTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTravelAir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpTravelTime;
        private System.Windows.Forms.NumericUpDown numTravelGround;
        private System.Windows.Forms.NumericUpDown numTravelAir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkHelipad;
        private System.Windows.Forms.CheckBox chkBurnUnit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label lblCoordinateStatus;
    }
}