using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Networking;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class AuthorizeNetworkIncidentRequestForm : BaseForm
    {
        private NetworkSARTaskRequest _incomingMessage;

        public NetworkSARTaskRequest incomingMessage { get => _incomingMessage; set => _incomingMessage = value; }
        public bool TrustDevice { get => chkTrustComputer.Checked; }


        public AuthorizeNetworkIncidentRequestForm()
        {
            
            InitializeComponent(); SetControlColors(this.Controls);
        }

        private void AuthorizeNetworkIncidentRequestForm_Load(object sender, EventArgs e)
        {
            lblComputerName.Text = incomingMessage.SourceName + " " + incomingMessage.RequestIP;
            chkTrustComputer.Visible = (!string.IsNullOrEmpty(incomingMessage.RequestIP) && !string.IsNullOrEmpty(incomingMessage.SourceName));

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();

        }
    }
}
