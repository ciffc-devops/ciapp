
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationalChartForm : BaseForm
    {
        private Incident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }

        public OrganizationalChartForm()
        {
           
            InitializeComponent(); 
        }


        private void OrganizationalChartForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            PopulateTree();
            rbUnifiedCommand.Checked = CurrentOrgChart.IsUnifiedCommand;

            Program.incidentDataService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.incidentDataService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OpPeriodChanged;


            chkIncludeContacts.Checked = Program.generalOptionsService.GetOptionsBoolValue("IncludeOrgContactsInIAP");
        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            PopulateTree();
        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                PopulateTree();
            }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item != null && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == e.item.RoleID)) { PopulateTree(e.item); }
            else { PopulateTree(); }
        }


        private void PopulateTree(ICSRole selectedRole = null)
        {
            if (!Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createOrgChartAsNeeded(Program.CurrentOpPeriod);
            }


            treeOrgChart.Nodes.Clear();
            // call recursive function
            AddCurrentChild(Guid.Empty, treeOrgChart.Nodes);

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
            var rows = CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == parentId).ToList();

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

        private void treeOrgChart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeOrgChart.SelectedNode != null)
            {
                ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
                if (role.RoleID == WF_ICS_ClassLibrary.Globals.IncidentCommanderID && CurrentOrgChart.IsUnifiedCommand) { btnAssignRole.Enabled = false; }
                else { btnAssignRole.Enabled = true; }
            }
            else
            {
                btnAssignRole.Enabled = false;
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            ICSRole parentRole = (ICSRole)treeOrgChart.SelectedNode.Tag;


            ICSRole role = new ICSRole();
            role.OrganizationalChartID = CurrentOrgChart.ID;
            role.OpPeriod = CurrentOrgChart.OpPeriod;
            role.ReportsTo = parentRole.RoleID;
            openRoleForEdit(role);
        }

        private void openRoleForEdit(ICSRole role)
        {
            if (role.AllowEditName)
            {
                using (OrganizationChartAddRoleForm addRoleForm = new OrganizationChartAddRoleForm())
                {
                    addRoleForm.selectedRole = role;
                    DialogResult dr = addRoleForm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Program.incidentDataService.UpsertICSRole(addRoleForm.selectedRole);
                    }
                }
            }
            else if (role.IsOpGroupSup)
            {
                MessageBox.Show(Properties.Resources.EditInAssignmnetList);
            }

            else { MessageBox.Show(Properties.Resources.ProtectedRole); }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
            openRoleForEdit(role);
        }

        private void btnAssignRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            AssignRole(role);
        }

        private void AssignRole(ICSRole role)
        {
            if (role != null)
            {
                using (OrganizationChartAssignRoleForm assignRoleForm = new OrganizationChartAssignRoleForm())
                {
                    assignRoleForm.selectedRole = role.Clone();

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
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            DeleteRole(role);

        }

        private void DeleteRole(ICSRole role)
        {
            if (role.AllowDelete)
            {
                //check if there are subordinate roles
                if (Program.CurrentOrgChart.ActiveRoles.Any(o => o.ReportsTo == role.RoleID))
                {
                    MessageBox.Show(Properties.Resources.DeleteSubordinateRoles);
                }
                else
                {
                    DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Program.incidentDataService.DeleteICSRole(role, Program.CurrentOpPeriod);
                    }
                }
            }
            else if (role.AllowEditName)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.RenameInsteadOfDeleteRole, Properties.Resources.RenameTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    openRoleForEdit(role);
                }
            }
            else { MessageBox.Show(Properties.Resources.ProtectedRole); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {


            if (chkIncludeContacts.Checked)
            {
                string orgChart = Program.pdfExportService.createOrgChartPDF(CurrentIncident, CurrentOpPeriod, false, true, false);
                string contactList = Program.pdfExportService.createOrgChartContactList(CurrentIncident, CurrentOpPeriod, false, true);

                List<byte[]> allPDFs = new List<byte[]>();


                using (FileStream stream = File.OpenRead(orgChart))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
                if (!string.IsNullOrEmpty(contactList))
                {
                    using (FileStream stream = File.OpenRead(contactList))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }
                }

                string fullFilepath = "";
                //int end = CurrentTask.FileName.LastIndexOf("\\");
                fullFilepath = FileAccessClasses.getWritablePath(CurrentIncident);

                string fullOutputFilename = "ICS 207 - Task " + CurrentIncident.IncidentNameAndNumberForPath + " - Op " + CurrentOpPeriod + " - Org Chart";
                //fullFilepath = System.IO.Path.Combine(fullFilepath, outputFileName);
                fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(fullFilepath, fullFile);

                    System.Diagnostics.Process.Start(fullFilepath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
                }

            }
            else
            {
                string path = Program.pdfExportService.createOrgChartPDF(CurrentIncident, CurrentOpPeriod, true);
                try { System.Diagnostics.Process.Start(path); }
                catch { }
            }


        }

        private void rbIncidentCommander_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncidentCommander.Checked)
            {
                if (CurrentOrgChart.HasFilledUnifiedCommandRoles)
                {
                    DialogResult dr = MessageBox.Show(Properties.Resources.NoSwitchToICWithUCRolesFilled, Properties.Resources.ClearUnifiedCommandRolesTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ICSRole uc2 = CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.UnifiedCommand2ID);
                        if (uc2 != null)
                        {
                            CurrentOrgChart.UnassignThisAndSubordinateRoles(uc2);
                        }

                        ICSRole uc3 = CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.UnifiedCommand3ID);
                        if (uc3 != null)
                        {
                            CurrentOrgChart.UnassignThisAndSubordinateRoles(uc2);
                        }
                        CurrentOrgChart.SwitchToSingleIC();
                    }
                    else
                    {
                        rbUnifiedCommand.Checked = true;
                    }
                }
                else { CurrentOrgChart.SwitchToSingleIC(); }
            }
        }

        private void rbUnifiedCommand_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnifiedCommand.Checked) { CurrentOrgChart.SwitchToUnifiedCommand(); }

        }

        private void rbIncidentCommander_Leave(object sender, EventArgs e)
        {

        }

        private void rbUnifiedCommand_Leave(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "OrgChart-" + Program.CurrentIncident.IncidentNameAndNumberForPath + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";






                string csv = OrgChartTools.OrgChartToCSV(CurrentOrgChart.ActiveRoles, delimiter);
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

        private void btnPrint203_Click(object sender, EventArgs e)
        {
            if (chkIncludeContacts.Checked)
            {
                string fullFilepath = "";
                fullFilepath = FileAccessClasses.getWritablePath(CurrentIncident);

                PDFCreationResults orgChartResults = Program.pdfExportService.createOrgAssignmentListPDF(CurrentIncident, CurrentOpPeriod, true, false);
                string orgChart = orgChartResults.path;

                string contactList = Program.pdfExportService.createOrgChartContactList(CurrentIncident, CurrentOpPeriod, false, true);

                if (orgChartResults.Successful)
                {
                    List<byte[]> allPDFs = new List<byte[]>();


                    using (FileStream stream = File.OpenRead(orgChart))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }
                    if (!string.IsNullOrEmpty(contactList))
                    {
                        using (FileStream stream = File.OpenRead(contactList))
                        {
                            byte[] fileBytes = new byte[stream.Length];

                            stream.Read(fileBytes, 0, fileBytes.Length);
                            stream.Close();
                            allPDFs.Add(fileBytes);
                        }
                    }



                    string fullOutputFilename = "ICS 203 - Incident " + CurrentIncident.IncidentNameAndNumberForPath + " - Op " + CurrentOpPeriod + " - Org Assignments List";
                    //fullFilepath = System.IO.Path.Combine(fullFilepath, outputFileName);
                    fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

                    byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                    try
                    {
                        File.WriteAllBytes(fullFilepath, fullFile);

                        System.Diagnostics.Process.Start(fullFilepath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
                }
            }
            else
            {
                PDFCreationResults results = Program.pdfExportService.createOrgAssignmentListPDF(CurrentIncident, CurrentOpPeriod, false, false);
                string path = results.path;
                try { System.Diagnostics.Process.Start(path); }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
                }
            }
        }

        private void addRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole parentRole = (ICSRole)treeOrgChart.SelectedNode.Tag;


            ICSRole role = new ICSRole();
            role.OrganizationalChartID = CurrentOrgChart.ID;
            role.OpPeriod = CurrentOrgChart.OpPeriod;
            role.ReportsTo = parentRole.RoleID;
            openRoleForEdit(role);
        }

        private void assignSelectedRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            AssignRole(role);
        }

        private void editSelectedRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
            openRoleForEdit(role);

        }

        private void printLogisticsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
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

        private void removeSelectedRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            DeleteRole(role);
        }
    }
}
