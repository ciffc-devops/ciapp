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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationsPlanEntryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlSavedComms = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSavedUsedForAir = new System.Windows.Forms.Button();
            this.chkSavedUsedForAir = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSavedAssignment = new System.Windows.Forms.TextBox();
            this.txtSavedFunction = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.cboSavedComms = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.editCommsChannelControl1 = new Wildfire_ICS_Assist.CustomControls.EditCommsChannelControl();
            this.btnAirHelp = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.chkUsedForAir = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAssignment = new System.Windows.Forms.TextBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlSavedComms.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.pnlSavedComms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(769, 781);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlSavedComms
            // 
            this.pnlSavedComms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedComms.BackColor = System.Drawing.Color.White;
            this.pnlSavedComms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedComms.Controls.Add(this.label13);
            this.pnlSavedComms.Controls.Add(this.btnSavedUsedForAir);
            this.pnlSavedComms.Controls.Add(this.chkSavedUsedForAir);
            this.pnlSavedComms.Controls.Add(this.label11);
            this.pnlSavedComms.Controls.Add(this.txtSavedAssignment);
            this.pnlSavedComms.Controls.Add(this.txtSavedFunction);
            this.pnlSavedComms.Controls.Add(this.label9);
            this.pnlSavedComms.Controls.Add(this.btnAddSaved);
            this.pnlSavedComms.Controls.Add(this.cboSavedComms);
            this.pnlSavedComms.Controls.Add(this.label1);
            this.pnlSavedComms.Location = new System.Drawing.Point(6, 7);
            this.pnlSavedComms.Name = "pnlSavedComms";
            this.pnlSavedComms.Size = new System.Drawing.Size(751, 158);
            this.pnlSavedComms.TabIndex = 1;
            this.pnlSavedComms.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(5, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 29);
            this.label13.TabIndex = 134;
            this.label13.Text = "Used for Air";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSavedUsedForAir
            // 
            this.btnSavedUsedForAir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavedUsedForAir.BackColor = System.Drawing.Color.White;
            this.btnSavedUsedForAir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSavedUsedForAir.BackgroundImage")));
            this.btnSavedUsedForAir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSavedUsedForAir.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnSavedUsedForAir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSavedUsedForAir.Location = new System.Drawing.Point(449, 119);
            this.btnSavedUsedForAir.Name = "btnSavedUsedForAir";
            this.btnSavedUsedForAir.Size = new System.Drawing.Size(25, 25);
            this.btnSavedUsedForAir.TabIndex = 132;
            this.btnSavedUsedForAir.Tag = "HelpSM";
            this.btnSavedUsedForAir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnSavedUsedForAir, "If this box is checked, this item will be included in the \'7. FREQUENCIES\' sectio" +
        "n of ICS-220 Air Ops Summary.");
            this.btnSavedUsedForAir.UseVisualStyleBackColor = false;
            this.btnSavedUsedForAir.Click += new System.EventHandler(this.btnAirHelp_Click);
            // 
            // chkSavedUsedForAir
            // 
            this.chkSavedUsedForAir.AutoSize = true;
            this.chkSavedUsedForAir.Location = new System.Drawing.Point(154, 119);
            this.chkSavedUsedForAir.Name = "chkSavedUsedForAir";
            this.chkSavedUsedForAir.Size = new System.Drawing.Size(289, 28);
            this.chkSavedUsedForAir.TabIndex = 4;
            this.chkSavedUsedForAir.Text = "Yes, this item is used for aircraft";
            this.chkSavedUsedForAir.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(343, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 29);
            this.label11.TabIndex = 131;
            this.label11.Text = "Assignment";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSavedAssignment
            // 
            this.txtSavedAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedAssignment.Location = new System.Drawing.Point(465, 77);
            this.txtSavedAssignment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSavedAssignment.Name = "txtSavedAssignment";
            this.txtSavedAssignment.Size = new System.Drawing.Size(145, 29);
            this.txtSavedAssignment.TabIndex = 3;
            // 
            // txtSavedFunction
            // 
            this.txtSavedFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedFunction.Location = new System.Drawing.Point(154, 77);
            this.txtSavedFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSavedFunction.Name = "txtSavedFunction";
            this.txtSavedFunction.Size = new System.Drawing.Size(182, 29);
            this.txtSavedFunction.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 29);
            this.label9.TabIndex = 129;
            this.label9.Text = "Function*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSaved.Location = new System.Drawing.Point(620, 26);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 80);
            this.btnAddSaved.TabIndex = 5;
            this.btnAddSaved.Text = "Add to Incident";
            this.btnAddSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddSaved.UseVisualStyleBackColor = true;
            this.btnAddSaved.Click += new System.EventHandler(this.btnAddSaved_Click);
            // 
            // cboSavedComms
            // 
            this.cboSavedComms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedComms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedComms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedComms.DisplayMember = "IDWithFrequency";
            this.cboSavedComms.FormattingEnabled = true;
            this.cboSavedComms.Location = new System.Drawing.Point(8, 36);
            this.cboSavedComms.Name = "cboSavedComms";
            this.cboSavedComms.Size = new System.Drawing.Size(603, 32);
            this.cboSavedComms.TabIndex = 1;
            this.cboSavedComms.ValueMember = "TemplateItemID";
            this.cboSavedComms.SelectedIndexChanged += new System.EventHandler(this.cboSavedComms_SelectedIndexChanged_1);
            this.cboSavedComms.Leave += new System.EventHandler(this.cboSavedComms_Leave);
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
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 549);
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
            this.panel2.Controls.Add(this.editCommsChannelControl1);
            this.panel2.Controls.Add(this.btnAirHelp);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.chkUsedForAir);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtAssignment);
            this.panel2.Controls.Add(this.txtFunction);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 537);
            this.panel2.TabIndex = 98;
            // 
            // editCommsChannelControl1
            // 
            this.editCommsChannelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editCommsChannelControl1.BackColor = System.Drawing.Color.Transparent;
            this.editCommsChannelControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCommsChannelControl1.Location = new System.Drawing.Point(9, 43);
            this.editCommsChannelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editCommsChannelControl1.Name = "editCommsChannelControl1";
            this.editCommsChannelControl1.selectedItem = null;
            this.editCommsChannelControl1.Size = new System.Drawing.Size(734, 296);
            this.editCommsChannelControl1.TabIndex = 26;
            // 
            // btnAirHelp
            // 
            this.btnAirHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAirHelp.BackColor = System.Drawing.Color.White;
            this.btnAirHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAirHelp.BackgroundImage")));
            this.btnAirHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAirHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAirHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAirHelp.Location = new System.Drawing.Point(464, 428);
            this.btnAirHelp.Name = "btnAirHelp";
            this.btnAirHelp.Size = new System.Drawing.Size(25, 25);
            this.btnAirHelp.TabIndex = 99;
            this.btnAirHelp.Tag = "HelpSM";
            this.btnAirHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAirHelp, "If this box is checked, this item will be included in the \'7. FREQUENCIES\' sectio" +
        "n of ICS-220 Air Ops Summary.");
            this.btnAirHelp.UseVisualStyleBackColor = false;
            this.btnAirHelp.Click += new System.EventHandler(this.btnAirHelp_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(19, 428);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 29);
            this.label12.TabIndex = 131;
            this.label12.Text = "Used for Air";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUsedForAir
            // 
            this.chkUsedForAir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUsedForAir.AutoSize = true;
            this.chkUsedForAir.Location = new System.Drawing.Point(169, 428);
            this.chkUsedForAir.Name = "chkUsedForAir";
            this.chkUsedForAir.Size = new System.Drawing.Size(289, 28);
            this.chkUsedForAir.TabIndex = 29;
            this.chkUsedForAir.Text = "Yes, this item is used for aircraft";
            this.chkUsedForAir.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(19, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 29);
            this.label8.TabIndex = 129;
            this.label8.Text = "Assignment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssignment
            // 
            this.txtAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssignment.Location = new System.Drawing.Point(169, 385);
            this.txtAssignment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(572, 29);
            this.txtAssignment.TabIndex = 28;
            // 
            // txtFunction
            // 
            this.txtFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunction.Location = new System.Drawing.Point(169, 346);
            this.txtFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(572, 29);
            this.txtFunction.TabIndex = 27;
            this.txtFunction.Leave += new System.EventHandler(this.txtFunction_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(19, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 127;
            this.label7.Text = "Function*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(301, 492);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveForLater.TabIndex = 30;
            this.chkSaveForLater.Text = "Save for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(334, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New  Communications Tool";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.Location = new System.Drawing.Point(539, 481);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 31;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // CommunicationsPlanEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            
            this.ClientSize = new System.Drawing.Size(769, 781);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommunicationsPlanEntryForm";
            this.Text = "Add a Communications Tool to the Incident";
            this.Load += new System.EventHandler(this.CommunicationsPlanEntryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlSavedComms.ResumeLayout(false);
            this.pnlSavedComms.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Panel pnlSavedComms;
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSavedComms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSavedAssignment;
        private System.Windows.Forms.TextBox txtSavedFunction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAssignment;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkUsedForAir;
        private System.Windows.Forms.Button btnAirHelp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSavedUsedForAir;
        private System.Windows.Forms.CheckBox chkSavedUsedForAir;
        private CustomControls.EditCommsChannelControl editCommsChannelControl1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}