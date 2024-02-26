using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Experimentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class ResourceReplacementPlanningForm : Form
    {
        public ResourceReplacementPlanningForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackground;
            dgvOutgoing.BackgroundColor = Program.FormAccent;
            dgvOutgoing.AutoGenerateColumns = false;
            datLastDayFilter.CustomFormat = Program.DateFormat;
            datLastDayFilter.Format = DateTimePickerFormat.Custom;
            colLastDay.DefaultCellStyle.Format = Program.DateFormat;
            colDateRequired.DefaultCellStyle.Format = Program.DateFormat + " HH:mm";
            setWrap();
        }

        private bool CellEditingInProgress = false;

        private void setWrap()
        {
            dgvOutgoing.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True; dgvOutgoing.RowTemplate.MinimumHeight = 30;

            dgvOutgoing.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOutgoing.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOutgoing.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvOutgoing.Columns[12].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void ResourceReplacementPlanningForm_Load(object sender, EventArgs e)
        {
            cboResourceVariety.SelectedIndex = 0;
            cboReplacementReqdFilter.SelectedIndex = 0;
            datLastDayFilter.Value = DateTime.Now.AddDays(14);
            BuildResourceList(getFilters());

            Program.wfIncidentService.ResourceReplacementChanged += WfIncidentService_ResourceReplacementChanged;
            Program.wfIncidentService.MemberSignInChanged += WfIncidentService_MemberSignInChanged;
        }

        private void WfIncidentService_MemberSignInChanged(WF_ICS_ClassLibrary.EventHandling.CheckInEventArgs e)
        {
            if (!CellEditingInProgress)
            {
                BuildResourceList(getFilters());
            }
        }

        private void WfIncidentService_ResourceReplacementChanged(WF_ICS_ClassLibrary.EventHandling.ResourceReplacementPlanEventArgs e)
        {
            if (!CellEditingInProgress)
            {
                BuildResourceList(getFilters());
            }
        }

        private void BuildResourceList(FilterSettings filters)
        {
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            List<CheckInRecord> allRecords = new List<CheckInRecord>(Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod));



            foreach (CheckInRecord rec in allRecords)
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

            if (filters.ReplacementRequirement == 1)
            {
                checkInRecords = checkInRecords.Where(o => o.ReplacementRequired).ToList();
            }
            else if (filters.ReplacementRequirement == 2)
            {
                checkInRecords = checkInRecords.Where(o => o.ReplacementRequired && o.ReplacementRecordID == Guid.Empty).ToList();
            }

            //checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();



            if (filters.ResourceVariety > 0)
            {
                checkInRecords = checkInRecords.Where(o => o.ResourceType.Equals(filters.ResourceVarietyName)).ToList(); ;
            }


            DateTime EndOfOp = Program.CurrentOpPeriodDetails.PeriodEnd;


            //last day as of
            checkInRecords = checkInRecords.Where(o => o.LastDayOnIncident.Date <= filters.LastDayAsOf.Date && o.LastDayOnIncident.Date >= filters.StillInAsOf.Date).ToList();

            //get replacement info
            foreach(CheckInRecordWithResource rec in checkInRecords) { 
                if(Program.CurrentIncident.ActiveResourceReplacementPlans.Any(o=>o.ReplacementForCheckInID == rec.Record.SignInRecordID))
                {
                    ResourceReplacementPlan plan = Program.CurrentIncident.ActiveResourceReplacementPlans.First(o => o.ReplacementForCheckInID == rec.Record.SignInRecordID);
                    rec.ReplacementRecordID = plan.ID;
                    rec.ReplacementOrderNumber = plan.OrderNumber;
                    rec.ReplacementResourceName = plan.ResourceName;
                    rec.ReplacementComment = plan.Comments;
                } else
                {
                    rec.ReplacementRecordID = Guid.Empty;
                    rec.ReplacementOrderNumber = string.Empty;
                    rec.ReplacementResourceName = string.Empty;
                    rec.ReplacementComment = string.Empty;

                }

                if (Program.CurrentOrgChart.ActiveRoles.Any(o => o.IndividualID == rec.Resource.ID))
                {
                    rec.Assignment = Program.CurrentOrgChart.ActiveRoles.First(o => o.IndividualID == rec.Resource.ID).RoleName;
                }
            }
            checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();
            dgvOutgoing.DataSource = checkInRecords;
        }

        private void cboResourceVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildResourceList(getFilters());
        }

        private void datLastDayFilter_ValueChanged(object sender, EventArgs e)
        {
            BuildResourceList(getFilters());
        }

        private void dgvOutgoing_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOutgoing.Rows.Count > 0 && e.RowIndex <= dgvOutgoing.Rows.Count && dgvOutgoing.Rows[e.RowIndex] != null)
            {


                DataGridViewRow row = dgvOutgoing.Rows[e.RowIndex];
                CheckInRecordWithResource item = (CheckInRecordWithResource)row.DataBoundItem;

                Font f = dgvOutgoing.DefaultCellStyle.Font;
                Font fItalic = new Font(f.Name, f.Size, System.Drawing.FontStyle.Italic);

                if (!item.ReplacementRequired)
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.Font = f;
                }
                else if (item.ReplacementRequired && item.ReplacementRecordID == Guid.Empty)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = f;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Program.GoodColor;
                    row.DefaultCellStyle.Font = f;

                }
            }
        }
        private class FilterSettings
        {
            public int ResourceVariety { get; set; } = 0;
            public string ResourceVarietyName { get; set; } = string.Empty;
            public int ReplacementRequirement { get; set; } = 0;
            public DateTime MidPoint { get; set; }
            public DateTime LastDayAsOf { get; set; } //only view resources who will be timing out as of this date (usually 2 weeks from today)
            public DateTime StillInAsOf { get; set; } //Only view resources who are still on incident as of this date (usually today)
        }

        private FilterSettings getFilters()
        {
            FilterSettings filters = new FilterSettings(); 
            filters.StillInAsOf = DateTime.Now; 
            filters.LastDayAsOf = datLastDayFilter.Value;
            filters.ResourceVariety = cboResourceVariety.SelectedIndex;
            filters.ResourceVarietyName = cboResourceVariety.Text;
            filters.ReplacementRequirement = cboReplacementReqdFilter.SelectedIndex ;
            return filters;
        }

        private void cboReplacementReqdFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BuildResourceList(getFilters());

        }

        private void dgvOutgoing_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == colEdit.Index && e.RowIndex >= 0)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvOutgoing.Rows[e.RowIndex].DataBoundItem;

                if (rec.ReplacementRecordID == Guid.Empty || !Program.CurrentIncident.ActiveResourceReplacementPlans.Any(o=>o.ID == rec.ReplacementRecordID))
                {
                    ResourceReplacementPlan plan = new ResourceReplacementPlan();
                    plan.ReplacementForCheckInID = rec.Record.SignInRecordID;
                    plan.ReplacedResourceName = rec.Resource.ResourceName;
                    plan.Assignment = rec.Assignment;
                    plan.EstimatedArrival = rec.DateReplacementRequired;
                    
                    OpenPlanForEdit(plan);
                } else
                {
                    ResourceReplacementPlan plan = Program.CurrentIncident.ActiveResourceReplacementPlans.First(o => o.ID == rec.ReplacementRecordID);
                    OpenPlanForEdit(plan);

                }
            }
        }

        private void OpenPlanForEdit(ResourceReplacementPlan plan)
        {


            using (ResourceReplacementEditForm editForm = new ResourceReplacementEditForm())
            {
                editForm.plan = plan.Clone();
                if(editForm.ShowDialog() == DialogResult.OK)
                {
                    plan = editForm.plan.Clone();
                    Program.wfIncidentService.UpsertResourceReplacementPlan(plan);
                    
                }
            }
        }

        private void dgvOutgoing_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOutgoing.Rows[e.RowIndex] != null && dgvOutgoing.Rows[e.RowIndex].DataBoundItem != null)
            {
                CheckInRecordWithResource row = dgvOutgoing.Rows[e.RowIndex].DataBoundItem as CheckInRecordWithResource;
                CellEditingInProgress = true;
                Program.wfIncidentService.UpsertCheckInRecord(row.Record);

                CellEditingInProgress = false;
            }
        }
    }
}
