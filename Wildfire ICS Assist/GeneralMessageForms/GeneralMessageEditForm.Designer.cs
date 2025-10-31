namespace Wildfire_ICS_Assist
{
    partial class GeneralMessageEditForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtToName = new System.Windows.Forms.TextBox();
            this.datMessageSent = new System.Windows.Forms.DateTimePicker();
            this.txtMessage = new SpellBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.txtToPosition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReply = new SpellBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReplyPosition = new System.Windows.Forms.TextBox();
            this.txtReplyName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.datReplyReceived = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(803, 532);
            this.splitContainer1.SplitterDistance = 462;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.txtToName);
            this.splitContainer2.Panel1.Controls.Add(this.datMessageSent);
            this.splitContainer2.Panel1.Controls.Add(this.txtMessage);
            this.splitContainer2.Panel1.Controls.Add(this.txtSubject);
            this.splitContainer2.Panel1.Controls.Add(this.cboFrom);
            this.splitContainer2.Panel1.Controls.Add(this.txtToPosition);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.prepAndApprovePanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.txtReply);
            this.splitContainer2.Panel2.Controls.Add(this.label9);
            this.splitContainer2.Panel2.Controls.Add(this.label11);
            this.splitContainer2.Panel2.Controls.Add(this.txtReplyPosition);
            this.splitContainer2.Panel2.Controls.Add(this.txtReplyName);
            this.splitContainer2.Panel2.Controls.Add(this.label10);
            this.splitContainer2.Panel2.Controls.Add(this.datReplyReceived);
            this.splitContainer2.Size = new System.Drawing.Size(803, 462);
            this.splitContainer2.SplitterDistance = 262;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 49;
            // 
            // txtToName
            // 
            this.txtToName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToName.Location = new System.Drawing.Point(205, 3);
            this.txtToName.Name = "txtToName";
            this.txtToName.Size = new System.Drawing.Size(205, 29);
            this.txtToName.TabIndex = 19;
            this.txtToName.TextChanged += new System.EventHandler(this.txtToName_TextChanged);
            // 
            // datMessageSent
            // 
            this.datMessageSent.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datMessageSent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datMessageSent.Location = new System.Drawing.Point(205, 146);
            this.datMessageSent.Name = "datMessageSent";
            this.datMessageSent.Size = new System.Drawing.Size(213, 29);
            this.datMessageSent.TabIndex = 23;
            this.datMessageSent.ValueChanged += new System.EventHandler(this.datMessageSent_ValueChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(205, 181);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(586, 67);
            this.txtMessage.TabIndex = 46;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(205, 111);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(586, 29);
            this.txtSubject.TabIndex = 22;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // cboFrom
            // 
            this.cboFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Location = new System.Drawing.Point(205, 73);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(586, 32);
            this.cboFrom.TabIndex = 21;
            this.cboFrom.Leave += new System.EventHandler(this.cboFrom_Leave);
            // 
            // txtToPosition
            // 
            this.txtToPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToPosition.Location = new System.Drawing.Point(206, 37);
            this.txtToPosition.Name = "txtToPosition";
            this.txtToPosition.Size = new System.Drawing.Size(204, 29);
            this.txtToPosition.TabIndex = 20;
            this.txtToPosition.TextChanged += new System.EventHandler(this.txtToPosition_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 29);
            this.label5.TabIndex = 34;
            this.label5.Text = "TO (Name)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(75, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "TO (Position)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 29);
            this.label2.TabIndex = 36;
            this.label2.Text = "FROM";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 29);
            this.label6.TabIndex = 39;
            this.label6.Text = "MESSAGE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 29);
            this.label3.TabIndex = 37;
            this.label3.Text = "SUBJECT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "DATE/TIME SENT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = true;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = true;
            this.prepAndApprovePanel1.ExpandsRight = false;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(419, 6);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 10, 31, 9, 52, 19, 867);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(372, 40);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(372, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(731, 143);
            this.prepAndApprovePanel1.TabIndex = 48;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved By";
            this.prepAndApprovePanel1.PreparedByChanged += new System.EventHandler(this.prepAndApprovePanel1_PreparedByChanged);
            this.prepAndApprovePanel1.ApprovedByChanged += new System.EventHandler(this.prepAndApprovePanel1_ApprovedByChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(193, 29);
            this.label8.TabIndex = 41;
            this.label8.Text = "REPLY";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReply
            // 
            this.txtReply.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReply.Location = new System.Drawing.Point(205, 12);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(586, 74);
            this.txtReply.TabIndex = 47;
            this.txtReply.TextChanged += new System.EventHandler(this.txtReply_TextChanged);
            this.txtReply.Child = new System.Windows.Controls.TextBox();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(-11, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 29);
            this.label9.TabIndex = 43;
            this.label9.Text = "REPLIED BY (Position)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(6, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 29);
            this.label11.TabIndex = 44;
            this.label11.Text = "REPLY RECEIVED";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReplyPosition
            // 
            this.txtReplyPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReplyPosition.Location = new System.Drawing.Point(206, 127);
            this.txtReplyPosition.Name = "txtReplyPosition";
            this.txtReplyPosition.Size = new System.Drawing.Size(403, 29);
            this.txtReplyPosition.TabIndex = 28;
            this.txtReplyPosition.TextChanged += new System.EventHandler(this.txtReplyPosition_TextChanged);
            // 
            // txtReplyName
            // 
            this.txtReplyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReplyName.Location = new System.Drawing.Point(206, 92);
            this.txtReplyName.Name = "txtReplyName";
            this.txtReplyName.Size = new System.Drawing.Size(403, 29);
            this.txtReplyName.TabIndex = 27;
            this.txtReplyName.TextChanged += new System.EventHandler(this.txtReplyName_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(6, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 29);
            this.label10.TabIndex = 42;
            this.label10.Text = "REPLIED BY (Name)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datReplyReceived
            // 
            this.datReplyReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datReplyReceived.Checked = false;
            this.datReplyReceived.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datReplyReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datReplyReceived.Location = new System.Drawing.Point(206, 162);
            this.datReplyReceived.Name = "datReplyReceived";
            this.datReplyReceived.ShowCheckBox = true;
            this.datReplyReceived.Size = new System.Drawing.Size(403, 29);
            this.datReplyReceived.TabIndex = 29;
            this.datReplyReceived.ValueChanged += new System.EventHandler(this.datReplyReceived_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(666, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 18;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GeneralMessageEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 532);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(819, 571);
            this.Name = "GeneralMessageEditForm";
            this.Text = "Edit General Message";
            this.Load += new System.EventHandler(this.GeneralMessageEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtToName;
        private System.Windows.Forms.TextBox txtToPosition;
        private System.Windows.Forms.DateTimePicker datReplyReceived;
        private System.Windows.Forms.TextBox txtReplyPosition;
        private System.Windows.Forms.TextBox txtReplyName;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.DateTimePicker datMessageSent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private SpellBox txtReply;
        private SpellBox txtMessage;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}