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
            assignment.ResourceIDNumber = Program.CurrentIncident.GetNextAssignmentNumber(Program.CurrentOpPeriod);
            OpenAssignmentForEdit(assignment);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvVehicles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
