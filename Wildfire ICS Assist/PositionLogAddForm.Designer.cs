namespace Wildfire_ICS_Assist
{
    partial class PositionLogAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionLogAddForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTrackProgress = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.datReminderTime = new System.Windows.Forms.DateTimePicker();
            this.datDueDate = new System.Windows.Forms.DateTimePicker();
            this.chkComplete = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTrackProgress = new System.Windows.Forms.RadioButton();
            this.rbInfoOnly = new System.Windows.Forms.RadioButton();
            this.datDateCreated = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntryText = new System.Windows.Forms.TextBox();
            this.lblEntryText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTrackProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlTrackProgress
            // 
            resources.ApplyResources(this.pnlTrackProgress, "pnlTrackProgress");
            this.pnlTrackProgress.BackColor = System.Drawing.Color.White;
            this.pnlTrackProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrackProgress.Controls.Add(this.label3);
            this.pnlTrackProgress.Controls.Add(this.chkReminder);
            this.pnlTrackProgress.Controls.Add(this.datReminderTime);
            this.pnlTrackProgress.Controls.Add(this.datDueDate);
            this.pnlTrackProgress.Controls.Add(this.chkComplete);
            this.pnlTrackProgress.Name = "pnlTrackProgress";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // chkReminder
            // 
            resources.ApplyResources(this.chkReminder, "chkReminder");
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.UseVisualStyleBackColor = true;
            this.chkReminder.CheckedChanged += new System.EventHandler(this.chkReminder_CheckedChanged);
            // 
            // datReminderTime
            // 
            resources.ApplyResources(this.datReminderTime, "datReminderTime");
            this.datReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datReminderTime.Name = "datReminderTime";
            this.datReminderTime.ValueChanged += new System.EventHandler(this.datReminderTime_ValueChanged);
            // 
            // datDueDate
            // 
            resources.ApplyResources(this.datDueDate, "datDueDate");
            this.datDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datDueDate.Name = "datDueDate";
            this.datDueDate.ValueChanged += new System.EventHandler(this.datDueDate_ValueChanged);
            // 
            // chkComplete
            // 
            resources.ApplyResources(this.chkComplete, "chkComplete");
            this.chkComplete.Name = "chkComplete";
            this.chkComplete.UseVisualStyleBackColor = true;
            this.chkComplete.CheckedChanged += new System.EventHandler(this.chkComplete_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // rbTrackProgress
            // 
            resources.ApplyResources(this.rbTrackProgress, "rbTrackProgress");
            this.rbTrackProgress.Name = "rbTrackProgress";
            this.rbTrackProgress.UseVisualStyleBackColor = true;
            this.rbTrackProgress.CheckedChanged += new System.EventHandler(this.rbTrackProgress_CheckedChanged);
            // 
            // rbInfoOnly
            // 
            resources.ApplyResources(this.rbInfoOnly, "rbInfoOnly");
            this.rbInfoOnly.Checked = true;
            this.rbInfoOnly.Name = "rbInfoOnly";
            this.rbInfoOnly.TabStop = true;
            this.rbInfoOnly.UseVisualStyleBackColor = true;
            this.rbInfoOnly.CheckedChanged += new System.EventHandler(this.rbInfoOnly_CheckedChanged);
            // 
            // datDateCreated
            // 
            resources.ApplyResources(this.datDateCreated, "datDateCreated");
            this.datDateCreated.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datDateCreated.Name = "datDateCreated";
            this.datDateCreated.ValueChanged += new System.EventHandler(this.datDateCreated_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtEntryText
            // 
            resources.ApplyResources(this.txtEntryText, "txtEntryText");
            this.txtEntryText.Name = "txtEntryText";
            // 
            // lblEntryText
            // 
            resources.ApplyResources(this.lblEntryText, "lblEntryText");
            this.lblEntryText.Name = "lblEntryText";
            // 
            // PositionLogAddForm
            // 
            this.AcceptButton = this.btnSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlTrackProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbTrackProgress);
            this.Controls.Add(this.rbInfoOnly);
            this.Controls.Add(this.datDateCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntryText);
            this.Controls.Add(this.lblEntryText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionLogAddForm";
            this.Load += new System.EventHandler(this.PositionLogAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTrackProgress.ResumeLayout(false);
            this.pnlTrackProgress.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlTrackProgress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.DateTimePicker datReminderTime;
        private System.Windows.Forms.DateTimePicker datDueDate;
        private System.Windows.Forms.CheckBox chkComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbTrackProgress;
        private System.Windows.Forms.RadioButton rbInfoOnly;
        private System.Windows.Forms.DateTimePicker datDateCreated;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEntryText;
        private System.Windows.Forms.Label lblEntryText;
    }
}