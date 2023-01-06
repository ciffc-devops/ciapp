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
    public partial class EditSavedIncidentObjectiveForm : Form
    {

        private IncidentObjective _objective = null;
        public IncidentObjective objective { get => _objective; set { _objective = value; displayObjective(); } }
        public EditSavedIncidentObjectiveForm()
        {
            InitializeComponent();
        }

        private void displayObjective()
        {
            txtObjectiveText.Text = _objective.Objective;
        }

        private void txtObjectiveText_TextChanged(object sender, EventArgs e)
        {
            objective.Objective = txtObjectiveText.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(objective.Objective))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("You must include text for the objective.");
            }
        }

        private void EditSavedIncidentObjectiveForm_Load(object sender, EventArgs e)
        {

        }
    }
}
