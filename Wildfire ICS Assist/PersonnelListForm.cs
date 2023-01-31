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
        }

        private void Program_TeamMembersUpdated(MemberEventArgs e)
        {
            BuildDataLists();
        }


        private void BuildDataLists()
        {



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
                    Program.wfIncidentService.UpsertMemberStatus(record);
                }
            }
        }
    }
}
