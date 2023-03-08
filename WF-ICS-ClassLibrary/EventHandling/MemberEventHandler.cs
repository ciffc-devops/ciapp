using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void MemberEventHandler(MemberEventArgs e);

    public class MemberEventArgs
    {
        public Guid MemberID { get; set; }
        public CheckInRecord signInRecord { get; set; }
        public Personnel teamMember { get; set; }

        public MemberEventArgs(Guid _memberID) { MemberID = _memberID; }
        public MemberEventArgs(CheckInRecord _record) { signInRecord = _record; if (_record != null) { MemberID = _record.ResourceID; } }
        public MemberEventArgs(Personnel _member) { teamMember = _member; if (teamMember != null) { MemberID = teamMember.PersonID; } }
    }
}
