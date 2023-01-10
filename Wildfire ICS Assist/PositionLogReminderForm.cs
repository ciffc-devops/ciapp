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

namespace Wildfire_ICS_Assist
{
    public partial class PositionLogReminderForm : Form
    {
        private PositionLogEntry _Entry;
        public PositionLogEntry Entry { get => _Entry; set { _Entry = value; loadEntry(); } }
        string currentUser { get => Program.CurrentTask.getNameByRoleID(Program.CurrentOpPeriod, Program.CurrentRole.RoleID, false); }

        public PositionLogReminderForm()
        {
            this.Icon = Program.programIcon;

            InitializeComponent(); this.BackColor = Program.FormBackground;
        }
        private void loadEntry()
        {
            lblReminderText.Text = Entry.LogText;
            datNewReminderTime.Value = DateTime.Now.AddHours(1);
        }

        private void btnMarkAsComplete_Click(object sender, EventArgs e)
        {
            if (Program.CurrentTask.allPositionLogEntries.Any(o => o.LogID == Entry.LogID))
            {

                Program.CurrentTask.allPositionLogEntries.Where(o => o.LogID == Entry.LogID).First().updateIsComplete(true, currentUser);
                MessageBox.Show("Marked as complete");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnSetNewReminder_Click(object sender, EventArgs e)
        {
            if (Program.CurrentTask.allPositionLogEntries.Any(o => o.LogID == Entry.LogID))
            {
                Program.CurrentTask.allPositionLogEntries.Where(o => o.LogID == Entry.LogID).First().ReminderTime = datNewReminderTime.Value;
                MessageBox.Show("New reminder set.");
                this.DialogResult = DialogResult.No;
                this.Close();
            }

        }
    }
}
