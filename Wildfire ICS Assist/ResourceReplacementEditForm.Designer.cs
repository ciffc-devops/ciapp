namespace Wildfire_ICS_Assist
{
    partial class ResourceReplacementEditForm
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
            this.lblEditPersonTitle = new System.Windows.Forms.Label();
            this.txtOrder = new SpellBox();
            this.txtHomeArea = new SpellBox();
            this.txtAssignment = new SpellBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComments = new SpellBox();
            this.cboCheckInLocation = new System.Windows.Forms.ComboBox();
            this.cboReplacing = new System.Windows.Forms.ComboBox();
            this.cboTransportation = new System.Windows.Forms.ComboBox();
            this.datArrival = new System.Windows.Forms.DateTimePicker();
            this.cboKind = new System.Windows.Forms.ComboBox();
            this.txtName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cboVariety = new System.Windows.Forms.ComboBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.cboVariety);
            this.splitContainer1.Panel1.Controls.Add(this.lblEditPersonTitle);
            this.splitContainer1.Panel1.Controls.Add(this.txtOrder);
            this.splitContainer1.Panel1.Controls.Add(this.txtHomeArea);
            this.splitContainer1.Panel1.Controls.Add(this.txtAssignment);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtComments);
            this.splitContainer1.Panel1.Controls.Add(this.cboCheckInLocation);
            this.splitContainer1.Panel1.Controls.Add(this.cboReplacing);
            this.splitContainer1.Panel1.Controls.Add(this.cboTransportation);
            this.splitContainer1.Panel1.Controls.Add(this.datArrival);
            this.splitContainer1.Panel1.Controls.Add(this.cboKind);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(545, 575);
            this.splitContainer1.SplitterDistance = 512;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblEditPersonTitle
            // 
            this.lblEditPersonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditPersonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonTitle.Location = new System.Drawing.Point(4, 9);
            this.lblEditPersonTitle.Name = "lblEditPersonTitle";
            this.lblEditPersonTitle.Size = new System.Drawing.Size(528, 29);
            this.lblEditPersonTitle.TabIndex = 163;
            this.lblEditPersonTitle.Text = "Incoming Resource Information";
            // 
            // txtOrder
            // 
            this.txtOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrder.Location = new System.Drawing.Point(177, 356);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(336, 29);
            this.txtOrder.TabIndex = 151;
            this.txtOrder.Child = new System.Windows.Controls.TextBox();
            // 
            // txtHomeArea
            // 
            this.txtHomeArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHomeArea.Location = new System.Drawing.Point(177, 245);
            this.txtHomeArea.Name = "txtHomeArea";
            this.txtHomeArea.Size = new System.Drawing.Size(336, 29);
            this.txtHomeArea.TabIndex = 148;
            this.txtHomeArea.Child = new System.Windows.Controls.TextBox();
            // 
            // txtAssignment
            // 
            this.txtAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssignment.Location = new System.Drawing.Point(177, 175);
            this.txtAssignment.Name = "txtAssignment";
            this.txtAssignment.Size = new System.Drawing.Size(336, 29);
            this.txtAssignment.TabIndex = 146;
            this.txtAssignment.Child = new System.Windows.Controls.TextBox();
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 29);
            this.label10.TabIndex = 162;
            this.label10.Text = "Comments";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 29);
            this.label9.TabIndex = 161;
            this.label9.Text = "Check-In Location";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(5, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 29);
            this.label7.TabIndex = 160;
            this.label7.Text = "Order #";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 29);
            this.label6.TabIndex = 159;
            this.label6.Text = "Replacing";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 29);
            this.label5.TabIndex = 158;
            this.label5.Text = "Transportation";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 29);
            this.label4.TabIndex = 157;
            this.label4.Text = "Home Area";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 29);
            this.label3.TabIndex = 156;
            this.label3.Text = "Est. Arrival";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 29);
            this.label2.TabIndex = 155;
            this.label2.Text = "Assignment";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 154;
            this.label1.Text = "Kind";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(177, 429);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(336, 70);
            this.txtComments.TabIndex = 153;
            this.txtComments.WordWrap = true;
            this.txtComments.Child = new System.Windows.Controls.TextBox();
            // 
            // cboCheckInLocation
            // 
            this.cboCheckInLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCheckInLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCheckInLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCheckInLocation.FormattingEnabled = true;
            this.cboCheckInLocation.Items.AddRange(new object[] {
            "ICP",
            "Base",
            "Camp",
            "Staging",
            "Heli-Base"});
            this.cboCheckInLocation.Location = new System.Drawing.Point(177, 391);
            this.cboCheckInLocation.Name = "cboCheckInLocation";
            this.cboCheckInLocation.Size = new System.Drawing.Size(336, 32);
            this.cboCheckInLocation.TabIndex = 152;
            // 
            // cboReplacing
            // 
            this.cboReplacing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReplacing.FormattingEnabled = true;
            this.cboReplacing.Location = new System.Drawing.Point(177, 318);
            this.cboReplacing.Name = "cboReplacing";
            this.cboReplacing.Size = new System.Drawing.Size(336, 32);
            this.cboReplacing.TabIndex = 150;
            // 
            // cboTransportation
            // 
            this.cboTransportation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTransportation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTransportation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTransportation.FormattingEnabled = true;
            this.cboTransportation.Items.AddRange(new object[] {
            "Aircraft",
            "Bus",
            "Vehicle"});
            this.cboTransportation.Location = new System.Drawing.Point(177, 280);
            this.cboTransportation.Name = "cboTransportation";
            this.cboTransportation.Size = new System.Drawing.Size(336, 32);
            this.cboTransportation.TabIndex = 149;
            // 
            // datArrival
            // 
            this.datArrival.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datArrival.Location = new System.Drawing.Point(177, 210);
            this.datArrival.Name = "datArrival";
            this.datArrival.Size = new System.Drawing.Size(336, 29);
            this.datArrival.TabIndex = 147;
            // 
            // cboKind
            // 
            this.cboKind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboKind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKind.FormattingEnabled = true;
            this.cboKind.Location = new System.Drawing.Point(177, 137);
            this.cboKind.Name = "cboKind";
            this.cboKind.Size = new System.Drawing.Size(336, 32);
            this.cboKind.TabIndex = 145;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(177, 95);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(355, 33);
            this.txtName.TabIndex = 144;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(5, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 29);
            this.label8.TabIndex = 143;
            this.label8.Text = "Name";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(211, 4);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 48);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(416, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 48);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(7, 4);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 48);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 29);
            this.label11.TabIndex = 165;
            this.label11.Text = "Variety";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboVariety
            // 
            this.cboVariety.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboVariety.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboVariety.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboVariety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVariety.FormattingEnabled = true;
            this.cboVariety.Items.AddRange(new object[] {
            "All Resources",
            "Personnel",
            "Visitor",
            "Vehicle",
            "Equipment",
            "Operator",
            "Crew"});
            this.cboVariety.Location = new System.Drawing.Point(177, 54);
            this.cboVariety.Name = "cboVariety";
            this.cboVariety.Size = new System.Drawing.Size(336, 32);
            this.cboVariety.TabIndex = 143;
            // 
            // ResourceReplacementEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 575);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(561, 503);
            this.Name = "ResourceReplacementEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resource Replacement Plan";
            this.Load += new System.EventHandler(this.ResourceReplacementEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CustomControls.TextBoxRequiredControl txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private SpellBox txtComments;
        private System.Windows.Forms.ComboBox cboCheckInLocation;
        private System.Windows.Forms.ComboBox cboReplacing;
        private System.Windows.Forms.ComboBox cboTransportation;
        private System.Windows.Forms.DateTimePicker datArrival;
        private System.Windows.Forms.ComboBox cboKind;
        private SpellBox txtAssignment;
        private SpellBox txtOrder;
        private SpellBox txtHomeArea;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblEditPersonTitle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboVariety;
    }
}