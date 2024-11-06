using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Wildfire_ICS_Assist
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Icon = Program.programIcon;
            this.BackColor = Program.FormBackground;

            //Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info
            //loop through all controls with the "Help" tag and set their icon and background colour
           


        }


        public void SetControlColors(System.Windows.Forms.Control.ControlCollection controls)
        {
            SetButtonColors(controls);
            SetDataGridViewColors(controls);
        }
        private void SetButtonColors(System.Windows.Forms.Control.ControlCollection controls)
        {
            IterateControls(controls, control =>
            {
                if(control is Button button)
                {
                    button.FlatStyle = FlatStyle.Popup;
                    button.Cursor = Cursors.Hand;
                    button.BackColor = Program.FormAccent;

                    if (control.Tag != null && control.Tag.ToString() == "ViewPDF")
                    {

                        button.Image = Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
                        button.TextImageRelation = TextImageRelation.ImageBeforeText;
                        button.ImageAlign = ContentAlignment.MiddleRight;
                        button.TextAlign = ContentAlignment.MiddleCenter;
                        button.BackColor = Program.ViewPDFColor;
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
                }
                
            });
        }

        private void SetDataGridViewColors(System.Windows.Forms.Control.ControlCollection controls)
        {
            IterateControls(controls, control =>
            {

                if (control is DataGridView view)
                {
                    view.BackgroundColor = Program.FormAccent;
                    //button.Cursor = Cursors.Help;
                }

            });
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
