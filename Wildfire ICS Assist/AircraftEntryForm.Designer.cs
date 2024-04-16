namespace Wildfire_ICS_Assist
{
    partial class AircraftEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AircraftEntryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMedivacHelpSaved = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.chkSavedIsMedivac = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.datSavedEnd = new System.Windows.Forms.DateTimePicker();
            this.datSavedStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSavedPilot = new System.Windows.Forms.TextBox();
            this.btnAddSaved = new System.Windows.Forms.Button();
            this.cboSaved = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMedivacHelpNew = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkNewIsMedivac = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datNewEnd = new System.Windows.Forms.DateTimePicker();
            this.datNewStart = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNewPilot = new System.Windows.Forms.TextBox();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.editAircraftControl1 = new Wildfire_ICS_Assist.CustomControls.EditAircraftControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(859, 811);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMedivacHelpSaved);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.chkSavedIsMedivac);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.datSavedEnd);
            this.panel1.Controls.Add(this.datSavedStart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSavedPilot);
            this.panel1.Controls.Add(this.btnAddSaved);
            this.panel1.Controls.Add(this.cboSaved);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 183);
            this.panel1.TabIndex = 1;
            // 
            // btnMedivacHelpSaved
            // 
            this.btnMedivacHelpSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMedivacHelpSaved.BackColor = System.Drawing.Color.White;
            this.btnMedivacHelpSaved.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMedivacHelpSaved.BackgroundImage")));
            this.btnMedivacHelpSaved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMedivacHelpSaved.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnMedivacHelpSaved.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMedivacHelpSaved.Location = new System.Drawing.Point(409, 147);
            this.btnMedivacHelpSaved.Name = "btnMedivacHelpSaved";
            this.btnMedivacHelpSaved.Size = new System.Drawing.Size(25, 25);
            this.btnMedivacHelpSaved.TabIndex = 122;
            this.btnMedivacHelpSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnMedivacHelpSaved, "If checked, this aircraft\'s information will be summarized in the Medivac field (" +
        "4) on the Air Operations Summary form.");
            this.btnMedivacHelpSaved.UseVisualStyleBackColor = false;
            this.btnMedivacHelpSaved.Click += new System.EventHandler(this.btnMedivacHelpNew_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 26);
            this.label8.TabIndex = 121;
            this.label8.Text = "Medivac";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSavedIsMedivac
            // 
            this.chkSavedIsMedivac.AutoSize = true;
            this.chkSavedIsMedivac.Location = new System.Drawing.Point(97, 147);
            this.chkSavedIsMedivac.Name = "chkSavedIsMedivac";
            this.chkSavedIsMedivac.Size = new System.Drawing.Size(306, 28);
            this.chkSavedIsMedivac.TabIndex = 5;
            this.chkSavedIsMedivac.Text = "Yes, this will be used for medivac";
            this.chkSavedIsMedivac.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(361, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 26);
            this.label4.TabIndex = 119;
            this.label4.Text = "End";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 26);
            this.label5.TabIndex = 118;
            this.label5.Text = "Start";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datSavedEnd
            // 
            this.datSavedEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datSavedEnd.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datSavedEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSavedEnd.Location = new System.Drawing.Point(422, 112);
            this.datSavedEnd.Name = "datSavedEnd";
            this.datSavedEnd.Size = new System.Drawing.Size(279, 29);
            this.datSavedEnd.TabIndex = 4;
            // 
            // datSavedStart
            // 
            this.datSavedStart.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datSavedStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datSavedStart.Location = new System.Drawing.Point(97, 112);
            this.datSavedStart.Name = "datSavedStart";
            this.datSavedStart.Size = new System.Drawing.Size(258, 29);
            this.datSavedStart.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 26);
            this.label6.TabIndex = 115;
            this.label6.Text = "Pilot";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSavedPilot
            // 
            this.txtSavedPilot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSavedPilot.Location = new System.Drawing.Point(97, 74);
            this.txtSavedPilot.Name = "txtSavedPilot";
            this.txtSavedPilot.Size = new System.Drawing.Size(604, 29);
            this.txtSavedPilot.TabIndex = 2;
            // 
            // btnAddSaved
            // 
            this.btnAddSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddSaved.Location = new System.Drawing.Point(710, 26);
            this.btnAddSaved.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddSaved.Name = "btnAddSaved";
            this.btnAddSaved.Size = new System.Drawing.Size(123, 80);
            this.btnAddSaved.TabIndex = 6;
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
            this.cboSaved.DisplayMember = "name";
            this.cboSaved.FormattingEnabled = true;
            this.cboSaved.Location = new System.Drawing.Point(8, 36);
            this.cboSaved.Name = "cboSaved";
            this.cboSaved.Size = new System.Drawing.Size(693, 32);
            this.cboSaved.TabIndex = 1;
            this.cboSaved.ValueMember = "HospitalID";
            this.cboSaved.Leave += new System.EventHandler(this.cboSaved_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Aircraft";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 554);
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
            this.panel2.Controls.Add(this.btnMedivacHelpNew);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.chkNewIsMedivac);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.datNewEnd);
            this.panel2.Controls.Add(this.datNewStart);
            this.panel2.Controls.Add(this.editAircraftControl1);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtNewPilot);
            this.panel2.Controls.Add(this.chkSaveForLater);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Location = new System.Drawing.Point(6, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 542);
            this.panel2.TabIndex = 98;
            // 
            // btnMedivacHelpNew
            // 
            this.btnMedivacHelpNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMedivacHelpNew.BackColor = System.Drawing.Color.White;
            this.btnMedivacHelpNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMedivacHelpNew.BackgroundImage")));
            this.btnMedivacHelpNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMedivacHelpNew.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnMedivacHelpNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMedivacHelpNew.Location = new System.Drawing.Point(480, 444);
            this.btnMedivacHelpNew.Name = "btnMedivacHelpNew";
            this.btnMedivacHelpNew.Size = new System.Drawing.Size(25, 25);
            this.btnMedivacHelpNew.TabIndex = 115;
            this.btnMedivacHelpNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnMedivacHelpNew, "If checked, this aircraft\'s information will be summarized in the Medivac field (" +
        "4) on the Air Operations Summary form.");
            this.btnMedivacHelpNew.UseVisualStyleBackColor = false;
            this.btnMedivacHelpNew.Click += new System.EventHandler(this.btnMedivacHelpNew_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(5, 444);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 26);
            this.label7.TabIndex = 114;
            this.label7.Text = "Medivac";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNewIsMedivac
            // 
            this.chkNewIsMedivac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNewIsMedivac.AutoSize = true;
            this.chkNewIsMedivac.Location = new System.Drawing.Point(168, 444);
            this.chkNewIsMedivac.Name = "chkNewIsMedivac";
            this.chkNewIsMedivac.Size = new System.Drawing.Size(306, 28);
            this.chkNewIsMedivac.TabIndex = 31;
            this.chkNewIsMedivac.Text = "Yes, this will be used for medivac";
            this.chkNewIsMedivac.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(450, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 26);
            this.label3.TabIndex = 113;
            this.label3.Text = "End";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(0, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 26);
            this.label2.TabIndex = 112;
            this.label2.Text = "Start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datNewEnd
            // 
            this.datNewEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datNewEnd.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datNewEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datNewEnd.Location = new System.Drawing.Point(511, 409);
            this.datNewEnd.Name = "datNewEnd";
            this.datNewEnd.Size = new System.Drawing.Size(313, 29);
            this.datNewEnd.TabIndex = 30;
            // 
            // datNewStart
            // 
            this.datNewStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datNewStart.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datNewStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datNewStart.Location = new System.Drawing.Point(168, 409);
            this.datNewStart.Name = "datNewStart";
            this.datNewStart.Size = new System.Drawing.Size(266, 29);
            this.datNewStart.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(0, 376);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 26);
            this.label12.TabIndex = 107;
            this.label12.Text = "Pilot";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPilot
            // 
            this.txtNewPilot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPilot.Location = new System.Drawing.Point(168, 374);
            this.txtNewPilot.Name = "txtNewPilot";
            this.txtNewPilot.Size = new System.Drawing.Size(656, 29);
            this.txtNewPilot.TabIndex = 28;
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(391, 497);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveForLater.TabIndex = 32;
            this.chkSaveForLater.Text = "Save for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 29);
            this.label10.TabIndex = 99;
            this.label10.Text = "New Aircraft";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.Location = new System.Drawing.Point(629, 486);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 33;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // editAircraftControl1
            // 
            this.editAircraftControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editAircraftControl1.BackColor = System.Drawing.Color.Transparent;
            this.editAircraftControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAircraftControl1.Location = new System.Drawing.Point(6, 43);
            this.editAircraftControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editAircraftControl1.Name = "editAircraftControl1";
            this.editAircraftControl1.selectedAircraft = null;
            this.editAircraftControl1.Size = new System.Drawing.Size(824, 322);
            this.editAircraftControl1.TabIndex = 27;
            // 
            // AircraftEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 811);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(875, 675);
            this.Name = "AircraftEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add an Aircraft";
            this.Load += new System.EventHandler(this.AircraftEntryForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddSaved;
        private System.Windows.Forms.ComboBox cboSaved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.EditAircraftControl editAircraftControl1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNewPilot;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker datSavedEnd;
        private System.Windows.Forms.DateTimePicker datSavedStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSavedPilot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datNewEnd;
        private System.Windows.Forms.DateTimePicker datNewStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkNewIsMedivac;
        private System.Windows.Forms.Button btnMedivacHelpSaved;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkSavedIsMedivac;
        private System.Windows.Forms.Button btnMedivacHelpNew;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}