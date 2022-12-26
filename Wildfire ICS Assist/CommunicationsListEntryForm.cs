using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsListEntryForm : Form
    {
        List<Contact> savedContacts = null;
        private Contact _selected = null;
        public Contact selected { get => _selected; }
       public bool SaveForLater { get => chkSaveForLater.Checked;  }
        public bool IsNewContact { get; set; }

        public CommunicationsListEntryForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CommunicationsListEntryForm_Load(object sender, EventArgs e)
        {
            savedContacts = ((List<Contact>)Program.generalOptionsService.GetOptionsValue("Contacts"));
            savedContacts = savedContacts.Where(o => o.Active).OrderBy(o => o.ContactName).ToList();
            savedContacts = savedContacts.Where(o => !Program.CurrentIncident.allContacts.Any(c => c.ContactID == o.ContactID)).ToList();
            Contact blank = new Contact(); blank.ContactID = Guid.Empty; blank.ContactName = Properties.Resources.SelectSavedContact;
            savedContacts.Insert(0, blank);

            cboSavedContacts.DataSource = savedContacts;

        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(cboSavedContacts.SelectedItem != null && ((Contact)cboSavedContacts.SelectedItem).ContactID != Guid.Empty)
            {
                _selected = (Contact)cboSavedContacts.SelectedItem;
                IsNewContact = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContactName.Text))
            {

                _selected = new Contact();
                selected.ContactName = txtContactName.Text;
                selected.Organization = txtOrganization.Text;
                selected.Title = txtTitle.Text;
                selected.Phone = txtPhone.Text;
                selected.Email = txtEmail.Text;
                selected.Callsign = txtCallsign.Text;
                selected.RadioChannel = txtRadioChannel.Text;
                selected.Notes = txtNotes.Text;
                IsNewContact = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show(Properties.Resources.EditContactValidationError);
            }
        }

        private void cboSavedContacts_Leave(object sender, EventArgs e)
        {
            if (cboSavedContacts.SelectedItem == null)
            {
                if (!string.IsNullOrEmpty(cboSavedContacts.Text))
                {
                    if (savedContacts.Any(o => o.ContactName.Equals(cboSavedContacts.Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cboSavedContacts.SelectedValue = savedContacts.Where(o => o.ContactName.Equals(cboSavedContacts.Text, StringComparison.InvariantCultureIgnoreCase)).First().ContactID;
                        _selected = (Contact)cboSavedContacts.SelectedItem;
                        //displaySelectedTeamMember();
                    }
                    else if (savedContacts.Any(o => o.NameAndOrg.Equals(cboSavedContacts.Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cboSavedContacts.SelectedValue = savedContacts.Where(o => o.NameAndOrg.Equals(cboSavedContacts.Text, StringComparison.InvariantCultureIgnoreCase)).First().ContactID;
                        _selected = (Contact)cboSavedContacts.SelectedItem;


                    }
                    else
                    {
                        cboSavedContacts.SelectedIndex = 0;
                        _selected = null;
                        System.Media.SystemSounds.Exclamation.Play();
                        cboSavedContacts.Focus();
                    }
                }
                else
                {
                    cboSavedContacts.SelectedIndex = 0;
                    _selected = null;
                    //System.Media.SystemSounds.Exclamation.Play();
                    //cboSavedContacts.Focus();
                }


            }
            else { _selected = (Contact)cboSavedContacts.SelectedItem; }
        }
    }
}
