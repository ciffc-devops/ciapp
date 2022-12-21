using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{

    public delegate void BriefingEventHandler(BriefingEventArgs e);

    public class BriefingEventArgs
    {
        public Briefing item { get; set; }

        public BriefingEventArgs(Briefing _item) { item = _item; }
    }
}
