using System;

namespace WF_ICS_ClassLibrary.Models
{
    public class DownloadRecord
    {
        public DownloadRecord() { }
        public DateTime DownloadDate { get; set; }
        public string DownloadIP { get; set; }
        public string DownloadEmail { get; set; }
        public string DownloadVersion { get; set; }
        private string _Agency;
        public string Agency { get => _Agency; set => _Agency = value; }
        private string _ProjectName;
        public string ProjectName { get => _ProjectName; set => _ProjectName = value; }
        private string _DownloadMethod;
        public string DownloadMethod { get => _DownloadMethod; set => _DownloadMethod = value; }
    }
}
