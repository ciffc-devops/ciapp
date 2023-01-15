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
    public partial class EditTeamMemberControl : UserControl
    {
        private TeamMember _teamMember = new TeamMember();
        public TeamMember teamMember { get => _teamMember; set { _teamMember = value; displayTeamMember(); } }


        private void displayTeamMember()
        {
            
            if (Program.generalOptionsService != null && Program.generalOptionsService.GetOptionsValue("Agencies") != null)
            {
                List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
                List<string> incidentAgencies = Program.CurrentIncident.TaskTeamMembers.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();
                incidentAgencies.AddRange(Program.CurrentIncident.TaskTeamMembers.Where(o => !string.IsNullOrEmpty(o.HomeAgency)).GroupBy(o => o.HomeAgency).Select(o => o.First().HomeAgency));
                agencies.AddRange(incidentAgencies.Distinct());
                agencies = agencies.OrderBy(o => o).ToList();
                agencies.Insert(0, string.Empty);

                cboAgency.DataSource = agencies;
                cboHomeAgency.DataSource = new List<string>(agencies);
            }
            
            if (_teamMember != null)
            {
                txtName.Text = teamMember.Name;
                txtEmail.Text = teamMember.Email;
                txtPhone.Text = teamMember.Phone;
                txtQualifications.Text = teamMember.SpecialSkills;
                txtDietary.Text = teamMember.Dietary;

                if (teamMember.ProvinceID != Guid.Empty) { cboProvince.SelectedValue = teamMember.ProvinceID; }
                else if (Program.generalOptionsService != null && Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID") != Guid.Empty) { cboProvince.SelectedValue = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); _teamMember.ProvinceID = Program.generalOptionsService.GetGuidOptionValue("DefaultProvinceID"); ; }
                if (!string.IsNullOrEmpty(teamMember.Agency)) { cboAgency.Text = teamMember.Agency; }
                if (!string.IsNullOrEmpty(teamMember.HomeAgency)) { cboHomeAgency.Text = teamMember.HomeAgency; }

                chkNoGluten.Checked = teamMember.NoGluten;
                chkVegetarian.Checked = teamMember.Vegetarian;
            }
        }
        public EditTeamMemberControl()
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
                if (string.IsNullOrEmpty(teamMember.Name.Trim())) { return false; }

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
            teamMember.Name = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                txtName.BackColor = Program.ErrorColor;
            }
            else { txtName.BackColor = Program.GoodColor; }
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvince.SelectedItem != null && cboProvince.SelectedValue != null && teamMember != null)
            {
                teamMember.ProvinceID = new Guid(cboProvince.SelectedValue.ToString());

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

        private void txtQualifications_TextChanged(object sender, EventArgs e)
        {
            teamMember.SpecialSkills = ((TextBox)sender).Text;
        }

        private void chkVegetarian_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CheckBox chk = (CheckBox)sender;
                if (chk.Checked) { chk.ImageIndex = 1; }
                else { chk.ImageIndex = 0; }

                teamMember.Vegetarian = chkVegetarian.Checked;
            }
        }

        private void chkNoGluten_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CheckBox chk = (CheckBox)sender;
                if (chk.Checked) { chk.ImageIndex = 1; }
                else { chk.ImageIndex = 0; }

                teamMember.NoGluten = chkNoGluten.Checked;
            }
        }

        private void txtDietary_TextChanged(object sender, EventArgs e)
        {
            teamMember.Dietary = ((TextBox)sender).Text;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            teamMember.Phone = ((MaskedTextBox)sender).Text;
        }

        private void cboAgency_Leave(object sender, EventArgs e)
        {
            teamMember.Agency = cboAgency.Text;
        }

        private void cboHomeAgency_Leave(object sender, EventArgs e)
        {
            teamMember.HomeAgency = cboHomeAgency.Text;
        }
    }
}
