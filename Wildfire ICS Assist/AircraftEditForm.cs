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
    public partial class AircraftEditForm : Form
    {
        public Aircraft selectedAircraft { get => editAircraftControl1.selectedAircraft; set { editAircraftControl1.selectedAircraft = value; LoadAircraft(); } }
        public AircraftEditForm()
        {
            InitializeComponent();
        }

        private void LoadAircraft()
        {
            txtNewPilot.Text = selectedAircraft.Pilot;
            datNewEnd.Value = selectedAircraft.EndTime;
            datNewStart.Value = selectedAircraft.StartTime;
            chkNewIsMedivac.Checked = selectedAircraft.IsMedivac;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editAircraftControl1.IsValid)
            {
                selectedAircraft.IsMedivac = chkNewIsMedivac.Checked;
                selectedAircraft.Pilot = txtNewPilot.Text;
                selectedAircraft.StartTime = datNewStart.Value;
                selectedAircraft.EndTime = datNewEnd.Value;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
