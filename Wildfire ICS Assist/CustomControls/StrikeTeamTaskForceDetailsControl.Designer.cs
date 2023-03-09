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
            this.components = new System.ComponentModel.Container();
            this.dgvSubGroups = new System.Windows.Forms.DataGridView();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfVehicles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResourcesTitle = new System.Windows.Forms.Label();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.btnAddResource = new System.Windows.Forms.Button();
            this.cmsAddResource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCrewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVehicleEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkInNewResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).BeginInit();
            this.cmsAddResource.SuspendLayout();
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
            this.btnDeleteResource.Location = new System.Drawing.Point(155, 438);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteResource.TabIndex = 116;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
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
            // cmsAddResource
            // 
            this.cmsAddResource.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsAddResource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCrewToolStripMenuItem,
            this.addPersonToolStripMenuItem,
            this.addVehicleEquipmentToolStripMenuItem,
            this.toolStripSeparator1,
            this.checkInNewResourceToolStripMenuItem});
            this.cmsAddResource.Name = "cmsAddResource";
            this.cmsAddResource.Size = new System.Drawing.Size(283, 130);
            // 
            // addCrewToolStripMenuItem
            // 
            this.addCrewToolStripMenuItem.Name = "addCrewToolStripMenuItem";
            this.addCrewToolStripMenuItem.Size = new System.Drawing.Size(282, 30);
            this.addCrewToolStripMenuItem.Text = "Add Crew";
            this.addCrewToolStripMenuItem.Click += new System.EventHandler(this.addCrewToolStripMenuItem_Click);
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            this.addPersonToolStripMenuItem.Size = new System.Drawing.Size(282, 30);
            this.addPersonToolStripMenuItem.Text = "Add Person";
            this.addPersonToolStripMenuItem.Click += new System.EventHandler(this.addPersonToolStripMenuItem_Click);
            // 
            // addVehicleEquipmentToolStripMenuItem
            // 
            this.addVehicleEquipmentToolStripMenuItem.Name = "addVehicleEquipmentToolStripMenuItem";
            this.addVehicleEquipmentToolStripMenuItem.Size = new System.Drawing.Size(282, 30);
            this.addVehicleEquipmentToolStripMenuItem.Text = "Add Vehicle/Equipment";
            this.addVehicleEquipmentToolStripMenuItem.Click += new System.EventHandler(this.addVehicleEquipmentToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(279, 6);
            // 
            // checkInNewResourceToolStripMenuItem
            // 
            this.checkInNewResourceToolStripMenuItem.Name = "checkInNewResourceToolStripMenuItem";
            this.checkInNewResourceToolStripMenuItem.Size = new System.Drawing.Size(282, 30);
            this.checkInNewResourceToolStripMenuItem.Text = "Check in new resource";
            // 
            // StrikeTeamTaskForceDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDeleteResource);
            this.Controls.Add(this.btnAddResource);
            this.Controls.Add(this.lblResourcesTitle);
            this.Controls.Add(this.dgvSubGroups);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StrikeTeamTaskForceDetailsControl";
            this.Size = new System.Drawing.Size(762, 483);
            this.Load += new System.EventHandler(this.StrikeTeamTaskForceDetailsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubGroups)).EndInit();
            this.cmsAddResource.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSubGroups;
        private System.Windows.Forms.Label lblResourcesTitle;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.Button btnAddResource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfPeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfVehicles;
        private System.Windows.Forms.ContextMenuStrip cmsAddResource;
        private System.Windows.Forms.ToolStripMenuItem addCrewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVehicleEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem checkInNewResourceToolStripMenuItem;
    }
}
