using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;

namespace WF_ICS_ClassLibrary.EventHandling
{
   

    public delegate void IncidentSummaryEventHandler(IncidentSummaryEventArgs e);

    public class IncidentSummaryEventArgs
    {
        public IncidentStatusSummary item { get; set; }

        public IncidentSummaryEventArgs(IncidentStatusSummary _item) { item = _item; }
    }
}
