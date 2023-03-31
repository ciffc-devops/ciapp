using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class DateTools
    {
        public static List<DateFormatOption> GetDateFormatOptions()
        {
            List<DateFormatOption> options = new List<DateFormatOption>();
            options.Add(new DateFormatOption("dd-MMM-yyyy", "Day-Mon-Year"));
            options.Add(new DateFormatOption("dd-MMMM-yyyy", "Day-Month-Year"));
            options.Add(new DateFormatOption("MMM-dd-yyyy", "Mon-Day-Year"));
            options.Add(new DateFormatOption("MMMM-dd-yyyy", "Month-Day-Year"));
            options.Add(new DateFormatOption("yyyy-MMM-dd", "Year-Mon-Day"));
            options.Add(new DateFormatOption("yyyy-MMMM-dd", "Year-Month-Day"));
            return options;
        }

    }

    public class DateFormatOption
    {
        public string Format { get; set; }
        public string DisplayName { get; set; }
        public string Example { get { return string.Format("{0:" + Format +"}", DateTime.Now); } }
        public string DisplayNameWithFormat
        {
            get
            {
                return DisplayName + " (" + Format + " )";
            }
        }
        public string DisplayNameWithExample { get { return DisplayName + " (" + Example + ")"; } }

        public DateFormatOption() { }
        public DateFormatOption(string format, string display) { Format = format; DisplayName = display; }
    }
}
