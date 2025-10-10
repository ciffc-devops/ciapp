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
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditSavedVehicleForm : BaseForm
    {

        public Vehicle vehicle { get => vehicleEquipmentEditControl1.CurrentVehicle; set {  displayVehicle(value); } }
        public bool DisplayOperator { get => vehicleEquipmentEditControl1.EnableOperatorField; set => vehicleEquipmentEditControl1.EnableOperatorField = value; }
        public void SetPossibleOperators(List<IncidentResource> resources)
        {
            vehicleEquipmentEditControl1.SetOperatorList(resources);
        }
        public EditSavedVehicleForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void displayVehicle(Vehicle veh)
        {
            
            vehicleEquipmentEditControl1.SetVehicle(veh);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateVehicle())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                LgMessageBox.Show("You must include the Resource Name so this vehicle or equipment can be identified later.");
            }
        }

        private bool validateVehicle()
        {
            return vehicleEquipmentEditControl1.IsComplete;
        }

        private void EditSavedVehicleForm_Load(object sender, EventArgs e)
        {

        }

      
    }
}
