namespace Wildfire_ICS_Assist
{
    partial class OperationalGroupsForm
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
            this.treeOpsChart = new System.Windows.Forms.TreeView();
            this.cmsSelectedItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLogisticsOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addTaskForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStrikeTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSingleResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblSelectedGroupLeader = new System.Windows.Forms.Label();
            this.lblSelectedGroupName = new System.Windows.Forms.Label();
            this.operationalGroupReportingResourcesControl1 = new Wildfire_ICS_Assist.CustomControls.OperationalGroupReportingResourcesControl();
            this.strikeTeamTaskForceDetailsControl1 = new Wildfire_ICS_Assist.CustomControls.StrikeTeamTaskForceDetailsControl();
            this.btnPrintLogistics = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint204 = new System.Windows.Forms.Button();
            this.btnEditBranch = new System.Windows.Forms.Button();
            this.btnPrint204A = new System.Windows.Forms.Button();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.btnAddBranch = new System.Windows.Forms.Button();
            this.cmsAddButton = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewBranchDivisionGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDivisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewTaskForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStrikeTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSingleResourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cmsSelectedItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.cmsAddButton.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnPrintLogistics);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint204);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditBranch);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint204A);
            this.splitContainer1.Panel2.Controls.Add(this.btnExportSignInToCSV);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBranch);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 669);
            this.splitContainer1.SplitterDistance = 592;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeOpsChart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.AutoScroll = true;
            this.splitContainer2.Panel2.AutoScrollMinSize = new System.Drawing.Size(425, 0);
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1057, 592);
            this.splitContainer2.SplitterDistance = 440;
            this.splitContainer2.TabIndex = 2;
            // 
            // treeOpsChart
            // 
            this.treeOpsChart.ContextMenuStrip = this.cmsSelectedItem;
            this.treeOpsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOpsChart.HideSelection = false;
            this.treeOpsChart.Location = new System.Drawing.Point(0, 0);
            this.treeOpsChart.Name = "treeOpsChart";
            this.treeOpsChart.Size = new System.Drawing.Size(440, 592);
            this.treeOpsChart.TabIndex = 1;
            this.treeOpsChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOpsChart_AfterSelect);
            // 
            // cmsSelectedItem
            // 
            this.cmsSelectedItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsSelectedItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.printLogisticsOverviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.addTaskForceToolStripMenuItem,
            this.addStrikeTeamToolStripMenuItem,
            this.addSingleResourceToolStripMenuItem});
            this.cmsSelectedItem.Name = "cmsSelectedItem";
            this.cmsSelectedItem.Size = new System.Drawing.Size(285, 190);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // printLogisticsOverviewToolStripMenuItem
            // 
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
            // addTaskForceToolStripMenuItem
            // 
            this.addTaskForceToolStripMenuItem.Name = "addTaskForceToolStripMenuItem";
            this.addTaskForceToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.addTaskForceToolStripMenuItem.Text = "Add Task Force";
            this.addTaskForceToolStripMenuItem.Click += new System.EventHandler(this.addTaskForceToolStripMenuItem_Click);
            // 
            // addStrikeTeamToolStripMenuItem
            // 
            this.addStrikeTeamToolStripMenuItem.Name = "addStrikeTeamToolStripMenuItem";
            this.addStrikeTeamToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.addStrikeTeamToolStripMenuItem.Text = "Add Strike Team";
            this.addStrikeTeamToolStripMenuItem.Click += new System.EventHandler(this.addStrikeTeamToolStripMenuItem_Click);
            // 
            // addSingleResourceToolStripMenuItem
            // 
            this.addSingleResourceToolStripMenuItem.Name = "addSingleResourceToolStripMenuItem";
            this.addSingleResourceToolStripMenuItem.Size = new System.Drawing.Size(284, 30);
            this.addSingleResourceToolStripMenuItem.Text = "Add Single Resource";
            this.addSingleResourceToolStripMenuItem.Click += new System.EventHandler(this.addSingleResourceToolStripMenuItem_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblSelectedGroupLeader);
            this.splitContainer3.Panel1.Controls.Add(this.lblSelectedGroupName);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.operationalGroupReportingResourcesControl1);
            this.splitContainer3.Panel2.Controls.Add(this.strikeTeamTaskForceDetailsControl1);
            this.splitContainer3.Size = new System.Drawing.Size(613, 592);
            this.splitContainer3.SplitterDistance = 68;
            this.splitContainer3.TabIndex = 2;
            // 
            // lblSelectedGroupLeader
            // 
            this.lblSelectedGroupLeader.AutoSize = true;
            this.lblSelectedGroupLeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedGroupLeader.Location = new System.Drawing.Point(39, 40);
            this.lblSelectedGroupLeader.Name = "lblSelectedGroupLeader";
            this.lblSelectedGroupLeader.Size = new System.Drawing.Size(278, 29);
            this.lblSelectedGroupLeader.TabIndex = 1;
            this.lblSelectedGroupLeader.Text = "lblSelectedGroupLeader";
            // 
            // lblSelectedGroupName
            // 
            this.lblSelectedGroupName.AutoSize = true;
            this.lblSelectedGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedGroupName.Location = new System.Drawing.Point(3, 9);
            this.lblSelectedGroupName.Name = "lblSelectedGroupName";
            this.lblSelectedGroupName.Size = new System.Drawing.Size(314, 31);
            this.lblSelectedGroupName.TabIndex = 0;
            this.lblSelectedGroupName.Text = "lblSelectedGroupName";
            // 
            // operationalGroupReportingResourcesControl1
            // 
            this.operationalGroupReportingResourcesControl1.BackColor = System.Drawing.Color.Transparent;
            this.operationalGroupReportingResourcesControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationalGroupReportingResourcesControl1.Location = new System.Drawing.Point(309, 33);
            this.operationalGroupReportingResourcesControl1.Margin = new System.Windows.Forms.Padding(6);
            this.operationalGroupReportingResourcesControl1.Name = "operationalGroupReportingResourcesControl1";
            this.operationalGroupReportingResourcesControl1.Size = new System.Drawing.Size(558, 209);
            this.operationalGroupReportingResourcesControl1.TabIndex = 0;
            this.operationalGroupReportingResourcesControl1.Visible = false;
            // 
            // strikeTeamTaskForceDetailsControl1
            // 
            this.strikeTeamTaskForceDetailsControl1.BackColor = System.Drawing.Color.Transparent;
            this.strikeTeamTaskForceDetailsControl1.ChangesMade = false;
            this.strikeTeamTaskForceDetailsControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strikeTeamTaskForceDetailsControl1.Location = new System.Drawing.Point(0, 6);
            this.strikeTeamTaskForceDetailsControl1.Margin = new System.Windows.Forms.Padding(6);
            this.strikeTeamTaskForceDetailsControl1.Name = "strikeTeamTaskForceDetailsControl1";
            this.strikeTeamTaskForceDetailsControl1.Size = new System.Drawing.Size(396, 330);
            this.strikeTeamTaskForceDetailsControl1.TabIndex = 1;
            this.strikeTeamTaskForceDetailsControl1.Visible = false;
            // 
            // btnPrintLogistics
            // 
            this.btnPrintLogistics.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrintLogistics.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintLogistics.Location = new System.Drawing.Point(397, 7);
            this.btnPrintLogistics.Name = "btnPrintLogistics";
            this.btnPrintLogistics.Size = new System.Drawing.Size(153, 58);
            this.btnPrintLogistics.TabIndex = 53;
            this.btnPrintLogistics.Text = "Logistics Overview";
            this.btnPrintLogistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintLogistics.UseVisualStyleBackColor = true;
            this.btnPrintLogistics.Click += new System.EventHandler(this.btnPrintLogistics_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(278, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 58);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint204
            // 
            this.btnPrint204.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint204.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint204.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint204.Location = new System.Drawing.Point(558, 7);
            this.btnPrint204.Name = "btnPrint204";
            this.btnPrint204.Size = new System.Drawing.Size(154, 58);
            this.btnPrint204.TabIndex = 41;
            this.btnPrint204.Text = "Print 204s";
            this.btnPrint204.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint204.UseVisualStyleBackColor = true;
            this.btnPrint204.Click += new System.EventHandler(this.btnPrint204_Click);
            // 
            // btnEditBranch
            // 
            this.btnEditBranch.Enabled = false;
            this.btnEditBranch.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditBranch.Location = new System.Drawing.Point(159, 7);
            this.btnEditBranch.Name = "btnEditBranch";
            this.btnEditBranch.Size = new System.Drawing.Size(113, 58);
            this.btnEditBranch.TabIndex = 50;
            this.btnEditBranch.Text = "Edit";
            this.btnEditBranch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditBranch.UseVisualStyleBackColor = true;
            this.btnEditBranch.Click += new System.EventHandler(this.btnEditBranch_Click);
            // 
            // btnPrint204A
            // 
            this.btnPrint204A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint204A.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint204A.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint204A.Location = new System.Drawing.Point(718, 7);
            this.btnPrint204A.Name = "btnPrint204A";
            this.btnPrint204A.Size = new System.Drawing.Size(154, 58);
            this.btnPrint204A.TabIndex = 52;
            this.btnPrint204A.Text = "Print 204As";
            this.btnPrint204A.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint204A.UseVisualStyleBackColor = true;
            this.btnPrint204A.Click += new System.EventHandler(this.btnPrint204A_Click);
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(878, 7);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(171, 58);
            this.btnExportSignInToCSV.TabIndex = 40;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            this.btnExportSignInToCSV.Click += new System.EventHandler(this.btnExportSignInToCSV_Click);
            // 
            // btnAddBranch
            // 
            this.btnAddBranch.ContextMenuStrip = this.cmsAddButton;
            this.btnAddBranch.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddBranch.Location = new System.Drawing.Point(12, 7);
            this.btnAddBranch.Name = "btnAddBranch";
            this.btnAddBranch.Size = new System.Drawing.Size(141, 58);
            this.btnAddBranch.TabIndex = 49;
            this.btnAddBranch.Text = "Add New";
            this.btnAddBranch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBranch.UseVisualStyleBackColor = true;
            this.btnAddBranch.Click += new System.EventHandler(this.btnAddBranch_Click);
            // 
            // cmsAddButton
            // 
            this.cmsAddButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmsAddButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBranchDivisionGroupToolStripMenuItem,
            this.addNewDivisionToolStripMenuItem,
            this.addNewGroupToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewTaskForceToolStripMenuItem,
            this.addNewStrikeTeamToolStripMenuItem,
            this.addNewSingleResourceToolStripMenuItem});
            this.cmsAddButton.Name = "cmsAddButton";
            this.cmsAddButton.Size = new System.Drawing.Size(297, 190);
            // 
            // addNewBranchDivisionGroupToolStripMenuItem
            // 
            this.addNewBranchDivisionGroupToolStripMenuItem.Name = "addNewBranchDivisionGroupToolStripMenuItem";
            this.addNewBranchDivisionGroupToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewBranchDivisionGroupToolStripMenuItem.Text = "Add new Branch";
            this.addNewBranchDivisionGroupToolStripMenuItem.Click += new System.EventHandler(this.addNewBranchDivisionGroupToolStripMenuItem_Click);
            // 
            // addNewDivisionToolStripMenuItem
            // 
            this.addNewDivisionToolStripMenuItem.Name = "addNewDivisionToolStripMenuItem";
            this.addNewDivisionToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewDivisionToolStripMenuItem.Text = "Add new Division";
            this.addNewDivisionToolStripMenuItem.Click += new System.EventHandler(this.addNewDivisionToolStripMenuItem_Click);
            // 
            // addNewGroupToolStripMenuItem
            // 
            this.addNewGroupToolStripMenuItem.Name = "addNewGroupToolStripMenuItem";
            this.addNewGroupToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewGroupToolStripMenuItem.Text = "Add new Group";
            this.addNewGroupToolStripMenuItem.Click += new System.EventHandler(this.addNewGroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // addNewTaskForceToolStripMenuItem
            // 
            this.addNewTaskForceToolStripMenuItem.Name = "addNewTaskForceToolStripMenuItem";
            this.addNewTaskForceToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewTaskForceToolStripMenuItem.Text = "Add new Task Force";
            this.addNewTaskForceToolStripMenuItem.Click += new System.EventHandler(this.addNewTaskForceToolStripMenuItem_Click);
            // 
            // addNewStrikeTeamToolStripMenuItem
            // 
            this.addNewStrikeTeamToolStripMenuItem.Name = "addNewStrikeTeamToolStripMenuItem";
            this.addNewStrikeTeamToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewStrikeTeamToolStripMenuItem.Text = "Add new Strike Team";
            this.addNewStrikeTeamToolStripMenuItem.Click += new System.EventHandler(this.addNewStrikeTeamToolStripMenuItem_Click);
            // 
            // addNewSingleResourceToolStripMenuItem
            // 
            this.addNewSingleResourceToolStripMenuItem.Name = "addNewSingleResourceToolStripMenuItem";
            this.addNewSingleResourceToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.addNewSingleResourceToolStripMenuItem.Text = "Add new Single Resource";
            this.addNewSingleResourceToolStripMenuItem.Click += new System.EventHandler(this.addNewSingleResourceToolStripMenuItem_Click);
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // OperationalGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 669);
            this.Controls.Add(this.splitContainer1);
            this.Name = "OperationalGroupsForm";
            this.Text = "Assignments List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperationalGroupsForm_FormClosing);
            this.Load += new System.EventHandler(this.OperationalGroupsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsSelectedItem.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.cmsAddButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditBranch;
        private System.Windows.Forms.Button btnAddBranch;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.Button btnPrint204A;
        private System.Windows.Forms.Button btnPrint204;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cmsAddButton;
        private System.Windows.Forms.ToolStripMenuItem addNewBranchDivisionGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTaskForceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDivisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewStrikeTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSingleResourceToolStripMenuItem;
        private System.Windows.Forms.TreeView treeOpsChart;
        private CustomControls.OperationalGroupReportingResourcesControl operationalGroupReportingResourcesControl1;
        private CustomControls.StrikeTeamTaskForceDetailsControl strikeTeamTaskForceDetailsControl1;
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.ContextMenuStrip cmsSelectedItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addTaskForceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStrikeTeamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSingleResourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLogisticsOverviewToolStripMenuItem;
        private System.Windows.Forms.Button btnPrintLogistics;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblSelectedGroupLeader;
        private System.Windows.Forms.Label lblSelectedGroupName;
    }
}