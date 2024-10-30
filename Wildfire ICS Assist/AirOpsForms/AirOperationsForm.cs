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
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class AirOperationsForm : BaseForm
    {
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }
        private AirOperationsSummary CurrentAirOpsSummary { get => Program.CurrentIncident.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }
        public NOTAM selectedNOTAM { get => CurrentAirOpsSummary.notam; set { CurrentAirOpsSummary.notam = value; } }
        private Coordinate[] enteredPolygonCoordinates = new Coordinate[4]; //NW, NE, SE, SW
        private Coordinate enteredRadiusCoordinate = null;


        public AirOperationsForm()
        {
            InitializeComponent(); dgvAircraft.BackgroundColor = Program.FormAccent;
        }

        private void AirOperationsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }

            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod, Program.CurrentRole);
            LoadMainData();
            PopulateAircraft();
            PopulateTree();
            PopulateCommsItems();

            loadNOTAM();

            Program.incidentDataService.OrganizationalChartChanged += Program_OrgChartChanged;
            Program.incidentDataService.ICSRoleChanged += Program_ICSRoleChanged;

            Program.incidentDataService.CommsPlanChanged += Program_CommsPlanChanged;
            Program.incidentDataService.CommsPlanItemChanged += Program_CommsPlanItemChanged;

            Program.incidentDataService.AircraftChanged += Program_AircraftChanged;
            Program.incidentDataService.AircraftsOperationsSummaryChanged += Program_AirOpsSummaryChanged;
            Program.incidentDataService.MemberSignInChanged += WfIncidentService_MemberSignInChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OpPeriodChanged;

            prepAndApprovePanel1.ApprovedByChanged += PrepAndApprovePanel1_ApprovedByChanged;
            prepAndApprovePanel1.PreparedByChanged += PrepAndApprovePanel1_PreparedByChanged;

        }

        private void PrepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
            CurrentAirOpsSummary.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;
        }

        private void PrepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
            CurrentAirOpsSummary.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;
        }

        private void WfIncidentService_MemberSignInChanged(CheckInEventArgs e)
        {
            if (e.signInRecord != null && e.signInRecord.ResourceType != null && e.signInRecord.ResourceType.Equals("Aircraft"))
            {
                PopulateAircraft();

            }
        }

        private void loadNOTAM()
        {
            lblNWCoordinateOK.Text = ""; lblNECoordinateOK.Text = ""; lblSECoordinateOK.Text = ""; lblSWCoordinateOK.Text = "";
            lblCoordinateStatus.Text = "";

            numAltitude.Value = selectedNOTAM.AltitudeASL;
            txtCenterPoint.Text = selectedNOTAM.CenterPoint;

            if (selectedNOTAM.UseRadius)
            {
                rbRadius.Checked = true;
                numRadius.Value = selectedNOTAM.RadiusNM;
                if (selectedNOTAM.RadiusCentre != null)
                {
                    rbRadius.Checked = true;
                    Coordinate coord = selectedNOTAM.RadiusCentre;

                    if (coord.Latitude != 0 || coord.Longitude != 0)
                    {
                        txtRadiusCoordinates.Text = coord.CoordinateOutput("Degrees Decimal Minutes");
                        lblCoordinateStatus.Text = "Coordinate OK";
                        lblCoordinateStatus.ForeColor = label1.ForeColor;
                        enteredRadiusCoordinate = coord;
                    }
                    else { txtRadiusCoordinates.Text = string.Empty; lblCoordinateStatus.Text = ""; }
                }
                else { txtRadiusCoordinates.Text = string.Empty; lblCoordinateStatus.Text = ""; }
            }
            else
            {
                rbPoygon.Checked = true;

                if (selectedNOTAM.PolygonNW != null)
                {
                    txtPolygonNW.Text = selectedNOTAM.PolygonNW.CoordinateOutput("Degrees Decimal Minutes");
                    lblNWCoordinateOK.Text = "Coordinate OK";
                    lblNWCoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonNW.Text = string.Empty; lblNWCoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonNE != null)
                {
                    txtPolygonNE.Text = selectedNOTAM.PolygonNE.CoordinateOutput("Degrees Decimal Minutes");
                    lblNECoordinateOK.Text = "Coordinate OK";
                    lblNECoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonNE.Text = string.Empty; lblNECoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonSE != null)
                {
                    txtPolygonSE.Text = selectedNOTAM.PolygonSE.CoordinateOutput("Degrees Decimal Minutes");
                    lblSECoordinateOK.Text = "Coordinate OK";
                    lblSECoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonSE.Text = string.Empty; lblSECoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonSW != null)
                {
                    txtPolygonSW.Text = selectedNOTAM.PolygonSW.CoordinateOutput("Degrees Decimal Minutes");
                    lblSWCoordinateOK.Text = "Coordinate OK";
                    lblSWCoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonSW.Text = string.Empty; lblSWCoordinateOK.Text = ""; }

            }

        }

        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            Program.CurrentIncident.createAirOpsSummaryAsNeeded(Program.CurrentOpPeriod);
            LoadMainData();
            PopulateAircraft();
            PopulateTree();
            PopulateCommsItems();
            loadNOTAM();
        }

     

        private void LoadMainData()
        {
            if (CurrentAirOpsSummary.Sunrise > datSunrise.MinDate) { datSunrise.Value = CurrentAirOpsSummary.Sunrise; }
            else { CurrentAirOpsSummary.Sunrise = datSunrise.Value; }

            if (CurrentAirOpsSummary.Sunset > datSunset.MinDate) { datSunset.Value = CurrentAirOpsSummary.Sunset; }
            else { CurrentAirOpsSummary.Sunset = datSunset.Value; }
            txtRemarks.Text = CurrentAirOpsSummary.Remarks;
            txtMedivacText.Text = CurrentAirOpsSummary.MedivacAircraftText;

            prepAndApprovePanel1.SetPreparedBy(CurrentAirOpsSummary.PreparedByRoleID, CurrentAirOpsSummary.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(CurrentAirOpsSummary.ApprovedByRoleID, CurrentAirOpsSummary.DateApproved);

        }

        private void Program_AirOpsSummaryChanged(AirOperationsSummaryEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                loadNOTAM();
                LoadMainData();
            }
        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree(); }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateTree();  }
        }


        private void Program_CommsPlanChanged(CommsPlanEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }
        private void Program_CommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod) { PopulateCommsItems(); }
        }

        private void Program_AircraftChanged(AircraftEventArgs e)
        {
            PopulateAircraft();
        }


        private void PopulateAircraft()
        {
            dgvAircraft.DataSource = null;
            dgvAircraft.AutoGenerateColumns = false;
            dgvAircraft.DataSource = Program.CurrentIncident.GetActiveAircraft(Program.CurrentOpPeriodDetails.PeriodMid);
        }

        private void PopulateCommsItems()
        {
            dgvCommsItems.AutoGenerateColumns = false;
            dgvCommsItems.DataSource = null;
            if (!Program.CurrentIncident.allCommsPlans.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createCommsPlanAsNeeded(Program.CurrentOpPeriod);
            }
            CommsPlan plan = Program.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);

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
            role.OrganizationalChartID = CurrentOrgChart.ID;
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
                    Program.incidentDataService.DeleteICSRole(role, Program.CurrentOpPeriod);
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
                        Program.incidentDataService.UpsertICSRole(addRoleForm.selectedRole);
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
                    entryForm.SelectedItem.OpPeriod = Program.CurrentOpPeriod;
                    entryForm.SelectedItem.OrganizationID = CurrentOrgChart.ID;

                    Program.incidentDataService.UpsertCommsPlanItem(entryForm.SelectedItem, null, "local");


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
                    Program.incidentDataService.UpsertCommsPlanItem(editForm.SelectedItem.Clone(), null, "local");

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

                foreach (CommsPlanItem c in toDelete) { c.Active = false; Program.incidentDataService.UpsertCommsPlanItem(c); }
            }
        }



        /*
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
                }*/
        /*
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
        */
        private void dgvAircraft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*  if(e.RowIndex >= 0)
              {
                  Aircraft a = dgvAircraft.Rows[e.RowIndex].DataBoundItem as Aircraft;
                  if(a != null) { OpenAircraftForEdit(a); }
              }*/
        }

        private void dgvAircraft_SelectionChanged(object sender, EventArgs e)
        {
            //btnEditAircraft.Enabled = dgvAircraft.SelectedRows.Count == 1;
            //btnDeleteAircraft.Enabled = dgvAircraft.SelectedRows.Count > 0;
            btnToggleMedicvac.Enabled = dgvAircraft.SelectedRows.Count > 0;
            btnSetStartEndTimes.Enabled = dgvAircraft.SelectedRows.Count > 0;
            btnRemarks.Enabled = dgvAircraft.SelectedRows.Count > 0;

        }

        private void btnDeleteAircraft_Click(object sender, EventArgs e)
        {
            if (dgvAircraft.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    List<Aircraft> toDelete = new List<Aircraft>();
                    foreach (DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        Aircraft a = (Aircraft)row.DataBoundItem;
                        if (a != null) { toDelete.Add(a); }
                    }
                    foreach (Aircraft a in toDelete)
                    {
                        a.Active = false;
                        Program.incidentDataService.UpsertAircraft(a);
                    }
                }
            }
        }

        private void txtMedivacText_TextChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.MedivacAircraftText = txtMedivacText.Text;
        }

        private void cboPreparedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    Program.incidentDataService.UpsertAirOperationsSummary(CurrentAirOpsSummary);
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
            CurrentAirOpsSummary.Sunrise = datSunrise.Value;
        }

        private void datSunset_ValueChanged(object sender, EventArgs e)
        {
            CurrentAirOpsSummary.Sunset = datSunset.Value;
        }

        private void AirOperationsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNOTAM();
            Program.incidentDataService.UpsertAirOperationsSummary(CurrentAirOpsSummary);

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveNOTAM();
            //catch any changes that have been made and make sure they're saved.
            Program.incidentDataService.UpsertAirOperationsSummary(CurrentAirOpsSummary);


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

        private void SaveNOTAM()
        {
            if (!coordinatesAreGoodOrBlank)
            {
                MessageBox.Show(Properties.Resources.ValidCoordinatesRequired);
            }
            else
            {
                selectedNOTAM.UseRadius = rbRadius.Checked;
                if (selectedNOTAM.UseRadius)
                {
                    selectedNOTAM.RadiusNM = numRadius.Value;
                    selectedNOTAM.RadiusCentre = enteredRadiusCoordinate;
                    selectedNOTAM.PolygonNW = null;
                    selectedNOTAM.PolygonNE = null;
                    selectedNOTAM.PolygonSE = null;
                    selectedNOTAM.PolygonSW = null;

                }
                else
                {
                    selectedNOTAM.RadiusNM = 0;
                    selectedNOTAM.RadiusCentre = null;
                    if (enteredPolygonCoordinates[0] != null) { selectedNOTAM.PolygonNW = enteredPolygonCoordinates[0]; }
                    if (enteredPolygonCoordinates[1] != null) { selectedNOTAM.PolygonNE = enteredPolygonCoordinates[1]; }
                    if (enteredPolygonCoordinates[2] != null) { selectedNOTAM.PolygonSE = enteredPolygonCoordinates[2]; }
                    if (enteredPolygonCoordinates[3] != null) { selectedNOTAM.PolygonSW = enteredPolygonCoordinates[3]; }
                }


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
            }
        }

        private void dgvAircraft_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAircraft.Rows[e.RowIndex].DataBoundItem != null)
            {
                Aircraft a = (Aircraft)dgvAircraft.Rows[e.RowIndex].DataBoundItem;
                Program.incidentDataService.UpsertAircraft(a);
            }
        }



        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates(txtRadiusCoordinates, lblCoordinateStatus);
            if (temp != null)
            {
                enteredRadiusCoordinate = temp;
            }
            else { enteredRadiusCoordinate = null; }
        }

        private Coordinate CheckCoordinates(TextBox txtCoordinates, Label lblResultMessage)
        {
            Coordinate temp = new Coordinate();
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
                {
                    lblResultMessage.Text = "Coordinate OK";
                    lblResultMessage.ForeColor = label1.ForeColor;
                    txtCoordinates.BackColor = SystemColors.Window;
                }
                else
                {
                    lblResultMessage.Text = "Coordinate Error!";
                    lblResultMessage.ForeColor = Color.Red;
                    txtCoordinates.BackColor = Program.ErrorColor;
                }
            }
            else
            {
                lblResultMessage.Text = "";
                lblResultMessage.ForeColor = Color.Red;
                txtCoordinates.BackColor = txtCenterPoint.BackColor;
            }
            return temp;
        }

        private bool coordinatesAreGoodOrBlank
        {
            get
            {
                if (rbRadius.Checked)
                {
                    if (string.IsNullOrEmpty(txtRadiusCoordinates.Text)) { return true; }
                    Coordinate temp = new Coordinate();
                    return temp.TryParseCoordinate(txtRadiusCoordinates.Text, out temp);
                }
                else
                {
                    Coordinate temp = new Coordinate();
                    if (!string.IsNullOrEmpty(txtPolygonNW.Text) && !temp.TryParseCoordinate(txtPolygonNW.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonNE.Text) && !temp.TryParseCoordinate(txtPolygonNE.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonSE.Text) && !temp.TryParseCoordinate(txtPolygonSE.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonSW.Text) && !temp.TryParseCoordinate(txtPolygonSW.Text, out temp)) { return false; }

                    return true;
                }
            }
        }

        private void txtCenterPoint_TextChanged(object sender, EventArgs e)
        {
            selectedNOTAM.CenterPoint = txtCenterPoint.Text;

        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            selectedNOTAM.AltitudeASL = numAltitude.Value;

        }

        private void numRadius_ValueChanged(object sender, EventArgs e)
        {
            selectedNOTAM.RadiusNM = numRadius.Value;

        }

        private void rbRadius_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRadius.Checked)
            {
                pnlRadius.BackColor = Color.White;
                rbPoygon.Checked = false;
            }
            else
            {
                pnlRadius.BackColor = Program.FormAccent;


            }

        }

        private void rbPoygon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPoygon.Checked)
            {
                pnlPolygon.BackColor = Color.White;
                rbRadius.Checked = false;
            }
            else
            {
                pnlPolygon.BackColor = Program.FormAccent;


            }
        }

        private void pnlRadius_Enter(object sender, EventArgs e)
        {
            rbRadius.Checked = true;

        }

        private void pnlPolygon_Enter(object sender, EventArgs e)
        {
            rbPoygon.Checked = true;

        }

        //NW, NE, SE, SW

        private void txtPolygonNW_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblNWCoordinateOK);
            if (temp != null && temp.Latitude != 0 && temp.Longitude != 0)
            {
                enteredPolygonCoordinates[0] = temp;
            }
            else { enteredPolygonCoordinates[0] = null; }
        }

        private void txtPolygonNE_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblNECoordinateOK);
            if (temp != null && temp.Latitude != 0 && temp.Longitude != 0)
            {
                enteredPolygonCoordinates[1] = temp;
            }
            else { enteredPolygonCoordinates[1] = null; }
        }

        private void txtPolygonSW_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblSWCoordinateOK);
            if (temp != null && temp.Latitude != 0 && temp.Longitude != 0)
            {
                enteredPolygonCoordinates[3] = temp;
            }
            else { enteredPolygonCoordinates[3] = null; }
        }

        private void txtPolygonSE_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblSECoordinateOK);
            if (temp != null && temp.Latitude != 0 && temp.Longitude != 0)
            {
                enteredPolygonCoordinates[2] = temp;
            }
            else { enteredPolygonCoordinates[2] = null; }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControlExt.tabControlCustomColor_DrawItem(sender, e);
        }

        private void btnSetStartEndTimes_Click(object sender, EventArgs e)
        {
            if (dgvAircraft.SelectedRows.Count > 0)
            {
                using (SelectTimeRangeForm selectForm = new SelectTimeRangeForm())
                {
                    List<Aircraft> aircraft = new List<Aircraft>();

                    foreach (DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        if (row.DataBoundItem != null)
                        {
                            aircraft.Add((Aircraft)row.DataBoundItem);
                        }
                    }
                    if (aircraft.Any())
                    {
                        selectForm.StartTime = aircraft.OrderBy(o => o.StartTime).First().StartTime;
                        selectForm.EndTime = aircraft.OrderByDescending(o => o.EndTime).First().EndTime;


                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {


                            foreach (Aircraft a in aircraft)
                            {
                                a.StartTime = selectForm.StartTime;
                                a.EndTime = selectForm.EndTime;
                                Program.incidentDataService.UpsertAircraft(a);
                            }
                        }
                    }
                }



            }
        }

        private void btnToggleMedicvac_Click(object sender, EventArgs e)
        {
            if (dgvAircraft.SelectedRows.Count > 0)
            {
                using (SelectBooleanForm selectForm = new SelectBooleanForm())
                {
                    List<Aircraft> aircraft = new List<Aircraft>();

                    foreach (DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        if (row.DataBoundItem != null)
                        {
                            aircraft.Add((Aircraft)row.DataBoundItem);
                        }
                    }

                    if (aircraft.Any())
                    {
                        selectForm.Question = "Are the selected aircraft used for medivac?";
                        selectForm.Response = aircraft.First().IsMedivac;
                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {


                            foreach (Aircraft a in aircraft)
                            {
                                a.IsMedivac = selectForm.Response;
                                Program.incidentDataService.UpsertAircraft(a);
                            }
                        }
                    }
                }



            }
        }

        private void btnRemarks_Click(object sender, EventArgs e)
        {
            if (dgvAircraft.SelectedRows.Count > 0)
            {
                using (EnterTextForm selectForm = new EnterTextForm())
                {
                    List<Aircraft> aircraft = new List<Aircraft>();

                    foreach (DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        if (row.DataBoundItem != null)
                        {
                            aircraft.Add((Aircraft)row.DataBoundItem);
                        }
                    }

                    if (aircraft.Any())
                    {
                        selectForm.Question = "Aircraft remarks";
                        selectForm.Response = aircraft.First().Remarks;
                        if (selectForm.ShowDialog() == DialogResult.OK)
                        {


                            foreach (Aircraft a in aircraft)
                            {
                                a.Remarks = selectForm.Response;
                                Program.incidentDataService.UpsertAircraft(a);
                            }
                        }
                    }
                }



            }
        }
    }
}

