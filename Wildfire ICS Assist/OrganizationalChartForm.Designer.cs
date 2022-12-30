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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeOrgChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Size = new System.Drawing.Size(930, 641);
            this.splitContainer1.SplitterDistance = 586;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeOrgChart
            // 
            this.treeOrgChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOrgChart.Location = new System.Drawing.Point(0, 0);
            this.treeOrgChart.Name = "treeOrgChart";
            this.treeOrgChart.Size = new System.Drawing.Size(930, 586);
            this.treeOrgChart.TabIndex = 0;
            this.treeOrgChart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOrgChart_AfterSelect);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(805, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 50;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnEdit.Location = new System.Drawing.Point(167, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(167, 42);
            this.btnEdit.TabIndex = 49;
            this.btnEdit.Text = "Assign Role";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
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
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.button1.Location = new System.Drawing.Point(340, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 42);
            this.button1.TabIndex = 51;
            this.button1.Text = "Edit Role";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OrganizationalChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(930, 641);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OrganizationalChartForm";
            this.Text = "OrganizationalChartForm";
            this.Load += new System.EventHandler(this.OrganizationalChartForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeOrgChart;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button1;
    }
}