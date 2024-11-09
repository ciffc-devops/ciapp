using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.GeneralModels;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.OptionsForms;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class MedicalPlanForm : BaseForm
    {
        private MedicalPlan CurrentPlan
        {
            get
            {
                Program.CurrentIncident.createMedicalPlanAsNeeded(Program.CurrentOpPeriod);
                return Program.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            }
        }

        public MedicalPlanForm()
        {

            InitializeComponent();
            SetControlColors(this.Controls);

        }

        private void MedicalPlanForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            LoadMedicalPlan();

            Program.incidentDataService.HospitalChanged += Program_HospitalChanged;
            Program.incidentDataService.AmbulanceServiceChanged += Program_AmbulanceChanged;
            Program.incidentDataService.MedicalAidStationChanged += Program_AidStationChanged;
            Program.incidentDataService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OpPeriodChanged;

            ICSFormInformation form = ICSFormTools.GetFormByNumber(206);
            if (form.Fields.Any(o => o.FieldNumber == 4)) { toolTip1.SetToolTip(btnFieldHelp4, form.Fields.First(o => o.FieldNumber == 4).InstructionsWithLineFeed); }
            if (form.Fields.Any(o => o.FieldNumber == 5)) { toolTip1.SetToolTip(btnFieldHelp5, form.Fields.First(o => o.FieldNumber == 5).InstructionsWithLineFeed); }
            if (form.Fields.Any(o => o.FieldNumber == 6)) { toolTip1.SetToolTip(btnFieldHelp6, form.Fields.First(o => o.FieldNumber == 6).InstructionsWithLineFeed); }
            if (form.Fields.Any(o => o.FieldNumber == 7)) { toolTip1.SetToolTip(btnFieldHelp7, form.Fields.First(o => o.FieldNumber == 7).InstructionsWithLineFeed); }
        }


        private void LoadMedicalPlan()
        {
            BuildAidStations();
            BuildAmbulances();
            BuildHospitals();
            txtEmergencyProcedures.Text = CurrentPlan.EmergencyProcedures;
            prepAndApprovePanel1.SetPreparedBy(CurrentPlan.PreparedByRoleID, CurrentPlan.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(CurrentPlan.ApprovedByRoleID, CurrentPlan.DateApproved);

        }

        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            LoadMedicalPlan();

        }


        private void BuildAidStations()
        {
            dgvAidStations.DataSource = null;
            dgvAidStations.AutoGenerateColumns = false;
            dgvAidStations.DataSource = CurrentPlan.ActiveAidStations;
            btnAddAidStation.Enabled = CurrentPlan.ActiveAidStations.Count < 5;
        }

        private void BuildAmbulances()
        {
            dgvTransport.DataSource = null;
            dgvTransport.AutoGenerateColumns = false;
            dgvTransport.DataSource = CurrentPlan.ActiveAmbulances;
            btnAddTransport.Enabled = CurrentPlan.ActiveAmbulances.Count < 5;
        }

        private void BuildHospitals()
        {
            dgvHospitals.DataSource = null;
            dgvHospitals.AutoGenerateColumns = false;
            dgvHospitals.DataSource = CurrentPlan.ActiveHospitals;
            btnAddHospital.Enabled = CurrentPlan.ActiveHospitals.Count < 5;
        }

        private void Program_AidStationChanged(MedicalAidStationEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildAidStations();
            }
        }
        private void Program_AmbulanceChanged(AmbulanceServiceEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildAmbulances();
            }
        }
        private void Program_HospitalChanged(HospitalEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildHospitals();
            }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {

            }
        }


        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddAidStation_Click(object sender, EventArgs e)
        {
            MedicalAidStation station = new MedicalAidStation();
            station.OpPeriod = Program.CurrentOpPeriod;
            OpenAidStationForEdit(station);
        }

        private void OpenAidStationForEdit(MedicalAidStation aidStation)
        {
            using (MedicalPlanEditAidStation editForm = new MedicalPlanEditAidStation())
            {
                editForm.aidStation = aidStation.Clone();
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertMedicalAidStation(editForm.aidStation);
                }
            }
        }

        private void btnEditAidStation_Click(object sender, EventArgs e)
        {
            if (dgvAidStations.SelectedRows.Count == 1)
            {
                MedicalAidStation aid = (MedicalAidStation)dgvAidStations.SelectedRows[0].DataBoundItem;
                OpenAidStationForEdit(aid);
            }
        }

        private void btnDeleteAidStation_Click(object sender, EventArgs e)
        {
            if (dgvAidStations.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<MedicalAidStation> toDelete = new List<MedicalAidStation>();

                foreach (DataGridViewRow row in dgvAidStations.SelectedRows)
                {
                    toDelete.Add((MedicalAidStation)row.DataBoundItem);
                }

                foreach (MedicalAidStation c in toDelete) { c.Active = false; Program.incidentDataService.UpsertMedicalAidStation(c); }
            }
        }

        private void dgvAidStations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MedicalAidStation aid = (MedicalAidStation)dgvAidStations.Rows[e.RowIndex].DataBoundItem;
                OpenAidStationForEdit(aid);
            }
        }

        private void dgvAidStations_SelectionChanged(object sender, EventArgs e)
        {
            btnEditAidStation.Enabled = dgvAidStations.SelectedRows.Count == 1;
            btnDeleteAidStation.Enabled = dgvAidStations.SelectedRows.Count > 0;
        }

        private void txtEmergencyProcedures_TextChanged(object sender, EventArgs e)
        {
            CurrentPlan.EmergencyProcedures = txtEmergencyProcedures.Text.Trim();
        }

        private void btnAddTransport_Click(object sender, EventArgs e)
        {
            using (MedicalPlanMedivacEntryForm entryForm = new MedicalPlanMedivacEntryForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertAmbulance(entryForm.SelectedAmbulance);
                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpsertOptionValue(entryForm.SelectedAmbulance, "Ambulance");

                    }
                }
            }
        }

        private void btnEditTransport_Click(object sender, EventArgs e)
        {
            if (dgvTransport.SelectedRows.Count == 1)
            {
                AmbulanceService amb = (AmbulanceService)dgvTransport.SelectedRows[0].DataBoundItem;
                OpenMedivacForEdit(amb);
            }
        }

        private void OpenMedivacForEdit(AmbulanceService amb)
        {

            using (EditMedivacForm editForm = new EditMedivacForm())
            {
                editForm.selectedAmbulance = amb.Clone();

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertAmbulance(editForm.selectedAmbulance);
                }

            }
        }

        private void dgvTransport_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AmbulanceService am = (AmbulanceService)dgvTransport.Rows[e.RowIndex].DataBoundItem;
                OpenMedivacForEdit(am);
            }
        }

        private void btnDeleteTransport_Click(object sender, EventArgs e)
        {
            if (dgvTransport.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<AmbulanceService> toDelete = new List<AmbulanceService>();

                foreach (DataGridViewRow row in dgvTransport.SelectedRows)
                {
                    toDelete.Add((AmbulanceService)row.DataBoundItem);
                }

                foreach (AmbulanceService c in toDelete) { c.Active = false; Program.incidentDataService.UpsertAmbulance(c); }
            }
        }

        private void dgvTransport_SelectionChanged(object sender, EventArgs e)
        {
            btnEditTransport.Enabled = dgvTransport.SelectedRows.Count == 1;
            btnDeleteTransport.Enabled = dgvTransport.SelectedRows.Count > 0;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MedicalPlan plan = Program.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == Program.CurrentOpPeriod);


            if (plan.PreparedByRoleID == Guid.Empty)
            {
                plan.PreparedByResourceName = Program.CurrentRole.IndividualName;
                plan.PreparedByRoleName = Program.CurrentRole.RoleName;
            }

            string path = Program.pdfExportService.createMedicalPlanPDF(Program.CurrentIncident, Program.CurrentOpPeriod, false, false, false);
            if (!string.IsNullOrEmpty(path))
            {
                try { System.Diagnostics.Process.Start(path); }
                catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }
            }
            else
            {
                MessageBox.Show("Sorry, there was an error generating the contact list.");
            }
        }



        private void btnDeleteHospital_Click(object sender, EventArgs e)
        {
            if (dgvHospitals.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<Hospital> toDelete = new List<Hospital>();

                foreach (DataGridViewRow row in dgvHospitals.SelectedRows)
                {
                    toDelete.Add((Hospital)row.DataBoundItem);
                }

                foreach (Hospital c in toDelete) { c.Active = false; Program.incidentDataService.UpsertHospital(c); }
            }
        }

        private void btnAddHospital_Click(object sender, EventArgs e)
        {
            using (MedicalPlanHospitalEntryForm entryForm = new MedicalPlanHospitalEntryForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    entryForm.selectedHospital.OpPeriod = Program.CurrentOpPeriod;
                    Program.incidentDataService.UpsertHospital(entryForm.selectedHospital);

                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpsertOptionValue(entryForm.selectedHospital, "Hospital");

                    }
                }
            }
        }

        private void btnEditHospital_Click(object sender, EventArgs e)
        {
            if (dgvHospitals.SelectedRows.Count == 1)
            {
                Hospital h = (Hospital)dgvHospitals.SelectedRows[0].DataBoundItem;
                OpenHospitalForEdit(h);
            }
        }

        private void OpenHospitalForEdit(Hospital h)
        {
            using (EditHosptalForm editForm = new EditHosptalForm())
            {
                editForm.selectedHospital = h;
                editForm.ShowTravelTimes = true;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertHospital(editForm.selectedHospital);
                }
            }
        }

        private void dgvHospitals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Hospital h = (Hospital)dgvHospitals.Rows[e.RowIndex].DataBoundItem;
                OpenHospitalForEdit(h);
            }
        }


        private void txtEmergencyProcedures_Leave_1(object sender, EventArgs e)
        {
            Program.incidentDataService.UpsertMedicalPlan(CurrentPlan);

        }

        private void MedicalPlanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.incidentDataService.UpsertMedicalPlan(CurrentPlan);

        }

        private void txtEmergencyProcedures_TextChanged_1(object sender, EventArgs e)
        {
            CurrentPlan.EmergencyProcedures = txtEmergencyProcedures.Text.Trim();

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControlExt.tabControlCustomColor_DrawItem(sender, e);
        }

        private void prepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            CurrentPlan.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
            CurrentPlan.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;

        }

        private void prepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            CurrentPlan.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
            CurrentPlan.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;

        }

        private void btnFormVideo_Click(object sender, EventArgs e)
        {
            ICSFormInformation form = ICSFormTools.GetFormByNumber(206);
            if (form != null && !string.IsNullOrEmpty(form.VideoURL))
            {
                System.Diagnostics.Process.Start(form.VideoURL);
            }
        }

        private void btnFormHelp_Click(object sender, EventArgs e)
        {
            ICSFormHelpForm helpForm = new ICSFormHelpForm();
            helpForm.SelectedForm = ICSFormTools.GetFormByNumber(206);
            helpForm.Show();
        }

        private void btnFieldHelp4_Click(object sender, EventArgs e)
        {
          


        }
    }
}
