namespace Wildfire_ICS_Assist.CustomControls
{
    partial class EditTeamAssignmentTemplateControl
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
            this.txtAssignmentName = new System.Windows.Forms.TextBox();
            this.txtTacticalAssignment = new System.Windows.Forms.TextBox();
            this.txtSpecialInstructions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAssignmentType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAssignmentName
            // 
            this.txtAssignmentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssignmentName.Location = new System.Drawing.Point(198, 0);
            this.txtAssignmentName.Margin = new System.Windows.Forms.Padding(6);
            this.txtAssignmentName.Name = "txtAssignmentName";
            this.txtAssignmentName.Size = new System.Drawing.Size(187, 29);
            this.txtAssignmentName.TabIndex = 0;
            this.txtAssignmentName.TextChanged += new System.EventHandler(this.txtAssignmentName_TextChanged);
            // 
            // txtTacticalAssignment
            // 
            this.txtTacticalAssignment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTacticalAssignment.Location = new System.Drawing.Point(198, 78);
            this.txtTacticalAssignment.Margin = new System.Windows.Forms.Padding(6);
            this.txtTacticalAssignment.Multiline = true;
            this.txtTacticalAssignment.Name = "txtTacticalAssignment";
            this.txtTacticalAssignment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTacticalAssignment.Size = new System.Drawing.Size(187, 147);
            this.txtTacticalAssignment.TabIndex = 2;
            this.txtTacticalAssignment.TextChanged += new System.EventHandler(this.txtTacticalAssignment_TextChanged);
            // 
            // txtSpecialInstructions
            // 
            this.txtSpecialInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpecialInstructions.Location = new System.Drawing.Point(198, 236);
            this.txtSpecialInstructions.Margin = new System.Windows.Forms.Padding(6);
            this.txtSpecialInstructions.Multiline = true;
            this.txtSpecialInstructions.Name = "txtSpecialInstructions";
            this.txtSpecialInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecialInstructions.Size = new System.Drawing.Size(187, 120);
            this.txtSpecialInstructions.TabIndex = 3;
            this.txtSpecialInstructions.TextChanged += new System.EventHandler(this.txtSpecialInstructions_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Resource Name*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Assignment Type";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tactical Assignment";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Special Instructions";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboAssignmentType
            // 
            this.cboAssignmentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAssignmentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAssignmentType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAssignmentType.FormattingEnabled = true;
            this.cboAssignmentType.Location = new System.Drawing.Point(198, 37);
            this.cboAssignmentType.Name = "cboAssignmentType";
            this.cboAssignmentType.Size = new System.Drawing.Size(187, 32);
            this.cboAssignmentType.TabIndex = 1;
            this.cboAssignmentType.SelectedIndexChanged += new System.EventHandler(this.cboAssignmentType_SelectedIndexChanged);
            this.cboAssignmentType.Leave += new System.EventHandler(this.cboAssignmentType_Leave);
            // 
            // EditTeamAssignmentTemplateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cboAssignmentType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSpecialInstructions);
            this.Controls.Add(this.txtTacticalAssignment);
            this.Controls.Add(this.txtAssignmentName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditTeamAssignmentTemplateControl";
            this.Size = new System.Drawing.Size(385, 356);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssignmentName;
        private System.Windows.Forms.TextBox txtTacticalAssignment;
        private System.Windows.Forms.TextBox txtSpecialInstructions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAssignmentType;
    }
}
