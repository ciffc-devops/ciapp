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
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelEditCheckInOutForm : Form
    {
        private List<CheckInRecord> _records = new List<CheckInRecord>();
        public List<CheckInRecord> records { get => _records; set { _records = value; LoadValues(); } }


        public PersonnelEditCheckInOutForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
            GeneralTools.SetDateFormat(this);
        }

        private void LoadValues()
        {
            List<Personnel> members = new List<Personnel>();
            foreach (CheckInRecord record in _records) { if (!members.Any(o => o.PersonID == record.teamMember.PersonID)) { members.Add(record.teamMember); } }

            if (members.Count == 1)
            {
                lblNames.Text = members[0].Name;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (Personnel member in members) { if (sb.Length > 0) { sb.Append(", "); } sb.Append(member.Name); }
                lblNames.Text = sb.ToString();
            }
            DateTime CheckIn = DateTime.MaxValue;
            DateTime CheckOut = DateTime.MaxValue;
            DateTime LDW = DateTime.MaxValue;
            string depart = null;
            string method = null;


            //If the values for an item are all the same, use the value. otherwise leave it blank.
            foreach(CheckInRecord record in records)
            {
                if (record.IsSignIn)
                {
                    if (CheckIn == DateTime.MaxValue) { CheckIn = record.SignInTime; }
                    else if (CheckIn != record.SignInTime) { CheckIn = DateTime.MinValue; }
                }
                if (LDW == DateTime.MaxValue) { LDW = record.LastDayOnIncident; }
                else if (LDW != record.LastDayOnIncident) { LDW = DateTime.MinValue; }

                if (!record.IsSignIn)
                {
                    if (CheckOut == DateTime.MaxValue) { CheckOut = record.SignInTime; }
                    else if (CheckOut != record.SignInTime) { CheckOut = DateTime.MinValue; }
                }

                if (string.IsNullOrEmpty(depart)) { depart = record.DeparturePoint; }
                else if (!depart.Equals(record.DeparturePoint)) { depart = "VARIED"; }

                if (string.IsNullOrEmpty(method)) { method = record.MethodOfTravel; }
                else if (!method.Equals(record.MethodOfTravel)) { method = "VARIED"; }
            }

            if(CheckIn > DateTime.MinValue && CheckIn < DateTime.MaxValue) { datCheckInTime.Value = CheckIn; }
            if (LDW > DateTime.MinValue && LDW < DateTime.MaxValue) { datLDW.Value = LDW; }
            if (method != null && !method.Equals("VARIED")) { cboMethodOfTravel.Text = method; }
            if (depart != null && !depart.Equals("VARIED")) { txtDeparturePoint.Text = depart; }

            chkCheckIn.Checked = false;
            chkDeparturePoint.Checked = false;
            chkLDW.Checked = false;
            chkMethod.Checked = false;

        }

        private void datCheckInTime_ValueChanged(object sender, EventArgs e)
        {
            chkCheckIn.Checked = true;
            datLDW.MinDate = datCheckInTime.Value;
        }

        private void datCheckInTime_Leave(object sender, EventArgs e)
        {
            
        }

        private void datLDW_Leave(object sender, EventArgs e)
        {

        }

        private void txtDeparturePoint_Leave(object sender, EventArgs e)
        {

        }

        private void cboMethodOfTravel_Leave(object sender, EventArgs e)
        {

        }

        private void datLDW_ValueChanged(object sender, EventArgs e)
        {
            chkLDW.Checked = true;
        }

        private void txtDeparturePoint_TextChanged(object sender, EventArgs e)
        {
            chkDeparturePoint.Checked = true;
        }

        private void cboMethodOfTravel_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkMethod.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach(CheckInRecord record in records)
            {
                if (chkCheckIn.Checked) { record.SignInTime = datCheckInTime.Value; }
                if (chkLDW.Checked) { record.LastDayOnIncident = datLDW.Value; }
                if (chkMethod.Checked) { record.MethodOfTravel = cboMethodOfTravel.Text; }
                if (chkDeparturePoint.Checked) { record.DeparturePoint = txtDeparturePoint.Text; }

                if(chkCheckIn.Checked || chkLDW.Checked || chkMethod.Checked || chkDeparturePoint.Checked)
                {
                    Program.wfIncidentService.UpsertMemberStatus(record);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
