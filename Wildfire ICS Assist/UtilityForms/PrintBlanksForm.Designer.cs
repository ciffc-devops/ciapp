namespace Wildfire_ICS_Assist.UtilityForms
{
    partial class PrintBlanksForm
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
            this.dgvForms = new System.Windows.Forms.DataGridView();
            this.colFormNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInIap = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chkAddOpInfo = new System.Windows.Forms.CheckBox();
            this.chkAddIncidentInfoToForms = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvForms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkAddOpInfo);
            this.splitContainer1.Panel2.Controls.Add(this.chkAddIncidentInfoToForms);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 394;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvForms
            // 
            this.dgvForms.AllowUserToAddRows = false;
            this.dgvForms.AllowUserToResizeColumns = false;
            this.dgvForms.AllowUserToResizeRows = false;
            this.dgvForms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFormNumber,
            this.colFormName,
            this.colInIap,
            this.colQty});
            this.dgvForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvForms.Location = new System.Drawing.Point(0, 0);
            this.dgvForms.Name = "dgvForms";
            this.dgvForms.RowHeadersVisible = false;
            this.dgvForms.RowTemplate.Height = 35;
            this.dgvForms.Size = new System.Drawing.Size(800, 394);
            this.dgvForms.TabIndex = 0;
            // 
            // colFormNumber
            // 
            this.colFormNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colFormNumber.DataPropertyName = "FormNumberWithModifier";
            this.colFormNumber.HeaderText = "#";
            this.colFormNumber.Name = "colFormNumber";
            this.colFormNumber.ReadOnly = true;
            this.colFormNumber.Width = 45;
            // 
            // colFormName
            // 
            this.colFormName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFormName.DataPropertyName = "FormName";
            this.colFormName.HeaderText = "Name";
            this.colFormName.Name = "colFormName";
            this.colFormName.ReadOnly = true;
            // 
            // colInIap
            // 
            this.colInIap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colInIap.DataPropertyName = "IsInIAP";
            this.colInIap.HeaderText = "IAP";
            this.colInIap.Name = "colInIap";
            this.colInIap.ReadOnly = true;
            this.colInIap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colInIap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colInIap.Width = 64;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.Width = 150;
            // 
            // chkAddOpInfo
            // 
            this.chkAddOpInfo.AutoSize = true;
            this.chkAddOpInfo.Checked = true;
            this.chkAddOpInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddOpInfo.Location = new System.Drawing.Point(320, 11);
            this.chkAddOpInfo.Name = "chkAddOpInfo";
            this.chkAddOpInfo.Size = new System.Drawing.Size(261, 28);
            this.chkAddOpInfo.TabIndex = 59;
            this.chkAddOpInfo.Text = "Add Op Period Info to forms";
            this.chkAddOpInfo.UseVisualStyleBackColor = true;
            // 
            // chkAddIncidentInfoToForms
            // 
            this.chkAddIncidentInfoToForms.AutoSize = true;
            this.chkAddIncidentInfoToForms.Checked = true;
            this.chkAddIncidentInfoToForms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddIncidentInfoToForms.Location = new System.Drawing.Point(12, 11);
            this.chkAddIncidentInfoToForms.Name = "chkAddIncidentInfoToForms";
            this.chkAddIncidentInfoToForms.Size = new System.Drawing.Size(302, 28);
            this.chkAddIncidentInfoToForms.TabIndex = 58;
            this.chkAddIncidentInfoToForms.Text = "Add Incident identifier(s) to forms";
            this.chkAddIncidentInfoToForms.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrint.Location = new System.Drawing.Point(653, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(144, 42);
            this.btnPrint.TabIndex = 57;
            this.btnPrint.Tag = "ViewPDF";
            this.btnPrint.Text = "View PDFs";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.FileName = "BlankICSForms.pdf";
            this.saveFileDialog1.Filter = "PDF Files|*.pdf";
            // 
            // PrintBlanksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PrintBlanksForm";
            this.Text = "Print Blank PDF ICS Forms";
            this.Load += new System.EventHandler(this.PrintBlanksForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvForms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvForms;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colInIap;
        private System.Windows.Forms.DataGridViewComboBoxColumn colQty;
        private System.Windows.Forms.CheckBox chkAddIncidentInfoToForms;
        private System.Windows.Forms.CheckBox chkAddOpInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}