using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;

namespace Wildfire_ICS_Assist
{
    public partial class IncidentDetailsForm : Form
    {
        public IncidentDetailsForm()
        {
            InitializeComponent();
        }

        private void llProgramURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = Globals.ProgramURL;
            if (null != target)
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {
                MessageBox.Show("Item clicked: " + target);
            }
        }
    }
}
