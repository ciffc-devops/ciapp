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
using Wildfire_ICS_Assist.Classes;

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
        static int YellowNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("YellowResourceTimeoutDays"));
        static int RedNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("RedResourceTimeoutDays"));

        private void ResourceReplacementPlanningForm_Load(object sender, EventArgs e)
        {
            cboResourceVariety.SelectedIndex = 0;
            cboReplacementReqdFilter.SelectedIndex = 0;
            cboLastDayAsOf.SelectedIndex = 0;
            datLastDayFilter.Value = DateTime.Now.AddDays(14);
            BuildResourceList(getFilters());

            Program.wfIncidentService.ResourceReplacementChanged += WfIncidentService_ResourceReplacementChanged;
            Program.wfIncidentService.MemberSignInChanged += WfIncidentService_MemberSignInChanged;

            lblLegendNoReplacementNeeded.BackColor = Color.Gray;
            lblLegendReplacementPlanned.BackColor = Program.GoodColor;
            lblLegendResourceYellow.Text = "Resource leaving in " + YellowNumber + " days";
            lblReplacementResourceRed.Text = "Resource leaving in " + RedNumber + " days";

            cboOutgoingOutputInclude.DropDownWidth = cboOutgoingOutputInclude.GetDropDownWidth();
            cboOutgoingOutputFilters.DropDownWidth = cboOutgoingOutputFilters.GetDropDownWidth();
            cboOutgoingOutputFilters.SelectedIndex = 0;
            cboOutgoingOutputInclude.SelectedIndex = 0;

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

        private List<CheckInRecordWithResource> GetResources(ResourceReplacementFilterSettings filters)
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
            if (filters.LastDayIsOrAsOf == 0)
            {
                checkInRecords = checkInRecords.Where(o => o.LastDayOnIncident.Date <= filters.LastDayAsOf.Date && o.LastDayOnIncident.Date >= filters.StillInAsOf.Date).ToList();
            }
            else if (filters.LastDayIsOrAsOf == 1)
            {
                checkInRecords = checkInRecords.Where(o => o.LastDayOnIncident.Date == filters.LastDayAsOf.Date).ToList();
            }

            //get replacement info
            foreach (CheckInRecordWithResource rec in checkInRecords)
            {
                if (Program.CurrentIncident.ActiveResourceReplacementPlans.Any(o => o.ReplacementForCheckInID == rec.Record.SignInRecordID))
                {
                    ResourceReplacementPlan plan = Program.CurrentIncident.ActiveResourceReplacementPlans.First(o => o.ReplacementForCheckInID == rec.Record.SignInRecordID);
                    rec.ReplacementRecordID = plan.ID;
                    rec.ReplacementOrderNumber = plan.OrderNumber;
                    rec.ReplacementResourceName = plan.ResourceName;
                    rec.ReplacementComment = plan.Comments;
                }
                else
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
            return checkInRecords;
        }

        private void BuildResourceList(ResourceReplacementFilterSettings filters)
        {
            List<CheckInRecordWithResource> checkInRecords = GetResources(filters);
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
                    if (item.DaysTillTimeOut <= RedNumber)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (item.DaysTillTimeOut <= YellowNumber)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                    
                    row.DefaultCellStyle.Font = f;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Program.GoodColor;
                    row.DefaultCellStyle.Font = f;

                }
            }
        }
         
        private ResourceReplacementFilterSettings getFilters()
        {
            ResourceReplacementFilterSettings filters = new ResourceReplacementFilterSettings(); 
            filters.StillInAsOf = DateTime.Now; 
            filters.LastDayAsOf = datLastDayFilter.Value;
            filters.ResourceVariety = cboResourceVariety.SelectedIndex;
            filters.ResourceVarietyName = cboResourceVariety.Text;
            filters.LastDayIsOrAsOf = cboLastDayAsOf.SelectedIndex;
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

        private void cboLastDayAsOf_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildResourceList(getFilters());


        }

        private void btnExportSignInToCSV_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "Resource Replacement Planning-" + Program.CurrentIncident.IncidentIdentifier + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";

                ResourceReplacementFilterSettings filters = getFilters();
                if(cboOutgoingOutputFilters.SelectedIndex == 1)
                {
                    filters.ResourceVariety = 0;
                    filters.ResourceVarietyName = "All";
                    filters.ReplacementRequirement = 0;
                }
                
                List<CheckInRecordWithResource> resources = GetResources(filters);
               

                string csv =CheckInTools.ExportOutgoingResources(resources, filters, delimiter);
                try
                {
                    System.IO.File.WriteAllText(exportPath, csv);

                    DialogResult openNow = MessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                    if (openNow == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorry, there was a problem writing to the file.  Please report this error: " + ex.ToString());
                }
            }
        }
    }
}
