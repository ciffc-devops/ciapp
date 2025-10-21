using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditSavedSafetyNoteForm : BaseForm
    {
        private SafetyMessage _selectedMessage = null;
        public SafetyMessage selectedMessage { get => _selectedMessage; set { _selectedMessage = value; LoadMessage(); } }

        private void LoadMessage()
        {
            txtSummaryLine.Text = selectedMessage.SummaryLine;
            if (!string.IsNullOrEmpty(selectedMessage.Message)) { txtMessage.Text = selectedMessage.Message.Replace("\n", Environment.NewLine); }
            else { txtMessage.Text = string.Empty; }
        }
        public EditSavedSafetyNoteForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
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
                //selectedMessage.Message = Regex.Replace(selectedMessage.Message, "(?<!\r)\n", "\r\n");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            bool isGood = true;
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; isGood = false; }
            else { txtSummaryLine.BackColor = SystemColors.Window; }

            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; isGood = false; }
            else { txtMessage.BackColor = SystemColors.Window;}
            return isGood;
        }

        private void txtSummaryLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; }
            else { txtSummaryLine.BackColor = SystemColors.Window;  }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; }
            else { txtMessage.BackColor = SystemColors.Window; }

        }

        private void EditSavedSafetyNoteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
