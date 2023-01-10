namespace Wildfire_ICS_Assist
{
    partial class VehiclesForm
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
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.colIncidentIDNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMustBeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddClue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvVehicles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddClue);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1080, 657);
            this.splitContainer1.SplitterDistance = 601;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIncidentIDNo,
            this.colClassification,
            this.colMake,
            this.colAgency,
            this.colOperator,
            this.colMustBeOut,
            this.colAssignment});
            this.dgvVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVehicles.Location = new System.Drawing.Point(0, 0);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersVisible = false;
            this.dgvVehicles.RowTemplate.Height = 35;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(1080, 601);
            this.dgvVehicles.TabIndex = 0;
            // 
            // colIncidentIDNo
            // 
            this.colIncidentIDNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIncidentIDNo.DataPropertyName = "IncidentIDNo";
            this.colIncidentIDNo.HeaderText = "Incident ID";
            this.colIncidentIDNo.Name = "colIncidentIDNo";
            this.colIncidentIDNo.ReadOnly = true;
            this.colIncidentIDNo.Width = 113;
            // 
            // colClassification
            // 
            this.colClassification.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colClassification.DataPropertyName = "Classification";
            this.colClassification.HeaderText = "Class";
            this.colClassification.Name = "colClassification";
            this.colClassification.ReadOnly = true;
            this.colClassification.Width = 80;
            // 
            // colMake
            // 
            this.colMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMake.DataPropertyName = "Make";
            this.colMake.HeaderText = "Make";
            this.colMake.Name = "colMake";
            this.colMake.ReadOnly = true;
            this.colMake.Width = 81;
            // 
            // colAgency
            // 
            this.colAgency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAgency.DataPropertyName = "AgencyOrOwner";
            this.colAgency.HeaderText = "Agency/Owner";
            this.colAgency.Name = "colAgency";
            this.colAgency.ReadOnly = true;
            this.colAgency.Width = 162;
            // 
            // colOperator
            // 
            this.colOperator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colOperator.DataPropertyName = "OperatorName";
            this.colOperator.HeaderText = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.ReadOnly = true;
            this.colOperator.Width = 109;
            // 
            // colMustBeOut
            // 
            this.colMustBeOut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMustBeOut.DataPropertyName = "MustBeOutTime";
            this.colMustBeOut.HeaderText = "Release Date/Time";
            this.colMustBeOut.Name = "colMustBeOut";
            this.colMustBeOut.ReadOnly = true;
            this.colMustBeOut.Width = 178;
            // 
            // colAssignment
            // 
            this.colAssignment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAssignment.DataPropertyName = "IncidentAssignment";
            this.colAssignment.HeaderText = "Assignment";
            this.colAssignment.MinimumWidth = 150;
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.ReadOnly = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(894, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(183, 42);
            this.btnPrint.TabIndex = 48;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(239, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 42);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(120, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 42);
            this.btnEdit.TabIndex = 46;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddClue
            // 
            this.btnAddClue.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddClue.Location = new System.Drawing.Point(12, 3);
            this.btnAddClue.Name = "btnAddClue";
            this.btnAddClue.Size = new System.Drawing.Size(102, 42);
            this.btnAddClue.TabIndex = 45;
            this.btnAddClue.Text = "Add";
            this.btnAddClue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddClue.UseVisualStyleBackColor = true;
            // 
            // VehiclesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 657);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VehiclesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicles";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIncidentIDNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMustBeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignment;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddClue;
    }
}