namespace Wildfire_ICS_Assist
{
    partial class SafetyMessageEditForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new SpellBox();
            this.txtNewSitePlanLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSummaryLine = new System.Windows.Forms.TextBox();
            this.chkNewSitePlanRequired = new System.Windows.Forms.CheckBox();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.picTitleImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnRemoveImage = new System.Windows.Forms.Button();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.collapsiblePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleImage)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(1100, 536);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(979, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 51);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images|*.jpg;*.jpeg;*.png;,*.gif,*.bmp";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtMessage);
            this.splitContainer2.Panel1.Controls.Add(this.txtNewSitePlanLocation);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.txtSummaryLine);
            this.splitContainer2.Panel1.Controls.Add(this.chkNewSitePlanRequired);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.prepAndApprovePanel1);
            this.splitContainer2.Panel2.Controls.Add(this.collapsiblePanel1);
            this.splitContainer2.Size = new System.Drawing.Size(1100, 469);
            this.splitContainer2.SplitterDistance = 689;
            this.splitContainer2.TabIndex = 135;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 29);
            this.label2.TabIndex = 119;
            this.label2.Text = "Message/Plan Name";
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(13, 79);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(673, 266);
            this.txtMessage.TabIndex = 132;
            this.txtMessage.WordWrap = true;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged_1);
            this.txtMessage.Child = new System.Windows.Controls.TextBox();
            // 
            // txtNewSitePlanLocation
            // 
            this.txtNewSitePlanLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewSitePlanLocation.Location = new System.Drawing.Point(13, 417);
            this.txtNewSitePlanLocation.Name = "txtNewSitePlanLocation";
            this.txtNewSitePlanLocation.Size = new System.Drawing.Size(673, 29);
            this.txtNewSitePlanLocation.TabIndex = 4;
            this.txtNewSitePlanLocation.TextChanged += new System.EventHandler(this.txtNewSitePlanLocation_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 24);
            this.label1.TabIndex = 118;
            this.label1.Text = "Safety Message / Expanded Safety Message, Plan, Site Safety Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 382);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 24);
            this.label4.TabIndex = 127;
            this.label4.Text = "Approved Site Safety Plan(s) Located at:";
            // 
            // txtSummaryLine
            // 
            this.txtSummaryLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSummaryLine.Location = new System.Drawing.Point(211, 14);
            this.txtSummaryLine.Name = "txtSummaryLine";
            this.txtSummaryLine.Size = new System.Drawing.Size(475, 29);
            this.txtSummaryLine.TabIndex = 1;
            this.txtSummaryLine.TextChanged += new System.EventHandler(this.txtSummaryLine_TextChanged);
            // 
            // chkNewSitePlanRequired
            // 
            this.chkNewSitePlanRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNewSitePlanRequired.AutoSize = true;
            this.chkNewSitePlanRequired.Location = new System.Drawing.Point(13, 351);
            this.chkNewSitePlanRequired.Name = "chkNewSitePlanRequired";
            this.chkNewSitePlanRequired.Size = new System.Drawing.Size(250, 28);
            this.chkNewSitePlanRequired.TabIndex = 3;
            this.chkNewSitePlanRequired.Text = "Site Safety Plan Required?";
            this.chkNewSitePlanRequired.UseVisualStyleBackColor = true;
            this.chkNewSitePlanRequired.CheckedChanged += new System.EventHandler(this.chkNewSitePlanRequired_CheckedChanged);
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.Collapsed = true;
            this.collapsiblePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.Controls.Add(this.picTitleImage);
            this.collapsiblePanel1.Controls.Add(this.btnSelectImage);
            this.collapsiblePanel1.Controls.Add(this.btnRemoveImage);
            this.collapsiblePanel1.EnableExpandCollapse = true;
            this.collapsiblePanel1.ExpandsRight = true;
            this.collapsiblePanel1.ExpandsUpward = false;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(17, 54);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(386, 40);
            this.collapsiblePanel1.SizeWhenCollapsed = new System.Drawing.Size(386, 40);
            this.collapsiblePanel1.SizeWhenExpanded = new System.Drawing.Size(386, 265);
            this.collapsiblePanel1.TabIndex = 134;
            this.collapsiblePanel1.TitleText = "Image / Photo";
            // 
            // picTitleImage
            // 
            this.picTitleImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitleImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTitleImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTitleImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.picTitleImage.Location = new System.Drawing.Point(3, 96);
            this.picTitleImage.Name = "picTitleImage";
            this.picTitleImage.Size = new System.Drawing.Size(378, 164);
            this.picTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTitleImage.TabIndex = 129;
            this.picTitleImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnSelectImage.Location = new System.Drawing.Point(3, 54);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(112, 36);
            this.btnSelectImage.TabIndex = 130;
            this.btnSelectImage.Text = "Select...";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnRemoveImage
            // 
            this.btnRemoveImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.btnRemoveImage.Location = new System.Drawing.Point(121, 54);
            this.btnRemoveImage.Name = "btnRemoveImage";
            this.btnRemoveImage.Size = new System.Drawing.Size(112, 36);
            this.btnRemoveImage.TabIndex = 131;
            this.btnRemoveImage.Text = "Remove";
            this.btnRemoveImage.UseVisualStyleBackColor = true;
            this.btnRemoveImage.Click += new System.EventHandler(this.btnRemoveImage_Click);
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.White;
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = false;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = true;
            this.prepAndApprovePanel1.ExpandsRight = false;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(17, 6);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 11, 12, 8, 52, 17, 130);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(386, 229);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(386, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(386, 229);
            this.prepAndApprovePanel1.TabIndex = 133;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved";
            // 
            // SafetyMessageEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 536);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(771, 575);
            this.Name = "SafetyMessageEditForm";
            this.Text = "Edit Safety Message";
            this.Load += new System.EventHandler(this.SafetyMessageEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.collapsiblePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitleImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private SpellBox txtMessage;
        private System.Windows.Forms.TextBox txtNewSitePlanLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSummaryLine;
        private System.Windows.Forms.CheckBox chkNewSitePlanRequired;
        private CustomControls.CollapsiblePanel collapsiblePanel1;
        private System.Windows.Forms.PictureBox picTitleImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnRemoveImage;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
    }
}