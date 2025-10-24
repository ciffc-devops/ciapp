namespace Wildfire_ICS_Assist.IncidentObjectiveForms
{
    partial class IncidentObjectivesListForm
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
            this.tvObjectives = new System.Windows.Forms.TreeView();
            this.cpWeather = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtWeatherForcast = new SpellBox();
            this.cpFireStatus = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboFireStatus = new System.Windows.Forms.ComboBox();
            this.txtFireSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cpSituationalAwareness = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtSituationalAwareness = new SpellBox();
            this.cpCommandEmphasis = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtCommandEmphasis = new SpellBox();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.cpSafetyPlanRequired = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.chkSafetyPlanRequired = new System.Windows.Forms.CheckBox();
            this.txtSafetyPlanLocation = new SpellBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cpGeneralSafety = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtGeneralSafetyMessage = new SpellBox();
            this.cboSafetyMessages = new System.Windows.Forms.ComboBox();
            this.btnFillSafetyFrom208 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAddStrategy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cpWeather.SuspendLayout();
            this.cpFireStatus.SuspendLayout();
            this.cpSituationalAwareness.SuspendLayout();
            this.cpCommandEmphasis.SuspendLayout();
            this.cpSafetyPlanRequired.SuspendLayout();
            this.cpGeneralSafety.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddStrategy);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnNew);
            this.splitContainer1.Size = new System.Drawing.Size(992, 538);
            this.splitContainer1.SplitterDistance = 489;
            this.splitContainer1.TabIndex = 26;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvObjectives);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cpWeather);
            this.splitContainer2.Panel2.Controls.Add(this.cpFireStatus);
            this.splitContainer2.Panel2.Controls.Add(this.cpCommandEmphasis);
            this.splitContainer2.Panel2.Controls.Add(this.prepAndApprovePanel1);
            this.splitContainer2.Panel2.Controls.Add(this.cpSafetyPlanRequired);
            this.splitContainer2.Panel2.Controls.Add(this.cpGeneralSafety);
            this.splitContainer2.Panel2.Controls.Add(this.cpSituationalAwareness);
            this.splitContainer2.Size = new System.Drawing.Size(992, 489);
            this.splitContainer2.SplitterDistance = 580;
            this.splitContainer2.TabIndex = 0;
            // 
            // tvObjectives
            // 
            this.tvObjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjectives.Location = new System.Drawing.Point(0, 0);
            this.tvObjectives.Name = "tvObjectives";
            this.tvObjectives.Size = new System.Drawing.Size(580, 489);
            this.tvObjectives.TabIndex = 0;
            // 
            // cpWeather
            // 
            this.cpWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpWeather.Collapsed = true;
            this.cpWeather.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpWeather.Controls.Add(this.txtWeatherForcast);
            this.cpWeather.EnableExpandCollapse = true;
            this.cpWeather.ExpandsRight = true;
            this.cpWeather.ExpandsUpward = false;
            this.cpWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpWeather.Location = new System.Drawing.Point(9, 67);
            this.cpWeather.Margin = new System.Windows.Forms.Padding(6);
            this.cpWeather.Name = "cpWeather";
            this.cpWeather.Size = new System.Drawing.Size(387, 40);
            this.cpWeather.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpWeather.SizeWhenExpanded = new System.Drawing.Size(387, 392);
            this.cpWeather.TabIndex = 62;
            this.cpWeather.TitleText = "Weather Forecast";
            // 
            // txtWeatherForcast
            // 
            this.txtWeatherForcast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeatherForcast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtWeatherForcast.Location = new System.Drawing.Point(7, 51);
            this.txtWeatherForcast.Multiline = true;
            this.txtWeatherForcast.Name = "txtWeatherForcast";
            this.txtWeatherForcast.Size = new System.Drawing.Size(373, 319);
            this.txtWeatherForcast.TabIndex = 34;
            this.txtWeatherForcast.Child = new System.Windows.Controls.TextBox();
            // 
            // cpFireStatus
            // 
            this.cpFireStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFireStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFireStatus.Collapsed = true;
            this.cpFireStatus.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFireStatus.Controls.Add(this.cboFireStatus);
            this.cpFireStatus.Controls.Add(this.txtFireSize);
            this.cpFireStatus.Controls.Add(this.label2);
            this.cpFireStatus.Controls.Add(this.label1);
            this.cpFireStatus.EnableExpandCollapse = true;
            this.cpFireStatus.ExpandsRight = true;
            this.cpFireStatus.ExpandsUpward = false;
            this.cpFireStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpFireStatus.Location = new System.Drawing.Point(9, 171);
            this.cpFireStatus.Margin = new System.Windows.Forms.Padding(6);
            this.cpFireStatus.Name = "cpFireStatus";
            this.cpFireStatus.Size = new System.Drawing.Size(387, 40);
            this.cpFireStatus.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpFireStatus.SizeWhenExpanded = new System.Drawing.Size(387, 129);
            this.cpFireStatus.TabIndex = 64;
            this.cpFireStatus.TitleText = "Fire Size / Status";
            // 
            // cboFireStatus
            // 
            this.cboFireStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFireStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFireStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFireStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboFireStatus.FormattingEnabled = true;
            this.cboFireStatus.Items.AddRange(new object[] {
            "OC",
            "NUC",
            "BH",
            "UC"});
            this.cboFireStatus.Location = new System.Drawing.Point(120, 83);
            this.cboFireStatus.Name = "cboFireStatus";
            this.cboFireStatus.Size = new System.Drawing.Size(260, 32);
            this.cboFireStatus.TabIndex = 38;
            // 
            // txtFireSize
            // 
            this.txtFireSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFireSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtFireSize.Location = new System.Drawing.Point(120, 48);
            this.txtFireSize.Name = "txtFireSize";
            this.txtFireSize.Size = new System.Drawing.Size(260, 29);
            this.txtFireSize.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fire Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fire Size ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cpSituationalAwareness
            // 
            this.cpSituationalAwareness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpSituationalAwareness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpSituationalAwareness.Collapsed = true;
            this.cpSituationalAwareness.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpSituationalAwareness.Controls.Add(this.txtSituationalAwareness);
            this.cpSituationalAwareness.EnableExpandCollapse = true;
            this.cpSituationalAwareness.ExpandsRight = true;
            this.cpSituationalAwareness.ExpandsUpward = false;
            this.cpSituationalAwareness.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpSituationalAwareness.Location = new System.Drawing.Point(9, 275);
            this.cpSituationalAwareness.Margin = new System.Windows.Forms.Padding(6);
            this.cpSituationalAwareness.Name = "cpSituationalAwareness";
            this.cpSituationalAwareness.Size = new System.Drawing.Size(387, 40);
            this.cpSituationalAwareness.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpSituationalAwareness.SizeWhenExpanded = new System.Drawing.Size(387, 377);
            this.cpSituationalAwareness.TabIndex = 63;
            this.cpSituationalAwareness.TitleText = "Situational Awareness";
            // 
            // txtSituationalAwareness
            // 
            this.txtSituationalAwareness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSituationalAwareness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtSituationalAwareness.Location = new System.Drawing.Point(7, 51);
            this.txtSituationalAwareness.Multiline = true;
            this.txtSituationalAwareness.Name = "txtSituationalAwareness";
            this.txtSituationalAwareness.Size = new System.Drawing.Size(373, 319);
            this.txtSituationalAwareness.TabIndex = 34;
            this.txtSituationalAwareness.Child = new System.Windows.Controls.TextBox();
            // 
            // cpCommandEmphasis
            // 
            this.cpCommandEmphasis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpCommandEmphasis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpCommandEmphasis.Collapsed = true;
            this.cpCommandEmphasis.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpCommandEmphasis.Controls.Add(this.txtCommandEmphasis);
            this.cpCommandEmphasis.EnableExpandCollapse = true;
            this.cpCommandEmphasis.ExpandsRight = true;
            this.cpCommandEmphasis.ExpandsUpward = false;
            this.cpCommandEmphasis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpCommandEmphasis.Location = new System.Drawing.Point(9, 223);
            this.cpCommandEmphasis.Margin = new System.Windows.Forms.Padding(6);
            this.cpCommandEmphasis.Name = "cpCommandEmphasis";
            this.cpCommandEmphasis.Size = new System.Drawing.Size(387, 40);
            this.cpCommandEmphasis.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpCommandEmphasis.SizeWhenExpanded = new System.Drawing.Size(387, 392);
            this.cpCommandEmphasis.TabIndex = 63;
            this.cpCommandEmphasis.TitleText = "Command Emphasis";
            // 
            // txtCommandEmphasis
            // 
            this.txtCommandEmphasis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommandEmphasis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtCommandEmphasis.Location = new System.Drawing.Point(7, 51);
            this.txtCommandEmphasis.Multiline = true;
            this.txtCommandEmphasis.Name = "txtCommandEmphasis";
            this.txtCommandEmphasis.Size = new System.Drawing.Size(373, 336);
            this.txtCommandEmphasis.TabIndex = 34;
            this.txtCommandEmphasis.Child = new System.Windows.Controls.TextBox();
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = true;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = true;
            this.prepAndApprovePanel1.ExpandsRight = true;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(9, 15);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 10, 29, 14, 7, 6, 690);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(387, 40);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(387, 228);
            this.prepAndApprovePanel1.TabIndex = 65;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved by";
            this.prepAndApprovePanel1.PreparedByChanged += new System.EventHandler(this.prepAndApprovePanel1_PreparedByChanged);
            this.prepAndApprovePanel1.ApprovedByChanged += new System.EventHandler(this.prepAndApprovePanel1_ApprovedByChanged);
            // 
            // cpSafetyPlanRequired
            // 
            this.cpSafetyPlanRequired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpSafetyPlanRequired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpSafetyPlanRequired.Collapsed = true;
            this.cpSafetyPlanRequired.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpSafetyPlanRequired.Controls.Add(this.chkSafetyPlanRequired);
            this.cpSafetyPlanRequired.Controls.Add(this.txtSafetyPlanLocation);
            this.cpSafetyPlanRequired.Controls.Add(this.label3);
            this.cpSafetyPlanRequired.Controls.Add(this.label4);
            this.cpSafetyPlanRequired.EnableExpandCollapse = true;
            this.cpSafetyPlanRequired.ExpandsRight = true;
            this.cpSafetyPlanRequired.ExpandsUpward = false;
            this.cpSafetyPlanRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpSafetyPlanRequired.Location = new System.Drawing.Point(9, 327);
            this.cpSafetyPlanRequired.Margin = new System.Windows.Forms.Padding(6);
            this.cpSafetyPlanRequired.Name = "cpSafetyPlanRequired";
            this.cpSafetyPlanRequired.Size = new System.Drawing.Size(387, 40);
            this.cpSafetyPlanRequired.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpSafetyPlanRequired.SizeWhenExpanded = new System.Drawing.Size(387, 158);
            this.cpSafetyPlanRequired.TabIndex = 66;
            this.cpSafetyPlanRequired.TitleText = "Safety Plan";
            // 
            // chkSafetyPlanRequired
            // 
            this.chkSafetyPlanRequired.AutoSize = true;
            this.chkSafetyPlanRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.chkSafetyPlanRequired.Location = new System.Drawing.Point(236, 48);
            this.chkSafetyPlanRequired.Name = "chkSafetyPlanRequired";
            this.chkSafetyPlanRequired.Size = new System.Drawing.Size(61, 28);
            this.chkSafetyPlanRequired.TabIndex = 36;
            this.chkSafetyPlanRequired.Text = "Yes";
            this.chkSafetyPlanRequired.UseVisualStyleBackColor = true;
            // 
            // txtSafetyPlanLocation
            // 
            this.txtSafetyPlanLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtSafetyPlanLocation.Location = new System.Drawing.Point(7, 117);
            this.txtSafetyPlanLocation.Name = "txtSafetyPlanLocation";
            this.txtSafetyPlanLocation.Size = new System.Drawing.Size(367, 31);
            this.txtSafetyPlanLocation.TabIndex = 35;
            this.txtSafetyPlanLocation.Child = new System.Windows.Controls.TextBox();
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = "Approved Site Safety Plan(s) Located at:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 29);
            this.label4.TabIndex = 33;
            this.label4.Text = "Site safety plan required?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cpGeneralSafety
            // 
            this.cpGeneralSafety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpGeneralSafety.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpGeneralSafety.Collapsed = true;
            this.cpGeneralSafety.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpGeneralSafety.Controls.Add(this.txtGeneralSafetyMessage);
            this.cpGeneralSafety.Controls.Add(this.cboSafetyMessages);
            this.cpGeneralSafety.Controls.Add(this.btnFillSafetyFrom208);
            this.cpGeneralSafety.EnableExpandCollapse = true;
            this.cpGeneralSafety.ExpandsRight = true;
            this.cpGeneralSafety.ExpandsUpward = false;
            this.cpGeneralSafety.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpGeneralSafety.Location = new System.Drawing.Point(9, 119);
            this.cpGeneralSafety.Margin = new System.Windows.Forms.Padding(6);
            this.cpGeneralSafety.Name = "cpGeneralSafety";
            this.cpGeneralSafety.Size = new System.Drawing.Size(387, 40);
            this.cpGeneralSafety.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.cpGeneralSafety.SizeWhenExpanded = new System.Drawing.Size(387, 367);
            this.cpGeneralSafety.TabIndex = 63;
            this.cpGeneralSafety.TitleText = "General Safety Message";
            // 
            // txtGeneralSafetyMessage
            // 
            this.txtGeneralSafetyMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneralSafetyMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtGeneralSafetyMessage.Location = new System.Drawing.Point(7, 51);
            this.txtGeneralSafetyMessage.Multiline = true;
            this.txtGeneralSafetyMessage.Name = "txtGeneralSafetyMessage";
            this.txtGeneralSafetyMessage.Size = new System.Drawing.Size(367, 244);
            this.txtGeneralSafetyMessage.TabIndex = 36;
            this.txtGeneralSafetyMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // cboSafetyMessages
            // 
            this.cboSafetyMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSafetyMessages.DisplayMember = "SummaryLine";
            this.cboSafetyMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSafetyMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboSafetyMessages.FormattingEnabled = true;
            this.cboSafetyMessages.Location = new System.Drawing.Point(176, 309);
            this.cboSafetyMessages.Name = "cboSafetyMessages";
            this.cboSafetyMessages.Size = new System.Drawing.Size(198, 32);
            this.cboSafetyMessages.TabIndex = 35;
            this.cboSafetyMessages.ValueMember = "ID";
            // 
            // btnFillSafetyFrom208
            // 
            this.btnFillSafetyFrom208.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnFillSafetyFrom208.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_302_square_download;
            this.btnFillSafetyFrom208.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFillSafetyFrom208.Location = new System.Drawing.Point(7, 301);
            this.btnFillSafetyFrom208.Name = "btnFillSafetyFrom208";
            this.btnFillSafetyFrom208.Size = new System.Drawing.Size(163, 46);
            this.btnFillSafetyFrom208.TabIndex = 34;
            this.btnFillSafetyFrom208.Text = "Fill from 208";
            this.btnFillSafetyFrom208.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFillSafetyFrom208.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrint.Location = new System.Drawing.Point(840, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 39);
            this.btnPrint.TabIndex = 58;
            this.btnPrint.Tag = "ViewPDF";
            this.btnPrint.Text = "View PDF";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAddStrategy
            // 
            this.btnAddStrategy.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddStrategy.Location = new System.Drawing.Point(183, 1);
            this.btnAddStrategy.Name = "btnAddStrategy";
            this.btnAddStrategy.Size = new System.Drawing.Size(203, 40);
            this.btnAddStrategy.TabIndex = 54;
            this.btnAddStrategy.Text = "Add Strat / Tactic";
            this.btnAddStrategy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddStrategy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddStrategy.UseVisualStyleBackColor = true;
            this.btnAddStrategy.Click += new System.EventHandler(this.btnAddStrategy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(523, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 39);
            this.btnDelete.TabIndex = 57;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(392, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 39);
            this.btnEdit.TabIndex = 56;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnNew.Location = new System.Drawing.Point(3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(174, 39);
            this.btnNew.TabIndex = 55;
            this.btnNew.Text = "Add Objective";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // IncidentObjectivesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 538);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(821, 577);
            this.Name = "IncidentObjectivesListForm";
            this.Text = "Incident Objectives";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IncidentObjectivesListForm_FormClosing);
            this.Load += new System.EventHandler(this.IncidentObjectivesListForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cpWeather.ResumeLayout(false);
            this.cpFireStatus.ResumeLayout(false);
            this.cpFireStatus.PerformLayout();
            this.cpSituationalAwareness.ResumeLayout(false);
            this.cpCommandEmphasis.ResumeLayout(false);
            this.cpSafetyPlanRequired.ResumeLayout(false);
            this.cpSafetyPlanRequired.PerformLayout();
            this.cpGeneralSafety.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvObjectives;
        private System.Windows.Forms.Button btnAddStrategy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private CustomControls.CollapsiblePanel cpFireStatus;
        private System.Windows.Forms.ComboBox cboFireStatus;
        private System.Windows.Forms.TextBox txtFireSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CustomControls.CollapsiblePanel cpGeneralSafety;
        private SpellBox txtGeneralSafetyMessage;
        private System.Windows.Forms.ComboBox cboSafetyMessages;
        private System.Windows.Forms.Button btnFillSafetyFrom208;
        private CustomControls.CollapsiblePanel cpWeather;
        private SpellBox txtWeatherForcast;
        private CustomControls.CollapsiblePanel cpSituationalAwareness;
        private SpellBox txtSituationalAwareness;
        private CustomControls.CollapsiblePanel cpCommandEmphasis;
        private SpellBox txtCommandEmphasis;
        private CustomControls.CollapsiblePanel cpSafetyPlanRequired;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private SpellBox txtSafetyPlanLocation;
        private System.Windows.Forms.CheckBox chkSafetyPlanRequired;
    }
}