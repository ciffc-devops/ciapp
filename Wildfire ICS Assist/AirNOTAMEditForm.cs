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

namespace Wildfire_ICS_Assist
{
    public partial class AirNOTAMEditForm : Form
    {
        private NOTAM _selectedNOTAM = null;
        public NOTAM selectedNOTAM { get => _selectedNOTAM; set { _selectedNOTAM = value;  loadNOTAM(); } }
        bool coordinatesAreGoodOrBlank = true;
        public AirNOTAMEditForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void loadNOTAM()
        {
            numRadius.Value = selectedNOTAM.RadiusNM;
            numAltitude.Value = selectedNOTAM.AltitudeASL;
            txtCenterPoint.Text = selectedNOTAM.CenterPoint;

            Coordinate coord = new Coordinate();
            coord.Latitude = selectedNOTAM.Latitude;
            coord.Longitude = selectedNOTAM.Longitude;
            if (coord.Latitude != 0 || coord.Longitude != 0)
            {
                txtCoordinates.Text = coord.CoordinateOutput("Degrees Decimal Minutes");
                lblCoordinateStatus.Text = "Coordinate OK";
                lblCoordinateStatus.ForeColor = label1.ForeColor;
            }
            else { txtCoordinates.Text = string.Empty; lblCoordinateStatus.Text = ""; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AirNOTAMEditForm_Load(object sender, EventArgs e)
        {

        }

        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
                {
                    lblCoordinateStatus.Text = "Coordinate OK";
                    lblCoordinateStatus.ForeColor = label1.ForeColor;
                    selectedNOTAM.Latitude = temp.Latitude;
                    selectedNOTAM.Longitude = temp.Longitude;
                    coordinatesAreGoodOrBlank = true;
                }
                else
                {
                    lblCoordinateStatus.Text = "Coordinate Error!";
                    lblCoordinateStatus.ForeColor = Color.Red;
                    coordinatesAreGoodOrBlank = false;
                }
            }
            else
            {
                lblCoordinateStatus.Text = "";
                lblCoordinateStatus.ForeColor = Color.Red;
                coordinatesAreGoodOrBlank = true;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!coordinatesAreGoodOrBlank)
            {
                MessageBox.Show(Properties.Resources.ValidCoordinatesRequired);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtCenterPoint_TextChanged(object sender, EventArgs e)
        {
            selectedNOTAM.CenterPoint= txtCenterPoint.Text;
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            selectedNOTAM.AltitudeASL= numAltitude.Value;
        }

        private void numRadius_ValueChanged(object sender, EventArgs e)
        {
            selectedNOTAM.RadiusNM = numRadius.Value;
        }
    }
}
