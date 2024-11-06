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
    public partial class EditSavedAircraftForm : BaseForm
    {
        public Aircraft SelectedAircraft { get => editAircraftControl1.selectedAircraft; set => editAircraftControl1.selectedAircraft = value; }

        public EditSavedAircraftForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editAircraftControl1.IsValid) { this.DialogResult = DialogResult.OK; this.Close(); }
        }

        private void EditSavedAircraftForm_Load(object sender, EventArgs e)
        {

        }
    }
}
