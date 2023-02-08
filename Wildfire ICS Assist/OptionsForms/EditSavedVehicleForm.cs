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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditSavedVehicleForm : Form
    {

        private Vehicle _vehicle = null;
        public Vehicle vehicle { get => _vehicle; set { _vehicle= value; displayVehicle(); } }
        public EditSavedVehicleForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void displayVehicle()
        {
            txtOrderRequestNo.Text = vehicle.OrderRequestNo;
            txtIncidentIDNo.Text = vehicle.IncidentIDNo;
            txtClassification.Text = vehicle.Classification;
            txtMake.Text = vehicle.Make;
            txtCategoryKindCapacity.Text = vehicle.CategoryKindCapacity;
            txtFeatures.Text = vehicle.Features;
            txtAgencyOrOwner.Text = vehicle.AgencyOrOwner;
            txtOperatorName.Text = vehicle.OperatorName;
            txtLicenseOrID.Text = vehicle.LicenseOrID;
            txtNotes.Text = vehicle.Notes;
            
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
                MessageBox.Show("You must include the Callsign / Incident ID No. so this vehicle or equipment can be identified later.");
            }
        }

        private bool validateVehicle()
        {
            if (string.IsNullOrEmpty(txtIncidentIDNo.Text))
            {
                lblCallsign.ForeColor = Color.Red;
                txtIncidentIDNo.BackColor = Program.ErrorColor;


            }
            else { txtIncidentIDNo.BackColor = Color.LightGreen; lblCallsign.ForeColor = SystemColors.ControlText; }
            return !string.IsNullOrEmpty(txtIncidentIDNo.Text);
        }

        private void txtOrderRequestNo_TextChanged(object sender, EventArgs e)
        {
            vehicle.OrderRequestNo = ((TextBox)sender).Text;
        }

        private void txtIncidentIDNo_TextChanged(object sender, EventArgs e)
        {
            vehicle.IncidentIDNo = ((TextBox)sender).Text;
        }

        private void txtClassification_TextChanged(object sender, EventArgs e)
        {
            vehicle.Classification = ((TextBox)sender).Text;
        }

        private void txtMake_TextChanged(object sender, EventArgs e)
        {
            vehicle.Make = ((TextBox)sender).Text;
        }

        private void txtCategoryKindCapacity_TextChanged(object sender, EventArgs e)
        {
            vehicle.CategoryKindCapacity = ((TextBox)sender).Text;
        }

        private void txtFeatures_TextChanged(object sender, EventArgs e)
        {
            vehicle.Features = ((TextBox)sender).Text;
        }

        private void txtAgencyOrOwner_TextChanged(object sender, EventArgs e)
        {
            vehicle.AgencyOrOwner = ((TextBox)sender).Text;
        }

        private void txtOperatorName_TextChanged(object sender, EventArgs e)
        {
            vehicle.OperatorName = ((TextBox)sender).Text;
        }

        private void txtLicenseOrID_TextChanged(object sender, EventArgs e)
        {
            vehicle.LicenseOrID = ((TextBox)sender).Text;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            vehicle.Notes = ((TextBox)sender).Text;
        }

        private void EditSavedVehicleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
