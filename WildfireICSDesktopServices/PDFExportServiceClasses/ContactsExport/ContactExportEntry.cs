using System;
using System.Collections.Generic;
using System.Text;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices.PDFExportServiceClasses.ContactsExport
{
    public class ContactExportEntry
    {
        private Guid _ID;
        private string _Name;
        private string _Position;
        private List<string[]> _ContactMethods = new List<string[]>();

        public Guid ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Position { get => _Position; set => _Position = value; }
        public List<string[]> ContactMethods { get => _ContactMethods; set => _ContactMethods = value; }
        public string ContactMethodsFullString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int x = 0; x < ContactMethods.Count; x++)
                {
                    if (!string.IsNullOrEmpty(ContactMethods[x][0]) || !string.IsNullOrEmpty(ContactMethods[x][1]))
                    {
                        if (sb.Length > 0) { sb.Append(", "); }
                        sb.Append(ContactMethods[x][0]);
                        sb.Append(": ");
                        sb.Append(ContactMethods[x][1]);
                    }
                }
                return sb.ToString();
            }
        }
        public ContactExportEntry() { }
        public ContactExportEntry(Contact contact)
        {
            ID = contact.ContactID;
            Name = contact.ContactName;
            Position = contact.Title;
            if (!string.IsNullOrEmpty(contact.Phone)) { ContactMethods.Add(new string[] { "Phone", contact.Phone }); }
            if (!string.IsNullOrEmpty(contact.Email)) { ContactMethods.Add(new string[] { "Email", contact.Email }); }
            if (!string.IsNullOrEmpty(contact.Callsign)) { ContactMethods.Add(new string[] { "Callsign", contact.Callsign }); }
            if (!string.IsNullOrEmpty(contact.RadioChannel)) { ContactMethods.Add(new string[] { "Radio Channel", contact.RadioChannel }); }
        }
        public ContactExportEntry(ICSRole role, Personnel person)
        {
            Name = person.Name;
            if (!string.IsNullOrEmpty(person.Email)) { ContactMethods.Add(new string[] { "Email", person.Email }); }
            if (!string.IsNullOrEmpty(person.CellphoneNumber)) { ContactMethods.Add(new string[] { "Cell", person.CellphoneNumber }); }
            if (!string.IsNullOrEmpty(person.CallSign)) { ContactMethods.Add(new string[] { "Callsign", person.CallSign }); }
            Position = role.RoleName;
            
        }
    }
}
