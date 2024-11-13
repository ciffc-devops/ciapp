using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.CustomControls;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class CloseOpPeriodForm : BaseForm
    {
        public CloseOpPeriodForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private OperationalPeriod NextOpPeriod { get => Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == NextOp); }

        private int NextOp { get => Convert.ToInt32(numOpPeriod.Value); }

        private void CloseOpPeriodForm_Load(object sender, EventArgs e)
        {
            dgvSafety.AutoGenerateColumns = false;
            dgvResources.AutoGenerateColumns = false;
            dgvSummaryStats.AutoGenerateColumns = false;
            LoadOpPeriod();
        }

        private void LoadOpPeriod()
        {
            datOpsStart.MinDate = Program.CurrentOpPeriodDetails.PeriodEnd;
            numOpPeriod.Minimum = Program.CurrentOpPeriod + 1;
            dgvObjectives.AutoGenerateColumns = false;
            numOpPeriod.Value = Program.CurrentOpPeriod + 1;

            LoadObjectives();
            LoadResources();
            LoadOrgChart();
            LoadOther();
            BuildSafetyPlanList();
            BuildSummaryStats();

            Program.incidentDataService.MemberSignInChanged += Program_CheckInChanged;
            Program.incidentDataService.VehicleChanged += Program_VehicleChanged;
            Program.incidentDataService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OperationalPeriodChanged;

            Program.incidentDataService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.incidentDataService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.incidentDataService.IncidentObjectiveChanged += Program_IncidentObjectiveChanged;
            Program.incidentDataService.IncidentObjectivesSheetChanged += Program_IncidentObjectivesSheetChanged;
            Program.incidentDataService.SafetyMessageChanged += Program_SafetyMessageChanged;

        }

        private void LoadObjectives()
        {
            UpdateObjectiveSummary();

        }
        private void LoadResources()
        {
            LoadResourcesList();

        }
        private void LoadOrgChart()
        {
            lblCurrentOrgTitle.Text = "Op " + Program.CurrentOpPeriod + " Org Chart";
            lblNextOrgTitle.Text = "Op " + NextOp + " Org Chart";
            PopulateOrgChart(Program.CurrentOpPeriod, treeOrgChart);
            PopulateOrgChart(NextOp, treeOrgChart2);

        }
        private void LoadOther()
        {            
            //other
            lblAirOpsCopyStatus.Text = "";
            lblCommsPlanCopyStatus.Text = "";
            lblMedPlanCopyStatus.Text = "";


        }


        #region Incident Event Handling
        private void Program_OperationalPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            LoadOpPeriod();
        }

        private void Program_CheckInChanged(CheckInEventArgs e)
        {
            LoadResources(); BuildSummaryStats();
        }
        private void Program_VehicleChanged(VehicleEventArgs e)
        {
            LoadResources(); BuildSummaryStats();
        }

        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            LoadResources(); BuildSummaryStats();
        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            LoadOrgChart();

        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            LoadOrgChart();

        }
        private void Program_IncidentObjectiveChanged(IncidentObjectiveEventArgs e)
        {
            LoadObjectives();
        }
        private void Program_IncidentObjectivesSheetChanged(IncidentObjectivesSheetEventArgs e)
        {
            LoadObjectives();
        }
        private void Program_SafetyMessageChanged(SafetyMessageEventArgs e)
        {
            BuildSafetyPlanList();
        }
        #endregion


        private void datOpsStart_ValueChanged(object sender, EventArgs e)
        {

        }



        private void datOpsStart_Leave(object sender, EventArgs e)
        {
            NextOpPeriod.PeriodStart = datOpsStart.Value; Program.incidentDataService.UpsertOperationalPeriod(NextOpPeriod);
        }

        private void datOpsEnd_Leave(object sender, EventArgs e)
        {
            NextOpPeriod.PeriodEnd = datOpsEnd.Value; Program.incidentDataService.UpsertOperationalPeriod(NextOpPeriod);
        }

        #region Resources

        private void LoadResourcesList()
        {
           
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            bool showCrewDetails = false;
            DateTime mid = Program.CurrentOpPeriodDetails.PeriodMid;
            if (showCrewDetails)
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }
            else
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod && o.ParentRecordID == Guid.Empty))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null && resource.ParentResourceID == Guid.Empty)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }

            int RedNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("RedResourceTimeoutDays"));
            lblResourceListDetail.Text = "The list above includes all resources with a Last Day On Incident date within the next " + RedNumber + " days.";
            checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();

            DateTime EndOfOp = Program.CurrentOpPeriodDetails.PeriodEnd;
            checkInRecords = checkInRecords.Where(o => o.CheckOutDate == DateTime.MaxValue).ToList();
            checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= RedNumber).ToList();
            dgvResources.DataSource = checkInRecords;
        }

        private void btnPrintDemob_Click(object sender, EventArgs e)
        {
            List<IncidentResource> selectedResources = new List<IncidentResource>();
            foreach (DataGridViewRow row in dgvResources.SelectedRows)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)row.DataBoundItem;
                selectedResources.Add(rec.Resource);
            }

            if (selectedResources.Any())
            {
                List<byte[]> allPDFs = Program.pdfExportService.exportDemobChecklistToPDF(Program.CurrentIncident, selectedResources, false);

                string fullFilepath = "";
                fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

                string fullOutputFilename = "ICS-221 " + Program.CurrentIncident.IncidentNameAndNumberForPath + " " + DateTime.Now.ToString(Globals.DateFormat);
                fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(fullFilepath, fullFile);
                    System.Diagnostics.Process.Start(fullFilepath);
                }
                catch (Exception ex) { MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
            }

        }

        private void dgvResources_SelectionChanged(object sender, EventArgs e)
        {
            btnPrintDemob.Enabled = dgvResources.SelectedRows.Count > 0;
            btnDemob.Enabled = dgvResources.SelectedRows.Count == 1;
        }

        #endregion

        #region OrgChart

        private void PopulateOrgChart(int OpPeriod, TreeView tree)
        {
            if (!Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == OpPeriod))
            {
                Program.CurrentIncident.createOrgChartAsNeeded(OpPeriod);
            }
            PopulateTree(tree, Program.CurrentIncident.allOrgCharts.First(o => o.OpPeriod == OpPeriod));

        }

        private void PopulateTree(TreeView tree, OrganizationChart chart, ICSRole selectedRole = null)
        {



            tree.Nodes.Clear();
            // call recursive function
            AddCurrentChild(chart, Guid.Empty, tree.Nodes);

            if (tree.Nodes.Count > 0)
            {
                tree.Nodes[0].ExpandAll();
                if (selectedRole == null)
                {
                    tree.SelectedNode = tree.Nodes[0];
                }
                else
                {
                    TreeNode selectedNode = GetSelectedByRoleID(tree, selectedRole.RoleID);
                    if (selectedNode != null)
                    {
                        tree.SelectedNode = selectedNode;
                    }
                    else { tree.SelectedNode = tree.Nodes[0]; }
                }
                if (tree.SelectedNode != null) tree.SelectedNode.EnsureVisible();

            }
            tree.Focus();
        }


        private TreeNode GetSelectedByRoleID(TreeView tree, Guid roleid)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in tree.Nodes)
            {
                itemNode = FromID(roleid, node);
                if (itemNode != null) break;
            }

            return itemNode;
        }


        private TreeNode FromID(Guid itemId, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (((ICSRole)node.Tag).RoleID == itemId) return node;
                TreeNode next = FromID(itemId, node);
                if (next != null) return next;
            }
            return null;
        }

        private void AddCurrentChild(OrganizationChart chart, Guid parentId, TreeNodeCollection nodes)
        {
            var rows = chart.ActiveRoles.Where(o => o.ReportsTo == parentId).ToList();

            foreach (var row in rows)
            {
                var roleID = row.RoleID;
                string name = row.RoleNameWithIndividual;

                var node = nodes.Add(roleID.ToString(), name);
                if (row.IndividualID == Guid.Empty || string.IsNullOrEmpty(row.IndividualName)) { node.NodeFont = GetNodeFont(true); }
                else { node.NodeFont = GetNodeFont(false); }
                node.Tag = row; // if you need to keep a row reference on the node
                AddCurrentChild(chart, row.RoleID, node.Nodes);
            }
        }


        private Font GetNodeFont(bool italic)
        {
            if (italic)
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16, FontStyle.Italic, GraphicsUnit.Pixel);
                return MyFont;
            }
            else
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
                return MyFont;
            }
        }


        private void btnCopyOrgChart_Click(object sender, EventArgs e)
        {
            int rolesAdded = 0;
            int rolesAssigned = 0;

            OrganizationChart currentOrg = Program.CurrentIncident.allOrgCharts.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            OrganizationChart currentNextOp = Program.CurrentIncident.allOrgCharts.First(o => o.OpPeriod == NextOp);

            OrganizationChart newCopy = Program.CurrentIncident.createOrgChartFromPrevious(Program.CurrentOpPeriod, NextOp);
            
            foreach(ICSRole role in currentOrg.ActiveRoles)
            {
                if (!newCopy.AllRoles.Any(o => o.RoleID == role.RoleID))
                {
                    ICSRole r = role.Clone(); r.OpPeriod = NextOp; r.OrganizationalChartID = newCopy.ID; r.IndividualID = Guid.Empty; r.IndividualName = string.Empty ; newCopy.AllRoles.Add(r);
                }
            }

            currentNextOp.OpPeriod = -99; currentNextOp.Active = false;
            Program.incidentDataService.UpsertOrganizationalChart(currentNextOp);
            newCopy.CreateOpGroupsForOrgRoles(Program.CurrentIncident);

            if (chkCopyOrgAssignments.Checked)
            {
                DateTime startOfOp = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == NextOp).PeriodStart.AddMinutes(5);

                foreach(ICSRole role in currentOrg.ActiveRoles)
                {
                    if (role.IndividualID != Guid.Empty && Program.CurrentIncident.ResourceIsCheckedIn(role.IndividualID, startOfOp) && Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == role.IndividualID))
                    {
                       if(newCopy.AllRoles.Any(o=>o.RoleID == role.RoleID))
                        {
                            ICSRole nr = newCopy.AllRoles.First(o => o.RoleID == role.RoleID);
                            nr.IndividualName = role.IndividualName;
                            nr.IndividualID = role.IndividualID;
                            
                        }
                    }
                }
            }
            if(newCopy.AllRoles.Any(o=>o.IndividualID == Guid.Empty && !string.IsNullOrEmpty(o.IndividualName)))
            {
                ICSRole first = newCopy.AllRoles.First(o => o.IndividualID == Guid.Empty && !string.IsNullOrEmpty(o.IndividualName));
            }

            Program.incidentDataService.UpsertOrganizationalChart(newCopy);
            PopulateOrgChart(NextOp, treeOrgChart2);

        }


        #endregion


        #region Objectives
        private void UpdateObjectiveSummary()
        {
            Program.CurrentIncident.createObjectivesSheetAsNeeded(Program.CurrentOpPeriod);

            dgvObjectives.DataSource = Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.OrderBy(o=>o.Priority).ThenBy(o=>o.Objective).ToList();


        }

        private void dgvObjectives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObjectives.Columns["colTransferObjective"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvObjectives.Columns["colTransferObjective"].Index)
            {
                IncidentObjective savedObjective = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;

                if (!Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any(o => o.Objective.Equals(savedObjective.Objective) && o.OpPeriod == NextOp))
                {
                    IncidentObjective newObjective = new IncidentObjective();
                    newObjective.OpPeriod = NextOp;
                    newObjective.Objective = savedObjective.Objective;
                    newObjective.Priority = Program.CurrentIncident.getNextObjectivePriority(NextOp);


                    savedObjective.CopyNextOpText = "Copied";
                    Program.incidentDataService.UpsertIncidentObjective(newObjective);

                }
            }
        }

        private void dgvObjectives_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObjectives.Columns["colObjectiveCompleted"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvObjectives.Columns["colObjectiveCompleted"].Index)
            {
                IncidentObjective objective = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;
                if (Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any(o => o.ObjectiveID == objective.ObjectiveID))
                {
                    IncidentObjective savedObjective = Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.First(o => o.ObjectiveID == objective.ObjectiveID);
                    savedObjective.Completed = objective.Completed;
                    Program.incidentDataService.UpsertIncidentObjective(savedObjective);
                }
            }
        }


        #endregion


        #region Safety Plan

        private void BuildSafetyPlanList()
        {
            dgvSafety.DataSource = Program.CurrentIncident.allSafetyMessages.Where(o => o.Active && o.OpPeriod == Program.CurrentOpPeriod).ToList();
        }

        private void dgvSafety_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvSafety.Columns["colSafetyCopyToNext"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvSafety.Columns["colSafetyCopyToNext"].Index)
            {
                SafetyMessage saved = (SafetyMessage)dgvSafety.Rows[e.RowIndex].DataBoundItem;

                if (!Program.CurrentIncident.allSafetyMessages.Any(o => o.OpPeriod == NextOp && o.Message.Equals(saved.Message) && o.SummaryLine.Equals(saved.SummaryLine)))
                {
                    SafetyMessage newitem = saved.Clone();
                    newitem.OpPeriod = NextOp;
                    newitem.ID = Guid.NewGuid();


                    saved.CopyNextOpText = "Copied";
                    Program.incidentDataService.UpsertSafetyMessage(newitem);

                }
                else
                {
                    saved.CopyNextOpText = "Duplicate";
                }
            }
        }




        #endregion


        #region Other Items
        private void btnCopyCommsPlan_Click(object sender, EventArgs e)
        {
            int itemsAdded = 0;

            Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
            Program.CurrentIncident.createCommsPlanAsNeeded(NextOp);

            foreach(CommsPlanItem item in Program.CurrentIncident.allCommsPlans.First(o=>o.OpPeriod == Program.CurrentOpPeriod).ActiveCommsItems)
            {
                if (!Program.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == NextOp).ActiveCommsItems.Any(o => o.Equals(item)))
                {

                    CommsPlanItem newItem = item.Clone();
                    newItem.OpPeriod = NextOp;
                    newItem.ItemID = Guid.NewGuid();
                    Program.incidentDataService.UpsertCommsPlanItem(newItem);
                    itemsAdded++;
                }
            }
            if(itemsAdded > 0) { lblCommsPlanCopyStatus.Text = "Added " + itemsAdded + " to next op period"; }
            else { lblCommsPlanCopyStatus.Text = "No new items added"; }
        }

        private void btnCopyMedPlan_Click(object sender, EventArgs e)
        {
            int hospitalsAdded = 0;
            int emsAdded = 0;
            int faAdded = 0;

            Program.CurrentIncident.createMedicalPlanAsNeeded(Program.CurrentOpPeriod);
            Program.CurrentIncident.createMedicalPlanAsNeeded(NextOp);

            MedicalPlan current = Program.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            MedicalPlan next = Program.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == NextOp);

            next.EmergencyProcedures = current.EmergencyProcedures;
            Program.incidentDataService.UpsertMedicalPlan(next);

            foreach (Hospital h in current.Hospitals)
            {
                if (!next.Hospitals.Any(o => o.HospitalID == h.HospitalID)) { next.Hospitals.Add(h); hospitalsAdded++; }
            }
            foreach (AmbulanceService h in current.Ambulances)
            {
                if (!next.Ambulances.Any(o => o.AmbulanceID == h.AmbulanceID)) { next.Ambulances.Add(h); emsAdded++; }
            }
            foreach (MedicalAidStation h in current.MedicalAidStations)
            {
                if (!next.MedicalAidStations.Any(o => o.AidStationID == h.AidStationID)) { next.MedicalAidStations.Add(h); faAdded++; }
            }

            if (hospitalsAdded + emsAdded + faAdded > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Added "); sb.Append(hospitalsAdded); sb.Append(" Hospitals, ");
                sb.Append(emsAdded); sb.Append(" Transports, ");
                sb.Append(faAdded); sb.Append(" Aid Stations ");
                lblMedPlanCopyStatus.Text = sb.ToString();
            } else { lblMedPlanCopyStatus.Text = "Nothing copied"; }
        }

        private void btnCopyAirOps_Click(object sender, EventArgs e)
        {
            int aircraftAdded = 0;
            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod);
            Program.CurrentIncident.createAirOpsSummaryAsNeeded(NextOp);

            AirOperationsSummary current = Program.CurrentIncident.allAirOperationsSummaries.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            AirOperationsSummary next = Program.CurrentIncident.allAirOperationsSummaries.First(o => o.OpPeriod == NextOp);

            next.Remarks = current.Remarks;
            next.Sunrise = current.Sunrise;
            next.Sunset = current.Sunset;
            next.MedivacAircraftText = current.MedivacAircraftText;

           

            next.notam = current.notam.Clone();

            Program.incidentDataService.UpsertAirOperationsSummary(next);
            lblAirOpsCopyStatus.Text = "Added " + aircraftAdded + " aircraft + NOTAM and general items";
        }


        #endregion

        #region Summary Stats

        private void BuildSummaryStats()
        {
            List<SummaryStat> allSummaryStats = new List<SummaryStat>();
            allSummaryStats.AddRange(Program.CurrentIncident.GetSummaryPersonHours(Program.CurrentOpPeriod));
            allSummaryStats.AddRange(Program.CurrentIncident.GetSummaryResourceCounts(Program.CurrentOpPeriod));
            allSummaryStats.AddRange((Program.CurrentIncident.GetSummaryPersonnelPerSection(Program.CurrentOpPeriod)));

            dgvSummaryStats.DataSource = null;
            dgvSummaryStats.DataSource = allSummaryStats;
        }

        #endregion

        private void numOpPeriod_ValueChanged(object sender, EventArgs e)
        {
            int newOpNumber = Convert.ToInt32(numOpPeriod.Value);
            if (newOpNumber != Program.CurrentOpPeriod)
            {
                IncidentOpPeriodChangedEventArgs args = new IncidentOpPeriodChangedEventArgs();
                args.NewOpPeriod = newOpNumber;


                if (!Program.CurrentIncident.AllOperationalPeriods.Any(o => o.PeriodNumber == newOpNumber))
                {
                    OperationalPeriod per = Program.CurrentIncident.createOpPeriodAsNeeded(newOpNumber);

                    Program.incidentDataService.UpsertOperationalPeriod(per);

                    Program.CurrentIncident.createOrgChartAsNeeded(newOpNumber);
                    Program.CurrentIncident.createObjectivesSheetAsNeeded(newOpNumber);

                }

                OperationalPeriod selectedPeriod = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == newOpNumber);
                datOpsStart.Value = selectedPeriod.PeriodStart;
                datOpsEnd.Value = selectedPeriod.PeriodEnd;
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSummaryStats_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgvSummaryStats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colindex = dgvSummaryStats.Columns["colSummaryMoreInfo"].Index;
            if(e.RowIndex >= 0 && e.ColumnIndex == colindex)
            {
                SummaryStat stat = (SummaryStat)dgvSummaryStats.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrEmpty(stat.MoreInfo)) { MessageBox.Show(stat.MoreInfo); }
            }
        }

        private void btnDemob_Click(object sender, EventArgs e)
        {
            if(dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource res = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenDemobForEdit(res);
            }
        }

        private void OpenDemobForEdit(CheckInRecordWithResource res)
        {
            DemobilizationRecord demob = new DemobilizationRecord();
            if (Program.CurrentIncident.ActiveDemobilizationRecords.Any(o => o.SignInRecordID == res.Record.SignInRecordID))
            {
                demob = Program.CurrentIncident.ActiveDemobilizationRecords.First(o => o.SignInRecordID == res.Record.SignInRecordID);
            }
            else
            {
                demob.SignInRecordID = res.Record.SignInRecordID;
                demob.ResourceID = res.Resource.ID;
                demob.DebriefDate = DateTime.Now;
                demob.DemobDate = DateTime.Now;
                demob.OpPeriod = Program.CurrentOpPeriod;

            }

            using (DemobilizeResourceForm demobForm = new DemobilizeResourceForm())
            {
                demobForm.SetRecord(res.Resource, res.Record, demob);
                DialogResult dr = demobForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertDemobRecord(demob);
                }
            }

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }
    }
}
