using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void VehicleEventHandler(VehicleEventArgs e);

    public class VehicleEventArgs
    {
        public Vehicle item { get; set; }

        public VehicleEventArgs(Vehicle _item) { item = _item; }
    }
}
