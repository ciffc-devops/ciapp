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
    public partial class ResourcesEditUniqueNumberForm : Form
    {
        private IncidentResource _selectedResource = new IncidentResource();
        public int newNumber { get => Convert.ToInt32(numNewNumber.Value); }
        public List<int> OtherNumbersToExclude { get; set; } = new List<int>();
        public void SetResource(IncidentResource resource)
        {
            _selectedResource = resource;
            numNewNumber.Value = resource.UniqueIDNum;
            lblCurrentNumber.Text = resource.UniqueIDNumWithPrefix;
            lblResourceName.Text = resource.ResourceName;
        }

        public ResourcesEditUniqueNumberForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void ResourcesEditUniqueNumber_Load(object sender, EventArgs e)
        {

        }

        private void numNewNumber_ValueChanged(object sender, EventArgs e)
        {
            bool isUnique = Program.CurrentIncident.ConfirmResourceNumUnique(_selectedResource.ResourceType, newNumber, _selectedResource.ID);
            if(OtherNumbersToExclude.Any(o=>o == newNumber)) { isUnique = false; }
            if (isUnique) { lblUniqueCheck.Text = "Number is unique"; lblUniqueCheck.BackColor = Program.GoodColor; btnSave.Enabled = true; }
            else { lblUniqueCheck.Text = "NOT unique"; lblUniqueCheck.BackColor = Program.ErrorColor; btnSave.Enabled = false; }
        }
    }
}
