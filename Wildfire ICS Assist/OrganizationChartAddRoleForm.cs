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

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationChartAddRoleForm : Form
    {
        private ICSRole _selectedRole = null;
        public ICSRole selectedRole { get => _selectedRole; set { _selectedRole = value;  } }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }
        public bool RestrictToAirOps { get; set; } = false;

        public OrganizationChartAddRoleForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
            

           
        }
        private void OrganizationChartAddRole_Load(object sender, EventArgs e)
        {
            
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
                reportsToRoles.Add(CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.AirOpsDirector));
                reportsToRoles.AddRange(CurrentOrgChart.GetChildRoles(Globals.AirOpsDirector, true));
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
                ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem; if (reportsTo != null)
                {
                    List<ICSRole> branchRoles = OrgChartTools.staticRoles.Where(o => o.BranchID == reportsTo.BranchID || o.BranchID == Guid.Empty).OrderBy(o => o.RoleName).ToList();
                    if(branchRoles.Any(o=>o.RoleName.Equals(selectedRole.RoleName, StringComparison.OrdinalIgnoreCase)))
                    {
                        cboNewRoleName.SelectedValue = branchRoles.First(o => o.RoleName.Equals(selectedRole.RoleName, StringComparison.OrdinalIgnoreCase)).RoleID;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ICSRole selectedName = (ICSRole)cboNewRoleName.SelectedItem;

                selectedRole.RoleName = selectedName.RoleName;
                selectedRole.BaseRoleName= selectedName.BaseRoleName;
                selectedRole.IncludeReportsToInName= selectedName.IncludeReportsToInName;
                selectedRole.Mnemonic = selectedName.Mnemonic;
                selectedRole.RoleDescription = selectedName.RoleDescription;
                ICSRole rep = (ICSRole)cboReportsTo.SelectedItem;
                selectedRole.ReportsTo = rep.RoleID;
                selectedRole.ReportsToRoleName = rep.RoleName;
                selectedRole.BranchID = rep.BranchID;
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 

        }

        private bool ValidateForm()
        {
            if (cboNewRoleName.SelectedItem == null) { cboNewRoleName.BackColor = Program.ErrorColor; return false; } else { cboNewRoleName.BackColor = Program.GoodColor; }
            if (cboReportsTo.SelectedItem == null) { cboReportsTo.BackColor = Program.ErrorColor; return false; } else { cboReportsTo.BackColor = Program.GoodColor; }
            if(((ICSRole)cboReportsTo.SelectedItem).RoleID == selectedRole.RoleID) { cboReportsTo.BackColor = Program.ErrorColor; MessageBox.Show(Properties.Resources.CantReportToSelf); return false; }

            //When editing an existing role, don't let it make its own subordinate its parent
            if (CurrentOrgChart.ActiveRoles.Any(o=>o.RoleID == selectedRole.RoleID)) {
                List<ICSRole> childRoles = CurrentOrgChart.GetChildRoles(selectedRole.RoleID, true);
                ICSRole rep = (ICSRole)cboReportsTo.SelectedItem;
                if(childRoles.Any(o=>o.RoleID == rep.RoleID))
                {
                    MessageBox.Show(Properties.Resources.InvalidReportsToRole);
                    cboReportsTo.BackColor = Program.ErrorColor;
                    return false;
                }
            }
            return true;
        }

        private void cboReportsTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICSRole parentRole = (ICSRole)cboReportsTo.SelectedItem;

            if (parentRole != null)
            {
                //update the list of role names based on the currently selected branch.
                Guid BranchID = parentRole.BranchID;
                List<ICSRole> branchRoles = OrgChartTools.staticRoles.Where(o=>o.BranchID == BranchID || o.BranchID == Guid.Empty).OrderBy(o=>o.RoleName).ToList();
                cboNewRoleName.DataSource = null;
                cboNewRoleName.DataSource = branchRoles;
                cboNewRoleName.DisplayMember = "RoleName";
                cboNewRoleName.ValueMember = "RoleID";

                /* beleive it or not, this is all for colouring */
                List<Guid> ChiefIDs = new List<Guid>();
                ChiefIDs.Add(Globals.OpsChiefID); ChiefIDs.Add(Globals.PlanningChiefID); ChiefIDs.Add(Globals.LogisticsChiefID); ChiefIDs.Add(Globals.FinanceChiefID); ChiefIDs.Add(Globals.DeputyIncidentCommanderID);
                List<Guid> CommandStaffRoles = new List<Guid>();
                foreach (ICSRole role in CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == Globals.IncidentCommanderID && !ChiefIDs.Contains(o.RoleID)))                {                    CommandStaffRoles.Add(role.RoleID);                }
                splitContainer1.Panel1.BackColor = Color.White;
                if (CommandStaffRoles.Contains(parentRole.RoleID)) { splitContainer1.Panel1.BackColor = Color.IndianRed; }
                else if (parentRole.BranchID == Globals.IncidentCommanderID) { splitContainer1.Panel1.BackColor = Color.LimeGreen; }
                else if (parentRole.BranchID == Globals.OpsChiefID) { splitContainer1.Panel1.BackColor = Color.Orange; }
                else if (parentRole.BranchID == Globals.PlanningChiefID) { splitContainer1.Panel1.BackColor = Color.CornflowerBlue; }
                else if (parentRole.BranchID == Globals.LogisticsChiefID) { splitContainer1.Panel1.BackColor = Color.Khaki; }
                else if (parentRole.BranchID == Globals.FinanceChiefID) { splitContainer1.Panel1.BackColor = Color.LightGray; }
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
        }
    }
}
