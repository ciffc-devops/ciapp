namespace Wildfire_ICS_Assist
{
    partial class AirOperationsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirOperationsForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvAircraft = new System.Windows.Forms.DataGridView();
            this.colReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMakeModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPilot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnDeleteAircraft = new System.Windows.Forms.Button();
            this.btnEditAircraft = new System.Windows.Forms.Button();
            this.btnAddAircraft = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteComms = new System.Windows.Forms.Button();
            this.btnEditComms = new System.Windows.Forms.Button();
            this.btnAddComms = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCommsItems = new System.Windows.Forms.DataGridView();
            this.colCommsSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeOrgChart = new System.Windows.Forms.TreeView();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPreparedBy = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNOTAM = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircraft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.btnNOTAM);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.cboPreparedBy);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker2);
            this.splitContainer1.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel2.Controls.Add(this.txtRemarks);
            this.splitContainer1.Size = new System.Drawing.Size(1351, 582);
            this.splitContainer1.SplitterDistance = 362;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvAircraft
            // 
            this.dgvAircraft.AllowUserToAddRows = false;
            this.dgvAircraft.AllowUserToDeleteRows = false;
            this.dgvAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAircraft.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvAircraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAircraft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReg,
            this.colMakeModel,
            this.colBase,
            this.colPilot,
            this.colStart,
            this.colEnd,
            this.colRemarks});
            this.dgvAircraft.Location = new System.Drawing.Point(8, 44);
            this.dgvAircraft.Margin = new System.Windows.Forms.Padding(6);
            this.dgvAircraft.Name = "dgvAircraft";
            this.dgvAircraft.ReadOnly = true;
            this.dgvAircraft.RowHeadersVisible = false;
            this.dgvAircraft.RowTemplate.Height = 35;
            this.dgvAircraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAircraft.Size = new System.Drawing.Size(435, 236);
            this.dgvAircraft.TabIndex = 1;
            // 
            // colReg
            // 
            this.colReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colReg.DataPropertyName = "Registration";
            this.colReg.HeaderText = "Registration";
            this.colReg.Name = "colReg";
            this.colReg.ReadOnly = true;
            this.colReg.Width = 133;
            // 
            // colMakeModel
            // 
            this.colMakeModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMakeModel.DataPropertyName = "MakeModel";
            this.colMakeModel.HeaderText = "Make/Model";
            this.colMakeModel.Name = "colMakeModel";
            this.colMakeModel.ReadOnly = true;
            this.colMakeModel.Width = 139;
            // 
            // colBase
            // 
            this.colBase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBase.DataPropertyName = "Base";
            this.colBase.HeaderText = "Base";
            this.colBase.Name = "colBase";
            this.colBase.ReadOnly = true;
            this.colBase.Width = 77;
            // 
            // colPilot
            // 
            this.colPilot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPilot.DataPropertyName = "Pilot";
            this.colPilot.HeaderText = "Pilot";
            this.colPilot.Name = "colPilot";
            this.colPilot.ReadOnly = true;
            this.colPilot.Width = 70;
            // 
            // colStart
            // 
            this.colStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colStart.DataPropertyName = "StartTime";
            dataGridViewCellStyle1.Format = "MMM-dd HH:mm";
            this.colStart.DefaultCellStyle = dataGridViewCellStyle1;
            this.colStart.HeaderText = "Start";
            this.colStart.Name = "colStart";
            this.colStart.ReadOnly = true;
            this.colStart.Width = 71;
            // 
            // colEnd
            // 
            this.colEnd.DataPropertyName = "EndTime";
            dataGridViewCellStyle2.Format = "MMM-dd HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.colEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.colEnd.HeaderText = "End";
            this.colEnd.Name = "colEnd";
            this.colEnd.ReadOnly = true;
            // 
            // colRemarks
            // 
            this.colRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRemarks.DataPropertyName = "Remarks";
            this.colRemarks.HeaderText = "Remarks";
            this.colRemarks.MinimumWidth = 150;
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.ReadOnly = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteAircraft);
            this.splitContainer2.Panel1.Controls.Add(this.btnEditAircraft);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddAircraft);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.dgvAircraft);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1351, 362);
            this.splitContainer2.SplitterDistance = 449;
            this.splitContainer2.TabIndex = 2;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.treeOrgChart);
            this.splitContainer3.Panel1.Controls.Add(this.btnDeleteRole);
            this.splitContainer3.Panel1.Controls.Add(this.btnEditRole);
            this.splitContainer3.Panel1.Controls.Add(this.btnAssignRole);
            this.splitContainer3.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvCommsItems);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteComms);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditComms);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddComms);
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Size = new System.Drawing.Size(898, 362);
            this.splitContainer3.SplitterDistance = 448;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnDeleteAircraft
            // 
            this.btnDeleteAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAircraft.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteAircraft.Location = new System.Drawing.Point(235, 286);
            this.btnDeleteAircraft.Name = "btnDeleteAircraft";
            this.btnDeleteAircraft.Size = new System.Drawing.Size(113, 73);
            this.btnDeleteAircraft.TabIndex = 53;
            this.btnDeleteAircraft.Text = "Delete";
            this.btnDeleteAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteAircraft.UseVisualStyleBackColor = true;
            // 
            // btnEditAircraft
            // 
            this.btnEditAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditAircraft.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditAircraft.Location = new System.Drawing.Point(116, 286);
            this.btnEditAircraft.Name = "btnEditAircraft";
            this.btnEditAircraft.Size = new System.Drawing.Size(113, 73);
            this.btnEditAircraft.TabIndex = 52;
            this.btnEditAircraft.Text = "Edit";
            this.btnEditAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditAircraft.UseVisualStyleBackColor = true;
            // 
            // btnAddAircraft
            // 
            this.btnAddAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAircraft.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddAircraft.Location = new System.Drawing.Point(8, 286);
            this.btnAddAircraft.Name = "btnAddAircraft";
            this.btnAddAircraft.Size = new System.Drawing.Size(102, 73);
            this.btnAddAircraft.TabIndex = 51;
            this.btnAddAircraft.Text = "Add";
            this.btnAddAircraft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAircraft.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 29);
            this.label4.TabIndex = 50;
            this.label4.Text = "Aircraft";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 55;
            this.label1.Text = "Personnel";
            // 
            // btnDeleteComms
            // 
            this.btnDeleteComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteComms.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteComms.Location = new System.Drawing.Point(240, 286);
            this.btnDeleteComms.Name = "btnDeleteComms";
            this.btnDeleteComms.Size = new System.Drawing.Size(113, 73);
            this.btnDeleteComms.TabIndex = 58;
            this.btnDeleteComms.Text = "Delete";
            this.btnDeleteComms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteComms.UseVisualStyleBackColor = true;
            this.btnDeleteComms.Click += new System.EventHandler(this.btnDeleteComms_Click);
            // 
            // btnEditComms
            // 
            this.btnEditComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditComms.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditComms.Location = new System.Drawing.Point(121, 286);
            this.btnEditComms.Name = "btnEditComms";
            this.btnEditComms.Size = new System.Drawing.Size(113, 73);
            this.btnEditComms.TabIndex = 57;
            this.btnEditComms.Text = "Edit";
            this.btnEditComms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditComms.UseVisualStyleBackColor = true;
            this.btnEditComms.Click += new System.EventHandler(this.btnEditComms_Click);
            // 
            // btnAddComms
            // 
            this.btnAddComms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddComms.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddComms.Location = new System.Drawing.Point(13, 286);
            this.btnAddComms.Name = "btnAddComms";
            this.btnAddComms.Size = new System.Drawing.Size(102, 73);
            this.btnAddComms.TabIndex = 56;
            this.btnAddComms.Text = "Add";
            this.btnAddComms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddComms.UseVisualStyleBackColor = true;
            this.btnAddComms.Click += new System.EventHandler(this.btnAddComms_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 29);
            this.label2.TabIndex = 55;
            this.label2.Text = "Frequencies";
            // 
            // dgvCommsItems
            // 
            this.dgvCommsItems.AllowUserToAddRows = false;
            this.dgvCommsItems.AllowUserToDeleteRows = false;
            this.dgvCommsItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommsItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCommsItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvCommsItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommsItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCommsSystem,
            this.colChannelID,
            this.colFunction,
            this.colFrequency,
            this.colTone,
            this.colComments});
            this.dgvCommsItems.Location = new System.Drawing.Point(13, 41);
            this.dgvCommsItems.Name = "dgvCommsItems";
            this.dgvCommsItems.ReadOnly = true;
            this.dgvCommsItems.RowHeadersVisible = false;
            this.dgvCommsItems.RowTemplate.Height = 30;
            this.dgvCommsItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommsItems.Size = new System.Drawing.Size(421, 239);
            this.dgvCommsItems.TabIndex = 59;
            // 
            // colCommsSystem
            // 
            this.colCommsSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCommsSystem.DataPropertyName = "CommsSystem";
            this.colCommsSystem.HeaderText = "Comms System";
            this.colCommsSystem.Name = "colCommsSystem";
            this.colCommsSystem.ReadOnly = true;
            this.colCommsSystem.Width = 166;
            // 
            // colChannelID
            // 
            this.colChannelID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colChannelID.DataPropertyName = "ChannelID";
            this.colChannelID.HeaderText = "Channel";
            this.colChannelID.Name = "colChannelID";
            this.colChannelID.ReadOnly = true;
            this.colChannelID.Width = 106;
            // 
            // colFunction
            // 
            this.colFunction.DataPropertyName = "CommsFunction";
            this.colFunction.HeaderText = "Function";
            this.colFunction.Name = "colFunction";
            this.colFunction.ReadOnly = true;
            this.colFunction.Width = 109;
            // 
            // colFrequency
            // 
            this.colFrequency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFrequency.DataPropertyName = "Frequency";
            this.colFrequency.HeaderText = "Frequency";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.ReadOnly = true;
            this.colFrequency.Width = 127;
            // 
            // colTone
            // 
            this.colTone.DataPropertyName = "Tone";
            this.colTone.HeaderText = "Tone";
            this.colTone.Name = "colTone";
            this.colTone.ReadOnly = true;
            this.colTone.Width = 80;
            // 
            // colComments
            // 
            this.colComments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComments.DataPropertyName = "Comments";
            this.colComments.HeaderText = "Remarks";
            this.colComments.MinimumWidth = 100;
            this.colComments.Name = "colComments";
            this.colComments.ReadOnly = true;
            // 
            // treeOrgChart
            // 
            this.treeOrgChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeOrgChart.Location = new System.Drawing.Point(8, 41);
            this.treeOrgChart.Name = "treeOrgChart";
            this.treeOrgChart.Size = new System.Drawing.Size(437, 239);
            this.treeOrgChart.TabIndex = 56;
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteRole.Location = new System.Drawing.Point(314, 286);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(123, 73);
            this.btnDeleteRole.TabIndex = 60;
            this.btnDeleteRole.Text = "Remove Role";
            this.btnDeleteRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditRole.Location = new System.Drawing.Point(219, 286);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(89, 73);
            this.btnEditRole.TabIndex = 59;
            this.btnEditRole.Text = "Edit Role";
            this.btnEditRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnAssignRole
            // 
            this.btnAssignRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAssignRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAssignRole.Location = new System.Drawing.Point(101, 286);
            this.btnAssignRole.Name = "btnAssignRole";
            this.btnAssignRole.Size = new System.Drawing.Size(112, 73);
            this.btnAssignRole.TabIndex = 58;
            this.btnAssignRole.Text = "Assign Role";
            this.btnAssignRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignRole.UseVisualStyleBackColor = true;
            this.btnAssignRole.Click += new System.EventHandler(this.btnAssignRole_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAdd.Location = new System.Drawing.Point(3, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 73);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add Role";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(12, 38);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(986, 163);
            this.txtRemarks.TabIndex = 0;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(1082, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(88, 29);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.CustomFormat = "HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(1251, 79);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(88, 29);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(1002, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 32);
            this.label5.TabIndex = 60;
            this.label5.Text = "Prepared By";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPreparedBy
            // 
            this.cboPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPreparedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreparedBy.FormattingEnabled = true;
            this.cboPreparedBy.Location = new System.Drawing.Point(1140, 116);
            this.cboPreparedBy.Name = "cboPreparedBy";
            this.cboPreparedBy.Size = new System.Drawing.Size(199, 32);
            this.cboPreparedBy.TabIndex = 59;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(1226, 159);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 57;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 29);
            this.label6.TabIndex = 62;
            this.label6.Text = "Remarks";
            // 
            // btnNOTAM
            // 
            this.btnNOTAM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNOTAM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnNOTAM.Image = ((System.Drawing.Image)(resources.GetObject("btnNOTAM.Image")));
            this.btnNOTAM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNOTAM.Location = new System.Drawing.Point(1140, 11);
            this.btnNOTAM.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnNOTAM.Name = "btnNOTAM";
            this.btnNOTAM.Size = new System.Drawing.Size(199, 61);
            this.btnNOTAM.TabIndex = 63;
            this.btnNOTAM.Text = "NOTAM";
            this.btnNOTAM.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNOTAM.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1002, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 24);
            this.label7.TabIndex = 64;
            this.label7.Text = "Sunrise";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1176, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 24);
            this.label8.TabIndex = 65;
            this.label8.Text = "Sunset";
            // 
            // AirOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 582);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1367, 621);
            this.Name = "AirOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Air Operations Summary";
            this.Load += new System.EventHandler(this.AirOperationsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAircraft)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvAircraft;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMakeModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPilot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemarks;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDeleteAircraft;
        private System.Windows.Forms.Button btnEditAircraft;
        private System.Windows.Forms.Button btnAddAircraft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteComms;
        private System.Windows.Forms.Button btnEditComms;
        private System.Windows.Forms.Button btnAddComms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCommsItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommsSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPreparedBy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNOTAM;
    }
}