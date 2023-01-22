using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class SavedTeamAssignmentsForm : Form
    {
        public SavedTeamAssignmentsForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            dgvAssignments.BackgroundColor = Program.FormAccent;
        }

        private void SavedTeamAssignmentsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
