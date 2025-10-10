using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.OptionsForms;

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationChartAssignRoleForm : BaseForm
    {
        private ICSRole _selectedRole = null;
        public ICSRole selectedRole { get => _selectedRole; set { _selectedRole = value; DisplayRole(); } }
        List<Personnel> members = null;

        private void DisplayRole()
        {
            /*
            List<Personnel> savedMembers = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = Program.CurrentIncident.getTaskTeamMembers(savedMembers, false, false, Program.CurrentOpPeriod);

            cboSavedMembers.DataSource = members;
            */
            members = Program.CurrentIncident.GetCurrentlySignedInPersonnel(Program.CurrentOpPeriod);
            cboSavedMembers.DataSource = members;
            if(selectedRole.IndividualID != Guid.Empty && members.Any(o=>o.PersonID == selectedRole.IndividualID)) { cboSavedMembers.SelectedValue = selectedRole.IndividualID; }
            lblRoleName.Text = selectedRole.RoleName;
        }
        public OrganizationChartAssignRoleForm()
        {
            InitializeComponent(); 
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OrganizationChartAssignRole_Load(object sender, EventArgs e)
        {
            //editTeamMemberControl1.SetPersonnel(new Personnel());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cboSavedMembers_Leave(object sender, EventArgs e)
        {
            if (cboSavedMembers.SelectedItem == null)
            {
                if (!string.IsNullOrEmpty(cboSavedMembers.Text) && members != null && members.Any())
                {
                    if (members.Any(o => o.Name.Equals(cboSavedMembers.Text, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        cboSavedMembers.SelectedValue = members.Where(o => o.Name.Equals(cboSavedMembers.Text, StringComparison.InvariantCultureIgnoreCase)).First().PersonID;
                        
                        //displaySelectedTeamMember();
                    }
                  
                    else
                    {
                        cboSavedMembers.SelectedIndex = -1;
                        cboSavedMembers.Text = string.Empty;
                    }
                }
                else
                {
                    cboSavedMembers.SelectedIndex = -1;
                    cboSavedMembers.Text = string.Empty;
                    //System.Media.SystemSounds.Exclamation.Play();
                    //cboSavedMembers.Focus();
                }


            }
            

            
        }

        private void btnAssignSaved_Click(object sender, EventArgs e)
        {
            if(cboSavedMembers.SelectedItem!= null)
            {
                Personnel member =(Personnel) cboSavedMembers.SelectedItem;
                selectedRole.IndividualID = member.PersonID;
                //selectedRole.teamMember = member.Clone();
                selectedRole.IndividualName= member.Name;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /*
        private void btnAssignNew_Click(object sender, EventArgs e)
        {
                       if (editTeamMemberControl1.FormValid)
            {
                Personnel member = editTeamMemberControl1.teamMember;

                selectedRole.IndividualID = member.PersonID;
               // selectedRole.teamMember = member.Clone();
                selectedRole.IndividualName = member.Name;

                if (chkSaveForLater.Checked)
                {
                    Program.generalOptionsService.UpserOptionValue(member, "TeamMember");
                }



                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                LgMessageBox.Show(Properties.Resources.MissingInformationValidationError);
            }
        }*/

        

        private void btnClearAssignment_Click(object sender, EventArgs e)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            selectedRole.IndividualID = Guid.Empty;
            //selectedRole.teamMember = blankMember;
            selectedRole.IndividualName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
