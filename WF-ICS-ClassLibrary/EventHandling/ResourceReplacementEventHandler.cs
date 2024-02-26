using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
   

    public delegate void ResourceReplacementEventHandler(ResourceReplacementPlanEventArgs e);

    public class ResourceReplacementPlanEventArgs
    {
        public ResourceReplacementPlan item { get; set; }

        public ResourceReplacementPlanEventArgs(ResourceReplacementPlan _item) { item = _item; }
    }

}
