using System.Collections.Generic;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices
{
    public interface IPDFExportService
    {
        string createBlankSignInPDF(WFIncident task, List<GroupSignInPrintRequest> groups, int opsPeriod, bool tempFileName = false, bool flattenPDF = false);
        string createBriefingPDF(WFIncident task, Briefing briefing, bool automaticallyOpen = true, bool tempFileName = false);
        string createCommsPlanPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        string createMedicalPlanPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        string createNotePDF(WFIncident task, Note note, bool automaticallyOpen = true, bool tempFileName = false);
        string createObjectivesPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> createOpPeriodContentsList(WFIncident task, List<string> items, int OpPeriod);
        string createOrgChartContactList(WFIncident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false);
        string createOrgChartPDF(WFIncident task, int OpsPeriod, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        string createRadioLogPDF(WFIncident task, int opsPeriod, bool automaticallyOpen = true, bool tempFileName = false);
        string createSafetyPlanPDF(WFIncident task, SafetyPlan plan, bool automaticallyOpen = true, bool tempFileName = false, bool flattenPDF = false);
        string createSignInPDF(WFIncident task, int opsPeriod, bool tempFileName = false, bool flattenPDF = false);
        List<byte[]> createSinglePageBlankSignInSheetAsBytes(WFIncident task, GroupSignInPrintRequest group, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false);
        List<byte[]> createSinglePageSignInSheetAsBytes(WFIncident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod, bool flattenPDF = false);
        string createTimelinePDF(WFIncident task, bool IncludeSAR, bool IncludeSubject, bool automaticallyOpen = true, bool tempFileName = false);
        List<byte[]> exportBriefingToBytes(int OpPeriodToExport, WFIncident task);
        string exportBriefingToPDF(Briefing briefing, WFIncident task, bool includeExecution, bool includeMapQRImage = false);
        List<byte[]> exportIAPToPDF(WFIncident task, int OpPeriodToExport, bool includeBriefing = true, bool includeSafety = true, bool includeLPQ = true, bool flattenPDF = false);
        List<byte[]> exportNotesToPDF(WFIncident task, int CurrentOpPeriod);
        List<byte[]> exportRadioLogToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF = false);
        List<byte[]> exportSafetyPlansToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF);
        string exportSinglePageSignInSheetAsPDF(WFIncident task, List<MemberStatus> statuses, int pageNumber, int totalPages, int OpsPeriod);
        List<byte[]> exportTimelineToPDF(WFIncident task);
        List<byte[]> getBlankSignInSheetPDFs(WFIncident task, List<GroupSignInPrintRequest> groups, int OpsPeriod, bool flattenPDF);
        List<byte[]> getSignInSheetPDFs(WFIncident task, int OpsPeriod, bool flattenPDF);
        List<byte[]> exportGeneralMessagesToPDF(WFIncident task, int OpPeriodToExport, bool flattenPDF);
        List<byte[]> exportGeneralMessagesToPDF(WFIncident task, List<GeneralMessage> items, bool flattenPDF);
        string createGeneralMessagePDF(WFIncident task, GeneralMessage item, bool tempFileName = false, bool flattenPDF = false);
    }
}