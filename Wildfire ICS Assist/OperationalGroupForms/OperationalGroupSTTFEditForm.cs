using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.Properties;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupSTTFEditForm : BaseForm
    {
        private OperationalGroup _SelectedGroup = new OperationalGroup();
        public OperationalGroup SelectedGroup { get => _SelectedGroup; set { _SelectedGroup = value; } }

        public OperationalGroupSTTFEditForm()
        {
            InitializeComponent();
        }

        private void Program_OperationalSubGroupChanged(CrewEventArgs e)
        {
            if(e.item.OperationalGroupID == SelectedGroup.ID)
            {
                PopulateReportingResources();
            }
        }

        private void OperationalGroupSTTFEditForm_Load(object sender, EventArgs e)
        {
            PopulateReportsTo();
            PopulateLeader();
            LoadGroup();
            Program.incidentDataService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
            txtIdentifier.Focus();
        }

        private void LoadGroup()
        {
            if (this.SelectedGroup != null)
            {
                cboType.SelectedIndex = cboType.FindStringExact(SelectedGroup.GroupType);
                txtComments.Text = SelectedGroup.Comments;
                txtContact.Text = SelectedGroup.Contact;
                txtIdentifier.Text = SelectedGroup.Name;

                try { cboReportsTo.SelectedValue = SelectedGroup.ParentID; }
                catch { }
                try { cboSupervisor.SelectedValue = SelectedGroup.LeaderID; }
                catch { }
                PopulateReportingResources();

                if(SelectedGroup.PreparedByRoleID == Guid.Empty)
                {
                    SelectedGroup.SetPreparedBy(Program.CurrentRole);
                    SelectedGroup.DatePrepared = DateTime.Now;
                }
            }
        }

        private void PopulateReportingResources()
        {
            strikeTeamTaskForceDetailsControl1.SetSelectedGroup(SelectedGroup);
        }

        private void PopulateReportsTo()
        {
            List<OperationalGroup> OpGroups = new List<OperationalGroup>(Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.OpPeriod == Program.CurrentOpPeriod));
            OpGroups = OpGroups.Where(o=>o.GroupType != "Task Force" && o.GroupType != "Strike Team").ToList();
            cboReportsTo.DataSource = OpGroups;
            cboReportsTo.ValueMember = "ID";
            cboReportsTo.DisplayMember = "ResourceNameWithDepth";
        }

        private void PopulateLeader()
        {
List<string> LeaderRoleAcronyms = new List<string> { "STLD", "TFLD", "DIVS" };
            List<Personnel> members = Program.CurrentIncident.IncidentPersonnel.OrderByDescending(o=>LeaderRoleAcronyms.Contains(o.InitialRoleAcronym)).ThenBy(o => o.Name).ToList();



            Personnel blank = new Personnel(); blank.PersonID = Guid.Empty; members.Insert(0, blank);

            List<Personnel> mems = new List<Personnel>();
            mems.AddRange(members);
            cboSupervisor.DataSource = mems;
            cboSupervisor.ValueMember = "PersonID";
            cboSupervisor.DisplayMember = "NameWithInitialRoleAcronym";
        }

        private void cboReportsTo_Leave(object sender, EventArgs e)
        {
            if(cboReportsTo.SelectedItem == null) { cboReportsTo.Text = ""; }
            if (cboReportsTo.SelectedItem == null)
            {
                errorProvider1.SetError(cboReportsTo, "You must select who this team reports to");
                cboReportsTo.BackColor = Program.ErrorColor; 
            } else
            {
                errorProvider1.SetError(cboReportsTo, "");
                cboReportsTo.BackColor = Program.GoodColor;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsComplete())
            {
                SaveFormValuesToSelected();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveFormValuesToSelected()
        {
            SelectedGroup.ResourceIdentifier = txtIdentifier.Text;
            SelectedGroup.Name = txtIdentifier.Text;
            SelectedGroup.Contact = txtContact.Text;
            SelectedGroup.GroupType = cboType.Text;
            SelectedGroup.Comments = txtComments.Text;

            SelectedGroup.ResourceListing = strikeTeamTaskForceDetailsControl1.SelectedOpGroup.ResourceListing;

            if (cboSupervisor.SelectedItem != null)
            {
                Personnel sup = (Personnel)cboSupervisor.SelectedItem;
                SelectedGroup.LeaderName = sup.Name;
                SelectedGroup.LeaderID = sup.PersonID;
            }
            else
            {
                SelectedGroup.LeaderName = string.Empty;
                SelectedGroup.LeaderID = Guid.Empty;
            }

            if (cboReportsTo.SelectedItem != null)
            {
                OperationalGroup ParentGroup = (OperationalGroup)cboReportsTo.SelectedItem;
                SelectedGroup.ParentID = ParentGroup.ID;
                SelectedGroup.ParentName = ParentGroup.ResourceName;
            }
        }

        private bool IsComplete()
        {
            if (string.IsNullOrEmpty(txtIdentifier.Text.Trim())) {
                errorProvider1.SetError(txtIdentifier, "You must enter a name for this team");
                txtIdentifier.BackColor = Program.ErrorColor; return false; }
            else { txtIdentifier.BackColor = Program.GoodColor; }

            if (cboReportsTo.SelectedItem == null)
            {
                errorProvider1.SetError(cboReportsTo, "You must select who this team reports to");
                cboReportsTo.BackColor = Program.ErrorColor; return false;
            } 
            return true;
        }

        private void txtIdentifier_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentifier.Text.Trim()))
            {
                errorProvider1.SetError(txtIdentifier, "You must enter a name for this team");
                txtIdentifier.BackColor = Program.ErrorColor; 
            }
            else { txtIdentifier.BackColor = Program.GoodColor; }

        }

        private void btnSetPreparedAndApproved_Click(object sender, EventArgs e)
        {
            SetPreparedAndApprovedForm form = new SetPreparedAndApprovedForm();
            form.SetPreparedBy(SelectedGroup.PreparedByRoleID, SelectedGroup.DatePrepared);
            form.SetApprovedBy(SelectedGroup.ApprovedByRoleID, SelectedGroup.DateApproved);
            DialogResult dr = form.ShowDialog();
            if (dr == DialogResult.OK)
            {
                SelectedGroup.SetPreparedBy(form.PreparedBy); SelectedGroup.DatePrepared = form.DatePrepared;
                SelectedGroup.SetApprovedBy(form.ApprovedBy); SelectedGroup.DateApproved = form.DateApproved;
            }
        }
    }
}
