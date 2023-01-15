using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace WildfireICSDesktopServices
{
    public class PDFExportService : IPDFExportService
    {





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





        public List<byte[]> exportIAPToPDF(WFIncident task, int OpPeriodToExport, bool includeBriefing = true, bool includeSafety = true, bool includeLPQ = true, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            GeneralOptionsService service = new GeneralOptionsService();
            GeneralOptions options = service.GetGeneralOptions();

            //fullFilepath = System.IO.Path.Combine(fullFilepath, fullOutputFilename);

            //Lost Person Questionnaire
            if (includeLPQ)
            {
                string lostpath = createLostPersonQuestionnairePDF(task, true, OpPeriodToExport);
                using (FileStream stream = File.OpenRead(lostpath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }







            //org chart

            string orgpath = createOrgChartPDF(task, OpPeriodToExport, false, true, flattenPDF);
            using (FileStream stream = File.OpenRead(orgpath))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }
            if (options.IncludeOrgContactsInIAP)
            {
                string orgContacts = createOrgChartContactList(task, OpPeriodToExport, false, true);
                if (!string.IsNullOrEmpty(orgContacts))
                {
                    using (FileStream stream = File.OpenRead(orgContacts))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }
                }
            }



            if (includeBriefing)
            {
                if (task.allBriefings.Any(o => o.OpPeriod == OpPeriodToExport))
                {

                    allPDFs.AddRange(exportBriefingToBytes(OpPeriodToExport, task));

                }
            }

            string objectivesPath = createObjectivesPDF(task, OpPeriodToExport, false, true, flattenPDF);
            using (FileStream stream = File.OpenRead(objectivesPath))
            {
                byte[] fileBytes = new byte[stream.Length];

                stream.Read(fileBytes, 0, fileBytes.Length);
                stream.Close();
                allPDFs.Add(fileBytes);
            }



            string comPath = createCommsPlanPDF(task, OpPeriodToExport, false, true, flattenPDF);
            if (!string.IsNullOrEmpty(comPath))
            {
                using (FileStream stream = File.OpenRead(comPath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }

            }

            if (options.IncludeOtherContactsWithIAP && task.allContacts.Any())
            {
                //ContactListServices contactListServices = new ContactListServices();
                string preparedByName = null; string preparedByTitle = null;

                if (task.allOrgCharts.Where(o => o.OpPeriod == OpPeriodToExport).Any())
                {
                    OrganizationChart currentChart = task.allOrgCharts.Where(o => o.OpPeriod == OpPeriodToExport).First();
                    preparedByName = currentChart.getNameByRoleName("Logistics Section Chief");
                    preparedByTitle = "Logistics Section Chief";
                }

                string contactsPath = ContactListServices.createContactsPDF(task, OpPeriodToExport, preparedByName, preparedByTitle, false, false);
                if (!string.IsNullOrEmpty(contactsPath))
                {
                    using (FileStream stream = File.OpenRead(contactsPath))
                    {
                        byte[] fileBytes = new byte[stream.Length];

                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();
                        allPDFs.Add(fileBytes);
                    }

                }
            }

            //Medical Plan

            string medPath = createMedicalPlanPDF(task, OpPeriodToExport, false, true, flattenPDF);
            if (medPath != null)
            {
                using (FileStream stream = File.OpenRead(medPath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }


            if (includeSafety && task.allSafetyMessages.Where(o => o.OpPeriod == OpPeriodToExport).Any())
            {
                allPDFs.AddRange(exportSafetyMessagesToPDF(task, OpPeriodToExport, flattenPDF));
            }

            return allPDFs;

        }

       

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




                    string fileToUse = "BlankForms/ICS-213-WF-General-Message.pdf";
                    PdfReader rdr = new PdfReader(fileToUse);

                    using (FileStream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                    {
                        PdfStamper stamper = new PdfStamper(rdr, stream);
                        stamper.AcroFields.SetField("1A INCIDENT NAME Optional", task.TaskName);
                        stamper.AcroFields.SetField("1B INCIDENT NUMBER", task.TaskNumber);
                        stamper.AcroFields.SetField("4 SUBJECT", item.Subject);
                        stamper.AcroFields.SetField("7 MESSAGE", item.Message);
                        string date = string.Format("{0:yyyy-MMM-dd}", item.DateSent);
                        stamper.AcroFields.SetField("5 DATE", string.Format("{0:yyyy-MMM-dd}", item.DateSent));
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
                        stamper.AcroFields.SetField("ReplyDate", string.Format("{0:yyyy-MMM-dd HH:mm}", item.ReplyDate));





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



                    string fileToUse = "BlankForms/ICS-208-WF-Safety-Message.pdf";
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


                        stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                        stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
                        stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                        stamper.AcroFields.SetField("Text1", string.Format("{0:HH:mm}", currentOp.PeriodEnd));






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

                string fileToUse = "BlankForms/ICS-206-WF-Medical-Plan.pdf";



                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));



                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1B INCIDENT NUMBER", task.TaskNumber);
                stamper.AcroFields.SetField("1A INCIDENT NAME", task.TaskName);


                stamper.AcroFields.SetField("1B INCIDENT NUMBERDate From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
                stamper.AcroFields.SetField("1B INCIDENT NUMBERTime From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));




                //This will check with the org chart to see if an individual has been assigned, assuming the name is vacant right now
                if (plan.PreparedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.PreparedBy) && currentChart.AllRoles.Any(o => o.RoleID == plan.PreparedByRoleID))
                {
                    ICSRole role = currentChart.AllRoles.First(o => o.RoleID == plan.PreparedByRoleID);
                    plan.PreparedBy = role.IndividualName;
                }
                stamper.AcroFields.SetField("Name", plan.PreparedBy);
                stamper.AcroFields.SetField("Position", plan.PreparedByPosition);

                //This will check with the org chart to see if an individual has been assigned, assuming the name is vacant right now
                if (plan.ApprovedByRoleID != Guid.Empty && string.IsNullOrEmpty(plan.ApprovedBy) && currentChart.AllRoles.Any(o => o.RoleID == plan.ApprovedByRoleID))
                {
                    ICSRole role = currentChart.AllRoles.First(o => o.RoleID == plan.ApprovedByRoleID);
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

                string fileToUse = "BlankForms/ICS205WF-Communications-Plan.pdf";
                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));

                OperationalPeriod currentOp = task.AllOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == plan.OpsPeriod);

                //Op Plan
                DateTime today = DateTime.Now;
                //Top Section
                stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentIdentifier);
                stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
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
                    stamper.AcroFields.SetField("RxTx FrequencyRow" + (row + 1), item.Frequency);
                    stamper.AcroFields.SetField("ToneRow" + (row + 1), item.Tone);
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




        public string createObjectivesPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false)
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
                    string fileToUse = "BlankForms/ICS-202-WF-Incident-Objectives.pdf";
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
                    stamper.AcroFields.SetField("2 DATE PREPARED", string.Format("{0:yyyy-MMM-dd HH:mm}", currentSheet.DatePrepared));
                    stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                    stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
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
            else { return null; }
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

                string fileToUse = "BlankForms/ICS-207-WF-Organization-Chart.pdf";
                if (currentChart.IsUnifiedCommand) { fileToUse = "BlankForms/ICS-207-WF Incident Organization Chart Unified.pdf"; }

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(path, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {

                            
                            int TotalPages = currentChart.CalculateOrgChartPageCount();

                            stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentNameOrNumber);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", currentOp.PeriodEnd));

                            ICSRole PreparedBy = new ICSRole();
                            if(currentChart.PreparedByUserID != Guid.Empty)
                            {
                                PreparedBy.teamMember = new TeamMember(currentChart.PreparedByUserID);
                                PreparedBy.teamMember.Name = currentChart.PreparedBy;
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


                            foreach (ICSRole role in currentChart.AllRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
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
                string fileToUse = "BlankForms/ICS-207-WF-Organization-Chart-Extension.pdf";


                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(path, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {



                            stamper.AcroFields.SetField("1 INCIDENT NAME AND NUMBERRow1", task.IncidentIdentifier);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodStart));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:yyyy-MMM-dd}", currentOp.PeriodEnd));
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

                if (chart.AllRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)).Any())
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


                            if (chart.GetRoleByID(Globals.IncidentCommanderID).teamMember != null)
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
                            if (chart.AllRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)).Count() <= 5)
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
                                foreach (ICSRole role in chart.AllRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)))
                                {
                                    table.AddCell(role.RoleName);
                                    table.AddCell(role.IndividualName);
                                    string contactInfo = null;
                                    if (!string.IsNullOrEmpty(role.teamMember.Phone)) { contactInfo = role.teamMember.Phone.FormatPhone(); }
                                    if (!string.IsNullOrEmpty(role.teamMember.Email))
                                    {
                                        if (!string.IsNullOrEmpty(contactInfo)) { contactInfo += Environment.NewLine; }
                                        contactInfo += role.teamMember.Email;
                                    }
                                    table.AddCell(contactInfo);
                                }

                                document.Add(table);
                            }
                            else //large compelx org chart, break it down by section
                            {
                                List<Guid> branches = new List<Guid>();
                                foreach (ICSRole role in chart.AllRoles.Where(o => !string.IsNullOrEmpty(o.IndividualName)))
                                {
                                    Guid branchid = role.BranchID;
                                    if (!branches.Contains(branchid)) { branches.Add(branchid); }
                                }

                                foreach (Guid branch in branches)
                                {
                                    string branchName = chart.AllRoles.Where(o => o.RoleID == branch).First().RoleName;
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
                                    foreach (ICSRole role in chart.AllRoles.Where(o => o.BranchID == branch && !string.IsNullOrEmpty(o.IndividualName)))
                                    {
                                        iTextSharp.text.Font fonttoUse = normalfont;
                                        if (role.RoleID == branch) { fonttoUse = subsectionfont; }

                                        table.AddCell(new Phrase(role.RoleName, fonttoUse));
                                        table.AddCell(new Phrase(role.IndividualName, fonttoUse));
                                        string contactInfo = null;
                                        if (!string.IsNullOrEmpty(role.teamMember.Phone)) { contactInfo = role.teamMember.Phone.FormatPhone(); }
                                        if (!string.IsNullOrEmpty(role.teamMember.Email))
                                        {
                                            if (!string.IsNullOrEmpty(contactInfo)) { contactInfo += Environment.NewLine; }
                                            contactInfo += role.teamMember.Email;
                                        }
                                        table.AddCell(contactInfo);
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



        private string createLostPersonQuestionnairePDF(WFIncident task, bool tempFileName = false, int OpPeriodToExport = 0)
        {

            string path = FileAccessClasses.getWritablePath(task);
            if (!tempFileName)
            {


                if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }

                string outputFileName = "ICS 302 - Task " + task.TaskNumber + " - Op " + OpPeriodToExport + " - Lost Person Questionnaire";
                path = FileAccessClasses.getUniqueFileName(outputFileName, path);

                //path = System.IO.Path.Combine(path, outputFileName);
            }
            else
            {
                path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            }

            try
            {


                OrganizationChart currentChart = new OrganizationChart();
                if (task.allOrgCharts.Where(o => o.OpPeriod == OpPeriodToExport).Any())
                {
                    currentChart = task.allOrgCharts.Where(o => o.OpPeriod == OpPeriodToExport).First();
                }


                string fileToUse = "ICSForms/ICS 302 - Lost Person Questionaire.pdf";


                PdfReader rdr = new PdfReader(fileToUse);
                PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, System.IO.FileMode.Create));


                //Op Plan

                //Top Section
                stamper.AcroFields.SetField("302TASK", task.TaskNumber);
                stamper.AcroFields.SetField("302TASK NAME", task.TaskName);

                stamper.AcroFields.SetField("302DATE  TIME PREPARED", string.Format(Globals.cultureInfo, "{0:yyyy-MMM-dd HH:mm}", DateTime.Now));
                stamper.AcroFields.SetField("INTERVIEWED BY PLANNING", currentChart.getNameByRoleName("Planning Section Chief"));
                stamper.AcroFields.SetField("302POLICEBCAS FILE", task.AgencyFileNumber);


                AcroFields af = stamper.AcroFields;

                List<string> fieldNames = new List<string>();
                foreach (var field in af.Fields)
                {
                    fieldNames.Add(field.Key);
                }
                foreach (string s in fieldNames)
                {
                    stamper.AcroFields.RenameField(s, s + "-302");
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



        public List<byte[]> exportBriefingToBytes(int OpPeriodToExport, WFIncident task)
        {
            List<byte[]> allPDFs = new List<byte[]>();
            if (task.allBriefings.Any(o => o.OpPeriod == OpPeriodToExport))
            {
                Briefing selectedBriefing = task.allBriefings.First(o => o.OpPeriod == OpPeriodToExport);
                string briefingPath = exportBriefingToPDF(selectedBriefing, task, true);
                using (FileStream stream = File.OpenRead(briefingPath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }
            return allPDFs;
        }


        public string createBriefingPDF(WFIncident task, Briefing briefing, bool automaticallyOpen = true, bool tempFileName = false)
        {
            string path = null;
            if (task != null && briefing != null)
            {
                Guid ExecutionSectionID = new Guid("5f6a9484-9f56-4baa-a1b6-43dacd1fe6b8");
                path = FileAccessClasses.getWritablePath(task);
                if (!tempFileName)
                {




                    if (task.DocumentPath == null && path != null) { task.DocumentPath = path; }
                    string outputFileName = "Briefing Op Period " + briefing.OpPeriod;
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

                        OrganizationChart chart = new OrganizationChart();
                        if (task.allOrgCharts.Where(o => o.OpPeriod == briefing.OpPeriod).Any())
                        {
                            chart = task.allOrgCharts.Where(o => o.OpPeriod == briefing.OpPeriod).First();
                        }

                        document.AddAuthor(chart.getNameByRoleName("SAR Manager"));

                        TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
                        writer.PageEvent = PageEventHandler;
                        // Define the page header
                        PageEventHandler.Title = "";
                        //PageEventHandler.Title = "Task Number " + CurrentTask.TaskNumber + " - " + CurrentTask.TaskName + " Op Period " + selectedBriefing.OpPeriod.ToString();
                        PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, iTextSharp.text.Font.BOLD);


                        document.AddTitle("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + briefing.OpPeriod.ToString());

                        // Open the document to enable you to write to the document

                        document.Open();
                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                        iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                        iTextSharp.text.Font notefont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK);

                        // Add a simple and wellknown phrase to the document in a flow layout manner
                        //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                        Anchor briefingTarget = new Anchor("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + briefing.OpPeriod.ToString(), titlefont);
                        briefingTarget.Name = "Briefing";
                        Paragraph tp = new Paragraph();
                        tp.Add(briefingTarget);
                        tp.Font = titlefont;

                        document.Add(tp);

                        foreach (BriefingSection section in briefing.AllSections)
                        {
                            List<BriefingItem> subSections = section.allItems.Where(o => !string.IsNullOrEmpty(o.itemValue)).GroupBy(o => o.subSectionName).Select(grp => grp.First()).ToList();

                            document.Add(new Paragraph(section.sectionName, sectionfont));
                            foreach (BriefingItem ss in subSections)
                            {
                                if (section.allItems.Where(o => o.subSectionName == ss.subSectionName).Count() > 1)
                                {
                                    document.Add(new Paragraph(ss.subSectionName, subsectionfont));
                                }

                                foreach (BriefingItem bi in section.allItems.Where(o => o.subSectionName == ss.subSectionName))
                                {
                                    if (!string.IsNullOrEmpty(bi.itemValue))
                                    {
                                        Paragraph p1 = new Paragraph(bi.itemName + " -- " + bi.itemValue, normalfont);
                                        p1.IndentationLeft = 10;
                                        document.Add(p1);

                                        //if this is a map URL, lets make a QR
                                        /*
                                        if (bi.BriefingFieldID == new Guid("8536d309-d946-44ad-9a86-1fe77336c17c"))
                                        {
                                            Paragraph p2 = new Paragraph("Scan the QR code below to load the map", notefont);
                                            p2.IndentationLeft = 40;
                                            document.Add(p2);

                                            Bitmap mapQR = briefing.MapQRCode(bi.itemValue.Trim(), 100);
                                            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(mapQR, System.Drawing.Imaging.ImageFormat.Jpeg);



                                            pic.Border = iTextSharp.text.Rectangle.BOX;
                                            pic.BorderColor = iTextSharp.text.BaseColor.BLACK;
                                            pic.BorderWidth = 1f;
                                            pic.IndentationLeft = 40;

                                            document.Add(pic);
                                        }*/
                                    }
                                }
                            }

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

                }
                catch (Exception)
                {

                }
            }
            return path;
        }

        public string exportBriefingToPDF(Briefing briefing, WFIncident task, bool includeExecution, bool includeMapQRImage = false)
        {
            Guid ExecutionSectionID = new Guid("5f6a9484-9f56-4baa-a1b6-43dacd1fe6b8");
            Guid MissionSectionID = new Guid("440c3692-da5a-49d3-a01c-073d33a4ef1f");
            string path = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            using (System.IO.FileStream fs = new FileStream(path, FileMode.Create))
            {
                // Create an instance of the document class which represents the PDF document itself.
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                // Create an instance to the PDF file by creating an instance of the PDF 
                // Writer class using the document and the filestrem in the constructor.



                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                document.AddAuthor(task.PlansChief(briefing.OpPeriod));

                TwoColumnHeaderFooter PageEventHandler = new TwoColumnHeaderFooter();
                writer.PageEvent = PageEventHandler;
                // Define the page header
                PageEventHandler.Title = "";
                //PageEventHandler.Title = "Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + selectedBriefing.OpPeriod.ToString();
                PageEventHandler.HeaderFont = FontFactory.GetFont(BaseFont.COURIER_BOLD, 10, iTextSharp.text.Font.BOLD);


                document.AddTitle(task.TaskNumber + " - " + task.TaskName + " Op Period " + briefing.OpPeriod.ToString());

                // Open the document to enable you to write to the document

                document.Open();
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font italicFont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.DARK_GRAY);
                iTextSharp.text.Font notefont = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLACK);

                // Add a simple and wellknown phrase to the document in a flow layout manner
                document.Add(new Paragraph(task.TaskNumber + " | " + task.TaskName + " | Op #" + briefing.OpPeriod.ToString(), titlefont));

                GeneralOptionsService service = new GeneralOptionsService();
                GeneralOptions options = service.GetGeneralOptions();

                foreach (BriefingSection section in briefing.AllSections)
                {
                    if (!includeExecution && section.sectionID == ExecutionSectionID)
                    {
                        document.Add(new Paragraph(section.sectionName, sectionfont));
                        if (options.LeaveSpaceIn204SMEAC)
                        {
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                        }
                        else
                        {
                            document.Add(new Paragraph(" TBD", italicFont));
                        }
                    }
                    else if (!includeExecution && section.sectionID == MissionSectionID)
                    {
                        document.Add(new Paragraph(section.sectionName, sectionfont));
                        if (options.LeaveSpaceIn204SMEAC)
                        {
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                            document.Add(new Paragraph(" "));
                        }
                        else
                        {
                            document.Add(new Paragraph(" TBD", italicFont));
                        }
                    }
                    else
                    {
                        List<BriefingItem> subSections = section.allItems.Where(o => !string.IsNullOrEmpty(o.itemValue)).GroupBy(o => o.subSectionName).Select(grp => grp.First()).ToList();
                        document.Add(new Paragraph(section.sectionName, sectionfont));
                        foreach (BriefingItem ss in subSections)
                        {
                            if (section.allItems.Where(o => o.subSectionName == ss.subSectionName).Count() > 1)
                            {
                                document.Add(new Paragraph(ss.subSectionName, subsectionfont));
                            }

                            foreach (BriefingItem bi in section.allItems.Where(o => o.subSectionName == ss.subSectionName))
                            {
                                if (!string.IsNullOrEmpty(bi.itemValue))
                                {
                                    Paragraph p1 = new Paragraph(bi.itemName + " -- " + bi.itemValue, normalfont);
                                    p1.IndentationLeft = 10;
                                    document.Add(p1);


                                }
                            }
                        }
                    }

                }
                // Close the document

                document.Close();
                // Close the writer instance

                writer.Close();
                // Always close open filehandles explicity

            }
            return path;
        }

        public string exportSinglePageSignInSheetAsPDF(WFIncident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
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
                stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:yyyy-MMM-dd HH:mm}", statuses.OrderBy(o => o.SignInTime).First().SignInTime));
                if (statuses.Any(o => o.SignOutTime < DateTime.MaxValue))
                {
                    stamper.AcroFields.SetField("PeriodTo", string.Format("{0:yyyy-MMM-dd HH:mm}", statuses.Where(o => o.SignOutTime < DateTime.MaxValue).OrderByDescending(o => o.SignOutTime).First().SignOutTime));
                }
                stamper.AcroFields.SetField("GROUP NAME", statuses[0].OrganizationName);
            }



            stamper.AcroFields.SetField("PAGE", pageNumber.ToString());

            double totalHours = 0;
            decimal totalKMs = 0;

            for (int x = 0; x < statuses.Count; x++)
            {
                MemberStatus status = statuses[x];
                TeamMember member = new TeamMember();
                if (status.MemberID != Guid.Empty && task.TaskTeamMembers.Any(o => o.PersonID == status.MemberID)) { member = task.TaskTeamMembers.First(o => o.PersonID == status.MemberID); }

                stamper.AcroFields.SetField("Name" + (x + 1).ToString(), status.MemberName);
                stamper.AcroFields.SetField("Address" + (x + 1).ToString(), member.AddressWithPhone);


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
                        stamper.AcroFields.SetField("PeriodFrom", string.Format("{0:yyyy-MMM-dd HH:mm}", statuses.OrderBy(o => o.SignInTime).First().SignInTime));
                        if (statuses.Any(o => o.SignOutTime < DateTime.MaxValue))
                        {
                            stamper.AcroFields.SetField("PeriodTo", string.Format("{0:yyyy-MMM-dd HH:mm}", statuses.Where(o => o.SignOutTime < DateTime.MaxValue).OrderByDescending(o => o.SignOutTime).First().SignOutTime));
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
                        TeamMember member = new TeamMember();
                        if (status.MemberID != Guid.Empty && task.TaskTeamMembers.Where(o => o.PersonID == status.MemberID).Any()) { member = task.TaskTeamMembers.Where(o => o.PersonID == status.MemberID).First(); }
                        else if (status.MemberID != Guid.Empty && task.getTaskTeamMembers(options.AllTeamMembers, false, false, OpsPeriod).Where(o => o.PersonID == status.MemberID).Any())
                        {
                            member = task.getTaskTeamMembers(options.AllTeamMembers, false, false, OpsPeriod).Where(o => o.PersonID == status.MemberID).First();
                        }
                        stamper.AcroFields.SetField("Name" + (x + 1).ToString(), status.MemberName);
                        stamper.AcroFields.SetField("Address" + (x + 1).ToString(), member.AddressWithPhone);



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
                                document.Add(new Paragraph(date.ToString("yyyy-MMM-dd", Globals.cultureInfo), subsectionfont));

                                foreach (TimelineEvent ev in eventsIncluded.Where(o => o.EventDateTime.Year == date.Year && o.EventDateTime.Month == date.Month && o.EventDateTime.Day == date.Day))
                                {
                                    Paragraph p1 = new Paragraph(ev.EventDateTime.ToString("HH:mm", Globals.cultureInfo) + " -- " + ev.EventName + " - " + ev.EventText, normalfont);
                                    p1.IndentationLeft = 10;
                                    document.Add(p1);
                                }
                            }
                            else if (x < totalDays)
                            {
                                document.Add(new Paragraph(date.ToString("yyyy-MMM-dd", Globals.cultureInfo), subsectionfont));
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

        public List<byte[]> createSinglePageBlankSignInSheetAsBytes(WFIncident task, GroupSignInPrintRequest group, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempFileName();

            string fileToUse = "ICSForms/ICS 211 - Check In List.pdf";
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


        public List<byte[]> createOpPeriodContentsList(WFIncident task, List<string> items, int OpPeriod)
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
                    document.AddTitle("Task Number " + task.TaskNumber + " - " + task.TaskName + " Op Period " + OpPeriod.ToString(Globals.cultureInfo));
                }
                else { document.AddTitle("Task Number " + task.TaskNumber + " - " + task.TaskName); }
                // Open the document to enable you to write to the document

                document.Open();
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                iTextSharp.text.Font titlefont = new iTextSharp.text.Font(bfTimes, 22, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font sectionfont = new iTextSharp.text.Font(bfTimes, 20, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font subsectionfont = new iTextSharp.text.Font(bfTimes, 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                iTextSharp.text.Font normalfont = new iTextSharp.text.Font(bfTimes, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

                // Add a simple and wellknown phrase to the document in a flow layout manner
                //Chapter chapter1 = new Chapter(new Paragraph("Briefing"), 1);
                Anchor briefingTarget = new Anchor("Task Number " + task.TaskNumber + " - " + task.TaskName, titlefont);
                briefingTarget.Name = "Index";
                Paragraph tp = new Paragraph();
                tp.Add(briefingTarget);
                tp.Font = titlefont;

                document.Add(tp);

                if (!string.IsNullOrEmpty(task.AgencyFileNumber))
                {
                    document.Add(new Paragraph("Agency File #" + task.AgencyFileNumber, subsectionfont));
                }
                if (OpPeriod > 0)
                {
                    document.Add(new Paragraph("Operational Period #" + OpPeriod.ToString(Globals.cultureInfo), subsectionfont));
                }
                else
                {
                    document.Add(new Paragraph("As of " + DateTime.Now.ToString("yyyy-MMM-dd"), subsectionfont));
                }
                document.Add(new Paragraph(" "));

                string logoPath = null;
                GeneralOptionsService generalOptionsService = new GeneralOptionsService(true);

                Organization org = (Organization)generalOptionsService.GetOptionsValue("SARGroup");
                if (org != null && org.OrganizationID != Guid.Empty && !string.IsNullOrEmpty(org.LogoFileName))
                {
                    logoPath = "SARGroupLogos/" + org.LogoFileName;
                }
                else
                {
                    logoPath = "SARGroupLogos/BCSARA-Logo-960.png";
                }

                //Picture
                if (!string.IsNullOrEmpty(logoPath))
                {
                    //iTextSharp.text.Document doc = new iTextSharp.text.Document();
                    try
                    {
                        if (File.Exists(logoPath))
                        {
                            iTextSharp.text.Image tif = iTextSharp.text.Image.GetInstance(logoPath);

                            tif.ScaleToFit(315, 220);
                            float x = ((315 - tif.ScaledWidth) / 2) + 263;
                            tif.SetAbsolutePosition(x, 400);

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



                        document.Add(new Paragraph("Created: " + note.DateCreated.ToString("yyyy-MMM-dd HH:mm", Globals.cultureInfo), subsectionfont));
                        document.Add(new Paragraph("Updated: " + note.DateUpdated.ToString("yyyy-MMM-dd HH:mm", Globals.cultureInfo), subsectionfont));

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

    }
}
