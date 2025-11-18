using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public class ComboBoxDataItem
    {
        public string DisplayText { get; set; }
        public string ValueText { get; set; }   
        public ComboBoxDataItem() { }
        public ComboBoxDataItem(string displayText, string valueText = null)
        {
            DisplayText = displayText;
            if (valueText != null) { ValueText = valueText; }
            else { ValueText = displayText; }
        }
    }
}
