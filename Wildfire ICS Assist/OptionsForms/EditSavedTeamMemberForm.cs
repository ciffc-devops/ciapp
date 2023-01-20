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
    public partial class EditSavedTeamMemberForm : Form
    {
        public TeamMember selectedMember { get => editTeamMemberControl1.teamMember; set { editTeamMemberControl1.teamMember = value; } } 


        public EditSavedTeamMemberForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editTeamMemberControl1.FormValid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void EditSavedTeamMemberForm_Load(object sender, EventArgs e)
        {

        }

        private void editTeamMemberControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
