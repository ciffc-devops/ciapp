namespace Wildfire_ICS_Assist
{
    partial class PositionLogReminderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PositionLogReminderForm));
            this.btnSetNewReminder = new System.Windows.Forms.Button();
            this.datNewReminderTime = new System.Windows.Forms.DateTimePicker();
            this.btnMarkAsComplete = new System.Windows.Forms.Button();
            this.lblReminderText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetNewReminder
            // 
            this.btnSetNewReminder.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_55_clock;
            resources.ApplyResources(this.btnSetNewReminder, "btnSetNewReminder");
            this.btnSetNewReminder.Name = "btnSetNewReminder";
            this.btnSetNewReminder.UseVisualStyleBackColor = true;
            this.btnSetNewReminder.Click += new System.EventHandler(this.btnSetNewReminder_Click);
            // 
            // datNewReminderTime
            // 
            resources.ApplyResources(this.datNewReminderTime, "datNewReminderTime");
            this.datNewReminderTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datNewReminderTime.Name = "datNewReminderTime";
            // 
            // btnMarkAsComplete
            // 
            this.btnMarkAsComplete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_739_check;
            resources.ApplyResources(this.btnMarkAsComplete, "btnMarkAsComplete");
            this.btnMarkAsComplete.Name = "btnMarkAsComplete";
            this.btnMarkAsComplete.UseVisualStyleBackColor = true;
            this.btnMarkAsComplete.Click += new System.EventHandler(this.btnMarkAsComplete_Click);
            // 
            // lblReminderText
            // 
            resources.ApplyResources(this.lblReminderText, "lblReminderText");
            this.lblReminderText.BackColor = System.Drawing.Color.White;
            this.lblReminderText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReminderText.Name = "lblReminderText";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PositionLogReminderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.btnSetNewReminder);
            this.Controls.Add(this.datNewReminderTime);
            this.Controls.Add(this.btnMarkAsComplete);
            this.Controls.Add(this.lblReminderText);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PositionLogReminderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetNewReminder;
        private System.Windows.Forms.DateTimePicker datNewReminderTime;
        private System.Windows.Forms.Button btnMarkAsComplete;
        private System.Windows.Forms.Label lblReminderText;
        private System.Windows.Forms.Label label1;
    }
}