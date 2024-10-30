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
    public partial class PrepAndApprovePanel : UserControl
    {
        public PrepAndApprovePanel()
        {
            InitializeComponent();
            PopulateRoleComboBoxes();

        }

        private Size _CollapsedSize = new Size(485, 40);
        private Size _ExpandedSize = new Size(619, 197);
        
        private bool _CollapseLeft = true;
        private bool _ExpandUp = false;
        private bool _IsCurrentlyCollapsed = false;
        private Color _BackgroundColorCollapsed = Program.FormAccent;
        private bool _ExpandAndCollapseEnabled = true;

        [Description("Text displayed at the top of the panel"), Category("Appearance")]
        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }
        [Description("Enable the expand and collapse properties"), Category("Behavior")]
        public bool EnableExpandCollapse { get => _ExpandAndCollapseEnabled; set { ToggleExpandCapability( value); } }


        [Description("If true, the panel will collapsed towards the left. if false, towards the right"), Category("Layout")]
        public bool ExpandsRight { get => _CollapseLeft; set => _CollapseLeft = value; }
        [Description("If true, the panel will expand downward from its collapsed position, or upwards"), Category("Layout")]
        public bool ExpandsUpward { get => _ExpandUp; set => _ExpandUp = value; }

        [Description("Sets the initial collapsed vs expanded status of the control"), Category("Layout")]
        public bool Collapsed { get => _IsCurrentlyCollapsed; set { if (value) { Collapse(); } else { Expand(); } } }

        [Description("The width and height of the panel when collapsed"), Category("Layout")]
        public Size SizeWhenCollapsed { get => _CollapsedSize; set => _CollapsedSize = value; }

        [Description("The width and height of the panel when Expanded"), Category("Layout")]
        public Size SizeWhenExpanded { get => _ExpandedSize; set => _ExpandedSize = value; }


        [Description("The background color to be used when collapsed. It will default to Form Accent if nothing is provided"), Category("Appearance")]
        public Color CollapsedBackgroundColor
        {
            get => _BackgroundColorCollapsed;
            set
            {
                _BackgroundColorCollapsed = value;
                if (this.Collapsed) { this.BackColor = value; SetForegroundColor(); }
                else
                {
                    btnExpandCollapse.BackColor = value;
                }
            }
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
        public void SetPreparedBy(Guid RoleID)
        {
            try { cboPrepBy.SelectedValue = RoleID; }
            catch { cboPrepBy.SelectedIndex = 0; }
        }
        public void SetApprovedBy(Guid RoleID)
        {
            try { cboApproveBy.SelectedValue = RoleID; }
            catch { cboApproveBy.SelectedIndex = 0; }
        }


        public event EventHandler PanelCollapsed;
        public event EventHandler PanelExpanded;

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

        private void ToggleExpandCapability(bool ExpandCollapseEnabled)
        {
            _ExpandAndCollapseEnabled = ExpandCollapseEnabled;
            btnExpandCollapse.Visible = ExpandCollapseEnabled;
            if (!ExpandCollapseEnabled)
            {
                lblTitle.Location = new Point(5, 0);
                lblTitle.Cursor = Cursors.Default;
            } else
            {
                lblTitle.Location = new Point(40, 0);
                lblTitle.Cursor = Cursors.Hand;
            }
        }

        public void Collapse()
        {

            if (!Collapsed)
            {


                int currentX = this.Location.X;
                int currentY = this.Location.Y;

                this.Height = SizeWhenCollapsed.Height;
                this.Width = SizeWhenCollapsed.Width;

                int newX = 0;
                int newY = 0;

                this.BackColor = CollapsedBackgroundColor;// Color.FromArgb(219, 218, 204);
                btnExpandCollapse.BackColor = Color.White;

                if (!Collapsed)
                {
                    if (ExpandsUpward)
                    {
                        newY = currentY + (SizeWhenExpanded.Height - SizeWhenCollapsed.Height);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!ExpandsRight)
                    {
                        newX = currentX + (SizeWhenExpanded.Width - SizeWhenCollapsed.Width);
                    }
                    else
                    {
                        newX = currentX;
                    }
                }


                this.Location = new Point(newX, newY);
                lblTitle.Width = this.Width - lblTitle.Location.X;


                this.SendToBack();



                btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_221_chevron_down_3x;
                _IsCurrentlyCollapsed = true;
                HandlePanelCollapsed(this, null);

                SetForegroundColor();
            }

        }

        public void Expand()
        {
            if (Collapsed)
            {
                int currentX = this.Location.X;
                int currentY = this.Location.Y;

                this.Height = SizeWhenExpanded.Height;
                this.Width = SizeWhenExpanded.Width;
                this.BackColor = Color.White;

                btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_222_chevron_up_3x;
                btnExpandCollapse.BackColor = CollapsedBackgroundColor; // Color.FromArgb(219, 218, 204); 

                int newX = 0;
                int newY = 0;

                if (Collapsed)
                {
                    if (ExpandsUpward)
                    {
                        newY = currentY - (SizeWhenExpanded.Height - SizeWhenCollapsed.Height);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!ExpandsRight)
                    {
                        newX = currentX - (SizeWhenExpanded.Width - SizeWhenCollapsed.Width);
                    }
                    else
                    {
                        newX = currentX;
                    }
                }


                this.Location = new Point(newX, newY);
                lblTitle.Width = this.Width - lblTitle.Location.X;

                this.BringToFront();
                _IsCurrentlyCollapsed = false; HandlePanelExpanded(this, null);

                SetForegroundColor();
            }
        }

        public void Toggle()
        {
            if (_ExpandAndCollapseEnabled)
            {
                if (Collapsed) { Expand(); }
                else { Collapse(); }
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

        protected virtual void OnPanelCollapsed(EventArgs e)
        {
            EventHandler handler = this.PanelCollapsed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void HandlePanelExpanded(object sender, EventArgs e)
        {
            // we'll explain this in a minute
            this.OnPanelExpanded(EventArgs.Empty);
        }

        protected virtual void OnPanelExpanded(EventArgs e)
        {
            EventHandler handler = this.PanelExpanded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void PopulateRoleComboBoxes()
        {
            if (Program.CurrentOrgChart != null)
            {
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
