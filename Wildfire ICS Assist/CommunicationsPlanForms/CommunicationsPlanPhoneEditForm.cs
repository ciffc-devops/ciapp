using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.CommunicationsPlanForms
{
    public partial class CommunicationsPlanPhoneEditForm : BaseForm
    {
        public CommunicationsPlanPhoneEditForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);
        }

        public bool ShowSelectSaved
        {
            get { return splitContainer2.Panel1Collapsed; }
            set { ToggleShowSelectSaved(value); }
        }
        public bool SaveForLater { get { return chkSaveForLater.Checked; } }
        private CommsPlanItem _selectedItem;
        public CommsPlanItem SelectedItem { get { return _selectedItem; } set { _selectedItem = value; LoadSaved(); } }


        private void CommunicationsPlanPhoneEditForm_Load(object sender, EventArgs e)
        {
            //Load saved comms systems
           List<CommsPlanItem>  SavedCommsPlanItems = (List<CommsPlanItem>)Program.generalOptionsService.GetOptionsValue("allCommsPlanItems");
            cboSavedComms.DataSource = SavedCommsPlanItems.Where(o => !o.IsRadio).ToList();
            if (SavedCommsPlanItems.Count <= 0) { pnlSavedComms.Enabled = false; }

        }

        private void LoadSaved()
        {
            if(SelectedItem != null)
            {
                cboEditCommsSystem.Text = SelectedItem.CommsSystem;
                cboEditFunction.Text = SelectedItem.CommsFunction;
                txtEditName.Text = SelectedItem.ChannelID;
                txtEditAssignment.Text = SelectedItem.Assignment;
                txtEditNumber.Text = SelectedItem.PhoneNumber;
                txtEditURL.Text = SelectedItem.URL;
                chkEditUsedForAir.Checked = SelectedItem.UsedForAircraft;
                txtEditRemarks.Text = SelectedItem.Comments;

            }
        }

        private void ToggleShowSelectSaved(bool showSelectSaved)
        {
            splitContainer2.Panel1Collapsed = !showSelectSaved;
            btnSave.Visible = !showSelectSaved;

            btnAddNew.Visible = showSelectSaved;
            chkSaveForLater.Visible = showSelectSaved;

            if (showSelectSaved)
            {
                lblEditChannelTitle.Text = "Edit Non-Radio Communications Channel";
            } else
            {
                lblEditChannelTitle.Text = "Add New Non-Radio Communications Channel";
            }

        }

        private void btnAirHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);
        }

        private void btnSavedUsedForAir_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);
        }

        private void txtEditName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtEditName.Text)){ errorProvider1.SetError(txtEditName, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(txtEditName, ""); }
        }

        private void cboEditFunction_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(cboEditFunction.Text)){ errorProvider1.SetError(cboEditFunction, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(cboEditFunction, ""); }
        }

        private void cboSavedFunction_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(cboSavedFunction.Text)){ errorProvider1.SetError(cboSavedFunction, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(cboSavedFunction, ""); }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateEditForm())
            {
                saveEditValues();
                this.DialogResult = DialogResult.OK;
            }
        }
        private void saveEditValues()
        {
            SelectedItem.CommsSystem = cboEditCommsSystem.Text;
            SelectedItem.CommsFunction = cboEditFunction.Text;
            SelectedItem.ChannelID = txtEditName.Text;
            SelectedItem.Assignment = txtEditAssignment.Text;
            SelectedItem.PhoneNumber = txtEditNumber.Text;
            SelectedItem.URL = txtEditURL.Text;
            SelectedItem.UsedForAircraft = chkEditUsedForAir.Checked;
            SelectedItem.Assignment = txtEditAssignment.Text;
            SelectedItem.Comments = txtEditRemarks.Text;
        }

        private bool ValidateEditForm()
        {
                        if (string.IsNullOrEmpty(cboEditFunction.Text)) { errorProvider1.SetError(cboEditFunction, Properties.Resources.RequiredNote); return false; }
                        if (string.IsNullOrEmpty(txtEditName.Text)) { errorProvider1.SetError(txtEditName, Properties.Resources.RequiredNote); return false; }


            return true;
        }

        private bool ValidateSelectSavedForm()
        {
            if(string.IsNullOrEmpty(cboSavedFunction.Text)) { errorProvider1.SetError(cboSavedFunction, Properties.Resources.RequiredNote); return false; } 
            if(cboSavedComms.SelectedItem == null) { errorProvider1.SetError(cboSavedComms, Properties.Resources.RequiredNote); return false; }
            return true;
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if (ValidateSelectSavedForm())
            {
                SelectedItem = ((CommsPlanItem)cboSavedComms.SelectedItem).Clone();
                SelectedItem.CommsFunction = cboSavedFunction.Text;
                SelectedItem.Assignment = txtSavedAssignment.Text;
                SelectedItem.UsedForAircraft = chkSavedUsedForAir.Checked;
                SelectedItem.ID = Guid.NewGuid();
                chkSaveForLater.Checked = false;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateEditForm())
            {
                saveEditValues();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
