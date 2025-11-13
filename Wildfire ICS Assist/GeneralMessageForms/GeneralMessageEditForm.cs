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
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;

namespace Wildfire_ICS_Assist
{
    public partial class GeneralMessageEditForm : BaseForm
    {
        private GeneralMessage _generalMessage = null;
        public GeneralMessage generalMessage { get => _generalMessage; set { _generalMessage = value; DisplayMessage(); } }
        public OrganizationChart CurrentOrgChart
        {
            get
            {
                if (!Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
                {
                    Program.CurrentIncident.createOrgChartAsNeeded(Program.CurrentOpPeriod);
                }
                return Program.CurrentIncident.allOrgCharts.First(o => o.OpPeriod == Program.CurrentOpPeriod);
            }
        }

        public GeneralMessageEditForm()
        {
            
            InitializeComponent(); SetControlColors(this.Controls);
            GeneralTools.SetDateFormat(this);
            splitContainer2.BackColor = Program.AccentColor;
        }

        List<Control> requiredFields = new List<Control>();

        private void DisplayMessage()
        {
            PopulateComboBox(cboFrom);

            txtToName.Text = generalMessage.ToName;
            txtToPosition.Text = generalMessage.ToPosition;
            txtSubject.Text = generalMessage.Subject;
            txtMessage.Text = generalMessage.Message;
            txtReply.Text = generalMessage.Reply;
            txtReplyName.Text = generalMessage.ReplyByName;
            txtReplyPosition.Text = generalMessage.ReplyByPosition;
            if (generalMessage.DateSent != DateTime.MinValue) { datMessageSent.Value = generalMessage.DateSent; }
            else { datMessageSent.Value = DateTime.Now; }
            if (generalMessage.ReplyDate != DateTime.MinValue) { datReplyReceived.Value = generalMessage.ReplyDate; datReplyReceived.Checked = true; }
            else { datMessageSent.Value = DateTime.Now; datReplyReceived.Checked = false; }
            if (generalMessage.FromRoleID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == generalMessage.FromRoleID)) { cboFrom.SelectedValue = generalMessage.FromRoleID; }

            prepAndApprovePanel1.SetPreparedBy(generalMessage.PreparedByRoleID, generalMessage.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(generalMessage.ApprovedByRoleID, generalMessage.DateApproved);
            
        }

        private void PopulateComboBox(ComboBox cbo)
        {

            List<ICSRole> roles = CurrentOrgChart.Clone().ActiveRoles;
            ICSRole blank = new ICSRole();
            blank.RoleID = Guid.Empty;
            blank.BaseRoleName = "-None-";
            roles.Insert(0, blank);
            cbo.DataSource = roles;
            cbo.DisplayMember = "RoleNameWithIndividualAndDepth";
            cbo.ValueMember = "RoleID";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtToName_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ToName = ((TextBox)sender).Text.Trim(); _ = ValidateNew();
        }

        private void txtToPosition_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ToPosition = ((TextBox)sender).Text.Trim(); _ = ValidateNew();

        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            generalMessage.Subject = ((TextBox)sender).Text.Trim(); _ = ValidateNew();

        }

        private void datMessageSent_ValueChanged(object sender, EventArgs e)
        {
            generalMessage.DateSent = datMessageSent.Value;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            generalMessage.Message = ((SpellBox)sender).Text.Trim();
            _ = ValidateNew();
        }

        private void txtReply_TextChanged(object sender, EventArgs e)
        {
            generalMessage.Reply = ((SpellBox)sender).Text.Trim(); _ = ValidateNew();
            datReplyReceived.Checked = !string.IsNullOrEmpty(generalMessage.Reply);

        }

        private void txtReplyName_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ReplyByName = ((TextBox)sender).Text.Trim(); _ = ValidateNew();
            datReplyReceived.Checked = !string.IsNullOrEmpty(generalMessage.Reply);
        }

        private void txtReplyPosition_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ReplyByPosition = ((TextBox)sender).Text.Trim(); _ = ValidateNew();
            datReplyReceived.Checked = !string.IsNullOrEmpty(generalMessage.Reply);
        }

        private void datReplyReceived_ValueChanged(object sender, EventArgs e)
        {
            generalMessage.ReplyDate = datReplyReceived.Value;
            
        }

        private void cboFrom_Leave(object sender, EventArgs e)
        {
            if (cboFrom.SelectedItem != null)
            {
                ICSRole from = (ICSRole)cboFrom.SelectedItem;
                generalMessage.FromRoleID = from.RoleID;
                generalMessage.FromName = from.IndividualName;
                generalMessage.FromPosition = from.RoleName;
            }
            else
            {
                generalMessage.FromRoleID = Guid.Empty;
                generalMessage.FromName = string.Empty;
                generalMessage.FromPosition = string.Empty;
            }
        }

 
        private void GeneralMessageEditForm_Load(object sender, EventArgs e)
        {
            requiredFields.Add(txtMessage);
            requiredFields.Add(txtSubject);


        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateNew())
            {
                DateTime dat = generalMessage.DatePrepared;

                if (datReplyReceived.Checked)
                {
                    generalMessage.ReplyDate = datReplyReceived.Value;
                }
                else
                {
                    generalMessage.ReplyDate = DateTime.MinValue;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateNew()
        {
            bool isValid = true;
            foreach (Control ctrl in requiredFields)
            {
                if (string.IsNullOrEmpty(ctrl.Text)) { errorProvider1.SetError(ctrl, Properties.Resources.RequiredNote); isValid = false; }
                else { errorProvider1.SetError(ctrl, ""); }
            }

           

            if (!string.IsNullOrEmpty(txtReply.Text))
            {
                //require one or the other of these items
                if (string.IsNullOrEmpty(txtReplyName.Text) && string.IsNullOrEmpty(txtReplyPosition.Text))
                {
                    errorProvider1.SetError(txtReplyName, Properties.Resources.RequiredNote);
                    errorProvider1.SetError(txtReplyPosition, Properties.Resources.RequiredNote);
                    isValid = false;
                }
                else
                {
                    errorProvider1.SetError(txtReplyName, "");
                    errorProvider1.SetError(txtReplyPosition, "");
                }
            }

            return isValid;
        }

        private void prepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            generalMessage.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
            generalMessage.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;

        }

        private void prepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            generalMessage.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
            generalMessage.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;

        }

        private void txtMessage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text)) { errorProvider1.SetError(txtMessage, Properties.Resources.RequiredNote); }
            else { errorProvider1.SetError(txtMessage, ""); }
        }

        private void txtToName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtToName.Text)) { errorProvider1.SetError(txtToName, Properties.Resources.RequiredNote); }
            else { errorProvider1.SetError(txtToName, ""); }
        }

        private void txtSubject_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubject.Text)) { errorProvider1.SetError(txtSubject, Properties.Resources.RequiredNote); }
            else { errorProvider1.SetError(txtSubject, ""); }

        }
    }
}
