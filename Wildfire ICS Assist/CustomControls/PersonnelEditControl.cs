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
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class PersonnelEditControl : UserControl
    {
        private Personnel _teamMember = new Personnel();
        public Personnel teamMember { get => _teamMember;  }
        public void SetPersonnel (Personnel p) { _teamMember = p; displayTeamMember(); }

        private void displayTeamMember()
        {

            cboAgency.DataSource = AgencyTools.GetFixedAgencies(true);
            


            if (Program.generalOptionsService != null && Program.generalOptionsService.GetOptionsValue("Agencies") != null)
            {
                cboOtherAgency.DataSource = GetIncidentAgencies();

                List<string> homebases = (List<string>)Program.generalOptionsService.GetOptionsValue("HomeBases");
                List<string> incidentBases = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.HomeUnit)).GroupBy(o => o.HomeUnit).Select(o => o.First().HomeUnit).ToList();
                homebases.AddRange(incidentBases);
                homebases = homebases.Distinct().OrderBy(o => o).ToList();
                homebases.Insert(0, string.Empty);

                cboHomeAgency.DataSource = homebases;
            }
            
            if (_teamMember != null)
            {
                txtFirstName.SetText(teamMember.FirstName);
                txtMiddleName.Text = teamMember.MiddleInitial;
                txtLastName.SetText(teamMember.LastName);
                cboAccomodationPreference.Text = teamMember.AccomodationPreference;
                if (teamMember.HomeProvinceID != Guid.Empty) { cboProvince.SelectedValue = teamMember.HomeProvinceID; }
                else if (Program.generalOptionsService != null && Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID") != Guid.Empty) { cboProvince.SelectedValue = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); _teamMember.HomeProvinceID = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); ; }
                cboCountry.Text = teamMember.HomeCountry;
                if (!string.IsNullOrEmpty(teamMember.Agency))
                {
                    List<string> fixedAgencies = AgencyTools.GetFixedAgencies();
                    if (fixedAgencies.Contains(teamMember.Agency)) { cboAgency.SelectedIndex = cboAgency.FindStringExact(teamMember.Agency); }
                    else
                    {
                        cboAgency.SelectedIndex = -1;
                        cboOtherAgency.Text = teamMember.Agency;
                    }
                }
                chkContractor.Checked = teamMember.IsContractor;
                txtCellphone.Text = teamMember.CellphoneNumber;
                cboType.Text = teamMember.Type;
                cboKind.Text = teamMember.Kind;
                txtPronouns.Text = teamMember.Pronouns;
                txtEmail.Text = teamMember.Email;
                if (!string.IsNullOrEmpty(teamMember.HomeUnit)) { cboHomeAgency.Text = teamMember.HomeUnit; }

                //txtDietary.Text = teamMember.Dietary;
                chkDietary.Checked = teamMember.HasDietaryRestrictions;
                txtCallsign.Text = teamMember.CallSign;
                chkAllergies.Checked = teamMember.HasAllergies;
                txtNOKName.SetText(teamMember.EmergencyContact);

                //chkNoGluten.Checked = teamMember.NoGluten;
                //chkVegetarian.Checked = teamMember.Vegetarian;
            } else
            {
                cboCountry.Text = "Canada";
            }
        }

        private List<string> GetIncidentAgencies()
        {
            List<string> final = new List<string>();
            List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
            List<string> incidentAgencies = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();
            List<string> staticAgencies = AgencyTools.GetFixedAgencies();

            foreach(string s in agencies)
            {
                if (!final.Contains(s) && !staticAgencies.Contains(s)) { final.Add(s); }
            }
            foreach (string s in incidentAgencies)
            {
                if (!final.Contains(s) && !staticAgencies.Contains(s)) { final.Add(s); }
            }

            final = final.Distinct().ToList();
            final = final.OrderBy(o => o).ToList();
            final.Insert(0, "");
            return final;
        }

        public PersonnelEditControl()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; cboAccomodationPreference.SelectedIndex = 0;
            List<Province> provinces = ProvinceTools.GetProvinces();
            Province other = new Province(); other.ProvinceGUID = Guid.Empty; other.ProvinceName = "Other / NA"; provinces.Add(other);
            bsProvAndTerr.DataSource = provinces;
            cboProvince.DisplayMember = "ProvinceName";
            cboProvince.ValueMember = "ProvinceGUID";

            txtFirstName.TextChanged += TxtFirstName_TextChanged;
            txtLastName.TextChanged += TxtLastName_TextChanged;
            txtNOKName.TextChanged += TxtNOKName_TextChanged;
        }

        private void TxtNOKName_TextChanged(object sender, EventArgs e)
        {
            teamMember.EmergencyContact = ((TextBox)sender).Text; SetColours();
        }

        private void TxtLastName_TextChanged(object sender, EventArgs e)
        {
            teamMember.LastName = ((TextBox)sender).Text;
        }

        private void TxtFirstName_TextChanged(object sender, EventArgs e)
        {
            teamMember.FirstName = ((TextBox)sender).Text;
        }

        private void SetColours()
        {
            if (string.IsNullOrEmpty(cboAccomodationPreference.Text.Trim())) { cboAccomodationPreference.BackColor = Program.ErrorColor; } else { cboAccomodationPreference.BackColor = SystemColors.Window; }
            if (string.IsNullOrEmpty(txtCellphone.Text.Trim())) { txtCellphone.BackColor = Program.ErrorColor; } else { txtCellphone.BackColor = SystemColors.Window; }
            if (cboAgency.SelectedItem == null || cboAgency.SelectedIndex == 0) { cboAgency.BackColor = Program.ErrorColor; } else {  cboAgency.BackColor= SystemColors.Window; }
        }

        public bool FormValid
        {
            get
            {

                if (teamMember == null) { return false; }
                if (string.IsNullOrEmpty(teamMember.FirstName) || string.IsNullOrEmpty(teamMember.FirstName.Trim())) { return false; }
                if (string.IsNullOrEmpty(teamMember.LastName) || string.IsNullOrEmpty(teamMember.LastName.Trim())) { return false; }
                if (string.IsNullOrEmpty(teamMember.AccomodationPreference) || string.IsNullOrEmpty(teamMember.AccomodationPreference.Trim())) { return false; }
                if (string.IsNullOrEmpty(teamMember.CellphoneNumber) || string.IsNullOrEmpty(teamMember.CellphoneNumber.Trim())) { return false; }
                if (string.IsNullOrEmpty(teamMember.Agency)) { return false; };
                if (string.IsNullOrEmpty(teamMember.EmergencyContact)) { return false; };
                SetColours();

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
            SetColours();
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
            teamMember.CellphoneNumber = ((MaskedTextBox)sender).Text; SetColours();
        }

        private void cboAgency_Leave(object sender, EventArgs e)
        {
          cboOtherAgency.Enabled = cboAgency.Text.Equals("Other Agency");
            if (cboOtherAgency.Enabled)
            {
                teamMember.Agency = cboOtherAgency.Text;
            } else { teamMember.Agency = cboAgency.Text; }
            SetColours();
        }

        private void cboHomeAgency_Leave(object sender, EventArgs e)
        {
            teamMember.HomeUnit = cboHomeAgency.Text;
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
            teamMember.Gender = ((ComboBox)sender).Text; SetColours();
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

        private void cboAccomodationPreference_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamMember.AccomodationPreference = ((ComboBox)sender).Text; SetColours();
        }

        private void cboOtherAgency_Leave(object sender, EventArgs e)
        {
            if (cboOtherAgency.Enabled)
            {
                teamMember.Agency = cboOtherAgency.Text;
            }
        }

        private void txtPronouns_TextChanged(object sender, EventArgs e)
        {
            teamMember.Pronouns = ((TextBox)sender).Text;

        }

        private void txtCellphone_TextChanged(object sender, EventArgs e)
        {
            teamMember.CellphoneNumber = ((TextBox)sender).Text;
            SetColours();
        }
    }
}
