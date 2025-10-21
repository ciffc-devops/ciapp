using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices.OrgChartExport
{
    public class OrgChartEntry
    {
        private Guid _ID;
        private Guid _RoleID;
        private Guid _GenericRoleID;
        private string _RoleName;
        private string _IndividualName;
        private List<int> _SeePageNumbers = new List<int>();
        private string _AgencyName;

        public Guid ID { get => _ID; set => _ID = value; }
        public Guid RoleID { get => _RoleID; set => _RoleID = value; }
        public Guid GenericRoleID { get => _GenericRoleID; set => _GenericRoleID = value; }
        public string RoleName { get => _RoleName; set => _RoleName = value; }
        public string IndividualName { get => _IndividualName; set => _IndividualName = value; }
        public string IndividualNameWithSeePage
        {
            get
            {
                if (SeePageNumbers.Any())
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (int page in SeePageNumbers)
                    {
                        if (sb.Length > 0) { sb.Append(", "); }
                        sb.Append(page.ToString());
                    }

                    return IndividualName + " / See Page(s) " + sb.ToString();
                }
                else { return IndividualName; }
            }
        }
        public List<int> SeePageNumbers { get => _SeePageNumbers;  }
        public string AgencyName { get => _AgencyName; set => _AgencyName = value; }

        public OrgChartEntry()
        {
            ID = Guid.NewGuid();
        }

        public OrgChartEntry(ICSRole role, int seePageNumber = 0)
        {
            RoleID = role.RoleID;
            GenericRoleID = role.GenericRoleID;
            RoleName = role.RoleName;
            IndividualName = role.IndividualName;
           
            ID = Guid.NewGuid();
            if (seePageNumber > 0)
            {
                SeePageNumbers.Add(seePageNumber);
            }
        }

        public void AddSeePageIfNeeded(int newSeePage)
        {
            if(!SeePageNumbers.Any(o=>o == newSeePage))
            {
                SeePageNumbers.Add(newSeePage);
            }
        }
    }
}
