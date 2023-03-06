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
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupSTTFEditForm : Form
    {
        private OperationalGroup _SelectedGroup = new OperationalGroup();
        public OperationalGroup SelectedGroup { get => _SelectedGroup; set { _SelectedGroup = value; } }

        public OperationalGroupSTTFEditForm()
        {
            this.Icon = Program.programIcon; InitializeComponent(); this.BackColor = Program.FormBackground;
            dgvSubGroups.AutoGenerateColumns = false; dgvSubGroups.BackgroundColor = Program.FormAccent;
        }

        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            if(e.item.OperationalGroupID == SelectedGroup.ID)
            {
                PopulateSubGroups();
            }
        }

        private void OperationalGroupSTTFEditForm_Load(object sender, EventArgs e)
        {
            PopulateReportsTo();
            PopulateLeader();
            LoadGroup();
            Program.wfIncidentService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
        }

        private void LoadGroup()
        {
            if (this.SelectedGroup != null)
            {
                cboType.SelectedIndex = cboType.FindStringExact(SelectedGroup.GroupType);
                txtComments.Text = SelectedGroup.Comments;
                txtContact.Text = SelectedGroup.Contact;
                txtIdentifier.Text = SelectedGroup.ResourceIdentifier;

                try { cboReportsTo.SelectedValue = SelectedGroup.ParentID; }
                catch { }
                try { cboSupervisor.SelectedValue = SelectedGroup.LeaderID; }
                catch { }
                PopulateSubGroups();
            }
        }

        private void PopulateSubGroups()
        {
            dgvSubGroups.DataSource = null;
            dgvSubGroups.AutoGenerateColumns = false;
            dgvSubGroups.DataSource = Program.CurrentIncident.ActiveOperationalSubGroups.Where(o=>o.OperationalGroupID == SelectedGroup.ID).ToList();
        }

        private void PopulateReportsTo()
        {
            List<ICSRole> OpsRoles = new List<ICSRole>();

            OpsRoles.Clear();

            OpsRoles.Add(Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == WF_ICS_ClassLibrary.Globals.OpsChiefID && o.IsOpGroupSup));
            OpsRoles.AddRange(Program.CurrentOrgChart.GetChildRoles(Globals.OpsChiefID, true, true));
            OpsRoles = OpsRoles.Where(o=>o.IsOpGroupSup && !o.IsTFST).ToList();
            cboReportsTo.DataSource = OpsRoles;
            cboReportsTo.DisplayMember = "RoleNameForDropdown";
            cboReportsTo.ValueMember = "RoleID";
        }

        private void PopulateLeader()
        {
            List<Personnel> members = Program.CurrentIncident.TaskTeamMembers.OrderBy(o => o.Name).ToList();
            Personnel blank = new Personnel(); blank.PersonID = Guid.Empty; members.Insert(0, blank);

            List<Personnel> mems = new List<Personnel>();
            mems.AddRange(members);
            cboSupervisor.DataSource = mems;
            cboSupervisor.ValueMember = "PersonID";
            cboSupervisor.DisplayMember = "Name";
        }

        private void cboReportsTo_Leave(object sender, EventArgs e)
        {
            if(cboReportsTo.SelectedItem == null) { cboReportsTo.Text = ""; }
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
                ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem;

                SelectedGroup.ParentID = reportsTo.RoleID;
                if (reportsTo.OperationalGroupID != Guid.Empty && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.ID == reportsTo.OperationalGroupID))
                {
                    OperationalGroup gr = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.ID == reportsTo.OperationalGroupID);
                    SelectedGroup.ParentName = gr.ResourceName;
                }
                else { SelectedGroup.ParentName = reportsTo.RoleName; }

            }
        }

        private bool IsComplete()
        {
            if (string.IsNullOrEmpty(txtIdentifier.Text.Trim())) { txtIdentifier.BackColor = Program.ErrorColor; return false; }
            else { txtIdentifier.BackColor = Program.GoodColor; }
            return true;
        }

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            OperationalSubGroup sub = new OperationalSubGroup();
            sub.OperationalGroupID = SelectedGroup.ID;
            OpenResourceForEdit(sub);
        }

        private void OpenResourceForEdit(OperationalSubGroup sub)
        {
            if (sub != null)
            {
                using (OperationalGroupEditResourceForm form = new OperationalGroupEditResourceForm())
                {
                    form.subGroup = sub;

                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        OperationalSubGroup grp = form.subGroup;
                        Program.wfIncidentService.UpsertOperationalSubGroup(grp);
                    }
                }
            }
        }

        private void dgvSubGroups_SelectionChanged(object sender, EventArgs e)
        {
            btnDeleteResource.Enabled = dgvSubGroups.SelectedRows.Count > 0;
            btnEditResource.Enabled = dgvSubGroups.SelectedRows.Count == 1;
        }

        private void btnEditResource_Click(object sender, EventArgs e)
        {
            if (dgvSubGroups.SelectedRows.Count == 1)
            {
                OperationalSubGroup sub = dgvSubGroups.SelectedRows[0].DataBoundItem as OperationalSubGroup;
                OpenResourceForEdit(sub);
            }
        }

        private void btnDeleteResource_Click(object sender, EventArgs e)
        {
            if(dgvSubGroups.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalSubGroup> toDelete = new List<OperationalSubGroup>();
                foreach(DataGridViewRow row in dgvSubGroups.SelectedRows)
                {
                    toDelete.Add(row.DataBoundItem as OperationalSubGroup);
                }
                foreach (OperationalSubGroup sub in toDelete) { sub.Active = false; Program.wfIncidentService.UpsertOperationalSubGroup(sub); }
            }
        }
    }
}
