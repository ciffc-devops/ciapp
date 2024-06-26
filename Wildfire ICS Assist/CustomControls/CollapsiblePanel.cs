﻿using System;
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
        private bool _CurrentlyCollapsed = true;
        private Color _BackgroundColorCollapsed = Program.FormAccent;

        [Description("Text displayed at the top of the panel"), Category("Appearance")]
        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }

        [Description("If true, the panel will collapsed towards the left. if false, towards the right"), Category("Appearance")]
        public bool CollapseLeft { get => _CollapseLeft; set => _CollapseLeft = value; }
        [Description("If true, the panel will expand downward from its collapsed position, or upwards"), Category("Appearance")]
        public bool ExpandUp { get => _ExpandUp; set => _ExpandUp = value; }

        [Description("Sets the initial collapsed vs expanded status of the control"), Category("Appearance")]
        public bool CurrentlyCollapsed { get => _CurrentlyCollapsed; set { if (value) { Collapse(); } else { Expand(); } } }



        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int CollapsedHeight { get => _CollapsedHeight; set => _CollapsedHeight = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int CollapsedWidth { get => _CollapsedWidth; set => _CollapsedWidth = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int ExpandedWidth { get => _ExpandedWidth; set => _ExpandedWidth = value; }

        [Description("The width of the panel when collapsed"), Category("Layout")]
        public int ExpandedHeight { get => _ExpandedHeight; set => _ExpandedHeight = value; }

        [Description("The background color to be used when collapsed. It will default to Form Accent if nothing is provided"), Category("Appearance")]
        public Color BackgroundColorCollapsed
        {
            get => _BackgroundColorCollapsed;
            set
            {
                _BackgroundColorCollapsed = value;
                if (this.CurrentlyCollapsed) { this.BackColor = value; SetForegroundColor(); }
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

            if (!CurrentlyCollapsed)
            {


                int currentX = this.Location.X;
                int currentY = this.Location.Y;

                this.Height = CollapsedHeight;
                this.Width = CollapsedWidth;

                int newX = 0;
                int newY = 0;

                this.BackColor = BackgroundColorCollapsed;// Color.FromArgb(219, 218, 204);
                btnExpandCollapse.BackColor = Color.White;

                if (!CurrentlyCollapsed)
                {
                    if (ExpandUp)
                    {
                        newY = currentY + (ExpandedHeight - CollapsedHeight);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!CollapseLeft)
                    {
                        newX = currentX + (ExpandedWidth - CollapsedWidth);
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
                _CurrentlyCollapsed = true;
                HandlePanelCollapsed(this, null);

                SetForegroundColor();
            }

        }

        public void Expand()
        {
            if (CurrentlyCollapsed)
            {
                int currentX = this.Location.X;
                int currentY = this.Location.Y;

                this.Height = ExpandedHeight;
                this.Width = ExpandedWidth;
                this.BackColor = Color.White;

                btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_222_chevron_up_3x;
                btnExpandCollapse.BackColor = BackgroundColorCollapsed; // Color.FromArgb(219, 218, 204); 

                int newX = 0;
                int newY = 0;

                if (CurrentlyCollapsed)
                {
                    if (ExpandUp)
                    {
                        newY = currentY - (ExpandedHeight - CollapsedHeight);
                    }
                    else
                    {
                        newY = currentY;
                    }

                    if (!CollapseLeft)
                    {
                        newX = currentX - (ExpandedWidth - CollapsedWidth);
                    }
                    else
                    {
                        newX = currentX;
                    }
                }


                this.Location = new Point(newX, newY);
                lblTitle.Width = this.Width - lblTitle.Location.X;

                this.BringToFront();
                _CurrentlyCollapsed = false; HandlePanelExpanded(this, null);

                SetForegroundColor();
            }
        }

        public void Toggle()
        {
            if (CurrentlyCollapsed) { Expand(); }
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
