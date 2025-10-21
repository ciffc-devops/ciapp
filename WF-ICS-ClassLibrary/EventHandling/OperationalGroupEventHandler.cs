using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void OperationalGroupEventHandler(OperationalGroupEventArgs e);

    public class OperationalGroupEventArgs
    {
        public OperationalGroup item { get; set; }

        public OperationalGroupEventArgs(OperationalGroup _item) { item = _item; }
    }



    public delegate void OperationalSubGroupEventHandler(CrewEventArgs e);

    public class CrewEventArgs
    {
        public Crew item { get; set; }

        public CrewEventArgs(Crew _item) { item = _item; }
    }


}
