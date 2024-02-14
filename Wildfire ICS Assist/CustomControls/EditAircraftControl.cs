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
                txtBase.Text = selectedAircraft.Base;
                txtMakeModel.Text = selectedAircraft.MakeModel;
                txtRegistration.SetText(selectedAircraft.Registration);
                txtContactNumber.Text = selectedAircraft.ContactNumber;
                if (!string.IsNullOrEmpty(selectedAircraft.Remarks)) { txtRemarks.Text = selectedAircraft.Remarks.Replace("\n", Environment.NewLine); }
                if (!selectedAircraft.IsHeli) { cboIsHeli.SelectedIndex = 1; } else { cboIsHeli.SelectedIndex = 0; }
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
            return txtRegistration.IsValid;
        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            if(selectedAircraft != null) { selectedAircraft.ContactNumber = txtContactNumber.Text; }
        }

        private void txtMakeModel_TextChanged_1(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.MakeModel = txtMakeModel.Text; }

        }

        private void txtBase_TextChanged_1(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.Base = txtBase.Text; }

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
            if (selectedAircraft != null) { selectedAircraft.IsHeli = cboIsHeli.SelectedIndex == 0; }
        }

        private void txtContactNumber_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
