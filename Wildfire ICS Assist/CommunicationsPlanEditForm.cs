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
    public partial class CommunicationsPlanEditForm : Form
    {
        private CommsPlanItem _SelectedItem = null;
        public CommsPlanItem SelectedItem { get => _SelectedItem; }


        public CommunicationsPlanEditForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateNew()
        {
            if (string.IsNullOrEmpty(txtChannelID.Text)) { txtChannelID.BackColor = Program.ErrorColor; return false; } else { txtChannelID.BackColor = Program.GoodColor; }
            if (string.IsNullOrEmpty(txtFunction.Text)) { txtFunction.BackColor = Program.ErrorColor; return false; } else { txtFunction.BackColor = Program.GoodColor; }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
    }
}
