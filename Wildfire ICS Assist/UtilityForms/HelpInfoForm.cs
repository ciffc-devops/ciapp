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
    public partial class HelpInfoForm : Form
    {
        public string Title { get { return lblTitle.Text; } set { lblTitle.Text = value; this.Text = value; } }
        public string Body { get { return txtHelpText.Text; } set { txtHelpText.Text = value; } }
        public string MoreInfoButtonText { get { return btnMoreInfo.Text; } set { btnMoreInfo.Text = value; btnMoreInfo.Visible = !string.IsNullOrEmpty(value); } }
        private string _moreInfoURL;
        public string MoreInfoURL { get => _moreInfoURL; set => _moreInfoURL = value; }

        public void SetHelpItem(HelpInfo info)
        {
            Title = info.Title;
            Body = info.Body;
            MoreInfoButtonText = info.MoreInfoButtonText;
            MoreInfoURL = info.MoreInfoURL;
        }

        public void SetHelpItem(string helpID)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic(helpID))
            {
                SetHelpItem(info);
            }
        }

        public HelpInfoForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;
            this.Icon = Program.programIcon;

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!string.IsNullOrEmpty(MoreInfoURL))
            {
                System.Diagnostics.Process.Start(MoreInfoURL);
            }

        }

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
