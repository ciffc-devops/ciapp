using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelViewCheckinForm : Form
    {
        private CheckInRecord _record = new CheckInRecord();
        public CheckInRecord record { get => _record; set { _record = value; LoadInfo(); } } 

        public PersonnelViewCheckinForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void Program_StatusChanged(MemberEventArgs e)
        {
            if(e.MemberID == record.ResourceID)
            {
                if(Program.CurrentIncident.AllCheckInRecords.Any(o=>o.SignInRecordID == record.SignInRecordID))
                {
                    record = Program.CurrentIncident.AllCheckInRecords.First(o=>o.SignInRecordID == record.SignInRecordID);
                }
            }
        }
        private void PersonnelViewCheckinForm_Load(object sender, EventArgs e)
        {
            Program.wfIncidentService.MemberSignInChanged += Program_StatusChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;

        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                LoadInfo();
            }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item != null && e.item.OpPeriod == Program.CurrentOpPeriod) { LoadInfo(); }
        }

        private void Program_AssignmentChanged(TeamAssignmentEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            if(record != null)
            {
                //individual
              

                //checkin
                if (record.CheckInDate > DateTime.MinValue) { lblCheckInTime.Text = string.Format("{0:" + Program.DateFormat + " HH:mm}", record.CheckInDate); }
                else { lblCheckInTime.Text = "TBD"; }

                if (record.LastDayOnIncident > DateTime.MinValue)
                {
                    lblLDW.Text = string.Format("{0:" + Program.DateFormat + "}", record.LastDayOnIncident);
                    DateTime opDate = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodEnd;
                    if (opDate != DateTime.MinValue)
                    {
                        TimeSpan ts = record.LastDayOnIncident - opDate;
                        lblDaysToLDW.Text = "(" + ts.TotalDays + " days from end of op period)";
                    }
                } else { lblLDW.Text = "TBD"; }
              

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      


   
        private void btnEditCheckIn_Click(object sender, EventArgs e)
        {
            List<CheckInRecord> records = new List<CheckInRecord>();
            records.Add(record);
            using (PersonnelEditCheckInOutForm editForm = new PersonnelEditCheckInOutForm())
            {
                editForm.records = records;
                editForm.ShowDialog();
            }
        }

        private void btnEditIndividual_Click(object sender, EventArgs e)
        {
            using (OptionsForms.EditSavedPersonnelForm editForm = new OptionsForms.EditSavedPersonnelForm())
            {
                Personnel person = new Personnel();
                if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == record.ResourceID))
                {
                    person = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == record.ResourceID);

                    editForm.selectedMember = person;
                    DialogResult dr = editForm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        
                        Program.wfIncidentService.UpsertPersonnel(editForm.selectedMember);
                    }
                }
            }
        }

       
    }
}
