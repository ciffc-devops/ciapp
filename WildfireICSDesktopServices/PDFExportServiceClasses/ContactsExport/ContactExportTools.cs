using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;



namespace WildfireICSDesktopServices.PDFExportServiceClasses.ContactsExport
{
    public static class ContactExportTools
    {
        public static int MaxContactsPerPage = 34;
        private static string DateFormat { get; set; } = "MMM-dd-yyyy";

        public static void SetDateFormat(string str)
        {
            if (!string.IsNullOrEmpty(str)) { DateFormat = str; }
            else { DateFormat = "MMM-dd-yyyy"; }
        }

        public static string ExportExtraContactListToPDF(Incident incident, int OperationalPeriodToExport, bool useTempPath = false, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempPath();
            if (!useTempPath)
            {
                path = FileAccessClasses.getWritablePath(incident);
            }

          
            ContactExportHeader header = new ContactExportHeader();
            header.IncidentName = incident.IncidentNameOrNumber;
            OperationalPeriod op = incident.AllOperationalPeriods.FirstOrDefault(o => o.Active && o.PeriodNumber == OperationalPeriodToExport);
            header.PreparedDate = DateTime.Now;
            if (op != null)
            {
                header.StartDate = op.PeriodStart;
                header.EndDate = op.PeriodEnd;
            }
            else { return null;            }

            List<ContactExportEntry> entries = new List<ContactExportEntry>();
            foreach(Contact c in incident.allContacts)
            {
                if (c.Active &&!string.IsNullOrEmpty( c.ContactName))
                {
                    ContactExportEntry entry = new ContactExportEntry(c);
                    entries.Add(entry);
                }
            }

            return ExportContactListToPDF(path, header, entries, flattenPDF);

        }

        public static List<byte[]> ExportContactListToByteArray(string SavePath, ContactExportHeader header, List<ContactExportEntry> entries, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();

            string finalPath = ExportContactListToPDF(SavePath, header, entries, flattenPDF);

            if (finalPath != null)
            {
                using (FileStream stream = File.OpenRead(finalPath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }
        public static List<byte[]> ExportOrgChartContactListToByteArray(Incident incident, int OperationalPeriodToExport, bool flattenPDF = false)
        {
            List<byte[]> allPDFs = new List<byte[]>();
            OrganizationChart orgChart = incident.allOrgCharts.FirstOrDefault(o => o.Active && o.OpPeriod == OperationalPeriodToExport);
            OperationalPeriod period = incident.AllOperationalPeriods.FirstOrDefault(o=>o.Active && o.PeriodNumber == OperationalPeriodToExport);
            ContactExportHeader header = new ContactExportHeader(orgChart);
            header.IncidentName = incident.IncidentNameOrNumber;
            header.StartDate = period.PeriodStart;
            header.EndDate = period.PeriodEnd;

            List<ContactExportEntry> entries = GetEntriesFromOrgChart(orgChart, incident.IncidentPersonnel);

            string path = System.IO.Path.GetTempPath();
           

            string finalPath = ExportContactListToPDF(path, header, entries, flattenPDF);

            if (finalPath != null)
            {
                using (FileStream stream = File.OpenRead(finalPath))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }
            }

            return allPDFs;
        }

        public static string ExportContactListToPDF(string SavePath, ContactExportHeader header, List<ContactExportEntry> entries,  bool flattenPDF = false)
        {
            string path = SavePath;

            string outputFileName = "ICS 205A - " + header.IncidentName + " - Communications List " + header.StartDate.ToString("yyyy-MMM-dd");
            outputFileName = outputFileName.ReplaceInvalidPathChars();

            path = FileAccessClasses.getUniqueFileName(outputFileName, path);
            List<ContactExportEntry> entriesToExport = new List<ContactExportEntry>(entries);

            entries = entries.OrderBy(o => o.Name).ToList();

            List<string> paths = new List<string>();

            while (entriesToExport.Any())
            {
                List<ContactExportEntry> pageEntries = entriesToExport.Take(MaxContactsPerPage).ToList();
                string pagePath = GenerateContactPageForExport(header, pageEntries, flattenPDF);
                if (string.IsNullOrEmpty(pagePath)) { continue; }
                paths.Add(pagePath);
                entriesToExport.RemoveRange(0, pageEntries.Count);
            }
           
            _ = PDFExtraTools.MergePDFs(paths, path, flattenPDF);
            return path;
        }

        private static string GenerateContactPageForExport(ContactExportHeader header, List<ContactExportEntry> entries, bool flattenPDF = false)
        {
            string path = System.IO.Path.GetTempPath();


            path = Path.Combine(path, Guid.NewGuid().ToString() + ".pdf");


            string fileToUse = PDFExtraTools.getPDFFilePath("ICS205A-CommunicationsList.pdf");
            fileToUse = PDFExtraTools.getPDFFilePath(fileToUse);
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create));





                    stamper.AcroFields.SetField("1 Incident Name", header.IncidentName);


                    stamper.AcroFields.SetField("Text44", string.Format("{0:" + DateFormat + " HH:mm}", header.StartDate));
                    stamper.AcroFields.SetField("Text45", string.Format("{0:" + DateFormat + " HH:mm}", header.EndDate));
                    stamper.AcroFields.SetField("Text48", string.Format("{0:" + DateFormat + " HH:mm}", header.PreparedDate));
                    stamper.AcroFields.SetField("Name", header.PreparedByIndividualName);
                    stamper.AcroFields.SetField("Text46", header.PreparedByRoleName);

                    for (int x = 0; x < entries.Count && x < MaxContactsPerPage; x++)
                    {
                        //
                        stamper.AcroFields.SetField("Incident Assigned PositionRow" + (x + 1), entries[x].Position);
                        stamper.AcroFields.SetField("ContactName" + (x + 1), entries[x].Name);
                        stamper.AcroFields.SetField("Methods of Contact phone pager cell etcRow" + (x + 1), entries[x].ContactMethodsFullString);
                    }

                    stamper.RenameAllFields();

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

        private static List<ContactExportEntry> GetEntriesFromOrgChart(OrganizationChart orgChart, List<Personnel> personnel)
        {
            List<ContactExportEntry> entries = new List<ContactExportEntry>();
            if (orgChart == null) { return entries; }
            foreach(ICSRole role in orgChart.ActiveRoles)
            {
                if (role == null) { continue; }
                if (role.IndividualID == Guid.Empty) { continue; }
                Personnel person = personnel.FirstOrDefault(p => p.ID == role.IndividualID);
                if (person == null) { continue; }
                

                ContactExportEntry entry = new ContactExportEntry(role, person);
                entries.Add(entry);
            }
            return entries;
        }
    }
}
