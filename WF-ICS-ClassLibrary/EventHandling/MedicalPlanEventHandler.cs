using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void MedicalPlanEventHandler(MedicalPlanEventArgs e);

    public class MedicalPlanEventArgs
    {
        public MedicalPlan item { get; set; }

        public MedicalPlanEventArgs(MedicalPlan _item) { item = _item; }
    }
}
