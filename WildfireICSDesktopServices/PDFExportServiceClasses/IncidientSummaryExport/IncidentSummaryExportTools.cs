using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;
using WildfireICSDesktopServices.Logging;
using WildfireICSDesktopServices.OrgChartExport;

namespace WildfireICSDesktopServices.PDFExportServiceClasses.IncidentSummaryExport
{
    public static class IncidentSummaryExportTools
    {
        public static int AgenciesPerPage = 17;
        public static int KindOrTypePerPage = 21;

        public static string exportToPDF(this IncidentStatusSummary summary, Incident incident, bool flattenPDF)
        {


            List<string> paths = new List<string>();
            paths.Add(createMainPDF(summary, incident, flattenPDF));

            //Page 4 is trickier since we may need several depending on how many agencies and types/kinds we have.
            int pagesWide = 1;
            int pagesTall = 1;

            int totalAgencies = summary.SummaryAgencyEntries.Count;
            if (totalAgencies > AgenciesPerPage)
            {
                pagesTall = (int)Math.Ceiling((double)totalAgencies / AgenciesPerPage);
            }
            int totalTypes = summary.GetTotalTypes();
            if (totalTypes > KindOrTypePerPage)
            {
                pagesWide = (int)Math.Ceiling((double)totalTypes / KindOrTypePerPage);
            }

            for (int y = 0; y < pagesTall; y++)
            {
                for (int x = 0; x < pagesWide; x++)
                {
                    string page4 = SetPageFourContents(summary, incident, flattenPDF,x, y);
                    paths.Add(page4);
                }
            }

            string finalPath = FileAccessClasses.getUniqueFileName("ICS-209 Status Summary", FileAccessClasses.getWritablePath(incident), "pdf", true);
            _ = PDFExtraTools.MergePDFs(paths, finalPath, flattenPDF);

            return finalPath;
        }

        private static string createMainPDF(IncidentStatusSummary summary, Incident incident, bool flattenPDF)
        {
            List<string> paths = new List<string>();

            try
            {
                int FormSet = Globals._generalOptionsService.GetIntOptionsValue("FormSet");

                string pageOnetoThreePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";
                string fileToUse = PDFExtraTools.getPDFFilePath("Form-209.pdf", FormSet);
                

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (FileStream stream = new System.IO.FileStream(pageOnetoThreePath, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(rdr, stream))
                        {

                            //Page 1
                            stamper.SetPageOneContents(summary, incident);

                            //Page 2
                            stamper.SetPageTwoContents(summary, incident);

                            //Page 3
                            stamper.SetPageThreeContents(summary, incident);





                            //Rename the fields
                            stamper.RenameAllFields();

                            if (flattenPDF)
                            {
                                stamper.FormFlattening = true; //Flatten the PDF
                            }
                            else
                            {
                                stamper.FormFlattening = false; //Do not flatten the PDF
                            }




                            stamper.Close();//Close a PDFStamper Object
                            stamper.Dispose();
                        }
                        //rdr.Close();    //Close a PDFReader Object
                    }
                }



                paths.Add(pageOnetoThreePath);



                return pageOnetoThreePath;


            }
            catch (IOException ex)
            {
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " + ex.Message + Environment.NewLine + ex.StackTrace);
                return null;
            }
            catch (System.UnauthorizedAccessException uae)
            {
                LogService logService = new LogService();
                logService.Log("OrgChartExportTools > CreateExtensionPage ====== " + uae.Message + Environment.NewLine + uae.StackTrace);
                return null;
            }

        }

