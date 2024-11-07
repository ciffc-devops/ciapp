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
            dgvResources.BackgroundColor = Program.AccentColor;

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
                    lblResourcesTitle.Text = selectedGroup.ResourceName + " Resources";
                }
                if (Program.CurrentIncident != null) { dgvResources.DataSource = Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.ParentID == role.RoleID && o.OpPeriod == Program.CurrentOpPeriod).ToList(); }
            }
        }

        private void dgvResources_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvResources.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvResources_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResources.Rows.Count > 0 && e.RowIndex <= dgvResources.Rows.Count && dgvResources.Rows[e.RowIndex] != null)
            {


                DataGridViewRow row = dgvResources.Rows[e.RowIndex];
                if(e.RowIndex >= 7)
                {
                    row.Cells["colNumber"].Style.BackColor = Program.ErrorColor;
                } else
                {
                    row.Cells["colNumber"].Style.BackColor = Program.GoodColor;
                }
            }
        }
    }
}
