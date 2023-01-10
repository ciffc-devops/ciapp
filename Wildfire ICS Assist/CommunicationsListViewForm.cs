using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.OptionsForms;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsListViewForm : Form
    {
        private Contact _contact = new Contact();
        public Contact contact { get => _contact;  set { _contact = value; DisplayContact(); } }

        private void DisplayContact()
        {
            lblName.Text = contact.ContactName;
            lblOrganization.Text = contact.Organization;
            lblTitle.Text = contact.Title;
            lblCallsign.Text = contact.Callsign;
            lblPhone.Text = contact.Phone;
            lblEmail.Text = contact.Email;
            lblRadio.Text = contact.RadioChannel;
            lblNotes.Text = contact.Notes;
        }
        public CommunicationsListViewForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }


        private void Program_ContactChanged(ContactEventArgs e)
        {
            if (e.item.ContactID == contact.ContactID)
            {
                contact = e.item;
                    
            }
                
        }



        private void CommunicationsListViewForm_Load(object sender, EventArgs e)
        {
            Program.wfIncidentService.ContactChanged += Program_ContactChanged;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OpenContactForEdit(Contact item)
        {
            using (EditContactForm editItem = new EditContactForm(item.Clone()))
            {
                DialogResult dr = editItem.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    if (editItem.contact != null)
                    {
                        Program.wfIncidentService.UpsertContact(editItem.contact);

                        //if options.allcontacts includes this one, update its contents
                        List<Contact> savedContacts = (List<Contact>)Program.generalOptionsService.GetOptionsValue("Contacts");
                        if (savedContacts.Any(o => o.ContactID == editItem.contact.ContactID))
                        {
                            Program.generalOptionsService.UpserOptionValue(editItem.contact, "Contact");
                        }
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenContactForEdit(contact);
        }
    }
}
