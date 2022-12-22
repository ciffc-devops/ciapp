using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditContactForm : Form
    {
        private Contact _contact = new Contact();
        public Contact contact { get => _contact; private set => _contact = value; }

        public EditContactForm(Contact contactToEdit)
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
            contact = contactToEdit;

        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            if (contact != null)
            {
                displayContact();
            }
        }

        private void displayContact()
        {
            txtContactName.Text = contact.ContactName;
            txtOrganization.Text = contact.Organization;
            txtTitle.Text = contact.Title;
            txtPhone.Text = contact.Phone;
            txtEmail.Text = contact.Email;
            txtCallsign.Text = contact.Callsign;
            txtRadioChannel.Text = contact.RadioChannel;
            txtNotes.Text = contact.Notes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContactName.Text))
            {
                contact.ContactName = txtContactName.Text;
                contact.Organization = txtOrganization.Text;
                contact.Title = txtTitle.Text;
                contact.Phone = txtPhone.Text;
                contact.Email = txtEmail.Text;
                contact.Callsign = txtCallsign.Text;
                contact.RadioChannel = txtRadioChannel.Text;
                contact.Notes = txtNotes.Text;



                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("You must enter a name for the contact, even a generic one is fine.");
            }
        }
    }
}
