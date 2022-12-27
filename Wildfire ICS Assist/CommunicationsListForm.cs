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
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsListForm : Form
    {
        public CommunicationsListForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void Program_ContactChanged(ContactEventArgs e)
        {
            BuildData();
        }


        private void BuildData()
        {
            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.DataSource = null;
            List<Contact> contacts = Program.CurrentIncident.allContacts.Where(o => o.Active).OrderBy(o => o.ContactName).ToList();
            dgvContacts.DataSource = contacts;

            btnExport.Enabled = contacts.Any();
            btnPrint.Enabled = contacts.Any();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "Contacts-" + Program.CurrentIncident.IncidentIdentifier + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";



                List<Contact> contacts = Program.CurrentIncident.allContacts.Where(o => o.Active).OrderBy(o => o.ContactName).ToList(); ;

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

        private void dgvContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Contact c = (Contact)dgvContacts.Rows[e.RowIndex].DataBoundItem;
                OpenForView(c);
            }
        }

        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvContacts.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvContacts.SelectedRows.Count > 0;
        }

        private void CommunicationsListForm_Load(object sender, EventArgs e)
        {
            Program.wfIncidentService.ContactChanged += Program_ContactChanged;

            BuildData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CommunicationsListEntryForm entryForm = new CommunicationsListEntryForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Contact c = entryForm.selected;
                    if (null != c)
                    {
                        Program.wfIncidentService.UpsertContact(c);

                        if (entryForm.IsNewContact && entryForm.SaveForLater)
                        {
                            Program.generalOptionsService.UpserOptionValue(entryForm.selected, "Contact");

                        }
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string preparedByName = null; string preparedByTitle = null;

            if (Program.CurrentIncident.allOrgCharts.Where(o => o.OpPeriod == Program.CurrentOpPeriod).Any())
            {
                OrganizationChart currentChart = Program.CurrentIncident.allOrgCharts.Where(o => o.OpPeriod == Program.CurrentOpPeriod).First();
                preparedByName = currentChart.getNameByRoleName("Logistics Section Chief");
                preparedByTitle = "Logistics Section Chief";
            }



            string path = ContactListServices.createContactsPDF(Program.CurrentIncident, Program.CurrentOpPeriod, preparedByName, preparedByTitle, false, false);
            if (!string.IsNullOrEmpty(path))
            {
                try { System.Diagnostics.Process.Start(path); }
                catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }
            }
            else
            {
                MessageBox.Show("Sorry, there was an error generating the contact list.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count == 1)
            {
                Contact item = (Contact)dgvContacts.SelectedRows[0].DataBoundItem;
                OpenContactForEdit(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<Contact> toDelete = new List<Contact>();

                foreach (DataGridViewRow row in dgvContacts.SelectedRows)
                {
                    toDelete.Add((Contact)row.DataBoundItem);
                }

                foreach (Contact c in toDelete) { c.Active = false; Program.wfIncidentService.UpsertContact(c); }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count == 1)
            {
                Contact item = (Contact)dgvContacts.SelectedRows[0].DataBoundItem;
                OpenForView(item);
            }

        }

        private void OpenForView(Contact c)
        {
            using (CommunicationsListViewForm viewForm = new CommunicationsListViewForm())
            {
                viewForm.contact = c;
                viewForm.ShowDialog();
            }
        }
    }
}
