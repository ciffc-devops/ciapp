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
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class PositionLogAddForm : Form
    {
        private PositionLogEntry _thisEntry;
        public PositionLogEntry thisEntry { get => _thisEntry; set { _thisEntry = value; loadEntry(); } }
        string currentUser { get => Program.CurrentTask.getNameByRoleID(Program.CurrentOpPeriod, Program.CurrentRole.RoleID, false); }

        public PositionLogAddForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
            this.Icon = Program.programIcon;
            GeneralTools.SetDateFormat(this);

        }

        private void PositionLogAddForm_Load(object sender, EventArgs e)
        {
            lblEntryText.Text = "Entry Text - " + thisEntry.Role.RoleName;
        }

        private void loadEntry()
        {
            rbInfoOnly.Checked = thisEntry.IsInfoOnly;
            rbTrackProgress.Checked = !thisEntry.IsInfoOnly;
            datDateCreated.Value = thisEntry.DateCreated;
            txtEntryText.Text = thisEntry.LogText;
            datDueDate.Value = thisEntry.TimeDue;
            chkComplete.Checked = thisEntry.IsComplete;
            chkReminder.Checked = thisEntry.ReminderTime != DateTime.MinValue;
            if (thisEntry.ReminderTime > DateTime.MinValue) { datReminderTime.Value = thisEntry.ReminderTime; }
            else { datReminderTime.Value = datDueDate.Value; }
        }

        private void rbInfoOnly_CheckedChanged(object sender, EventArgs e)
        {
            thisEntry.IsInfoOnly = rbInfoOnly.Checked;
            pnlTrackProgress.Enabled = !rbInfoOnly.Checked;
        }

        private void rbTrackProgress_CheckedChanged(object sender, EventArgs e)
        {
            thisEntry.IsInfoOnly = rbInfoOnly.Checked;
            pnlTrackProgress.Enabled = !rbInfoOnly.Checked;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void datDateCreated_ValueChanged(object sender, EventArgs e)
        {

            thisEntry.updateDateCreated(datDateCreated.Value, currentUser);
        }

        private void chkComplete_CheckedChanged(object sender, EventArgs e)
        {
            thisEntry.updateIsComplete(chkComplete.Checked, currentUser);
        }

        private void datDueDate_ValueChanged(object sender, EventArgs e)
        {
            thisEntry.updateTimeDue(datDueDate.Value, currentUser);
        }

        private void datReminderTime_ValueChanged(object sender, EventArgs e)
        {
        }

        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (chkReminder.Checked) { thisEntry.ReminderTime = datReminderTime.Value; }
            else { thisEntry.ReminderTime = DateTime.MinValue; }
            */
            datReminderTime.Enabled = chkReminder.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            thisEntry.UpdateLogText(txtEntryText.Text, currentUser);
            if (chkReminder.Checked) { thisEntry.ReminderTime = datReminderTime.Value; }
            else { thisEntry.ReminderTime = DateTime.MinValue; }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtEntryText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
