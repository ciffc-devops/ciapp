using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;

using WildfireICSDesktopServices.Logging;
using WildfireICSDesktopServices.OrgChartExport;
using static iTextSharp.text.pdf.codec.TiffWriter;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace WildfireICSDesktopServices.OrgChartExport
{
    public static class OrgChartExportTools
    {
        public static int ChildrenPerExtensionPage = 4;
        public static int GrandchildrenPerExtensionPage = 5;

        private static string DateFormat { get; set; } = "MMM-dd-yyyy";

        public static void SetDateFormat(string str)
        {
            if (!string.IsNullOrEmpty(str)) { DateFormat = str; }
            else { DateFormat = "MMM-dd-yyyy"; }
        }

        public static List<byte[]> exportOrgChartToByteArray(this Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            List<byte[]> allPDFs = new List<byte[]>();

           string finalPath = exportOrgChartToPDF(task, OpPeriodToExport, flattenPDF);

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

        public static string exportOrgChartToPDF(this Incident task, int OpPeriodToExport, bool flattenPDF)
        {
            OrgChartForExport orgChart = task.CreateOrgChartForExport(OpPeriodToExport);

            List<string> paths = new List<string>();
            paths.Add(GeneratePageOnePDF(orgChart.PageOne, orgChart.TotalPages));
            for (int x = 0; x < orgChart.ExtensionPages.Count; x++)
            {
                paths.Add(GenerateExtensionPagePDF(orgChart.ExtensionPages[x], orgChart.TotalPages));
            }

            string finalPath = Path.Combine(FileAccessClasses.getWritablePath(task), "ICS-207 Org Chart.pdf");
            _ = PDFExtraTools.MergePDFs(paths, finalPath, flattenPDF);

            return finalPath;
        }

        public static OrgChartForExport CreateOrgChartForExport(this Incident incident, int OperationalPeriodNumber)
        {
            OrgChartForExport orgChart = new OrgChartForExport();
            OrganizationChart organizationChart = incident.activeOrgCharts.FirstOrDefault(o => o.Active && o.OpPeriod == OperationalPeriodNumber);
            List<ICSRole> unPrintedRoles = new List<ICSRole>(organizationChart.ActiveRoles);

            orgChart.PageOne = CreateOrgChartPageOneForExport(incident, OperationalPeriodNumber);
            unPrintedRoles = unPrintedRoles.removePrintedRoles(orgChart.PageOne);

            while (unPrintedRoles.Any())
            {
                //determine which roles on the current chart have unprinted children
                OrgChartEntry startingEntry = null;
            
                ICSRole startingRole = null;
                //check page one
                startingEntry = orgChart.PageOne.GetEntryByRoleID(unPrintedRoles.First().ReportsTo);
                if(startingEntry == null)
                {
                    foreach (OrgChartExtensionPage ext in orgChart.ExtensionPages)
                    {
                        startingEntry = ext.GetEntryByRoleID(unPrintedRoles.First().ReportsTo);
                        if(startingEntry != null) { break; }
                    }
                }

                if(startingEntry != null)
                {
                    startingRole = organizationChart.ActiveRoles.First(o => o.RoleID == startingEntry.RoleID);
                }

            
                if (startingEntry == null || startingRole == null)
                {
                    throw new Exception("Unable to find starting role for OrgChartExport.  This should never happen.");
                }

                //determine which roles will be added to the next page
                List<ICSRole> rolesToAdd = new List<ICSRole>();
                List<ICSRole> childRoles = unPrintedRoles.Where(o => o.ReportsTo == startingRole.RoleID).ToList();
                for(int x= 0; x < ChildrenPerExtensionPage && x < childRoles.Count; x++)
                {
                    rolesToAdd.Add(childRoles[x]);
                    List<ICSRole> grandChildren = unPrintedRoles.Where(o => o.ReportsTo == childRoles[x].RoleID).ToList();
                    for (int y = 0; y < GrandchildrenPerExtensionPage && y < grandChildren.Count; y++)
                    {
                        rolesToAdd.Add(grandChildren[y]);
                    }
                }

                //generate that OrgChartExtension page
                OrgChartExtensionPage page = CreateOrgChartExtensionPageForExport(startingRole, rolesToAdd, orgChart.PageOne);
                page.PageNumber = orgChart.TotalPages + 1;
                startingEntry.AddSeePageIfNeeded(page.PageNumber);
                orgChart.ExtensionPages.Add(page);
                unPrintedRoles = unPrintedRoles.removePrintedRoles(page);
            }


            return orgChart;
        }



        private static OrgChartPageOne CreateOrgChartPageOneForExport(Incident incident, int OperationalPeriodNumber)
        {
            OrgChartPageOne page = new OrgChartPageOne();
            int OfficerSpacesOnPage = 3;
            int OpsChildrenOnPage = 5;
            int PlansChildrenOnPage = 4;
            int FinanceChildrenOnPage = 4;
            int LogisticsChildrenOnPage = 2;
            int LogisticsGrandChildrenOnPage = 3;


            OperationalPeriod period = incident.AllOperationalPeriods.FirstOrDefault(o => o.Active && o.PeriodNumber == OperationalPeriodNumber);
            OrganizationChart organizationChart = incident.activeOrgCharts.FirstOrDefault(o => o.Active && o.OpPeriod == OperationalPeriodNumber);

            if (period != null)
            {
                page.StartDate = period.PeriodStart;
                page.EndDate = period.PeriodEnd;
            }
            page.IncidentName = incident.TaskName;
            page.IncidentNumber = incident.TaskNumber;
            page.PreparedByRoleName = organizationChart.PreparedByRoleName;
            page.PreparedByIndividualName = organizationChart.PreparedByResourceName;
            page.DatePrepared = organizationChart.DatePrepared;

            for (int x = 0; x < OfficerSpacesOnPage && x < organizationChart.IncidentCommanders.Count; x++)
            {
                page.IncidentCommanders[x] = new OrgChartEntry(organizationChart.IncidentCommanders[x]);
                if (page.IncidentCommanders[x] != null)
                {
                    Personnel p = incident.IncidentPersonnel.FirstOrDefault(o => o.ID == organizationChart.IncidentCommanders[x].IndividualID);
                    if (p != null) { page.IncidentCommanders[x].AgencyName = p.AgencyName; }
                }
            }


            page.LiaisonOfficer = new OrgChartEntry(organizationChart.GetRoleByID(Globals.LiaisonOfficerGenericID, false));
            page.SafetyOfficer = new OrgChartEntry(organizationChart.GetRoleByID(Globals.SafetyOfficerGenericID, false));
            page.PublicInformationOfficer = new OrgChartEntry(organizationChart.GetRoleByID(Globals.InformationOfficerGenericID, false));

            List<ICSRole> reportingRoles = organizationChart.ActiveRoles.Where(o => Globals.SectionChiefGenericIDs.Contains(o.GenericRoleID)).ToList();
            for (int x = 0; x < 4 && x < reportingRoles.Count; x++)
            {

                page.Entries[x] = new OrgChartEntry[9];
                page.Entries[x][0] = new OrgChartEntry(reportingRoles[x]);

                List<ICSRole> grandChildRoles = organizationChart.ActiveRoles.Where(o => o.ReportsTo == reportingRoles[x].RoleID).ToList();
                int gcRoles = 0;
                int ggcRoles = 0;
                switch(reportingRoles[x].GenericRoleID)
                {
                    case var id when id == Globals.OpsChiefGenericID:
                        gcRoles = OpsChildrenOnPage;
                        break;
                    case var id when id == Globals.PlanningChiefGenericID:
                        gcRoles = PlansChildrenOnPage;
                        break;
                    case var id when id == Globals.FinanceChiefGenericID:
                        gcRoles = FinanceChildrenOnPage;
                        break;
                    case var id when id == Globals.LogisticsChiefGenericID:
                        gcRoles = LogisticsChildrenOnPage;
                        ggcRoles = LogisticsGrandChildrenOnPage;
                        break;
                }
                for (int y = 0; y < gcRoles && y < grandChildRoles.Count; y++)
                {
                    page.Entries[x][y + 1] = new OrgChartEntry(grandChildRoles[y]);

                }

                if (ggcRoles > 0)
                {
                    int nextOpenRoleIndex = grandChildRoles.Count + 1;
                    for(int y = 0; y < LogisticsGrandChildrenOnPage && y < gcRoles && y < grandChildRoles.Count; y++)
                    {
                        List<ICSRole> greatGrandChildRoles = organizationChart.ActiveRoles.Where(o => o.ReportsTo == grandChildRoles[y].RoleID).ToList();
                        for (int z = 0; z < ggcRoles; z++)
                        {
                            if (greatGrandChildRoles.Count <= z)
                            {
                                page.Entries[x][nextOpenRoleIndex] = new OrgChartEntry();

                            }
                            else
                            {
                                page.Entries[x][nextOpenRoleIndex] = new OrgChartEntry(greatGrandChildRoles[z]);
                            }
                            nextOpenRoleIndex++;
                        }
                    }
                }

            }

            return page;
        }

        private static OrgChartExtensionPage CreateOrgChartExtensionPageForExport(ICSRole StartingRole, List<ICSRole> roles, OrgChartPageOne pageOne)
        {
            OrgChartExtensionPage page = new OrgChartExtensionPage();
            page.IncidentName = pageOne.IncidentName;
            page.IncidentNumber = pageOne.IncidentNumber;
            page.PreparedByIndividualName = pageOne.PreparedByIndividualName;
            page.PreparedByRoleName = pageOne.PreparedByRoleName;
            page.StartDate = pageOne.StartDate;
            page.EndDate = pageOne.EndDate;
            page.DatePrepared = pageOne.DatePrepared;


            page.ReportsToEntry = new OrgChartEntry(StartingRole);
            List<ICSRole> reportingRoles = roles.Where(o => o.ReportsTo == page.ReportsToEntry.RoleID).ToList();
            for (int x = 0; x < ChildrenPerExtensionPage && x < reportingRoles.Count; x++)
            {
                page.Entries[x] = new OrgChartEntry[8];
                page.Entries[x][0] = new OrgChartEntry(reportingRoles[x]);
                List<ICSRole> grandChildRoles = roles.Where(o => o.ReportsTo == reportingRoles[x].RoleID).ToList();
                for (int y = 0; y < GrandchildrenPerExtensionPage && y < grandChildRoles.Count; y++)
                {
                    page.Entries[x][y + 1] = new OrgChartEntry(grandChildRoles[y]);
                }

            }

            return page;
        }


        private static List<ICSRole> removePrintedRoles(this List<ICSRole> list, OrgChartPageOne page)
        {

            for (int x = 0; x < page.AllEntries.Count(); x++)
            {
                if (page.AllEntries[x] == null) { continue; }
                list = list.Where(o => o.RoleID != page.AllEntries[x].RoleID).ToList();
            }
            return list;
        }

        private static List<ICSRole> removePrintedRoles(this List<ICSRole> list, OrgChartExtensionPage page)
        {
            for (int x = 0; x < page.AllEntries.Count(); x++)
            {
                if (page.AllEntries[x] == null) { continue; }
                list = list.Where(o => o.RoleID != page.AllEntries[x].RoleID).ToList();
            }
            return list;
        }

        private static string GeneratePageOnePDF(OrgChartPageOne page, int TotalPages)
        {
            string outputPath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            try
            {
                int FormSet = Globals._generalOptionsService.GetIntOptionsValue("FormSet");

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-207 Incident Organization Chart.pdf", FormSet);
                

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(outputPath, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {



                            stamper.AcroFields.SetField("Name", page.IncidentName);
                            stamper.AcroFields.SetField("Number I", page.IncidentNumber);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", page.StartDate));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", page.EndDate));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", page.StartDate));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", page.EndDate));


                            stamper.AcroFields.SetField("Position", page.PreparedByRoleName);
                            stamper.AcroFields.SetField("Name_2", page.PreparedByIndividualName);
                            stamper.AcroFields.SetField("Date TimeName", page.DatePrepared.ToString(Globals.DateFormat + " HH:mm"));

                            stamper.AcroFields.SetField("PAGE", "1");
                            stamper.AcroFields.SetField("OF", TotalPages.ToString());

                            //IC
                            stamper.AcroFields.SetField("ICTitle", page.IncidentCommanderTilesString);
                            stamper.AcroFields.SetField("ICName", page.IncidentCommanderNamesString);

                            //Officers
                            int OfficerNumber = 1;
                            if (!string.IsNullOrEmpty(page.LiaisonOfficer.IndividualNameWithSeePage))
                            {
                                stamper.AcroFields.SetField("OfficerTitle" + OfficerNumber.ToString(), page.LiaisonOfficer.RoleName);
                                stamper.AcroFields.SetField("OfficerName" + OfficerNumber.ToString(), page.LiaisonOfficer.IndividualNameWithSeePage);
                                OfficerNumber++;
                            }
                            if (!string.IsNullOrEmpty(page.SafetyOfficer.IndividualNameWithSeePage))
                            {
                                stamper.AcroFields.SetField("OfficerTitle" + OfficerNumber.ToString(), page.SafetyOfficer.RoleName);
                                stamper.AcroFields.SetField("OfficerName" + OfficerNumber.ToString(), page.SafetyOfficer.IndividualNameWithSeePage);
                                OfficerNumber++;
                            }
                            if (!string.IsNullOrEmpty(page.PublicInformationOfficer.IndividualNameWithSeePage))
                            {
                                stamper.AcroFields.SetField("OfficerTitle" + OfficerNumber.ToString(), page.PublicInformationOfficer.RoleName);
                                stamper.AcroFields.SetField("OfficerName" + OfficerNumber.ToString(), page.PublicInformationOfficer.IndividualNameWithSeePage);
                            }

                            for (int x = 0; x < page.Entries.Length; x++)
                            {
                                if (page.Entries[x] == null) { continue; }

                                string prefix = "";
                                switch (page.Entries[x][0].GenericRoleID)
                                {
                                    case var id when id == Globals.OpsChiefGenericID:
                                        prefix = "Ops";
                                        break;
                                    case var id when id == Globals.PlanningChiefGenericID:
                                        prefix = "Plans";
                                        break;
                                    case var id when id == Globals.FinanceChiefGenericID:
                                        prefix = "Finance";
                                        break;
                                    case var id when id == Globals.LogisticsChiefGenericID:
                                        prefix = "Logs";
                                        break;
                                }
                                if(prefix == "Logs")
                                {
                                    ;
                                }
                                stamper.AcroFields.SetField(prefix + "Title", page.Entries[x][0].RoleName);
                                stamper.AcroFields.SetField(prefix + "Name", page.Entries[x][0].IndividualNameWithSeePage);



                                for (int y = 1; y < page.Entries[x].Length; y++)
                                {
                                    

                                    if (page.Entries[x][y] != null)
                                    {
                                        string fieldName = prefix + "Title" + (y).ToString().ToString();
                                        string fieldName2 = prefix + "Name" + (y).ToString().ToString();
                                        stamper.AcroFields.SetField(fieldName, page.Entries[x][y].RoleName);
                                        stamper.AcroFields.SetField(fieldName2, page.Entries[x][y].IndividualNameWithSeePage);

                                    }
                                }
                            }






                            //Rename the fields
                            stamper.RenameAllFields();





                            stamper.Close();//Close a PDFStamper Object
                            stamper.Dispose();
                        }
                        //rdr.Close();    //Close a PDFReader Object
                    }
                }

            }
            catch (IOException ex)
            {
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " + ex.Message + Environment.NewLine + ex.StackTrace);
                outputPath = null;
            }
            catch (System.UnauthorizedAccessException uae)
            {
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " + uae.Message + Environment.NewLine + uae.StackTrace);
                outputPath = null;
            }

            return outputPath;
        }

        private static string getOrgChartPositionFieldName(int childNumber, int grandChildNumber)
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
        private static string getOrgChartNameFieldName(int childNumber, int grandChildNumber)
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



        private static string GenerateExtensionPagePDF(OrgChartExtensionPage page, int TotalPages)
        {
            string outputPath =  System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
            try
            {
                int FormSet = Globals._generalOptionsService.GetIntOptionsValue("FormSet");

                string fileToUse = PDFExtraTools.getPDFFilePath("ICS-207 Incident Organization Chart Extension.pdf", FormSet);

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(outputPath, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {



                            stamper.AcroFields.SetField("1 INCIDENT", page.IncidentName);
                            stamper.AcroFields.SetField("1 INCIDENT Number", page.IncidentNumber);

                            stamper.AcroFields.SetField("Date From", string.Format("{0:" + DateFormat + "}", page.StartDate));
                            stamper.AcroFields.SetField("Date To", string.Format("{0:" + DateFormat + "}", page.EndDate));
                            stamper.AcroFields.SetField("Time From", string.Format("{0:HH:mm}", page.StartDate));
                            stamper.AcroFields.SetField("Time To", string.Format("{0:HH:mm}", page.EndDate));

                            
                                stamper.AcroFields.SetField("Position", page.PreparedByRoleName);
                                stamper.AcroFields.SetField("Name", page.PreparedByIndividualName);
                            stamper.AcroFields.SetField("Date TimeName", page.DatePrepared.ToString(Globals.DateFormat + " HH:mm"));

                            stamper.AcroFields.SetField("PAGE", page.PageNumber.ToString());
                            stamper.AcroFields.SetField("OF", TotalPages.ToString());

                            //Parent Role
                            stamper.AcroFields.SetField("Position1", page.ReportsToEntry.RoleName);
                            stamper.AcroFields.SetField("Name1", page.ReportsToEntry.IndividualName);

                           for(int x = 0; x < page.Entries.Length; x++)
                            {
                                if(page.Entries[x] == null) { continue; }
                                for (int y = 0; y < page.Entries[x].Length; y++)
                                {
                                    if (page.Entries[x][y] != null)
                                    {
                                        string fieldName = getOrgChartPositionFieldName(x, y); //"TitleC" + (x+1).ToString() + "R" + (y).ToString();
                                        string fieldName2 = getOrgChartNameFieldName(x, y); //"NameC" + (x + 1).ToString() + "R" + (y).ToString();
                                        stamper.AcroFields.SetField(fieldName, page.Entries[x][y].RoleName);
                                        stamper.AcroFields.SetField(fieldName2, page.Entries[x][y].IndividualNameWithSeePage);
                                    }
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
                                stamper.AcroFields.RenameField(s, s + "-207-" + page.PageNumber);
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
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " +  ex.Message + Environment.NewLine + ex.StackTrace);
                outputPath = null;
            }
            catch (System.UnauthorizedAccessException uae)
            {
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " + uae.Message + Environment.NewLine + uae.StackTrace);
                outputPath = null;
            }

            return outputPath;
        }


    }
}