        private static void SetPageOneContents(this PdfStamper stamper, IncidentStatusSummary summary, Incident incident)
        {
            if (summary == null) { throw new ArgumentNullException(nameof(summary), "IncidentStatusSummary cannot be null."); }

            //Fields 1 - 11
            stamper.SetFieldStringValue("1 INCIDENT NAME", incident.TaskName);
            stamper.SetFieldStringValue("2 INCIDENT NO", incident.TaskNumber);
            switch (summary.ReportVersion)
            {
                case 0: // Initial
                    stamper.SetPDFCheckbox("Check Box Initial"); break;
                case 1: // Update
                    stamper.SetPDFCheckbox("Check Box Update"); break;
                case 2: // Final
                    stamper.SetPDFCheckbox("Check Box Final"); break;
            }
            if (summary.ReportNumber > 0) { stamper.SetFieldStringValue("*3. REPORT VERSION Rpt# (if used)", summary.ReportNumber.ToString()); }

            stamper.SetFieldStringValue("4 INCIDENT COMMANDERS  AGENCY OR ORGANIZATION", summary.ICAndOrganization);
            stamper.SetFieldStringValue("5 INCIDENT MANAGEMENT ORGANIZATION", summary.IMOrganization);
            stamper.SetFieldStringValue("*6.INCIDENT START DATE/TIME Date", summary.IncidentStart.ToString(Globals.DateFormat));
            stamper.SetFieldStringValue("*6.INCIDENT START DATE/TIME Time", summary.IncidentStart.ToString("HH:mm"));
            stamper.SetFieldStringValue("7 CURRENT INCIDENT SIZE OR AREA INVOLVED", summary.IncidentSize);
            stamper.SetFieldStringValue("8. PERCENT CONTAINED", (summary.PercentContained / 100).ToString("P"));
            stamper.SetFieldStringValue("8. PERCENT COMPLETED", (summary.PercentCompleted / 100).ToString("P"));
            stamper.SetFieldStringValue("9 INCIDENT DEFINITION", summary.IncidentDefinition);
            stamper.SetFieldStringValue("10 INCIDENT COMPLEXITY LEVEL", summary.ComplexityLevel);
            stamper.SetFieldStringValue("*11. FOR TIME PERIOD From Date/Time", summary.ReportFromTimePeriod.ToString(Globals.DateFormat + " HH:mm"));
            stamper.SetFieldStringValue("*11. TO TIME PERIOD To Date/Time", summary.ReportToTimePeriod.ToString(Globals.DateFormat + " HH:mm"));

            //Fields 12-15
            stamper.SetFieldStringValue("*12 PREPARED BY Print Name", summary.PreparedByResourceName);
            stamper.SetFieldStringValue("*12 PREPARED BY ICS Position", summary.PreparedByRoleName);
            stamper.SetFieldStringValue("*12 PREPARED BY Date/Time Prepared", summary.DatePrepared.ToString(Globals.DateFormat + " HH:mm"));
            stamper.SetFieldStringValue("*13. DATE/TIME SUBMITTED", summary.DateSubmitted.ToString(Globals.DateFormat + " HH:mm"));
            stamper.SetFieldStringValue("*14 APPROVED BY Print Name", summary.ApprovedByResourceName);
            stamper.SetFieldStringValue("*14 APPROVED BY ICS Position", summary.ApprovedByRoleName);
            stamper.SetFieldStringValue("*14 APPROVED BY Date/Time Prepared", summary.DateApproved.ToString(Globals.DateFormat + " HH:mm"));
            stamper.SetFieldStringValue("*15. PRIMARY LOCATION, ORGANIZATION, OR AGENCY SENT TO", summary.PrimarySendTo);

            //Fields 16 - 27
            Province province = ProvinceTools.GetProvinces().FirstOrDefault(p => p.ProvinceID == summary.ProvinceID);
            if (province != null) { stamper.SetFieldStringValue("*16. PROVINCE/TERRITORY", province.ProvinceName); }
            stamper.SetFieldStringValue("*17. COUNTY, REGIONAL/RURAL MUNICIPALITY, REGIONAL/MUNICIPAL DISTRICT", summary.District);
            stamper.SetFieldStringValue("*18. CITY", summary.City);
            stamper.SetFieldStringValue("19. UNIT OR OTHER", summary.Unit);
            stamper.SetFieldStringValue("*20. INCIDENT JURISDICTION", summary.Jurisdiction);
            stamper.SetFieldStringValue("21. INCIDENT LOCATION OWNERSHIP", summary.LocationOwnership);
            stamper.SetFieldStringValue("22. LONGITUDE", summary.Longitude.ToString());
            stamper.SetFieldStringValue("22. LATITUDE", summary.Latitude.ToString());
            stamper.SetFieldStringValue("23. DATUM", summary.LocationDatum);
            stamper.SetFieldStringValue("24. LEGAL DESCRIPTION", summary.LocationLegalDescription);
            stamper.SetFieldStringValue("*25. SHORT LOCATION OR AREA DESCRIPTION", summary.ShortLocationDescription);
            stamper.SetFieldStringValue("*26. UTM COORDINATES", summary.UTM);
            stamper.SetFieldStringValue("27. NOTE ANY ELECTRONIC GEOSPATIAL DATA INCLUDED OR ATTACHED", summary.GeoDataNote);

            //Fields 28 - 30
            stamper.SetFieldStringValue("*28. SIGNIFICANT EVENTS FOR THE TIME PERIOD REPORTED", summary.SignificantEvents);
            stamper.SetFieldStringValue("29. PRIMARY MATERIALS OR HAZARDS INVOLVED", summary.PrimaryMaterialsOrHazards);
            stamper.SetFieldStringValue("30 DAMAGE ASSESSMENT INFORMATION", summary.DamageAssessmentInfo);
            stamper.SetFieldStringValue("Other", summary.StructureSummaryOtherLabel);
            stamper.SetFieldStringValue("B  Threatened 72 hrsE Single Residences", summary.StructureSummarySingleResidence[0].ToString());
            stamper.SetFieldStringValue("C  DamagedE Single Residences", summary.StructureSummarySingleResidence[1].ToString());
            stamper.SetFieldStringValue("D  DestroyedE Single Residences", summary.StructureSummarySingleResidence[2].ToString());
            stamper.SetFieldStringValue("B  Threatened 72 hrsF Nonresidential Commercial Property", summary.StructureSummaryCommercial[0].ToString());
            stamper.SetFieldStringValue("C  DamagedF Nonresidential Commercial Property", summary.StructureSummaryCommercial[1].ToString());
            stamper.SetFieldStringValue("D  DestroyedF Nonresidential Commercial Property", summary.StructureSummaryCommercial[2].ToString());
            stamper.SetFieldStringValue("B  Threatened 72 hrsOther Minor Structures", summary.StructureSummaryMinor[0].ToString());
            stamper.SetFieldStringValue("C  DamagedOther Minor Structures", summary.StructureSummaryMinor[1].ToString());
            stamper.SetFieldStringValue("D  DestroyedOther Minor Structures", summary.StructureSummaryMinor[2].ToString());
            stamper.SetFieldStringValue("B  Threatened 72 hrsOther", summary.StructureSummaryOther[0].ToString());
            stamper.SetFieldStringValue("C  DamagedOther", summary.StructureSummaryOther[1].ToString());
            stamper.SetFieldStringValue("D  DestroyedOther", summary.StructureSummaryOther[2].ToString());



        }

