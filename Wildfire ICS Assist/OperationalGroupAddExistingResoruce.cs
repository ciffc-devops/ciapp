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
    public partial class OperationalGroupAddExistingResoruce : BaseForm
    {
        public OperationalGroupAddExistingResoruce()
        {
            InitializeComponent();
            dgvSubGroups.BackgroundColor = Program.FormAccent;
        }

        private List<IncidentResource> _resourcesToAdd = new List<IncidentResource>();
        public List<IncidentResource> resourcesToAdd { get => _resourcesToAdd; }

        private void OperationalGroupAddExistingResoruce_Load(object sender, EventArgs e)
        {
            dgvSubGroups.AutoGenerateColumns = false;
            BuildResourceList();

        }

        private void BuildResourceList()
        {
            List<IncidentResource> resources = Program.CurrentIncident.GetUncommittedResources(Program.CurrentOpPeriod);
            dgvSubGroups.DataSource = null;
            dgvSubGroups.DataSource = resources;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            resourcesToAdd.Clear();
            foreach(DataGridViewRow row in dgvSubGroups.SelectedRows)
            {
                IncidentResource res = (IncidentResource)row.DataBoundItem;
                resourcesToAdd.Add(res);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
