namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditAircraftControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboIsHeli = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.numBurnRate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCompanyName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.txtRegistration = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.txtRemarks = new SpellBox();
            this.txtContactNumber = new SpellBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Registration*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kind (Model)*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Remarks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 180);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contact #";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboIsHeli
            // 
            this.cboIsHeli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIsHeli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsHeli.FormattingEnabled = true;
            this.cboIsHeli.Items.AddRange(new object[] {
            "Helicopter - All",
            "Helicopter - Light",
            "Helicopter - Intermediate",
            "Helicopter - Medium",
            "Helicopter - Heavy",
            "Fixed-Wing"});
            this.cboIsHeli.Location = new System.Drawing.Point(178, 96);
            this.cboIsHeli.Name = "cboIsHeli";
            this.cboIsHeli.Size = new System.Drawing.Size(302, 32);
            this.cboIsHeli.TabIndex = 3;
            this.cboIsHeli.SelectedIndexChanged += new System.EventHandler(this.cboIsHeli_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboModel
            // 
            this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Items.AddRange(new object[] {
            "EC20",
            "EC25",
            "EC30",
            "EC35",
            "EC45",
            "AH145",
            "EC55",
            "MBK7",
            "MBH5",
            "S313",
            "S315",
            "S316",
            "S318",
            "S319",
            "S330",
            "S332",
            "S342",
            "S350",
            "S355",
            "S360",
            "S365",
            "BH04",
            "BH06",
            "BH06T",
            "BH12",
            "BH214",
            "BHST",
            "BH22",
            "BH23",
            "BH41",
            "BH47",
            "BH47T",
            "BH407",
            "BH427",
            "B429",
            "BH430",
            "BH505",
            "HV07",
            "HV34",
            "BV44",
            "HB42",
            "HB43",
            "BR71",
            "BABY",
            "C1C",
            "DM52",
            "HELCY",
            "EH28",
            "EH48",
            "HGCG2",
            "HL11",
            "HL12",
            "HL2TS",
            "HL36",
            "HK12",
            "KA32",
            "A109",
            "AW109",
            "A119",
            "A139",
            "A169",
            "A189",
            "HU30",
            "HU50",
            "HU52",
            "HU60",
            "EXPL",
            "MOZY",
            "M500",
            "RH22",
            "RH44",
            "R66",
            "ROTO",
            "ROTOT",
            "HU33",
            "SK51",
            "SK55",
            "SK55T",
            "SK58",
            "SK58T",
            "SK61",
            "SK62",
            "SK64",
            "SK76",
            "SK76D",
            "SK92",
            "S52"});
            this.cboModel.Location = new System.Drawing.Point(178, 136);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(302, 32);
            this.cboModel.TabIndex = 4;
            this.cboModel.Leave += new System.EventHandler(this.cboModel_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 32);
            this.label7.TabIndex = 18;
            this.label7.Text = "Company Name*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // numBurnRate
            // 
            this.numBurnRate.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBurnRate.Location = new System.Drawing.Point(178, 216);
            this.numBurnRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBurnRate.Name = "numBurnRate";
            this.numBurnRate.Size = new System.Drawing.Size(120, 29);
            this.numBurnRate.TabIndex = 7;
            this.numBurnRate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numBurnRate.ValueChanged += new System.EventHandler(this.numBurnRate_ValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 32);
            this.label8.TabIndex = 20;
            this.label8.Text = "Fuel Burn Rate";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(304, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 24);
            this.label9.TabIndex = 21;
            this.label9.Text = "Liters / hour of flight";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(178, 16);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(6);
            this.txtCompanyName.Multiline = false;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(320, 32);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // txtRegistration
            // 
            this.txtRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistration.BackColor = System.Drawing.Color.Transparent;
            this.txtRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistration.Location = new System.Drawing.Point(178, 56);
            this.txtRegistration.Margin = new System.Windows.Forms.Padding(6);
            this.txtRegistration.Multiline = false;
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(320, 32);
            this.txtRegistration.TabIndex = 2;
            this.txtRegistration.TextChanged += new System.EventHandler(this.txtRegistration_TextChanged_1);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(178, 252);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(302, 162);
            this.txtRemarks.TabIndex = 8;
            this.txtRemarks.WordWrap = true;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged_1);
            this.txtRemarks.Child = new System.Windows.Controls.TextBox();
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumber.Location = new System.Drawing.Point(178, 176);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(302, 32);
            this.txtContactNumber.TabIndex = 6;
            this.txtContactNumber.TextChanged += new System.EventHandler(this.txtContactNumber_TextChanged_1);
            this.txtContactNumber.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.txtContactNumber_ChildChanged);
            this.txtContactNumber.Child = new System.Windows.Controls.TextBox();
            // 
            // EditAircraftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numBurnRate);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboModel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboIsHeli);
            this.Controls.Add(this.txtRegistration);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditAircraftControl";
            this.Size = new System.Drawing.Size(504, 417);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurnRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private SpellBox txtContactNumber;
        private SpellBox txtRemarks;
        private TextBoxRequiredControl txtRegistration;
        private System.Windows.Forms.ComboBox cboIsHeli;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboModel;
        private TextBoxRequiredControl txtCompanyName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numBurnRate;
    }
}
