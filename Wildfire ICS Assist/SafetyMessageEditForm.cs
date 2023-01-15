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
    public partial class SafetyMessageEditForm : Form
    {
        private SafetyMessage _selectedMessage = null;
        public SafetyMessage selectedMessage { get => _selectedMessage; set { _selectedMessage = value; LoadMessage(); } }

        private void LoadMessage()
        {
            txtSummaryLine.Text = selectedMessage.SummaryLine;
            if (!string.IsNullOrEmpty(selectedMessage.Message)) { txtMessage.Text = selectedMessage.Message.Replace("\n", Environment.NewLine); }
            else { txtMessage.Text = string.Empty; }
            txtNewSitePlanLocation.Text = selectedMessage.SitePlanLocation;
            chkNewSitePlanRequired.Checked = selectedMessage.SitePlanRequired;

        }
        public SafetyMessageEditForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                selectedMessage.SummaryLine = txtSummaryLine.Text;

                selectedMessage.Message = txtMessage.Text;

                selectedMessage.SitePlanLocation = txtNewSitePlanLocation.Text;
                selectedMessage.SitePlanRequired= chkNewSitePlanRequired.Checked;   
                //selectedMessage.Message = Regex.Replace(selectedMessage.Message, "(?<!\r)\n", "\r\n");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            bool isGood = true;
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; isGood = false; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }

            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; isGood = false; }
            else { txtMessage.BackColor = Program.GoodColor; }
            return isGood;
        }

        private void txtSummaryLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; }
            else { txtMessage.BackColor = Program.GoodColor; }

        }

        private void SafetyMessageEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
