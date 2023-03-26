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
    public partial class CheckInForm : Form
    {
        
        private CheckInRecord _checkInRecord = new CheckInRecord();
        public CheckInRecord checkInRecord { get => _checkInRecord; private set => _checkInRecord = value; }

        private IncidentResource _selectedResource = new IncidentResource();
        public IncidentResource selectedResource { get => _selectedResource; private set => _selectedResource = value; }
        private List<IncidentResource> _SubResources = new List<IncidentResource>();
        public List<IncidentResource> SubResources { get => _SubResources; private set => _SubResources = value; }
        private bool editingExisting = false;

        public bool AutoStartNextCheckin { get => chkAutoNewCheckin.Checked; set => chkAutoNewCheckin.Checked = value; }
        public List<OperationalGroupResourceListing> resourcesToRemoveFromCrew { get => crewEditControl1.resourcesToRemoveFromCrew; }

        private string CheckInMode = null;


        public CheckInForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
            GeneralTools.SetDateFormat(this);
            personnelEditControl1.SetPersonnel(new Personnel());
           

        }

        public void SetCheckIn(CheckInRecord rec)
        {
            checkInRecord = rec;

            if(rec.ResourceID != Guid.Empty)
            {
                editingExisting = true;
                crewEditControl1.EditExisting = true;
                btnCheckIn.Text = "Save Changes";
                resourceCheckInEditControl1.SetCheckInRecord(rec);

                //we are editing an existing record

                pnlSavedPersonnel.Visible = false;
                pnlPersonEdit.Location = new Point(0, 0);
                lblEditPersonTitle.Text = "Edit Personnel";

                chkSaveVehicleForLater.Visible = false;
                pnlEditVehicle.Location = new Point(0, 0);
                pnlSavedVehicle.Visible = false;
                lblEditVehicleTitle.Text = "Edit Vehicle / Equipment";
            }


            if (rec.IsPerson)
            {
                if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == rec.ResourceID && o.Active))
                {
                    selectedResource = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == rec.ResourceID && o.Active);
                    personnelEditControl1.SetPersonnel(selectedResource as Personnel);
                    chkSavePersonForLater.Visible = false;
                    wizardPages1.SelectedIndex = 1;

                    resourceCheckInEditControl1.SetResource(selectedResource as Personnel);
                }
            }
            else if (rec.IsVehicle || rec.IsEquipment) 
            {
                if (Program.CurrentIncident.allVehicles.Any(o => o.ID == rec.ResourceID && o.Active))
                {
                    selectedResource = Program.CurrentIncident.allVehicles.First(o => o.ID == rec.ResourceID && o.Active);
                    LoadVehicleOperators();
                    vehicleEquipmentEditControl1.SetVehicle(selectedResource as Vehicle);

                    wizardPages1.SelectedIndex = 4;
                }
            }
            else if (rec.IsVisitor)
            {
                if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == rec.ResourceID && o.Active))
                {
                    selectedResource = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == rec.ResourceID && o.Active);
                    visitorEditControl1.setPerson(selectedResource as Personnel);

                    wizardPages1.SelectedIndex = 3;
                }
            }
            else if (rec.IsCrew || rec.IsHECrew)
            {
                if (Program.CurrentIncident.ActiveOperationalSubGroups.Any(o => o.ID == rec.ResourceID))
                {
                    selectedResource = Program.CurrentIncident.ActiveOperationalSubGroups.First(o => o.ID == rec.ResourceID);
                    SubResources.AddRange(Program.CurrentIncident.GetReportingResources(selectedResource.ID));

                    crewEditControl1.SetSubGroup(selectedResource as OperationalSubGroup, SubResources);
                    btnDoneCrewEdit.Visible = true;
                    wizardPages1.SelectedIndex = 2;
                }
            }
        }

        private void LoadVehicleOperators()
        {
            List<IncidentResource> potentialOperators = (Program.CurrentIncident.GetUncommittedResources(Program.CurrentOpPeriod)).Where(o => o.GetType().Name.Equals("Personnel")).ToList();
            //in case we're editing, add the current operator
            if (selectedResource.GetType().Name.Equals("Vehicle"))
            {
                Vehicle v = selectedResource as Vehicle;
                if (v.OperatorID != Guid.Empty)
                {
                    potentialOperators.AddRange(Program.CurrentIncident.IncidentPersonnel.Where(o => o.ID == v.OperatorID));
                }
            }
            Personnel p = new Personnel();
            p.Name = "";
            p.ID = Guid.Empty;
            potentialOperators.Insert(0, p);

            cboSavedOperator.DataSource = potentialOperators;
            List<IncidentResource> operatorsForNewEquipment = new List<IncidentResource>(); operatorsForNewEquipment.AddRange(potentialOperators);
            vehicleEquipmentEditControl1.SetOperatorList(operatorsForNewEquipment);
            vehicleEquipmentEditControl1.EnableOperatorField = true;
        }

        private void PersonnelSignInForm_Load(object sender, EventArgs e)
        {
            checkInRecord.OpPeriod = Program.CurrentOpPeriod;
            LoadData();
           
            foreach(TabPage p in wizardPages1.TabPages) { p.BackColor = Program.FormBackground; }
          
        }

        private void BuildSavedVehicleList()
        {
            Vehicle blankVehicle = new Vehicle();
            blankVehicle.IncidentIDNo = "-Select a saved vehicle-";
            blankVehicle.ID = Guid.Empty;
            List<Vehicle> savedVehicles = new List<Vehicle>();
            savedVehicles.AddRange((List<Vehicle>)Program.generalOptionsService.GetOptionsValue("Vehicles"));
            if (vehicleEquipmentEditControl1.CurrentVehicle.IsEquipment) { savedVehicles = savedVehicles.Where(o => o.IsEquipment).ToList(); blankVehicle.IncidentIDNo = "-Select a saved piece of equipment-"; }
            else {  savedVehicles = savedVehicles.Where(o=>!o.IsEquipment).ToList(); blankVehicle.IncidentIDNo = "-Select a saved vehicle-"; }  

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
            if(cboSavedOperator.Items.Count == 0) { LoadVehicleOperators(); }
            BuildSavedVehicleList();
            
        }

        private void btnSelectSaved_Click(object sender, EventArgs e)
        {
            if (cboSavedPersonnel.SelectedItem != null)
            {
                _selectedResource = (Personnel)cboSavedPersonnel.SelectedItem;
                checkInRecord.ResourceType = "Personnel";
                MoveToCheckInDetailsPage();
                //txtSelectedName.Text = selectedMember.Name;
                
            }
        }

        private void btnSelectNew_Click(object sender, EventArgs e)
        {
            if (personnelEditControl1.FormValid)
            {
                _selectedResource = personnelEditControl1.teamMember;
                checkInRecord.ResourceType = "Personnel";
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
            CheckInMode = "Crew";
            OperationalSubGroup sub = new OperationalSubGroup();
            crewEditControl1.SetSubGroup(sub, SubResources);
            wizardPages1.SelectedIndex = 2;
        }

        private void btnVehicleEquipment_Click(object sender, EventArgs e)
        {
            CheckInMode = "Vehicle"; 
            Vehicle v = new Vehicle();
            vehicleEquipmentEditControl1.SetVehicle(v);
            BuildSavedVehicleList();
            wizardPages1.SelectedIndex = 4;
        }

        private void btnSinglePersonnel_Click(object sender, EventArgs e)
        {
            CheckInMode = "Personnel";
            wizardPages1.SelectedIndex = 1;
        }

        private void btnVisitor_Click(object sender, EventArgs e)
        {
            CheckInMode = "Visitor";
            wizardPages1.SelectedIndex = 3;
        }

        private void wizardPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBack.Visible = wizardPages1.SelectedIndex > 0;

            btnCheckIn.Visible = wizardPages1.SelectedIndex == 5;
            chkAutoNewCheckin.Visible = wizardPages1.SelectedIndex == 5;
            if (editingExisting)
            {
                btnBack.Visible = wizardPages1.SelectedIndex == 5;
                chkAutoNewCheckin.Visible = false;
            }
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
            if(cboSavedVehicles.SelectedItem != null && ((Vehicle)cboSavedVehicles.SelectedItem).ID != Guid.Empty && cboSavedOperator.SelectedItem != null)
            {
                _selectedResource = ((Vehicle)cboSavedVehicles.SelectedItem).Clone();
                Vehicle v = (Vehicle)_selectedResource;
                if (v.IsEquipment) { checkInRecord.ResourceType = "Equipment"; }
                else { checkInRecord.ResourceType = "Vehicle"; }
                
                (selectedResource as Vehicle).OperatorID = (cboSavedOperator.SelectedItem as IncidentResource).ID;
                (selectedResource as Vehicle).OperatorName = (cboSavedOperator.SelectedItem as IncidentResource).ResourceName;
                selectedResource.LeaderName = (cboSavedOperator.SelectedItem as IncidentResource).ResourceName;

                MoveToCheckInDetailsPage();
            } else if (cboSavedOperator.SelectedItem == null) { lblSavedOperator.ForeColor = Program.ErrorColor; }
        }

        private void btnSelectNewVehicle_Click(object sender, EventArgs e)
        {
            if (vehicleEquipmentEditControl1.IsComplete)
            {
                _selectedResource = vehicleEquipmentEditControl1.CurrentVehicle.Clone();
                Vehicle v = (Vehicle)_selectedResource;
                if (v.IsEquipment) { checkInRecord.ResourceType = "Equipment"; }
                else { checkInRecord.ResourceType = "Vehicle"; }

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
              //  SubResources.Clear();
              //  SubResources.AddRange(crewEditControl1.resources);
                MoveToCheckInDetailsPage();
            }
        }

        private void resourceCheckInEditControl1_Load(object sender, EventArgs e)
        {

        }

        private void cboSavedOperator_Leave(object sender, EventArgs e)
        {
            if (cboSavedOperator.SelectedItem == null) { cboSavedOperator.Text = string.Empty; }
        }

        private void btnHECrew_Click(object sender, EventArgs e)
        {
            CheckInMode = "Heavy Equipment Crew"; 
            OperationalSubGroup sub = new OperationalSubGroup();
            sub.IsEquipmentCrew = true;
            crewEditControl1.SetSubGroup(sub, SubResources);
            wizardPages1.SelectedIndex = 2;
            
        }

        private void btnEquipAndOperator_Click(object sender, EventArgs e)
        {
            CheckInMode = "Equipment";
            Vehicle v = new Vehicle();
            v.IsEquipment = true;
            vehicleEquipmentEditControl1.SetVehicle(v);
            BuildSavedVehicleList();
            wizardPages1.SelectedIndex = 4;

        }
    }
}
