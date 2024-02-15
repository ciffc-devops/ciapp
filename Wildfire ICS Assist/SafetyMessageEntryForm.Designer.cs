namespace Wildfire_ICS_Assist
{
    partial class SafetyMessageEntryForm
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
            this.pnlSaved = new System.Windows.Forms.Panel();
            this.txtSavedSitePlanLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkSavedSitePlanRequired = new System.Windows.Forms.CheckBox();
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.cboSaved = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNewSitePlanLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkNewSitePlanRequired = new System.Windows.Forms.CheckBox();
            this.txtSummaryLine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtNewMessage = new SpellBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSaved.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.pnlSaved);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(847, 682);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlSaved
            // 
            this.pnlSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSaved.BackColor = System.Drawing.Color.White;
            this.pnlSaved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSaved.Controls.Add(this.txtSavedSitePlanLocation);
            this.pnlSaved.Controls.Add(this.label7);
            this.pnlSaved.Controls.Add(this.chkSavedSitePlanRequired);
            this.pnlSaved.Controls.Add(this.btnAddSaved);
            this.pnlSaved.Controls.Add(this.cboSaved);
            this.pnlSaved.Controls.Add(this.label1);
            this.pnlSaved.Location = new System.Drawing.Point(6, 7);
            this.pnlSaved.Name = "pnlSaved";
            this.pnlSaved.Size = new System.Drawing.Size(829, 147);
            this.pnlSaved.TabIndex = 1;
            // 
            // txtSavedSitePlanLocation
            // 
            this.txtSavedSitePlanLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedSitePlanLocation.Location = new System.Drawing.Point(12, 108);
            this.txtSavedSitePlanLocation.Name = "txtSavedSitePlanLocation";
            this.txtSavedSitePlanLocation.Size = new System.Drawing.Size(677, 29);
            this.txtSavedSitePlanLocation.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(343, 29);
            this.label7.TabIndex = 129;
            this.label7.Text = "Approved Site Safety Plan(s) Located at:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSavedSitePlanRequired
            // 
            this.chkSavedSitePlanRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSavedSitePlanRequired.AutoSize = true;
            this.chkSavedSitePlanRequired.Location = new System.Drawing.Point(439, 74);
            this.chkSavedSitePlanRequired.Name = "chkSavedSitePlanRequired";
            this.chkSavedSitePlanRequired.Size = new System.Drawing.Size(250, 28);
            this.chkSavedSitePlanRequired.TabIndex = 2;
            this.chkSavedSitePlanRequired.Text = "Site Safety Plan Required?";
            this.chkSavedSitePlanRequired.UseVisualStyleBackColor = true;
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSaved.Location = new System.Drawing.Point(698, 36);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 80);
            this.btnAddSaved.TabIndex = 4;
            this.btnAddSaved.Text = "Add to Incident";
            this.btnAddSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSaved.UseVisualStyleBackColor = true;
            this.btnAddSaved.Click += new System.EventHandler(this.btnAddSaved_Click);
            // 
            // cboSaved
            // 
            this.cboSaved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSaved.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSaved.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSaved.DisplayMember = "SummaryLine";
            this.cboSaved.FormattingEnabled = true;
            this.cboSaved.Location = new System.Drawing.Point(12, 36);
            this.cboSaved.Name = "cboSaved";
            this.cboSaved.Size = new System.Drawing.Size(677, 32);
            this.cboSaved.TabIndex = 1;
            this.cboSaved.ValueMember = "ID";
            this.cboSaved.Leave += new System.EventHandler(this.cboSaved_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Safety Message / Plan";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_38_picture;
            this.pictureBox1.Location = new System.Drawing.Point(257, 471);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 100;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(302, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(524, 24);
            this.label5.TabIndex = 99;
            this.label5.Text = "*To add an image to the safety plan, Edit it after adding it here.";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 461);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtNewMessage);
            this.panel2.Controls.Add(this.txtNewSitePlanLocation);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkNewSitePlanRequired);
            this.panel2.Controls.Add(this.txtSummaryLine);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.lblEditTitle);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 449);
            this.panel2.TabIndex = 98;
            // 
            // txtNewSitePlanLocation
            // 
            this.txtNewSitePlanLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewSitePlanLocation.Location = new System.Drawing.Point(365, 344);
            this.txtNewSitePlanLocation.Name = "txtNewSitePlanLocation";
            this.txtNewSitePlanLocation.Size = new System.Drawing.Size(454, 29);
            this.txtNewSitePlanLocation.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 24);
            this.label4.TabIndex = 124;
            this.label4.Text = "Approved Site Safety Plan(s) Located at:";
            // 
            // chkNewSitePlanRequired
            // 
            this.chkNewSitePlanRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNewSitePlanRequired.AutoSize = true;
            this.chkNewSitePlanRequired.Location = new System.Drawing.Point(20, 316);
            this.chkNewSitePlanRequired.Name = "chkNewSitePlanRequired";
            this.chkNewSitePlanRequired.Size = new System.Drawing.Size(250, 28);
            this.chkNewSitePlanRequired.TabIndex = 7;
            this.chkNewSitePlanRequired.Text = "Site Safety Plan Required?";
            this.chkNewSitePlanRequired.UseVisualStyleBackColor = true;
            // 
            // txtSummaryLine
            // 
            this.txtSummaryLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummaryLine.Location = new System.Drawing.Point(214, 51);
            this.txtSummaryLine.Name = "txtSummaryLine";
            this.txtSummaryLine.Size = new System.Drawing.Size(605, 29);
            this.txtSummaryLine.TabIndex = 5;
            this.txtSummaryLine.TextChanged += new System.EventHandler(this.txtSummaryLine_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 29);
            this.label2.TabIndex = 122;
            this.label2.Text = "Message/Plan Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(652, 24);
            this.label3.TabIndex = 121;
            this.label3.Text = "Safety Message / Expanded Safety Message, Plan, Site Safety Plan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(379, 404);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveForLater.TabIndex = 9;
            this.chkSaveForLater.Text = "Save for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.AutoSize = true;
            this.lblEditTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditTitle.Location = new System.Drawing.Point(3, 10);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(332, 29);
            this.lblEditTitle.TabIndex = 99;
            this.lblEditTitle.Text = "New Safety Message / Plan";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.Location = new System.Drawing.Point(617, 393);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 10;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtNewMessage
            // 
            this.txtNewMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewMessage.Location = new System.Drawing.Point(12, 119);
            this.txtNewMessage.Multiline = true;
            this.txtNewMessage.Name = "txtNewMessage";
            this.txtNewMessage.Size = new System.Drawing.Size(807, 191);
            this.txtNewMessage.TabIndex = 125;
            this.txtNewMessage.WordWrap = true;
            this.txtNewMessage.TextChanged += new System.EventHandler(this.txtNewMessage_TextChanged);
            this.txtNewMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // SafetyMessageEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 682);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(863, 698);
            this.Name = "SafetyMessageEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add a new Safety Message/Plan";
            this.Load += new System.EventHandler(this.SafetyMessageEntryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSaved.ResumeLayout(false);
            this.pnlSaved.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlSaved;
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSaved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtNewSitePlanLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkNewSitePlanRequired;
        private System.Windows.Forms.TextBox txtSummaryLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSavedSitePlanLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkSavedSitePlanRequired;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private SpellBox txtNewMessage;
    }
}