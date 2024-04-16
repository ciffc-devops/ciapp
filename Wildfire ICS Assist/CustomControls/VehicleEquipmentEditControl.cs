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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class VehicleEquipmentEditControl : UserControl
    {
        private Vehicle _currentVehicle = new Vehicle();
        public Vehicle CurrentVehicle { get => _currentVehicle;  }
        public void SetVehicle(Vehicle vehicle) { _currentVehicle = vehicle; loadVehicle(); }

        public bool EnableOperatorField { get => cboOperator.Enabled; set => cboOperator.Enabled = value; }
        public void SetOperatorList(List<IncidentResource> Operators)
        {
            cboOperator.DataSource = null;
            cboOperator.DataSource = Operators;
        }

        public VehicleEquipmentEditControl()
        {
            InitializeComponent();
        }

        private void loadVehicle()
        {
            if (CurrentVehicle != null)
            {
                txtIncidentIDNo.SetText(CurrentVehicle.IncidentIDNo);
                txtUnitNumber.Text = CurrentVehicle.UnitNumber;
                txtSerialNumber.Text = CurrentVehicle.SerialNumber;
                txtLicenseOrID.Text = CurrentVehicle.LicenseOrID;
                txtKind.Text = CurrentVehicle.Kind;
                cboType.Text = CurrentVehicle.Type;
                txtFeatures.Text = CurrentVehicle.Features;
                txtOrderRequestNo.Text = CurrentVehicle.OrderRequestNo;
                if (CurrentVehicle.OperatorID != Guid.Empty)
                {
                    try { cboOperator.SelectedValue = CurrentVehicle.OperatorID; }
                    catch { cboOperator.SelectedItem = null; }
                }
                else { cboOperator.SelectedItem = null; }
                txtNotes.Text = CurrentVehicle.Notes;
                

            }
        }

        public bool IsComplete
        {
            get
            {
                return txtIncidentIDNo.IsValid;
            }
        }

      

        private void cboOperator_Leave(object sender, EventArgs e)
        {
            if(cboOperator.SelectedItem != null) {
                IncidentResource res = cboOperator.SelectedItem as IncidentResource;
                CurrentVehicle.OperatorID = res.ID;
                CurrentVehicle.OperatorName = res.ResourceName;
                CurrentVehicle.LeaderName = CurrentVehicle.OperatorName;
            }
            else
            {
                cboOperator.Text = "";
                CurrentVehicle.OperatorID = Guid.Empty;
                CurrentVehicle.OperatorName = string.Empty; CurrentVehicle.LeaderName = CurrentVehicle.OperatorName;
            }
        }

        private void txtIncidentIDNo_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.IncidentIDNo = txtIncidentIDNo.Text;
        }

        private void txtUnitNumber_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.UnitNumber = txtUnitNumber.Text;
        }

        private void txtSerialNumber_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.SerialNumber = txtSerialNumber.Text;
        }

        private void txtLicenseOrID_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.LicenseOrID = txtLicenseOrID.Text;
        }

        private void txtKind_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Kind = txtKind.Text;
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Type = cboType.Text;
        }

        private void txtFeatures_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Features = txtFeatures.Text;
        }

        private void txtOrderRequestNo_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.OrderRequestNo = txtOrderRequestNo.Text;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Notes = txtNotes.Text;
        }
    }
}
