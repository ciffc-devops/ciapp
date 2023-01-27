using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Interfaces;

namespace WildfireICSDesktopServices
{
    public class PositionLogService : IPositionLogService
    {


        public string CreateICSPDF(WFIncident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }



            string outputFileName = "ICS 214 - Task " + task.IncidentIdentifier + " - " + role.RoleName + " - OP " + OpPeriod.ToString() + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);




            List<byte[]> allPDFs = exportPositionLogToPDF(task, OpPeriod, role, flattenPDF);

            //path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(path, fullFile);

            }
            catch (Exception)
            {
                path = null;
            }


            return path;
        }


        public List<byte[]> exportPositionLogToPDF(WFIncident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();



            List<PositionLogEntry> entries = task.allPositionLogEntries.Where(o => o.OpPeriod == OpPeriodToExport && o.Role.RoleID == role.RoleID).ToList();
            int totalPages = getPositionLogPageCount(entries);


            List<string> pdfFileNames = new List<string>();
            List<PositionLogEntry> firstPageEntries = entries.Take(19).ToList();
            allPDFs.AddRange(buildFirstPDFPage(firstPageEntries, task, OpPeriodToExport, role, 1, totalPages, flattenPDF));

            List<PositionLogEntry> extraPageEntries = entries.Skip(19).ToList();
            for (int x = 1; x < totalPages; x++)
            {
                List<PositionLogEntry> nextEntries = extraPageEntries.Skip(31 * (x - 1)).Take(37).ToList();

                allPDFs.AddRange(buildPDFPage(nextEntries, task, OpPeriodToExport, role, x + 1, totalPages, flattenPDF));
            }
            return allPDFs;

        }

        public int getPositionLogPageCount(List<PositionLogEntry> entries)
        {

            int totalPages = 0;
            if (entries.Any()) { totalPages = 1; }
            if (entries.Count > 19)
            {
                totalPages += Convert.ToInt32(Math.Floor(Convert.ToDecimal(entries.Count - 19) / 37m));
                if ((entries.Count - 19) % 37 > 0) { totalPages += 1; }

            }

            if (totalPages == 0) { totalPages = 1; }
            return totalPages;
        }


        private static List<byte[]> buildFirstPDFPage(List<PositionLogEntry> entries, WFIncident task, int OpsPeriod, ICSRole role, int pageNumber, int pageCount, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempFileName();
            string fileToUse = "BlankForms/ICS-214-WF-Activity-Log.pdf";

            OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == OpsPeriod);

            ICSRole RoleWithName = null;
            if (task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod && o.ActiveRoles.Any(r => r.RoleID == role.RoleID)))
            {
                RoleWithName = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First().ActiveRoles.Where(o => o.RoleID == role.RoleID).First();
            }
            else { RoleWithName = role; }

            ICSRole branchRole = null;
            if (role.BranchID == role.RoleID) { branchRole = RoleWithName; }
            else if (task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod && o.ActiveRoles.Any(r => r.RoleID == role.BranchID)))
            {
                branchRole = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First().ActiveRoles.Where(r => r.RoleID == role.BranchID).First();
            }

            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {
                    stamper.AcroFields.SetField("1 INCIDENT NAME", task.TaskName);
                   
                    stamper.AcroFields.SetField("2 DATE PREPARED", string.Format("{0:yyyy-MMM-dd HH:mm}", DateTime.Now));
                    stamper.AcroFields.SetField("OP", OpsPeriod.ToString());
                    stamper.AcroFields.SetField("4 NAME", RoleWithName.IndividualName);
                    stamper.AcroFields.SetField("5 ICS POSITION", role.RoleName);
                    stamper.AcroFields.SetField("Name", RoleWithName.IndividualName);
                    stamper.AcroFields.SetField("Position", role.RoleName);

                    stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));



                    stamper.AcroFields.SetField("PAGE", pageNumber.ToString());
                    stamper.AcroFields.SetField("OF", pageCount.ToString());

                    List<ICSRole> UnitRoles = new List<ICSRole>();
                    if (task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod))
                    {
                        UnitRoles = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First().ActiveRoles.Where(o => o.BranchID == branchRole.RoleID).ToList();
                        UnitRoles = UnitRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)).ToList();
                        for (int x = 0; x < UnitRoles.Count && x < 16; x++)
                        {
                            stamper.AcroFields.SetField("NameRow" + (x + 1), UnitRoles[x].IndividualName);
                            stamper.AcroFields.SetField("ICS PositionRow" + (x + 1), UnitRoles[x].RoleName);
                        }

                    }




                    for (int x = 0; x < entries.Count; x++)
                    {
                        PositionLogEntry entry = entries[x];
                        stamper.AcroFields.SetField("TimeRow" + (x + 1), entry.DateCreated.ToString("HH:mm"));
                        string IsIncomplete = null; if (!entries[x].IsInfoOnly && !entries[x].IsComplete) { IsIncomplete = "INCOMPLETE -- "; }
                        stamper.AcroFields.SetField("Major EventsRow" + (x + 1), IsIncomplete + entry.LogText);



                    }


                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-214-" + pageNumber.ToString());
                    }

                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }
                }
            }



            List<byte[]> allPDFs = new List<byte[]>();


            using (FileStream stream = File.OpenRead(path))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }

            return allPDFs;
        }



        private static List<byte[]> buildPDFPage(List<PositionLogEntry> entries, WFIncident task, int OpsPeriod, ICSRole role, int pageNumber, int pageCount, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempFileName();
            string fileToUse = "BlankForms/ICS-214-WF-Activity-Log-Supplemental.pdf";
            OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == OpsPeriod);

            ICSRole branchRole = null;
            if (role.BranchID == role.RoleID) { branchRole = role; }
            else if (task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod && o.ActiveRoles.Any(r => r.RoleID == role.BranchID)))
            {
                branchRole = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First().ActiveRoles.Where(r => r.RoleID == role.BranchID).First();
            }

            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {
                    stamper.AcroFields.SetField("1 INCIDENT NAMERow1", task.TaskName);

                    stamper.AcroFields.SetField("DATE  TIME PREPARED", string.Format("{0:yyyy-MMM-dd HH:mm}", DateTime.Now));
                    stamper.AcroFields.SetField("OP", OpsPeriod.ToString());
                    stamper.AcroFields.SetField("3 NAME", role.IndividualName);
                    stamper.AcroFields.SetField("4 ICS POSITION", role.RoleName);
                    stamper.AcroFields.SetField("Name", role.IndividualName);
                    stamper.AcroFields.SetField("Position", role.RoleName);

                    stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));



                    stamper.AcroFields.SetField("PAGE", pageNumber.ToString());
                    stamper.AcroFields.SetField("OF", pageCount.ToString());

                    for (int x = 0; x < entries.Count; x++)
                    {
                        PositionLogEntry entry = entries[x];
                        string IsIncomplete = null; if (!entries[x].IsInfoOnly && !entries[x].IsComplete) { IsIncomplete = "INCOMPLETE -- "; }

                        stamper.AcroFields.SetField("TimeRow" + (x + 1), entry.DateCreated.ToString("HH:mm"));
                        stamper.AcroFields.SetField("Major EventsRow" + (x + 1), IsIncomplete + entry.LogText);



                    }


                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-214-" + pageNumber.ToString());
                    }

                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }
                }
            }



            List<byte[]> allPDFs = new List<byte[]>();


            using (FileStream stream = File.OpenRead(path))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }

            return allPDFs;
        }







        public List<byte[]> exportVerbosePositionLogToPDF(WFIncident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();


            string briefingPath = CreateVerbosePDF(task, role, OpPeriodToExport, null, true, flattenPDF);
            using (FileStream stream = File.OpenRead(briefingPath))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }

            return allPDFs;

        }


        public string CreateVerbosePDF(WFIncident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF)
        {
            string path = pathToUse;
            if (task != null)
            {

                if (!useTempPath)
                {
                    if (string.IsNullOrEmpty(path)) { path = FileAccessClasses.getWritablePath(task); }

                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "Incident " + task.IncidentIdentifier + " Op # " + OpPeriod + " - " + role.RoleName;
                    path = FileAccessClasses.getUniqueFileName(outputFileName, path);
                    //path = System.IO.Path.Combine(path, outputFileName);

                }
                else
                {
                    path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                }
                try
                {

                    using (System.IO.FileStream fs = new FileStream(path, FileMode.Create))
                    {


                        // Create an instance of the document class which represents the PDF document itself.
                        Document document = new Document(PageSize.A4, 25, 25, 30, 30);

                        // Create an instance to the PDF file by creating an instance of the PDF 
                        // Writer class using the document and the filestrem in the constructor.

                        PdfWriter writer = PdfWriter.GetInstance(document, fs);



                        TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
                        writer.PageEvent = PageEventHandler;
                        // Define the page header
                        PageEventHandler.Title = "";
                        //PageEventHandler.Title = "Task Number " + CurrentTask.TaskNumber + " - " + CurrentTask.TaskName + " Op Period " + selectedBriefing.OpPeriod.ToString();
                        PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, iTextSharp.text.Font.BOLD);


                        document.AddTitle(role.RoleName + " Position Log - Task Number " + task.TaskNumber + " - " + task.TaskName + " Op " + OpPeriod);

                        // Open the document to enable you to write to the document

                        document.Open();
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        // Add a simple and wellknown phrase to the document in a flow layout manner
                        //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                        string title = role.RoleName + " Position Log";



                        Anchor briefingTarget = new Anchor(title, titlefont);
                        briefingTarget.Name = "Timeline";
                        Paragraph tp = new Paragraph();
                        tp.Add(briefingTarget);
                        tp.Font = titlefont;
                        Paragraph stp = new Paragraph("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op " + OpPeriod, sectionfont);
                        document.Add(tp);
                        document.Add(stp);


                        foreach (PositionLogEntry entry in task.allPositionLogEntries.Where(o => o.OpPeriod == OpPeriod && o.Role.RoleID == role.RoleID).OrderBy(o => o.DateCreated))
                        {
                            document.Add(new Paragraph(entry.LogText, subsectionfont));
                            Paragraph p1 = new Paragraph(entry.LogHistoryString, normalfont);
                            p1.IndentationLeft = 30;
                            document.Add(p1);

                        }



                        // Close the document
                        document.Close();
                        // Close the writer instance
                        writer.Close();

                        // Always close open filehandles explicity

                    }
                }
                catch (Exception)
                {
                    path = null;
                }
            }
            return path;
        }


    }
}
