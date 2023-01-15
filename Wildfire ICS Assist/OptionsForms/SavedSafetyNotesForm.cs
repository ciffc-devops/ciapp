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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class SavedSafetyNotesForm : Form
    {
        public SavedSafetyNotesForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SafetyMessage msg = new SafetyMessage();
            msg.SafetyTemplateID = Guid.NewGuid();
            OpenForEdit(msg);
        }

        private void BuildDataList()
        {
            dgvSafetyNotes.AutoGenerateColumns = false;
            dgvSafetyNotes.DataSource = null;
            List<SafetyMessage> list = (List<SafetyMessage>)Program.generalOptionsService.GetOptionsValue("SafetyMessages");
            list = list.Where(o => o.Active).OrderBy(o=>o.SummaryLine).ToList();
            dgvSafetyNotes.DataSource = list;
        }

        private void OpenForEdit(SafetyMessage message)
        {
            using (EditSavedSafetyNoteForm editForm = new EditSavedSafetyNoteForm())
            {
                editForm.selectedMessage = message.Clone();
                DialogResult dr = editForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editForm.selectedMessage, "SafetyMessage");
                    BuildDataList();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvSafetyNotes.SelectedRows.Count == 1)
            {
                SafetyMessage msg = (SafetyMessage) dgvSafetyNotes.SelectedRows[0].DataBoundItem;
                OpenForEdit(msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<SafetyMessage> messages = new List<SafetyMessage>();
                foreach (DataGridViewRow row in dgvSafetyNotes.SelectedRows)
                {
                    messages.Add((SafetyMessage)row.DataBoundItem);
                }
                foreach (SafetyMessage sm in messages) { sm.Active = false; Program.generalOptionsService.UpserOptionValue(sm, "SafetyMessage"); }
                BuildDataList();
            }
        }

        private void SavedSafetyNotesForm_Load(object sender, EventArgs e)
        {
            BuildDataList();
        }
    }
}
