using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models.NewsModels;

namespace Wildfire_ICS_Assist.NewsForms
{
    public partial class NewsListForm : BaseForm
    {
        public NewsListForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);
        }

        private void NewsListForm_Load(object sender, EventArgs e)
        {
            dgvNews.AutoGenerateColumns = false;
            dgvNews.DataSource = Program.newsService.newsArchive;
            dgvNews.ClearSelection();
            dgvNews.CurrentCell = null;

        }

        private void dgvNews_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                NewsItem news = (NewsItem)dgvNews.Rows[e.RowIndex].DataBoundItem;
                using (NewsViewForm form = new NewsViewForm())
                {
                    form.CurrentNews = news;
                    form.ShowDialog();
                }
            }

        }

        private void dgvNews_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NewsItem news = (NewsItem)dgvNews.Rows[e.RowIndex].DataBoundItem;
                using (NewsViewForm form = new NewsViewForm())
                {
                    form.CurrentNews = news;
                    form.ShowDialog();
                }
            }
        }

        private void dgvNews_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                NewsItem news = (NewsItem)dgvNews.Rows[e.RowIndex].DataBoundItem;
                using (NewsViewForm form = new NewsViewForm())
                {
                    form.CurrentNews = news;
                    form.ShowDialog();
                }
            }
        }

        private void dgvNews_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNews.Rows.Count > 0 && e.RowIndex <= dgvNews.Rows.Count && dgvNews.Rows[e.RowIndex] != null)
            {
                DataGridViewRow row = dgvNews.Rows[e.RowIndex];


                NewsItem news = (NewsItem)row.DataBoundItem;
                if (!news.ReadLocally)
                {
                    row.Cells[0].Style.BackColor = Program.ErrorColor;
                }
                else { row.Cells[0].Style.BackColor = row.Cells[1].Style.BackColor; }



            }
        }

        private void dgvNews_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgvNews.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.None)
                {
                    dgvNews.ClearSelection();
                    dgvNews.CurrentCell = null;
                }
            }
        }
    }
}
