using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models.NewsModels;

namespace Wildfire_ICS_Assist.NewsForms
{
    public partial class NewsViewForm : BaseForm
    {
        private NewsItem _CurrentNews = new NewsItem();
        public NewsItem CurrentNews { get => _CurrentNews; set { _CurrentNews = value; LoadCurrentNews(); } }

        public NewsViewForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnViewOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CurrentNews.ReadOnlineURL);

        }

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(CurrentNews.NewsUrl);

        }
        private void LoadCurrentNews()
        {
            lblTitle.Text = CurrentNews.NewsTitle;
            lblDate.Text = CurrentNews.NewsDate.ToString(Program.DateFormat);
            bool containsR = CurrentNews.NewsText.Contains("\r");
            bool containsN = CurrentNews.NewsText.Contains("\n");
            bool containsENL = CurrentNews.NewsText.Contains(Environment.NewLine);


            txtNewsText.Text = CurrentNews.NewsText.Replace("\n", Environment.NewLine);
            btnMoreInfo.Visible = CurrentNews.HasUrl;

            CurrentNews.ReadLocally = true;
            Program.newsService.UpsertNewsItem(CurrentNews);


        }

    }
}
