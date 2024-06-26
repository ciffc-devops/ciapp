﻿namespace Wildfire_ICS_Assist
{
    partial class PrintIncidentForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintIncidentForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTitlePageContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.picTitleImage = new System.Windows.Forms.PictureBox();
            this.chkTitlePage = new System.Windows.Forms.CheckBox();
            this.chkCheckInLists = new System.Windows.Forms.CheckBox();
            this.chkAssignmentDetails = new System.Windows.Forms.CheckBox();
            this.chkContacts = new System.Windows.Forms.CheckBox();
            this.chkNotes = new System.Windows.Forms.CheckBox();
            this.chkVerboseActivityLog = new System.Windows.Forms.CheckBox();
            this.chkActivityLog = new System.Windows.Forms.CheckBox();
            this.chkGeneralMessages = new System.Windows.Forms.CheckBox();
            this.chkAirOps = new System.Windows.Forms.CheckBox();
            this.chkSafetyMessage = new System.Windows.Forms.CheckBox();
            this.chkOrgChart = new System.Windows.Forms.CheckBox();
            this.chkMedPlan = new System.Windows.Forms.CheckBox();
            this.chkCommsPlan = new System.Windows.Forms.CheckBox();
            this.chkAssignments = new System.Windows.Forms.CheckBox();
            this.chkOrgAssignments = new System.Windows.Forms.CheckBox();
            this.chkFlattenPDF = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chkIncidentObjectives = new System.Windows.Forms.CheckBox();
            this.lblOpPeriodTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAsPDF = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browseFileControl3 = new Wildfire_ICS_Assist.CustomControls.BrowseFileControl();
            this.browseFileControl4 = new Wildfire_ICS_Assist.CustomControls.BrowseFileControl();
            this.browseFileControl2 = new Wildfire_ICS_Assist.CustomControls.BrowseFileControl();
            this.browseFileControl1 = new Wildfire_ICS_Assist.CustomControls.BrowseFileControl();
            this.txtCriticalMessage = new SpellBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlTitlePageContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleImage)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.browseFileControl3);
            this.splitContainer1.Panel1.Controls.Add(this.browseFileControl4);
            this.splitContainer1.Panel1.Controls.Add(this.browseFileControl2);
            this.splitContainer1.Panel1.Controls.Add(this.browseFileControl1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.pnlTitlePageContent);
            this.splitContainer1.Panel1.Controls.Add(this.chkTitlePage);
            this.splitContainer1.Panel1.Controls.Add(this.chkCheckInLists);
            this.splitContainer1.Panel1.Controls.Add(this.chkAssignmentDetails);
            this.splitContainer1.Panel1.Controls.Add(this.chkContacts);
            this.splitContainer1.Panel1.Controls.Add(this.chkNotes);
            this.splitContainer1.Panel1.Controls.Add(this.chkVerboseActivityLog);
            this.splitContainer1.Panel1.Controls.Add(this.chkActivityLog);
            this.splitContainer1.Panel1.Controls.Add(this.chkGeneralMessages);
            this.splitContainer1.Panel1.Controls.Add(this.chkAirOps);
            this.splitContainer1.Panel1.Controls.Add(this.chkSafetyMessage);
            this.splitContainer1.Panel1.Controls.Add(this.chkOrgChart);
            this.splitContainer1.Panel1.Controls.Add(this.chkMedPlan);
            this.splitContainer1.Panel1.Controls.Add(this.chkCommsPlan);
            this.splitContainer1.Panel1.Controls.Add(this.chkAssignments);
            this.splitContainer1.Panel1.Controls.Add(this.chkOrgAssignments);
            this.splitContainer1.Panel1.Controls.Add(this.chkFlattenPDF);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.chkIncidentObjectives);
            this.splitContainer1.Panel1.Controls.Add(this.lblOpPeriodTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveAsPDF);
            this.splitContainer1.Size = new System.Drawing.Size(865, 779);
            this.splitContainer1.SplitterDistance = 702;
            this.splitContainer1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 24);
            this.label4.TabIndex = 40;
            this.label4.Text = "Additional PDFs";
            // 
            // pnlTitlePageContent
            // 
            this.pnlTitlePageContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTitlePageContent.Controls.Add(this.txtCriticalMessage);
            this.pnlTitlePageContent.Controls.Add(this.label1);
            this.pnlTitlePageContent.Controls.Add(this.btnRemoveImage);
            this.pnlTitlePageContent.Controls.Add(this.btnSelectImage);
            this.pnlTitlePageContent.Controls.Add(this.label3);
            this.pnlTitlePageContent.Controls.Add(this.picTitleImage);
            this.pnlTitlePageContent.Location = new System.Drawing.Point(3, 557);
            this.pnlTitlePageContent.Name = "pnlTitlePageContent";
            this.pnlTitlePageContent.Size = new System.Drawing.Size(862, 141);
            this.pnlTitlePageContent.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title Page Image";
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.Location = new System.Drawing.Point(168, 79);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(112, 36);
            this.btnRemoveImage.TabIndex = 5;
            this.btnRemoveImage.Text = "Remove";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(168, 37);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(112, 36);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Text = "Select...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Title page message for this operational period";
            // 
            // picTitleImage
            // 
            this.picTitleImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTitleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTitleImage.Location = new System.Drawing.Point(37, 37);
            this.picTitleImage.Name = "picTitleImage";
            this.picTitleImage.Size = new System.Drawing.Size(123, 89);
            this.picTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitleImage.TabIndex = 3;
            this.picTitleImage.TabStop = false;
            // 
            // chkTitlePage
            // 
            this.chkTitlePage.AutoSize = true;
            this.chkTitlePage.Checked = true;
            this.chkTitlePage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTitlePage.Location = new System.Drawing.Point(46, 121);
            this.chkTitlePage.Name = "chkTitlePage";
            this.chkTitlePage.Size = new System.Drawing.Size(113, 28);
            this.chkTitlePage.TabIndex = 38;
            this.chkTitlePage.Text = "Title Page";
            this.chkTitlePage.UseVisualStyleBackColor = true;
            this.chkTitlePage.CheckedChanged += new System.EventHandler(this.chkTitlePage_CheckedChanged);
            // 
            // chkCheckInLists
            // 
            this.chkCheckInLists.AutoSize = true;
            this.chkCheckInLists.Location = new System.Drawing.Point(313, 291);
            this.chkCheckInLists.Name = "chkCheckInLists";
            this.chkCheckInLists.Size = new System.Drawing.Size(190, 28);
            this.chkCheckInLists.TabIndex = 37;
            this.chkCheckInLists.Text = "211 - Check In Lists";
            this.chkCheckInLists.UseVisualStyleBackColor = true;
            // 
            // chkAssignmentDetails
            // 
            this.chkAssignmentDetails.AutoSize = true;
            this.chkAssignmentDetails.Location = new System.Drawing.Point(313, 223);
            this.chkAssignmentDetails.Name = "chkAssignmentDetails";
            this.chkAssignmentDetails.Size = new System.Drawing.Size(237, 28);
            this.chkAssignmentDetails.TabIndex = 33;
            this.chkAssignmentDetails.Text = "204A - ST/TF/Grp Details";
            this.chkAssignmentDetails.UseVisualStyleBackColor = true;
            // 
            // chkContacts
            // 
            this.chkContacts.AutoSize = true;
            this.chkContacts.Location = new System.Drawing.Point(313, 257);
            this.chkContacts.Name = "chkContacts";
            this.chkContacts.Size = new System.Drawing.Size(261, 28);
            this.chkContacts.TabIndex = 32;
            this.chkContacts.Text = "205A - Communications List";
            this.chkContacts.UseVisualStyleBackColor = true;
            // 
            // chkNotes
            // 
            this.chkNotes.AutoSize = true;
            this.chkNotes.Location = new System.Drawing.Point(617, 223);
            this.chkNotes.Name = "chkNotes";
            this.chkNotes.Size = new System.Drawing.Size(166, 28);
            this.chkNotes.TabIndex = 30;
            this.chkNotes.Text = "Additional Notes";
            this.chkNotes.UseVisualStyleBackColor = true;
            // 
            // chkVerboseActivityLog
            // 
            this.chkVerboseActivityLog.AutoSize = true;
            this.chkVerboseActivityLog.Location = new System.Drawing.Point(617, 189);
            this.chkVerboseActivityLog.Name = "chkVerboseActivityLog";
            this.chkVerboseActivityLog.Size = new System.Drawing.Size(209, 28);
            this.chkVerboseActivityLog.TabIndex = 29;
            this.chkVerboseActivityLog.Text = "Verbose Activity Logs";
            this.chkVerboseActivityLog.UseVisualStyleBackColor = true;
            // 
            // chkActivityLog
            // 
            this.chkActivityLog.AutoSize = true;
            this.chkActivityLog.Location = new System.Drawing.Point(617, 155);
            this.chkActivityLog.Name = "chkActivityLog";
            this.chkActivityLog.Size = new System.Drawing.Size(190, 28);
            this.chkActivityLog.TabIndex = 28;
            this.chkActivityLog.Text = "214 - Activity Log(s)";
            this.chkActivityLog.UseVisualStyleBackColor = true;
            // 
            // chkGeneralMessages
            // 
            this.chkGeneralMessages.AutoSize = true;
            this.chkGeneralMessages.Location = new System.Drawing.Point(617, 121);
            this.chkGeneralMessages.Name = "chkGeneralMessages";
            this.chkGeneralMessages.Size = new System.Drawing.Size(245, 28);
            this.chkGeneralMessages.TabIndex = 27;
            this.chkGeneralMessages.Text = "213 - General Message(s)";
            this.chkGeneralMessages.UseVisualStyleBackColor = true;
            // 
            // chkAirOps
            // 
            this.chkAirOps.AutoSize = true;
            this.chkAirOps.Location = new System.Drawing.Point(313, 189);
            this.chkAirOps.Name = "chkAirOps";
            this.chkAirOps.Size = new System.Drawing.Size(223, 28);
            this.chkAirOps.TabIndex = 26;
            this.chkAirOps.Text = "220 - Air Ops Summary";
            this.chkAirOps.UseVisualStyleBackColor = true;
            // 
            // chkSafetyMessage
            // 
            this.chkSafetyMessage.AutoSize = true;
            this.chkSafetyMessage.Location = new System.Drawing.Point(313, 155);
            this.chkSafetyMessage.Name = "chkSafetyMessage";
            this.chkSafetyMessage.Size = new System.Drawing.Size(270, 28);
            this.chkSafetyMessage.TabIndex = 24;
            this.chkSafetyMessage.Text = "208 - Safety Message/Plan(s)";
            this.chkSafetyMessage.UseVisualStyleBackColor = true;
            // 
            // chkOrgChart
            // 
            this.chkOrgChart.AutoSize = true;
            this.chkOrgChart.Location = new System.Drawing.Point(313, 121);
            this.chkOrgChart.Name = "chkOrgChart";
            this.chkOrgChart.Size = new System.Drawing.Size(230, 28);
            this.chkOrgChart.TabIndex = 23;
            this.chkOrgChart.Text = "207 - Organization Chart";
            this.chkOrgChart.UseVisualStyleBackColor = true;
            // 
            // chkMedPlan
            // 
            this.chkMedPlan.AutoSize = true;
            this.chkMedPlan.Location = new System.Drawing.Point(46, 291);
            this.chkMedPlan.Name = "chkMedPlan";
            this.chkMedPlan.Size = new System.Drawing.Size(183, 28);
            this.chkMedPlan.TabIndex = 22;
            this.chkMedPlan.Text = "206 - Medical Plan";
            this.chkMedPlan.UseVisualStyleBackColor = true;
            // 
            // chkCommsPlan
            // 
            this.chkCommsPlan.AutoSize = true;
            this.chkCommsPlan.Location = new System.Drawing.Point(46, 257);
            this.chkCommsPlan.Name = "chkCommsPlan";
            this.chkCommsPlan.Size = new System.Drawing.Size(258, 28);
            this.chkCommsPlan.TabIndex = 21;
            this.chkCommsPlan.Text = "205 - Communications Plan";
            this.chkCommsPlan.UseVisualStyleBackColor = true;
            // 
            // chkAssignments
            // 
            this.chkAssignments.AutoSize = true;
            this.chkAssignments.Location = new System.Drawing.Point(46, 223);
            this.chkAssignments.Name = "chkAssignments";
            this.chkAssignments.Size = new System.Drawing.Size(206, 28);
            this.chkAssignments.TabIndex = 20;
            this.chkAssignments.Text = "204 - Assignment List";
            this.chkAssignments.UseVisualStyleBackColor = true;
            // 
            // chkOrgAssignments
            // 
            this.chkOrgAssignments.AutoSize = true;
            this.chkOrgAssignments.Location = new System.Drawing.Point(46, 189);
            this.chkOrgAssignments.Name = "chkOrgAssignments";
            this.chkOrgAssignments.Size = new System.Drawing.Size(243, 28);
            this.chkOrgAssignments.TabIndex = 19;
            this.chkOrgAssignments.Text = "203 - Org Assignment List";
            this.chkOrgAssignments.UseVisualStyleBackColor = true;
            // 
            // chkFlattenPDF
            // 
            this.chkFlattenPDF.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFlattenPDF.AutoSize = true;
            this.chkFlattenPDF.BackColor = System.Drawing.Color.Transparent;
            this.chkFlattenPDF.Checked = true;
            this.chkFlattenPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFlattenPDF.FlatAppearance.BorderSize = 0;
            this.chkFlattenPDF.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.chkFlattenPDF.ImageIndex = 1;
            this.chkFlattenPDF.ImageList = this.imageList1;
            this.chkFlattenPDF.Location = new System.Drawing.Point(34, 41);
            this.chkFlattenPDF.Name = "chkFlattenPDF";
            this.chkFlattenPDF.Size = new System.Drawing.Size(282, 38);
            this.chkFlattenPDF.TabIndex = 18;
            this.chkFlattenPDF.Text = "All PDF fields will be locked";
            this.chkFlattenPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkFlattenPDF.UseVisualStyleBackColor = false;
            this.chkFlattenPDF.CheckedChanged += new System.EventHandler(this.chkFlattenPDF_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "glyphicons-basic-218-lock-open.png");
            this.imageList1.Images.SetKeyName(1, "glyphicons-basic-217-lock.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Include...";
            // 
            // chkIncidentObjectives
            // 
            this.chkIncidentObjectives.AutoSize = true;
            this.chkIncidentObjectives.Location = new System.Drawing.Point(46, 155);
            this.chkIncidentObjectives.Name = "chkIncidentObjectives";
            this.chkIncidentObjectives.Size = new System.Drawing.Size(234, 28);
            this.chkIncidentObjectives.TabIndex = 14;
            this.chkIncidentObjectives.Text = "202 - Incident Objectives";
            this.chkIncidentObjectives.UseVisualStyleBackColor = true;
            // 
            // lblOpPeriodTitle
            // 
            this.lblOpPeriodTitle.AutoSize = true;
            this.lblOpPeriodTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpPeriodTitle.Location = new System.Drawing.Point(12, 9);
            this.lblOpPeriodTitle.Name = "lblOpPeriodTitle";
            this.lblOpPeriodTitle.Size = new System.Drawing.Size(331, 29);
            this.lblOpPeriodTitle.TabIndex = 13;
            this.lblOpPeriodTitle.Text = "Print Operational Period 22";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(12, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 58);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAsPDF
            // 
            this.btnSaveAsPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAsPDF.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnSaveAsPDF.Location = new System.Drawing.Point(677, 7);
            this.btnSaveAsPDF.Name = "btnSaveAsPDF";
            this.btnSaveAsPDF.Size = new System.Drawing.Size(178, 58);
            this.btnSaveAsPDF.TabIndex = 15;
            this.btnSaveAsPDF.Text = "Save as a PDF";
            this.btnSaveAsPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAsPDF.UseVisualStyleBackColor = true;
            this.btnSaveAsPDF.Click += new System.EventHandler(this.btnSaveAsPDF_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;,*.gif,*.bmp";
            // 
            // browseFileControl3
            // 
            this.browseFileControl3.FileName = null;
            this.browseFileControl3.Filter = "PDFs|*.pdf";
            this.browseFileControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFileControl3.Location = new System.Drawing.Point(15, 460);
            this.browseFileControl3.Margin = new System.Windows.Forms.Padding(6);
            this.browseFileControl3.MinimumSize = new System.Drawing.Size(0, 44);
            this.browseFileControl3.Name = "browseFileControl3";
            this.browseFileControl3.Size = new System.Drawing.Size(838, 44);
            this.browseFileControl3.TabIndex = 44;
            // 
            // browseFileControl4
            // 
            this.browseFileControl4.FileName = null;
            this.browseFileControl4.Filter = "PDFs|*.pdf";
            this.browseFileControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFileControl4.Location = new System.Drawing.Point(15, 508);
            this.browseFileControl4.Margin = new System.Windows.Forms.Padding(6);
            this.browseFileControl4.MinimumSize = new System.Drawing.Size(0, 44);
            this.browseFileControl4.Name = "browseFileControl4";
            this.browseFileControl4.Size = new System.Drawing.Size(838, 44);
            this.browseFileControl4.TabIndex = 43;
            // 
            // browseFileControl2
            // 
            this.browseFileControl2.FileName = null;
            this.browseFileControl2.Filter = "PDFs|*.pdf";
            this.browseFileControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFileControl2.Location = new System.Drawing.Point(15, 412);
            this.browseFileControl2.Margin = new System.Windows.Forms.Padding(6);
            this.browseFileControl2.MinimumSize = new System.Drawing.Size(0, 44);
            this.browseFileControl2.Name = "browseFileControl2";
            this.browseFileControl2.Size = new System.Drawing.Size(838, 44);
            this.browseFileControl2.TabIndex = 42;
            // 
            // browseFileControl1
            // 
            this.browseFileControl1.FileName = null;
            this.browseFileControl1.Filter = "PDFs|*.pdf";
            this.browseFileControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseFileControl1.Location = new System.Drawing.Point(15, 364);
            this.browseFileControl1.Margin = new System.Windows.Forms.Padding(6);
            this.browseFileControl1.MinimumSize = new System.Drawing.Size(0, 44);
            this.browseFileControl1.Name = "browseFileControl1";
            this.browseFileControl1.Size = new System.Drawing.Size(838, 44);
            this.browseFileControl1.TabIndex = 41;
            // 
            // txtCriticalMessage
            // 
            this.txtCriticalMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCriticalMessage.Location = new System.Drawing.Point(310, 37);
            this.txtCriticalMessage.Multiline = true;
            this.txtCriticalMessage.Name = "txtCriticalMessage";
            this.txtCriticalMessage.Size = new System.Drawing.Size(542, 101);
            this.txtCriticalMessage.TabIndex = 37;
            this.txtCriticalMessage.WordWrap = true;
            this.txtCriticalMessage.Leave += new System.EventHandler(this.txtCriticalMessage_Leave_1);
            this.txtCriticalMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(608, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "*These documents will be included in the PDF, but not saved within this software " +
    "for other users";
            // 
            // PrintIncidentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 779);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(666, 665);
            this.Name = "PrintIncidentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Incident Action Plan";
            this.Load += new System.EventHandler(this.PrintIncidentForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlTitlePageContent.ResumeLayout(false);
            this.pnlTitlePageContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkFlattenPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncidentObjectives;
        private System.Windows.Forms.Label lblOpPeriodTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAsPDF;
        private System.Windows.Forms.CheckBox chkAirOps;
        private System.Windows.Forms.CheckBox chkSafetyMessage;
        private System.Windows.Forms.CheckBox chkOrgChart;
        private System.Windows.Forms.CheckBox chkMedPlan;
        private System.Windows.Forms.CheckBox chkCommsPlan;
        private System.Windows.Forms.CheckBox chkAssignments;
        private System.Windows.Forms.CheckBox chkOrgAssignments;
        private System.Windows.Forms.CheckBox chkNotes;
        private System.Windows.Forms.CheckBox chkVerboseActivityLog;
        private System.Windows.Forms.CheckBox chkActivityLog;
        private System.Windows.Forms.CheckBox chkGeneralMessages;
        private System.Windows.Forms.CheckBox chkContacts;
        private System.Windows.Forms.CheckBox chkAssignmentDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTitleImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkCheckInLists;
        private System.Windows.Forms.CheckBox chkTitlePage;
        private System.Windows.Forms.Panel pnlTitlePageContent;
        private SpellBox txtCriticalMessage;
        private System.Windows.Forms.Label label4;
        private CustomControls.BrowseFileControl browseFileControl2;
        private CustomControls.BrowseFileControl browseFileControl1;
        private CustomControls.BrowseFileControl browseFileControl3;
        private CustomControls.BrowseFileControl browseFileControl4;
        private System.Windows.Forms.Label label5;
    }
}