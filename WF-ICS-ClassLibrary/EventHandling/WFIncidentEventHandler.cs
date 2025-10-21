using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
   

    public delegate void WFIncidentEventHandler(IncidentEventArgs e);

    public class IncidentEventArgs
    {
        public Incident item { get; set; }

        public IncidentEventArgs(Incident _item) { item = _item; }
    }

}
