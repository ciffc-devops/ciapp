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
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;

namespace Wildfire_ICS_Assist.IncidentStatusSummaryForms
{
    public partial class IncidentStatusSummaryListForm : BaseForm
    {
        public IncidentStatusSummaryListForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);

            dgvSummaries.AutoGenerateColumns = false;
            Program.incidentDataService.IncidentSummaryChanged += IncidentDataService_IncidentSummaryChanged;
        }

        private void IncidentDataService_IncidentSummaryChanged(WF_ICS_ClassLibrary.EventHandling.IncidentSummaryEventArgs e)
        {
            dgvSummaries.DataSource = Program.CurrentIncident.ActiveIncidentStatusSummaries.OrderBy(o => o.ReportFromTimePeriod).ToList();
        }

        private void IncidentStatusSummaryListForm_Load(object sender, EventArgs e)
        {
            dgvSummaries.Columns["colFrom"].DefaultCellStyle.Format = Globals.DateFormat + " HH:mm";
            dgvSummaries.Columns["colTo"].DefaultCellStyle.Format = Globals.DateFormat + " HH:mm";
            dgvSummaries.DataSource = Program.CurrentIncident.ActiveIncidentStatusSummaries.OrderBy(o=>o.ReportFromTimePeriod).ToList();
        }

        private void OpenSummaryForEdit(IncidentStatusSummary summary)
        {
            if (summary == null) return;
           
            using(IncidentStatusSummaryForm form = new IncidentStatusSummaryForm())
            {
                form.SetIncidentSummary(summary.Clone());
                form.ShowDialog(this);
                if (form.DialogResult == DialogResult.OK)
                {
                    // Refresh the data grid view
                    Program.incidentDataService.UpsertIncidentSummary(form.incidentStatusSummary);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IncidentStatusSummary summary = new IncidentStatusSummary();
            summary.SetPreparedBy(Program.CurrentRole);
            summary.OpPeriod = Program.CurrentOpPeriod;
            //fill other data based on previous summaries


            OpenSummaryForEdit(summary);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvSummaries.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSummaries.SelectedRows[0];
                if (selectedRow.DataBoundItem is IncidentStatusSummary summary)
                {
                    OpenSummaryForEdit(summary);
                }
            }
            else
            {
                MessageBox.Show("Please select a summary to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
