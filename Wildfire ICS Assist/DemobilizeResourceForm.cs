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
    public partial class DemobilizeResourceForm : Form
    {
        public DemobilizationRecord SelectedDemobRecord { get => demobilizationEditControl1.SelectedDemobRecord; }

        public void SetRecord(IncidentResource res, CheckInRecord rec, DemobilizationRecord demob)
        {
            demobilizationEditControl1.SetRecord(res, rec, demob);
        }

        public DemobilizeResourceForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
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
    }
}
