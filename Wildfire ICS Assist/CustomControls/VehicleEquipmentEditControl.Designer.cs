namespace Wildfire_ICS_Assist.CustomControls
{
    partial class VehicleEquipmentEditControl
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
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCallsign = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new SpellBox();
            this.txtUnitNumber = new SpellBox();
            this.txtIncidentIDNo = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtKind = new SpellBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtLicenseOrID = new SpellBox();
            this.txtFeatures = new SpellBox();
            this.txtOrderRequestNo = new SpellBox();
            this.txtNotes = new SpellBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.lblSavedOperator = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(3, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 24);
            this.label15.TabIndex = 140;
            this.label15.Text = "Resource Type";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 139;
            this.label2.Text = "Resource Kind";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 126;
            this.label1.Text = "Order Request No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCallsign
            // 
            this.lblCallsign.Location = new System.Drawing.Point(3, 6);
            this.lblCallsign.Name = "lblCallsign";
            this.lblCallsign.Size = new System.Drawing.Size(175, 29);
            this.lblCallsign.TabIndex = 127;
            this.lblCallsign.Text = "Company Name*";
            this.lblCallsign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 29);
            this.label12.TabIndex = 137;
            this.label12.Text = "Other Notes";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 29);
            this.label5.TabIndex = 130;
            this.label5.Text = "Features";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 29);
            this.label8.TabIndex = 133;
            this.label8.Text = "License Plate or ID#";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerialNumber.Location = new System.Drawing.Point(159, 2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(194, 29);
            this.txtSerialNumber.TabIndex = 3;
            this.txtSerialNumber.TextChanged += new System.EventHandler(this.txtSerialNumber_TextChanged);
            this.txtSerialNumber.Child = new System.Windows.Controls.TextBox();
            // 
            // txtUnitNumber
            // 
            this.txtUnitNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitNumber.Location = new System.Drawing.Point(187, 2);
            this.txtUnitNumber.Name = "txtUnitNumber";
            this.txtUnitNumber.Size = new System.Drawing.Size(268, 29);
            this.txtUnitNumber.TabIndex = 2;
            this.txtUnitNumber.TextChanged += new System.EventHandler(this.txtUnitNumber_TextChanged);
            this.txtUnitNumber.Child = new System.Windows.Controls.TextBox();
            // 
            // txtIncidentIDNo
            // 
            this.txtIncidentIDNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncidentIDNo.BackColor = System.Drawing.Color.Transparent;
            this.txtIncidentIDNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncidentIDNo.Location = new System.Drawing.Point(187, 6);
            this.txtIncidentIDNo.Margin = new System.Windows.Forms.Padding(6);
            this.txtIncidentIDNo.Multiline = true;
            this.txtIncidentIDNo.Name = "txtIncidentIDNo";
            this.txtIncidentIDNo.Size = new System.Drawing.Size(642, 29);
            this.txtIncidentIDNo.TabIndex = 1;
            this.txtIncidentIDNo.TextChanged += new System.EventHandler(this.txtIncidentIDNo_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.txtUnitNumber);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.txtSerialNumber);
            this.splitContainer1.Size = new System.Drawing.Size(832, 35);
            this.splitContainer1.SplitterDistance = 455;
            this.splitContainer1.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 29);
            this.label10.TabIndex = 143;
            this.label10.Text = "Unit #";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(3, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 24);
            this.label11.TabIndex = 144;
            this.label11.Text = "Serial #";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 120);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtKind);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cboType);
            this.splitContainer2.Panel2.Controls.Add(this.label15);
            this.splitContainer2.Size = new System.Drawing.Size(832, 35);
            this.splitContainer2.SplitterDistance = 455;
            this.splitContainer2.TabIndex = 5;
            // 
            // txtKind
            // 
            this.txtKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKind.Location = new System.Drawing.Point(187, 4);
            this.txtKind.Name = "txtKind";
            this.txtKind.Size = new System.Drawing.Size(268, 29);
            this.txtKind.TabIndex = 5;
            this.txtKind.TextChanged += new System.EventHandler(this.txtKind_TextChanged);
            this.txtKind.Child = new System.Windows.Controls.TextBox();
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Type 1",
            "Type 2",
            "Type 3",
            "Type 4",
            "Type 5",
            "Type 6",
            "Type 7"});
            this.cboType.Location = new System.Drawing.Point(159, 2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(194, 32);
            this.cboType.TabIndex = 6;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // txtLicenseOrID
            // 
            this.txtLicenseOrID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicenseOrID.Location = new System.Drawing.Point(187, 85);
            this.txtLicenseOrID.Name = "txtLicenseOrID";
            this.txtLicenseOrID.Size = new System.Drawing.Size(625, 29);
            this.txtLicenseOrID.TabIndex = 4;
            this.txtLicenseOrID.TextChanged += new System.EventHandler(this.txtLicenseOrID_TextChanged);
            this.txtLicenseOrID.Child = new System.Windows.Controls.TextBox();
            // 
            // txtFeatures
            // 
            this.txtFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFeatures.Location = new System.Drawing.Point(187, 159);
            this.txtFeatures.Name = "txtFeatures";
            this.txtFeatures.Size = new System.Drawing.Size(625, 29);
            this.txtFeatures.TabIndex = 7;
            this.txtFeatures.TextChanged += new System.EventHandler(this.txtFeatures_TextChanged);
            this.txtFeatures.Child = new System.Windows.Controls.TextBox();
            // 
            // txtOrderRequestNo
            // 
            this.txtOrderRequestNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrderRequestNo.Location = new System.Drawing.Point(187, 194);
            this.txtOrderRequestNo.Name = "txtOrderRequestNo";
            this.txtOrderRequestNo.Size = new System.Drawing.Size(625, 29);
            this.txtOrderRequestNo.TabIndex = 8;
            this.txtOrderRequestNo.TextChanged += new System.EventHandler(this.txtOrderRequestNo_TextChanged);
            this.txtOrderRequestNo.Child = new System.Windows.Controls.TextBox();
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(187, 269);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(625, 83);
            this.txtNotes.TabIndex = 10;
            this.txtNotes.Text = "`";
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            this.txtNotes.Child = new System.Windows.Controls.TextBox();
            // 
            // cboOperator
            // 
            this.cboOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOperator.DisplayMember = "NameWithKindAndType";
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Location = new System.Drawing.Point(187, 231);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(625, 32);
            this.cboOperator.TabIndex = 9;
            this.cboOperator.ValueMember = "ID";
            this.cboOperator.Leave += new System.EventHandler(this.cboOperator_Leave);
            // 
            // lblSavedOperator
            // 
            this.lblSavedOperator.Location = new System.Drawing.Point(69, 235);
            this.lblSavedOperator.Name = "lblSavedOperator";
            this.lblSavedOperator.Size = new System.Drawing.Size(106, 24);
            this.lblSavedOperator.TabIndex = 151;
            this.lblSavedOperator.Text = "Operator";
            this.lblSavedOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VehicleEquipmentEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.lblSavedOperator);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtOrderRequestNo);
            this.Controls.Add(this.txtFeatures);
            this.Controls.Add(this.txtLicenseOrID);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtIncidentIDNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCallsign);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VehicleEquipmentEditControl";
            this.Size = new System.Drawing.Size(832, 355);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCallsign;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private SpellBox txtSerialNumber;
        private SpellBox txtUnitNumber;
        private TextBoxRequiredControl txtIncidentIDNo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cboType;
        private SpellBox txtKind;
        private SpellBox txtLicenseOrID;
        private SpellBox txtFeatures;
        private SpellBox txtOrderRequestNo;
        private SpellBox txtNotes;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.Label lblSavedOperator;
    }
}
