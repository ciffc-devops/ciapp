using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;


namespace Wildfire_ICS_Assist.OperationalPeriodForms
{
    public partial class CreateOperationalPeriodForm : BaseForm
    {

        OperationalPeriod _operationalPeriod = new OperationalPeriod();
        public OperationalPeriod operationalPeriod { get => _operationalPeriod; set => _operationalPeriod = value; }
        public bool SwitchToNewOpNow { get => chkSwitchNow.Checked; }
        bool LoadingInProgress = false;

        List<IncidentDataItem> ItemsAvailableForCopy = new List<IncidentDataItem>();


        public CreateOperationalPeriodForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);



        }
        private void CreateOperationalPeriodForm_Load(object sender, EventArgs e)
        {
            LoadingInProgress = true;
            numOpPeriod.Value = operationalPeriod.PeriodNumber;
            datOpsStart.Value = operationalPeriod.PeriodStart;
            datStartTime.Value = operationalPeriod.PeriodStart;

            datOpsEnd.Value = operationalPeriod.PeriodEnd;
            datEndTime.Value = operationalPeriod.PeriodEnd;

            BuildOpPeriodComboBox();

            if (Program.CurrentIncident.AllOperationalPeriods.Any(o => o.Active && o.ID == operationalPeriod.ID))
            {
                numOpPeriod.Enabled = false;
                chkSwitchNow.Visible = false;
                btnCreateOpPeriod.Text = "Save Changes";
            }

            LoadingInProgress = false;
            //numOpPeriod.Minimum = lowestUnusedOpNumber;
        }


        private void BuildOpPeriodComboBox()
        {
            cboCurrentOperationalPeriod.DisplayMember = "DisplayName";
            cboCurrentOperationalPeriod.ValueMember = "PeriodNumber";

            List<OperationalPeriod> periods = Program.CurrentIncident.AllOperationalPeriods.Where(o => o.Active && o.ID != operationalPeriod.ID).OrderBy(o => o.PeriodStart).ToList();
            cboCurrentOperationalPeriod.DataSource = periods;
            cboCurrentOperationalPeriod.DropDownWidth = cboCurrentOperationalPeriod.GetDropDownWidth();
            cboCurrentOperationalPeriod.SelectedIndex = cboCurrentOperationalPeriod.Items.Count - 1;
        }

        private void BuildListOfCopyableItems()
        {
            ItemsAvailableForCopy = new List<IncidentDataItem>();

            if (cboCurrentOperationalPeriod.SelectedItem != null)
            {
                OperationalPeriod copyFrom = cboCurrentOperationalPeriod.SelectedItem as OperationalPeriod;

                if (Program.CurrentIncident.hasMeaningfulObjectives(copyFrom.PeriodNumber)) { ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Incident Objectives", ID = ItemsAvailableForCopy.Count + 1 }); }
                if (Program.CurrentIncident.hasMeangfulCommsPlan(copyFrom.PeriodNumber)) { ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Communications Plan", ID = ItemsAvailableForCopy.Count + 1 }); }
                if (Program.CurrentIncident.hasMeaningfulMedicalPlan(copyFrom.PeriodNumber)) { ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Medical Plan", ID = ItemsAvailableForCopy.Count + 1 }); }
                 ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Organization Chart", ID = ItemsAvailableForCopy.Count + 1 }); 
                if (Program.CurrentIncident.allSafetyMessages.Any(o => o.OpPeriod == copyFrom.PeriodNumber && o.Active)) { ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Safety Message(s)", ID = ItemsAvailableForCopy.Count + 1 }); }
                if (Program.CurrentIncident.hasMeaningfulAirOps(copyFrom.PeriodNumber)) { ItemsAvailableForCopy.Add(new IncidentDataItem() { DisplayName = "Air Operations Plans", ID = ItemsAvailableForCopy.Count + 1 }); }
                //if (Program.CurrentIncident.hasMeaningfulObjectives(copyFrom.PeriodNumber)) { items.Add(new IncidentDataItem() { DisplayName = "Incident Objectives", ID = 1 }); }


            }

            flowCopyableItems.Controls.Clear();

            foreach (IncidentDataItem item in ItemsAvailableForCopy)
            {
                CheckBox chk = new CheckBox();
                chk.Text = item.DisplayName;
                chk.Tag = item.ID;
                chk.AutoSize = true;

                flowCopyableItems.Controls.Add(chk);
            }
        }


        private void btnCreateOpPeriod_Click(object sender, EventArgs e)
        {
            Tuple<bool, string> result = ValidateNewOP();
            if (result.Item1)
            {

                Program.incidentDataService.UpsertOperationalPeriod(operationalPeriod);
                if (cboCurrentOperationalPeriod.SelectedItem != null)
                {
                    int copyFromPeriodNumber = (cboCurrentOperationalPeriod.SelectedItem as OperationalPeriod).PeriodNumber;
                    int copyToPeriodNumber = operationalPeriod.PeriodNumber;

                    //copy stuff over
                    foreach (Control c in flowCopyableItems.Controls)
                    {
                        if (c is CheckBox)
                        {
                            CheckBox chk = c as CheckBox;
                            if (chk.Checked)
                            {
                                switch (chk.Text)
                                {
                                    case "Organization Chart":
                                       OrganizationChart newChart =  Program.CurrentIncident.CreateOrganizationalChartFromPreviousOP(copyFromPeriodNumber, copyToPeriodNumber, true);
                                        Program.incidentDataService.UpsertOrganizationalChart(newChart);
                                        Program.CurrentIncident.CreateAllOperationalGroupsAsNeeded(copyToPeriodNumber);

                                      


                                        break;
                                    case "Communications Plan":
                                        List<CommsPlanItem> commsItems = Program.CurrentIncident.CopyCommunicationsPlan(copyFromPeriodNumber, copyToPeriodNumber);

                                        break;
                                    case "Medical Plan":
                                        var newMedPlan = Program.CurrentIncident.CopyMedicalPlan(copyFromPeriodNumber, copyToPeriodNumber);
                                        break;
                                    case "Incident Objectives":
                                        IncidentObjectivesSheet newSheet = Program.CurrentIncident.CopyIncidentObjectivesSheet(copyFromPeriodNumber, copyToPeriodNumber);
                                        break;
                                    case "Safety Message(s)":
                                        List<SafetyMessage> newMessages = Program.CurrentIncident.CopySafetyMessages(copyFromPeriodNumber, copyToPeriodNumber);
                                        break;
                                    case "Air Operations Plans":
                                        AirOperationsSummary airOperationsSummary = Program.CurrentIncident.CopyAirOperationsSummary(copyFromPeriodNumber, copyToPeriodNumber);
                                        break;
                                }
                            }

                        }
                    }

                }




                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                LgMessageBox.Show(result.Item2, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private Tuple<bool, string> ValidateNewOP()
        {
            bool opGood = true;

            StringBuilder errs = new StringBuilder();

            //period number must be unique
            if (Program.CurrentIncident.AllOperationalPeriods.Any(o => o.Active && o.PeriodNumber == numOpPeriod.Value && o.ID != operationalPeriod.ID))
            {
                errs.AppendLine("Operational Period Number already in use.");
                opGood = false;
                errorProvider1.SetError(numOpPeriod, "Operational Period Number already in use.");
            }
            else { errorProvider1.SetError(numOpPeriod, ""); }


            //date and time covered must be unique
            Tuple<bool, bool, bool> overlap = Program.CurrentIncident.GetDoesThisOperationalPeriodOverlap(operationalPeriod);
            if (overlap.Item1 || overlap.Item2 || overlap.Item3)
            {
                errs.AppendLine("This time range overlaps with another operational period");
                opGood = false;
                if (overlap.Item1 || overlap.Item3)
                {
                    errorProvider1.SetError(datStartTime, "This time range overlaps with another operational period");
                }
                if (overlap.Item2 || overlap.Item3)
                {
                    errorProvider1.SetError(datEndTime, "This time range overlaps with another operational period");
                }

            }
            else { errorProvider1.SetError(datStartTime, ""); errorProvider1.SetError(datEndTime, ""); }

            return new Tuple<bool, string>(opGood, errs.ToString());
        }

        private void numOpPeriod_ValueChanged(object sender, EventArgs e)
        {
            operationalPeriod.PeriodNumber = (int)numOpPeriod.Value;
            _ = ValidateNewOP();
        }

        private void datOpsStart_ValueChanged(object sender, EventArgs e)
        {
            datOpsEnd.MinDate = datOpsStart.Value.Date;
            SetStartTime();
        }

        private void datOpsEnd_ValueChanged(object sender, EventArgs e)
        {
            SetEndTime();
        }

        private void datStartTime_ValueChanged(object sender, EventArgs e)
        {
            SetStartTime();
        }

        private void datEndTime_ValueChanged(object sender, EventArgs e)
        {
            SetEndTime();
        }

        private void SetStartTime()
        {
            if (!LoadingInProgress)
            {
                DateTime start = datOpsStart.Value.Date;
                start = start.AddHours(datStartTime.Value.Hour).AddMinutes(datStartTime.Value.Minute);
                operationalPeriod.PeriodStart = start;
                _ = ValidateNewOP();
            }
        }
        private void SetEndTime()
        {
            if (!LoadingInProgress)
            {
                DateTime end = datOpsEnd.Value.Date;
                end = end.AddHours(datEndTime.Value.Hour).AddMinutes(datEndTime.Value.Minute);
                operationalPeriod.PeriodEnd = end;
                _ = ValidateNewOP();

            }
        }

        private void cboCurrentOperationalPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildListOfCopyableItems();
        }



        private class IncidentDataItem
        {
            public string DisplayName { get; set; }
            public int ID { get; set; }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowCopyableItems.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox chk = c as CheckBox;
                    chk.Checked = true;
                }
            }
        }

        private void btnCheckNone_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowCopyableItems.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox chk = c as CheckBox;
                    chk.Checked = false;
                }
            }
        }
    }


}
