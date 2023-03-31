using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void PositionLogEventHandler(PositionLogEventArgs e);

    public class PositionLogEventArgs
    {
        public PositionLogEntry item { get; set; }

        public PositionLogEventArgs(PositionLogEntry _item) { item = _item; }
    }
}
