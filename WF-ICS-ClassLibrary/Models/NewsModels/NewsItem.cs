using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.NewsModels
{
    [Serializable]
    public class NewsItem
    {
        private Guid _ID;
        private DateTime _NewsDate;
        private string _NewsTitle;
        private string _NewsText;
        private string _NewsUrl;
        private bool _ReadLocally;
        private DateTime _LastUpdatedUTC;
        private bool _Active;

        public Guid ID { get => _ID; set => _ID = value; }
        public DateTime NewsDate { get => _NewsDate; set => _NewsDate = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string NewsTitle { get => _NewsTitle; set => _NewsTitle = value; }
        public string NewsText { get => _NewsText; set => _NewsText = value; }
        public string NewsUrl { get => _NewsUrl; set => _NewsUrl = value; }
        public bool ReadLocally { get => _ReadLocally; set => _ReadLocally = value; }
        public bool UnreadLocally { get => !ReadLocally; }
        public string UnreadNotice { get { if (!ReadLocally) { return "Yes"; } else { return ""; } } }
        public bool Active { get => _Active; set => _Active = value; }
        public bool HasUrl { get => !string.IsNullOrEmpty(_NewsUrl); }
        public string ReadOnlineURL { get => "https://ciapp.icscanada.ca/news/" + ID; }

        public string PreviewText
        {
            get
            {
                if (NewsText.Length > 300)
                {
                    return NewsText.Substring(0, 300) + "...";
                }
                else { return NewsText; }
            }
        }
        public string NewsTextHTML
        {
            get
            {
                return NewsText.Replace(Environment.NewLine, "<br />");
            }
        }
        public NewsItem() { ID = Guid.NewGuid(); Active = true; NewsDate = DateTime.Now; }

    }
}
