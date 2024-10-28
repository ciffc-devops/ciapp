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

namespace Wildfire_ICS_Assist
{
    public partial class IncidentObjectiveEntryForm : BaseForm
    {
        private IncidentObjective _objective = null;
        public IncidentObjective Objective { get => _objective; set => _objective = value; }
        public IncidentObjectiveEntryForm()
        {
            InitializeComponent(); 
        }
        public bool SaveForLater { get => chkSaveForLater.Checked; }

        private void loadSavedObjectives()
        {
            List<IncidentObjective> items = (List<IncidentObjective>)Program.generalOptionsService.GetOptionsValue("Objectives");
            items = items.Where(o => o.Active).OrderBy(o => o.Objective).ToList();
           
            cboSavedObjectives.DataSource = items;
            cboSavedObjectives.ValueMember = "ObjectiveID";
            cboSavedObjectives.DisplayMember = "Objective";

            pnlSaved.Enabled = items.Any();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("IncidentObjectives"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                Objective = new IncidentObjective();
                Objective.Objective = txtNewObjective.Text;
                Objective.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateNew()
        {
            if (string.IsNullOrEmpty(txtNewObjective.Text))
            {
                txtNewObjective.BackColor = Program.ErrorColor;
                return false;
            }
            else
            {
                txtNewObjective.BackColor = Program.GoodColor;
                return true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddSaved_Click(object sender, EventArgs e)
        {
            if(null != cboSavedObjectives.SelectedItem)
            {
                Objective = (IncidentObjective) cboSavedObjectives.SelectedItem;
                Objective.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
                Objective.CopyNextOpText = "Copy to selected op";
                this.DialogResult = DialogResult.OK;
                this.Close();

            } else if (!string.IsNullOrEmpty(cboSavedObjectives.Text))
            {
                Objective = new IncidentObjective();
                Objective.Objective = cboSavedObjectives.Text;
                Objective.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void cboSavedObjectives_Leave(object sender, EventArgs e)
        {

        }

        private void IncidentObjectiveEntryForm_Load(object sender, EventArgs e)
        {
            loadSavedObjectives();
        }
    }
}
