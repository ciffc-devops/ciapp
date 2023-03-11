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
    public partial class PersonnelEditControl : UserControl
    {
        private Personnel _teamMember = new Personnel();
        public Personnel teamMember { get => _teamMember;  }
        public void SetPersonnel (Personnel p) { _teamMember = p; displayTeamMember(); }

        private void displayTeamMember()
        {
            
            if (Program.generalOptionsService != null && Program.generalOptionsService.GetOptionsValue("Agencies") != null)
            {
                List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
                List<string> incidentAgencies = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();
               
                agencies.AddRange(incidentAgencies.Distinct());
                agencies = agencies.Distinct().ToList();
                agencies = agencies.OrderBy(o => o).ToList();
                agencies.Insert(0, string.Empty);

                cboAgency.DataSource = agencies;

                List<string> homebases = (List<string>)Program.generalOptionsService.GetOptionsValue("HomeBases");
                List<string> incidentBases = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.HomeUnit)).GroupBy(o => o.HomeUnit).Select(o => o.First().HomeUnit).ToList();
                homebases.AddRange(incidentBases.Distinct());
                homebases = homebases.OrderBy(o => o).ToList();
                homebases.Insert(0, string.Empty);

                cboHomeAgency.DataSource = homebases;
            }
            
            if (_teamMember != null)
            {
                txtFirstName.Text = teamMember.FirstName;
                txtMiddleName.Text = teamMember.MiddleInitial;
                txtLastName.Text = teamMember.LastName;
                cboGender.Text = teamMember.Gender;
                if (teamMember.HomeProvinceID != Guid.Empty) { cboProvince.SelectedValue = teamMember.HomeProvinceID; }
                else if (Program.generalOptionsService != null && Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID") != Guid.Empty) { cboProvince.SelectedValue = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); _teamMember.HomeProvinceID = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); ; }
                cboCountry.Text = teamMember.HomeCountry;
                if (!string.IsNullOrEmpty(teamMember.Agency)) { cboAgency.Text = teamMember.Agency; }
                chkContractor.Checked = teamMember.IsContractor;
                txtPhone.Text = teamMember.CellphoneNumber;
                cboType.Text = teamMember.Type;
                cboKind.Text = teamMember.Kind;
                txtEmail.Text = teamMember.Email;
                if (!string.IsNullOrEmpty(teamMember.HomeUnit)) { cboHomeAgency.Text = teamMember.HomeUnit; }

                //txtDietary.Text = teamMember.Dietary;
                chkDietary.Checked = teamMember.HasDietaryRestrictions;
                txtCallsign.Text = teamMember.CallSign;
                chkAllergies.Checked = teamMember.HasAllergies;
                txtWeight.Text = teamMember.Weight;

                txtNOKName.Text = teamMember.EmergencyContact;

                //chkNoGluten.Checked = teamMember.NoGluten;
                //chkVegetarian.Checked = teamMember.Vegetarian;
            } else
            {
                cboCountry.Text = "Canada";
            }
        }
        public PersonnelEditControl()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
            bsProvAndTerr.DataSource = ProvinceTools.GetProvinces();
            cboProvince.DisplayMember = "ProvinceName";
            cboProvince.ValueMember = "ProvinceGUID";
        }


        public bool FormValid
        {
            get
            {

                if (teamMember == null) { return false; }
                if (string.IsNullOrEmpty(teamMember.LastName) || string.IsNullOrEmpty(teamMember.LastName.Trim()))
                {
                    txtLastName.BackColor = Program.ErrorColor;
                    return false;

                }

                return true;
            }
        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            teamMember.FirstName = ((TextBox)sender).Text;
           
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvince.SelectedItem != null && cboProvince.SelectedValue != null && teamMember != null)
            {
                teamMember.HomeProvinceID = new Guid(cboProvince.SelectedValue.ToString());

            }
        }

        private void cboAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            teamMember.Email = ((TextBox)sender).Text;
        }

        private void cboHomeAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
        }



        private void txtPhone_Leave(object sender, EventArgs e)
        {
            teamMember.CellphoneNumber = ((MaskedTextBox)sender).Text;
        }

        private void cboAgency_Leave(object sender, EventArgs e)
        {
            teamMember.Agency = cboAgency.Text;
        }

        private void cboHomeAgency_Leave(object sender, EventArgs e)
        {
            teamMember.HomeUnit = cboHomeAgency.Text;
        }

        private void txtNOKName_TextChanged(object sender, EventArgs e)
        {
            teamMember.EmergencyContact = ((TextBox)sender).Text;

        }

       

        private void txtCallsign_TextChanged(object sender, EventArgs e)
        {
            teamMember.CallSign = ((TextBox)sender).Text;
        }

        private void chkDietary_CheckedChanged(object sender, EventArgs e)
        {
            teamMember.HasDietaryRestrictions = chkDietary.Checked;
        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {
            teamMember.MiddleInitial = ((TextBox)sender).Text;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            teamMember.LastName = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                ((TextBox)sender).BackColor = Program.ErrorColor;
            }
            else { ((TextBox)sender).BackColor = Program.GoodColor; }
        }

        private void chkContractor_CheckedChanged(object sender, EventArgs e)
        {
            teamMember.IsContractor = chkContractor.Checked;
        }

        private void chkAllergies_CheckedChanged(object sender, EventArgs e)
        {
            teamMember.HasAllergies = chkAllergies.Checked;
        }

        private void cboGender_Leave(object sender, EventArgs e)
        {
            teamMember.Gender = ((ComboBox)sender).Text;
        }

        private void cboCountry_Leave(object sender, EventArgs e)
        {
            teamMember.HomeCountry = ((ComboBox)sender).Text;
        }

        private void PersonnelEditControl_Load(object sender, EventArgs e)
        {

        }

        private void txtKind_TextChanged(object sender, EventArgs e)
        {
            teamMember.Kind = ((TextBox)sender).Text;
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            teamMember.Type = ((TextBox)sender).Text;
        }

        private void cboKind_Leave(object sender, EventArgs e)
        {
            teamMember.Kind = ((ComboBox)sender).Text;
        }

        private void cboType_Leave(object sender, EventArgs e)
        {
            teamMember.Type = ((ComboBox)sender).Text;
        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            teamMember.Weight = ((TextBox)sender).Text; 
        }
    }
}
