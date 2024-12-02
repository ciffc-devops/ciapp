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
using WF_ICS_ClassLibrary;
using System.CodeDom;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using WF_ICS_ClassLibrary.Models.OrganizationalChartModels;

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationChartAddRoleForm : BaseForm
    {
        private ICSRole _selectedRole = null;
        public ICSRole selectedRole { get => _selectedRole; set { _selectedRole = value; } }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }
        public bool RestrictToAirOps { get; set; } = false;
        bool LoadingDone = false;
        public string OperationalGroupName { get => txtOperationalGroupName.Text; }
        public OrganizationChartAddRoleForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);

        }
        private void OrganizationChartAddRole_Load(object sender, EventArgs e)
        {
            this.Size = new Size(464, 240);

            DisplayRole();
            cboNewRoleName.Focus();
        }

        private void DisplayRole()
        {
            cboReportsTo.Items.Clear();
            CurrentOrgChart.SortRoles();



            List<ICSRole> reportsToRoles = new List<ICSRole>();
            if (RestrictToAirOps)
            {
                reportsToRoles.Add(CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.AirOpsDirectorGenericID));
                reportsToRoles.AddRange(CurrentOrgChart.GetChildRoles(Globals.AirOpsDirectorGenericID, true));
            }
            else { reportsToRoles.AddRange(CurrentOrgChart.ActiveRoles); }
            cboReportsTo.DataSource = reportsToRoles;




            if (selectedRole.ReportsTo != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == selectedRole.ReportsTo))
            {
                cboReportsTo.SelectedValue = selectedRole.ReportsTo;
            }

            if (string.IsNullOrEmpty(selectedRole.RoleName)) { lblTitle.Text = Properties.Resources.AddOrgChartRole; }
            else { lblTitle.Text = "Edit " + selectedRole.RoleName; }
            cboReportsTo.Enabled = selectedRole.AllowEditReportsTo;
            if (!selectedRole.AllowEditReportsTo)
            {
                toolTip1.SetToolTip(cboReportsTo, Properties.Resources.ProtectedRole);
            }

            if (!string.IsNullOrEmpty(selectedRole.RoleName))
            {
                ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem;
                if (reportsTo != null)
                {
                    List<GenericICSRole> branchRoles = OrganizationalChartTools.GetGenericICSRoles(reportsTo.SectionID).OrderBy(o => o.RoleName).ToList();
                    if (branchRoles.Any(o => o.GenericRoleID == selectedRole.GenericRoleID))
                    {
                        cboNewRoleName.SelectedValue = selectedRole.GenericRoleID;
                    }
                }
            }

            ToggleOpGroupName();
            LoadingDone = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                GenericICSRole selectedName = (GenericICSRole)cboNewRoleName.SelectedItem;
                ICSRole rep = (ICSRole)cboReportsTo.SelectedItem;
                selectedRole.ReportsTo = rep.RoleID;
                selectedRole.ReportsToRoleName = rep.RoleName;
                selectedRole.SectionID = rep.SectionID;
                selectedRole.Depth = rep.Depth + 1;
                /*
                selectedRole.BaseRoleName = selectedName.RoleName;
                selectedRole.RoleNameWithPlaceholder = selectedName.RoleNameWithPlaceholder;
                selectedRole.MnemonicAbrv = selectedName.MnemonicAbrv;
                selectedRole.RoleDescription = selectedName.RoleDescription;
                
                selectedRole.RequiresOperationalGroup = selectedName.RequiresOperationalGroup;
                selectedRole.GenericRoleID = selectedName.GenericRoleID;
                */

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private bool ValidateForm()
        {
            //if (cboNewRoleName.SelectedItem == null) { cboNewRoleName.BackColor = Program.ErrorColor; return false; } else { cboNewRoleName.BackColor = Program.GoodColor; }
            //if (cboReportsTo.SelectedItem == null) { cboReportsTo.BackColor = Program.ErrorColor; return false; } else { cboReportsTo.BackColor = Program.GoodColor; }
            if (((ICSRole)cboReportsTo.SelectedItem).RoleID == selectedRole.RoleID) { cboReportsTo.BackColor = Program.ErrorColor; MessageBox.Show(Properties.Resources.CantReportToSelf); return false; }

            //When editing an existing role, don't let it make its own subordinate its parent
            if (CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == selectedRole.RoleID))
            {
                List<ICSRole> childRoles = CurrentOrgChart.GetChildRoles(selectedRole.RoleID, true);
                ICSRole rep = (ICSRole)cboReportsTo.SelectedItem;
                if (childRoles.Any(o => o.RoleID == rep.RoleID))
                {
                    MessageBox.Show(Properties.Resources.InvalidReportsToRole);
                    cboReportsTo.BackColor = Program.ErrorColor;
                    return false;
                }
            }

            if(selectedRole.RequiresOperationalGroup && !txtOperationalGroupName.IsValid && selectedRole.OperationalGroupID == Guid.Empty)
            {
                return false;
            }
            return true;
        }

        private void cboReportsTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICSRole parentRole = (ICSRole)cboReportsTo.SelectedItem;

            if (parentRole != null)
            {
                //update the list of role names based on the currently selected branch.
                Guid BranchID = parentRole.SectionID;
                List<GenericICSRole> branchRoles = OrganizationalChartTools.GenericRolesCache.Where(o => o.SectionID == BranchID || o.SectionID == Guid.Empty).OrderBy(o => o.RoleName).ToList();
                cboNewRoleName.DataSource = null;
                cboNewRoleName.DataSource = branchRoles;
                cboNewRoleName.DisplayMember = "RoleName";
                cboNewRoleName.ValueMember = "GenericRoleID";

                /* beleive it or not, this is all for colouring */
                List<Guid> ChiefIDs = new List<Guid>();
                ChiefIDs.Add(Globals.OpsChiefGenericID); ChiefIDs.Add(Globals.PlanningChiefGenericID); ChiefIDs.Add(Globals.LogisticsChiefGenericID); ChiefIDs.Add(Globals.FinanceChiefGenericID); ChiefIDs.Add(Globals.DeputyIncidentCommanderGenericID);
                List<Guid> CommandStaffRoles = new List<Guid>();
                foreach (ICSRole role in CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == Globals.IncidentCommanderGenericID && !ChiefIDs.Contains(o.RoleID))) { CommandStaffRoles.Add(role.RoleID); }
                splitContainer1.Panel1.BackColor = Color.White;
                if (CommandStaffRoles.Contains(parentRole.RoleID)) { splitContainer1.Panel1.BackColor = Color.IndianRed; }
                else if (parentRole.SectionID == Globals.IncidentCommanderGenericID) { splitContainer1.Panel1.BackColor = Color.LimeGreen; }
                else if (parentRole.SectionID == Globals.OpsChiefGenericID) { splitContainer1.Panel1.BackColor = Color.Orange; }
                else if (parentRole.SectionID == Globals.PlanningChiefGenericID) { splitContainer1.Panel1.BackColor = Color.CornflowerBlue; }
                else if (parentRole.SectionID == Globals.LogisticsChiefGenericID) { splitContainer1.Panel1.BackColor = Color.Khaki; }
                else if (parentRole.SectionID == Globals.FinanceChiefGenericID) { splitContainer1.Panel1.BackColor = Color.LightGray; }
                else { splitContainer1.Panel1.BackColor = Color.White; }
            }
        }

        private void cboReportsTo_Leave(object sender, EventArgs e)
        {

        }

        private void cboNewRoleName_Leave(object sender, EventArgs e)
        {
            if (cboNewRoleName.SelectedItem == null)
            {
                cboNewRoleName.SelectedIndex = -1;
                cboNewRoleName.Text = string.Empty;
                cboNewRoleName.Focus();
                System.Media.SystemSounds.Exclamation.Play();

            }
            else { selectedRole.FillFromGenericRole((GenericICSRole)cboNewRoleName.SelectedItem); }
            ToggleOpGroupName();

        }

        private void ToggleOpGroupName()
        {
            if (selectedRole.RequiresOperationalGroup )
            {
                this.Size = new Size(464, 302);
                splitContainer2.Panel2Collapsed = false;
                splitContainer2.SplitterDistance = 119;
                txtOperationalGroupName.Width = this.Size.Width - 30;
                if (selectedRole.OperationalGroupID != Guid.Empty && Program.CurrentIncident.AllOperationalGroups.Any(o => o.ID == selectedRole.OperationalGroupID))
                {

                    txtOperationalGroupName.SetText(Program.CurrentIncident.AllOperationalGroups.FirstOrDefault(o => o.ID == selectedRole.OperationalGroupID).Name);
                    txtOperationalGroupName.Enabled = selectedRole.AllowEditName;

                }
                else
                {
                    switch (selectedRole.MnemonicAbrv)
                    {
                        case "AOBD": lblOperationalGroupTypeName.Text = "Branch Name"; txtOperationalGroupName.SetText("Air Operations"); txtOperationalGroupName.Enabled = false; break;
                        case "ASGS": lblOperationalGroupTypeName.Text = "Group Name"; txtOperationalGroupName.SetText("Air Support"); txtOperationalGroupName.Enabled = false; break;
                        case "ATGS": lblOperationalGroupTypeName.Text = "Group Name"; txtOperationalGroupName.SetText("Air Tactical"); txtOperationalGroupName.Enabled = false; break;
                        case "DIVS": lblOperationalGroupTypeName.Text = "Division Name"; txtOperationalGroupName.SetText(""); txtOperationalGroupName.Enabled = true; break;
                        case "HEBD": lblOperationalGroupTypeName.Text = "Branch Name"; txtOperationalGroupName.SetText("Heavy Equipment"); txtOperationalGroupName.Enabled = false; break;
                        case "HEGS": lblOperationalGroupTypeName.Text = "Group Name"; txtOperationalGroupName.SetText("Heavy Equipment"); txtOperationalGroupName.Enabled = false; break;
                        case "OPBD": lblOperationalGroupTypeName.Text = "Branch Name"; txtOperationalGroupName.SetText(""); txtOperationalGroupName.Enabled = true; break;
                        case "STLD": lblOperationalGroupTypeName.Text = "Strike Team Name"; txtOperationalGroupName.SetText(""); txtOperationalGroupName.Enabled = true; break;
                        case "TFLD": lblOperationalGroupTypeName.Text = "Task Force Name"; txtOperationalGroupName.SetText(""); txtOperationalGroupName.Enabled = true; break;
                        case "":
                            lblOperationalGroupTypeName.Text = "Group Name"; txtOperationalGroupName.Enabled = true;

                            break;

                    }
                }
            }

            else
            {
                this.Size = new Size(464, 240);
                splitContainer2.Panel2Collapsed = true;


            }
        }

        private void cboNewRoleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LoadingDone && cboNewRoleName.SelectedItem != null)
            {
                selectedRole.FillFromGenericRole((GenericICSRole)cboNewRoleName.SelectedItem);
            }
            ToggleOpGroupName();
        }

        private void txtOperationalGroupName_Load(object sender, EventArgs e)
        {

        }
    }
}
