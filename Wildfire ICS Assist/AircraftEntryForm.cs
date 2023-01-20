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
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class AircraftEntryForm : Form
    {
        private Aircraft _selectedAircraft = null;
        public Aircraft selectedAircraft { get => _selectedAircraft; set { _selectedAircraft = value; editAircraftControl1.selectedAircraft = value; } }
        public bool SaveForLater { get => chkSaveForLater.Checked; }
        private List<Aircraft> savedAircraft = null;

        public AircraftEntryForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMedivacHelpNew_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("AircraftIsMedivac"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem != null)
            {
                selectedAircraft = ((Aircraft)cboSaved.SelectedItem).Clone();
                selectedAircraft.OpPeriod = Program.CurrentOpPeriod;
                selectedAircraft.Pilot = txtSavedPilot.Text;
                selectedAircraft.StartTime = datSavedStart.Value;
                selectedAircraft.IsMedivac = chkSavedIsMedivac.Checked;
                selectedAircraft.EndTime = datNewEnd.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();

            } else
            {
                cboSaved.Focus();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if(editAircraftControl1.IsValid)
            {
                selectedAircraft = editAircraftControl1.selectedAircraft;
                selectedAircraft.OpPeriod = Program.CurrentOpPeriod;
                selectedAircraft.Pilot = txtNewPilot.Text;
                selectedAircraft.IsMedivac = chkNewIsMedivac.Checked;
                selectedAircraft.StartTime = datNewStart.Value;
                selectedAircraft.EndTime = datNewEnd.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cboSaved_Leave(object sender, EventArgs e)
        {
            if (cboSaved.SelectedItem == null) { cboSaved.Text = ""; }
        }

        private void AircraftEntryForm_Load(object sender, EventArgs e)
        {
            savedAircraft = Program.generalOptionsService.GetOptionsValue("Aircrafts") as List<Aircraft>;
            savedAircraft = savedAircraft.Where(o => o.Active).ToList();
            cboSaved.DataSource = savedAircraft;
            cboSaved.DisplayMember = "RegAndMakeModel";
            cboSaved.ValueMember= "ID";

            OperationalPeriod op = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod);
            datNewEnd.Value = op.PeriodEnd;
            datNewStart.Value = op.PeriodStart;
            datSavedStart.Value = op.PeriodStart;
            datSavedEnd.Value = op.PeriodEnd;
        }
    }
}
