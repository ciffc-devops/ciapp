using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
  
    public delegate void GeneralMessageEventHandler(GeneralMessageEventArgs e);

    public class GeneralMessageEventArgs
    {
        public GeneralMessage item { get; set; }

        public GeneralMessageEventArgs(GeneralMessage _item) { item = _item; }
    }
}
