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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class OperationalGroupReportingResourcesControl : UserControl
    {
        private ICSRole _role = null;
        public ICSRole role { get => _role; set { _role = value; LoadOpGroup(); } }

        public OperationalGroupReportingResourcesControl()
        {
            InitializeComponent();
            dgvResources.AutoGenerateColumns = false;
            dgvResources.BackgroundColor = Program.FormAccent;

        }

        private void LoadOpGroup()
        {
            if (role != null)
            {
                lblResourcesTitle.Text = role.RoleName + " Resources";

                OperationalGroup selectedGroup = new OperationalGroup();
                if (Program.CurrentIncident != null && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID))
                {
                    selectedGroup = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID);
                    lblResourcesTitle.Text = selectedGroup.Name + " Resources";
                }
                if (Program.CurrentIncident != null) { dgvResources.DataSource = Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.ParentID == role.RoleID).ToList(); }
            }
        }

        private void dgvResources_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvResources.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}
