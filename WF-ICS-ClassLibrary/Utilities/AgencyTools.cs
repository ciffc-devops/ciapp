using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class AgencyTools
    {
        public static List<string> GetFixedAgencies(bool includeBlank = false)
        {
            List<string> list = new List<string>();

            list.Add("AB");
            list.Add("BC");
            list.Add("MB");
            list.Add("NB");
            list.Add("NL");
            list.Add("NS");
            list.Add("NT");
            list.Add("ON");
            list.Add("PC");
            list.Add("PE");
            list.Add("QC");
            list.Add("SK");
            list.Add("YT");
            list.Add("CIFFC");
            list.Add("CFS (Canadian Forest Service)");
            list.Add("DND");
            list.Add("Private");
            list.Add("AU – Australia");
            list.Add("MX – Mexico");
            list.Add("NZ – New Zealand");
            list.Add("US – United States");
            list.Add("ZA – South Africa");
            list.Add("Other Agency");

            if (includeBlank) { list.Insert(0, string.Empty); }

            return list;
        }

    }
}
