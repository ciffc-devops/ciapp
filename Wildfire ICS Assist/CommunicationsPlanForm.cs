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
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsPlanForm : Form
    {
        public CommunicationsPlanForm()
        {
            InitializeComponent();
        }


        private void BuildDataList()
        {
            if(!Program.CurrentIncident.allCommsPlans.Any(o => o.OpsPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
                Program.wfIncidentService.UpsertCommsPlan(Program.CurrentIncident.allCommsPlans.First(o => o.OpsPeriod == Program.CurrentOpPeriod));
            }
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpsPeriod == Program.CurrentOpPeriod);
            List<CommsPlanItem> items = 

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
