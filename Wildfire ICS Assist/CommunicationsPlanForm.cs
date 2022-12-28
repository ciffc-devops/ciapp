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
    public partial class CommunicationsPlanForm : Form
    {
        public CommunicationsPlanForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CommunicationsPlanEntryForm entryForm = new CommunicationsPlanEntryForm())
            {
               DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {



                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpserOptionValue(entryForm.SelectedItem, "CommsItem");
                    }
                }
            }
        }
    }
}
