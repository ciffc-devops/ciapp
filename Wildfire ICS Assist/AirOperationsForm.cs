using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class AirOperationsForm : Form
    {
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }
        private AirOperationsSummary CurrentAirOpsSummary { get => Program.CurrentIncident.allAirOperationsSummaries.FirstOrDefault(o=>o.OpPeriod == Program.CurrentOpPeriod); }    


        public AirOperationsForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground; dgvAircraft.BackgroundColor = Program.FormAccent;
        }

        private void AirOperationsForm_Load(object sender, EventArgs e)
        {
            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod);

            PopulateTree();
            PopulateCommsItems();


            SetNOTAMCheckbox();

            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;

            Program.wfIncidentService.CommsPlanChanged += Program_CommsPlanChanged;
            Program.wfIncidentService.CommsPlanItemChanged+= Program_CommsPlanItemChanged;
        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree(); }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree(); }
        }


        private void Program_CommsPlanChanged(CommsPlanEventArgs e)
        {
            if(e.item.OpsPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }
        private void Program_CommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if (e.item.OpsPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }


        private void PopulateCommsItems()
        {
            dgvCommsItems.AutoGenerateColumns = false;
            dgvCommsItems.DataSource = null;
            if (!Program.CurrentIncident.allCommsPlans.Any(o => o.OpsPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
            }
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpsPeriod == Program.CurrentOpPeriod);

            dgvCommsItems.DataSource = plan.ActiveAirCommsItems;

        }


        //Org chart stuff
        private void PopulateTree(ICSRole selectedRole = null)
        {
            if (!Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createOrgChartAsNeeded(Program.CurrentOpPeriod);
            }


            treeOrgChart.Nodes.Clear();
            // call recursive function
            AddFirstChild(treeOrgChart.Nodes);

            if (treeOrgChart.Nodes.Count > 0)
            {
                treeOrgChart.Nodes[0].ExpandAll();
                if (selectedRole == null)
                {
                    treeOrgChart.SelectedNode = treeOrgChart.Nodes[0];
                }
                else
                {
                    TreeNode selectedNode = GetSelectedByRoleID(selectedRole.RoleID);
                    if (selectedNode != null)
                    {
                        treeOrgChart.SelectedNode = selectedNode;
                    }
                    else { treeOrgChart.SelectedNode = treeOrgChart.Nodes[0]; }
                }
                if (treeOrgChart.SelectedNode != null) treeOrgChart.SelectedNode.EnsureVisible();

            }
            treeOrgChart.Focus();
        }

        private TreeNode GetSelectedByRoleID(Guid roleid)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeOrgChart.Nodes)
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

        private void AddCurrentChild(Guid parentId, TreeNodeCollection nodes)
        {
            var rows = CurrentOrgChart.AllRoles.Where(o => o.ReportsTo == parentId).ToList();

            foreach (var row in rows)
            {
                var roleID = row.RoleID;
                string name = row.RoleNameWithIndividual;

                var node = nodes.Add(roleID.ToString(), name);
                if (row.IndividualID == Guid.Empty || string.IsNullOrEmpty(row.IndividualName)) { node.NodeFont = GetNodeFont(true); }
                else { node.NodeFont = GetNodeFont(false); }
                node.Tag = row; // if you need to keep a row reference on the node
                AddCurrentChild(row.RoleID, node.Nodes);
            }
        }
        private void AddFirstChild(TreeNodeCollection nodes)
        {
            var rows = CurrentOrgChart.AllRoles.Where(o => o.RoleID == WF_ICS_ClassLibrary.Globals.AirOpsDirector).ToList();

            foreach (var row in rows)
            {
                var roleID = row.RoleID;
                string name = row.RoleNameWithIndividual;

                var node = nodes.Add(roleID.ToString(), name);
                if (row.IndividualID == Guid.Empty || string.IsNullOrEmpty(row.IndividualName)) { node.NodeFont = GetNodeFont(true); }
                else { node.NodeFont = GetNodeFont(false); }
                node.Tag = row; // if you need to keep a row reference on the node
                AddCurrentChild(row.RoleID, node.Nodes);
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


        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.Remarks = txtRemarks.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ICSRole role = new ICSRole();
            role.OrganizationalChartID = CurrentOrgChart.OrganizationalChartID;
            role.OpPeriod = CurrentOrgChart.OpPeriod;
            openRoleForEdit(role);
        }

        private void btnAssignRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            using (OrganizationChartAssignRoleForm assignRoleForm = new OrganizationChartAssignRoleForm())
            {
                assignRoleForm.selectedRole = role.Clone();

                DialogResult dr = assignRoleForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertICSRole(assignRoleForm.selectedRole);

                    if (CurrentOrgChart.PreparedByRoleID == Guid.Empty)
                    {
                        CurrentOrgChart.PreparedByRole = Program.CurrentRole.RoleName;
                        CurrentOrgChart.PreparedBy = Program.CurrentRole.IndividualName;
                        CurrentOrgChart.PreparedByRoleID = Program.CurrentRole.RoleID;
                        CurrentOrgChart.PreparedByUserID = Program.CurrentRole.IndividualID;
                        Program.wfIncidentService.UpsertOrganizationalChart(CurrentOrgChart, false);
                    }
                }

            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
            openRoleForEdit(role);
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            if (role.AllowDelete)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Program.wfIncidentService.DeleteICSRole(role, Program.CurrentOpPeriod);
                }
            }
            else { MessageBox.Show(Properties.Resources.ProtectedRole); }
        }

        private void openRoleForEdit(ICSRole role)
        {
            if (role.AllowEditName)
            {
                using (OrganizationChartAddRoleForm addRoleForm = new OrganizationChartAddRoleForm())
                {
                    addRoleForm.selectedRole = role;
                    addRoleForm.RestrictToAirOps = true;
                    DialogResult dr = addRoleForm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Program.wfIncidentService.UpsertICSRole(addRoleForm.selectedRole);
                    }
                }
            }
            else { MessageBox.Show(Properties.Resources.ProtectedRole); }
        }

        private void btnAddComms_Click(object sender, EventArgs e)
        {
            using (CommunicationsPlanEntryForm entryForm = new CommunicationsPlanEntryForm())
            {
                entryForm.DefaultAircraft = true;
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    entryForm.SelectedItem.OpsPeriod = Program.CurrentOpPeriod;
                    entryForm.SelectedItem.OrganizationID = CurrentOrgChart.OrganizationalChartID;

                    Program.wfIncidentService.UpsertCommsPlanItem(entryForm.SelectedItem, null, "local");


                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpserOptionValue(entryForm.SelectedItem, "CommsItem");
                    }
                }
            }
        }

        private void btnEditComms_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteComms_Click(object sender, EventArgs e)
        {

        }


        private void SetNOTAMCheckbox()
        {
            if (CurrentAirOpsSummary.notam.AnyContent) { btnNOTAM.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnNOTAM.Image = null;  }

        }
    }
}
