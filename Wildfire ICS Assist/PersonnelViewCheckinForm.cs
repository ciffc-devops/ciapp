using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelViewCheckinForm : Form
    {
        private SignInRecord _record = new SignInRecord();
        public SignInRecord record { get => _record; set { _record = value; LoadInfo(); } } 

        public PersonnelViewCheckinForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void Program_StatusChanged(MemberEventArgs e)
        {
            if(e.MemberID == record.MemberID)
            {
                if(Program.CurrentIncident.AllSignInRecords.Any(o=>o.SignInRecordID == record.SignInRecordID))
                {
                    record = Program.CurrentIncident.AllSignInRecords.First(o=>o.SignInRecordID == record.SignInRecordID);
                }
            }
        }
        private void PersonnelViewCheckinForm_Load(object sender, EventArgs e)
        {
            Program.wfIncidentService.MemberSignInChanged += Program_StatusChanged;
            Program.wfIncidentService.TeamAssignmentChanged += Program_AssignmentChanged;
            Program.wfIncidentService.ICSRoleChanged += Program_ICSRoleChanged;
            Program.wfIncidentService.OrganizationalChartChanged += Program_OrgChartChanged;

        }

        private void Program_OrgChartChanged(OrganizationChartEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                LoadInfo();
            }
        }
        private void Program_ICSRoleChanged(ICSRoleEventArgs e)
        {
            if (e.item != null && e.item.OpPeriod == Program.CurrentOpPeriod) { LoadInfo(); }
        }

        private void Program_AssignmentChanged(TeamAssignmentEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            if(record != null)
            {
                //individual
                lblName.Text = record.teamMember.Name;
                lblProvince.Text = record.teamMember.ProvinceName;
                lblAgency.Text = record.teamMember.Agency;
                lblPhone.Text = record.teamMember.Phone.FormatPhone();
                lblEmail.Text = record.teamMember.Email;
                lblHomeBase.Text = record.teamMember.HomeBase;
                lblQualifications.Text = record.teamMember.SpecialSkills;

                //em contact
                lblEmergencyContact.Text = record.teamMember.NOKName;
                lblEmergencyPhone.Text = record.teamMember.NOKPhone.FormatPhone();
                lblEmergencyRelationship.Text = record.teamMember.NOKRelation;

                //assignment
                MemberStatus status = Program.CurrentIncident.getMemberStatus(record.teamMember, Program.CurrentOpPeriod);
                if(status != null) { lblAssignmentOrRole.Text = status.getCurrentActivityName; btnViewAssignmentOrRole.Enabled = status.IsAssigned; }
                else { lblAssignmentOrRole.Text = "Unassigned"; btnViewAssignmentOrRole.Enabled = false; }

                //checkin
                if (record.SignInTime > DateTime.MinValue) { lblCheckInTime.Text = string.Format("{0:" + Program.DateFormat + " HH:mm}", record.SignInTime); }
                else { lblCheckInTime.Text = "TBD"; }

                if (record.LastDayWorked > DateTime.MinValue)
                {
                    lblLDW.Text = string.Format("{0:" + Program.DateFormat + "}", record.LastDayWorked);
                    DateTime opDate = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == Program.CurrentOpPeriod).PeriodEnd;
                    if (opDate != DateTime.MinValue)
                    {
                        TimeSpan ts = record.LastDayWorked - opDate;
                        lblLDW.Text += " (" + ts.TotalDays + " from end of op period)";
                    }
                } else { lblLDW.Text = "TBD"; }
                lblDeparturePoint.Text = record.DeparturePoint;
                lblMethodOfTravel.Text = record.MethodOfTravel;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnViewAssignmentOrRole_Click(object sender, EventArgs e)
        {
            MemberStatus status = Program.CurrentIncident.getMemberStatus(record.teamMember, Program.CurrentOpPeriod);
            if(null != status && status.IsAssigned)
            {
                if(status.ICSRoleID != Guid.Empty)
                {
                    OrganizationChart chart = Program.CurrentOrgChart;

                    if(chart.AllRoles.Any(o=>o.RoleID == status.ICSRoleID))
                    {
                        ICSRole role = chart.AllRoles.First(o => o.RoleID == status.ICSRoleID);
                        HelpInfo info = new HelpInfo(role.RoleName, role.RoleDescription);

                        using (HelpInfoForm help = new HelpInfoForm())
                        {
                            help.Title = info.Title;
                            help.Body = info.Body;
                            help.ShowDialog();
                        }
                    }
                    
                }
                else if (status.AssignmentID != Guid.Empty)
                {
                    if(Program.CurrentIncident.AllAssignments.Any(o=>o.ID == status.AssignmentID))
                    {
                        TeamAssignment ta = Program.CurrentIncident.AllAssignments.First(o => o.ID == status.AssignmentID);
                        OpenAssignmentForEdit(ta);
                    }
                }
            }
        }


        private void OpenAssignmentForEdit(TeamAssignment assignment)
        {
            using (TeamAssignmentEditForm editForm = new TeamAssignmentEditForm())
            {
                editForm.selectedAssignment = assignment;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertTeamAssignment(editForm.selectedAssignment.Clone());
                }
            }
        }


        private void btnEditCheckIn_Click(object sender, EventArgs e)
        {
            List<SignInRecord> records = new List<SignInRecord>();
            records.Add(record);
            using (PersonnelEditCheckInOutForm editForm = new PersonnelEditCheckInOutForm())
            {
                editForm.records = records;
                editForm.ShowDialog();
            }
        }

        private void btnEditIndividual_Click(object sender, EventArgs e)
        {
            using (OptionsForms.EditSavedTeamMemberForm editForm = new OptionsForms.EditSavedTeamMemberForm())
            {
                editForm.selectedMember = record.teamMember;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    record.teamMember = editForm.selectedMember;
                    Program.wfIncidentService.UpsertMemberStatus(record);
                }
            }
        }

       
    }
}
