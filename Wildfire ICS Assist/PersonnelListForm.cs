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

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelListForm : Form
    {
        public PersonnelListForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            dgvPersonnel.BackgroundColor = Program.FormAccent;
            dgvTotalByAgency.BackgroundColor = Program.FormAccent;
        }

        private void PersonnelListForm_Load(object sender, EventArgs e)
        {
            BuildDataLists();
            Program.wfIncidentService.MemberSignInChanged += Program_TeamMembersUpdated;
        }

        private void Program_TeamMembersUpdated(MemberEventArgs e)
        {
            BuildDataLists();
        }


        private void BuildDataLists()
        {
            dgvPersonnel.DataSource = null;
            List<MemberStatus> memberStatuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);
            dgvPersonnel.AutoGenerateColumns = false;
            dgvPersonnel.DataSource = memberStatuses;

            dgvTotalByAgency.AutoGenerateColumns = false;
            dgvTotalByAgency.DataSource = null;
            List<AgencyPersonnelCount> agencyCounts = Program.CurrentIncident.GetAgencyPersonnelCount(Program.CurrentOpPeriod);
            dgvTotalByAgency.DataSource = agencyCounts;


        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            using (PersonnelSignInForm signInForm = new PersonnelSignInForm())
            {
                DialogResult dr = signInForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    SignInRecord record = signInForm.signInRecord;
                    record.IsSignIn = true;
                    Program.wfIncidentService.UpsertMemberStatus(record);
                }
            }
        }
    }
}
