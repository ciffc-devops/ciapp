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

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationChartAddRoleForm : Form
    {
        private ICSRole _selectedRole = null;
        public ICSRole selectedRole { get => _selectedRole; set { _selectedRole = value;  } }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }

        public OrganizationChartAddRoleForm()
        {
            InitializeComponent();
            

           
        }
        private void OrganizationChartAddRole_Load(object sender, EventArgs e)
        {
            
            DisplayRole();
        }

        private void DisplayRole()
        {
            cboReportsTo.Items.Clear();
            CurrentOrgChart.SortRoles();

            cboReportsTo.DataSource = CurrentOrgChart.AllRoles.Where(o => o.RoleID != selectedRole.RoleID).ToList();
            txtRoleName.Text = selectedRole.RoleName;
            if(selectedRole.ReportsTo != Guid.Empty && CurrentOrgChart.AllRoles.Any(o=>o.RoleID == selectedRole.ReportsTo))
            {
                cboReportsTo.SelectedValue = selectedRole.ReportsTo;
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
                selectedRole.RoleName = txtRoleName.Text.Trim();
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
            if (string.IsNullOrEmpty(txtRoleName.Text)) { txtRoleName.BackColor = Program.ErrorColor; return false; } else { txtRoleName.BackColor = Program.GoodColor; }
            if (cboReportsTo.SelectedItem == null) { cboReportsTo.BackColor = Program.ErrorColor; return false; } else { cboReportsTo.BackColor = Program.GoodColor; }
            return true;
        }

        private void cboReportsTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ICSRole parentRole = (ICSRole)cboReportsTo.SelectedItem;

            if (parentRole != null)
            {
                List<Guid> ChiefIDs = new List<Guid>();
                ChiefIDs.Add(Globals.OpsChiefID); ChiefIDs.Add(Globals.PlanningChiefID); ChiefIDs.Add(Globals.LogisticsChiefID); ChiefIDs.Add(Globals.AdminChiefID); ChiefIDs.Add(Globals.DeputyIncidentCommanderID);


                List<Guid> CommandStaffRoles = new List<Guid>();
                foreach (ICSRole role in CurrentOrgChart.AllRoles.Where(o => o.ReportsTo == Globals.IncidentCommanderID && !ChiefIDs.Contains(o.RoleID)))
                {
                    CommandStaffRoles.Add(role.RoleID);
                }


                splitContainer1.Panel1.BackColor = Color.White;
                if (CommandStaffRoles.Contains(parentRole.RoleID))
                {
                    splitContainer1.Panel1.BackColor = Color.IndianRed;
                }
                else if (parentRole.BranchID == Globals.IncidentCommanderID)
                {
                    splitContainer1.Panel1.BackColor = Color.LimeGreen;
                    //    pnlCommandTeam.BackColor = Color.LimeGreen;
                }
                else if (parentRole.BranchID == Globals.OpsChiefID)
                {
                    splitContainer1.Panel1.BackColor = Color.Orange;
                }
                else if (parentRole.BranchID == Globals.PlanningChiefID)
                {
                    splitContainer1.Panel1.BackColor = Color.CornflowerBlue;
                }
                else if (parentRole.BranchID == Globals.LogisticsChiefID)
                {
                    splitContainer1.Panel1.BackColor = Color.Khaki;
                }
                else if (parentRole.BranchID == Globals.AdminChiefID)
                {
                    splitContainer1.Panel1.BackColor = Color.LightGray;
                }
                else
                {
                    splitContainer1.Panel1.BackColor = Color.White;
                }
            }
        }

        private void cboReportsTo_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem == null)
            {
                if (!string.IsNullOrEmpty(((ComboBox)sender).Text))
                {
                    if (CurrentOrgChart.AllRoles.Any(o => o.RoleName.Equals(((ComboBox)sender).Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        ((ComboBox)sender).SelectedValue = CurrentOrgChart.AllRoles.Where(o => o.RoleName.Equals(((ComboBox)sender).Text, StringComparison.InvariantCultureIgnoreCase)).First().RoleID;
                        //selectedRole.rep = (ICSRole)((ComboBox)sender).SelectedItem;
                        //displaySelectedTeamMember();
                    }
                    else if (CurrentOrgChart.AllRoles.Any(o => o.RoleNameForDropdown.Equals(((ComboBox)sender).Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        ((ComboBox)sender).SelectedValue = CurrentOrgChart.AllRoles.Where(o => o.RoleNameForDropdown.Equals(((ComboBox)sender).Text, StringComparison.InvariantCultureIgnoreCase)).First().RoleID;
                        //selectedRole = (ICSRole)((ComboBox)sender).SelectedItem;


                    }
                    else
                    {
                        ((ComboBox)sender).SelectedIndex = 0;
                        //selectedRole = null;
                        System.Media.SystemSounds.Exclamation.Play();
                        ((ComboBox)sender).Focus();
                    }
                }
                else
                {
                    ((ComboBox)sender).SelectedIndex = 0;
                    //selectedRole = null;
                    //System.Media.SystemSounds.Exclamation.Play();
                    //((ComboBox)sender).Focus();
                }


            }
            //else { selectedRole = (ICSRole)((ComboBox)sender).SelectedItem; }

            if (null != ((ComboBox)sender).SelectedItem)
            {
                //selectedRole = (ICSRole)((ComboBox)sender).SelectedItem;
            }
            else
            {
                ((ComboBox)sender).SelectedIndex = 0;
                //selectedRole = null;
                System.Media.SystemSounds.Exclamation.Play();
                ((ComboBox)sender).Focus();

            }
        }
    }
}
