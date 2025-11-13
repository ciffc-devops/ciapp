using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.CommunicationsPlanForms
{
    public partial class CommunicationsPlanNonRadioViewForm : BaseForm
    {
        private CommsPlanItem _SelectedItem = null;
        public CommsPlanItem SelectedItem { get => _SelectedItem; set { _SelectedItem = value; loadSelectedCommsPlanItem(); } }
        private void loadSelectedCommsPlanItem()
        {
            lblSystem.Text = SelectedItem.CommsSystem;
            lblChannelID.Text = SelectedItem.ChannelID;
            lblPhoneNumber.Text = SelectedItem.PhoneNumber;
            lblFunction.Text = SelectedItem.CommsFunction;
            llURL.Text = SelectedItem.URL;
            llURL.Click += LlURL_Click;
            lblAssignment.Text = SelectedItem.Assignment;
            lblRemarks.Text = SelectedItem.Comments;
            this.Text = SelectedItem.IDWithFrequency;
        }

        private void LlURL_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedItem.URL) && SelectedItem.URL.isValidURL())
            {
                System.Diagnostics.Process.Start(SelectedItem.URL);
            }
        }

        public CommunicationsPlanNonRadioViewForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);
        }

        private void CommunicationsPlanNonRadioViewForm_Load(object sender, EventArgs e)
        {
            Program.incidentDataService.CommsPlanItemChanged += IncidentDataService_CommsPlanItemChanged;
            Program.incidentDataService.CommsPlanChanged += IncidentDataService_CommsPlanChanged;
        }

        private void IncidentDataService_CommsPlanChanged(WF_ICS_ClassLibrary.EventHandling.CommsPlanEventArgs e)
        {
            if (e.item.OpPeriod == SelectedItem.OpPeriod)
            {
                if (e.item.ActiveCommsItems.Any(c => c.ItemID == SelectedItem.ItemID))
                {
                    SelectedItem = e.item.ActiveCommsItems.First(c => c.ItemID == SelectedItem.ItemID).Clone();
                    loadSelectedCommsPlanItem();
                }
            }
        }

        private void IncidentDataService_CommsPlanItemChanged(WF_ICS_ClassLibrary.EventHandling.CommsPlanItemEventArgs e)
        {
            if (e.item.ItemID == SelectedItem.ItemID)
            {
                SelectedItem = e.item.Clone();
                loadSelectedCommsPlanItem();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (CommunicationsPlanPhoneEditForm editForm = new CommunicationsPlanPhoneEditForm())
            {
                editForm.SelectedItem = SelectedItem.Clone();
                editForm.ShowSelectSaved = false;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertCommsPlanItem(editForm.SelectedItem.Clone(), null, "local");

                }
            }
        }
    }
}
