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
            if (_teamMember != null)
            {
                txtName.Text = teamMember.Name;
                txtEmail.Text = teamMember.Email;
                txtPhone.Text = teamMember.Phone;
                txtQualifications.Text = teamMember.SpecialSkills;
                txtDietary.Text = teamMember.Dietary;

                if (teamMember.ProvinceID != Guid.Empty) { cboProvince.SelectedValue = teamMember.ProvinceID; }
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


        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            teamMember.Name  = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                txtName.BackColor = Program.ErrorColor;
            }
else { txtName.BackColor = Program.GoodColor; }
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboProvince.SelectedItem != null && cboProvince.SelectedValue != null && teamMember != null)
            {
                teamMember.ProvinceID = new Guid(cboProvince.SelectedValue.ToString());

            }
        }

        private void cboAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamMember.Agency= ((TextBox)sender).Text;
        }

        private void txtPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            teamMember.Email= ((TextBox)sender).Text;
        }

        private void cboHomeAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamMember.HomeAgency= ((TextBox)sender).Text;
        }

        private void txtQualifications_TextChanged(object sender, EventArgs e)
        {
            teamMember.SpecialSkills= ((TextBox)sender).Text;
        }

        private void chkVegetarian_CheckedChanged(object sender, EventArgs e)
        {
            teamMember.Vegetarian= chkVegetarian.Checked;
        }

        private void chkNoGluten_CheckedChanged(object sender, EventArgs e)
        {
            teamMember.NoGluten = chkNoGluten.Checked;
        }

        private void txtDietary_TextChanged(object sender, EventArgs e)
        {
            teamMember.Dietary= ((TextBox)sender).Text;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            teamMember.Phone= ((MaskedTextBox)sender).Text;
        }
    }
}
