﻿using System;
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

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelListForm : Form
    {
        public PersonnelListForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            dgvPersonnel.BackgroundColor = Program.FormAccent;
            dgvTotalByAgency.BackgroundColor = Program.FormAccent;
        }

        private void PersonnelListForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            BuildDataLists();
            Program.wfIncidentService.MemberSignInChanged += Program_TeamMembersUpdated;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

            cpnlAgencyTotals.CurrentlyCollapsed = true;

        }

        private void Program_TeamMembersUpdated(MemberEventArgs e)
        {
            BuildDataLists();
        }

        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            BuildDataLists();
        }

        private void BuildDataLists()
        {
            DateTime endOfOp = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodEnd;


            dgvPersonnel.DataSource = null;
            List<MemberStatus> memberStatuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);
            if (chkNotSignedInOnly.Checked) { memberStatuses = memberStatuses.Where(o => o.SignInTime <= DateTime.MinValue).ToList(); }
            if (chkUnassignedOnly.Checked) { memberStatuses = memberStatuses.Where(o => !o.IsAssigned).ToList(); }
            if (chkLDWSoon.Checked) {
                
                memberStatuses = memberStatuses.Where(o => (o.LastDayWorked - endOfOp).TotalHours < 36).ToList();
            }

            dgvPersonnel.AutoGenerateColumns = false;
            dgvPersonnel.DataSource = memberStatuses;

            dgvTotalByAgency.AutoGenerateColumns = false;
            dgvTotalByAgency.DataSource = null;
            List<AgencyPersonnelCount> agencyCounts = Program.CurrentIncident.GetAgencyPersonnelCount(Program.CurrentOpPeriod);
            dgvTotalByAgency.DataSource = agencyCounts;

            int LessThan24 = Program.CurrentIncident.AllCheckInRecords.Count(o=>(o.LastDayOnIncident - endOfOp).TotalHours <= 24);
            int LessThan48 = Program.CurrentIncident.AllCheckInRecords.Count(o => (o.LastDayOnIncident - endOfOp).TotalHours <= 48);
            lblLDWLessThan24.Text = "LDW < 24 Hours: " + LessThan24;
            lblLDWLessThan48.Text = "LDW < 48 Hours: " + LessThan48;

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            using (PersonnelCheckInForm signInForm = new PersonnelCheckInForm())
            {
                DialogResult dr = signInForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    CheckInRecord record = signInForm.checkInRecord;
                    Program.wfIncidentService.UpsertCheckInRecord(record);
                }
            }
        }

        private void dgvPersonnel_SelectionChanged(object sender, EventArgs e)
        {
            List<MemberStatus> statuses = new List<MemberStatus>();


            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                pnlSelectedMember.Enabled = true;
                foreach (DataGridViewRow row in dgvPersonnel.SelectedRows)
                {
                    statuses.Add((MemberStatus)row.DataBoundItem);
                }

                btnSignInSelected.Enabled = !statuses.Any(o => o.SignInTime > DateTime.MinValue);


            }
            else
            {
                pnlSelectedMember.Enabled = false;
            }


            if (dgvPersonnel.SelectedRows.Count == 1)
            {
                btnViewDetails.Enabled = true;
                MemberStatus status = statuses[0]; //(MemberStatus)dgvMembersOnTask.SelectedRows[0].DataBoundItem;
//                btnViewEquipment.Enabled = Program.CurrentIncident.allEquipmentIssues.Any(o => o.OpPeriod == Program.CurrentOpPeriod && (o.ReturnDate == DateTime.MaxValue || o.ReturnDate == DateTime.MinValue) && (o.MemberID == status.MemberID || (status.AssignmentID != Guid.Empty && o.MemberID == status.AssignmentID)));


              
                // btnSignOut.Enabled = true;
            }
            else
            {
                btnViewDetails.Enabled = false;
              //  btnViewEquipment.Enabled = false;
              //  btnViewAssignment.Enabled = false;
            }
        }

        private void chkUnassignedOnly_CheckedChanged(object sender, EventArgs e)
        {
            BuildDataLists();
        }

        private void chkNotSignedInOnly_CheckedChanged(object sender, EventArgs e)
        {
            BuildDataLists();
        }

        private void btnBulkSignIn_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExportSignInToCSV_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "CheckIn-" + Program.CurrentIncident.IncidentIdentifier + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";





                List<MemberStatus> memberStatuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);
                string csv = Program.CurrentIncident.ExportSignInRecordsToCSV(memberStatuses, delimiter);

                try
                {
                    System.IO.File.WriteAllText(exportPath, csv);

                    DialogResult openNow = MessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                    if (openNow == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, there was a problem writing to the file.  Please report this error: " + ex.ToString());
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count == 1)
            {
                MemberStatus status = (MemberStatus)dgvPersonnel.SelectedRows[0].DataBoundItem;
                CheckInRecord record = getRecordFromStatus(status);
                OpenForView(record);
            }
        }

        private CheckInRecord getRecordFromStatus(MemberStatus status)
        {
            CheckInRecord record = null;
            if (status.CheckInRecordID != Guid.Empty && Program.CurrentIncident.AllCheckInRecords.Any(o => o.SignInRecordID == status.CheckInRecordID))
            {
                record = Program.CurrentIncident.AllCheckInRecords.First(o => o.SignInRecordID == status.CheckInRecordID);
            }
            else
            {
                record = new CheckInRecord();
                record.OpPeriod = Program.CurrentOpPeriod;
                record.CheckInDate = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodStart;
                record.LastDayOnIncident = record.CheckInDate.AddDays(14);
                record.ResourceType = "Person";
                if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.PersonID == status.MemberID))
                {
                    record.ResourceID = Program.CurrentIncident.IncidentPersonnel.First(o => o.PersonID == status.MemberID).ID;
                    record.ResourceName = Program.CurrentIncident.IncidentPersonnel.First(o => o.PersonID == status.MemberID).ResourceName;
                    
                }

            }

            return record;
        }

        private void OpenForView(CheckInRecord record)
        {
            using (PersonnelViewCheckinForm viewForm = new PersonnelViewCheckinForm())
            {
                viewForm.record = record;
                viewForm.ShowDialog();
            }
        }
        private void dgvPersonnel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MemberStatus status = (MemberStatus)dgvPersonnel.Rows[e.RowIndex].DataBoundItem;
                CheckInRecord record = getRecordFromStatus(status);
                OpenForView(record);
            }

        }

        private void btnUpdateTimes_Click(object sender, EventArgs e)
        {
            List<MemberStatus> statuses = new List<MemberStatus>();
            foreach(DataGridViewRow row in dgvPersonnel.SelectedRows)
            {
                statuses.Add(row.DataBoundItem as MemberStatus);
            }

            List<CheckInRecord> records = new List<CheckInRecord>();
            foreach(MemberStatus status in statuses)
            {
               records.Add(getRecordFromStatus(status));
            }

            if (records.Any())
            {
                using (PersonnelEditCheckInOutForm editForm = new PersonnelEditCheckInOutForm())
                {
                    editForm.records = records;
                    editForm.ShowDialog();
                }
            }
        }

        private void dgvPersonnel_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPersonnel.Rows.Count > 0 && e.RowIndex <= dgvPersonnel.Rows.Count && dgvPersonnel.Rows[e.RowIndex] != null)
            {
                

                DataGridViewRow row = dgvPersonnel.Rows[e.RowIndex];

                int AssignmentColumnIndex = row.Cells["colAssignment"].ColumnIndex;
                int LDWColumnIndex = row.Cells["colLDW"].ColumnIndex;
                int CheckInColumnIndex = row.Cells["colCheckIn"].ColumnIndex;


                MemberStatus status = (MemberStatus)row.DataBoundItem;


                if (status.getCurrentActivityName == "Signed Out") 
                {
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Style.BackColor = Color.LightGray;
                        c.Style.ForeColor = Color.DarkGray;
                    }

                }
                else if (!status.IsAssigned)
                {
                    row.Cells[AssignmentColumnIndex].Style.BackColor = Program.GoodColor;
                }
                else
                {
                    row.Cells[AssignmentColumnIndex].Style.BackColor = Color.White;
                }


                if (status.SignInTime == DateTime.MinValue)
                {
                    row.Cells[CheckInColumnIndex].Style.BackColor = Color.Yellow;
                }

                if (Program.CurrentIncident.AllCheckInRecords.Any(o => o.SignInRecordID == status.CheckInRecordID))
                {
                   CheckInRecord rec = Program.CurrentIncident.AllCheckInRecords.First(o => o.SignInRecordID == status.CheckInRecordID);
                    TimeSpan ts = rec.LastDayOnIncident - Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodEnd;
                    if(ts.TotalHours <= 36)
                    {
                        row.Cells[LDWColumnIndex].Style.BackColor = Color.LightCoral;

                    }
                }

                
            }
        }

        private void btnSignInSelected_Click(object sender, EventArgs e)
        {
            List<MemberStatus> statuses = new List<MemberStatus>();
            foreach (DataGridViewRow row in dgvPersonnel.SelectedRows)
            {
                statuses.Add(row.DataBoundItem as MemberStatus);
            }

            List<CheckInRecord> records = new List<CheckInRecord>();
            foreach (MemberStatus status in statuses)
            {
                if(status.CheckInRecordID == Guid.Empty)
                {
                    CheckInRecord record = getRecordFromStatus(status);
                    records.Add(record);
                }
            }

            if (records.Any())
            {
                using (PersonnelEditCheckInOutForm editForm = new PersonnelEditCheckInOutForm())
                {
                    editForm.records = records;
                    editForm.ShowDialog();
                }
            }
        }

        private void chkLDWSoon_CheckedChanged(object sender, EventArgs e)
        {
            BuildDataLists();
        }
    }
}
