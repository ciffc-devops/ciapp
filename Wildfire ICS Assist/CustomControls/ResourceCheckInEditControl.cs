using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class ResourceCheckInEditControl : UserControl
    {
        private List<CheckInInfoField> infoFields = new List<CheckInInfoField>();
        private List<CheckInInfoFieldControl> infoFieldControls = new List<CheckInInfoFieldControl>();
        private CheckInRecord _checkInRecord = new CheckInRecord();
        public CheckInRecord checkInRecord { get => _checkInRecord; }
        public void SetCheckInRecord(CheckInRecord record) { _checkInRecord = record; }

        private IncidentResource _selectedResource = new IncidentResource();
        public IncidentResource selectedResource { get => _selectedResource; }
        public void SetResource(IncidentResource record) { _selectedResource = record;  }


        public ResourceCheckInEditControl()
        {
            InitializeComponent();
        }

        private void ResourceCheckInEditControl_Load(object sender, EventArgs e)
        {
            
        }

        private void CalculateDateDiffs()
        {
            TimeSpan ts1 = datCheckInTime.Value - datLastDayOfRest.Value;
            lblDaysSinceLastDayOfRest.Text = Math.Round(ts1.TotalDays, 0).ToString() + " days";

            TimeSpan ts2 = datLDW.Value - datCheckInTime.Value;
            TimeSpan ts3 = datLDW.Value - datLastDayOfRest.Value;
            lblLastDayCount.Text = Math.Round(ts3.TotalDays, 0).ToString() + " days since rest / " + Math.Round(ts2.TotalDays, 0).ToString() + " since check in";
        }
       
        private void datCheckInTime_ValueChanged(object sender, EventArgs e)
        {
            datLDW.MinDate = datCheckInTime.Value;
            CalculateDateDiffs();
        }

        private void datLDW_ValueChanged(object sender, EventArgs e)
        {

            if (datCheckInTime.Value > datLDW.Value) { lblLastDayWorking.ForeColor = Color.Red; }
            else { lblLastDayWorking.ForeColor = lblLastDayCount.ForeColor; }

            CalculateDateDiffs();
        }

        public bool ValidateCheckInInfo()
        {
            if (datCheckInTime.Value > datLDW.Value)
            {
                lblLastDayWorking.ForeColor = Color.Red;
                return false;
            }
            else { lblLastDayWorking.ForeColor = lblLastDayCount.ForeColor; }
            return true;
        }

        public void SaveFormFieldsToCheckin()
        {
            checkInRecord.InfoFields = new List<CheckInInfoField>();
            foreach (CheckInInfoFieldControl ctrl in infoFieldControls)
            {
                checkInRecord.InfoFields.Add(ctrl.infoField.Clone());
            }
            checkInRecord.CheckInDate = datCheckInTime.Value;
            checkInRecord.LastDayOnIncident = datLDW.Value;
            checkInRecord.LastDayOfRest = datLastDayOfRest.Value;
        }

        public void LoadPage()
        {
            if (_checkInRecord.CheckInDate == DateTime.MinValue)
            {
                DateTime today = DateTime.Now;
                _checkInRecord.LastDayOfRest = today;
                _checkInRecord.CheckInDate = today; 
                _checkInRecord.LastDayOnIncident = today.AddDays(14);
            }

                if (datLastDayOfRest.MinDate <= checkInRecord.LastDayOfRest) { datLastDayOfRest.Value = _checkInRecord.LastDayOfRest; } else { datLastDayOfRest.Value = datLastDayOfRest.MinDate; }

            if (datCheckInTime.MinDate <= _checkInRecord.CheckInDate) { datCheckInTime.Value = _checkInRecord.CheckInDate; } else { datCheckInTime.Value = datCheckInTime.MinDate; }
            if (datLDW.MinDate <= checkInRecord.LastDayOnIncident) { datLDW.Value = _checkInRecord.LastDayOnIncident; } else { datLDW.Value = datLDW.MinDate; }
            
            txtSelectedName.Text = _selectedResource.ResourceName;
            txtResourceType.Text = checkInRecord.ResourceType;

            infoFields.Clear();
            if (_checkInRecord.InfoFields.Any()) { infoFields.AddRange(_checkInRecord.InfoFields); }
            else { infoFields = CheckInTools.GetInfoFields(checkInRecord.ResourceType); }

            infoFieldControls.Clear();
            pnlCheckInFields.Controls.Clear();
            pnlCheckInFields.AutoScroll = false;
            pnlCheckInFields.HorizontalScroll.Enabled = false;
            pnlCheckInFields.HorizontalScroll.Visible = false;
            pnlCheckInFields.HorizontalScroll.Maximum = 0;
            pnlCheckInFields.AutoScroll = true;

            foreach (CheckInInfoField field in infoFields)
            {
                CheckInInfoFieldControl ctrl = new CheckInInfoFieldControl();
                ctrl.SetInfoField(field);
                ctrl.Location = new Point(5, getCheckInFieldY());
                ctrl.Width = pnlCheckInFields.Width - 10;
                if (infoFieldControls.Any()) { ctrl.Width = infoFieldControls.First().Width; }
                ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                infoFieldControls.Add(ctrl);
                pnlCheckInFields.Controls.Add(ctrl);
            }
            lblScrollHint.Visible = pnlCheckInFields.VerticalScroll.Visible;
        }

        private int getCheckInFieldY()
        {
            int lastY = 0;

            if (infoFieldControls.Any())
            {
                lastY = infoFieldControls.Last().Location.Y;
                lastY = lastY + 40;
            }

            return lastY;
        }

        private void datLastDayOfRest_ValueChanged(object sender, EventArgs e)
        {
            datCheckInTime.MinDate = datLastDayOfRest.Value;
            CalculateDateDiffs();
        }
    }
}
