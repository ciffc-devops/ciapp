using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class SummaryStat
    {
        public string Category { get; set; }
        public string Text { get; set; }
        public int OpTotal { get; set; }
        public int IncidentToDate { get; set; }
        public string IncidentToDateStr {  get { if(IncidentToDate >= 0) { return IncidentToDate.ToString(); } return string.Empty; } }
        public string MoreInfo { get; set; }
        public string MoreInfoTitle { get { if (string.IsNullOrEmpty(MoreInfo)) { return string.Empty; } else { return "Info"; } } }

        public SummaryStat() { }
        public SummaryStat(string cat, string txt, string mi, int optotal = 0, int incidenttodate = 0)
        {
            Category = cat; Text = txt; OpTotal = optotal; IncidentToDate = incidenttodate; MoreInfo = mi;
        }
    }
}
