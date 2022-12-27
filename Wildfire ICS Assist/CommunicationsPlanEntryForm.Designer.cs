namespace Wildfire_ICS_Assist
{
    partial class CommunicationsPlanEntryForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.cboSavedContacts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTone = new System.Windows.Forms.TextBox();
            this.txtChannelID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.txtCommsSystem = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(769, 622);
            this.splitContainer1.SplitterDistance = 137;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(15, 424);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 99;
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
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtTone);
            this.panel2.Controls.Add(this.txtChannelID);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtComments);
            this.panel2.Controls.Add(this.txtFrequency);
            this.panel2.Controls.Add(this.txtCommsSystem);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 412);
            this.panel2.TabIndex = 98;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(393, 367);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(137, 28);
            this.chkSaveForLater.TabIndex = 115;
            this.chkSaveForLater.Text = "Save for later";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New Comms Tool";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.Location = new System.Drawing.Point(539, 356);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 99;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnAddSaved);
            this.panel1.Controls.Add(this.cboSavedContacts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 124);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSaved.Location = new System.Drawing.Point(620, 26);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 80);
            this.btnAddSaved.TabIndex = 98;
            this.btnAddSaved.Text = "Add to Incident";
            this.btnAddSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSaved.UseVisualStyleBackColor = true;
            // 
            // cboSavedContacts
            // 
            this.cboSavedContacts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedContacts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedContacts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedContacts.DisplayMember = "NameAndOrg";
            this.cboSavedContacts.FormattingEnabled = true;
            this.cboSavedContacts.Location = new System.Drawing.Point(8, 36);
            this.cboSavedContacts.Name = "cboSavedContacts";
            this.cboSavedContacts.Size = new System.Drawing.Size(603, 32);
            this.cboSavedContacts.TabIndex = 1;
            this.cboSavedContacts.ValueMember = "ContactID";
            this.cboSavedContacts.SelectedIndexChanged += new System.EventHandler(this.cboSavedContacts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Communications Tool";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 29);
            this.label2.TabIndex = 125;
            this.label2.Text = "Tone";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTone
            // 
            this.txtTone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTone.Location = new System.Drawing.Point(169, 208);
            this.txtTone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTone.Name = "txtTone";
            this.txtTone.Size = new System.Drawing.Size(572, 29);
            this.txtTone.TabIndex = 119;
            // 
            // txtChannelID
            // 
            this.txtChannelID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChannelID.Location = new System.Drawing.Point(169, 91);
            this.txtChannelID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtChannelID.Name = "txtChannelID";
            this.txtChannelID.Size = new System.Drawing.Size(572, 29);
            this.txtChannelID.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 29);
            this.label6.TabIndex = 124;
            this.label6.Text = "Remarks";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 29);
            this.label5.TabIndex = 123;
            this.label5.Text = "Frequency";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 29);
            this.label3.TabIndex = 122;
            this.label3.Text = "Channel*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 29);
            this.label4.TabIndex = 121;
            this.label4.Text = "Comms System";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(169, 286);
            this.txtComments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(572, 59);
            this.txtComments.TabIndex = 120;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrequency.Location = new System.Drawing.Point(169, 169);
            this.txtFrequency.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(572, 29);
            this.txtFrequency.TabIndex = 118;
            // 
            // txtCommsSystem
            // 
            this.txtCommsSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommsSystem.Location = new System.Drawing.Point(169, 52);
            this.txtCommsSystem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCommsSystem.Name = "txtCommsSystem";
            this.txtCommsSystem.Size = new System.Drawing.Size(572, 29);
            this.txtCommsSystem.TabIndex = 116;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(169, 130);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(572, 29);
            this.textBox1.TabIndex = 126;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 127;
            this.label7.Text = "Function*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 29);
            this.label8.TabIndex = 129;
            this.label8.Text = "Assignment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(169, 247);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(572, 29);
            this.textBox2.TabIndex = 128;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(113, 77);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(184, 29);
            this.textBox3.TabIndex = 128;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 29);
            this.label9.TabIndex = 129;
            this.label9.Text = "Function*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(307, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 29);
            this.label11.TabIndex = 131;
            this.label11.Text = "Assignment";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(429, 77);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(181, 29);
            this.textBox4.TabIndex = 130;
            // 
            // CommunicationsPlanEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(769, 622);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CommunicationsPlanEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CommunicationsPlanEntryForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSavedContacts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTone;
        private System.Windows.Forms.TextBox txtChannelID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.TextBox txtCommsSystem;
    }
}