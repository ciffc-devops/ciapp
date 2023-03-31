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
        public CommsPlanItem commsPlanItem { get => editCommsChannelControl1.selectedItem; set => editCommsChannelControl1.selectedItem = value; }
        public EditCommsItemForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editCommsChannelControl1.IsComplete) { this.DialogResult = DialogResult.OK; this.Close(); }
            else { MessageBox.Show("You must enter a name for this channel"); }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditCommsItem_Load(object sender, EventArgs e)
        {

        }

       
    }
}
