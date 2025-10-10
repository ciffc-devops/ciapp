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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOperationalPeriodForm));
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
            this.flowCopyableItems = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCheckNone = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.cboCurrentOperationalPeriod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.errorProvider1.SetError(this.splitContainer1, resources.GetString("splitContainer1.Error"));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.errorProvider1.SetIconAlignment(this.splitContainer1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer1, ((int)(resources.GetObject("splitContainer1.IconPadding"))));
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.errorProvider1.SetError(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer1.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer1.Panel1, ((int)(resources.GetObject("splitContainer1.Panel1.IconPadding"))));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.chkSwitchNow);
            this.splitContainer1.Panel2.Controls.Add(this.btnCreateOpPeriod);
            this.errorProvider1.SetError(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer1.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer1.Panel2, ((int)(resources.GetObject("splitContainer1.Panel2.IconPadding"))));
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.errorProvider1.SetError(this.splitContainer2, resources.GetString("splitContainer2.Error"));
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.errorProvider1.SetIconAlignment(this.splitContainer2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer2, ((int)(resources.GetObject("splitContainer2.IconPadding"))));
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.errorProvider1.SetError(this.splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer2.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer2.Panel1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer2.Panel1, ((int)(resources.GetObject("splitContainer2.Panel1.IconPadding"))));
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.flowCopyableItems);
            this.splitContainer2.Panel2.Controls.Add(this.btnCheckNone);
            this.splitContainer2.Panel2.Controls.Add(this.btnCheckAll);
            this.splitContainer2.Panel2.Controls.Add(this.cboCurrentOperationalPeriod);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.errorProvider1.SetError(this.splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer2.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer2.Panel2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer2.Panel2, ((int)(resources.GetObject("splitContainer2.Panel2.IconPadding"))));
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.errorProvider1.SetError(this.splitContainer3, resources.GetString("splitContainer3.Error"));
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.errorProvider1.SetIconAlignment(this.splitContainer3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer3.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer3, ((int)(resources.GetObject("splitContainer3.IconPadding"))));
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.Controls.Add(this.numOpPeriod);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.errorProvider1.SetError(this.splitContainer3.Panel1, resources.GetString("splitContainer3.Panel1.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer3.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer3.Panel1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer3.Panel1, ((int)(resources.GetObject("splitContainer3.Panel1.IconPadding"))));
            // 
            // splitContainer3.Panel2
            // 
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.errorProvider1.SetError(this.splitContainer3.Panel2, resources.GetString("splitContainer3.Panel2.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer3.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer3.Panel2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer3.Panel2, ((int)(resources.GetObject("splitContainer3.Panel2.IconPadding"))));
            // 
            // numOpPeriod
            // 
            resources.ApplyResources(this.numOpPeriod, "numOpPeriod");
            this.errorProvider1.SetError(this.numOpPeriod, resources.GetString("numOpPeriod.Error"));
            this.errorProvider1.SetIconAlignment(this.numOpPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("numOpPeriod.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.numOpPeriod, ((int)(resources.GetObject("numOpPeriod.IconPadding"))));
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
            this.numOpPeriod.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numOpPeriod.ValueChanged += new System.EventHandler(this.numOpPeriod_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider1.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider1.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // splitContainer4
            // 
            resources.ApplyResources(this.splitContainer4, "splitContainer4");
            this.errorProvider1.SetError(this.splitContainer4, resources.GetString("splitContainer4.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer4.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer4, ((int)(resources.GetObject("splitContainer4.IconPadding"))));
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            resources.ApplyResources(this.splitContainer4.Panel1, "splitContainer4.Panel1");
            this.splitContainer4.Panel1.Controls.Add(this.datOpsStart);
            this.splitContainer4.Panel1.Controls.Add(this.datStartTime);
            this.splitContainer4.Panel1.Controls.Add(this.label15);
            this.errorProvider1.SetError(this.splitContainer4.Panel1, resources.GetString("splitContainer4.Panel1.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer4.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer4.Panel1.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer4.Panel1, ((int)(resources.GetObject("splitContainer4.Panel1.IconPadding"))));
            // 
            // splitContainer4.Panel2
            // 
            resources.ApplyResources(this.splitContainer4.Panel2, "splitContainer4.Panel2");
            this.splitContainer4.Panel2.Controls.Add(this.datOpsEnd);
            this.splitContainer4.Panel2.Controls.Add(this.datEndTime);
            this.splitContainer4.Panel2.Controls.Add(this.label18);
            this.errorProvider1.SetError(this.splitContainer4.Panel2, resources.GetString("splitContainer4.Panel2.Error"));
            this.errorProvider1.SetIconAlignment(this.splitContainer4.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer4.Panel2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.splitContainer4.Panel2, ((int)(resources.GetObject("splitContainer4.Panel2.IconPadding"))));
            // 
            // datOpsStart
            // 
            resources.ApplyResources(this.datOpsStart, "datOpsStart");
            this.errorProvider1.SetError(this.datOpsStart, resources.GetString("datOpsStart.Error"));
            this.datOpsStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorProvider1.SetIconAlignment(this.datOpsStart, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("datOpsStart.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.datOpsStart, ((int)(resources.GetObject("datOpsStart.IconPadding"))));
            this.datOpsStart.Name = "datOpsStart";
            this.datOpsStart.ValueChanged += new System.EventHandler(this.datOpsStart_ValueChanged);
            // 
            // datStartTime
            // 
            resources.ApplyResources(this.datStartTime, "datStartTime");
            this.errorProvider1.SetError(this.datStartTime, resources.GetString("datStartTime.Error"));
            this.datStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorProvider1.SetIconAlignment(this.datStartTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("datStartTime.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.datStartTime, ((int)(resources.GetObject("datStartTime.IconPadding"))));
            this.datStartTime.Name = "datStartTime";
            this.datStartTime.ShowUpDown = true;
            this.datStartTime.ValueChanged += new System.EventHandler(this.datStartTime_ValueChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.errorProvider1.SetError(this.label15, resources.GetString("label15.Error"));
            this.errorProvider1.SetIconAlignment(this.label15, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label15.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label15, ((int)(resources.GetObject("label15.IconPadding"))));
            this.label15.Name = "label15";
            // 
            // datOpsEnd
            // 
            resources.ApplyResources(this.datOpsEnd, "datOpsEnd");
            this.errorProvider1.SetError(this.datOpsEnd, resources.GetString("datOpsEnd.Error"));
            this.datOpsEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorProvider1.SetIconAlignment(this.datOpsEnd, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("datOpsEnd.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.datOpsEnd, ((int)(resources.GetObject("datOpsEnd.IconPadding"))));
            this.datOpsEnd.Name = "datOpsEnd";
            this.datOpsEnd.ValueChanged += new System.EventHandler(this.datOpsEnd_ValueChanged);
            // 
            // datEndTime
            // 
            resources.ApplyResources(this.datEndTime, "datEndTime");
            this.errorProvider1.SetError(this.datEndTime, resources.GetString("datEndTime.Error"));
            this.datEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.errorProvider1.SetIconAlignment(this.datEndTime, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("datEndTime.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.datEndTime, ((int)(resources.GetObject("datEndTime.IconPadding"))));
            this.datEndTime.Name = "datEndTime";
            this.datEndTime.ShowUpDown = true;
            this.datEndTime.ValueChanged += new System.EventHandler(this.datEndTime_ValueChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.errorProvider1.SetError(this.label18, resources.GetString("label18.Error"));
            this.errorProvider1.SetIconAlignment(this.label18, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label18.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label18, ((int)(resources.GetObject("label18.IconPadding"))));
            this.label18.Name = "label18";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider1.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider1.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // flowCopyableItems
            // 
            resources.ApplyResources(this.flowCopyableItems, "flowCopyableItems");
            this.flowCopyableItems.BackColor = System.Drawing.Color.White;
            this.flowCopyableItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorProvider1.SetError(this.flowCopyableItems, resources.GetString("flowCopyableItems.Error"));
            this.errorProvider1.SetIconAlignment(this.flowCopyableItems, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("flowCopyableItems.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.flowCopyableItems, ((int)(resources.GetObject("flowCopyableItems.IconPadding"))));
            this.flowCopyableItems.Name = "flowCopyableItems";
            // 
            // btnCheckNone
            // 
            resources.ApplyResources(this.btnCheckNone, "btnCheckNone");
            this.errorProvider1.SetError(this.btnCheckNone, resources.GetString("btnCheckNone.Error"));
            this.errorProvider1.SetIconAlignment(this.btnCheckNone, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCheckNone.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnCheckNone, ((int)(resources.GetObject("btnCheckNone.IconPadding"))));
            this.btnCheckNone.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_292_square_empty_minus;
            this.btnCheckNone.Name = "btnCheckNone";
            this.btnCheckNone.UseVisualStyleBackColor = true;
            this.btnCheckNone.Click += new System.EventHandler(this.btnCheckNone_Click);
            // 
            // btnCheckAll
            // 
            resources.ApplyResources(this.btnCheckAll, "btnCheckAll");
            this.errorProvider1.SetError(this.btnCheckAll, resources.GetString("btnCheckAll.Error"));
            this.errorProvider1.SetIconAlignment(this.btnCheckAll, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCheckAll.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnCheckAll, ((int)(resources.GetObject("btnCheckAll.IconPadding"))));
            this.btnCheckAll.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_294_square_empty_check;
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // cboCurrentOperationalPeriod
            // 
            resources.ApplyResources(this.cboCurrentOperationalPeriod, "cboCurrentOperationalPeriod");
            this.cboCurrentOperationalPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorProvider1.SetError(this.cboCurrentOperationalPeriod, resources.GetString("cboCurrentOperationalPeriod.Error"));
            this.cboCurrentOperationalPeriod.FormattingEnabled = true;
            this.errorProvider1.SetIconAlignment(this.cboCurrentOperationalPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cboCurrentOperationalPeriod.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.cboCurrentOperationalPeriod, ((int)(resources.GetObject("cboCurrentOperationalPeriod.IconPadding"))));
            this.cboCurrentOperationalPeriod.Name = "cboCurrentOperationalPeriod";
            this.cboCurrentOperationalPeriod.SelectedIndexChanged += new System.EventHandler(this.cboCurrentOperationalPeriod_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.errorProvider1.SetError(this.label4, resources.GetString("label4.Error"));
            this.errorProvider1.SetIconAlignment(this.label4, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label4.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label4, ((int)(resources.GetObject("label4.IconPadding"))));
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider1.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider1.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // chkSwitchNow
            // 
            resources.ApplyResources(this.chkSwitchNow, "chkSwitchNow");
            this.chkSwitchNow.Checked = true;
            this.chkSwitchNow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorProvider1.SetError(this.chkSwitchNow, resources.GetString("chkSwitchNow.Error"));
            this.errorProvider1.SetIconAlignment(this.chkSwitchNow, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkSwitchNow.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.chkSwitchNow, ((int)(resources.GetObject("chkSwitchNow.IconPadding"))));
            this.chkSwitchNow.Name = "chkSwitchNow";
            this.chkSwitchNow.UseVisualStyleBackColor = true;
            // 
            // btnCreateOpPeriod
            // 
            resources.ApplyResources(this.btnCreateOpPeriod, "btnCreateOpPeriod");
            this.errorProvider1.SetError(this.btnCreateOpPeriod, resources.GetString("btnCreateOpPeriod.Error"));
            this.errorProvider1.SetIconAlignment(this.btnCreateOpPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCreateOpPeriod.IconAlignment"))));
            this.errorProvider1.SetIconPadding(this.btnCreateOpPeriod, ((int)(resources.GetObject("btnCreateOpPeriod.IconPadding"))));
            this.btnCreateOpPeriod.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnCreateOpPeriod.Name = "btnCreateOpPeriod";
            this.btnCreateOpPeriod.Tag = "Save";
            this.btnCreateOpPeriod.UseVisualStyleBackColor = true;
            this.btnCreateOpPeriod.Click += new System.EventHandler(this.btnCreateOpPeriod_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            resources.ApplyResources(this.errorProvider1, "errorProvider1");
            // 
            // CreateOperationalPeriodForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CreateOperationalPeriodForm";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnCreateOpPeriod;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCurrentOperationalPeriod;
        private System.Windows.Forms.CheckBox chkSwitchNow;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.FlowLayoutPanel flowCopyableItems;
        private System.Windows.Forms.Button btnCheckNone;
        private System.Windows.Forms.Button btnCheckAll;
    }
}