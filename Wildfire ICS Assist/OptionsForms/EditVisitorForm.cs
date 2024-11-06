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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class EditVisitorForm : BaseForm
    {
        public Personnel selectedPerson { get => visitorEditControl1.selectedPerson; set { visitorEditControl1.setPerson(value); } }    

        public EditVisitorForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);
        }

        private void EditVisitorForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (visitorEditControl1.FormValid)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
