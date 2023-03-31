using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void TaskUpdateEventHandler(TaskUpdateEventArgs e);

    public class TaskUpdateEventArgs
    {
        public TaskUpdate item { get; set; }

        public TaskUpdateEventArgs(TaskUpdate _item) { item = _item; }
    }
}
