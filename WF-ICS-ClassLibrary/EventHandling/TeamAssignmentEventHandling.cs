using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void TeamAssignmentEventHandler(TeamAssignmentEventArgs e);

    public class TeamAssignmentEventArgs
    {
        public TeamAssignment item { get; set; }

        public TeamAssignmentEventArgs(TeamAssignment _item) { item = _item; }
    }
}
