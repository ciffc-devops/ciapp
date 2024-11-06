using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models.GeneralModels;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WF_ICS_ClassLibrary.EventHandling;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class DeletedItemsForm : BaseForm
    {
        private List<DeletedItemRecord> _DeletedItems = new List<DeletedItemRecord>();
        public List<DeletedItemRecord> DeletedItems { get => _DeletedItems; private set { _DeletedItems = value; } }

        public DeletedItemsForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            SetControlColors(this.Controls);

        }

        public void SetDeletedItems(List<DeletedItemRecord> deletedItems)
        {


            DeletedItems = deletedItems.OrderBy(o => o.DateDeleted).ToList();
            dataGridView1.DataSource = DeletedItems;
        }

        private void SarTaskService_TaskUpdateChanged(WF_ICS_ClassLibrary.EventHandling.TaskUpdateEventArgs e)
        {
            List<DeletedItemRecord> records = Program.CurrentTask.GetDeletedItemRecords(Program.CurrentOpPeriod);
            SetDeletedItems(records);
        }

        private void DeletedItemsForm_Load(object sender, EventArgs e)
        {
            List<DeletedItemRecord> records = Program.CurrentTask.GetDeletedItemRecords(Program.CurrentOpPeriod);
            SetDeletedItems(records);
            Program.incidentDataService.TaskUpdateChanged += SarTaskService_TaskUpdateChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += IncidentDataService_CurrentOpPeriodChanged; ;
        }

        private void IncidentDataService_CurrentOpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            List<DeletedItemRecord> records = Program.CurrentTask.GetDeletedItemRecords(Program.CurrentOpPeriod);
            SetDeletedItems(records);
        }

     

        private void btnRestore_Click(object sender, EventArgs e)
        {
            List<DeletedItemRecord> records = new List<DeletedItemRecord>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                records.Add((DeletedItemRecord)row.DataBoundItem);
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to restore " + records.Count + " items?", "Restore Items", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (DeletedItemRecord record in records)
                {
                    TaskUpdate LastUpdateForItem = Program.CurrentTask.GetLastUpdateByItemID(record.Id);
                    if (LastUpdateForItem != null)
                    {
                        TaskUpdate newUpdate = Program.incidentDataService.CreateTaskUpdateForItem(LastUpdateForItem.Data.Clone(), "UPSERT");

                        newUpdate.Data = LastUpdateForItem.Data.Clone();
                        newUpdate.Data.LastUpdatedUTC = DateTime.UtcNow;
                        newUpdate.Data.Active = true;

                        Program.incidentDataService.ProcessTaskUpdate(newUpdate);
                    }
                }

                MessageBox.Show("Done!");
            }


        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("RestoreDeleted"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }
    }
}
