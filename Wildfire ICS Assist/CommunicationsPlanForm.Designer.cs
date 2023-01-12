namespace Wildfire_ICS_Assist
{
    partial class CommunicationsPlanForm
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
            this.dgvCommsItems = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colCommsSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvCommsItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnView);
            this.splitContainer1.Panel2.Controls.Add(this.btnExport);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Size = new System.Drawing.Size(776, 366);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvCommsItems
            // 
            this.dgvCommsItems.AllowUserToAddRows = false;
            this.dgvCommsItems.AllowUserToDeleteRows = false;
            this.dgvCommsItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCommsItems.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvCommsItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommsItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCommsSystem,
            this.colChannelID,
            this.colFunction,
            this.colFrequency,
            this.colTone,
            this.colComments});
            this.dgvCommsItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommsItems.Location = new System.Drawing.Point(0, 0);
            this.dgvCommsItems.Name = "dgvCommsItems";
            this.dgvCommsItems.ReadOnly = true;
            this.dgvCommsItems.RowHeadersVisible = false;
            this.dgvCommsItems.RowTemplate.Height = 30;
            this.dgvCommsItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommsItems.Size = new System.Drawing.Size(776, 312);
            this.dgvCommsItems.TabIndex = 3;
            this.dgvCommsItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommsItems_CellDoubleClick);
            this.dgvCommsItems.SelectionChanged += new System.EventHandler(this.dgvCommsItems_SelectionChanged);
            // 
            // btnView
            // 
            this.btnView.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_52_eye;
            this.btnView.Location = new System.Drawing.Point(120, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(102, 42);
            this.btnView.TabIndex = 49;
            this.btnView.Text = "View";
            this.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExport.Location = new System.Drawing.Point(529, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 42);
            this.btnExport.TabIndex = 48;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(660, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(347, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 42);
            this.btnDelete.TabIndex = 46;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(228, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 42);
            this.btnEdit.TabIndex = 45;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAdd.Location = new System.Drawing.Point(12, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 42);
            this.btnAdd.TabIndex = 44;
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colCommsSystem
            // 
            this.colCommsSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colCommsSystem.DataPropertyName = "CommsSystem";
            this.colCommsSystem.HeaderText = "Comms System";
            this.colCommsSystem.Name = "colCommsSystem";
            this.colCommsSystem.ReadOnly = true;
            this.colCommsSystem.Width = 166;
            // 
            // colChannelID
            // 
            this.colChannelID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colChannelID.DataPropertyName = "ChannelID";
            this.colChannelID.HeaderText = "Channel";
            this.colChannelID.Name = "colChannelID";
            this.colChannelID.ReadOnly = true;
            this.colChannelID.Width = 106;
            // 
            // colFunction
            // 
            this.colFunction.DataPropertyName = "CommsFunction";
            this.colFunction.HeaderText = "Function";
            this.colFunction.Name = "colFunction";
            this.colFunction.ReadOnly = true;
            this.colFunction.Width = 109;
            // 
            // colFrequency
            // 
            this.colFrequency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFrequency.DataPropertyName = "Frequency";
            this.colFrequency.HeaderText = "Frequency";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.ReadOnly = true;
            this.colFrequency.Width = 127;
            // 
            // colTone
            // 
            this.colTone.DataPropertyName = "Tone";
            this.colTone.HeaderText = "Tone";
            this.colTone.Name = "colTone";
            this.colTone.ReadOnly = true;
            this.colTone.Width = 80;
            // 
            // colComments
            // 
            this.colComments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colComments.DataPropertyName = "Comments";
            this.colComments.HeaderText = "Remarks";
            this.colComments.MinimumWidth = 100;
            this.colComments.Name = "colComments";
            this.colComments.ReadOnly = true;
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
            // 
            // CommunicationsPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(776, 366);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(792, 405);
            this.Name = "CommunicationsPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Communications Plan (ICS-205)";
            this.Load += new System.EventHandler(this.CommunicationsPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCommsItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommsSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
        private System.Windows.Forms.SaveFileDialog svdExport;
    }
}