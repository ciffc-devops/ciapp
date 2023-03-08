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
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelEnterPersonForm : Form
    {
        private Personnel _selectedPerson = new Personnel();
        public Personnel selectedPerson { get => _selectedPerson; private set => _selectedPerson = value; }

        public PersonnelEnterPersonForm()
        {
            InitializeComponent();
        }

        private void PersonnelEnterPersonForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            cboSavedPersonnel.DataSource = null;
            List<MemberStatus> statuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);

            List<Personnel> members = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = members.Where(o => o.MemberActive).OrderBy(o => o.ProvinceName).ThenBy(o => o.Agency).ThenBy(o => o.Name).ToList();
            members = members.Where(o => !statuses.Any(s => s.MemberID == o.PersonID)).ToList();

            cboSavedPersonnel.DataSource = members;

            personnelEditControl1.SetPersonnel(selectedPerson.Clone());
        }

        private void cboSavedPersonnel_Leave(object sender, EventArgs e)
        {
            if(cboSavedPersonnel.SelectedItem == null) { cboSavedPersonnel.Text = ""; }
        }

        private void btnSelectSavedPerson_Click(object sender, EventArgs e)
        {
            if(cboSavedPersonnel.SelectedItem != null && (cboSavedPersonnel.SelectedItem as Personnel).ID != Guid.Empty)
            {
                selectedPerson = cboSavedPersonnel.SelectedItem as Personnel;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSelectNewPerson_Click(object sender, EventArgs e)
        {
            if (personnelEditControl1.FormValid)
            {
                selectedPerson = personnelEditControl1.teamMember.Clone();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
