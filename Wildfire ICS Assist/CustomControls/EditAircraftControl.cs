using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class EditAircraftControl : UserControl
    {
        private Aircraft _selectedAircraft = null;
        public Aircraft selectedAircraft { get => _selectedAircraft; set { _selectedAircraft = value; loadAircraft(); } }
        public bool IsValid { get => ValidateForm(); }
        public EditAircraftControl()
        {
            InitializeComponent();
            txtRegistration.TextChanged += TxtRegistration_TextChanged;
            cboIsHeli.SelectedIndex = 0;
        }
        public void SetAircraft(Aircraft a)
        {
            selectedAircraft = a;
        }
        private void TxtRegistration_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null)
            {
                selectedAircraft.Registration = txtRegistration.Text;
            }
        }

        private void loadAircraft()
        {
            if (selectedAircraft != null)
            {
                txtRegistration.SetText(selectedAircraft.Registration);
                txtContactNumber.Text = selectedAircraft.ContactNumber;
               txtCompanyName.SetText(selectedAircraft.CompanyName);
                numBurnRate.Value = selectedAircraft.FuelBurnRate;

                if (!string.IsNullOrEmpty(selectedAircraft.Remarks)) { txtRemarks.Text = selectedAircraft.Remarks.Replace("\n", Environment.NewLine); }
                if (!selectedAircraft.IsHeli) { cboIsHeli.SelectedIndex = 5; } else { cboIsHeli.SelectedIndex = 0; }
                cboModel.SelectedIndex = -1;
                cboModel.Text = selectedAircraft.MakeModel;

            }
        }

        private void txtRegistration_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtMakeModel_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
        }

        private bool ValidateForm()
        {

            if (!txtRegistration.IsValid) { return false; }
            if (!txtCompanyName.IsValid) { return false; }
            if (string.IsNullOrEmpty(cboModel.Text)) { return false; }
            return true;

        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            if(selectedAircraft != null) { selectedAircraft.ContactNumber = txtContactNumber.Text; }
        }

        private void txtMakeModel_TextChanged_1(object sender, EventArgs e)
        {

        }

     

        private void txtContactNumber_TextChanged_1(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.ContactNumber = txtContactNumber.Text; }

        }

        private void txtRemarks_TextChanged_1(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.Remarks = txtRemarks.Text; }

        }

        private void cboIsHeli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.IsHeli = cboIsHeli.SelectedIndex <5; }
            switch (cboIsHeli.SelectedIndex)
            {
                
                case 1:
                    cboModel.DataSource = AircraftTools.GetHelicopterTypes("Light", true); break;
                case 2:
                    cboModel.DataSource = AircraftTools.GetHelicopterTypes("Intermediate", true); break;
                case 3:
                    cboModel.DataSource = AircraftTools.GetHelicopterTypes("Medium", true); break;
                case 4:
                    cboModel.DataSource = AircraftTools.GetHelicopterTypes("Heavy", true); break;
                case 5:
                    cboModel.DataSource = AircraftTools.GetFixedWingTypes(true); break;
                default:
                    cboModel.DataSource = AircraftTools.GetHelicopterTypes(true); break;
            }
            cboModel.SelectedIndex = -1;
        }

        private void txtContactNumber_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null)
            {
                selectedAircraft.CompanyName = txtCompanyName.Text;
            }
        }

        private void txtRegistration_TextChanged_1(object sender, EventArgs e)
        {
            if (selectedAircraft != null)
            {
                selectedAircraft.Registration = txtRegistration.Text;
            }
        }

        private void cboModel_Leave(object sender, EventArgs e)
        {
            if (selectedAircraft != null)
            {
                selectedAircraft.MakeModel = cboModel.Text;
            }

            if (string.IsNullOrEmpty(cboModel.Text)) { errorProvider1.SetError(cboModel, "You must enter or select a model for this aircraft"); }
            else { errorProvider1.SetError(cboModel, string.Empty); }
        }

        private void numBurnRate_ValueChanged(object sender, EventArgs e)
        {
            if(selectedAircraft != null) { selectedAircraft.FuelBurnRate = numBurnRate.Value; }
        }
    }
}
