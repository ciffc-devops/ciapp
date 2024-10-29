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
using Wildfire_ICS_Assist.CustomControls;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class PrintIncidentForm : BaseForm
    {
        private Incident CurrentIncident { get => Program.CurrentIncident; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; }
        public bool PrintIncidentToDate { get; set; } = false;
        public bool PrintIAPByDefault { get; set; } = false;
        public PrintIncidentForm()
        {
            InitializeComponent(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PrintIncidentForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            if (PrintIncidentToDate)
            {
                this.Text = "Print Incident " + CurrentIncident.IncidentIdentifier;
                lblOpPeriodTitle.Text = "Print Incident " + CurrentIncident.IncidentIdentifier;

                if (PrintIAPByDefault) { setCheckboxStatusIncidentIAP(); }
                else { setCheckboxStatusIncident(); }
                if (!string.IsNullOrEmpty(CurrentIncident.IncidentTitleImageBytes))
                {
                    Image img = CurrentIncident.IncidentTitleImageBytes.getImageFromBytes();
                    if (img != null) { picTitleImage.Image = img; }
                }
            }
            else
            {
                OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);

                this.Text = "Print Operational Period";
                lblOpPeriodTitle.Text = "Print Operational Period #" + CurrentOpPeriod;
                if (PrintIAPByDefault) { setCheckboxeStatusIAP(); }
                else { setCheckboxStatusOpPeriod(); }
                txtCriticalMessage.Text = period.CriticalMessage;
                if (!string.IsNullOrEmpty(period.TitleImageBytes))
                {
                    Image img = period.TitleImageBytes.getImageFromBytes();
                    if (img != null) { picTitleImage.Image = img; }
                }
            }
        }

        private void setCheckboxeStatusIAP()
        {
            chkIncidentObjectives.Enabled = CurrentIncident.hasMeaningfulObjectives(CurrentOpPeriod);
            chkIncidentObjectives.Checked = chkIncidentObjectives.Enabled;

            chkCommsPlan.Enabled = CurrentIncident.hasMeangfulCommsPlan(CurrentOpPeriod);
            chkCommsPlan.Checked = chkCommsPlan.Enabled;

            chkMedPlan.Enabled = CurrentIncident.hasMeaningfulMedicalPlan(CurrentOpPeriod);
            chkMedPlan.Checked = chkMedPlan.Enabled;

            chkOrgChart.Enabled = CurrentIncident.hasMeaningfulOrgChart(CurrentOpPeriod);
            chkOrgAssignments.Enabled = chkOrgChart.Enabled;
            chkOrgAssignments.Checked = chkOrgAssignments.Enabled;

            chkAssignments.Enabled = CurrentIncident.hasMeaningfulTeamAssignments(CurrentOpPeriod);
            chkAssignments.Checked = chkAssignments.Enabled;
            chkAssignmentDetails.Enabled = chkAssignments.Enabled;

            //additional contacts
            chkContacts.Enabled = CurrentIncident.allContacts.Any(o => o.Active);

            chkCheckInLists.Enabled = CurrentIncident.AllCheckInRecords.Any(o => o.OpPeriod <= Program.CurrentOpPeriod);
            

            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o => o.OpPeriod == CurrentOpPeriod && o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.OpPeriod == CurrentOpPeriod && o.Active);

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active && o.OpPeriod == CurrentOpPeriod);

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any(o => o.OpPeriod == CurrentOpPeriod);
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;


            chkAirOps.Enabled = CurrentIncident.hasMeaningfulAirOps(CurrentOpPeriod);
            chkAirOps.Checked = chkAirOps.Enabled;
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
            chkOrgAssignments.Enabled = chkOrgChart.Enabled;
            chkOrgAssignments.Checked = chkOrgAssignments.Enabled;

            chkAssignments.Enabled = CurrentIncident.hasMeaningfulTeamAssignments(CurrentOpPeriod);
            chkAssignments.Checked = chkAssignments.Enabled;
            chkAssignmentDetails.Enabled = chkAssignments.Enabled;

            chkContacts.Enabled = CurrentIncident.allContacts.Any(o => o.Active);
            chkContacts.Checked = chkContacts.Enabled;

            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o => o.OpPeriod == CurrentOpPeriod && o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.OpPeriod == CurrentOpPeriod && o.Active);
            chkGeneralMessages.Checked = chkGeneralMessages.Enabled;

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active && o.OpPeriod == CurrentOpPeriod);
            chkNotes.Checked = chkNotes.Enabled;

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any(o => o.OpPeriod == CurrentOpPeriod);
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;
            chkVerboseActivityLog.Checked = chkVerboseActivityLog.Enabled;

            chkAirOps.Enabled = CurrentIncident.hasMeaningfulAirOps(CurrentOpPeriod);
            chkAirOps.Checked = chkAirOps.Enabled;

            chkCheckInLists.Enabled = CurrentIncident.AllCheckInRecords.Any(o => o.OpPeriod <= Program.CurrentOpPeriod);
            chkCheckInLists.Checked = chkCheckInLists.Enabled;

        }

        private void setCheckboxStatusIncident()
        {
            chkIncidentObjectives.Enabled = CurrentIncident.AllIncidentObjectiveSheets.Any(o => o.Objectives.Any(i => i.Active));
            chkIncidentObjectives.Checked = chkIncidentObjectives.Enabled;

            chkCommsPlan.Enabled = CurrentIncident.allCommsPlans.Any(o => o.ActiveCommsItems.Any());
            chkCommsPlan.Checked = chkCommsPlan.Enabled;

            chkMedPlan.Enabled = CurrentIncident.allMedicalPlans.Any(o => o.ActiveAmbulances.Any() || o.ActiveAidStations.Any() || o.ActiveHospitals.Any());
            chkMedPlan.Checked = chkMedPlan.Enabled;

            chkOrgChart.Enabled = CurrentIncident.allOrgCharts.Any(o => o.FilledRoles.Any());
            chkOrgChart.Checked = chkOrgChart.Enabled;
            chkOrgAssignments.Enabled = chkOrgChart.Enabled;
            chkOrgAssignments.Checked = chkOrgAssignments.Enabled;

            chkAssignments.Enabled = CurrentIncident.ActiveOperationalGroups.Any(o => !o.IsBranchOrDiv);
            chkAssignments.Checked = chkAssignments.Enabled;
            chkAssignmentDetails.Enabled = chkAssignments.Enabled;

            chkContacts.Enabled = CurrentIncident.allContacts.Any(o => o.Active);
            chkContacts.Checked = chkContacts.Enabled;


            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o => o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.Active);
            chkGeneralMessages.Checked = chkGeneralMessages.Enabled;

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active);
            chkNotes.Checked = chkNotes.Enabled;

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any();
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;
            chkVerboseActivityLog.Checked = chkVerboseActivityLog.Enabled;

            chkCheckInLists.Enabled = CurrentIncident.AllCheckInRecords.Any(o => o.OpPeriod <= Program.CurrentOpPeriod);
            chkCheckInLists.Checked = chkCheckInLists.Enabled;

            chkAirOps.Enabled = CurrentIncident.hasMeaningfulAirOps();
            chkAirOps.Checked = chkAirOps.Enabled;
        }
        private void setCheckboxStatusIncidentIAP()
        {
            chkIncidentObjectives.Enabled = CurrentIncident.AllIncidentObjectiveSheets.Any(o => o.Objectives.Any(i => i.Active));
            chkIncidentObjectives.Checked = chkIncidentObjectives.Enabled;

            chkCommsPlan.Enabled = CurrentIncident.allCommsPlans.Any(o => o.ActiveCommsItems.Any());
            chkCommsPlan.Checked = chkCommsPlan.Enabled;

            chkMedPlan.Enabled = CurrentIncident.allMedicalPlans.Any(o => o.ActiveAmbulances.Any() || o.ActiveAidStations.Any() || o.ActiveHospitals.Any());
            chkMedPlan.Checked = chkMedPlan.Enabled;

            chkOrgChart.Enabled = CurrentIncident.allOrgCharts.Any(o => o.FilledRoles.Any());
            chkOrgAssignments.Enabled = chkOrgChart.Enabled;
            chkOrgAssignments.Checked = chkOrgAssignments.Enabled;

            chkAssignments.Enabled = CurrentIncident.ActiveOperationalGroups.Any(o => !o.IsBranchOrDiv);
            chkAssignments.Checked = chkAssignments.Enabled;
            chkAssignmentDetails.Enabled = chkAssignments.Enabled;

            chkContacts.Enabled = CurrentIncident.allContacts.Any(o => o.Active);


            chkSafetyMessage.Enabled = CurrentIncident.allSafetyMessages.Any(o => o.Active);
            chkSafetyMessage.Checked = chkSafetyMessage.Enabled;

            chkGeneralMessages.Enabled = CurrentIncident.AllGeneralMessages.Any(o => o.Active);

            chkNotes.Enabled = CurrentIncident.allNotes.Any(o => o.Active);

            chkActivityLog.Enabled = CurrentIncident.allPositionLogEntries.Any();
            chkActivityLog.Checked = chkActivityLog.Enabled;
            chkVerboseActivityLog.Enabled = chkActivityLog.Enabled;

            chkCheckInLists.Enabled = CurrentIncident.AllCheckInRecords.Any(o => o.OpPeriod <= Program.CurrentOpPeriod);

            chkAirOps.Enabled = CurrentIncident.hasMeaningfulAirOps();
            chkAirOps.Checked = chkAirOps.Enabled;

        }

        List<BrowseFileControl> browseControls
        {
            get
            {
                List<BrowseFileControl> controls = new List<BrowseFileControl>();
                controls.Add(browseFileControl1);
                controls.Add(browseFileControl2);
                controls.Add(browseFileControl3);
                controls.Add(browseFileControl4);
                return controls;
            }
        }


        private void btnSaveAsPDF_Click(object sender, EventArgs e)
        {
            

            string path = generatePDF();
            if (!string.IsNullOrEmpty(path))
            {
                System.Diagnostics.Process.Start(path);
            }

            

        }

        private string generatePDF()
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(CurrentIncident);

            string fullOutputFilename = "Task " + CurrentIncident.IncidentIdentifier + " Op " + CurrentOpPeriod;    // + ".pdf";
            if (PrintIncidentToDate) { fullOutputFilename = "Task " + CurrentIncident.IncidentIdentifier + " as of Op " + CurrentOpPeriod; }

            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            if (chkTitlePage.Checked)
            {
                allPDFs.AddRange(buildContentsList());
            }
            List<int> OpsToPrint = new List<int>();
            if (!PrintIncidentToDate) { OpsToPrint.Add(CurrentOpPeriod); }
            else
            {
                foreach (OperationalPeriod op in CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber <= CurrentOpPeriod)) { OpsToPrint.Add(op.PeriodNumber); }
            }



            foreach (int op in OpsToPrint)
            {
                if (chkIncidentObjectives.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportIncidentObjectivesToPDF(CurrentIncident, op, true, chkFlattenPDF.Checked));
                }
                if (chkOrgAssignments.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportOrgAssignmentListToPDF(CurrentIncident, op, chkFlattenPDF.Checked));

                }
                if (chkAssignments.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportAllAssignmentSummariesToPDF(CurrentIncident, op, chkFlattenPDF.Checked));

                }
                if (chkAssignmentDetails.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportAllAssignmentDetailsToPDF(CurrentIncident, op, chkFlattenPDF.Checked));

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
                if (chkOrgChart.Checked)
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

                if (chkAirOps.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportAirOpsSummaryToPDF(CurrentIncident, CurrentOpPeriod, chkFlattenPDF.Checked));
                }





                //Contacts
                if (chkContacts.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportContactsToPDF(CurrentIncident, CurrentOpPeriod, null, null, chkFlattenPDF.Checked));
                }

                if (chkCheckInLists.Checked)
                {
                    allPDFs.AddRange(Program.pdfExportService.exportCheckInSheetsToPDF(CurrentIncident, CurrentOpPeriod, false, chkFlattenPDF.Checked));
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


            //add additional PDFs
            foreach(BrowseFileControl browseFileControl in browseControls)
            {
                if(!string.IsNullOrEmpty(browseFileControl.FileName) && File.Exists(browseFileControl.FileName))
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(browseFileControl.FileName);
                    allPDFs.Add(bytes);

                }
            }

            if (allPDFs != null && allPDFs.Count > 0)
            {
                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(fullFilepath, fullFile);
                    return fullFilepath;
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
                }
            }

            return null;
        }

        private List<byte[]> buildContentsList()
        {
            List<string> contents = new List<string>();
            if (PrintIncidentToDate)
            {
                StringBuilder opNames = new StringBuilder();

                foreach (OperationalPeriod op in CurrentIncident.AllOperationalPeriods.Where(o => o.PeriodNumber <= CurrentOpPeriod))
                {
                    if (opNames.Length > 0) { opNames.Append(", "); }
                    opNames.Append(op.PeriodNumber);
                }




                //contents.Add("Each of the following (when available) for operational periods: " + opNames.ToString());

            }


            if (chkIncidentObjectives.Checked) { contents.Add("• ICS-202 WF Incident Objectives"); }
            if (chkOrgAssignments.Checked) { contents.Add("• ICS-203 WF Organization Assignment List"); }
            if (chkAssignments.Checked) { contents.Add("• ICS-204 WF Assignment Summary List"); }

            if (chkCommsPlan.Checked) { contents.Add("• ICS-205 WF Communications Plan"); }
            //medical
            if (chkMedPlan.Checked) { contents.Add("• ICS-206 WF Medical Plan"); }
            //org
            if (chkOrgChart.Checked)
            {
                bool IncludeContacts = Program.generalOptionsService.GetOptionsBoolValue("IncludeOrgContactsInIAP");
                contents.Add("• ICS-207 WF Organization Chart"); if (IncludeContacts)
                {
                    contents.Add("   • With contact list");
                }

            }
            //safety
            if (chkSafetyMessage.Checked) { contents.Add("• ICS-208 WF Safety Message/Plan(s)"); }

            //Air Ops
            if (chkAirOps.Checked) { contents.Add("• ICS-220 WF Air Operations Summary"); }



            if (chkContacts.Checked) { contents.Add("• ICS-205A Communications List"); }

            //general msg
            if (chkGeneralMessages.Checked) { contents.Add("• ICS-213 WF General Message(s)"); }






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

            if (chkNotes.Checked) { contents.Add("•  Note(s)"); }

            if (PrintIncidentToDate)
            {
                //return Program.pdfExportService.createFreeformOpPeriodContentsList(CurrentIncident, contents, 0);
                StringBuilder sb = new StringBuilder();
                foreach (string s in contents) { sb.Append(s); sb.Append(Environment.NewLine); }


                //CurrentIncident, CurrentOpPeriod, sb.ToString(), img, true, chkFlattenPDF.Checked)
                return Program.pdfExportService.exportOpTitlePageToPDF(CurrentIncident, 0, sb.ToString(), CurrentIncident.IncidentTitleImageBytes, chkFlattenPDF.Checked);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in contents) { sb.Append(s); sb.Append(Environment.NewLine); }
                OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);


                //CurrentIncident, CurrentOpPeriod, sb.ToString(), img, true, chkFlattenPDF.Checked)
                return Program.pdfExportService.exportOpTitlePageToPDF(CurrentIncident, CurrentOpPeriod, sb.ToString(), period.TitleImageBytes, chkFlattenPDF.Checked);
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            selectPhoto();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureRemoveImage, Properties.Resources.SureRemoveImageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (PrintIncidentToDate)
                {
                    CurrentIncident.IncidentTitleImageBytes = string.Empty;
                    TaskBasics basics = new TaskBasics(CurrentIncident);
                    Program.incidentDataService.UpdateTaskBasics(basics, "local");
                    picTitleImage.Image = null;
                }
                else
                {
                    OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);
                    period.TitleImageBytes = string.Empty;
                    Program.incidentDataService.UpsertOperationalPeriod(period);
                    picTitleImage.Image = null;

                }
            }
        }

        private void selectPhoto()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                //they've chosen a file, try to open it.
                try
                {
                    FileInfo file = new FileInfo(openFileDialog1.FileName);

                    string newFileName = CurrentIncident.IncidentIdentifier;
                    if (PrintIncidentToDate) { newFileName += "-TitleImage"; }
                    else { newFileName += "-Op" + CurrentOpPeriod + "TitleImage"; }


                    string newFilePath = CurrentIncident.FileName;
                    newFilePath = Path.Combine(FileAccessClasses.getWritablePath(CurrentIncident), newFileName);

                    int uniqueNumber = 0;
                    while (File.Exists(newFilePath + file.Extension))
                    {
                        uniqueNumber += 1;
                        newFileName = CurrentIncident.IncidentIdentifier;
                        if (PrintIncidentToDate) { newFileName += "-TitleImage"; }
                        else { newFileName += "-Op" + CurrentOpPeriod + "TitleImage"; }
                        newFileName += "-" + uniqueNumber;
                        newFilePath = Path.Combine(FileAccessClasses.getWritablePath(CurrentIncident), newFileName);
                    }

                    System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
                    Bitmap newImage = new Bitmap(image);
                    long maxFileSize = 200000;
                    if (file.Length > maxFileSize)
                    {
                        long factor = (file.Length + (maxFileSize - 1)) / maxFileSize;

                        int newh = image.Height / (int)factor;
                        int neww = image.Width / (int)factor;
                        newImage = image.ResizeImage(neww, newh);
                        newImage.Save(newFilePath);
                    }
                    else
                    {
                        file.CopyTo(newFilePath);
                    }


                    image.Dispose();
                    if (PrintIncidentToDate)
                    {
                        CurrentIncident.IncidentTitleImageBytes = newImage.BytesStringFromImage();
                        TaskBasics basics = new TaskBasics(CurrentIncident);
                        Program.incidentDataService.UpdateTaskBasics(basics, "local");

                    }
                    else
                    {
                        OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);
                        period.TitleImageBytes = newImage.BytesStringFromImage();
                        Program.incidentDataService.UpsertOperationalPeriod(period);
                    }
                    picTitleImage.Image = newImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error selecting that image, please report the following to technical support: " + ex.ToString());
                }
            }
        }

        private void chkFlattenPDF_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked) { chk.ImageIndex = 1; chk.Text = "All PDF fields will be locked"; }
            else { chk.ImageIndex = 0; chk.Text = "All PDF fields will be editable"; }
        }

        private void txtCriticalMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCriticalMessage_Leave(object sender, EventArgs e)
        {
            OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);
            if (period.CriticalMessage == null || !period.CriticalMessage.Equals(txtCriticalMessage.Text))
            {
                period.CriticalMessage = txtCriticalMessage.Text;
                Program.incidentDataService.UpsertOperationalPeriod(period);

            }

        }

        private void btnEmailIAP_Click(object sender, EventArgs e)
        {
            List<Personnel> activePersonnel = Program.CurrentIncident.GetCurrentlySignedInPersonnel(Program.CurrentOpPeriod);
            activePersonnel = activePersonnel.Where(o => !string.IsNullOrEmpty(o.Email) && o.Email.isValidEmail()).ToList();
            if (DialogResult.Yes == MessageBox.Show("The PDF will be emailed to " + activePersonnel.Count + " people. You can add additional receipients in your email client. Do you want to proceed?", "Proceed with email", MessageBoxButtons.YesNo))
            {

                MAPI mapi = new MAPI();
                string pdf = generatePDF();
                if (!string.IsNullOrEmpty(pdf))
                {
                    mapi.AddAttachment(pdf);

                    foreach (Personnel p in activePersonnel)
                    {
                        mapi.AddRecipientBCC(p.Email);
                    }
                    try
                    {
                        mapi.SendMailPopup("IAP for " + Program.CurrentIncident.IncidentIdentifier, "Attached is the Incident Action Plan for operational period # " + Program.CurrentOpPeriod + " from " + Program.CurrentOpPeriodDetails.PeriodStart.ToString(Program.DateFormat) + " to " + Program.CurrentOpPeriodDetails.PeriodEnd.ToString(Program.DateFormat));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        MessageBox.Show("Sorry, there was an error trying to send the PDF.  You may need to save the pdf and email it manually.");
                    }
                } else { MessageBox.Show("There was an error generating the pdf."); }
            }
        }

        private void chkTitlePage_CheckedChanged(object sender, EventArgs e)
        {
            pnlTitlePageContent.Enabled =  chkTitlePage.Checked;
        }

        private void txtCriticalMessage_Leave_1(object sender, EventArgs e)
        {
            OperationalPeriod period = Program.CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod);
            if (period.CriticalMessage == null || !period.CriticalMessage.Equals(txtCriticalMessage.Text))
            {
                period.CriticalMessage = txtCriticalMessage.Text;
                Program.incidentDataService.UpsertOperationalPeriod(period);

            }
        }
    }
}
