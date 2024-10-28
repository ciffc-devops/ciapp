using System.Collections.Generic;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Interfaces
{
    public interface IPositionLogService
    {
        string CreateICSPDF(Incident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF);
        string CreateVerbosePDF(Incident task, ICSRole role, int OpPeriod, string pathToUse, bool useTempPath, bool flattenPDF);
        List<byte[]> exportPositionLogToPDF(Incident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false);
        List<byte[]> exportVerbosePositionLogToPDF(Incident task, int OpPeriodToExport, ICSRole role, bool flattenPDF = false);
        int getPositionLogPageCount(List<PositionLogEntry> entries);
    }
}