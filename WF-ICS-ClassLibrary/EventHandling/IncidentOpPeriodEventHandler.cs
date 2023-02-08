using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.EventHandling
{

    public delegate void IncidenOpPeriodChangedEventHandler(IncidentOpPeriodChangedEventArgs e);


    public class IncidentOpPeriodChangedEventArgs : EventArgs
    {
        public int NewOpPeriod { get; set; }

        public IncidentOpPeriodChangedEventArgs() { }
        public IncidentOpPeriodChangedEventArgs(int newOp) { NewOpPeriod = newOp; }
    }
}
