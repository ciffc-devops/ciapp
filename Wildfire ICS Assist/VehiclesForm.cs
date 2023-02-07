using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class VehiclesForm : Form
    {
        public VehiclesForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;dgvVehicles.BackgroundColor = Program.FormAccent;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public WFIncident CurrentTask { get => Program.CurrentTask; }
        public int CurrentOpPeriod { get => Program.CurrentOpPeriod; }

    
        private void VehiclesForm_Load(object sender, EventArgs e)
        {
            dgvVehicles.AutoGenerateColumns = false;

            UpdateVehicleList();
            Program.wfIncidentService.VehicleChanged += Program_VehicleChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;
        }

        private void Program_VehicleChanged(VehicleEventArgs e)
        {
            UpdateVehicleList();
        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            UpdateVehicleList();
        }

        private void UpdateVehicleList()
        {
            dgvVehicles.DataSource = null;
            dgvVehicles.DataSource = GetVehicles();
        }

        public List<Vehicle> GetVehicles(bool includeInactive = false)
        {
            if (includeInactive) { return CurrentTask.allVehicles.Where(o => o.OpPeriod == CurrentOpPeriod).OrderBy(o => o.IncidentIDNo).ToList(); }
            else { return CurrentTask.allVehicles.Where(o => o.OpPeriod == CurrentOpPeriod && o.Active).OrderBy(o => o.IncidentIDNo).ToList(); }
        }

        private void OpenForEdit(Vehicle v, bool EditExisting = true)
        {
            using (VehicleEditForm editForm = new VehicleEditForm(v.Clone(), EditExisting))
            {
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    editForm.CurrentVehicle.LastUpdatedUTC = DateTime.UtcNow;
                    Program.wfIncidentService.UpsertVehicle(editForm.CurrentVehicle);

                    if (editForm.SaveForLater && !EditExisting)
                    {
                        Program.generalOptionsService.UpserOptionValue(editForm.CurrentVehicle, "Vehicle");
                    }
                }
            }
        }

        private void btnAddClue_Click(object sender, EventArgs e)
        {
            Vehicle vehicleToEdit = new Vehicle();
            vehicleToEdit.TaskID = CurrentTask.TaskID;
            vehicleToEdit.OpPeriod = CurrentOpPeriod;
            vehicleToEdit.StartTime = DateTime.Now;
            vehicleToEdit.MustBeOutTime = CurrentTask.getOpPeriodEnd(CurrentOpPeriod);

            OpenForEdit(vehicleToEdit, false);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Vehicle vehicleToEdit = (Vehicle)dgvVehicles.SelectedRows[0].DataBoundItem;
            OpenForEdit(vehicleToEdit);

        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvVehicles.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvVehicles.SelectedRows.Count > 0;
        }

        private void dgvVehicles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Vehicle vehicleToEdit = (Vehicle)dgvVehicles.Rows[e.RowIndex].DataBoundItem;
                OpenForEdit(vehicleToEdit);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    List<Vehicle> toDelete = new List<Vehicle>();
                    foreach (DataGridViewRow row in dgvVehicles.SelectedRows)
                    {
                        
                        toDelete.Add((Vehicle)row.DataBoundItem);
                        /*
                        if (parent.ThisMachineIsServer || parent.ThisMachineIsClient)
                        {
                            NetworkDeleteOrder order = new NetworkDeleteOrder(CurrentTask.TaskID);
                            order.GuidValue = vehicleToEdit.VehicleID;
                            order.objectType = vehicleToEdit.GetType().ToString();
                            parent.SendNetworkDeleteOrder(order);
                        }
                        */
                    }

                    foreach(Vehicle v in toDelete)
                    {
                        Program.wfIncidentService.DeleteVehicle(v);
                    }
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string preparedByName = null; string preparedByTitle = null;

            if (CurrentTask.allOrgCharts.Any(o => o.OpPeriod == CurrentOpPeriod))
            {
                OrganizationChart currentChart = CurrentTask.allOrgCharts.First(o => o.OpPeriod == CurrentOpPeriod);
                preparedByName = currentChart.getNameByRoleName("Logistics Section Chief");
                preparedByTitle = "Logistics Section Chief";
            }



            string path = Program.pdfExportService.createVehiclePDF(CurrentTask, CurrentOpPeriod, preparedByName, preparedByTitle, false, false);
            if (!string.IsNullOrEmpty(path))
            {
                try { System.Diagnostics.Process.Start(path); }
                catch { MessageBox.Show("Sorry, there seems to be a problem opening your PDF viewer automatically.  Please check for a popup from your anti-virus program."); }
            }
            else
            {
                MessageBox.Show("Sorry, there was an error generating the vehicle list.");
            }
        }
    }
}
