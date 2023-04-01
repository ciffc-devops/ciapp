namespace Wildfire_ICS_Assist.CustomControls
{
    partial class PersonnelEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonnelEditControl));
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.bsProvAndTerr = new System.Windows.Forms.BindingSource(this.components);
            this.cboAgency = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboHomeAgency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtNOKName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEmailHelp = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCallsign = new System.Windows.Forms.TextBox();
            this.chkDietary = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboAccomodationPreference = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkContractor = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkAllergies = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cboKind = new System.Windows.Forms.ComboBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboOtherAgency = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPronouns = new System.Windows.Forms.TextBox();
            this.txtCellphone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(214, 6);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(6);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(190, 29);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cboProvince
            // 
            this.cboProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvince.DataSource = this.bsProvAndTerr;
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(214, 258);
            this.cboProvince.Margin = new System.Windows.Forms.Padding(6);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(190, 32);
            this.cboProvince.TabIndex = 6;
            this.cboProvince.SelectedIndexChanged += new System.EventHandler(this.cboProvince_SelectedIndexChanged);
            // 
            // cboAgency
            // 
            this.cboAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAgency.FormattingEnabled = true;
            this.cboAgency.Location = new System.Drawing.Point(214, 302);
            this.cboAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgency.Name = "cboAgency";
            this.cboAgency.Size = new System.Drawing.Size(190, 32);
            this.cboAgency.TabIndex = 7;
            this.cboAgency.SelectedIndexChanged += new System.EventHandler(this.cboAgency_SelectedIndexChanged);
            this.cboAgency.Leave += new System.EventHandler(this.cboAgency_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 261);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Home Prov/Terr";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 305);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agency*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 540);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cellphone*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(214, 579);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(190, 29);
            this.txtEmail.TabIndex = 14;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 579);
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
            this.cboHomeAgency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHomeAgency.FormattingEnabled = true;
            this.cboHomeAgency.Location = new System.Drawing.Point(214, 421);
            this.cboHomeAgency.Name = "cboHomeAgency";
            this.cboHomeAgency.Size = new System.Drawing.Size(190, 32);
            this.cboHomeAgency.TabIndex = 10;
            this.cboHomeAgency.Leave += new System.EventHandler(this.cboHomeAgency_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(18, 424);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 29);
            this.label7.TabIndex = 16;
            this.label7.Text = "Home Unit / Base";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Help;
            this.button1.Location = new System.Drawing.Point(408, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 92;
            this.button1.TabStop = false;
            this.toolTip1.SetToolTip(this.button1, "Enter the Province or Territory");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Help;
            this.button2.Location = new System.Drawing.Point(408, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 93;
            this.button2.TabStop = false;
            this.toolTip1.SetToolTip(this.button2, "Use this section to list agency name (or designator), and individual names for al" +
        "l single resource personnel (e.g., ORC, ARL, NBDNR).");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Cursor = System.Windows.Forms.Cursors.Help;
            this.button6.Location = new System.Drawing.Point(410, 425);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 26);
            this.button6.TabIndex = 97;
            this.button6.TabStop = false;
            this.toolTip1.SetToolTip(this.button6, "Enter the home unit or agency to which the resource or individual is normally ass" +
        "igned (may not be departure location).");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // txtNOKName
            // 
            this.txtNOKName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNOKName.Location = new System.Drawing.Point(211, 724);
            this.txtNOKName.Name = "txtNOKName";
            this.txtNOKName.Size = new System.Drawing.Size(190, 29);
            this.txtNOKName.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtNOKName, "Ideally, your EMBC ID#");
            this.txtNOKName.TextChanged += new System.EventHandler(this.txtNOKName_TextChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Help;
            this.button3.Location = new System.Drawing.Point(407, 725);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 125;
            this.button3.TabStop = false;
            this.toolTip1.SetToolTip(this.button3, "Provide regional or home unit emergency contact. ");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // btnEmailHelp
            // 
            this.btnEmailHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmailHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmailHelp.BackgroundImage")));
            this.btnEmailHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmailHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnEmailHelp.Location = new System.Drawing.Point(408, 580);
            this.btnEmailHelp.Name = "btnEmailHelp";
            this.btnEmailHelp.Size = new System.Drawing.Size(26, 26);
            this.btnEmailHelp.TabIndex = 134;
            this.btnEmailHelp.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEmailHelp, "Emails may be used for IAP delivery. Enter work emails or company emails only. ");
            this.btnEmailHelp.UseVisualStyleBackColor = true;
            this.btnEmailHelp.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "check-box-unchecked.png");
            this.imageList1.Images.SetKeyName(1, "check-box-checked.png");
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(4, 710);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(201, 57);
            this.label13.TabIndex = 102;
            this.label13.Text = "Employer emergency contact information *";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 614);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 109;
            this.label4.Text = "Call sign";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCallsign
            // 
            this.txtCallsign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCallsign.Location = new System.Drawing.Point(214, 613);
            this.txtCallsign.Name = "txtCallsign";
            this.txtCallsign.Size = new System.Drawing.Size(190, 29);
            this.txtCallsign.TabIndex = 15;
            this.txtCallsign.TextChanged += new System.EventHandler(this.txtCallsign_TextChanged);
            // 
            // chkDietary
            // 
            this.chkDietary.AutoSize = true;
            this.chkDietary.Location = new System.Drawing.Point(214, 648);
            this.chkDietary.Name = "chkDietary";
            this.chkDietary.Size = new System.Drawing.Size(220, 28);
            this.chkDietary.TabIndex = 16;
            this.chkDietary.Text = "Yes, dietary restrictions";
            this.chkDietary.UseVisualStyleBackColor = true;
            this.chkDietary.CheckedChanged += new System.EventHandler(this.chkDietary_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(18, 647);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 111;
            this.label8.Text = "Dietary Restrictions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(18, 217);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 29);
            this.label9.TabIndex = 113;
            this.label9.Text = "Home Country";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCountry
            // 
            this.cboCountry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Items.AddRange(new object[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua and Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "The Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cape Verde",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo, Republic of the",
            "Congo, Democratic Republic of the",
            "Costa Rica",
            "Cote d\'Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor (Timor-Leste)",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "The Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Israel",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea, North",
            "Korea, South",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Macedonia",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia, Federated States of",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar (Burma)",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Swaziland",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Tonga",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Tuvalu",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States of America",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City (Holy See)",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.cboCountry.Location = new System.Drawing.Point(214, 214);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(6);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(190, 32);
            this.cboCountry.TabIndex = 5;
            this.cboCountry.Leave += new System.EventHandler(this.cboCountry_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(18, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(187, 29);
            this.label10.TabIndex = 115;
            this.label10.Text = "Middle Initial";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.Location = new System.Drawing.Point(214, 47);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(6);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(190, 29);
            this.txtMiddleName.TabIndex = 1;
            this.txtMiddleName.TextChanged += new System.EventHandler(this.txtMiddleName_TextChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(18, 88);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 29);
            this.label11.TabIndex = 117;
            this.label11.Text = "Last Name*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(214, 88);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(6);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(190, 29);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(0, 171);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 29);
            this.label12.TabIndex = 119;
            this.label12.Text = "Accomodation Pref.*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAccomodationPreference
            // 
            this.cboAccomodationPreference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAccomodationPreference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAccomodationPreference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAccomodationPreference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccomodationPreference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccomodationPreference.FormattingEnabled = true;
            this.cboAccomodationPreference.Items.AddRange(new object[] {
            "Male-Only",
            "Female-Only",
            "Not Gender-Restricted"});
            this.cboAccomodationPreference.Location = new System.Drawing.Point(214, 170);
            this.cboAccomodationPreference.Margin = new System.Windows.Forms.Padding(6);
            this.cboAccomodationPreference.Name = "cboAccomodationPreference";
            this.cboAccomodationPreference.Size = new System.Drawing.Size(190, 32);
            this.cboAccomodationPreference.TabIndex = 4;
            this.cboAccomodationPreference.SelectedIndexChanged += new System.EventHandler(this.cboAccomodationPreference_SelectedIndexChanged);
            this.cboAccomodationPreference.Leave += new System.EventHandler(this.cboGender_Leave);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(18, 387);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(187, 29);
            this.label14.TabIndex = 122;
            this.label14.Text = "Contractor";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkContractor
            // 
            this.chkContractor.AutoSize = true;
            this.chkContractor.Location = new System.Drawing.Point(214, 387);
            this.chkContractor.Name = "chkContractor";
            this.chkContractor.Size = new System.Drawing.Size(61, 28);
            this.chkContractor.TabIndex = 9;
            this.chkContractor.Text = "Yes";
            this.chkContractor.UseVisualStyleBackColor = true;
            this.chkContractor.CheckedChanged += new System.EventHandler(this.chkContractor_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(18, 681);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 29);
            this.label15.TabIndex = 124;
            this.label15.Text = "Allergies";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAllergies
            // 
            this.chkAllergies.AutoSize = true;
            this.chkAllergies.Location = new System.Drawing.Point(214, 682);
            this.chkAllergies.Name = "chkAllergies";
            this.chkAllergies.Size = new System.Drawing.Size(141, 28);
            this.chkAllergies.TabIndex = 17;
            this.chkAllergies.Text = "Yes, allergies";
            this.chkAllergies.UseVisualStyleBackColor = true;
            this.chkAllergies.CheckedChanged += new System.EventHandler(this.chkAllergies_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(18, 462);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(187, 29);
            this.label16.TabIndex = 127;
            this.label16.Text = "Resource Kind";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(18, 503);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(187, 29);
            this.label17.TabIndex = 129;
            this.label17.Text = "Resource Type";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboKind
            // 
            this.cboKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboKind.FormattingEnabled = true;
            this.cboKind.Items.AddRange(new object[] {
            "Overhead / IMT",
            "Crew Member",
            "Single Resource",
            "Aircraft Personnel",
            "Contractor"});
            this.cboKind.Location = new System.Drawing.Point(214, 459);
            this.cboKind.Name = "cboKind";
            this.cboKind.Size = new System.Drawing.Size(190, 32);
            this.cboKind.TabIndex = 11;
            this.cboKind.Leave += new System.EventHandler(this.cboKind_Leave);
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
            "Type 3"});
            this.cboType.Location = new System.Drawing.Point(214, 502);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(190, 32);
            this.cboType.TabIndex = 12;
            this.cboType.Leave += new System.EventHandler(this.cboType_Leave);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(18, 349);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(187, 29);
            this.label19.TabIndex = 132;
            this.label19.Text = "... Other Agency";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboOtherAgency
            // 
            this.cboOtherAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOtherAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboOtherAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboOtherAgency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboOtherAgency.FormattingEnabled = true;
            this.cboOtherAgency.Location = new System.Drawing.Point(214, 346);
            this.cboOtherAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboOtherAgency.Name = "cboOtherAgency";
            this.cboOtherAgency.Size = new System.Drawing.Size(190, 32);
            this.cboOtherAgency.TabIndex = 8;
            this.cboOtherAgency.Leave += new System.EventHandler(this.cboOtherAgency_Leave);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(18, 129);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(187, 29);
            this.label20.TabIndex = 136;
            this.label20.Text = "Preferred Pronouns";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPronouns
            // 
            this.txtPronouns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPronouns.Location = new System.Drawing.Point(214, 129);
            this.txtPronouns.Margin = new System.Windows.Forms.Padding(6);
            this.txtPronouns.Name = "txtPronouns";
            this.txtPronouns.Size = new System.Drawing.Size(190, 29);
            this.txtPronouns.TabIndex = 3;
            this.txtPronouns.TextChanged += new System.EventHandler(this.txtPronouns_TextChanged);
            // 
            // txtCellphone
            // 
            this.txtCellphone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellphone.Location = new System.Drawing.Point(214, 543);
            this.txtCellphone.Margin = new System.Windows.Forms.Padding(6);
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(190, 29);
            this.txtCellphone.TabIndex = 13;
            this.txtCellphone.TextChanged += new System.EventHandler(this.txtCellphone_TextChanged);
            // 
            // PersonnelEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtCellphone);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtPronouns);
            this.Controls.Add(this.btnEmailHelp);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboOtherAgency);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboKind);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkAllergies);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkContractor);
            this.Controls.Add(this.cboAccomodationPreference);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDietary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCallsign);
            this.Controls.Add(this.txtNOKName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboHomeAgency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAgency);
            this.Controls.Add(this.cboProvince);
            this.Controls.Add(this.txtFirstName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(442, 769);
            this.Name = "PersonnelEditControl";
            this.Size = new System.Drawing.Size(442, 769);
            this.Load += new System.EventHandler(this.PersonnelEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.ComboBox cboAgency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboHomeAgency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.BindingSource bsProvAndTerr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtNOKName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCallsign;
        private System.Windows.Forms.CheckBox chkDietary;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboAccomodationPreference;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkContractor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkAllergies;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboKind;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboOtherAgency;
        private System.Windows.Forms.Button btnEmailHelp;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPronouns;
        private System.Windows.Forms.TextBox txtCellphone;
    }
}
