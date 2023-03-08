using Microsoft.VisualBasic;
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
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;

namespace Wildfire_ICS_Assist
{
    public partial class PersonnelCheckInForm : Form
    {
        
        private CheckInRecord _checkInRecord = new CheckInRecord();
        public CheckInRecord checkInRecord { get => _checkInRecord; private set => _checkInRecord = value; }

        private IncidentResource _selectedResource = new IncidentResource();
        public IncidentResource selectedResource { get => _selectedResource; private set => _selectedResource = value; }
        private List<IncidentResource> _SubResources = new List<IncidentResource>();
        public List<IncidentResource> SubResources { get => _SubResources; private set => _SubResources = value; }


        public bool AutoStartNextCheckin { get => chkAutoNewCheckin.Checked; }

        public PersonnelCheckInForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            GeneralTools.SetDateFormat(this);
        }

        private void PersonnelSignInForm_Load(object sender, EventArgs e)
        {
            LoadData();
            personnelEditControl1.SetPersonnel( new Personnel());
           
            foreach(TabPage p in wizardPages1.TabPages) { p.BackColor = Program.FormBackground; }
            BuildSavedVehicleList();

        }

        private void BuildSavedVehicleList()
        {
            Vehicle blankVehicle = new Vehicle();
            blankVehicle.IncidentIDNo = "-Select a saved vehicle-";
            blankVehicle.ID = Guid.Empty;
            List<Vehicle> savedVehicles = new List<Vehicle>();
            savedVehicles.AddRange((List<Vehicle>)Program.generalOptionsService.GetOptionsValue("Vehicles"));
            savedVehicles.Insert(0, blankVehicle);

            cboSavedVehicles.DataSource = savedVehicles;

        }

   

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        private void LoadData()
        {
            cboSavedPersonnel.DataSource = null;
            List<MemberStatus> statuses = Program.CurrentIncident.getAllMemberStatus(Program.CurrentOpPeriod);

            List<Personnel> members = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = members.Where(o => o.MemberActive).OrderBy(o => o.ProvinceName).ThenBy(o => o.Agency).ThenBy(o => o.Name).ToList();
            members = members.Where(o => !statuses.Any(s => s.MemberID == o.PersonID)).ToList();

            cboSavedPersonnel.DataSource = members;


        }

        private void btnSelectSaved_Click(object sender, EventArgs e)
        {
            if (cboSavedPersonnel.SelectedItem != null)
            {
                _selectedResource = (Personnel)cboSavedPersonnel.SelectedItem;
                checkInRecord.ResourceType = "Person";
                MoveToCheckInDetailsPage();
                //txtSelectedName.Text = selectedMember.Name;
                
            }
        }

        private void btnSelectNew_Click(object sender, EventArgs e)
        {
            if (personnelEditControl1.FormValid)
            {
                _selectedResource = personnelEditControl1.teamMember;
                checkInRecord.ResourceType = "Person";
                //txtSelectedName.Text = selectedMember.Name;
                MoveToCheckInDetailsPage();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (wizardPages1.SelectedIndex > 0)
            {
                if (MessageBox.Show(Properties.Resources.SureCancel, Properties.Resources.AreYouSureTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }

        }

        private void cboSavedPersonnel_Leave(object sender, EventArgs e)
        {
            if (cboSavedPersonnel.SelectedItem == null)
            {
                cboSavedPersonnel.Text = string.Empty;

            }
        }

       

        private void MoveToCheckInDetailsPage()
        {
            wizardPages1.SelectedIndex = 5;
            
            resourceCheckInEditControl1.SetResource (_selectedResource);
            resourceCheckInEditControl1.SetCheckInRecord(_checkInRecord);
            resourceCheckInEditControl1.LoadPage();
        }

      


        private void btnCheckIn_Click(object sender, EventArgs e)
        {
           if(_selectedResource != null && resourceCheckInEditControl1.ValidateCheckInInfo())
            {
                resourceCheckInEditControl1.SaveFormFieldsToCheckin();

                checkInRecord = resourceCheckInEditControl1.checkInRecord.Clone();
                checkInRecord.ResourceID = _selectedResource.ID;

                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            /*
            if (selectedMember != null && ValidateCheckInInfo())
            {
                checkInRecord.ResourceID = selectedMember.ID;
                checkInRecord.ResourceName = selectedMember.Name;
                checkInRecord.ResourceType = "Person";

                checkInRecord.OpPeriod = Program.CurrentOpPeriod;


                checkInRecord.CheckInDate = datCheckInTime.Value;
                checkInRecord.LastDayOnIncident = datLDW.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }*/
        }

     
        private void txtDeparturePoint_TextChanged(object sender, EventArgs e)
        {

        }

   

        private void btnCrew_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 2;
        }

        private void btnVehicleEquipment_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 4;
        }

        private void btnSinglePersonnel_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 1;
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 3;
        }

        private void wizardPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBack.Visible = wizardPages1.SelectedIndex > 0;
            btnCheckIn.Visible = wizardPages1.SelectedIndex == 5;
            chkAutoNewCheckin.Visible = wizardPages1.SelectedIndex == 5;

            btnDoneCrewEdit.Visible = wizardPages1.SelectedIndex == 2;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch(wizardPages1.SelectedIndex)
            {
                case 0:
                    break;
                case 5:
                    if (checkInRecord.IsVisitor) { wizardPages1.SelectedIndex = 3; }
                    else if (checkInRecord.IsCrew) { wizardPages1.SelectedIndex = 2; }
                    else if (checkInRecord.IsVehicle) { wizardPages1.SelectedIndex = 4; }
                    else { wizardPages1.SelectedIndex = 1; }
                    break;
                default:
                    wizardPages1.SelectedIndex = 0;
                    break;
            }
        }

        private void btnSelectSavedVehicle_Click(object sender, EventArgs e)
        {
            if(cboSavedVehicles.SelectedItem != null && ((Vehicle)cboSavedVehicles.SelectedItem).ID != Guid.Empty)
            {
                _selectedResource = ((Vehicle)cboSavedVehicles.SelectedItem).Clone();
                checkInRecord.ResourceType = "Vehicle";
                MoveToCheckInDetailsPage();
            }
        }

        private void btnSelectNewVehicle_Click(object sender, EventArgs e)
        {
            if (vehicleEquipmentEditControl1.IsComplete)
            {
                _selectedResource = vehicleEquipmentEditControl1.CurrentVehicle.Clone();
                checkInRecord.ResourceType = "Vehicle";
                MoveToCheckInDetailsPage();
            }
        }

       
        private void btnSelectVisitor_Click(object sender, EventArgs e)
        {
            if (visitorEditControl1.FormValid)
            {
                visitorEditControl1.selectedPerson.Kind = "Visitor";
                visitorEditControl1.selectedPerson.Type = "Visitor";
                _selectedResource = visitorEditControl1.selectedPerson.Clone();
                checkInRecord.ResourceType = "Visitor";
                MoveToCheckInDetailsPage();
            }
        }

        private void btnDoneCrewEdit_Click(object sender, EventArgs e)
        {
            if (crewEditControl1.FormIsComplete)
            {
                


                selectedResource = crewEditControl1.subGroup.Clone();
                checkInRecord.ResourceType = "Crew";
                SubResources.Clear();
                SubResources.AddRange(crewEditControl1.resources);
                MoveToCheckInDetailsPage();
            }
        }
    }
}
