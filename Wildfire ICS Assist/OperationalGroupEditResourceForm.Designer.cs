namespace Wildfire_ICS_Assist
{
    partial class OperationalGroupEditResourceForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbEquipment = new System.Windows.Forms.RadioButton();
            this.rbPersonnel = new System.Windows.Forms.RadioButton();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.cboResourceRole = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboResourceItem = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboResourceType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboResourceKind = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.colLeader = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(1162, 463);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.txtTransport);
            this.splitContainer2.Panel1.Controls.Add(this.txtName);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.btnDeleteResource);
            this.splitContainer2.Panel2.Controls.Add(this.dgvGroup);
            this.splitContainer2.Size = new System.Drawing.Size(1162, 394);
            this.splitContainer2.SplitterDistance = 491;
            this.splitContainer2.TabIndex = 116;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbEquipment);
            this.panel1.Controls.Add(this.rbPersonnel);
            this.panel1.Controls.Add(this.btnAddResource);
            this.panel1.Controls.Add(this.cboResourceRole);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboResourceItem);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboResourceType);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboResourceKind);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(32, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 285);
            this.panel1.TabIndex = 109;
            // 
            // rbEquipment
            // 
            this.rbEquipment.AutoSize = true;
            this.rbEquipment.Location = new System.Drawing.Point(178, 45);
            this.rbEquipment.Name = "rbEquipment";
            this.rbEquipment.Size = new System.Drawing.Size(199, 28);
            this.rbEquipment.TabIndex = 116;
            this.rbEquipment.Text = "Equipment / Vehicle";
            this.rbEquipment.UseVisualStyleBackColor = true;
            this.rbEquipment.CheckedChanged += new System.EventHandler(this.rbEquipment_CheckedChanged);
            // 
            // rbPersonnel
            // 
            this.rbPersonnel.AutoSize = true;
            this.rbPersonnel.Location = new System.Drawing.Point(23, 45);
            this.rbPersonnel.Name = "rbPersonnel";
            this.rbPersonnel.Size = new System.Drawing.Size(114, 28);
            this.rbPersonnel.TabIndex = 115;
            this.rbPersonnel.Text = "Personnel";
            this.rbPersonnel.UseVisualStyleBackColor = true;
            this.rbPersonnel.CheckedChanged += new System.EventHandler(this.rbPersonnel_CheckedChanged);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_210_circle_empty_right;
            this.btnAddResource.Location = new System.Drawing.Point(326, 231);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(115, 42);
            this.btnAddResource.TabIndex = 114;
            this.btnAddResource.Text = "Add";
            this.btnAddResource.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // cboResourceRole
            // 
            this.cboResourceRole.Enabled = false;
            this.cboResourceRole.FormattingEnabled = true;
            this.cboResourceRole.Items.AddRange(new object[] {
            "Leader",
            "Crew Boss",
            "Crew",
            "Operator"});
            this.cboResourceRole.Location = new System.Drawing.Point(140, 193);
            this.cboResourceRole.Name = "cboResourceRole";
            this.cboResourceRole.Size = new System.Drawing.Size(301, 32);
            this.cboResourceRole.TabIndex = 112;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(19, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 29);
            this.label10.TabIndex = 113;
            this.label10.Text = "Role:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(19, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 29);
            this.label9.TabIndex = 110;
            this.label9.Text = "Resource:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboResourceItem
            // 
            this.cboResourceItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboResourceItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboResourceItem.DisplayMember = "Name";
            this.cboResourceItem.FormattingEnabled = true;
            this.cboResourceItem.Location = new System.Drawing.Point(140, 79);
            this.cboResourceItem.Name = "cboResourceItem";
            this.cboResourceItem.Size = new System.Drawing.Size(301, 32);
            this.cboResourceItem.TabIndex = 111;
            this.cboResourceItem.ValueMember = "PersonID";
            this.cboResourceItem.SelectedIndexChanged += new System.EventHandler(this.cboResourceItem_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 29);
            this.label8.TabIndex = 109;
            this.label8.Text = "Add Resources";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboResourceType
            // 
            this.cboResourceType.Enabled = false;
            this.cboResourceType.FormattingEnabled = true;
            this.cboResourceType.Location = new System.Drawing.Point(140, 155);
            this.cboResourceType.Name = "cboResourceType";
            this.cboResourceType.Size = new System.Drawing.Size(301, 32);
            this.cboResourceType.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 29);
            this.label6.TabIndex = 108;
            this.label6.Text = "Type:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboResourceKind
            // 
            this.cboResourceKind.Enabled = false;
            this.cboResourceKind.FormattingEnabled = true;
            this.cboResourceKind.Location = new System.Drawing.Point(140, 117);
            this.cboResourceKind.Name = "cboResourceKind";
            this.cboResourceKind.Size = new System.Drawing.Size(301, 32);
            this.cboResourceKind.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 29);
            this.label7.TabIndex = 106;
            this.label7.Text = "Kind:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(28, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 29);
            this.label3.TabIndex = 101;
            this.label3.Text = "Resource Identifier:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransport
            // 
            this.txtTransport.Location = new System.Drawing.Point(211, 47);
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(267, 29);
            this.txtTransport.TabIndex = 108;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(211, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(267, 29);
            this.txtName.TabIndex = 102;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 29);
            this.label5.TabIndex = 107;
            this.label5.Text = "Transport:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteResource
            // 
            this.btnDeleteResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteResource.Enabled = false;
            this.btnDeleteResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteResource.Location = new System.Drawing.Point(8, 349);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteResource.TabIndex = 52;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeColumns = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colKind,
            this.colType,
            this.colLeader});
            this.dgvGroup.Location = new System.Drawing.Point(8, 8);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowTemplate.Height = 30;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(647, 335);
            this.dgvGroup.TabIndex = 4;
            this.dgvGroup.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(1025, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 24;
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
            this.btnCancel.Location = new System.Drawing.Point(16, 8);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 23);
            this.label11.TabIndex = 110;
            this.label11.Text = "(within incident)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colLeader
            // 
            this.colLeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLeader.DataPropertyName = "Role";
            this.colLeader.HeaderText = "Role";
            this.colLeader.Items.AddRange(new object[] {
            "Leader",
            "Crew Boss",
            "Crew",
            "Operator"});
            this.colLeader.Name = "colLeader";
            this.colLeader.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLeader.Width = 74;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // colKind
            // 
            this.colKind.DataPropertyName = "Kind";
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.HeaderText = "Resource Name";
            this.colName.MinimumWidth = 250;
            this.colName.Name = "colName";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(454, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 111;
            this.label1.Text = "Edit values directly in the grid";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OperationalGroupEditResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 463);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OperationalGroupEditResourceForm";
            this.Text = "Edit Resource";
            this.Load += new System.EventHandler(this.OperationalGroupEditResourceForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboResourceType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboResourceKind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboResourceRole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboResourceItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.RadioButton rbEquipment;
        private System.Windows.Forms.RadioButton rbPersonnel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLeader;
    }
}