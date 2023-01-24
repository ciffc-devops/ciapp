namespace Wildfire_ICS_Assist
{
    partial class NetworkSettingsForm
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
            this.pnlServerInfo = new System.Windows.Forms.Panel();
            this.lblServerInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbStandalone = new System.Windows.Forms.RadioButton();
            this.pnlClientSettings = new System.Windows.Forms.Panel();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImportCoordinatesHelp = new System.Windows.Forms.Button();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlServerInfo.SuspendLayout();
            this.pnlClientSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServerInfo
            // 
            this.pnlServerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlServerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlServerInfo.Controls.Add(this.lblServerInfo);
            this.pnlServerInfo.Location = new System.Drawing.Point(33, 119);
            this.pnlServerInfo.Name = "pnlServerInfo";
            this.pnlServerInfo.Size = new System.Drawing.Size(572, 112);
            this.pnlServerInfo.TabIndex = 61;
            // 
            // lblServerInfo
            // 
            this.lblServerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerInfo.Location = new System.Drawing.Point(6, 5);
            this.lblServerInfo.Name = "lblServerInfo";
            this.lblServerInfo.Size = new System.Drawing.Size(558, 101);
            this.lblServerInfo.TabIndex = 0;
            this.lblServerInfo.Text = "--";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(501, 361);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 49);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(11, 361);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 49);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbStandalone
            // 
            this.rbStandalone.AutoSize = true;
            this.rbStandalone.Checked = true;
            this.rbStandalone.Location = new System.Drawing.Point(16, 51);
            this.rbStandalone.Name = "rbStandalone";
            this.rbStandalone.Size = new System.Drawing.Size(248, 28);
            this.rbStandalone.TabIndex = 54;
            this.rbStandalone.TabStop = true;
            this.rbStandalone.Text = "Run on this computer only";
            this.rbStandalone.UseVisualStyleBackColor = true;
            // 
            // pnlClientSettings
            // 
            this.pnlClientSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClientSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClientSettings.Controls.Add(this.txtServerPort);
            this.pnlClientSettings.Controls.Add(this.txtServerIP);
            this.pnlClientSettings.Controls.Add(this.label3);
            this.pnlClientSettings.Controls.Add(this.label2);
            this.pnlClientSettings.Enabled = false;
            this.pnlClientSettings.Location = new System.Drawing.Point(33, 271);
            this.pnlClientSettings.Name = "pnlClientSettings";
            this.pnlClientSettings.Size = new System.Drawing.Size(572, 77);
            this.pnlClientSettings.TabIndex = 58;
            // 
            // txtServerPort
            // 
            this.txtServerPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPort.Location = new System.Drawing.Point(172, 38);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(395, 29);
            this.txtServerPort.TabIndex = 54;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIP.Location = new System.Drawing.Point(172, 3);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(395, 29);
            this.txtServerIP.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 24);
            this.label3.TabIndex = 51;
            this.label3.Text = "Port Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 24);
            this.label2.TabIndex = 50;
            this.label2.Text = "Server IP Address";
            // 
            // btnImportCoordinatesHelp
            // 
            this.btnImportCoordinatesHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportCoordinatesHelp.BackgroundImage = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_931_speech_bubble_question_3x;
            this.btnImportCoordinatesHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImportCoordinatesHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCoordinatesHelp.Location = new System.Drawing.Point(566, 16);
            this.btnImportCoordinatesHelp.Name = "btnImportCoordinatesHelp";
            this.btnImportCoordinatesHelp.Size = new System.Drawing.Size(38, 38);
            this.btnImportCoordinatesHelp.TabIndex = 57;
            this.btnImportCoordinatesHelp.UseVisualStyleBackColor = true;
            // 
            // rbClient
            // 
            this.rbClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(11, 237);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(427, 28);
            this.rbClient.TabIndex = 56;
            this.rbClient.Text = "This computer will connect to another computer";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Location = new System.Drawing.Point(16, 85);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(295, 28);
            this.rbServer.TabIndex = 55;
            this.rbServer.Text = "This computer will be the server";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 29);
            this.label1.TabIndex = 53;
            this.label1.Text = "Network Settings";
            // 
            // NetworkSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 420);
            this.ControlBox = false;
            this.Controls.Add(this.pnlServerInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbStandalone);
            this.Controls.Add(this.pnlClientSettings);
            this.Controls.Add(this.btnImportCoordinatesHelp);
            this.Controls.Add(this.rbClient);
            this.Controls.Add(this.rbServer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "NetworkSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Network Share Settings";
            this.Load += new System.EventHandler(this.NetworkSettingsForm_Load);
            this.pnlServerInfo.ResumeLayout(false);
            this.pnlClientSettings.ResumeLayout(false);
            this.pnlClientSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlServerInfo;
        private System.Windows.Forms.Label lblServerInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbStandalone;
        private System.Windows.Forms.Panel pnlClientSettings;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportCoordinatesHelp;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.Label label1;
    }
}