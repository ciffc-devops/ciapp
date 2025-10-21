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
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class SavedAircraftsForm : BaseForm
    {
        public SavedAircraftsForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void SavedAircraftsForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            LoadAircraft();
        }

        private void LoadAircraft()
        {
            dgvAircraft.DataSource = null;
            List<Aircraft> aircraftList = (List<Aircraft>)Program.generalOptionsService.GetOptionsValue("Aircrafts");
            aircraftList = aircraftList.Where(o=>o.Active).ToList();
            dgvAircraft.AutoGenerateColumns = false;
            dgvAircraft.DataSource = aircraftList;
        }

        private void OpenForEdit(Aircraft air)
        {
            using (EditSavedAircraftForm editForm = new EditSavedAircraftForm())
            {
                editForm.SelectedAircraft = air;
                DialogResult dr = editForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpsertOptionValue(editForm.SelectedAircraft, "Aircraft");
                    LoadAircraft();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Aircraft air = new Aircraft();
            OpenForEdit(air);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvAircraft.SelectedRows.Count == 1)
            {
                Aircraft air = dgvAircraft.SelectedRows[0].DataBoundItem as Aircraft;
                OpenForEdit(air);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAircraft.SelectedRows.Count > 0)
            {
                DialogResult dr = LgMessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvAircraft.SelectedRows)
                    {
                        Aircraft h = (Aircraft)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpsertOptionValue(h, "Aircraft");
                    }
                    LoadAircraft();
                }
            }

        }

        private void dgvAircraft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                Aircraft air = dgvAircraft.Rows[e.RowIndex].DataBoundItem as Aircraft;
                OpenForEdit(air);
            }
        }

        private void dgvAircraft_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvAircraft.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvAircraft.SelectedRows.Count > 0;
        }
    }
}
