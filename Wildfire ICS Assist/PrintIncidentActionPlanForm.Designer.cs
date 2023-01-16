﻿namespace Wildfire_ICS_Assist
{
    partial class PrintIncidentActionPlanForm
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
            this.chkFlattenPDF = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAsPDF = new System.Windows.Forms.Button();
            this.chkIncidentObjectives = new System.Windows.Forms.CheckBox();
            this.lblOpPeriodTitle = new System.Windows.Forms.Label();
            this.chkOrgAssignments = new System.Windows.Forms.CheckBox();
            this.chkCommsPlan = new System.Windows.Forms.CheckBox();
            this.chkAssignments = new System.Windows.Forms.CheckBox();
            this.chkOrgChart = new System.Windows.Forms.CheckBox();
            this.chkMedPlan = new System.Windows.Forms.CheckBox();
            this.chkAirOps = new System.Windows.Forms.CheckBox();
            this.chkIncidentStatus = new System.Windows.Forms.CheckBox();
            this.chkSafetyMessage = new System.Windows.Forms.CheckBox();
            this.chkVerboseActivityLog = new System.Windows.Forms.CheckBox();
            this.chkActivityLog = new System.Windows.Forms.CheckBox();
            this.chkGeneralMessages = new System.Windows.Forms.CheckBox();
            this.chkNotes = new System.Windows.Forms.CheckBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.chkNotes);
            this.splitContainer1.Panel1.Controls.Add(this.chkVerboseActivityLog);
            this.splitContainer1.Panel1.Controls.Add(this.chkActivityLog);
            this.splitContainer1.Panel1.Controls.Add(this.chkGeneralMessages);
            this.splitContainer1.Panel1.Controls.Add(this.chkAirOps);
            this.splitContainer1.Panel1.Controls.Add(this.chkIncidentStatus);
            this.splitContainer1.Panel1.Controls.Add(this.chkSafetyMessage);
            this.splitContainer1.Panel1.Controls.Add(this.chkOrgChart);
            this.splitContainer1.Panel1.Controls.Add(this.chkMedPlan);
            this.splitContainer1.Panel1.Controls.Add(this.chkCommsPlan);
            this.splitContainer1.Panel1.Controls.Add(this.chkAssignments);
            this.splitContainer1.Panel1.Controls.Add(this.chkOrgAssignments);
            this.splitContainer1.Panel1.Controls.Add(this.chkFlattenPDF);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.chkIncidentObjectives);
            this.splitContainer1.Panel1.Controls.Add(this.lblOpPeriodTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveAsPDF);
            this.splitContainer1.Size = new System.Drawing.Size(658, 501);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.TabIndex = 1;
            // 
            // chkFlattenPDF
            // 
            this.chkFlattenPDF.AutoSize = true;
            this.chkFlattenPDF.Checked = true;
            this.chkFlattenPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFlattenPDF.Location = new System.Drawing.Point(17, 53);
            this.chkFlattenPDF.Name = "chkFlattenPDF";
            this.chkFlattenPDF.Size = new System.Drawing.Size(211, 28);
            this.chkFlattenPDF.TabIndex = 18;
            this.chkFlattenPDF.Text = "Lock all editable fields";
            this.chkFlattenPDF.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Include...";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(12, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 46);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAsPDF
            // 
            this.btnSaveAsPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAsPDF.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnSaveAsPDF.Location = new System.Drawing.Point(477, 3);
            this.btnSaveAsPDF.Name = "btnSaveAsPDF";
            this.btnSaveAsPDF.Size = new System.Drawing.Size(178, 46);
            this.btnSaveAsPDF.TabIndex = 15;
            this.btnSaveAsPDF.Text = "Save as a PDF";
            this.btnSaveAsPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAsPDF.UseVisualStyleBackColor = true;
            this.btnSaveAsPDF.Click += new System.EventHandler(this.btnSaveAsPDF_Click);
            // 
            // chkIncidentObjectives
            // 
            this.chkIncidentObjectives.AutoSize = true;
            this.chkIncidentObjectives.Checked = true;
            this.chkIncidentObjectives.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncidentObjectives.Location = new System.Drawing.Point(44, 120);
            this.chkIncidentObjectives.Name = "chkIncidentObjectives";
            this.chkIncidentObjectives.Size = new System.Drawing.Size(234, 28);
            this.chkIncidentObjectives.TabIndex = 14;
            this.chkIncidentObjectives.Text = "202 - Incident Objectives";
            this.chkIncidentObjectives.UseVisualStyleBackColor = true;
            // 
            // lblOpPeriodTitle
            // 
            this.lblOpPeriodTitle.AutoSize = true;
            this.lblOpPeriodTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpPeriodTitle.Location = new System.Drawing.Point(12, 9);
            this.lblOpPeriodTitle.Name = "lblOpPeriodTitle";
            this.lblOpPeriodTitle.Size = new System.Drawing.Size(331, 29);
            this.lblOpPeriodTitle.TabIndex = 13;
            this.lblOpPeriodTitle.Text = "Print Operational Period 22";
            // 
            // chkOrgAssignments
            // 
            this.chkOrgAssignments.AutoSize = true;
            this.chkOrgAssignments.Checked = true;
            this.chkOrgAssignments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrgAssignments.Location = new System.Drawing.Point(44, 154);
            this.chkOrgAssignments.Name = "chkOrgAssignments";
            this.chkOrgAssignments.Size = new System.Drawing.Size(243, 28);
            this.chkOrgAssignments.TabIndex = 19;
            this.chkOrgAssignments.Text = "203 - Org Assignment List";
            this.chkOrgAssignments.UseVisualStyleBackColor = true;
            // 
            // chkCommsPlan
            // 
            this.chkCommsPlan.AutoSize = true;
            this.chkCommsPlan.Checked = true;
            this.chkCommsPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCommsPlan.Location = new System.Drawing.Point(44, 222);
            this.chkCommsPlan.Name = "chkCommsPlan";
            this.chkCommsPlan.Size = new System.Drawing.Size(258, 28);
            this.chkCommsPlan.TabIndex = 21;
            this.chkCommsPlan.Text = "205 - Communications Plan";
            this.chkCommsPlan.UseVisualStyleBackColor = true;
            // 
            // chkAssignments
            // 
            this.chkAssignments.AutoSize = true;
            this.chkAssignments.Checked = true;
            this.chkAssignments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAssignments.Location = new System.Drawing.Point(44, 188);
            this.chkAssignments.Name = "chkAssignments";
            this.chkAssignments.Size = new System.Drawing.Size(206, 28);
            this.chkAssignments.TabIndex = 20;
            this.chkAssignments.Text = "204 - Assignment List";
            this.chkAssignments.UseVisualStyleBackColor = true;
            // 
            // chkOrgChart
            // 
            this.chkOrgChart.AutoSize = true;
            this.chkOrgChart.Checked = true;
            this.chkOrgChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrgChart.Location = new System.Drawing.Point(44, 290);
            this.chkOrgChart.Name = "chkOrgChart";
            this.chkOrgChart.Size = new System.Drawing.Size(230, 28);
            this.chkOrgChart.TabIndex = 23;
            this.chkOrgChart.Text = "207 - Organization Chart";
            this.chkOrgChart.UseVisualStyleBackColor = true;
            // 
            // chkMedPlan
            // 
            this.chkMedPlan.AutoSize = true;
            this.chkMedPlan.Checked = true;
            this.chkMedPlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMedPlan.Location = new System.Drawing.Point(44, 256);
            this.chkMedPlan.Name = "chkMedPlan";
            this.chkMedPlan.Size = new System.Drawing.Size(183, 28);
            this.chkMedPlan.TabIndex = 22;
            this.chkMedPlan.Text = "206 - Medical Plan";
            this.chkMedPlan.UseVisualStyleBackColor = true;
            // 
            // chkAirOps
            // 
            this.chkAirOps.AutoSize = true;
            this.chkAirOps.Checked = true;
            this.chkAirOps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAirOps.Location = new System.Drawing.Point(44, 392);
            this.chkAirOps.Name = "chkAirOps";
            this.chkAirOps.Size = new System.Drawing.Size(223, 28);
            this.chkAirOps.TabIndex = 26;
            this.chkAirOps.Text = "220 - Air Ops Summary";
            this.chkAirOps.UseVisualStyleBackColor = true;
            // 
            // chkIncidentStatus
            // 
            this.chkIncidentStatus.AutoSize = true;
            this.chkIncidentStatus.Checked = true;
            this.chkIncidentStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncidentStatus.Location = new System.Drawing.Point(44, 358);
            this.chkIncidentStatus.Name = "chkIncidentStatus";
            this.chkIncidentStatus.Size = new System.Drawing.Size(196, 28);
            this.chkIncidentStatus.TabIndex = 25;
            this.chkIncidentStatus.Text = "209 - Incident Status";
            this.chkIncidentStatus.UseVisualStyleBackColor = true;
            // 
            // chkSafetyMessage
            // 
            this.chkSafetyMessage.AutoSize = true;
            this.chkSafetyMessage.Checked = true;
            this.chkSafetyMessage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSafetyMessage.Location = new System.Drawing.Point(44, 324);
            this.chkSafetyMessage.Name = "chkSafetyMessage";
            this.chkSafetyMessage.Size = new System.Drawing.Size(270, 28);
            this.chkSafetyMessage.TabIndex = 24;
            this.chkSafetyMessage.Text = "208 - Safety Message/Plan(s)";
            this.chkSafetyMessage.UseVisualStyleBackColor = true;
            // 
            // chkVerboseActivityLog
            // 
            this.chkVerboseActivityLog.AutoSize = true;
            this.chkVerboseActivityLog.Checked = true;
            this.chkVerboseActivityLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerboseActivityLog.Location = new System.Drawing.Point(346, 188);
            this.chkVerboseActivityLog.Name = "chkVerboseActivityLog";
            this.chkVerboseActivityLog.Size = new System.Drawing.Size(209, 28);
            this.chkVerboseActivityLog.TabIndex = 29;
            this.chkVerboseActivityLog.Text = "Verbose Activity Logs";
            this.chkVerboseActivityLog.UseVisualStyleBackColor = true;
            // 
            // chkActivityLog
            // 
            this.chkActivityLog.AutoSize = true;
            this.chkActivityLog.Checked = true;
            this.chkActivityLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivityLog.Location = new System.Drawing.Point(346, 154);
            this.chkActivityLog.Name = "chkActivityLog";
            this.chkActivityLog.Size = new System.Drawing.Size(190, 28);
            this.chkActivityLog.TabIndex = 28;
            this.chkActivityLog.Text = "214 - Activity Log(s)";
            this.chkActivityLog.UseVisualStyleBackColor = true;
            // 
            // chkGeneralMessages
            // 
            this.chkGeneralMessages.AutoSize = true;
            this.chkGeneralMessages.Checked = true;
            this.chkGeneralMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGeneralMessages.Location = new System.Drawing.Point(346, 120);
            this.chkGeneralMessages.Name = "chkGeneralMessages";
            this.chkGeneralMessages.Size = new System.Drawing.Size(245, 28);
            this.chkGeneralMessages.TabIndex = 27;
            this.chkGeneralMessages.Text = "213 - General Message(s)";
            this.chkGeneralMessages.UseVisualStyleBackColor = true;
            // 
            // chkNotes
            // 
            this.chkNotes.AutoSize = true;
            this.chkNotes.Checked = true;
            this.chkNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotes.Location = new System.Drawing.Point(346, 222);
            this.chkNotes.Name = "chkNotes";
            this.chkNotes.Size = new System.Drawing.Size(166, 28);
            this.chkNotes.TabIndex = 30;
            this.chkNotes.Text = "Additional Notes";
            this.chkNotes.UseVisualStyleBackColor = true;
            // 
            // PrintIncidentActionPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 501);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PrintIncidentActionPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Incident Action Plan";
            this.Load += new System.EventHandler(this.PrintIncidentActionPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkFlattenPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncidentObjectives;
        private System.Windows.Forms.Label lblOpPeriodTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAsPDF;
        private System.Windows.Forms.CheckBox chkAirOps;
        private System.Windows.Forms.CheckBox chkIncidentStatus;
        private System.Windows.Forms.CheckBox chkSafetyMessage;
        private System.Windows.Forms.CheckBox chkOrgChart;
        private System.Windows.Forms.CheckBox chkMedPlan;
        private System.Windows.Forms.CheckBox chkCommsPlan;
        private System.Windows.Forms.CheckBox chkAssignments;
        private System.Windows.Forms.CheckBox chkOrgAssignments;
        private System.Windows.Forms.CheckBox chkNotes;
        private System.Windows.Forms.CheckBox chkVerboseActivityLog;
        private System.Windows.Forms.CheckBox chkActivityLog;
        private System.Windows.Forms.CheckBox chkGeneralMessages;
    }
}