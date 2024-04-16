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
    public partial class PersonnelEditCheckInOutForm : BaseForm
    {
        private List<CheckInRecord> _records = new List<CheckInRecord>();
        public List<CheckInRecord> records { get => _records; set { _records = value; LoadValues(); } }


        public PersonnelEditCheckInOutForm()
        {
            InitializeComponent(); 
            GeneralTools.SetDateFormat(this);
        }

        private void LoadValues()
        {
            List<Personnel> members = new List<Personnel>();
            foreach (CheckInRecord record in _records) { if (!members.Any(o => o.PersonID == record.ResourceID) && Program.CurrentIncident.IncidentPersonnel.Any(o=>o.ID == record.ResourceID)) { members.Add(Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == record.ResourceID)); } }

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
                if (record.CheckInDate > DateTime.MinValue)
                {
                    if (CheckIn == DateTime.MaxValue) { CheckIn = record.CheckInDate; }
                    else if (CheckIn != record.CheckInDate) { CheckIn = DateTime.MinValue; }
                }
                if (LDW == DateTime.MaxValue) { LDW = record.LastDayOnIncident; }
                else if (LDW != record.LastDayOnIncident) { LDW = DateTime.MinValue; }

                if (record.CheckOutDate < DateTime.MaxValue)
                {
                    if (CheckOut == DateTime.MaxValue) { CheckOut = record.CheckOutDate; }
                    else if (CheckOut != record.CheckOutDate) { CheckOut = DateTime.MinValue; }
                }
            }

            if(CheckIn > DateTime.MinValue && CheckIn < DateTime.MaxValue) { datCheckInTime.Value = CheckIn; }
            if (LDW > DateTime.MinValue && LDW < DateTime.MaxValue) { datLDW.Value = LDW; }

            chkCheckIn.Checked = false;
            chkLDW.Checked = false;

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


        private void datLDW_ValueChanged(object sender, EventArgs e)
        {
            chkLDW.Checked = true;
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
                if (chkCheckIn.Checked) { record.CheckInDate = datCheckInTime.Value; }
                if (chkLDW.Checked) { record.LastDayOnIncident = datLDW.Value; }

                if(chkCheckIn.Checked || chkLDW.Checked )
                {
                    Program.wfIncidentService.UpsertCheckInRecord(record);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
