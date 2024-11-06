using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Security.Policy;
using WF_ICS_ClassLibrary.EventHandling;
using Microsoft.VisualStudio.PlatformUI;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.CustomControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CollapsiblePanel : UserControl
    {
        private int _CollapsedWidth = 485;
        private int _CollapsedHeight = 40;
        private int _ExpandedWidth = 485;
        private int _ExpandedHeight = 300;
        private bool _CollapseLeft = true;
        private bool _ExpandUp = false;
        private bool _IsCurrentlyCollapsed = true;
        private Color _BackgroundColorCollapsed = Program.FormAccent; 
        private bool _ExpandAndCollapseEnabled = true;


        [Description("Enable the expand and collapse properties"), Category("Behavior")]
        public bool EnableExpandCollapse { get => _ExpandAndCollapseEnabled; set { ToggleExpandCapability(value); } }


        [Description("Text displayed at the top of the panel"), Category("Appearance")]
        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }

        [Description("If true, the panel will collapsed towards the left. if false, towards the right"), Category("Appearance")]
        public bool ExpandsRight { get => _CollapseLeft; set => _CollapseLeft = value; }
        [Description("If true, the panel will expand downward from its collapsed position, or upwards"), Category("Appearance")]
        public bool ExpandsUpward { get => _ExpandUp; set => _ExpandUp = value; }

        [Description("Sets the initial collapsed vs expanded status of the control"), Category("Appearance")]
        public bool Collapsed { get => _IsCurrentlyCollapsed; set { if (value) { Collapse(); } else { Expand(); } } }



        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int HeightWhenCollapsed { get => _CollapsedHeight; set => _CollapsedHeight = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int WidthWhenCollapsed { get => _CollapsedWidth; set => _CollapsedWidth = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int WidthWhenExpanded { get => _ExpandedWidth; set => _ExpandedWidth = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int HeightWhenExpanded { get => _ExpandedHeight; set => _ExpandedHeight = value; }

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

        public event EventHandler PanelCollapsed;
        public event EventHandler PanelExpanded;

        public CollapsiblePanel()
        {
            InitializeComponent();
        }

        private void ToggleExpandCapability(bool ExpandCollapseEnabled)
        {
            _ExpandAndCollapseEnabled = ExpandCollapseEnabled;
            btnExpandCollapse.Visible = ExpandCollapseEnabled;
            if (!ExpandCollapseEnabled)
            {
                lblTitle.Location = new Point(5, 0);
                lblTitle.Cursor = Cursors.Default;
            }
            else
            {
                lblTitle.Location = new Point(40, 0);
                lblTitle.Cursor = Cursors.Hand;
            }
        }
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

        public void Collapse()
        {

            if (!Collapsed)
            {


                int currentX = this.Location.X;
                int currentY = this.Location.Y;

                this.Height = HeightWhenCollapsed;
                this.Width = WidthWhenCollapsed;

                int newX = 0;
                int newY = 0;

                this.BackColor = CollapsedBackgroundColor;// Color.FromArgb(219, 218, 204);
                btnExpandCollapse.BackColor = Color.White;

                if (!Collapsed)
                {
                    if (ExpandsUpward)
                    {
                        newY = currentY + (HeightWhenExpanded - HeightWhenCollapsed);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!ExpandsRight)
                    {
                        newX = currentX + (WidthWhenExpanded - WidthWhenCollapsed);
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

                this.Height = HeightWhenExpanded;
                this.Width = WidthWhenExpanded;
                this.BackColor = Color.White;

                btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_222_chevron_up_3x;
                btnExpandCollapse.BackColor = CollapsedBackgroundColor; // Color.FromArgb(219, 218, 204); 

                int newX = 0;
                int newY = 0;

                if (Collapsed)
                {
                    if (ExpandsUpward)
                    {
                        newY = currentY - (HeightWhenExpanded - HeightWhenCollapsed);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!ExpandsRight)
                    {
                        newX = currentX - (WidthWhenExpanded - WidthWhenCollapsed);
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
            if (Collapsed) { Expand(); }
            else { Collapse(); }
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
    }
}
