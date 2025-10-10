using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class LgMessageBoxForm: BaseForm
    {
        public string MessageText { get { return lblMessageText.Text; } set { lblMessageText.Text = value; } }
        public string TitleText { get => this.Text; set => this.Text = value; }

        public LgMessageBoxForm(string Message_Text, string Message_Title = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            InitializeComponent();
            MessageText = Message_Text;
            TitleText = Message_Title;

            // Dynamically calculate the size of the label and adjust the form size
            using (Graphics g = lblMessageText.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(lblMessageText.Text, lblMessageText.Font, lblMessageText.Width);

                // Adjust the form height based on the label's height
                this.Height = lblMessageText.Top + (int)Math.Ceiling(textSize.Height) + flowLayoutPanel1.Height + 100; // Add padding for buttons and margins
            }





            if (buttons == MessageBoxButtons.OK)
            {
                AddButton(DialogResult.OK);
            }
            else if (buttons == MessageBoxButtons.YesNo)
            {
                AddButton(DialogResult.No);
                AddButton(DialogResult.Yes);

            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                AddButton(DialogResult.Cancel);
                AddButton(DialogResult.OK);


            }
            else if (buttons == MessageBoxButtons.YesNoCancel)
            {



                AddButton(DialogResult.Cancel);
                AddButton(DialogResult.No);
                AddButton(DialogResult.Yes);
            }
            if (icon != MessageBoxIcon.None)
            {
                //todo
            }
        }

        private void AddButton(DialogResult result)
        {
            Button newButton = new Button();
            newButton.AutoSize = true;
            newButton.Padding = new Padding(5, 5, 5, 5);
            newButton.ImageAlign = ContentAlignment.MiddleRight;
            newButton.TextImageRelation = TextImageRelation.ImageBeforeText;

            switch (result)
            {
                case DialogResult.OK:
                    newButton.Text = "OK";
                    this.CancelButton = newButton;
                    break;
                case DialogResult.Cancel:
                    newButton.Text = "Cancel";
                    newButton.Image = Properties.Resources.glyphicons_basic_223_chevron_left;
                    this.CancelButton = newButton;
                    break;
                case DialogResult.Yes:
                    newButton.Text = "Yes";
                    newButton.Image = Properties.Resources.glyphicons_basic_739_check;
                    this.AcceptButton = newButton;
                    break;
                case DialogResult.No:
                    newButton.Text = "No";
                    newButton.Image = Properties.Resources.glyphicons_basic_193_circle_empty_remove;

                    break;


            }
            newButton.DialogResult |= result;
            newButton.Focus();
            flowLayoutPanel1.Controls.Add(newButton);
        }
    }

    public static class LgMessageBox
    {
        public static DialogResult Show(string message, string title = null, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            return new LgMessageBoxForm(message, title, buttons).ShowDialog();
        }
    }
}
