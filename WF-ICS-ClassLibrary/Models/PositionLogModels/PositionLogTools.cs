using System;
using System.Collections.Generic;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    public static class PositionLogTools
    {
        public static string ExportToCSV(List<PositionLogEntry> entries, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("ROLE"); csv.Append(delimiter);
            csv.Append("NAME"); csv.Append(delimiter);
            csv.Append("ENTERED"); csv.Append(delimiter);
            csv.Append("LAST UPDATED"); csv.Append(delimiter);
            csv.Append("CONTENTS"); csv.Append(delimiter);
            csv.Append("DUE"); csv.Append(delimiter);
            csv.Append("COMPLETED"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);

            foreach (PositionLogEntry entry in entries)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                csv.Append("\""); csv.Append(entry.RoleName.ToString()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.Role.IndividualName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.DateCreated.ToString(Globals.DateFormat + " HH:mm")); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.DateUpdated.ToString(Globals.DateFormat + " HH:mm")); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(entry.LogText.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                if (entry.IsInfoOnly)
                {
                    csv.Append("\"NA"); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\"NA"); csv.Append("\""); csv.Append(delimiter);
                }
                else
                {
                    if (entry.IsComplete) { csv.Append("\"YES"); csv.Append("\""); csv.Append(delimiter); }
                    else { csv.Append("\"NO"); csv.Append("\""); csv.Append(delimiter); }
                    csv.Append("\""); csv.Append(entry.TimeDue.ToString(Globals.DateFormat + " HH:mm")); csv.Append("\""); csv.Append(delimiter);

                }

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }
    }
}
