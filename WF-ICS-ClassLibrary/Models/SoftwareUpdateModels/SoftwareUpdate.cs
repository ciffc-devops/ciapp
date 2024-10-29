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
        //private decimal _Version;
        private string _DownloadURL;
        private string _ProjectName;
        private bool _Visible;
        private int _MajorVersion;
        private int _MinorVersion;
        private int _BuildNumber;
        private string _ZipDownloadURL;

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


        public decimal Version { get { return Convert.ToDecimal(MajorVersion.ToString() + "." + MinorVersion.ToString()); } }
        public string VersionWithBuild { get { return MajorVersion.ToString() + "." + MinorVersion.ToString() + "." + BuildNumber; } }
        public string DownloadURL { get => _DownloadURL; set => _DownloadURL = value; }
        public string ZipDownloadURL { get => _ZipDownloadURL; set => _ZipDownloadURL = value; }
        public bool HasDownloadURL { get => !string.IsNullOrEmpty(DownloadURL); }
        public string sarassistDownloadURL { get { return DownloadURL; } }
        public string ZipIfPossibleDownloadURL
        {
            get
            {
                if (!string.IsNullOrEmpty(ZipDownloadURL)) { return ZipDownloadURL; }
                else { return DownloadURL; }
            }
        }
        public bool Visible { get => _Visible; set => _Visible = value; }

        public int MajorVersion { get => _MajorVersion; set => _MajorVersion = value; }
        public int MinorVersion { get => _MinorVersion; set => _MinorVersion = value; }
        public int BuildNumber { get => _BuildNumber; set => _BuildNumber = value; }



    }
}
