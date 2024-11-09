namespace Wildfire_ICS_Assist.NewsForms
{
    partial class NewsListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNews = new System.Windows.Forms.DataGridView();
            this.colNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewsTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNews
            // 
            this.dgvNews.AllowUserToAddRows = false;
            this.dgvNews.AllowUserToDeleteRows = false;
            this.dgvNews.AllowUserToResizeColumns = false;
            this.dgvNews.AllowUserToResizeRows = false;
            this.dgvNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNews.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNew,
            this.colNewsDate,
            this.colNewsTitle,
            this.colView});
            this.dgvNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNews.Location = new System.Drawing.Point(0, 0);
            this.dgvNews.MultiSelect = false;
            this.dgvNews.Name = "dgvNews";
            this.dgvNews.ReadOnly = true;
            this.dgvNews.RowHeadersVisible = false;
            this.dgvNews.RowTemplate.Height = 30;
            this.dgvNews.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNews.Size = new System.Drawing.Size(800, 450);
            this.dgvNews.TabIndex = 1;
            this.dgvNews.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellContentClick);
            this.dgvNews.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNews_CellContentDoubleClick);
            this.dgvNews.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNews_CellFormatting);
            this.dgvNews.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNews_CellMouseDoubleClick);
            this.dgvNews.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvNews_MouseUp);
            // 
            // colNew
            // 
            this.colNew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colNew.DataPropertyName = "UnreadNotice";
            this.colNew.HeaderText = "New";
            this.colNew.Name = "colNew";
            this.colNew.ReadOnly = true;
            this.colNew.Width = 74;
            // 
            // colNewsDate
            // 
            this.colNewsDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colNewsDate.DataPropertyName = "NewsDate";
            dataGridViewCellStyle1.Format = "yyyy-MMM-dd";
            this.colNewsDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNewsDate.HeaderText = "Date";
            this.colNewsDate.Name = "colNewsDate";
            this.colNewsDate.ReadOnly = true;
            this.colNewsDate.Width = 73;
            // 
            // colNewsTitle
            // 
            this.colNewsTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNewsTitle.DataPropertyName = "NewsTitle";
            this.colNewsTitle.HeaderText = "Title";
            this.colNewsTitle.Name = "colNewsTitle";
            this.colNewsTitle.ReadOnly = true;
            // 
            // colView
            // 
            this.colView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colView.HeaderText = "";
            this.colView.Name = "colView";
            this.colView.ReadOnly = true;
            this.colView.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colView.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colView.Text = "View";
            this.colView.UseColumnTextForButtonValue = true;
            this.colView.Width = 19;
            // 
            // NewsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvNews);
            this.Name = "NewsListForm";
            this.Text = "News";
            this.Load += new System.EventHandler(this.NewsListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNews)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNews;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewsTitle;
        private System.Windows.Forms.DataGridViewButtonColumn colView;
    }
}