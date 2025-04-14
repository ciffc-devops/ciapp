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
using WildfireICSDesktopServices.Logging;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupsForm : BaseForm
    {
        OrganizationChart CurrentOrgChart { get => Program.CurrentOrgChart; }
        public OperationalGroupsForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);

        }

        private void OperationalGroupsForm_Load(object sender, EventArgs e)
        {
            if(Program.CurrentIncident.ActiveOperationalGroups.Count == 0)
            {
                Globals.incidentService.CurrentIncident.CreateAllOperationalGroupsAsNeeded(Program.CurrentOpPeriod);
            }

            //if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            PopulateTree();
            Program.incidentDataService.OperationalGroupChanged += Program_OperationalGroupChanged;
            Program.incidentDataService.OrganizationalChartChanged += Program_OrgChartChangedChanged;
            Program.incidentDataService.ICSRoleChanged += Program_ICSRoleChangedChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OperationalPeriodChanged;

        }


        private void Program_OperationalPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            PopulateTree();
        }



        private void Program_OperationalGroupChanged(OperationalGroupEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                OperationalGroup selected = null;
                if (treeOpsChart.SelectedNode != null)
                {


                    selected = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
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
                OperationalGroup selected = Program.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o=>o.LeaderICSRoleID == e.item.ID && o.OpPeriod == Program.CurrentOpPeriod);
                if (selected != null)
                {
                    SetSelectedNode(selected);
                }
            }
        }
        private void Program_OrgChartChangedChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                OperationalGroup selected = null;
                if (treeOpsChart.SelectedNode != null)
                {


                    selected = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                }
                PopulateTree();

                if (selected != null) { SetSelectedNode(selected); }
            }
        }


        private void SetSelectedNode(OperationalGroup selectedRole)
        {
            if (selectedRole == null)
            {
                treeOpsChart.SelectedNode = treeOpsChart.Nodes[0];
            }
            else
            {
                if (treeOpsChart.Nodes.Count > 0)
                {
                    TreeNode selectedNode = GetSelectedByRoleID(selectedRole.ID);
                    if (selectedNode != null)
                    {
                        treeOpsChart.SelectedNode = selectedNode;
                    }
                    else { treeOpsChart.SelectedNode = treeOpsChart.Nodes[0]; }
                }
            }
            if (treeOpsChart.SelectedNode != null) treeOpsChart.SelectedNode.EnsureVisible();
        }


        private void PopulateTree(OperationalGroup selectedGroup = null)
        {
           

            treeOpsChart.Nodes.Clear();

            Program.CurrentIncident.UpdateOperationalGroupCounts(Program.CurrentOpPeriod);

            OperationalGroup FirstOpGroup = Program.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o=>o.ParentID == Guid.Empty && o.OpPeriod == Program.CurrentOpPeriod);

            // call recursive function starting with the operations section
            AddCurrentChild(Guid.Empty, treeOpsChart.Nodes);


            //Set the currently selected node
            if (treeOpsChart.Nodes.Count > 0)
            {
                treeOpsChart.Nodes[0].ExpandAll();
                if (selectedGroup == null)
                {
                    treeOpsChart.SelectedNode = treeOpsChart.Nodes[0];
                }
                else
                {
                    TreeNode selectedNode = GetSelectedByRoleID(selectedGroup.ID);
                    if (selectedNode != null)
                    {
                        treeOpsChart.SelectedNode = selectedNode;
                       
                    }
                    else { treeOpsChart.SelectedNode = treeOpsChart.Nodes[0]; }
                }
                if (treeOpsChart.SelectedNode != null) treeOpsChart.SelectedNode.EnsureVisible();

            }
            treeOpsChart.Focus();

        }

        private TreeNode GetSelectedByRoleID(Guid groupId)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeOpsChart.Nodes)
            {
                itemNode = FromID(groupId, node);
                if (itemNode != null) break;
            }

            return itemNode;
        }

        private TreeNode FromID(Guid itemId, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (((OperationalGroup)node.Tag).ID == itemId) return node;
                TreeNode next = FromID(itemId, node);
                if (next != null) return next;
            }
            return null;
        }

        private void AddCurrentChild(Guid parentId, TreeNodeCollection nodes)
        {
            //var rows = CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == parentId && o.SectionID == Globals.OpsChiefGenericID && o.IsOpGroupSup).OrderBy(o=>o.RoleName).ToList();
            var rows = Program.CurrentIncident.ActiveOperationalGroups.Where(o=>o.ParentID == parentId && o.OpPeriod == Program.CurrentOpPeriod).OrderBy(o => o.ResourceName).ToList();

            foreach (var row in rows)
            {
                

                var ID = row.ID;
                string name = row.ResourceName;

               
                    var node = nodes.Add(ID.ToString(), name);
                    if (row.LeaderID == Guid.Empty || string.IsNullOrEmpty(row.LeaderName)) { node.NodeFont = GetNodeFont(true); }
                    else { node.NodeFont = GetNodeFont(false); }
                    node.Tag = row; // if you need to keep a row reference on the node
                    ShouldAutoExpand(node);
                    AddCurrentChild(row.ID, node.Nodes);
                
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

                Program.incidentDataService.UpsertOperationalGroup(strikeTeamTaskForceDetailsControl1.SelectedOpGroup);
            }
        }

        private void treeOpsChart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeOpsChart.SelectedNode != null)
            {
                btnEditBranch.Enabled = true;
               
                Program.CurrentIncident.UpdateOperationalGroupCounts(Program.CurrentOpPeriod);

                OperationalGroup selectedGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                
                ICSRole LeaderICSRole = Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == selectedGroup.LeaderICSRoleID);

                //TODO Fix this to avoid deleting hard-coded op groups
                if (LeaderICSRole != null)
                {
                    btnDelete.Enabled = LeaderICSRole.AllowDelete;
                }

                SaveSTTFChanges();
                lblSelectedGroupName.Text = selectedGroup.ResourceName;
                lblSelectedGroupLeader.Text = selectedGroup.LeaderICSRoleName + " " + selectedGroup.LeaderName;

                if (selectedGroup != null && (selectedGroup.GroupType.EqualsWithNull("Strike Team") || selectedGroup.GroupType.EqualsWithNull("Task Force")))
                {
                    operationalGroupReportingResourcesControl1.Visible = false;
                    strikeTeamTaskForceDetailsControl1.Visible = true;
                    strikeTeamTaskForceDetailsControl1.Dock = DockStyle.Fill;
                    strikeTeamTaskForceDetailsControl1.SetSelectedGroup(selectedGroup);
                    //strikeTeamTaskForceDetailsControl1.SetRole(role);
                }
                else
                {
                    operationalGroupReportingResourcesControl1.Visible = true;
                    operationalGroupReportingResourcesControl1.Dock = DockStyle.Fill;
                    operationalGroupReportingResourcesControl1.SelectedOpGroup = selectedGroup;
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
                    form.SelectedGroup = group.Clone();

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OperationalGroup updatedGroup = form.SelectedGroup;
                        Program.incidentDataService.UpsertOperationalGroup(updatedGroup);
                        if (updatedGroup.LeaderICSRoleID == Guid.Empty)
                        {
                            ICSRole role = updatedGroup.CreateRoleFromOperationalGroup(Globals.incidentService.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == updatedGroup.OpPeriod).ID);
                            role.OperationalGroupName = updatedGroup.ResourceName;
                            Guid ReportsToRoleID = Program.CurrentIncident.GetICSReportsToThroughOpGroup(role);
                            if(ReportsToRoleID != Guid.Empty)
                            {
                                ICSRole reportsToRole = Program.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == updatedGroup.OpPeriod).AllRoles.FirstOrDefault(o => o.RoleID == ReportsToRoleID);
                                role.ReportsTo = reportsToRole.RoleID;
                                role.ReportsToGenericRoleID = reportsToRole.GenericRoleID;
                                role.ReportsToRoleName = reportsToRole.RoleName;
                            }
                            Program.incidentDataService.UpsertICSRole(role);
                            updatedGroup.LeaderICSRoleID = role.RoleID;
                            updatedGroup.LeaderICSRoleName = role.RoleName;

                            Program.incidentDataService.UpsertOperationalGroup(updatedGroup);
                        }
                        else if (!updatedGroup.Name.Equals(group.Name))
                        {
                            ICSRole role = Program.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == Program.CurrentOpPeriod).AllRoles.FirstOrDefault(o => o.RoleID == updatedGroup.LeaderICSRoleID);
                            if (role != null)
                            {
                                role.OperationalGroupName = updatedGroup.ResourceName;
                                Program.incidentDataService.UpsertICSRole(role);
                            }

                            //TODO need code here to switch to/from the specifically codified roles like heavy group branch 
                        }
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

                OperationalGroup selectedGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;

                if (selectedGroup.ParentID == Guid.Empty)
                {
                    using (OrganizationChartAssignRoleForm assignRoleForm = new OrganizationChartAssignRoleForm())
                    {
                        assignRoleForm.selectedRole = CurrentOrgChart.AllRoles.FirstOrDefault(o => o.RoleID == selectedGroup.LeaderICSRoleID);

                        DialogResult dr = assignRoleForm.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            Program.incidentDataService.UpsertICSRole(assignRoleForm.selectedRole);

                            if (CurrentOrgChart.PreparedByRoleID == Guid.Empty)
                            {
                                CurrentOrgChart.PreparedByRoleName = Program.CurrentRole.RoleName;
                                CurrentOrgChart.PreparedByResourceName = Program.CurrentRole.IndividualName;
                                CurrentOrgChart.PreparedByRoleID = Program.CurrentRole.RoleID;
                                CurrentOrgChart.PreparedByResourceID = Program.CurrentRole.IndividualID;
                                Program.incidentDataService.UpsertOrganizationalChart(CurrentOrgChart, false);
                            }
                        }

                    }
                }
                else
                {


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

        private void addNewBranchDivisionGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = Program.CurrentOpPeriod;
            OperationalGroup OpSection = Program.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.ParentID == Guid.Empty && o.OpPeriod == Program.CurrentOpPeriod);

            group.ParentID = OpSection.ID;
            group.ParentName = OpSection.ResourceName; 
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
                OperationalGroup selectedNodeGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                if(selectedNodeGroup.GroupType.Equals("Branch") || selectedNodeGroup.GroupType.Equals("Section"))
                {
                    group.ParentID = selectedNodeGroup.ID;
                    group.ParentName = selectedNodeGroup.ResourceName;
                }
                else
                {
                    group.ParentID = selectedNodeGroup.ParentID;
                    group.ParentName = selectedNodeGroup.ParentName;


                }

            
            }
            else
            {
                group.ParentID = Globals.OpsChiefGenericID;
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
                OperationalGroup selectedNodeGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                if (selectedNodeGroup.GroupType.Equals("Branch") || selectedNodeGroup.GroupType.Equals("Section"))
                {
                    group.ParentID = selectedNodeGroup.ID;
                    group.ParentName = selectedNodeGroup.ResourceName;
                }
                else
                {
                    group.ParentID = selectedNodeGroup.ParentID;
                    group.ParentName = selectedNodeGroup.ParentName;


                }
            }
            else
            {
                group.ParentID = Globals.OpsChiefGenericID;
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
                OperationalGroup selectedGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                if (selectedGroup.IsBranchOrDiv)
                {
                    group.ParentID = selectedGroup.ID;
                    group.ParentName = selectedGroup.ResourceName;
                }
                else
                {
                    group.ParentID = selectedGroup.ParentID;
                    group.ParentName = selectedGroup.ParentName;
                }
            }
            else
            {
                group.ParentID = Globals.OpsChiefGenericID;
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
                        Program.incidentDataService.UpsertOperationalGroup(grp);
                        
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
                OperationalGroup SelectedOpGroup = (OperationalGroup)treeOpsChart.SelectedNode.Tag;
                ICSRole OpGroupLeaderRole = Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == SelectedOpGroup.LeaderICSRoleID);

                if (OpGroupLeaderRole != null && OpGroupLeaderRole.AllowDelete)
                {
                    List<ICSRole> reportingRoles = CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == OpGroupLeaderRole.RoleID).ToList();
                    if (reportingRoles.Count > 0)
                    {
                        MessageBox.Show(Properties.Resources.DeleteSubordinateRoles);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            Program.incidentDataService.DeleteICSRole(OpGroupLeaderRole, Program.CurrentOpPeriod);
                            SelectedOpGroup.Active = false;
                            Program.incidentDataService.UpsertOperationalGroup(SelectedOpGroup);
                        }


                    }
                }

            }
        }

        private void btnPrint204_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsOutput.Show(ptLowerLeft);
        }

        private void btnPrint204A_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExportSignInToCSV_Click(object sender, EventArgs e)
        {
            
        }


        private void ExportToCSV()
        {
            svdExport.FileName = "AssignmentList-" + Program.CurrentIncident.IncidentNameAndNumberForPath + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";



                Program.CurrentIncident.UpdateOperationalGroupCounts(Program.CurrentOpPeriod);
                List<OperationalGroup> groups = Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.OpPeriod == Program.CurrentOpPeriod).OrderBy(o=>o.Depth).ThenBy(o=>o.Name).ToList();

                string csv = OperationalGroupTools.OperationalGroupsToCSV(groups, delimiter);
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
            
        }

        private void printLogisticsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
            List<byte[]> allPDFs = Program.pdfExportService.exportLogisticsSummaryToPDF(Program.CurrentTask, Program.CurrentOpPeriod, role, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Logistics Overview " + Program.CurrentIncident.IncidentNameAndNumberForPath;
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

        private void exportToSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void viewICS204PDFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 204 - " + Program.CurrentIncident.IncidentNameAndNumberForPath + " Op " + Program.CurrentOpPeriod;    // + ".pdf";

            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            PDFCreationResults results = Program.pdfExportService.exportAllAssignmentSummariesToPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false);
            if (results.errors.Any())
            {
                LogService log = new LogService();
                foreach (Exception ex in results.errors)
                {
                    log.Log("Exported ICS 204 PDF error: " + ex.ToString());
                }

            }
            if (results.Successful)
            {
                allPDFs.AddRange(results.bytes);


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
            else
            {
                MessageBox.Show("There was an error trying to export the ICS 204 PDFs.  Please check the log for details.");
            }
        }

        private void viewICS204APDFsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 204A - " + Program.CurrentIncident.IncidentNameAndNumberForPath + " Op " + Program.CurrentOpPeriod;    // + ".pdf";

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

        private void viewLogisticsOverviewPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOpsChart.SelectedNode.Tag;
            List<byte[]> allPDFs = Program.pdfExportService.exportLogisticsSummaryToPDF(Program.CurrentTask, Program.CurrentOpPeriod, role, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Logistics Overview " + Program.CurrentIncident.IncidentNameAndNumberForPath;
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
}
