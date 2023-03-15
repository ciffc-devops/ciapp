using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void DemobEventHandler(DemobEventArgs e);

    public class DemobEventArgs
    {
        public DemobilizationRecord item { get; set; }

        public DemobEventArgs(DemobilizationRecord _item) { item = _item; }
    }
}
