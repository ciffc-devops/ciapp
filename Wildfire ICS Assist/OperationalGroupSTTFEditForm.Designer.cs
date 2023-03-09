namespace Wildfire_ICS_Assist
{
    partial class OperationalGroupSTTFEditForm
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
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSupervisor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboReportsTo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvSubGroups = new System.Windows.Forms.DataGridView();
            this.btnAddCrew = new System.Windows.Forms.Button();
            this.cmsAddCrew = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addExistingCrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSingle = new System.Windows.Forms.Button();
            this.cmsAddSingle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewEquipmentVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.btnEditResource = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).BeginInit();
            this.cmsAddCrew.SuspendLayout();
            this.cmsAddSingle.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Strike Team",
            "Task Force",
            "Group",
            "SIngle Resource"});
            this.cboType.Location = new System.Drawing.Point(136, 10);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(267, 32);
            this.cboType.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 29);
            this.label3.TabIndex = 97;
            this.label3.Text = "Identifier*:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentifier.Location = new System.Drawing.Point(136, 48);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(267, 29);
            this.txtIdentifier.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(507, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 94;
            this.label2.Text = "Reports to:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 96;
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSupervisor
            // 
            this.cboSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSupervisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupervisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupervisor.DisplayMember = "Name";
            this.cboSupervisor.FormattingEnabled = true;
            this.cboSupervisor.Location = new System.Drawing.Point(620, 46);
            this.cboSupervisor.Name = "cboSupervisor";
            this.cboSupervisor.Size = new System.Drawing.Size(414, 32);
            this.cboSupervisor.TabIndex = 100;
            this.toolTip1.SetToolTip(this.cboSupervisor, "Use the Check-In feature to add additional personnel");
            this.cboSupervisor.ValueMember = "PersonID";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(429, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 29);
            this.label4.TabIndex = 99;
            this.label4.Text = "Leader / Supervisor:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboReportsTo
            // 
            this.cboReportsTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReportsTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReportsTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReportsTo.DisplayMember = "RoleNameForDropdown";
            this.cboReportsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportsTo.FormattingEnabled = true;
            this.cboReportsTo.Location = new System.Drawing.Point(620, 8);
            this.cboReportsTo.Name = "cboReportsTo";
            this.cboReportsTo.Size = new System.Drawing.Size(414, 32);
            this.cboReportsTo.TabIndex = 95;
            this.cboReportsTo.ValueMember = "RoleID";
            this.cboReportsTo.Leave += new System.EventHandler(this.cboReportsTo_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(23, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 29);
            this.label5.TabIndex = 102;
            this.label5.Text = "Comments";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(136, 118);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(898, 62);
            this.txtComments.TabIndex = 103;
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(1046, 650);
            this.splitContainer1.SplitterDistance = 582;
            this.splitContainer1.TabIndex = 104;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtContact);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.cboType);
            this.splitContainer2.Panel1.Controls.Add(this.txtComments);
            this.splitContainer2.Panel1.Controls.Add(this.txtIdentifier);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.cboReportsTo);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.cboSupervisor);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1046, 582);
            this.splitContainer2.SplitterDistance = 188;
            this.splitContainer2.TabIndex = 104;
            // 
            // txtContact
            // 
            this.txtContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContact.Location = new System.Drawing.Point(136, 83);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(267, 29);
            this.txtContact.TabIndex = 105;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(23, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 29);
            this.label6.TabIndex = 104;
            this.label6.Text = "Contact:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvSubGroups);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnAddCrew);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddSingle);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteResource);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditResource);
            this.splitContainer3.Size = new System.Drawing.Size(1046, 390);
            this.splitContainer3.SplitterDistance = 336;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvSubGroups
            // 
            this.dgvSubGroups.AllowUserToAddRows = false;
            this.dgvSubGroups.AllowUserToDeleteRows = false;
            this.dgvSubGroups.AllowUserToResizeColumns = false;
            this.dgvSubGroups.AllowUserToResizeRows = false;
            this.dgvSubGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colName,
            this.colLeader,
            this.colNumberOfPeople,
            this.colNumberOfVehicles});
            this.dgvSubGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubGroups.Location = new System.Drawing.Point(0, 0);
            this.dgvSubGroups.Name = "dgvSubGroups";
            this.dgvSubGroups.ReadOnly = true;
            this.dgvSubGroups.RowHeadersVisible = false;
            this.dgvSubGroups.RowTemplate.Height = 30;
            this.dgvSubGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubGroups.Size = new System.Drawing.Size(1046, 336);
            this.dgvSubGroups.TabIndex = 3;
            this.dgvSubGroups.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSubGroups_CellFormatting);
            this.dgvSubGroups.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSubGroups_RowPostPaint);
            this.dgvSubGroups.SelectionChanged += new System.EventHandler(this.dgvSubGroups_SelectionChanged);
            // 
            // btnAddCrew
            // 
            this.btnAddCrew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddCrew.ContextMenuStrip = this.cmsAddCrew;
            this.btnAddCrew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCrew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddCrew.Location = new System.Drawing.Point(258, 3);
            this.btnAddCrew.Name = "btnAddCrew";
            this.btnAddCrew.Size = new System.Drawing.Size(145, 42);
            this.btnAddCrew.TabIndex = 107;
            this.btnAddCrew.Text = "Add Crew";
            this.btnAddCrew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCrew.UseVisualStyleBackColor = true;
            this.btnAddCrew.Click += new System.EventHandler(this.btnAddCrew_Click);
            // 
            // cmsAddCrew
            // 
            this.cmsAddCrew.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsAddCrew.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addExistingCrewToolStripMenuItem,
            this.createNewCrewToolStripMenuItem});
            this.cmsAddCrew.Name = "cmsAddCrew";
            this.cmsAddCrew.Size = new System.Drawing.Size(234, 64);
            // 
            // addExistingCrewToolStripMenuItem
            // 
            this.addExistingCrewToolStripMenuItem.Name = "addExistingCrewToolStripMenuItem";
            this.addExistingCrewToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.addExistingCrewToolStripMenuItem.Text = "Add existing crew";
            // 
            // createNewCrewToolStripMenuItem
            // 
            this.createNewCrewToolStripMenuItem.Name = "createNewCrewToolStripMenuItem";
            this.createNewCrewToolStripMenuItem.Size = new System.Drawing.Size(233, 30);
            this.createNewCrewToolStripMenuItem.Text = "Create new crew";
            // 
            // btnAddSingle
            // 
            this.btnAddSingle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddSingle.ContextMenuStrip = this.cmsAddSingle;
            this.btnAddSingle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSingle.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSingle.Location = new System.Drawing.Point(6, 3);
            this.btnAddSingle.Name = "btnAddSingle";
            this.btnAddSingle.Size = new System.Drawing.Size(246, 42);
            this.btnAddSingle.TabIndex = 106;
            this.btnAddSingle.Text = "Add Single Resource";
            this.btnAddSingle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSingle.UseVisualStyleBackColor = true;
            this.btnAddSingle.Click += new System.EventHandler(this.btnAddSingle_Click);
            // 
            // cmsAddSingle
            // 
            this.cmsAddSingle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsAddSingle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewPersonToolStripMenuItem,
            this.createNewEquipmentVehicleToolStripMenuItem});
            this.cmsAddSingle.Name = "cmsAddSingle";
            this.cmsAddSingle.Size = new System.Drawing.Size(293, 64);
            // 
            // createNewPersonToolStripMenuItem
            // 
            this.createNewPersonToolStripMenuItem.Name = "createNewPersonToolStripMenuItem";
            this.createNewPersonToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.createNewPersonToolStripMenuItem.Text = "Add personnel";
            this.createNewPersonToolStripMenuItem.Click += new System.EventHandler(this.createNewPersonToolStripMenuItem_Click);
            // 
            // createNewEquipmentVehicleToolStripMenuItem
            // 
            this.createNewEquipmentVehicleToolStripMenuItem.Name = "createNewEquipmentVehicleToolStripMenuItem";
            this.createNewEquipmentVehicleToolStripMenuItem.Size = new System.Drawing.Size(292, 30);
            this.createNewEquipmentVehicleToolStripMenuItem.Text = "Add Equipment / Vehicle";
            this.createNewEquipmentVehicleToolStripMenuItem.Click += new System.EventHandler(this.createNewEquipmentVehicleToolStripMenuItem_Click);
            // 
            // btnDeleteResource
            // 
            this.btnDeleteResource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteResource.Enabled = false;
            this.btnDeleteResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteResource.Location = new System.Drawing.Point(528, 2);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteResource.TabIndex = 54;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
            // 
            // btnEditResource
            // 
            this.btnEditResource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditResource.Enabled = false;
            this.btnEditResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditResource.Location = new System.Drawing.Point(409, 2);
            this.btnEditResource.Name = "btnEditResource";
            this.btnEditResource.Size = new System.Drawing.Size(113, 42);
            this.btnEditResource.TabIndex = 53;
            this.btnEditResource.Text = "Edit";
            this.btnEditResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditResource.UseVisualStyleBackColor = true;
            this.btnEditResource.Click += new System.EventHandler(this.btnEditResource_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(909, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNumber.HeaderText = "#";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            this.colNumber.Width = 45;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.HeaderText = "Resource Name";
            this.colName.MinimumWidth = 250;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colLeader
            // 
            this.colLeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLeader.DataPropertyName = "LeaderName";
            this.colLeader.HeaderText = "Resource Leader";
            this.colLeader.Name = "colLeader";
            this.colLeader.ReadOnly = true;
            this.colLeader.Width = 165;
            // 
            // colNumberOfPeople
            // 
            this.colNumberOfPeople.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNumberOfPeople.DataPropertyName = "NumberOfPeople";
            this.colNumberOfPeople.HeaderText = "# of People";
            this.colNumberOfPeople.Name = "colNumberOfPeople";
            this.colNumberOfPeople.ReadOnly = true;
            this.colNumberOfPeople.Width = 119;
            // 
            // colNumberOfVehicles
            // 
            this.colNumberOfVehicles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNumberOfVehicles.DataPropertyName = "NumberOfVehicles";
            this.colNumberOfVehicles.HeaderText = "# of Vehicles/Equip";
            this.colNumberOfVehicles.Name = "colNumberOfVehicles";
            this.colNumberOfVehicles.ReadOnly = true;
            this.colNumberOfVehicles.Width = 180;
            // 
            // OperationalGroupSTTFEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 650);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1043, 537);
            this.Name = "OperationalGroupSTTFEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Strike Team / Task Force / Group";
            this.Load += new System.EventHandler(this.OperationalGroupSTTFEditForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).EndInit();
            this.cmsAddCrew.ResumeLayout(false);
            this.cmsAddSingle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSupervisor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboReportsTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.Button btnEditResource;
        private System.Windows.Forms.DataGridView dgvSubGroups;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddCrew;
        private System.Windows.Forms.Button btnAddSingle;
        private System.Windows.Forms.ContextMenuStrip cmsAddSingle;
        private System.Windows.Forms.ToolStripMenuItem createNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewEquipmentVehicleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsAddCrew;
        private System.Windows.Forms.ToolStripMenuItem addExistingCrewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCrewToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfVehicles;
    }
}