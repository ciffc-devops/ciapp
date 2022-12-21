using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;

namespace Wildfire_ICS_Assist
{
    public partial class IncidentDetailsForm : Form
    {
        public IncidentDetailsForm()
        {
            //Test french language
            /* 
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
            */
            InitializeComponent();
        }
        private void IncidentDetailsForm_Load(object sender, EventArgs e)
        {
            SetVersionNumber();
         
        }

        private void SetVersionNumber()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            decimal d_version = Convert.ToDecimal(fileVersionInfo.ProductMajorPart + "." + fileVersionInfo.FileMinorPart, System.Globalization.CultureInfo.InvariantCulture);
            decimal d_build = Convert.ToDecimal(fileVersionInfo.FileBuildPart);
            lblVersionNumber.Text = Globals.ProgramName + " ver " + string.Format(CultureInfo.InvariantCulture, "{0:0.0#}", d_version) + "." + d_build;

        }


        private void llProgramURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = Globals.ProgramURL;
            if (null != target)
            {
                System.Diagnostics.Process.Start(target);
            }
            else
            {
                MessageBox.Show("Item clicked: " + target);
            }
        }

        private void aboutCIAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UtilityForms.AboutProgramForm aboutForm = new UtilityForms.AboutProgramForm();
            aboutForm.ShowDialog();
        }
    }
}
