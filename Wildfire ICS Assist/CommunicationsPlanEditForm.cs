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
    public partial class CommunicationsPlanEditForm : Form
    {
        public CommsPlanItem SelectedItem { get => editCommsChannelControl1.selectedItem; set { editCommsChannelControl1.selectedItem = value; loadSelectedCommsPlanItem(); } }


        public CommunicationsPlanEditForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void loadSelectedCommsPlanItem()
        {
            txtFunction.Text = SelectedItem.CommsFunction;
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
            if (string.IsNullOrEmpty(txtFunction.Text)) { txtFunction.BackColor = Program.ErrorColor; return false; } else { txtFunction.BackColor = Program.GoodColor; }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                //_SelectedItem = new CommsPlanItem();
                editCommsChannelControl1.selectedItem.CommsFunction = txtFunction.Text;
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
    }
}
