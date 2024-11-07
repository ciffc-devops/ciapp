using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public class ProgramColor
    {
       private System.Drawing.Color _color;
        private string _name;

        public Color Color { get => _color; set => _color = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
