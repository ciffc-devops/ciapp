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
            this.btnDelete = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnEditBranch = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.strikeTeamTaskForceDetailsControl1 = new Wildfire_ICS_Assist.CustomControls.StrikeTeamTaskForceDetailsControl();
            this.operationalGroupReportingResourcesControl1 = new Wildfire_ICS_Assist.CustomControls.OperationalGroupReportingResourcesControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditBranch);
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.btnExportSignInToCSV);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBranch);
            this.splitContainer1.Size = new System.Drawing.Size(1210, 669);
            this.splitContainer1.SplitterDistance = 617;
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
            this.splitContainer2.Panel2.Controls.Add(this.strikeTeamTaskForceDetailsControl1);
            this.splitContainer2.Panel2.Controls.Add(this.operationalGroupReportingResourcesControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1210, 617);
            this.splitContainer2.SplitterDistance = 504;
            this.splitContainer2.TabIndex = 2;
            // 
            // treeOpsChart
            // 
            this.treeOpsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOpsChart.HideSelection = false;
            this.treeOpsChart.Location = new System.Drawing.Point(0, 0);
            this.treeOpsChart.Name = "treeOpsChart";
            this.treeOpsChart.Size = new System.Drawing.Size(504, 617);
            this.treeOpsChart.TabIndex = 1;
            this.treeOpsChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOpsChart_AfterSelect);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(278, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 42);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button5
            // 
            this.button5.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(397, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 42);
            this.button5.TabIndex = 41;
            this.button5.Text = "Print 204s";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnEditBranch
            // 
            this.btnEditBranch.Enabled = false;
            this.btnEditBranch.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditBranch.Location = new System.Drawing.Point(159, 3);
            this.btnEditBranch.Name = "btnEditBranch";
            this.btnEditBranch.Size = new System.Drawing.Size(113, 42);
            this.btnEditBranch.TabIndex = 50;
            this.btnEditBranch.Text = "Edit";
            this.btnEditBranch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditBranch.UseVisualStyleBackColor = true;
            this.btnEditBranch.Click += new System.EventHandler(this.btnEditBranch_Click);
            // 
            // button6
            // 
            this.button6.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.Location = new System.Drawing.Point(557, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(154, 42);
            this.button6.TabIndex = 52;
            this.button6.Text = "Print 204As";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(717, 3);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(171, 42);
            this.btnExportSignInToCSV.TabIndex = 40;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            // 
            // btnAddBranch
            // 
            this.btnAddBranch.ContextMenuStrip = this.cmsAddButton;
            this.btnAddBranch.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddBranch.Location = new System.Drawing.Point(12, 3);
            this.btnAddBranch.Name = "btnAddBranch";
            this.btnAddBranch.Size = new System.Drawing.Size(141, 42);
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
            // strikeTeamTaskForceDetailsControl1
            // 
            this.strikeTeamTaskForceDetailsControl1.BackColor = System.Drawing.Color.Transparent;
            this.strikeTeamTaskForceDetailsControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strikeTeamTaskForceDetailsControl1.Location = new System.Drawing.Point(18, 236);
            this.strikeTeamTaskForceDetailsControl1.Margin = new System.Windows.Forms.Padding(6);
            this.strikeTeamTaskForceDetailsControl1.Name = "strikeTeamTaskForceDetailsControl1";
            this.strikeTeamTaskForceDetailsControl1.role = null;
            this.strikeTeamTaskForceDetailsControl1.Size = new System.Drawing.Size(396, 330);
            this.strikeTeamTaskForceDetailsControl1.TabIndex = 1;
            this.strikeTeamTaskForceDetailsControl1.Visible = false;
            // 
            // operationalGroupReportingResourcesControl1
            // 
            this.operationalGroupReportingResourcesControl1.BackColor = System.Drawing.Color.Transparent;
            this.operationalGroupReportingResourcesControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationalGroupReportingResourcesControl1.Location = new System.Drawing.Point(31, 15);
            this.operationalGroupReportingResourcesControl1.Margin = new System.Windows.Forms.Padding(6);
            this.operationalGroupReportingResourcesControl1.Name = "operationalGroupReportingResourcesControl1";
            this.operationalGroupReportingResourcesControl1.role = null;
            this.operationalGroupReportingResourcesControl1.Size = new System.Drawing.Size(558, 209);
            this.operationalGroupReportingResourcesControl1.TabIndex = 0;
            this.operationalGroupReportingResourcesControl1.Visible = false;
            // 
            // OperationalGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 669);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OperationalGroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operational Groups";
            this.Load += new System.EventHandler(this.OperationalGroupsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsAddButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEditBranch;
        private System.Windows.Forms.Button btnAddBranch;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
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
    }
}