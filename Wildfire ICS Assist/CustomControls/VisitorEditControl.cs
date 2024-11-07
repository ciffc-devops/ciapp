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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class VisitorEditControl : UserControl
    {
        private Personnel _selectedPerson = new Personnel();
        public Personnel selectedPerson { get => _selectedPerson;  }
        public void setPerson(Personnel person) { _selectedPerson = person; displayTeamMember(); }
        public VisitorEditControl()
        {
            InitializeComponent(); this.BackColor = Program.FormBackgroundColor;
        }

        private void displayTeamMember()
        {
          

            if (Program.generalOptionsService != null && Program.generalOptionsService.GetOptionsValue("Agencies") != null)
            {
                List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
                List<string> incidentAgencies = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();

                agencies.AddRange(incidentAgencies.Distinct());
                agencies = agencies.OrderBy(o => o).ToList();
                agencies.Insert(0, string.Empty);

                cboAgency.DataSource = agencies;

            }

            if (_selectedPerson != null)
            {
                txtFirstName.Text = selectedPerson.FirstName;
                txtLastName.SetText(selectedPerson.LastName);
                if (!string.IsNullOrEmpty(selectedPerson.Agency)) { cboAgency.Text = selectedPerson.Agency; }
                //txtDietary.Text = teamMember.Dietary;
                chkDietary.Checked = selectedPerson.HasDietaryRestrictions;
                chkAllergies.Checked = selectedPerson.HasAllergies;
                txtNOKName.Text = selectedPerson.EmergencyContact;
            }
        }

        public bool FormValid
        {
            get
            {

                if (selectedPerson == null) { return false; }
                if (string.IsNullOrEmpty(selectedPerson.LastName) || string.IsNullOrEmpty(selectedPerson.LastName.Trim()))
                {
                    
                    return false;

                }

                return true;
            }
        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

       
        private void cboAgency_Leave(object sender, EventArgs e)
        {
            selectedPerson.Agency = cboAgency.Text;
        }

        private void chkDietary_CheckedChanged(object sender, EventArgs e)
        {
            selectedPerson.HasDietaryRestrictions = chkDietary.Checked;

        }

        private void chkAllergies_CheckedChanged(object sender, EventArgs e)
        {
            selectedPerson.HasAllergies = chkAllergies.Checked;
        }

        private void VisitorEditControl_Load(object sender, EventArgs e)
        {
 
        }

        private void txtFirstName_TextChanged_1(object sender, EventArgs e)
        {
            selectedPerson.FirstName = ((SpellBox)sender).Text;

        }

        private void txtNOKName_TextChanged_1(object sender, EventArgs e)
        {
            selectedPerson.EmergencyContact = ((SpellBox)sender).Text;

        }

        private void txtLastName_TextChanged_1(object sender, EventArgs e)
        {
            selectedPerson.LastName = txtLastName.Text;
        }
    }
}
