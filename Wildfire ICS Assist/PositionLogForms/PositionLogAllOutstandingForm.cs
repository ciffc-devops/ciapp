using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class PositionLogAllOutstandingForm : BaseForm
    {
        private Incident CurrentTask { get => Program.CurrentTask; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; }
        private ICSRole CurrentRole { get => Program.CurrentRole; }
        string currentUserName { get => Program.CurrentTask.getNameByRoleID(Program.CurrentOpPeriod, Program.CurrentRole.RoleID, false); }


        public PositionLogAllOutstandingForm()
        {
            
            InitializeComponent(); SetControlColors(this.Controls);
        }
        private void buildPositionLog()
        {
            List<PositionLogEntry> entries = CurrentTask.allPositionLogEntries.Where(o => o.OpPeriod == CurrentOpPeriod && !o.IsComplete && !o.IsInfoOnly).OrderBy(o => o.TimeDue).ToList();

            dgvLog.DataSource = entries;
        }

        private void Parent_PositionLogChanged(PositionLogEventArgs e)
        {
            buildPositionLog();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count == 1)
            {
                PositionLogEntry entry = (PositionLogEntry)dgvLog.SelectedRows[0].DataBoundItem;
                PositionLogViewDetailsForm _details = new PositionLogViewDetailsForm();
                _details.thisEntry = entry;
                _ = _details.ShowDialog(this);

            }
        }

        private void btnEditClue_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count == 1)
            {
                PositionLogEntry entry = (PositionLogEntry)dgvLog.SelectedRows[0].DataBoundItem;
                PositionLogAddForm _positionLogAddForm = new PositionLogAddForm();
                _positionLogAddForm.thisEntry = entry;
                DialogResult dr = _positionLogAddForm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertPositionLogEntry(_positionLogAddForm.thisEntry);

                    //buildPositionLog();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = LgMessageBox.Show("Are you sure you want to mark the selected log entry(ies) as deleted?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLog.SelectedRows)
                {
                    PositionLogEntry entry = (PositionLogEntry)row.DataBoundItem;
                    entry.UpdateLogText("-Deleted " + DateTime.Now.ToString(Globals.DateFormat + " HH:mm") + "-", currentUserName);
                    entry.IsInfoOnly = true;
                    Program.incidentDataService.UpsertPositionLogEntry(entry);


                    // buildPositionLog();

                }
            }
        }

        private void PositionLogAllOutstandingForm_Load(object sender, EventArgs e)
        {
            Program.incidentDataService.PositionLogChanged += Parent_PositionLogChanged;

            dgvLog.AutoGenerateColumns = false;
            buildPositionLog();
        }

        private void dgvLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLog.SelectedRows.Count == 1)
            {
                PositionLogEntry entry = (PositionLogEntry)dgvLog.SelectedRows[0].DataBoundItem;
                PositionLogAddForm _positionLogAddForm = new PositionLogAddForm();
                _positionLogAddForm.thisEntry = entry;
                DialogResult dr = _positionLogAddForm.ShowDialog(this);
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertPositionLogEntry(_positionLogAddForm.thisEntry);


                    //buildPositionLog();
                }
            }
        }
    }
}
