﻿namespace Wildfire_ICS_Assist.CustomControls
{
    partial class ResourceCheckInEditControl
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
            this.lblLastDayCount = new System.Windows.Forms.Label();
            this.lblScrollHint = new System.Windows.Forms.Label();
            this.pnlCheckInFields = new System.Windows.Forms.Panel();
            this.txtResourceType = new System.Windows.Forms.TextBox();
            this.txtSelectedName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.datLDW = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLastDayWorking = new System.Windows.Forms.Label();
            this.lblDaysSinceLastDayOfRest = new System.Windows.Forms.Label();
            this.datLastDayOfRest = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLastDayCount
            // 
            this.lblLastDayCount.AutoSize = true;
            this.lblLastDayCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDayCount.Location = new System.Drawing.Point(406, 123);
            this.lblLastDayCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastDayCount.Name = "lblLastDayCount";
            this.lblLastDayCount.Size = new System.Drawing.Size(306, 20);
            this.lblLastDayCount.TabIndex = 129;
            this.lblLastDayCount.Text = "25 days since rest / 25 days since check in";
            this.lblLastDayCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblScrollHint
            // 
            this.lblScrollHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScrollHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScrollHint.ForeColor = System.Drawing.Color.Maroon;
            this.lblScrollHint.Location = new System.Drawing.Point(581, 47);
            this.lblScrollHint.Name = "lblScrollHint";
            this.lblScrollHint.Size = new System.Drawing.Size(132, 70);
            this.lblScrollHint.TabIndex = 128;
            this.lblScrollHint.Text = "*be sure to scroll the box below";
            this.lblScrollHint.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pnlCheckInFields
            // 
            this.pnlCheckInFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCheckInFields.AutoScroll = true;
            this.pnlCheckInFields.BackColor = System.Drawing.Color.White;
            this.pnlCheckInFields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckInFields.Location = new System.Drawing.Point(7, 156);
            this.pnlCheckInFields.Name = "pnlCheckInFields";
            this.pnlCheckInFields.Size = new System.Drawing.Size(709, 314);
            this.pnlCheckInFields.TabIndex = 4;
            // 
            // txtResourceType
            // 
            this.txtResourceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResourceType.Location = new System.Drawing.Point(446, 6);
            this.txtResourceType.Margin = new System.Windows.Forms.Padding(6);
            this.txtResourceType.Name = "txtResourceType";
            this.txtResourceType.ReadOnly = true;
            this.txtResourceType.Size = new System.Drawing.Size(267, 29);
            this.txtResourceType.TabIndex = 126;
            this.txtResourceType.TabStop = false;
            // 
            // txtSelectedName
            // 
            this.txtSelectedName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedName.Location = new System.Drawing.Point(202, 6);
            this.txtSelectedName.Margin = new System.Windows.Forms.Padding(6);
            this.txtSelectedName.Name = "txtSelectedName";
            this.txtSelectedName.ReadOnly = true;
            this.txtSelectedName.Size = new System.Drawing.Size(232, 29);
            this.txtSelectedName.TabIndex = 120;
            this.txtSelectedName.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 29);
            this.label3.TabIndex = 122;
            this.label3.Text = "Resource";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datCheckInTime
            // 
            this.datCheckInTime.CustomFormat = "yyyy-MMM-dd HH:mm";
            this.datCheckInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datCheckInTime.Location = new System.Drawing.Point(202, 86);
            this.datCheckInTime.Name = "datCheckInTime";
            this.datCheckInTime.Size = new System.Drawing.Size(195, 29);
            this.datCheckInTime.TabIndex = 2;
            this.datCheckInTime.ValueChanged += new System.EventHandler(this.datCheckInTime_ValueChanged);
            // 
            // datLDW
            // 
            this.datLDW.CustomFormat = "yyyy-MMM-dd";
            this.datLDW.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLDW.Location = new System.Drawing.Point(202, 121);
            this.datLDW.Name = "datLDW";
            this.datLDW.Size = new System.Drawing.Size(195, 29);
            this.datLDW.TabIndex = 3;
            this.datLDW.ValueChanged += new System.EventHandler(this.datLDW_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 124;
            this.label4.Text = "Check-In at Incident*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastDayWorking
            // 
            this.lblLastDayWorking.Location = new System.Drawing.Point(8, 121);
            this.lblLastDayWorking.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLastDayWorking.Name = "lblLastDayWorking";
            this.lblLastDayWorking.Size = new System.Drawing.Size(187, 29);
            this.lblLastDayWorking.TabIndex = 125;
            this.lblLastDayWorking.Text = "Last Day at Incident*";
            this.lblLastDayWorking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDaysSinceLastDayOfRest
            // 
            this.lblDaysSinceLastDayOfRest.AutoSize = true;
            this.lblDaysSinceLastDayOfRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDaysSinceLastDayOfRest.Location = new System.Drawing.Point(406, 86);
            this.lblDaysSinceLastDayOfRest.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDaysSinceLastDayOfRest.Name = "lblDaysSinceLastDayOfRest";
            this.lblDaysSinceLastDayOfRest.Size = new System.Drawing.Size(55, 20);
            this.lblDaysSinceLastDayOfRest.TabIndex = 132;
            this.lblDaysSinceLastDayOfRest.Text = "5 days";
            this.lblDaysSinceLastDayOfRest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // datLastDayOfRest
            // 
            this.datLastDayOfRest.CustomFormat = "yyyy-MMM-dd";
            this.datLastDayOfRest.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datLastDayOfRest.Location = new System.Drawing.Point(202, 51);
            this.datLastDayOfRest.Name = "datLastDayOfRest";
            this.datLastDayOfRest.Size = new System.Drawing.Size(195, 29);
            this.datLastDayOfRest.TabIndex = 1;
            this.datLastDayOfRest.ValueChanged += new System.EventHandler(this.datLastDayOfRest_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 29);
            this.label2.TabIndex = 131;
            this.label2.Text = "Last Day of Rest*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ResourceCheckInEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDaysSinceLastDayOfRest);
            this.Controls.Add(this.datLastDayOfRest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLastDayCount);
            this.Controls.Add(this.lblScrollHint);
            this.Controls.Add(this.pnlCheckInFields);
            this.Controls.Add(this.txtResourceType);
            this.Controls.Add(this.txtSelectedName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datCheckInTime);
            this.Controls.Add(this.datLDW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLastDayWorking);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ResourceCheckInEditControl";
            this.Size = new System.Drawing.Size(719, 473);
            this.Load += new System.EventHandler(this.ResourceCheckInEditControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLastDayCount;
        private System.Windows.Forms.Label lblScrollHint;
        private System.Windows.Forms.Panel pnlCheckInFields;
        private System.Windows.Forms.TextBox txtResourceType;
        private System.Windows.Forms.TextBox txtSelectedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datCheckInTime;
        private System.Windows.Forms.DateTimePicker datLDW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLastDayWorking;
        private System.Windows.Forms.Label lblDaysSinceLastDayOfRest;
        private System.Windows.Forms.DateTimePicker datLastDayOfRest;
        private System.Windows.Forms.Label label2;
    }
}