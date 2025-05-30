using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels
{
    public class SummaryAgencyEntry
    {
        private string _AgencyName;
        private int _AdditionalPersonnel;
        private List<SummaryResourceEntry> _Resources = new List<SummaryResourceEntry>();

        public string AgencyName { get => _AgencyName; set => _AgencyName = value; }
        public int AdditionalPersonnel { get => _AdditionalPersonnel; set => _AdditionalPersonnel = value; }
        public List<SummaryResourceEntry> Resources { get => _Resources; set => _Resources = value; }
    }
}
