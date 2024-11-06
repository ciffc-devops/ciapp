using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class SelectBooleanForm : BaseForm
    {
        public string Question { get => lblQuestion.Text; set => lblQuestion.Text = value; }    
        public bool Response { get => rbYes.Checked; set { rbYes.Checked = value;  rbNo.Checked = !value; } }
        public SelectBooleanForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }
    }
}
