using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void OperationalPeriodEventHandler(OperationalPeriodEventArgs e);

    public class OperationalPeriodEventArgs
    {
        public OperationalPeriod item { get; set; }

        public OperationalPeriodEventArgs(OperationalPeriod _item) { item = _item; }
    }
}
