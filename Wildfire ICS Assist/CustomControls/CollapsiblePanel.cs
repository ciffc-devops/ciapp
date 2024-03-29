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
        private bool _CurrentlyCollapsed = true;

        [Description("Text displayed at the top of the panel"), Category("Appearance")]
        public string TitleText { get => lblTitle.Text; set => lblTitle.Text = value; }

        [Description("If true, the panel will collapsed towards the left. if false, towards the right"), Category("Appearance")]
        public bool CollapseLeft { get => _CollapseLeft; set => _CollapseLeft = value; }

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


        public event EventHandler PanelCollapsed;
        public event EventHandler PanelExpanded;


        public CollapsiblePanel()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        public void Collapse()
        {
            int currentX = this.Location.X;
            int currentY = this.Location.Y;

            this.Height = CollapsedHeight;
            this.Width = CollapsedWidth;

            this.BackColor = Program.FormAccent;// Color.FromArgb(219, 218, 204);
            btnExpandCollapse.BackColor = Color.White;

            if (!CollapseLeft && !CurrentlyCollapsed)
            {
                int collapsedX = currentX;
                collapsedX = currentX + (ExpandedWidth - CollapsedWidth);
                this.Location = new Point(collapsedX, currentY);
            }

            lblTitle.Width = this.Width  - lblTitle.Location.X;


            this.SendToBack();
            


            btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_221_chevron_down_3x;
            _CurrentlyCollapsed = true;
            HandlePanelCollapsed(this, null);
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

        public void Expand()
        {
            int currentX = this.Location.X;
            int currentY = this.Location.Y;

            this.Height = ExpandedHeight;
            this.Width = ExpandedWidth;
            this.BackColor = Color.White;

            btnExpandCollapse.BackgroundImage = Properties.Resources.glyphicons_basic_222_chevron_up_3x;
            btnExpandCollapse.BackColor = Program.FormAccent; // Color.FromArgb(219, 218, 204); 

            if (!CollapseLeft && CurrentlyCollapsed)
            {
                int collapsedX = currentX;
                collapsedX = currentX - (ExpandedWidth - CollapsedWidth);
                this.Location = new Point(collapsedX, currentY);
            }
            lblTitle.Width = this.Width  - lblTitle.Location.X;

            this.BringToFront();
            _CurrentlyCollapsed = false;
            HandlePanelExpanded(this, null);
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
    }

}
