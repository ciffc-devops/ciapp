using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.NewsModels
{
    [Serializable]
    public class NewsArchive
    {
        private List<NewsItem> _newsItems = new List<NewsItem>();
        public List<NewsItem> newsItems { get => _newsItems; set => _newsItems = value; }
    }
}
