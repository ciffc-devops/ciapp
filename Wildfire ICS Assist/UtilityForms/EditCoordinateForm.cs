using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class EditCoordinateForm : BaseForm
    {
        
       public Coordinate enteredCoordinate { get; private set; }
        public EditCoordinateForm(Coordinate enteredCoordinate = null)
        {
            InitializeComponent(); SetControlColors(this.Controls);
            this.enteredCoordinate = enteredCoordinate;
            if (enteredCoordinate != null)
            {
                string positionFormat = Program.generalOptionsService.GetOptionsValue("PositionFormat").ToString();
                txtCoordinate.Text = enteredCoordinate.CoordinateOutput(positionFormat);
            } else { this.enteredCoordinate = new Coordinate(); }
        }

        private void txtPolygonNW_TextChanged(object sender, EventArgs e)
        {
            Coordinate temp = CheckCoordinates((TextBox)sender, lblNWCoordinateOK);
            if (temp != null && temp.Latitude != 0 && temp.Longitude != 0)
            {
                enteredCoordinate.Latitude = temp.Latitude;
                enteredCoordinate.Longitude = temp.Longitude;

            }
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
                    txtCoordinates.BackColor = SystemColors.Window;
                    btnNext.Enabled = true;
                }
                else
                {
                    lblResultMessage.Text = "Coordinate Error!";
                    lblResultMessage.ForeColor = Color.Red;
                    txtCoordinates.BackColor = Program.ErrorColor;
                    btnNext.Enabled = false;
                }
            }
          
            return temp;
        }
    }
}
