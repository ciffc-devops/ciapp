namespace Wildfire_ICS_Assist
{
    partial class CheckInInfoEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.datCheckInToday = new System.Windows.Forms.DateTimePicker();
            this.lblCheckInInfoTitle = new System.Windows.Forms.Label();
            this.chkCheckInToday = new System.Windows.Forms.CheckBox();
            this.btnDoneCrewEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.resourceCheckInEditControl1 = new Wildfire_ICS_Assist.CustomControls.ResourceCheckInEditControl();
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
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDoneCrewEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(742, 505);
            this.splitContainer1.SplitterDistance = 434;
            this.splitContainer1.TabIndex = 145;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.datCheckInToday);
            this.splitContainer2.Panel1.Controls.Add(this.lblCheckInInfoTitle);
            this.splitContainer2.Panel1.Controls.Add(this.chkCheckInToday);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.resourceCheckInEditControl1);
            this.splitContainer2.Size = new System.Drawing.Size(742, 434);
            this.splitContainer2.SplitterDistance = 106;
            this.splitContainer2.TabIndex = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 29);
            this.label1.TabIndex = 143;
            this.label1.Text = "Today\'s Check-In";
            // 
            // datCheckInToday
            // 
            this.datCheckInToday.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckInToday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInToday.Location = new System.Drawing.Point(207, 32);
            this.datCheckInToday.Name = "datCheckInToday";
            this.datCheckInToday.Size = new System.Drawing.Size(239, 29);
            this.datCheckInToday.TabIndex = 140;
            this.datCheckInToday.ValueChanged += new System.EventHandler(this.datCheckInToday_ValueChanged);
            // 
            // lblCheckInInfoTitle
            // 
            this.lblCheckInInfoTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCheckInInfoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInInfoTitle.Location = new System.Drawing.Point(3, 73);
            this.lblCheckInInfoTitle.Name = "lblCheckInInfoTitle";
            this.lblCheckInInfoTitle.Size = new System.Drawing.Size(448, 29);
            this.lblCheckInInfoTitle.TabIndex = 139;
            this.lblCheckInInfoTitle.Text = "Check-In Information";
            // 
            // chkCheckInToday
            // 
            this.chkCheckInToday.AutoSize = true;
            this.chkCheckInToday.Checked = true;
            this.chkCheckInToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCheckInToday.Location = new System.Drawing.Point(39, 32);
            this.chkCheckInToday.Name = "chkCheckInToday";
            this.chkCheckInToday.Size = new System.Drawing.Size(162, 28);
            this.chkCheckInToday.TabIndex = 142;
            this.chkCheckInToday.Text = "Check-In Today";
            this.chkCheckInToday.UseVisualStyleBackColor = true;
            // 
            // btnDoneCrewEdit
            // 
            this.btnDoneCrewEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoneCrewEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnDoneCrewEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoneCrewEdit.Location = new System.Drawing.Point(606, 6);
            this.btnDoneCrewEdit.Name = "btnDoneCrewEdit";
            this.btnDoneCrewEdit.Size = new System.Drawing.Size(124, 51);
            this.btnDoneCrewEdit.TabIndex = 22;
            this.btnDoneCrewEdit.Text = "Save";
            this.btnDoneCrewEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoneCrewEdit.UseVisualStyleBackColor = true;
            this.btnDoneCrewEdit.Click += new System.EventHandler(this.btnDoneCrewEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(15, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // resourceCheckInEditControl1
            // 
            this.resourceCheckInEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceCheckInEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resourceCheckInEditControl1.Location = new System.Drawing.Point(0, 0);
            this.resourceCheckInEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.resourceCheckInEditControl1.MinimumSize = new System.Drawing.Size(716, 300);
            this.resourceCheckInEditControl1.Name = "resourceCheckInEditControl1";
            this.resourceCheckInEditControl1.Size = new System.Drawing.Size(742, 324);
            this.resourceCheckInEditControl1.TabIndex = 0;
            // 
            // CheckInInfoEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 505);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CheckInInfoEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Check-In Information";
            this.Load += new System.EventHandler(this.CheckInInfoEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datCheckInToday;
        private System.Windows.Forms.Label lblCheckInInfoTitle;
        private System.Windows.Forms.CheckBox chkCheckInToday;
        private System.Windows.Forms.Button btnDoneCrewEdit;
        private System.Windows.Forms.Button btnCancel;
        private CustomControls.ResourceCheckInEditControl resourceCheckInEditControl1;
    }
}