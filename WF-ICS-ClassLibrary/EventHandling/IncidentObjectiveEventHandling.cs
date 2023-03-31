using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    internal class IncidentObjectiveEventHandling
    {
    }

    public delegate void IncidentObjectiveEventHandler(IncidentObjectiveEventArgs e);

    public class IncidentObjectiveEventArgs
    {
        public IncidentObjective item { get; set; }

        public IncidentObjectiveEventArgs(IncidentObjective _item) { item = _item; }
    }

    internal class IncidentObjectivesSheetEventHandling
    {
    }

    public delegate void IncidentObjectivesSheetEventHandler(IncidentObjectivesSheetEventArgs e);

    public class IncidentObjectivesSheetEventArgs
    {
        public IncidentObjectivesSheet item { get; set; }

        public IncidentObjectivesSheetEventArgs(IncidentObjectivesSheet _item) { item = _item; }
    }
}
