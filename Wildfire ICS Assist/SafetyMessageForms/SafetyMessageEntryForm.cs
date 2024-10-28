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

namespace Wildfire_ICS_Assist
{
    public partial class SafetyMessageEntryForm : BaseForm
    {

        private SafetyMessage _selectedMessage = new SafetyMessage();
        public SafetyMessage selectedMessage { get => _selectedMessage; set => _selectedMessage = value; }
        public bool SaveForLater { get => chkSaveForLater.Checked; }
        public SafetyMessageEntryForm()
        {
            InitializeComponent(); 
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SafetyMessageEntryForm_Load(object sender, EventArgs e)
        {
            BuildDataList();
            Program.incidentDataService.SafetyMessageChanged += Program_SafetyMessageChanged;
        }

        private void Program_SafetyMessageChanged(SafetyMessageEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod) { BuildDataList(); }
        }

        private void BuildDataList()
        {
            cboSaved.DataSource = null;
            List<SafetyMessage> list = (List<SafetyMessage>)Program.generalOptionsService.GetOptionsValue("SafetyMessages");
            list = list.Where(o => o.Active && !Program.CurrentIncident.allSafetyMessages.Any(m=>m.OpPeriod == Program.CurrentOpPeriod && m.SafetyTemplateID == o.SafetyTemplateID && m.Active)).OrderBy(o => o.SummaryLine).ToList();
            cboSaved.DataSource = list;
            if(list.Count <= 0) { pnlSaved.Enabled = false; }
        }

        private bool ValidateNew()
        {
            bool isGood = true;
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; isGood = false; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }

            if (string.IsNullOrEmpty(txtNewMessage.Text.Trim())) { txtNewMessage.BackColor = Program.ErrorColor; isGood = false; }
            else { txtNewMessage.BackColor = Program.GoodColor; }
            return isGood;

        }

        private void txtSummaryLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }

        }

        private void txtNewMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewMessage.Text.Trim())) { txtNewMessage.BackColor = Program.ErrorColor;}
            else { txtNewMessage.BackColor = Program.GoodColor; }

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                
                selectedMessage.Message = txtNewMessage.Text;
                selectedMessage.SummaryLine = txtSummaryLine.Text;
                selectedMessage.SitePlanRequired = chkNewSitePlanRequired.Checked;
                selectedMessage.SitePlanLocation = txtNewSitePlanLocation.Text;
                selectedMessage.SafetyTemplateID = Guid.Empty;
                selectedMessage.OpPeriod = Program.CurrentOpPeriod;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem != null)
            {
                selectedMessage = ((SafetyMessage)cboSaved.SelectedItem).Clone();
                selectedMessage.SitePlanLocation = txtSavedSitePlanLocation.Text;
                selectedMessage.SitePlanRequired = chkSavedSitePlanRequired.Checked;
                selectedMessage.CopyNextOpText = "Copy to selected op";
                selectedMessage.OpPeriod = Program.CurrentOpPeriod;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void cboSaved_Leave(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem == null)
            {
                cboSaved.SelectedIndex = -1;
                cboSaved.Text = string.Empty;
            }
        }
    }
}
