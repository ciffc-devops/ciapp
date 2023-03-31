using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void TaskBasicsEventHandler(TaskBasicsEventArgs e);

    public class TaskBasicsEventArgs
    {
        public TaskBasics item { get; set; }

        public TaskBasicsEventArgs(TaskBasics _item) { item = _item; }
    }
}
