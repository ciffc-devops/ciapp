using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void CommsPlanItemEventHandler(CommsPlanItemEventArgs e);

    public class CommsPlanItemEventArgs
    {
        public CommsPlanItem item { get; set; }

        public CommsPlanItemEventArgs(CommsPlanItem _item) { item = _item; }
    }


    public delegate void CommsPlanEventHandler(CommsPlanEventArgs e);

    public class CommsPlanEventArgs
    {
        public CommsPlan item { get; set; }

        public CommsPlanEventArgs(CommsPlan _item) { item = _item; }
    }






    public delegate void CommsPlanItemListEventHandler(CommsPlanItemEventArgs e);
}
