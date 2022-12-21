using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void SafetyPlanEventHandler(SafetyPlanEventArgs e);

    public class SafetyPlanEventArgs
    {
        public SafetyPlan item { get; set; }

        public SafetyPlanEventArgs(SafetyPlan _item) { item = _item; }
    }
}
