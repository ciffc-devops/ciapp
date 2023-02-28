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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExportSignInToCSV = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.colBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDivision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResourceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberOfPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvPersonnel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExportSignInToCSV);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1001, 719);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(249, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 42);
            this.btnDelete.TabIndex = 51;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(130, 33);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 42);
            this.btnEdit.TabIndex = 50;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAdd.Location = new System.Drawing.Point(13, 33);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 42);
            this.btnAdd.TabIndex = 49;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnExportSignInToCSV
            // 
            this.btnExportSignInToCSV.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExportSignInToCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportSignInToCSV.Location = new System.Drawing.Point(792, 19);
            this.btnExportSignInToCSV.Name = "btnExportSignInToCSV";
            this.btnExportSignInToCSV.Size = new System.Drawing.Size(197, 66);
            this.btnExportSignInToCSV.TabIndex = 40;
            this.btnExportSignInToCSV.Text = "Export to CSV";
            this.btnExportSignInToCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportSignInToCSV.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(12, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 89);
            this.panel1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(521, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Branch/Division/Group/Staging";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(12, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 89);
            this.panel2.TabIndex = 56;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.button2.Location = new System.Drawing.Point(249, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 42);
            this.button2.TabIndex = 51;
            this.button2.Text = "Delete";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Task Force/Strike Team/Group";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.button3.Location = new System.Drawing.Point(130, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 42);
            this.button3.TabIndex = 50;
            this.button3.Text = "Edit";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.button4.Location = new System.Drawing.Point(13, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 42);
            this.button4.TabIndex = 49;
            this.button4.Text = "Add";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.Location = new System.Drawing.Point(368, 33);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 42);
            this.button5.TabIndex = 41;
            this.button5.Text = "Print 204s";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.Location = new System.Drawing.Point(368, 33);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(154, 42);
            this.button6.TabIndex = 52;
            this.button6.Text = "Print 204As";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.AllowUserToAddRows = false;
            this.dgvPersonnel.AllowUserToDeleteRows = false;
            this.dgvPersonnel.AllowUserToResizeColumns = false;
            this.dgvPersonnel.AllowUserToResizeRows = false;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBranch,
            this.colDivision,
            this.colResourceID,
            this.colLeader,
            this.colNumberOfPeople});
            this.dgvPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonnel.Location = new System.Drawing.Point(0, 0);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.ReadOnly = true;
            this.dgvPersonnel.RowHeadersVisible = false;
            this.dgvPersonnel.RowTemplate.Height = 30;
            this.dgvPersonnel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonnel.Size = new System.Drawing.Size(1001, 511);
            this.dgvPersonnel.TabIndex = 1;
            // 
            // colBranch
            // 
            this.colBranch.HeaderText = "Branch";
            this.colBranch.Name = "colBranch";
            this.colBranch.ReadOnly = true;
            // 
            // colDivision
            // 
            this.colDivision.HeaderText = "Division/Group/Staging";
            this.colDivision.Name = "colDivision";
            this.colDivision.ReadOnly = true;
            // 
            // colResourceID
            // 
            this.colResourceID.HeaderText = "Resource ID";
            this.colResourceID.Name = "colResourceID";
            this.colResourceID.ReadOnly = true;
            // 
            // colLeader
            // 
            this.colLeader.HeaderText = "Resource Leader";
            this.colLeader.Name = "colLeader";
            this.colLeader.ReadOnly = true;
            // 
            // colNumberOfPeople
            // 
            this.colNumberOfPeople.HeaderText = "# of People";
            this.colNumberOfPeople.Name = "colNumberOfPeople";
            this.colNumberOfPeople.ReadOnly = true;
            // 
            // OperationalGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 719);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "OperationalGroupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Operational Groups";
            this.Load += new System.EventHandler(this.OperationalGroupsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportSignInToCSV;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBranch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDivision;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResourceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberOfPeople;
    }
}