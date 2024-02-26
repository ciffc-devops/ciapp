using Microsoft.VisualStudio.Experimentation;
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
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;

namespace Wildfire_ICS_Assist
{
    public partial class ResourceReplacementEditForm : Form
    {
        private ResourceReplacementPlan _plan = new ResourceReplacementPlan();

        public ResourceReplacementPlan plan { get => _plan; set { _plan = value; DisplayPlan(); } }
        
        public ResourceReplacementEditForm()
        {
            InitializeComponent(); 
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackground;
            datArrival.Format = DateTimePickerFormat.Custom;
            datArrival.CustomFormat = Program.DateFormat + " HH:mm";
        }


        private void DisplayPlan()
        {
            LoadKindList();
            LoadReplacingList();

            txtName.SetText(plan.ResourceName);
           cboKind.Text = plan.Kind;
            txtAssignment.Text = plan.Assignment;
            if (plan.EstimatedArrival >= datArrival.MinDate && plan.EstimatedArrival <= datArrival.MaxDate) { datArrival.Value = plan.EstimatedArrival; }
            txtHomeArea.Text = plan.HomeArea;
            cboTransportation.Text = plan.Transportation;
            if (plan.ReplacementForCheckInID != Guid.Empty)
            {
                try
                {
                    cboReplacing.SelectedValue = plan.ReplacementForCheckInID;
                }
                catch (Exception)
                {

                }
            }
            
            txtOrder.Text = plan.OrderNumber;
            cboCheckInLocation.Text = plan.CheckInLocation;
            txtComments.Text = plan.Comments;

            if (string.IsNullOrEmpty(plan.ResourceName)) { btnDelete.Visible = false; }


        }

        private void LoadReplacingList()
        {
            List<CheckInRecord> allrecords = new List<CheckInRecord>(Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod));
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();


            foreach (CheckInRecord rec in allrecords)
            {
                IncidentResource resource = new IncidentResource();
                if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                {
                    resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                }

                if (resource != null && resource.ParentResourceID == Guid.Empty)
                {
                    checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    if (Program.CurrentOrgChart.ActiveRoles.Any(o => o.IndividualID == resource.ID))
                    {
                        checkInRecords.Last().Assignment = Program.CurrentOrgChart.ActiveRoles.First(o => o.IndividualID == resource.ID).RoleName;
                    }

                }
            }

            checkInRecords = checkInRecords.Where(o => !Program.CurrentIncident.HasResourceReplacementPlan(o.Record.SignInRecordID, plan.ID)).ToList();


            cboReplacing.DataSource = checkInRecords;
            cboReplacing.ValueMember = "SignInRecordID";
            cboReplacing.DisplayMember = "NameWithAssignment";
        }

        private void LoadKindList()
        {
            List<string> kinds = new List<string>();
            if (Program.CurrentIncident.AllIncidentResources.Any())
            {
                kinds = Program.CurrentIncident.AllIncidentResources.GroupBy(o => o.Kind).Select(o => o.First().Kind).ToList();
            }
            cboKind.DataSource = kinds;
        }
        private void ResourceReplacementEditForm_Load(object sender, EventArgs e)
        {
            foreach (var cb in Controls.OfType<ComboBox>())
            {
                cb.DropDownWidth = cb.GetDropDownWidth();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool proceed = true;
            foreach (var cb in Controls.OfType<TextBoxRequiredControl>())
            {
                if(!cb.IsValid) { proceed = false; break; } 
            }

            if (proceed)
            {
                plan.ResourceName = txtName.Text;
                plan.Kind = cboKind.Text;
                plan.Assignment = txtAssignment.Text;
                plan.EstimatedArrival = datArrival.Value;
                plan.HomeArea = txtHomeArea.Text;
                plan.Transportation = cboTransportation.Text;
                //replacing
                if(cboReplacing.SelectedItem != null)
                {
                    CheckInRecordWithResource replacing = (CheckInRecordWithResource)cboReplacing.SelectedItem;
                    plan.ReplacementForCheckInID = replacing.Record.SignInRecordID;
                    plan.ReplacedResourceName = replacing.Resource.ResourceName;
                }
                plan.OrderNumber = txtOrder.Text;
                plan.CheckInLocation = cboCheckInLocation.Text;
                plan.Comments = txtComments.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                plan.Active = false;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
