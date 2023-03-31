namespace Wildfire_ICS_Assist.CustomControls
{
    partial class CollapsiblePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsiblePanel));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExpandCollapse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(39, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(443, 30);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Panel Title Here";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // btnExpandCollapse
            // 
            this.btnExpandCollapse.BackColor = System.Drawing.Color.LightGray;
            this.btnExpandCollapse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExpandCollapse.BackgroundImage")));
            this.btnExpandCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExpandCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpandCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandCollapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExpandCollapse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExpandCollapse.Location = new System.Drawing.Point(6, 3);
            this.btnExpandCollapse.Name = "btnExpandCollapse";
            this.btnExpandCollapse.Size = new System.Drawing.Size(30, 30);
            this.btnExpandCollapse.TabIndex = 31;
            this.btnExpandCollapse.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExpandCollapse.UseVisualStyleBackColor = false;
            this.btnExpandCollapse.Click += new System.EventHandler(this.btnExpandCollapse_Click);
            // 
            // CollapsiblePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExpandCollapse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CollapsiblePanel";
            this.Size = new System.Drawing.Size(485, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExpandCollapse;
    }
}
