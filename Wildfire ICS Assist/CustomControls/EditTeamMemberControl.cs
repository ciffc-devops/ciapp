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
        private TeamMember _teamMember = null;
        public TeamMember teamMember { get => _teamMember; set { _teamMember = value; displayTeamMember(); } }


        private void displayTeamMember()
        {
            txtName.Text = teamMember.Name;
            txtEmail.Text = teamMember.Email;   
            txtPhone.Text = teamMember.Phone;
            txtQualifications.Text = teamMember.SpecialSkills;
            txtDietary.Text = teamMember.Dietary;

            cboProvince.SelectedValue = teamMember.ProvinceID;
            cboAgency.Text = teamMember.Agency;
            cboHomeAgency.Text = teamMember.HomeAgency;

            chkNoGluten.Checked = teamMember.NoGluten;
            chkVegetarian.Checked = teamMember.Vegetarian;
        }
        public EditTeamMemberControl()
        {
            InitializeComponent();
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
        }

        private void cboProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            teamMember.ProvinceID = new Guid(cboProvince.SelectedValue.ToString());
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
            teamMember.Phone= ((TextBox)sender).Text;
        }
    }
}
