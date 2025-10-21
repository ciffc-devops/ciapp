using System;
using System.Collections.Generic;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    public static class CommsPlanTools
    {
        public static string PlanToCSV(List<CommsPlanItem> items, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("System/Type"); csv.Append(delimiter);
            csv.Append("Channel"); csv.Append(delimiter);
            csv.Append("Function"); csv.Append(delimiter);
            csv.Append("Rx Frequency"); csv.Append(delimiter);
            csv.Append("Rx Tone"); csv.Append(delimiter);
            csv.Append("Tx Frequency"); csv.Append(delimiter);
            csv.Append("Tx Tone"); csv.Append(delimiter);
            csv.Append("Assignment"); csv.Append(delimiter);
            csv.Append("Remarks"); csv.Append(delimiter);
             csv.Append(Environment.NewLine);

            foreach (CommsPlanItem item in items)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 

                csv.Append("\""); csv.Append(item.CommsSystem.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.ChannelID.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.CommsFunction.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RxFrequency.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RxTone.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.TxFrequency.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.TxTone.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Assignment.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Comments.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }
    }
    }
