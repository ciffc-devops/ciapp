using Newtonsoft.Json.Linq;
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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class PrepAndApprovePanel : CollapsiblePanel
    {
        public PrepAndApprovePanel()
        {
            InitializeComponent();
            if (Program.incidentDataService != null) { Program.incidentDataService.CurrentOpPeriodChanged += IncidentDataService_CurrentOpPeriodChanged; }
            PopulateRoleComboBoxes();

        }

        private void IncidentDataService_CurrentOpPeriodChanged(WF_ICS_ClassLibrary.EventHandling.IncidentOpPeriodChangedEventArgs e)
        {
            PopulateRoleComboBoxes();

        }






        public DateTime PreparedByDateTime
        {
            get { if (datPrepDate.Checked) { return datPrepDate.Value.Date + datPrepTime.Value.TimeOfDay; } return DateTime.MinValue; }
            set
            {
                if (value > datPrepDate.MinDate && value < datPrepDate.MaxDate)
                {
                    datPrepDate.Value = value.Date;
                    datPrepTime.Value = value;
                    datPrepDate.Checked = true;
                }
                else
                {
                    datPrepDate.Value = DateTime.Now;
                    datPrepTime.Value = DateTime.Now;
                }
            }
        }
        public DateTime ApprovedByDateTime
        {
            get { if (chkApproved.Checked) { return datApproveDate.Value.Date + datApproveTime.Value.TimeOfDay; } return DateTime.MinValue; }
            set
            {
                if (value > datApproveDate.MinDate && value < datApproveDate.MaxDate)
                {
                    datApproveDate.Value = value.Date;
                    datApproveTime.Value = value;
                    chkApproved.Checked = true;
                }
                else
                {
                    datApproveDate.Value = DateTime.Now;
                    datApproveTime.Value = DateTime.Now;
                    chkApproved.Checked = false;

                }
            }
        }

        public ICSRole ApprovedByRole
        {
            get
            {
                if (cboApproveBy.SelectedItem != null && chkApproved.Checked) { return (ICSRole)cboApproveBy.SelectedItem; }
                return null;
            }
           
        }
        public ICSRole PreparedByRole
        {
            get
            {
                if (cboPrepBy.SelectedItem != null) { return (ICSRole)cboPrepBy.SelectedItem; }
                return null;
            }
           
        }
        public void SetPreparedBy(Guid RoleID, DateTime PrepDate)
        {
            PreparedByDateTime = PrepDate;
            try { cboPrepBy.SelectedValue = RoleID; }
            catch { cboPrepBy.SelectedIndex = 0; }
        }
        public void SetApprovedBy(Guid RoleID, DateTime ApproveDate)
        {
            ApprovedByDateTime = ApproveDate;
            try { cboApproveBy.SelectedValue = RoleID; }
            catch { cboApproveBy.SelectedIndex = 0; }
        }



        public event EventHandler PreparedByChanged;
        public event EventHandler ApprovedByChanged;

        private void SetForegroundColor()
        {
            foreach (Control c in this.Controls)
            {
                UpdateColorControls(c);
            }
        }
        private void UpdateColorControls(Control myControl)
        {
            //myControl.BackColor = Colors.Black;
            myControl.ForeColor = ColourUtilities.GetGoodTextColor(this.BackColor);
            foreach (Control subC in myControl.Controls)
            {
                UpdateColorControls(subC);
            }
        }



        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            Toggle();

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            Toggle();

        }

        private void HandlePanelCollapsed(object sender, EventArgs e)
        {
            // we'll explain this in a minute
            this.OnPanelCollapsed(EventArgs.Empty);
        }

    

        private void HandlePanelExpanded(object sender, EventArgs e)
        {
            // we'll explain this in a minute
            this.OnPanelExpanded(EventArgs.Empty);
        }

    
        private void PopulateRoleComboBoxes()
        {
            if (Program.CurrentOrgChart != null)
            {
                Guid currentPrepByID = Guid.Empty; if (cboPrepBy.SelectedItem != null) { currentPrepByID = ((ICSRole)cboPrepBy.SelectedItem).ID; }
                Guid currentApproveByID = Guid.Empty; if (cboApproveBy.SelectedItem != null) { currentApproveByID = ((ICSRole)cboApproveBy.SelectedItem).ID; }

                List<ICSRole> prepRoles = new List<ICSRole>(Program.CurrentOrgChart.ActiveRoles);
                ICSRole blank = new ICSRole(); blank.RoleName = string.Empty; blank.RoleID = Guid.Empty; prepRoles.Insert(0, blank);

                List<ICSRole> approveRoles = new List<ICSRole>(Program.CurrentOrgChart.ActiveRoles);
                approveRoles.Insert(0, blank);

                cboPrepBy.DataSource = prepRoles;
                cboPrepBy.DisplayMember = "RoleNameWithIndividualAndDepth";
                cboPrepBy.ValueMember = "ID";
                cboPrepBy.DropDownWidth = cboPrepBy.GetDropDownWidth();

                cboApproveBy.DataSource = approveRoles;
                cboApproveBy.DisplayMember = "RoleNameWithIndividualAndDepth";
                cboApproveBy.ValueMember = "ID";
                cboApproveBy.DropDownWidth = cboApproveBy.GetDropDownWidth();
                if (currentPrepByID != Guid.Empty)
                {
                    try { cboPrepBy.SelectedValue = currentPrepByID; }
                    catch { cboPrepBy.SelectedIndex = 0; }
                }
                if (currentApproveByID != Guid.Empty)
                {
                    try { cboApproveBy.SelectedValue = currentApproveByID; }
                    catch { cboApproveBy.SelectedIndex = 0; }
                }
            }
        }

        private void PrepAndApprovePanel_Load(object sender, EventArgs e)
        {
            
            datApproveDate.Enabled = chkApproved.Checked;
            datApproveTime.Enabled = chkApproved.Checked;
            cboApproveBy.Enabled = chkApproved.Checked;

        }


        protected virtual void OnPreparedByChanged(EventArgs e)
        {
            EventHandler handler = this.PreparedByChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnApprovedByChanged(EventArgs e)
        {
            EventHandler handler = this.ApprovedByChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void datPrepDate_ValueChanged(object sender, EventArgs e)
        {
            OnPreparedByChanged(null);
        }

        private void datPrepTime_ValueChanged(object sender, EventArgs e)
        {
            OnPreparedByChanged(null);

        }

        private void datApproveDate_ValueChanged(object sender, EventArgs e)
        {
            OnApprovedByChanged(null);
        }

        private void datApproveTime_ValueChanged(object sender, EventArgs e)
        {
            OnApprovedByChanged(null);

        }

        private void cboPrepBy_Leave(object sender, EventArgs e)
        {
            //OnPreparedByChanged(null);

        }

        private void cboApproveBy_Leave(object sender, EventArgs e)
        {
            //OnApprovedByChanged(null);

        }

        private void chkApproved_CheckedChanged(object sender, EventArgs e)
        {
            datApproveDate.Enabled = chkApproved.Checked;
            datApproveTime.Enabled = chkApproved.Checked;   
            cboApproveBy.Enabled = chkApproved.Checked;
            OnApprovedByChanged(null);

        }

        private void cboApproveBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnApprovedByChanged(null);

        }

        private void cboPrepBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnPreparedByChanged(null);

        }
    }
}
