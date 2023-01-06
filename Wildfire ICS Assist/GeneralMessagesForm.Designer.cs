namespace Wildfire_ICS_Assist
{
    partial class GeneralMessagesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralMessagesForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rbOutstandingMessages = new System.Windows.Forms.RadioButton();
            this.rbAllMessages = new System.Windows.Forms.RadioButton();
            this.btnFormInfo = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.colDateSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReply = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rbOutstandingMessages);
            this.splitContainer1.Panel1.Controls.Add(this.rbAllMessages);
            this.splitContainer1.Panel1.Controls.Add(this.btnFormInfo);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1467, 831);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 2;
            // 
            // rbOutstandingMessages
            // 
            this.rbOutstandingMessages.AutoSize = true;
            this.rbOutstandingMessages.Location = new System.Drawing.Point(154, 15);
            this.rbOutstandingMessages.Name = "rbOutstandingMessages";
            this.rbOutstandingMessages.Size = new System.Drawing.Size(224, 28);
            this.rbOutstandingMessages.TabIndex = 11;
            this.rbOutstandingMessages.Text = "Messages without reply";
            this.rbOutstandingMessages.UseVisualStyleBackColor = true;
            // 
            // rbAllMessages
            // 
            this.rbAllMessages.AutoSize = true;
            this.rbAllMessages.Checked = true;
            this.rbAllMessages.Location = new System.Drawing.Point(8, 15);
            this.rbAllMessages.Name = "rbAllMessages";
            this.rbAllMessages.Size = new System.Drawing.Size(140, 28);
            this.rbAllMessages.TabIndex = 10;
            this.rbAllMessages.TabStop = true;
            this.rbAllMessages.Text = "All Messages";
            this.rbAllMessages.UseVisualStyleBackColor = true;
            // 
            // btnFormInfo
            // 
            this.btnFormInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFormInfo.BackColor = System.Drawing.Color.White;
            this.btnFormInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnFormInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormInfo.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_931_speech_bubble_question_sm;
            this.btnFormInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFormInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFormInfo.Location = new System.Drawing.Point(1325, 9);
            this.btnFormInfo.Name = "btnFormInfo";
            this.btnFormInfo.Size = new System.Drawing.Size(130, 40);
            this.btnFormInfo.TabIndex = 9;
            this.btnFormInfo.Text = "Form Info";
            this.btnFormInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFormInfo.UseVisualStyleBackColor = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvLog);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer2.Panel2.Controls.Add(this.btnViewDetails);
            this.splitContainer2.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer2.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(1467, 772);
            this.splitContainer2.SplitterDistance = 700;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateSent,
            this.colFrom,
            this.colTo,
            this.colSubject,
            this.colReply});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 0);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowTemplate.Height = 30;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(1467, 700);
            this.dgvLog.TabIndex = 0;
            // 
            // colDateSent
            // 
            this.colDateSent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDateSent.DataPropertyName = "DateSent";
            dataGridViewCellStyle1.Format = "yyyy-MMM-dd HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.colDateSent.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDateSent.HeaderText = "Date/Time";
            this.colDateSent.Name = "colDateSent";
            this.colDateSent.ReadOnly = true;
            this.colDateSent.Width = 121;
            // 
            // colFrom
            // 
            this.colFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colFrom.DataPropertyName = "From";
            this.colFrom.HeaderText = "From";
            this.colFrom.Name = "colFrom";
            this.colFrom.ReadOnly = true;
            this.colFrom.Width = 80;
            // 
            // colTo
            // 
            this.colTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTo.DataPropertyName = "To";
            this.colTo.HeaderText = "To";
            this.colTo.Name = "colTo";
            this.colTo.ReadOnly = true;
            this.colTo.Width = 58;
            // 
            // colSubject
            // 
            this.colSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSubject.DataPropertyName = "Subject";
            this.colSubject.HeaderText = "Subject";
            this.colSubject.MinimumWidth = 300;
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            // 
            // colReply
            // 
            this.colReply.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colReply.DataPropertyName = "HasReply";
            this.colReply.HeaderText = "Reply";
            this.colReply.Name = "colReply";
            this.colReply.ReadOnly = true;
            this.colReply.Width = 64;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.Location = new System.Drawing.Point(1246, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(209, 52);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Text = "Print (ICS 213)";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnViewDetails.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_28_search;
            this.btnViewDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewDetails.Location = new System.Drawing.Point(193, 6);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(232, 52);
            this.btnViewDetails.TabIndex = 90;
            this.btnViewDetails.TabStop = false;
            this.btnViewDetails.Text = "View Entry Details";
            this.btnViewDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewDetails.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(550, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(113, 52);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEdit.Location = new System.Drawing.Point(431, 6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(113, 52);
            this.btnEdit.TabIndex = 40;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdd.Location = new System.Drawing.Point(8, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(179, 52);
            this.btnAdd.TabIndex = 89;
            this.btnAdd.TabStop = false;
            this.btnAdd.Text = "Add Message";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // GeneralMessagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1467, 831);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GeneralMessagesForm";
            this.Text = "General Messages";
            this.Load += new System.EventHandler(this.GeneralMessagesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rbOutstandingMessages;
        private System.Windows.Forms.RadioButton rbAllMessages;
        private System.Windows.Forms.Button btnFormInfo;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubject;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colReply;
    }
}