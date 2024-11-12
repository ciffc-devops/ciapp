namespace Wildfire_ICS_Assist.SafetyMessageForms
{
    partial class CreateNewSafetyMessageForm
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
            this.wizardPages1 = new Wildfire_ICS_Assist.CustomControls.WizardPages();
            this.tpStart = new System.Windows.Forms.TabPage();
            this.btnCopyFromPreviousOP = new System.Windows.Forms.Button();
            this.btnFromTemplate = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.tpTemplate = new System.Windows.Forms.TabPage();
            this.pnlTemplatePreview = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemplatePreviewName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTemplatePreviewMessage = new SpellBox();
            this.btnUseTemplate = new System.Windows.Forms.Button();
            this.cboSaved = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tpPreviousOP = new System.Windows.Forms.TabPage();
            this.cboOpPeriod = new System.Windows.Forms.ComboBox();
            this.pnlPrevOpPreview = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPreviewPrevOpSubject = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPreviewPrevOpMessage = new SpellBox();
            this.btnSelectPrevOpPlan = new System.Windows.Forms.Button();
            this.cboCopyFromOpPlan = new System.Windows.Forms.ComboBox();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new SpellBox();
            this.txtNewSitePlanLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSummaryLine = new System.Windows.Forms.TextBox();
            this.chkNewSitePlanRequired = new System.Windows.Forms.CheckBox();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.picTitleImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.wizardPages1.SuspendLayout();
            this.tpStart.SuspendLayout();
            this.tpTemplate.SuspendLayout();
            this.pnlTemplatePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tpPreviousOP.SuspendLayout();
            this.pnlPrevOpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.collapsiblePanel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.wizardPages1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkSaveForLater);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(1110, 565);
            this.splitContainer1.SplitterDistance = 498;
            this.splitContainer1.TabIndex = 4;
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.tpStart);
            this.wizardPages1.Controls.Add(this.tpTemplate);
            this.wizardPages1.Controls.Add(this.tpPreviousOP);
            this.wizardPages1.Controls.Add(this.tpDetails);
            this.wizardPages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPages1.Location = new System.Drawing.Point(0, 0);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(1110, 498);
            this.wizardPages1.TabIndex = 133;
            this.wizardPages1.SelectedIndexChanged += new System.EventHandler(this.wizardPages1_SelectedIndexChanged);
            // 
            // tpStart
            // 
            this.tpStart.Controls.Add(this.btnCopyFromPreviousOP);
            this.tpStart.Controls.Add(this.btnFromTemplate);
            this.tpStart.Controls.Add(this.btnNew);
            this.tpStart.Location = new System.Drawing.Point(4, 33);
            this.tpStart.Name = "tpStart";
            this.tpStart.Padding = new System.Windows.Forms.Padding(3);
            this.tpStart.Size = new System.Drawing.Size(1102, 461);
            this.tpStart.TabIndex = 0;
            this.tpStart.Text = "start";
            this.tpStart.UseVisualStyleBackColor = true;
            // 
            // btnCopyFromPreviousOP
            // 
            this.btnCopyFromPreviousOP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCopyFromPreviousOP.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_611_copy_duplicate;
            this.btnCopyFromPreviousOP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyFromPreviousOP.Location = new System.Drawing.Point(470, 194);
            this.btnCopyFromPreviousOP.Name = "btnCopyFromPreviousOP";
            this.btnCopyFromPreviousOP.Size = new System.Drawing.Size(163, 84);
            this.btnCopyFromPreviousOP.TabIndex = 2;
            this.btnCopyFromPreviousOP.Text = "Copy from a previous OP";
            this.btnCopyFromPreviousOP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyFromPreviousOP.UseVisualStyleBackColor = true;
            this.btnCopyFromPreviousOP.Click += new System.EventHandler(this.btnCopyFromPreviousOP_Click);
            // 
            // btnFromTemplate
            // 
            this.btnFromTemplate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFromTemplate.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_809_drop_plus;
            this.btnFromTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFromTemplate.Location = new System.Drawing.Point(639, 194);
            this.btnFromTemplate.Name = "btnFromTemplate";
            this.btnFromTemplate.Size = new System.Drawing.Size(153, 84);
            this.btnFromTemplate.TabIndex = 1;
            this.btnFromTemplate.Text = "Start from a template";
            this.btnFromTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFromTemplate.UseVisualStyleBackColor = true;
            this.btnFromTemplate.Click += new System.EventHandler(this.btnFromTemplate_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_841_square_plus;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(301, 194);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(163, 84);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New Safety Message";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tpTemplate
            // 
            this.tpTemplate.Controls.Add(this.pnlTemplatePreview);
            this.tpTemplate.Controls.Add(this.btnUseTemplate);
            this.tpTemplate.Controls.Add(this.cboSaved);
            this.tpTemplate.Controls.Add(this.label6);
            this.tpTemplate.Location = new System.Drawing.Point(4, 33);
            this.tpTemplate.Name = "tpTemplate";
            this.tpTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tpTemplate.Size = new System.Drawing.Size(1102, 461);
            this.tpTemplate.TabIndex = 2;
            this.tpTemplate.Text = "Template";
            this.tpTemplate.UseVisualStyleBackColor = true;
            // 
            // pnlTemplatePreview
            // 
            this.pnlTemplatePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTemplatePreview.Controls.Add(this.label8);
            this.pnlTemplatePreview.Controls.Add(this.pictureBox1);
            this.pnlTemplatePreview.Controls.Add(this.label7);
            this.pnlTemplatePreview.Controls.Add(this.label3);
            this.pnlTemplatePreview.Controls.Add(this.txtTemplatePreviewName);
            this.pnlTemplatePreview.Controls.Add(this.label5);
            this.pnlTemplatePreview.Controls.Add(this.txtTemplatePreviewMessage);
            this.pnlTemplatePreview.Location = new System.Drawing.Point(17, 94);
            this.pnlTemplatePreview.Name = "pnlTemplatePreview";
            this.pnlTemplatePreview.Size = new System.Drawing.Size(1074, 367);
            this.pnlTemplatePreview.TabIndex = 140;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(160, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(428, 20);
            this.label8.TabIndex = 142;
            this.label8.Text = "(you\'ll be able to edit the text as needed on the next screen)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_809_drop_plus;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 141;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 29);
            this.label7.TabIndex = 138;
            this.label7.Text = "Preview";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 29);
            this.label3.TabIndex = 135;
            this.label3.Text = "Message/Plan Name";
            // 
            // txtTemplatePreviewName
            // 
            this.txtTemplatePreviewName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplatePreviewName.Enabled = false;
            this.txtTemplatePreviewName.Location = new System.Drawing.Point(207, 45);
            this.txtTemplatePreviewName.Name = "txtTemplatePreviewName";
            this.txtTemplatePreviewName.Size = new System.Drawing.Size(848, 29);
            this.txtTemplatePreviewName.TabIndex = 133;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(652, 24);
            this.label5.TabIndex = 134;
            this.label5.Text = "Safety Message / Expanded Safety Message, Plan, Site Safety Plan";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTemplatePreviewMessage
            // 
            this.txtTemplatePreviewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplatePreviewMessage.Enabled = false;
            this.txtTemplatePreviewMessage.Location = new System.Drawing.Point(13, 110);
            this.txtTemplatePreviewMessage.Multiline = true;
            this.txtTemplatePreviewMessage.Name = "txtTemplatePreviewMessage";
            this.txtTemplatePreviewMessage.Size = new System.Drawing.Size(1046, 252);
            this.txtTemplatePreviewMessage.TabIndex = 136;
            this.txtTemplatePreviewMessage.WordWrap = true;
            this.txtTemplatePreviewMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // btnUseTemplate
            // 
            this.btnUseTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseTemplate.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnUseTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUseTemplate.Location = new System.Drawing.Point(700, 37);
            this.btnUseTemplate.Name = "btnUseTemplate";
            this.btnUseTemplate.Size = new System.Drawing.Size(124, 51);
            this.btnUseTemplate.TabIndex = 139;
            this.btnUseTemplate.Text = "Select";
            this.btnUseTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUseTemplate.UseVisualStyleBackColor = true;
            this.btnUseTemplate.Click += new System.EventHandler(this.btnUseTemplate_Click);
            // 
            // cboSaved
            // 
            this.cboSaved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSaved.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSaved.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSaved.DisplayMember = "SummaryLine";
            this.cboSaved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSaved.FormattingEnabled = true;
            this.cboSaved.Location = new System.Drawing.Point(17, 47);
            this.cboSaved.Name = "cboSaved";
            this.cboSaved.Size = new System.Drawing.Size(677, 32);
            this.cboSaved.TabIndex = 138;
            this.cboSaved.ValueMember = "ID";
            this.cboSaved.SelectedIndexChanged += new System.EventHandler(this.cboSaved_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 29);
            this.label6.TabIndex = 137;
            this.label6.Text = "Saved Safety Message / Plan";
            // 
            // tpPreviousOP
            // 
            this.tpPreviousOP.Controls.Add(this.cboOpPeriod);
            this.tpPreviousOP.Controls.Add(this.pnlPrevOpPreview);
            this.tpPreviousOP.Controls.Add(this.btnSelectPrevOpPlan);
            this.tpPreviousOP.Controls.Add(this.cboCopyFromOpPlan);
            this.tpPreviousOP.Location = new System.Drawing.Point(4, 33);
            this.tpPreviousOP.Name = "tpPreviousOP";
            this.tpPreviousOP.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreviousOP.Size = new System.Drawing.Size(1102, 461);
            this.tpPreviousOP.TabIndex = 3;
            this.tpPreviousOP.Text = "Prev OP";
            this.tpPreviousOP.UseVisualStyleBackColor = true;
            // 
            // cboOpPeriod
            // 
            this.cboOpPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpPeriod.FormattingEnabled = true;
            this.cboOpPeriod.Location = new System.Drawing.Point(14, 28);
            this.cboOpPeriod.Name = "cboOpPeriod";
            this.cboOpPeriod.Size = new System.Drawing.Size(279, 32);
            this.cboOpPeriod.TabIndex = 144;
            this.cboOpPeriod.SelectedIndexChanged += new System.EventHandler(this.cboOpPeriod_SelectedIndexChanged);
            // 
            // pnlPrevOpPreview
            // 
            this.pnlPrevOpPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrevOpPreview.Controls.Add(this.label9);
            this.pnlPrevOpPreview.Controls.Add(this.pictureBox2);
            this.pnlPrevOpPreview.Controls.Add(this.label10);
            this.pnlPrevOpPreview.Controls.Add(this.label11);
            this.pnlPrevOpPreview.Controls.Add(this.txtPreviewPrevOpSubject);
            this.pnlPrevOpPreview.Controls.Add(this.label12);
            this.pnlPrevOpPreview.Controls.Add(this.txtPreviewPrevOpMessage);
            this.pnlPrevOpPreview.Location = new System.Drawing.Point(14, 75);
            this.pnlPrevOpPreview.Name = "pnlPrevOpPreview";
            this.pnlPrevOpPreview.Size = new System.Drawing.Size(1074, 367);
            this.pnlPrevOpPreview.TabIndex = 143;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(428, 20);
            this.label9.TabIndex = 142;
            this.label9.Text = "(you\'ll be able to edit the text as needed on the next screen)";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_809_drop_plus;
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 44);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 141;
            this.pictureBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(47, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 29);
            this.label10.TabIndex = 138;
            this.label10.Text = "Preview";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 29);
            this.label11.TabIndex = 135;
            this.label11.Text = "Message/Plan Name";
            // 
            // txtPreviewPrevOpSubject
            // 
            this.txtPreviewPrevOpSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviewPrevOpSubject.Enabled = false;
            this.txtPreviewPrevOpSubject.Location = new System.Drawing.Point(207, 45);
            this.txtPreviewPrevOpSubject.Name = "txtPreviewPrevOpSubject";
            this.txtPreviewPrevOpSubject.Size = new System.Drawing.Size(848, 29);
            this.txtPreviewPrevOpSubject.TabIndex = 133;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(652, 24);
            this.label12.TabIndex = 134;
            this.label12.Text = "Safety Message / Expanded Safety Message, Plan, Site Safety Plan";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPreviewPrevOpMessage
            // 
            this.txtPreviewPrevOpMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviewPrevOpMessage.Enabled = false;
            this.txtPreviewPrevOpMessage.Location = new System.Drawing.Point(13, 110);
            this.txtPreviewPrevOpMessage.Multiline = true;
            this.txtPreviewPrevOpMessage.Name = "txtPreviewPrevOpMessage";
            this.txtPreviewPrevOpMessage.Size = new System.Drawing.Size(1046, 252);
            this.txtPreviewPrevOpMessage.TabIndex = 136;
            this.txtPreviewPrevOpMessage.WordWrap = true;
            this.txtPreviewPrevOpMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // btnSelectPrevOpPlan
            // 
            this.btnSelectPrevOpPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPrevOpPlan.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectPrevOpPlan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectPrevOpPlan.Location = new System.Drawing.Point(697, 18);
            this.btnSelectPrevOpPlan.Name = "btnSelectPrevOpPlan";
            this.btnSelectPrevOpPlan.Size = new System.Drawing.Size(124, 51);
            this.btnSelectPrevOpPlan.TabIndex = 142;
            this.btnSelectPrevOpPlan.Text = "Select";
            this.btnSelectPrevOpPlan.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectPrevOpPlan.UseVisualStyleBackColor = true;
            this.btnSelectPrevOpPlan.Click += new System.EventHandler(this.btnSelectPrevOpPlan_Click);
            // 
            // cboCopyFromOpPlan
            // 
            this.cboCopyFromOpPlan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCopyFromOpPlan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCopyFromOpPlan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCopyFromOpPlan.DisplayMember = "SummaryLine";
            this.cboCopyFromOpPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCopyFromOpPlan.FormattingEnabled = true;
            this.cboCopyFromOpPlan.Location = new System.Drawing.Point(299, 28);
            this.cboCopyFromOpPlan.Name = "cboCopyFromOpPlan";
            this.cboCopyFromOpPlan.Size = new System.Drawing.Size(392, 32);
            this.cboCopyFromOpPlan.TabIndex = 141;
            this.cboCopyFromOpPlan.ValueMember = "ID";
            this.cboCopyFromOpPlan.SelectedIndexChanged += new System.EventHandler(this.cboCopyFromOpPlan_SelectedIndexChanged);
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.splitContainer2);
            this.tpDetails.Location = new System.Drawing.Point(4, 33);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(1102, 461);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtMessage);
            this.splitContainer2.Panel1.Controls.Add(this.txtNewSitePlanLocation);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtSummaryLine);
            this.splitContainer2.Panel1.Controls.Add(this.chkNewSitePlanRequired);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel1);
            this.splitContainer2.Panel2.Controls.Add(this.prepAndApprovePanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1096, 455);
            this.splitContainer2.SplitterDistance = 685;
            this.splitContainer2.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 29);
            this.label2.TabIndex = 119;
            this.label2.Text = "Message/Plan Name";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(13, 79);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(669, 252);
            this.txtMessage.TabIndex = 132;
            this.txtMessage.WordWrap = true;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // txtNewSitePlanLocation
            // 
            this.txtNewSitePlanLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewSitePlanLocation.Location = new System.Drawing.Point(13, 403);
            this.txtNewSitePlanLocation.Name = "txtNewSitePlanLocation";
            this.txtNewSitePlanLocation.Size = new System.Drawing.Size(669, 29);
            this.txtNewSitePlanLocation.TabIndex = 4;
            this.txtNewSitePlanLocation.TextChanged += new System.EventHandler(this.txtNewSitePlanLocation_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(652, 24);
            this.label1.TabIndex = 118;
            this.label1.Text = "Safety Message / Expanded Safety Message, Plan, Site Safety Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 24);
            this.label4.TabIndex = 127;
            this.label4.Text = "Approved Site Safety Plan(s) Located at:";
            // 
            // txtSummaryLine
            // 
            this.txtSummaryLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummaryLine.Location = new System.Drawing.Point(211, 14);
            this.txtSummaryLine.Name = "txtSummaryLine";
            this.txtSummaryLine.Size = new System.Drawing.Size(471, 29);
            this.txtSummaryLine.TabIndex = 1;
            this.txtSummaryLine.TextChanged += new System.EventHandler(this.txtSummaryLine_TextChanged);
            // 
            // chkNewSitePlanRequired
            // 
            this.chkNewSitePlanRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNewSitePlanRequired.AutoSize = true;
            this.chkNewSitePlanRequired.Location = new System.Drawing.Point(13, 337);
            this.chkNewSitePlanRequired.Name = "chkNewSitePlanRequired";
            this.chkNewSitePlanRequired.Size = new System.Drawing.Size(250, 28);
            this.chkNewSitePlanRequired.TabIndex = 3;
            this.chkNewSitePlanRequired.Text = "Site Safety Plan Required?";
            this.chkNewSitePlanRequired.UseVisualStyleBackColor = true;
            this.chkNewSitePlanRequired.CheckedChanged += new System.EventHandler(this.chkNewSitePlanRequired_CheckedChanged);
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = true;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = true;
            this.prepAndApprovePanel1.ExpandsRight = false;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(17, 6);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 11, 12, 8, 52, 17, 130);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(386, 40);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(386, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(386, 229);
            this.prepAndApprovePanel1.TabIndex = 133;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved";
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.BackColor = System.Drawing.Color.White;
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.Collapsed = false;
            this.collapsiblePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.Controls.Add(this.picTitleImage);
            this.collapsiblePanel1.Controls.Add(this.btnSelectImage);
            this.collapsiblePanel1.Controls.Add(this.btnRemoveImage);
            this.collapsiblePanel1.EnableExpandCollapse = true;
            this.collapsiblePanel1.ExpandsRight = true;
            this.collapsiblePanel1.ExpandsUpward = false;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(17, 54);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(386, 265);
            this.collapsiblePanel1.SizeWhenCollapsed = new System.Drawing.Size(386, 40);
            this.collapsiblePanel1.SizeWhenExpanded = new System.Drawing.Size(386, 265);
            this.collapsiblePanel1.TabIndex = 134;
            this.collapsiblePanel1.TitleText = "Image / Photo";
            // 
            // picTitleImage
            // 
            this.picTitleImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitleImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTitleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTitleImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.picTitleImage.Location = new System.Drawing.Point(3, 96);
            this.picTitleImage.Name = "picTitleImage";
            this.picTitleImage.Size = new System.Drawing.Size(378, 164);
            this.picTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitleImage.TabIndex = 129;
            this.picTitleImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnSelectImage.Location = new System.Drawing.Point(3, 54);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(112, 36);
            this.btnSelectImage.TabIndex = 130;
            this.btnSelectImage.Text = "Select...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnRemoveImage.Location = new System.Drawing.Point(121, 54);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(112, 36);
            this.btnRemoveImage.TabIndex = 131;
            this.btnRemoveImage.Text = "Remove";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(675, 18);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(305, 28);
            this.chkSaveForLater.TabIndex = 10;
            this.chkSaveForLater.Text = "Save template for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            this.chkSaveForLater.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(989, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 51);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;,*.gif,*.bmp";
            // 
            // CreateNewSafetyMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 565);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CreateNewSafetyMessageForm";
            this.Text = "CreateNewSafetyMessageForm";
            this.Load += new System.EventHandler(this.CreateNewSafetyMessageForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.wizardPages1.ResumeLayout(false);
            this.tpStart.ResumeLayout(false);
            this.tpTemplate.ResumeLayout(false);
            this.tpTemplate.PerformLayout();
            this.pnlTemplatePreview.ResumeLayout(false);
            this.pnlTemplatePreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tpPreviousOP.ResumeLayout(false);
            this.pnlPrevOpPreview.ResumeLayout(false);
            this.pnlPrevOpPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tpDetails.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.collapsiblePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SpellBox txtMessage;
        private System.Windows.Forms.PictureBox picTitleImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private System.Windows.Forms.TextBox txtNewSitePlanLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNewSitePlanRequired;
        private System.Windows.Forms.TextBox txtSummaryLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private CustomControls.WizardPages wizardPages1;
        private System.Windows.Forms.TabPage tpStart;
        private System.Windows.Forms.TabPage tpDetails;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControls.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Button btnCopyFromPreviousOP;
        private System.Windows.Forms.Button btnFromTemplate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TabPage tpTemplate;
        private System.Windows.Forms.TabPage tpPreviousOP;
        private System.Windows.Forms.Label label3;
        private SpellBox txtTemplatePreviewMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTemplatePreviewName;
        private System.Windows.Forms.ComboBox cboSaved;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlTemplatePreview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUseTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboOpPeriod;
        private System.Windows.Forms.Panel pnlPrevOpPreview;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPreviewPrevOpSubject;
        private System.Windows.Forms.Label label12;
        private SpellBox txtPreviewPrevOpMessage;
        private System.Windows.Forms.Button btnSelectPrevOpPlan;
        private System.Windows.Forms.ComboBox cboCopyFromOpPlan;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}