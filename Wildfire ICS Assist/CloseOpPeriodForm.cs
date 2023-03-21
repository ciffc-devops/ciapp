﻿using NetworkCommsDotNet.Tools;
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
    public partial class CloseOpPeriodForm : Form
    {
        public CloseOpPeriodForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private OperationalPeriod NextOpPeriod { get => Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == NextOp); }

        private int NextOp { get => Program.CurrentOpPeriod + 1; }

        private void CloseOpPeriodForm_Load(object sender, EventArgs e)
        {
            dgvObjectives.AutoGenerateColumns = false;
            OperationalPeriod per = Program.CurrentIncident.createOpPeriodAsNeeded(NextOp);
            Program.wfIncidentService.UpsertOperationalPeriod(per);
            datOpsStart.Value = NextOpPeriod.PeriodStart;
            datOpsEnd.Value = NextOpPeriod.PeriodEnd;

            UpdateObjectiveSummary();

            lblCurrentOrgTitle.Text = "Op " + Program.CurrentOpPeriod + " Org Chart";
            lblNextOrgTitle.Text = "Op " + NextOp + " Org Chart";
            PopulateOrgChart(Program.CurrentOpPeriod, treeOrgChart);
            PopulateOrgChart(NextOp, treeOrgChart2);

            dgvSafety.AutoGenerateColumns = false;
            BuildSafetyPlanList();


            //other
            lblAirOpsCopyStatus.Text = "";
            lblCommsPlanCopyStatus.Text = "";
            lblMedPlanCopyStatus.Text = "";
        }

        private void datOpsStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datOpsStart_Leave(object sender, EventArgs e)
        {
            NextOpPeriod.PeriodStart = datOpsStart.Value; Program.wfIncidentService.UpsertOperationalPeriod(NextOpPeriod);
        }

        private void datOpsEnd_Leave(object sender, EventArgs e)
        {
            NextOpPeriod.PeriodEnd = datOpsEnd.Value; Program.wfIncidentService.UpsertOperationalPeriod(NextOpPeriod);
        }


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
                    ICSRole r = role.Clone(); r.OpPeriod = NextOp; r.OrganizationalChartID = newCopy.OrganizationalChartID; r.teamMember = new Personnel(); newCopy.AllRoles.Add(r);
                }
            }

            currentNextOp.OpPeriod = -99; currentNextOp.Active = false;
            Program.wfIncidentService.UpsertOrganizationalChart(currentNextOp);
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
                            nr.teamMember = role.teamMember.Clone();
                        }
                    }
                }
            }
            if(newCopy.AllRoles.Any(o=>o.IndividualID == Guid.Empty && !string.IsNullOrEmpty(o.IndividualName)))
            {
                ICSRole first = newCopy.AllRoles.First(o => o.IndividualID == Guid.Empty && !string.IsNullOrEmpty(o.IndividualName));
            }

            Program.wfIncidentService.UpsertOrganizationalChart(newCopy);
            PopulateOrgChart(Program.CurrentOpPeriod + 1, treeOrgChart2);

        }


        #endregion


        #region Objectives
        private void UpdateObjectiveSummary()
        {
            Program.CurrentIncident.createObjectivesSheetAsNeeded(Program.CurrentOpPeriod);

            dgvObjectives.DataSource = Program.CurrentIncident.allIncidentObjectives.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.OrderBy(o=>o.Priority).ThenBy(o=>o.Objective).ToList();


        }

        private void dgvObjectives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObjectives.Columns["colTransferObjective"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvObjectives.Columns["colTransferObjective"].Index)
            {
                IncidentObjective savedObjective = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;

                if (!Program.CurrentIncident.allIncidentObjectives.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any(o => o.Objective.Equals(savedObjective.Objective) && o.OpPeriod == NextOp))
                {
                    IncidentObjective newObjective = new IncidentObjective();
                    newObjective.OpPeriod =Program. CurrentOpPeriod + 1;
                    newObjective.Objective = savedObjective.Objective;
                    newObjective.Priority = Program.CurrentIncident.getNextObjectivePriority(Program.CurrentOpPeriod + 1);


                    savedObjective.CopyNextOpText = "Copied";
                    Program.wfIncidentService.UpsertIncidentObjective(newObjective);

                }
            }
        }

        private void dgvObjectives_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObjectives.Columns["colObjectiveCompleted"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvObjectives.Columns["colObjectiveCompleted"].Index)
            {
                IncidentObjective objective = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;
                if (Program.CurrentIncident.allIncidentObjectives.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any(o => o.ObjectiveID == objective.ObjectiveID))
                {
                    IncidentObjective savedObjective = Program.CurrentIncident.allIncidentObjectives.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.First(o => o.ObjectiveID == objective.ObjectiveID);
                    savedObjective.Completed = objective.Completed;
                    Program.wfIncidentService.UpsertIncidentObjective(savedObjective);
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
                    Program.wfIncidentService.UpsertSafetyMessage(newitem);

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

            foreach(CommsPlanItem item in Program.CurrentIncident.allCommsPlans.First(o=>o.OpsPeriod == Program.CurrentOpPeriod).ActiveCommsItems)
            {
                if (!Program.CurrentIncident.allCommsPlans.First(o => o.OpsPeriod == NextOp).ActiveCommsItems.Any(o => o.Equals(item)))
                {

                    CommsPlanItem newItem = item.Clone();
                    newItem.OpsPeriod = NextOp;
                    newItem.ItemID = Guid.NewGuid();
                    Program.wfIncidentService.UpsertCommsPlanItem(newItem);
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
            Program.wfIncidentService.UpsertMedicalPlan(next);

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

            foreach(Aircraft a in current.aircrafts)
            {
                if(!next.aircrafts.Any(o=>o.ID == a.ID))
                {
                    Aircraft nextA = a.Clone();
                    nextA.OpPeriod = NextOp;
                    Program.wfIncidentService.UpsertAircraft(nextA);
                    aircraftAdded++;
                }
            }

            next.notam = current.notam.Clone();

            Program.wfIncidentService.UpsertAirOperationsSummary(next);
            lblAirOpsCopyStatus.Text = "Added " + aircraftAdded + " aircraft + NOTAM and general items";
        }

        #endregion

 
    }
}