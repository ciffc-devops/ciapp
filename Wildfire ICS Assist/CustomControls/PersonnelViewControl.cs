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
    public partial class PersonnelViewControl : UserControl
    {
        private Personnel _teamMember = new Personnel();
        public Personnel teamMember { get => _teamMember; set { _teamMember = value; displayTeamMember(); } }

        public PersonnelViewControl()
        {
            InitializeComponent();
        }

        private void PersonnelViewControl_Load(object sender, EventArgs e)
        {

        }

        private void displayTeamMember()
        {
            if (_teamMember != null)
            {
                lblFirstName.Text = teamMember.FirstName;
                lblMiddleName.Text = teamMember.MiddleInitial;
                lblLastName.Text = teamMember.LastName;
                lblGender.Text = teamMember.Gender;
                lblProvince.Text = teamMember.ProvinceName;
                lblCountry.Text = teamMember.HomeCountry;
                lblHomeAgency.Text  = teamMember.Agency;
                if (teamMember.IsContractor) { lblContractor.Text = "Yes"; } else { lblContractor.Text = "No"; }
                if (teamMember.HasDietaryRestrictions) { lblDietary.Text = "Yes"; } else { lblDietary.Text = "No"; }
                if (teamMember.HasAllergies) { lblAllergies.Text = "Yes"; } else { lblAllergies.Text = "No"; }
                lblCellphone.Text = teamMember.CellphoneNumber;
                lblEmail.Text = teamMember.Email;
                lblHomeUnit.Text = teamMember.HomeUnit;
                lblCallsign.Text = teamMember.Callsign;
                lblEmergencyContact.Text = teamMember.EmergencyContact;
            }
        }
    }
}
