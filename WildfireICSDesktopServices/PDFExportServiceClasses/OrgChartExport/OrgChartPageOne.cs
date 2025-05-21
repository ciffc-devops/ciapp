using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace WildfireICSDesktopServices.OrgChartExport
{
    public class OrgChartPageOne : OrgChartPage
    {

        private OrgChartEntry _LiaisonOfficer;
        private OrgChartEntry _SafetyOfficer;
        private OrgChartEntry _PublicInformationOfficer;

        private OrgChartEntry[] _IncidentCommanders = new OrgChartEntry[3];


        public OrgChartEntry LiaisonOfficer { get => _LiaisonOfficer; set => _LiaisonOfficer = value; }
        public OrgChartEntry SafetyOfficer { get => _SafetyOfficer; set => _SafetyOfficer = value; }
        public OrgChartEntry PublicInformationOfficer { get => _PublicInformationOfficer; set => _PublicInformationOfficer = value; }
        public OrgChartEntry[] IncidentCommanders { get => _IncidentCommanders; set => _IncidentCommanders = value; }
        public string IncidentCommanderNamesString
        {
            get
            {
                string str = string.Empty;
                for (int x = 0; x < _IncidentCommanders.Length; x++)
                {
                    if (_IncidentCommanders[x] != null && !string.IsNullOrEmpty(_IncidentCommanders[x].IndividualName))
                    {
                        if (str.Length > 0) { str += " & "; }
                        str += _IncidentCommanders[x].IndividualName;
                    }
                }
                return str;
            }
        }
        public string IncidentCommanderTilesString
        {
            get
            {
                if (IncidentCommanders.Count(o => o != null) <= 1) { return "Incident Commander"; }
                else
                {
                    StringBuilder sb = new StringBuilder(0);
                    sb.Append("Unified Command - ");
                    for (int x = 0; x < _IncidentCommanders.Length; x++)
                    {
                        if (_IncidentCommanders[x] != null)
                        {

                            if (!string.IsNullOrEmpty(_IncidentCommanders[x].AgencyName))
                            {
                                if (x > 0) { sb.Append(" & "); }

                                sb.Append(_IncidentCommanders[x].AgencyName);
                            }
                        }
                    }
                    return sb.ToString();
                }
            }
        }

        public new OrgChartEntry GetEntryByRoleID(Guid id)
        {
            if(SafetyOfficer.RoleID == id) { return SafetyOfficer; }    
            if (PublicInformationOfficer.RoleID == id) { return PublicInformationOfficer; }
            if (LiaisonOfficer.RoleID == id) { return LiaisonOfficer; }
            foreach (OrgChartEntry[] entryArray in Entries)
            {
                foreach (OrgChartEntry entry in entryArray)
                {
                    if(entry == null) { continue; }
                    if (entry.RoleID == id) { return entry; }
                }
            }
           foreach(OrgChartEntry entry in IncidentCommanders)
            {
                if (entry == null) { continue; }
                if (entry.RoleID == id) { return entry; }
            }
            return null;
        }

        public List<OrgChartEntry> AllEntries
        {
            get
            {
                List<OrgChartEntry> allEntries = new List<OrgChartEntry>();
                allEntries.Add(LiaisonOfficer);
                allEntries.Add(SafetyOfficer);
                allEntries.Add(PublicInformationOfficer);
                foreach (OrgChartEntry entry in IncidentCommanders)
                {
                    if (entry != null) { allEntries.Add(entry); }
                }


                foreach (OrgChartEntry[] entryArray in Entries)
                {
                    foreach (OrgChartEntry entry in entryArray)
                    {
                        if (entry == null) { continue; }
                        allEntries.Add(entry);
                    }
                }
                return allEntries;
            }
        }
    }
}
