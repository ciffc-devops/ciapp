using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void NoteEventHandler(NoteEventArgs e);

    public class NoteEventArgs
    {
        public Note item { get; set; }

        public NoteEventArgs(Note _item) { item = _item; }
    }
}
