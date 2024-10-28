using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.CustomControls;

namespace Wildfire_ICS_Assist
{
    public partial class CheckInEditCrewForm : BaseForm
    {
       public  Crew selectedCrew
        {
            get { return crewEditControl1.subGroup; }
            set { SetCrew(value); }
        }

        public List<OperationalGroupResourceListing> resourcesToRemoveFromCrew { get => crewEditControl1.resourcesToRemoveFromCrew; }
        public List<IncidentResource> subResources { get => crewEditControl1.resources; }

        public CheckInEditCrewForm()
        {
            InitializeComponent();
            crewEditControl1.EditExisting = true;

        }

        private void SetCrew(Crew crew)
        {
            
            if (Program.CurrentIncident.ActiveOperationalSubGroups.Any(o => o.ID == crew.ID))
            {
                List<IncidentResource> SubResources = new List<IncidentResource>();
                SubResources.AddRange(Program.CurrentIncident.GetReportingResources(crew.ID));

                crewEditControl1.SetSubGroup(crew, SubResources);
                
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (crewEditControl1.FormIsComplete)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
