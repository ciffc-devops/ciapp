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

namespace Wildfire_ICS_Assist
{
    public partial class DemobilizeResourceForm : BaseForm
    {
        public DemobilizationRecord SelectedDemobRecord { get => demobilizationEditControl1.SelectedDemobRecord; }

        public void SetRecord(IncidentResource res, CheckInRecord rec, DemobilizationRecord demob)
        {
            demobilizationEditControl1.SetRecord(res, rec, demob);
        }

        public DemobilizeResourceForm()
        {
            InitializeComponent(); 
        }

        private void DemobilizeResourceForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult  = DialogResult.OK;
            this.Close();
        }

        private void btnPrintDemob_Click(object sender, EventArgs e)
        {
            string path = Program.pdfExportService.createDemobChecklistPDF(Program.CurrentIncident, demobilizationEditControl1.SelectedResource, false, false);
            if (!string.IsNullOrEmpty(path))
            {
                try { System.Diagnostics.Process.Start(path); }
                catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }
            }
            else
            {
                MessageBox.Show("Sorry, there was an error generating the contact list.");
            }
        }
    }
}
