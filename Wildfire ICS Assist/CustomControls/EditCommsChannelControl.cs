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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class EditCommsChannelControl : UserControl
    {
        private CommsPlanItem _commsPlanItem = null;
        public CommsPlanItem selectedItem { get => _commsPlanItem; set { _commsPlanItem = value; displayItem(); } }

        public EditCommsChannelControl()
        {
            InitializeComponent();
        }

        private void displayItem()
        {
            if (_commsPlanItem != null)
            {
                txtChannelID.Text = selectedItem.ChannelID;
                txtComments.Text = selectedItem.Comments;
                txtCommsSystem.Text = selectedItem.CommsSystem;
                txtRxFrequency.Text = selectedItem.RxFrequency;
                txtRxTone.Text = selectedItem.RxTone;
                txtTxFrequency.Text = selectedItem.TxFrequency;
                txtTxTone.Text = selectedItem.TxTone;
            }
        }

        private void txtCommsSystem_TextChanged(object sender, EventArgs e)
        {
            selectedItem.CommsSystem = ((TextBox)sender).Text;

        }

        private void txtChannelID_TextChanged(object sender, EventArgs e)
        {
            selectedItem.ChannelID = ((TextBox)sender).Text;
            if (string.IsNullOrEmpty(((TextBox)sender).Text)) { ((TextBox)sender).BackColor = Program.ErrorColor; }
            else { ((TextBox)sender).BackColor = Program.GoodColor; }
        }

        private void txtRxFrequency_TextChanged(object sender, EventArgs e)
        {
            selectedItem.RxFrequency = ((TextBox)sender).Text;

        }

        private void txtRxTone_TextChanged(object sender, EventArgs e)
        {
            selectedItem.RxTone = ((TextBox)sender).Text;

        }

        private void txtTxFrequency_TextChanged(object sender, EventArgs e)
        {
            selectedItem.TxFrequency = ((TextBox)sender).Text;

        }

        private void txtTxTone_TextChanged(object sender, EventArgs e)
        {
            selectedItem.TxTone = ((TextBox)sender).Text;

        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            selectedItem.Comments = ((TextBox)sender).Text;

        }

        public bool IsComplete
        {
            get { return !string.IsNullOrEmpty(txtChannelID.Text); }
        }
    }
}
