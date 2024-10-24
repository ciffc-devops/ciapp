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



    public delegate void OperationalSubGroupEventHandler(OperationalSubGroupEventArgs e);

    public class OperationalSubGroupEventArgs
    {
        public Crew item { get; set; }

        public OperationalSubGroupEventArgs(Crew _item) { item = _item; }
    }


}
