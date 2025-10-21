namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditBranchControl
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
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSupervisor = new System.Windows.Forms.ComboBox();
            this.lblGroupLeaderTitle = new System.Windows.Forms.Label();
            this.cboReportsTo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtTactical = new SpellBox();
            this.txtSpecial = new SpellBox();
            this.collapsiblePanel1 = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboComms4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboComms1 = new System.Windows.Forms.ComboBox();
            this.cboComms2 = new System.Windows.Forms.ComboBox();
            this.cboComms3 = new System.Windows.Forms.ComboBox();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.collapsiblePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(194, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(338, 40);
            this.label10.TabIndex = 108;
            this.label10.Text = "Use the Check-In function to add personnel";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 29);
            this.label9.TabIndex = 107;
            this.label9.Text = "Basic Information";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Branch",
            "Division",
            "Group"});
            this.cboType.Location = new System.Drawing.Point(194, 37);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(338, 32);
            this.cboType.TabIndex = 98;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // cboName
            // 
            this.cboName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(194, 113);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(252, 32);
            this.cboName.TabIndex = 103;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            this.cboName.TextUpdate += new System.EventHandler(this.cboName_TextUpdate);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(81, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 29);
            this.label3.TabIndex = 102;
            this.label3.Text = "Name*:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(321, 113);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 29);
            this.txtName.TabIndex = 104;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged_1);
            this.txtName.Leave += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 29);
            this.label2.TabIndex = 99;
            this.label2.Text = "Reports to:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 101;
            this.label1.Text = "Type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSupervisor
            // 
            this.cboSupervisor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSupervisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupervisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupervisor.DisplayMember = "NameWithInitialRoleAcronym";
            this.cboSupervisor.FormattingEnabled = true;
            this.cboSupervisor.Location = new System.Drawing.Point(194, 156);
            this.cboSupervisor.Name = "cboSupervisor";
            this.cboSupervisor.Size = new System.Drawing.Size(338, 32);
            this.cboSupervisor.TabIndex = 106;
            this.cboSupervisor.ValueMember = "PersonID";
            this.cboSupervisor.SelectedIndexChanged += new System.EventHandler(this.cboSupervisor_SelectedIndexChanged);
            this.cboSupervisor.Leave += new System.EventHandler(this.cboSupervisor_Leave);
            // 
            // lblGroupLeaderTitle
            // 
            this.lblGroupLeaderTitle.Location = new System.Drawing.Point(3, 156);
            this.lblGroupLeaderTitle.Name = "lblGroupLeaderTitle";
            this.lblGroupLeaderTitle.Size = new System.Drawing.Size(185, 29);
            this.lblGroupLeaderTitle.TabIndex = 105;
            this.lblGroupLeaderTitle.Text = "Director/Supervisor:";
            this.lblGroupLeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboReportsTo
            // 
            this.cboReportsTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReportsTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReportsTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReportsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportsTo.FormattingEnabled = true;
            this.cboReportsTo.Location = new System.Drawing.Point(194, 75);
            this.cboReportsTo.Name = "cboReportsTo";
            this.cboReportsTo.Size = new System.Drawing.Size(338, 32);
            this.cboReportsTo.TabIndex = 100;
            this.cboReportsTo.SelectedIndexChanged += new System.EventHandler(this.cboReportsTo_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(357, 29);
            this.label8.TabIndex = 95;
            this.label8.Text = "Special Instructions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(343, 29);
            this.label7.TabIndex = 94;
            this.label7.Text = "Tactical Assignments";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 234);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtTactical);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtSpecial);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Size = new System.Drawing.Size(937, 328);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 111;
            // 
            // txtTactical
            // 
            this.txtTactical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTactical.Location = new System.Drawing.Point(8, 32);
            this.txtTactical.Multiline = true;
            this.txtTactical.Name = "txtTactical";
            this.txtTactical.Size = new System.Drawing.Size(914, 125);
            this.txtTactical.TabIndex = 109;
            this.txtTactical.TextChanged += new System.EventHandler(this.txtTactical_TextChanged);
            this.txtTactical.Child = new System.Windows.Controls.TextBox();
            // 
            // txtSpecial
            // 
            this.txtSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpecial.Location = new System.Drawing.Point(8, 32);
            this.txtSpecial.Multiline = true;
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.Size = new System.Drawing.Size(914, 126);
            this.txtSpecial.TabIndex = 110;
            this.txtSpecial.TextChanged += new System.EventHandler(this.txtSpecial_TextChanged);
            this.txtSpecial.Child = new System.Windows.Controls.TextBox();
            // 
            // collapsiblePanel1
            // 
            this.collapsiblePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.collapsiblePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.collapsiblePanel1.Collapsed = true;
            this.collapsiblePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.collapsiblePanel1.Controls.Add(this.cboComms4);
            this.collapsiblePanel1.Controls.Add(this.label5);
            this.collapsiblePanel1.Controls.Add(this.cboComms1);
            this.collapsiblePanel1.Controls.Add(this.cboComms2);
            this.collapsiblePanel1.Controls.Add(this.cboComms3);
            this.collapsiblePanel1.EnableExpandCollapse = true;
            this.collapsiblePanel1.ExpandsRight = true;
            this.collapsiblePanel1.ExpandsUpward = false;
            this.collapsiblePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collapsiblePanel1.Location = new System.Drawing.Point(542, 7);
            this.collapsiblePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.collapsiblePanel1.Name = "collapsiblePanel1";
            this.collapsiblePanel1.Size = new System.Drawing.Size(387, 40);
            this.collapsiblePanel1.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.collapsiblePanel1.SizeWhenExpanded = new System.Drawing.Size(387, 251);
            this.collapsiblePanel1.TabIndex = 114;
            this.collapsiblePanel1.TitleText = "Communications Summary";
            // 
            // cboComms4
            // 
            this.cboComms4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms4.DisplayMember = "SystemIDChannelFunction";
            this.cboComms4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboComms4.FormattingEnabled = true;
            this.cboComms4.Location = new System.Drawing.Point(6, 203);
            this.cboComms4.Name = "cboComms4";
            this.cboComms4.Size = new System.Drawing.Size(365, 32);
            this.cboComms4.TabIndex = 37;
            this.cboComms4.ValueMember = "ItemID";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 42);
            this.label5.TabIndex = 33;
            this.label5.Text = "To add more options, use the Communications Plan tool";
            // 
            // cboComms1
            // 
            this.cboComms1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms1.DisplayMember = "SystemIDChannelFunction";
            this.cboComms1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboComms1.FormattingEnabled = true;
            this.cboComms1.Location = new System.Drawing.Point(6, 89);
            this.cboComms1.Name = "cboComms1";
            this.cboComms1.Size = new System.Drawing.Size(365, 32);
            this.cboComms1.TabIndex = 34;
            this.cboComms1.ValueMember = "ItemID";
            this.cboComms1.SelectedIndexChanged += new System.EventHandler(this.cboComms1_SelectedIndexChanged);
            // 
            // cboComms2
            // 
            this.cboComms2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms2.DisplayMember = "SystemIDChannelFunction";
            this.cboComms2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboComms2.FormattingEnabled = true;
            this.cboComms2.Location = new System.Drawing.Point(6, 127);
            this.cboComms2.Name = "cboComms2";
            this.cboComms2.Size = new System.Drawing.Size(365, 32);
            this.cboComms2.TabIndex = 35;
            this.cboComms2.ValueMember = "ItemID";
            // 
            // cboComms3
            // 
            this.cboComms3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms3.DisplayMember = "SystemIDChannelFunction";
            this.cboComms3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.cboComms3.FormattingEnabled = true;
            this.cboComms3.Location = new System.Drawing.Point(6, 165);
            this.cboComms3.Name = "cboComms3";
            this.cboComms3.Size = new System.Drawing.Size(365, 32);
            this.cboComms3.TabIndex = 36;
            this.cboComms3.ValueMember = "ItemID";
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = true;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.EnableExpandCollapse = true;
            this.prepAndApprovePanel1.ExpandsRight = true;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(542, 59);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 12, 12, 8, 56, 53, 426);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(387, 40);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(387, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(387, 235);
            this.prepAndApprovePanel1.TabIndex = 113;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved By";
            // 
            // EditBranchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSupervisor);
            this.Controls.Add(this.lblGroupLeaderTitle);
            this.Controls.Add(this.cboReportsTo);
            this.Controls.Add(this.collapsiblePanel1);
            this.Controls.Add(this.prepAndApprovePanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditBranchControl";
            this.Size = new System.Drawing.Size(943, 565);
            this.Load += new System.EventHandler(this.EditBranchControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.collapsiblePanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSupervisor;
        private System.Windows.Forms.Label lblGroupLeaderTitle;
        private System.Windows.Forms.ComboBox cboReportsTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboComms4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboComms1;
        private System.Windows.Forms.ComboBox cboComms3;
        private System.Windows.Forms.ComboBox cboComms2;
        private SpellBox txtTactical;
        private SpellBox txtSpecial;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PrepAndApprovePanel prepAndApprovePanel1;
        private CollapsiblePanel collapsiblePanel1;
    }
}
