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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class EditTeamAssignmentTemplateControl : UserControl
    {
        private TeamAssignment _selectedAssignment = null;
        public TeamAssignment selectedAssignment { get => _selectedAssignment; set {  _selectedAssignment = value; LoadAssignment(); } }  


        private void LoadAssignment()
        {
            LoadAssignmentTypes();

            txtAssignmentName.Text = selectedAssignment.ResourceName;
            if (!string.IsNullOrEmpty(selectedAssignment.SpecialInstructions)){ txtSpecialInstructions.Text = selectedAssignment.SpecialInstructions.Replace("\n", Environment.NewLine); }
            if (!string.IsNullOrEmpty(selectedAssignment.TacticalAssignment)) { txtTacticalAssignment.Text = selectedAssignment.TacticalAssignment.Replace("\n", Environment.NewLine); }

        }

        private void LoadAssignmentTypes()
        {
            List<string> types = Program.generalOptionsService.GetTeamAssignmentTypes();
            if (selectedAssignment.IncidentID != Guid.Empty)
            {
                foreach(TeamAssignment ta in Program.CurrentIncident.AllAssignments.Where(o=> !string.IsNullOrEmpty(o.AssignmentType)))
                {
                    if(!types.Contains(ta.AssignmentType, StringComparer.InvariantCultureIgnoreCase)) { types.Add(ta.AssignmentType);}
                }
               
            }
            types = types.OrderBy(o => o).ToList();
            cboAssignmentType.DataSource = types;
        }

        public EditTeamAssignmentTemplateControl()
        {
            InitializeComponent();
        }
    }
}
