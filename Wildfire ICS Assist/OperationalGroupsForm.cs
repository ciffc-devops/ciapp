using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupsForm : Form
    {
        public OperationalGroupsForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void OperationalGroupsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
