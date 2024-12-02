using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.OrganizationalChartModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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
        public bool AssignIfPossible { get => chkAutoAssign.Checked; }

        public bool IsComplete
        {
            get
            {
                foreach(CheckInInfoFieldControl ctrl in infoFieldControls)
                {
                    if (!ctrl.IsComplete) { return false; }
                }
                return true;
            }
        }

        public ResourceCheckInEditControl()
        {
            InitializeComponent();
        }

        private void ResourceCheckInEditControl_Load(object sender, EventArgs e)
        {
            
        }

        private List<GenericICSRole> GetICSRolesForDropdown()
        {
            List<GenericICSRole> roles = OrganizationalChartTools.GetGenericICSRoles();
            roles = roles.
                OrderByDescending(o => o.MnemonicAbrv.Contains("ICT")).ThenByDescending(o => o.SectionID == Globals.IncidentCommanderGenericID)
                .ThenByDescending(o => o.MnemonicAbrv.Contains("OSC")).ThenByDescending(o => o.SectionID == Globals.OpsChiefGenericID)
                .ThenByDescending(o => o.MnemonicAbrv.Contains("PSC")).ThenByDescending(o => o.SectionID == Globals.PlanningChiefGenericID)
                .ThenByDescending(o => o.MnemonicAbrv.Contains("LSC")).ThenByDescending(o => o.SectionID == Globals.LogisticsChiefGenericID)
                .ThenByDescending(o => o.MnemonicAbrv.Contains("FSC")).ThenByDescending(o => o.SectionID == Globals.FinanceChiefGenericID)
                .ThenBy(o => o.RoleName).ToList();

            GenericICSRole blank = new GenericICSRole() { GenericRoleID = Guid.Empty, RoleName = string.Empty, ReportsToGenericRoleID = Guid.Empty, SectionID = Guid.Empty, MnemonicAbrv = string.Empty, RoleDescription = string.Empty };
            roles.Insert(0, blank);

            return roles;
        }
        
        private void CalculateDateDiffs()
        {
            TimeSpan ts1 = datCheckInTime.Value - datLastDayOfRest.Value;
            lblDaysSinceLastDayOfRest.Text = Math.Round(ts1.TotalDays, 0).ToString() + " days";

            TimeSpan ts2 = datLDW.Value - datCheckInTime.Value;
            TimeSpan ts3 = datLDW.Value - datLastDayOfRest.Value;
            lblLastDayCount.Text = Math.Round(ts3.TotalDays, 0).ToString() + " days since rest / " + Math.Round(ts2.TotalDays, 0).ToString() + " days since check in";
        }
       
        private void datCheckInTime_ValueChanged(object sender, EventArgs e)
        {
            datLDW.MinDate = datCheckInTime.Value.Date;
            CalculateDateDiffs();
        }

        private void datLDW_ValueChanged(object sender, EventArgs e)
        {

            if (datCheckInTime.Value.Date > datLDW.Value.Date) { lblLastDayWorking.ForeColor = Color.Red; }
            else { lblLastDayWorking.ForeColor = lblLastDayCount.ForeColor; }

            CalculateDateDiffs();
        }

        public bool ValidateCheckInInfo()
        {
            bool IsValid = true;
            if (checkInRecord.IsPerson)
            {
                if (datCheckInTime.Value.Date > datLDW.Value.Date)
                {
                    lblLastDayWorking.ForeColor = Color.Red;
                    errorProvider1.SetError(datCheckInTime, "Your check in time should be earlier than your last day working");
                    IsValid = false;
                }
                else
                {
                    lblLastDayWorking.ForeColor = lblLastDayCount.ForeColor; errorProvider1.SetError(datCheckInTime, "");
                }

                if (datCheckInTime.Value > Program.CurrentOpPeriodDetails.PeriodEnd || datLDW.Value < Program.CurrentOpPeriodDetails.PeriodStart)
                {
                    DialogResult proceed = MessageBox.Show("This check in falls outside the current operational period date/time.  They will not be shown on the resource list by default without adjusting filters. Do you want to proceed anyway?", "Outside current op period", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (proceed == DialogResult.No) { IsValid = false; }
                }
            }
            else
            {
                if (datCheckInTimeOtherResource.Value > Program.CurrentOpPeriodDetails.PeriodEnd || (datLDWOtherResource.Checked && datLDWOtherResource.Value < Program.CurrentOpPeriodDetails.PeriodStart))
                {
                    DialogResult proceed = MessageBox.Show("This check in falls outside the current operational period date/time.  They will not be shown on the resource list by default without adjusting filters. Do you want to proceed anyway?", "Outside current op period", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (proceed == DialogResult.No) { IsValid = false; }
                }

            }



            //confirm the ID is unique
            bool isUnique =  Program.CurrentIncident.ConfirmResourceNumUnique(selectedResource.ResourceType, selectedResource.UniqueIDNum,selectedResource.ID);
            if (!isUnique)
            {
                numUniqueIDNumber.BackColor = Program.ErrorColor;
                errorProvider1.SetError(numUniqueIDNumber, "This number must be unique");
                IsValid = false;
            }
            else
            {
                numUniqueIDNumber.BackColor = Program.GoodColor;
                errorProvider1.SetError(numUniqueIDNumber, "");

            }

            bool allAdditionalFieldsComplete = IsComplete;
            if (!IsComplete) { IsValid = false; }
            return IsValid;
        }

        public void SaveFormFieldsToCheckIn()
        {
            checkInRecord.InfoFields = new List<CheckInInfoField>();
            foreach (CheckInInfoFieldControl ctrl in infoFieldControls)
            {
                checkInRecord.InfoFields.Add(ctrl.infoField.Clone());
            }
            if (pnlPersonnelDetails.Visible)
            {
                checkInRecord.CheckInDate = datCheckInTime.Value;
                checkInRecord.FirstDayOnIncident = datFirstDayOnIncident.Value;
                checkInRecord.LastDayOnIncident = datLDW.Value;
                checkInRecord.LastDayOfRest = datLastDayOfRest.Value;

                
            }
            else
            {
                checkInRecord.CheckInDate = datCheckInTimeOtherResource.Value;
                if (datLDWOtherResource.Checked) { checkInRecord.LastDayOnIncident = datLDWOtherResource.Value; }
                else { checkInRecord.LastDayOnIncident = DateTime.MaxValue; }
                checkInRecord.FirstDayOnIncident = datFirstDayOnIncidentOtherResource.Value;
            }

            if (pnlRoleOnTask.Visible)
            {
if (cboICSRole.SelectedItem != null)
                {
                    GenericICSRole genericRole = (GenericICSRole)cboICSRole.SelectedItem;


                    checkInRecord.InitialRoleName = genericRole.RoleName;
                    checkInRecord.InitialRoleAcronym = genericRole.MnemonicAbrv;
                }
                else { checkInRecord.InitialRoleAcronym = string.Empty; checkInRecord.InitialRoleName = string.Empty; }
            }



        }

        public void LoadPage()
        {
            

            txtSelectedName.Text = _selectedResource.ResourceName;
            txtResourceType.Text = checkInRecord.ResourceType;




            infoFields.Clear();
            if (_checkInRecord.InfoFields.Any()) { infoFields.AddRange(_checkInRecord.InfoFields); }
            else { infoFields = CheckInTools.GetInfoFields(checkInRecord.ResourceType); }

            if (checkInRecord.IsCrew || checkInRecord.IsPerson || checkInRecord.IsVisitor || checkInRecord.IsHECrew)
            {
                if (_checkInRecord.CheckInDate == DateTime.MinValue)
                {
                    DateTime today = DateTime.Now;
                    _checkInRecord.LastDayOfRest = today;
                    _checkInRecord.CheckInDate = today;
                    _checkInRecord.FirstDayOnIncident = today;
                    _checkInRecord.LastDayOnIncident = today.AddDays(14);
                }
                else if (_checkInRecord.LastDayOnIncident > datLDW.MaxDate) { _checkInRecord.LastDayOnIncident = _checkInRecord.CheckInDate.AddDays(14); }


                if (datLastDayOfRest.MinDate <= checkInRecord.LastDayOfRest) { datLastDayOfRest.Value = _checkInRecord.LastDayOfRest; } else { datLastDayOfRest.Value = datLastDayOfRest.MinDate; }

                if (datCheckInTime.MinDate <= _checkInRecord.CheckInDate) { datCheckInTime.Value = _checkInRecord.CheckInDate; } else { datCheckInTime.Value = datCheckInTime.MinDate; }
                if (datFirstDayOnIncident.MinDate <= _checkInRecord.FirstDayOnIncident) { datFirstDayOnIncident.Value = _checkInRecord.FirstDayOnIncident; } else { datFirstDayOnIncident.Value = datFirstDayOnIncident.MinDate; }
                if (datLDW.MinDate <= checkInRecord.LastDayOnIncident) { datLDW.Value = _checkInRecord.LastDayOnIncident; } else { datLDW.Value = datLDW.MinDate; }

                if (checkInRecord.IsPerson)
                {
                    chkAutoAssign.Enabled = true;
                    List<GenericICSRole> roles = GetICSRolesForDropdown();
                    cboICSRole.DataSource = roles;

                    if (!string.IsNullOrEmpty(checkInRecord.InitialRoleAcronym) && roles.Any(o => !string.IsNullOrEmpty(o.MnemonicAbrv) && o.MnemonicAbrv.Equals(checkInRecord.InitialRoleAcronym)))
                    {
                        cboICSRole.SelectedValue = roles.First(o => !string.IsNullOrEmpty(o.MnemonicAbrv) && o.MnemonicAbrv.Equals(checkInRecord.InitialRoleAcronym)).GenericRoleID;
                    }
                }
                pnlOtherResourceDetails.Visible = false;
                pnlPersonnelDetails.Visible = true;

                if (checkInRecord.IsPerson)
                {
                    pnlRoleOnTask.Visible = true;
                    pnlPersonnelDetails.Location = new System.Drawing.Point(0, pnlRoleOnTask.Location.Y + pnlRoleOnTask.Size.Height + 10);
                    pnlCheckInFields.Location = new System.Drawing.Point(0, pnlPersonnelDetails.Location.Y + pnlPersonnelDetails.Size.Height + 10);
                    pnlCheckInFields.Height = this.Height - pnlCheckInFields.Location.Y;

                }
                else //crew or visitor
                {
                    pnlRoleOnTask.Visible = false;
                    pnlPersonnelDetails.Location = new System.Drawing.Point(0, cboUniqueIDLetter.Location.Y + cboUniqueIDLetter.Size.Height + 10);
                    pnlCheckInFields.Location = new System.Drawing.Point(0, pnlPersonnelDetails.Location.Y + pnlPersonnelDetails.Size.Height + 10);
                    pnlCheckInFields.Height = this.Height - pnlCheckInFields.Location.Y;

                }
            }


            else
            {
                if (_checkInRecord.CheckInDate == DateTime.MinValue)
                {
                    DateTime today = DateTime.Now;
                    _checkInRecord.CheckInDate = today;
                    _checkInRecord.FirstDayOnIncident = today;
                }
                pnlRoleOnTask.Visible = false;

                datLDWOtherResource.Checked = checkInRecord.LastDayOnIncident != DateTime.MaxValue;
                if (datLDWOtherResource.Checked) { datLDWOtherResource.Value = checkInRecord.LastDayOnIncident; }
                
                if (datCheckInTimeOtherResource.MinDate <= _checkInRecord.CheckInDate) { datCheckInTimeOtherResource.Value = _checkInRecord.CheckInDate; } else { datCheckInTimeOtherResource.Value = datCheckInTimeOtherResource.MinDate; }

                if (datFirstDayOnIncidentOtherResource.MinDate <= _checkInRecord.FirstDayOnIncident) { datFirstDayOnIncidentOtherResource.Value = _checkInRecord.FirstDayOnIncident; } else { datFirstDayOnIncidentOtherResource.Value = datFirstDayOnIncidentOtherResource.MinDate; }
                pnlPersonnelDetails.Visible = false;
                pnlOtherResourceDetails.Location = new System.Drawing.Point(0, cboUniqueIDLetter.Location.Y + cboUniqueIDLetter.Size.Height + 10);
                pnlOtherResourceDetails.Visible = true;
                pnlCheckInFields.Location = new System.Drawing.Point(0, pnlOtherResourceDetails.Location.Y + pnlOtherResourceDetails.Size.Height + 10);
                pnlCheckInFields.Height = this.Height - pnlCheckInFields.Location.Y;
            }


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

            switch (selectedResource.ResourceType)
            {
                case "Personnel": cboUniqueIDLetter.Text = "P"; break;
                case "Vehicle": cboUniqueIDLetter.Text = "V"; break;
                case "Equipment": cboUniqueIDLetter.Text = "E"; break;
                case "Crew": cboUniqueIDLetter.Text = "C"; break;
                case "Heavy Equipment Crew": cboUniqueIDLetter.Text = "C"; break;
                case "Aircraft":cboUniqueIDLetter.Text = "A"; break;

            }
            if (selectedResource.UniqueIDNum == 0)
            {
                numUniqueIDNumber.Value = Program.CurrentIncident.GetNextUniqueNum(selectedResource.ResourceType, 1, 1000);

            }
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

        private void cboICSRole_Leave(object sender, EventArgs e)
        {
            if (cboICSRole.SelectedItem == null) { cboICSRole.Text = string.Empty; }
        }

        private void cboICSRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkAutoAssign.Checked = cboICSRole.SelectedIndex > 0;
        }

        private void btnGetNextID_Click(object sender, EventArgs e)
        {
           numUniqueIDNumber.Value = Program.CurrentIncident.GetNextUniqueNum(selectedResource.ResourceType, 1, 1000);
        }

        private void numUniqueIDNumber_ValueChanged(object sender, EventArgs e)
        {
            selectedResource.UniqueIDNum = Convert.ToInt32(numUniqueIDNumber.Value); ValidateCheckInInfo();
        }
    }
}
