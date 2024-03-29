﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class StrikeTeamTaskForceDetailsControl : UserControl
    {
        private ICSRole _role = null;
        public ICSRole role { get => _role; private set { _role = value;  } }

        public bool ChangesMade { get; set; } = false;

        public void SetRole(ICSRole role_to_set)
        {
            _role = role_to_set; LoadOpGroup();
        }
        OperationalGroup _selectedGroup = new OperationalGroup();
        public OperationalGroup selectedGroup { get => _selectedGroup; private set => _selectedGroup = value; }


        private int ReportingPersonnelCount = 0;

        public StrikeTeamTaskForceDetailsControl()
        {
            InitializeComponent();
            dgvSubGroups.AutoGenerateColumns = false; dgvSubGroups.BackgroundColor = Program.FormAccent;

        }

        private void LoadOpGroup()
        {
            if (role != null)
            {
                lblResourcesTitle.Text = role.RoleName + " Resources";

                
                if (Program.CurrentIncident != null && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID))
                {
                    selectedGroup = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID);
                    lblResourcesTitle.Text = selectedGroup.ResourceName + " Resources";
                }
                PopulateReportingResources();
            }
        }


        private void PopulateReportingResources()
        {
            dgvSubGroups.DataSource = null;
            dgvSubGroups.AutoGenerateColumns = false;
            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(selectedGroup.ActiveResourceListing);
            foreach (IncidentResource resource in Program.CurrentIncident.GetReportingResources(selectedGroup.ID).Where(o => o.Active))
            {
                if (!resources.Any(o => o.ID == resource.ID)) { resources.Add(resource); }
            }
            // ReportingPersonnelCount = resources.Count(o => o.GetType().Name.Equals("Personnel") || o.GetType().Name.Equals("OperationalSubGroup"));
            ReportingPersonnelCount = resources.Count(o=>o.NumberOfPeople > 0);

            dgvSubGroups.DataSource = resources.OrderBy(o => o.ResourceName).ToList();

        }

        private void StrikeTeamTaskForceDetailsControl_Load(object sender, EventArgs e)
        {
            LoadOpGroup();
            if (Program.wfIncidentService != null) { Program.wfIncidentService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged; }

        }

        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            if (e.item.OperationalGroupID == selectedGroup.ID)
            {
                PopulateReportingResources();
            }
        }


        private void btnAddResource_Click(object sender, EventArgs e)
        {
            using (OperationalGroupAddExistingResoruce addExisting = new OperationalGroupAddExistingResoruce())
            {
                DialogResult dr = addExisting.ShowDialog();

                if(dr == DialogResult.OK)
                {
                    ChangesMade = true;
                    foreach (IncidentResource resource in addExisting.resourcesToAdd)
                    {
                        
                        
                        OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                        listing.OperationalGroupID = selectedGroup.ID;
                        listing.Kind = resource.Kind;
                        listing.Type = resource.Type;
                        listing.ResourceID = resource.ID;
                        listing.ResourceName = resource.ResourceName;
                        listing.Contact = resource.Contact;
                        listing.LeaderName = resource.LeaderName;
                        listing.NumberOfPeople = resource.NumberOfPeople;
                        listing.NumberOfVehicles = resource.NumberOfVehicles;
                        if (resource.GetType().Name.Equals("Personnel")) { listing.ResourceType = "Personnel"; }
                        else if (resource.GetType().Name.Equals("Vehicle")) {
                            if (((Vehicle)resource).IsEquipment) { listing.ResourceType = "Equipment"; }
                            else { listing.ResourceType = "Vehicle"; }
                        }
                        else if (resource.GetType().Name.Equals(new OperationalSubGroup().GetType().Name)) { listing.ResourceType = "Crew"; }


                        selectedGroup.ResourceListing.Add(listing);
                       
                        
                    }
                    PopulateReportingResources();
                }
            }
            /*
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsAddResource.Show(ptLowerLeft);
            */
        }


        private void btnDeleteResource_Click(object sender, EventArgs e)
        {
            if (dgvSubGroups.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChangesMade = true;
                List<OperationalGroupResourceListing> toDelete = new List<OperationalGroupResourceListing>();
                foreach (DataGridViewRow row in dgvSubGroups.SelectedRows)
                {
                    toDelete.Add(row.DataBoundItem as OperationalGroupResourceListing);
                }
                foreach (OperationalGroupResourceListing sub in toDelete)
                {
                    if (selectedGroup.ResourceListing.Any(o => o.ID == sub.ID))
                    {
                        selectedGroup.ResourceListing.First(o => o.ID == sub.ID).Active = false;
                        
                    }
                }
                Program.wfIncidentService.UpsertOperationalGroup(selectedGroup);
            }
        }

        private void dgvSubGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvSubGroups.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void dgvSubGroups_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteResource.Enabled = dgvSubGroups.SelectedRows.Count > 0;
        }

        private void dgvSubGroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSubGroups.Rows.Count > 0 && e.RowIndex <= dgvSubGroups.Rows.Count && dgvSubGroups.Rows[e.RowIndex] != null)
            {


                DataGridViewRow row = dgvSubGroups.Rows[e.RowIndex];
                if (ReportingPersonnelCount > 7)
                {
                    row.Cells["colNumber"].Style.BackColor = Program.ErrorColor;
                }
                else
                {
                    row.Cells["colNumber"].Style.BackColor = Program.GoodColor;
                }
            }
        }

        private void addCrewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addVehicleEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
