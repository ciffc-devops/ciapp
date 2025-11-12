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
    public partial class CommunicationsPlanEditForm : BaseForm
    {
        public CommsPlanItem SelectedItem { get => editCommsChannelControl1.selectedItem; set { editCommsChannelControl1.selectedItem = value; loadSelectedCommsPlanItem(); } }


        public CommunicationsPlanEditForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void loadSelectedCommsPlanItem()
        {
            cboNewFunction.Text = SelectedItem.CommsFunction;
            txtAssignment.Text = SelectedItem.Assignment;
            chkUsedForAir.Checked = SelectedItem.UsedForAircraft;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateNew()
        {
            if (!editCommsChannelControl1.IsComplete) {  return false; } 
            if (string.IsNullOrEmpty(cboNewFunction.Text)) { errorProvider1.SetError(cboNewFunction, "This is required"); return false; } else { errorProvider1.SetError(cboNewFunction, ""); }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                //_SelectedItem = new CommsPlanItem();
                editCommsChannelControl1.selectedItem.CommsFunction = cboNewFunction.Text;
                editCommsChannelControl1.selectedItem.Assignment = txtAssignment.Text;
                editCommsChannelControl1.selectedItem.UsedForAircraft = chkUsedForAir.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CommunicationsPlanEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAirHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void cboNewFunction_TextUpdate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboNewFunction.Text)) { errorProvider1.SetError(cboNewFunction, "This is required");  } else { errorProvider1.SetError(cboNewFunction, ""); }


        }
    }
}
