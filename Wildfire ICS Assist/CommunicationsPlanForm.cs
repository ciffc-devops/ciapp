using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsPlanForm : Form
    {
        public CommunicationsPlanForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }
        private void CommunicationsPlanForm_Load(object sender, EventArgs e)
        {
            BuildDataList();
            Program.wfIncidentService.CommsPlanChanged += Program_OnCommsPlanChanged;
            Program.wfIncidentService.CommsPlanItemChanged += Program_OnCommsPlanItemChanged;
        }


        private void Program_OnCommsPlanChanged(CommsPlanEventArgs e)
        {
            if(e.item.OpsPeriod == Program.CurrentOpPeriod) { BuildDataList(); }
        }
        private void Program_OnCommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if(e.item.OpsPeriod == Program.CurrentOpPeriod) { BuildDataList(); }
        }
        private void BuildDataList()
        {
            dgvCommsItems.AutoGenerateColumns = false;
            dgvCommsItems.DataSource = null;
            if(!Program.CurrentIncident.allCommsPlans.Any(o => o.OpsPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
            }
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpsPeriod == Program.CurrentOpPeriod);

            dgvCommsItems.DataSource = plan.ActiveCommsItems;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CommunicationsPlanEntryForm entryForm = new CommunicationsPlanEntryForm())
            {
               DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    entryForm.SelectedItem.OpsPeriod = Program.CurrentOpPeriod;
                    
                    Program.wfIncidentService.UpsertCommsPlanItem(entryForm.SelectedItem, null, "local");


                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpserOptionValue(entryForm.SelectedItem, "CommsItem");
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void dgvCommsItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCommsItems_SelectionChanged(object sender, EventArgs e)
        {

        }

    }
}
