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

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class UpdateHistoryForm : BaseForm
    {
        private List<TaskUpdate> _Updates = new List<TaskUpdate>();
        public List<TaskUpdate> Updates { get => _Updates; private set { _Updates = value; } }

        private TaskUpdate _SelectedUpdate = null;
        public TaskUpdate SelectedUpdate { get => _SelectedUpdate; }

        public void SetUpdateList(List<TaskUpdate> updates)
        {
            Updates = updates.OrderBy(o => o.LastUpdatedUTC).ToList();
            dgvUpdates.DataSource = Updates;
        }

        public UpdateHistoryForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            dgvUpdates.AutoGenerateColumns = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvUpdates.SelectedRows.Count == 1 && dgvUpdates.SelectedRows[0].DataBoundItem != null)
            {
                string warning = "Are you sure you want to revert to this previous version of the item?";
                if (MessageBox.Show(warning, "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TaskUpdate update = ((TaskUpdate)dgvUpdates.SelectedRows[0].DataBoundItem).Clone();

                    update.LastUpdatedUTC = DateTime.UtcNow;
                    update.UpdateID = Guid.NewGuid();
                    update.CreatedByRoleName = Program.CurrentRole.RoleName;
                    update.Source = "local";
                    update.ProcessedLocally = false;



                    _SelectedUpdate = update;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void UpdateHistoryForm_Load(object sender, EventArgs e)
        {
            Program.incidentDataService.TaskUpdateChanged += SarTaskService_TaskUpdateChanged;
        }

        private void SarTaskService_TaskUpdateChanged(WF_ICS_ClassLibrary.EventHandling.TaskUpdateEventArgs e)
        {
            if (Updates.Any() && e.item.ItemID == Updates.First().ItemID)
            {
                List<TaskUpdate> updates = Program.CurrentTask.allTaskUpdates.Where(o => o.ItemID == Updates.First().ItemID).ToList();

                SetUpdateList(updates);
            }

        }

        private void UpdateHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.incidentDataService.TaskUpdateChanged -= SarTaskService_TaskUpdateChanged;

        }
    }
}