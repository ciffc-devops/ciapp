using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Interfaces
{
    public interface ITaskUpdateService
    {
        Task<List<TaskUpdate>> DownloadTaskUpdateList(Guid TaskID);
        Task<bool> SubmitTaskUpdate(TaskUpdate update);
        Task<List<TaskUpdate>> DownloadTaskUpdateDetails(Guid TaskID, Guid machineID, DateTime cutoffDate);
    }
}
