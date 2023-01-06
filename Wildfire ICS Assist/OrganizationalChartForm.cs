﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationalChartForm : Form
    {
        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }

        public OrganizationalChartForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }


        private void OrganizationalChartForm_Load(object sender, EventArgs e)
        {
            PopulateTree();


            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;
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
            PopulateTree();
        }


        private void PopulateTree()
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
                treeOrgChart.SelectedNode = treeOrgChart.Nodes[0];
                if (treeOrgChart.SelectedNode != null) treeOrgChart.SelectedNode.EnsureVisible();

            }
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
                if (OrgChartTools.ProtectedRoleIDs.Contains(role.RoleID))
                {
                    btnEditRole.Enabled = false;
                    btnDeleteRole.Enabled = false;
                }
                else
                {
                    btnEditRole.Enabled = true;
                    btnDeleteRole.Enabled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ICSRole role = new ICSRole();
            role.OrganizationalChartID = CurrentOrgChart.OrganizationalChartID;
            role.OpPeriod = CurrentOrgChart.OpPeriod;
            openRoleForEdit(role);
        }

        private void openRoleForEdit(ICSRole role)
        {
            using (OrganizationChartAddRoleForm addRoleForm = new OrganizationChartAddRoleForm())
            {
                addRoleForm.selectedRole = role;
                DialogResult dr = addRoleForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertICSRole(addRoleForm.selectedRole);
                }
            }
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)treeOrgChart.SelectedNode.Tag;
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
                }

            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            ICSRole role = (ICSRole)(treeOrgChart.SelectedNode.Tag);
            if (!OrgChartTools.ProtectedRoleIDs.Contains(role.RoleID))
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    Program.wfIncidentService.DeleteICSRole(role, Program.CurrentOpPeriod);
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool IncludeContacts = Program.generalOptionsService.GetOptionsBoolValue("IncludeOrgContactsInIAP");

            if (IncludeContacts)
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

                string fullOutputFilename = "ICS 207 - Task " + CurrentIncident.IncidentIdentifier + " - Op " + CurrentOpPeriod + " - Org Chart";
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
    }
}