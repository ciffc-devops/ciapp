using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    public class SoftwareUpdate
    {
        private DateTime _UpdateDate;
        private int _UpdateID;
        private string _Description;
        private decimal _Version;
        private string _DownloadURL;
        private string _ProjectName;
        private bool _Visible;
        public DateTime UpdateDate { get => _UpdateDate; set => _UpdateDate = value; }
        public int UpdateID { get => _UpdateID; set => _UpdateID = value; }

        private bool _StableRelease;
        public bool StableRelease { get => _StableRelease; set => _StableRelease = value; }

        public string Description { get => _Description; set => _Description = value; }
        public string DescriptionWithBullets
        {
            get
            {
                StringBuilder db = new StringBuilder();
                string[] lines = Regex.Split(Description, "<br />");
                bool inList = false;
                foreach (string s in lines)
                {
                    if (s.Length > 0)
                    {
                        if (s.Substring(0, 1) == "-")
                        {
                            if (!inList) { db.Append("<ul>"); inList = true; }
                            db.Append("<li>");
                            db.Append(s.Substring(1));
                            db.Append("</li>");
                        }
                        else
                        {
                            if (inList) { db.Append("</ul>"); inList = false; }
                            db.Append(s); db.Append("<br />");
                        }
                    }
                    else { db.Append("<br />"); }
                }
                if (inList) { db.Append("</ul>"); }
                return db.ToString();
            }
        }
        public string ProjectName { get => _ProjectName; set => _ProjectName = value; }

        public string DescriptionWithLinefeeds
        {
            get
            {
                return Description.Replace("<br />", "\r\n");
            }
        }


        public decimal Version { get => _Version; set => _Version = value; }
        public string DownloadURL { get => _DownloadURL; set => _DownloadURL = value; }
        public string sarassistDownloadURL { get { return DownloadURL.Replace("https://greathat.ca/sarics/", "http://www.sarassist.ca/downloads/"); } }
        public bool Visible { get => _Visible; set => _Visible = value; }



    }
}
