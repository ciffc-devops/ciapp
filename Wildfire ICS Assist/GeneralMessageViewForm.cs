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
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class GeneralMessageViewForm : Form
    {
        private GeneralMessage _generalMessage = null;
        public GeneralMessage generalMessage { get => _generalMessage; set { _generalMessage = value; DisplayMessage(); } }

        public GeneralMessageViewForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void DisplayMessage()
        {

            lblTo.Text = generalMessage.To;
            lblFrom.Text = generalMessage.From;
            lblApprovedBy.Text = generalMessage.ApprovedBy;
            lblSubject.Text = generalMessage.Subject;
            txtMessage.Text = generalMessage.Message;
            txtReply.Text = generalMessage.Reply;
            lblReplyBy.Text = generalMessage.ReplyBy;
            if (generalMessage.DateSent != DateTime.MinValue) { lblDateSent.Text = string.Format("{0:yyyy-MMM-dd HH:mm}", generalMessage.DateSent); }
            else { lblDateSent.Text = string.Empty; }
            if (generalMessage.ReplyDate != DateTime.MinValue) { lblReplyReceived.Text = string.Format("{0:yyyy-MMM-dd HH:mm}", generalMessage.ReplyDate); }
            else { lblReplyReceived.Text = string.Empty; }
            

        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            string path = Program.pdfExportService.createGeneralMessagePDF(Program.CurrentIncident, generalMessage, false, true);
            if (!string.IsNullOrEmpty(path))
            {
                System.Diagnostics.Process.Start(path);
            }


        }

        private void GeneralMessageViewForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
