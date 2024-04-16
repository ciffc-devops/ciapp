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
    public partial class EnterTextForm : BaseForm
    {
        public EnterTextForm()
        {
            InitializeComponent();
        }

        public string Question { get => lblQuestion.Text; set => lblQuestion.Text = value; }    
        public string Response { get => txtRemarks.Text; set => txtRemarks.Text = value; }
        private void EnterTextForm_Load(object sender, EventArgs e)
        {

        }
    }
}
