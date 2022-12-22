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
    public partial class EditCommsItemForm : Form
    {
        private CommsPlanItem _commsPlanItem = null;
        public CommsPlanItem commsPlanItem { get => _commsPlanItem; set { _commsPlanItem = value; displayItem(); } }
        public EditCommsItemForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void displayItem()
        {
            txtChannelID.Text = commsPlanItem.ChannelID;
            txtComments.Text = commsPlanItem.Comments;
            txtCommsSystem.Text  = commsPlanItem.CommsSystem;
            txtFrequency.Text = commsPlanItem.Frequency;
            txtTone.Text = commsPlanItem.Tone;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtChannelID.Text)) { this.DialogResult = DialogResult.OK; this.Close(); }
            else { MessageBox.Show("You must enter a name for this channel"); }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtCommsSystem_TextChanged(object sender, EventArgs e)
        {
            commsPlanItem.CommsSystem = ((TextBox)sender).Text;
        }

        private void txtChannelID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text)) { ((TextBox)sender).BackColor = Color.Salmon; }
            else { ((TextBox)sender).BackColor = Color.LightGreen; }
            commsPlanItem.ChannelID = ((TextBox)sender).Text;
        }

        private void txtFrequency_TextChanged(object sender, EventArgs e)
        {
            commsPlanItem.Frequency = ((TextBox)sender).Text;
        }

        private void txtTone_TextChanged(object sender, EventArgs e)
        {
            commsPlanItem.Tone = ((TextBox)sender).Text;

        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            commsPlanItem.Comments = ((TextBox)sender).Text;
        }

        private void btnCommsSystemHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void EditCommsItem_Load(object sender, EventArgs e)
        {

        }
    }
}
