using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist.OperationalPeriodForms
{
    public partial class OperationalPeriodReviewForm : BaseForm
    {
        public OperationalPeriodReviewForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void OperationalPeriodReviewForm_Load(object sender, EventArgs e)
        {
            dgvObjectives.AutoGenerateColumns = false;
            dgvResources.AutoGenerateColumns = false;   
            dgvSummaryStats.AutoGenerateColumns = false;
            LoadOpPeriod();
        }


        private void LoadOpPeriod()
        {
            dgvObjectives.AutoGenerateColumns = false;

            UpdateObjectiveSummary();
            LoadResourcesList();
            BuildSummaryStats();

            Program.incidentDataService.MemberSignInChanged += IncidentDataService_MemberSignInChanged; ;
            Program.incidentDataService.VehicleChanged += IncidentDataService_VehicleChanged; ;
            Program.incidentDataService.OperationalSubGroupChanged += IncidentDataService_OperationalSubGroupChanged; ;
            Program.incidentDataService.CurrentOpPeriodChanged += IncidentDataService_CurrentOpPeriodChanged; ;

            Program.incidentDataService.OrganizationalChartChanged += IncidentDataService_OrganizationalChartChanged; ;
            Program.incidentDataService.ICSRoleChanged += IncidentDataService_ICSRoleChanged; ;
            Program.incidentDataService.IncidentObjectiveChanged += IncidentDataService_IncidentObjectiveChanged; ;
            Program.incidentDataService.IncidentObjectivesSheetChanged += IncidentDataService_IncidentObjectivesSheetChanged; ;

            dgvObjectives.CellValueChanged += dgvObjectives_CellValueChanged;

        }

        private void IncidentDataService_IncidentObjectiveChanged(WF_ICS_ClassLibrary.EventHandling.IncidentObjectiveEventArgs e)
        {
            UpdateObjectiveSummary();
        }

        private void IncidentDataService_IncidentObjectivesSheetChanged(WF_ICS_ClassLibrary.EventHandling.IncidentObjectivesSheetEventArgs e)
        {
            UpdateObjectiveSummary();
        }

        private void IncidentDataService_ICSRoleChanged(WF_ICS_ClassLibrary.EventHandling.ICSRoleEventArgs e)
        {
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void IncidentDataService_OrganizationalChartChanged(WF_ICS_ClassLibrary.EventHandling.OrganizationChartEventArgs e)
        {
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void IncidentDataService_CurrentOpPeriodChanged(WF_ICS_ClassLibrary.EventHandling.IncidentOpPeriodChangedEventArgs e)
        {
            UpdateObjectiveSummary();
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void IncidentDataService_OperationalSubGroupChanged(WF_ICS_ClassLibrary.EventHandling.CrewEventArgs e)
        {
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void IncidentDataService_VehicleChanged(WF_ICS_ClassLibrary.EventHandling.VehicleEventArgs e)
        {
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void IncidentDataService_MemberSignInChanged(WF_ICS_ClassLibrary.EventHandling.CheckInEventArgs e)
        {
            LoadResourcesList();
            BuildSummaryStats();
        }

        private void UpdateObjectiveSummary()
        {
            if (Program.CurrentIncident.AllIncidentObjectiveSheets.Any(o => o.OpPeriod == Program.CurrentOpPeriod) && Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any())
            {
                dgvObjectives.DataSource = Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.OrderBy(o => o.Priority).ThenBy(o => o.Objective).ToList();
            }
        }

        private void dgvObjectives_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObjectives.Columns["colObjectiveCompleted"] != null && e.RowIndex >= 0 && e.ColumnIndex == dgvObjectives.Columns["colObjectiveCompleted"].Index)
            {
                IncidentObjective objective = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;
                if (Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.Any(o => o.ObjectiveID == objective.ObjectiveID))
                {
                    IncidentObjective savedObjective = Program.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == Program.CurrentOpPeriod).ActiveObjectives.First(o => o.ObjectiveID == objective.ObjectiveID);
                    savedObjective.Completed = objective.Completed;
                    Program.incidentDataService.UpsertIncidentObjective(savedObjective);
                }
            }
        }

        #region Resources

        private void LoadResourcesList()
        {

            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            bool showCrewDetails = false;
            DateTime mid = Program.CurrentOpPeriodDetails.PeriodMid;
            if (showCrewDetails)
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }
            else
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod && o.ParentRecordID == Guid.Empty))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null && resource.ParentResourceID == Guid.Empty)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }

            int RedNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("RedResourceTimeoutDays"));
            lblResourceListDetail.Text = "The list above includes all resources with a Last Day On Incident date within the next " + RedNumber + " days.";
            checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();

            DateTime EndOfOp = Program.CurrentOpPeriodDetails.PeriodEnd;
            checkInRecords = checkInRecords.Where(o => o.CheckOutDate == DateTime.MaxValue).ToList();
            checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= RedNumber).ToList();
            dgvResources.DataSource = checkInRecords;
        }

        private void btnPrintDemob_Click(object sender, EventArgs e)
        {
            List<IncidentResource> selectedResources = new List<IncidentResource>();
            foreach (DataGridViewRow row in dgvResources.SelectedRows)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)row.DataBoundItem;
                selectedResources.Add(rec.Resource);
            }

            if (selectedResources.Any())
            {
                List<byte[]> allPDFs = Program.pdfExportService.exportDemobChecklistToPDF(Program.CurrentIncident, selectedResources, false);

                string fullFilepath = "";
                fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

                string fullOutputFilename = "ICS-221 " + Program.CurrentIncident.IncidentNameAndNumberForPath + " " + DateTime.Now.ToString(Globals.DateFormat);
                fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(fullFilepath, fullFile);
                    System.Diagnostics.Process.Start(fullFilepath);
                }
                catch (Exception ex) { MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
            }

        }

        private void dgvResources_SelectionChanged(object sender, EventArgs e)
        {
            btnPrintDemob.Enabled = dgvResources.SelectedRows.Count > 0;
            btnDemob.Enabled = dgvResources.SelectedRows.Count == 1;
        }

        private void btnDemob_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource res = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenDemobForEdit(res);
            }
        }

        private void OpenDemobForEdit(CheckInRecordWithResource res)
        {
            DemobilizationRecord demob = new DemobilizationRecord();
            if (Program.CurrentIncident.ActiveDemobilizationRecords.Any(o => o.SignInRecordID == res.Record.SignInRecordID))
            {
                demob = Program.CurrentIncident.ActiveDemobilizationRecords.First(o => o.SignInRecordID == res.Record.SignInRecordID);
            }
            else
            {
                demob.SignInRecordID = res.Record.SignInRecordID;
                demob.ResourceID = res.Resource.ID;
                demob.DebriefDate = DateTime.Now;
                demob.DemobDate = DateTime.Now;
                demob.OpPeriod = Program.CurrentOpPeriod;

            }

            using (DemobilizeResourceForm demobForm = new DemobilizeResourceForm())
            {
                demobForm.SetRecord(res.Resource, res.Record, demob);
                DialogResult dr = demobForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertDemobRecord(demob);
                }
            }

        }


        #endregion

        #region Summary Stats

        private void BuildSummaryStats()
        {
            List<SummaryStat> allSummaryStats = new List<SummaryStat>();
            allSummaryStats.AddRange(Program.CurrentIncident.GetSummaryPersonHours(Program.CurrentOpPeriod));
            allSummaryStats.AddRange(Program.CurrentIncident.GetSummaryResourceCounts(Program.CurrentOpPeriod));
            allSummaryStats.AddRange((Program.CurrentIncident.GetSummaryPersonnelPerSection(Program.CurrentOpPeriod)));

            dgvSummaryStats.DataSource = null;
            dgvSummaryStats.DataSource = allSummaryStats;
        }



        #endregion

        private void dgvSummaryStats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int colindex = dgvSummaryStats.Columns["colSummaryMoreInfo"].Index;
            if (e.RowIndex >= 0 && e.ColumnIndex == colindex)
            {
                SummaryStat stat = (SummaryStat)dgvSummaryStats.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrEmpty(stat.MoreInfo)) { MessageBox.Show(stat.MoreInfo); }
            }
        }
    }
}
