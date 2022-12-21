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
    public partial class EditHosptalForm : Form
    {
        private Hospital _selectedHospital = null;

        public Hospital selectedHospital { get => _selectedHospital; set { _selectedHospital = value; displayHospital(); } }
        public bool ShowTravelTimes { get => grpTravelTime.Visible; set => grpTravelTime.Visible = value; }

        public EditHosptalForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void EditHosptalForm_Load(object sender, EventArgs e)
        {

        }

        private void displayHospital()
        {
            txtHospitalName.Text = selectedHospital.name;
            txtAddress.Text = selectedHospital.location;
            txtPhone.Text = selectedHospital.phone;
            chkBurnUnit.Checked = selectedHospital.burnUnit;
            chkHelipad.Checked = selectedHospital.helipad;
            lblCoordinateStatus.Text = string.Empty;

            StringBuilder coordText = new StringBuilder();

            Coordinate coord = new Coordinate();
            coord.Latitude = selectedHospital.Latitude;
            coord.Longitude = selectedHospital.Longitude;
            if (coord.Latitude != 0 || coord.Longitude != 0) { txtLatitude.Text = coord.CoordinateOutput(Program.generalOptionsService.GetOptionsValue("CoordinateFormat").ToString()); } 
            else { txtLatitude.Text = string.Empty; }

            numTravelAir.Value = selectedHospital.travelTimeAir;
            numTravelGround.Value = selectedHospital.travelTimeGround;

        }

        private void txtLatitude_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (temp.TryParseCoordinate(txtLatitude.Text, out temp))
            {
                lblCoordinateStatus.Text = "Coordinate OK";
                lblCoordinateStatus.ForeColor = label1.ForeColor;
                selectedHospital.Latitude = temp.Latitude;
                selectedHospital.Longitude = temp.Longitude;
            }
            else
            {
                lblCoordinateStatus.Text = "Coordinate Error!";
                lblCoordinateStatus.ForeColor = Color.Red;
            }
        }

        private void txtHospitalName_TextChanged(object sender, EventArgs e)
        {
            selectedHospital.name = ((TextBox)sender).Text;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            selectedHospital.location = ((TextBox)sender).Text;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            selectedHospital.phone = ((TextBox)sender).Text;
        }

        private void chkHelipad_CheckedChanged(object sender, EventArgs e)
        {
            selectedHospital.helipad = ((CheckBox)sender).Checked;
        }

        private void chkBurnUnit_CheckedChanged(object sender, EventArgs e)
        {
            selectedHospital.burnUnit = ((CheckBox)sender).Checked;
        }

        private void numTravelAir_ValueChanged(object sender, EventArgs e)
        {
            selectedHospital.travelTimeAir = ((NumericUpDown)sender).Value;
        }

        private void numTravelGround_ValueChanged(object sender, EventArgs e)
        {
            selectedHospital.travelTimeGround = ((NumericUpDown)sender).Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
