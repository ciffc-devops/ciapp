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
            
            InitializeComponent(); 
            GeneralTools.SetDateFormat(this);
        }

        List<Control> requiredFields = new List<Control>();

        private void DisplayMessage()
        {
            PopulateComboBox(cboFrom);
            PopulateComboBox(cboApprovedBy);

            txtToName.Text = generalMessage.ToName;
            txtToPosition.Text = generalMessage.ToPosition;
            txtSubject.Text = generalMessage.Subject;
            txtMessage.Text = generalMessage.Message;
            txtReply.Text = generalMessage.Reply;
            txtReplyName.Text = generalMessage.ReplyByName;
            txtReplyPosition.Text = generalMessage.ReplyByPosition;
            if (generalMessage.DateSent != DateTime.MinValue) { datMessageSent.Value = generalMessage.DateSent; }
            else { datMessageSent.Value = DateTime.Now; }
            if (generalMessage.ReplyDate != DateTime.MinValue) { datReplyReceived.Value = generalMessage.ReplyDate; }
            else { datMessageSent.Value = DateTime.Now; }
            if (generalMessage.FromRoleID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == generalMessage.FromRoleID)) { cboFrom.SelectedValue = generalMessage.FromRoleID; }
            if (generalMessage.ApprovedByRoleID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == generalMessage.ApprovedByRoleID)) { cboApprovedBy.SelectedValue = generalMessage.ApprovedByRoleID; }

        }

        private void PopulateComboBox(ComboBox cbo)
        {

            List<ICSRole> roles = CurrentOrgChart.Clone().ActiveRoles;
            ICSRole blank = new ICSRole();
            blank.RoleID = Guid.Empty;
            blank.RoleName = "-None-";
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

        }

        private void txtReplyName_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ReplyByName = ((TextBox)sender).Text.Trim(); _ = ValidateNew();

        }

        private void txtReplyPosition_TextChanged(object sender, EventArgs e)
        {
            generalMessage.ReplyByPosition = ((TextBox)sender).Text.Trim(); _ = ValidateNew();

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

        private void cboApprovedBy_Leave(object sender, EventArgs e)
        {
            if (cboApprovedBy.SelectedItem != null)
            {
                ICSRole approvedBy = (ICSRole)cboApprovedBy.SelectedItem;
                generalMessage.ApprovedByRoleID = approvedBy.RoleID;
                generalMessage.ApprovedByName = approvedBy.IndividualName;
                generalMessage.ApprovedByPosition = approvedBy.RoleName;
            }
            else
            {
                generalMessage.ApprovedByRoleID = Guid.Empty;
                generalMessage.ApprovedByName = string.Empty;
                generalMessage.ApprovedByPosition = string.Empty;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateNew()
        {
            bool isValid = true;
            foreach (Control ctrl in requiredFields)
            {
                if (string.IsNullOrEmpty(ctrl.Text)) { ctrl.BackColor = Program.ErrorColor; isValid = false; }
                else { ctrl.BackColor = Program.GoodColor; }
            }

            //require one or the other of these items
            if(string.IsNullOrEmpty(txtToName.Text) && string.IsNullOrEmpty(txtToPosition.Text))
            {
                txtToName.BackColor = Program.ErrorColor; txtToPosition.BackColor = Program.ErrorColor;
                isValid = false;
            } else
            {
                txtToName.BackColor = Program.GoodColor; txtToPosition.BackColor = Program.GoodColor;
            }

            if (!string.IsNullOrEmpty(txtReply.Text))
            {
                //require one or the other of these items
                if (string.IsNullOrEmpty(txtReplyName.Text) && string.IsNullOrEmpty(txtReplyPosition.Text))
                {
                    txtReplyName.BackColor = Program.ErrorColor; txtReplyPosition.BackColor = Program.ErrorColor;
                    isValid = false;
                }
                else
                {
                    txtReplyName.BackColor = Program.GoodColor; txtReplyPosition.BackColor = Program.GoodColor;
                }
            } else { txtReply.BackColor = Program.StandardTextboxColor; }

            return isValid;
        }
    }
}
