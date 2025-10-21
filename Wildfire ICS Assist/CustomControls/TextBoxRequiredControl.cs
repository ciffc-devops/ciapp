using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class TextBoxRequiredControl : UserControl
    {
        [Description("Determine whether the control shows multiple lines of text"), Category("Appearance")]
        public bool Multiline
        {
            get => textBox1.Multiline; set
            {
                textBox1.Multiline = value;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when Text Changes")]

        public new event EventHandler TextChanged
        {
            add { textBox1.TextChanged += value; }
            remove { textBox1.TextChanged -= value; }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when control loses focus")]

        public new event EventHandler Leave
        {
            add { textBox1.Leave += value; }
            remove { textBox1.Leave -= value; }
        }



        public bool IsValid { get { return !string.IsNullOrEmpty(textBox1.Text); } }
        public new string Text { get => textBox1.Text; }
        public void SetText(string txt) { textBox1.Text = txt; validateTextBox(); }

        public TextBoxRequiredControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateTextBox();
        }

        private void validateTextBox()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "This field is required");
                textBox1.SetBackColor(Program.ErrorColor);
            }
            else
            {
                errorProvider1.SetError(textBox1, string.Empty);
                textBox1.SetBackColor(Program.GoodColor);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            validateTextBox();
        }

        private void TextBoxRequiredControl_Load(object sender, EventArgs e)
        {
            validateTextBox();

        }

        private void TextBoxRequiredControl_Enter(object sender, EventArgs e)
        {
            validateTextBox();

        }
    }
}
