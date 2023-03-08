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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class CrewEditControl : UserControl
    {
        private OperationalSubGroup _subGroup = new OperationalSubGroup();
        public OperationalSubGroup subGroup { get { return _subGroup; } }
        public void SetSubGroup(OperationalSubGroup sub) { _subGroup = sub; loadSubGroup(); }
        private List<IncidentResource> _resources = new List<IncidentResource>();
        public List<IncidentResource> resources { get => _resources; }

        public CrewEditControl()
        {
            InitializeComponent();
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
                loadResourceList();
            }
        }

        private void loadResourceList()
        {
            if (_subGroup != null)
            {
                dgvGroup.DataSource = null;
                dgvGroup.AutoGenerateColumns = false;
                dgvGroup.DataSource = _subGroup.ActiveResourceListing;
            }

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            using (PersonnelEnterPersonForm entryForm = new PersonnelEnterPersonForm())
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
                    subGroup.ResourceListing.Add(listing);
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
                    listing.ResourceType = "Vehicle";
                    listing.ResourceName = entryForm.CurrentVehicle.ResourceName;
                    subGroup.ResourceListing.Add(listing);
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
    }
}
