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
    public partial class SavedVehiclesForm : Form
    {
        public SavedVehiclesForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void SavedVehiclesForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            dgvVehicles.AutoGenerateColumns = false;
            buildList();
        }

        private void buildList()
        {
            dgvVehicles.DataSource = null;
            List<Vehicle> items = (List<Vehicle>)Program.generalOptionsService.GetOptionsValue("Vehicles");
            items = items.Where(o => o.Active).OrderBy(o => o.IncidentIDNo).ToList();
            dgvVehicles.DataSource = items;

        }

        private void openItemForEdit(Vehicle item)
        {
            using (EditSavedVehicleForm editItem = new EditSavedVehicleForm())
            {
                editItem.vehicle = item.Clone();
                editItem.DisplayOperator = false;
                DialogResult dr = editItem.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpsertOptionValue(editItem.vehicle, "Vehicle");
                    buildList();


                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Active = true;
            openItemForEdit(vehicle);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 1)
            {
                Vehicle item = (Vehicle)dgvVehicles.SelectedRows[0].DataBoundItem;
                openItemForEdit(item);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvVehicles.SelectedRows)
                    {
                        Vehicle h = (Vehicle)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpsertOptionValue(h, "Vehicle");
                    }
                    buildList();
                }
            }

        }

        private void dgvVehicles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Vehicle item = (Vehicle)dgvVehicles.Rows[e.RowIndex].DataBoundItem;
                openItemForEdit(item);
            }

        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvVehicles.SelectedRows.Count > 0);
            btnEdit.Enabled = (dgvVehicles.SelectedRows.Count == 1);


        }
    }
}
