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
using Wildfire_ICS_Assist.Classes;


namespace Wildfire_ICS_Assist.OperationalPeriodForms
{
    public partial class CreateOperationalPeriodForm : BaseForm
    {

        OperationalPeriod _operationalPeriod = new OperationalPeriod();
        public OperationalPeriod operationalPeriod { get => _operationalPeriod; set => _operationalPeriod = value; }
        public bool SwitchToNewOpNow { get => chkSwitchNow.Checked; }
        public CreateOperationalPeriodForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }
        private void CreateOperationalPeriodForm_Load(object sender, EventArgs e)
        {
            numOpPeriod.Value = operationalPeriod.PeriodNumber;
            datOpsStart.Value = operationalPeriod.PeriodStart;
            datOpsEnd.Value = operationalPeriod.PeriodEnd;
            datStartTime.Value = operationalPeriod.PeriodStart;
            datEndTime.Value = operationalPeriod.PeriodEnd;

            BuildOpPeriodComboBox();
            //numOpPeriod.Minimum = lowestUnusedOpNumber;
        }


        private void BuildOpPeriodComboBox()
        {
            cboCurrentOperationalPeriod.DisplayMember = "DisplayName";
            cboCurrentOperationalPeriod.ValueMember = "PeriodNumber";

            List<OperationalPeriod> periods = Program.CurrentIncident.AllOperationalPeriods.Where(o => o.Active && o.ID != operationalPeriod.ID).OrderBy(o => o.PeriodStart).ToList();
            cboCurrentOperationalPeriod.DataSource = periods;
            cboCurrentOperationalPeriod.DropDownWidth = cboCurrentOperationalPeriod.GetDropDownWidth();
        }


        private void btnCreateOpPeriod_Click(object sender, EventArgs e)
        {
            if (ValidateNewOP())
            {

                Program.incidentDataService.UpsertOperationalPeriod(operationalPeriod);
                //copy stuff over







                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateNewOP()
        {
            bool opGood = true;

            StringBuilder errs = new StringBuilder();

            //period number must be unique
            if(Program.CurrentIncident.AllOperationalPeriods.Any(o => o.Active && o.PeriodNumber == numOpPeriod.Value))
            {
                errs.AppendLine("Operational Period Number already in use.");
                opGood = false;
                errorProvider1.SetError(numOpPeriod, "Operational Period Number already in use.");
            } else {  errorProvider1.SetError(numOpPeriod, ""); }


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

            return opGood;
        }

        private void numOpPeriod_ValueChanged(object sender, EventArgs e)
        {
            operationalPeriod.PeriodNumber = (int)numOpPeriod.Value;
            ValidateNewOP();
        }

        private void datOpsStart_ValueChanged(object sender, EventArgs e)
        {
            datOpsEnd.MinDate = datOpsStart.Value;
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
            DateTime start = datOpsStart.Value.Date;
            start = start.AddHours(datStartTime.Value.Hour).AddMinutes(datStartTime.Value.Minute);
            operationalPeriod.PeriodStart = start;
            ValidateNewOP();
        }
        private void SetEndTime()
        {
            DateTime end = datOpsEnd.Value.Date;
            end = end.AddHours(datEndTime.Value.Hour).AddMinutes(datEndTime.Value.Minute);
            operationalPeriod.PeriodEnd = end;
            ValidateNewOP();
        }

    
    }
}
