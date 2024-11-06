namespace Wildfire_ICS_Assist.UtilityForms
{
    partial class InternetSyncForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InternetSyncForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLearnMore = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlJoinSync = new System.Windows.Forms.Panel();
            this.btnCopyJoinEncryiptionKey = new System.Windows.Forms.Button();
            this.btnCopyJoinShareInfo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJoinSyncEncryptionKey = new System.Windows.Forms.TextBox();
            this.rbOngoingSync = new System.Windows.Forms.RadioButton();
            this.pnlNewSync = new System.Windows.Forms.Panel();
            this.btnCopyExistingEncryptionKey = new System.Windows.Forms.Button();
            this.btnCopySharingInfo = new System.Windows.Forms.Button();
            this.rbNewSync = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewSyncEncryptionKey = new System.Windows.Forms.TextBox();
            this.pnlNoSync = new System.Windows.Forms.Panel();
            this.rbDoNotSync = new System.Windows.Forms.RadioButton();
            this.lblSyncStatus = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlJoinSync.SuspendLayout();
            this.pnlNewSync.SuspendLayout();
            this.pnlNoSync.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnLearnMore);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.pnlJoinSync);
            this.splitContainer1.Panel1.Controls.Add(this.pnlNewSync);
            this.splitContainer1.Panel1.Controls.Add(this.pnlNoSync);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblSyncStatus);
            this.splitContainer1.Panel2.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(868, 572);
            this.splitContainer1.SplitterDistance = 501;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnLearnMore
            // 
            this.btnLearnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLearnMore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLearnMore.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnLearnMore.Image = ((System.Drawing.Image)(resources.GetObject("btnLearnMore.Image")));
            this.btnLearnMore.Location = new System.Drawing.Point(686, 12);
            this.btnLearnMore.Name = "btnLearnMore";
            this.btnLearnMore.Size = new System.Drawing.Size(164, 37);
            this.btnLearnMore.TabIndex = 88;
            this.btnLearnMore.TabStop = false;
            this.btnLearnMore.Tag = "Help";
            this.btnLearnMore.Text = "Learn more";
            this.btnLearnMore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLearnMore.UseVisualStyleBackColor = true;
            this.btnLearnMore.Click += new System.EventHandler(this.btnLearnMore_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(638, 32);
            this.label16.TabIndex = 35;
            this.label16.Text = "Internet Task Sync";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlJoinSync
            // 
            this.pnlJoinSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlJoinSync.BackColor = System.Drawing.Color.White;
            this.pnlJoinSync.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlJoinSync.Controls.Add(this.btnCopyJoinEncryiptionKey);
            this.pnlJoinSync.Controls.Add(this.btnCopyJoinShareInfo);
            this.pnlJoinSync.Controls.Add(this.label3);
            this.pnlJoinSync.Controls.Add(this.label2);
            this.pnlJoinSync.Controls.Add(this.txtJoinSyncEncryptionKey);
            this.pnlJoinSync.Controls.Add(this.rbOngoingSync);
            this.pnlJoinSync.Location = new System.Drawing.Point(12, 109);
            this.pnlJoinSync.Name = "pnlJoinSync";
            this.pnlJoinSync.Size = new System.Drawing.Size(838, 203);
            this.pnlJoinSync.TabIndex = 2;
            this.pnlJoinSync.Click += new System.EventHandler(this.pnlJoinSync_Click);
            this.pnlJoinSync.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlJoinSync_Paint);
            // 
            // btnCopyJoinEncryiptionKey
            // 
            this.btnCopyJoinEncryiptionKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyJoinEncryiptionKey.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyJoinEncryiptionKey.Image")));
            this.btnCopyJoinEncryiptionKey.Location = new System.Drawing.Point(790, 103);
            this.btnCopyJoinEncryiptionKey.Name = "btnCopyJoinEncryiptionKey";
            this.btnCopyJoinEncryiptionKey.Size = new System.Drawing.Size(43, 37);
            this.btnCopyJoinEncryiptionKey.TabIndex = 77;
            this.btnCopyJoinEncryiptionKey.UseVisualStyleBackColor = true;
            this.btnCopyJoinEncryiptionKey.Click += new System.EventHandler(this.btnCopyJoinEncryiptionKey_Click);
            // 
            // btnCopyJoinShareInfo
            // 
            this.btnCopyJoinShareInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyJoinShareInfo.Image")));
            this.btnCopyJoinShareInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopyJoinShareInfo.Location = new System.Drawing.Point(12, 141);
            this.btnCopyJoinShareInfo.Name = "btnCopyJoinShareInfo";
            this.btnCopyJoinShareInfo.Size = new System.Drawing.Size(219, 42);
            this.btnCopyJoinShareInfo.TabIndex = 76;
            this.btnCopyJoinShareInfo.Text = "Copy sharing info";
            this.btnCopyJoinShareInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyJoinShareInfo.UseVisualStyleBackColor = true;
            this.btnCopyJoinShareInfo.Click += new System.EventHandler(this.btnCopyJoinShareInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(794, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "You will need to get the task ID and encryption key from your colleague.  Each ta" +
    "sk has a unique encryption key.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 61;
            this.label2.Text = "Encryption Key";
            // 
            // txtJoinSyncEncryptionKey
            // 
            this.txtJoinSyncEncryptionKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJoinSyncEncryptionKey.Location = new System.Drawing.Point(12, 106);
            this.txtJoinSyncEncryptionKey.Name = "txtJoinSyncEncryptionKey";
            this.txtJoinSyncEncryptionKey.Size = new System.Drawing.Size(772, 29);
            this.txtJoinSyncEncryptionKey.TabIndex = 65;
            this.txtJoinSyncEncryptionKey.TextChanged += new System.EventHandler(this.txtJoinSyncEncryptionKey_TextChanged);
            this.txtJoinSyncEncryptionKey.Leave += new System.EventHandler(this.txtJoinSyncEncryptionKey_Leave);
            // 
            // rbOngoingSync
            // 
            this.rbOngoingSync.AutoSize = true;
            this.rbOngoingSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOngoingSync.Location = new System.Drawing.Point(12, 3);
            this.rbOngoingSync.Name = "rbOngoingSync";
            this.rbOngoingSync.Size = new System.Drawing.Size(265, 33);
            this.rbOngoingSync.TabIndex = 1;
            this.rbOngoingSync.TabStop = true;
            this.rbOngoingSync.Text = "Join an Ongoing Sync";
            this.rbOngoingSync.UseVisualStyleBackColor = true;
            this.rbOngoingSync.CheckedChanged += new System.EventHandler(this.rbOngoingSync_CheckedChanged);
            // 
            // pnlNewSync
            // 
            this.pnlNewSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNewSync.BackColor = System.Drawing.Color.White;
            this.pnlNewSync.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNewSync.Controls.Add(this.btnCopyExistingEncryptionKey);
            this.pnlNewSync.Controls.Add(this.btnCopySharingInfo);
            this.pnlNewSync.Controls.Add(this.rbNewSync);
            this.pnlNewSync.Controls.Add(this.label5);
            this.pnlNewSync.Controls.Add(this.txtNewSyncEncryptionKey);
            this.pnlNewSync.Location = new System.Drawing.Point(12, 318);
            this.pnlNewSync.Name = "pnlNewSync";
            this.pnlNewSync.Size = new System.Drawing.Size(838, 154);
            this.pnlNewSync.TabIndex = 3;
            this.pnlNewSync.Click += new System.EventHandler(this.pnlNewSync_Click);
            // 
            // btnCopyExistingEncryptionKey
            // 
            this.btnCopyExistingEncryptionKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyExistingEncryptionKey.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyExistingEncryptionKey.Image")));
            this.btnCopyExistingEncryptionKey.Location = new System.Drawing.Point(790, 66);
            this.btnCopyExistingEncryptionKey.Name = "btnCopyExistingEncryptionKey";
            this.btnCopyExistingEncryptionKey.Size = new System.Drawing.Size(43, 37);
            this.btnCopyExistingEncryptionKey.TabIndex = 74;
            this.btnCopyExistingEncryptionKey.UseVisualStyleBackColor = true;
            this.btnCopyExistingEncryptionKey.Click += new System.EventHandler(this.btnCopyExistingEncryptionKey_Click);
            // 
            // btnCopySharingInfo
            // 
            this.btnCopySharingInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCopySharingInfo.Image")));
            this.btnCopySharingInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopySharingInfo.Location = new System.Drawing.Point(12, 101);
            this.btnCopySharingInfo.Name = "btnCopySharingInfo";
            this.btnCopySharingInfo.Size = new System.Drawing.Size(219, 42);
            this.btnCopySharingInfo.TabIndex = 73;
            this.btnCopySharingInfo.Text = "Copy sharing info";
            this.btnCopySharingInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopySharingInfo.UseVisualStyleBackColor = true;
            this.btnCopySharingInfo.Click += new System.EventHandler(this.btnCopySharingInfo_Click);
            // 
            // rbNewSync
            // 
            this.rbNewSync.AutoSize = true;
            this.rbNewSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNewSync.Location = new System.Drawing.Point(12, 3);
            this.rbNewSync.Name = "rbNewSync";
            this.rbNewSync.Size = new System.Drawing.Size(208, 33);
            this.rbNewSync.TabIndex = 2;
            this.rbNewSync.TabStop = true;
            this.rbNewSync.Text = "Start a new Sync";
            this.rbNewSync.UseVisualStyleBackColor = true;
            this.rbNewSync.CheckedChanged += new System.EventHandler(this.rbNewSync_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 24);
            this.label5.TabIndex = 69;
            this.label5.Text = "Encryption Key";
            // 
            // txtNewSyncEncryptionKey
            // 
            this.txtNewSyncEncryptionKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewSyncEncryptionKey.Location = new System.Drawing.Point(12, 66);
            this.txtNewSyncEncryptionKey.Name = "txtNewSyncEncryptionKey";
            this.txtNewSyncEncryptionKey.ReadOnly = true;
            this.txtNewSyncEncryptionKey.Size = new System.Drawing.Size(772, 29);
            this.txtNewSyncEncryptionKey.TabIndex = 70;
            // 
            // pnlNoSync
            // 
            this.pnlNoSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNoSync.BackColor = System.Drawing.Color.White;
            this.pnlNoSync.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoSync.Controls.Add(this.rbDoNotSync);
            this.pnlNoSync.Location = new System.Drawing.Point(12, 55);
            this.pnlNoSync.Name = "pnlNoSync";
            this.pnlNoSync.Size = new System.Drawing.Size(838, 48);
            this.pnlNoSync.TabIndex = 0;
            this.pnlNoSync.Click += new System.EventHandler(this.pnlNoSync_Click);
            // 
            // rbDoNotSync
            // 
            this.rbDoNotSync.AutoSize = true;
            this.rbDoNotSync.Checked = true;
            this.rbDoNotSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDoNotSync.Location = new System.Drawing.Point(12, 3);
            this.rbDoNotSync.Name = "rbDoNotSync";
            this.rbDoNotSync.Size = new System.Drawing.Size(155, 33);
            this.rbDoNotSync.TabIndex = 0;
            this.rbDoNotSync.TabStop = true;
            this.rbDoNotSync.Text = "Do not sync";
            this.rbDoNotSync.UseVisualStyleBackColor = true;
            this.rbDoNotSync.CheckedChanged += new System.EventHandler(this.rbDoNotSync_CheckedChanged);
            // 
            // lblSyncStatus
            // 
            this.lblSyncStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSyncStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyncStatus.Location = new System.Drawing.Point(136, 10);
            this.lblSyncStatus.Name = "lblSyncStatus";
            this.lblSyncStatus.Size = new System.Drawing.Size(584, 46);
            this.lblSyncStatus.TabIndex = 90;
            this.lblSyncStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(733, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(117, 46);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 90;
            this.progressBar1.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(6, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 46);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_487_exchange;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(729, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 46);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "OK";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // InternetSyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 572);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(884, 611);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(884, 611);
            this.Name = "InternetSyncForm";
            this.Text = "Internet Sync";
            this.Load += new System.EventHandler(this.InternetSyncForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlJoinSync.ResumeLayout(false);
            this.pnlJoinSync.PerformLayout();
            this.pnlNewSync.ResumeLayout(false);
            this.pnlNewSync.PerformLayout();
            this.pnlNoSync.ResumeLayout(false);
            this.pnlNoSync.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLearnMore;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlJoinSync;
        private System.Windows.Forms.Button btnCopyJoinEncryiptionKey;
        private System.Windows.Forms.Button btnCopyJoinShareInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJoinSyncEncryptionKey;
        private System.Windows.Forms.RadioButton rbOngoingSync;
        private System.Windows.Forms.Panel pnlNewSync;
        private System.Windows.Forms.Button btnCopyExistingEncryptionKey;
        private System.Windows.Forms.Button btnCopySharingInfo;
        private System.Windows.Forms.RadioButton rbNewSync;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewSyncEncryptionKey;
        private System.Windows.Forms.Panel pnlNoSync;
        private System.Windows.Forms.RadioButton rbDoNotSync;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblSyncStatus;
    }
}