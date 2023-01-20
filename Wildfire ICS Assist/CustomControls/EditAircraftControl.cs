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
        }

        private void loadAircraft()
        {
            if (selectedAircraft != null)
            {
                txtBase.Text = selectedAircraft.Base;
                txtMakeModel.Text = selectedAircraft.MakeModel;
                txtRegistration.Text = selectedAircraft.Registration;
                txtContactNumber.Text = selectedAircraft.ContactNumber;
                if (!string.IsNullOrEmpty(selectedAircraft.Remarks)) { txtRemarks.Text = selectedAircraft.Remarks.Replace("\n", Environment.NewLine); }
            }
        }

        private void txtRegistration_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null)
            {
                selectedAircraft.Registration = txtRegistration.Text;
                if (string.IsNullOrEmpty(txtRegistration.Text.Trim())) { txtRegistration.BackColor = Program.ErrorColor; }
                else { txtRegistration.BackColor = Program.GoodColor; }
            }
        }

        private void txtMakeModel_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.MakeModel = txtMakeModel.Text; }
        }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.Base = txtBase.Text; }
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            if (selectedAircraft != null) { selectedAircraft.Remarks = txtRemarks.Text; }
        }

        private bool ValidateForm()
        {
            return !string.IsNullOrEmpty(txtRegistration.Text.Trim());
        }

        private void txtContactNumber_TextChanged(object sender, EventArgs e)
        {
            if(selectedAircraft != null) { selectedAircraft.ContactNumber = txtContactNumber.Text; }
        }
    }
}
