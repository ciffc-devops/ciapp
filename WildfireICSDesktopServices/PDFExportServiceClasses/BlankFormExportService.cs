using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;


namespace WildfireICSDesktopServices.PDFExportServiceClasses
{
    public static class BlankFormExportService
    {
        public static List<byte[]> createBlankFormPDFs(List<Tuple<string, int>> formsToPrint, OperationalPeriod opPeriodDetails = null, string incidentName = null, string incidentNumber = null)
        {

            List<byte[]> allPDFs = new List<byte[]>();
            WildfirePDFExportService pDFExportService = new WildfirePDFExportService();
            Incident incident = new Incident();
            incident.TaskName = incidentName;
            incident.TaskNumber = incidentNumber;
            int periodNumberToExport = 0;
            if (opPeriodDetails != null)
            {
                incident.AllOperationalPeriods.Add(opPeriodDetails);
                periodNumberToExport = opPeriodDetails.PeriodNumber;
            }



            for (int x = 0; x < formsToPrint.Count; x++)
            {
                string formName = formsToPrint[x].Item1;
                int qty = formsToPrint[x].Item2;
                for(int q = 0; q < qty; q++)
                {
                    List<byte[]> pdfBytes = null;
                    switch (formName)
                    {
                        case "202":
                            IncidentObjectivesSheet sheet = new IncidentObjectivesSheet();
                            sheet.Active = true; sheet.OpPeriod = periodNumberToExport; sheet.LastUpdatedUTC = DateTime.UtcNow; sheet.DatePrepared = DateTime.Now;
                            incident.AllIncidentObjectiveSheets.Add(sheet);
                            pdfBytes = pDFExportService.exportIncidentObjectivesToPDF(incident, periodNumberToExport, false, false);
                            break;
                        case "203":
                            OrganizationChart orgChart = new OrganizationChart();
                            orgChart.Active = true; orgChart.OpPeriod = periodNumberToExport; orgChart.LastUpdatedUTC = DateTime.UtcNow; orgChart.DatePrepared = DateTime.Now;
                            orgChart.AllRoles = OrganizationalChartTools.GetBlankPrimaryRoles();
                            foreach (ICSRole role in orgChart.AllRoles) { role.OpPeriod = periodNumberToExport; role.OrganizationalChartID = orgChart.ID; }

                            incident.allOrgCharts.Add(orgChart);
                            pdfBytes = pDFExportService.exportOrgAssignmentListToPDF(incident, periodNumberToExport, false);
                            break;
                        case "204WF":
                            OperationalGroup group = new OperationalGroup();
                            group.Active = true; group.OpPeriod = periodNumberToExport; group.LastUpdatedUTC = DateTime.UtcNow; group.DatePrepared = DateTime.Now; group.ID = Guid.Empty;
                            group.GroupType = "Branch";
                            incident.AllOperationalGroups.Add(group);
                            PDFCreationResults results204 = pDFExportService.createAssignmentSummaryPDF(incident,Guid.Empty,true,false);
                            pdfBytes = results204.bytes;
                            break;
                    }
                    if(pdfBytes == null || pdfBytes.Count == 0)
                    {
                        continue;
                    }

                    allPDFs.AddRange(pdfBytes);

                }
            }


            return allPDFs;
        }

    }
}
