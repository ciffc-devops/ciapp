using System;
using System.Collections.Generic;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    public static class ContactTools
    {
        public static string ContactsToCSV(List<Contact> contacts, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("ID"); csv.Append(delimiter);
            csv.Append("NAME"); csv.Append(delimiter);
            csv.Append("TITLE"); csv.Append(delimiter);
            csv.Append("ORGANIZATION"); csv.Append(delimiter);
            csv.Append("PHONE"); csv.Append(delimiter);
            csv.Append("EMAIL"); csv.Append(delimiter);
            csv.Append("CALLSIGN"); csv.Append(delimiter);
            csv.Append("RADIO CHANNEL"); csv.Append(delimiter);
            csv.Append("NOTES");
            csv.Append(Environment.NewLine);

            foreach (Contact contact in contacts)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                csv.Append("\""); csv.Append(contact.ContactID.ToString()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.ContactName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Title.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Organization.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Phone.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Email.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Callsign.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.RadioChannel.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(contact.Notes.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

     
    }
}
