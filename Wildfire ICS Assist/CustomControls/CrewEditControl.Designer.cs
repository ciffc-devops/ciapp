namespace Wildfire_ICS_Assist.CustomControls
{
    partial class CrewEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrewEditControl));
            this.label11 = new System.Windows.Forms.Label();
            this.lblIdentifierLabel = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.colVariety = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUniqueId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateUniqueIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            this.btnEditSelected = new System.Windows.Forms.Button();
            this.btnRemoveFromCrew = new System.Windows.Forms.Button();
            this.cboCrewType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbCrew = new System.Windows.Forms.RadioButton();
            this.rbHECrew = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.btnChangeID = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAgency = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(-10, 193);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 23);
            this.label11.TabIndex = 115;
            this.label11.Text = "(within incident)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIdentifierLabel
            // 
            this.lblIdentifierLabel.Location = new System.Drawing.Point(-13, 10);
            this.lblIdentifierLabel.Name = "lblIdentifierLabel";
            this.lblIdentifierLabel.Size = new System.Drawing.Size(157, 29);
            this.lblIdentifierLabel.TabIndex = 111;
            this.lblIdentifierLabel.Text = "Crew Identifier*:";
            this.lblIdentifierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransport
            // 
            this.txtTransport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransport.Location = new System.Drawing.Point(156, 169);
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(565, 29);
            this.txtTransport.TabIndex = 5;
            this.txtTransport.TextChanged += new System.EventHandler(this.txtTransport_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-10, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 29);
            this.label5.TabIndex = 113;
            this.label5.Text = "Transport:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 29);
            this.label6.TabIndex = 119;
            this.label6.Text = "Email:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(84, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(308, 29);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 29);
            this.label1.TabIndex = 118;
            this.label1.Text = "Cellphone:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(175, 3);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(179, 29);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 35);
            this.label2.TabIndex = 122;
            this.label2.Text = "Edit roles directly in the grid";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteResource
            // 
            this.btnDeleteResource.Enabled = false;
            this.btnDeleteResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteResource.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteResource.Location = new System.Drawing.Point(2, 392);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(157, 67);
            this.btnDeleteResource.TabIndex = 10;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeColumns = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVariety,
            this.colUniqueId,
            this.colName,
            this.colKind,
            this.colType,
            this.colLeader});
            this.dgvGroup.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroup.Location = new System.Drawing.Point(0, 0);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowTemplate.Height = 30;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(577, 482);
            this.dgvGroup.TabIndex = 8;
            this.dgvGroup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGroup_CellFormatting);
            this.dgvGroup.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvGroup_EditingControlShowing);
            this.dgvGroup.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // colVariety
            // 
            this.colVariety.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariety.DataPropertyName = "ResourceType";
            this.colVariety.HeaderText = "Category";
            this.colVariety.Name = "colVariety";
            this.colVariety.Visible = false;
            // 
            // colUniqueId
            // 
            this.colUniqueId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUniqueId.DataPropertyName = "UniqueIDNumWithPrefix";
            this.colUniqueId.HeaderText = "ID";
            this.colUniqueId.Name = "colUniqueId";
            this.colUniqueId.ReadOnly = true;
            this.colUniqueId.Width = 52;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.HeaderText = "Resource Name";
            this.colName.MinimumWidth = 200;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colKind
            // 
            this.colKind.DataPropertyName = "Kind";
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            this.colKind.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colLeader
            // 
            this.colLeader.DataPropertyName = "Role";
            this.colLeader.HeaderText = "Role";
            this.colLeader.Items.AddRange(new object[] {
            "Crew Leader",
            "Sub-Leader",
            "Squad Boss",
            "Crew Member"});
            this.colLeader.Name = "colLeader";
            this.colLeader.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLeader.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.updateUniqueIDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // updateUniqueIDToolStripMenuItem
            // 
            this.updateUniqueIDToolStripMenuItem.Name = "updateUniqueIDToolStripMenuItem";
            this.updateUniqueIDToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.updateUniqueIDToolStripMenuItem.Text = "Update Unique ID";
            this.updateUniqueIDToolStripMenuItem.Click += new System.EventHandler(this.updateUniqueIDToolStripMenuItem_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_893_user_worker;
            this.btnAddPerson.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPerson.Location = new System.Drawing.Point(3, 3);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(157, 67);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Enabled = false;
            this.btnAddVehicle.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_29_cars;
            this.btnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddVehicle.Location = new System.Drawing.Point(2, 76);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(157, 67);
            this.btnAddVehicle.TabIndex = 7;
            this.btnAddVehicle.Text = "Add Veh/Equip";
            this.btnAddVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // btnEditSelected
            // 
            this.btnEditSelected.Enabled = false;
            this.btnEditSelected.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditSelected.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditSelected.Location = new System.Drawing.Point(2, 149);
            this.btnEditSelected.Name = "btnEditSelected";
            this.btnEditSelected.Size = new System.Drawing.Size(157, 67);
            this.btnEditSelected.TabIndex = 8;
            this.btnEditSelected.Text = "Edit Selected";
            this.btnEditSelected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditSelected.UseVisualStyleBackColor = true;
            this.btnEditSelected.Click += new System.EventHandler(this.btnEditSelected_Click);
            // 
            // btnRemoveFromCrew
            // 
            this.btnRemoveFromCrew.Enabled = false;
            this.btnRemoveFromCrew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_372_minus;
            this.btnRemoveFromCrew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemoveFromCrew.Location = new System.Drawing.Point(2, 295);
            this.btnRemoveFromCrew.Name = "btnRemoveFromCrew";
            this.btnRemoveFromCrew.Size = new System.Drawing.Size(157, 91);
            this.btnRemoveFromCrew.TabIndex = 9;
            this.btnRemoveFromCrew.Text = "Remove from Crew";
            this.btnRemoveFromCrew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveFromCrew.UseVisualStyleBackColor = true;
            this.btnRemoveFromCrew.Click += new System.EventHandler(this.btnRemoveFromCrew_Click);
            // 
            // cboCrewType
            // 
            this.cboCrewType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCrewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCrewType.FormattingEnabled = true;
            this.cboCrewType.Items.AddRange(new object[] {
            "Type 1",
            "Type 2",
            "Type 3",
            "Type 4",
            "Type 5",
            "Type 6",
            "Type 7"});
            this.cboCrewType.Location = new System.Drawing.Point(156, 45);
            this.cboCrewType.Name = "cboCrewType";
            this.cboCrewType.Size = new System.Drawing.Size(565, 32);
            this.cboCrewType.TabIndex = 2;
            this.cboCrewType.SelectedIndexChanged += new System.EventHandler(this.cboCrewType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-13, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 29);
            this.label3.TabIndex = 126;
            this.label3.Text = "Crew Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbCrew
            // 
            this.rbCrew.AutoSize = true;
            this.rbCrew.Checked = true;
            this.rbCrew.Location = new System.Drawing.Point(3, 465);
            this.rbCrew.Name = "rbCrew";
            this.rbCrew.Size = new System.Drawing.Size(72, 28);
            this.rbCrew.TabIndex = 128;
            this.rbCrew.TabStop = true;
            this.rbCrew.Text = "Crew";
            this.rbCrew.UseVisualStyleBackColor = true;
            this.rbCrew.Visible = false;
            this.rbCrew.CheckedChanged += new System.EventHandler(this.rbCrew_CheckedChanged);
            // 
            // rbHECrew
            // 
            this.rbHECrew.AutoSize = true;
            this.rbHECrew.Location = new System.Drawing.Point(0, 489);
            this.rbHECrew.Name = "rbHECrew";
            this.rbHECrew.Size = new System.Drawing.Size(227, 28);
            this.rbHECrew.TabIndex = 129;
            this.rbHECrew.Text = "Heavy Equipment Crew";
            this.rbHECrew.UseVisualStyleBackColor = true;
            this.rbHECrew.Visible = false;
            this.rbHECrew.CheckedChanged += new System.EventHandler(this.rbHECrew_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(-35, 130);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtPhone);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(756, 33);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 131;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(156, 6);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(583, 33);
            this.txtName.TabIndex = 130;
            // 
            // btnChangeID
            // 
            this.btnChangeID.Enabled = false;
            this.btnChangeID.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_740_hash;
            this.btnChangeID.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnChangeID.Location = new System.Drawing.Point(3, 222);
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(157, 67);
            this.btnChangeID.TabIndex = 133;
            this.btnChangeID.Text = "Change ID #";
            this.btnChangeID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChangeID.UseVisualStyleBackColor = true;
            this.btnChangeID.Click += new System.EventHandler(this.btnChangeID_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Help;
            this.button2.Location = new System.Drawing.Point(692, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 136;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 29);
            this.label4.TabIndex = 134;
            this.label4.Text = "Agency*:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cboAgency.Location = new System.Drawing.Point(156, 86);
            this.cboAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgency.Name = "cboAgency";
            this.cboAgency.Size = new System.Drawing.Size(527, 32);
            this.cboAgency.TabIndex = 135;
            this.cboAgency.SelectedIndexChanged += new System.EventHandler(this.cboAgency_SelectedIndexChanged);
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
            this.splitContainer2.Panel1.Controls.Add(this.txtTransport);
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.lblIdentifierLabel);
            this.splitContainer2.Panel1.Controls.Add(this.cboAgency);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.cboCrewType);
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.txtName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(745, 722);
            this.splitContainer2.SplitterDistance = 236;
            this.splitContainer2.TabIndex = 137;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnAddPerson);
            this.splitContainer3.Panel1.Controls.Add(this.btnDeleteResource);
            this.splitContainer3.Panel1.Controls.Add(this.rbHECrew);
            this.splitContainer3.Panel1.Controls.Add(this.btnChangeID);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddVehicle);
            this.splitContainer3.Panel1.Controls.Add(this.rbCrew);
            this.splitContainer3.Panel1.Controls.Add(this.btnEditSelected);
            this.splitContainer3.Panel1.Controls.Add(this.btnRemoveFromCrew);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvGroup);
            this.splitContainer3.Size = new System.Drawing.Size(745, 482);
            this.splitContainer3.SplitterDistance = 164;
            this.splitContainer3.TabIndex = 0;
            // 
            // CrewEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(625, 705);
            this.Name = "CrewEditControl";
            this.Size = new System.Drawing.Size(745, 722);
            this.Load += new System.EventHandler(this.CrewEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIdentifierLabel;
        private System.Windows.Forms.TextBox txtTransport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnAddVehicle;
        private System.Windows.Forms.Button btnEditSelected;
        private System.Windows.Forms.Button btnRemoveFromCrew;
        private System.Windows.Forms.ComboBox cboCrewType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbCrew;
        private System.Windows.Forms.RadioButton rbHECrew;
        private TextBoxRequiredControl txtName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUniqueId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateUniqueIDToolStripMenuItem;
        private System.Windows.Forms.Button btnChangeID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAgency;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
    }
}
