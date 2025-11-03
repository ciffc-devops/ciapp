using System;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices.PDFExportServiceClasses.ContactsExport
{
    public class ContactExportHeader
    {
        private string _IncidentName;
        private string _IncidentNumber;
        private string _BasicLocalCommsInformation;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private string _PreparedByRoleName;
        private string _PreparedByIndividualName;
        private DateTime _PreparedDate;

        public string IncidentName { get => _IncidentName; set => _IncidentName = value; }
        public string BasicLocalCommsInformation { get => _BasicLocalCommsInformation; set => _BasicLocalCommsInformation = value; }
        public DateTime StartDate { get => _StartDate; set => _StartDate = value; }
        public DateTime EndDate { get => _EndDate; set => _EndDate = value; }
        public string PreparedByRoleName { get => _PreparedByRoleName; set => _PreparedByRoleName = value; }
        public string PreparedByIndividualName { get => _PreparedByIndividualName; set => _PreparedByIndividualName = value; }
        public DateTime PreparedDate { get => _PreparedDate; set => _PreparedDate = value; }
        public string IncidentNumber { get => _IncidentNumber; set => _IncidentNumber = value; }

        public ContactExportHeader() { }
        public ContactExportHeader(OrganizationChart chart)
        {
            if (chart == null) { return; }
          
            PreparedByRoleName = chart.PreparedByRoleName;
            PreparedByIndividualName = chart.PreparedByResourceName;
            PreparedDate = chart.DatePrepared;
        }
    }
}
