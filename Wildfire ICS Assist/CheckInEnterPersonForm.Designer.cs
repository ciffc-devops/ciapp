namespace Wildfire_ICS_Assist
{
    partial class CheckInEnterPersonForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlSavedPersonnel = new System.Windows.Forms.Panel();
            this.btnSelectSavedPerson = new System.Windows.Forms.Button();
            this.cboSavedPersonnel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.personnelEditControl1 = new Wildfire_ICS_Assist.CustomControls.PersonnelEditControl();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectNewPerson = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlSavedPersonnel.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnBack);
            this.splitContainer1.Size = new System.Drawing.Size(630, 1026);
            this.splitContainer1.SplitterDistance = 958;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlSavedPersonnel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.personnelEditControl1);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.btnSelectNewPerson);
            this.splitContainer2.Size = new System.Drawing.Size(630, 958);
            this.splitContainer2.SplitterDistance = 98;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlSavedPersonnel
            // 
            this.pnlSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedPersonnel.BackColor = System.Drawing.Color.White;
            this.pnlSavedPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedPersonnel.Controls.Add(this.btnSelectSavedPerson);
            this.pnlSavedPersonnel.Controls.Add(this.cboSavedPersonnel);
            this.pnlSavedPersonnel.Controls.Add(this.label6);
            this.pnlSavedPersonnel.Location = new System.Drawing.Point(12, 12);
            this.pnlSavedPersonnel.Name = "pnlSavedPersonnel";
            this.pnlSavedPersonnel.Size = new System.Drawing.Size(606, 80);
            this.pnlSavedPersonnel.TabIndex = 10;
            // 
            // btnSelectSavedPerson
            // 
            this.btnSelectSavedPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSavedPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectSavedPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectSavedPerson.Location = new System.Drawing.Point(465, 27);
            this.btnSelectSavedPerson.Name = "btnSelectSavedPerson";
            this.btnSelectSavedPerson.Size = new System.Drawing.Size(130, 40);
            this.btnSelectSavedPerson.TabIndex = 5;
            this.btnSelectSavedPerson.Text = "Select";
            this.btnSelectSavedPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectSavedPerson.UseVisualStyleBackColor = true;
            this.btnSelectSavedPerson.Click += new System.EventHandler(this.btnSelectSavedPerson_Click);
            // 
            // cboSavedPersonnel
            // 
            this.cboSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedPersonnel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedPersonnel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedPersonnel.DisplayMember = "NameWithAgency";
            this.cboSavedPersonnel.FormattingEnabled = true;
            this.cboSavedPersonnel.Location = new System.Drawing.Point(8, 32);
            this.cboSavedPersonnel.Name = "cboSavedPersonnel";
            this.cboSavedPersonnel.Size = new System.Drawing.Size(451, 32);
            this.cboSavedPersonnel.TabIndex = 4;
            this.cboSavedPersonnel.ValueMember = "PersonID";
            this.cboSavedPersonnel.Leave += new System.EventHandler(this.cboSavedPersonnel_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(598, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Saved Personnel";
            // 
            // personnelEditControl1
            // 
            this.personnelEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personnelEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.personnelEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personnelEditControl1.Location = new System.Drawing.Point(17, 35);
            this.personnelEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.personnelEditControl1.MinimumSize = new System.Drawing.Size(442, 702);
            this.personnelEditControl1.Name = "personnelEditControl1";
            this.personnelEditControl1.Size = new System.Drawing.Size(601, 769);
            this.personnelEditControl1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "New Personnel";
            // 
            // btnSelectNewPerson
            // 
            this.btnSelectNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNewPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectNewPerson.Location = new System.Drawing.Point(488, 813);
            this.btnSelectNewPerson.Name = "btnSelectNewPerson";
            this.btnSelectNewPerson.Size = new System.Drawing.Size(130, 40);
            this.btnSelectNewPerson.TabIndex = 11;
            this.btnSelectNewPerson.Text = "Select";
            this.btnSelectNewPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectNewPerson.UseVisualStyleBackColor = true;
            this.btnSelectNewPerson.Click += new System.EventHandler(this.btnSelectNewPerson_Click);
            // 
            // btnBack
            // 
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnBack.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnBack.Location = new System.Drawing.Point(6, 6);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(124, 51);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Cancel";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // CheckInEnterPersonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBack;
            this.ClientSize = new System.Drawing.Size(630, 1026);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(646, 875);
            this.Name = "CheckInEnterPersonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select or Enter a Person";
            this.Load += new System.EventHandler(this.PersonnelEnterPersonForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlSavedPersonnel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlSavedPersonnel;
        private System.Windows.Forms.Button btnSelectSavedPerson;
        private System.Windows.Forms.ComboBox cboSavedPersonnel;
        private System.Windows.Forms.Label label6;
        private CustomControls.PersonnelEditControl personnelEditControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectNewPerson;
        private System.Windows.Forms.Button btnBack;
    }
}