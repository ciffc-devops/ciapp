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
            this.label4 = new System.Windows.Forms.Label();
            this.cboReportsTo = new System.Windows.Forms.ComboBox();
            this.txtSpecial = new System.Windows.Forms.TextBox();
            this.txtTactical = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cboComms4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboComms1 = new System.Windows.Forms.ComboBox();
            this.cboComms3 = new System.Windows.Forms.ComboBox();
            this.cboComms2 = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(194, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 40);
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
            this.cboType.Size = new System.Drawing.Size(231, 32);
            this.cboType.TabIndex = 98;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // cboName
            // 
            this.cboName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(194, 113);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(121, 32);
            this.cboName.TabIndex = 103;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
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
            this.txtName.Size = new System.Drawing.Size(100, 29);
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
            this.cboSupervisor.DisplayMember = "Name";
            this.cboSupervisor.FormattingEnabled = true;
            this.cboSupervisor.Location = new System.Drawing.Point(194, 156);
            this.cboSupervisor.Name = "cboSupervisor";
            this.cboSupervisor.Size = new System.Drawing.Size(231, 32);
            this.cboSupervisor.TabIndex = 106;
            this.cboSupervisor.ValueMember = "PersonID";
            this.cboSupervisor.SelectedIndexChanged += new System.EventHandler(this.cboSupervisor_SelectedIndexChanged);
            this.cboSupervisor.Leave += new System.EventHandler(this.cboSupervisor_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 29);
            this.label4.TabIndex = 105;
            this.label4.Text = "Director/Supervisor:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboReportsTo
            // 
            this.cboReportsTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReportsTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboReportsTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReportsTo.DisplayMember = "RoleNameForDropdown";
            this.cboReportsTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportsTo.FormattingEnabled = true;
            this.cboReportsTo.Location = new System.Drawing.Point(194, 75);
            this.cboReportsTo.Name = "cboReportsTo";
            this.cboReportsTo.Size = new System.Drawing.Size(231, 32);
            this.cboReportsTo.TabIndex = 100;
            this.cboReportsTo.ValueMember = "RoleID";
            this.cboReportsTo.SelectedIndexChanged += new System.EventHandler(this.cboReportsTo_SelectedIndexChanged);
            // 
            // txtSpecial
            // 
            this.txtSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpecial.Location = new System.Drawing.Point(7, 468);
            this.txtSpecial.Multiline = true;
            this.txtSpecial.Name = "txtSpecial";
            this.txtSpecial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecial.Size = new System.Drawing.Size(787, 89);
            this.txtSpecial.TabIndex = 97;
            this.txtSpecial.TextChanged += new System.EventHandler(this.txtSpecial_TextChanged);
            // 
            // txtTactical
            // 
            this.txtTactical.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTactical.Location = new System.Drawing.Point(8, 263);
            this.txtTactical.Multiline = true;
            this.txtTactical.Name = "txtTactical";
            this.txtTactical.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTactical.Size = new System.Drawing.Size(786, 146);
            this.txtTactical.TabIndex = 96;
            this.txtTactical.TextChanged += new System.EventHandler(this.txtTactical_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(357, 29);
            this.label8.TabIndex = 95;
            this.label8.Text = "Special Instructions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(343, 29);
            this.label7.TabIndex = 94;
            this.label7.Text = "Tactical Assignments";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboComms4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cboComms1);
            this.panel2.Controls.Add(this.cboComms3);
            this.panel2.Controls.Add(this.cboComms2);
            this.panel2.Location = new System.Drawing.Point(431, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 245);
            this.panel2.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(330, 29);
            this.label6.TabIndex = 38;
            this.label6.Text = "Communications Summary";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboComms4
            // 
            this.cboComms4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms4.DisplayMember = "SystemIDChannelFunction";
            this.cboComms4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms4.FormattingEnabled = true;
            this.cboComms4.Location = new System.Drawing.Point(19, 197);
            this.cboComms4.Name = "cboComms4";
            this.cboComms4.Size = new System.Drawing.Size(325, 32);
            this.cboComms4.TabIndex = 37;
            this.cboComms4.ValueMember = "ItemID";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 42);
            this.label5.TabIndex = 33;
            this.label5.Text = "To add more options, use the Communications Plan tool";
            // 
            // cboComms1
            // 
            this.cboComms1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms1.DisplayMember = "SystemIDChannelFunction";
            this.cboComms1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms1.FormattingEnabled = true;
            this.cboComms1.Location = new System.Drawing.Point(19, 83);
            this.cboComms1.Name = "cboComms1";
            this.cboComms1.Size = new System.Drawing.Size(325, 32);
            this.cboComms1.TabIndex = 34;
            this.cboComms1.ValueMember = "ItemID";
            this.cboComms1.SelectedIndexChanged += new System.EventHandler(this.cboComms1_SelectedIndexChanged);
            // 
            // cboComms3
            // 
            this.cboComms3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms3.DisplayMember = "SystemIDChannelFunction";
            this.cboComms3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms3.FormattingEnabled = true;
            this.cboComms3.Location = new System.Drawing.Point(19, 159);
            this.cboComms3.Name = "cboComms3";
            this.cboComms3.Size = new System.Drawing.Size(325, 32);
            this.cboComms3.TabIndex = 36;
            this.cboComms3.ValueMember = "ItemID";
            // 
            // cboComms2
            // 
            this.cboComms2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboComms2.DisplayMember = "SystemIDChannelFunction";
            this.cboComms2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComms2.FormattingEnabled = true;
            this.cboComms2.Location = new System.Drawing.Point(19, 121);
            this.cboComms2.Name = "cboComms2";
            this.cboComms2.Size = new System.Drawing.Size(325, 32);
            this.cboComms2.TabIndex = 35;
            this.cboComms2.ValueMember = "ItemID";
            // 
            // EditBranchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSupervisor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboReportsTo);
            this.Controls.Add(this.txtSpecial);
            this.Controls.Add(this.txtTactical);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditBranchControl";
            this.Size = new System.Drawing.Size(812, 569);
            this.Load += new System.EventHandler(this.EditBranchControl_Load);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboReportsTo;
        private System.Windows.Forms.TextBox txtSpecial;
        private System.Windows.Forms.TextBox txtTactical;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboComms4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboComms1;
        private System.Windows.Forms.ComboBox cboComms3;
        private System.Windows.Forms.ComboBox cboComms2;
    }
}
