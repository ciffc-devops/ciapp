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
    public partial class MedicalPlanHospitalEntryForm : BaseForm
    {
        private Hospital _selectedHospital = new Hospital();

        public Hospital selectedHospital { get => _selectedHospital;  }
        public bool SaveForLater { get => chkSaveForLater.Checked; }

        public MedicalPlanHospitalEntryForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtLatitude_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
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

        private void MedicalPlanHospitalEntryForm_Load(object sender, EventArgs e)
        {
            List<Hospital> hospitals = (List<Hospital>)Program.generalOptionsService.GetOptionsValue("Hospitals");
            hospitals = hospitals.Where(o => o.Active).OrderBy(o => o.name).ToList();
            cboSaved.DataSource = hospitals;
            pnlSavedHospital.Enabled = hospitals.Any();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem != null)
            {
                _selectedHospital = (Hospital)cboSaved.SelectedItem;
                selectedHospital.travelTimeGround = numSavedTravelGround.Value;
                selectedHospital.travelTimeAir = numSavedTravelAir.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                selectedHospital.name = txtHospitalName.Text.Trim();
                selectedHospital.phone =txtPhone.Text.Trim();   
                selectedHospital.location = txtAddress.Text.Trim();
                selectedHospital.burnUnit = chkBurnUnit.Checked;
                selectedHospital.helipad = chkHelipad.Checked;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateNew()
        {
            if (string.IsNullOrEmpty(txtHospitalName.Text.Trim())) { txtHospitalName.BackColor = Program.ErrorColor; return false; }
            else { txtHospitalName.BackColor = Program.GoodColor; }

            return true;
        }

        private void cboSaved_Leave(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem == null) { cboSaved.Text = ""; }
        }

        private void txtHospitalName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHospitalName.Text.Trim())) { txtHospitalName.BackColor = Program.ErrorColor; }
            else { txtHospitalName.BackColor = Program.GoodColor; }


        }
    }
}
