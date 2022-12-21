using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void TimelineEventHandler(TimelineEventArgs e);

    public class TimelineEventArgs
    {
        public Timeline item { get; set; }

        public TimelineEventArgs(Timeline _item) { item = _item; }
    }

    public delegate void TimelineEventEventHandler(TimelineEventEventArgs e);

    public class TimelineEventEventArgs
    {
        public TimelineEvent item { get; set; }

        public TimelineEventEventArgs(TimelineEvent _item) { item = _item; }
    }
}
