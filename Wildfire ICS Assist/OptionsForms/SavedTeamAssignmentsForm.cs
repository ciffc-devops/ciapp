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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class SavedTeamAssignmentsForm : Form
    {
        public SavedTeamAssignmentsForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            dgvAssignments.BackgroundColor = Program.FormAccent;
        }

        private void SavedTeamAssignmentsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            BuildAssignmentList();
        }

        private void BuildAssignmentList()
        {
            dgvAssignments.AutoGenerateColumns = false;
            dgvAssignments.DataSource = null;
            List<TeamAssignment> assignments = (List<TeamAssignment>)Program.generalOptionsService.GetOptionsValue("TeamAssignments");
            assignments = assignments.Where(o=>o.Active).OrderBy(o=>o.ResourceName).ToList();
            dgvAssignments.DataSource = assignments;

        }

        private void OpenForEdit(TeamAssignment assignment)
        {
            using (EditSavedTeamAssignmentsForm editForm = new EditSavedTeamAssignmentsForm())
            {
                editForm.selectedAssignment = assignment;
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editForm.selectedAssignment, "TeamAssignment");
                    BuildAssignmentList();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TeamAssignment assignment = new TeamAssignment();
            OpenForEdit(assignment);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvAssignments.SelectedRows.Count == 1)
            {
                TeamAssignment assignment = (TeamAssignment)dgvAssignments.SelectedRows[0].DataBoundItem;
                OpenForEdit(assignment);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvAssignments.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<TeamAssignment> toDelete = new List<TeamAssignment>();
                foreach(DataGridViewRow row in dgvAssignments.SelectedRows)
                {
                    toDelete.Add((TeamAssignment)row.DataBoundItem);
                }
                foreach(TeamAssignment ta in toDelete)
                {
                    ta.Active = false;
                    Program.generalOptionsService.UpserOptionValue(ta, "TeamAssignment");
                }
                BuildAssignmentList();
            }
        }

        private void dgvAssignments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TeamAssignment ta = (TeamAssignment)dgvAssignments.Rows[e.RowIndex].DataBoundItem;
                OpenForEdit(ta);
            }
        }

        private void dgvAssignments_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvAssignments.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvAssignments.SelectedRows.Count > 0;
        }
    }
}
