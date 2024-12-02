using System;
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
        private OperationalGroup _selectedOpGroup = null;
        public OperationalGroup SelectedOpGroup { get => _selectedOpGroup; set { _selectedOpGroup = value; LoadOpGroup(); } }

        public bool ChangesMade { get; set; } = false;

        public void SetSelectedGroup(OperationalGroup selected_group)
        {
            SelectedOpGroup = selected_group; 
        }


        private int ReportingPersonnelCount = 0;

        public StrikeTeamTaskForceDetailsControl()
        {
            InitializeComponent();
            dgvSubGroups.AutoGenerateColumns = false; dgvSubGroups.BackgroundColor = Program.AccentColor;
            if(Program.incidentDataService != null)
            {
                Program.incidentDataService.OperationalGroupChanged += IncidentDataService_OperationalGroupChanged;
            }

        }

        private void IncidentDataService_OperationalGroupChanged(OperationalGroupEventArgs e)
        {
            if (SelectedOpGroup != null)
            {
                if (e.item.ID == SelectedOpGroup.ID || e.item.ParentID == SelectedOpGroup.ID) { LoadOpGroup(); }
            } 
        }

        private void LoadOpGroup()
        {
            if (SelectedOpGroup != null)
            {
                lblResourcesTitle.Text = "Assigned Resources";
                PopulateReportingResources();
            }
        }


        private void PopulateReportingResources()
        {
            dgvSubGroups.DataSource = null;
            dgvSubGroups.AutoGenerateColumns = false;
            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(SelectedOpGroup.ActiveResourceListing);
            foreach (IncidentResource resource in Program.CurrentIncident.GetReportingResources(SelectedOpGroup.ID).Where(o => o.Active))
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
            if (Program.incidentDataService != null) { Program.incidentDataService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged; }

        }

        private void Program_OperationalSubGroupChanged(CrewEventArgs e)
        {
            if (e.item.OperationalGroupID == SelectedOpGroup.ID)
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
                        listing.OperationalGroupID = SelectedOpGroup.ID;
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
                        else if (resource.GetType().Name.Equals(new Crew().GetType().Name)) { listing.ResourceType = "Crew"; }


                        SelectedOpGroup.ResourceListing.Add(listing);
                       
                        
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
                    if (SelectedOpGroup.ResourceListing.Any(o => o.ID == sub.ID))
                    {
                        SelectedOpGroup.ResourceListing.First(o => o.ID == sub.ID).Active = false;
                        
                    }
                }
                Program.incidentDataService.UpsertOperationalGroup(SelectedOpGroup);
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
