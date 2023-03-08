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

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupEditResourceForm : Form
    {
        private OperationalSubGroup _subGroup = new OperationalSubGroup();
        public OperationalSubGroup subGroup { get => _subGroup; set => _subGroup = value; }
        private BindingList<OperationalGroupResourceListing> _listings = new BindingList<OperationalGroupResourceListing>();


        public OperationalGroupEditResourceForm()
        {
            this.Icon = Program.programIcon; InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void OperationalGroupEditResourceForm_Load(object sender, EventArgs e)
        {
            rbPersonnel.Checked = true;
            dgvGroup.AutoGenerateColumns = false;
            dgvGroup.DataSource = _listings;
            LoadSubGroup();
        }

        private void buildResourceList()
        {
            _listings.Clear();
            foreach(OperationalGroupResourceListing l in subGroup.ResourceListing.Where(o=>o.Active).OrderByDescending(o=>o.IsLeader)) { _listings.Add(l); }
            
        }

        private void cboList_Leave(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            if (cbo.SelectedItem == null) { cbo.Text = string.Empty; }
        }

        private void rbPersonnel_CheckedChanged(object sender, EventArgs e)
        {
            BuildAddList();
           
        }

        private void LoadSubGroup()
        {
            txtName.Text = subGroup.ResourceName;
            txtTransport.Text = subGroup.Transport;
            buildResourceList();
        }

        private void BuildAddList()
        {
            cboResourceKind.Enabled = false; cboResourceKind.Text = "";
            cboResourceType.Enabled = false; cboResourceType.Text = "";
            cboResourceRole.Enabled = false; cboResourceRole.Text = "";
            cboResourceItem.DataSource = null;


            if (rbPersonnel.Checked)
            {
                List<Personnel> members = Program.CurrentIncident.IncidentPersonnel.OrderBy(o => o.Name).ToList();
                List<Personnel> mems = new List<Personnel>();
                mems.AddRange(members);
                mems = mems.Where(o => !subGroup.ResourceListing.Any(r => r.Active && r.ResourceID == o.ID)).ToList();
                cboResourceItem.DataSource = mems;
                cboResourceItem.ValueMember = "ID";
                cboResourceItem.DisplayMember = "Name";


            }
            else if (rbEquipment.Checked)
            {

                cboResourceItem.DataSource = GetVehicles();
                cboResourceItem.ValueMember = "ID";
                cboResourceItem.DisplayMember = "ResourceIdentifier";
            }
        }

        private void rbEquipment_CheckedChanged(object sender, EventArgs e)
        {
            BuildAddList();
        }

        public List<Vehicle> GetVehicles(bool includeInactive = false)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (includeInactive) { vehicles.AddRange(Program. CurrentTask.allVehicles.Where(o => o.OpPeriod == Program.CurrentOpPeriod).OrderBy(o => o.IncidentIDNo).ToList()); }
            else { vehicles.AddRange(Program.CurrentTask.allVehicles.Where(o => o.OpPeriod == Program.CurrentOpPeriod && o.Active).OrderBy(o => o.IncidentIDNo).ToList()); }
            vehicles = vehicles.Where(o => !subGroup.ResourceListing.Any(r => r.Active && r.ResourceID == o.ID)).ToList();

            return vehicles;
        }

        private void cboResourceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboResourceItem.SelectedItem != null)
            {
                if (rbPersonnel.Checked)
                {
                    cboResourceKind.Enabled = true;
                    cboResourceType.Enabled = true;
                    cboResourceRole.Enabled = true;
                }
                else
                {
                    Vehicle selected = (Vehicle)cboResourceItem.SelectedItem;
                    cboResourceKind.Enabled = false;
                    cboResourceKind.Text = selected.Kind;
                    cboResourceType.Enabled = false;
                    cboResourceType.Text = selected.Type;
                    cboResourceRole.Enabled = true;
                }
            } else { cboResourceItem.Text = ""; }
        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
            listing.SubGroupID = subGroup.ID;
            listing.OperationalGroupID = subGroup.OperationalGroupID;
            if (rbPersonnel.Checked)
            {
                Personnel personnel = (Personnel)cboResourceItem.SelectedItem;
                listing.ResourceID = personnel.PersonID;
                listing.ResourceType = "Personnel";
                listing.Role = cboResourceRole.Text;
                listing.Kind = cboResourceKind.Text;
                listing.Type = cboResourceType.Text;    
                listing.ResourceName = personnel.Name;
            }
            else
            {
                Vehicle vehicle = (Vehicle)cboResourceItem.SelectedItem;
                listing.ResourceID = vehicle.ID;
                listing.ResourceType = "Vehicle/Equipment";
                listing.Role = cboResourceRole.Text;
                listing.Kind = vehicle.Kind;
                listing.Type = vehicle.Type;
                listing.ResourceName = vehicle.ResourceIdentifier;

            }
            subGroup.ResourceListing.Add(listing);
            buildResourceList();
            BuildAddList();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsComplete())
            {
                subGroup.ResourceName = txtName.Text;
                subGroup.Transport = txtTransport.Text;

                if (subGroup.ResourceListing.Any(o => o.Active && o.Role.Equals("Leader")))
                {
                    OperationalGroupResourceListing ld = subGroup.ResourceListing.First(o => o.Active && o.Role.Equals("Leader"));
                    subGroup.LeaderID = ld.ID;
                    subGroup.LeaderName = ld.ResourceName;
                }
                else if (subGroup.ResourceListing.Any(o => o.Active && o.ResourceType.Equals("Personnel")))
                {
                    OperationalGroupResourceListing ld = subGroup.ResourceListing.First(o => o.Active && o.ResourceType.Equals("Personnel"));
                    subGroup.LeaderID = ld.ID;
                    subGroup.LeaderName = ld.ResourceName;
                }
                else { subGroup.LeaderID = Guid.Empty; subGroup.LeaderName = string.Empty; }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool IsComplete()
        {
            if (string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; return false; } else { txtName.BackColor = Program.GoodColor; }

            return true;
        }

        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteResource.Enabled = (dgvGroup.SelectedRows.Count > 0);
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
                buildResourceList();
                BuildAddList();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; } else { txtName.BackColor = Program.GoodColor; }

        }
    }
}
