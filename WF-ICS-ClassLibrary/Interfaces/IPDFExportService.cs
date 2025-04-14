using System;
using System.Collections.Generic;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace WildfireICSDesktopServices
{
    public interface IPDFExportService
    {
        void SetDateFormat(string str);
        string createBlankSignInPDF(Incident task, List<GroupSignInPrintRequest> groups, int opsPeriod, bool tempFileName = false, bool flattenPDF = false);
        string createBriefingPDF(Incident task, Briefing briefing, bool automaticallyOpen = true, bool tempFileName = false);
        string createCommsPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportCommsPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createMedicalPlanPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportMedicalPlanToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createNotePDF(Incident task, Note note, bool automaticallyOpen = true, bool tempFileName = false);
        string createObjectivesPDF(Incident task, int OpsPeriod, bool IncludeAttachments = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportIncidentObjectivesToPDF(Incident task, int OpPeriodToExport, bool IncludeObjectives, bool flattenPDF);
        List<byte[]> createFreeformOpPeriodContentsList(Incident task, List<string> items, int OpPeriod);
        PDFCreationResults createOrgChartContactList(Incident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false);
        List<byte[]> exportOrgChartContactsToPDF(Incident task, int OpPeriodToExport);
        string createOrgChartPDF(Incident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> exportOrgChartToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        string createRadioLogPDF(Incident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false);
        string createSafetyMessagePDF(Incident task, SafetyMessage plan, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        string createSignInPDF(Incident task, int opsPeriod, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> createSinglePageBlankSignInSheetAsBytes(Incident task, GroupSignInPrintRequest group, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false);
        List<byte[]> createSinglePageSignInSheetAsBytes(Incident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false);
        string createTimelinePDF(Incident task, bool IncludeSAR, bool IncludeSubject, bool automaticallyOpen = true, bool tempFileName = false);
        List<byte[]> exportBriefingToBytes(int OpPeriodToExport, Incident task);
        string exportBriefingToPDF(Briefing briefing, Incident task, bool includeExecution, bool includeMapQRImage = false);
        List<byte[]> exportNotesToPDF(Incident task, int CurrentOpPeriod);
        List<byte[]> exportRadioLogToPDF(Incident task, int OpPeriodToExport, bool flattenPDF = false);
        List<byte[]> exportSafetyMessagesToPDF(Incident task, int OpPeriodToExport, bool flattenPDF);
        List<byte[]> exportSafetyMessagesToPDF(Incident task, List<SafetyMessage> messagesToPrint, bool flattenPDF);
        string createVehiclePDF(Incident task, int OpPeriod, string PreparedByName, string PreparedByRoleName, bool useTempPath, bool flattenPDF);
        List<byte[]> exportVehiclesToPDF(Incident task, int OpPeriodToExport, string PreparedByName, string PreparedByRoleName, bool flattenPDF);
        string exportSinglePageSignInSheetAsPDF(Incident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod);
        List<byte[]> exportTimelineToPDF(Incident task);
        List<byte[]> getBlankSignInSheetPDFs(Incident task, List<GroupSignInPrintRequest> groups, int OpsPeriod, bool flattenPDF);
        List<byte[]> getSignInSheetPDFs(Incident task, int OpsPeriod, bool flattenPDF);
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

        PDFCreationResults CreateCustomTitlePagePDF(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool useTempPath, bool flattenPDF = false);
        PDFCreationResults GetCustomTitlePageBytes(Incident incident, TitlePageOptions options, int OperationalPeriodNumber, bool flattenPDF = false);
    }
}