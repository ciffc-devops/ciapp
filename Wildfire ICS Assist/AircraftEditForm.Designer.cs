namespace Wildfire_ICS_Assist
{
    partial class AircraftEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AircraftEditForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editAircraftControl1 = new Wildfire_ICS_Assist.CustomControls.EditAircraftControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMedivacHelpNew = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkNewIsMedivac = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datNewEnd = new System.Windows.Forms.DateTimePicker();
            this.datNewStart = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNewPilot = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnMedivacHelpNew);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.chkNewIsMedivac);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.datNewEnd);
            this.splitContainer1.Panel1.Controls.Add(this.datNewStart);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.txtNewPilot);
            this.splitContainer1.Panel1.Controls.Add(this.editAircraftControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(669, 459);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 3;
            // 
            // editAircraftControl1
            // 
            this.editAircraftControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editAircraftControl1.BackColor = System.Drawing.Color.Transparent;
            this.editAircraftControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editAircraftControl1.Location = new System.Drawing.Point(0, 0);
            this.editAircraftControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editAircraftControl1.Name = "editAircraftControl1";
            this.editAircraftControl1.selectedAircraft = null;
            this.editAircraftControl1.Size = new System.Drawing.Size(663, 274);
            this.editAircraftControl1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(532, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 51);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMedivacHelpNew
            // 
            this.btnMedivacHelpNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMedivacHelpNew.BackColor = System.Drawing.Color.White;
            this.btnMedivacHelpNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMedivacHelpNew.BackgroundImage")));
            this.btnMedivacHelpNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMedivacHelpNew.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnMedivacHelpNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedivacHelpNew.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMedivacHelpNew.Location = new System.Drawing.Point(476, 348);
            this.btnMedivacHelpNew.Name = "btnMedivacHelpNew";
            this.btnMedivacHelpNew.Size = new System.Drawing.Size(25, 25);
            this.btnMedivacHelpNew.TabIndex = 124;
            this.btnMedivacHelpNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMedivacHelpNew.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(1, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 26);
            this.label7.TabIndex = 123;
            this.label7.Text = "Medivac";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkNewIsMedivac
            // 
            this.chkNewIsMedivac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNewIsMedivac.AutoSize = true;
            this.chkNewIsMedivac.Location = new System.Drawing.Point(164, 348);
            this.chkNewIsMedivac.Name = "chkNewIsMedivac";
            this.chkNewIsMedivac.Size = new System.Drawing.Size(306, 28);
            this.chkNewIsMedivac.TabIndex = 119;
            this.chkNewIsMedivac.Text = "Yes, this will be used for medivac";
            this.chkNewIsMedivac.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(375, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 26);
            this.label3.TabIndex = 122;
            this.label3.Text = "End";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(-4, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 26);
            this.label2.TabIndex = 121;
            this.label2.Text = "Start";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datNewEnd
            // 
            this.datNewEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.datNewEnd.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datNewEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datNewEnd.Location = new System.Drawing.Point(436, 313);
            this.datNewEnd.Name = "datNewEnd";
            this.datNewEnd.Size = new System.Drawing.Size(221, 29);
            this.datNewEnd.TabIndex = 118;
            // 
            // datNewStart
            // 
            this.datNewStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datNewStart.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datNewStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datNewStart.Location = new System.Drawing.Point(164, 313);
            this.datNewStart.Name = "datNewStart";
            this.datNewStart.Size = new System.Drawing.Size(200, 29);
            this.datNewStart.TabIndex = 117;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(-4, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 26);
            this.label12.TabIndex = 120;
            this.label12.Text = "Pilot";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNewPilot
            // 
            this.txtNewPilot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewPilot.Location = new System.Drawing.Point(164, 278);
            this.txtNewPilot.Name = "txtNewPilot";
            this.txtNewPilot.Size = new System.Drawing.Size(493, 29);
            this.txtNewPilot.TabIndex = 116;
            // 
            // AircraftEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 459);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(685, 498);
            this.Name = "AircraftEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Aircraft";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomControls.EditAircraftControl editAircraftControl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMedivacHelpNew;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkNewIsMedivac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datNewEnd;
        private System.Windows.Forms.DateTimePicker datNewStart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNewPilot;
    }
}