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
    public partial class TeamAssignmentEditForm : Form
    {
        private TeamAssignment _selectedAssignment = null;
        public TeamAssignment selectedAssignment { get => _selectedAssignment; set { _selectedAssignment = value; LoadAssignment(); } }

        public TeamAssignmentEditForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            PopulateCommsPlanItems();
        }

        private void LoadAssignment()
        {
            numAssignmentNumber.Value = selectedAssignment.ResourceIDNumber;
        }

        private void TeamAssignmentEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void PopulateCommsPlanItems()
        {
            List<CommsPlanItem> items = new List<CommsPlanItem>();
            if (Program.CurrentIncident.hasMeangfulCommsPlan(Program.CurrentOpPeriod)) { items = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpsPeriod == Program.CurrentOpPeriod).ActiveCommsItems; }
            CommsPlanItem blank = new CommsPlanItem();
            blank.ItemID = Guid.Empty;
            items.Insert(0, blank);

            cboComms1.DataSource = new List<CommsPlanItem>(items);
            cboComms2.DataSource = new List<CommsPlanItem>(items);
            cboComms3.DataSource = new List<CommsPlanItem>(items);
            cboComms4.DataSource = new List<CommsPlanItem>(items);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
