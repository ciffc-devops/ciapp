using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void SafetyMessageEventHandler(SafetyMessageEventArgs e);

    public class SafetyMessageEventArgs
    {
        public SafetyMessage item { get; set; }

        public SafetyMessageEventArgs(SafetyMessage _item) { item = _item; }
    }
}