        private static void SetPageTwoContents(this PdfStamper stamper, IncidentStatusSummary summary, Incident incident)
        {
            if (summary == null) { throw new ArgumentNullException(nameof(summary), "IncidentStatusSummary cannot be null."); }

            //Fields 1 - 2
            stamper.SetFieldStringValue("*1. INCIDENT NAME", incident.TaskName);
            stamper.SetFieldStringValue("2. INCIDENT NO", incident.TaskNumber);

            //Civilians Impacted
            for (int x = 0; x < summary.CiviliansImpactedThisPeriod.Length; x++)
            {
                if (summary.CiviliansImpactedEstimate[x])
                {
                    stamper.SetFieldStringValue("31a" + (x + 1), summary.CiviliansImpactedThisPeriod[x].ToString() + " (Est)");
                    stamper.SetFieldStringValue("31b" + (x + 1), summary.CiviliansImpactedToDate[x].ToString() + " (Est)");

                }
                else
                {
                    stamper.SetFieldStringValue("31a" + (x + 1), summary.CiviliansImpactedThisPeriod[x].ToString());
                    stamper.SetFieldStringValue("31b" + (x + 1), summary.CiviliansImpactedToDate[x].ToString());

                }
            }
            //Responders Impacted
            for (int x = 0; x < summary.RespondersImpactedThisPeriod.Length; x++)
            {
                if (summary.RespondersImpactedEstimate[x])
                {
                    stamper.SetFieldStringValue("32a" + (x + 1), summary.RespondersImpactedThisPeriod[x].ToString() + " (Est)");
                    stamper.SetFieldStringValue("32b" + (x + 1), summary.RespondersImpactedToDate[x].ToString() + " (Est)");

                }
                else
                {
                    stamper.SetFieldStringValue("32a" + (x + 1), summary.RespondersImpactedThisPeriod[x].ToString());
                    stamper.SetFieldStringValue("32b" + (x + 1), summary.RespondersImpactedToDate[x].ToString());

                }
            }

            stamper.SetFieldStringValue("33 LIFE SAFETY AND HEALTH STATUSTHREAT REMARKS", summary.LifeSafetyHealthRemarks);
            stamper.SetFieldStringValue("35. WEATHER CONCERNS", summary.WeatherConcerns);

            for (int x = 0; x < summary.HealthThreatManagementActive.Length; x++)
            {
                if (summary.HealthThreatManagementActive[x])
                {
                    stamper.SetPDFCheckbox("34cb" + (x + 1)); // Active
                }
            }
            for (int x = 0; x < summary.HealthThreatManagementOtherLabels.Length; x++)
            {
                stamper.SetFieldStringValue("34OtherLabel" + (x + 1), summary.HealthThreatManagementOtherLabels[x]);
            }

            stamper.SetFieldStringValue("36. PROJECTED INCIDENT ACTIVITY 12 hours", summary.ProjectedEscalation[0]);
            stamper.SetFieldStringValue("36. PROJECTED INCIDENT ACTIVITY 24 hours", summary.ProjectedEscalation[2]);
            stamper.SetFieldStringValue("36. PROJECTED INCIDENT ACTIVITY 48 hours", summary.ProjectedEscalation[2]);
            stamper.SetFieldStringValue("36. PROJECTED INCIDENT ACTIVITY 72 hours", summary.ProjectedEscalation[3]);
            stamper.SetFieldStringValue("36. PROJECTED INCIDENT ACTIVITY Anticipated after 72 hours", summary.ProjectedEscalation[4]);

            stamper.SetFieldStringValue("37. OBJECTIVES", summary.Objectives);

        }

