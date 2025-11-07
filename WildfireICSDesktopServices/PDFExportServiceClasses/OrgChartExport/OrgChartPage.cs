using System;

namespace WildfireICSDesktopServices.OrgChartExport
{
    public class OrgChartPage
    {
        private Guid _ID;
        private int _PageNumber;
        private string _IncidentName;
        private string _IncidentNumber;
        private string _PreparedByRoleName;
        private string _PreparedByIndividualName;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private DateTime _DatePrepared;

        private OrgChartEntry[][] _Entries = new OrgChartEntry[OrgChartExportTools.ChildrenPerExtensionPage][];

        public Guid ID { get => _ID; set => _ID = value; }
        public string IncidentName { get => _IncidentName; set => _IncidentName = value; }
        public string PreparedByRoleName { get => _PreparedByRoleName; set => _PreparedByRoleName = value; }
        public string PreparedByIndividualName { get => _PreparedByIndividualName; set => _PreparedByIndividualName = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime EndDate { get => _EndDate; set => _EndDate = value; }

        public OrgChartEntry[][] Entries { get => _Entries; set => _Entries = value; }
        public int PageNumber { get => _PageNumber; set => _PageNumber = value; }
        public string IncidentNumber { get => _IncidentNumber; set => _IncidentNumber = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }

        public OrgChartEntry GetEntryByRoleID(Guid id)
        {
            foreach (OrgChartEntry[] entryArray in Entries)
            {
                foreach (OrgChartEntry entry in entryArray)
                {
                    if (entry.RoleID == id) { return entry; }
                }
            }
            return null;
        }
    }
}
