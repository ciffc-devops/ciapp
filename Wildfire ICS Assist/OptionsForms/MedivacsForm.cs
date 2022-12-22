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
    public partial class MedivacsForm : Form
    {
        public MedivacsForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void MedivacsForm_Load(object sender, EventArgs e)
        {
            dgvMedivac.AutoGenerateColumns = false;
            buildDataList();
        }

        private void buildDataList()
        {
            dgvMedivac.DataSource = null;
            List<AmbulanceService> items = (List<AmbulanceService>)Program.generalOptionsService.GetOptionsValue("Ambulances");
            items = items.Where(o => o.Active).OrderBy(o=>o.Organization).ToList();
            dgvMedivac.DataSource = items;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AmbulanceService selected = new AmbulanceService();
            EditMedivacForm editForm = new EditMedivacForm();
            editForm.selectedAmbulance = selected;
           
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                Program.generalOptionsService.UpserOptionValue(editForm.selectedAmbulance, "Ambulance");
                buildDataList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMedivac.SelectedRows.Count == 1)
            {
                AmbulanceService selected = ((AmbulanceService)dgvMedivac.SelectedRows[0].DataBoundItem).Clone();
                EditMedivacForm editForm = new EditMedivacForm();
                editForm.selectedAmbulance = selected;

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editForm.selectedAmbulance, "Ambulance");
                    buildDataList();
                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedivac.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the selected medivac service(s)?", "Delete?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvMedivac.SelectedRows)
                    {
                        AmbulanceService h = (AmbulanceService)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpserOptionValue(h, "Ambulance");
                    }
                    buildDataList();
                }
            }
        }

        private void dgvMedivac_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvMedivac.SelectedRows.Count == 1)
            {
                AmbulanceService selected = ((AmbulanceService)dgvMedivac.SelectedRows[0].DataBoundItem).Clone();
                EditMedivacForm editForm = new EditMedivacForm();
                editForm.selectedAmbulance = selected;

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editForm.selectedAmbulance, "Ambulance");
                    buildDataList();
                }

            }
        }

        private void dgvMedivac_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvMedivac.SelectedRows.Count > 0);
            btnEdit.Enabled = (dgvMedivac.SelectedRows.Count == 1);

        }
    }
}
