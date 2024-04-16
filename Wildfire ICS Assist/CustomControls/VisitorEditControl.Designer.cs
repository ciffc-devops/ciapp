namespace Wildfire_ICS_Assist.CustomControls
{
    partial class VisitorEditControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitorEditControl));
            this.button3 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.chkAllergies = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDietary = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAgency = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtFirstName = new SpellBox();
            this.txtNOKName = new SpellBox();
            this.txtLastName = new Wildfire_ICS_Assist.CustomControls.TextBoxRequiredControl();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(559, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 136;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(6, 166);
            this.label15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 29);
            this.label15.TabIndex = 135;
            this.label15.Text = "Allergies";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAllergies
            // 
            this.chkAllergies.AutoSize = true;
            this.chkAllergies.Location = new System.Drawing.Point(202, 167);
            this.chkAllergies.Name = "chkAllergies";
            this.chkAllergies.Size = new System.Drawing.Size(141, 28);
            this.chkAllergies.TabIndex = 130;
            this.chkAllergies.Text = "Yes, allergies";
            this.chkAllergies.UseVisualStyleBackColor = true;
            this.chkAllergies.CheckedChanged += new System.EventHandler(this.chkAllergies_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 51);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 29);
            this.label11.TabIndex = 134;
            this.label11.Text = "Last Name*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 132);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(187, 29);
            this.label8.TabIndex = 133;
            this.label8.Text = "Dietary Restrictions";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDietary
            // 
            this.chkDietary.AutoSize = true;
            this.chkDietary.Location = new System.Drawing.Point(202, 133);
            this.chkDietary.Name = "chkDietary";
            this.chkDietary.Size = new System.Drawing.Size(220, 28);
            this.chkDietary.TabIndex = 129;
            this.chkDietary.Text = "Yes, dietary restrictions";
            this.chkDietary.UseVisualStyleBackColor = true;
            this.chkDietary.CheckedChanged += new System.EventHandler(this.chkDietary_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(187, 29);
            this.label13.TabIndex = 132;
            this.label13.Text = "Emergency Contact";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 128;
            this.label1.Text = "First Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(559, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 26);
            this.button2.TabIndex = 139;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnShowHelp_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 29);
            this.label3.TabIndex = 137;
            this.label3.Text = "Agency";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAgency
            // 
            this.cboAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAgency.FormattingEnabled = true;
            this.cboAgency.Location = new System.Drawing.Point(202, 92);
            this.cboAgency.Margin = new System.Windows.Forms.Padding(6);
            this.cboAgency.Name = "cboAgency";
            this.cboAgency.Size = new System.Drawing.Size(348, 32);
            this.cboAgency.TabIndex = 138;
            this.cboAgency.Leave += new System.EventHandler(this.cboAgency_Leave);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(202, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(348, 29);
            this.txtFirstName.TabIndex = 140;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged_1);
            this.txtFirstName.Child = new System.Windows.Controls.TextBox();
            // 
            // txtNOKName
            // 
            this.txtNOKName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNOKName.Location = new System.Drawing.Point(202, 200);
            this.txtNOKName.Name = "txtNOKName";
            this.txtNOKName.Size = new System.Drawing.Size(348, 29);
            this.txtNOKName.TabIndex = 141;
            this.txtNOKName.TextChanged += new System.EventHandler(this.txtNOKName_TextChanged_1);
            this.txtNOKName.Child = new System.Windows.Controls.TextBox();
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(202, 51);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(6);
            this.txtLastName.Multiline = true;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(366, 29);
            this.txtLastName.TabIndex = 142;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged_1);
            // 
            // VisitorEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtNOKName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboAgency);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkAllergies);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkDietary);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "VisitorEditControl";
            this.Size = new System.Drawing.Size(588, 235);
            this.Load += new System.EventHandler(this.VisitorEditControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkAllergies;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDietary;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboAgency;
        private System.Windows.Forms.ToolTip toolTip1;
        private SpellBox txtFirstName;
        private TextBoxRequiredControl txtLastName;
        private SpellBox txtNOKName;
    }
}
