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


        private Coordinate[] enteredPolygonCoordinates = new Coordinate[4]; //NW, NE, SE, SW
        private Coordinate enteredRadiusCoordinate = null;


        public AirNOTAMEditForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void loadNOTAM()
        {
            lblNWCoordinateOK.Text = ""; lblNECoordinateOK.Text = ""; lblSECoordinateOK.Text = ""; lblSWCoordinateOK.Text = "";
            lblCoordinateStatus.Text = "";

            numAltitude.Value = selectedNOTAM.AltitudeASL;
            txtCenterPoint.Text = selectedNOTAM.CenterPoint;

            if (selectedNOTAM.UseRadius)
            {
                rbRadius.Checked = true;
                numRadius.Value = selectedNOTAM.RadiusNM;
                if (selectedNOTAM.RadiusCentre != null)
                {
                    rbRadius.Checked = true;
                    Coordinate coord = selectedNOTAM.RadiusCentre;

                    if (coord.Latitude != 0 || coord.Longitude != 0)
                    {
                        txtRadiusCoordinates.Text = coord.CoordinateOutput("Degrees Decimal Minutes");
                        lblCoordinateStatus.Text = "Coordinate OK";
                        lblCoordinateStatus.ForeColor = label1.ForeColor;
                    }
                    else { txtRadiusCoordinates.Text = string.Empty; lblCoordinateStatus.Text = ""; }
                }
                else { txtRadiusCoordinates.Text = string.Empty; lblCoordinateStatus.Text = ""; }
            }
            else
            {
                rbPoygon.Checked = true;

                if (selectedNOTAM.PolygonNW != null)
                {
                    txtPolygonNW.Text = selectedNOTAM.PolygonNW.CoordinateOutput("Degrees Decimal Minutes");
                    lblNWCoordinateOK.Text = "Coordinate OK";
                    lblNWCoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonNW.Text = string.Empty; lblNWCoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonNE != null)
                {
                    txtPolygonNE.Text = selectedNOTAM.PolygonNE.CoordinateOutput("Degrees Decimal Minutes");
                    lblNECoordinateOK.Text = "Coordinate OK";
                    lblNECoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonNE.Text = string.Empty; lblNECoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonSE != null)
                {
                    txtPolygonSE.Text = selectedNOTAM.PolygonSE.CoordinateOutput("Degrees Decimal Minutes");
                    lblSECoordinateOK.Text = "Coordinate OK";
                    lblSECoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonSE.Text = string.Empty; lblSECoordinateOK.Text = ""; }

                if (selectedNOTAM.PolygonSW != null)
                {
                    txtPolygonSW.Text = selectedNOTAM.PolygonSW.CoordinateOutput("Degrees Decimal Minutes");
                    lblSWCoordinateOK.Text = "Coordinate OK";
                    lblSWCoordinateOK.ForeColor = label1.ForeColor;
                }
                else { txtPolygonSW.Text = string.Empty; lblSWCoordinateOK.Text = ""; }

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AirNOTAMEditForm_Load(object sender, EventArgs e)
        {
            if (selectedNOTAM.UseRadius) { numRadius.Focus(); }
        }

        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates(txtRadiusCoordinates, lblCoordinateStatus);
            if(temp != null)
            {
                enteredRadiusCoordinate = temp;
            }
            else { enteredRadiusCoordinate = null; }
        }

        private Coordinate CheckCoordinates(TextBox txtCoordinates, Label lblResultMessage)
        {
            Coordinate temp = new Coordinate();
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
                {
                    lblResultMessage.Text = "Coordinate OK";
                    lblResultMessage.ForeColor = label1.ForeColor;
                    txtCoordinates.BackColor = Program.GoodColor;
                }
                else
                {
                    lblResultMessage.Text = "Coordinate Error!";
                    lblResultMessage.ForeColor = Color.Red;
                    txtCoordinates.BackColor = Program.ErrorColor;
                }
            }
            else
            {
                lblResultMessage.Text = "";
                lblResultMessage.ForeColor = Color.Red;
                txtCoordinates.BackColor = txtCenterPoint.BackColor;
            }
            return temp;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!coordinatesAreGoodOrBlank)
            {
                MessageBox.Show(Properties.Resources.ValidCoordinatesRequired);
            }
            else
            {
                selectedNOTAM.UseRadius = rbRadius.Checked;
                if (selectedNOTAM.UseRadius)
                {
                    selectedNOTAM.RadiusNM = numRadius.Value;
                    selectedNOTAM.RadiusCentre = enteredRadiusCoordinate;
                    selectedNOTAM.PolygonNW = null;
                    selectedNOTAM.PolygonNE = null;
                    selectedNOTAM.PolygonSE = null;
                    selectedNOTAM.PolygonSW = null;

                }
                else
                {
                    selectedNOTAM.RadiusNM = 0;
                    selectedNOTAM.RadiusCentre = null;
                    selectedNOTAM.PolygonNW = enteredPolygonCoordinates[0];
                    selectedNOTAM.PolygonNE = enteredPolygonCoordinates[1];
                    selectedNOTAM.PolygonSE = enteredPolygonCoordinates[2];
                    selectedNOTAM.PolygonSW = enteredPolygonCoordinates[3];
                }


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool coordinatesAreGoodOrBlank
        {
            get
            {
                if (rbRadius.Checked)
                {
                    if (string.IsNullOrEmpty(txtRadiusCoordinates.Text)) { return true; }
                    Coordinate temp = new Coordinate();
                    return temp.TryParseCoordinate(txtRadiusCoordinates.Text, out temp);
                }
                else
                {
                    Coordinate temp = new Coordinate();
                    if (!string.IsNullOrEmpty(txtPolygonNW.Text) && !temp.TryParseCoordinate(txtPolygonNW.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonNE.Text) && !temp.TryParseCoordinate(txtPolygonNE.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonSE.Text) && !temp.TryParseCoordinate(txtPolygonSE.Text, out temp)) { return false; }
                    if (!string.IsNullOrEmpty(txtPolygonSW.Text) && !temp.TryParseCoordinate(txtPolygonSW.Text, out temp)) { return false; }

                    return true;
                }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rbRadius_CheckedChanged(object sender, EventArgs e)
        {
            if(rbRadius.Checked)
            {
                pnlRadius.BackColor = Color.White;
                rbPoygon.Checked = false;
            } else
            {
                pnlRadius.BackColor = Program.FormAccent;
                

            }
        }

        private void rbPoygon_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPoygon.Checked)
            {
                pnlPolygon.BackColor = Color.White;
                rbRadius.Checked = false;
            }
            else
            {
                pnlPolygon.BackColor = Program.FormAccent;


            }
        }

        private void pnlRadius_Enter(object sender, EventArgs e)
        {
            rbRadius.Checked = true;
        }

        private void pnlPolygon_Enter(object sender, EventArgs e)
        {
            rbPoygon.Checked = true;
        }


        //NW, NE, SE, SW

        private void txtPolygonNW_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblNWCoordinateOK);
            if (temp != null)
            {
                enteredPolygonCoordinates[0] = temp;
            }
            else { enteredPolygonCoordinates[0] = null; }
        }

        private void txtPolygonNE_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblNECoordinateOK);
            if (temp != null)
            {
                enteredPolygonCoordinates[1] = temp;
            }
            else { enteredPolygonCoordinates[1] = null; }
        }

        private void txtPolygonSW_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblSWCoordinateOK);
            if (temp != null)
            {
                enteredPolygonCoordinates[3] = temp;
            }
            else { enteredPolygonCoordinates[3] = null; }
        }

        private void txtPolygonSE_Leave(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblSECoordinateOK);
            if (temp != null)
            {
                enteredPolygonCoordinates[2] = temp;
            }
            else { enteredPolygonCoordinates[2] = null; }
        }
    }
}
