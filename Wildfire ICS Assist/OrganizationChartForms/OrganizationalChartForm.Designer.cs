namespace Wildfire_ICS_Assist
{
    partial class OrganizationalChartForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.chkIncludeContacts = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbUnifiedCommand = new System.Windows.Forms.RadioButton();
            this.rbIncidentCommander = new System.Windows.Forms.RadioButton();
            this.treeOrgChart = new System.Windows.Forms.TreeView();
            this.btnPrint203 = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnPrint207 = new System.Windows.Forms.Button();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.assignSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printLogisticsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint203);
            this.splitContainer1.Panel2.Controls.Add(this.btnExport);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint207);
            this.splitContainer1.Panel2.Controls.Add(this.btnAssignRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Size = new System.Drawing.Size(1226, 594);
            this.splitContainer1.SplitterDistance = 539;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.chkIncludeContacts);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.rbUnifiedCommand);
            this.splitContainer2.Panel1.Controls.Add(this.rbIncidentCommander);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeOrgChart);
            this.splitContainer2.Size = new System.Drawing.Size(1226, 539);
            this.splitContainer2.SplitterDistance = 40;
            this.splitContainer2.TabIndex = 1;
            // 
            // chkIncludeContacts
            // 
            this.chkIncludeContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeContacts.AutoSize = true;
            this.chkIncludeContacts.Location = new System.Drawing.Point(923, 7);
            this.chkIncludeContacts.Name = "chkIncludeContacts";
            this.chkIncludeContacts.Size = new System.Drawing.Size(301, 28);
            this.chkIncludeContacts.TabIndex = 3;
            this.chkIncludeContacts.Text = "Include contact list when printing";
            this.chkIncludeContacts.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command Structure:";
            // 
            // rbUnifiedCommand
            // 
            this.rbUnifiedCommand.AutoSize = true;
            this.rbUnifiedCommand.Location = new System.Drawing.Point(430, 5);
            this.rbUnifiedCommand.Name = "rbUnifiedCommand";
            this.rbUnifiedCommand.Size = new System.Drawing.Size(179, 28);
            this.rbUnifiedCommand.TabIndex = 1;
            this.rbUnifiedCommand.TabStop = true;
            this.rbUnifiedCommand.Text = "Unified Command";
            this.rbUnifiedCommand.UseVisualStyleBackColor = true;
            this.rbUnifiedCommand.CheckedChanged += new System.EventHandler(this.rbUnifiedCommand_CheckedChanged);
            this.rbUnifiedCommand.Leave += new System.EventHandler(this.rbUnifiedCommand_Leave);
            // 
            // rbIncidentCommander
            // 
            this.rbIncidentCommander.AutoSize = true;
            this.rbIncidentCommander.Checked = true;
            this.rbIncidentCommander.Location = new System.Drawing.Point(220, 5);
            this.rbIncidentCommander.Name = "rbIncidentCommander";
            this.rbIncidentCommander.Size = new System.Drawing.Size(204, 28);
            this.rbIncidentCommander.TabIndex = 0;
            this.rbIncidentCommander.TabStop = true;
            this.rbIncidentCommander.Text = "Incident Commander";
            this.rbIncidentCommander.UseVisualStyleBackColor = true;
            this.rbIncidentCommander.CheckedChanged += new System.EventHandler(this.rbIncidentCommander_CheckedChanged);
            this.rbIncidentCommander.Leave += new System.EventHandler(this.rbIncidentCommander_Leave);
            // 
            // treeOrgChart
            // 
            this.treeOrgChart.ContextMenuStrip = this.contextMenuStrip1;
            this.treeOrgChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrgChart.HideSelection = false;
            this.treeOrgChart.Location = new System.Drawing.Point(0, 0);
            this.treeOrgChart.Name = "treeOrgChart";
            this.treeOrgChart.Size = new System.Drawing.Size(1226, 495);
            this.treeOrgChart.TabIndex = 0;
            this.treeOrgChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOrgChart_AfterSelect);
            // 
            // btnPrint203
            // 
            this.btnPrint203.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint203.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnPrint203.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint203.Location = new System.Drawing.Point(882, 3);
            this.btnPrint203.Name = "btnPrint203";
            this.btnPrint203.Size = new System.Drawing.Size(160, 42);
            this.btnPrint203.TabIndex = 53;
            this.btnPrint203.Text = "Print ICS-203";
            this.btnPrint203.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint203.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint203.UseVisualStyleBackColor = true;
            this.btnPrint203.Click += new System.EventHandler(this.btnPrint203_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnExport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExport.Location = new System.Drawing.Point(751, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 42);
            this.btnExport.TabIndex = 49;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnDeleteRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteRole.Location = new System.Drawing.Point(493, 3);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(177, 42);
            this.btnDeleteRole.TabIndex = 52;
            this.btnDeleteRole.Text = "Remove Role";
            this.btnDeleteRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnEditRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditRole.Location = new System.Drawing.Point(340, 3);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(147, 42);
            this.btnEditRole.TabIndex = 51;
            this.btnEditRole.Text = "Edit Role";
            this.btnEditRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnPrint207
            // 
            this.btnPrint207.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint207.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnPrint207.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint207.Location = new System.Drawing.Point(1048, 3);
            this.btnPrint207.Name = "btnPrint207";
            this.btnPrint207.Size = new System.Drawing.Size(166, 42);
            this.btnPrint207.TabIndex = 50;
            this.btnPrint207.Text = "Print ICS-207";
            this.btnPrint207.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint207.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint207.UseVisualStyleBackColor = true;
            this.btnPrint207.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAssignRole
            // 
            this.btnAssignRole.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAssignRole.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnAssignRole.Location = new System.Drawing.Point(167, 3);
            this.btnAssignRole.Name = "btnAssignRole";
            this.btnAssignRole.Size = new System.Drawing.Size(167, 42);
            this.btnAssignRole.TabIndex = 49;
            this.btnAssignRole.Text = "Assign Role";
            this.btnAssignRole.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAssignRole.UseVisualStyleBackColor = true;
            this.btnAssignRole.Click += new System.EventHandler(this.btnAssignRole_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAdd.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAdd.Location = new System.Drawing.Point(12, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(149, 42);
            this.btnAdd.TabIndex = 48;
            this.btnAdd.Text = "Add Role";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRoleToolStripMenuItem,
            this.toolStripSeparator1,
            this.assignSelectedRoleToolStripMenuItem,
            this.editSelectedRoleToolStripMenuItem,
            this.printLogisticsOverviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.removeSelectedRoleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(285, 188);
            // 
            // addRoleToolStripMenuItem
            // 
            this.addRoleToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.addRoleToolStripMenuItem.Name = "addRoleToolStripMenuItem";
            this.addRoleToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.addRoleToolStripMenuItem.Text = "Add Role";
            this.addRoleToolStripMenuItem.Click += new System.EventHandler(this.addRoleToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(281, 6);
            // 
            // assignSelectedRoleToolStripMenuItem
            // 
            this.assignSelectedRoleToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.assignSelectedRoleToolStripMenuItem.Name = "assignSelectedRoleToolStripMenuItem";
            this.assignSelectedRoleToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.assignSelectedRoleToolStripMenuItem.Text = "Assign Selected Role";
            this.assignSelectedRoleToolStripMenuItem.Click += new System.EventHandler(this.assignSelectedRoleToolStripMenuItem_Click);
            // 
            // editSelectedRoleToolStripMenuItem
            // 
            this.editSelectedRoleToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.editSelectedRoleToolStripMenuItem.Name = "editSelectedRoleToolStripMenuItem";
            this.editSelectedRoleToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.editSelectedRoleToolStripMenuItem.Text = "Edit Selected Role";
            this.editSelectedRoleToolStripMenuItem.Click += new System.EventHandler(this.editSelectedRoleToolStripMenuItem_Click);
            // 
            // removeSelectedRoleToolStripMenuItem
            // 
            this.removeSelectedRoleToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.removeSelectedRoleToolStripMenuItem.Name = "removeSelectedRoleToolStripMenuItem";
            this.removeSelectedRoleToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.removeSelectedRoleToolStripMenuItem.Text = "Remove Selected Role";
            this.removeSelectedRoleToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedRoleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(281, 6);
            // 
            // printLogisticsOverviewToolStripMenuItem
            // 
            this.printLogisticsOverviewToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printLogisticsOverviewToolStripMenuItem.Name = "printLogisticsOverviewToolStripMenuItem";
            this.printLogisticsOverviewToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.printLogisticsOverviewToolStripMenuItem.Text = "Print Logistics Overview";
            this.printLogisticsOverviewToolStripMenuItem.Click += new System.EventHandler(this.printLogisticsOverviewToolStripMenuItem_Click);
            // 
            // OrganizationalChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            this.ClientSize = new System.Drawing.Size(1226, 594);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1168, 498);
            this.Name = "OrganizationalChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Organization Chart";
            this.Load += new System.EventHandler(this.OrganizationalChartForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.Button btnPrint207;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbUnifiedCommand;
        private System.Windows.Forms.RadioButton rbIncidentCommander;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.Button btnPrint203;
        private System.Windows.Forms.CheckBox chkIncludeContacts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem assignSelectedRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLogisticsOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedRoleToolStripMenuItem;
    }
}