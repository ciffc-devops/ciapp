namespace Wildfire_ICS_Assist.CustomControls
{
    partial class StrikeTeamTaskForceDetailsControl
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
            this.dgvSubGroups = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResourcesTitle = new System.Windows.Forms.Label();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.btnEditResource = new System.Windows.Forms.Button();
            this.btnAddResource = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubGroups
            // 
            this.dgvSubGroups.AllowUserToAddRows = false;
            this.dgvSubGroups.AllowUserToDeleteRows = false;
            this.dgvSubGroups.AllowUserToResizeColumns = false;
            this.dgvSubGroups.AllowUserToResizeRows = false;
            this.dgvSubGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSubGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNumber,
            this.colName,
            this.colLeader,
            this.colNumberOfPeople,
            this.colNumberOfVehicles});
            this.dgvSubGroups.Location = new System.Drawing.Point(8, 38);
            this.dgvSubGroups.Name = "dgvSubGroups";
            this.dgvSubGroups.ReadOnly = true;
            this.dgvSubGroups.RowHeadersVisible = false;
            this.dgvSubGroups.RowTemplate.Height = 30;
            this.dgvSubGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubGroups.Size = new System.Drawing.Size(738, 394);
            this.dgvSubGroups.TabIndex = 4;
            this.dgvSubGroups.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSubGroups_CellFormatting);
            this.dgvSubGroups.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvSubGroups_RowPostPaint);
            this.dgvSubGroups.SelectionChanged += new System.EventHandler(this.dgvSubGroups_SelectionChanged);
            // 
            // colNumber
            // 
            this.colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            // lblResourcesTitle
            // 
            this.lblResourcesTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResourcesTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourcesTitle.Location = new System.Drawing.Point(3, 6);
            this.lblResourcesTitle.Name = "lblResourcesTitle";
            this.lblResourcesTitle.Size = new System.Drawing.Size(756, 29);
            this.lblResourcesTitle.TabIndex = 113;
            this.lblResourcesTitle.Text = "Reporting Resources";
            this.lblResourcesTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDeleteResource
            // 
            this.btnDeleteResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteResource.Enabled = false;
            this.btnDeleteResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteResource.Location = new System.Drawing.Point(274, 438);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteResource.TabIndex = 116;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
            // 
            // btnEditResource
            // 
            this.btnEditResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditResource.Enabled = false;
            this.btnEditResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditResource.Location = new System.Drawing.Point(155, 438);
            this.btnEditResource.Name = "btnEditResource";
            this.btnEditResource.Size = new System.Drawing.Size(113, 42);
            this.btnEditResource.TabIndex = 115;
            this.btnEditResource.Text = "Edit";
            this.btnEditResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditResource.UseVisualStyleBackColor = true;
            this.btnEditResource.Click += new System.EventHandler(this.btnEditResource_Click);
            // 
            // btnAddResource
            // 
            this.btnAddResource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddResource.Location = new System.Drawing.Point(8, 438);
            this.btnAddResource.Name = "btnAddResource";
            this.btnAddResource.Size = new System.Drawing.Size(141, 42);
            this.btnAddResource.TabIndex = 114;
            this.btnAddResource.Text = "Add New";
            this.btnAddResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddResource.UseVisualStyleBackColor = true;
            this.btnAddResource.Click += new System.EventHandler(this.btnAddResource_Click);
            // 
            // StrikeTeamTaskForceDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDeleteResource);
            this.Controls.Add(this.btnEditResource);
            this.Controls.Add(this.btnAddResource);
            this.Controls.Add(this.lblResourcesTitle);
            this.Controls.Add(this.dgvSubGroups);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StrikeTeamTaskForceDetailsControl";
            this.Size = new System.Drawing.Size(762, 483);
            this.Load += new System.EventHandler(this.StrikeTeamTaskForceDetailsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubGroups;
        private System.Windows.Forms.Label lblResourcesTitle;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.Button btnEditResource;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfVehicles;
    }
}
