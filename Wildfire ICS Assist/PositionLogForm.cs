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
    public partial class PositionLogForm : BaseForm
    {
        private WFIncident CurrentTask { get => Program.CurrentTask; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; }
        private ICSRole CurrentRole { get => Program.CurrentRole; }
        string currentUserName { get => Program.CurrentTask.getNameByRoleID(Program.CurrentOpPeriod, Program.CurrentRole.RoleID, false); }

        public PositionLogForm()
        {
           
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildPositionLog();

        }
        private void Program_PositionLogChanged(PositionLogEventArgs e)
        {
            buildPositionLog();
        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            buildPositionLog();
        }

        private void PositionLogForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            Program.wfIncidentService.PositionLogChanged += Program_PositionLogChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

            lblPositionName.Text = CurrentRole.RoleName;
            dgvLog.AutoGenerateColumns = false;
            cboSort.SelectedIndex = 0;
        }
        private void buildPositionLog()
        {
            List<PositionLogEntry> entries = CurrentTask.GetPositionLog(CurrentRole, CurrentOpPeriod);
            switch (cboSort.SelectedIndex)
            {
                case 0: //full log, newest first
                    entries = entries.OrderByDescending(o => o.DateCreated).ToList();
                    break;
                case 1: //full log, oldest first
                    entries = entries.OrderBy(o => o.DateCreated).ToList();
                    break;
                case 2: //pending, newest first
                    entries = entries.Where(o => !o.IsComplete && !o.IsInfoOnly).OrderByDescending(o => o.DateCreated).ToList();
                    break;
                case 3: //pending, oldest first
                    entries = entries.Where(o => !o.IsComplete && !o.IsInfoOnly).OrderBy(o => o.DateCreated).ToList();
                    break;
                case 4: //pending by Due date
                    entries = entries.Where(o => !o.IsComplete && !o.IsInfoOnly).OrderByDescending(o => o.TimeDue).ToList();
                    break;
            }
            dgvLog.DataSource = entries;
        }

        private void btnAddToPositionLog_Click(object sender, EventArgs e)
        {
            PositionLogEntry entry = new PositionLogEntry();
            entry.DateCreated = DateTime.Now;
            entry.TimeDue = CurrentTask.getOpPeriodEnd(CurrentOpPeriod);
            entry.ReminderTime = entry.TimeDue;
            entry.IsInfoOnly = true;
            entry.Role = Program.CurrentRole;
            entry.OpPeriod = CurrentOpPeriod;

            PositionLogAddForm _positionLogAddForm = new PositionLogAddForm();
            _positionLogAddForm.thisEntry = entry;
            DialogResult dr = _positionLogAddForm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Program.wfIncidentService.UpsertPositionLogEntry(_positionLogAddForm.thisEntry);// .CurrentTask.UpsertPositionLogEntry(_positionLogAddForm.thisEntry);
            }
        }

        private void OpenLogForEdit(PositionLogEntry entry)
        {
            PositionLogAddForm _positionLogAddForm = new PositionLogAddForm();
            _positionLogAddForm.thisEntry = entry;
            DialogResult dr = _positionLogAddForm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                Program.wfIncidentService.UpsertPositionLogEntry(_positionLogAddForm.thisEntry.Clone());
            }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvLog.SelectedRows)
                {
                    PositionLogEntry entry = (PositionLogEntry)row.DataBoundItem;
                    entry.UpdateLogText("-Deleted " + DateTime.Now.ToString(Program.DateFormat + " HH:mm") + "-", currentUserName);
                    entry.IsInfoOnly = true;
                    Program.wfIncidentService.UpsertPositionLogEntry(entry.Clone());

                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string path = Program.positionLogService.CreateICSPDF(Program.CurrentTask, Program.CurrentRole, Program.CurrentOpPeriod, null, false, false);
            try { System.Diagnostics.Process.Start(path); }
            catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }

        }

        private void btnPrintVerbose_Click(object sender, EventArgs e)
        {
            string path = Program.positionLogService.CreateVerbosePDF(Program.CurrentTask, Program.CurrentRole, Program.CurrentOpPeriod, null, false, false);
            try { System.Diagnostics.Process.Start(path); }
            catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }

        }

        private void dgvLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLog.SelectedRows.Count == 1)
            {
                PositionLogEntry entry = (PositionLogEntry)dgvLog.SelectedRows[0].DataBoundItem;
                OpenLogForEdit(entry);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count == 1)
            {
                PositionLogEntry entry = (PositionLogEntry)dgvLog.SelectedRows[0].DataBoundItem;
                OpenLogForEdit(entry);
            }

        }

        private void btnFormInfo_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("PositionLog"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void dgvLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = dgvLog.Rows[e.RowIndex];
            PositionLogEntry entry = (PositionLogEntry)row.DataBoundItem;
            if (!entry.IsComplete && !entry.IsInfoOnly)
            {
                DateTime today = DateTime.Now;
                TimeSpan ts = today - entry.TimeDue;

                if (ts.TotalMinutes > 0)
                {
                    row.Cells["colDueDate"].Style.BackColor = Color.Red;
                }
                else
                {
                    row.Cells["colDueDate"].Style.BackColor = Color.LightYellow;
                }
            }
            else { row.Cells["colDueDate"].Style.BackColor = Color.White; }
        }

    }
}
