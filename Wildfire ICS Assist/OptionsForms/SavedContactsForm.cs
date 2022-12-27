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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using WF_ICS_ClassLibrary.Utilities;

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
            using (EditContactForm contactListEditContact = new EditContactForm(newContact))
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
            using (EditContactForm contactListEditContact = new EditContactForm(c))
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
            string msg = Properties.Resources.SureDelete;

            DialogResult conf = MessageBox.Show(msg, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
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
                using (EditContactForm contactListEditContact = new EditContactForm(c))
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "Saved Contacts from CIAPP.csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";

                

                List<Contact> contacts = ((List<Contact>)Program.generalOptionsService.GetOptionsValue("Contacts"));
                contacts = contacts.Where(o => o.Active).OrderBy(o => o.ContactName).ToList();

                string csv = ContactTools.ContactsToCSV(contacts, delimiter);


                try
                {
                    System.IO.File.WriteAllText(exportPath, csv);

                    DialogResult openNow = MessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                    if (openNow == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, there was a problem writing to the file.  Please report this error: " + ex.ToString());
                }
            }
        }
    }
}
