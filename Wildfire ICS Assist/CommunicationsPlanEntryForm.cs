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
    public partial class CommunicationsPlanEntryForm : Form
    {
        private CommsPlanItem _SelectedItem = null;
        public CommsPlanItem SelectedItem { get => _SelectedItem; }
        public bool SaveForLater { get => chkSaveForLater.Checked; }

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
                this.DialogResult = DialogResult.OK; this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                _SelectedItem = new CommsPlanItem();
                _SelectedItem.CommsSystem = txtCommsSystem.Text;
                _SelectedItem.ChannelID = txtChannelID.Text;
                _SelectedItem.Frequency = txtFrequency.Text;
                _SelectedItem.CommsFunction = txtFunction.Text;
                _SelectedItem.Tone = txtTone.Text;
                _SelectedItem.Assignment = txtAssignment.Text;
                _SelectedItem.Comments = txtComments.Text;
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
            if (string.IsNullOrEmpty(txtChannelID.Text)) { txtChannelID.BackColor = Program.ErrorColor; return false; } else { txtChannelID.BackColor = Program.GoodColor; }
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
            SavedCommsPlanItems.Clear();
            SavedCommsPlanItems = (List<CommsPlanItem>)Program.generalOptionsService.GetOptionsValue("CommsItems");
            cboSavedComms.DataSource = SavedCommsPlanItems;
        }

        private void cboSavedComms_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
