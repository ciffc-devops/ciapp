namespace Wildfire_ICS_Assist
{
    partial class CommunicationsPlanEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationsPlanEditForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAirHelp = new System.Windows.Forms.Button();
            this.editCommsChannelControl1 = new Wildfire_ICS_Assist.CustomControls.EditCommsChannelControl();
            this.label12 = new System.Windows.Forms.Label();
            this.chkUsedForAir = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAssignment = new System.Windows.Forms.TextBox();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.splitContainer1.Panel1.Controls.Add(this.btnAirHelp);
            this.splitContainer1.Panel1.Controls.Add(this.editCommsChannelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.chkUsedForAir);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txtAssignment);
            this.splitContainer1.Panel1.Controls.Add(this.txtFunction);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(504, 503);
            this.splitContainer1.SplitterDistance = 440;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnAirHelp
            // 
            this.btnAirHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAirHelp.BackColor = System.Drawing.Color.White;
            this.btnAirHelp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAirHelp.BackgroundImage")));
            this.btnAirHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAirHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.btnAirHelp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAirHelp.Location = new System.Drawing.Point(437, 394);
            this.btnAirHelp.Name = "btnAirHelp";
            this.btnAirHelp.Size = new System.Drawing.Size(25, 25);
            this.btnAirHelp.TabIndex = 148;
            this.btnAirHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAirHelp, "If this box is checked, this item will be included in the \'7. FREQUENCIES\' sectio" +
        "n of ICS-220 Air Ops Summary.");
            this.btnAirHelp.UseVisualStyleBackColor = false;
            this.btnAirHelp.Click += new System.EventHandler(this.btnAirHelp_Click);
            // 
            // editCommsChannelControl1
            // 
            this.editCommsChannelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editCommsChannelControl1.BackColor = System.Drawing.Color.Transparent;
            this.editCommsChannelControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editCommsChannelControl1.Location = new System.Drawing.Point(6, 6);
            this.editCommsChannelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.editCommsChannelControl1.Name = "editCommsChannelControl1";
            this.editCommsChannelControl1.selectedItem = null;
            this.editCommsChannelControl1.Size = new System.Drawing.Size(492, 310);
            this.editCommsChannelControl1.TabIndex = 147;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(15, 394);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 29);
            this.label12.TabIndex = 146;
            this.label12.Text = "Used for Air";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUsedForAir
            // 
            this.chkUsedForAir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUsedForAir.AutoSize = true;
            this.chkUsedForAir.Location = new System.Drawing.Point(165, 394);
            this.chkUsedForAir.Name = "chkUsedForAir";
            this.chkUsedForAir.Size = new System.Drawing.Size(255, 28);
            this.chkUsedForAir.TabIndex = 145;
            this.chkUsedForAir.Text = "Yes, this item is used for air";
            this.chkUsedForAir.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.Location = new System.Drawing.Point(15, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 29);
            this.label8.TabIndex = 143;
            this.label8.Text = "Assignment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssignment
            // 
            this.txtAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssignment.Location = new System.Drawing.Point(165, 357);
            this.txtAssignment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(297, 29);
            this.txtAssignment.TabIndex = 135;
            // 
            // txtFunction
            // 
            this.txtFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunction.Location = new System.Drawing.Point(165, 318);
            this.txtFunction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(297, 29);
            this.txtFunction.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(15, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 29);
            this.label7.TabIndex = 142;
            this.label7.Text = "Function*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(376, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 16;
            this.btnSave.Tag = "Save";
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CommunicationsPlanEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 503);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CommunicationsPlanEditForm";
            this.Text = "Edit Comms System";
            this.Load += new System.EventHandler(this.CommunicationsPlanEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAssignment;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkUsedForAir;
        private CustomControls.EditCommsChannelControl editCommsChannelControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAirHelp;
    }
}