using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class PrintIncidentActionPlanForm : Form
    {
        private WFIncident CurrentIncident { get => Program.CurrentIncident; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; }
        public bool PrintTaskToDate { get; set; } = false;

        public PrintIncidentActionPlanForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PrintIncidentActionPlanForm_Load(object sender, EventArgs e)
        {
            if (PrintTaskToDate)
            {
                this.Text = "Print Incident " + CurrentIncident.IncidentIdentifier;
                lblOpPeriodTitle.Text = "Print Incident " + CurrentIncident.IncidentIdentifier;
                setCheckboxStatusIncident();
            }
            else
            {
                this.Text = "Print Operational Period";
                lblOpPeriodTitle.Text = "Print Operational Period #" + CurrentOpPeriod;
                setCheckboxStatusOpPeriod();
            }
        }

        private void setCheckboxStatusOpPeriod()
        {
            chkIncidentObjectives.Enabled = CurrentIncident.hasMeaningfulObjectives(CurrentOpPeriod);
            chkIncidentObjectives.Checked = chkIncidentObjectives.Enabled;

            chkCommsPlan.Enabled = CurrentIncident.hasMeangfulCommsPlan(CurrentOpPeriod);
            chkCommsPlan.Checked = chkCommsPlan.Enabled;

            chkMedPlan.Enabled = CurrentIncident.hasMeaningfulMedicalPlan(CurrentOpPeriod);
            chkMedPlan.Checked = chkMedPlan.Enabled;

            chkOrgChart.Enabled = CurrentIncident.hasMeaningfulOrgChart(CurrentOpPeriod);
            chkOrgChart.Checked = chkOrgChart.Enabled;

            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o=>o.OpPeriod == CurrentOpPeriod && o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.OpPeriod == CurrentOpPeriod && o.Active);
            chkGeneralMessages.Checked = chkGeneralMessages.Enabled;

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active && o.OpPeriod == CurrentOpPeriod);
            chkNotes.Checked = chkNotes.Enabled;

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any(o => o.OpPeriod == CurrentOpPeriod);
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;
            chkVerboseActivityLog.Checked = chkVerboseActivityLog.Enabled;





        }

        private void setCheckboxStatusIncident()
        {
            chkIncidentObjectives.Enabled = CurrentIncident.allIncidentObjectives.Any(o => o.Objectives.Any(i => i.Active));
            chkIncidentObjectives.Checked = chkIncidentObjectives.Enabled;

            chkCommsPlan.Enabled = CurrentIncident.allCommsPlans.Any(o => o.ActiveCommsItems.Any());
            chkCommsPlan.Checked = chkCommsPlan.Enabled;

            chkMedPlan.Enabled = CurrentIncident.allMedicalPlans.Any(o=>o.ActiveAmbulances.Any() || o.ActiveAidStations.Any() || o.ActiveHospitals.Any());
            chkMedPlan.Checked = chkMedPlan.Enabled;

            chkOrgChart.Enabled = CurrentIncident.allOrgCharts.Any(o=>o.FilledRoles.Any());
            chkOrgChart.Checked = chkOrgChart.Enabled;

            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o =>  o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.Active);
            chkGeneralMessages.Checked = chkGeneralMessages.Enabled;

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active );
            chkNotes.Checked = chkNotes.Enabled;

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any();
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;
            chkVerboseActivityLog.Checked = chkVerboseActivityLog.Enabled;




        }

        private void btnSaveAsPDF_Click(object sender, EventArgs e)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(CurrentIncident);

            string fullOutputFilename = "Task " + CurrentIncident.IncidentIdentifier + " Op " + CurrentOpPeriod;    // + ".pdf";
            if (PrintTaskToDate) { fullOutputFilename = "Task " + CurrentIncident.IncidentIdentifier + " as of Op " + CurrentOpPeriod; }

            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            allPDFs.AddRange(buildContentsList());

            List<int> OpsToPrint = new List<int>();
            if (!PrintTaskToDate) { OpsToPrint.Add(CurrentOpPeriod); }
            else
            {
                foreach (OperationalPeriod op in CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber <= CurrentOpPeriod)) { OpsToPrint.Add(op.PeriodNumber); }
            }



            foreach (int op in OpsToPrint)
            {
                if (chkIncidentObjectives.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportIncidentObjectivesToPDF(CurrentIncident, op, chkFlattenPDF.Checked));
                }


                if (chkCommsPlan.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportCommsPlanToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));
                }
                //medical
                if (chkMedPlan.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportMedicalPlanToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));
                }
                //org
                if (chkOrgAssignments.Checked)
                {
                    bool IncludeContacts = Program.generalOptionsService.GetOptionsBoolValue("IncludeOrgContactsInIAP");
                    allPDFs.AddRange(Program.pdfExportService.exportOrgChartToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));
                    if (IncludeContacts)
                    {
                        allPDFs.AddRange(Program.pdfExportService.exportOrgChartContactsToPDF(CurrentIncident, CurrentOpPeriod));

                    }

                }
                //safety
                if (chkSafetyMessage.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportSafetyMessagesToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));
                }

                //general msg
                if (chkGeneralMessages.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportGeneralMessagesToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));

                }


                if (chkActivityLog.Checked)
                {
                    foreach (ICSRole role in CurrentIncident.allOrgCharts.Where(o => o.OpPeriod == op).First().AllRoles)
                    {
                        if (CurrentIncident.allPositionLogEntries.Any(o => o.Role.RoleID == role.RoleID && o.OpPeriod == op))
                        {
                            allPDFs.AddRange(Program.positionLogService.exportPositionLogToPDF(CurrentIncident, op, role, chkFlattenPDF.Checked));
                        }
                    }
                }
                if (chkVerboseActivityLog.Checked)
                {
                    foreach (ICSRole role in CurrentIncident.allOrgCharts.Where(o => o.OpPeriod == op).First().AllRoles)
                    {
                        if (CurrentIncident.allPositionLogEntries.Any(o => o.Role.RoleID == role.RoleID && o.OpPeriod == op))
                        {
                            allPDFs.AddRange(Program.positionLogService.exportVerbosePositionLogToPDF(CurrentIncident, op, role, chkFlattenPDF.Checked));
                        }
                    }
                }

                if (chkNotes.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportNotesToPDF(CurrentIncident, op));
                }
            }



            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
            }
        }

        private List<byte[]> buildContentsList()
        {
            List<string> contents = new List<string>();
            if (PrintTaskToDate)
            {
                StringBuilder opNames = new StringBuilder();

                foreach (OperationalPeriod op in CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber <= CurrentOpPeriod))
                {
                    if (opNames.Length > 0) { opNames.Append(", "); }
                    opNames.Append(op.PeriodNumber);
                }




                contents.Add("Each of the following (when available) for operational periods: " + opNames.ToString());

            }


            if (chkIncidentObjectives.Checked)
            {
                contents.Add("• ICS-202 WF Incident Objectives");
            }


            if (chkCommsPlan.Checked)
            {
                contents.Add("• ICS-205 WF Communications Plan");
            }
            //medical
            if (chkMedPlan.Checked)
            {
                contents.Add("• ICS-206 WF Medical Plan");
            }
            //org
            if (chkOrgAssignments.Checked)
            {
                bool IncludeContacts = Program.generalOptionsService.GetOptionsBoolValue("IncludeOrgContactsInIAP");
                contents.Add("• ICS-207 WF Organization Chart"); if (IncludeContacts)
                {
                    contents.Add("   • With contact list");
                }

            }
            //safety
            if (chkSafetyMessage.Checked)
            {
                contents.Add("• ICS-208 WF Safety Message/Plan(s)");
            }

            //general msg
            if (chkGeneralMessages.Checked)
            {
                contents.Add("• ICS-213 WF General Message(s)");
            }






            if (chkActivityLog.Checked)
            {
                contents.Add("• Activity Log(s) for:");
                foreach (string s in CurrentIncident.GetPositionNamesWithLogs(CurrentOpPeriod))
                {
                    contents.Add("   • " + s);
                }

            }

            if (chkVerboseActivityLog.Checked)
            {
                contents.Add("• Verbose Activity Log(s) for:");
                foreach (string s in CurrentIncident.GetPositionNamesWithLogs(CurrentOpPeriod))
                {
                    contents.Add("   • " + s);
                }

            }

          
            if (chkNotes.Checked)
            {
                contents.Add("•  Note(s)");
            }
          
            if (PrintTaskToDate)
            {
                return Program.pdfExportService.createOpPeriodContentsList(CurrentIncident, contents, 0);
            }
            else
            {
                return Program.pdfExportService.createOpPeriodContentsList(CurrentIncident, contents, CurrentOpPeriod);
            }
        }
    }
}
