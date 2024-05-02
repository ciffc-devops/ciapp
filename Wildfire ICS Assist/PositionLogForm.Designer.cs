namespace Wildfire_ICS_Assist
{
    partial class PositionLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionLogForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cboOpPeriod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboViewOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSort = new System.Windows.Forms.ComboBox();
            this.btnFormInfo = new System.Windows.Forms.Button();
            this.lblPositionName = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.btnPrintVerbose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddToPositionLog = new System.Windows.Forms.Button();
            this.colRoleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComplete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.svdExport = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1.Controls.Add(this.btnFormInfo);
            this.splitContainer1.Panel1.Controls.Add(this.lblPositionName);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.label2);
            this.splitContainer3.Panel2.Controls.Add(this.cboSort);
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.cboOpPeriod);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.cboViewOption);
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            // 
            // cboOpPeriod
            // 
            resources.ApplyResources(this.cboOpPeriod, "cboOpPeriod");
            this.cboOpPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOpPeriod.FormattingEnabled = true;
            this.cboOpPeriod.Items.AddRange(new object[] {
            resources.GetString("cboOpPeriod.Items"),
            resources.GetString("cboOpPeriod.Items1")});
            this.cboOpPeriod.Name = "cboOpPeriod";
            this.cboOpPeriod.SelectedIndexChanged += new System.EventHandler(this.cboOpPeriod_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboViewOption
            // 
            resources.ApplyResources(this.cboViewOption, "cboViewOption");
            this.cboViewOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViewOption.FormattingEnabled = true;
            this.cboViewOption.Items.AddRange(new object[] {
            resources.GetString("cboViewOption.Items"),
            resources.GetString("cboViewOption.Items1"),
            resources.GetString("cboViewOption.Items2")});
            this.cboViewOption.Name = "cboViewOption";
            this.cboViewOption.SelectedIndexChanged += new System.EventHandler(this.cboViewOption_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cboSort
            // 
            resources.ApplyResources(this.cboSort, "cboSort");
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.FormattingEnabled = true;
            this.cboSort.Items.AddRange(new object[] {
            resources.GetString("cboSort.Items"),
            resources.GetString("cboSort.Items1"),
            resources.GetString("cboSort.Items2"),
            resources.GetString("cboSort.Items3"),
            resources.GetString("cboSort.Items4")});
            this.cboSort.Name = "cboSort";
            this.cboSort.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            // 
            // btnFormInfo
            // 
            resources.ApplyResources(this.btnFormInfo, "btnFormInfo");
            this.btnFormInfo.BackColor = System.Drawing.Color.White;
            this.btnFormInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnFormInfo.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_931_speech_bubble_question_sm;
            this.btnFormInfo.Name = "btnFormInfo";
            this.btnFormInfo.UseVisualStyleBackColor = false;
            this.btnFormInfo.Click += new System.EventHandler(this.btnFormInfo_Click);
            // 
            // lblPositionName
            // 
            resources.ApplyResources(this.lblPositionName, "lblPositionName");
            this.lblPositionName.Name = "lblPositionName";
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLog);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExport);
            this.splitContainer2.Panel2.Controls.Add(this.btnPrintVerbose);
            this.splitContainer2.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer2.Panel2.Controls.Add(this.btnViewDetails);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Panel2.Controls.Add(this.btnAddToPositionLog);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoleName,
            this.colDateCreated,
            this.colLogText,
            this.colComplete,
            this.colDueDate});
            resources.ApplyResources(this.dgvLog, "dgvLog");
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowTemplate.Height = 30;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_CellDoubleClick);
            this.dgvLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLog_CellFormatting);
            // 
            // btnPrintVerbose
            // 
            resources.ApplyResources(this.btnPrintVerbose, "btnPrintVerbose");
            this.btnPrintVerbose.Name = "btnPrintVerbose";
            this.btnPrintVerbose.UseVisualStyleBackColor = true;
            this.btnPrintVerbose.Click += new System.EventHandler(this.btnPrintVerbose_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnViewDetails
            // 
            resources.ApplyResources(this.btnViewDetails, "btnViewDetails");
            this.btnViewDetails.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_28_search;
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.TabStop = false;
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddToPositionLog
            // 
            resources.ApplyResources(this.btnAddToPositionLog, "btnAddToPositionLog");
            this.btnAddToPositionLog.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddToPositionLog.Name = "btnAddToPositionLog";
            this.btnAddToPositionLog.TabStop = false;
            this.btnAddToPositionLog.UseVisualStyleBackColor = true;
            this.btnAddToPositionLog.Click += new System.EventHandler(this.btnAddToPositionLog_Click);
            // 
            // colRoleName
            // 
            this.colRoleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRoleName.DataPropertyName = "RoleName";
            resources.ApplyResources(this.colRoleName, "colRoleName");
            this.colRoleName.Name = "colRoleName";
            this.colRoleName.ReadOnly = true;
            // 
            // colDateCreated
            // 
            this.colDateCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDateCreated.DataPropertyName = "DateCreated";
            dataGridViewCellStyle1.Format = "yyyy-MMM-dd HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.colDateCreated.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.colDateCreated, "colDateCreated");
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.ReadOnly = true;
            // 
            // colLogText
            // 
            this.colLogText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLogText.DataPropertyName = "LogText";
            resources.ApplyResources(this.colLogText, "colLogText");
            this.colLogText.Name = "colLogText";
            this.colLogText.ReadOnly = true;
            // 
            // colComplete
            // 
            this.colComplete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colComplete.DataPropertyName = "IsComplete";
            resources.ApplyResources(this.colComplete, "colComplete");
            this.colComplete.Name = "colComplete";
            this.colComplete.ReadOnly = true;
            this.colComplete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colComplete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDueDate
            // 
            this.colDueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDueDate.DataPropertyName = "TimeDueAsString";
            dataGridViewCellStyle2.NullValue = null;
            this.colDueDate.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.colDueDate, "colDueDate");
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.ReadOnly = true;
            // 
            // svdExport
            // 
            this.svdExport.DefaultExt = "csv";
            resources.ApplyResources(this.svdExport, "svdExport");
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_400_export;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // PositionLogForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.splitContainer1);
            this.Name = "PositionLogForm";
            this.Load += new System.EventHandler(this.PositionLogForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnFormInfo;
        private System.Windows.Forms.ComboBox cboSort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPositionName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnPrintVerbose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddToPositionLog;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ComboBox cboOpPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboViewOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDueDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog svdExport;
    }
}