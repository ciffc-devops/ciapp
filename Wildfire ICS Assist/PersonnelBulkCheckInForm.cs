using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelBulkCheckInForm : Form
    {
        private List<CheckInRecord> _records = new List<CheckInRecord>();
        public List<CheckInRecord> records { get => _records; set => _records = value; }


        public PersonnelBulkCheckInForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
            dgvSavedPersonnel.BackgroundColor = Program.FormAccent;
            GeneralTools.SetDateFormat(this);

        }

        private void datCheckInTime_ValueChanged(object sender, EventArgs e)
        {
            datLDW.MinDate = datCheckInTime.Value;
        }

        private void PersonnelBulkCheckInForm_Load(object sender, EventArgs e)
        {
            datCheckInTime.Value = DateTime.Now;
            datLDW.Value = DateTime.Now.AddDays(14);
            LoadData();

        }

        private void datLDW_ValueChanged(object sender, EventArgs e)
        {
            if (datCheckInTime.Value > datLDW.Value) { lblLastDayWorking.ForeColor = Color.Red; }
            else { lblLastDayWorking.ForeColor = label4.ForeColor; }

        }

        private void LoadData()
        {
            dgvSavedPersonnel.AutoGenerateColumns = false;
            dgvSavedPersonnel.DataSource = null;
            List<MemberStatus> statuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);

            List<Personnel> members = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            //add members from previous op periods
            List<Personnel> prevMembers = Program.CurrentIncident.TaskTeamMembers.Where(o=> !members.Any(m=>m.PersonID == o.PersonID)).ToList();
            members.AddRange(prevMembers);


            members = members.Where(o => o.MemberActive).OrderBy(o => o.ProvinceName).ThenBy(o => o.Agency).ThenBy(o => o.Name).ToList();
            members = members.Where(o => !statuses.Any(s => s.MemberID == o.PersonID)).ToList();

            dgvSavedPersonnel.DataSource = members;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (ValidateCheckInInfo())
            {
                List<Personnel> membersToSignIn = new List<Personnel>();
                int checkIndex = dgvSavedPersonnel.Columns["colCheck"].Index;
                foreach (DataGridViewRow row in dgvSavedPersonnel.Rows)
                {
                    if (row.Index >= 0)
                    {
                        Personnel member = (Personnel)row.DataBoundItem;
                        DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[checkIndex];
                        if (cell.Value != null && cell.Value.ToString().Equals(cell.TrueValue.ToString(), StringComparison.InvariantCultureIgnoreCase))
                        {
                            membersToSignIn.Add(member);
                        }
                    }
                }

                foreach (Personnel member in membersToSignIn)
                {
                    CheckInRecord record = new CheckInRecord();
                    record.IsSignIn = true;
                    record.OpPeriod = Program.CurrentOpPeriod;
                    record.teamMember = member;
                    record.SignInTime = datCheckInTime.Value;
                    record.LastDayOnIncident = datLDW.Value;
                    record.MethodOfTravel = cboMethodOfTravel.Text;
                    record.DeparturePoint = txtDeparturePoint.Text;
                    records.Add(record);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateCheckInInfo()
        {
            if (datCheckInTime.Value > datLDW.Value)
            {
                lblLastDayWorking.ForeColor = Color.Red;
                return false;
            }
            else { lblLastDayWorking.ForeColor = label4.ForeColor; }
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
