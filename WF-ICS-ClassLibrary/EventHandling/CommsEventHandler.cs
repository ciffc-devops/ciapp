using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void CommsEventHandler(CommsEventArgs e);

    public class CommsEventArgs
    {
        public CommsLogEntry entry { get; set; }

        public CommsEventArgs(CommsLogEntry _entry) { entry = _entry; }
    }
}
