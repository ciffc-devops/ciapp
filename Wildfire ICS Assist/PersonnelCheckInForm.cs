using Microsoft.VisualBasic;
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
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelCheckInForm : Form
    {
        private Personnel _selectedMember;
        public Personnel selectedMember { get => _selectedMember; set => _selectedMember = value; }
        private CheckInRecord _signInRecord = new CheckInRecord();
        public CheckInRecord signInRecord { get => _signInRecord; set => _signInRecord = value; }
        public bool AutoAssignToOrg { get => chkAssignOnOrgChart.Checked; }

        public PersonnelCheckInForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            GeneralTools.SetDateFormat(this);
        }

        private void PersonnelSignInForm_Load(object sender, EventArgs e)
        {
            LoadData();
            pnlCheckInInfo.BackColor = Program.FormAccent;
            pnlCheckInInfo.Enabled = false;
            editTeamMemberControl1.teamMember = new Personnel();
            datCheckInTime.Value = DateTime.Now;
            datLDW.Value = DateTime.Now.AddDays(14);
            buildICSRoleDropdown();


        }

        private void buildICSRoleDropdown()
        {
            ICSRole role = Program.CurrentRole.Clone();
            List<ICSRole> roles = OrgChartTools.GetAllRoles();
            roles = roles.OrderByDescending(o=>o.SectionID == WF_ICS_ClassLibrary.Globals.IncidentCommanderID).ThenBy(o=>o.RoleNameWithSection).ToList();
            cboICSRole.DataSource = null;
            cboICSRole.DataSource = roles;
            cboICSRole.DisplayMember = "RoleNameWithSection";
            cboICSRole.ValueMember = "RoleID";

        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void LoadData()
        {
            cboSavedPersonnel.DataSource = null;
            List<MemberStatus> statuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);

            List<Personnel> members = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = members.Where(o => o.MemberActive).OrderBy(o => o.ProvinceName).ThenBy(o => o.Agency).ThenBy(o => o.Name).ToList();
            members = members.Where(o => !statuses.Any(s => s.MemberID == o.PersonID)).ToList();

            cboSavedPersonnel.DataSource = members;

            List<ICSRole> roles = new List<ICSRole>(); roles.AddRange(OrgChartTools.staticRoles);
            cboICSRole.DataSource = roles;

        }

        private void btnSelectSaved_Click(object sender, EventArgs e)
        {
            if (cboSavedPersonnel.SelectedItem != null)
            {
                selectedMember = (Personnel)cboSavedPersonnel.SelectedItem;
                txtSelectedName.Text = selectedMember.Name;
                pnlCheckInInfo.Enabled = true;
                pnlCheckInInfo.BackColor = Color.White;
                txtDeparturePoint.Focus();
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
                txtDeparturePoint.Focus();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboSavedPersonnel_Leave(object sender, EventArgs e)
        {
            if (cboSavedPersonnel.SelectedItem == null)
            {
                cboSavedPersonnel.Text = string.Empty;

            }
        }

        private bool ValidateCheckInInfo()
        {
            if (datCheckInTime.Value > datLDW.Value)
            {
                lblLastDayWorking.ForeColor = Color.Red;
                return false;
            }
            else { lblLastDayWorking.ForeColor = label1.ForeColor; }
            return true;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (selectedMember != null && ValidateCheckInInfo())
            {
                signInRecord.teamMember = selectedMember;
                signInRecord.OpPeriod = Program.CurrentOpPeriod;

                if (datLastDayOfRest.Checked) { signInRecord.LastDayOfRest = datLastDayOfRest.Value; } else { signInRecord.LastDayOfRest = DateTime.MinValue; }
                if (datStartTravel.Checked) { signInRecord.StartOfTravel = datStartTravel.Value; }                else { signInRecord.StartOfTravel = DateTime.MinValue; }

                signInRecord.SignInTime = datCheckInTime.Value;
                signInRecord.LastDayOnIncident = datLDW.Value;
                if (datLastDayTravel.Checked) { signInRecord.LastDayOfTravel = datLastDayTravel.Value; } else { signInRecord.LastDayOfTravel = DateTime.MinValue; }
                if (datFirstDayOnIncident.Checked) { signInRecord.FirstDayOnIncident = datFirstDayOnIncident.Value; } else { signInRecord.FirstDayOnIncident = DateTime.MinValue; }
                signInRecord.DeparturePoint = txtDeparturePoint.Text;
                signInRecord.MethodOfTravel = cboMethodOfTravel.Text;
                signInRecord.Accomodations= cboAccomodations.Text;
                signInRecord.Breakfast = chkBreakfast.Checked;
                signInRecord.Lunch = chkLunch.Checked;
                signInRecord.Dinner = chkDinner.Checked;

                if(cboICSRole.SelectedItem != null)
                {
                    signInRecord.InitialIncidentRoleID = ((ICSRole)cboICSRole.SelectedItem).RoleID;
                    signInRecord.InitialRoleName = ((ICSRole)cboICSRole.SelectedItem).RoleName;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void datCheckInTime_ValueChanged(object sender, EventArgs e)
        {
            datLDW.MinDate = datCheckInTime.Value;
        }

        private void datLDW_ValueChanged(object sender, EventArgs e)
        {
            if (datCheckInTime.Value > datLDW.Value) { lblLastDayWorking.ForeColor = Color.Red; }
            else { lblLastDayWorking.ForeColor = label1.ForeColor; }
        }

        private void txtDeparturePoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboICSRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboICSRole.SelectedItem != null)
            {
                ICSRole role = (ICSRole)cboICSRole.SelectedItem;
                chkAssignOnOrgChart.Enabled = RoleAvailableForAutoAssign(role);
                chkAssignOnOrgChart.Checked = chkAssignOnOrgChart.Enabled;
            } else { chkAssignOnOrgChart.Enabled = false; chkAssignOnOrgChart.Checked = false; }
        }

        private bool RoleAvailableForAutoAssign(ICSRole role)
        {
            List<ICSRole> roles = Program.CurrentOrgChart.ActiveRoles;
            if (!roles.Any(o => o.RoleName.Equals(role.RoleName, StringComparison.OrdinalIgnoreCase) && o.IndividualID == Guid.Empty)) { return false; }
            return true;
        }
    }
}
