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
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditMedivacForm : Form
    {
        private AmbulanceService _selectedAmbulance = null;

        public AmbulanceService selectedAmbulance { get => _selectedAmbulance; set { _selectedAmbulance = value; DisplayAmbulance(); } }

        public EditMedivacForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }


        private void DisplayAmbulance()
        {
            txtOrganization.Text = selectedAmbulance.Organization;
            txtContact.Text = selectedAmbulance.Contact;
            txtLocation.Text = selectedAmbulance.Location;
            rbALS.Checked = selectedAmbulance.IsALS;
            rbBLS.Checked = !selectedAmbulance.IsALS;
            Coordinate coord = new Coordinate();
            coord.Latitude = selectedAmbulance.Latitude;
            coord.Longitude = selectedAmbulance.Longitude;
            if (coord.Latitude != 0 || coord.Longitude != 0) { txtCoordinates.Text = coord.CoordinateOutput(Program.generalOptionsService.GetOptionsValue("CoordinateFormat").ToString()); }
            else { txtCoordinates.Text = string.Empty; }

        }
        private void rbALS_CheckedChanged(object sender, EventArgs e)
        {
            selectedAmbulance.IsALS = rbALS.Checked;
        }

        private void rbBLS_CheckedChanged(object sender, EventArgs e)
        {
            selectedAmbulance.IsBLS = rbBLS.Checked;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            selectedAmbulance.Contact = txtContact.Text;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            selectedAmbulance.Location = txtLocation.Text;
        }

        private void txtOrganization_TextChanged(object sender, EventArgs e)
        {
            selectedAmbulance.Organization= txtOrganization.Text;   
        }

        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
            {
                lblCoordinateStatus.Text = "Coordinate OK";
                lblCoordinateStatus.ForeColor = label1.ForeColor;
                selectedAmbulance.Latitude = temp.Latitude;
                selectedAmbulance.Longitude = temp.Longitude;
            }
            else
            {
                lblCoordinateStatus.Text = "Coordinate Error!";
                lblCoordinateStatus.ForeColor = Color.Red;
            }

        }

        private void EditMedivacForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            StringBuilder err = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrEmpty(selectedAmbulance.Organization)) { isValid = false; err.Append("You must include the name of the medivac service."); }

            if (!isValid) { MessageBox.Show(err.ToString()); }
            return isValid;
        }
    }
}
