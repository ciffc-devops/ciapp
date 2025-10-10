namespace WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels
{
    public class SummaryResourceEntry
    {
        private string _ResourceDisplayName;
        private string _ResourceTypeName;
        private string _ResourceKindName;

        private int _ResourceCount;
        private int _PersonnelCount;
        private string _AgencyName;

        public string ResourceDisplayName { get => _ResourceDisplayName; set => _ResourceDisplayName = value; }
        public int ResourceCount { get => _ResourceCount; set => _ResourceCount = value; }
        public int PersonnelCount { get => _PersonnelCount; set => _PersonnelCount = value; }
        public string AgencyName { get => _AgencyName; set => _AgencyName = value; }
        public string ResourceKindName { get => _ResourceKindName; set => _ResourceKindName = value; }
        public string ResourceTypeName { get => _ResourceTypeName; set => _ResourceTypeName = value; }
    }
}
