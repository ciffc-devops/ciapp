using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace WildfireICSDesktopServices.OrgChartExport
{


    public class OrgChartExtensionPage : OrgChartPage
    {

        private OrgChartEntry _ReportsToEntry;


        public OrgChartEntry ReportsToEntry { get => _ReportsToEntry; set => _ReportsToEntry = value; }

        public new OrgChartEntry GetEntryByRoleID(Guid id)
        {
            if (ReportsToEntry.RoleID == id) { return ReportsToEntry; }
            foreach (OrgChartEntry[] entryArray in Entries)
            {
                if (entryArray == null) { continue; }
                foreach (OrgChartEntry entry in entryArray)
                {
                    if (entry == null) { continue; }
                    if (entry.RoleID == id) { return entry; }
                }
            }
            return null;
        }

        public List<OrgChartEntry> AllEntries
        {
            get
            {
                List<OrgChartEntry> allEntries = new List<OrgChartEntry>();
                allEntries.Add(ReportsToEntry);
                foreach (OrgChartEntry[] entryArray in Entries)
                {
                    if(entryArray == null) { continue; }
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
