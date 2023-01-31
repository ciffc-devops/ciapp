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
    public partial class PersonnelSignInForm : Form
    {
        private TeamMember _selectedMember;
        public TeamMember selectedMember { get => _selectedMember; set => _selectedMember = value; }
        private SignInRecord _signInRecord = new SignInRecord();
        public SignInRecord signInRecord { get => _signInRecord; set => _signInRecord = value; }

        public PersonnelSignInForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void PersonnelSignInForm_Load(object sender, EventArgs e)
        {
            LoadData();
            pnlCheckInInfo.BackColor = Program.FormAccent;
            pnlCheckInInfo.Enabled = false;
        }

        private void LoadData()
        {
            cboSavedPersonnel.DataSource = null;
            List<TeamMember> members = (List<TeamMember>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = members.Where(o => o.MemberActive).OrderBy(o => o.ProvinceName).ThenBy(o => o.Agency).ThenBy(o => o.Name).ToList();
            cboSavedPersonnel.DataSource = members;
        }

        private void btnSelectSaved_Click(object sender, EventArgs e)
        {
            if(cboSavedPersonnel.SelectedItem != null)
            {
                selectedMember = (TeamMember)cboSavedPersonnel.SelectedItem;
                txtSelectedName.Text = selectedMember.Name;
                pnlCheckInInfo.Enabled = true;
                pnlCheckInInfo.BackColor = Color.White;
                datCheckInTime.Focus();
            }
        }

        private void btnSelectNew_Click(object sender, EventArgs e)
        {
            if (editTeamMemberControl1.FormValid)
            {
                selectedMember = editTeamMemberControl1.teamMember;
                txtSelectedName.Text = selectedMember.Name;
                pnlCheckInInfo.Enabled = true;
                pnlCheckInInfo.BackColor = Color.White;
                datCheckInTime.Focus();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboSavedPersonnel_Leave(object sender, EventArgs e)
        {
            if(cboSavedPersonnel.SelectedItem == null)
            {
                cboSavedPersonnel.Text = string.Empty;

            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if(selectedMember != null)
            {
                signInRecord.teamMember = selectedMember;
                signInRecord.OpPeriod = Program.CurrentOpPeriod;
                signInRecord.SignInTime = datCheckInTime.Value;
                signInRecord.LastDayWorked = datLDW.Value;
                signInRecord.DeparturePoint = txtDeparturePoint.Text;
                signInRecord.MethodOfTravel = cboMethodOfTravel.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