        private static void SetPageThreeContents(this PdfStamper stamper, IncidentStatusSummary summary, Incident incident)
        {
            if (summary == null) { throw new ArgumentNullException(nameof(summary), "IncidentStatusSummary cannot be null."); }

            //Fields 1 - 2
            stamper.SetFieldStringValue("*1. INCIDENT NAMEPage3", incident.TaskName);
            stamper.SetFieldStringValue("2. INCIDENT NOPage3", incident.TaskNumber);

            for (int x = 0; x < summary.CurrentThreatSummary.Length; x++)
            {
                stamper.SetFieldStringValue("38-" + (x + 1), summary.CurrentThreatSummary[x]);
            }

            for (int x = 0; x < summary.CriticalResourcesNeeded.Length; x++)
            {
                stamper.SetFieldStringValue("39-" + (x + 1), summary.CriticalResourcesNeeded[x]);
            }
            stamper.SetFieldStringValue("41 PLANNED ACTIONS FOR NEXT OPERATIONAL PERIOD", summary.StrategicDiscussion);
            stamper.SetFieldStringValue("42 PROJECTED FINAL INCIDENT SIZEAREA use unit label  eg sq km", summary.PlannedActions);

            stamper.SetFieldStringValue("42. PROJECTED FINAL INCIENT SIZE/AREA", summary.ProjectedFinalSize);
            stamper.SetFieldStringValue("43. ANTICIPATED INCIDENT MANAGEMENT COMPLETION DATE", summary.AnticipatedIMCompleteDate.ToString(Globals.DateFormat));
            stamper.SetFieldStringValue("44. PROJECTED SIGNIFICANT RESOURCE DEMOBILIZATION START DATE", summary.ProjectedResourceDemobDate.ToString(Globals.DateFormat));
            stamper.SetFieldStringValue("45. ESTIMATED INCIDENT COSTS TO DATE", summary.EstimatedCostsToDate.ToString("C"));
            stamper.SetFieldStringValue("46. PROJECTED FINAL INCIDENT COST ESTIMATE", summary.ProjectedFinalCost.ToString("C"));
            stamper.SetFieldStringValue("47. REMARKS", summary.Remarks);



        }

