namespace Wildfire_ICS_Assist
{
    partial class TeamAssignmentEditForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnApplyTemplate = new System.Windows.Forms.Button();
            this.cboAssignmentTemplates = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSetToNextAssignmentNumber = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numAssignmentNumber = new System.Windows.Forms.NumericUpDown();
            this.cboReportsTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAndPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.editTeamAssignmentTemplateControl1 = new Wildfire_ICS_Assist.CustomControls.EditTeamAssignmentTemplateControl();
            this.cpEquipment = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cpComms = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboComms4 = new System.Windows.Forms.ComboBox();
            this.cboComms3 = new System.Windows.Forms.ComboBox();
            this.cboComms2 = new System.Windows.Forms.ComboBox();
            this.cboComms1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cpPersonnel = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.label6 = new System.Windows.Forms.Label();
            this.numPersonnelRequired = new System.Windows.Forms.NumericUpDown();
            this.cboPerson10 = new System.Windows.Forms.ComboBox();
            this.cboPerson8 = new System.Windows.Forms.ComboBox();
            this.cboPerson6 = new System.Windows.Forms.ComboBox();
            this.cboPerson4 = new System.Windows.Forms.ComboBox();
            this.cboPerson2 = new System.Windows.Forms.ComboBox();
            this.cboPerson11 = new System.Windows.Forms.ComboBox();
            this.cboPerson9 = new System.Windows.Forms.ComboBox();
            this.cboPerson7 = new System.Windows.Forms.ComboBox();
            this.cboPerson5 = new System.Windows.Forms.ComboBox();
            this.cboPerson3 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPerson1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTemplateHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAssignmentNumber)).BeginInit();
            this.cpComms.SuspendLayout();
            this.cpPersonnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPersonnelRequired)).BeginInit();
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(10, 400);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveAndPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(1175, 614);
            this.splitContainer1.SplitterDistance = 551;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.btnTemplateHelp);
            this.splitContainer2.Panel1.Controls.Add(this.btnApplyTemplate);
            this.splitContainer2.Panel1.Controls.Add(this.cboAssignmentTemplates);
            this.splitContainer2.Panel1.Controls.Add(this.label14);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnSetToNextAssignmentNumber);
            this.splitContainer2.Panel2.Controls.Add(this.editTeamAssignmentTemplateControl1);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.numAssignmentNumber);
            this.splitContainer2.Panel2.Controls.Add(this.cboReportsTo);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.cpEquipment);
            this.splitContainer2.Panel2.Controls.Add(this.cpComms);
            this.splitContainer2.Panel2.Controls.Add(this.cpPersonnel);
            this.splitContainer2.Size = new System.Drawing.Size(1175, 551);
            this.splitContainer2.SplitterDistance = 55;
            this.splitContainer2.TabIndex = 105;
            // 
            // btnApplyTemplate
            // 
            this.btnApplyTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyTemplate.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_613_paste;
            this.btnApplyTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnApplyTemplate.Location = new System.Drawing.Point(918, 7);
            this.btnApplyTemplate.Margin = new System.Windows.Forms.Padding(6);
            this.btnApplyTemplate.Name = "btnApplyTemplate";
            this.btnApplyTemplate.Size = new System.Drawing.Size(199, 40);
            this.btnApplyTemplate.TabIndex = 107;
            this.btnApplyTemplate.Text = "Apply Template";
            this.btnApplyTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApplyTemplate.UseVisualStyleBackColor = true;
            // 
            // cboAssignmentTemplates
            // 
            this.cboAssignmentTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssignmentTemplates.DisplayMember = "AssignmentName";
            this.cboAssignmentTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssignmentTemplates.FormattingEnabled = true;
            this.cboAssignmentTemplates.Location = new System.Drawing.Point(220, 11);
            this.cboAssignmentTemplates.Name = "cboAssignmentTemplates";
            this.cboAssignmentTemplates.Size = new System.Drawing.Size(689, 32);
            this.cboAssignmentTemplates.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(202, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "Assignment Templates";
            // 
            // btnSetToNextAssignmentNumber
            // 
            this.btnSetToNextAssignmentNumber.Location = new System.Drawing.Point(362, 43);
            this.btnSetToNextAssignmentNumber.Name = "btnSetToNextAssignmentNumber";
            this.btnSetToNextAssignmentNumber.Size = new System.Drawing.Size(192, 38);
            this.btnSetToNextAssignmentNumber.TabIndex = 77;
            this.btnSetToNextAssignmentNumber.Text = "Set to next available";
            this.btnSetToNextAssignmentNumber.UseVisualStyleBackColor = true;
            this.btnSetToNextAssignmentNumber.Click += new System.EventHandler(this.btnSetToNextAssignmentNumber_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 24);
            this.label2.TabIndex = 75;
            this.label2.Text = "Assignment Number*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numAssignmentNumber
            // 
            this.numAssignmentNumber.Location = new System.Drawing.Point(236, 48);
            this.numAssignmentNumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numAssignmentNumber.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAssignmentNumber.Name = "numAssignmentNumber";
            this.numAssignmentNumber.Size = new System.Drawing.Size(120, 29);
            this.numAssignmentNumber.TabIndex = 67;
            this.numAssignmentNumber.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAssignmentNumber.Leave += new System.EventHandler(this.numAssignmentNumber_Leave);
            // 
            // cboReportsTo
            // 
            this.cboReportsTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReportsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportsTo.FormattingEnabled = true;
            this.cboReportsTo.Location = new System.Drawing.Point(235, 5);
            this.cboReportsTo.Name = "cboReportsTo";
            this.cboReportsTo.Size = new System.Drawing.Size(514, 32);
            this.cboReportsTo.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 24);
            this.label1.TabIndex = 65;
            this.label1.Text = "Reports To";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAndPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnSaveAndPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveAndPrint.Location = new System.Drawing.Point(859, 5);
            this.btnSaveAndPrint.Margin = new System.Windows.Forms.Padding(6);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(179, 48);
            this.btnSaveAndPrint.TabIndex = 108;
            this.btnSaveAndPrint.Text = "Save and Print";
            this.btnSaveAndPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAndPrint.UseVisualStyleBackColor = true;
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(1050, 5);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 48);
            this.btnSave.TabIndex = 107;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(5, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // editTeamAssignmentTemplateControl1
            // 
            this.editTeamAssignmentTemplateControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editTeamAssignmentTemplateControl1.BackColor = System.Drawing.Color.Transparent;
            this.editTeamAssignmentTemplateControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTeamAssignmentTemplateControl1.Location = new System.Drawing.Point(37, 85);
            this.editTeamAssignmentTemplateControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editTeamAssignmentTemplateControl1.Name = "editTeamAssignmentTemplateControl1";
            this.editTeamAssignmentTemplateControl1.selectedAssignment = null;
            this.editTeamAssignmentTemplateControl1.Size = new System.Drawing.Size(712, 386);
            this.editTeamAssignmentTemplateControl1.TabIndex = 76;
            // 
            // cpEquipment
            // 
            this.cpEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpEquipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpEquipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpEquipment.CollapsedHeight = 40;
            this.cpEquipment.CollapsedWidth = 400;
            this.cpEquipment.CollapseLeft = false;
            this.cpEquipment.CurrentlyCollapsed = true;
            this.cpEquipment.ExpandedHeight = 300;
            this.cpEquipment.ExpandedWidth = 485;
            this.cpEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpEquipment.Location = new System.Drawing.Point(766, 57);
            this.cpEquipment.Margin = new System.Windows.Forms.Padding(6);
            this.cpEquipment.Name = "cpEquipment";
            this.cpEquipment.Size = new System.Drawing.Size(400, 40);
            this.cpEquipment.TabIndex = 73;
            this.cpEquipment.TitleText = "Equipment & Vehicles";
            // 
            // cpComms
            // 
            this.cpComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpComms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpComms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpComms.CollapsedHeight = 40;
            this.cpComms.CollapsedWidth = 400;
            this.cpComms.CollapseLeft = false;
            this.cpComms.Controls.Add(this.cboComms4);
            this.cpComms.Controls.Add(this.cboComms3);
            this.cpComms.Controls.Add(this.cboComms2);
            this.cpComms.Controls.Add(this.cboComms1);
            this.cpComms.Controls.Add(this.label3);
            this.cpComms.CurrentlyCollapsed = true;
            this.cpComms.ExpandedHeight = 259;
            this.cpComms.ExpandedWidth = 485;
            this.cpComms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpComms.Location = new System.Drawing.Point(766, 109);
            this.cpComms.Margin = new System.Windows.Forms.Padding(6);
            this.cpComms.Name = "cpComms";
            this.cpComms.Size = new System.Drawing.Size(400, 40);
            this.cpComms.TabIndex = 74;
            this.cpComms.TitleText = "Communications Summary";
            // 
            // cboComms4
            // 
            this.cboComms4.DisplayMember = "SystemIDChannelFunction";
            this.cboComms4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms4.FormattingEnabled = true;
            this.cboComms4.Location = new System.Drawing.Point(15, 209);
            this.cboComms4.Name = "cboComms4";
            this.cboComms4.Size = new System.Drawing.Size(454, 32);
            this.cboComms4.TabIndex = 37;
            this.cboComms4.ValueMember = "ItemID";
            // 
            // cboComms3
            // 
            this.cboComms3.DisplayMember = "SystemIDChannelFunction";
            this.cboComms3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms3.FormattingEnabled = true;
            this.cboComms3.Location = new System.Drawing.Point(15, 171);
            this.cboComms3.Name = "cboComms3";
            this.cboComms3.Size = new System.Drawing.Size(454, 32);
            this.cboComms3.TabIndex = 36;
            this.cboComms3.ValueMember = "ItemID";
            // 
            // cboComms2
            // 
            this.cboComms2.DisplayMember = "SystemIDChannelFunction";
            this.cboComms2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms2.FormattingEnabled = true;
            this.cboComms2.Location = new System.Drawing.Point(15, 133);
            this.cboComms2.Name = "cboComms2";
            this.cboComms2.Size = new System.Drawing.Size(454, 32);
            this.cboComms2.TabIndex = 35;
            this.cboComms2.ValueMember = "ItemID";
            // 
            // cboComms1
            // 
            this.cboComms1.DisplayMember = "SystemIDChannelFunction";
            this.cboComms1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms1.FormattingEnabled = true;
            this.cboComms1.Location = new System.Drawing.Point(15, 95);
            this.cboComms1.Name = "cboComms1";
            this.cboComms1.Size = new System.Drawing.Size(454, 32);
            this.cboComms1.TabIndex = 34;
            this.cboComms1.ValueMember = "ItemID";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(457, 42);
            this.label3.TabIndex = 33;
            this.label3.Text = "Set communications systems to be shown on the assignment form\r\nTo add more, use t" +
    "he Communications Plan tool";
            // 
            // cpPersonnel
            // 
            this.cpPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpPersonnel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpPersonnel.CollapsedHeight = 40;
            this.cpPersonnel.CollapsedWidth = 400;
            this.cpPersonnel.CollapseLeft = false;
            this.cpPersonnel.Controls.Add(this.label6);
            this.cpPersonnel.Controls.Add(this.numPersonnelRequired);
            this.cpPersonnel.Controls.Add(this.cboPerson10);
            this.cpPersonnel.Controls.Add(this.cboPerson8);
            this.cpPersonnel.Controls.Add(this.cboPerson6);
            this.cpPersonnel.Controls.Add(this.cboPerson4);
            this.cpPersonnel.Controls.Add(this.cboPerson2);
            this.cpPersonnel.Controls.Add(this.cboPerson11);
            this.cpPersonnel.Controls.Add(this.cboPerson9);
            this.cpPersonnel.Controls.Add(this.cboPerson7);
            this.cpPersonnel.Controls.Add(this.cboPerson5);
            this.cpPersonnel.Controls.Add(this.cboPerson3);
            this.cpPersonnel.Controls.Add(this.label5);
            this.cpPersonnel.Controls.Add(this.cboPerson1);
            this.cpPersonnel.Controls.Add(this.label4);
            this.cpPersonnel.CurrentlyCollapsed = true;
            this.cpPersonnel.ExpandedHeight = 364;
            this.cpPersonnel.ExpandedWidth = 872;
            this.cpPersonnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPersonnel.Location = new System.Drawing.Point(766, 5);
            this.cpPersonnel.Margin = new System.Windows.Forms.Padding(6);
            this.cpPersonnel.Name = "cpPersonnel";
            this.cpPersonnel.Size = new System.Drawing.Size(400, 40);
            this.cpPersonnel.TabIndex = 72;
            this.cpPersonnel.TitleText = "Personnel";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(231, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 24);
            this.label6.TabIndex = 66;
            this.label6.Text = "Personnel Required";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numPersonnelRequired
            // 
            this.numPersonnelRequired.Location = new System.Drawing.Point(455, 81);
            this.numPersonnelRequired.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numPersonnelRequired.Name = "numPersonnelRequired";
            this.numPersonnelRequired.Size = new System.Drawing.Size(120, 29);
            this.numPersonnelRequired.TabIndex = 47;
            this.numPersonnelRequired.ValueChanged += new System.EventHandler(this.numPersonnelRequired_ValueChanged);
            // 
            // cboPerson10
            // 
            this.cboPerson10.FormattingEnabled = true;
            this.cboPerson10.Location = new System.Drawing.Point(455, 278);
            this.cboPerson10.Name = "cboPerson10";
            this.cboPerson10.Size = new System.Drawing.Size(401, 32);
            this.cboPerson10.TabIndex = 46;
            // 
            // cboPerson8
            // 
            this.cboPerson8.FormattingEnabled = true;
            this.cboPerson8.Location = new System.Drawing.Point(456, 240);
            this.cboPerson8.Name = "cboPerson8";
            this.cboPerson8.Size = new System.Drawing.Size(401, 32);
            this.cboPerson8.TabIndex = 45;
            // 
            // cboPerson6
            // 
            this.cboPerson6.FormattingEnabled = true;
            this.cboPerson6.Location = new System.Drawing.Point(456, 202);
            this.cboPerson6.Name = "cboPerson6";
            this.cboPerson6.Size = new System.Drawing.Size(401, 32);
            this.cboPerson6.TabIndex = 44;
            // 
            // cboPerson4
            // 
            this.cboPerson4.FormattingEnabled = true;
            this.cboPerson4.Location = new System.Drawing.Point(455, 164);
            this.cboPerson4.Name = "cboPerson4";
            this.cboPerson4.Size = new System.Drawing.Size(401, 32);
            this.cboPerson4.TabIndex = 43;
            // 
            // cboPerson2
            // 
            this.cboPerson2.FormattingEnabled = true;
            this.cboPerson2.Location = new System.Drawing.Point(456, 126);
            this.cboPerson2.Name = "cboPerson2";
            this.cboPerson2.Size = new System.Drawing.Size(401, 32);
            this.cboPerson2.TabIndex = 42;
            // 
            // cboPerson11
            // 
            this.cboPerson11.FormattingEnabled = true;
            this.cboPerson11.Location = new System.Drawing.Point(48, 316);
            this.cboPerson11.Name = "cboPerson11";
            this.cboPerson11.Size = new System.Drawing.Size(401, 32);
            this.cboPerson11.TabIndex = 41;
            // 
            // cboPerson9
            // 
            this.cboPerson9.FormattingEnabled = true;
            this.cboPerson9.Location = new System.Drawing.Point(47, 278);
            this.cboPerson9.Name = "cboPerson9";
            this.cboPerson9.Size = new System.Drawing.Size(401, 32);
            this.cboPerson9.TabIndex = 40;
            // 
            // cboPerson7
            // 
            this.cboPerson7.FormattingEnabled = true;
            this.cboPerson7.Location = new System.Drawing.Point(48, 240);
            this.cboPerson7.Name = "cboPerson7";
            this.cboPerson7.Size = new System.Drawing.Size(401, 32);
            this.cboPerson7.TabIndex = 39;
            // 
            // cboPerson5
            // 
            this.cboPerson5.FormattingEnabled = true;
            this.cboPerson5.Location = new System.Drawing.Point(48, 202);
            this.cboPerson5.Name = "cboPerson5";
            this.cboPerson5.Size = new System.Drawing.Size(401, 32);
            this.cboPerson5.TabIndex = 38;
            // 
            // cboPerson3
            // 
            this.cboPerson3.FormattingEnabled = true;
            this.cboPerson3.Location = new System.Drawing.Point(47, 164);
            this.cboPerson3.Name = "cboPerson3";
            this.cboPerson3.Size = new System.Drawing.Size(401, 32);
            this.cboPerson3.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 24);
            this.label5.TabIndex = 36;
            this.label5.Text = "Ldr.";
            // 
            // cboPerson1
            // 
            this.cboPerson1.FormattingEnabled = true;
            this.cboPerson1.Location = new System.Drawing.Point(48, 126);
            this.cboPerson1.Name = "cboPerson1";
            this.cboPerson1.Size = new System.Drawing.Size(401, 32);
            this.cboPerson1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(862, 42);
            this.label4.TabIndex = 34;
            this.label4.Text = "Set the personnel assigned to this team below.  To add additional people, use the" +
    " Check-In tool in the program.";
            // 
            // btnTemplateHelp
            // 
            this.btnTemplateHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateHelp.BackColor = System.Drawing.Color.White;
            this.btnTemplateHelp.BackgroundImage = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_931_speech_bubble_question_3x;
            this.btnTemplateHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnTemplateHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTemplateHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTemplateHelp.Location = new System.Drawing.Point(1126, 7);
            this.btnTemplateHelp.Name = "btnTemplateHelp";
            this.btnTemplateHelp.Size = new System.Drawing.Size(40, 40);
            this.btnTemplateHelp.TabIndex = 108;
            this.btnTemplateHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTemplateHelp.UseVisualStyleBackColor = false;
            this.btnTemplateHelp.Click += new System.EventHandler(this.btnTemplateHelp_Click);
            // 
            // TeamAssignmentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 614);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(995, 584);
            this.Name = "TeamAssignmentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Team Assignment";
            this.Load += new System.EventHandler(this.TeamAssignmentEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAssignmentNumber)).EndInit();
            this.cpComms.ResumeLayout(false);
            this.cpPersonnel.ResumeLayout(false);
            this.cpPersonnel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPersonnelRequired)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnApplyTemplate;
        private System.Windows.Forms.ComboBox cboAssignmentTemplates;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAssignmentNumber;
        private System.Windows.Forms.ComboBox cboReportsTo;
        private CustomControls.CollapsiblePanel cpPersonnel;
        private CustomControls.CollapsiblePanel cpEquipment;
        private CustomControls.CollapsiblePanel cpComms;
        private CustomControls.EditTeamAssignmentTemplateControl editTeamAssignmentTemplateControl1;
        private System.Windows.Forms.Button btnSetToNextAssignmentNumber;
        private System.Windows.Forms.ComboBox cboComms4;
        private System.Windows.Forms.ComboBox cboComms3;
        private System.Windows.Forms.ComboBox cboComms2;
        private System.Windows.Forms.ComboBox cboComms1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveAndPrint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numPersonnelRequired;
        private System.Windows.Forms.ComboBox cboPerson10;
        private System.Windows.Forms.ComboBox cboPerson8;
        private System.Windows.Forms.ComboBox cboPerson6;
        private System.Windows.Forms.ComboBox cboPerson4;
        private System.Windows.Forms.ComboBox cboPerson2;
        private System.Windows.Forms.ComboBox cboPerson11;
        private System.Windows.Forms.ComboBox cboPerson9;
        private System.Windows.Forms.ComboBox cboPerson7;
        private System.Windows.Forms.ComboBox cboPerson5;
        private System.Windows.Forms.ComboBox cboPerson3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPerson1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTemplateHelp;
    }
}