using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;
using WildfireICSDesktopServices.PDFExportServiceClasses.IncidentSummaryExport;


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
            dgvSummaries.DataSource = Program.CurrentIncident.ActiveIncidentStatusSummaries.OrderBy(o => o.ReportFromTimePeriod).ToList();
        }

        private void OpenSummaryForEdit(IncidentStatusSummary summary)
        {
            if (summary == null) return;

            using (IncidentStatusSummaryForm form = new IncidentStatusSummaryForm())
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
            IncidentStatusSummary summary = null;
            DateTime now = DateTime.Now;

            if (Program.CurrentIncident.ActiveIncidentStatusSummaries.Any(o => o.ReportToTimePeriod < now))
            {
                DialogResult result = LgMessageBox.Show("Would you like to start with a copy of the most recent summary?", "Copy last summary", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    IncidentStatusSummary lastsummary = Program.CurrentIncident.ActiveIncidentStatusSummaries.Where(o => o.ReportToTimePeriod < now).OrderByDescending(o => o.ReportToTimePeriod).FirstOrDefault();
                    if (lastsummary != null)
                    {
                        summary = IncidentSummaryTools.CreateStatusSummaryFromPrevious(lastsummary);
                        summary.OpPeriod = Program.CurrentOpPeriod;
                        summary.SetPreparedBy(Program.CurrentRole);
                        summary.DatePrepared = DateTime.Now;
                        summary.ReportToTimePeriod = Program.CurrentOpPeriodDetails.PeriodEnd;
                    }
                }
                else if (result == DialogResult.No)
                {
                    summary = new IncidentStatusSummary();
                    summary.SetPreparedBy(Program.CurrentRole);
                    summary.OpPeriod = Program.CurrentOpPeriod;
                    summary.DatePrepared = DateTime.Now;
                    summary.DateSubmitted = DateTime.Now;
                }
                else
                {
                    return; // User cancelled
                }


            }
            else
            {
                summary = new IncidentStatusSummary();
                summary.SetPreparedBy(Program.CurrentRole);
                summary.OpPeriod = Program.CurrentOpPeriod;
                summary.DatePrepared = DateTime.Now;
                summary.DateSubmitted = DateTime.Now;

          
            }
          

            if (summary != null)
            {
                OpenSummaryForEdit(summary);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSummaries.SelectedRows.Count > 0)
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
            if (dgvSummaries.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSummaries.SelectedRows)
                {

                    if (row.DataBoundItem is IncidentStatusSummary summary)
                    {
                        Print209(summary);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a summary to print.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Print209(IncidentStatusSummary summary)
        {

            if (summary == null) return;
            string path = summary.exportToPDF(Program.CurrentIncident, false);


            try
            {

                System.Diagnostics.Process.Start(path);
            }
            catch (Exception ex)
            {
                LgMessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
            }
        }
    }
}
