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
        private OperationalGroup _selectedOpGroup = null;
        public OperationalGroup SelectedOpGroup { get => _selectedOpGroup; set { _selectedOpGroup = value; LoadOpGroup(); } }

        public OperationalGroupReportingResourcesControl()
        {
            InitializeComponent();
            dgvResources.AutoGenerateColumns = false;
            dgvResources.BackgroundColor = Program.AccentColor;
            if (Program.incidentDataService != null)
            {
                Program.incidentDataService.OperationalGroupChanged += IncidentDataService_OperationalGroupChanged;
            }
            
        }

        private void IncidentDataService_OperationalGroupChanged(WF_ICS_ClassLibrary.EventHandling.OperationalGroupEventArgs e)
        {
            if (e.item.ID == SelectedOpGroup.ID) { LoadOpGroup(); }
            if (e.item.ParentID == SelectedOpGroup.ID) { LoadOpGroup(); }
        }

        private void LoadOpGroup()
        {
            if (SelectedOpGroup != null)
            {
                lblResourcesTitle.Text = "Assigned Resources";

                if (Program.CurrentIncident != null)
                {
                    dgvResources.DataSource = Program.CurrentIncident.ActiveOperationalGroups.Where(o => o.ParentID == SelectedOpGroup.ID && o.OpPeriod == Program.CurrentOpPeriod).ToList();
                }
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
