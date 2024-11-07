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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrepAndApprovePanel));
            this.datPrepDate = new System.Windows.Forms.DateTimePicker();
            this.datPrepTime = new System.Windows.Forms.DateTimePicker();
            this.datApproveTime = new System.Windows.Forms.DateTimePicker();
            this.datApproveDate = new System.Windows.Forms.DateTimePicker();
            this.cboPrepBy = new System.Windows.Forms.ComboBox();
            this.cboApproveBy = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExpandCollapse = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datPrepDate
            // 
            this.datPrepDate.CustomFormat = "yyyy-MMM-dd";
            this.datPrepDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datPrepDate.Location = new System.Drawing.Point(5, 31);
            this.datPrepDate.Margin = new System.Windows.Forms.Padding(6);
            this.datPrepDate.Name = "datPrepDate";
            this.datPrepDate.Size = new System.Drawing.Size(154, 29);
            this.datPrepDate.TabIndex = 0;
            this.datPrepDate.ValueChanged += new System.EventHandler(this.datPrepDate_ValueChanged);
            // 
            // datPrepTime
            // 
            this.datPrepTime.CustomFormat = "HH:mm";
            this.datPrepTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datPrepTime.Location = new System.Drawing.Point(171, 31);
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
            this.datApproveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datApproveTime.Location = new System.Drawing.Point(171, 32);
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
            this.datApproveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datApproveDate.Location = new System.Drawing.Point(6, 32);
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
            this.cboPrepBy.FormattingEnabled = true;
            this.cboPrepBy.Location = new System.Drawing.Point(276, 29);
            this.cboPrepBy.Margin = new System.Windows.Forms.Padding(6);
            this.cboPrepBy.Name = "cboPrepBy";
            this.cboPrepBy.Size = new System.Drawing.Size(326, 32);
            this.cboPrepBy.TabIndex = 4;
            this.cboPrepBy.SelectedIndexChanged += new System.EventHandler(this.cboPrepBy_SelectedIndexChanged);
            this.cboPrepBy.Leave += new System.EventHandler(this.cboPrepBy_Leave);
            // 
            // cboApproveBy
            // 
            this.cboApproveBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboApproveBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApproveBy.FormattingEnabled = true;
            this.cboApproveBy.Location = new System.Drawing.Point(276, 30);
            this.cboApproveBy.Margin = new System.Windows.Forms.Padding(6);
            this.cboApproveBy.Name = "cboApproveBy";
            this.cboApproveBy.Size = new System.Drawing.Size(326, 32);
            this.cboApproveBy.TabIndex = 5;
            this.cboApproveBy.SelectedIndexChanged += new System.EventHandler(this.cboApproveBy_SelectedIndexChanged);
            this.cboApproveBy.Leave += new System.EventHandler(this.cboApproveBy_Leave);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cboPrepBy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.datPrepDate);
            this.panel1.Controls.Add(this.datPrepTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 54);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 68);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prepared";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.chkApproved);
            this.panel2.Controls.Add(this.cboApproveBy);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.datApproveTime);
            this.panel2.Controls.Add(this.datApproveDate);
            this.panel2.Location = new System.Drawing.Point(6, 127);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 70);
            this.panel2.TabIndex = 0;
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Location = new System.Drawing.Point(5, 0);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(112, 28);
            this.chkApproved.TabIndex = 7;
            this.chkApproved.Text = "Approved";
            this.chkApproved.UseVisualStyleBackColor = true;
            this.chkApproved.CheckedChanged += new System.EventHandler(this.chkApproved_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "By";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(39, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(581, 42);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "Prepared and Approved Info";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandCollapse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandCollapse.BackgroundImage")));
            this.btnExpandCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpandCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpandCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExpandCollapse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExpandCollapse.Location = new System.Drawing.Point(6, 5);
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            this.btnExpandCollapse.Size = new System.Drawing.Size(30, 30);
            this.btnExpandCollapse.TabIndex = 33;
            this.btnExpandCollapse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandCollapse.UseVisualStyleBackColor = false;
            this.btnExpandCollapse.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // PrepAndApprovePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExpandCollapse);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PrepAndApprovePanel";
            this.Size = new System.Drawing.Size(619, 197);
            this.Load += new System.EventHandler(this.PrepAndApprovePanel_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datPrepDate;
        private System.Windows.Forms.DateTimePicker datPrepTime;
        private System.Windows.Forms.DateTimePicker datApproveTime;
        private System.Windows.Forms.DateTimePicker datApproveDate;
        private System.Windows.Forms.ComboBox cboPrepBy;
        private System.Windows.Forms.ComboBox cboApproveBy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExpandCollapse;
        private System.Windows.Forms.CheckBox chkApproved;
    }
}
