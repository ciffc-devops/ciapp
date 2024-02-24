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
            this.button3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.chkDietary = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
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
            this.txtFirstName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.txtLastName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtCellphone = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.txtNOKName = new SpellBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProvince
            // 
            this.cboProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProvince.DataSource = this.bsProvAndTerr;
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(170, 3);
            this.cboProvince.Margin = new System.Windows.Forms.Padding(6);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(131, 32);
            this.cboProvince.TabIndex = 7;
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
            this.cboAgency.Location = new System.Drawing.Point(220, 182);
            this.cboAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgency.Name = "cboAgency";
            this.cboAgency.Size = new System.Drawing.Size(477, 32);
            this.cboAgency.TabIndex = 8;
            this.cboAgency.SelectedIndexChanged += new System.EventHandler(this.cboAgency_SelectedIndexChanged);
            this.cboAgency.Leave += new System.EventHandler(this.cboAgency_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name (First, Mid, Last)*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Home Prov/Terr";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(205, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agency*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cellphone*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(90, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 29);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 29);
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
            this.cboHomeAgency.Location = new System.Drawing.Point(220, 301);
            this.cboHomeAgency.Name = "cboHomeAgency";
            this.cboHomeAgency.Size = new System.Drawing.Size(477, 32);
            this.cboHomeAgency.TabIndex = 11;
            this.cboHomeAgency.Leave += new System.EventHandler(this.cboHomeAgency_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 304);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 29);
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
            this.button1.Location = new System.Drawing.Point(314, 8);
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
            this.button2.Location = new System.Drawing.Point(707, 184);
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
            this.button6.Location = new System.Drawing.Point(707, 305);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(26, 26);
            this.button6.TabIndex = 97;
            this.button6.TabStop = false;
            this.toolTip1.SetToolTip(this.button6, "Enter the home unit or agency to which the resource or individual is normally ass" +
        "igned (may not be departure location).");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Help;
            this.button3.Location = new System.Drawing.Point(707, 477);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 125;
            this.button3.TabStop = false;
            this.toolTip1.SetToolTip(this.button3, "Provide regional or home unit emergency contact. ");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnShowHelp_Click);
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
            this.label13.Location = new System.Drawing.Point(8, 477);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 57);
            this.label13.TabIndex = 102;
            this.label13.Text = "Employer emergency contact information ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDietary
            // 
            this.chkDietary.AutoSize = true;
            this.chkDietary.Location = new System.Drawing.Point(220, 438);
            this.chkDietary.Name = "chkDietary";
            this.chkDietary.Size = new System.Drawing.Size(220, 28);
            this.chkDietary.TabIndex = 17;
            this.chkDietary.Text = "Yes, dietary restrictions";
            this.chkDietary.UseVisualStyleBackColor = true;
            this.chkDietary.CheckedChanged += new System.EventHandler(this.chkDietary_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 437);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 29);
            this.label8.TabIndex = 111;
            this.label8.Text = "Dietary Restrictions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(-3, 9);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 29);
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
            this.cboCountry.Location = new System.Drawing.Point(218, 6);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(6);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(161, 32);
            this.cboCountry.TabIndex = 6;
            this.cboCountry.Leave += new System.EventHandler(this.cboCountry_Leave);
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.Location = new System.Drawing.Point(6, 4);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(6);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(146, 29);
            this.txtMiddleName.TabIndex = 2;
            this.txtMiddleName.TextChanged += new System.EventHandler(this.txtMiddleName_TextChanged);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 92);
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
            this.cboAccomodationPreference.Location = new System.Drawing.Point(220, 91);
            this.cboAccomodationPreference.Margin = new System.Windows.Forms.Padding(6);
            this.cboAccomodationPreference.Name = "cboAccomodationPreference";
            this.cboAccomodationPreference.Size = new System.Drawing.Size(477, 32);
            this.cboAccomodationPreference.TabIndex = 5;
            this.cboAccomodationPreference.SelectedIndexChanged += new System.EventHandler(this.cboAccomodationPreference_SelectedIndexChanged);
            this.cboAccomodationPreference.Leave += new System.EventHandler(this.cboGender_Leave);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(6, 267);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(205, 29);
            this.label14.TabIndex = 122;
            this.label14.Text = "Contractor";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkContractor
            // 
            this.chkContractor.AutoSize = true;
            this.chkContractor.Location = new System.Drawing.Point(220, 267);
            this.chkContractor.Name = "chkContractor";
            this.chkContractor.Size = new System.Drawing.Size(61, 28);
            this.chkContractor.TabIndex = 10;
            this.chkContractor.Text = "Yes";
            this.chkContractor.UseVisualStyleBackColor = true;
            this.chkContractor.CheckedChanged += new System.EventHandler(this.chkContractor_CheckedChanged);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(452, 437);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 29);
            this.label15.TabIndex = 124;
            this.label15.Text = "Allergies";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAllergies
            // 
            this.chkAllergies.AutoSize = true;
            this.chkAllergies.Location = new System.Drawing.Point(589, 438);
            this.chkAllergies.Name = "chkAllergies";
            this.chkAllergies.Size = new System.Drawing.Size(141, 28);
            this.chkAllergies.TabIndex = 18;
            this.chkAllergies.Text = "Yes, allergies";
            this.chkAllergies.UseVisualStyleBackColor = true;
            this.chkAllergies.CheckedChanged += new System.EventHandler(this.chkAllergies_CheckedChanged);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 9);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(205, 29);
            this.label16.TabIndex = 127;
            this.label16.Text = "Resource Kind";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 10);
            this.label17.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 29);
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
            this.cboKind.Location = new System.Drawing.Point(220, 9);
            this.cboKind.Name = "cboKind";
            this.cboKind.Size = new System.Drawing.Size(163, 32);
            this.cboKind.TabIndex = 12;
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
            this.cboType.Location = new System.Drawing.Point(163, 9);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(143, 32);
            this.cboType.TabIndex = 13;
            this.cboType.Leave += new System.EventHandler(this.cboType_Leave);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(6, 229);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(205, 29);
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
            this.cboOtherAgency.Location = new System.Drawing.Point(220, 226);
            this.cboOtherAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboOtherAgency.Name = "cboOtherAgency";
            this.cboOtherAgency.Size = new System.Drawing.Size(477, 32);
            this.cboOtherAgency.TabIndex = 9;
            this.cboOtherAgency.Leave += new System.EventHandler(this.cboOtherAgency_Leave);
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(6, 50);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(205, 29);
            this.label20.TabIndex = 136;
            this.label20.Text = "Preferred Pronouns";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPronouns
            // 
            this.txtPronouns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPronouns.Location = new System.Drawing.Point(220, 50);
            this.txtPronouns.Margin = new System.Windows.Forms.Padding(6);
            this.txtPronouns.Name = "txtPronouns";
            this.txtPronouns.Size = new System.Drawing.Size(477, 29);
            this.txtPronouns.TabIndex = 4;
            this.txtPronouns.TextChanged += new System.EventHandler(this.txtPronouns_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.Location = new System.Drawing.Point(4, 4);
            this.txtFirstName.Multiline = false;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 29);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.Location = new System.Drawing.Point(6, 4);
            this.txtLastName.Multiline = false;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(149, 29);
            this.txtLastName.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(214, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtFirstName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(483, 38);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtMiddleName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLastName);
            this.splitContainer2.Size = new System.Drawing.Size(320, 38);
            this.splitContainer2.SplitterDistance = 158;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 339);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label16);
            this.splitContainer3.Panel1.Controls.Add(this.cboKind);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.cboType);
            this.splitContainer3.Panel2.Controls.Add(this.label17);
            this.splitContainer3.Size = new System.Drawing.Size(732, 48);
            this.splitContainer3.SplitterDistance = 387;
            this.splitContainer3.TabIndex = 12;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(1, 393);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.txtCellphone);
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer4.Panel2.Controls.Add(this.label6);
            this.splitContainer4.Size = new System.Drawing.Size(732, 39);
            this.splitContainer4.SplitterDistance = 387;
            this.splitContainer4.TabIndex = 14;
            // 
            // txtCellphone
            // 
            this.txtCellphone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCellphone.BackColor = System.Drawing.Color.Transparent;
            this.txtCellphone.Location = new System.Drawing.Point(218, 2);
            this.txtCellphone.Margin = new System.Windows.Forms.Padding(6);
            this.txtCellphone.Multiline = false;
            this.txtCellphone.Name = "txtCellphone";
            this.txtCellphone.Size = new System.Drawing.Size(166, 30);
            this.txtCellphone.TabIndex = 14;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer5.IsSplitterFixed = true;
            this.splitContainer5.Location = new System.Drawing.Point(2, 132);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.cboCountry);
            this.splitContainer5.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.label2);
            this.splitContainer5.Panel2.Controls.Add(this.cboProvince);
            this.splitContainer5.Panel2.Controls.Add(this.button1);
            this.splitContainer5.Size = new System.Drawing.Size(732, 48);
            this.splitContainer5.SplitterDistance = 387;
            this.splitContainer5.TabIndex = 6;
            // 
            // txtNOKName
            // 
            this.txtNOKName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKName.Location = new System.Drawing.Point(220, 477);
            this.txtNOKName.Multiline = true;
            this.txtNOKName.Name = "txtNOKName";
            this.txtNOKName.Size = new System.Drawing.Size(474, 57);
            this.txtNOKName.TabIndex = 137;
            this.txtNOKName.WordWrap = true;
            this.txtNOKName.TextChanged += new System.EventHandler(this.txtNOKName_TextChanged_1);
            this.txtNOKName.Child = new System.Windows.Controls.TextBox();
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // PersonnelEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.txtNOKName);
            this.Controls.Add(this.splitContainer5);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtPronouns);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboOtherAgency);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkAllergies);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.chkContractor);
            this.Controls.Add(this.cboAccomodationPreference);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDietary);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboHomeAgency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAgency);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(735, 543);
            this.Name = "PersonnelEditControl";
            this.Size = new System.Drawing.Size(735, 543);
            this.Load += new System.EventHandler(this.PersonnelEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsProvAndTerr)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDietary;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.TextBox txtMiddleName;
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
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPronouns;
        private TextBoxRequiredControl txtFirstName;
        private TextBoxRequiredControl txtLastName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private TextBoxRequiredControl txtCellphone;
        private SpellBox txtNOKName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
