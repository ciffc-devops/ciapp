
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
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class TeamAssignmentEditForm : Form
    {
        private TeamAssignment _selectedAssignment = null;
        public TeamAssignment selectedAssignment { get => _selectedAssignment; set { _selectedAssignment = value; LoadAssignment(); } }
        private List<CommsPlanItem> _AvailableCommsPlanItems = new List<CommsPlanItem>();
        private List<ICSRole> OpsRoles = new List<ICSRole>();
        public TeamAssignmentEditForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
           BuildCommsComboboxList();
           PopulateCommsPlanItems();
           BuildPersonnelComboboxList();
            PopulateReportsTo();
        }

        private void LoadAssignment()
        {
            numAssignmentNumber.Value = selectedAssignment.ResourceIDNumber;
            txtBriefSummary.Text = selectedAssignment.BriefSummary;
            txtContact.Text = selectedAssignment.Contact;
            numPersonnelRequired.Value = selectedAssignment.NumberOfPersons;
            editTeamAssignmentTemplateControl1.selectedAssignment = selectedAssignment;
            if(selectedAssignment.ReportsToRoleID != Guid.Empty && OpsRoles.Any(o=>o.RoleID == selectedAssignment.ReportsToRoleID))
            {
                cboReportsTo.SelectedValue = selectedAssignment.ReportsToRoleID;
            }

            int nextFreeComms = 0;
            foreach(Guid g in selectedAssignment.CommsPlanItemIDs)
            {

                if(_AvailableCommsPlanItems.Any(o=>o.ItemID == g)) { CommsComboBoxes[nextFreeComms].SelectedValue = g; nextFreeComms += 1; }
                if(nextFreeComms >= CommsComboBoxes.Count) { break; }
            }
        }

        private void TeamAssignmentEditForm_Load(object sender, EventArgs e)
        {
            LoadTemplateList();
        }

        private void LoadTemplateList()
        {
            List<TeamAssignment> assignments = (List<TeamAssignment>)Program.generalOptionsService.GetOptionsValue("TeamAssignments");
            assignments = assignments.Where(o => o.Active).OrderBy(o => o.ResourceName).ToList();
            cboAssignmentTemplates.DataSource = assignments;
            cboAssignmentTemplates.DisplayMember = "ResourceNameWithType";
            cboAssignmentTemplates.ValueMember = "ID";
        }

        private void PopulateReportsTo()
        {
            OpsRoles.Clear();
            
            OpsRoles.Add(Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == WF_ICS_ClassLibrary.Globals.OpsChiefID));
            OpsRoles.AddRange(Program.CurrentOrgChart.GetChildRoles(Globals.OpsChiefID, true, true));
            cboReportsTo.DataSource = OpsRoles;
            cboReportsTo.DisplayMember = "RoleNameForDropdown";
            cboReportsTo.ValueMember = "RoleID";
        }

        private void PopulateCommsPlanItems()
        {
            _AvailableCommsPlanItems.Clear();
            if (Program.CurrentIncident.hasMeangfulCommsPlan(Program.CurrentOpPeriod)) { _AvailableCommsPlanItems = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpsPeriod == Program.CurrentOpPeriod).ActiveCommsItems; }
            CommsPlanItem blank = new CommsPlanItem();
            blank.ItemID = Guid.Empty;
            _AvailableCommsPlanItems.Insert(0, blank);
            foreach(ComboBox cb in CommsComboBoxes)
            {
                cb.DataSource = new List<CommsPlanItem>(_AvailableCommsPlanItems);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        List<ComboBox> PersonnelComboBoxes = new List<ComboBox>();
        private void BuildPersonnelComboboxList()
        {
            PersonnelComboBoxes.Clear();
            PersonnelComboBoxes.Add(cboPerson1);
            PersonnelComboBoxes.Add(cboPerson2);
            PersonnelComboBoxes.Add(cboPerson3);
            PersonnelComboBoxes.Add(cboPerson4);
            PersonnelComboBoxes.Add(cboPerson5);
            PersonnelComboBoxes.Add(cboPerson6);
            PersonnelComboBoxes.Add(cboPerson7);
            PersonnelComboBoxes.Add(cboPerson8);
            PersonnelComboBoxes.Add(cboPerson9);
            PersonnelComboBoxes.Add(cboPerson10);
            PersonnelComboBoxes.Add(cboPerson11);

        }

        List<ComboBox> CommsComboBoxes = new List<ComboBox>();
        private void BuildCommsComboboxList()
        {
            CommsComboBoxes.Clear();
            CommsComboBoxes.Add(cboComms1);
            CommsComboBoxes.Add(cboComms2);
            CommsComboBoxes.Add(cboComms3);
            CommsComboBoxes.Add(cboComms4);

        }



        private void numPersonnelRequired_ValueChanged(object sender, EventArgs e)
        {
            selectedAssignment.NumberOfPersons = Convert.ToInt32(numPersonnelRequired.Value);
            for(int x = 0; x < PersonnelComboBoxes.Count; x++)
            {
                if ((x + 1) <= selectedAssignment.NumberOfPersons) { PersonnelComboBoxes[x].Enabled = true; }
                else { PersonnelComboBoxes[x].Enabled = false; PersonnelComboBoxes[x].SelectedIndex = -1; }
            }

        }

        private void btnSetToNextAssignmentNumber_Click(object sender, EventArgs e)
        {
            numAssignmentNumber.Value = Program.CurrentIncident.GetNextAssignmentNumber(Program.CurrentOpPeriod);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveAssignment();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveAssignment()
        {
            ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem;

            selectedAssignment.ReportsToRoleID = reportsTo.RoleID;
            selectedAssignment.DivisionName = reportsTo.RoleName;
            if (reportsTo.RoleID != Globals.OpsChiefID) { selectedAssignment.BranchName = Program.CurrentOrgChart.GetRoleByID(reportsTo.ReportsTo, false).RoleName; }
            else { selectedAssignment.BranchName = "Operations"; }
            selectedAssignment.Contact = txtContact.Text;
            selectedAssignment.BriefSummary = txtBriefSummary.Text;
            selectedAssignment.ResourceIDNumber = Convert.ToInt32(numAssignmentNumber.Value);
            selectedAssignment.AssignmentType = editTeamAssignmentTemplateControl1.selectedAssignment.AssignmentType;
            selectedAssignment.ResourceName = editTeamAssignmentTemplateControl1.selectedAssignment.ResourceName;
            selectedAssignment.TacticalAssignment = editTeamAssignmentTemplateControl1.selectedAssignment.TacticalAssignment;
            selectedAssignment.SpecialInstructions = editTeamAssignmentTemplateControl1.selectedAssignment.SpecialInstructions;

            selectedAssignment.CommsPlanItemIDs.Clear();
            foreach (ComboBox cb in CommsComboBoxes)
            {
                if (cb.SelectedItem != null && (cb.SelectedItem as CommsPlanItem).ItemID != Guid.Empty) { selectedAssignment.CommsPlanItemIDs.Add((cb.SelectedItem as CommsPlanItem).ItemID); }
            }

            selectedAssignment.AssignedMemberIDs.Clear();
            foreach (ComboBox cb in PersonnelComboBoxes)
            {
                if (cb.SelectedItem != null && (cb.SelectedItem as TeamMember).PersonID != Guid.Empty) { selectedAssignment.AssignedMemberIDs.Add((cb.SelectedItem as TeamMember).PersonID); }

            }
            if (PersonnelComboBoxes[0].SelectedItem != null)
            {
                TeamMember ld = PersonnelComboBoxes[0].SelectedItem as TeamMember;
                selectedAssignment.LeaderName = ld.Name;
                selectedAssignment.LeaderPersonID = ld.PersonID;
            }

        }

        private bool ValidateForm()
        {
            bool isValid = true;
            int num = Convert.ToInt32(numAssignmentNumber.Value);
            if (!Program.CurrentIncident.AssignmentNumberUniqueAndValid(Program.CurrentOpPeriod, num, selectedAssignment.ID))
            {
               isValid = false; 
            }
            if (string.IsNullOrEmpty(editTeamAssignmentTemplateControl1.selectedAssignment.ResourceName)) { isValid = false; }
           // if (string.IsNullOrEmpty(txtBriefSummary.Text.Trim())) { isValid = false; }



            return isValid;
        }

    
        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveAssignment();
                Program.wfIncidentService.UpsertTeamAssignment(selectedAssignment);
                //print it

                this.DialogResult = DialogResult.Ignore;
                this.Close();
            }
        }

        private void numAssignmentNumber_Leave(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(numAssignmentNumber.Value);
            if (Program.CurrentIncident.AssignmentNumberUniqueAndValid(Program.CurrentOpPeriod, num, selectedAssignment.ID))
            {
                numAssignmentNumber.BackColor = Program.GoodColor;
            }
            else { numAssignmentNumber.BackColor = Program.ErrorColor; }
        }

        private void btnTemplateHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("TeamAssignmentTemplate"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnApplyTemplate_Click(object sender, EventArgs e)
        {
            if(cboAssignmentTemplates.SelectedItem != null)
            {
                TeamAssignment template = (TeamAssignment)cboAssignmentTemplates.SelectedItem;
                editTeamAssignmentTemplateControl1.selectedAssignment.ResourceName = template.ResourceName;
                editTeamAssignmentTemplateControl1.selectedAssignment.AssignmentType = template.AssignmentType;
                editTeamAssignmentTemplateControl1.selectedAssignment.TacticalAssignment = template.TacticalAssignment;
                editTeamAssignmentTemplateControl1.selectedAssignment.SpecialInstructions = template.SpecialInstructions;
                editTeamAssignmentTemplateControl1.selectedAssignment = editTeamAssignmentTemplateControl1.selectedAssignment;
                editTeamAssignmentTemplateControl1.Focus();

            }
        }

        private void txtBriefSummary_TextChanged(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(txtBriefSummary.Text)) { txtBriefSummary.BackColor = Program.ErrorColor; }
            else { txtBriefSummary.BackColor = Program.GoodColor; }
            */
        }
    }
}
