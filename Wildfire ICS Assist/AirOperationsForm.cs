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
        private AirOperationsSummary CurrentAirOpsSummary { get => Program.CurrentIncident.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }


        public AirOperationsForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground; dgvAircraft.BackgroundColor = Program.FormAccent;
        }

        private void AirOperationsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }

            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod);
            LoadMainData();
            PopulateAircraft();
            PopulateTree();
            PopulateCommsItems();
            LoadPreparedBy();

            SetNOTAMCheckbox();

            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;

            Program.wfIncidentService.CommsPlanChanged += Program_CommsPlanChanged;
            Program.wfIncidentService.CommsPlanItemChanged += Program_CommsPlanItemChanged;

            Program.wfIncidentService.AircraftChanged += Program_AircraftChanged;
            Program.wfIncidentService.AircraftsOperationsSummaryChanged += Program_AirOpsSummaryChanged;

            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod);
            LoadMainData();
            PopulateAircraft();
            PopulateTree();
            PopulateCommsItems();
            LoadPreparedBy();

            SetNOTAMCheckbox();
        }

        private void LoadPreparedBy()
        {
            cboPreparedBy.DataSource = null;
            cboPreparedBy.DataSource = CurrentOrgChart.Clone().ActiveRoles; cboPreparedBy.DisplayMember = "RoleNameWithIndividualAndDepth"; cboPreparedBy.ValueMember = "RoleID";
            if (CurrentAirOpsSummary.PreparedByPositionID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == CurrentAirOpsSummary.PreparedByPositionID)) { cboPreparedBy.SelectedValue = CurrentAirOpsSummary.PreparedByPositionID; }

        }

        private void LoadMainData()
        {
            if (CurrentAirOpsSummary.Sunrise > datSunrise.MinDate) { datSunrise.Value = CurrentAirOpsSummary.Sunrise; }
            else { CurrentAirOpsSummary.Sunrise = datSunrise.Value; }

            if (CurrentAirOpsSummary.Sunset > datSunset.MinDate) { datSunset.Value = CurrentAirOpsSummary.Sunset; }
            else { CurrentAirOpsSummary.Sunset = datSunset.Value; }
            txtRemarks.Text = CurrentAirOpsSummary.Remarks;
            txtMedivacText.Text = CurrentAirOpsSummary.MedivacAircraftText;


        }

        private void Program_AirOpsSummaryChanged (AirOperationsSummaryEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                SetNOTAMCheckbox();
                LoadMainData();
                LoadPreparedBy();
            }
        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree(); }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree(); LoadPreparedBy(); }
        }


        private void Program_CommsPlanChanged(CommsPlanEventArgs e)
        {
            if (e.item.OpsPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }
        private void Program_CommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if (e.item.OpsPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }

        private void Program_AircraftChanged(AircraftEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateAircraft(); }
        }

        private void PopulateAircraft()
        {
            dgvAircraft.DataSource = null;
            dgvAircraft.AutoGenerateColumns = false;
            dgvAircraft.DataSource = CurrentAirOpsSummary.activeAircraft;
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
        private void AddFirstChild(TreeNodeCollection nodes)
        {
            var rows = CurrentOrgChart.ActiveRoles.Where(o => o.RoleID == WF_ICS_ClassLibrary.Globals.AirOpsDirector).ToList();

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
            if (dgvCommsItems.SelectedRows.Count == 1)
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
                    Program.wfIncidentService.UpsertCommsPlanItem(editForm.SelectedItem.Clone(), null, "local");

                }
            }
        }

        private void btnDeleteComms_Click(object sender, EventArgs e)
        {
            if (dgvCommsItems.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<CommsPlanItem> toDelete = new List<CommsPlanItem>();

                foreach (DataGridViewRow row in dgvCommsItems.SelectedRows)
                {
                    toDelete.Add((CommsPlanItem)row.DataBoundItem);
                }

                foreach (CommsPlanItem c in toDelete) { c.Active = false; Program.wfIncidentService.UpsertCommsPlanItem(c); }
            }
        }


        private void SetNOTAMCheckbox()
        {
            if (CurrentAirOpsSummary.notam.AnyContent) { btnNOTAM.Image = Properties.Resources.glyphicons_basic_739_check; }
            else { btnNOTAM.Image = null; }

        }

        private void btnAddAircraft_Click(object sender, EventArgs e)
        {
            using (AircraftEntryForm entryForm = new AircraftEntryForm())
            {
                Aircraft a = new Aircraft();
                a.OpPeriod = Program.CurrentOpPeriod;
                entryForm.selectedAircraft = a;
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertAircraft(entryForm.selectedAircraft);
                    if (entryForm.SaveForLater)
                    {
                        Aircraft save = entryForm.selectedAircraft.Clone();
                        save.Pilot = string.Empty;
                        save.StartTime = DateTime.MinValue;
                        save.EndTime = DateTime.MinValue;
                        save.IsMedivac = false;
                        Program.generalOptionsService.UpserOptionValue(save, "Aircraft");

                    }
                }
            }
        }

        private void OpenAircraftForEdit(Aircraft aircraft)
        {
            using (AircraftEditForm editForm = new AircraftEditForm())
            {
                editForm.selectedAircraft = aircraft.Clone();
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertAircraft(editForm.selectedAircraft);
                }
            }
        }
        private void btnEditAircraft_Click(object sender, EventArgs e)
        {
            if(dgvAircraft.SelectedRows.Count == 1)
            {
                Aircraft a = dgvAircraft.SelectedRows[0].DataBoundItem as Aircraft;
                if (a != null) { OpenAircraftForEdit(a); }
            }
        }

        private void dgvAircraft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Aircraft a = dgvAircraft.Rows[e.RowIndex].DataBoundItem as Aircraft;
                if(a != null) { OpenAircraftForEdit(a); }
            }
        }

        private void dgvAircraft_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAircraft.Enabled = dgvAircraft.SelectedRows.Count == 1;
            btnDeleteAircraft.Enabled = dgvAircraft.SelectedRows.Count > 0;
        }

        private void btnDeleteAircraft_Click(object sender, EventArgs e)
        {
            if(dgvAircraft.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    List<Aircraft> toDelete = new List<Aircraft>();
                    foreach(DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        Aircraft a = (Aircraft)row.DataBoundItem;
                        if(a != null) { toDelete.Add(a); }
                    }
                    foreach(Aircraft a in toDelete)
                    {
                        a.Active = false;
                        Program.wfIncidentService.UpsertAircraft(a);
                    }
                }
            }
        }

        private void txtMedivacText_TextChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.MedivacAircraftText= txtMedivacText.Text;
        }

        private void cboPreparedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboPreparedBy_Leave(object sender, EventArgs e)
        {
            if(cboPreparedBy.SelectedItem != null)
            {
                ICSRole role = (ICSRole)cboPreparedBy.SelectedItem;
                CurrentAirOpsSummary.PreparedByName = role.IndividualName;
                CurrentAirOpsSummary.PreparedByPosition = role.RoleName;
                CurrentAirOpsSummary.PreparedByPositionID= role.RoleID;
            }
        }

        private void btnNOTAM_Click(object sender, EventArgs e)
        {
            using (AirNOTAMEditForm editForm = new AirNOTAMEditForm())
            {
                editForm.selectedNOTAM = CurrentAirOpsSummary.notam.Clone();
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    CurrentAirOpsSummary.notam = editForm.selectedNOTAM;
                    if (CurrentAirOpsSummary.notam.UseRadius && CurrentAirOpsSummary.notam.RadiusCentre != null) { SetSunTimesByCoordinate(CurrentAirOpsSummary.notam.RadiusCentre); }
                    else if (!CurrentAirOpsSummary.notam.UseRadius && CurrentAirOpsSummary.notam.AnyCoordinates)
                    {
                        List<Coordinate> coordinates = new List<Coordinate>();
                        if (CurrentAirOpsSummary.notam.PolygonNW != null) { coordinates.Add(CurrentAirOpsSummary.notam.PolygonNW); }
                        if (CurrentAirOpsSummary.notam.PolygonNE != null) { coordinates.Add(CurrentAirOpsSummary.notam.PolygonNE); }
                        if (CurrentAirOpsSummary.notam.PolygonSW != null) { coordinates.Add(CurrentAirOpsSummary.notam.PolygonSW); }
                        if (CurrentAirOpsSummary.notam.PolygonSE != null) { coordinates.Add(CurrentAirOpsSummary.notam.PolygonSE); }
                        if (coordinates.Any())
                        {
                            Coordinate centre = GISTools.FindCentroid(coordinates);
                            if (centre != null) { SetSunTimesByCoordinate(centre); }
                        }
                    }
                    Program.wfIncidentService.UpsertAirOperationsSummary(CurrentAirOpsSummary);
                    SetNOTAMCheckbox();
                }
            }
        }

        private void SetSunTimesByCoordinate(Coordinate c)
        {
            DateTime opTime = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodStart;
            datSunrise.Value = GISTools.GetSunrise(c, opTime);
            datSunset.Value = GISTools.GetSunset(c, opTime);
        }

        private void datSunrise_ValueChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.Sunrise= datSunrise.Value;
        }

        private void datSunset_ValueChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.Sunset= datSunset.Value;
        }

        private void AirOperationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.wfIncidentService.UpsertAirOperationsSummary(CurrentAirOpsSummary);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //catch any changes that have been made and make sure they're saved.
            Program.wfIncidentService.UpsertAirOperationsSummary(CurrentAirOpsSummary);


            string path = Program.pdfExportService.CreateAirOpsSummaryPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false, false);
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
    }
}
