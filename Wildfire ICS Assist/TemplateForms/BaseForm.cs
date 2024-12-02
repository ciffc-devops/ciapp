using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wildfire_ICS_Assist.CustomControls;
using static System.Windows.Forms.Control;

namespace Wildfire_ICS_Assist
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackgroundColor;

            //Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info
            //loop through all controls with the "Help" tag and set their icon and background colour
           


        }

        public void applyResources(ComponentResourceManager resources, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                //if (ctl.GetType() == typeof(SpellBox))                {                    ((SpellBox)ctl).Language = CultureInfo.CurrentCulture;                }
                applyResources(resources, ctl.Controls);
            }
        }
        public void SetControlColors(System.Windows.Forms.Control.ControlCollection controls)
        {
            IterateControls(controls, control =>
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Popup;
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Program.AccentColor;

                    if (control.Tag != null && control.Tag.ToString() == "ViewPDF")
                    {

                        button.Image = Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.PrimaryColor;
                        //button.Cursor = Cursors.Help;

                    }
                    else if (control.Tag != null && control.Tag.ToString() == "Help")
                    {
                        button.Image = Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.HelpColor;
                        button.Cursor = Cursors.Help;

                    }
                    else if (control.Tag != null && control.Tag.ToString() == "HelpSM")
                    {
                        button.BackgroundImage = Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
                        button.BackgroundImageLayout = ImageLayout.Stretch;
                        //button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        //button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.HelpColor;
                        button.Cursor = Cursors.Help;

                    } else if (control.Tag != null && control.Tag.ToString().Equals("Save"))
                    {

                        button.Image = Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.SaveColor;
                        //button.Cursor = Cursors.Help;

                    }
                    else if (control.Tag != null && control.Tag.ToString().Equals("AddToIncident"))
                    {

                        button.Image = Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.SaveColor;
                        //button.Cursor = Cursors.Help;

                    }
                }
                else if (control is DataGridView view)
                {
                    view.BackgroundColor = Program.AccentColor;
                    //button.Cursor = Cursors.Help;
                }
                else if (control is TabControl tabControl)
                {
                    tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                    tabControl.DrawItem += TabControl_DrawItem;
                    tabControl.Padding = new Point(15, 10);

                    foreach (TabPage tab in tabControl.TabPages)
                    {
                        tab.BorderStyle = BorderStyle.Fixed3D;
                        
                    }
                }

            });
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControlExt.tabControlCustomColor_DrawItem(sender, e);

        }

     

     
        public static void IterateControls(System.Windows.Forms.Control.ControlCollection controls, Action<Control> action)
        {
            foreach (Control control in controls)
            {
                action(control);
                if (control.HasChildren)
                {
                    IterateControls(control.Controls, action);
                }
            }
        }
    }
}
