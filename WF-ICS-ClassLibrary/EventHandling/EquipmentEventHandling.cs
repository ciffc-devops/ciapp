using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public class TaskEquipmentEventArgs
    {
        public TaskEquipment item { get; set; }

        public TaskEquipmentEventArgs(TaskEquipment _item) { item = _item; }
    }
    public delegate void TaskEquipmentEventHandler(TaskEquipmentEventArgs e);


    public class EquipmentIssueEventArgs
    {
        public EquipmentIssue item { get; set; }

        public EquipmentIssueEventArgs(EquipmentIssue _item) { item = _item; }
    }
    public delegate void EquipmentIssueEventHandler(EquipmentIssueEventArgs e);
}
