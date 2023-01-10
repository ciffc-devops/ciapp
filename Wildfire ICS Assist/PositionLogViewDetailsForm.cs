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

namespace Wildfire_ICS_Assist
{
    public partial class PositionLogViewDetailsForm : Form
    {
        private PositionLogEntry _thisEntry;
        public PositionLogEntry thisEntry { get => _thisEntry; set { _thisEntry = value; loadEntry(); } }

        public PositionLogViewDetailsForm()
        {
            this.Icon = Program.programIcon;

            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void loadEntry()
        {
            txtCurrentLog.Text = thisEntry.LogText;

            txtHistory.Text = thisEntry.LogHistoryString;
        }

    }
}
