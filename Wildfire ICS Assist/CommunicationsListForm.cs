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

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsListForm : Form
    {
        public CommunicationsListForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void BuildData()
        {
            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.DataSource = null;
            List<Contact> contacts = Program.CurrentIncident.allContacts.Where(o => o.Active).OrderBy(o => o.ContactName).ToList(); ;
            dgvContacts.DataSource = contacts;

            btnExport.Enabled = contacts.Any();
            btnPrint.Enabled = contacts.Any();
        }

        private void OpenContactForEdit(Contact contact)
        {
            
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
            if(e.RowIndex >= 0)
            {
                Contact c = (Contact)dgvContacts.Rows[e.RowIndex].DataBoundItem;
                OpenContactForEdit(c);
            }
        }

        private void dgvContacts_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvContacts.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvContacts.SelectedRows.Count > 0;
        }

        private void CommunicationsListForm_Load(object sender, EventArgs e)
        {
            BuildData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
