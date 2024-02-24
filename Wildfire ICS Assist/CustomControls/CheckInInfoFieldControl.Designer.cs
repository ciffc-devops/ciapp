namespace Wildfire_ICS_Assist.CustomControls
{
    partial class CheckInInfoFieldControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInInfoFieldControl));
            this.datDateValue = new System.Windows.Forms.DateTimePicker();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.txtStringValue = new System.Windows.Forms.TextBox();
            this.chkBoolValue = new System.Windows.Forms.CheckBox();
            this.cboListValue = new System.Windows.Forms.ComboBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numNumberValue = new System.Windows.Forms.NumericUpDown();
            this.pnlWeight = new System.Windows.Forms.Panel();
            this.rbLBS = new System.Windows.Forms.RadioButton();
            this.rbKG = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numNumberValue)).BeginInit();
            this.pnlWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // datDateValue
            // 
            this.datDateValue.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datDateValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datDateValue.Location = new System.Drawing.Point(267, 5);
            this.datDateValue.Name = "datDateValue";
            this.datDateValue.Size = new System.Drawing.Size(109, 29);
            this.datDateValue.TabIndex = 20;
            this.datDateValue.ValueChanged += new System.EventHandler(this.datDateValue_ValueChanged);
            // 
            // lblFieldName
            // 
            this.lblFieldName.Location = new System.Drawing.Point(4, 5);
            this.lblFieldName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(254, 29);
            this.lblFieldName.TabIndex = 21;
            this.lblFieldName.Text = "Check-In at Incident*";
            this.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStringValue
            // 
            this.txtStringValue.Location = new System.Drawing.Point(492, 6);
            this.txtStringValue.Name = "txtStringValue";
            this.txtStringValue.Size = new System.Drawing.Size(100, 29);
            this.txtStringValue.TabIndex = 22;
            this.txtStringValue.TextChanged += new System.EventHandler(this.txtStringValue_TextChanged);
            // 
            // chkBoolValue
            // 
            this.chkBoolValue.AutoSize = true;
            this.chkBoolValue.Location = new System.Drawing.Point(425, 5);
            this.chkBoolValue.Name = "chkBoolValue";
            this.chkBoolValue.Size = new System.Drawing.Size(61, 28);
            this.chkBoolValue.TabIndex = 23;
            this.chkBoolValue.Text = "Yes";
            this.chkBoolValue.UseVisualStyleBackColor = true;
            this.chkBoolValue.CheckedChanged += new System.EventHandler(this.chkBoolValue_CheckedChanged);
            // 
            // cboListValue
            // 
            this.cboListValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboListValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboListValue.FormattingEnabled = true;
            this.cboListValue.Location = new System.Drawing.Point(554, 3);
            this.cboListValue.Name = "cboListValue";
            this.cboListValue.Size = new System.Drawing.Size(121, 32);
            this.cboListValue.TabIndex = 24;
            this.cboListValue.Leave += new System.EventHandler(this.cboListValue_Leave);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHelp.BackgroundImage")));
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnHelp.Location = new System.Drawing.Point(1306, 6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(26, 26);
            this.btnHelp.TabIndex = 140;
            this.btnHelp.TabStop = false;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // numNumberValue
            // 
            this.numNumberValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numNumberValue.Location = new System.Drawing.Point(700, 5);
            this.numNumberValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numNumberValue.Name = "numNumberValue";
            this.numNumberValue.Size = new System.Drawing.Size(469, 29);
            this.numNumberValue.TabIndex = 141;
            this.numNumberValue.ValueChanged += new System.EventHandler(this.numNumberValue_ValueChanged);
            // 
            // pnlWeight
            // 
            this.pnlWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeight.Controls.Add(this.rbLBS);
            this.pnlWeight.Controls.Add(this.rbKG);
            this.pnlWeight.Location = new System.Drawing.Point(1175, 0);
            this.pnlWeight.Name = "pnlWeight";
            this.pnlWeight.Size = new System.Drawing.Size(125, 40);
            this.pnlWeight.TabIndex = 142;
            // 
            // rbLBS
            // 
            this.rbLBS.AutoSize = true;
            this.rbLBS.Location = new System.Drawing.Point(65, 5);
            this.rbLBS.Name = "rbLBS";
            this.rbLBS.Size = new System.Drawing.Size(58, 28);
            this.rbLBS.TabIndex = 1;
            this.rbLBS.Text = "Lbs";
            this.rbLBS.UseVisualStyleBackColor = true;
            this.rbLBS.CheckedChanged += new System.EventHandler(this.rbLBS_CheckedChanged);
            // 
            // rbKG
            // 
            this.rbKG.AutoSize = true;
            this.rbKG.Checked = true;
            this.rbKG.Location = new System.Drawing.Point(8, 6);
            this.rbKG.Name = "rbKG";
            this.rbKG.Size = new System.Drawing.Size(51, 28);
            this.rbKG.TabIndex = 0;
            this.rbKG.TabStop = true;
            this.rbKG.Text = "Kg";
            this.rbKG.UseVisualStyleBackColor = true;
            this.rbKG.CheckedChanged += new System.EventHandler(this.rbKG_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // CheckInInfoFieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWeight);
            this.Controls.Add(this.numNumberValue);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.cboListValue);
            this.Controls.Add(this.chkBoolValue);
            this.Controls.Add(this.txtStringValue);
            this.Controls.Add(this.datDateValue);
            this.Controls.Add(this.lblFieldName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CheckInInfoFieldControl";
            this.Size = new System.Drawing.Size(1335, 40);
            this.Load += new System.EventHandler(this.CheckInInfoFieldControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNumberValue)).EndInit();
            this.pnlWeight.ResumeLayout(false);
            this.pnlWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datDateValue;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.TextBox txtStringValue;
        private System.Windows.Forms.CheckBox chkBoolValue;
        private System.Windows.Forms.ComboBox cboListValue;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numNumberValue;
        private System.Windows.Forms.Panel pnlWeight;
        private System.Windows.Forms.RadioButton rbLBS;
        private System.Windows.Forms.RadioButton rbKG;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
