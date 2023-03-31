using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    internal class AircraftEventHandling
    {
    }

    public delegate void AircraftEventHandler(AircraftEventArgs e);

    public class AircraftEventArgs
    {
        public Aircraft item { get; set; }

        public AircraftEventArgs(Aircraft _item) { item = _item; }
    }

    internal class AircraftsOperationsSummaryEventHandling
    {
    }

    public delegate void AircraftsOperationsSummaryEventHandler(AirOperationsSummaryEventArgs e);

    public class AirOperationsSummaryEventArgs
    {
        public AirOperationsSummary item { get; set; }

        public AirOperationsSummaryEventArgs(AirOperationsSummary _item) { item = _item; }
    }
}
