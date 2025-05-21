using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using static System.Collections.Specialized.BitVector32;
using Rectangle = iTextSharp.text.Rectangle;

namespace WildfireICSDesktopServices
{
    public class PDFExportService : IPDFExportService
    {
        private static string DateFormat { get; set; } = "MMM-dd-yyyy";

        public void SetDateFormat(string str)
        {
            if (!string.IsNullOrEmpty(str)) { DateFormat = str; }
            else { DateFormat = "MMM-dd-yyyy"; }
        }

       
        #region Dietary and Allergy Details

        public List<byte[]> exportDietaryAndAllergyToPDF(Incident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriodToExport);
            OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriodToExport);
            List<CheckInRecordWithResource> allCheckInRecords = incident.GetCheckInWithResources(OpPeriodToExport);

            allCheckInRecords = allCheckInRecords.Where(o => o.Record.ParentRecordID == Guid.Empty && o.Resource.GetType().Equals(typeof(Personnel))).OrderBy(o => o.Record.CheckInLocation).ToList(); //remove non-personnel
            allCheckInRecords = allCheckInRecords.Where(o => (o.Resource as Personnel).HasAllergies || (o.Resource as Personnel).HasDietaryRestrictions).ToList();
            //if (thisOpOnly) { allCheckInRecords = allCheckInRecords.Where(o => o.Record.DailyCheckInRecords.Any(d => d.OpPeriod == OpPeriodToExport)).ToList(); }


            int totalPages = 1;
            int rowsOnPage = 40;


            if (allCheckInRecords.Count > rowsOnPage)
            {
                totalPages += Convert.ToInt32(Math.Floor(Convert.ToDecimal(allCheckInRecords.Count - rowsOnPage) / Convert.ToDecimal(rowsOnPage)));
                if ((allCheckInRecords.Count - rowsOnPage) % rowsOnPage > 0) { totalPages += 1; }
                if (totalPages == 0) { totalPages = 1; }
            }

            List<string> pdfFileNames = new List<string>();

            for (int x = 1; x <= totalPages; x++)
            {
                List<CheckInRecordWithResource> resourcesThisPage = allCheckInRecords.Skip((x - 1) * rowsOnPage).Take(rowsOnPage).ToList();
                allPDFs.AddRange(createSinglePageDietaryAndAllergyPDF(incident, OpPeriodToExport, resourcesThisPage, x, totalPages, flattenPDF));

            }

            /*
            List<PositionLogEntry> extraPageEntries = entries.Skip(19).ToList();
            for (int x = 1; x < totalPages; x++)
            {
                List<PositionLogEntry> nextEntries = extraPageEntries.Skip(31 * (x - 1)).Take(37).ToList();

                allPDFs.AddRange(buildPDFPage(nextEntries, task, OpPeriodToExport, role, x + 1, totalPages, flattenPDF));
            }
            */


