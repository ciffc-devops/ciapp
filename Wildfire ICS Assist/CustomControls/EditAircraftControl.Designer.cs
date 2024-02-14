namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditAircraftControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMakeModel = new SpellBox();
            this.txtBase = new SpellBox();
            this.txtContactNumber = new SpellBox();
            this.txtRemarks = new SpellBox();
            this.txtRegistration = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.cboIsHeli = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Registration*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Make / Model";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Base";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 32);
            this.label4.TabIndex = 11;
            this.label4.Text = "Remarks";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contact #";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMakeModel
            // 
            this.txtMakeModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMakeModel.Location = new System.Drawing.Point(162, 50);
            this.txtMakeModel.Name = "txtMakeModel";
            this.txtMakeModel.Size = new System.Drawing.Size(680, 32);
            this.txtMakeModel.TabIndex = 2;
            this.txtMakeModel.TextChanged += new System.EventHandler(this.txtMakeModel_TextChanged_1);
            this.txtMakeModel.Child = new System.Windows.Controls.TextBox();
            // 
            // txtBase
            // 
            this.txtBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBase.Location = new System.Drawing.Point(162, 88);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(680, 32);
            this.txtBase.TabIndex = 3;
            this.txtBase.TextChanged += new System.EventHandler(this.txtBase_TextChanged_1);
            this.txtBase.Child = new System.Windows.Controls.TextBox();
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumber.Location = new System.Drawing.Point(162, 126);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(680, 32);
            this.txtContactNumber.TabIndex = 4;
            this.txtContactNumber.TextChanged += new System.EventHandler(this.txtContactNumber_TextChanged_1);
            this.txtContactNumber.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.txtContactNumber_ChildChanged);
            this.txtContactNumber.Child = new System.Windows.Controls.TextBox();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(162, 202);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(680, 73);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.WordWrap = true;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged_1);
            this.txtRemarks.Child = new System.Windows.Controls.TextBox();
            // 
            // txtRegistration
            // 
            this.txtRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistration.Location = new System.Drawing.Point(162, 12);
            this.txtRegistration.Margin = new System.Windows.Forms.Padding(6);
            this.txtRegistration.Multiline = false;
            this.txtRegistration.Name = "txtRegistration";
            this.txtRegistration.Size = new System.Drawing.Size(680, 32);
            this.txtRegistration.TabIndex = 1;
            // 
            // cboIsHeli
            // 
            this.cboIsHeli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboIsHeli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsHeli.FormattingEnabled = true;
            this.cboIsHeli.Items.AddRange(new object[] {
            "Helicopter",
            "Fixed-Wing"});
            this.cboIsHeli.Location = new System.Drawing.Point(162, 164);
            this.cboIsHeli.Name = "cboIsHeli";
            this.cboIsHeli.Size = new System.Drawing.Size(680, 32);
            this.cboIsHeli.TabIndex = 5;
            this.cboIsHeli.SelectedIndexChanged += new System.EventHandler(this.cboIsHeli_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Type";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditAircraftControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboIsHeli);
            this.Controls.Add(this.txtRegistration);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtContactNumber);
            this.Controls.Add(this.txtBase);
            this.Controls.Add(this.txtMakeModel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditAircraftControl";
            this.Size = new System.Drawing.Size(845, 281);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private SpellBox txtBase;
        private SpellBox txtContactNumber;
        private SpellBox txtRemarks;
        private TextBoxRequiredControl txtRegistration;
        private SpellBox txtMakeModel;
        private System.Windows.Forms.ComboBox cboIsHeli;
        private System.Windows.Forms.Label label6;
    }
}
