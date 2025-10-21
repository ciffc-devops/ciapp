namespace WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels
{
    public class SummaryResourceTotal
    {
        private string _ResourceKindTypeName;
        private int _ResourceCount;
        private int _PersonnelCount;

        public string ResourceKindTypeName { get => _ResourceKindTypeName; set => _ResourceKindTypeName = value; }
        public int ResourceCount { get => _ResourceCount; set => _ResourceCount = value; }
        public int PersonnelCount { get => _PersonnelCount; set => _PersonnelCount = value; }
    }
}
