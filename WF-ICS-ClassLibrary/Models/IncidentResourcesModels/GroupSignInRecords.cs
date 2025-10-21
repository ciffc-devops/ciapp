using System;
using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models
{
    public class GroupSignInRecords
    {
        public string GroupName { get; set; }
        public List<MemberStatus> MemberStatuses { get; set; }
        public int totalPages
        {
            get
            {
                decimal divResult = Convert.ToDecimal(MemberStatuses.Count) / 6m;
                int totalPages = Convert.ToInt32(Math.Ceiling(divResult));
                //if (OpAssignments.Count() % 7 > 0) { totalPages += 1; }
                if (totalPages == 0) { totalPages = 1; }
                return totalPages;
            }
        }

        public GroupSignInRecords() { MemberStatuses = new List<MemberStatus>(); }
        public GroupSignInRecords(string name) { GroupName = name; MemberStatuses = new List<MemberStatus>(); }
    }

}
