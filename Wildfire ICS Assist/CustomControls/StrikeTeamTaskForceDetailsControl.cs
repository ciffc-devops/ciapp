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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class StrikeTeamTaskForceDetailsControl : UserControl
    {
        private ICSRole _role = null;
        public ICSRole role { get => _role; set { _role = value; LoadOpGroup(); } }
        OperationalGroup selectedGroup = new OperationalGroup();

        public StrikeTeamTaskForceDetailsControl()
        {
            InitializeComponent();
            dgvSubGroups.AutoGenerateColumns = false; dgvSubGroups.BackgroundColor = Program.FormAccent;

        }

        private void LoadOpGroup()
        {
            if (role != null)
            {
                lblResourcesTitle.Text = role.RoleName + " Resources";

                
                if (Program.CurrentIncident != null && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID))
                {
                    selectedGroup = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID);
                    lblResourcesTitle.Text = selectedGroup.ResourceName + " Resources";
                }
                PopulateSubGroups();
            }
        }


        private void PopulateSubGroups()
        {
            dgvSubGroups.DataSource = null;
            dgvSubGroups.AutoGenerateColumns = false;
            dgvSubGroups.DataSource = Program.CurrentIncident.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == selectedGroup.ID).ToList();
        }

        private void StrikeTeamTaskForceDetailsControl_Load(object sender, EventArgs e)
        {
            LoadOpGroup();
            if (Program.wfIncidentService != null) { Program.wfIncidentService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged; }

        }

        private void Program_OperationalSubGroupChanged(OperationalSubGroupEventArgs e)
        {
            if (e.item.OperationalGroupID == selectedGroup.ID)
            {
                PopulateSubGroups();
            }
        }


        private void btnAddResource_Click(object sender, EventArgs e)
        {
            OperationalSubGroup sub = new OperationalSubGroup();
            sub.OperationalGroupID = selectedGroup.ID;
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
            if (dgvSubGroups.SelectedRows.Count > 0 && MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<OperationalSubGroup> toDelete = new List<OperationalSubGroup>();
                foreach (DataGridViewRow row in dgvSubGroups.SelectedRows)
                {
                    toDelete.Add(row.DataBoundItem as OperationalSubGroup);
                }
                foreach (OperationalSubGroup sub in toDelete) { sub.Active = false; Program.wfIncidentService.UpsertOperationalSubGroup(sub); }
            }
        }

        private void dgvSubGroups_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvSubGroups.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();

        }

        private void dgvSubGroups_SelectionChanged(object sender, EventArgs e)
        {
            btnEditResource.Enabled = dgvSubGroups.SelectedRows.Count == 1;
            btnDeleteResource.Enabled = dgvSubGroups.SelectedRows.Count > 0;
        }
    }
}
