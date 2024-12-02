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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizationalChartForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.rbUnifiedCommand = new System.Windows.Forms.RadioButton();
            this.rbIncidentCommander = new System.Windows.Forms.RadioButton();
            this.treeOrgChart = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.assignSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLogisticsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint203 = new System.Windows.Forms.Button();
            this.cmsOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewICS203AssignmentsPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewICS207OrganizationalChartPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToSpreadsheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.cmsOutput.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRole);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(285, 166);
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
            // printLogisticsOverviewToolStripMenuItem
            // 
            this.printLogisticsOverviewToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.printLogisticsOverviewToolStripMenuItem.Name = "printLogisticsOverviewToolStripMenuItem";
            this.printLogisticsOverviewToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.printLogisticsOverviewToolStripMenuItem.Text = "Print Logistics Overview";
            this.printLogisticsOverviewToolStripMenuItem.Click += new System.EventHandler(this.printLogisticsOverviewToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(281, 6);
            // 
            // removeSelectedRoleToolStripMenuItem
            // 
            this.removeSelectedRoleToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.removeSelectedRoleToolStripMenuItem.Name = "removeSelectedRoleToolStripMenuItem";
            this.removeSelectedRoleToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.removeSelectedRoleToolStripMenuItem.Text = "Remove Selected Role";
            this.removeSelectedRoleToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedRoleToolStripMenuItem_Click);
            // 
            // btnPrint203
            // 
            this.btnPrint203.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint203.ContextMenuStrip = this.cmsOutput;
            this.btnPrint203.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint203.Location = new System.Drawing.Point(1054, 2);
            this.btnPrint203.Name = "btnPrint203";
            this.btnPrint203.Size = new System.Drawing.Size(160, 42);
            this.btnPrint203.TabIndex = 53;
            this.btnPrint203.Tag = "ViewPDF";
            this.btnPrint203.Text = "Output";
            this.btnPrint203.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint203.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint203.UseVisualStyleBackColor = true;
            this.btnPrint203.Click += new System.EventHandler(this.btnPrint203_Click);
            // 
            // cmsOutput
            // 
            this.cmsOutput.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.viewICS203AssignmentsPDFToolStripMenuItem,
            this.viewICS207OrganizationalChartPDFToolStripMenuItem,
            this.toolStripSeparator3,
            this.exportToSpreadsheetToolStripMenuItem});
            this.cmsOutput.Name = "cmsOutput";
            this.cmsOutput.Size = new System.Drawing.Size(415, 137);
            // 
            // viewICS203AssignmentsPDFToolStripMenuItem
            // 
            this.viewICS203AssignmentsPDFToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.viewICS203AssignmentsPDFToolStripMenuItem.Name = "viewICS203AssignmentsPDFToolStripMenuItem";
            this.viewICS203AssignmentsPDFToolStripMenuItem.Size = new System.Drawing.Size(414, 30);
            this.viewICS203AssignmentsPDFToolStripMenuItem.Text = "View ICS-203 Assignments PDF";
            this.viewICS203AssignmentsPDFToolStripMenuItem.Click += new System.EventHandler(this.viewICS203AssignmentsPDFToolStripMenuItem_Click);
            this.viewICS203AssignmentsPDFToolStripMenuItem.TextChanged += new System.EventHandler(this.viewICS203AssignmentsPDFToolStripMenuItem_TextChanged);
            // 
            // viewICS207OrganizationalChartPDFToolStripMenuItem
            // 
            this.viewICS207OrganizationalChartPDFToolStripMenuItem.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.viewICS207OrganizationalChartPDFToolStripMenuItem.Name = "viewICS207OrganizationalChartPDFToolStripMenuItem";
            this.viewICS207OrganizationalChartPDFToolStripMenuItem.Size = new System.Drawing.Size(414, 30);
            this.viewICS207OrganizationalChartPDFToolStripMenuItem.Text = "View ICS-207 Organizational Chart PDF";
            this.viewICS207OrganizationalChartPDFToolStripMenuItem.Click += new System.EventHandler(this.viewICS207OrganizationalChartPDFToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(411, 6);
            // 
            // exportToSpreadsheetToolStripMenuItem
            // 
            this.exportToSpreadsheetToolStripMenuItem.Name = "exportToSpreadsheetToolStripMenuItem";
            this.exportToSpreadsheetToolStripMenuItem.Size = new System.Drawing.Size(414, 30);
            this.exportToSpreadsheetToolStripMenuItem.Text = "Export to Spreadsheet";
            this.exportToSpreadsheetToolStripMenuItem.Click += new System.EventHandler(this.exportToSpreadsheetToolStripMenuItem_Click);
            // 
            // btnDeleteRole
            // 
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
            // btnAssignRole
            // 
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
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.DropDownWidth = 350;
            this.toolStripComboBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Include a contact list when printing",
            "Do not include a contact list when printing"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(350, 33);
            this.toolStripComboBox1.Text = "Include a contact list when printing";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "glyphicons-basic-739-check-green.png");
            this.imageList1.Images.SetKeyName(1, "glyphicons-basic-639-octagon-remove-empty-red.png");
            // 
            // OrganizationalChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 594);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1168, 498);
            this.Name = "OrganizationalChartForm";
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
            this.cmsOutput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbUnifiedCommand;
        private System.Windows.Forms.RadioButton rbIncidentCommander;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem assignSelectedRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLogisticsOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedRoleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsOutput;
        private System.Windows.Forms.ToolStripMenuItem viewICS203AssignmentsPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewICS207OrganizationalChartPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportToSpreadsheetToolStripMenuItem;
        private System.Windows.Forms.Button btnPrint203;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}