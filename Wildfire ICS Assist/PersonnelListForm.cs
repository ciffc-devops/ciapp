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
            BuildDataLists();
            Program.wfIncidentService.MemberSignInChanged += Program_TeamMembersUpdated;
            cpnlAgencyTotals.CurrentlyCollapsed = true;

        }

        private void Program_TeamMembersUpdated(MemberEventArgs e)
        {
            BuildDataLists();
        }


        private void BuildDataLists()
        {
            dgvPersonnel.DataSource = null;
            List<MemberStatus> memberStatuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);
            if(chkNotSignedInOnly.Checked)
            {
                memberStatuses = memberStatuses.Where(o => o.SignInTime <= DateTime.MinValue).ToList();
            }
            if (chkUnassignedOnly.Checked) { memberStatuses = memberStatuses.Where(o => !o.IsAssigned).ToList(); }

            dgvPersonnel.AutoGenerateColumns = false;
            dgvPersonnel.DataSource = memberStatuses;

            dgvTotalByAgency.AutoGenerateColumns = false;
            dgvTotalByAgency.DataSource = null;
            List<AgencyPersonnelCount> agencyCounts = Program.CurrentIncident.GetAgencyPersonnelCount(Program.CurrentOpPeriod);
            dgvTotalByAgency.DataSource = agencyCounts;


        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            using (PersonnelSignInForm signInForm = new PersonnelSignInForm())
            {
                DialogResult dr = signInForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    SignInRecord record = signInForm.signInRecord;
                    record.IsSignIn = true;
                    Program.wfIncidentService.UpsertMemberStatus(record);
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
                btnEdit.Enabled = true;
                MemberStatus status = statuses[0]; //(MemberStatus)dgvMembersOnTask.SelectedRows[0].DataBoundItem;
                btnViewEquipment.Enabled = Program.CurrentIncident.allEquipmentIssues.Any(o => o.OpPeriod == Program.CurrentOpPeriod && (o.ReturnDate == DateTime.MaxValue || o.ReturnDate == DateTime.MinValue) && (o.MemberID == status.MemberID || (status.AssignmentID != Guid.Empty && o.MemberID == status.AssignmentID)));


                if (status.AssignmentName != "Unassigned")
                {
                    btnViewAssignment.Enabled = true;
                }
                else
                {
                    btnViewAssignment.Enabled = false;
                }
                // btnSignOut.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnViewEquipment.Enabled = false;
                btnViewAssignment.Enabled = false;
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
            using (PersonnelBulkCheckInForm signInForm = new PersonnelBulkCheckInForm())
            {
                DialogResult dr = signInForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    foreach (SignInRecord record in signInForm.records)
                    {
                        record.IsSignIn = true;
                        Program.wfIncidentService.UpsertMemberStatus(record);
                    }
                }
            }
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
    }
}
