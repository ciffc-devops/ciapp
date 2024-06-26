﻿namespace Wildfire_ICS_Assist
{
    partial class IncidentObjectivesForm
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
            this.dgvObjectives = new System.Windows.Forms.DataGridView();
            this.colObjective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDown = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cpFireStatus = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboFireStatus = new System.Windows.Forms.ComboBox();
            this.txtFireSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cpWeather = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cpGeneralSafety = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboSafetyMessages = new System.Windows.Forms.ComboBox();
            this.btnFillSafetyFrom208 = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtWeatherForcast = new SpellBox();
            this.txtGeneralSafetyMessage = new SpellBox();
            this.cpPrepared = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboPreparedBy = new System.Windows.Forms.ComboBox();
            this.cboApprovedBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).BeginInit();
            this.cpFireStatus.SuspendLayout();
            this.cpWeather.SuspendLayout();
            this.cpGeneralSafety.SuspendLayout();
            this.cpPrepared.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnNew);
            this.splitContainer1.Size = new System.Drawing.Size(878, 440);
            this.splitContainer1.SplitterDistance = 375;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.dgvObjectives);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cpPrepared);
            this.splitContainer2.Panel2.Controls.Add(this.cpWeather);
            this.splitContainer2.Panel2.Controls.Add(this.cpGeneralSafety);
            this.splitContainer2.Panel2.Controls.Add(this.cpFireStatus);
            this.splitContainer2.Size = new System.Drawing.Size(878, 375);
            this.splitContainer2.SplitterDistance = 376;
            this.splitContainer2.TabIndex = 2;
            // 
            // dgvObjectives
            // 
            this.dgvObjectives.AllowUserToAddRows = false;
            this.dgvObjectives.AllowUserToDeleteRows = false;
            this.dgvObjectives.AllowUserToResizeColumns = false;
            this.dgvObjectives.AllowUserToResizeRows = false;
            this.dgvObjectives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvObjectives.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvObjectives.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvObjectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObjective,
            this.colUp,
            this.colDown});
            this.dgvObjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObjectives.Location = new System.Drawing.Point(0, 0);
            this.dgvObjectives.Name = "dgvObjectives";
            this.dgvObjectives.ReadOnly = true;
            this.dgvObjectives.RowHeadersVisible = false;
            this.dgvObjectives.RowTemplate.Height = 30;
            this.dgvObjectives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjectives.Size = new System.Drawing.Size(376, 375);
            this.dgvObjectives.TabIndex = 0;
            this.dgvObjectives.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellContentClick);
            this.dgvObjectives.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellContentDoubleClick);
            this.dgvObjectives.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellDoubleClick);
            this.dgvObjectives.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvObjectives_CellPainting);
            this.dgvObjectives.SelectionChanged += new System.EventHandler(this.dgvObjectives_SelectionChanged);
            // 
            // colObjective
            // 
            this.colObjective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObjective.DataPropertyName = "Objective";
            this.colObjective.HeaderText = "Objective";
            this.colObjective.MinimumWidth = 200;
            this.colObjective.Name = "colObjective";
            this.colObjective.ReadOnly = true;
            // 
            // colUp
            // 
            this.colUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUp.HeaderText = "";
            this.colUp.Name = "colUp";
            this.colUp.ReadOnly = true;
            this.colUp.Width = 65;
            // 
            // colDown
            // 
            this.colDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDown.HeaderText = "";
            this.colDown.Name = "colDown";
            this.colDown.ReadOnly = true;
            this.colDown.Width = 65;
            // 
            // cpFireStatus
            // 
            this.cpFireStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFireStatus.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFireStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFireStatus.CollapsedHeight = 40;
            this.cpFireStatus.CollapsedWidth = 485;
            this.cpFireStatus.CollapseLeft = true;
            this.cpFireStatus.Controls.Add(this.cboFireStatus);
            this.cpFireStatus.Controls.Add(this.txtFireSize);
            this.cpFireStatus.Controls.Add(this.label2);
            this.cpFireStatus.Controls.Add(this.label1);
            this.cpFireStatus.CurrentlyCollapsed = true;
            this.cpFireStatus.ExpandedHeight = 137;
            this.cpFireStatus.ExpandedWidth = 485;
            this.cpFireStatus.ExpandUp = false;
            this.cpFireStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpFireStatus.Location = new System.Drawing.Point(10, 119);
            this.cpFireStatus.Margin = new System.Windows.Forms.Padding(6);
            this.cpFireStatus.Name = "cpFireStatus";
            this.cpFireStatus.Size = new System.Drawing.Size(485, 40);
            this.cpFireStatus.TabIndex = 60;
            this.cpFireStatus.TitleText = "Fire Size / Status";
            // 
            // cboFireStatus
            // 
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
            this.cboFireStatus.Size = new System.Drawing.Size(183, 32);
            this.cboFireStatus.TabIndex = 38;
            this.cboFireStatus.Leave += new System.EventHandler(this.cboFireStatus_Leave);
            // 
            // txtFireSize
            // 
            this.txtFireSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtFireSize.Location = new System.Drawing.Point(120, 48);
            this.txtFireSize.Name = "txtFireSize";
            this.txtFireSize.Size = new System.Drawing.Size(183, 29);
            this.txtFireSize.TabIndex = 37;
            this.txtFireSize.Leave += new System.EventHandler(this.txtFireSize_Leave);
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
            // cpWeather
            // 
            this.cpWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpWeather.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpWeather.CollapsedHeight = 40;
            this.cpWeather.CollapsedWidth = 485;
            this.cpWeather.CollapseLeft = true;
            this.cpWeather.Controls.Add(this.txtWeatherForcast);
            this.cpWeather.CurrentlyCollapsed = true;
            this.cpWeather.ExpandedHeight = 260;
            this.cpWeather.ExpandedWidth = 485;
            this.cpWeather.ExpandUp = false;
            this.cpWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpWeather.Location = new System.Drawing.Point(10, 15);
            this.cpWeather.Margin = new System.Windows.Forms.Padding(6);
            this.cpWeather.Name = "cpWeather";
            this.cpWeather.Size = new System.Drawing.Size(485, 40);
            this.cpWeather.TabIndex = 58;
            this.cpWeather.TitleText = "Weather Forecast";
            // 
            // cpGeneralSafety
            // 
            this.cpGeneralSafety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpGeneralSafety.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpGeneralSafety.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpGeneralSafety.CollapsedHeight = 40;
            this.cpGeneralSafety.CollapsedWidth = 485;
            this.cpGeneralSafety.CollapseLeft = true;
            this.cpGeneralSafety.Controls.Add(this.txtGeneralSafetyMessage);
            this.cpGeneralSafety.Controls.Add(this.cboSafetyMessages);
            this.cpGeneralSafety.Controls.Add(this.btnFillSafetyFrom208);
            this.cpGeneralSafety.CurrentlyCollapsed = true;
            this.cpGeneralSafety.ExpandedHeight = 300;
            this.cpGeneralSafety.ExpandedWidth = 485;
            this.cpGeneralSafety.ExpandUp = false;
            this.cpGeneralSafety.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpGeneralSafety.Location = new System.Drawing.Point(10, 67);
            this.cpGeneralSafety.Margin = new System.Windows.Forms.Padding(6);
            this.cpGeneralSafety.Name = "cpGeneralSafety";
            this.cpGeneralSafety.Size = new System.Drawing.Size(485, 40);
            this.cpGeneralSafety.TabIndex = 59;
            this.cpGeneralSafety.TitleText = "General Safety Message";
            // 
            // cboSafetyMessages
            // 
            this.cboSafetyMessages.DisplayMember = "SummaryLine";
            this.cboSafetyMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSafetyMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboSafetyMessages.FormattingEnabled = true;
            this.cboSafetyMessages.Location = new System.Drawing.Point(176, 257);
            this.cboSafetyMessages.Name = "cboSafetyMessages";
            this.cboSafetyMessages.Size = new System.Drawing.Size(302, 32);
            this.cboSafetyMessages.TabIndex = 35;
            this.cboSafetyMessages.ValueMember = "ID";
            // 
            // btnFillSafetyFrom208
            // 
            this.btnFillSafetyFrom208.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnFillSafetyFrom208.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_302_square_download;
            this.btnFillSafetyFrom208.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFillSafetyFrom208.Location = new System.Drawing.Point(7, 249);
            this.btnFillSafetyFrom208.Name = "btnFillSafetyFrom208";
            this.btnFillSafetyFrom208.Size = new System.Drawing.Size(163, 46);
            this.btnFillSafetyFrom208.TabIndex = 34;
            this.btnFillSafetyFrom208.Text = "Fill from 208";
            this.btnFillSafetyFrom208.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFillSafetyFrom208.UseVisualStyleBackColor = true;
            this.btnFillSafetyFrom208.Click += new System.EventHandler(this.btnFillSafetyFrom208_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(753, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(274, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 51);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(143, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 51);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnNew.Location = new System.Drawing.Point(12, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 51);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "Add";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 65;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Width = 65;
            // 
            // txtWeatherForcast
            // 
            this.txtWeatherForcast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtWeatherForcast.Location = new System.Drawing.Point(7, 51);
            this.txtWeatherForcast.Multiline = true;
            this.txtWeatherForcast.Name = "txtWeatherForcast";
            this.txtWeatherForcast.Size = new System.Drawing.Size(471, 204);
            this.txtWeatherForcast.TabIndex = 34;
            this.txtWeatherForcast.WordWrap = true;
            this.txtWeatherForcast.Child = new System.Windows.Controls.TextBox();
            // 
            // txtGeneralSafetyMessage
            // 
            this.txtGeneralSafetyMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.txtGeneralSafetyMessage.Location = new System.Drawing.Point(7, 51);
            this.txtGeneralSafetyMessage.Multiline = true;
            this.txtGeneralSafetyMessage.Name = "txtGeneralSafetyMessage";
            this.txtGeneralSafetyMessage.Size = new System.Drawing.Size(471, 192);
            this.txtGeneralSafetyMessage.TabIndex = 36;
            this.txtGeneralSafetyMessage.WordWrap = true;
            this.txtGeneralSafetyMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // cpPrepared
            // 
            this.cpPrepared.BackColor = System.Drawing.Color.White;
            this.cpPrepared.BackgroundColorCollapsed = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpPrepared.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpPrepared.CollapsedHeight = 40;
            this.cpPrepared.CollapsedWidth = 485;
            this.cpPrepared.CollapseLeft = true;
            this.cpPrepared.Controls.Add(this.label4);
            this.cpPrepared.Controls.Add(this.label3);
            this.cpPrepared.Controls.Add(this.cboApprovedBy);
            this.cpPrepared.Controls.Add(this.cboPreparedBy);
            this.cpPrepared.CurrentlyCollapsed = false;
            this.cpPrepared.ExpandedHeight = 140;
            this.cpPrepared.ExpandedWidth = 485;
            this.cpPrepared.ExpandUp = false;
            this.cpPrepared.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpPrepared.Location = new System.Drawing.Point(10, 168);
            this.cpPrepared.Margin = new System.Windows.Forms.Padding(6);
            this.cpPrepared.Name = "cpPrepared";
            this.cpPrepared.Size = new System.Drawing.Size(485, 140);
            this.cpPrepared.TabIndex = 61;
            this.cpPrepared.TitleText = "Prepared and Approved";
            // 
            // cboPreparedBy
            // 
            this.cboPreparedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPreparedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPreparedBy.FormattingEnabled = true;
            this.cboPreparedBy.Location = new System.Drawing.Point(140, 51);
            this.cboPreparedBy.Name = "cboPreparedBy";
            this.cboPreparedBy.Size = new System.Drawing.Size(335, 32);
            this.cboPreparedBy.TabIndex = 33;
            this.cboPreparedBy.Leave += new System.EventHandler(this.cboPreparedBy_Leave);
            // 
            // cboApprovedBy
            // 
            this.cboApprovedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboApprovedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboApprovedBy.FormattingEnabled = true;
            this.cboApprovedBy.Location = new System.Drawing.Point(140, 89);
            this.cboApprovedBy.Name = "cboApprovedBy";
            this.cboApprovedBy.Size = new System.Drawing.Size(335, 32);
            this.cboApprovedBy.TabIndex = 34;
            this.cboApprovedBy.Leave += new System.EventHandler(this.cboApprovedBy_Leave);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(7, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 32);
            this.label3.TabIndex = 35;
            this.label3.Text = "Prepared by";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 36;
            this.label4.Text = "Approved by";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IncidentObjectivesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(878, 440);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(894, 479);
            this.Name = "IncidentObjectivesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Incident Objectives";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IncidentObjectivesForm_FormClosing);
            this.Load += new System.EventHandler(this.IncidentObjectivesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).EndInit();
            this.cpFireStatus.ResumeLayout(false);
            this.cpFireStatus.PerformLayout();
            this.cpWeather.ResumeLayout(false);
            this.cpGeneralSafety.ResumeLayout(false);
            this.cpPrepared.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvObjectives;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControls.CollapsiblePanel cpGeneralSafety;
        private CustomControls.CollapsiblePanel cpWeather;
        private CustomControls.CollapsiblePanel cpFireStatus;
        private System.Windows.Forms.ComboBox cboFireStatus;
        private System.Windows.Forms.TextBox txtFireSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjective;
        private System.Windows.Forms.DataGridViewButtonColumn colUp;
        private System.Windows.Forms.DataGridViewButtonColumn colDown;
        private System.Windows.Forms.ComboBox cboSafetyMessages;
        private System.Windows.Forms.Button btnFillSafetyFrom208;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private SpellBox txtWeatherForcast;
        private SpellBox txtGeneralSafetyMessage;
        private CustomControls.CollapsiblePanel cpPrepared;
        private System.Windows.Forms.ComboBox cboApprovedBy;
        private System.Windows.Forms.ComboBox cboPreparedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}