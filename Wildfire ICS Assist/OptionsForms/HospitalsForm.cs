using Newtonsoft.Json.Bson;
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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class HospitalsForm : Form
    {
        public HospitalsForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();

        }

        private void HospitalsForm_Load(object sender, EventArgs e)
        {
            dgvHospitals.AutoGenerateColumns = false;

            buildDataList();
        }

        private void buildDataList()
        {
            dgvHospitals.DataSource = null;
            List<Hospital> hospitals = (List<Hospital>)Program.generalOptionsService.GetOptionsValue("Hospitals");
            hospitals = hospitals.Where(o => o.Active).ToList();
            dgvHospitals.DataSource = hospitals;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Hospital selectedHospital = new Hospital();
            EditHosptalForm editHosptalForm = new EditHosptalForm();
            editHosptalForm.selectedHospital = selectedHospital;
            editHosptalForm.ShowTravelTimes = false;
            if (editHosptalForm.ShowDialog() == DialogResult.OK)
            {
                Program.generalOptionsService.UpserOptionValue(editHosptalForm.selectedHospital, "Hospital");
                buildDataList();
            }
        }

        private void dgvHospitals_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvHospitals.SelectedRows.Count > 0);
            btnEdit.Enabled = (dgvHospitals.SelectedRows.Count == 1);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHospitals.SelectedRows.Count == 1)
            {
                Hospital selectedHospital = ((Hospital)dgvHospitals.SelectedRows[0].DataBoundItem).Clone();
                EditHosptalForm editHosptalForm = new EditHosptalForm();
                editHosptalForm.selectedHospital = selectedHospital;
                editHosptalForm.ShowTravelTimes = false;
                if (editHosptalForm.ShowDialog() == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editHosptalForm.selectedHospital, "Hospital");
                    buildDataList();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (dgvHospitals.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the selected hospital(s)?", "Delete?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvHospitals.SelectedRows)
                    {
                        Hospital h = (Hospital)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpserOptionValue(h, "Hospiatl");
                    }
                    buildDataList();
                }
            }
        }

        private void dgvHospitals_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                Hospital selectedHospital = ((Hospital)dgvHospitals.Rows[e.RowIndex].DataBoundItem).Clone();
                EditHosptalForm editHosptalForm = new EditHosptalForm();
                editHosptalForm.selectedHospital = selectedHospital;
                editHosptalForm.ShowTravelTimes = false;
                if (editHosptalForm.ShowDialog() == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editHosptalForm.selectedHospital, "Hospital");
                    buildDataList();
                }



            }
        }
    }
}
