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
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class CommunicationsPlanForm : BaseForm
    {
        private const int RowsPerSheet = 27;
        SortableBindingList<CommsPlanItem> items = null;

        public CommunicationsPlanForm()
        {
           
            InitializeComponent();
            dgvCommsItems.AutoGenerateColumns = false;
        }
        private void CommunicationsPlanForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }

            BuildDataList();
            Program.incidentDataService.CommsPlanChanged += Program_OnCommsPlanChanged;
            Program.incidentDataService.CommsPlanItemChanged += Program_OnCommsPlanItemChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OpPeriodChanged;

            prepAndApprovePanel1.ApprovedByChanged += PrepAndApprovePanel1_ApprovedByChanged;
            prepAndApprovePanel1.PreparedByChanged += PrepAndApprovePanel1_PreparedByChanged; ;
        }

        private void PrepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod);
            if (plan != null)
            {
                plan.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
                plan.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;
            }
        }

        private void PrepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod);
            if (plan != null)
            {
                plan.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
                plan.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;
            }
        }

        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            BuildDataList();
        }


        private void Program_OnCommsPlanChanged(CommsPlanEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod) { BuildDataList(); }
        }
        private void Program_OnCommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod) { BuildDataList(); }
        }
        private void BuildDataList()
        {
           
            
            if(!Program.CurrentIncident.allCommsPlans.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
            }
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            items = new SortableBindingList<CommsPlanItem>(plan.ActiveCommsItems);
            dgvCommsItems.DataSource = items;
            btnAdd.Enabled = plan.ActiveCommsItems.Count < RowsPerSheet;

            prepAndApprovePanel1.SetPreparedBy(plan.PreparedByRoleID, plan.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(plan.ApprovedByRoleID, plan.DateApproved);

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CommunicationsPlanEntryForm entryForm = new CommunicationsPlanEntryForm())
            {
               DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    entryForm.SelectedItem.OpPeriod = Program.CurrentOpPeriod;
                    
                    Program.incidentDataService.UpsertCommsPlanItem(entryForm.SelectedItem, null, "local");


                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpsertOptionValue(entryForm.SelectedItem, "CommsItem");
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvCommsItems.SelectedRows.Count == 1)
            {
                CommsPlanItem item = (CommsPlanItem)dgvCommsItems.SelectedRows[0].DataBoundItem;
                OpenForView(item);
            }
        }

        private void OpenForView(CommsPlanItem item)
        {
            using (CommunicationsPlanViewForm viewForm = new CommunicationsPlanViewForm())
            {
                viewForm.SelectedItem = item;
                viewForm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvCommsItems.SelectedRows.Count == 1)
            {
                CommsPlanItem item = (CommsPlanItem)dgvCommsItems.SelectedRows[0].DataBoundItem;
                OpenForEdit(item);
            }
        }

        private void OpenForEdit(CommsPlanItem item)
        {
            using (CommunicationsPlanEditForm editForm = new CommunicationsPlanEditForm())
            {
                editForm.SelectedItem = item;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertCommsPlanItem(editForm.SelectedItem.Clone(), null, "local");

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCommsItems.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<CommsPlanItem> toDelete = new List<CommsPlanItem>();

                foreach (DataGridViewRow row in dgvCommsItems.SelectedRows)
                {
                    toDelete.Add((CommsPlanItem)row.DataBoundItem);
                }

                foreach (CommsPlanItem c in toDelete) { c.Active = false; Program.incidentDataService.UpsertCommsPlanItem(c); }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "CommsPlan-" + Program.CurrentIncident.IncidentIdentifier + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";


                CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);



                string csv = CommsPlanTools.PlanToCSV(plan.ActiveCommsItems, delimiter);
                try
                {
                    System.IO.File.WriteAllText(exportPath, csv);

                    DialogResult openNow = MessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                    if (openNow == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, there was a problem writing to the file.  Please report this error: " + ex.ToString());
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            if (string.IsNullOrEmpty(plan.PreparedByResourceName) || string.IsNullOrEmpty(plan.PreparedByRoleName))
            {



                if (Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
                {
                    OrganizationChart currentChart = Program.CurrentIncident.allOrgCharts.First(o => o.OpPeriod == Program.CurrentOpPeriod);
                    ICSRole prepBy = currentChart.GetRoleByID(Globals.LogisticsChiefID, true);
                    if (prepBy != null)
                    {
                        plan.PreparedByResourceName = prepBy.IndividualName; plan.PreparedByRoleName = prepBy.RoleName;
                        Program.incidentDataService.UpsertCommsPlan(plan);
                    }
                }

            }
            if (string.IsNullOrEmpty(plan.PreparedByResourceName) || string.IsNullOrEmpty(plan.PreparedByRoleName))
            {
                plan.PreparedByResourceName = Program.CurrentRole.IndividualName;
                plan.PreparedByRoleName = Program.CurrentRole.RoleName;
            }

            string path = Program.pdfExportService.createCommsPlanPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false, false, false);
            if (!string.IsNullOrEmpty(path))
            {
                try { System.Diagnostics.Process.Start(path); }
                catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }
            }
            else
            {
                MessageBox.Show("Sorry, there was an error generating the contact list.");
            }

        }

        private void dgvCommsItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex != dgvCommsItems.Columns["colDown"].Index && e.ColumnIndex != dgvCommsItems.Columns["colUp"].Index)
            {
                CommsPlanItem item = (CommsPlanItem) dgvCommsItems.Rows[e.RowIndex].DataBoundItem;
                OpenForView(item);
            }
        }

        private void dgvCommsItems_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvCommsItems.SelectedRows.Count == 1;
            btnView.Enabled = btnEdit.Enabled;
            btnDelete.Enabled = dgvCommsItems.SelectedRows.Count > 0;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControlExt.tabControlCustomColor_DrawItem(sender, e);

        }

        private void dgvCommsItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        private void dgvCommsItems_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvCommsItems.Columns[e.ColumnIndex];
            int currentSortColumn = dgvCommsItems.SortedColumn?.Index ?? -1;


            ListSortDirection direction;

            // Determine the sort direction
            if (dgvCommsItems.SortOrder == SortOrder.Ascending)
            {
                if (column.Index == currentSortColumn)
                {
                    direction = ListSortDirection.Ascending;
                }
                else
                {
                    direction = ListSortDirection.Descending;
                }
            }
            else
            {
                if (column.Index == currentSortColumn)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
            }

            // Sort the selected column
            dgvCommsItems.Sort(column, direction);
           
        }
    }
}
