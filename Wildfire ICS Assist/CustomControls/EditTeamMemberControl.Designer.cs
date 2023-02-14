namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditTeamMemberControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTeamMemberControl));
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.bsProvAndTerr = new System.Windows.Forms.BindingSource(this.components);
            this.cboAgency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboHomeAgency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQualifications = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.txtNOKRelationship = new System.Windows.Forms.TextBox();
            this.txtNOKName = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txtNOKPhone = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.chkDietary = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(212, 6);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(233, 29);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cboProvince
            // 
            this.cboProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvince.DataSource = this.bsProvAndTerr;
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(212, 44);
            this.cboProvince.Margin = new System.Windows.Forms.Padding(6);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(233, 32);
            this.cboProvince.TabIndex = 1;
            this.cboProvince.SelectedIndexChanged += new System.EventHandler(this.cboProvince_SelectedIndexChanged);
            // 
            // cboAgency
            // 
            this.cboAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgency.FormattingEnabled = true;
            this.cboAgency.Location = new System.Drawing.Point(212, 85);
            this.cboAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgency.Name = "cboAgency";
            this.cboAgency.Size = new System.Drawing.Size(233, 32);
            this.cboAgency.TabIndex = 2;
            this.cboAgency.SelectedIndexChanged += new System.EventHandler(this.cboAgency_SelectedIndexChanged);
            this.cboAgency.Leave += new System.EventHandler(this.cboAgency_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Full Name*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prov / Terr.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agency";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(212, 126);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(233, 29);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtPhone_MaskInputRejected);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phone";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(212, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 29);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 29);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboHomeAgency
            // 
            this.cboHomeAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboHomeAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboHomeAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboHomeAgency.FormattingEnabled = true;
            this.cboHomeAgency.Location = new System.Drawing.Point(212, 199);
            this.cboHomeAgency.Name = "cboHomeAgency";
            this.cboHomeAgency.Size = new System.Drawing.Size(233, 32);
            this.cboHomeAgency.TabIndex = 5;
            this.cboHomeAgency.SelectedIndexChanged += new System.EventHandler(this.cboHomeAgency_SelectedIndexChanged);
            this.cboHomeAgency.Leave += new System.EventHandler(this.cboHomeAgency_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 202);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = "Home Base";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 238);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 29);
            this.label11.TabIndex = 21;
            this.label11.Text = "Other Qualifications";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQualifications
            // 
            this.txtQualifications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQualifications.Location = new System.Drawing.Point(212, 237);
            this.txtQualifications.Name = "txtQualifications";
            this.txtQualifications.Size = new System.Drawing.Size(233, 29);
            this.txtQualifications.TabIndex = 6;
            this.txtQualifications.TextChanged += new System.EventHandler(this.txtQualifications_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(451, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 92;
            this.button1.TabStop = false;
            this.toolTip1.SetToolTip(this.button1, "Enter he Province or Territory");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(451, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 93;
            this.button2.TabStop = false;
            this.toolTip1.SetToolTip(this.button2, "Use this section to list agency name (or designator), and individual names for al" +
        "l single resource personnel (e.g., ORC, ARL, NBDNR).");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(451, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 95;
            this.button4.TabStop = false;
            this.toolTip1.SetToolTip(this.button4, "Enter any other contact information for the resource");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(451, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 96;
            this.button5.TabStop = false;
            this.toolTip1.SetToolTip(this.button5, "Enter any other contact information for the resource");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(451, 203);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 26);
            this.button6.TabIndex = 97;
            this.button6.TabStop = false;
            this.toolTip1.SetToolTip(this.button6, "Enter the home unit or agency to which the resource or individual is normally ass" +
        "igned (may not be departure location).");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Location = new System.Drawing.Point(451, 239);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(26, 26);
            this.button10.TabIndex = 101;
            this.button10.TabStop = false;
            this.toolTip1.SetToolTip(this.button10, "Enter any other qualifications pertinent to the incident");
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // txtNOKRelationship
            // 
            this.txtNOKRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKRelationship.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOKRelationship.Location = new System.Drawing.Point(212, 373);
            this.txtNOKRelationship.Name = "txtNOKRelationship";
            this.txtNOKRelationship.Size = new System.Drawing.Size(233, 26);
            this.txtNOKRelationship.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtNOKRelationship, "Ideally, your EMBC ID#");
            this.txtNOKRelationship.TextChanged += new System.EventHandler(this.txtNOKRelationship_TextChanged);
            // 
            // txtNOKName
            // 
            this.txtNOKName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOKName.Location = new System.Drawing.Point(212, 341);
            this.txtNOKName.Name = "txtNOKName";
            this.txtNOKName.Size = new System.Drawing.Size(233, 26);
            this.txtNOKName.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtNOKName, "Ideally, your EMBC ID#");
            this.txtNOKName.TextChanged += new System.EventHandler(this.txtNOKName_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check-box-unchecked.png");
            this.imageList1.Images.SetKeyName(1, "check-box-checked.png");
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(16, 405);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 29);
            this.label15.TabIndex = 107;
            this.label15.Text = "EM Contact Phone";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNOKPhone
            // 
            this.txtNOKPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOKPhone.Location = new System.Drawing.Point(212, 406);
            this.txtNOKPhone.Margin = new System.Windows.Forms.Padding(6);
            this.txtNOKPhone.Name = "txtNOKPhone";
            this.txtNOKPhone.Size = new System.Drawing.Size(233, 26);
            this.txtNOKPhone.TabIndex = 11;
            this.txtNOKPhone.TextChanged += new System.EventHandler(this.txtNOKPhone_TextChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 372);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 29);
            this.label14.TabIndex = 103;
            this.label14.Text = "Relationship";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 340);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(187, 29);
            this.label13.TabIndex = 102;
            this.label13.Text = "Emergency Contact";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 273);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 109;
            this.label4.Text = "Callsign";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCallsign
            // 
            this.txtCallsign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallsign.Location = new System.Drawing.Point(212, 272);
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(233, 29);
            this.txtCallsign.TabIndex = 7;
            this.txtCallsign.TextChanged += new System.EventHandler(this.txtCallsign_TextChanged);
            // 
            // chkDietary
            // 
            this.chkDietary.AutoSize = true;
            this.chkDietary.Location = new System.Drawing.Point(212, 307);
            this.chkDietary.Name = "chkDietary";
            this.chkDietary.Size = new System.Drawing.Size(220, 28);
            this.chkDietary.TabIndex = 8;
            this.chkDietary.Text = "Yes, dietary restrictions";
            this.chkDietary.UseVisualStyleBackColor = true;
            this.chkDietary.CheckedChanged += new System.EventHandler(this.chkDietary_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 307);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 111;
            this.label8.Text = "Dietary Restrictions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditTeamMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDietary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCallsign);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtNOKPhone);
            this.Controls.Add(this.txtNOKRelationship);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNOKName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtQualifications);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboHomeAgency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAgency);
            this.Controls.Add(this.cboProvince);
            this.Controls.Add(this.txtName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditTeamMemberControl";
            this.Size = new System.Drawing.Size(485, 437);
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.ComboBox cboAgency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHomeAgency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQualifications;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.BindingSource bsProvAndTerr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNOKPhone;
        private System.Windows.Forms.TextBox txtNOKRelationship;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNOKName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.CheckBox chkDietary;
        private System.Windows.Forms.Label label8;
    }
}
