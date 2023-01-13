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
    public partial class MedicalPlanMedivacEntryForm : Form
    {
        private AmbulanceService _SelectedAmbulance = new AmbulanceService();
        public AmbulanceService SelectedAmbulance { get => _SelectedAmbulance; }
        public bool SaveForLater { get => chkSaveForLater.Checked; }
        public MedicalPlanMedivacEntryForm()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCoordinates_Leave(object sender, EventArgs e)
        {
            Coordinate temp = new Coordinate();
            if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
            {
                lblCoordinateStatus.Text = "Coordinate OK";
                lblCoordinateStatus.ForeColor = label1.ForeColor;
                SelectedAmbulance.Latitude = temp.Latitude;
                SelectedAmbulance.Longitude = temp.Longitude;
            }
            else
            {
                lblCoordinateStatus.Text = "Coordinate Error!";
                lblCoordinateStatus.ForeColor = Color.Red;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void buildDataList()
        {
            cboSaved.DataSource = null;
            List<AmbulanceService> items = (List<AmbulanceService>)Program.generalOptionsService.GetOptionsValue("Ambulances");
            items = items.Where(o => o.Active).OrderBy(o => o.Organization).ToList();
            cboSaved.DataSource = items;
        }

        private void MedicalPlanMedivacEntryForm_Load(object sender, EventArgs e)
        {
            buildDataList();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem == null) { cboSaved.BackColor = Program.ErrorColor; }
            else
            {
                AmbulanceService ambulance = (AmbulanceService)cboSaved.SelectedItem;
                _SelectedAmbulance= ambulance;
                _SelectedAmbulance.OpPeriod = Program.CurrentOpPeriod;
                this.DialogResult= DialogResult.OK;
                this.Close();
            }
        }

        private void cboSaved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSaved.SelectedItem == null) { cboSaved.BackColor = Program.ErrorColor; }
            else { cboSaved.BackColor = Program.GoodColor; }
        }

        private bool ValidateNewForm()
        {
            StringBuilder err = new StringBuilder();
            bool isValid = true;

            if (string.IsNullOrEmpty(txtOrganization.Text.Trim())) { txtOrganization.BackColor = Program.ErrorColor; isValid = false; err.Append("You must include the name of the medivac service."); }
            else { txtOrganization.BackColor = Program.GoodColor; }

            if (!isValid) { MessageBox.Show(err.ToString()); }
            return isValid;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNewForm())
            {
                SelectedAmbulance.AmbulanceID = Guid.NewGuid();
                SelectedAmbulance.Organization = txtOrganization.Text.Trim();
                SelectedAmbulance.Contact = txtContact.Text.Trim();
                SelectedAmbulance.Location = txtLocation.Text.Trim();
                SelectedAmbulance.IsALS = rbALS.Checked;
                SelectedAmbulance.IsBLS= rbBLS.Checked;
                SelectedAmbulance.OpPeriod = Program.CurrentOpPeriod;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
