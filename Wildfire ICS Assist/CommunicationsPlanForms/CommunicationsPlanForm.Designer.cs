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
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAircraft = new System.Windows.Forms.TabPage();
            this.dgvCommsItems = new System.Windows.Forms.DataGridView();
            this.colCommsSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toOther = new System.Windows.Forms.TabPage();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpAircraft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).BeginInit();
            this.toOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            this.svdExport.Filter = "Comma-separated values|*.csv";
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnView);
            this.splitContainer1.Panel2.Controls.Add(this.btnExport);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Size = new System.Drawing.Size(1003, 366);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAircraft);
            this.tabControl1.Controls.Add(this.toOther);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(10, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 312);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpAircraft
            // 
            this.tpAircraft.Controls.Add(this.dgvCommsItems);
            this.tpAircraft.Location = new System.Drawing.Point(4, 33);
            this.tpAircraft.Name = "tpAircraft";
            this.tpAircraft.Padding = new System.Windows.Forms.Padding(3);
            this.tpAircraft.Size = new System.Drawing.Size(995, 275);
            this.tpAircraft.TabIndex = 0;
            this.tpAircraft.Text = "Comms Systems";
            this.tpAircraft.UseVisualStyleBackColor = true;
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
            this.colAssignment,
            this.colComments});
            this.dgvCommsItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommsItems.Location = new System.Drawing.Point(3, 3);
            this.dgvCommsItems.Name = "dgvCommsItems";
            this.dgvCommsItems.ReadOnly = true;
            this.dgvCommsItems.RowHeadersVisible = false;
            this.dgvCommsItems.RowTemplate.Height = 30;
            this.dgvCommsItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommsItems.Size = new System.Drawing.Size(989, 269);
            this.dgvCommsItems.TabIndex = 3;
            this.dgvCommsItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommsItems_CellClick);
            this.dgvCommsItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommsItems_CellDoubleClick);
            this.dgvCommsItems.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCommsItems_ColumnHeaderMouseClick);
            this.dgvCommsItems.SelectionChanged += new System.EventHandler(this.dgvCommsItems_SelectionChanged);
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
            this.colFrequency.DataPropertyName = "FullRx";
            this.colFrequency.HeaderText = "Rx Freq/Tone";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.ReadOnly = true;
            this.colFrequency.Width = 153;
            // 
            // colTone
            // 
            this.colTone.DataPropertyName = "FullTx";
            this.colTone.HeaderText = "Tx Freq/Tone";
            this.colTone.Name = "colTone";
            this.colTone.ReadOnly = true;
            this.colTone.Width = 152;
            // 
            // colAssignment
            // 
            this.colAssignment.DataPropertyName = "Assignment";
            this.colAssignment.HeaderText = "Assignment";
            this.colAssignment.Name = "colAssignment";
            this.colAssignment.ReadOnly = true;
            this.colAssignment.Width = 134;
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
            // toOther
            // 
            this.toOther.Controls.Add(this.prepAndApprovePanel1);
            this.toOther.Location = new System.Drawing.Point(4, 33);
            this.toOther.Name = "toOther";
            this.toOther.Size = new System.Drawing.Size(995, 275);
            this.toOther.TabIndex = 4;
            this.toOther.Text = "Prepared By";
            this.toOther.UseVisualStyleBackColor = true;
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.White;
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = false;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = false;
            this.prepAndApprovePanel1.ExpandsRight = true;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(8, 6);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 10, 30, 11, 49, 49, 204);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(754, 197);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(485, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(619, 197);
            this.prepAndApprovePanel1.TabIndex = 71;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved Info";
            this.prepAndApprovePanel1.PreparedByChanged += new System.EventHandler(this.prepAndApprovePanel1_PreparedByChanged_1);
            this.prepAndApprovePanel1.ApprovedByChanged += new System.EventHandler(this.prepAndApprovePanel1_ApprovedByChanged_1);
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
            this.btnExport.Location = new System.Drawing.Point(728, 3);
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
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrint.Location = new System.Drawing.Point(859, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(141, 42);
            this.btnPrint.TabIndex = 47;
            this.btnPrint.Tag = "ViewPDF";
            this.btnPrint.Text = "View PDF";
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
            // CommunicationsPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 366);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(792, 405);
            this.Name = "CommunicationsPlanForm";
            this.Text = "Communications Plan (ICS-205)";
            this.Load += new System.EventHandler(this.CommunicationsPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpAircraft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommsItems)).EndInit();
            this.toOther.ResumeLayout(false);
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
        private System.Windows.Forms.SaveFileDialog svdExport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAircraft;
        private System.Windows.Forms.TabPage toOther;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommsSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComments;
    }
}