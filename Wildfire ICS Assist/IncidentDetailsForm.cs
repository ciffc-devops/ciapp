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
using Wildfire_ICS_Assist.OptionsForms;

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

        //These hold a reference to the various forms so that only one of each can be open at a time.
        List<Form> ActiveForms = new List<Form>();
        HospitalsForm hospitalsForm = null;
        MedivacsForm medivacsForm = null;
        SavedContactsForm savedContactsForm = null;
        SavedCommsItemsForm savedCommsItemsForm= null;
        SavedVehiclesForm savedVehiclesForm= null;
        SavedIncidentObjectivesForm savedObjectivesForm = null;
        SavedSafetyNotesForm savedSafetyNotesForm = null;
        SavedTeamMembersForm savedTeamMembersForm = null;


        private void RemoveActiveForm(Form form)
        {
            if (form != null) { ActiveForms = ActiveForms.Where(o => o.GetType() != form.GetType()).ToList(); }
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

        private void hospitalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == hospitalsForm)
            {
                hospitalsForm = new HospitalsForm();
                hospitalsForm.FormClosed += HospitalsForm_Closed;
                hospitalsForm.Show(this);
                ActiveForms.Add(hospitalsForm);
            }

            hospitalsForm.BringToFront();
        }

        void HospitalsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(hospitalsForm);
            hospitalsForm = null;

        }

        private void medivacServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == medivacsForm)
            {
                medivacsForm = new MedivacsForm();
                medivacsForm.FormClosed += MedivacsForm_Closed;
                medivacsForm.Show(this);
                ActiveForms.Add(medivacsForm);
            }

            medivacsForm.BringToFront();
        }

        void MedivacsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(medivacsForm);
            medivacsForm = null;

        }

        private void contactsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (null == savedContactsForm)
            {
                savedContactsForm = new SavedContactsForm();
                savedContactsForm.FormClosed += SavedContactsForm_Closed;
                savedContactsForm.Show(this);
                ActiveForms.Add(savedContactsForm);
            }

            savedContactsForm.BringToFront();
        }

        void SavedContactsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedContactsForm);
            savedContactsForm = null;

        }

        private void communicationsSystemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedCommsItemsForm)
            {
                savedCommsItemsForm = new SavedCommsItemsForm();
                savedCommsItemsForm.FormClosed += SavedCommsPlanItemsForm_Closed;
                savedCommsItemsForm.Show(this);
                ActiveForms.Add(savedCommsItemsForm);
            }

            savedCommsItemsForm.BringToFront();
        }

        void SavedCommsPlanItemsForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedCommsItemsForm);
            savedCommsItemsForm = null;

        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedVehiclesForm)
            {
                savedVehiclesForm = new SavedVehiclesForm();
                savedVehiclesForm.FormClosed += SavedVehiclesForm_Closed;
                savedVehiclesForm.Show(this);
                ActiveForms.Add(savedVehiclesForm);
            }

            savedVehiclesForm.BringToFront();
        }

        void SavedVehiclesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedVehiclesForm);
            savedVehiclesForm = null;

        }

        private void teamMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedTeamMembersForm)
            {
                savedTeamMembersForm = new SavedTeamMembersForm();
                savedTeamMembersForm.FormClosed += SavedTeamMembersForm_Closed;
                savedTeamMembersForm.Show(this);
                ActiveForms.Add(savedTeamMembersForm);
            }

            savedTeamMembersForm.BringToFront();
        }

        void SavedTeamMembersForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedTeamMembersForm);
            savedTeamMembersForm = null;

        }

        private void incidentObjectivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedObjectivesForm)
            {
                savedObjectivesForm = new SavedIncidentObjectivesForm();
                savedObjectivesForm.FormClosed += SavedObjectivesForm_Closed;
                savedObjectivesForm.Show(this);
                ActiveForms.Add(savedObjectivesForm);
            }

            savedObjectivesForm.BringToFront();
        }

        void SavedObjectivesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedObjectivesForm);
            savedObjectivesForm = null;

        }

        private void safetyNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == savedSafetyNotesForm)
            {
                savedSafetyNotesForm = new SavedSafetyNotesForm();
                savedSafetyNotesForm.FormClosed += SavedSafetyNotesForm_Closed;
                savedSafetyNotesForm.Show(this);
                ActiveForms.Add(savedSafetyNotesForm);
            }

            savedSafetyNotesForm.BringToFront();
        }

        void SavedSafetyNotesForm_Closed(object sender, FormClosedEventArgs e)
        {
            RemoveActiveForm(savedSafetyNotesForm);
            savedSafetyNotesForm = null;

        }
    }
}
