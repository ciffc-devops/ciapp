using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildfireICSDesktopServices.OrgChartExport;

namespace WildfireICSDesktopServices.OrgChartExport
{
    public class OrgChartForExport
    {
        private OrgChartPageOne _pageOne;
        private List<OrgChartExtensionPage> _extensionPages = new List<OrgChartExtensionPage>();

        public List<OrgChartExtensionPage> ExtensionPages { get => _extensionPages; set => _extensionPages = value; }
        public OrgChartPageOne PageOne { get => _pageOne; set => _pageOne = value; }

        public int TotalPages { get => 1 + _extensionPages.Count; }
    }
}
