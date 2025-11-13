namespace Wildfire_ICS_Assist.UtilityForms
{
    partial class EditCoordinateForm
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
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtCoordinate = new System.Windows.Forms.TextBox();
            this.lblNWCoordinateOK = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtCoordinate);
            this.splitContainer1.Panel1.Controls.Add(this.lblNWCoordinateOK);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrevious);
            this.splitContainer1.Panel2.Controls.Add(this.btnNext);
            this.splitContainer1.Size = new System.Drawing.Size(451, 194);
            this.splitContainer1.SplitterDistance = 128;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnPrevious
            // 
            this.btnPrevious.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnPrevious.Location = new System.Drawing.Point(5, 8);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(129, 46);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "Cancel";
            this.btnPrevious.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_739_check_black;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(339, 8);
            this.btnNext.Margin = new System.Windows.Forms.Padding(5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(107, 46);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "OK";
            this.btnNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // txtPolygonNW
            // 
            this.txtCoordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoordinate.Location = new System.Drawing.Point(17, 69);
            this.txtCoordinate.Name = "txtPolygonNW";
            this.txtCoordinate.Size = new System.Drawing.Size(422, 29);
            this.txtCoordinate.TabIndex = 143;
            this.txtCoordinate.TextChanged += new System.EventHandler(this.txtPolygonNW_TextChanged);
            // 
            // lblNWCoordinateOK
            // 
            this.lblNWCoordinateOK.AutoSize = true;
            this.lblNWCoordinateOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNWCoordinateOK.Location = new System.Drawing.Point(17, 101);
            this.lblNWCoordinateOK.Name = "lblNWCoordinateOK";
            this.lblNWCoordinateOK.Size = new System.Drawing.Size(101, 15);
            this.lblNWCoordinateOK.TabIndex = 144;
            this.lblNWCoordinateOK.Text = "Coordinates okay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 29);
            this.label1.TabIndex = 145;
            this.label1.Text = "Enter Coordinate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 15);
            this.label10.TabIndex = 146;
            this.label10.Text = "You can enter it in Lat/Lng, UTM, MGRS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditCoordinateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 194);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditCoordinateForm";
            this.Text = "Coordinate";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCoordinate;
        private System.Windows.Forms.Label lblNWCoordinateOK;
        private System.Windows.Forms.Label label10;
    }
}