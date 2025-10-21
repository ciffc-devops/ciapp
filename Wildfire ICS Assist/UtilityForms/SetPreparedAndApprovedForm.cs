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

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class SetPreparedAndApprovedForm : BaseForm
    {
        public DateTime DatePrepared { get => prepAndApprovePanel1.PreparedByDateTime; set => prepAndApprovePanel1.PreparedByDateTime = value; }
        public ICSRole PreparedBy { get => prepAndApprovePanel1.PreparedByRole; }
        public DateTime DateApproved { get => prepAndApprovePanel1.ApprovedByDateTime; set => prepAndApprovePanel1.ApprovedByDateTime = value; }
        public ICSRole ApprovedBy { get => prepAndApprovePanel1.ApprovedByRole; }

        public void SetPreparedBy(Guid PreparedByRoleID, DateTime PreparedByDate)
        {
            prepAndApprovePanel1.SetPreparedBy(PreparedByRoleID, PreparedByDate);
        }
        public void SetApprovedBy(Guid ApprovedByRoleID, DateTime ApprovedByDate)
        {
            prepAndApprovePanel1.SetApprovedBy(ApprovedByRoleID, ApprovedByDate);
        }

        public SetPreparedAndApprovedForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);

        }
    }
}
