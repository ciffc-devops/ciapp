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
using Wildfire_ICS_Assist.UtilityForms;


namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsPlanEntryForm : BaseForm
    {
        private CommsPlanItem _SelectedItem = null;
        public CommsPlanItem SelectedItem { get => _SelectedItem; }
        public bool SaveForLater { get => chkSaveForLater.Checked; }
        public bool DefaultAircraft { get; set; } = false;

        List<CommsPlanItem> SavedCommsPlanItems { get;  set; }


        public CommunicationsPlanEntryForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboSavedComms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSaved();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if (ValidateSaved())
            {
                _SelectedItem = ((CommsPlanItem)cboSavedComms.SelectedItem).Clone();
                _SelectedItem.CommsFunction = txtSavedFunction.Text;
                _SelectedItem.Assignment = txtSavedAssignment.Text;
                _SelectedItem.OpPeriod = Program.CurrentOpPeriod;
                _SelectedItem.Active = true;
                _SelectedItem.UsedForAircraft = chkSavedUsedForAir.Checked;
                
                _SelectedItem.ItemID = Guid.NewGuid();
                this.DialogResult = DialogResult.OK; this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                _SelectedItem = editCommsChannelControl1.selectedItem;
                _SelectedItem.OpPeriod = Program.CurrentOpPeriod;
                _SelectedItem.CommsFunction = txtFunction.Text;
                _SelectedItem.Assignment = txtAssignment.Text;
                _SelectedItem.UsedForAircraft = chkUsedForAir.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateSaved()
        {


            if (string.IsNullOrEmpty(txtSavedFunction.Text)) { txtSavedFunction.BackColor = Program.ErrorColor; return false; } else { txtSavedFunction.BackColor = Program.GoodColor; }
            if(cboSavedComms.SelectedItem == null) { cboSavedComms.BackColor = Program.ErrorColor;  return false; } else { cboSavedComms.BackColor = Program.GoodColor; }
            return true;
        }

        private bool ValidateNew()
        {
            if (!editCommsChannelControl1.IsComplete) {  return false; } 
            if (string.IsNullOrEmpty(txtFunction.Text)) { txtFunction.BackColor = Program.ErrorColor; return false; } else { txtFunction.BackColor = Program.GoodColor; }

            return true;
        }

        private void txtChannelID_Leave(object sender, EventArgs e)
        {
            ValidateNew();
        }

        private void txtFunction_Leave(object sender, EventArgs e)
        {
            ValidateNew();
        }

        private void cboSavedComms_Leave(object sender, EventArgs e)
        {
            if (cboSavedComms.SelectedItem == null)
            {
                if (!string.IsNullOrEmpty(cboSavedComms.Text))
                {
                    if (SavedCommsPlanItems.Any(o => o.ChannelID.Equals(cboSavedComms.Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cboSavedComms.SelectedValue = SavedCommsPlanItems.Where(o => o.ChannelID.Equals(cboSavedComms.Text, StringComparison.InvariantCultureIgnoreCase)).First().ItemID;
                        _SelectedItem = (CommsPlanItem)cboSavedComms.SelectedItem;
                        //displaySelectedTeamMember();
                    }
                    else if (SavedCommsPlanItems.Any(o => o.IDWithFrequency.Equals(cboSavedComms.Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cboSavedComms.SelectedValue = SavedCommsPlanItems.Where(o => o.IDWithFrequency.Equals(cboSavedComms.Text, StringComparison.InvariantCultureIgnoreCase)).First().ItemID;
                        _SelectedItem = (CommsPlanItem)cboSavedComms.SelectedItem;


                    }
                    else
                    {
                        cboSavedComms.SelectedIndex = 0;
                        _SelectedItem = null;
                        System.Media.SystemSounds.Exclamation.Play();
                        cboSavedComms.Focus();
                    }
                }
                else
                {
                    cboSavedComms.SelectedIndex = 0;
                    _SelectedItem = null;
                    //System.Media.SystemSounds.Exclamation.Play();
                    //cboSavedComms.Focus();
                }


            }
            else { _SelectedItem = (CommsPlanItem)cboSavedComms.SelectedItem; }
        }

        private void CommunicationsPlanEntryForm_Load(object sender, EventArgs e)
        {

            SavedCommsPlanItems = (List<CommsPlanItem>)Program.generalOptionsService.GetOptionsValue("CommsItems");
            cboSavedComms.DataSource = SavedCommsPlanItems;
            if (SavedCommsPlanItems.Count <= 0) { pnlSavedComms.Enabled = false; }
            chkUsedForAir.Checked = DefaultAircraft;
            chkSavedUsedForAir.Checked = DefaultAircraft;
            editCommsChannelControl1.selectedItem = new CommsPlanItem();
        }

        private void cboSavedComms_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnAirHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);
        }
    }
}
