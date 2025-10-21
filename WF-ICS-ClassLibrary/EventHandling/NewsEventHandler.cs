using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.NewsModels;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void NewsEventHandler(NewsEventArgs e);

    public class NewsEventArgs
    {
        public NewsItem item { get; set; }

        public NewsEventArgs(NewsItem _item) { item = _item; }
    }
}
