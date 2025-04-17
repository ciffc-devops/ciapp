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
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class CrewEditControl : UserControl
    {
        private Crew _SelectedCrew = new Crew();
        public Crew selectedCrew { get { return _SelectedCrew; } }
        public void SetCrew(Crew crew, List<IncidentResource> res) { _SelectedCrew = crew; resources = res; loadCrewDetails(); }

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
            txtName.TextChanged += TxtName_TextChanged;
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            selectedCrew.ResourceName = txtName.Text;

        }

        private void loadCrewDetails()
        {
            if (selectedCrew != null)
            {
                txtEmail.Text = selectedCrew.Email;
                txtPhone.Text = selectedCrew.Phone;
                txtName.SetText( selectedCrew.ResourceName);
                txtTransport.Text = selectedCrew.Transport;
                rbCrew.Checked = !selectedCrew.IsEquipmentCrew;
                rbHECrew.Checked = selectedCrew.IsEquipmentCrew;
                if (!string.IsNullOrEmpty(selectedCrew.Type)) { cboCrewType.Text = selectedCrew.Type; }
                else { cboCrewType.SelectedIndex = 0; }

                btnAddVehicle.Enabled = !rbCrew.Checked;
                selectedCrew.IsEquipmentCrew = !rbCrew.Checked;

                foreach(OperationalGroupResourceListing listing in selectedCrew.ActiveResourceListing)
                {
                    if (!resources.Any(o => o.ID == listing.ResourceID) && Program.CurrentIncident.AllIncidentResources.Any(o=>o.ID == listing.ResourceID))
                    {
                        resources.Add(Program.CurrentIncident.AllIncidentResources.First(o => o.ID == listing.ResourceID).Clone());
                    }
                }


                loadResourceList();
            }
            else
            {

            }
        }

        private void loadResourceList()
        {
            if (_SelectedCrew != null)
            {
                


                dgvGroup.DataSource = null;
                dgvGroup.AutoGenerateColumns = false;
                List<OperationalGroupResourceListing> listings = _SelectedCrew.ActiveResourceListing;
                dgvGroup.DataSource = listings.OrderByDescending(o => o.IsLeader).ThenBy(o => o.ResourceName).ToList();
            }

        }

        private int getNextUniqueID(IncidentResource res)
        {
            int uniqueid = Program.CurrentIncident.GetNextUniqueNum(res.ResourceType);
            while(resources.Count(o=>o.ResourceType.Equals(res.ResourceType) && o.UniqueIDNum == uniqueid && o.ID != res.ID) > 0)
            {
                uniqueid++;
            }
            return uniqueid;
        }


        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            using (CheckInEnterPersonForm entryForm = new CheckInEnterPersonForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Personnel p = entryForm.selectedPerson.Clone();
                    p.UniqueIDNum = getNextUniqueID(p); 

                    if (resources.Any(o => o.ID == p.ID))
                    {
                        LgMessageBox.Show("Sorry, this resource is already in the list.");
                    }
                    else
                    {
                        resources.Add(p);

                        OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                      
                        listing.OperationalGroupID = selectedCrew.ID;
                        listing.Kind = entryForm.selectedPerson.Kind;
                        listing.Type = entryForm.selectedPerson.Type;

                        listing.ResourceID = entryForm.selectedPerson.PersonID;
                        listing.ResourceType = "Personnel";
                        listing.ResourceName = entryForm.selectedPerson.Name;
                        listing.UniqueIDNum = p.UniqueIDNum;
                        listing.Role = "Crew Member";

                        int count = selectedCrew.ActiveResourceListing.Count(o => o.ID == listing.ID);

                        selectedCrew.UpsertResourceListing(listing);

                        loadResourceList();
                    }
                }
            }
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            Vehicle vehicleToEdit = new Vehicle();
            vehicleToEdit.TaskID = Program.CurrentTask.ID;
            vehicleToEdit.OpPeriod = Program.CurrentOpPeriod;
            vehicleToEdit.StartTime = DateTime.Now;

            using (VehicleEditForm entryForm = new VehicleEditForm(vehicleToEdit, false))
            {

                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Vehicle r = entryForm.CurrentVehicle.Clone();
                    r.UniqueIDNum = getNextUniqueID(r); 

                    if (resources.Any(o => o.ID == r.ID))
                    {
                        LgMessageBox.Show("Sorry, this resource is already in the list.");
                    }
                    else
                    {
                        resources.Add(r);

                        OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                        
                        listing.OperationalGroupID = selectedCrew.ID;
                        listing.Kind = entryForm.CurrentVehicle.Kind;
                        listing.Type = entryForm.CurrentVehicle.Type;
                        listing.UniqueIDNum = r.UniqueIDNum;

                        listing.ResourceID = entryForm.CurrentVehicle.ID;
                        if (entryForm.CurrentVehicle.IsEquipment) { listing.ResourceType = "Equipment"; }
                        else { listing.ResourceType = "Vehicle"; }
                        listing.ResourceName = entryForm.CurrentVehicle.ResourceName;
                        //subGroup.ResourceListing.Add(listing);
                        selectedCrew.UpsertResourceListing(listing);
                        loadResourceList();
                    }
                }
            }
        }

        private void OpenPersonForEdit(Personnel person)
        {
            using (EditSavedPersonnelForm entryForm = new EditSavedPersonnelForm())
            {
                entryForm.selectedMember = person;
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _resources = _resources.Where(o => o.ID != person.ID).ToList();
                    resources.Add(entryForm.selectedMember.Clone());

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    if (selectedCrew.ResourceListing.Any(o => o.ResourceID == entryForm.selectedMember.ID)) { listing = selectedCrew.ResourceListing.First(o => o.ResourceID == entryForm.selectedMember.ID); }
                    listing.OperationalGroupID = selectedCrew.ID;
                    listing.Kind = entryForm.selectedMember.Kind;
                    listing.Type = entryForm.selectedMember.Type;

                    listing.ResourceID = entryForm.selectedMember.PersonID;
                    listing.ResourceType = "Personnel";
                    listing.ResourceName = entryForm.selectedMember.Name;
                    selectedCrew.UpsertResourceListing(listing);

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
                    resources.Add(entryForm.vehicle.Clone());

                    OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                    if (selectedCrew.ResourceListing.Any(o => o.ResourceID == entryForm.vehicle.ID)) { listing = selectedCrew.ResourceListing.First(o => o.ResourceID == entryForm.vehicle.ID); }
                    
                    listing.OperationalGroupID = selectedCrew.ID;
                    listing.Kind = entryForm.vehicle.Kind;
                    listing.Type = entryForm.vehicle.Type;

                    listing.ResourceID = entryForm.vehicle.ID;
                    if (entryForm.vehicle.IsEquipment) { listing.ResourceType = "Equipment"; }
                    else { listing.ResourceType = "Vehicle"; }
                    listing.ResourceName = entryForm.vehicle.ResourceName;
                    selectedCrew.UpsertResourceListing(listing);

                    loadResourceList();
                }
            }
        }

        private void btnDeleteResource_Click(object sender, EventArgs e)
        {
            if (LgMessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            btnChangeID.Enabled = btnEditSelected.Enabled;
        }


        public bool FormIsComplete
        {
            get
            {
                return txtName.IsValid;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            selectedCrew.Email = txtEmail.Text;
        }

        private void txtTransport_TextChanged(object sender, EventArgs e)
        {
            selectedCrew.Transport = txtTransport.Text;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            selectedCrew.Phone = txtPhone.Text;
        }

        private void btnEditSelected_Click(object sender, EventArgs e)
        {
            OperationalGroupResourceListing listing = (OperationalGroupResourceListing)dgvGroup.SelectedRows[0].DataBoundItem;
            EditResource(listing);
        }

        private void EditResource(OperationalGroupResourceListing listing)
        {
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
            if (dgvGroup.SelectedRows.Count > 0 && LgMessageBox.Show(Properties.Resources.SureRemoveFromCrew, Properties.Resources.AreYouSureTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalGroupResourceListing> toRemove = new List<OperationalGroupResourceListing>();
                foreach (DataGridViewRow row in dgvGroup.SelectedRows)
                {
                    toRemove.Add(row.DataBoundItem as OperationalGroupResourceListing);
                }
                resourcesToRemoveFromCrew.AddRange(toRemove);
                selectedCrew.ResourceListing = selectedCrew.ResourceListing.Where(o => !toRemove.Any(r => r.ID == o.ID)).ToList();
                loadResourceList();



            }
        }

        private void cboCrewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCrew.Type = cboCrewType.Text;
        }

        private void rbCrew_CheckedChanged(object sender, EventArgs e)
        {
            btnAddVehicle.Enabled = !rbCrew.Checked;
            selectedCrew.IsEquipmentCrew = !rbCrew.Checked;
        }

        private void rbHECrew_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbHECrew.Checked && selectedCrew.ActiveResourceListing.Any(o => o.ResourceType.Equals("Equipment") || o.ResourceType.Equals("Vehicle")))
            {
                rbHECrew.Checked = true;
            }
        }

        private void dgvGroup_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgvGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvGroup.Columns["colLeader"].Index)
            {
                DataGridViewRow row = dgvGroup.Rows[e.RowIndex];
                
                if(row.DataBoundItem != null)
                {
                    OperationalGroupResourceListing item = (OperationalGroupResourceListing)row.DataBoundItem;
                    if (!item.ResourceType.Equals("Personnel"))
                    {
                        DataGridViewCell cell = dgvGroup.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        DataGridViewComboBoxCell chkCell = cell as DataGridViewComboBoxCell;
                        chkCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        cell.ReadOnly = true;
                    }
                }

            }
        }

        private void updateUniqueIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count == 1)
            {
                OperationalGroupResourceListing rec = (OperationalGroupResourceListing)dgvGroup.SelectedRows[0].DataBoundItem;
                UpdateUniqueID(rec);
            }
        }

        private void UpdateUniqueID(OperationalGroupResourceListing rec)
        {
            if (rec != null)
            {
                using (ResourcesEditUniqueNumberForm editForm = new ResourcesEditUniqueNumberForm())
                {
                    if (resources.Any(o => o.ID == rec.ResourceID))
                    {
                        IncidentResource resource = resources.First(o => o.ID == rec.ResourceID);
                        editForm.SetResource(resource);
                        List<int> OtherNumbersToExclude = new List<int>();
                        foreach (IncidentResource res in resources.Where(o => o.ResourceType.Equals(rec.ResourceType) && o.ID != resource.ID)) { OtherNumbersToExclude.Add(res.UniqueIDNum); }
                        editForm.OtherNumbersToExclude = OtherNumbersToExclude;

                        DialogResult dr = editForm.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            rec.UniqueIDNum = editForm.newNumber;
                            resource.UniqueIDNum = editForm.newNumber;
                            loadResourceList();

                            //Program.wfIncidentService.UpsertIncidentResource(rec.Resource);
                        }
                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvGroup.SelectedRows.Count == 1)
            {
                OperationalGroupResourceListing rec = (OperationalGroupResourceListing)dgvGroup.SelectedRows[0].DataBoundItem;
                EditResource(rec);
            }
        }

        private void btnChangeID_Click(object sender, EventArgs e)
        {
            if (dgvGroup.SelectedRows.Count == 1)
            {
                OperationalGroupResourceListing rec = (OperationalGroupResourceListing)dgvGroup.SelectedRows[0].DataBoundItem;
                UpdateUniqueID(rec);
            }
        }
    }
}
