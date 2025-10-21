using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist
{
    public partial class OperationalGroupBranchEditForm : BaseForm
    {
        public OperationalGroup SelectedGroup { get => editBranchControl3.SelectedGroup; set { editBranchControl3.SelectedGroup = value; } }

        public OperationalGroupBranchEditForm()
        {
            InitializeComponent(); 
         
           
        }

        private void OperationalGroupBranchEditForm_Load(object sender, EventArgs e)
        {

            if (SelectedGroup != null && SelectedGroup.PreparedByRoleID == Guid.Empty)
            {
                if (Program.CurrentRole != null)
                {
                    SelectedGroup.SetPreparedBy(Program.CurrentRole);
                }
                SelectedGroup.DatePrepared = DateTime.Now;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (editBranchControl3.IsComplete())
            {
                editBranchControl3.SaveFormValuesToSelected();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
