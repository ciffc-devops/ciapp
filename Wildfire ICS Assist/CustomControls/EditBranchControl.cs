using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class EditBranchControl : UserControl
    {
        private OperationalGroup _SelectedGroup = new OperationalGroup(Guid.Empty);
        public OperationalGroup SelectedGroup { get => _SelectedGroup; set { _SelectedGroup = value; } }
        private List<CommsPlanItem> _AvailableCommsPlanItems = new List<CommsPlanItem>();
        private List<ICSRole> OpsRoles = new List<ICSRole>();
        public bool UnsavedChanges = false;

        public EditBranchControl()
        {
            InitializeComponent();
           
        }

        private void EditBranchControl_Load(object sender, EventArgs e)
        {
            cboName.Location = new Point(cboReportsTo.Location.X, cboName.Location.Y);
            cboName.Width = cboReportsTo.Width;
            cboName.Visible = false;
            txtName.Location = cboName.Location;
            txtName.Width = cboName.Width;
            txtName.Visible = false;
            cboType.SelectedIndex = 0;
            if (SelectedGroup != null && SelectedGroup.ID != Guid.Empty)
            {
                PopulateLeader();
                PopulateReportsTo();
                BuildCommsComboboxList();
                PopulateCommsPlanItems();
                LoadGroup();
                UnsavedChanges = false;
            }
        }

        private void PopulateLeader()
        {
            if ( Program.CurrentIncident != null && Program.CurrentIncident.IncidentPersonnel != null)
            {
                List<Personnel> members = Program.CurrentIncident.IncidentPersonnel.OrderBy(o => o.Name).ToList();
                Personnel blank = new Personnel(); blank.PersonID = Guid.Empty; members.Insert(0, blank);

                List<Personnel> mems = new List<Personnel>();
                mems.AddRange(members);
                cboSupervisor.DataSource = mems;
                cboSupervisor.ValueMember = "PersonID";
                cboSupervisor.DisplayMember = "NameWithInitialRoleAcronym";
            }


        }
        private void PopulateReportsTo()
        {
            OpsRoles.Clear();
            if (Program.CurrentOrgChart != null)
            {
                OpsRoles.Add(Program.CurrentOrgChart.ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.OpsChiefID && !o.IsPlaceholder));
                OpsRoles.AddRange(Program.CurrentOrgChart.GetChildRoles(Globals.OpsChiefID, true, true));
                OpsRoles = OpsRoles.Where(o => o.RoleID == Globals.OpsChiefID || o.IsBranch).OrderByDescending(o=>o.RoleID == Globals.OpsChiefID).ThenBy(o=>o.RoleName).ToList();
                cboReportsTo.DataSource = OpsRoles;
                cboReportsTo.DisplayMember = "RoleNameForDropdown";
                cboReportsTo.ValueMember = "RoleID";
            }
        }

        private void LoadGroup()
        {
            txtName.Text = SelectedGroup.Name;
            txtTactical.Text = SelectedGroup.TacticalAssignment;
            txtSpecial.Text = SelectedGroup.SpecialInstructions;
            cboType.SelectedIndex = cboType.FindStringExact(SelectedGroup.GroupType);
            cboReportsTo.SelectedValue = SelectedGroup.ParentID;
            cboSupervisor.SelectedValue = SelectedGroup.LeaderID;
            if (SelectedGroup.IsBranchOrDiv && !string.IsNullOrEmpty(SelectedGroup.Name)) { cboName.SelectedIndex = cboName.FindStringExact(SelectedGroup.Name); }
            else if (cboName.Items.Count > 0) { cboName.SelectedIndex = 0; }
            else { cboName.SelectedIndex = -1; }

            int nextFreeComms = 0;
            foreach (Guid g in SelectedGroup.CommsPlanItemIDs)
            {

                if (_AvailableCommsPlanItems.Any(o => o.ItemID == g)) { CommsComboBoxes[nextFreeComms].SelectedValue = g; nextFreeComms += 1; }
                if (nextFreeComms >= CommsComboBoxes.Count) { break; }
            }

            //block editing some things after its been made
            if (SelectedGroup.LeaderICSRoleID != Guid.Empty)
            {
                ICSRole role = Program.CurrentIncident.GetICSRoleByOpGroupID(SelectedGroup.ID);
                txtName.Enabled = role.AllowEditName;
                cboName.Enabled = role.AllowEditName;
            }

            if (Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.ID == SelectedGroup.ID))
            {
                cboType.Enabled = false;
            }

        }

        List<ComboBox> CommsComboBoxes = new List<ComboBox>();
        private void BuildCommsComboboxList()
        {
            CommsComboBoxes.Clear();
            CommsComboBoxes.Add(cboComms1);
            CommsComboBoxes.Add(cboComms2); cboComms2.SelectedIndexChanged += cboComms1_SelectedIndexChanged;
            CommsComboBoxes.Add(cboComms3); cboComms2.SelectedIndexChanged += cboComms1_SelectedIndexChanged;
            CommsComboBoxes.Add(cboComms4); cboComms2.SelectedIndexChanged += cboComms1_SelectedIndexChanged;

        }
        private void PopulateCommsPlanItems()
        {
            if (Program.CurrentIncident != null)
            {
                _AvailableCommsPlanItems.Clear();
                if (Program.CurrentIncident.hasMeangfulCommsPlan(Program.CurrentOpPeriod)) { _AvailableCommsPlanItems = Program.CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpsPeriod == Program.CurrentOpPeriod).ActiveCommsItems; }
                CommsPlanItem blank = new CommsPlanItem();
                blank.ItemID = Guid.Empty;
                _AvailableCommsPlanItems.Insert(0, blank);
                foreach (ComboBox cb in CommsComboBoxes)
                {
                    cb.DataSource = new List<CommsPlanItem>(_AvailableCommsPlanItems);

                }
            }
        }

        private void buildBranchNames()
        {
            cboName.Items.Clear();
            for (int x = 1; x < 21; x++)
            {
                if (Program.CurrentIncident != null)
                {
                    if (!string.IsNullOrEmpty(SelectedGroup.Name) && SelectedGroup.Name.Equals(x.ToString())) { cboName.Items.Add(x.ToString()); }

                    else if (!Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.OpPeriod == Program.CurrentOpPeriod && o.Name.Equals(x.ToString())))
                    {
                        cboName.Items.Add(x.ToString());
                    }
                } else { cboName.Items.Add(x.ToString()); }
            }
            if (!string.IsNullOrEmpty(SelectedGroup.Name) && cboName.FindStringExact(SelectedGroup.Name) == -1)
            {
                cboName.Items.Add(SelectedGroup.Name);
            }

            //Heavy Equipment
            if (cboName.FindStringExact("Heavy Equipment") == -1 && !Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.OpPeriod == Program.CurrentOpPeriod && o.Name.Equals("Heavy Equipment")))
            {
                cboName.Items.Add("Heavy Equipment");
            }
            //Heavy Equipment
            if (cboName.FindStringExact("Structure Protection") == -1 && !Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.OpPeriod == Program.CurrentOpPeriod && o.Name.Equals("Structure Protection")))
            {
                cboName.Items.Add("Structure Protection");
            }

        }

        private void BuildDivisionNames()
        {
            cboName.Items.Clear();
            for (int x = 0; x < 26; x++)
            {
                //cboName.Items.Add(char.ConvertFromUtf32(65 + x));

                if (!string.IsNullOrEmpty(SelectedGroup.Name) && SelectedGroup.Name.Equals(char.ConvertFromUtf32(65 + x))) { cboName.Items.Add(char.ConvertFromUtf32(65 + x)); }

                else if (!Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.OpPeriod == Program.CurrentOpPeriod && o.Name.Equals(char.ConvertFromUtf32(65 + x))))
                {
                    cboName.Items.Add(char.ConvertFromUtf32(65 + x));
                }


            }
            for (int x = 0; x < 26; x++)
            {
                //cboName.Items.Add("A" + char.ConvertFromUtf32(65 + x));

                if (!string.IsNullOrEmpty(SelectedGroup.Name) && SelectedGroup.Name.Equals("A" + char.ConvertFromUtf32(65 + x))) { cboName.Items.Add("A" + char.ConvertFromUtf32(65 + x)); }

                else if (Program.CurrentIncident != null && !Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.OpPeriod == Program.CurrentOpPeriod && o.Name.Equals("A" + char.ConvertFromUtf32(65 + x))))
                {
                    cboName.Items.Add("A" + char.ConvertFromUtf32(65 + x));
                }
            }
            if (!string.IsNullOrEmpty(SelectedGroup.Name) && cboName.FindStringExact(SelectedGroup.Name) == -1)
            {
                cboName.Items.Add(SelectedGroup.Name);
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            {
                case 0: //branch
                    txtName.Visible = false;
                    cboName.Visible = true;
                    buildBranchNames();
                    cboName.SelectedIndex = 0;
                    if (!string.IsNullOrEmpty(SelectedGroup.Name) && SelectedGroup.GroupType.Equals("Branch"))
                    {
                        cboName.SelectedIndex = cboName.FindStringExact(SelectedGroup.Name);
                    }
                    else { cboName.SelectedIndex = 0; }
                    if (cboReportsTo.Items.Count > 0)
                    {
                        cboReportsTo.SelectedIndex = 0;
                    }
                    cboReportsTo.Enabled = false;
                    break;
                case 1: //division
                    BuildDivisionNames();
                    txtName.Visible = false;
                    cboName.Visible = true;
                    cboName.SelectedIndex = 0;
                    if (!string.IsNullOrEmpty(SelectedGroup.Name) && SelectedGroup.GroupType.Equals("Division"))
                    {
                        cboName.SelectedIndex = cboName.FindStringExact(SelectedGroup.Name);
                    }
                    else { cboName.SelectedIndex = 0; }
                    cboReportsTo.Enabled = true;

                    break;
                default:
                    txtName.Visible = true;
                    cboName.Visible = false;
                    cboReportsTo.Enabled = true;
                    if (!string.IsNullOrEmpty(SelectedGroup.GroupType) && SelectedGroup.GroupType.Equals("Group")) { txtName.Text = SelectedGroup.Name; }
                    break;
            }
            UnsavedChanges = true;
        }

      

       
        public void SaveFormValuesToSelected()
        {
            SelectedGroup.GroupType = cboType.SelectedItem.ToString();
            if (SelectedGroup.PreparedByPositionID == Guid.Empty)
            {
                SelectedGroup.PreparedByName = Program.CurrentRole.IndividualName;
                SelectedGroup.PreparedByPositionID = Program.CurrentRole.RoleID;
                SelectedGroup.PreparedByPosition = Program.CurrentRole.RoleName;
            }
            SelectedGroup.TacticalAssignment = txtTactical.Text;
            SelectedGroup.SpecialInstructions = txtSpecial.Text;

            if (cboSupervisor.SelectedItem != null)
            {
                Personnel sup = (Personnel)cboSupervisor.SelectedItem;
                SelectedGroup.LeaderName = sup.Name;
                SelectedGroup.LeaderID = sup.PersonID;
            }
            else
            {
                SelectedGroup.LeaderName = string.Empty;
                SelectedGroup.LeaderID = Guid.Empty;
            }

            if (cboReportsTo.SelectedItem != null)
            {
                ICSRole reportsTo = (ICSRole)cboReportsTo.SelectedItem;

                SelectedGroup.ParentID = reportsTo.RoleID;
                if (reportsTo.OperationalGroupID != Guid.Empty && Program.CurrentIncident.ActiveOperationalGroups.Any(o => o.ID == reportsTo.OperationalGroupID))
                {
                    OperationalGroup gr = Program.CurrentIncident.ActiveOperationalGroups.First(o => o.ID == reportsTo.OperationalGroupID);
                    SelectedGroup.ParentName = gr.ResourceName;
                }

                else
                {
                    SelectedGroup.ParentName = reportsTo.RoleName;
                }



            }

            if (SelectedGroup.GroupType.Equals("Branch")) { SelectedGroup.Name = cboName.Text; }
            else if (SelectedGroup.GroupType.Equals("Division")) { SelectedGroup.Name = cboName.Text; }
            else { SelectedGroup.Name = txtName.Text; }

            SelectedGroup.CommsPlanItemIDs.Clear();
            foreach (ComboBox cb in CommsComboBoxes)
            {
                if (cb.SelectedItem != null && (cb.SelectedItem as CommsPlanItem).ItemID != Guid.Empty) { SelectedGroup.CommsPlanItemIDs.Add((cb.SelectedItem as CommsPlanItem).ItemID); }
            }

        }

        public bool IsComplete()
        {
            if (cboType.SelectedIndex == 2 && string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; return false; }
            else { txtName.BackColor = Program.GoodColor; }
            return true;
        }

        private void cboSupervisor_Leave(object sender, EventArgs e)
        {
            if (cboSupervisor.SelectedItem == null) { cboSupervisor.Text = ""; }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == 2 && string.IsNullOrEmpty(txtName.Text)) { txtName.BackColor = Program.ErrorColor; }
            else { txtName.BackColor = Program.GoodColor; }

        }

        private void cboReportsTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void txtTactical_TextChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void txtSpecial_TextChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboComms1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }

        private void cboName_TextUpdate(object sender, EventArgs e)
        {
            UnsavedChanges = true;

        }
    }
}
