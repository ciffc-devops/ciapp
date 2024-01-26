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
                txtOrderRequestNo.Text = CurrentVehicle.OrderRequestNo;
                txtIncidentIDNo.Text = CurrentVehicle.IncidentIDNo;
                txtClassification.Text = CurrentVehicle.Classification;
                txtMake.Text = CurrentVehicle.Make;
                txtCategoryKindCapacity.Text = CurrentVehicle.CategoryKindCapacity;
                txtFeatures.Text = CurrentVehicle.Features;
                txtAgencyOrOwner.Text = CurrentVehicle.AgencyOrOwner;
               // txtOperatorName.Text = CurrentVehicle.OperatorName;
                txtLicenseOrID.Text = CurrentVehicle.LicenseOrID;
                txtIncidentAssignment.Text = CurrentVehicle.IncidentAssignment;
                txtNotes.Text = CurrentVehicle.Notes;
                txtKind.Text = CurrentVehicle.Kind;
                txtType.Text = CurrentVehicle.Type;
                if (CurrentVehicle.IsEquipment) { rbEquipment.Checked = true; }
                else { rbVehicle.Checked = true; }

                if(CurrentVehicle.OperatorID != Guid.Empty)
                {
                    try { cboOperator.SelectedValue = CurrentVehicle.OperatorID; }
                    catch { cboOperator.SelectedItem = null; }
                } else { cboOperator.SelectedItem = null; }
            }
        }

        public bool IsComplete
        {
            get
            {
                if (string.IsNullOrEmpty(txtIncidentIDNo.Text)) { txtIncidentIDNo.BackColor = Program.ErrorColor; }
                else { txtIncidentIDNo.BackColor = Program.GoodColor; }

                return !string.IsNullOrEmpty(txtIncidentIDNo.Text);
            }
        }

        private void txtOrderRequestNo_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.OrderRequestNo = txtOrderRequestNo.Text;
           
        }

        private void txtIncidentIDNo_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.IncidentIDNo = txtIncidentIDNo.Text;
            if (string.IsNullOrEmpty(txtIncidentIDNo.Text)) { txtIncidentIDNo.BackColor = Program.ErrorColor; }
            else { txtIncidentIDNo.BackColor = Program.GoodColor; }
          
        }

        private void txtClassification_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Classification = txtClassification.Text;
        }

        private void txtMake_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Make = txtMake.Text;


        }

        private void txtCategoryKindCapacity_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.CategoryKindCapacity = txtCategoryKindCapacity.Text;

        }

        private void txtKind_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Kind = txtKind.Text;

        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Type = txtType.Text;

        }

        private void txtFeatures_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Features = txtFeatures.Text;

        }

        private void txtAgencyOrOwner_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.AgencyOrOwner = txtAgencyOrOwner.Text;

        }

    

        private void txtLicenseOrID_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.LicenseOrID = txtLicenseOrID.Text;

        }

        private void txtIncidentAssignment_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.IncidentAssignment = txtIncidentAssignment.Text;

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            CurrentVehicle.Notes = txtNotes.Text;

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

        private void rbVehicle_CheckedChanged(object sender, EventArgs e)
        {
            //txtLicenseOrID.Enabled = rbVehicle.Checked;
            txtType.Enabled = !rbVehicle.Checked;
            txtKind.Enabled = !rbVehicle.Checked;
            CurrentVehicle.IsEquipment = !rbVehicle.Checked;
        }
    }
}
