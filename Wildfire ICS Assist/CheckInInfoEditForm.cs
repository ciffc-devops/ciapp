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
    public partial class CheckInInfoEditForm : Form
    {
        public CheckInRecord SelectedRecord { get => resourceCheckInEditControl1.checkInRecord; }

     
        public CheckInInfoEditForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackground;
        }
        public bool AssignIfPossible { get => resourceCheckInEditControl1.AssignIfPossible; }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void SetRecord(CheckInRecordWithResource rec)
        {
            resourceCheckInEditControl1.SetCheckInRecord(rec.Record);





            if (rec.Record.IsPerson)
            {
                if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == rec.Resource.ID && o.Active))
                {

                    resourceCheckInEditControl1.SetResource(rec.Resource as Personnel);
                }
            }
            else if (rec.Record.IsVehicle || rec.Record.IsEquipment)
            {
                resourceCheckInEditControl1.SetResource(rec.Resource as Vehicle);

            }
            else if (rec.Record.IsVisitor)
            {
                resourceCheckInEditControl1.SetResource(rec.Resource as Personnel);

            }
            else if (rec.Record.IsCrew || rec.Record.IsHECrew)
            {
                resourceCheckInEditControl1.SetResource(rec.Resource as OperationalSubGroup);

            }
            resourceCheckInEditControl1.LoadPage();
        }

        private void CheckInInfoEditForm_Load(object sender, EventArgs e)
        {

        }

        private void datCheckInToday_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnDoneCrewEdit_Click(object sender, EventArgs e)
        {
            resourceCheckInEditControl1.SaveFormFieldsToCheckIn();
            if (resourceCheckInEditControl1.ValidateCheckInInfo())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
