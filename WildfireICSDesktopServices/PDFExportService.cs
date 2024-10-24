using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
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

        private string getBlankFormsFolder()
        {
            string dir = AppContext.BaseDirectory;
            return System.IO.Path.Combine(dir, "BlankForms");
        }

        private string getPDFFilePath(string fileToUse)
        {
            if (fileToUse.Contains("BlankForms/"))
            {
                fileToUse = fileToUse.Replace("BlankForms/", "");
            }
            string dir = getBlankFormsFolder();
            return System.IO.Path.Combine(dir, fileToUse);
        }

        #region Dietary and Allergy Details

        public List<byte[]> exportDietaryAndAllergyToPDF(WFIncident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF)
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

        public List<byte[]> createSinglePageDietaryAndAllergyPDF(WFIncident incident, int OpPeriod, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "Dietary and Allergy Details - " + incident.IncidentIdentifier + " OP " + OpPeriod.ToString() + " page " + thisPageNum;
            outputFileName += ".pdf";

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            string fileToUse = getPDFFilePath("Dietary and Allergy Details.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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
        public List<byte[]> exportGeneralMessagesToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<GeneralMessage> items = task.ActiveGeneralMessages.Where(o => o.OpPeriod == OpPeriodToExport).ToList();
            foreach (GeneralMessage sp in items)
            {
                string path = createGeneralMessagePDF(task, sp,  true, flattenPDF);
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

        public List<byte[]> exportGeneralMessagesToPDF(WFIncident task, List<GeneralMessage> items, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            foreach (GeneralMessage sp in items)
            {
                string path = createGeneralMessagePDF(task, sp,  true, flattenPDF);
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

        public string createGeneralMessagePDF(WFIncident task, GeneralMessage item, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);
            if (task != null && item != null)
            {
                if (!tempFileName)
                {


                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string filename = "ICS 213 - " + task.IncidentIdentifier + " - " + item.Subject.Sanitize() + ".pdf";
                    if (filename.Length > 100)
                    {
                        filename = "ICS 213 - " + task.IncidentIdentifier + " - " + item.Subject.Sanitize().Substring(0, 20) + ".pdf";
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




                    string fileToUse = getPDFFilePath("ICS-213-WF-General-Message.pdf");
                    fileToUse = getPDFFilePath(fileToUse);
                    PdfReader rdr = new PdfReader(fileToUse);

                    using (FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
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
                        if (!string.IsNullOrEmpty(item.ApprovedByPosition)) { stamper.AcroFields.SetField("Position", item.ApprovedByPosition); }
                        if (!string.IsNullOrEmpty(item.ApprovedByName)) { stamper.AcroFields.SetField("Name", item.ApprovedByName); }
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

        #region Safety Messages

        public List<byte[]> exportSafetyMessagesToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
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

        public List<byte[]> exportSafetyMessagesToPDF(WFIncident task, List<SafetyMessage> messagesToPrint, bool flattenPDF)
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



        public string createSafetyMessagePDF(WFIncident task, SafetyMessage plan, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);
            if (task != null && plan != null)
            {
                if (!tempFileName)
                {


                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string filename = "ICS 208 - Task " + task.IncidentIdentifier + " - Op " + plan.OpPeriod.ToString(Globals.cultureInfo) + " - Hazard " +  plan.SummaryLine.Sanitize() + ".pdf";
                    if (filename.Length > 100)
                    {
                        filename = "ICS 208 - Task " + task.IncidentIdentifier + " - Op " + plan.OpPeriod.ToString(Globals.cultureInfo) + " - Hazard " + plan.SummaryLine.Sanitize().Substring(0, 20) + ".pdf";
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



                    string fileToUse = getPDFFilePath("ICS-208-WF-Safety-Message.pdf");
                    if(!string.IsNullOrEmpty(plan.ImageBytes))
                    {
                        fileToUse = getPDFFilePath("ICS-208-WF-Safety-Message-with-image.pdf");
                    }
                    fileToUse = getPDFFilePath(fileToUse);
                    PdfReader rdr = new PdfReader(fileToUse);

                    using (FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                    {
                        PdfStamper stamper = new PdfStamper(rdr, stream);
                        stamper.AcroFields.SetField("1 INCIDENT NAME OR NUMBER 2 OPERATIONAL Date From Date To", task.IncidentIdentifier);

                        stamper.AcroFields.SetField("SafetyMessage", plan.Message);
                        stamper.AcroFields.SetField("Approved Site Safety Plans Located at I", plan.SitePlanLocation);

                        stamper.AcroFields.SetField("PreparedByPosition", plan.ApprovedByRoleName);
                        stamper.AcroFields.SetField("5 PREPARED BY I Position I Name I", plan.ApprovedByName);


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

        public List<byte[]> exportDemobChecklistToPDF(WFIncident task, List< IncidentResource> Resources, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            string outputFileName = "ICS-211 " + DateTime.Now.ToString(Globals.DateFormat) + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            List<byte[]> allPDFs = new List<byte[]>();

            foreach (IncidentResource res in Resources)
            {
                allPDFs.AddRange(exportDemobChecklistToPDF(task, res, flattenPDF));
            }
            return allPDFs;
        }


        public List<byte[]> exportDemobChecklistToPDF(WFIncident task, IncidentResource Resource, bool flattenPDF)
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


        public string createDemobChecklistPDF(WFIncident task, IncidentResource Resource, bool tempFileName = false, bool flattenPDF = false)
        {

            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }

                string outputFileName = "ICS 221 - " + Resource.UniqueIDNumWithPrefix;

                //path = System.IO.Path.Combine(path, outputFileName);
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }
            try
            {

                string fileToUse = getPDFFilePath("ICS-221-WF Demobilization Checkout.pdf");
                fileToUse = getPDFFilePath(fileToUse);


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
        public List<byte[]> exportMedicalPlanToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
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


        public string createMedicalPlanPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
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
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }
            try
            {

                string fileToUse = getPDFFilePath("ICS-206-WF-Medical-Plan.pdf");
                fileToUse = getPDFFilePath(fileToUse);


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
                if (plan.PreparedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.PreparedBy) && currentChart.ActiveRoles.Any(o => o.RoleID == plan.PreparedByRoleID))
                {
                    ICSRole role = currentChart.ActiveRoles.First(o => o.RoleID == plan.PreparedByRoleID);
                    plan.PreparedBy = role.IndividualName;
                }
                stamper.AcroFields.SetField("Name", plan.PreparedBy);
                stamper.AcroFields.SetField("Position", plan.PreparedByPosition);

                //This will check with the org chart to see if an individual has been assigned, assuming the name is vacant right now
                if (plan.ApprovedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.ApprovedBy) && currentChart.ActiveRoles.Any(o => o.RoleID == plan.ApprovedByRoleID))
                {
                    ICSRole role = currentChart.ActiveRoles.First(o => o.RoleID == plan.ApprovedByRoleID);
                    plan.ApprovedBy = role.IndividualName;
                }
                stamper.AcroFields.SetField("Name_2", plan.ApprovedBy);
                stamper.AcroFields.SetField("Position_2", plan.ApprovedByPosition);

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
        public List<byte[]> exportCommsPlanToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
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


        public string createCommsPlanPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
        {
            string path = FileAccessClasses.getWritablePath(task);
            if (!tempFileName)
            {



                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                string outputFileName = "ICS 205 - Task " + task.TaskNumber + " - Op Period " + OpsPeriod.ToString();
                //path = System.IO.Path.Combine(path, outputFileName);
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            }


            if (!task.allCommsPlans.Where(o => o.OpsPeriod == OpsPeriod).Any())
            {
                task.createCommsPlanAsNeeded(OpsPeriod);
            }

            CommsPlan plan = task.allCommsPlans.Where(o => o.OpsPeriod == OpsPeriod).First();



            try
            {

                string fileToUse = getPDFFilePath("ICS205WF-Communications-Plan.pdf");
                fileToUse = getPDFFilePath(fileToUse);
                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));

                OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == plan.OpsPeriod);

                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentIdentifier);
                stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));


                stamper.AcroFields.SetField("Name", plan.PreparedBy);
                stamper.AcroFields.SetField("Position", plan.PreparedByPosition);

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
        public List<byte[]> exportIncidentObjectivesToPDF(WFIncident task, int OpPeriodToExport, bool IncludeAttachments, bool flattenPDF)
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

        public string createObjectivesPDF(WFIncident task, int OpsPeriod, bool includeAttachments = false, bool tempFileName = false, bool flattenPDF = false)
        {
            if (task != null)
            {
                string path = FileAccessClasses.getWritablePath(task);

                if (!tempFileName)
                {


                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "ICS 202 - Task " + task.IncidentIdentifier + " - Op Period " + OpsPeriod.ToString();
                    //path = System.IO.Path.Combine(path, outputFileName);
                    path = FileAccessClasses.getUniqueFileName(outputFileName, path);
                }
                else
                {
                    path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                }


                try
                {
                    string fileToUse = getPDFFilePath("ICS-202-WF-Incident-Objectives.pdf");
                    fileToUse = getPDFFilePath(fileToUse);

                    if (!File.Exists(fileToUse)) { return "err Blank PDF Not found"; }

                    PdfReader rdr = new PdfReader(fileToUse);
                    PdfStamper stamper = new PdfStamper(rdr, new FileStream(path, FileMode.Create));

                    task.createObjectivesSheetAsNeeded(OpsPeriod);

                    IncidentObjectivesSheet currentSheet = task.allIncidentObjectives.First(o=>o.OpPeriod== OpsPeriod);

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

                    ICSRole PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefID, true);
                    if (null != PreparedBy)
                    {
                        stamper.AcroFields.SetField("9 PREPARED BY Planning Section Chief", PreparedBy.IndividualName);
                    }
                    ICSRole IC = currentChart.GetRoleByID(Globals.IncidentCommanderID, true);
                    if (null != IC)
                    {
                        stamper.AcroFields.SetField("10 APPROVED BY Incident Commander", IC.IndividualName);
                    }

                    stamper.AcroFields.SetField("3A FIRE SIZE", currentSheet.FireSize);
                    stamper.AcroFields.SetField("3B FIRE STATUS", currentSheet.FireStatus);
                    stamper.AcroFields.SetField("6 WEATHER FORCASTRow1", currentSheet.WeatherForcast);
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
        public List<byte[]> exportOrgAssignmentListToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
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


  

        public PDFCreationResults createOrgAssignmentListPDF(WFIncident task, int OpsPeriod,  bool tempFileName = false, bool flattenPDF = false)
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

                string fileToUse = getPDFFilePath("ICS-203-WF Organization Assignment List Blanked.pdf");
                
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


                                stamper.AcroFields.SetField("1 INCIDENT NAME OR NUMBER", task.IncidentNameOrNumber);
                                stamper.AcroFields.SetField("2 DATE PREPARED", string.Format("{0:" + DateFormat + "}", DateTime.Now));
                                stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentOp.PeriodStart));
                                stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentOp.PeriodEnd));
                                stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                                ICSRole PreparedBy = new ICSRole();
                                if (currentChart.PreparedByUserID != Guid.Empty)
                                {
                                   
                                    PreparedBy.IndividualName = currentChart.PreparedBy;
                                    PreparedBy.RoleName = currentChart.PreparedByRole;
                                }
                                else
                                {
                                    PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefID, true);
                                }

                                if (null != PreparedBy)
                                {
                                    stamper.AcroFields.SetField("Position", PreparedBy.RoleName);
                                    stamper.AcroFields.SetField("Name", PreparedBy.IndividualName);
                                }
                                //stamper.AcroFields.SetField("PAGE", "1");
                                currentChart.SortRoles();

                                //Incident Command
                                List<ICSRole> icRoles = currentChart.GetRolesForAssignmentList(Globals.IncidentCommanderID, 10, 7);
                                for (int x = 0; x < 7 && x < icRoles.Count; x++)
                                {
                                    if (icRoles[x].ReportsTo == Globals.IncidentCommanderID || icRoles[x].RoleID == Globals.IncidentCommanderID) { stamper.SetFieldFontBold("4 INCIDENT AND COMMAND STAFFRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("4 INCIDENT AND COMMAND STAFFRow" + (x + 1), icRoles[x].RoleName);
                                    stamper.AcroFields.SetField("4 INCIDENT AND COMMAND STAFFRow" + (x + 1) + "_2", icRoles[x].IndividualName);
                                }
                                //agency reps
                                List<ICSRole> repRoles = currentChart.ActiveRoles.Where(o => o.SectionID == Globals.IncidentCommanderID && o.RoleName.Equals("Agency Representative")).OrderBy(o => o.Depth).ThenBy(o => o.ManualSortOrder).ThenBy(o => o.RoleName).ToList();
                                for (int x = 0; x < 8 && x < repRoles.Count; x++)
                                {

                                    if (repRoles[x].IndividualID != Guid.Empty && task.IncidentPersonnel.Any(o => o.ID == repRoles[x].IndividualID))
                                    {
                                        Personnel p = task.IncidentPersonnel.First(o=>o.ID == repRoles[x].IndividualID);    
                                        stamper.AcroFields.SetField("Agency  OrganizationRow" + (x + 1), p.Agency);
                                    }
                                    else { stamper.AcroFields.SetField("Agency  OrganizationRow" + (x + 1), repRoles[x].RoleName); }
                                    stamper.AcroFields.SetField("RepresentativeRow" + (x + 1), repRoles[x].IndividualName);
                                }

                                //Planning
                                List<ICSRole> planRoles = currentChart.GetRolesForAssignmentList(Globals.PlanningChiefID, 0, 10);
                                for (int x = 0; x < 10 && x < planRoles.Count; x++)
                                {
                                    if (planRoles[x].ReportsTo == Globals.PlanningChiefID || planRoles[x].RoleID == Globals.PlanningChiefID) { stamper.SetFieldFontBold("6 PLANNING SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("6 PLANNING SECTIONRow" + (x + 1), planRoles[x].RoleName);
                                    stamper.AcroFields.SetField("6 PLANNING SECTIONRow" + (x + 1) + "_2", planRoles[x].IndividualName);
                                }

                                //Ops
                                List<ICSRole> opsRoles = currentChart.GetRolesForAssignmentList(Globals.OpsChiefID, 0, 35);
                                for (int x = 0; x < 35 && x < opsRoles.Count; x++)
                                {
                                    if (opsRoles[x].ReportsTo == Globals.OpsChiefID || opsRoles[x].RoleID == Globals.OpsChiefID) { stamper.SetFieldFontBold("8 OPERATIONS SECTIONRow" + (x + 1)); }
                                    stamper.AcroFields.SetField("8 OPERATIONS SECTIONRow" + (x + 1), opsRoles[x].RoleName);
                                    stamper.AcroFields.SetField("8 OPERATIONS SECTIONRow" + (x + 1) + "_2", opsRoles[x].IndividualName);
                                }
                                //Logistics
                                List<ICSRole> logRoles = currentChart.GetRolesForAssignmentList(Globals.LogisticsChiefID, 0, 13);
                                for (int x = 0; x < 13 && x < logRoles.Count; x++)
                                {
                                    if (logRoles[x].ReportsTo == Globals.LogisticsChiefID || logRoles[x].RoleID == Globals.LogisticsChiefID) { stamper.SetFieldFontBold("7 LOGISTICS SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("7 LOGISTICS SECTIONRow" + (x + 1), logRoles[x].RoleName);
                                    stamper.AcroFields.SetField("7 LOGISTICS SECTIONRow" + (x + 1) + "_2", logRoles[x].IndividualName);
                                }
                                //Finance
                                List<ICSRole> financeRoles = currentChart.GetRolesForAssignmentList(Globals.FinanceChiefID, 0, 6);
                                for (int x = 0; x < 6 && x < financeRoles.Count; x++)
                                {
                                    if (financeRoles[x].ReportsTo == Globals.FinanceChiefID || financeRoles[x].RoleID == Globals.FinanceChiefID) { stamper.SetFieldFontBold("9 FINANCIALADMINISTRATION SECTIONRow" + (x + 1)); }

                                    stamper.AcroFields.SetField("9 FINANCIALADMINISTRATION SECTIONRow" + (x + 1), financeRoles[x].RoleName);
                                    stamper.AcroFields.SetField("9 FINANCIALADMINISTRATION SECTIONRow" + (x + 1) + "_2", financeRoles[x].IndividualName);
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
                } else
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
                    string outputFileName = "ICS 207 - Incident " + task.IncidentIdentifier + " - Op " + OpsPeriod + " - Org Chart";
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

















        public List<byte[]> exportOrgChartToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
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


        public string createOrgChartPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
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

                string fileToUse = getPDFFilePath("ICS-207-WF Incident Organization Chart.pdf");
                if (currentChart.IsUnifiedCommand) { fileToUse = ("ICS-207-WF Incident Organization Chart Unified.pdf"); }
                fileToUse = getPDFFilePath(fileToUse);
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
                            if(currentChart.PreparedByUserID != Guid.Empty)
                            {
                                //PreparedBy.teamMember = new Personnel(currentChart.PreparedByUserID);
                                PreparedBy.IndividualName = currentChart.PreparedBy;
                                PreparedBy.RoleName = currentChart.PreparedByRole;
                            }
                            else
                            {
                                PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefID, true);
                            }
                            
                            if (null != PreparedBy)
                            {
                                stamper.AcroFields.SetField("PreparedByPosition", PreparedBy.RoleName);
                                stamper.AcroFields.SetField("PreparedByName", PreparedBy.IndividualName);
                            }
                            stamper.AcroFields.SetField("PAGE", "1");


                            foreach (ICSRole role in currentChart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
                            {
                                if (!string.IsNullOrEmpty(role.PDFTitleName))
                                {
                                    stamper.AcroFields.SetField(role.PDFTitleName, role.RoleName);
                                }

                                List<ICSRole> childRoles = currentChart.GetChildRoles(role.RoleID, false);

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
                    string outputFileName = "ICS 207 - Task " + task.IncidentIdentifier + " - Op " + OpsPeriod + " - Org Chart";
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

        

        public List<string> createOrgChartExtensionPDF(WFIncident task, OrganizationChart currentChart, ICSRole parentRole, int ThisPageNumber, int totalPages, int startOnChild = 0, bool flattenPDF = false)
        {
            List<string> paths = new List<string>();


            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == currentChart.OpPeriod);
            paths.Add(path);

            try
            {
                string fileToUse = getPDFFilePath("ICS-207-WF-Organization-Chart-Extension.pdf");
                fileToUse = getPDFFilePath(fileToUse);

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

                            ICSRole PreparedBy = currentChart.GetRoleByID(Globals.PlanningChiefID, true);
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



        public List<byte[]> exportOrgChartContactsToPDF(WFIncident task, int OpPeriodToExport)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createOrgChartContactList(task, OpPeriodToExport, false, true);
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


        public string createOrgChartContactList(WFIncident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;

            if (task != null)
            {
                OrganizationChart chart = new OrganizationChart();
                if (task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).Any())
                {
                    chart = task.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First();
                }

                if (chart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)).Any())
                {
                    path = FileAccessClasses.getWritablePath(task);
                    if (!tempFileName)
                    {
                        if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                        string outputFileName = "Org Chart Contacts " + opsPeriod.ToString(Globals.cultureInfo);
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


                            if (chart.GetRoleByID(Globals.IncidentCommanderID).IndividualID != Guid.Empty)
                            {
                                document.AddAuthor(chart.GetRoleByID(Globals.IncidentCommanderID).IndividualName);
                            }
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
                            if (chart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)).Count() <= 5)
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
                                    string branchName = chart.ActiveRoles.Where(o => o.RoleID == branch).First().RoleName;
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
                            try { System.Diagnostics.Process.Start(path); }
                            catch { }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return path;
        }

        #endregion

        #region Contacts

        public List<byte[]> exportContactsToPDF(WFIncident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName, bool flattenPDF)
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

        public  string createContactsPDF(WFIncident task, int OpPeriod, string createdBy, string createdByTitle, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "ICS 205A - Task " + task.IncidentIdentifier + " - Communications List " + OpPeriod.ToString() + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("ICS205A-CommunicationsList.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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
        public List<byte[]> exportVehiclesToPDF(WFIncident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName,  bool flattenPDF)
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


        public string createVehiclePDF(WFIncident task, int OpPeriod, string PreparedByName, string PreparedByRoleName, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "ICS 218 - Task " + task.TaskNumber + " - Support Vehicle Equipment Inventory " + OpPeriod.ToString() + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("ICS 218 - Support Vehicle Equipment Inventory.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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

        private PdfStamper buildVehiclePDFContents(PdfStamper stamper, WFIncident task, int OpsPeriod, string PreparedByName, string PreparedByRoleName, bool flattenPDF)
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

        public List<byte[]> exportCheckInSheetsToPDF(WFIncident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF)
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

                List<CheckInRecordWithResource> checkInThisLocation = allCheckInRecords.Where(o => o.CheckInLocation.Equals(checkInLocation, StringComparison.InvariantCultureIgnoreCase)).ToList();
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

        private List<byte[]> createSinglePageCheckInSheetPDF(WFIncident incident, int OpPeriod, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "ICS-211 - " + incident.IncidentIdentifier + " OP " + OpPeriod.ToString() + " page " + thisPageNum;
            outputFileName += ".pdf";

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);

            string fileToUse = getPDFFilePath("ICS-211-WF Check In.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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


                    ICSRole PreparedBy = currentOrgChart.GetRoleByID(Globals.LogisticsChiefID, true);


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
        public string exportSinglePageSignInSheetAsPDF(WFIncident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = getPDFFilePath(fileToUse);
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

        public List<byte[]> createSinglePageSignInSheetAsBytes(WFIncident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = getPDFFilePath(fileToUse);
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


        public List<byte[]> createSinglePageBlankSignInSheetAsBytes(WFIncident task, GroupSignInPrintRequest group, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
            fileToUse = getPDFFilePath(fileToUse);
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


        public List<byte[]> getSignInSheetPDFs(WFIncident task, int OpsPeriod, bool flattenPDF)
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

        public List<byte[]> getBlankSignInSheetPDFs(WFIncident task, List<GroupSignInPrintRequest> groups, int OpsPeriod, bool flattenPDF)
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



        public string createSignInPDF(WFIncident task, int opsPeriod, bool tempFileName = false, bool flattenPDF = false)
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
                    //MessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.");
                }


                //MessageBox.Show("PDF Generated Successfully....!!!");


            }
            catch (IOException ex)
            {
                //MessageBox.Show("It appears a previous version of the PDF is still open.  Please close it before trying to generate a new copy.\r\n\r\nDetailed error message:" + ex.ToString());
            }
            catch (System.UnauthorizedAccessException ex)
            {
                /*
                MessageBox.Show("A program on your system, typically a virus scanner, is prevening files from being saved to " + path + ". Please select a different folder to save to.");
                saveAsPromptShown = true;
                DialogResult dr = fbdSaveLocation.ShowDialog();
                saveAsPromptShown = false;
                if (dr == DialogResult.OK)
                {
                    path = fbdSaveLocation.SelectedPath;
                    if (FileAccessClasses.checkWriteAccess(path))
                    {
                        //MessageBox.Show("Thank you, you have selected " + path + " please try to save again.");
                        CurrentTask.DocumentPath = path;
                        createSignInPDF(opsPeriod, automaticallyOpen);
                    }
                }*/
            }
            return path;
        }

        public string createBlankSignInPDF(WFIncident task, List<GroupSignInPrintRequest> groups, int opsPeriod, bool tempFileName = false, bool flattenPDF = false)
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
                    //MessageBox.Show("There was an error trying to save " + path + " please verify the path is accessible.");
                }


                //MessageBox.Show("PDF Generated Successfully....!!!");


            }
            catch (IOException ex)
            {
                // MessageBox.Show("It appears a previous version of the PDF is still open.  Please close it before trying to generate a new copy.\r\n\r\nDetailed error message:" + ex.ToString());
            }
            catch (System.UnauthorizedAccessException ex)
            {
                /*
                MessageBox.Show("A program on your system, typically a virus scanner, is prevening files from being saved to " + path + ". Please select a different folder to save to.");
                saveAsPromptShown = true;
                DialogResult dr = fbdSaveLocation.ShowDialog();
                saveAsPromptShown = false;
                if (dr == DialogResult.OK)
                {
                    path = fbdSaveLocation.SelectedPath;
                    if (FileAccessClasses.checkWriteAccess(path))
                    {
                        //MessageBox.Show("Thank you, you have selected " + path + " please try to save again.");
                        CurrentTask.DocumentPath = path;
                        createSignInPDF(opsPeriod, automaticallyOpen);
                    }
                }*/
            }
            return path;
        }

        #endregion

        #region Timeline

        public List<byte[]> exportTimelineToPDF(WFIncident task)
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
        public string createTimelinePDF(WFIncident task, bool IncludeSAR, bool IncludeSubject, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;
            if (task != null && task.taskTimeline != null)
            {
                path = FileAccessClasses.getWritablePath(task);
                if (!tempFileName)
                {



                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "Task " + task.TaskNumber + " Timeline"; ;
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

        public List<byte[]> createFreeformOpPeriodContentsList(WFIncident task, List<string> items, int OpPeriod)
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

        public List<byte[]> exportOpTitlePageToPDF(WFIncident task, int OpPeriod, string contentsText,string titleImageBytes, bool flattenPDF)
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

        public string createOpTitlePagePDF(WFIncident task, int OpPeriod, string contentsText, string titleImageBytes, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            string outputFileName = "Task " + task.IncidentIdentifier + " - Title Page - OP " + OpPeriod.ToString() + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath ("/ICS-000 Title Page.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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
        private int getRadioLogPageCount(WFIncident task, int OpPeriodToExport)
        {
            List<CommsLogEntry> entries = task.allCommsLogEntries.Where(o => o.OpPeriod == OpPeriodToExport).OrderBy(o => o.LogDate).ToList();

            int totalPages = Convert.ToInt32(Math.Floor(Convert.ToDecimal(entries.Count) / 26m));
            if (entries.Count % 26 > 0) { totalPages += 1; }
            if (totalPages == 0) { totalPages = 1; }
            return totalPages;
        }

        public List<byte[]> exportRadioLogToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF = false)
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

        private string createSinglePageRadioLog(WFIncident task, List<CommsLogEntry> entries, int pageNumber, int totalPages, int OpsPeriod)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 309 - Radio Log.pdf";
            fileToUse = getPDFFilePath(fileToUse);
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


        public string createRadioLogPDF(WFIncident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = FileAccessClasses.getWritablePath(task);

            if (!tempFileName)
            {

                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
            }
            else { path = System.IO.Path.GetTempPath(); }

            List<byte[]> allPDFs = exportRadioLogToPDF(task, opsPeriod);

            string outputFileName = "ICS 309 - Task " + task.TaskNumber + " - Radio Log Op " + opsPeriod.ToString() + ".pdf";
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

        private List<byte[]> createSinglePageRadioLogAsBytes(WFIncident task, List<CommsLogEntry> entries, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
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

        public List<byte[]> exportNotesToPDF(WFIncident task, int CurrentOpPeriod)
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



        public string createNotePDF(WFIncident task, Note note, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;
            if (task != null && task.taskTimeline != null)
            {
                path = FileAccessClasses.getWritablePath(task);
                if (!tempFileName)
                {



                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = note.NoteTitle;
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

        public string CreateAirOpsSummaryPDF(WFIncident task, int OpPeriod, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }



            string outputFileName = "ICS 220 - Task " + task.IncidentIdentifier + " - OP " + OpPeriod.ToString() + ".pdf";
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


        public List<byte[]> exportAirOpsSummaryToPDF(WFIncident incident, int OpPeriodToExport, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            AirOperationsSummary summary = incident.allAirOperationsSummaries.FirstOrDefault(o=>o.OpPeriod == OpPeriodToExport);
            List<Aircraft> aircraftList = incident.GetActiveAircraft(OpPeriodToExport);


            int totalPages = getAirOpsSummaryPageCount(incident, summary);


            List<string> pdfFileNames = new List<string>();


            List<CommsPlanItem> comms = incident.allCommsPlans.FirstOrDefault(o => o.OpsPeriod == summary.OpPeriod).ActiveAirCommsItems;
            List<ICSRole> roles = new List<ICSRole>();
            roles.Add(incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == summary.OpPeriod).ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.AirOpsDirector));
            roles.AddRange(incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == summary.OpPeriod).GetChildRoles(Globals.AirOpsDirector, true));



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

        private int getAirOpsSummaryPageCount(WFIncident incident, AirOperationsSummary sum)
        {
            int AirPP = 15;
            int RolePP = 10;
            int CommsPP = 10;
            List<Aircraft> aircraftList = incident.GetActiveAircraft(sum.OpPeriod);

            List<CommsPlanItem> comms = incident.allCommsPlans.FirstOrDefault(o => o.OpsPeriod == sum.OpPeriod).ActiveAirCommsItems;
            List<ICSRole> roles = new List<ICSRole>();
            roles.Add(incident.allOrgCharts.FirstOrDefault(o=>o.OpPeriod == sum.OpPeriod).ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.AirOpsDirector));
            roles.AddRange(incident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == sum.OpPeriod).GetChildRoles(Globals.AirOpsDirector, true));


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


        private List<byte[]> buildSingleAirOpsSummaryPage(WFIncident task, int OpsPeriod, List<Aircraft> aircraft, List<ICSRole> roles, List<CommsPlanItem> comms, int pageNumber, int pageCount, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempFileName();
            string fileToUse = getPDFFilePath("ICS-220-WF Air Operations Summary.pdf");
            

            OperationalPeriod currentOp = task.AllOperationalPeriods.First(o => o.PeriodNumber == OpsPeriod);
            AirOperationsSummary summary = task.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == OpsPeriod);
            if (summary.notam.UseRadius) { fileToUse = getPDFFilePath("ICS-220-WF Air Operations Summary.pdf"); }
            else { fileToUse = getPDFFilePath("ICS-220-WF Air Operations Summary Polygon.pdf"); }
            fileToUse = getPDFFilePath(fileToUse);
            using (PdfReader rdr = new PdfReader(fileToUse))
            {
                using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create)))
                {
                    stamper.AcroFields.SetField("1 INCIDENT NAME OR NUMBERRow1", task.IncidentNameOrNumber);

                    stamper.AcroFields.SetField("Contact Name", summary.PreparedByName);
                    stamper.AcroFields.SetField("Position", summary.PreparedByPosition);

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
                        stamper.AcroFields.SetField("NameRow" + (x + 1), roles[x].IndividualName);
                        stamper.AcroFields.SetField("PositionRow" + (x + 1), roles[x].RoleName);
                        if (roles[x].IndividualID != Guid.Empty && task.IncidentPersonnel.Any(o => o.ID == roles[x].IndividualID))
                        {
                            Personnel p = task.IncidentPersonnel.First(o => o.ID == roles[x].IndividualID);
                            stamper.AcroFields.SetField("Phone Row" + (x + 1), p.CellphoneNumber);
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

        public string createLogisticsSummaryPDF(WFIncident task, int OpPeriod, ICSRole ParentRole, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }



            string outputFileName = "LOGISTICS OVERVIEW - " + task.IncidentIdentifier + " OP " + OpPeriod.ToString() + " " + ParentRole.RoleName + ".pdf";
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

        public List<byte[]> exportLogisticsSummaryToPDF(WFIncident incident, int OpPeriodToExport, ICSRole ParentRole, bool flattenPDF)
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
                if (!counts.Any(o => o.KindName.Equals(item.Resource.Kind) && (o.TypeName == null || o.TypeName.Equals(item.Resource.Type))))
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
                if (!string.IsNullOrEmpty(item.Resource.Kind) && !string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => o.KindName.Equals(item.Resource.Kind) && o.TypeName.Equals(item.Resource.Type)); }
                else if (string.IsNullOrEmpty(item.Resource.Kind) && string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => o.KindName.Equals("No Kind Given") && o.TypeName.Equals("No Type Given")); }
                else if (string.IsNullOrEmpty(item.Resource.Kind)) { thisone = counts.First(o => o.KindName.Equals("No Kind Given") && o.TypeName.Equals(item.Resource.Type)); }
                else if (string.IsNullOrEmpty(item.Resource.Type)) { thisone = counts.First(o => o.KindName.Equals(item.Resource.Kind) && o.TypeName.Equals("No Type Given")); }

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
    
        private List<byte[]> createLogisticsSummaryPage1PDF(WFIncident incident, int OpPeriod, ICSRole ParentRole, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "LOGISTICS OVERVIEW - " + incident.IncidentIdentifier + " OP " + OpPeriod.ToString();
            if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { outputFileName += " " + ParentRole.RoleName; }
            outputFileName += ".pdf";

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("Logistics Overview.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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



        private List<byte[]> createLogisticsSummarySubsequentPDF(WFIncident incident, int OpPeriod, ICSRole ParentRole, List<KindTypeWithCounts> counts, int thisPageNum, int totalPageNum, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();

            string outputFileName = "LOGISTICS OVERVIEW - " + incident.IncidentIdentifier + " OP " + OpPeriod.ToString();
            if (ParentRole != null && ParentRole.RoleID != Guid.Empty) { outputFileName += " " + ParentRole.RoleName; }
            outputFileName += ".pdf";

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("Logistics Overview Subsequent Page.pdf");
            fileToUse = getPDFFilePath(fileToUse);
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
        public List<byte[]> exportAllAssignmentSummariesToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<ICSRole> rolesToExport = new List<ICSRole>();

            if (task.allOrgCharts.Any(o => o.OpPeriod == OpPeriodToExport))
            {
                OrganizationChart org = task.allOrgCharts.First(o => o.OpPeriod == OpPeriodToExport);
                foreach( ICSRole role in org.AllRoles.Where(o => o.IsOpGroupSup && !o.IsTFST && o.Active))
                {
                    if (role.RoleID != Globals.AirOpsDirector && role.ReportsTo != Globals.AirOpsDirector)
                    {
                        if (task.AllOperationalGroups.Any(o => !o.IsBranchOrDiv && o.ParentID == role.RoleID)) { rolesToExport.Add(role); }
                        else if (!task.AllOperationalGroups.Any(o => o.ParentID == role.RoleID)) { rolesToExport.Add(role); }
                    }
                }


                foreach (ICSRole sp in rolesToExport)
                {
                    string path = createAssignmentSummaryPDF(task, OpPeriodToExport, sp.RoleID, true, flattenPDF);
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

        public List<byte[]> exportAssignmentListToPDF(WFIncident task, int OpPeriodToExport, Guid DivisionID, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string path = createAssignmentSummaryPDF(task, OpPeriodToExport, DivisionID, true, flattenPDF);
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

        public string createAssignmentSummaryPDF(WFIncident task, int OpPeriod, Guid OpGroupICSRoleID, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            ICSRole div = task.allOrgCharts.FirstOrDefault(o=>o.OpPeriod == OpPeriod).GetRoleByID(OpGroupICSRoleID, false);
            OperationalGroup opGroup = task.AllOperationalGroups.FirstOrDefault(o => o.LeaderICSRoleID == div.RoleID);

            string outputFileName = "ICS 204 - " + task.IncidentIdentifier + " OP " + OpPeriod.ToString()  + " " + div.RoleName + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("ICS-204-WF Assignment List.pdf");
            fileToUse = getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));

                    ICSRole branch = new ICSRole();

                    if(div.RoleID != Globals.OpsChiefID && div.ReportsTo != Globals.OpsChiefID) { branch = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == OpPeriod).GetRoleByID(div.ReportsTo, false); }
                    else { branch = div; }

                    if (task.AllOperationalGroups.Any(o => o.ID == branch.OperationalGroupID))
                    {
                        OperationalGroup branchGroup = task.AllOperationalGroups.First(o => o.ID == branch.OperationalGroupID);
                        stamper.AcroFields.SetField("1 BRANCH", branchGroup.Name);
                    }


                    stamper.AcroFields.SetField("2 DIVISIONGROUPSTAGING", opGroup.Name);


                    OperationalPeriod currentPeriod = task.AllOperationalPeriods.Where(o => o.PeriodNumber == OpPeriod).First();

                    stamper.AcroFields.SetField("3 INCIDENT NAME OR NUMBERRow1", task.IncidentNameOrNumber);


                    stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentPeriod.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", currentPeriod.PeriodEnd));
                    stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentPeriod.PeriodEnd));
                    
                    stamper.AcroFields.SetField("Name", opGroup.PreparedByName);
                    stamper.AcroFields.SetField("Position", opGroup.PreparedByPosition);

                    List<ICSRole> operationalpersonnel = new List<ICSRole>();
                    operationalpersonnel.Insert(0, div);
                    if (div.RoleID != branch.RoleID) { operationalpersonnel.Insert(0, branch); }
                    Guid reportsTo = branch.ReportsTo;
                    while (reportsTo != Globals.IncidentCommanderID)
                    {
                        ICSRole role = branch = task.allOrgCharts.FirstOrDefault(o => o.OpPeriod == OpPeriod).GetRoleByID(reportsTo, false);
                        operationalpersonnel.Insert(0, role);
                        reportsTo = role.ReportsTo;
                    }
                    for (int x = 0; x < 4 && x < operationalpersonnel.Count; x++)
                    {
                        stamper.AcroFields.SetField("5 OPERATIONAL PERSONNEL" + (x + 1), operationalpersonnel[x].RoleName);

                        if (operationalpersonnel[x].IndividualID != Guid.Empty)
                        {
                            stamper.AcroFields.SetField("5 OPERATIONAL PERSONNEL" + (x + 5), operationalpersonnel[x].IndividualName);
                        }
                        
                    }

                    List<IncidentResource> reportingResources = task.GetReportingResources(opGroup.ID);
                    reportingResources.AddRange(task.ActiveOperationalGroups.Where(o => o.ParentID == div.RoleID && !o.IsBranchOrDiv));
                    List<CommsPlanItem> comms = new List<CommsPlanItem>();
                       

                    int assignmentRow = 1;
                    foreach (IncidentResource ta in reportingResources)
                    {
                        if (ta.GetType().Name.Equals("OperationalGroup"))
                        {
                            stamper.AcroFields.SetField("Resource IdentifierRow" + assignmentRow,((OperationalGroup) ta).ResourceName);
                        } else { stamper.AcroFields.SetField("Resource IdentifierRow" + assignmentRow, ta.ResourceName); }
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

                    foreach(Guid g in opGroup.CommsPlanItemIDs)
                    {
                        if(task.allCommsPlans.Any(o=>o.OpsPeriod == OpPeriod) && task.allCommsPlans.First(o=>o.OpsPeriod == OpPeriod).allCommsItems.Any(o=>o.ItemID == g))
                        {
                            comms.Add(task.allCommsPlans.First(o => o.OpsPeriod == OpPeriod).allCommsItems.First(o => o.ItemID == g));
                        }
                    }

                    for (int x = 0; x< comms.Count && x < 4; x++)
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
                    //rdr.Close();    //Close a PDFReader Object
                }
            }
            catch (Exception)
            {
                path = null;
            }
            return path;
        }






        public List<byte[]> exportAllAssignmentDetailsToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<OperationalGroup> groupsToExport = new List<OperationalGroup>();

            if (task.ActiveOperationalGroups.Any(o=>o.OpPeriod == OpPeriodToExport))
            {
                groupsToExport.AddRange(task.ActiveOperationalGroups.Where(o => !o.IsBranchOrDiv && o.OpPeriod == OpPeriodToExport));


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
        public string createAssignmentDetailsPDF(WFIncident task, int OpPeriod, Guid OpGroupID, bool useTempPath, bool flattenPDF)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(task);
            }

            OperationalGroup opGroup = task.AllOperationalGroups.FirstOrDefault(o => o.ID == OpGroupID);

            string outputFileName = "ICS 204A - " + task.IncidentIdentifier + " OP " + OpPeriod.ToString() + " " + opGroup.ResourceName + ".pdf";
            path = FileAccessClasses.getUniqueFileName(outputFileName, path);


            string fileToUse = getPDFFilePath("ICS-204A-WF Assignment Details.pdf");
            fileToUse = getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));
                    OrganizationChart orgChart = new OrganizationChart();
                    if(task.allOrgCharts.Any(o=>o.OpPeriod == OpPeriod))
                    {
                        orgChart = task.allOrgCharts.First(o => o.OpPeriod == OpPeriod);
                        if(orgChart.ActiveRoles.Any(o=>o.RoleID == opGroup.ParentID))
                        {
                            ICSRole div = orgChart.ActiveRoles.First(o => o.RoleID == opGroup.ParentID);
                            stamper.AcroFields.SetField("2 DIVISIONGROUPSTAGING", div.RoleName);
                            if(orgChart.ActiveRoles.Any(o=>o.RoleID == div.ReportsTo))
                            {
                                stamper.AcroFields.SetField("1 BRANCH", orgChart.ActiveRoles.First(o => o.RoleID == div.ReportsTo).RoleName);

                            }
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


                    stamper.AcroFields.SetField("Name", opGroup.PreparedByName);
                    stamper.AcroFields.SetField("Position", opGroup.PreparedByPosition);

                   

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


        public string createBriefingPDF(WFIncident task, Briefing briefing, bool automaticallyOpen = true, bool tempFileName = false)
        {
            throw new NotImplementedException();
        }

        public List<byte[]> exportBriefingToBytes(int OpPeriodToExport, WFIncident task)
        {
            throw new NotImplementedException();
        }

        public string exportBriefingToPDF(Briefing briefing, WFIncident task, bool includeExecution, bool includeMapQRImage = false)
        {
            throw new NotImplementedException();
        }
     
    }
}
