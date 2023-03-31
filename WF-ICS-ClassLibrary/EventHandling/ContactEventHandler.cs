using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void ContactEventHandler(ContactEventArgs e);

    public class ContactEventArgs
    {
        public Contact item { get; set; }

        public ContactEventArgs(Contact _item) { item = _item; }
    }
}
