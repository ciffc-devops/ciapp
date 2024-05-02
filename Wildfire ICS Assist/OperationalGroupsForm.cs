using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupsForm : BaseForm
    {
        OrganizationChart CurrentOrgChart { get => Program.CurrentOrgChart; }
        public OperationalGroupsForm()
        {
            InitializeComponent(); 
        }

        private void OperationalGroupsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            PopulateTree();
            Program.wfIncidentService.OperationalGroupChanged += Program_OperationalGroupChanged;
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChangedChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChangedChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OperationalPeriodChanged;

        }


        private void Program_OperationalPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            PopulateTree();
        }



        private void Program_OperationalGroupChanged(OperationalGroupEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                ICSRole selected = null;
                if (treeOpsChart.SelectedNode != null)
                {


                    selected = (ICSRole)treeOpsChart.SelectedNode.Tag;
                }
                PopulateTree();
                if(selected != null) { SetSelectedNode(selected); }
            }
        }
        private void Program_ICSRoleChangedChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                PopulateTree();
                SetSelectedNode(e.item);
            }
        }
        private void Program_OrgChartChangedChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                ICSRole selected = null;
                if (treeOpsChart.SelectedNode != null)
                {


                    selected = (ICSRole)treeOpsChart.SelectedNode.Tag;
                }
                PopulateTree();

                if (selected != null) { SetSelectedNode(selected); }
            }
        }


        private void SetSelectedNode(ICSRole selectedRole)
        {
            if (selectedRole == null)
            {
                treeOpsChart.SelectedNode = treeOpsChart.Nodes[0];
            }
            else
            {
                TreeNode selectedNode = GetSelectedByRoleID(selectedRole.RoleID);
                if (selectedNode != null)
                {
                    treeOpsChart.SelectedNode = selectedNode;
                }
                else { treeOpsChart.SelectedNode = treeOpsChart.Nodes[0]; }
            }
            if (treeOpsChart.SelectedNode != null) treeOpsChart.SelectedNode.EnsureVisible();
        }


        private void PopulateTree(ICSRole selectedRole = null)
        {
           

            treeOpsChart.Nodes.Clear();
            // call recursive function
            AddCurrentChild(Globals.IncidentCommanderID, treeOpsChart.Nodes);

            if (treeOpsChart.Nodes.Count > 0)
            {
                treeOpsChart.Nodes[0].ExpandAll();
                if (selectedRole == null)
                {
                    treeOpsChart.SelectedNode = treeOpsChart.Nodes[0];
                }
                else
                {
                    TreeNode selectedNode = GetSelectedByRoleID(selectedRole.RoleID);
                    if (selectedNode != null)
                    {
                        treeOpsChart.SelectedNode = selectedNode;
                       
                    }
                    else { treeOpsChart.SelectedNode = treeOpsChart.Nodes[0]; }
                }
                if (treeOpsChart.SelectedNode != null) treeOpsChart.SelectedNode.EnsureVisible();

            }
            treeOpsChart.Focus();

            btnPrint204A.Enabled = Program.CurrentIncident.ActiveOperationalGroups.Any(o => !o.IsBranchOrDiv && o.OpPeriod == Program.CurrentOpPeriod);
        }

        private TreeNode GetSelectedByRoleID(Guid roleid)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeOpsChart.Nodes)
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
            var rows = CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == parentId && o.SectionID == Globals.OpsChiefID && o.IsOpGroupSup).OrderBy(o=>o.RoleName).ToList();

            foreach (var row in rows)
            {
                

                var roleID = row.RoleID;
                string name = row.RoleNameWithIndividualAssigned;

                if (!row.IsPlaceholder)
                {

                    var node = nodes.Add(roleID.ToString(), name);
                    if (row.IndividualID == Guid.Empty || string.IsNullOrEmpty(row.IndividualName)) { node.NodeFont = GetNodeFont(true); }
                    else { node.NodeFont = GetNodeFont(false); }
                    node.Tag = row; // if you need to keep a row reference on the node
                    ShouldAutoExpand(node);
                    AddCurrentChild(row.RoleID, node.Nodes);
                }
            }
        }

        private void ShouldAutoExpand(TreeNode tn)
        {
            if (tn.Level < 2)
                tn.Expand();
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

        private void SaveSTTFChanges()
        {
            //save any changes to the strike team before moving on
            if (strikeTeamTaskForceDetailsControl1.Visible && strikeTeamTaskForceDetailsControl1.ChangesMade)
            {
                strikeTeamTaskForceDetailsControl1.ChangesMade = false;

                Program.wfIncidentService.UpsertOperationalGroup(strikeTeamTaskForceDetailsControl1.selectedGroup);
            }
        }

        private void treeOpsChart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeOpsChart.SelectedNode != null)
            {
                btnEditBranch.Enabled = true;
               
                Program.CurrentIncident.UpdateOperationalGroupCounts(Program.CurrentOpPeriod);

                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
                btnDelete.Enabled = role.AllowDelete;

                SaveSTTFChanges();

                OperationalGroup selectedGroup = new OperationalGroup();
                if (Program.CurrentIncident != null && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID))
                {
                    selectedGroup = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID);
                }


                if (selectedGroup != null && (selectedGroup.GroupType.EqualsWithNull("Strike Team") || selectedGroup.GroupType.EqualsWithNull("Task Force")))
                {
                    operationalGroupReportingResourcesControl1.Visible = false;
                    strikeTeamTaskForceDetailsControl1.Visible = true;
                    strikeTeamTaskForceDetailsControl1.Dock = DockStyle.Fill;
                    strikeTeamTaskForceDetailsControl1.SetRole(role);
                }
                else
                {
                    operationalGroupReportingResourcesControl1.Visible = true;
                    operationalGroupReportingResourcesControl1.Dock = DockStyle.Fill;
                    operationalGroupReportingResourcesControl1.role = role;
                    strikeTeamTaskForceDetailsControl1.Visible = false;
                }
                
            }
            else
            {
                
                //btnAssignRole.Enabled = false;
            }
        }


        private void OpenBrachDivForEdit(OperationalGroup group)
        {
            if (group != null)
            {
                using (OperationalGroupBranchEditForm form = new OperationalGroupBranchEditForm())
                {
                    form.SelectedGroup = group;

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OperationalGroup grp = form.SelectedGroup;
                        Program.wfIncidentService.UpsertOperationalGroup(grp);
                    }
                }
            }
        }

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsAddButton.Show(ptLowerLeft);


        }



        private void btnEditBranch_Click(object sender, EventArgs e)
        {
            EditSelectedNode();
        }

        private void EditSelectedNode()
        {
            if (treeOpsChart.SelectedNode != null)
            {
                btnEditBranch.Enabled = true;
                btnDelete.Enabled = true;

                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;

                if (role.RoleID == Globals.OpsChiefID)
                {
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
                else
                {
                    OperationalGroup selectedGroup = new OperationalGroup();
                    if (Program.CurrentIncident != null && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID && o.OpPeriod == role.OpPeriod))
                    {
                        selectedGroup = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID && o.OpPeriod == role.OpPeriod);

                        if (selectedGroup.GroupType.EqualsWithNull("Task Force") || selectedGroup.GroupType.EqualsWithNull("Strike Team") || selectedGroup.GroupType.EqualsWithNull("Single Resource"))
                        {
                            OpenTFSTForEdit(selectedGroup);
                        }
                        else
                        {
                            OpenBrachDivForEdit(selectedGroup);
                        }
                    }
                }
            }
        }

        private void addNewBranchDivisionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = Program.CurrentOpPeriod;
            group.ParentID = Globals.OpsChiefID;
            group.GroupType = "Branch";
            OpenBrachDivForEdit(group);
        }

        private void addNewTaskForceStrikeTeamSingleResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addNewDivisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = Program.CurrentOpPeriod;
            if (treeOpsChart.SelectedNode != null)
            {
                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
                if (role.ReportsTo == Globals.OpsChiefID || role.RoleID == Globals.OpsChiefID)
                {
                    group.ParentID = role.RoleID;
                    group.ParentName = role.RoleName;
                }
                else
                {
                    group.ParentID = role.ReportsTo;
                    group.ParentName = role.ReportsToRoleName;
                }
            }
            else
            {
                group.ParentID = Globals.OpsChiefID;
            }
            group.GroupType = "Division";
            OpenBrachDivForEdit(group);
        }

        private void addNewGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = Program.CurrentOpPeriod;
            if (treeOpsChart.SelectedNode != null)
            {
                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
                if (role.ReportsTo == Globals.OpsChiefID || role.RoleID == Globals.OpsChiefID)
                {
                    group.ParentID = role.RoleID;
                    group.ParentName = role.RoleName;
                }
                else
                {
                    group.ParentID = role.ReportsTo;
                    group.ParentName = role.ReportsToRoleName;
                }
            }
            else
            {
                group.ParentID = Globals.OpsChiefID;
            }
            group.GroupType = "Group";
            OpenBrachDivForEdit(group);
        }

        private void addNewTaskForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Task Force");
        }

        private void AddStTf(string type)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = Program.CurrentOpPeriod;
            if (treeOpsChart.SelectedNode != null)
            {
                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
                if (!role.IsTFST)
                {
                    group.ParentID = role.RoleID;
                    group.ParentName = role.RoleName;
                }
                else
                {
                    group.ParentID = role.ReportsTo;
                    group.ParentName = role.ReportsToRoleName;
                }
            }
            else
            {
                group.ParentID = Globals.OpsChiefID;
            }
            group.GroupType = type;

            OpenTFSTForEdit(group);
        }

        private void addNewStrikeTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Strike Team");
        }

        private void addNewSingleResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Single Resource");
        }

        private void OpenTFSTForEdit(OperationalGroup group)
        {
            if (group != null)
            {
                using (OperationalGroupSTTFEditForm form = new OperationalGroupSTTFEditForm())
                {
                    form.SelectedGroup = group;

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OperationalGroup grp = form.SelectedGroup;
                        Program.wfIncidentService.UpsertOperationalGroup(grp);
                        
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        private void DeleteSelectedNode()
        {
            if (treeOpsChart.SelectedNode != null)
            {
                ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;

                if (role.AllowDelete)
                {
                    List<ICSRole> reportingRoles = CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == role.RoleID).ToList();
                    if (reportingRoles.Count > 0)
                    {
                        MessageBox.Show(Properties.Resources.DeleteSubordinateRoles);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            Program.wfIncidentService.DeleteICSRole(role, Program.CurrentOpPeriod);
                        }


                    }
                }

            }
        }

        private void btnPrint204_Click(object sender, EventArgs e)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 204 - " + Program.CurrentIncident.IncidentIdentifier + " Op " + Program.CurrentOpPeriod;    // + ".pdf";

            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            allPDFs.AddRange(Program.pdfExportService.exportAllAssignmentSummariesToPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false));

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
            }
        }

        private void btnPrint204A_Click(object sender, EventArgs e)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 204A - " + Program.CurrentIncident.IncidentIdentifier + " Op " + Program.CurrentOpPeriod;    // + ".pdf";

            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            allPDFs.AddRange(Program.pdfExportService.exportAllAssignmentDetailsToPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false));

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
            }
        }

        private void btnExportSignInToCSV_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "AssignmentList-" + Program.CurrentIncident.IncidentIdentifier + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";




                List<ICSRole> roles = new List<ICSRole>();
                foreach(ICSRole role in Program.CurrentOrgChart.ActiveRoles.Where(o=>o.IsOpGroupSup || o.RoleID == Globals.OpsChiefID))
                {
                    if (role.RoleID == Globals.OpsChiefID) { roles.Add(role); }
                   else if (role.IsOpGroupSup) { roles.Add(role); }
                }
                List<OperationalGroup> groups = Program.CurrentIncident.ActiveOperationalGroups.Where(o=>o.OpPeriod == Program.CurrentOpPeriod).ToList();

                string csv = OperationalGroupTools.OperationalGroupsToCSV(roles, groups, delimiter);
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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedNode();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        private void addTaskForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Task Force");

        }

        private void addStrikeTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Strike Team");

        }

        private void addSingleResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStTf("Single Resource");

        }

        private void btnPrintLogistics_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
            List<byte[]> allPDFs = Program.pdfExportService.exportLogisticsSummaryToPDF(Program.CurrentTask, Program.CurrentOpPeriod, role, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Logistics Overview " + Program.CurrentIncident.IncidentIdentifier;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
        }

        private void printLogisticsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
            List<byte[]> allPDFs = Program.pdfExportService.exportLogisticsSummaryToPDF(Program.CurrentTask, Program.CurrentOpPeriod, role, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Logistics Overview " + Program.CurrentIncident.IncidentIdentifier;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
        }

        private void OperationalGroupsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSTTFChanges();
        }
    }
}
