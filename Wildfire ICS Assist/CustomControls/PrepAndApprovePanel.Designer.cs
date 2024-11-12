namespace Wildfire_ICS_Assist.CustomControls
{
    partial class PrepAndApprovePanel
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
            this.datPrepDate = new System.Windows.Forms.DateTimePicker();
            this.datPrepTime = new System.Windows.Forms.DateTimePicker();
            this.datApproveTime = new System.Windows.Forms.DateTimePicker();
            this.datApproveDate = new System.Windows.Forms.DateTimePicker();
            this.cboPrepBy = new System.Windows.Forms.ComboBox();
            this.cboApproveBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datPrepDate
            // 
            this.datPrepDate.CustomFormat = "yyyy-MMM-dd";
            this.datPrepDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datPrepDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datPrepDate.Location = new System.Drawing.Point(130, 6);
            this.datPrepDate.Margin = new System.Windows.Forms.Padding(6);
            this.datPrepDate.Name = "datPrepDate";
            this.datPrepDate.Size = new System.Drawing.Size(154, 29);
            this.datPrepDate.TabIndex = 0;
            this.datPrepDate.ValueChanged += new System.EventHandler(this.datPrepDate_ValueChanged);
            // 
            // datPrepTime
            // 
            this.datPrepTime.CustomFormat = "HH:mm";
            this.datPrepTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datPrepTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datPrepTime.Location = new System.Drawing.Point(296, 6);
            this.datPrepTime.Margin = new System.Windows.Forms.Padding(6);
            this.datPrepTime.Name = "datPrepTime";
            this.datPrepTime.ShowUpDown = true;
            this.datPrepTime.Size = new System.Drawing.Size(72, 29);
            this.datPrepTime.TabIndex = 1;
            this.datPrepTime.ValueChanged += new System.EventHandler(this.datPrepTime_ValueChanged);
            // 
            // datApproveTime
            // 
            this.datApproveTime.CustomFormat = "HH:mm";
            this.datApproveTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datApproveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datApproveTime.Location = new System.Drawing.Point(295, 94);
            this.datApproveTime.Margin = new System.Windows.Forms.Padding(6);
            this.datApproveTime.Name = "datApproveTime";
            this.datApproveTime.ShowUpDown = true;
            this.datApproveTime.Size = new System.Drawing.Size(72, 29);
            this.datApproveTime.TabIndex = 3;
            this.datApproveTime.ValueChanged += new System.EventHandler(this.datApproveTime_ValueChanged);
            // 
            // datApproveDate
            // 
            this.datApproveDate.CustomFormat = "yyyy-MMM-dd";
            this.datApproveDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.datApproveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datApproveDate.Location = new System.Drawing.Point(130, 94);
            this.datApproveDate.Margin = new System.Windows.Forms.Padding(6);
            this.datApproveDate.Name = "datApproveDate";
            this.datApproveDate.Size = new System.Drawing.Size(153, 29);
            this.datApproveDate.TabIndex = 2;
            this.datApproveDate.ValueChanged += new System.EventHandler(this.datApproveDate_ValueChanged);
            // 
            // cboPrepBy
            // 
            this.cboPrepBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPrepBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.SetFlowBreak(this.cboPrepBy, true);
            this.cboPrepBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboPrepBy.FormattingEnabled = true;
            this.cboPrepBy.Location = new System.Drawing.Point(6, 50);
            this.cboPrepBy.Margin = new System.Windows.Forms.Padding(6);
            this.cboPrepBy.Name = "cboPrepBy";
            this.cboPrepBy.Size = new System.Drawing.Size(289, 32);
            this.cboPrepBy.TabIndex = 4;
            this.cboPrepBy.SelectedIndexChanged += new System.EventHandler(this.cboPrepBy_SelectedIndexChanged);
            this.cboPrepBy.Leave += new System.EventHandler(this.cboPrepBy_Leave);
            // 
            // cboApproveBy
            // 
            this.cboApproveBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApproveBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApproveBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboApproveBy.FormattingEnabled = true;
            this.cboApproveBy.Location = new System.Drawing.Point(6, 138);
            this.cboApproveBy.Margin = new System.Windows.Forms.Padding(6);
            this.cboApproveBy.Name = "cboApproveBy";
            this.cboApproveBy.Size = new System.Drawing.Size(290, 32);
            this.cboApproveBy.TabIndex = 5;
            this.cboApproveBy.SelectedIndexChanged += new System.EventHandler(this.cboApproveBy_SelectedIndexChanged);
            this.cboApproveBy.Leave += new System.EventHandler(this.cboApproveBy_Leave);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(380, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "By";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prepared";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkApproved
            // 
            this.chkApproved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.chkApproved.Location = new System.Drawing.Point(6, 94);
            this.chkApproved.Margin = new System.Windows.Forms.Padding(6);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(112, 32);
            this.chkApproved.TabIndex = 7;
            this.chkApproved.Text = "Approved";
            this.chkApproved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApproved.UseVisualStyleBackColor = true;
            this.chkApproved.CheckedChanged += new System.EventHandler(this.chkApproved_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.datPrepDate);
            this.flowLayoutPanel1.Controls.Add(this.datPrepTime);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cboPrepBy);
            this.flowLayoutPanel1.Controls.Add(this.chkApproved);
            this.flowLayoutPanel1.Controls.Add(this.datApproveDate);
            this.flowLayoutPanel1.Controls.Add(this.datApproveTime);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cboApproveBy);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 44);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(474, 176);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(379, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrepAndApprovePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PrepAndApprovePanel";
            this.Size = new System.Drawing.Size(483, 202);
            this.SizeWhenExpanded = new System.Drawing.Size(485, 204);
            this.Load += new System.EventHandler(this.PrepAndApprovePanel_Load);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datPrepDate;
        private System.Windows.Forms.DateTimePicker datPrepTime;
        private System.Windows.Forms.DateTimePicker datApproveTime;
        private System.Windows.Forms.DateTimePicker datApproveDate;
        private System.Windows.Forms.ComboBox cboPrepBy;
        private System.Windows.Forms.ComboBox cboApproveBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkApproved;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
    }
}
