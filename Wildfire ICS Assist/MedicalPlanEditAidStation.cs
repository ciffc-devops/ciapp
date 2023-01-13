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
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class MedicalPlanEditAidStation : Form
    {
        private MedicalAidStation _aidStation = null;
        public MedicalAidStation aidStation { get => _aidStation; set { _aidStation = value; LoadAidStation(); } }

        private void LoadAidStation()
        {
            txtContact.Text = aidStation.ContactNumber;
            txtLocation.Text = aidStation.Location;
            chkParamedics.Checked = aidStation.ParamedicsAvailable;
            txtAidStation.Text = aidStation.Name;
            Coordinate coord = new Coordinate();
            coord.Latitude = aidStation.Latitude;
            coord.Longitude = aidStation.Longitude;
            if (coord.Latitude != 0 || coord.Longitude != 0) { txtCoordinates.Text = coord.CoordinateOutput(Program.generalOptionsService.GetOptionsValue("CoordinateFormat").ToString()); }
            else { txtCoordinates.Text = string.Empty; }
        }
        public MedicalPlanEditAidStation()
        {
            InitializeComponent();
        }

        private void MedicalPlanEditAidStation_Load(object sender, EventArgs e)
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
                aidStation.ContactNumber = txtContact.Text;
                aidStation.Location = txtLocation.Text;
                aidStation.Name = txtAidStation.Text;
                aidStation.ParamedicsAvailable = chkParamedics.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            bool formOK = true;
            if (string.IsNullOrEmpty(txtAidStation.Text.Trim())) { txtAidStation.BackColor = Program.ErrorColor; return false; } else { txtAidStation.BackColor = Program.GoodColor; }

            return formOK;
        }

        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
            {
                lblCoordinateStatus.Text = "Coordinate OK";
                lblCoordinateStatus.ForeColor = label1.ForeColor;
                aidStation.Latitude = temp.Latitude;
                aidStation.Longitude = temp.Longitude;
            }
            else
            {
                lblCoordinateStatus.Text = "Coordinate Error!";
                lblCoordinateStatus.ForeColor = Color.Red;
            }
        }
    }
}
