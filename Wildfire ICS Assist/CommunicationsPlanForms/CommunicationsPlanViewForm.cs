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
    public partial class CommunicationsPlanViewForm : BaseForm
    {
        private CommsPlanItem _SelectedItem = null;
        public CommsPlanItem SelectedItem { get => _SelectedItem; set { _SelectedItem = value; loadSelectedCommsPlanItem(); } }
        private void loadSelectedCommsPlanItem()
        {
            lblSystem.Text = SelectedItem.CommsSystem;
            lblChannelID.Text = SelectedItem.ChannelID;
            lblFrequency.Text = SelectedItem.FullFrequency;
            lblFunction.Text = SelectedItem.CommsFunction;
            lblTone.Text = SelectedItem.FullTone;
            lblAssignment.Text = SelectedItem.Assignment;
            lblRemarks.Text = SelectedItem.Comments;
            this.Text = SelectedItem.IDWithFrequency;
        }
        public CommunicationsPlanViewForm()
        {
            InitializeComponent(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenForEdit(SelectedItem);
        }

        private void OpenForEdit(CommsPlanItem item)
        {
            using (CommunicationsPlanEditForm editForm = new CommunicationsPlanEditForm())
            {
                editForm.SelectedItem = item;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertCommsPlanItem(editForm.SelectedItem.Clone(), null, "local");

                }
            }
        }

        private void CommunicationsPlanViewForm_Load(object sender, EventArgs e)
        {
            Program.incidentDataService.CommsPlanItemChanged += Program_OnCommsPlanItemChanged;
        }

        private void Program_OnCommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if (e.item.ItemID == SelectedItem.ItemID) { loadSelectedCommsPlanItem(); }
        }
    }
}
