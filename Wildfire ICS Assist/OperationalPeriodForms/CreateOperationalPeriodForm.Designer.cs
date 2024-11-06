namespace Wildfire_ICS_Assist.OperationalPeriodForms
{
    partial class CreateOperationalPeriodForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.numOpPeriod = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.datOpsStart = new System.Windows.Forms.DateTimePicker();
            this.datStartTime = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.datOpsEnd = new System.Windows.Forms.DateTimePicker();
            this.datEndTime = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCurrentOperationalPeriod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.clbItemsToCopy = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSwitchNow = new System.Windows.Forms.CheckBox();
            this.btnCreateOpPeriod = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkSwitchNow);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateOpPeriod);
            this.splitContainer1.Size = new System.Drawing.Size(813, 582);
            this.splitContainer1.SplitterDistance = 519;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cboCurrentOperationalPeriod);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.clbItemsToCopy);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Size = new System.Drawing.Size(813, 519);
            this.splitContainer2.SplitterDistance = 80;
            this.splitContainer2.TabIndex = 99;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(0, 37);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.numOpPeriod);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(813, 42);
            this.splitContainer3.SplitterDistance = 135;
            this.splitContainer3.TabIndex = 102;
            // 
            // numOpPeriod
            // 
            this.numOpPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numOpPeriod.Location = new System.Drawing.Point(45, 8);
            this.numOpPeriod.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.numOpPeriod.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numOpPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpPeriod.Name = "numOpPeriod";
            this.numOpPeriod.Size = new System.Drawing.Size(68, 29);
            this.numOpPeriod.TabIndex = 93;
            this.numOpPeriod.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numOpPeriod.ValueChanged += new System.EventHandler(this.numOpPeriod_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 24);
            this.label1.TabIndex = 98;
            this.label1.Text = "#";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.datOpsStart);
            this.splitContainer4.Panel1.Controls.Add(this.datStartTime);
            this.splitContainer4.Panel1.Controls.Add(this.label15);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.datOpsEnd);
            this.splitContainer4.Panel2.Controls.Add(this.datEndTime);
            this.splitContainer4.Panel2.Controls.Add(this.label18);
            this.splitContainer4.Size = new System.Drawing.Size(674, 42);
            this.splitContainer4.SplitterDistance = 336;
            this.splitContainer4.TabIndex = 0;
            // 
            // datOpsStart
            // 
            this.datOpsStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datOpsStart.CustomFormat = "yyyy-MMM-dd";
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsStart.Location = new System.Drawing.Point(70, 8);
            this.datOpsStart.Name = "datOpsStart";
            this.datOpsStart.Size = new System.Drawing.Size(155, 29);
            this.datOpsStart.TabIndex = 94;
            this.datOpsStart.ValueChanged += new System.EventHandler(this.datOpsStart_ValueChanged);
            // 
            // datStartTime
            // 
            this.datStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datStartTime.CustomFormat = "HH:mm";
            this.datStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datStartTime.Location = new System.Drawing.Point(231, 8);
            this.datStartTime.Name = "datStartTime";
            this.datStartTime.ShowUpDown = true;
            this.datStartTime.Size = new System.Drawing.Size(77, 29);
            this.datStartTime.TabIndex = 100;
            this.datStartTime.ValueChanged += new System.EventHandler(this.datStartTime_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(3, 10);
            this.label15.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 24);
            this.label15.TabIndex = 96;
            this.label15.Text = "From";
            // 
            // datOpsEnd
            // 
            this.datOpsEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datOpsEnd.CustomFormat = "yyyy-MMM-dd";
            this.datOpsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datOpsEnd.Location = new System.Drawing.Point(54, 8);
            this.datOpsEnd.Name = "datOpsEnd";
            this.datOpsEnd.Size = new System.Drawing.Size(164, 29);
            this.datOpsEnd.TabIndex = 95;
            this.datOpsEnd.ValueChanged += new System.EventHandler(this.datOpsEnd_ValueChanged);
            // 
            // datEndTime
            // 
            this.datEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.datEndTime.CustomFormat = "HH:mm";
            this.datEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datEndTime.Location = new System.Drawing.Point(224, 8);
            this.datEndTime.Name = "datEndTime";
            this.datEndTime.ShowUpDown = true;
            this.datEndTime.Size = new System.Drawing.Size(73, 29);
            this.datEndTime.TabIndex = 101;
            this.datEndTime.ValueChanged += new System.EventHandler(this.datEndTime_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(9, 10);
            this.label18.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 24);
            this.label18.TabIndex = 97;
            this.label18.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 29);
            this.label2.TabIndex = 99;
            this.label2.Text = "Create Operational Period";
            // 
            // cboCurrentOperationalPeriod
            // 
            this.cboCurrentOperationalPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCurrentOperationalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentOperationalPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.cboCurrentOperationalPeriod.FormattingEnabled = true;
            this.cboCurrentOperationalPeriod.Location = new System.Drawing.Point(370, 48);
            this.cboCurrentOperationalPeriod.Name = "cboCurrentOperationalPeriod";
            this.cboCurrentOperationalPeriod.Size = new System.Drawing.Size(430, 37);
            this.cboCurrentOperationalPeriod.TabIndex = 105;
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 34);
            this.label4.TabIndex = 104;
            this.label4.Text = "Transfer from this Operational Period:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clbItemsToCopy
            // 
            this.clbItemsToCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbItemsToCopy.FormattingEnabled = true;
            this.clbItemsToCopy.Location = new System.Drawing.Point(12, 91);
            this.clbItemsToCopy.Name = "clbItemsToCopy";
            this.clbItemsToCopy.Size = new System.Drawing.Size(788, 316);
            this.clbItemsToCopy.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(403, 24);
            this.label3.TabIndex = 102;
            this.label3.Text = "Copy data from another operational period";
            // 
            // chkSwitchNow
            // 
            this.chkSwitchNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSwitchNow.AutoSize = true;
            this.chkSwitchNow.Location = new System.Drawing.Point(359, 17);
            this.chkSwitchNow.Name = "chkSwitchNow";
            this.chkSwitchNow.Size = new System.Drawing.Size(210, 28);
            this.chkSwitchNow.TabIndex = 56;
            this.chkSwitchNow.Text = "Switch to this OP now";
            this.chkSwitchNow.UseVisualStyleBackColor = true;
            // 
            // btnCreateOpPeriod
            // 
            this.btnCreateOpPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOpPeriod.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnCreateOpPeriod.Location = new System.Drawing.Point(575, 5);
            this.btnCreateOpPeriod.Name = "btnCreateOpPeriod";
            this.btnCreateOpPeriod.Size = new System.Drawing.Size(226, 51);
            this.btnCreateOpPeriod.TabIndex = 55;
            this.btnCreateOpPeriod.Tag = "Save";
            this.btnCreateOpPeriod.Text = "Create Op Period";
            this.btnCreateOpPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateOpPeriod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateOpPeriod.UseVisualStyleBackColor = true;
            this.btnCreateOpPeriod.Click += new System.EventHandler(this.btnCreateOpPeriod_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // CreateOperationalPeriodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 582);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CreateOperationalPeriodForm";
            this.Text = "Create Operational Period";
            this.Load += new System.EventHandler(this.CreateOperationalPeriodForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOpPeriod)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker datOpsEnd;
        private System.Windows.Forms.DateTimePicker datOpsStart;
        private System.Windows.Forms.NumericUpDown numOpPeriod;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datStartTime;
        private System.Windows.Forms.DateTimePicker datEndTime;
        private System.Windows.Forms.CheckedListBox clbItemsToCopy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnCreateOpPeriod;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCurrentOperationalPeriod;
        private System.Windows.Forms.CheckBox chkSwitchNow;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}