        private static string SetPageFourContents(IncidentStatusSummary summary, Incident incident, bool flattenPDF, int pageX = 0, int pageY = 0)
        {
            if (summary == null) { throw new ArgumentNullException(nameof(summary), "IncidentStatusSummary cannot be null."); }


            string path = System.IO.Path.GetTempPath();


            path = Path.Combine(path, Guid.NewGuid().ToString() + ".pdf");

            int FormSet = Globals._generalOptionsService.GetIntOptionsValue("FormSet");

            string fileToUse = PDFExtraTools.getPDFFilePath("Form-209-page4.pdf", FormSet);
            
            try
            {

                using (PdfReader rdr = new PdfReader(fileToUse))
                {
                    using (PdfStamper stamper = new PdfStamper(rdr, new System.IO.FileStream(path, FileMode.Create)))
                    {


                        //Fields 1, 2, 53
                        stamper.SetFieldStringValue("*1. INCIDENT NAMEPage4", incident.TaskName);
                        stamper.SetFieldStringValue("2. INCIDENT NOPage4", incident.TaskNumber);
                        stamper.SetFieldStringValue("52 ADDITIONAL COOPERATING AND ASSISTING ORGANIZATIONS NOT LISTED ABOVE", summary.AdditionalAssistingOrganizations);

                        int totalAdditionalPersonnel = 0;
                        int totalPersonnel = 0;
                        List<SummaryAgencyEntry> entriesThisPage = summary.SummaryAgencyEntries.OrderBy(o => o.AgencyName).Skip(pageY * AgenciesPerPage).ToList();
                        List<string> KindTypeColumns = new List<string>();
                        //get the column names

                        for (int x = 0; x < entriesThisPage.Count() && x < AgenciesPerPage; x++)
                        {
                            for (int y = 0; y < entriesThisPage[x].Resources.Count(); y++)
                            {
                                if (!KindTypeColumns.Contains(entriesThisPage[x].Resources[y].ResourceDisplayName))
                                    KindTypeColumns.Add(entriesThisPage[x].Resources[y].ResourceDisplayName);
                            }
                        }
                        KindTypeColumns = KindTypeColumns.OrderBy(o => o).Skip(pageX * KindOrTypePerPage).Take(KindOrTypePerPage).ToList();


                        for (int x = 0; x < entriesThisPage.Count() && x < AgenciesPerPage; x++)
                        {

                            stamper.SetFieldStringValue("48 AGENCY OR ORGANIZATIONRow" + (x + 1), entriesThisPage[x].AgencyName);

                            foreach (SummaryResourceEntry entry in entriesThisPage[x].Resources)
                            {
                                if (KindTypeColumns.Contains(entry.ResourceDisplayName))
                                {
                                    int columnIndex = KindTypeColumns.IndexOf(entry.ResourceDisplayName);
                                    stamper.SetFieldStringValue("49 RESOURCES " + (columnIndex + 1), entry.ResourceDisplayName);
                                    stamper.SetFieldStringValue("Resources-R" + (x + 1) + "-C" + (columnIndex + 1) + "-a", entry.ResourceCount.ToString());

                                    stamper.SetFieldStringValue("Resources-R" + (x + 1) + "-C" + (columnIndex + 1) + "-b", entry.PersonnelCount.ToString());
                                    //Resources 1-1
                                }
                            }

                            stamper.SetFieldStringValue("50. ADDITIONAL PERSONNEL Row " + (x + 1), entriesThisPage[x].AdditionalPersonnel.ToString());
                            stamper.SetFieldStringValue("51 TOTAL PERSONNEL Row " + (x + 1), entriesThisPage[x].TotalPersonnel.ToString());
                            totalAdditionalPersonnel += entriesThisPage[x].AdditionalPersonnel;
                            totalPersonnel += entriesThisPage[x].TotalPersonnel;
                        }

                        //totals row
                        for (int x = 0; x < KindTypeColumns.Count() && x < KindOrTypePerPage-1; x++)
                        {
                            int resourceKindTypeTotal = 0;
                            foreach (SummaryAgencyEntry agency in entriesThisPage)
                            {
                                if (agency.Resources.Any(o => o.ResourceDisplayName == KindTypeColumns[x]))
                                {
                                    resourceKindTypeTotal += agency.Resources.First(o => o.ResourceDisplayName == KindTypeColumns[x]).ResourceCount;
                                }
                            }

                            stamper.SetFieldStringValue("Total Resources " + (x + 1), resourceKindTypeTotal.ToString());
                        }

                        stamper.SetFieldStringValue("52. TOTAL RESOURCES", totalAdditionalPersonnel.ToString());
                        stamper.SetFieldStringValue("51 TOTAL PERSONNEL Row 18", totalPersonnel.ToString());


                        stamper.RenameAllFields();

                        if (flattenPDF)
                        {
                            stamper.FormFlattening = true;
                        }



                        stamper.Close();//Close a PDFStamper Object
                        stamper.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return path;




        }
    }
}
