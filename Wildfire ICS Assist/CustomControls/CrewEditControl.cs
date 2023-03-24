using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.OptionsForms;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class CrewEditControl : UserControl
    {
        private OperationalSubGroup _subGroup = new OperationalSubGroup();
        public OperationalSubGroup subGroup { get { return _subGroup; } }
        public void SetSubGroup(OperationalSubGroup sub, List<IncidentResource> res) { _subGroup = sub; resources = res; loadSubGroup(); }

        private List<IncidentResource> _resources = new List<IncidentResource>();
        public List<IncidentResource> resources { get => _resources; private set => _resources = value; }

        private List<OperationalGroupResourceListing> _resourcesToRemoveFromCrew = new List<OperationalGroupResourceListing>();
        public List<OperationalGroupResourceListing> resourcesToRemoveFromCrew { get => _resourcesToRemoveFromCrew; }
        public bool EditExisting { get; set; }

        public CrewEditControl()
        {
            InitializeComponent();
            cboCrewType.SelectedIndex = 0;
        }

        private void CrewEditControl_Load(object sender, EventArgs e)
        {

        }

        private void loadSubGroup()
        {
            if (subGroup != null)
            {
                txtEmail.Text = subGroup.Email;
                txtPhone.Text = subGroup.Phone;
                txtName.Text = subGroup.ResourceName;
                txtTransport.Text = subGroup.Transport;
                rbCrew.Checked = !subGroup.IsEquipmentCrew;
                rbHECrew.Checked = subGroup.IsEquipmentCrew;
                if (!string.IsNullOrEmpty(subGroup.Type)) { cboCrewType.Text = subGroup.Type; }
                else { cboCrewType.SelectedIndex = 0; }
                loadResourceList();
            } else
            {
               
            }
        }

        private void loadResourceList()
        {
            if (_subGroup != null)
            {
                dgvGroup.DataSource = null;
                dgvGroup.AutoGenerateColumns = false;
                List<OperationalGroupResourceListing> listings = _subGroup.ActiveResourceListing;
                dgvGroup.DataSource = listings.OrderByDescending(o=>o.IsLeader).ThenBy(o=>o.ResourceName).ToList();
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            using (CheckInEnterPersonForm entryForm = new CheckInEnterPersonForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    resources.Add(entryForm.selectedPerson);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    listing.SubGroupID = subGroup.ID;
                    listing.OperationalGroupID = subGroup.OperationalGroupID;
                    listing.Kind = entryForm.selectedPerson.Kind;
                    listing.Type = entryForm.selectedPerson.Type;

                    listing.ResourceID = entryForm.selectedPerson.PersonID;
                    listing.ResourceType = "Personnel";
                    listing.ResourceName = entryForm.selectedPerson.Name;
                    subGroup.UpsertResourceListing(listing);

                    loadResourceList();
                }
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
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
                    resources.Add(entryForm.CurrentVehicle);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    listing.SubGroupID = subGroup.ID;
                    listing.OperationalGroupID = subGroup.OperationalGroupID;
                    listing.Kind = entryForm.CurrentVehicle.Kind;
                    listing.Type = entryForm.CurrentVehicle.Type;

                    listing.ResourceID = entryForm.CurrentVehicle.ID;
                    if (entryForm.CurrentVehicle.IsEquipment) { listing.ResourceType = "Equipment"; }
                    else { listing.ResourceType = "Vehicle"; }
                    listing.ResourceName = entryForm.CurrentVehicle.ResourceName;
                    //subGroup.ResourceListing.Add(listing);
                    subGroup.UpsertResourceListing(listing);
                    loadResourceList();
                }
            }
        }

        private void OpenPersonForEdit(Personnel person)
        {
            using (EditSavedTeamMemberForm entryForm = new EditSavedTeamMemberForm())
            {
                entryForm.selectedMember = person;
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _resources = _resources.Where(o => o.ID != person.ID).ToList();
                    resources.Add(entryForm.selectedMember);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    if(subGroup.ResourceListing.Any(o=>o.ResourceID == entryForm.selectedMember.ID)) { listing = subGroup.ResourceListing.First(o => o.ResourceID == entryForm.selectedMember.ID); }
                    listing.SubGroupID = subGroup.ID;
                    listing.OperationalGroupID = subGroup.OperationalGroupID;
                    listing.Kind = entryForm.selectedMember.Kind;
                    listing.Type = entryForm.selectedMember.Type;

                    listing.ResourceID = entryForm.selectedMember.PersonID;
                    listing.ResourceType = "Personnel";
                    listing.ResourceName = entryForm.selectedMember.Name;
                    subGroup.UpsertResourceListing(listing);

                    loadResourceList();
                }
            }
        }

        private void OpenVehicleForEdit(Vehicle v)
        {
            using (EditSavedVehicleForm entryForm = new EditSavedVehicleForm())
            {
                entryForm.vehicle = v;
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _resources = _resources.Where(o => o.ID != v.ID).ToList();
                    resources.Add(entryForm.vehicle);

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    if (subGroup.ResourceListing.Any(o => o.ResourceID == entryForm.vehicle.ID)) { listing = subGroup.ResourceListing.First(o => o.ResourceID == entryForm.vehicle.ID); }
                    listing.SubGroupID = subGroup.ID;
                    listing.OperationalGroupID = subGroup.OperationalGroupID;
                    listing.Kind = entryForm.vehicle.Kind;
                    listing.Type = entryForm.vehicle.Type;

                    listing.ResourceID = entryForm.vehicle.ID;
                    if (entryForm.vehicle.IsEquipment) { listing.ResourceType = "Equipment"; }
                    else { listing.ResourceType = "Vehicle"; }
                    listing.ResourceName = entryForm.vehicle.ResourceName;
                    subGroup.UpsertResourceListing(listing);

                    loadResourceList();
                }
            }
        }

        private void btnDeleteResource_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalGroupResourceListing> toDelete = new List<OperationalGroupResourceListing>();
                foreach (DataGridViewRow row in dgvGroup.SelectedRows)
                {
                    toDelete.Add(row.DataBoundItem as OperationalGroupResourceListing);
                }
                foreach (OperationalGroupResourceListing item in toDelete)
                {
                    item.Active = false;
                }
                loadResourceList();
            }
        }

        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteResource.Enabled = dgvGroup.SelectedRows.Count > 0;
            btnRemoveFromCrew.Enabled = dgvGroup.SelectedRows.Count > 0;
            if (!EditExisting) { btnRemoveFromCrew.Enabled = false; }
            btnEditSelected.Enabled = dgvGroup.SelectedRows.Count == 1;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; }
            else { txtName.BackColor = Program.GoodColor; }
            subGroup.ResourceName = txtName.Text;
        }

        public bool FormIsComplete
        {
            get
            {
                if (string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; }
                else { txtName.BackColor = Program.GoodColor; }
                return !string.IsNullOrEmpty(txtName.Text);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            subGroup.Email = txtEmail.Text;
        }

        private void txtTransport_TextChanged(object sender, EventArgs e)
        {
            subGroup.Transport = txtTransport.Text;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            subGroup.Phone = txtPhone.Text;
        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            OperationalGroupResourceListing listing = (OperationalGroupResourceListing)dgvGroup.SelectedRows[0].DataBoundItem;
            if (listing.ResourceType.Equals("Personnel"))
            {
                if (resources.Any(o => o.ID == listing.ResourceID))
                {
                    Personnel p = resources.First(o => o.ID == listing.ResourceID) as Personnel;
                    OpenPersonForEdit(p);
                }
            }
            else if (listing.ResourceType.Equals("Vehicle"))
            {
                if (resources.Any(o => o.ID == listing.ResourceID))
                {
                    Vehicle p = resources.First(o => o.ID == listing.ResourceID) as Vehicle;
                    OpenVehicleForEdit(p);
                }
            }
            else if (listing.ResourceType.Equals("Equipment"))
            {
                if (resources.Any(o => o.ID == listing.ResourceID))
                {
                    Vehicle p = resources.First(o => o.ID == listing.ResourceID) as Vehicle;
                    OpenVehicleForEdit(p);
                }
            }
        }

        private void btnRemoveFromCrew_Click(object sender, EventArgs e)
        {
            if(dgvGroup.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureRemoveFromCrew, Properties.Resources.AreYouSureTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalGroupResourceListing> toRemove = new List<OperationalGroupResourceListing>();
                foreach(DataGridViewRow row in dgvGroup.SelectedRows)
                {
                    toRemove.Add(row.DataBoundItem as OperationalGroupResourceListing);
                }
                resourcesToRemoveFromCrew.AddRange(toRemove);
                subGroup.ResourceListing = subGroup.ResourceListing.Where(o => !toRemove.Any(r => r.ID == o.ID)).ToList();
                loadResourceList();



            }
        }

        private void cboCrewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            subGroup.Type = cboCrewType.Text;
        }

        private void rbCrew_CheckedChanged(object sender, EventArgs e)
        {
            btnAddVehicle.Enabled = !rbCrew.Checked;
            subGroup.IsEquipmentCrew = !rbCrew.Checked;
        }

        private void rbHECrew_CheckedChanged(object sender, EventArgs e)
        {
            if(!rbHECrew.Checked && subGroup.ActiveResourceListing.Any(o => o.ResourceType.Equals("Equipment") || o.ResourceType.Equals("Vehicle")))
            {
                rbHECrew.Checked = true;
                lblOnlyHECrews.Visible = true;
            }
        }
    }
}
