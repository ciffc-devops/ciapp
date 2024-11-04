namespace Wildfire_ICS_Assist.IncidentStatusSummaryForms
{
    partial class IncidentStatusSummaryForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpBasics = new System.Windows.Forms.TabPage();
            this.tpApproval = new System.Windows.Forms.TabPage();
            this.tpLocation = new System.Windows.Forms.TabPage();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.tpDecisionSupport = new System.Windows.Forms.TabPage();
            this.tpResources = new System.Windows.Forms.TabPage();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numReportNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRequiredControl1 = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.spellBox1 = new SpellBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpBasics.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReportNumber)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrev);
            this.splitContainer1.Panel2.Controls.Add(this.btnNext);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Size = new System.Drawing.Size(1105, 552);
            this.splitContainer1.SplitterDistance = 497;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpBasics);
            this.tabControl1.Controls.Add(this.tpApproval);
            this.tabControl1.Controls.Add(this.tpLocation);
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Controls.Add(this.tpDecisionSupport);
            this.tabControl1.Controls.Add(this.tpResources);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1105, 497);
            this.tabControl1.TabIndex = 0;
            // 
            // tpBasics
            // 
            this.tpBasics.Controls.Add(this.panel3);
            this.tpBasics.Controls.Add(this.panel2);
            this.tpBasics.Controls.Add(this.prepAndApprovePanel1);
            this.tpBasics.Controls.Add(this.panel1);
            this.tpBasics.Location = new System.Drawing.Point(4, 33);
            this.tpBasics.Name = "tpBasics";
            this.tpBasics.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasics.Size = new System.Drawing.Size(1097, 460);
            this.tpBasics.TabIndex = 0;
            this.tpBasics.Text = "Basics";
            this.tpBasics.UseVisualStyleBackColor = true;
            // 
            // tpApproval
            // 
            this.tpApproval.Location = new System.Drawing.Point(4, 33);
            this.tpApproval.Name = "tpApproval";
            this.tpApproval.Padding = new System.Windows.Forms.Padding(3);
            this.tpApproval.Size = new System.Drawing.Size(1097, 460);
            this.tpApproval.TabIndex = 1;
            this.tpApproval.Text = "Approval";
            this.tpApproval.UseVisualStyleBackColor = true;
            // 
            // tpLocation
            // 
            this.tpLocation.Location = new System.Drawing.Point(4, 33);
            this.tpLocation.Name = "tpLocation";
            this.tpLocation.Size = new System.Drawing.Size(1097, 460);
            this.tpLocation.TabIndex = 2;
            this.tpLocation.Text = "Location Info";
            this.tpLocation.UseVisualStyleBackColor = true;
            // 
            // tpSummary
            // 
            this.tpSummary.Location = new System.Drawing.Point(4, 33);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Size = new System.Drawing.Size(1097, 460);
            this.tpSummary.TabIndex = 3;
            this.tpSummary.Text = "Summary";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // tpDecisionSupport
            // 
            this.tpDecisionSupport.Location = new System.Drawing.Point(4, 33);
            this.tpDecisionSupport.Name = "tpDecisionSupport";
            this.tpDecisionSupport.Size = new System.Drawing.Size(1097, 460);
            this.tpDecisionSupport.TabIndex = 4;
            this.tpDecisionSupport.Text = "Decision Support";
            this.tpDecisionSupport.UseVisualStyleBackColor = true;
            // 
            // tpResources
            // 
            this.tpResources.Location = new System.Drawing.Point(4, 33);
            this.tpResources.Name = "tpResources";
            this.tpResources.Size = new System.Drawing.Size(1097, 460);
            this.tpResources.TabIndex = 5;
            this.tpResources.Text = "Resoures";
            this.tpResources.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnPrev.Location = new System.Drawing.Point(3, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(96, 42);
            this.btnPrev.TabIndex = 55;
            this.btnPrev.Text = "Prev";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnNext.Location = new System.Drawing.Point(836, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(107, 42);
            this.btnNext.TabIndex = 54;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrint.Location = new System.Drawing.Point(949, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(144, 42);
            this.btnPrint.TabIndex = 53;
            this.btnPrint.Text = "View PDF";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numReportNumber);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 127);
            this.panel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 28);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Initial";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 62);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 28);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Update";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 96);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(69, 28);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Final";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Report Version";
            // 
            // numReportNumber
            // 
            this.numReportNumber.Location = new System.Drawing.Point(181, 92);
            this.numReportNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numReportNumber.Name = "numReportNumber";
            this.numReportNumber.Size = new System.Drawing.Size(67, 29);
            this.numReportNumber.TabIndex = 3;
            this.numReportNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(172, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rpt #";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(172, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "(if used)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = false;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = false;
            this.prepAndApprovePanel1.ExpandsRight = true;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(8, 142);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 11, 1, 14, 39, 56, 417);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(514, 197);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(485, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(619, 197);
            this.prepAndApprovePanel1.TabIndex = 1;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.spellBox1);
            this.panel2.Controls.Add(this.textBoxRequiredControl1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(620, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 165);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(739, 275);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Incident Command";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(378, 24);
            this.label5.TabIndex = 3;
            this.label5.Text = "Incident Commander(s) and  Agency or Org";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(229, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Incident Management Org";
            // 
            // textBoxRequiredControl1
            // 
            this.textBoxRequiredControl1.BackColor = System.Drawing.Color.Transparent;
            this.textBoxRequiredControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRequiredControl1.Location = new System.Drawing.Point(6, 60);
            this.textBoxRequiredControl1.Margin = new System.Windows.Forms.Padding(6);
            this.textBoxRequiredControl1.Multiline = false;
            this.textBoxRequiredControl1.Name = "textBoxRequiredControl1";
            this.textBoxRequiredControl1.Size = new System.Drawing.Size(374, 34);
            this.textBoxRequiredControl1.TabIndex = 5;
            // 
            // spellBox1
            // 
            this.spellBox1.Location = new System.Drawing.Point(6, 127);
            this.spellBox1.Name = "spellBox1";
            this.spellBox1.Size = new System.Drawing.Size(356, 30);
            this.spellBox1.TabIndex = 6;
            this.spellBox1.Child = new System.Windows.Controls.TextBox();
            // 
            // IncidentStatusSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 552);
            this.Controls.Add(this.splitContainer1);
            this.Name = "IncidentStatusSummaryForm";
            this.Text = "Incident Status Summary";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpBasics.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReportNumber)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpBasics;
        private System.Windows.Forms.TabPage tpApproval;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TabPage tpLocation;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.TabPage tpDecisionSupport;
        private System.Windows.Forms.TabPage tpResources;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numReportNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private SpellBox spellBox1;
        private CustomControls.TextBoxRequiredControl textBoxRequiredControl1;
    }
}