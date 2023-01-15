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
    public partial class SavedIncidentObjectivesForm : Form
    {
        public SavedIncidentObjectivesForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }
        private void SavedIncidentObjectivesForm_Load(object sender, EventArgs e)
        {
            dgvObjectives.AutoGenerateColumns = false;
            buildList();
        }

        private void buildList()
        {
            dgvObjectives.DataSource = null;
            List<IncidentObjective> items = (List<IncidentObjective>)Program.generalOptionsService.GetOptionsValue("Objectives");
            items = items.Where(o => o.Active).OrderBy(o => o.Objective).ToList();
            dgvObjectives.DataSource = items;

        }

        private void openItemForEdit(IncidentObjective item)
        {
            using (EditSavedIncidentObjectiveForm editItem = new EditSavedIncidentObjectiveForm())
            {
                editItem.objective = item.Clone();
                DialogResult dr = editItem.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editItem.objective, "Objective");
                    buildList();


                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            IncidentObjective item = new IncidentObjective();
            item.Active = true;
            openItemForEdit(item);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvObjectives.SelectedRows.Count == 1)
            {
                IncidentObjective item = (IncidentObjective)dgvObjectives.SelectedRows[0].DataBoundItem;
                openItemForEdit(item);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvObjectives.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvObjectives.SelectedRows)
                    {
                        IncidentObjective h = (IncidentObjective)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpserOptionValue(h, "Objective");
                    }
                    buildList();
                }
            }

        }

        private void dgvObjectives_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IncidentObjective item = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;
                openItemForEdit(item);
            }


        }

        private void dgvObjectives_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvObjectives.SelectedRows.Count > 0);
            btnEdit.Enabled = (dgvObjectives.SelectedRows.Count == 1);


        }


    }
}
