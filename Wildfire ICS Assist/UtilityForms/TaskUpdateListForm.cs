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

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class TaskUpdateListForm : BaseForm
    {
        public TaskUpdateListForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);

        }

        private void TaskUpdateListForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Program.CurrentTask.allTaskUpdates;

            Program.incidentDataService.TaskUpdateChanged += Program_TaskUpdateChanged;

            dgvSummary.DataSource = getCountByTypeSummary();

        }

        private void Program_TaskUpdateChanged(TaskUpdateEventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Program.CurrentTask.allTaskUpdates;

            dgvSummary.DataSource = getCountByTypeSummary();

        }

        private List<TaskUpdateSummaryItem> getCountByTypeSummary()
        {
            List<TaskUpdateSummaryItem> summaryItems = new List<TaskUpdateSummaryItem>();

            List<TaskUpdate> updates = Program.CurrentTask.allTaskUpdates;

            foreach (TaskUpdate update in updates)
            {
                if (!summaryItems.Any(o => o.Label.Equals(update.ObjectType)))
                {
                    summaryItems.Add(new TaskUpdateSummaryItem(0, update.ObjectType));
                }
                summaryItems.First(o => o.Label.Equals(update.ObjectType)).NumberValue++;
            }

            return summaryItems;
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                TaskUpdate update = (TaskUpdate)dataGridView1.SelectedRows[0].DataBoundItem;
                using (TaskUpdateDetailsForm form = new TaskUpdateDetailsForm())
                {
                    form.SetTaskUpdate(update);
                    form.ShowDialog();
                }

            }
        }

        private void deleteTaskUpdateLocallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the local copy of this update? it will not impact internet sync or network sync users.  This should only be done to resolve issues with saving a file locally.  Proceed?", "Delete?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                List<TaskUpdate> updatesToDelete = new List<TaskUpdate>();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    TaskUpdate update = (TaskUpdate)row.DataBoundItem;
                    updatesToDelete.Add(update);
                }
                Program.CurrentTask.allTaskUpdates = Program.CurrentTask.allTaskUpdates.Except(updatesToDelete).ToList();
                MessageBox.Show("Task Update Deleted Locally");
                Program_TaskUpdateChanged(null);

            }
        }
    }

    class TaskUpdateSummaryItem
    {
        public TaskUpdateSummaryItem() { }
        public TaskUpdateSummaryItem(double numberValue, string label)
        {
            NumberValue = numberValue;
            Label = label;
        }

        public double NumberValue { get; set; }
        public string Label { get; set; }
    }
}
