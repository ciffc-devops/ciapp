namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditCommsChannelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCommsChannelControl));
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTxTone = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTxFrequency = new System.Windows.Forms.TextBox();
            this.btnToneHelp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRxTone = new System.Windows.Forms.TextBox();
            this.txtChannelID = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCommsSystemHelp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtRxFrequency = new System.Windows.Forms.TextBox();
            this.txtCommsSystem = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Help;
            this.button1.Location = new System.Drawing.Point(413, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 125;
            this.button1.TabStop = false;
            this.button1.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.button1, "Include any sub audible, Network Access or CTCSS tones if applicable. This inform" +
        "ation is useful for field programmable radios.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 29);
            this.label4.TabIndex = 124;
            this.label4.Text = "Tx Tone";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTxTone
            // 
            this.txtTxTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTxTone.Location = new System.Drawing.Point(158, 200);
            this.txtTxTone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTxTone.Name = "txtTxTone";
            this.txtTxTone.Size = new System.Drawing.Size(248, 29);
            this.txtTxTone.TabIndex = 6;
            this.txtTxTone.TextChanged += new System.EventHandler(this.txtTxTone_TextChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Help;
            this.button3.Location = new System.Drawing.Point(413, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 123;
            this.button3.TabStop = false;
            this.button3.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.button3, "enter the transmit (TX) frequency");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 122;
            this.label7.Text = "Tx Frequency";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTxFrequency
            // 
            this.txtTxFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTxFrequency.Location = new System.Drawing.Point(158, 161);
            this.txtTxFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTxFrequency.Name = "txtTxFrequency";
            this.txtTxFrequency.Size = new System.Drawing.Size(248, 29);
            this.txtTxFrequency.TabIndex = 5;
            this.txtTxFrequency.TextChanged += new System.EventHandler(this.txtTxFrequency_TextChanged);
            // 
            // btnToneHelp
            // 
            this.btnToneHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToneHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToneHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnToneHelp.Location = new System.Drawing.Point(413, 122);
            this.btnToneHelp.Name = "btnToneHelp";
            this.btnToneHelp.Size = new System.Drawing.Size(26, 26);
            this.btnToneHelp.TabIndex = 119;
            this.btnToneHelp.TabStop = false;
            this.btnToneHelp.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.btnToneHelp, "Include any sub audible, Network Access or CTCSS tones if applicable. This inform" +
        "ation is useful for field programmable radios.");
            this.btnToneHelp.UseVisualStyleBackColor = true;
            this.btnToneHelp.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 118;
            this.label2.Text = "Rx Tone";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRxTone
            // 
            this.txtRxTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRxTone.Location = new System.Drawing.Point(158, 122);
            this.txtRxTone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRxTone.Name = "txtRxTone";
            this.txtRxTone.Size = new System.Drawing.Size(248, 29);
            this.txtRxTone.TabIndex = 4;
            this.txtRxTone.TextChanged += new System.EventHandler(this.txtRxTone_TextChanged);
            // 
            // txtChannelID
            // 
            this.txtChannelID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChannelID.Location = new System.Drawing.Point(158, 44);
            this.txtChannelID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChannelID.Name = "txtChannelID";
            this.txtChannelID.Size = new System.Drawing.Size(248, 29);
            this.txtChannelID.TabIndex = 2;
            this.txtChannelID.TextChanged += new System.EventHandler(this.txtChannelID_TextChanged);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Cursor = System.Windows.Forms.Cursors.Help;
            this.button5.Location = new System.Drawing.Point(413, 242);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(26, 26);
            this.button5.TabIndex = 117;
            this.button5.TabStop = false;
            this.button5.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.button5, "Include any comments or remarks specific to the channel assignment.");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Help;
            this.button4.Location = new System.Drawing.Point(413, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 116;
            this.button4.TabStop = false;
            this.button4.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.button4, "Enter the receive (RX) frequency");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Help;
            this.button2.Location = new System.Drawing.Point(413, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 115;
            this.button2.TabStop = false;
            this.button2.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.button2, resources.GetString("button2.ToolTip"));
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // btnCommsSystemHelp
            // 
            this.btnCommsSystemHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommsSystemHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCommsSystemHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnCommsSystemHelp.Location = new System.Drawing.Point(413, 5);
            this.btnCommsSystemHelp.Name = "btnCommsSystemHelp";
            this.btnCommsSystemHelp.Size = new System.Drawing.Size(26, 26);
            this.btnCommsSystemHelp.TabIndex = 114;
            this.btnCommsSystemHelp.TabStop = false;
            this.btnCommsSystemHelp.Tag = "HelpSM";
            this.toolTip1.SetToolTip(this.btnCommsSystemHelp, "Use this field to describe the owner of the radio system (if multi systems are us" +
        "ed on same incident. I.e., DNR, DOT, DFO, and \"Type\" examples are: Cellular, Sat" +
        "ellite, UHF, VHF, etc.");
            this.btnCommsSystemHelp.UseVisualStyleBackColor = true;
            this.btnCommsSystemHelp.Click += new System.EventHandler(this.btnCommsSystemHelp_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 29);
            this.label6.TabIndex = 113;
            this.label6.Text = "Remarks";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 29);
            this.label5.TabIndex = 112;
            this.label5.Text = "Rx Frequency";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 29);
            this.label3.TabIndex = 111;
            this.label3.Text = "Channel*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 29);
            this.label1.TabIndex = 110;
            this.label1.Text = "Comms System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(158, 239);
            this.txtComments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(248, 57);
            this.txtComments.TabIndex = 7;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // txtRxFrequency
            // 
            this.txtRxFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRxFrequency.Location = new System.Drawing.Point(158, 83);
            this.txtRxFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRxFrequency.Name = "txtRxFrequency";
            this.txtRxFrequency.Size = new System.Drawing.Size(248, 29);
            this.txtRxFrequency.TabIndex = 3;
            this.txtRxFrequency.TextChanged += new System.EventHandler(this.txtRxFrequency_TextChanged);
            // 
            // txtCommsSystem
            // 
            this.txtCommsSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommsSystem.Location = new System.Drawing.Point(158, 5);
            this.txtCommsSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommsSystem.Name = "txtCommsSystem";
            this.txtCommsSystem.Size = new System.Drawing.Size(248, 29);
            this.txtCommsSystem.TabIndex = 1;
            this.txtCommsSystem.TextChanged += new System.EventHandler(this.txtCommsSystem_TextChanged);
            // 
            // EditCommsChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTxTone);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTxFrequency);
            this.Controls.Add(this.btnToneHelp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRxTone);
            this.Controls.Add(this.txtChannelID);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCommsSystemHelp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtRxFrequency);
            this.Controls.Add(this.txtCommsSystem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditCommsChannelControl";
            this.Size = new System.Drawing.Size(442, 301);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTxTone;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTxFrequency;
        private System.Windows.Forms.Button btnToneHelp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRxTone;
        private System.Windows.Forms.TextBox txtChannelID;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCommsSystemHelp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtRxFrequency;
        private System.Windows.Forms.TextBox txtCommsSystem;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
