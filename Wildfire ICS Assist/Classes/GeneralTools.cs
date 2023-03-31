using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.Classes
{
    public static class GeneralTools
    {
        public static void SetDateFormat(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(DateTimePicker))
                {
                    string currentFormat = (c as DateTimePicker).CustomFormat;
                    if (currentFormat.Contains("y"))
                    {
                        if (currentFormat.Contains("H"))
                        {
                            (c as DateTimePicker).CustomFormat = Program.DateFormat + " HH:mm";
                        } else
                        {
                            (c as DateTimePicker).CustomFormat = Program.DateFormat;
                        }
                    }
                } else
                {
                    SetDateFormat(c);
                }
            }
        }
    }
}
