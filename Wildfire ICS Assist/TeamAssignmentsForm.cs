using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class TeamAssignmentsForm : Form
    {
        public TeamAssignmentsForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            dgvAssignments.BackgroundColor = Program.FormAccent;
        }

        private void TeamAssignmentsForm_Load(object sender, EventArgs e)
        {
            Program.wfIncidentService.TeamAssignmentChanged += Program_AssignmentChanged;
            BuildAssignmentList();
        }

        private void BuildAssignmentList()
        {
            dgvAssignments.DataSource = null;
            dgvAssignments.AutoGenerateColumns = false;
            dgvAssignments.DataSource = Program.CurrentIncident.ActiveAssignments.Where(o=>o.OpPeriod == Program.CurrentOpPeriod).OrderBy(o=>o.ResourceIDNumber).ToList();
        }

        private void Program_AssignmentChanged (TeamAssignmentEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildAssignmentList();
            }
        }

        private void OpenAssignmentForEdit(TeamAssignment assignment)
        {
            using (TeamAssignmentEditForm editForm = new TeamAssignmentEditForm())
            {
                editForm.selectedAssignment = assignment;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertTeamAssignment(editForm.selectedAssignment.Clone());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TeamAssignment assignment = new TeamAssignment();
            assignment.OpPeriod = Program.CurrentOpPeriod;
            assignment.IncidentID = Program.CurrentIncident.TaskID;
            assignment.NumberOfPersons = 2;
            assignment.ResourceIDNumber = Program.CurrentIncident.GetNextAssignmentNumber(Program.CurrentOpPeriod);
            assignment.PreparedByRoleID = Program.CurrentRole.RoleID;
            assignment.PreparedByRoleName = Program.CurrentRole.RoleName;
            assignment.PreparedByIndividualName = Program.CurrentRole.IndividualName;
            OpenAssignmentForEdit(assignment);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvAssignments.SelectedRows.Count == 1)
            {
                TeamAssignment ta = dgvAssignments.SelectedRows[0].DataBoundItem as TeamAssignment;
                OpenAssignmentForEdit(ta);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvAssignments.SelectedRows.Count > 0)
            {
                if(MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<TeamAssignment> assignments = new List<TeamAssignment>();
                    foreach(DataGridViewRow row in dgvAssignments.SelectedRows)
                    {
                        assignments.Add(row.DataBoundItem as TeamAssignment);
                    }

                    foreach(TeamAssignment assignment in assignments)
                    {
                        assignment.Active = false;
                        Program.wfIncidentService.UpsertTeamAssignment(assignment);
                    }
                }
            }
        }

        private void dgvAssignments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TeamAssignment ta = (TeamAssignment)dgvAssignments.Rows[e.RowIndex].DataBoundItem;
                OpenAssignmentForEdit(ta);
            }
        }

        private void dgvAssignments_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvAssignments.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvAssignments.SelectedRows.Count > 0;
            btnPrintSelected.Enabled = btnDelete.Enabled;
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            List<Guid> DivisionIDs = new List<Guid>();
            List<TeamAssignment> assignments = Program.CurrentIncident.ActiveAssignments.Where(o=>o.OpPeriod == Program.CurrentOpPeriod).OrderBy(o=>o.DivisionName).ThenBy(o=>o.ResourceIDNumber).ToList();
            foreach(TeamAssignment ta in assignments)
            {
                if (!DivisionIDs.Contains(ta.ReportsToRoleID)) { DivisionIDs.Add(ta.ReportsToRoleID);}
            }

            List<byte[]> allPDFs = new List<byte[]>();
            foreach(Guid g in DivisionIDs)
            {
                allPDFs.AddRange(Program.pdfExportService.exportAssignmentListToPDF(Program.CurrentTask, Program.CurrentOpPeriod, g, null, null, false));
            }




            string fullFilepath = "";
            //int end = CurrentTask.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 204 - Task " + Program.CurrentIncident.IncidentIdentifier + " - Op - " + Program.CurrentOpPeriod + " Assignments";
            //fullFilepath = System.IO.Path.Combine(fullFilepath, outputFileName);
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);

                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
            }
        }
    }
}
