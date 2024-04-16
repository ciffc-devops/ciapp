using NetworkCommsDotNet;
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
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class VehicleEditForm : BaseForm
    {
        private Vehicle _currentVehicle = new Vehicle();
        private bool _EditingSavedVehicle;
        public Vehicle CurrentVehicle { get => _currentVehicle; private set => _currentVehicle = value; }
        bool EditingSavedVehicle { get => _EditingSavedVehicle;  set => _EditingSavedVehicle = value; }
        public bool SaveForLater { get => chkSaveForLater.Checked; }

        public VehicleEditForm(Vehicle vehicle_to_edit, bool editExisting = false)
        {
            InitializeComponent(); 
            GeneralTools.SetDateFormat(this);
            CurrentVehicle = vehicle_to_edit;
            EditingSavedVehicle = editExisting;
            if (EditingSavedVehicle) { SetForEdit(); }
            else { SetForNewEntry(); }
        }

        private void SetForNewEntry()
        {
            
            btnAddNew.Visible = true;
            chkSaveForLater.Visible = true;
            btnSave.Visible = false;

        }

        private void SetForEdit()
        {
            splitContainer2.Panel1Collapsed = true;
            splitContainer2.Panel1.Hide();
            btnAddNew.Visible = false;
            chkSaveForLater.Visible = false;
            btnSave.Visible = true;
        }

        private void VehicleEditForm_Load(object sender, EventArgs e)
        {
            
            Vehicle blankVehicle = new Vehicle();
            blankVehicle.IncidentIDNo = "-Select a saved vehicle-";
            blankVehicle.ID = Guid.Empty;
            List<Vehicle> savedVehicles = new List<Vehicle>(); 
            savedVehicles.AddRange((List<Vehicle>)Program.generalOptionsService.GetOptionsValue("Vehicles"));
            savedVehicles.Insert(0, blankVehicle);

            cboSavedVehicles.DataSource = savedVehicles;

            loadVehicle();
        }

        private void loadVehicle()
        {
            vehicleEquipmentEditControl1.SetVehicle( CurrentVehicle.Clone());
        }

        private void SetVehicleFromForm()
        {
            CurrentVehicle = vehicleEquipmentEditControl1.CurrentVehicle.Clone();

        }

        private void btnUseSaved_Click(object sender, EventArgs e)
        {
            if(cboSavedVehicles.SelectedItem != null)
            {
                CurrentVehicle = ((Vehicle)cboSavedVehicles.SelectedItem).Clone();
                CurrentVehicle.OpPeriod = Program.CurrentOpPeriod;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (vehicleEquipmentEditControl1.IsComplete)
            {
                SetVehicleFromForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("You must include the Callsign / Incident ID No. so this vehicle or equipment can be identified later.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateVehicle())
            {
                SetVehicleFromForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("You must include the Callsign / Incident ID No. so this vehicle or equipment can be identified later.");
            }
        }

        private bool validateVehicle()
        {
            return vehicleEquipmentEditControl1.IsComplete;
        }

        private void txtOrderRequestNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoryKindCapacity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
