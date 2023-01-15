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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeOrgChart = new System.Windows.Forms.TreeView();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAssignRole = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rbIncidentCommander = new System.Windows.Forms.RadioButton();
            this.rbUnifiedCommand = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnAssignRole);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Size = new System.Drawing.Size(1209, 651);
            this.splitContainer1.SplitterDistance = 596;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeOrgChart
            // 
            this.treeOrgChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrgChart.Location = new System.Drawing.Point(0, 0);
            this.treeOrgChart.Name = "treeOrgChart";
            this.treeOrgChart.Size = new System.Drawing.Size(1209, 552);
            this.treeOrgChart.TabIndex = 0;
            this.treeOrgChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOrgChart_AfterSelect);
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
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(1084, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(1209, 596);
            this.splitContainer2.SplitterDistance = 40;
            this.splitContainer2.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Command Structure:";
            // 
            // OrganizationalChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1209, 651);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(815, 412);
            this.Name = "OrganizationalChartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Organizational Chart";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAssignRole;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbUnifiedCommand;
        private System.Windows.Forms.RadioButton rbIncidentCommander;
    }
}