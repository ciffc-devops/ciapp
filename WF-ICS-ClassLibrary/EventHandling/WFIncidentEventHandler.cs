using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
   

    public delegate void WFIncidentEventHandler(WFIncidentEventArgs e);

    public class WFIncidentEventArgs
    {
        public WFIncident item { get; set; }

        public WFIncidentEventArgs(WFIncident _item) { item = _item; }
    }

}
