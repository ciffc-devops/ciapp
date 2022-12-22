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
    public partial class SavedContactsForm : Form
    {
        public SavedContactsForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void SavedContactsForm_Load(object sender, EventArgs e)
        {
            dgvContacts.AutoGenerateColumns = false;
            buildDataList();
        }

        private void buildDataList()
        {
            dgvContacts.DataSource = null;
            List<Contact> contacts = ((List<Contact>)Program.generalOptionsService.GetOptionsValue("Contacts"));
            contacts = contacts.Where(o=>o.Active).OrderBy(o => o.ContactName).ToList();
            dgvContacts.DataSource = contacts;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Contact newContact = new Contact();
            using (EditContact contactListEditContact = new EditContact(newContact))
            {
                DialogResult dr = contactListEditContact.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(contactListEditContact.contact, "Contact");
                    buildDataList();

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Contact c = (Contact)dgvContacts.SelectedRows[0].DataBoundItem;
            using (EditContact contactListEditContact = new EditContact(c))
            {
                DialogResult dr = contactListEditContact.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(contactListEditContact.contact, "Contact");
                    buildDataList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Are you sure you want to deleted the selected contact";
            if (dgvContacts.SelectedRows.Count > 1) { msg += "s"; }
            msg += "?";

            DialogResult conf = MessageBox.Show(msg, "Are you sure", MessageBoxButtons.YesNo);
            if (conf == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvContacts.SelectedRows)
                {
                    Contact c = (Contact)row.DataBoundItem;
                    c.Active = false;
                    Program.generalOptionsService.UpserOptionValue(c, "Contact");

                }
                buildDataList();
            }
        }

        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = (dgvContacts.SelectedRows.Count == 1);
            btnDelete.Enabled = dgvContacts.SelectedRows.Count > 0;
        }

        private void dgvContacts_CellMouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Contact c = (Contact)dgvContacts.Rows[e.RowIndex].DataBoundItem;
                using (EditContact contactListEditContact = new EditContact(c))
                {
                    DialogResult dr = contactListEditContact.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Program.generalOptionsService.UpserOptionValue(contactListEditContact.contact, "Contact");
                        buildDataList();
                    }
                }
            }
        }
    }
}
