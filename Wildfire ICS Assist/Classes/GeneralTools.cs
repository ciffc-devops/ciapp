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
        public static int GetDropDownWidth(this ComboBox myCombo)
        {
            try
            {
                int w = myCombo.Items.Cast<object>().Max(o => TextRenderer.MeasureText(myCombo.GetItemText(o), myCombo.Font).Width);
                if (w > 0) { return w + 30; } else { return 100; }
            }
            catch
            {
                return 100;
            }
        }

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
