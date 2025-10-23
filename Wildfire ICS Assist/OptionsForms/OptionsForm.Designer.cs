namespace Wildfire_ICS_Assist.OptionsForms
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.cboFormSet = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkShowTest = new System.Windows.Forms.CheckBox();
            this.txtOrganizationName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRemoveLogo = new System.Windows.Forms.Button();
            this.btnChangeLogo = new System.Windows.Forms.Button();
            this.picReportLogo = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDateFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDefaultProvince = new System.Windows.Forms.ComboBox();
            this.rbNumbersOrLetters = new System.Windows.Forms.RadioButton();
            this.rbNumbersOnly = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboDefaultICSRole = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPositionFormat = new System.Windows.Forms.ComboBox();
            this.tbFileManagement = new System.Windows.Forms.TabPage();
            this.btnBrowseBackupLocation = new System.Windows.Forms.Button();
            this.txtBackupLocation = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAutomaticSubFoldersHelp = new System.Windows.Forms.Button();
            this.txtAutomaticSubFolders = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.cboAutoBackupFrequency = new System.Windows.Forms.ComboBox();
            this.btnAutoBackupHelp = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.chkAutomaticBackups = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.chkPromptForInitialSave = new System.Windows.Forms.CheckBox();
            this.btnBrowseDefaultSaveLocation = new System.Windows.Forms.Button();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.tbNetworking = new System.Windows.Forms.TabPage();
            this.btnHelpDefaultPort = new System.Windows.Forms.Button();
            this.btnHelpDefaultToServer = new System.Windows.Forms.Button();
            this.numDefaultPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label26 = new System.Windows.Forms.Label();
            this.chkDefaultToServer = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnTrustedDevicesHelp = new System.Windows.Forms.Button();
            this.btnRemoveTrustedDevice = new System.Windows.Forms.Button();
            this.lbTrustedDevices = new System.Windows.Forms.ListBox();
            this.tpResources = new System.Windows.Forms.TabPage();
            this.numRedResourceTimeoutDays = new System.Windows.Forms.NumericUpDown();
            this.numYellowResourceTimeoutDays = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.fbdDefaultSave = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReportLogo)).BeginInit();
            this.tbFileManagement.SuspendLayout();
            this.tbNetworking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultPortNumber)).BeginInit();
            this.tpResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRedResourceTimeoutDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYellowResourceTimeoutDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbGeneral);
            this.tabControl1.Controls.Add(this.tbFileManagement);
            this.tabControl1.Controls.Add(this.tbNetworking);
            this.tabControl1.Controls.Add(this.tpResources);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 588);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tbGeneral
            // 
            this.tbGeneral.BackColor = System.Drawing.Color.Transparent;
            this.tbGeneral.Controls.Add(this.label14);
            this.tbGeneral.Controls.Add(this.cboFormSet);
            this.tbGeneral.Controls.Add(this.label13);
            this.tbGeneral.Controls.Add(this.chkShowTest);
            this.tbGeneral.Controls.Add(this.txtOrganizationName);
            this.tbGeneral.Controls.Add(this.label12);
            this.tbGeneral.Controls.Add(this.label11);
            this.tbGeneral.Controls.Add(this.btnRemoveLogo);
            this.tbGeneral.Controls.Add(this.btnChangeLogo);
            this.tbGeneral.Controls.Add(this.picReportLogo);
            this.tbGeneral.Controls.Add(this.label7);
            this.tbGeneral.Controls.Add(this.cboDateFormat);
            this.tbGeneral.Controls.Add(this.label1);
            this.tbGeneral.Controls.Add(this.cboDefaultProvince);
            this.tbGeneral.Controls.Add(this.rbNumbersOrLetters);
            this.tbGeneral.Controls.Add(this.rbNumbersOnly);
            this.tbGeneral.Controls.Add(this.label19);
            this.tbGeneral.Controls.Add(this.label28);
            this.tbGeneral.Controls.Add(this.cboDefaultICSRole);
            this.tbGeneral.Controls.Add(this.label3);
            this.tbGeneral.Controls.Add(this.cboPositionFormat);
            this.tbGeneral.Location = new System.Drawing.Point(4, 33);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneral.Size = new System.Drawing.Size(738, 551);
            this.tbGeneral.TabIndex = 0;
            this.tbGeneral.Text = "General";
            this.tbGeneral.Click += new System.EventHandler(this.tbGeneral_Click);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(242, 32);
            this.label14.TabIndex = 146;
            this.label14.Text = "ICS Form Selection";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboFormSet
            // 
            this.cboFormSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFormSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormSet.FormattingEnabled = true;
            this.cboFormSet.Items.AddRange(new object[] {
            "All Hazards",
            "Wildfire"});
            this.cboFormSet.Location = new System.Drawing.Point(267, 6);
            this.cboFormSet.Name = "cboFormSet";
            this.cboFormSet.Size = new System.Drawing.Size(463, 32);
            this.cboFormSet.TabIndex = 147;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(58, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(215, 24);
            this.label13.TabIndex = 144;
            this.label13.Text = "Testing";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowTest
            // 
            this.chkShowTest.AutoSize = true;
            this.chkShowTest.Location = new System.Drawing.Point(279, 428);
            this.chkShowTest.Name = "chkShowTest";
            this.chkShowTest.Size = new System.Drawing.Size(245, 28);
            this.chkShowTest.TabIndex = 145;
            this.chkShowTest.Text = "Yes, show the Test button";
            this.chkShowTest.UseVisualStyleBackColor = true;
            // 
            // txtOrganizationName
            // 
            this.txtOrganizationName.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganizationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrganizationName.Location = new System.Drawing.Point(267, 283);
            this.txtOrganizationName.Margin = new System.Windows.Forms.Padding(6);
            this.txtOrganizationName.Multiline = false;
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.Size = new System.Drawing.Size(463, 32);
            this.txtOrganizationName.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(258, 32);
            this.label12.TabIndex = 137;
            this.label12.Text = "Organization/Nation Name";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(242, 32);
            this.label11.TabIndex = 136;
            this.label11.Text = "Report Logo";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRemoveLogo
            // 
            this.btnRemoveLogo.Location = new System.Drawing.Point(447, 365);
            this.btnRemoveLogo.Name = "btnRemoveLogo";
            this.btnRemoveLogo.Size = new System.Drawing.Size(100, 34);
            this.btnRemoveLogo.TabIndex = 135;
            this.btnRemoveLogo.Text = "Remove";
            this.btnRemoveLogo.UseVisualStyleBackColor = true;
            this.btnRemoveLogo.Click += new System.EventHandler(this.btnRemoveLogo_Click);
            // 
            // btnChangeLogo
            // 
            this.btnChangeLogo.Location = new System.Drawing.Point(447, 324);
            this.btnChangeLogo.Name = "btnChangeLogo";
            this.btnChangeLogo.Size = new System.Drawing.Size(100, 34);
            this.btnChangeLogo.TabIndex = 134;
            this.btnChangeLogo.Text = "Change";
            this.btnChangeLogo.UseVisualStyleBackColor = true;
            this.btnChangeLogo.Click += new System.EventHandler(this.btnChangeLogo_Click);
            // 
            // picReportLogo
            // 
            this.picReportLogo.Location = new System.Drawing.Point(267, 324);
            this.picReportLogo.Name = "picReportLogo";
            this.picReportLogo.Size = new System.Drawing.Size(174, 99);
            this.picReportLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picReportLogo.TabIndex = 133;
            this.picReportLogo.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(242, 32);
            this.label7.TabIndex = 120;
            this.label7.Text = "Date Format for PDFs";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDateFormat
            // 
            this.cboDateFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDateFormat.FormattingEnabled = true;
            this.cboDateFormat.Location = new System.Drawing.Point(267, 134);
            this.cboDateFormat.Name = "cboDateFormat";
            this.cboDateFormat.Size = new System.Drawing.Size(463, 32);
            this.cboDateFormat.TabIndex = 121;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 118;
            this.label1.Text = "Default Prov/Terr.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDefaultProvince
            // 
            this.cboDefaultProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultProvince.DisplayMember = "RoleNameForDropdown";
            this.cboDefaultProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultProvince.FormattingEnabled = true;
            this.cboDefaultProvince.Items.AddRange(new object[] {
            "UTM",
            "Decimal Degrees",
            "Degrees Decimal Minutes",
            "Degrees Minutes Seconds",
            "MGRS"});
            this.cboDefaultProvince.Location = new System.Drawing.Point(267, 242);
            this.cboDefaultProvince.Name = "cboDefaultProvince";
            this.cboDefaultProvince.Size = new System.Drawing.Size(463, 32);
            this.cboDefaultProvince.TabIndex = 119;
            // 
            // rbNumbersOrLetters
            // 
            this.rbNumbersOrLetters.AutoSize = true;
            this.rbNumbersOrLetters.Location = new System.Drawing.Point(468, 100);
            this.rbNumbersOrLetters.Name = "rbNumbersOrLetters";
            this.rbNumbersOrLetters.Size = new System.Drawing.Size(195, 28);
            this.rbNumbersOrLetters.TabIndex = 117;
            this.rbNumbersOrLetters.Text = "Allow All Characters";
            this.rbNumbersOrLetters.UseVisualStyleBackColor = true;
            // 
            // rbNumbersOnly
            // 
            this.rbNumbersOnly.AutoSize = true;
            this.rbNumbersOnly.Checked = true;
            this.rbNumbersOnly.Location = new System.Drawing.Point(267, 100);
            this.rbNumbersOnly.Name = "rbNumbersOnly";
            this.rbNumbersOnly.Size = new System.Drawing.Size(195, 28);
            this.rbNumbersOnly.TabIndex = 116;
            this.rbNumbersOnly.TabStop = true;
            this.rbNumbersOnly.Text = "Only allow numbers";
            this.rbNumbersOnly.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(242, 32);
            this.label19.TabIndex = 115;
            this.label19.Text = "Incident Number Format";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(19, 204);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(242, 32);
            this.label28.TabIndex = 113;
            this.label28.Text = "Default ICS Role";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboDefaultICSRole
            // 
            this.cboDefaultICSRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultICSRole.DisplayMember = "RoleNameForDropdown";
            this.cboDefaultICSRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultICSRole.FormattingEnabled = true;
            this.cboDefaultICSRole.Items.AddRange(new object[] {
            "UTM",
            "Decimal Degrees",
            "Degrees Decimal Minutes",
            "Degrees Minutes Seconds",
            "MGRS"});
            this.cboDefaultICSRole.Location = new System.Drawing.Point(267, 204);
            this.cboDefaultICSRole.Name = "cboDefaultICSRole";
            this.cboDefaultICSRole.Size = new System.Drawing.Size(463, 32);
            this.cboDefaultICSRole.TabIndex = 114;
            this.cboDefaultICSRole.ValueMember = "GenericRoleID";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 32);
            this.label3.TabIndex = 99;
            this.label3.Text = "Position Format";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPositionFormat
            // 
            this.cboPositionFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPositionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPositionFormat.FormattingEnabled = true;
            this.cboPositionFormat.Items.AddRange(new object[] {
            "UTM",
            "Decimal Degrees",
            "Degrees Decimal Minutes",
            "Degrees Minutes Seconds",
            "MGRS"});
            this.cboPositionFormat.Location = new System.Drawing.Point(267, 62);
            this.cboPositionFormat.Name = "cboPositionFormat";
            this.cboPositionFormat.Size = new System.Drawing.Size(463, 32);
            this.cboPositionFormat.TabIndex = 100;
            // 
            // tbFileManagement
            // 
            this.tbFileManagement.Controls.Add(this.btnBrowseBackupLocation);
            this.tbFileManagement.Controls.Add(this.txtBackupLocation);
            this.tbFileManagement.Controls.Add(this.label34);
            this.tbFileManagement.Controls.Add(this.label6);
            this.tbFileManagement.Controls.Add(this.btnAutomaticSubFoldersHelp);
            this.tbFileManagement.Controls.Add(this.txtAutomaticSubFolders);
            this.tbFileManagement.Controls.Add(this.label5);
            this.tbFileManagement.Controls.Add(this.label32);
            this.tbFileManagement.Controls.Add(this.cboAutoBackupFrequency);
            this.tbFileManagement.Controls.Add(this.btnAutoBackupHelp);
            this.tbFileManagement.Controls.Add(this.label31);
            this.tbFileManagement.Controls.Add(this.chkAutomaticBackups);
            this.tbFileManagement.Controls.Add(this.label27);
            this.tbFileManagement.Controls.Add(this.chkPromptForInitialSave);
            this.tbFileManagement.Controls.Add(this.btnBrowseDefaultSaveLocation);
            this.tbFileManagement.Controls.Add(this.txtSaveLocation);
            this.tbFileManagement.Controls.Add(this.label4);
            this.tbFileManagement.Controls.Add(this.label2);
            this.tbFileManagement.Controls.Add(this.chkAutoSave);
            this.tbFileManagement.Location = new System.Drawing.Point(4, 33);
            this.tbFileManagement.Name = "tbFileManagement";
            this.tbFileManagement.Size = new System.Drawing.Size(738, 551);
            this.tbFileManagement.TabIndex = 3;
            this.tbFileManagement.Text = "File Management";
            this.tbFileManagement.UseVisualStyleBackColor = true;
            // 
            // btnBrowseBackupLocation
            // 
            this.btnBrowseBackupLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBackupLocation.Location = new System.Drawing.Point(631, 211);
            this.btnBrowseBackupLocation.Name = "btnBrowseBackupLocation";
            this.btnBrowseBackupLocation.Size = new System.Drawing.Size(99, 36);
            this.btnBrowseBackupLocation.TabIndex = 158;
            this.btnBrowseBackupLocation.Text = "Browse...";
            this.btnBrowseBackupLocation.UseVisualStyleBackColor = true;
            this.btnBrowseBackupLocation.Click += new System.EventHandler(this.btnBrowseBackupLocation_Click);
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupLocation.Location = new System.Drawing.Point(228, 214);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.ReadOnly = true;
            this.txtBackupLocation.Size = new System.Drawing.Size(392, 29);
            this.txtBackupLocation.TabIndex = 157;
            // 
            // label34
            // 
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(7, 217);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(215, 24);
            this.label34.TabIndex = 156;
            this.label34.Text = "Backup Location";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 80);
            this.label6.TabIndex = 155;
            this.label6.Text = "Separate each folder name with a comma\r\ne.g. GPX, Maps, Photos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAutomaticSubFoldersHelp
            // 
            this.btnAutomaticSubFoldersHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutomaticSubFoldersHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutomaticSubFoldersHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAutomaticSubFoldersHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnAutomaticSubFoldersHelp.Image")));
            this.btnAutomaticSubFoldersHelp.Location = new System.Drawing.Point(694, 253);
            this.btnAutomaticSubFoldersHelp.Name = "btnAutomaticSubFoldersHelp";
            this.btnAutomaticSubFoldersHelp.Size = new System.Drawing.Size(36, 36);
            this.btnAutomaticSubFoldersHelp.TabIndex = 154;
            this.btnAutomaticSubFoldersHelp.TabStop = false;
            this.btnAutomaticSubFoldersHelp.UseVisualStyleBackColor = true;
            this.btnAutomaticSubFoldersHelp.Click += new System.EventHandler(this.btnAutomaticSubFoldersHelp_Click);
            // 
            // txtAutomaticSubFolders
            // 
            this.txtAutomaticSubFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutomaticSubFolders.Location = new System.Drawing.Point(228, 253);
            this.txtAutomaticSubFolders.Multiline = true;
            this.txtAutomaticSubFolders.Name = "txtAutomaticSubFolders";
            this.txtAutomaticSubFolders.Size = new System.Drawing.Size(460, 80);
            this.txtAutomaticSubFolders.TabIndex = 153;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(215, 24);
            this.label5.TabIndex = 152;
            this.label5.Text = "Automatic Sub-folders";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(251, 179);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(102, 24);
            this.label32.TabIndex = 151;
            this.label32.Text = "Frequency";
            // 
            // cboAutoBackupFrequency
            // 
            this.cboAutoBackupFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAutoBackupFrequency.FormattingEnabled = true;
            this.cboAutoBackupFrequency.Items.AddRange(new object[] {
            "30 minutes",
            "1 hour",
            "2 hour",
            "4 hour"});
            this.cboAutoBackupFrequency.Location = new System.Drawing.Point(359, 176);
            this.cboAutoBackupFrequency.Name = "cboAutoBackupFrequency";
            this.cboAutoBackupFrequency.Size = new System.Drawing.Size(121, 32);
            this.cboAutoBackupFrequency.TabIndex = 150;
            // 
            // btnAutoBackupHelp
            // 
            this.btnAutoBackupHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutoBackupHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAutoBackupHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoBackupHelp.Image")));
            this.btnAutoBackupHelp.Location = new System.Drawing.Point(570, 137);
            this.btnAutoBackupHelp.Name = "btnAutoBackupHelp";
            this.btnAutoBackupHelp.Size = new System.Drawing.Size(36, 36);
            this.btnAutoBackupHelp.TabIndex = 149;
            this.btnAutoBackupHelp.TabStop = false;
            this.btnAutoBackupHelp.UseVisualStyleBackColor = true;
            this.btnAutoBackupHelp.Click += new System.EventHandler(this.btnAutoBackupHelp_Click);
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(7, 140);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(215, 24);
            this.label31.TabIndex = 147;
            this.label31.Text = "Automatic Backups";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAutomaticBackups
            // 
            this.chkAutomaticBackups.AutoSize = true;
            this.chkAutomaticBackups.Location = new System.Drawing.Point(228, 142);
            this.chkAutomaticBackups.Name = "chkAutomaticBackups";
            this.chkAutomaticBackups.Size = new System.Drawing.Size(342, 28);
            this.chkAutomaticBackups.TabIndex = 148;
            this.chkAutomaticBackups.Text = "Yes, make regular automatic backups";
            this.chkAutomaticBackups.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(7, 97);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(215, 24);
            this.label27.TabIndex = 145;
            this.label27.Text = "Prompt for initial save";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPromptForInitialSave
            // 
            this.chkPromptForInitialSave.Location = new System.Drawing.Point(228, 84);
            this.chkPromptForInitialSave.Name = "chkPromptForInitialSave";
            this.chkPromptForInitialSave.Size = new System.Drawing.Size(502, 52);
            this.chkPromptForInitialSave.TabIndex = 146;
            this.chkPromptForInitialSave.Text = "Yes, prompt after the incident name/number are added";
            this.chkPromptForInitialSave.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDefaultSaveLocation
            // 
            this.btnBrowseDefaultSaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDefaultSaveLocation.Location = new System.Drawing.Point(537, 46);
            this.btnBrowseDefaultSaveLocation.Name = "btnBrowseDefaultSaveLocation";
            this.btnBrowseDefaultSaveLocation.Size = new System.Drawing.Size(99, 36);
            this.btnBrowseDefaultSaveLocation.TabIndex = 144;
            this.btnBrowseDefaultSaveLocation.Text = "Browse...";
            this.btnBrowseDefaultSaveLocation.UseVisualStyleBackColor = true;
            this.btnBrowseDefaultSaveLocation.Click += new System.EventHandler(this.btnBrowseDefaultSaveLocation_Click);
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveLocation.Location = new System.Drawing.Point(228, 49);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.ReadOnly = true;
            this.txtSaveLocation.Size = new System.Drawing.Size(303, 29);
            this.txtSaveLocation.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 24);
            this.label4.TabIndex = 141;
            this.label4.Text = "Default Save Location";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 24);
            this.label2.TabIndex = 140;
            this.label2.Text = "Autosave";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(228, 15);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(256, 28);
            this.chkAutoSave.TabIndex = 143;
            this.chkAutoSave.Text = "Yes, auto save on changes";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // tbNetworking
            // 
            this.tbNetworking.Controls.Add(this.btnHelpDefaultPort);
            this.tbNetworking.Controls.Add(this.btnHelpDefaultToServer);
            this.tbNetworking.Controls.Add(this.numDefaultPortNumber);
            this.tbNetworking.Controls.Add(this.label26);
            this.tbNetworking.Controls.Add(this.chkDefaultToServer);
            this.tbNetworking.Controls.Add(this.label25);
            this.tbNetworking.Controls.Add(this.label24);
            this.tbNetworking.Controls.Add(this.btnTrustedDevicesHelp);
            this.tbNetworking.Controls.Add(this.btnRemoveTrustedDevice);
            this.tbNetworking.Controls.Add(this.lbTrustedDevices);
            this.tbNetworking.Location = new System.Drawing.Point(4, 33);
            this.tbNetworking.Name = "tbNetworking";
            this.tbNetworking.Size = new System.Drawing.Size(738, 551);
            this.tbNetworking.TabIndex = 2;
            this.tbNetworking.Text = "Networking";
            this.tbNetworking.UseVisualStyleBackColor = true;
            // 
            // btnHelpDefaultPort
            // 
            this.btnHelpDefaultPort.BackColor = System.Drawing.Color.Transparent;
            this.btnHelpDefaultPort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelpDefaultPort.Image = ((System.Drawing.Image)(resources.GetObject("btnHelpDefaultPort.Image")));
            this.btnHelpDefaultPort.Location = new System.Drawing.Point(264, 73);
            this.btnHelpDefaultPort.Name = "btnHelpDefaultPort";
            this.btnHelpDefaultPort.Size = new System.Drawing.Size(31, 32);
            this.btnHelpDefaultPort.TabIndex = 123;
            this.btnHelpDefaultPort.TabStop = false;
            this.btnHelpDefaultPort.UseVisualStyleBackColor = false;
            this.btnHelpDefaultPort.Click += new System.EventHandler(this.btnHelpDefaultPort_Click);
            // 
            // btnHelpDefaultToServer
            // 
            this.btnHelpDefaultToServer.BackColor = System.Drawing.Color.Transparent;
            this.btnHelpDefaultToServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHelpDefaultToServer.Image = ((System.Drawing.Image)(resources.GetObject("btnHelpDefaultToServer.Image")));
            this.btnHelpDefaultToServer.Location = new System.Drawing.Point(283, 38);
            this.btnHelpDefaultToServer.Name = "btnHelpDefaultToServer";
            this.btnHelpDefaultToServer.Size = new System.Drawing.Size(31, 32);
            this.btnHelpDefaultToServer.TabIndex = 122;
            this.btnHelpDefaultToServer.TabStop = false;
            this.btnHelpDefaultToServer.UseVisualStyleBackColor = false;
            this.btnHelpDefaultToServer.Click += new System.EventHandler(this.btnHelpDefaultToServer_Click);
            // 
            // numDefaultPortNumber
            // 
            this.numDefaultPortNumber.Location = new System.Drawing.Point(138, 75);
            this.numDefaultPortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDefaultPortNumber.Name = "numDefaultPortNumber";
            this.numDefaultPortNumber.Size = new System.Drawing.Size(120, 29);
            this.numDefaultPortNumber.TabIndex = 121;
            this.numDefaultPortNumber.Value = new decimal(new int[] {
            42999,
            0,
            0,
            0});
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(22, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(110, 24);
            this.label26.TabIndex = 120;
            this.label26.Text = "Port to use";
            // 
            // chkDefaultToServer
            // 
            this.chkDefaultToServer.AutoSize = true;
            this.chkDefaultToServer.Location = new System.Drawing.Point(28, 41);
            this.chkDefaultToServer.Name = "chkDefaultToServer";
            this.chkDefaultToServer.Size = new System.Drawing.Size(249, 28);
            this.chkDefaultToServer.TabIndex = 119;
            this.chkDefaultToServer.Text = "Always start up as a server";
            this.chkDefaultToServer.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(8, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(212, 29);
            this.label25.TabIndex = 118;
            this.label25.Text = "Network Settings";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 137);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(161, 24);
            this.label24.TabIndex = 117;
            this.label24.Text = "Trusted Devices";
            // 
            // btnTrustedDevicesHelp
            // 
            this.btnTrustedDevicesHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnTrustedDevicesHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTrustedDevicesHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnTrustedDevicesHelp.Image")));
            this.btnTrustedDevicesHelp.Location = new System.Drawing.Point(176, 133);
            this.btnTrustedDevicesHelp.Name = "btnTrustedDevicesHelp";
            this.btnTrustedDevicesHelp.Size = new System.Drawing.Size(31, 32);
            this.btnTrustedDevicesHelp.TabIndex = 116;
            this.btnTrustedDevicesHelp.TabStop = false;
            this.btnTrustedDevicesHelp.UseVisualStyleBackColor = false;
            this.btnTrustedDevicesHelp.Click += new System.EventHandler(this.btnTrustedDevicesHelp_Click);
            // 
            // btnRemoveTrustedDevice
            // 
            this.btnRemoveTrustedDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTrustedDevice.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_193_circle_empty_remove;
            this.btnRemoveTrustedDevice.Location = new System.Drawing.Point(440, 542);
            this.btnRemoveTrustedDevice.Name = "btnRemoveTrustedDevice";
            this.btnRemoveTrustedDevice.Size = new System.Drawing.Size(290, 42);
            this.btnRemoveTrustedDevice.TabIndex = 115;
            this.btnRemoveTrustedDevice.Text = "Remove Selected Device(s)";
            this.btnRemoveTrustedDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRemoveTrustedDevice.UseVisualStyleBackColor = true;
            this.btnRemoveTrustedDevice.Click += new System.EventHandler(this.btnRemoveTrustedDevice_Click);
            // 
            // lbTrustedDevices
            // 
            this.lbTrustedDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTrustedDevices.DisplayMember = "DeviceNameAndIP";
            this.lbTrustedDevices.FormattingEnabled = true;
            this.lbTrustedDevices.ItemHeight = 24;
            this.lbTrustedDevices.Location = new System.Drawing.Point(6, 167);
            this.lbTrustedDevices.Name = "lbTrustedDevices";
            this.lbTrustedDevices.ScrollAlwaysVisible = true;
            this.lbTrustedDevices.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTrustedDevices.Size = new System.Drawing.Size(724, 220);
            this.lbTrustedDevices.TabIndex = 114;
            this.lbTrustedDevices.ValueMember = "DeviceID";
            // 
            // tpResources
            // 
            this.tpResources.Controls.Add(this.numRedResourceTimeoutDays);
            this.tpResources.Controls.Add(this.numYellowResourceTimeoutDays);
            this.tpResources.Controls.Add(this.label10);
            this.tpResources.Controls.Add(this.label9);
            this.tpResources.Controls.Add(this.label8);
            this.tpResources.Location = new System.Drawing.Point(4, 33);
            this.tpResources.Margin = new System.Windows.Forms.Padding(2);
            this.tpResources.Name = "tpResources";
            this.tpResources.Padding = new System.Windows.Forms.Padding(2);
            this.tpResources.Size = new System.Drawing.Size(738, 551);
            this.tpResources.TabIndex = 4;
            this.tpResources.Text = "Resources";
            this.tpResources.UseVisualStyleBackColor = true;
            // 
            // numRedResourceTimeoutDays
            // 
            this.numRedResourceTimeoutDays.Location = new System.Drawing.Point(255, 81);
            this.numRedResourceTimeoutDays.Name = "numRedResourceTimeoutDays";
            this.numRedResourceTimeoutDays.Size = new System.Drawing.Size(120, 29);
            this.numRedResourceTimeoutDays.TabIndex = 131;
            // 
            // numYellowResourceTimeoutDays
            // 
            this.numYellowResourceTimeoutDays.Location = new System.Drawing.Point(255, 45);
            this.numYellowResourceTimeoutDays.Name = "numYellowResourceTimeoutDays";
            this.numYellowResourceTimeoutDays.Size = new System.Drawing.Size(120, 29);
            this.numYellowResourceTimeoutDays.TabIndex = 130;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(242, 32);
            this.label10.TabIndex = 129;
            this.label10.Text = "Red";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(242, 32);
            this.label9.TabIndex = 128;
            this.label9.Text = "Yellow";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(528, 32);
            this.label8.TabIndex = 127;
            this.label8.Text = "Highlight resources near their end of incident date";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(746, 660);
            this.splitContainer1.SplitterDistance = 588;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(14, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 51);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(612, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 51);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;,*.gif,*.bmp";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 660);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picReportLogo)).EndInit();
            this.tbFileManagement.ResumeLayout(false);
            this.tbFileManagement.PerformLayout();
            this.tbNetworking.ResumeLayout(false);
            this.tbNetworking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultPortNumber)).EndInit();
            this.tpResources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numRedResourceTimeoutDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYellowResourceTimeoutDays)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tbFileManagement;
        private System.Windows.Forms.TabPage tbNetworking;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboDefaultICSRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPositionFormat;
        private System.Windows.Forms.Button btnBrowseBackupLocation;
        private System.Windows.Forms.TextBox txtBackupLocation;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAutomaticSubFoldersHelp;
        private System.Windows.Forms.TextBox txtAutomaticSubFolders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cboAutoBackupFrequency;
        private System.Windows.Forms.Button btnAutoBackupHelp;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox chkAutomaticBackups;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chkPromptForInitialSave;
        private System.Windows.Forms.Button btnBrowseDefaultSaveLocation;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.Button btnHelpDefaultPort;
        private System.Windows.Forms.Button btnHelpDefaultToServer;
        private System.Windows.Forms.NumericUpDown numDefaultPortNumber;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chkDefaultToServer;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnTrustedDevicesHelp;
        private System.Windows.Forms.Button btnRemoveTrustedDevice;
        private System.Windows.Forms.ListBox lbTrustedDevices;
        private System.Windows.Forms.FolderBrowserDialog fbdDefaultSave;
        private System.Windows.Forms.RadioButton rbNumbersOrLetters;
        private System.Windows.Forms.RadioButton rbNumbersOnly;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDefaultProvince;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDateFormat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRemoveLogo;
        private System.Windows.Forms.Button btnChangeLogo;
        private System.Windows.Forms.PictureBox picReportLogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomControls.TextBoxRequiredControl txtOrganizationName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkShowTest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboFormSet;
        private System.Windows.Forms.TabPage tpResources;
        private System.Windows.Forms.NumericUpDown numRedResourceTimeoutDays;
        private System.Windows.Forms.NumericUpDown numYellowResourceTimeoutDays;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}