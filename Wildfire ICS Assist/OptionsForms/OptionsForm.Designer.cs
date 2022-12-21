﻿namespace Wildfire_ICS_Assist.OptionsForms
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.tbComms = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbNetworking = new System.Windows.Forms.TabPage();
            this.tbFileManagement = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPositionFormat = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboDefaultICSRole = new System.Windows.Forms.ComboBox();
            this.txtICPCallSign = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboRepeater = new System.Windows.Forms.ComboBox();
            this.cboEmergencyChannel = new System.Windows.Forms.ComboBox();
            this.cboSecondaryChannel = new System.Windows.Forms.ComboBox();
            this.cboPrimaryChannel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
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
            this.tabControl1.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.tbComms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tbFileManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbGeneral);
            this.tabControl1.Controls.Add(this.tbFileManagement);
            this.tabControl1.Controls.Add(this.tbComms);
            this.tabControl1.Controls.Add(this.tbNetworking);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 586);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tbGeneral
            // 
            this.tbGeneral.BackColor = System.Drawing.Color.Transparent;
            this.tbGeneral.Controls.Add(this.label28);
            this.tbGeneral.Controls.Add(this.cboDefaultICSRole);
            this.tbGeneral.Controls.Add(this.label3);
            this.tbGeneral.Controls.Add(this.cboPositionFormat);
            this.tbGeneral.Location = new System.Drawing.Point(4, 33);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneral.Size = new System.Drawing.Size(624, 556);
            this.tbGeneral.TabIndex = 0;
            this.tbGeneral.Text = "General";
            // 
            // tbComms
            // 
            this.tbComms.Controls.Add(this.label16);
            this.tbComms.Controls.Add(this.cboRepeater);
            this.tbComms.Controls.Add(this.cboEmergencyChannel);
            this.tbComms.Controls.Add(this.cboSecondaryChannel);
            this.tbComms.Controls.Add(this.cboPrimaryChannel);
            this.tbComms.Controls.Add(this.label10);
            this.tbComms.Controls.Add(this.label11);
            this.tbComms.Controls.Add(this.label13);
            this.tbComms.Controls.Add(this.label14);
            this.tbComms.Controls.Add(this.txtICPCallSign);
            this.tbComms.Controls.Add(this.label15);
            this.tbComms.Location = new System.Drawing.Point(4, 33);
            this.tbComms.Name = "tbComms";
            this.tbComms.Padding = new System.Windows.Forms.Padding(3);
            this.tbComms.Size = new System.Drawing.Size(624, 556);
            this.tbComms.TabIndex = 1;
            this.tbComms.Text = "Communications";
            this.tbComms.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Size = new System.Drawing.Size(746, 656);
            this.splitContainer1.SplitterDistance = 586;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(612, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 51);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(14, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 51);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbNetworking
            // 
            this.tbNetworking.Location = new System.Drawing.Point(4, 33);
            this.tbNetworking.Name = "tbNetworking";
            this.tbNetworking.Size = new System.Drawing.Size(675, 533);
            this.tbNetworking.TabIndex = 2;
            this.tbNetworking.Text = "Networking";
            this.tbNetworking.UseVisualStyleBackColor = true;
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
            this.tbFileManagement.Size = new System.Drawing.Size(738, 549);
            this.tbFileManagement.TabIndex = 3;
            this.tbFileManagement.Text = "File Management";
            this.tbFileManagement.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 99;
            this.label3.Text = "Position Format";
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
            this.cboPositionFormat.Location = new System.Drawing.Point(209, 6);
            this.cboPositionFormat.Name = "cboPositionFormat";
            this.cboPositionFormat.Size = new System.Drawing.Size(407, 32);
            this.cboPositionFormat.TabIndex = 100;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 47);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(145, 24);
            this.label28.TabIndex = 113;
            this.label28.Text = "Default ICS Role";
            // 
            // cboDefaultICSRole
            // 
            this.cboDefaultICSRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefaultICSRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefaultICSRole.FormattingEnabled = true;
            this.cboDefaultICSRole.Items.AddRange(new object[] {
            "UTM",
            "Decimal Degrees",
            "Degrees Decimal Minutes",
            "Degrees Minutes Seconds",
            "MGRS"});
            this.cboDefaultICSRole.Location = new System.Drawing.Point(209, 44);
            this.cboDefaultICSRole.Name = "cboDefaultICSRole";
            this.cboDefaultICSRole.Size = new System.Drawing.Size(407, 32);
            this.cboDefaultICSRole.TabIndex = 114;
            // 
            // txtICPCallSign
            // 
            this.txtICPCallSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtICPCallSign.Location = new System.Drawing.Point(139, 208);
            this.txtICPCallSign.Margin = new System.Windows.Forms.Padding(5);
            this.txtICPCallSign.Name = "txtICPCallSign";
            this.txtICPCallSign.Size = new System.Drawing.Size(477, 29);
            this.txtICPCallSign.TabIndex = 95;
            this.txtICPCallSign.Text = "BASE";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 212);
            this.label15.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 24);
            this.label15.TabIndex = 94;
            this.label15.Text = "ICP Call Sign";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(295, 29);
            this.label16.TabIndex = 114;
            this.label16.Text = "Default Communications";
            // 
            // cboRepeater
            // 
            this.cboRepeater.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRepeater.BackColor = System.Drawing.Color.White;
            this.cboRepeater.DisplayMember = "SystemWithID";
            this.cboRepeater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRepeater.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRepeater.FormattingEnabled = true;
            this.cboRepeater.Location = new System.Drawing.Point(139, 168);
            this.cboRepeater.Name = "cboRepeater";
            this.cboRepeater.Size = new System.Drawing.Size(477, 32);
            this.cboRepeater.TabIndex = 109;
            this.cboRepeater.ValueMember = "ItemID";
            // 
            // cboEmergencyChannel
            // 
            this.cboEmergencyChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEmergencyChannel.BackColor = System.Drawing.Color.White;
            this.cboEmergencyChannel.DisplayMember = "SystemWithID";
            this.cboEmergencyChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmergencyChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmergencyChannel.FormattingEnabled = true;
            this.cboEmergencyChannel.Location = new System.Drawing.Point(139, 130);
            this.cboEmergencyChannel.Name = "cboEmergencyChannel";
            this.cboEmergencyChannel.Size = new System.Drawing.Size(477, 32);
            this.cboEmergencyChannel.TabIndex = 108;
            this.cboEmergencyChannel.ValueMember = "ItemID";
            // 
            // cboSecondaryChannel
            // 
            this.cboSecondaryChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSecondaryChannel.BackColor = System.Drawing.Color.White;
            this.cboSecondaryChannel.DisplayMember = "SystemWithID";
            this.cboSecondaryChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecondaryChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSecondaryChannel.FormattingEnabled = true;
            this.cboSecondaryChannel.Location = new System.Drawing.Point(139, 92);
            this.cboSecondaryChannel.Name = "cboSecondaryChannel";
            this.cboSecondaryChannel.Size = new System.Drawing.Size(477, 32);
            this.cboSecondaryChannel.TabIndex = 107;
            this.cboSecondaryChannel.ValueMember = "ItemID";
            // 
            // cboPrimaryChannel
            // 
            this.cboPrimaryChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrimaryChannel.BackColor = System.Drawing.Color.White;
            this.cboPrimaryChannel.DisplayMember = "SystemWithID";
            this.cboPrimaryChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrimaryChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPrimaryChannel.FormattingEnabled = true;
            this.cboPrimaryChannel.Location = new System.Drawing.Point(139, 54);
            this.cboPrimaryChannel.Name = "cboPrimaryChannel";
            this.cboPrimaryChannel.Size = new System.Drawing.Size(477, 32);
            this.cboPrimaryChannel.TabIndex = 106;
            this.cboPrimaryChannel.ValueMember = "ItemID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 171);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 24);
            this.label10.TabIndex = 113;
            this.label10.Text = "Repeater(s)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 133);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 24);
            this.label11.TabIndex = 112;
            this.label11.Text = "Emergency";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 24);
            this.label13.TabIndex = 111;
            this.label13.Text = "Secondary";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 57);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 24);
            this.label14.TabIndex = 110;
            this.label14.Text = "Primary Ch.";
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
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBackupLocation.Location = new System.Drawing.Point(212, 214);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.ReadOnly = true;
            this.txtBackupLocation.Size = new System.Drawing.Size(408, 29);
            this.txtBackupLocation.TabIndex = 157;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(12, 217);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(149, 24);
            this.label34.TabIndex = 156;
            this.label34.Text = "Backup Location";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 80);
            this.label6.TabIndex = 155;
            this.label6.Text = "Separate each folder name with a comma\r\ne.g. GPX, Maps, Photos";
            // 
            // btnAutomaticSubFoldersHelp
            // 
            this.btnAutomaticSubFoldersHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutomaticSubFoldersHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutomaticSubFoldersHelp.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_635_circle_question;
            this.btnAutomaticSubFoldersHelp.Location = new System.Drawing.Point(694, 287);
            this.btnAutomaticSubFoldersHelp.Name = "btnAutomaticSubFoldersHelp";
            this.btnAutomaticSubFoldersHelp.Size = new System.Drawing.Size(36, 36);
            this.btnAutomaticSubFoldersHelp.TabIndex = 154;
            this.btnAutomaticSubFoldersHelp.TabStop = false;
            this.btnAutomaticSubFoldersHelp.UseVisualStyleBackColor = true;
            // 
            // txtAutomaticSubFolders
            // 
            this.txtAutomaticSubFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAutomaticSubFolders.Location = new System.Drawing.Point(212, 287);
            this.txtAutomaticSubFolders.Multiline = true;
            this.txtAutomaticSubFolders.Name = "txtAutomaticSubFolders";
            this.txtAutomaticSubFolders.Size = new System.Drawing.Size(476, 80);
            this.txtAutomaticSubFolders.TabIndex = 153;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 24);
            this.label5.TabIndex = 152;
            this.label5.Text = "Automatic Sub-folders";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(235, 179);
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
            this.cboAutoBackupFrequency.Location = new System.Drawing.Point(343, 176);
            this.cboAutoBackupFrequency.Name = "cboAutoBackupFrequency";
            this.cboAutoBackupFrequency.Size = new System.Drawing.Size(121, 32);
            this.cboAutoBackupFrequency.TabIndex = 150;
            // 
            // btnAutoBackupHelp
            // 
            this.btnAutoBackupHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutoBackupHelp.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_635_circle_question;
            this.btnAutoBackupHelp.Location = new System.Drawing.Point(554, 137);
            this.btnAutoBackupHelp.Name = "btnAutoBackupHelp";
            this.btnAutoBackupHelp.Size = new System.Drawing.Size(36, 36);
            this.btnAutoBackupHelp.TabIndex = 149;
            this.btnAutoBackupHelp.TabStop = false;
            this.btnAutoBackupHelp.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(12, 140);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(170, 24);
            this.label31.TabIndex = 147;
            this.label31.Text = "Automatic Backups";
            // 
            // chkAutomaticBackups
            // 
            this.chkAutomaticBackups.AutoSize = true;
            this.chkAutomaticBackups.Location = new System.Drawing.Point(208, 142);
            this.chkAutomaticBackups.Name = "chkAutomaticBackups";
            this.chkAutomaticBackups.Size = new System.Drawing.Size(342, 28);
            this.chkAutomaticBackups.TabIndex = 148;
            this.chkAutomaticBackups.Text = "Yes, make regular automatic backups";
            this.chkAutomaticBackups.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 97);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(186, 24);
            this.label27.TabIndex = 145;
            this.label27.Text = "Prompt for initial save";
            // 
            // chkPromptForInitialSave
            // 
            this.chkPromptForInitialSave.Location = new System.Drawing.Point(212, 84);
            this.chkPromptForInitialSave.Name = "chkPromptForInitialSave";
            this.chkPromptForInitialSave.Size = new System.Drawing.Size(410, 52);
            this.chkPromptForInitialSave.TabIndex = 146;
            this.chkPromptForInitialSave.Text = "Yes, prompt after the task name and number are added";
            this.chkPromptForInitialSave.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDefaultSaveLocation
            // 
            this.btnBrowseDefaultSaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDefaultSaveLocation.Location = new System.Drawing.Point(521, 46);
            this.btnBrowseDefaultSaveLocation.Name = "btnBrowseDefaultSaveLocation";
            this.btnBrowseDefaultSaveLocation.Size = new System.Drawing.Size(99, 36);
            this.btnBrowseDefaultSaveLocation.TabIndex = 144;
            this.btnBrowseDefaultSaveLocation.Text = "Browse...";
            this.btnBrowseDefaultSaveLocation.UseVisualStyleBackColor = true;
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSaveLocation.Location = new System.Drawing.Point(212, 49);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.ReadOnly = true;
            this.txtSaveLocation.Size = new System.Drawing.Size(303, 29);
            this.txtSaveLocation.TabIndex = 142;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 24);
            this.label4.TabIndex = 141;
            this.label4.Text = "Default Save Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 140;
            this.label2.Text = "Autosave";
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(208, 15);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(256, 28);
            this.chkAutoSave.TabIndex = 143;
            this.chkAutoSave.Text = "Yes, auto save on changes";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(746, 656);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            this.tbComms.ResumeLayout(false);
            this.tbComms.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tbFileManagement.ResumeLayout(false);
            this.tbFileManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.TabPage tbComms;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboRepeater;
        private System.Windows.Forms.ComboBox cboEmergencyChannel;
        private System.Windows.Forms.ComboBox cboSecondaryChannel;
        private System.Windows.Forms.ComboBox cboPrimaryChannel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtICPCallSign;
        private System.Windows.Forms.Label label15;
    }
}