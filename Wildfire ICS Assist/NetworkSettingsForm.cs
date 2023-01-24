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
    public partial class NetworkSettingsForm : Form
    {
        public NetworkSettingsForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void NetworkSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
