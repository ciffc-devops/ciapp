using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class ICSFormHelpForm : BaseForm
    {
        public ICSFormInformation SelectedForm { get; set; }
        public ICSFormHelpForm()
        {
            InitializeComponent();
        }

        private void ICSFormHelpForm_Load(object sender, EventArgs e)
        {
            if (SelectedForm != null)
            {
                tabControl1.TabPages[0].Text = SelectedForm.NameWithNumber;
                lblPurpose.Text = SelectedForm.Purpose;
                lblPreparation.Text = SelectedForm.Preparation;
                lblDistribution.Text = SelectedForm.Distribution;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = SelectedForm.Fields;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
