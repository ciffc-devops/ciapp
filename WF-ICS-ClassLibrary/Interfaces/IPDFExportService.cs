using System;
using System.Collections.Generic;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace WildfireICSDesktopServices
{
    public interface IPDFExportService
    {
        void SetDateFormat(string str);
        string createCommsPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportCommsPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createMedicalPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportMedicalPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createNotePDF(Incident task, Note note, bool automaticallyOpen = true, bool tempFileName = false);
        string createObjectivesPDF(Incident task, int OpsPeriod, bool IncludeAttachments = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportIncidentObjectivesToPDF(Incident task, int OpPeriodToExport, bool IncludeObjectives, bool flattenPDF);
        List<byte[]> createFreeformOpPeriodContentsList(Incident task, List<string> items, int OpPeriod);
        List<byte[]> exportOrgChartContactsToPDF(Incident task, int OpPeriodToExport, bool FlattenPDF = false);
        string createOrgChartPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportOrgChartToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createSafetyMessagePDF(Incident task, SafetyMessage plan, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportNotesToPDF(Incident task, int CurrentOpPeriod);
        List<byte[]> exportSafetyMessagesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        List<byte[]> exportSafetyMessagesToPDF(Incident task, List<SafetyMessage> messagesToPrint, bool flattenPDF);
        string createVehiclePDF(Incident task, int OpPeriod, string PreparedByName, string PreparedByRoleName, bool useTempPath, bool flattenPDF);
        List<byte[]> exportVehiclesToPDF(Incident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName, bool flattenPDF);
        PDFCreationResults ExportGeneralMessagesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        PDFCreationResults ExportGeneralMessagesToPDF(Incident task, List<GeneralMessage> items, bool flattenPDF);
        PDFCreationResults CreateGeneralMessagePDF(Incident task, GeneralMessage item, bool tempFileName = false, bool flattenPDF = false);
        string createContactsPDF(Incident task, int OpPeriod, string createdBy, string createdByTitle, bool useTempPath, bool flattenPDF);
        List<byte[]> exportContactsToPDF(Incident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName, bool flattenPDF);
        string CreateAirOpsSummaryPDF(Incident task, int OpPeriod, bool useTempPath, bool flattenPDF);
        List<byte[]> exportAirOpsSummaryToPDF(Incident incident, int OpPeriodToExport, bool flattenPDF = false);
        string createOpTitlePagePDF(Incident task, int OpPeriod, string contentsText, string titleImageBytes, bool useTempPath, bool flattenPDF);
        List<byte[]> exportOpTitlePageToPDF(Incident task, int OpPeriod, string contentsText, string titleImageBytes, bool flattenPDF);
        PDFCreationResults createOrgAssignmentListPDF(Incident task, int OpsPeriod, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportOrgAssignmentListToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        PDFCreationResults exportAssignmentListToPDF(Incident task, Guid DivisionID, bool flattenPDF);
        PDFCreationResults createAssignmentSummaryPDF(Incident task, Guid OperationalGroupID, bool useTempPath, bool flattenPDF);
        PDFCreationResults exportAllAssignmentSummariesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        List<byte[]> exportAllAssignmentDetailsToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createAssignmentDetailsPDF(Incident task, int OpPeriod, Guid OpGroupID, bool useTempPath, bool flattenPDF);

        List<byte[]> exportLogisticsSummaryToPDF(Incident task, int OpPeriodToExport, ICSRole ParentRole, bool flattenPDF);
        string createLogisticsSummaryPDF(Incident task, int OpPeriod, ICSRole ParentRole, bool useTempPath, bool flattenPDF);
        List<byte[]> exportDemobChecklistToPDF(Incident task, IncidentResource Resource, bool flattenPDF);
        string createDemobChecklistPDF(Incident task, IncidentResource Resource, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportDemobChecklistToPDF(Incident task, List<IncidentResource> Resources, bool flattenPDF);
        List<byte[]> exportCheckInSheetsToPDF(Incident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF);
        List<byte[]> createSinglePageDietaryAndAllergyPDF(Incident incident, int OpPeriod, List<CheckInRecordWithResource> allCheckInRecords, int thisPageNum, int totalPageNum, bool flattenPDF);
        List<byte[]> exportDietaryAndAllergyToPDF(Incident incident, int OpPeriodToExport, bool thisOpOnly, bool flattenPDF);

        string createPositionLogPDF(Incident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF);
        string CreateVerbosePDF(Incident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF);
        List<byte[]> exportPositionLogToPDF(Incident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false);
        List<byte[]> exportVerbosePositionLogToPDF(Incident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false);

        PDFCreationResults CreateCustomTitlePagePDF(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool useTempPath, bool flattenPDF = false);
        PDFCreationResults GetCustomTitlePageBytes(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool flattenPDF = false);

    }
}