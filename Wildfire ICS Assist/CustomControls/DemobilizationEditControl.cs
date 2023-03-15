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
    public partial class DemobilizationEditControl : UserControl
    {
        private IncidentResource _ResourceBeingDebriefed = new IncidentResource();
        private CheckInRecord _SelectedCheckInRecord = new CheckInRecord();
        private DemobilizationRecord _SelectedDemobRecord = new DemobilizationRecord();

        public CheckInRecord SelectedCheckInRecord { get => _SelectedCheckInRecord; private set => _SelectedCheckInRecord = value; }
        public DemobilizationRecord SelectedDemobRecord { get => _SelectedDemobRecord; private set => _SelectedDemobRecord = value; }

        public void SetRecord(IncidentResource res, CheckInRecord rec, DemobilizationRecord demob)
        {
            _ResourceBeingDebriefed = res; _SelectedCheckInRecord = rec; _SelectedDemobRecord = demob; DisplayDemob();
        }

        public DemobilizationEditControl()
        {
            InitializeComponent();
        }

        private void DisplayDemob()
        {
            txtSelectedName.Text = _ResourceBeingDebriefed.ResourceName;
            datCheckInDate.Value = _SelectedCheckInRecord.CheckInDate;
            datLastDayOfRest.Value = _SelectedCheckInRecord.LastDayOfRest;
            datCheckOutDate.MinDate = datCheckInDate.Value;
            if (SelectedDemobRecord.DemobDate > datCheckOutDate.MinDate) { datCheckOutDate.Value = SelectedDemobRecord.DemobDate; } else if (datCheckOutDate.MinDate < DateTime.Now) { datCheckOutDate.Value = DateTime.Now; }
            cboDemobLocation.Text = SelectedDemobRecord.DemobLocation;
            txtTravelTime.Text = SelectedDemobRecord.TravelTimeToHomeUnit;
            datDebriefDate.Value = SelectedDemobRecord.DebriefDate;
            cboDebriefLocation.Text = SelectedDemobRecord?.DebriefLocation;
            chkInventory.Checked = SelectedDemobRecord.InventoryReconciled;
            chkWithFacilities.Checked = SelectedDemobRecord.DiscrepanciesWithFacilities;
            chkWithFinance.Checked = SelectedDemobRecord.DiscrepanciesWithFinance;
            chkWithSupply.Checked = SelectedDemobRecord.DiscrepanciesWithSupply;
            chk211.Checked = SelectedDemobRecord.ICS211Completed;
        }

        private void datCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DemobDate = datCheckOutDate.Value;
        }

        private void cboDemobLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DemobLocation = cboDemobLocation.Text;
        }

        private void txtTravelTime_TextChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.TravelTimeToHomeUnit = txtTravelTime.Text;
        }

        private void datDebriefDate_ValueChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DebriefDate = datDebriefDate.Value;
        }

        private void cboDebriefLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DebriefLocation = cboDebriefLocation.Text;
        }

        private void chkInventory_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.InventoryReconciled = ((CheckBox)sender).Checked;
        }

        private void chkWithSupply_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DiscrepanciesWithSupply = ((CheckBox)sender).Checked;
        }

        private void chkWithFacilities_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DiscrepanciesWithFacilities = ((CheckBox)sender).Checked;
        }

        private void chkWithFinance_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.DiscrepanciesWithFinance = ((CheckBox)sender).Checked;
        }

        private void chk211_CheckedChanged(object sender, EventArgs e)
        {
            SelectedDemobRecord.ICS211Completed = ((CheckBox)sender).Checked;
        }
    }
}
