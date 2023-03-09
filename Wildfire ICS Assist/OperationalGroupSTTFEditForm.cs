using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.Properties;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupSTTFEditForm : Form
    {
        private OperationalGroup _SelectedGroup = new OperationalGroup();
        public OperationalGroup SelectedGroup { get => _SelectedGroup; set { _SelectedGroup = value; } }
        private List<IncidentResource> _resourcesToBeAdded = new List<IncidentResource>();
        public List<IncidentResource> resourcesToBeAdded { get => _resourcesToBeAdded; set => _resourcesToBeAdded = value; }

        public OperationalGroupSTTFEditForm()
        {
            this.Icon = Program.programIcon; InitializeComponent(); this.BackColor = Program.FormBackground;
            dgvSubGroups.AutoGenerateColumns = false; dgvSubGroups.BackgroundColor = Program.FormAccent;
        }

        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            if(e.item.OperationalGroupID == SelectedGroup.ID)
            {
                PopulateReportingResources();
            }
        }

        private void OperationalGroupSTTFEditForm_Load(object sender, EventArgs e)
        {
            PopulateReportsTo();
            PopulateLeader();
            LoadGroup();
            Program.wfIncidentService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
        }

        private void LoadGroup()
        {
            if (this.SelectedGroup != null)
            {
                cboType.SelectedIndex = cboType.FindStringExact(SelectedGroup.GroupType);
                txtComments.Text = SelectedGroup.Comments;
                txtContact.Text = SelectedGroup.Contact;
                txtIdentifier.Text = SelectedGroup.ResourceIdentifier;

                try { cboReportsTo.SelectedValue = SelectedGroup.ParentID; }
                catch { }
                try { cboSupervisor.SelectedValue = SelectedGroup.LeaderID; }
                catch { }
                PopulateReportingResources();
            }
        }

        private void PopulateReportingResources()
        {
            dgvSubGroups.DataSource = null;
            dgvSubGroups.AutoGenerateColumns = false;
            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(SelectedGroup.ActiveResourceListing);
            foreach(IncidentResource resource in Program.CurrentIncident.GetReportingResources(SelectedGroup.ID).Where(o => o.Active))
            {
                if (!resources.Any(o => o.ID == resource.ID)) { resources.Add(resource); }
            }
            dgvSubGroups.DataSource = resources.OrderBy(o=>o.ResourceName).ToList();
        }

        private void PopulateReportsTo()
        {
            List<ICSRole> OpsRoles = new List<ICSRole>();

            OpsRoles.Clear();

            OpsRoles.Add(Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == WF_ICS_ClassLibrary.Globals.OpsChiefID && o.IsOpGroupSup));
            OpsRoles.AddRange(Program.CurrentOrgChart.GetChildRoles(Globals.OpsChiefID, true, true));
            OpsRoles = OpsRoles.Where(o=>o.IsOpGroupSup && !o.IsTFST).ToList();
            cboReportsTo.DataSource = OpsRoles;
            cboReportsTo.DisplayMember = "RoleNameForDropdown";
            cboReportsTo.ValueMember = "RoleID";
        }

        private void PopulateLeader()
        {
            List<Personnel> members = Program.CurrentIncident.IncidentPersonnel.OrderBy(o => o.Name).ToList();
            Personnel blank = new Personnel(); blank.PersonID = Guid.Empty; members.Insert(0, blank);

            List<Personnel> mems = new List<Personnel>();
            mems.AddRange(members);
            cboSupervisor.DataSource = mems;
            cboSupervisor.ValueMember = "PersonID";
            cboSupervisor.DisplayMember = "Name";
        }

        private void cboReportsTo_Leave(object sender, EventArgs e)
        {
            if(cboReportsTo.SelectedItem == null) { cboReportsTo.Text = ""; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsComplete())
            {
                SaveFormValuesToSelected();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveFormValuesToSelected()
        {
            SelectedGroup.ResourceIdentifier = txtIdentifier.Text;
            SelectedGroup.Name = txtIdentifier.Text;
            SelectedGroup.Contact = txtContact.Text;
            SelectedGroup.GroupType = cboType.Text;
            SelectedGroup.Comments = txtComments.Text;

            if (cboSupervisor.SelectedItem != null)
            {
                Personnel sup = (Personnel)cboSupervisor.SelectedItem;
                SelectedGroup.LeaderName = sup.Name;
                SelectedGroup.LeaderID = sup.PersonID;
            }
            else
            {
                SelectedGroup.LeaderName = string.Empty;
                SelectedGroup.LeaderID = Guid.Empty;
            }

            if (cboReportsTo.SelectedItem != null)
            {
                ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem;

                SelectedGroup.ParentID = reportsTo.RoleID;
                if (reportsTo.OperationalGroupID != Guid.Empty && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.ID == reportsTo.OperationalGroupID))
                {
                    OperationalGroup gr = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.ID == reportsTo.OperationalGroupID);
                    SelectedGroup.ParentName = gr.ResourceName;
                }
                else { SelectedGroup.ParentName = reportsTo.RoleName; }

            }
        }

        private bool IsComplete()
        {
            if (string.IsNullOrEmpty(txtIdentifier.Text.Trim())) { txtIdentifier.BackColor = Program.ErrorColor; return false; }
            else { txtIdentifier.BackColor = Program.GoodColor; }
            return true;
        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            OperationalSubGroup sub = new OperationalSubGroup();
            sub.OperationalGroupID = SelectedGroup.ID;
            OpenResourceForEdit(sub);
        }

        private void OpenResourceForEdit(OperationalSubGroup sub)
        {
            if (sub != null)
            {
                using (OperationalGroupEditResourceForm form = new OperationalGroupEditResourceForm())
                {
                    form.subGroup = sub;

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OperationalSubGroup grp = form.subGroup;
                        Program.wfIncidentService.UpsertOperationalSubGroup(grp);
                    }
                }
            }
        }

        private void dgvSubGroups_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteResource.Enabled = dgvSubGroups.SelectedRows.Count > 0;
            btnEditResource.Enabled = dgvSubGroups.SelectedRows.Count == 1;
        }

        private void btnEditResource_Click(object sender, EventArgs e)
        {
            if (dgvSubGroups.SelectedRows.Count == 1)
            {
                OperationalSubGroup sub = dgvSubGroups.SelectedRows[0].DataBoundItem as OperationalSubGroup;
                OpenResourceForEdit(sub);
            }
        }

        private void btnDeleteResource_Click(object sender, EventArgs e)
        {
            if(dgvSubGroups.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalSubGroup> toDelete = new List<OperationalSubGroup>();
                foreach(DataGridViewRow row in dgvSubGroups.SelectedRows)
                {
                    toDelete.Add(row.DataBoundItem as OperationalSubGroup);
                }
                foreach (OperationalSubGroup sub in toDelete) { sub.Active = false; Program.wfIncidentService.UpsertOperationalSubGroup(sub); }
            }
        }

        private void btnAddSingle_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsAddSingle.Show(ptLowerLeft);
        }

        private void btnAddCrew_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsAddCrew.Show(ptLowerLeft);
        }

        private void createNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CheckInEnterPersonForm entryForm = new CheckInEnterPersonForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    
                    resourcesToBeAdded.Add(entryForm.selectedPerson);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    listing.OperationalGroupID = SelectedGroup.ID;
                    listing.Kind = entryForm.selectedPerson.Kind;
                    listing.Type = entryForm.selectedPerson.Type;

                    listing.ResourceID = entryForm.selectedPerson.PersonID;
                    listing.ResourceType = "Personnel";
                    listing.ResourceName = entryForm.selectedPerson.Name;
                    listing.Contact = entryForm.selectedPerson.Contact;
                    listing.LeaderName = entryForm.selectedPerson.Name;
                    SelectedGroup.ResourceListing.Add(listing);
                   
                    PopulateReportingResources();

                }
            }
        }

        private void createNewEquipmentVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehicle vehicleToEdit = new Vehicle();
            vehicleToEdit.TaskID = Program.CurrentTask.TaskID;
            vehicleToEdit.OpPeriod = Program.CurrentOpPeriod;
            vehicleToEdit.StartTime = DateTime.Now;

            using (VehicleEditForm entryForm = new VehicleEditForm(vehicleToEdit, false))
            {

                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    resourcesToBeAdded.Add(entryForm.CurrentVehicle);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    listing.OperationalGroupID = SelectedGroup.ID;
                    listing.Kind = entryForm.CurrentVehicle.Kind;
                    listing.Type = entryForm.CurrentVehicle.Type;

                    listing.ResourceID = entryForm.CurrentVehicle.ID;
                    listing.ResourceType = "Vehicle/Equipment";
                    listing.ResourceName = entryForm.CurrentVehicle.ResourceName;
                    listing.Contact = entryForm.CurrentVehicle.Contact;
                    SelectedGroup.ResourceListing.Add(listing);
                    PopulateReportingResources();
                }
            }
        }

        private void dgvSubGroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSubGroups.Rows.Count > 0 && e.RowIndex <= dgvSubGroups.Rows.Count && dgvSubGroups.Rows[e.RowIndex] != null)
            {


                DataGridViewRow row = dgvSubGroups.Rows[e.RowIndex];
                if (e.RowIndex >= 7)
                {
                    row.Cells["colNumber"].Style.BackColor = Program.ErrorColor;
                }
                else
                {
                    row.Cells["colNumber"].Style.BackColor = Program.GoodColor;
                }
            }
        }

        private void dgvSubGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvSubGroups.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }
    }
}