            return allPDFs;
        }

        public List<byte[]> createSinglePageDietaryAndAllergyPDF(Incident incident, int OpPeriod, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "Dietary and Allergy Details - " + incident.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString() + " page " + thisPageNum;
            outputFileName += ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            string fileToUse = PDFExtraTools.getPDFFilePath("Dietary and Allergy Details.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
                    OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod);

                    string checkInLocation = null;
                    if (allCheckInRecords.Any(o => !string.IsNullOrEmpty(o.Record.CheckInLocation)))
                    {
                        checkInLocation = allCheckInRecords.First(o => !string.IsNullOrEmpty(o.Record.CheckInLocation)).Record.CheckInLocation;
                    }

                    stamper.AcroFields.SetField("1 Event", incident.TaskName);
                    stamper.AcroFields.SetField("2 Task No", incident.TaskNumber);
                    stamper.AcroFields.SetField("3 Operational Period", OpPeriod.ToString());



                    stamper.AcroFields.SetField("From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("From_2", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("To_2", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                    //stamper.AcroFields.SetField("TIME", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));


                    for (int x = 0; x < allCheckInRecords.Count && x < 40; x++)
                    {
                        CheckInRecordWithResource record = allCheckInRecords[x];

                        Personnel p = null; if (record.Resource.GetType().Name.Equals("Personnel")) { p = (Personnel)record.Resource; }

                        if (p != null)
                        {
                            stamper.AcroFields.SetField("PersonRow" + (x + 1), p.Name);
                            stamper.AcroFields.SetField("AgencyRow" + (x + 1), p.Agency);

                            if (p.HasDietaryRestrictions) { stamper.AcroFields.SetField("DietaryRow" + (x + 1), "YES"); } else { stamper.AcroFields.SetField("DietaryRow" + (x + 1), "NO"); }
                            if (p.HasAllergies) { stamper.AcroFields.SetField("AllergiesRow" + (x + 1), "YES"); } else { stamper.AcroFields.SetField("AllergiesRow" + (x + 1), "N/A"); }

                            bool[] mealRequirements = record.GetMealRequirements();



                            if (mealRequirements[0]) { stamper.AcroFields.SetField("BrkRow" + (x + 1), "YES"); } else { stamper.AcroFields.SetField("BrkRow" + (x + 1), "NO"); }
                            if (mealRequirements[1]) { stamper.AcroFields.SetField("LnchRow" + (x + 1), "YES"); } else { stamper.AcroFields.SetField("LnchRow" + (x + 1), "NO"); }
                            if (mealRequirements[2]) { stamper.AcroFields.SetField("DinRow" + (x + 1), "YES"); } else { stamper.AcroFields.SetField("DinRow" + (x + 1), "NO"); }



                        }

                    }
                    stamper.AcroFields.SetField("PAGE", thisPageNum.ToString());
                    stamper.AcroFields.SetField("Of", totalPageNum.ToString());



                    //Rename all fields
                    //stamper = stamper.AddOrgLogoToForm();
                    stamper = stamper.RenameAllFields();



                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }

            List<byte[]> allPDFs = new List<byte[]>();

            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }
            return allPDFs;
        }

        #endregion

        #region General Message
        public PDFCreationResults ExportGeneralMessagesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<GeneralMessage> items = task.ActiveGeneralMessages.Where(o => o.OpPeriod == OpPeriodToExport).ToList();
            return ExportGeneralMessagesToPDF(task, items, flattenPDF);
          
        }

        public PDFCreationResults ExportGeneralMessagesToPDF(Incident task, List<GeneralMessage> items, bool flattenPDF)
        {
            PDFCreationResults results = new PDFCreationResults();

            results.bytes = new List<byte[]>();

            foreach (GeneralMessage sp in items)
            {
                var creationResults = CreateGeneralMessagePDF(task, sp,  true, flattenPDF);
                results.errors.AddRange(creationResults.errors);
                results.TotalPages += creationResults.TotalPages;
                if (creationResults.path != null)
                {
                    using (FileStream stream = File.OpenRead(creationResults.path))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        results.bytes.Add(fileBytes);
                    }
                }
            }
            return results;
        }

        public PDFCreationResults CreateGeneralMessagePDF(Incident task, GeneralMessage item, bool tempFileName = false, bool flattenPDF = false)
        {
            PDFCreationResults results = new PDFCreationResults();
            results.path = FileAccessClasses.getWritablePath(task);
            if (task != null && item != null)
            {
                if (!tempFileName)
                {


                    if (task.DocumentPath == null && results.path != null) { task.DocumentPath = results.path; }
                    string filename = "ICS 213 - " + task.IncidentNameAndNumberForPath + " - " + item.Subject.Sanitize() + ".pdf";
                    if (filename.Length > 100)
                    {
                        filename = "ICS 213 - " + task.IncidentNameAndNumberForPath + " - " + item.Subject.Sanitize().Substring(0, 20) + ".pdf";
                    }
                    results.path = FileAccessClasses.getUniqueFileName(filename, results.path);

                    //path = System.IO.Path.Combine(path, filename);

                }
                else
                {
                    results.path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                }

                try
                {




                    string fileToUse = PDFExtraTools.getPDFFilePath("ICS-213-WF-General-Message.pdf");
                    fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
                    PdfReader rdr = new PdfReader(fileToUse);

                    using (FileStream stream = new System.IO.FileStream(results.path, System.IO.FileMode.Create))
                    {
                        PdfStamper stamper = new PdfStamper(rdr, stream);
                        stamper.AcroFields.SetField("1A INCIDENT NAME Optional", task.TaskName);
                        stamper.AcroFields.SetField("1B INCIDENT NUMBER", task.TaskNumber);
                        stamper.AcroFields.SetField("4 SUBJECT", item.Subject);
                        stamper.AcroFields.SetField("7 MESSAGE", item.Message);
                        string date = string.Format("{0:" + DateFormat + "}", item.DateSent);
                        stamper.AcroFields.SetField("5 DATE", string.Format("{0:" + DateFormat + "}", item.DateSent));
                        stamper.AcroFields.SetField("6 TIME", string.Format("{0:HH:mm}", item.DateSent));
                        stamper.AcroFields.SetField("2 TO Name and Position", item.To);
                        stamper.AcroFields.SetField("3 FROM Name and Position", item.From);

                        //approved by
                        if (!string.IsNullOrEmpty(item.ApprovedByRoleName)) { stamper.AcroFields.SetField("Position", item.ApprovedByRoleName); }
                        if (!string.IsNullOrEmpty(item.ApprovedByResourceName)) { stamper.AcroFields.SetField("Name", item.ApprovedByResourceName); }
                        //reply
                        if (!string.IsNullOrEmpty(item.Reply)) { stamper.AcroFields.SetField("9 REPLY", item.Reply); }
                        if (!string.IsNullOrEmpty(item.ReplyByPosition)) { stamper.AcroFields.SetField("ReplyPosition", item.ReplyByPosition); }
                        if (!string.IsNullOrEmpty(item.ReplyByName)) { stamper.AcroFields.SetField("ReplyName", item.ReplyByName); }
                        if (item.ReplyDate > DateTime.MinValue) { stamper.AcroFields.SetField("ReplyDate", string.Format("{0:" + DateFormat + " HH:mm}", item.ReplyDate)); }







                        if (flattenPDF)
                        {
                            stamper.FormFlattening = true;
                        }


                        //Rename the fields
                        AcroFields af = stamper.AcroFields;
                        List<string> fieldNames = new List<string>();
                        foreach (var field in af.Fields)
                        {
                            fieldNames.Add(field.Key);
                        }
                        foreach (string s in fieldNames)
                        {
                            stamper.AcroFields.RenameField(s, s + item.MessageID.ToString());
                        }

                        results.TotalPages = 1;


                        stamper.Close();//Close a PDFStamper Object
                        stamper.Dispose();
                        rdr.Close();    //Close a PDFReader Object


                    }

                }
                catch (IOException ex)
                {
                    results.errors.Add(ex);
                }
                catch (System.UnauthorizedAccessException uaex)
                {
                    results.errors.Add(uaex);
                }
            }
            return results;
        }

        #endregion

        #region Safety Messages

        public List<byte[]> exportSafetyMessagesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<SafetyMessage> safetyPlans = task.allSafetyMessages.Where(o => o.OpPeriod == OpPeriodToExport).ToList();
            foreach (SafetyMessage sp in safetyPlans)
            {
                string path = createSafetyMessagePDF(task, sp, false, true, flattenPDF);
                if (path != null)
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }
                }
            }
            return allPDFs;
        }

        public List<byte[]> exportSafetyMessagesToPDF(Incident task, List<SafetyMessage> messagesToPrint, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            foreach (SafetyMessage sp in messagesToPrint)
            {
                string path = createSafetyMessagePDF(task, sp, false, true, flattenPDF);
                if (path != null)
                {
                    using (FileStream stream = File.OpenRead(path))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }
                }
            }
            return allPDFs;
        }



        public string createSafetyMessagePDF(Incident task, SafetyMessage plan, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);
            if (task != null && plan != null)
            {
                if (!tempFileName)
                {


                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string filename = "ICS 208 - Task " + task.IncidentNameAndNumberForPath + " - Op " + plan.OpPeriod.ToString(Globals.cultureInfo) + " - Hazard " +  plan.SummaryLine.Sanitize() + ".pdf";
                    if (filename.Length > 100)
                    {
                        filename = "ICS 208 - Task " + task.IncidentNameAndNumberForPath + " - Op " + plan.OpPeriod.ToString(Globals.cultureInfo) + " - Hazard " + plan.SummaryLine.Sanitize().Substring(0, 20) + ".pdf";
                    }
                    path = FileAccessClasses.getUniqueFileName(filename, path);

                    //path = System.IO.Path.Combine(path, filename);

                }
                else
                {
                    path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                }

                try
                {

                    OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == plan.OpPeriod);



                    string fileToUse = PDFExtraTools.getPDFFilePath("ICS-208-WF-Safety-Message.pdf");
                    if(!string.IsNullOrEmpty(plan.ImageBytes))
                    {
                        fileToUse = PDFExtraTools.getPDFFilePath("ICS-208-WF-Safety-Message-with-image.pdf");
                    }
                    fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
                    PdfReader rdr = new PdfReader(fileToUse);

                    using (FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                    {
                        PdfStamper stamper = new PdfStamper(rdr, stream);
                        stamper.AcroFields.SetField("1 INCIDENT NAME OR NUMBER 2 OPERATIONAL Date From Date To", task.IncidentIdentifier);

                        stamper.AcroFields.SetField("SafetyMessage", plan.Message);
                        stamper.AcroFields.SetField("Approved Site Safety Plans Located at I", plan.SitePlanLocation);

                        stamper.AcroFields.SetField("PreparedByPosition", plan.PreparedByRoleName);
                        stamper.AcroFields.SetField("5 PREPARED BY I Position I Name I", plan.PreparedByResourceName);


                        if (plan.SitePlanRequired) { PDFExtraTools.SetPDFCheckbox(stamper, "SitePlanRequiredYes"); }
                        else { PDFExtraTools.SetPDFCheckbox(stamper, "SitePlanRequiredNo"); }


                        stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                        stamper.AcroFields.SetField("Text1", string.Format("{0:HH:mm}", currentOp.PeriodEnd));


                        if (!string.IsNullOrEmpty(plan.ImageBytes))
                        {
                            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(plan.ImageBytes.getImageFromBytes(), System.Drawing.Imaging.ImageFormat.Jpeg);

                            pic.ScaleToFit(530, 220);
                            float x = 50; //((250 - pic.ScaledWidth) / 2) + 315;
                            float y = 100;
                            pic.SetAbsolutePosition(x, y);

                            stamper.GetOverContent(1).AddImage(pic);
                        }



                        //Rename the fields
                        AcroFields af = stamper.AcroFields;
                        List<string> fieldNames = new List<string>();
                        foreach (var field in af.Fields)
                        {
                            fieldNames.Add(field.Key);
                        }
                        
                        foreach (string s in fieldNames)
                        {
                            stamper.AcroFields.RenameField(s, s + "-208-" + plan.ID.ToString());
                        }


                        if (flattenPDF)
                        {
                            stamper.FormFlattening = true;
                        }





                        stamper.Close();//Close a PDFStamper Object
                        stamper.Dispose();
                        rdr.Close();    //Close a PDFReader Object
                    }

                }
                catch (IOException ex)
                {
                }
                catch (System.UnauthorizedAccessException)
                {

                }
            }
            return path;
        }
        #endregion

        #region Demob Checklist

        public List<byte[]> exportDemobChecklistToPDF(Incident task, List< IncidentResource> Resources, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            string outputFileName = "ICS-211 " + DateTime.Now.ToString(Globals.DateFormat) + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            List<byte[]> allPDFs = new List<byte[]>();

            foreach (IncidentResource res in Resources)
            {
                allPDFs.AddRange(exportDemobChecklistToPDF(task, res, flattenPDF));
            }
            return allPDFs;
        }


        public List<byte[]> exportDemobChecklistToPDF(Incident task, IncidentResource Resource, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createDemobChecklistPDF(task, Resource, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public string createDemobChecklistPDF(Incident task, IncidentResource Resource, bool tempFileName = false, bool flattenPDF = false)
        {

            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }

                string outputFileName = "ICS 221 - " + Resource.UniqueIDNumWithPrefix;

                //path = System.IO.Path.Combine(path, outputFileName);
                outputFileName = outputFileName.ReplaceInvalidPathChars();

                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }
            try
            {

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-221-WF Demobilization Checkout.pdf");
                fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);


                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));



                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1 INCIDENT NAMENUMBER", task.IncidentNameOrNumber);
                stamper.AcroFields.SetField("2 DATETIME", DateTime.Now.ToString(Globals.DateFormat));


                stamper.AcroFields.SetField("4 UNITPERSONNEL RELEASED", Resource.ResourceName);
                stamper.AcroFields.SetField("10 UNIT LEADER RESPONSIBLE FOR COLLECTING PERFORMANCE RATING", Resource.LeaderName);


                stamper.AcroFields.SetField("PAGE", "1");
                stamper.AcroFields.SetField("OF", "1");




                //Rename all fields
                AcroFields af = stamper.AcroFields;

                List<string> fieldNames = new List<string>();
                foreach (var field in af.Fields)
                {
                    fieldNames.Add(field.Key);
                }
                Guid randomID = Guid.NewGuid();
                foreach (string s in fieldNames)
                {
                    stamper.AcroFields.RenameField(s, s + randomID.ToString());
                }


                if (flattenPDF)
                {
                    stamper.FormFlattening = true;
                }

                stamper.Close();//Close a PDFStamper Object
                rdr.Close();    //Close a PDFReader Object



            }
            catch (IOException ex)
            {
            }
            catch (System.UnauthorizedAccessException ex)
            {

            }
            catch (Exception ex)
            {

            }

            return path;
        }


        #endregion

        #region Medical Plan
        public List<byte[]> exportMedicalPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createMedicalPlanPDF(task, OpPeriodToExport, false, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public string createMedicalPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            if (!task.allMedicalPlans.Any(o => o.OpPeriod == OpsPeriod)) { task.createMedicalPlanAsNeeded(OpsPeriod); }
            MedicalPlan plan = task.allMedicalPlans.Where(o => o.OpPeriod == OpsPeriod).First();

            if(!task.allOrgCharts.Any(o=>o.OpPeriod == OpsPeriod)) { task.createOrgChartAsNeeded(OpsPeriod); }
            OrganizationChart currentChart = task.allOrgCharts.First(o => o.OpPeriod == OpsPeriod);

            OperationalPeriod currentOp = task.AllOperationalPeriods.First(o=>o.PeriodNumber== OpsPeriod);


            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }

                string outputFileName = "ICS 206 - Task " + task.TaskNumber + " - Op Period " + OpsPeriod.ToString(Globals.cultureInfo);
                //path = System.IO.Path.Combine(path, outputFileName);
                outputFileName = outputFileName.ReplaceInvalidPathChars();

                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }
            try
            {

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-206-WF-Medical-Plan.pdf");
                fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);


                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));



                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1B INCIDENT NUMBER", task.TaskNumber);
                stamper.AcroFields.SetField("1A INCIDENT NAME", task.TaskName);


                stamper.AcroFields.SetField("1B INCIDENT NUMBERDate From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                stamper.AcroFields.SetField("1B INCIDENT NUMBERTime From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));




                //This will check with the org chart to see if an individual has been assigned, assuming the name is vacant right now
                if (plan.PreparedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.PreparedByResourceName) && currentChart.ActiveRoles.Any(o => o.RoleID == plan.PreparedByRoleID))
                {
                    ICSRole role = currentChart.ActiveRoles.First(o => o.RoleID == plan.PreparedByRoleID);
                    plan.PreparedByResourceName = role.IndividualName;
                }
                stamper.AcroFields.SetField("Name", plan.PreparedByResourceName);
                stamper.AcroFields.SetField("Position", plan.PreparedByRoleName);

                //This will check with the org chart to see if an individual has been assigned, assuming the name is vacant right now
                if (plan.ApprovedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.ApprovedByResourceName) && currentChart.ActiveRoles.Any(o => o.RoleID == plan.ApprovedByRoleID))
                {
                    ICSRole role = currentChart.ActiveRoles.First(o => o.RoleID == plan.ApprovedByRoleID);
                    plan.ApprovedByResourceName = role.IndividualName;
                }
                stamper.AcroFields.SetField("Name_2", plan.ApprovedByResourceName);
                stamper.AcroFields.SetField("Position_2", plan.ApprovedByRoleName);

                stamper.AcroFields.SetField("6 MEDICAL EMERGENCY PROCEDURESRow1", plan.EmergencyProcedures);


                for (int aid = 0; aid < plan.ActiveAidStations.Count && aid < 5; aid++)
                {
                    MedicalAidStation aidStation = plan.ActiveAidStations[aid];
                    stamper.AcroFields.SetField("Medical Aid StationsRow" + (aid + 1), aidStation.Name);
                    stamper.AcroFields.SetField("LocationRow" + (aid + 1) , aidStation.Location);
                    stamper.AcroFields.SetField("Contact number or frequencyRow" + (aid + 1), aidStation.ContactNumber);


                    if (aidStation.ParamedicsAvailable) { PDFExtraTools.SetPDFCheckbox(stamper, "AidParamedicY" + (aid + 1)); }
                    else { PDFExtraTools.SetPDFCheckbox(stamper, "AidParamedicN" + (aid + 1)); }


                }



                for (int a = 0; a < plan.ActiveAmbulances.Count && a < 5; a++)
                {
                    AmbulanceService ambulance = plan.ActiveAmbulances[a];
                    stamper.AcroFields.SetField("Medivac ServicesRow" + (a + 1), ambulance.Organization);
                    stamper.AcroFields.SetField("LocationRow" + (a + 1) + "_2", ambulance.Location);
                    stamper.AcroFields.SetField("Contact number or frequencyRow" + (a + 1) + "_2", ambulance.Contact);


                    if (ambulance.IsALS) { PDFExtraTools.SetPDFCheckbox(stamper, "MedivacALS" + (a + 1)); }
                    else { PDFExtraTools.SetPDFCheckbox(stamper, "MedivacBLS" + (a + 1)); }

                }


                for (int a = 0; a < plan.ActiveHospitals.Count && a < 5; a++)
                {
                    Hospital hospital = plan.ActiveHospitals[a];
                    stamper.AcroFields.SetField("Hospital NameRow" + (a + 1), hospital.name);
                    if (hospital.Latitude != 0 && hospital.Longitude != 0 && hospital.helipad)
                    {
                        Coordinate coord = new Coordinate();
                        coord.Latitude = hospital.Latitude;
                        coord.Longitude = hospital.Longitude;
                        GeneralOptionsService service = new GeneralOptionsService();
                        stamper.AcroFields.SetField("Address Lat And Long if HelipadRow" + (a + 1), coord.CoordinateOutput(service.GetOptionsValue("CoordinateFormat").ToString()));
                    }
                    else
                    {
                        stamper.AcroFields.SetField("Address Lat And Long if HelipadRow" + (a + 1), hospital.location);
                    }
                    stamper.AcroFields.SetField("AirRow" + (a + 1), hospital.travelTimeAir.ToString());
                    stamper.AcroFields.SetField("GrndRow" + (a + 1) , hospital.travelTimeGround.ToString());
                    stamper.AcroFields.SetField("Contact number or frequencyRow" + (a + 1) + "_3", hospital.phone);


                    if (hospital.helipad) { PDFExtraTools.SetPDFCheckbox(stamper, "HelipadY" + (a + 1)); }
                    else { PDFExtraTools.SetPDFCheckbox(stamper, "HelipadN" + (a + 1)); }

                    if (hospital.burnUnit) { PDFExtraTools.SetPDFCheckbox(stamper, "BurnY" + (a + 1)); }
                    else { PDFExtraTools.SetPDFCheckbox(stamper, "BurnN" + (a + 1)); }
                }


                //Rename all fields
                AcroFields af = stamper.AcroFields;

                List<string> fieldNames = new List<string>();
                foreach (var field in af.Fields)
                {
                    fieldNames.Add(field.Key);
                }
                Guid randomID = Guid.NewGuid();
                foreach (string s in fieldNames)
                {
                    stamper.AcroFields.RenameField(s, s + randomID.ToString());
                }


                if (flattenPDF)
                {
                    stamper.FormFlattening = true;
                }

                stamper.Close();//Close a PDFStamper Object
                rdr.Close();    //Close a PDFReader Object



            }
            catch (IOException ex)
            {
            }
            catch (System.UnauthorizedAccessException ex)
            {

            }

            return path;
        }
        #endregion

        #region Comms Plan
        public List<byte[]> exportCommsPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createCommsPlanPDF(task, OpPeriodToExport, false, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public string createCommsPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);
            if (!tempFileName)
            {



                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                string outputFileName = "ICS 205 - Task " + task.TaskNumber + " - Op Period " + OpsPeriod.ToString();
                //path = System.IO.Path.Combine(path, outputFileName);
                outputFileName = outputFileName.ReplaceInvalidPathChars();

                path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }


            if (!task.allCommsPlans.Any(o => o.OpPeriod == OpsPeriod))
            {
                task.createCommsPlanAsNeeded(OpsPeriod);
            }

            CommsPlan plan = task.allCommsPlans.FirstOrDefault(o => o.OpPeriod == OpsPeriod);



            try
            {

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS205WF-Communications-Plan.pdf");
                fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));

                OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == plan.OpPeriod);

                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentIdentifier);
                stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));


                stamper.AcroFields.SetField("Name", plan.PreparedByResourceName);
                stamper.AcroFields.SetField("Position", plan.PreparedByRoleName);

                for (int row = 0; row < plan.ActiveCommsItems.Count && row < 26; row++)
                {
                    CommsPlanItem item = plan.ActiveCommsItems[row];
                    stamper.AcroFields.SetField("System  TypeRow" + (row + 1), item.CommsSystem);
                    stamper.AcroFields.SetField("ChannelRow" + (row + 1), item.ChannelID);
                    stamper.AcroFields.SetField("FunctionRow" + (row + 1), item.CommsFunction);
                    stamper.AcroFields.SetField("RxTx FrequencyRow" + (row + 1), item.FullFrequency);
                    stamper.AcroFields.SetField("ToneRow" + (row + 1), item.FullTone);
                    stamper.AcroFields.SetField("AssignmentRow" + (row + 1), item.Assignment);
                    stamper.AcroFields.SetField("RemarksRow" + (row + 1), item.Comments);

                }






                if (flattenPDF)
                {
                    stamper.FormFlattening = true;
                }


                stamper.Close();//Close a PDFStamper Object
                rdr.Close();    //Close a PDFReader Object



            }
            catch (IOException ex)
            {
            }
            catch (System.UnauthorizedAccessException)
            {

            }
            return path;
        }
        #endregion

        #region Objectives
        public List<byte[]> exportIncidentObjectivesToPDF(Incident task, int OpPeriodToExport, bool IncludeAttachments, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createObjectivesPDF(task, OpPeriodToExport, IncludeAttachments, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }

        public string createObjectivesPDF(Incident task, int OpsPeriod, bool includeAttachments = false, bool tempFileName = false, bool flattenPDF = false)
        {
            if (task != null)
            {
                string path = FileAccessClasses.getWritablePath(task);

                if (!tempFileName)
                {


                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "ICS 202 - Task " + task.IncidentNameAndNumberForPath + " - Op Period " + OpsPeriod.ToString();
                    //path = System.IO.Path.Combine(path, outputFileName);
                    outputFileName = outputFileName.ReplaceInvalidPathChars();

                    path = FileAccessClasses.getUniqueFileName(outputFileName, path);
                }
                else
                {
                    path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                }

                try
                {
                    string fileToUse = PDFExtraTools.getPDFFilePath("ICS-202-WF-Incident-Objectives.pdf");
                    fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);

                    if (!File.Exists(fileToUse)) { return "err Blank PDF Not found"; }

                    PdfReader rdr = new PdfReader(fileToUse);
                    PdfStamper stamper = new PdfStamper(rdr, new FileStream(path, FileMode.Create));

                    task.createObjectivesSheetAsNeeded(OpsPeriod);

                    IncidentObjectivesSheet currentSheet = task.AllIncidentObjectiveSheets.First(o=>o.OpPeriod== OpsPeriod);

                    //Op Plan
                    OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == OpsPeriod);
                    OrganizationChart currentChart = task.allOrgCharts.First(o=>o.OpPeriod == OpsPeriod);   

                    //Top Section
                    stamper.AcroFields.SetField("1A INCIDENT NAME", task.TaskName);
                    stamper.AcroFields.SetField("1B INCIDENT NUMBER", task.TaskNumber);
                    stamper.AcroFields.SetField("2 DATE PREPARED", string.Format("{0:" + DateFormat + " HH:mm}", currentSheet.DatePrepared));
                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                    ICSRole PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefGenericID, true);
                    if (null != PreparedBy)
                    {
                        stamper.AcroFields.SetField("9 PREPARED BY Planning Section Chief", PreparedBy.IndividualName);
                    }
                    ICSRole IC = currentChart.GetRoleByID(Globals.IncidentCommanderGenericID, true);
                    if (null != IC)
                    {
                        stamper.AcroFields.SetField("10 APPROVED BY Incident Commander", IC.IndividualName);
                    }

                    stamper.AcroFields.SetField("3A FIRE SIZE", currentSheet.FireSize);
                    stamper.AcroFields.SetField("3B FIRE STATUS", currentSheet.FireStatus);
                    stamper.AcroFields.SetField("6 WEATHER FORCASTRow1", currentSheet.WeatherForecast);
                    stamper.AcroFields.SetField("7 GENERAL SAFETY MESSAGERow1", currentSheet.GeneralSafety);

                    stamper.AcroFields.SetField("5 GENERAL CONTROL OBJECTIVES FOR THE INCIDENT include alternativesRow1", currentSheet.ActiveObjectivesAsString);

                    if (includeAttachments)
                    {
                        //checkboxes
                        bool Has203 = task.hasMeaningfulOrgChart(currentSheet.OpPeriod);
                        bool Has204 = task.hasMeaningfulTeamAssignments(currentSheet.OpPeriod);
                        bool Has205 = task.hasMeangfulCommsPlan(currentSheet.OpPeriod);
                        bool Has206 = task.hasMeaningfulMedicalPlan(currentSheet.OpPeriod);
                        bool Has208 = task.hasAnySafetyMessages(currentSheet.OpPeriod);
                        bool Has220 = task.hasMeaningfulAirOps(currentSheet.OpPeriod);

                        if (Has203) { PDFExtraTools.SetPDFCheckbox(stamper, "CBOrgList"); }
                        if (Has204) { PDFExtraTools.SetPDFCheckbox(stamper, "CBAssignmentList"); }
                        if (Has205) { PDFExtraTools.SetPDFCheckbox(stamper, "CBComms"); }
                        if (Has206) { PDFExtraTools.SetPDFCheckbox(stamper, "CBMedicalPlan"); }
                        if (Has203) { PDFExtraTools.SetPDFCheckbox(stamper, "CBOrgChart"); }
                        if (Has208) { PDFExtraTools.SetPDFCheckbox(stamper, "CBSafetyPlan"); }
                        if (Has220) { PDFExtraTools.SetPDFCheckbox(stamper, "CBAirOps"); }

                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }



                    stamper.Close();//Close a PDFStamper Object
                    rdr.Close();    //Close a PDFReader Object

                }
                catch (IOException ex)
                {
                    path = null;
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    path = null;
                    
                }
                return path;
            }
            else { return null; }
        }
        #endregion

        #region Organization Assignments / Chart
        public List<byte[]> exportOrgAssignmentListToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();
            PDFCreationResults results = createOrgAssignmentListPDF(task, OpPeriodToExport, true, flattenPDF);
            string path = results.path;
            if (path != null && results.Successful)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }




        public PDFCreationResults createOrgAssignmentListPDF(Incident task, int OpsPeriod, bool tempFileName = false, bool flattenPDF = false)
        {
            PDFCreationResults results = new PDFCreationResults();



            List<string> paths = new List<string>();
            string finalPath = FileAccessClasses.getWritablePath(task);
            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";


            OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == OpsPeriod);

            int ThisPageNumber = 1;


            paths.Add(path);
            results.TempPath = path;


            try
            {

                results.LastStepReached = -1;
                if (!task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod))
                {
                    task.createOrgChartAsNeeded(OpsPeriod);
                }

                OrganizationChart currentChart = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First();

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-203 Organization Assignment List Blanked.pdf");

                if (File.Exists(fileToUse))
                {
                    results.LastStepReached = 0;


                    using (PdfReader rdr = new PdfReader(fileToUse))
                    {
                        results.LastStepReached = 1;
                        using (FileStream stream = new System.IO.FileStream(path, FileMode.Create))
                        {
                            results.LastStepReached = 2;
                            using (PdfStamper stamper = new PdfStamper(rdr, stream))
                            {
                                results.LastStepReached = 3;


                                stamper.AcroFields.SetField("1 INCIDENT NAMERow1", task.IncidentNameOrNumber);
                                stamper.AcroFields.SetField("2 DATERow1", string.Format("{0:" + DateFormat + "}", currentChart.DatePrepared));
                                stamper.AcroFields.SetField("3 TIMERow1", string.Format("{0:HH:mm}", currentChart.DatePrepared));
                                stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                                stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                                stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                                ICSRole PreparedBy = new ICSRole();
                                if (currentChart.PreparedByRoleID != Guid.Empty)
                                {

                                    PreparedBy.IndividualName = currentChart.PreparedByResourceName;
                                    PreparedBy.BaseRoleName = currentChart.PreparedByRoleName;
                                }


                                if (null != PreparedBy)
                                {
                                    stamper.AcroFields.SetField("11 PREPARED BY", PreparedBy.RoleName);
                                    stamper.AcroFields.SetField("11 PREPARED BY_2", PreparedBy.IndividualName);
                                }
                                //stamper.AcroFields.SetField("PAGE", "1");
                                currentChart.SortRoles();

                                //Incident Command
                                List<ICSRole> icRoles = currentChart.GetRolesForAssignmentList(Globals.IncidentCommanderGenericID, 10, 7);
                                for (int x = 0; x < 7 && x < icRoles.Count; x++)
                                {
                                    if (icRoles[x].ReportsTo == Globals.IncidentCommanderGenericID || icRoles[x].RoleID == Globals.IncidentCommanderGenericID) { stamper.SetFieldFontBold("5 INCIDENT AND COMMAND STAFFRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("5 INCIDENT AND COMMAND STAFFRow" + (x + 1), icRoles[x].RoleName);
                                    stamper.AcroFields.SetField("5 INCIDENT AND COMMAND STAFFRow" + (x + 1) + "_2", icRoles[x].IndividualName);
                                }
                                //agency reps
                                List<ICSRole> repRoles = currentChart.ActiveRoles.Where(o => o.SectionID == Globals.IncidentCommanderGenericID && o.RoleName.Equals("Agency Representative")).OrderBy(o => o.Depth).ThenBy(o => o.ManualSortOrder).ThenBy(o => o.RoleName).ToList();
                                for (int x = 0; x < 7 && x < repRoles.Count; x++)
                                {

                                    if (repRoles[x].IndividualID != Guid.Empty && task.IncidentPersonnel.Any(o => o.ID == repRoles[x].IndividualID))
                                    {
                                        Personnel p = task.IncidentPersonnel.First(o => o.ID == repRoles[x].IndividualID);
                                        stamper.AcroFields.SetField("Agency  OrganizationRow" + (x + 1), p.Agency);
                                    }
                                    else { stamper.AcroFields.SetField("Agency  OrganizationRow" + (x + 1), repRoles[x].RoleName); }
                                    stamper.AcroFields.SetField("RepresentativeRow" + (x + 1), repRoles[x].IndividualName);
                                }

                                //Planning
                                List<ICSRole> planRoles = currentChart.GetRolesForAssignmentList(Globals.PlanningChiefGenericID, 0, 10);
                                for (int x = 0; x < 10 && x < planRoles.Count; x++)
                                {
                                    if (planRoles[x].ReportsTo == Globals.PlanningChiefGenericID || planRoles[x].RoleID == Globals.PlanningChiefGenericID) { stamper.SetFieldFontBold("7 PLANNING SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("7 PLANNING SECTIONRow" + (x + 1), planRoles[x].RoleName);
                                    stamper.AcroFields.SetField("7 PLANNING SECTIONRow" + (x + 1) + "_2", planRoles[x].IndividualName);
                                }

                                //Ops
                                List<ICSRole> opsRoles = currentChart.GetRolesForAssignmentList(Globals.OpsChiefGenericID, 0, 35);
                                for (int x = 0; x < 34 && x < opsRoles.Count; x++)
                                {
                                    if (opsRoles[x].ReportsTo == Globals.OpsChiefGenericID || opsRoles[x].RoleID == Globals.OpsChiefGenericID) { stamper.SetFieldFontBold("9 OPERATIONS SECTIONRow" + (x + 1)); }
                                    stamper.AcroFields.SetField("9 OPERATIONS SECTIONRow" + (x + 1), opsRoles[x].RoleName);
                                    stamper.AcroFields.SetField("9 OPERATIONS SECTIONRow" + (x + 1) + "_2", opsRoles[x].IndividualName);
                                }
                                //Logistics
                                List<ICSRole> logRoles = currentChart.GetRolesForAssignmentList(Globals.LogisticsChiefGenericID, 0, 13);
                                for (int x = 0; x < 13 && x < logRoles.Count; x++)
                                {
                                    if (logRoles[x].ReportsTo == Globals.LogisticsChiefGenericID || logRoles[x].RoleID == Globals.LogisticsChiefGenericID) { stamper.SetFieldFontBold("8 LOGISTICS SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("8 LOGISTICS SECTIONRow" + (x + 1), logRoles[x].RoleName);
                                    stamper.AcroFields.SetField("8 LOGISTICS SECTIONRow" + (x + 1) + "_2", logRoles[x].IndividualName);
                                }
                                //Finance
                                List<ICSRole> financeRoles = currentChart.GetRolesForAssignmentList(Globals.FinanceChiefGenericID, 0, 6);
                                for (int x = 0; x < 6 && x < financeRoles.Count; x++)
                                {
                                    if (financeRoles[x].ReportsTo == Globals.FinanceChiefGenericID || financeRoles[x].RoleID == Globals.FinanceChiefGenericID) { stamper.SetFieldFontBold("10 FINANCIALADMINISTRATION SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("10 FINANCIALADMINISTRATION SECTIONRow" + (x + 1), financeRoles[x].RoleName);
                                    stamper.AcroFields.SetField("10 FINANCIALADMINISTRATION SECTIONRow" + (x + 1) + "_2", financeRoles[x].IndividualName);
                                }






                                //Rename the fields
                                AcroFields af = stamper.AcroFields;
                                List<string> fieldNames = new List<string>();
                                foreach (var field in af.Fields)
                                {
                                    fieldNames.Add(field.Key);
                                }
                                foreach (string s in fieldNames)
                                {
                                    stamper.AcroFields.RenameField(s, s + "-203-" + ThisPageNumber);
                                }


                                results.LastStepReached = 4;


                                stamper.Close();//Close a PDFStamper Object
                                stamper.Dispose();
                                //rdr.Close();    //Close a PDFReader Object
                            }
                        }

                    }
                }
                else
                {
                    results.Successful = false;
                    Exception ex = new Exception(fileToUse + " -- File did not exist");
                    results.errors.Add(ex);
                    return results;
                }
                //Final file

                if (!tempFileName)
                {
                    if (task.DocumentPath == null && finalPath != null) { task.DocumentPath = finalPath; }
                    string outputFileName = "ICS 207 - Incident " + task.IncidentNameAndNumberForPath + " - Op " + OpsPeriod + " - Org Chart";
                    finalPath = FileAccessClasses.getUniqueFileName(outputFileName, finalPath);

                }
                else { finalPath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf"; }

                results.LastStepReached = 5;


                _ = PDFExtraTools.MergePDFs(paths, finalPath, flattenPDF);
                results.LastStepReached = 6;
                results.Successful = true;

            }
            catch (IOException ex)
            {
                results.errors.Add(ex);
                results.Successful = false;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                results.errors.Add(ex);
                results.Successful = false;
            }
            results.path = finalPath;


            return results;
        }
















        public List<byte[]> exportOrgChartToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createOrgChartPDF(task, OpPeriodToExport, false, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public string createOrgChartPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            List<string> paths = new List<string>();
            string finalPath = FileAccessClasses.getWritablePath(task);
            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";


            OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == OpsPeriod);

            int ThisPageNumber = 1;


            paths.Add(path);

            try
            {


                if (!task.allOrgCharts.Any(o => o.OpPeriod == OpsPeriod))
                {
                    task.createOrgChartAsNeeded(OpsPeriod);
                }

                OrganizationChart currentChart = task.allOrgCharts.Where(o => o.OpPeriod == OpsPeriod).First();

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-207-WF Incident Organization Chart.pdf");
                if (currentChart.IsUnifiedCommand) { fileToUse = ("ICS-207-WF Incident Organization Chart Unified.pdf"); }
                fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(path, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {


                            int TotalPages = currentChart.CalculateOrgChartPageCount();

                            stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentNameOrNumber);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                            ICSRole PreparedBy = new ICSRole();
                            if (currentChart.PreparedByResourceID != Guid.Empty)
                            {
                                //PreparedBy.teamMember = new Personnel(currentChart.PreparedByUserID);
                                PreparedBy.IndividualName = currentChart.PreparedByResourceName;
                                PreparedBy.BaseRoleName = currentChart.PreparedByRoleName;
                            }
                            else
                            {
                                PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefGenericID, true);
                            }

                            if (null != PreparedBy)
                            {
                                stamper.AcroFields.SetField("PreparedByPosition", PreparedBy.RoleName);
                                stamper.AcroFields.SetField("PreparedByName", PreparedBy.IndividualName);
                            }
                            stamper.AcroFields.SetField("PAGE", "1");


                            foreach (ICSRole role in currentChart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
                            {
                                int rolesAdded = 0;
                                int OnSheetChildSpots = 0;
                                string SectionNamePart = "";
                                if (role.SectionID == Globals.OpsChiefGenericID) { SectionNamePart = "Ops"; }
                                else if (role.SectionID == Globals.PlanningChiefGenericID) { SectionNamePart = "Plans"; }
                                else if (role.SectionID == Globals.LogisticsChiefGenericID) { SectionNamePart = "Logistics"; }
                                else if (role.SectionID == Globals.FinanceChiefGenericID) { SectionNamePart = "Finance"; }


                                if (role.GenericRoleID == Globals.OpsChiefGenericID) { OnSheetChildSpots = 4; }
                                else if (role.GenericRoleID == Globals.PlanningChiefGenericID) { OnSheetChildSpots = 4; }
                                else if (role.GenericRoleID == Globals.LogisticsChiefGenericID) { OnSheetChildSpots = 2; }
                                else if (role.GenericRoleID == Globals.FinanceChiefGenericID) { OnSheetChildSpots = 4; }
                                else if (role.GenericRoleID == Globals.IncidentCommanderGenericID || role.GenericRoleID == Globals.UnifiedCommand1GenericID) { OnSheetChildSpots = 1; }
                                else if (role.GenericRoleID == Globals.SafetyOfficerGenericID) { OnSheetChildSpots = 1; }
                                else if (role.GenericRoleID == Globals.LiaisonOfficerGenericID) { OnSheetChildSpots = 2; }
                                else if (role.GenericRoleID == Globals.InformationOfficerGenericID) { OnSheetChildSpots = 2; }
                                else if (role.GenericRoleID == Globals.SupportBranchGenericID || role.GenericRoleID == Globals.ServiceBranchGenericID) { OnSheetChildSpots = 3; }



                                if (!string.IsNullOrEmpty(role.PDFTitleName))
                                {
                                    stamper.AcroFields.SetField(role.PDFTitleName, role.RoleName);
                                }


                                List<ICSRole> childRoles = currentChart.GetChildRoles(role.RoleID, false);


                                foreach (ICSRole child in childRoles)
                                {
                                    string nameField = null;
                                    string titleField = null;


                                    if (!string.IsNullOrEmpty(child.PDFFieldName))
                                    {
                                        nameField = child.PDFFieldName;
                                    }

                                   else  if (rolesAdded < OnSheetChildSpots)
                                    {
                                        rolesAdded++;
                                        nameField = "Name" + SectionNamePart + rolesAdded;
                                        titleField = "Title" + SectionNamePart + rolesAdded;
                                    }

                                    if (!string.IsNullOrEmpty(nameField))
                                    {


                                        if (!string.IsNullOrEmpty(titleField))
                                        {
                                            stamper.AcroFields.SetField(titleField, child.RoleName);
                                        }


                                        List<ICSRole> subChildRoles = currentChart.GetChildRoles(child.RoleID, false);


                                        if (!subChildRoles.Any(o => string.IsNullOrEmpty(o.PDFFieldName)))
                                        {
                                            stamper.AcroFields.SetField(nameField, child.IndividualName);

                                        }
                                        else if (subChildRoles.Any())
                                        {
                                            // Otherwise, we need to start generating extra pages
                                            List<string> extraPaths = createOrgChartExtensionPDF(task, currentChart, child, paths.Count + 1, TotalPages);

                                            string seeMore = null;
                                            if (!string.IsNullOrEmpty(child.IndividualName)) { seeMore = child.IndividualName + " / "; }
                                            seeMore += "See page " + (paths.Count + 1);
                                            if (extraPaths.Count > 1) { seeMore += " - " + (paths.Count + extraPaths.Count); }
                                            stamper.AcroFields.SetField(nameField, seeMore);

                                            paths.AddRange(extraPaths);


                                        }
                                    }
                                }
                                /*
                                if (!childRoles.Any(o => string.IsNullOrEmpty(o.PDFFieldName)))
                                {
                                    stamper.AcroFields.SetField(role.PDFFieldName, role.IndividualName);

                                }
                                else if (childRoles.Any())
                                {
                                    // Otherwise, we need to start generating extra pages
                                    List<string> extraPaths = createOrgChartExtensionPDF(task, currentChart, role, paths.Count + 1, TotalPages);
                                    if (!string.IsNullOrEmpty(role.PDFFieldName))
                                    {
                                        string seeMore = null;
                                        if (!string.IsNullOrEmpty(role.IndividualName)) { seeMore = role.IndividualName + " / "; }
                                        seeMore += "See page " + (paths.Count + 1);
                                        if (extraPaths.Count > 1) { seeMore += " - " + (paths.Count + extraPaths.Count); }
                                        stamper.AcroFields.SetField(role.PDFFieldName, seeMore);
                                    }
                                    paths.AddRange(extraPaths);

                                }
                                */
                            }

                            if (TotalPages != paths.Count)
                            {

                            }
                            stamper.AcroFields.SetField("OF", paths.Count.ToString());


                            //Rename the fields
                            AcroFields af = stamper.AcroFields;
                            List<string> fieldNames = new List<string>();
                            foreach (var field in af.Fields)
                            {
                                fieldNames.Add(field.Key);
                            }
                            foreach (string s in fieldNames)
                            {
                                stamper.AcroFields.RenameField(s, s + "-207-" + ThisPageNumber);
                            }





                            stamper.Close();//Close a PDFStamper Object
                            stamper.Dispose();
                            //rdr.Close();    //Close a PDFReader Object
                        }
                    }

                }

                //Final file

                if (!tempFileName)
                {
                    if (task.DocumentPath == null && finalPath != null) { task.DocumentPath = finalPath; }
                    string outputFileName = "ICS 207 - Task " + task.IncidentNameAndNumberForPath + " - Op " + OpsPeriod + " - Org Chart";
                    finalPath = FileAccessClasses.getUniqueFileName(outputFileName, finalPath);
                }
                else { finalPath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf"; }




                _ = PDFExtraTools.MergePDFs(paths, finalPath, flattenPDF);


            }
            catch (IOException ex)
            {

            }
            catch (System.UnauthorizedAccessException)
            {

            }
            return finalPath;
        }

   


        private string getOrgChartPositionFieldName(int childNumber, int grandChildNumber)
        {
            string positionFieldName = "";

            switch (childNumber)
            {
                case 0:
                    positionFieldName = "PositionA";
                    break;
                case 1:
                    positionFieldName = "PositionB";
                    break;
                case 2:
                    positionFieldName = "PositionC";
                    break;
                case 3:
                    positionFieldName = "PositionD";
                    break;

            }

            positionFieldName = positionFieldName + (grandChildNumber + 1);
            return positionFieldName;
        }
        private string getOrgChartNameFieldName(int childNumber, int grandChildNumber)
        {
            string nameFieldName = "";

            switch (childNumber)
            {
                case 0:
                    nameFieldName = "NameA";
                    break;
                case 1:
                    nameFieldName = "NameB";
                    break;
                case 2:
                    nameFieldName = "NameC";
                    break;
                case 3:
                    nameFieldName = "NameD";
                    break;

            }

            nameFieldName = nameFieldName + (grandChildNumber + 1);
            return nameFieldName;
        }

        

        public List<string> createOrgChartExtensionPDF(Incident task, OrganizationChart currentChart, ICSRole parentRole, int ThisPageNumber, int totalPages, int startOnChild = 0, bool flattenPDF = false)
        {
            List<string> paths = new List<string>();


            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == currentChart.OpPeriod);
            paths.Add(path);

            try
            {
                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-207-WF-Organization-Chart-Extension.pdf");
                fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(path, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {



                            stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentIdentifier);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                            ICSRole PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefGenericID, true);
                            if (null != PreparedBy)
                            {
                                stamper.AcroFields.SetField("PreparedByPosition", PreparedBy.RoleName);
                                stamper.AcroFields.SetField("PreparedByName", PreparedBy.IndividualName);
                            }
                            stamper.AcroFields.SetField("PAGE", ThisPageNumber.ToString());
                            stamper.AcroFields.SetField("OF", totalPages.ToString());

                            //Parent Role
                            stamper.AcroFields.SetField("Position1", parentRole.RoleName);
                            stamper.AcroFields.SetField("Name1", parentRole.IndividualName);

                            List<ICSRole> childRoles = currentChart.GetChildRoles(parentRole.RoleID, false);
                            childRoles = childRoles.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();

                            for (int r = startOnChild; r < childRoles.Count && r < (startOnChild + 4); r++)
                            {
                                ICSRole child = childRoles[r];
                                string positionFieldName = getOrgChartPositionFieldName(r, 0);
                                string nameFieldName = getOrgChartNameFieldName(r, 0);


                                stamper.AcroFields.SetField(positionFieldName, child.RoleName);
                                stamper.AcroFields.SetField(nameFieldName, child.IndividualName);

                                List<ICSRole> grandChildren = currentChart.GetChildRoles(child.RoleID, false);
                                grandChildren = grandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();

                                for (int g = 0; g < grandChildren.Count && g < 5; g++)
                                {
                                    ICSRole grandchild = grandChildren[g];
                                    string gcpositionFieldName = getOrgChartPositionFieldName(r, g + 1);
                                    string gcnameFieldName = getOrgChartNameFieldName(r, g + 1); ;

                                    //If it has grand kits, this starts over again...
                                    List<ICSRole> greatGrandChildren = currentChart.GetChildRoles(grandchild.RoleID, false);
                                    greatGrandChildren = greatGrandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();

                                    if (greatGrandChildren.Count > 0)
                                    {
                                        stamper.AcroFields.SetField(gcpositionFieldName, grandchild.RoleName);
                                        string seeMore = null;
                                        if (!string.IsNullOrEmpty(grandchild.IndividualName)) { seeMore = grandchild.IndividualName + " / "; }
                                        seeMore += "See page " + (ThisPageNumber + 1);
                                        

                                        stamper.AcroFields.SetField(gcnameFieldName, seeMore);

                                        List<string> childPaths = createOrgChartExtensionPDF(task, currentChart, grandchild, ThisPageNumber + 1, totalPages,0, flattenPDF);
                                        paths.AddRange(childPaths);
                                    }
                                    else
                                    {
                                        stamper.AcroFields.SetField(gcpositionFieldName, grandchild.RoleName);
                                        stamper.AcroFields.SetField(gcnameFieldName, grandchild.IndividualName);
                                    }



                                }





                            }

                            if(childRoles.Count > startOnChild + 4)
                            {
                                for(int x = startOnChild + 4; x < childRoles.Count; x = x + 4)
                                {
                                    List<string> childPaths = createOrgChartExtensionPDF(task, currentChart, parentRole, ThisPageNumber + paths.Count, x, totalPages, flattenPDF);
                                    paths.AddRange(childPaths);
                                }
                            }






                            //Rename the fields
                            AcroFields af = stamper.AcroFields;
                            List<string> fieldNames = new List<string>();
                            foreach (var field in af.Fields)
                            {
                                fieldNames.Add(field.Key);
                            }
                            foreach (string s in fieldNames)
                            {
                                 stamper.AcroFields.RenameField(s, s + "-207-" + ThisPageNumber); 
                            }





                            stamper.Close();//Close a PDFStamper Object
                            stamper.Dispose();
                        }
                        //rdr.Close();    //Close a PDFReader Object
                    }
                }

            }
            catch (IOException ex)
            {

            }
            catch (System.UnauthorizedAccessException)
            {

            }
            return paths;
        }



        public List<byte[]> exportOrgChartContactsToPDF(Incident task, int OpPeriodToExport)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            PDFCreationResults results = createOrgChartContactList(task, OpPeriodToExport, false, true);

            if (!string.IsNullOrEmpty(results.path))
            {
                using (FileStream stream = File.OpenRead(results.path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public PDFCreationResults createOrgChartContactList(Incident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false)
        {
            PDFCreationResults results = new PDFCreationResults();



            if (task != null)
            {
                OrganizationChart chart = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opsPeriod);
              if(chart != null && chart.ActiveRoles.Any(o => !string.IsNullOrEmpty(o.IndividualName)))
                {
                    results.path = FileAccessClasses.getWritablePath(task);
                    if (!tempFileName)
                    {
                        if (task.DocumentPath == null && results.path != null) { task.DocumentPath = results.path; }
                        string outputFileName = "Org Chart Contacts " + opsPeriod.ToString(Globals.cultureInfo);
                        outputFileName = outputFileName.ReplaceInvalidPathChars();

                        results.path = FileAccessClasses.getUniqueFileName(outputFileName, results.path);
                        //path = System.IO.Path.Combine(path, outputFileName);

                    }
                    else
                    {
                        results.path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                    }
                    try
                    {

                        using (System.IO.FileStream fs = new FileStream(results.path, FileMode.Create))
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


                            document.AddTitle("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + opsPeriod.ToString(Globals.cultureInfo));

                            // Open the document to enable you to write to the document

                            document.Open();
                            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                            iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                            iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                            iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                            iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                            // Add a simple and wellknown phrase to the document in a flow layout manner
                            //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                            Anchor briefingTarget = new Anchor("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + opsPeriod.ToString(Globals.cultureInfo), titlefont);
                            briefingTarget.Name = "Briefing";
                            Paragraph tp = new Paragraph();
                            tp.Add(briefingTarget);
                            tp.Font = titlefont;

                            document.Add(tp);

                            Paragraph spacer = new Paragraph();
                            spacer.Add(" ");
                            document.Add(spacer);

                            //for a small operation, keep it easy
                            if (chart.ActiveRoles.Count(o => !string.IsNullOrEmpty(o.IndividualName)) <= 5)
                            {
                                PdfPTable table = new PdfPTable(3);
                                table.WidthPercentage= 100;

                                Paragraph p = new Paragraph();
                                p.SpacingAfter = 10;
                                p.Font = sectionfont;
                                p.Add("Command Team Contact Info");

                                PdfPCell cell = new PdfPCell(p);
                                cell.Colspan = 3;
                                cell.Padding = 10;
                                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                                table.AddCell(cell);
                                foreach (ICSRole role in chart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)))
                                {
                                    if (task.IncidentPersonnel.Any(o => o.ID == role.IndividualID))
                                    {
                                        Personnel pers = task.IncidentPersonnel.First(o => o.ID == role.IndividualID);

                                        table.AddCell(role.RoleName);
                                        table.AddCell(role.IndividualName);
                                        string contactInfo = null;
                                        if (!string.IsNullOrEmpty(pers.CellphoneNumber)) { contactInfo = pers.CellphoneNumber.FormatPhone(); }
                                        if (!string.IsNullOrEmpty(pers.Email))
                                        {
                                            if (!string.IsNullOrEmpty(contactInfo)) { contactInfo += Environment.NewLine; }
                                            contactInfo += pers.Email;
                                        }
                                        table.AddCell(contactInfo);
                                    }
                                }

                                document.Add(table);
                            }
                            else //large compelx org chart, break it down by section
                            {
                                List<Guid> branches = new List<Guid>();
                                foreach (ICSRole role in chart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)))
                                {
                                    Guid branchid = role.SectionID;
                                    if (!branches.Contains(branchid)) { branches.Add(branchid); }
                                }

                                foreach (Guid branch in branches)
                                {
                                    string branchName = chart.ActiveRoles.First(o => o.GenericRoleID == branch).RoleName;
                                    branchName = branchName.Replace(" Chief", "");

                                    PdfPTable table = new PdfPTable(3);
                                    Paragraph p = new Paragraph();
                                    p.SpacingAfter = 30;
                                    p.Font = sectionfont;
                                    p.Add(branchName);

                                    PdfPCell cell = new PdfPCell(p);
                                    cell.Colspan = 3;
                                    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                                    cell.Padding = 10;
                                    table.AddCell(cell);
                                    foreach (ICSRole role in chart.ActiveRoles.Where(o => o.SectionID == branch && !string.IsNullOrEmpty(o.IndividualName)))
                                    {
                                        if (task.IncidentPersonnel.Any(o => o.ID == role.IndividualID))
                                        {
                                            Personnel pers = task.IncidentPersonnel.First(o => o.ID == role.IndividualID);
                                            iTextSharp.text.Font fonttoUse = normalfont;
                                            if (role.RoleID == branch) { fonttoUse = subsectionfont; }

                                            table.AddCell(new Phrase(role.RoleName, fonttoUse));
                                            table.AddCell(new Phrase(role.IndividualName, fonttoUse));
                                            string contactInfo = null;
                                            if (!string.IsNullOrEmpty(pers.CellphoneNumber)) { contactInfo = pers.CellphoneNumber.FormatPhone(); }
                                            if (!string.IsNullOrEmpty(pers.Email))
                                            {
                                                if (!string.IsNullOrEmpty(contactInfo)) { contactInfo += Environment.NewLine; }
                                                contactInfo += pers.Email;
                                            }
                                            table.AddCell(contactInfo);
                                        }
                                        /*
                                        if (!string.IsNullOrEmpty(role.teamMember.Phone)) { table.AddCell(new Phrase(role.teamMember.Phone.FormatPhone(), fonttoUse)); }
                                        else { table.AddCell(new Phrase(role.teamMember.Email, fonttoUse)); }
                                        */
                                    }

                                    document.Add(table);
                                    document.Add(spacer);
                                }

                            }






                            // Close the document
                            document.Close();
                            // Close the writer instance
                            writer.Close();

                            // Always close open filehandles explicity

                        }
                        if (automaticallyOpen)
                        {
                            try { System.Diagnostics.Process.Start(results.path); }
                            catch { }
                        }
                    }
                    catch (Exception ex)
                    {
                        results.errors.Add(ex);
                    }
                }
            }
            return results                ;
        }

        #endregion

        #region Contacts

        public List<byte[]> exportContactsToPDF(Incident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createContactsPDF(task, OpPeriodToExport, PreparedByName, PreparedByRoleName, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }

        public  string createContactsPDF(Incident task, int OpPeriod, string createdBy, string createdByTitle, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "ICS 205A - " + task.IncidentNameAndNumberForPath + " - Communications List " + OpPeriod.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS205A-CommunicationsList.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));



                    OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpPeriod).First();

                    stamper.AcroFields.SetField("1 Incident Name", task.IncidentIdentifier);


                    stamper.AcroFields.SetField("Text44", string.Format("{0:" + DateFormat + " HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Text45", string.Format("{0:" + DateFormat + " HH:mm}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("Text48", string.Format("{0:" + DateFormat + " HH:mm}", DateTime.Now));
                    stamper.AcroFields.SetField("Name", createdBy);
                    stamper.AcroFields.SetField("Text46", createdByTitle);

                    for (int x = 0; x < task.allContacts.Count && x < 34; x++)
                    {
                        //
                        stamper.AcroFields.SetField("Incident Assigned PositionRow" + (x + 1), task.allContacts[x].OrgAndTitle);
                        stamper.AcroFields.SetField("ContactName" + (x + 1), task.allContacts[x].ContactName);
                        stamper.AcroFields.SetField("Methods of Contact phone pager cell etcRow" + (x + 1), task.allContacts[x].AllContactMethods);
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }
        #endregion

        #region Vehicles
        public List<byte[]> exportVehiclesToPDF(Incident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName,  bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createVehiclePDF(task, OpPeriodToExport, PreparedByName, PreparedByRoleName, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }


        public string createVehiclePDF(Incident task, int OpPeriod, string PreparedByName, string PreparedByRoleName, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "ICS 218 - Task " + task.TaskNumber + " - Support Vehicle Equipment Inventory " + OpPeriod.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS 218 - Support Vehicle Equipment Inventory.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));



                    stamper = buildVehiclePDFContents(stamper, task, OpPeriod, PreparedByName, PreparedByRoleName, flattenPDF);

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }

        private PdfStamper buildVehiclePDFContents(PdfStamper stamper, Incident task, int OpsPeriod, string PreparedByName, string PreparedByRoleName, bool flattenPDF)
        {
            OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpsPeriod).First();

            stamper.AcroFields.SetField("1 INCIDENT NAME", task.TaskName);
            stamper.AcroFields.SetField("2 INCIDENT NUMBER", task.TaskNumber);


            stamper.AcroFields.SetField("3. DATE/TIME PREPARED Date", string.Format("{0:" + DateFormat + "}", DateTime.Now));
            stamper.AcroFields.SetField("3. DATE/TIME PREPARED Time", string.Format("{0:HH:mm}", DateTime.Now));
            stamper.AcroFields.SetField("6. PREPARED BY Name", PreparedByName + " - " + PreparedByRoleName);


            for (int x = 0; x < task.allVehicles.Where(o => o.OpPeriod == OpsPeriod).Count() && x < 13; x++)
            {
                //
                stamper.AcroFields.SetField("Order Request NoRow" + (x + 1), task.allVehicles[x].OrderRequestNo);
                stamper.AcroFields.SetField("Incident ID NoRow" + (x + 1), task.allVehicles[x].IncidentIDNo);
                stamper.AcroFields.SetField("Vehicle or Equipment ClassificationRow" + (x + 1), task.allVehicles[x].Classification);
                stamper.AcroFields.SetField("Vehicle or Equipment MakeRow" + (x + 1), task.allVehicles[x].Make);
                stamper.AcroFields.SetField("Category KindType Capacity or SizeRow" + (x + 1), task.allVehicles[x].CategoryKindCapacity);
                stamper.AcroFields.SetField("Vehicle or Equipment Features Row" + (x + 1), task.allVehicles[x].Features);
                stamper.AcroFields.SetField("Agency or OwnerRow" + (x + 1), task.allVehicles[x].AgencyOrOwner);
                stamper.AcroFields.SetField("Operator Name or ContactRow" + (x + 1), task.allVehicles[x].OperatorName);
                stamper.AcroFields.SetField("Vehicle License or ID NoRow" + (x + 1), task.allVehicles[x].LicenseOrID);
                stamper.AcroFields.SetField("Incident AssignmentRow" + (x + 1), task.allVehicles[x].IncidentAssignment);
                stamper.AcroFields.SetField("Incident Start Date and TimeRow" + (x + 1), task.allVehicles[x].StartTime.ToString(DateFormat + " HH:mm"));
                stamper.AcroFields.SetField("Incident Release Date and TimeRow" + (x + 1), task.allVehicles[x].MustBeOutTime.ToString(DateFormat + " HH:mm"));

            }


            if (flattenPDF)
            {
                stamper.FormFlattening = true;
            }

            return stamper;
        }
        #endregion

        #region Check In Sheet (211)

        public List<byte[]> exportCheckInSheetsToPDF(Incident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriodToExport);
            OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriodToExport);
            List<CheckInRecordWithResource> allCheckInRecords =   incident.GetCheckInWithResources(OpPeriodToExport); 
            allCheckInRecords = allCheckInRecords.Where(o=>o.Record.ParentRecordID == Guid.Empty).OrderBy(o=>o.Record.CheckInLocation).ToList(); //remove contents of crews
            if (thisOpOnly) { allCheckInRecords = allCheckInRecords.Where(o=>o.Record.OpPeriod == OpPeriodToExport).ToList(); }

            List<string> CheckInLocations = allCheckInRecords.Select(o => o.CheckInLocation).Distinct().ToList();

            foreach (string checkInLocation in CheckInLocations)
            {

                List<CheckInRecordWithResource> checkInThisLocation = allCheckInRecords.Where(o => !string.IsNullOrEmpty(o.CheckInLocation) && o.CheckInLocation.Equals(checkInLocation, StringComparison.InvariantCultureIgnoreCase)).ToList();
                int totalPages = 1;
                int rowsOnPage = 18;


                if (checkInThisLocation.Count > rowsOnPage)
                {
                    totalPages += Convert.ToInt32(Math.Floor(Convert.ToDecimal(checkInThisLocation.Count - rowsOnPage) / Convert.ToDecimal(rowsOnPage)));
                    if ((checkInThisLocation.Count - rowsOnPage) % rowsOnPage > 0) { totalPages += 1; }
                    if (totalPages == 0) { totalPages = 1; }
                }

                List<string> pdfFileNames = new List<string>();

                for (int x = 1; x <= totalPages; x++)
                {
                    List<CheckInRecordWithResource> resourcesThisPage = checkInThisLocation.Skip((x - 1) * rowsOnPage).Take(rowsOnPage).ToList();
                    allPDFs.AddRange(createSinglePageCheckInSheetPDF(incident, OpPeriodToExport, resourcesThisPage, x, totalPages, flattenPDF));

                }
            }
            /*
            List<PositionLogEntry> extraPageEntries = entries.Skip(19).ToList();
            for (int x = 1; x < totalPages; x++)
            {
                List<PositionLogEntry> nextEntries = extraPageEntries.Skip(31 * (x - 1)).Take(37).ToList();

                allPDFs.AddRange(buildPDFPage(nextEntries, task, OpPeriodToExport, role, x + 1, totalPages, flattenPDF));
            }
            */


            return allPDFs;
        }

        private List<byte[]> createSinglePageCheckInSheetPDF(Incident incident, int OpPeriod, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "ICS-211 - " + incident.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString() + " page " + thisPageNum;
            outputFileName += ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            string fileToUse = PDFExtraTools.getPDFFilePath("ICS-211-WF Check In.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
                    OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod);

                    string checkInLocation = null;
                    if (allCheckInRecords.Any(o => !string.IsNullOrEmpty(o.Record.CheckInLocation)))
                    {
                        checkInLocation = allCheckInRecords.First(o => !string.IsNullOrEmpty(o.Record.CheckInLocation)).Record.CheckInLocation;
                    }

                    stamper.AcroFields.SetField("1 INCIDENT NAMERow1", incident.TaskName);
                    stamper.AcroFields.SetField("2 INCIDENT NUMBERRow1", incident.TaskNumber);
                    stamper.AcroFields.SetField("3 CHECKIN LOCATIONRow1", checkInLocation);



                    stamper.AcroFields.SetField("DATE", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("TIME", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));

                   
                    for(int x = 0; x<allCheckInRecords.Count && x < 18; x++ )
                    {
                        CheckInRecordWithResource record = allCheckInRecords[x];

                        Personnel p = null; if (record.Resource.GetType().Name.Equals("Personnel")) { p = (Personnel)record.Resource; }
                        Vehicle v = null; if (record.Resource.GetType().Name.Equals("Vehicle")) { v = (Vehicle)record.Resource; }
                        Crew c = null; if (record.Resource.GetType().Name.Equals("OperationalSubGroup")) { c = (Crew)record.Resource; }



                        //Field 5
                        if (p != null) { stamper.AcroFields.SetField("PTRow" + (x + 1), p.ProvinceNameShort); }
                        if (p != null) { stamper.AcroFields.SetField("AGENCYRow" + (x + 1), p.Agency); }
                        stamper.AcroFields.SetField("CATRow" + (x + 1), record.ResourceType);
                        stamper.AcroFields.SetField("KINDRow" + (x + 1), record.Resource.Kind);
                        stamper.AcroFields.SetField("TYPERow" + (x + 1), record.Resource.Type);
                        stamper.AcroFields.SetField("STTFRow" + (x + 1), "");
                        stamper.AcroFields.SetField("RESOURCE NAME OR IDRow" + (x + 1), record.Resource.UniqueIDNumWithPrefix + " " + record.Resource.ResourceName);


                        stamper.AcroFields.SetField("6 LDWRow" + (x + 1), record.Record.LastDayOnIncident.ToString(Globals.DateFormat));
                        if (record.Record.InfoFields.Any(o => o.ID == new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d")))
                        {
                            CheckInInfoField field = record.Record.InfoFields.First(o => o.ID == new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d"));
                            stamper.AcroFields.SetField("7 ORDER REQUEST NUMBERRow" + (x + 1), field.StringValue);
                        }
                        stamper.AcroFields.SetField("8 DATETIME CHECKINRow" + (x + 1), record.CheckInDate.ToString(Globals.DateFormat));
                        stamper.AcroFields.SetField("9 LEADERS NAMERow" + (x + 1), record.Resource.LeaderName);
                        stamper.AcroFields.SetField("10 TOTAL NUMBER PERSONNELRow" + (x + 1), record.Resource.NumberOfPeople.ToString());
                        stamper.AcroFields.SetField("11 CONTACT INFORMATIONRow" + (x + 1), record.Resource.Contact);
                        if (p != null) { stamper.AcroFields.SetField("12 HOME UNITBASERow" + (x + 1), p.HomeUnit); }
                        stamper.AcroFields.SetField("13 DEPARTURE POINTRow" + (x + 1), "");
                        if (record.Record.InfoFields.Any(o => o.ID == new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89")))
                        {
                            CheckInInfoField field = record.Record.InfoFields.First(o => o.ID == new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89"));
                            stamper.AcroFields.SetField("14 METHOD OF TRAVELRow" + (x + 1), field.StringValue);
                        }
                        stamper.AcroFields.SetField("15 INCIDENT ASSINGMENTRow" + (x + 1), record.Record.InitialRoleAcronym);
                        stamper.AcroFields.SetField("16 OTHER QUALIFICATIONSRow" + (x + 1), "");
                        stamper.AcroFields.SetField("17 SENT TO RESOURCE UNITRow" + (x + 1), "");
                    }


                    ICSRole PreparedBy = currentOrgChart.GetRoleByID(Globals.LogisticsChiefGenericID, true);


                    stamper.AcroFields.SetField("18 REMARKSRow1", "");
                    stamper.AcroFields.SetField("Position", PreparedBy.RoleName);
                    stamper.AcroFields.SetField("Name", PreparedBy.IndividualName);


                    stamper.AcroFields.SetField("PAGE", thisPageNum.ToString());
                    stamper.AcroFields.SetField("OF", totalPageNum.ToString());



                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    Guid randomID = Guid.NewGuid();
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + randomID.ToString());
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }

            List<byte[]> allPDFs = new List<byte[]>();

            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }
            return allPDFs;
        }

        #endregion


        #region Sign In Sheets (SAR)
        public string exportSinglePageSignInSheetAsPDF(Incident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            //string outputFileName = "ICS 215 - Task #" + CurrentTask.TaskNumber + " - Operations Plan.pdf";
            //path = System.IO.Path.Combine(path, outputFileName);

            PdfReader rdr = new PdfReader(fileToUse);
            PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));


            //Op Plan

            //Top Section
            stamper.AcroFields.SetField("TASK", task.TaskNumber);
            stamper.AcroFields.SetField("TASK NAME", task.TaskName);

            stamper.AcroFields.SetField("FOR OP PERIOD", OpsPeriod.ToString());
            if (statuses.Count > 0)
            {
                stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:" + DateFormat + " HH:mm}", statuses.OrderBy(o => o.SignInTime).First().SignInTime));
                if (statuses.Any(o => o.SignOutTime < DateTime.MaxValue))
                {
                    stamper.AcroFields.SetField("PeriodTo", string.Format("{0:" + DateFormat + " HH:mm}", statuses.Where(o => o.SignOutTime < DateTime.MaxValue).OrderByDescending(o => o.SignOutTime).First().SignOutTime));
                }
                stamper.AcroFields.SetField("GROUP NAME", statuses[0].OrganizationName);
            }



            stamper.AcroFields.SetField("PAGE", pageNumber.ToString());

            double totalHours = 0;
            decimal totalKMs = 0;

            for (int x = 0; x < statuses.Count; x++)
            {
                MemberStatus status = statuses[x];
                Personnel member = new Personnel();
                if (status.MemberID != Guid.Empty && task.IncidentPersonnel.Any(o => o.PersonID == status.MemberID)) { member = task.IncidentPersonnel.First(o => o.PersonID == status.MemberID); }

                stamper.AcroFields.SetField("Name" + (x + 1).ToString(), status.MemberName);
                


                string timein = string.Format("{0:HH:mm}", status.SignInTime);
                stamper.AcroFields.SetField("TimeIn" + (x + 1).ToString(), timein);
                if (statuses[x].SignOutTime < DateTime.MaxValue)
                {
                    stamper.AcroFields.SetField("TimeOut" + (x + 1).ToString(), string.Format("{0:HH:mm}", status.SignOutTime));
                }
                else
                {
                    stamper.AcroFields.SetField("TimeOut" + (x + 1).ToString(), "");
                }
                if (status.SignInTime > DateTime.MinValue && status.SignOutTime < DateTime.MaxValue)
                {
                    TimeSpan ts = status.SignOutTime - status.SignInTime;
                    totalHours += ts.TotalHours;
                    stamper.AcroFields.SetField("Hours" + (x + 1).ToString(), string.Format("{0:#,##0.0}", ts.TotalHours));
                }
                if (status.KMs > 0)
                {
                    stamper.AcroFields.SetField("KM" + (x + 1).ToString(), string.Format("{0:#,##0.0}", status.KMs));
                    totalKMs += status.KMs;
                }

            }
            stamper.AcroFields.SetField("OF", totalPages.ToString());
            stamper.AcroFields.SetField("HoursTotal", string.Format("{0:#,##0.0}", totalHours));
            stamper.AcroFields.SetField("KMTotal", string.Format("{0:#,##0.0}", totalKMs));
            Guid page = Guid.NewGuid();
            /* Rename all the fields in case there is more than 1 page */
            stamper.AcroFields.RenameField("TASK", "211TASK" + page.ToString());
            stamper.AcroFields.RenameField("TASK NAME", "211TASK NAME" + page.ToString());
            stamper.AcroFields.RenameField("GROUP NAME", "211GROUP NAME" + page.ToString());
            stamper.AcroFields.RenameField("PeriodTo", "211PeriodTo" + page.ToString());
            stamper.AcroFields.RenameField("PeriodFrom", "211PeriodFrom" + page.ToString());
            stamper.AcroFields.RenameField("PAGE", "211PageNumber" + page.ToString());
            stamper.AcroFields.RenameField("OF", "211PageCount" + page.ToString());
            stamper.AcroFields.RenameField("CHECKIN LOCATION", "211CHECKIN LOCATION" + page.ToString());
            stamper.AcroFields.RenameField("FOR OP PERIOD", "211FOR OP PERIOD" + page.ToString());
            stamper.AcroFields.RenameField("KMTotal", "211KMTotal" + page.ToString());
            for (int x = 1; x < 7; x++)
            {
                stamper.AcroFields.RenameField("Name" + x.ToString(), "211Name" + x.ToString() + "-" + page.ToString());
                stamper.AcroFields.RenameField("TimeIn" + x.ToString(), "211TimeIn" + x.ToString() + "-" + page.ToString());
                stamper.AcroFields.RenameField("TimeOut" + x.ToString(), "211TimeOut" + x.ToString() + "-" + page.ToString());
            }


            stamper.Close();//Close a PDFStamper Object
            rdr.Close();    //Close a PDFReader Object

            return path;
        }

        public List<byte[]> createSinglePageSignInSheetAsBytes(Incident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            //string outputFileName = "ICS 215 - Task #" + CurrentTask.TaskNumber + " - Operations Plan.pdf";
            //path = System.IO.Path.Combine(path, outputFileName);

            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {


                    //Op Plan

                    //Top Section
                    stamper.AcroFields.SetField("TASK", task.TaskNumber);
                    stamper.AcroFields.SetField("TASK NAME", task.TaskName);

                    stamper.AcroFields.SetField("FOR OP PERIOD", OpsPeriod.ToString());
                    if (statuses.Count > 0)
                    {
                        stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:" + DateFormat + " HH:mm}", statuses.OrderBy(o => o.SignInTime).First().SignInTime));
                        if (statuses.Any(o => o.SignOutTime < DateTime.MaxValue))
                        {
                            stamper.AcroFields.SetField("PeriodTo", string.Format("{0:" + DateFormat + " HH:mm}", statuses.Where(o => o.SignOutTime < DateTime.MaxValue).OrderByDescending(o => o.SignOutTime).First().SignOutTime));
                        }
                        stamper.AcroFields.SetField("GROUP NAME", statuses[0].OrganizationName);
                    }



                    stamper.AcroFields.SetField("PAGE", pageNumber.ToString());

                    double totalHours = 0;
                    decimal totalKMs = 0;
                    GeneralOptions options = new GeneralOptionsService().GetGeneralOptions();

                    for (int x = 0; x < statuses.Count; x++)
                    {
                        MemberStatus status = statuses[x];
                        Personnel member = new Personnel();
                        if (status.MemberID != Guid.Empty && task.IncidentPersonnel.Where(o => o.PersonID == status.MemberID).Any()) { member = task.IncidentPersonnel.Where(o => o.PersonID == status.MemberID).First(); }
                      
                        stamper.AcroFields.SetField("Name" + (x + 1).ToString(), status.MemberName);



                        string timein = string.Format("{0:HH:mm}", status.SignInTime);
                        stamper.AcroFields.SetField("TimeIn" + (x + 1).ToString(), timein);
                        if (statuses[x].SignOutTime < DateTime.MaxValue)
                        {
                            stamper.AcroFields.SetField("TimeOut" + (x + 1).ToString(), string.Format("{0:HH:mm}", status.SignOutTime));
                        }
                        else
                        {
                            stamper.AcroFields.SetField("TimeOut" + (x + 1).ToString(), "");
                        }
                        if (status.SignInTime > DateTime.MinValue && status.SignOutTime < DateTime.MaxValue)
                        {
                            TimeSpan ts = status.SignOutTime - status.SignInTime;
                            totalHours += ts.TotalHours;
                            stamper.AcroFields.SetField("Hours" + (x + 1).ToString(), string.Format("{0:#,##0.0}", ts.TotalHours));
                        }
                        if (status.KMs > 0)
                        {
                            stamper.AcroFields.SetField("KM" + (x + 1).ToString(), string.Format("{0:#,##0.0}", status.KMs));
                            totalKMs += status.KMs;
                        }

                    }
                    stamper.AcroFields.SetField("OF", totalPages.ToString());
                    stamper.AcroFields.SetField("HoursTotal", string.Format("{0:#,##0.0}", totalHours));
                    stamper.AcroFields.SetField("KMTotal", string.Format("{0:#,##0.0}", totalKMs));
                    Guid page = Guid.NewGuid();


                    /* Rename all the fields in case there is more than 1 page */
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-" + page.ToString());
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


        public List<byte[]> createSinglePageBlankSignInSheetAsBytes(Incident task, GroupSignInPrintRequest group, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            //string outputFileName = "ICS 215 - Task #" + task.TaskNumber + " - Operations Plan.pdf";
            //path = System.IO.Path.Combine(path, outputFileName);

            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {


                    //Op Plan

                    //Top Section
                    stamper.AcroFields.SetField("TASK", task.TaskNumber);
                    stamper.AcroFields.SetField("TASK NAME", task.TaskName);

                    stamper.AcroFields.SetField("FOR OP PERIOD", OpsPeriod.ToString());
                    stamper.AcroFields.SetField("GROUP NAME", group.OrganizationName);




                    stamper.AcroFields.SetField("PAGE", pageNumber.ToString());
                    stamper.AcroFields.SetField("OF", totalPages.ToString());

                    Guid page = Guid.NewGuid();


                    /* Rename all the fields in case there is more than 1 page */
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-" + page.ToString());
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


        public List<byte[]> getSignInSheetPDFs(Incident task, int OpsPeriod, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<MemberStatus> Statuses = task.getAllMemberStatus(OpsPeriod, DateTime.MinValue, true);
            List<GroupSignInRecords> groupSignInRecords = new List<GroupSignInRecords>();
            foreach (MemberStatus status in Statuses)
            {
                if (!groupSignInRecords.Where(o => o.GroupName == status.OrganizationName).Any())
                {
                    groupSignInRecords.Add(new GroupSignInRecords(status.OrganizationName));
                }
                groupSignInRecords.Where(o => o.GroupName == status.OrganizationName).First().MemberStatuses.Add(status);
            }


            for (int gr = 0; gr < groupSignInRecords.Count; gr++)
            {
                for (int x = 1; x <= groupSignInRecords[gr].totalPages; x++)
                {
                    List<MemberStatus> nextStatuses = groupSignInRecords[gr].MemberStatuses.Skip(6 * (x - 1)).Take(6).ToList();

                    allPDFs.AddRange(createSinglePageSignInSheetAsBytes(task, nextStatuses, x, groupSignInRecords[gr].totalPages, OpsPeriod, flattenPDF));
                }
            }

            return allPDFs;
        }

        public List<byte[]> getBlankSignInSheetPDFs(Incident task, List<GroupSignInPrintRequest> groups, int OpsPeriod, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();



            for (int gr = 0; gr < groups.Count; gr++)
            {
                for (int x = 1; x <= groups[gr].PrintCount; x++)
                {
                    allPDFs.AddRange(createSinglePageBlankSignInSheetAsBytes(task, groups[gr], x, groups[gr].PrintCount, OpsPeriod, flattenPDF));
                }
            }

            return allPDFs;
        }



        public string createSignInPDF(Incident task, int opsPeriod, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }


            }
            else
            {
                path = System.IO.Path.GetTempPath();
            }
            try
            {
                //List<Assignment> OpAssignments = CurrentTask.allAssignments.Where(o => o.OpPeriod == CurrentOpPeriod).OrderBy(o => o.AssignmentNumber).ToList();
                List<byte[]> allPDFs = getSignInSheetPDFs(task, opsPeriod, flattenPDF);


                string outputFileName = "ICS 211 - Task " + task.TaskNumber + " - Sign In Sheets " + opsPeriod.ToString();
                outputFileName = outputFileName.ReplaceInvalidPathChars();

                //path = System.IO.Path.Combine(path, outputFileName);
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

                /*
                bool successful = MergePDFs(pdfFileNames, path);
                */

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(path, fullFile);
                    //if (automaticallyOpen) { System.Diagnostics.Process.Start(path); }

                }
                catch (Exception)
                {
                    //LgMessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.");
                }


                //LgMessageBox.Show("PDF Generated Successfully....!!!");


            }
            catch (IOException ex)
            {
                //LgMessageBox.Show("It appears a previous version of the PDF is still open.  Please close it before trying to generate a new copy.\r\n\r\nDetailed error message:" + ex.ToString());
            }
            catch (System.UnauthorizedAccessException ex)
            {
                /*
                LgMessageBox.Show("A program on your system, typically a virus scanner, is prevening files from being saved to " + path + ". Please select a different folder to save to.");
                saveAsPromptShown = true;
                DialogResult dr = fbdSaveLocation.ShowDialog();
                saveAsPromptShown = false;
                if (dr == DialogResult.OK)
                {
                    path = fbdSaveLocation.SelectedPath;
                    if (FileAccessClasses.checkWriteAccess(path))
                    {
                        //LgMessageBox.Show("Thank you, you have selected " + path + " please try to save again.");
                        CurrentTask.DocumentPath = path;
                        createSignInPDF(opsPeriod, automaticallyOpen);
                    }
                }*/
            }
            return path;
        }

        public string createBlankSignInPDF(Incident task, List<GroupSignInPrintRequest> groups, int opsPeriod, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }


            }
            else
            {
                path = System.IO.Path.GetTempPath();
            }
            try
            {
                //List<Assignment> OpAssignments = CurrentTask.allAssignments.Where(o => o.OpPeriod == CurrentOpPeriod).OrderBy(o => o.AssignmentNumber).ToList();
                List<byte[]> allPDFs = getBlankSignInSheetPDFs(task, groups, opsPeriod, flattenPDF);


                string outputFileName = "ICS 211 - Task " + task.TaskNumber + " - Blank Sign In Sheets " + opsPeriod.ToString();
                outputFileName = outputFileName.ReplaceInvalidPathChars();

                //path = System.IO.Path.Combine(path, outputFileName);
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

                /*
                bool successful = MergePDFs(pdfFileNames, path);
                */

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(path, fullFile);
                    //if (automaticallyOpen) { System.Diagnostics.Process.Start(path); }

                }
                catch (Exception)
                {
                    //LgMessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.");
                }


                //LgMessageBox.Show("PDF Generated Successfully....!!!");


            }
            catch (IOException ex)
            {
                // LgMessageBox.Show("It appears a previous version of the PDF is still open.  Please close it before trying to generate a new copy.\r\n\r\nDetailed error message:" + ex.ToString());
            }
            catch (System.UnauthorizedAccessException ex)
            {
                /*
                LgMessageBox.Show("A program on your system, typically a virus scanner, is prevening files from being saved to " + path + ". Please select a different folder to save to.");
                saveAsPromptShown = true;
                DialogResult dr = fbdSaveLocation.ShowDialog();
                saveAsPromptShown = false;
                if (dr == DialogResult.OK)
                {
                    path = fbdSaveLocation.SelectedPath;
                    if (FileAccessClasses.checkWriteAccess(path))
                    {
                        //LgMessageBox.Show("Thank you, you have selected " + path + " please try to save again.");
                        CurrentTask.DocumentPath = path;
                        createSignInPDF(opsPeriod, automaticallyOpen);
                    }
                }*/
            }
            return path;
        }

        #endregion

        #region Timeline

        public List<byte[]> exportTimelineToPDF(Incident task)
        {
            List<byte[]> allPDFs = new List<byte[]>();
            string path = createTimelinePDF(task, true, true, false, true);
            using (FileStream stream = File.OpenRead(path))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }
            return allPDFs;
        }
        public string createTimelinePDF(Incident task, bool IncludeSAR, bool IncludeSubject, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;
            if (task != null && task.taskTimeline != null)
            {
                path = FileAccessClasses.getWritablePath(task);
                if (!tempFileName)
                {



                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "Task " + task.TaskNumber + " Timeline"; 
                    outputFileName = outputFileName.ReplaceInvalidPathChars();

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


                        document.AddTitle("Task Number " + task.TaskNumber + " - " + task.TaskName + " Timeline");

                        // Open the document to enable you to write to the document

                        document.Open();
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        // Add a simple and wellknown phrase to the document in a flow layout manner
                        //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                        string title = "Timeline for Task Number " + task.TaskNumber;
                        if (IncludeSAR && !IncludeSubject)
                        {
                            title = "Timeline for Task Number " + task.TaskNumber + " SAR Events Only";
                        }
                        else if (IncludeSubject && !IncludeSAR)
                        {
                            title = "Timeline for Task Number " + task.TaskNumber + " Subject Events Only";
                        }


                        Anchor briefingTarget = new Anchor(title, titlefont);
                        briefingTarget.Name = "Timeline";
                        Paragraph tp = new Paragraph();
                        tp.Add(briefingTarget);
                        tp.Font = titlefont;


                        document.Add(tp);

                        List<TimelineEvent> eventsIncluded = task.taskTimeline.AllTimelineEvents.Where(o => (IncludeSAR && o.SAREvent) || (IncludeSubject && o.SubjectEvent)).ToList();
                        DateTime earliestDate = eventsIncluded.Min(o => o.EventDateTime);
                        DateTime latestDate = eventsIncluded.Max(o => o.EventDateTime);
                        TimeSpan timespan = latestDate - earliestDate;
                        double totalDays = timespan.TotalDays;
                        totalDays = Math.Ceiling(totalDays);
                        for (int x = 0; x <= totalDays; x++)
                        {
                            DateTime date = earliestDate.AddDays(x);

                            if (eventsIncluded.Any(o => o.EventDateTime.Year == date.Year && o.EventDateTime.Month == date.Month && o.EventDateTime.Day == date.Day))
                            {
                                document.Add(new Paragraph(date.ToString(DateFormat, Globals.cultureInfo), subsectionfont));

                                foreach (TimelineEvent ev in eventsIncluded.Where(o => o.EventDateTime.Year == date.Year && o.EventDateTime.Month == date.Month && o.EventDateTime.Day == date.Day))
                                {
                                    Paragraph p1 = new Paragraph(ev.EventDateTime.ToString("HH:mm", Globals.cultureInfo) + " -- " + ev.EventName + " - " + ev.EventText, normalfont);
                                    p1.IndentationLeft = 10;
                                    document.Add(p1);
                                }
                            }
                            else if (x < totalDays)
                            {
                                document.Add(new Paragraph(date.ToString(DateFormat, Globals.cultureInfo), subsectionfont));
                                Paragraph p1 = new Paragraph("No events for this day", normalfont);
                                p1.IndentationLeft = 10;
                                document.Add(p1);
                            }
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
                }
            }
            return path;
        }
        #endregion

        #region Title Page

        public PDFCreationResults GetCustomTitlePageBytes(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool flattenPDF = false)
        {
            PDFCreationResults results = CreateCustomTitlePagePDF(incident, options, OperationalPeriodNumber, true, flattenPDF);
            if (!string.IsNullOrEmpty(results.path))
            {
                using (FileStream stream = File.OpenRead(results.path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    results.bytes = new List<byte[]>();
                    results.bytes.Add(fileBytes);
                }
                return results;
            }
            return null;
        }

        public PDFCreationResults CreateCustomTitlePagePDF(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool useTempPath, bool flattenPDF = false)
        {
            PDFCreationResults results = new PDFCreationResults();
            results.path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                results.path = FileAccessClasses.getWritablePath(incident);
            }

            string outputFileName = incident.IncidentNameAndNumberForPath + " - Title Page - OP " + OperationalPeriodNumber.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            results.path = FileAccessClasses.getUniqueFileName(outputFileName, results.path);


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS-000 Title Page.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(results.path, FileMode.Create));


                    if (OperationalPeriodNumber > 0)
                    {
                        OperationalPeriod currentPeriod = incident.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == OperationalPeriodNumber);
                        if (currentPeriod != null)
                        {
                            stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                            stamper.AcroFields.SetField("OpPeriodOrFullIncidentTitle", "OPERATIONAL PERIOD");
                        }
                    }
                    else
                    {
                        DateTime incidentStart = incident.GetIncidentStart();
                        DateTime incidentEnd = incident.GetIncidentEnd();
                        if (incidentEnd > DateTime.Now) { incidentEnd = DateTime.Now; }

                        stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", incidentStart));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", incidentStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", incidentEnd));
                        stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", incidentEnd));
                        stamper.AcroFields.SetField("OpPeriodOrFullIncidentTitle", "INCIDENT TO DATE");
                    }


                    stamper.AcroFields.SetField("INCIDENT NAMERow1", incident.TaskName);
                    stamper.AcroFields.SetField("Incident NumberRow1", incident.TaskNumber);




                    /******************************
                     * Believe it or not, this whole next big section is just for laying out the four optional elements of the title page
                     ******************************/

                    //Bounds of the big open area
                    Point topLeft = new Point(38,680);
                    Point topRight = new Point(574, 680);
                    Point lowerLeft = new Point(38, 188);
                    Point lowerRight = new Point(574, 188);

                    int fullHeight = topLeft.Y - lowerLeft.Y;
                    int fullWidth = topRight.X - topLeft.X;
                    
                    Point bottomThirdLeft = new Point(38, Convert.ToInt32(Convert.ToDecimal(fullHeight) * (2m / 3m)));
                    Point bottomThirdRight = new Point(lowerRight.X, bottomThirdLeft.Y);
                    Point lowerCentre = new Point((lowerRight.X - lowerLeft.X) / 2 + lowerLeft.X, lowerLeft.Y);
                    Point lowerCentreRight = new Point((lowerRight.X - lowerCentre.X) / 2 + lowerCentre.X, lowerLeft.Y);

                    Rectangle mediabox = rdr.GetPageSize(1);


                    int padding = 10;

                    //fill the big open area
                    if (options.IncludeTitleImage)
                    {
                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(options.TitleImage.getImageFromBytes(), System.Drawing.Imaging.ImageFormat.Jpeg);

                        pic.ScaleToFit(fullWidth, topLeft.Y - bottomThirdLeft.Y);
                        float x = (mediabox.Width / 2) - (pic.ScaledWidth / 2);
                        float y = bottomThirdLeft.Y +  ((topLeft.Y - bottomThirdLeft.Y - pic.ScaledHeight) / 2);
                        pic.SetAbsolutePosition(x, y);
                        stamper.GetOverContent(1).AddImage(pic);
                    }


                    if (options.IncludeMessage)
                    {
                        if (!options.IncludeTitleImage) { stamper.AddFormFieldToExistingPDF("MultiLineTextField", bottomThirdLeft.X + padding, bottomThirdLeft.Y + padding, topRight.X - padding, topRight.Y - padding, "Message", options.Message, true); }
                        else
                        {

                            if (options.NumberOfItemsIncluded == 2) { stamper.AddFormFieldToExistingPDF("MultiLineTextField", lowerLeft.X + padding, lowerLeft.Y + padding, lowerRight.X - padding, bottomThirdLeft.Y - padding, "Message", options.Message, true); }
                            else { stamper.AddFormFieldToExistingPDF("MultiLineTextField", lowerLeft.X + padding, lowerLeft.Y + padding, lowerCentre.X - padding, bottomThirdLeft.Y - padding, "Message", options.Message, true); }
                        }

                    }

                    if (options.IncludeOrganizationLogo)
                    {


                        Point logoBottomRight = new Point(0, 0);
                        Point logoBottomLeft = new Point(0, 0);
                        Point logoTopRight = new Point(0, 0);

                        if (options.NumberOfItemsIncluded == 1)
                        {
                            //just the logo, use the whole top 2/3rds
                            logoBottomRight = bottomThirdRight;
                            logoBottomLeft = bottomThirdLeft;
                            logoTopRight = topRight;
                        }
                        else if (options.NumberOfItemsIncluded == 2)
                        {
                            if (options.IncludeQRCode)
                            {
                                logoBottomRight = bottomThirdRight;
                                logoBottomLeft = bottomThirdLeft;
                                logoTopRight = topRight;
                            }
                            else
                            {
                                logoBottomRight = lowerRight;
                                logoBottomLeft = lowerLeft;
                                logoTopRight = bottomThirdRight;
                            }
                        }
                        else if (options.NumberOfItemsIncluded == 3)
                        {
                            if (options.IncludeMessage && options.IncludeTitleImage)
                            {                           
                                logoBottomRight = lowerRight;
                                logoBottomLeft = lowerCentre;
                                logoTopRight = bottomThirdRight;
                            }
                            else
                            {                           
                                logoBottomRight = lowerCentre;
                                logoBottomLeft =lowerLeft;
                                logoTopRight = new Point(lowerCentre.X, bottomThirdLeft.Y);
                            }
                        }
                        else if(options.NumberOfItemsIncluded == 4)
                        {
                            logoBottomRight = lowerCentreRight;
                            logoBottomLeft = lowerCentre;
                            logoTopRight = new Point(lowerCentre.X, bottomThirdRight.Y);
                        }


                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(options.LogoImage.getImageFromBytes(), System.Drawing.Imaging.ImageFormat.Jpeg);
                        
                        pic.ScaleToFit(logoBottomRight.X - logoBottomLeft.X - padding * 2, logoTopRight.Y - logoBottomRight.Y - padding * 2);
                        //pic.SetAbsolutePosition(qrBottomLeft.X + (widthOfQRSpace / 2) - (QR.Width / 2) + padding , qrBottomLeft.Y + padding + textBoxHeight); 
                        int widthOfLogoSpace = logoBottomRight.X - logoBottomLeft.X - (padding * 2);
                        int heightOfLogoSpace = logoTopRight.Y - logoBottomRight.Y - (padding * 2);
                        float x = logoBottomLeft.X + (widthOfLogoSpace / 2) - (pic.ScaledWidth / 2) + padding;
                        float y = logoBottomLeft.Y + (heightOfLogoSpace / 2) - (pic.ScaledHeight / 2) + padding;
                        pic.SetAbsolutePosition(x, y);
                        stamper.GetOverContent(1).AddImage(pic);
                    }

                    if (options.IncludeQRCode)
                    {
                        Point qrBottomRight =new Point(0,0);
                        Point qrBottomLeft =new Point(0, 0);
                        Point qrTopRight = new Point(0, 0);

                        int textBoxHeight = 30;
                        if (string.IsNullOrEmpty(options.QRInstructions)) { textBoxHeight = 0; }

                        if (options.NumberOfItemsIncluded == 3)
                        {
                            //QR can take the bottom half
                            qrBottomRight = lowerRight;
                            qrBottomLeft = lowerCentre;
                            qrTopRight = bottomThirdRight;

                        }
                        else if (options.NumberOfItemsIncluded == 1 || options.NumberOfItemsIncluded == 2)
                        {
                            //qr can take the whole bottom third
                            qrBottomRight = lowerRight;
                            qrBottomLeft = lowerLeft;
                            qrTopRight = bottomThirdRight;
                        }
                        else
                        {
                            //qr is tucked into the lower right corner
                             qrBottomRight = lowerRight;
                             qrBottomLeft = lowerCentreRight;
                             qrTopRight = bottomThirdRight;
                        }

                        int QRSize = Math.Min(qrBottomRight.X - qrBottomLeft.X - (padding * 2), qrTopRight.Y - qrBottomRight.Y - (padding * 2) - textBoxHeight);
                        Bitmap QR = options.QRText.GetQRImage(QRSize);
                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(QR, System.Drawing.Imaging.ImageFormat.Jpeg);
                        int widthOfQRSpace = qrBottomRight.X - qrBottomLeft.X - (padding * 2);
                        pic.SetAbsolutePosition(qrBottomLeft.X + (widthOfQRSpace / 2) - (QR.Width / 2) + padding , qrBottomLeft.Y + padding + textBoxHeight); 
                        stamper.GetOverContent(1).AddImage(pic);

                        if (!string.IsNullOrEmpty(options.QRInstructions))
                        {
                            stamper.AddFormFieldToExistingPDF("MultiLineTextField", qrBottomLeft.X + padding, qrBottomLeft.Y + padding, qrBottomRight.X - padding, qrBottomRight.Y + padding + textBoxHeight, "QRInstructions", options.QRInstructions, true);
                        }




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
                        stamper.AcroFields.RenameField(s, s + "-titlepage");
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;

                        //re-add the signature field if we flattened it away
                        int[] instancesOfInterest = { 0, 1, 2 };
                        stamper = stamper.AddPDFField(fileToUse, "Signature", "Signature", 38, 222, "ReportSignature", instancesOfInterest);
                        stamper = stamper.AddPDFField(fileToUse, "Print Name", "TextField", 38, 200, "PrintName", instancesOfInterest);



                    }

                    results.TotalPages = 1;
                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception ex)
            {
                results.errors.Add(ex);
                results.path = string.Empty;
            }
            return results;
        }






        public List<byte[]> createFreeformOpPeriodContentsList(Incident task, List<string> items, int OpPeriod)
        {
            List<byte[]> allPDFs = new List<byte[]>();
            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

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

                if (OpPeriod > 0)
                {
                    document.AddTitle("Incident:  " + task.IncidentIdentifier + " Op Period " + OpPeriod.ToString(Globals.cultureInfo));
                }
                else { document.AddTitle("Incident: " + task.IncidentIdentifier); }
                // Open the document to enable you to write to the document

                document.Open();
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                // Add a simple and wellknown phrase to the document in a flow layout manner
                //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                Anchor briefingTarget = new Anchor("Incident: " + task.IncidentIdentifier , titlefont);
                briefingTarget.Name = "Index";
                Paragraph tp = new Paragraph();
                tp.Add(briefingTarget);
                tp.Font = titlefont;

                document.Add(tp);

                if (OpPeriod > 0)
                {
                    document.Add(new Paragraph("Operational Period #" + OpPeriod.ToString(Globals.cultureInfo), subsectionfont));
                }
                else
                {
                    document.Add(new Paragraph("As of " + DateTime.Now.ToString(DateFormat), subsectionfont));
                }
                document.Add(new Paragraph(" "));

                string logoPath = "Resources/ics-canada-logo.png";
                

                //Picture
                if (!string.IsNullOrEmpty(logoPath))
                {
                    //iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    try
                    {
                        if (File.Exists(logoPath))
                        {
                            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(logoPath);

                            tif.ScaleToFit(200, 200);
                            float x = ((200 - tif.ScaledWidth) / 2) + 350;
                            tif.SetAbsolutePosition(x, 450);

                            document.Add(tif);
                        }
                    }
                    catch (Exception)
                    {
                        //Log error;

                    }
                }
                document.Add(new Paragraph(" "));




                document.Add(new Paragraph("Contents:", sectionfont));

                foreach (string s in items)
                {
                    document.Add(new Paragraph(s, subsectionfont));
                }

                /*
                Anchor click = new Anchor("Click to go to Target");
                click.Reference = "#Briefing";
                Paragraph pe = new Paragraph();
                pe.Add(click);
                document.Add(pe);*/
                // Close the document
                document.Close();
                // Close the writer instance
                writer.Close();

                // Always close open filehandles explicity

            }

            using (FileStream stream = File.OpenRead(path))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }


            return allPDFs;
        }

        public List<byte[]> exportOpTitlePageToPDF(Incident task, int OpPeriod, string contentsText,string titleImageBytes, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createOpTitlePagePDF(task, OpPeriod, contentsText, titleImageBytes, true, flattenPDF);
            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }

        public string createOpTitlePagePDF(Incident task, int OpPeriod, string contentsText, string titleImageBytes, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = task.IncidentNameAndNumberForPath + " - Title Page - OP " + OpPeriod.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath ("ICS-000 Title Page.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));


                    if (OpPeriod > 0)
                    {
                        OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpPeriod).First();
                        stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                        stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                        stamper.AcroFields.SetField("OpPeriodOrFullIncidentTitle", "OPERATIONAL PERIOD");
                        if (!string.IsNullOrEmpty(currentPeriod.CriticalMessage)) { stamper.AcroFields.SetField("CriticalMessage", "Message for this Operational Period: " + Environment.NewLine + currentPeriod.CriticalMessage); }
                    }
                    else
                    {
                        DateTime incidentStart = task.GetIncidentStart();
                        DateTime incidentEnd = task.GetIncidentEnd();
                        if(incidentEnd > DateTime.Now) { incidentEnd = DateTime.Now; }

                        stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", incidentStart));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", incidentStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", incidentEnd));
                        stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", incidentEnd));
                        stamper.AcroFields.SetField("OpPeriodOrFullIncidentTitle", "INCIDENT TO DATE");
                    }


                    stamper.AcroFields.SetField("INCIDENT NAMERow1", task.TaskName);
                    stamper.AcroFields.SetField("Incident NumberRow1", task.TaskNumber);

                    



                    //stamper.AcroFields.SetField("ContentsList", contentsText);

                    if (!string.IsNullOrEmpty(titleImageBytes))
                    {
                        iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(titleImageBytes.getImageFromBytes(), System.Drawing.Imaging.ImageFormat.Jpeg);
                        Rectangle mediabox = rdr.GetPageSize(1);

                        pic.ScaleToFit(536, 340);
                        float x = (mediabox.Width / 2) - (pic.ScaledWidth / 2);
                        float y = 325;
                        pic.SetAbsolutePosition(x, y);

                        stamper.GetOverContent(1).AddImage(pic);
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
                        stamper.AcroFields.RenameField(s, s + "-titlepage");
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;

                        //re-add the signature field if we flattened it away
                        int[] instancesOfInterest = { 0, 1,2 };
                        stamper = stamper.AddPDFField( fileToUse, "Signature", "Signature", 38, 222, "ReportSignature",  instancesOfInterest);
                        stamper = stamper.AddPDFField(fileToUse, "Print Name", "TextField", 38, 200, "PrintName", instancesOfInterest);

                     

                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }

        #endregion

        #region Radio Log (SAR)
        private int getRadioLogPageCount(Incident task, int OpPeriodToExport)
        {
            List<CommsLogEntry> entries = task.allCommsLogEntries.Where(o => o.OpPeriod == OpPeriodToExport).OrderBy(o => o.LogDate).ToList();

            int totalPages = Convert.ToInt32(Math.Floor(Convert.ToDecimal(entries.Count) / 26m));
            if (entries.Count % 26 > 0) { totalPages += 1; }
            if (totalPages == 0) { totalPages = 1; }
            return totalPages;
        }

        public List<byte[]> exportRadioLogToPDF(Incident task, int OpPeriodToExport, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<CommsLogEntry> entries = task.allCommsLogEntries.Where(o => o.OpPeriod == OpPeriodToExport).OrderBy(o => o.LogDate).ToList();

            int totalPages = getRadioLogPageCount(task, OpPeriodToExport);

            List<string> pdfFileNames = new List<string>();
            for (int x = 1; x <= totalPages; x++)
            {
                List<CommsLogEntry> nextEntries = entries.Skip(26 * (x - 1)).Take(26).ToList();

                allPDFs.AddRange(createSinglePageRadioLogAsBytes(task, nextEntries, x, totalPages, OpPeriodToExport, flattenPDF));
            }
            return allPDFs;

        }

        private string createSinglePageRadioLog(Incident task, List<CommsLogEntry> entries, int pageNumber, int totalPages, int OpsPeriod)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 309 - Radio Log.pdf";
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            PdfReader rdr = new PdfReader(fileToUse);
            PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));


            //Top Section
            stamper.AcroFields.SetField("TASK", task.TaskNumber);
            stamper.AcroFields.SetField("TASK NAME", task.TaskName);

            stamper.AcroFields.SetField("FOR OP PERIOD", OpsPeriod.ToString());
            stamper.AcroFields.SetField("STATION CALLSIGN", task.ICPCallSign);

            if (entries.Count > 0)
            {
                stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:HH:mm}", entries[0].LogDate));
                stamper.AcroFields.SetField("PeriodTo", string.Format("{0:HH:mm}", entries[entries.Count - 1].LogDate));
            }


            for (int x = 0; x < entries.Count; x++)
            {
                stamper.AcroFields.SetField("TIMERow" + (x + 1).ToString(), string.Format("{0:HH:mm}", entries[x].LogDate));
                stamper.AcroFields.SetField("STN CALLEDRow" + (x + 1).ToString(), entries[x].ToName);
                stamper.AcroFields.SetField("THIS ISRow" + (x + 1).ToString(), entries[x].FromName);
                stamper.AcroFields.SetField("SUBJECTRow" + (x + 1).ToString(), entries[x].Message);

            }

            stamper.AcroFields.SetField("Text1", pageNumber.ToString());
            stamper.AcroFields.SetField("Text2", totalPages.ToString());

            //Rename all fields
            AcroFields af = stamper.AcroFields;

            List<string> fieldNames = new List<string>();
            foreach (var field in af.Fields)
            {
                fieldNames.Add(field.Key);
            }
            foreach (string s in fieldNames)
            {
                stamper.AcroFields.RenameField(s, s + "-309-" + pageNumber.ToString());
            }

            stamper.Close();//Close a PDFStamper Object
            rdr.Close();    //Close a PDFReader Object

            return path;
        }


        public string createRadioLogPDF(Incident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {

                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
            }
            else { path = System.IO.Path.GetTempPath(); }

            List<byte[]> allPDFs = exportRadioLogToPDF(task, opsPeriod);

            string outputFileName = "ICS 309 - Task " + task.TaskNumber + " - Radio Log Op " + opsPeriod.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(path, fullFile);

            }
            catch (Exception)
            {
            }

            return path;
        }

        private List<byte[]> createSinglePageRadioLogAsBytes(Incident task, List<CommsLogEntry> entries, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();
            string fileToUse = "ICSForms/ICS 309 - Radio Log.pdf";
            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {
                    //Top Section
                    stamper.AcroFields.SetField("TASK", task.TaskNumber);
                    stamper.AcroFields.SetField("TASK NAME", task.TaskName);

                    stamper.AcroFields.SetField("FOR OP PERIOD", OpsPeriod.ToString());
                    stamper.AcroFields.SetField("STATION CALLSIGN", task.ICPCallSign);

                    if (entries.Count > 0)
                    {
                        stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:HH:mm}", entries[0].LogDate));
                        stamper.AcroFields.SetField("PeriodTo", string.Format("{0:HH:mm}", entries[entries.Count - 1].LogDate));
                    }


                    for (int x = 0; x < entries.Count; x++)
                    {
                        stamper.AcroFields.SetField("TIMERow" + (x + 1).ToString(), string.Format("{0:HH:mm}", entries[x].LogDate));
                        stamper.AcroFields.SetField("STN CALLEDRow" + (x + 1).ToString(), entries[x].ToName);
                        stamper.AcroFields.SetField("THIS ISRow" + (x + 1).ToString(), entries[x].FromName);
                        stamper.AcroFields.SetField("SUBJECTRow" + (x + 1).ToString(), entries[x].Message);

                    }

                    stamper.AcroFields.SetField("Text1", pageNumber.ToString());
                    stamper.AcroFields.SetField("Text2", totalPages.ToString());

                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-309-" + pageNumber.ToString());
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
        #endregion

        #region Note

        public List<byte[]> exportNotesToPDF(Incident task, int CurrentOpPeriod)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            foreach (Note note in task.allNotes.Where(o => o.Active && o.OpPeriod == CurrentOpPeriod))
            {
                string path = createNotePDF(task, note, false, true);
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }



        public string createNotePDF(Incident task, Note note, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;
            if (task != null && task.taskTimeline != null)
            {
                path = FileAccessClasses.getWritablePath(task);
                if (!tempFileName)
                {



                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = note.NoteTitle;
                    outputFileName = outputFileName.ReplaceInvalidPathChars();

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


                        document.AddTitle("Task Number " + task.TaskNumber + " - " + note.NoteTitle);

                        // Open the document to enable you to write to the document

                        document.Open();
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.GRAY);
                        iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                        // Add a simple and wellknown phrase to the document in a flow layout manner
                        //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                        string title = note.NoteTitle;
                        Anchor briefingTarget = new Anchor(title, titlefont);
                        briefingTarget.Name = "Notetitle";
                        Paragraph tp = new Paragraph();
                        tp.Add(briefingTarget);
                        tp.Font = titlefont;


                        document.Add(tp);



                        document.Add(new Paragraph("Created: " + note.DateCreated.ToString(DateFormat + " HH:mm", Globals.cultureInfo), subsectionfont));
                        document.Add(new Paragraph("Updated: " + note.DateUpdated.ToString(DateFormat + " HH:mm", Globals.cultureInfo), subsectionfont));

                        document.Add(new Paragraph(" ", normalfont));
                        document.Add(new Paragraph(note.NoteText, normalfont));

                        // Close the document
                        document.Close();
                        // Close the writer instance
                        writer.Close();

                        // Always close open filehandles explicity

                    }
                }
                catch (Exception)
                {
                }
            }
            return path;
        }
        #endregion

        #region Air Ops Summary

        public string CreateAirOpsSummaryPDF(Incident task, int OpPeriod, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }



            string outputFileName = "ICS 220 - " + task.IncidentNameAndNumberForPath + " - OP " + OpPeriod.ToString() + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);




            List<byte[]> allPDFs = exportAirOpsSummaryToPDF(task, OpPeriod,  flattenPDF);

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


        public List<byte[]> exportAirOpsSummaryToPDF(Incident incident, int OpPeriodToExport, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            AirOperationsSummary summary = incident.allAirOperationsSummaries.FirstOrDefault(o=>o.OpPeriod == OpPeriodToExport);
            List<Aircraft> aircraftList = incident.GetActiveAircraft(OpPeriodToExport);


            int totalPages = getAirOpsSummaryPageCount(incident, summary);


            List<string> pdfFileNames = new List<string>();


            List<CommsPlanItem> comms = incident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == summary.OpPeriod).ActiveAirCommsItems;
            List<ICSRole> roles = new List<ICSRole>();
            ICSRole airOpsDirector = incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == summary.OpPeriod).ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.AirOpsDirectorGenericID);
            if (airOpsDirector != null)
            {
                roles.Add(airOpsDirector);
                roles.AddRange(incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == summary.OpPeriod).GetChildRoles(airOpsDirector.ID, true));
            }


            for (int x = 0; x < totalPages; x++)
            {
                List<Aircraft> pageair = new List<Aircraft>();
                List<CommsPlanItem> pagecomms = new List<CommsPlanItem>();
                List<ICSRole> pageroles = new List<ICSRole>();

                pageair = aircraftList.Skip(15 * (x)).Take(15).ToList();
                pagecomms = comms.Skip(10 * (x )).Take(10).ToList();
                pageroles = roles.Skip(10 * (x)).Take(10).ToList();


                allPDFs.AddRange(buildSingleAirOpsSummaryPage(incident, OpPeriodToExport, pageair, pageroles, pagecomms, x + 1, totalPages, flattenPDF));
            }
            return allPDFs;

        }

        private int getAirOpsSummaryPageCount(Incident incident, AirOperationsSummary sum)
        {
            int AirPP = 15;
            int RolePP = 10;
            int CommsPP = 10;
            List<Aircraft> aircraftList = incident.GetActiveAircraft(sum.OpPeriod);

            List<CommsPlanItem> comms = incident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == sum.OpPeriod).ActiveAirCommsItems;
            List<ICSRole> roles = new List<ICSRole>();
            roles.Add(incident.allOrgCharts.FirstOrDefault(o=>o.OpPeriod == sum.OpPeriod).ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.AirOpsDirectorGenericID));
            roles.AddRange(incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == sum.OpPeriod).GetChildRoles(Globals.AirOpsDirectorGenericID, true));


            int totalPages = 0;
            if(aircraftList.Count < AirPP && comms.Count < CommsPP && roles.Count < RolePP)
            {
                return 1;
            }
            else
            {
                int pagesAir = Convert.ToInt32(Math.Floor(Convert.ToDecimal(aircraftList.Count) / 15m));
                if ((aircraftList.Count) % 15 > 0) { pagesAir += 1; }
                totalPages = pagesAir;

                int pagesComms = Convert.ToInt32(Math.Floor(Convert.ToDecimal(comms.Count) / 10m));
                if ((comms.Count) % 10 > 0) { pagesComms += 1; }
                totalPages = Math.Max(totalPages, pagesComms);

                int pagesRoles = Convert.ToInt32(Math.Floor(Convert.ToDecimal(roles.Count) / 10m));
                if ((roles.Count) % 10 > 0) { pagesRoles += 1; }
                totalPages = Math.Max(totalPages, pagesRoles);


            }


            if (totalPages == 0) { totalPages = 1; }
            return totalPages;
        }


        private List<byte[]> buildSingleAirOpsSummaryPage(Incident task, int OpsPeriod, List<Aircraft> aircraft, List<ICSRole> roles, List<CommsPlanItem> comms, int pageNumber, int pageCount, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempFileName();
            string fileToUse = PDFExtraTools.getPDFFilePath("ICS-220-WF Air Operations Summary.pdf");
            

            OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == OpsPeriod);
            AirOperationsSummary summary = task.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == OpsPeriod);
            if (summary.notam.UseRadius) { fileToUse = PDFExtraTools.getPDFFilePath("ICS-220-WF Air Operations Summary.pdf"); }
            else { fileToUse = PDFExtraTools.getPDFFilePath("ICS-220-WF Air Operations Summary Polygon.pdf"); }
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {
                    stamper.AcroFields.SetField("1 INCIDENT NAME OR NUMBERRow1", task.IncidentNameOrNumber);

                    stamper.AcroFields.SetField("Contact Name", summary.PreparedByResourceName);
                    stamper.AcroFields.SetField("Position", summary.PreparedByRoleName);

                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                    stamper.AcroFields.SetField("3 REMARKS safety notes hazards etcRow1", summary.Remarks);
                    List<Aircraft> MedvacAircraft = task.GetActiveAircraft(currentOp.PeriodMid).Where(o => o.IsMedivac).ToList();


                    stamper.AcroFields.SetField("4 MEDIVAC AIRCRAFTRow1", summary.MedivacTextBlock(MedvacAircraft));
                    stamper.AcroFields.SetField("Sunrise", string.Format("{0:HH:mm}", summary.Sunrise));
                    stamper.AcroFields.SetField("Sunset", string.Format("{0:HH:mm}", summary.Sunset));


                   
                    stamper.AcroFields.SetField("Altitude ASL", summary.notam.AltitudeASL.ToString());
                    stamper.AcroFields.SetField("Center Point", summary.notam.CenterPoint);

                    if (summary.notam.UseRadius)
                    {
                        stamper.AcroFields.SetField("Radius nm", summary.notam.RadiusNM.ToString());
                        if (summary.notam.RadiusCentre != null)
                        {
                            string[] parts = summary.notam.RadiusCentre.DegreesDecimalMinutesSep;
                            stamper.AcroFields.SetField("Latitude", parts[0].ToString());
                            stamper.AcroFields.SetField("Longitude", parts[1].ToString());
                        }
                    }
                    else
                    {
                        if (summary.notam.PolygonNW != null)
                        {
                            string[] parts = summary.notam.PolygonNW.DegreesDecimalMinutesSep;
                            stamper.AcroFields.SetField("Northwest", parts[0].ToString());
                            stamper.AcroFields.SetField("Northwest_2", parts[1].ToString());
                        }

                        if (summary.notam.PolygonNE != null)
                        {
                            string[] parts = summary.notam.PolygonNE.DegreesDecimalMinutesSep;
                            stamper.AcroFields.SetField("Northeast", parts[0].ToString());
                            stamper.AcroFields.SetField("Northeast_2", parts[1].ToString());
                        }

                        if (summary.notam.PolygonSW != null)
                        {
                            string[] parts = summary.notam.PolygonSW.DegreesDecimalMinutesSep;
                            stamper.AcroFields.SetField("Southwest", parts[0].ToString());
                            stamper.AcroFields.SetField("Southwest_2", parts[1].ToString());
                        }

                        if (summary.notam.PolygonSE != null)
                        {
                            string[] parts = summary.notam.PolygonSE.DegreesDecimalMinutesSep;
                            stamper.AcroFields.SetField("Southeast", parts[0].ToString());
                            stamper.AcroFields.SetField("Southeast_2", parts[1].ToString());
                        }
                    }
                   
                    /* TODO Replace this with code to fill the radius or polygon values
                   
                    */


                    stamper.AcroFields.SetField("9 PAGE", pageNumber.ToString());
                    stamper.AcroFields.SetField("OF", pageCount.ToString());

                    for (int x = 0; x < roles.Count && x < 10; x++)
                    {
                        if (roles[x] != null)
                        {
                            stamper.AcroFields.SetField("NameRow" + (x + 1), roles[x].IndividualName);
                            stamper.AcroFields.SetField("PositionRow" + (x + 1), roles[x].RoleName);
                            if (roles[x].IndividualID != Guid.Empty && task.IncidentPersonnel.Any(o => o.ID == roles[x].IndividualID))
                            {
                                Personnel p = task.IncidentPersonnel.First(o => o.ID == roles[x].IndividualID);
                                stamper.AcroFields.SetField("Phone Row" + (x + 1), p.CellphoneNumber);
                            }
                        } else
                        {
                            ;
                        }
                    }


                    for (int x = 0; x<aircraft.Count && x<15; x++)
                    {
                        stamper.AcroFields.SetField("RegRow" + (x + 1), aircraft[x].Registration);
                        stamper.AcroFields.SetField("MakeModelRow" + (x + 1), aircraft[x].MakeModel);
                        stamper.AcroFields.SetField("BaseRow" + (x + 1), aircraft[x].Base);
                        stamper.AcroFields.SetField("StartRow" + (x + 1), string.Format("{0:HH:mm}", aircraft[x].StartTime));
                        stamper.AcroFields.SetField("RemarksRow" + (x + 1), aircraft[x].Remarks);
                        stamper.AcroFields.SetField("PilotRow" + (x + 1), aircraft[x].Pilot);
                        stamper.AcroFields.SetField("Contact Row" + (x + 1), aircraft[x].ContactNumber);
                    }

                    for(int x= 0; x<comms.Count && x < 10; x++)
                    {
                        stamper.AcroFields.SetField("FrequencyRow" + (x + 1), comms[x].ChannelID);
                        stamper.AcroFields.SetField("RxRow" + (x + 1), comms[x].RxFrequency);
                        stamper.AcroFields.SetField("TxRow" + (x + 1), comms[x].TxFrequency);
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
                        stamper.AcroFields.RenameField(s, s + "-220-" + pageNumber.ToString());
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
        #endregion

        #region Logistics Summary

        public string createLogisticsSummaryPDF(Incident task, int OpPeriod, ICSRole ParentRole, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }



            string outputFileName = "LOGISTICS OVERVIEW - " + task.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString() + " " + ParentRole.RoleName + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);




            List<byte[]> allPDFs = exportLogisticsSummaryToPDF(task, OpPeriod, ParentRole, flattenPDF);

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

        public List<byte[]> exportLogisticsSummaryToPDF(Incident incident, int OpPeriodToExport, ICSRole ParentRole, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriodToExport);
            OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriodToExport);
            List<CheckInRecordWithResource> allCheckInRecords = new List<CheckInRecordWithResource>();
            if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { allCheckInRecords = incident.GetCheckInWithResources(OpPeriodToExport, ParentRole); }
            else { allCheckInRecords = incident.GetCheckInWithResources(OpPeriodToExport); }

            List<KindTypeWithCounts> typesWithCount = getTypesWithCounts(allCheckInRecords, currentPeriod.PeriodEnd);

            int totalPages = 1;
            int rowsOnPage1 = 28;
            int rowsOnPage2Plus = 38;

            if (typesWithCount.Count > rowsOnPage1)
            {

                totalPages += Convert.ToInt32(Math.Floor(Convert.ToDecimal(typesWithCount.Count - rowsOnPage1) / Convert.ToDecimal(rowsOnPage2Plus)));
                if ((typesWithCount.Count - rowsOnPage1) % rowsOnPage2Plus > 0) { totalPages += 1; }



                if (totalPages == 0) { totalPages = 1; }
            }

            List<string> pdfFileNames = new List<string>();
            allPDFs.AddRange(createLogisticsSummaryPage1PDF(incident, OpPeriodToExport, ParentRole, allCheckInRecords, 1, totalPages, flattenPDF));
            for(int x = 1; x<totalPages; x++)
            {
                List<KindTypeWithCounts> pageCounts = typesWithCount.Skip(rowsOnPage1).Skip(rowsOnPage2Plus * (x-1)).Take(rowsOnPage2Plus).ToList();
                allPDFs.AddRange(createLogisticsSummarySubsequentPDF(incident, OpPeriodToExport, ParentRole, pageCounts, (x+1), totalPages, flattenPDF));

            }

            /*
            List<PositionLogEntry> extraPageEntries = entries.Skip(19).ToList();
            for (int x = 1; x < totalPages; x++)
            {
                List<PositionLogEntry> nextEntries = extraPageEntries.Skip(31 * (x - 1)).Take(37).ToList();

                allPDFs.AddRange(buildPDFPage(nextEntries, task, OpPeriodToExport, role, x + 1, totalPages, flattenPDF));
            }
            */


            return allPDFs;
        }


        private class KindTypeWithCounts
        {
            public string KindName { get; set; }
            public string TypeName { get; set; }
            public int[] Counts { get; set; } = new int[2];
            public KindTypeWithCounts() { }
            public KindTypeWithCounts(string knd, string ty) { KindName = knd; TypeName = ty; }
        }

        private List<KindTypeWithCounts> getTypesWithCounts(List<CheckInRecordWithResource> list, DateTime opEndDate)
        {
            List<KindTypeWithCounts> counts = new List<KindTypeWithCounts>();

            foreach (CheckInRecordWithResource item in list)
            {
                if (!counts.Any(o => o.KindName != null && o.KindName.Equals(item.Resource.Kind) && (o.TypeName == null || o.TypeName.Equals(item.Resource.Type))))
                {
                    if (string.IsNullOrEmpty(item.Resource.Type) && string.IsNullOrEmpty(item.Resource.Kind) && !counts.Any(o => o.KindName.Equals("No Kind Given") && o.TypeName.Equals("No Type Given")))
                    {

                        counts.Add(new KindTypeWithCounts("No Kind Given", "No Type Given"));

                    }
                    else if (item.Resource != null && string.IsNullOrEmpty(item.Resource.Kind) && !string.IsNullOrEmpty(item.Resource.Type) && !counts.Any(o => o.KindName.Equals("No Kind Given") && o.TypeName.Equals(item.Resource.Type)))
                    {
                        counts.Add(new KindTypeWithCounts("No Kind Given", item.Resource.Type));

                    }
                    else if (string.IsNullOrEmpty(item.Resource.Type) && !string.IsNullOrEmpty(item.Resource.Kind) && !counts.Any(o => o.KindName.Equals(item.Resource.Kind) && o.TypeName.Equals("No Type Given")))
                    {
                        counts.Add(new KindTypeWithCounts(item.Resource.Kind, "No Type Given"));
                    }
                    else
                    {
                        counts.Add(new KindTypeWithCounts(item.Resource.Kind, item.Resource.Type));
                    }


                }

                KindTypeWithCounts thisone = null;
                if (!string.IsNullOrEmpty(item.Resource.Kind) && !string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => !string.IsNullOrEmpty(o.KindName) && o.KindName.Equals(item.Resource.Kind) && o.TypeName.Equals(item.Resource.Type)); }
                else if (string.IsNullOrEmpty(item.Resource.Kind) && string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => o.KindName.EqualsWithNull("No Kind Given") && o.TypeName.EqualsWithNull("No Type Given")); }
                else if (string.IsNullOrEmpty(item.Resource.Kind)) { thisone = counts.First(o => o.KindName.EqualsWithNull("No Kind Given") && o.TypeName.EqualsWithNull(item.Resource.Type)); }
                else if (string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => o.KindName.EqualsWithNull(item.Resource.Kind) && o.TypeName.EqualsWithNull("No Type Given")); }

                if (thisone != null)
                {
                    thisone.Counts[0]++;
                    if (item.CheckOutDate.Date <= opEndDate.Date || item.LastDayOnIncident.Date <= opEndDate.Date)
                    {
                        thisone.Counts[1]++;
                    }
                }
            }

            counts = counts.OrderBy(o => o.KindName).ThenBy(o => o.TypeName).ToList();
            return counts;
        }
    
        private List<byte[]> createLogisticsSummaryPage1PDF(Incident incident, int OpPeriod, ICSRole ParentRole, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "LOGISTICS OVERVIEW - " + incident.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString();
            if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { outputFileName += " " + ParentRole.RoleName; }
            outputFileName += ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("Logistics Overview.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
                    OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod);



                    stamper.AcroFields.SetField("INCIDENT NAME OR NUMBERRow1", incident.IncidentNameOrNumber);
                    if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { stamper.AcroFields.SetField("BRANCH  DIVISION  OVERHEAD", ParentRole.RoleName); }
                    else { stamper.AcroFields.SetField("BRANCH  DIVISION  OVERHEAD", "Full Incident"); }

                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));

                    int[] accomodations = allCheckInRecords.GetAccommodationPreferences();

                    stamper.AcroFields.SetField("Not Incident CampRow1", accomodations[0].ToString());
                    stamper.AcroFields.SetField("MaleOnlyRow1", accomodations[1].ToString());
                    stamper.AcroFields.SetField("FemaleOnlyRow1", accomodations[2].ToString());
                    stamper.AcroFields.SetField("Not GenderRestrictedRow1", accomodations[3].ToString());


                    int[,] food = allCheckInRecords.GetMealRequirements();

                    stamper.AcroFields.SetField("BreakfastUnrestricted", food[0, 0].ToString());
                    stamper.AcroFields.SetField("BreakfastDietary Restrictions", food[0,1].ToString());
                    stamper.AcroFields.SetField("LunchUnrestricted", food[1,0].ToString());
                    stamper.AcroFields.SetField("LunchDietary Restrictions", food[1,1].ToString());
                    stamper.AcroFields.SetField("DinnerUnrestricted", food[2,0].ToString());
                    stamper.AcroFields.SetField("DinnerDietary Restrictions", food[2,1].ToString());

                    int[] vehicleTypes = allCheckInRecords.GetVehicleTypes();
                    stamper.AcroFields.SetField("AgencyOwnedRow1", vehicleTypes[0].ToString());
                    stamper.AcroFields.SetField("RentalRow1", vehicleTypes[1].ToString());
                    stamper.AcroFields.SetField("ContractorRow1", vehicleTypes[2].ToString());
                    stamper.AcroFields.SetField("PrivateRow1", vehicleTypes[3].ToString());

                    //need resources by type
                    List<KindTypeWithCounts> typesWithCount = getTypesWithCounts(allCheckInRecords, currentPeriod.PeriodEnd);
                 

                    for (int x = 0; x< typesWithCount.Count && x < 28; x++)
                    {
                        stamper.AcroFields.SetField("KindRow" + (x + 1).ToString(), typesWithCount[x].KindName);
                        stamper.AcroFields.SetField("TypeRow" + (x + 1).ToString(), typesWithCount[x].TypeName);
                        stamper.AcroFields.SetField("Total this Op PeriodRow" + (x + 1).ToString(), typesWithCount[x].Counts[0].ToString());
                        stamper.AcroFields.SetField("Departing End of Op PeriodRow" + (x + 1).ToString(), typesWithCount[x].Counts[1].ToString());
                    }




                    stamper.AcroFields.SetField("PAGE", thisPageNum.ToString());
                    stamper.AcroFields.SetField("OF", totalPageNum.ToString());



                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    Guid randomID = Guid.NewGuid();
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + randomID.ToString());
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }

            List<byte[]> allPDFs = new List<byte[]>();

            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }
            return allPDFs;
        }



        private List<byte[]> createLogisticsSummarySubsequentPDF(Incident incident, int OpPeriod, ICSRole ParentRole, List<KindTypeWithCounts> counts, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "LOGISTICS OVERVIEW - " + incident.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString();
            if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { outputFileName += " " + ParentRole.RoleName; }
            outputFileName += ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("Logistics Overview Subsequent Page.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
                    OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod);



                    stamper.AcroFields.SetField("INCIDENT NAME OR NUMBERRow1", incident.IncidentNameOrNumber);
                    if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { stamper.AcroFields.SetField("SCOPE", ParentRole.RoleName); }
                    else { stamper.AcroFields.SetField("SCOPE", "Full Incident"); }

                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));



                    for (int x = 0; x < counts.Count && x < 28; x++)
                    {
                        stamper.AcroFields.SetField("KindRow" + (x + 1).ToString(), counts[x].KindName);
                        stamper.AcroFields.SetField("TypeRow" + (x + 1).ToString(), counts[x].TypeName);
                        stamper.AcroFields.SetField("Total this Op PeriodRow" + (x + 1).ToString(), counts[x].Counts[0].ToString());
                        stamper.AcroFields.SetField("Departing End of Op PeriodRow" + (x + 1).ToString(), counts[x].Counts[1].ToString());
                    }




                    stamper.AcroFields.SetField("PAGE", thisPageNum.ToString());
                    stamper.AcroFields.SetField("OF", totalPageNum.ToString());



                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    Guid randomID = Guid.NewGuid();
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + randomID.ToString());
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }

            List<byte[]> allPDFs = new List<byte[]>();

            if (path != null)
            {
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }
            return allPDFs;
        }




        #endregion

        #region Assignment Summaries and Details
        public PDFCreationResults exportAllAssignmentSummariesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            PDFCreationResults results = new PDFCreationResults();
            results.bytes = new List<byte[]>();


            List<OperationalGroup> GroupsToPrint = new List<OperationalGroup>();
            //All divisions
            GroupsToPrint.AddRange(task.ActiveOperationalGroups.Where(o => o.OpPeriod == OpPeriodToExport && o.IsDivision));
            //All groups not within a division
            foreach(OperationalGroup group in task.ActiveOperationalGroups.Where(o => o.OpPeriod == OpPeriodToExport && o.IsGroup))
            {
                if (!GroupsToPrint.Any(o => o.ID == group.ID) && task.ActiveOperationalGroups.Any(o => o.ID == group.ParentID) && !task.ActiveOperationalGroups.First(o=>o.ID == group.ParentID).IsDivision)
                {
                    GroupsToPrint.Add(group);
                }
            }

            //All branches that contain strike teams or task forces directly
            foreach(OperationalGroup group in task.ActiveOperationalGroups.Where(o=>o.OpPeriod == OpPeriodToExport && o.IsBranch))
            {
                if (!GroupsToPrint.Any(o => o.ID == group.ID) && task.ActiveOperationalGroups.Any(o => o.ParentID == group.ID && (o.IsStrikeTeam || o.IsTaskForce)) )
                {
                    GroupsToPrint.Add(group);
                }
            }



            foreach (OperationalGroup group in GroupsToPrint)
            {
                PDFCreationResults groupResults = createAssignmentSummaryPDF(task, group.ID, true, flattenPDF);
                results.errors.AddRange(groupResults.errors);
                if (groupResults.path != null && groupResults.Successful)
                {
                    results.Successful = true;
                    using (FileStream stream = File.OpenRead(groupResults.path))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                       results.bytes.Add(fileBytes);
                    }
                }
            }
           
            return results;
        }

        public PDFCreationResults exportAssignmentListToPDF(Incident task,  Guid DivisionID, bool flattenPDF)
        {
            PDFCreationResults results = new PDFCreationResults();

          results.bytes = new List<byte[]>();

            PDFCreationResults pdfResults = createAssignmentSummaryPDF(task, DivisionID, true, flattenPDF);
            results.errors.AddRange(pdfResults.errors);
            results.Successful = pdfResults.Successful;
            if (pdfResults.path != null && pdfResults.Successful)
            {
                using (FileStream stream = File.OpenRead(pdfResults.path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                   results.bytes.Add(fileBytes);
                }
            }

            return results;
        }

        public PDFCreationResults createAssignmentSummaryPDF(Incident task, Guid OperationalGroupID, bool useTempPath, bool flattenPDF)
        {
            PDFCreationResults results = new PDFCreationResults();
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }


            OperationalGroup opGroup = task.AllOperationalGroups.FirstOrDefault(o => o.ID == OperationalGroupID);

            string outputFileName = "ICS 204 - " + task.IncidentNameAndNumberForPath + " OP " + opGroup.OpPeriod.ToString() + " " + opGroup.ResourceName + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS-204-WF Assignment List.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    OperationalGroup BranchGroup = null;
                    if (opGroup.GroupType.Equals("Branch") || opGroup.GroupType.Equals("Section")) { BranchGroup = opGroup; }
                    else
                    {
                        OperationalGroup parent = opGroup;

                        while (BranchGroup == null)
                        {
                            parent = task.AllOperationalGroups.FirstOrDefault(o => o.ID == parent.ParentID);
                            if (parent.GroupType.Equals("Branch") || parent.GroupType.Equals("Section")) { BranchGroup = parent; }
                        }
                    }

                    if (BranchGroup != null) { stamper.AcroFields.SetField("1 BRANCH", BranchGroup.ResourceName); }


                    stamper.AcroFields.SetField("2 DIVISIONGROUPSTAGING", opGroup.ResourceName);


                    OperationalPeriod currentPeriod = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == opGroup.OpPeriod);

                    stamper.AcroFields.SetField("3 INCIDENT NAME OR NUMBERRow1", task.IncidentNameOrNumber);

                    if (currentPeriod != null)
                    {
                        stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                        stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                    }

                    if (opGroup.PreparedByResourceID != Guid.Empty)
                    {
                        ICSRole role = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.FirstOrDefault(o => o.ID == opGroup.PreparedByRoleID);
                        stamper.AcroFields.SetField("Name", role.IndividualName);
                    }
                    stamper.AcroFields.SetField("Position", opGroup.PreparedByRoleName);

                    List<ICSRole> operationalPersonnel = new List<ICSRole>();
                    ICSRole thisLeader = task.activeOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.FirstOrDefault(o => o.ID == opGroup.LeaderICSRoleID);
                    if (thisLeader != null) { operationalPersonnel.Insert(0, thisLeader); }
                    if (BranchGroup != null && task.activeOrgCharts.First(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.Any(o => o.RoleID == BranchGroup.LeaderICSRoleID))
                    {
                        operationalPersonnel.Insert(0, task.activeOrgCharts.First(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.First(o => o.RoleID == BranchGroup.LeaderICSRoleID));

                        Guid reportsTo = BranchGroup.ParentID;
                        while (reportsTo != Guid.Empty)
                        {
                            OperationalGroup branchParent = task.ActiveOperationalGroups.FirstOrDefault(o => o.ID == reportsTo);
                            if (branchParent != null)
                            {
                                ICSRole role = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.FirstOrDefault(o => o.ID == branchParent.LeaderICSRoleID);
                                operationalPersonnel.Insert(0, role);
                                reportsTo = branchParent.ParentID;
                            }
                        }
                    }


                    for (int x = 0; x < 4 && x < operationalPersonnel.Count; x++)
                    {
                        stamper.AcroFields.SetField("5 OPERATIONAL PERSONNEL" + (x + 1), operationalPersonnel[x].RoleName);
                        if (operationalPersonnel[x].IndividualID != Guid.Empty) { stamper.AcroFields.SetField("5 OPERATIONAL PERSONNEL" + (x + 5), operationalPersonnel[x].IndividualName); }
                    }

                    List<IncidentResource> reportingResources = task.GetReportingResources(opGroup.ID);
                    reportingResources.AddRange(task.ActiveOperationalGroups.Where(o => o.ParentID == opGroup.ID && !o.IsBranchOrDiv));
                    List<CommsPlanItem> comms = new List<CommsPlanItem>();


                    int assignmentRow = 1;
                    foreach (IncidentResource ta in reportingResources)
                    {
                        if (ta.GetType().Name.Equals("OperationalGroup")) { stamper.AcroFields.SetField("Resource IdentifierRow" + assignmentRow, ((OperationalGroup)ta).ResourceName); }
                        else { stamper.AcroFields.SetField("Resource IdentifierRow" + assignmentRow, ta.ResourceName); }
                        stamper.AcroFields.SetField("LeaderRow" + assignmentRow, ta.LeaderName);
                        stamper.AcroFields.SetField("No of PersonsRow" + assignmentRow, ta.NumberOfPeople.ToString());
                        stamper.AcroFields.SetField("Contact cell radio frequency etcRow" + assignmentRow, ta.Contact);
                        if (ta.GetType().Name.Equals("OperationalGroup"))
                        {
                            stamper.AcroFields.SetField("Reporting Location Special Equipment and Supplies RemarksRow" + assignmentRow, (ta as OperationalGroup).Comments);
                        }
                        assignmentRow++;
                    }


                    stamper.AcroFields.SetField("7 TACTICAL ASSIGNMENTSRow1", opGroup.TacticalAssignment);



                    stamper.AcroFields.SetField("8 SPECIAL INSTRUCTIONSRow1", opGroup.SpecialInstructions);

                    foreach (Guid g in opGroup.CommsPlanItemIDs)
                    {
                        if (task.allCommsPlans.Any(o => o.OpPeriod == opGroup.OpPeriod) && task.allCommsPlans.First(o => o.OpPeriod == opGroup.OpPeriod).allCommsItems.Any(o => o.ItemID == g))
                        {
                            comms.Add(task.allCommsPlans.First(o => o.OpPeriod == opGroup.OpPeriod).allCommsItems.First(o => o.ItemID == g));
                        }
                    }

                    for (int x = 0; x < comms.Count && x < 4; x++)
                    {
                        stamper.AcroFields.SetField("NameRow" + (x + 1), comms[x].SystemWithID);
                        stamper.AcroFields.SetField("ChannelRow" + (x + 1), comms[x].ChannelNumber);
                        stamper.AcroFields.SetField("FunctionRow" + (x + 1), comms[x].CommsFunction);
                        stamper.AcroFields.SetField("Rx FrequencyRow" + (x + 1), comms[x].RxFrequency);
                        stamper.AcroFields.SetField("Rx ToneRow" + (x + 1), comms[x].RxTone);
                        stamper.AcroFields.SetField("Tx FrequencyRow" + (x + 1), comms[x].TxFrequency);
                        stamper.AcroFields.SetField("Tx ToneRow" + (x + 1), comms[x].TxTone);
                        stamper.AcroFields.SetField("RemarksRow1" + (x + 1), comms[x].Comments);


                    }


                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    Guid randomID = Guid.NewGuid();
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-204-" + randomID.ToString());
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();

                    results.Successful = true;

                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception ex)
            {
                results.errors.Add(ex);
            }

            results.path = path;
            return results;
        }






        public List<byte[]> exportAllAssignmentDetailsToPDF(Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<OperationalGroup> groupsToExport = new List<OperationalGroup>();

            if (task.ActiveOperationalGroups.Any(o=>o.OpPeriod == OpPeriodToExport))
            {
                groupsToExport.AddRange(task.ActiveOperationalGroups.Where(o => !o.GroupType.Equals("Section") && !o.IsBranchOrDiv && o.OpPeriod == OpPeriodToExport));


                foreach (OperationalGroup op in groupsToExport)
                {
                    string path = createAssignmentDetailsPDF(task, OpPeriodToExport, op.ID, true, flattenPDF);
                    if (path != null)
                    {
                        using (FileStream stream = File.OpenRead(path))
                        {
                            byte[] fileBytes = new byte[stream.Length];

                            stream.Read(fileBytes, 0, fileBytes.Length);
                            stream.Close();
                            allPDFs.Add(fileBytes);
                        }
                    }
                }
            }
            return allPDFs;
        }
        public string createAssignmentDetailsPDF(Incident task, int OpPeriod, Guid OpGroupID, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            OperationalGroup opGroup = task.AllOperationalGroups.FirstOrDefault(o => o.ID == OpGroupID);

            string outputFileName = "ICS 204A - " + task.IncidentNameAndNumberForPath + " OP " + OpPeriod.ToString() + " " + opGroup.ResourceName + ".pdf";
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS-204A-WF Assignment Details.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));
                   
                    OperationalGroup opGroupDiv = task.ActiveOperationalGroups.FirstOrDefault(o => o.ID == opGroup.ParentID);
                    if (opGroupDiv != null)
                    {
                        stamper.AcroFields.SetField("2 DIVISIONGROUPSTAGING", opGroupDiv.ResourceName);

                        if (opGroupDiv.ParentID != null)
                        {
                            OperationalGroup opGroupBranch = task.ActiveOperationalGroups.FirstOrDefault(o => o.ID == opGroupDiv.ParentID);
                            if (opGroupBranch != null)
                            {
                                stamper.AcroFields.SetField("1 BRANCH", opGroupBranch.ResourceName);

                            }
                        } else
                        {
                            stamper.AcroFields.SetField("1 BRANCH", opGroupDiv.ResourceName);
                        }
                    }


                  



                    OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpPeriod).First();

                    stamper.AcroFields.SetField("3 INCIDENT NAME OR NUMBERRow1", task.IncidentNameOrNumber);
                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("5 Identifier of Strike Team or Task Force or GroupRow1", opGroup.ResourceName); 
                    stamper.AcroFields.SetField("6 Name of STLD  TFLD or Group SupervisorRow1", opGroup.LeaderName);

                    if (opGroup.PreparedByResourceID != Guid.Empty)
                    {
                        ICSRole role = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == opGroup.OpPeriod).ActiveRoles.FirstOrDefault(o => o.ID == opGroup.PreparedByRoleID);
                        stamper.AcroFields.SetField("Name", role.IndividualName);
                    }
                    stamper.AcroFields.SetField("Position", opGroup.PreparedByRoleName);


                   

                    List<IncidentResource> reportingResources = task.GetReportingResources(opGroup.ID);
                    reportingResources.AddRange(task.ActiveOperationalSubGroups.Where(o => o.OperationalGroupID == opGroup.ID));
                    List<CommsPlanItem> comms = new List<CommsPlanItem>();


                    int assignmentRow = 1;
                    foreach (IncidentResource ta in reportingResources)
                    {
                        stamper.AcroFields.SetField("Resource IdentifierRow" + assignmentRow, ta.ResourceName);
                        stamper.AcroFields.SetField("KindRow" + assignmentRow, ta.Kind);
                        stamper.AcroFields.SetField("TypeRow" + assignmentRow, ta.Type);
                        if (ta.NumberOfPeople <= 1)
                        {
                            stamper.AcroFields.SetField("Name  Leader QtyRow" + assignmentRow, ta.LeaderName);
                        } else { stamper.AcroFields.SetField("Name  Leader QtyRow" + assignmentRow, ta.LeaderName + " (" + ta.NumberOfPeople + ")"); }
                        if (ta.GetType().Name.Equals(new OperationalGroupResourceListing().GetType().Name))
                        {
                            stamper.AcroFields.SetField("RoleRow" + assignmentRow, (ta as OperationalGroupResourceListing).Role);
                        }
                        if(ta.NumberOfPeople > 1)
                        {
                            ;
                        }
                        if(ta.GetType().Name.Equals(new OperationalGroupResourceListing().GetType().Name) &&  task.AllOperationalSubGroups.Any(o=>o.ID == (ta as OperationalGroupResourceListing).ResourceID))
                        {
                            stamper.AcroFields.SetField("TransportationRow" + assignmentRow, task.AllOperationalSubGroups.First(o => o.ID == (ta as OperationalGroupResourceListing).ResourceID).Transport);
                        }

                        assignmentRow++;
                    }


                    stamper.AcroFields.SetField("8 COMMENTS", opGroup.Comments);


                    //Rename all fields
                    AcroFields af = stamper.AcroFields;

                    List<string> fieldNames = new List<string>();
                    foreach (var field in af.Fields)
                    {
                        fieldNames.Add(field.Key);
                    }
                    Guid randomID = Guid.NewGuid();
                    foreach (string s in fieldNames)
                    {
                        stamper.AcroFields.RenameField(s, s + "-204-" + randomID.ToString());
                    }


                    if (flattenPDF)
                    {
                        stamper.FormFlattening = true;
                    }

                    stamper.Close();//Close a PDFStamper Object
                    stamper.Dispose();
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }
        #endregion


        public string createBriefingPDF(Incident task, Briefing briefing, bool automaticallyOpen = true, bool tempFileName = false)
        {
            throw new NotImplementedException();
        }

        public List<byte[]> exportBriefingToBytes(int OpPeriodToExport, Incident task)
        {
            throw new NotImplementedException();
        }

        public string exportBriefingToPDF(Briefing briefing, Incident task, bool includeExecution, bool includeMapQRImage = false)
        {
            throw new NotImplementedException();
        }
     
    }
}
