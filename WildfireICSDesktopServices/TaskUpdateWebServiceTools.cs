﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Interfaces;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace WildfireICSDesktopServices
{
    public static class TaskUpdateWebServiceTools
    {
        
        public static TaskUpdate taskUpdateFromWebServiceItem(this ca.icscanada.ciapp.TaskUpdate webItem)
        {
            TaskUpdate item = new TaskUpdate();

            item.UpdateID = webItem.UpdateID;
            item.TaskID = webItem.TaskID;
            item.LastUpdatedUTC = webItem.LastUpdatedUTC;
            item.CommandName = webItem.CommandName;
            item.MachineID = webItem.MachineID;
            item.ObjectType = webItem.ObjectType;
            item.DataEnc = webItem.DataEnc;

            return item;
        }

        public static ca.icscanada.ciapp.TaskUpdate taskUpdateToWebServiceItem(this TaskUpdate localItem)
        {
            ca.icscanada.ciapp.TaskUpdate webItem = new ca.icscanada.ciapp.TaskUpdate();

            webItem.UpdateID = localItem.UpdateID;
            webItem.TaskID = localItem.TaskID;
            webItem.LastUpdatedUTC = localItem.LastUpdatedUTC;
            webItem.CommandName = localItem.CommandName;
            webItem.MachineID = localItem.MachineID;
            webItem.ObjectType = localItem.ObjectType;
            webItem.DataEnc = localItem.DataEnc;
            //Importantly, localitem.data is never used here, and thus never sent to the web server.
            return webItem;
        }

    }

    public class TaskUpdateService : ITaskUpdateService
    {
        public async Task<List<TaskUpdate>> DownloadTaskUpdateDetails(Guid TaskID, Guid machineID, DateTime cutoffDate)
        {
            GetTaskUpdateDetailsComplete = new TaskCompletionSource<bool>();
            serverUpdateService.GetTaskUpdateDetailsAsync(TaskID, machineID, cutoffDate);
            await GetTaskUpdateDetailsComplete.Task;
            return DownloadTaskUpdateDetailsResult;

        }

        public async Task<bool> SubmitTaskUpdate(TaskUpdate update)
        {

            SubmitTaskUpdateComplete = new TaskCompletionSource<bool>();
            ca.icscanada.ciapp.TaskUpdate webUpdate = update.taskUpdateToWebServiceItem();
            serverUpdateService.SubmitTaskUpdateAsync(webUpdate);
            await SubmitTaskUpdateComplete.Task;

            return SubmitTaskUpdateResult;
        }
    


        ca.icscanada.ciapp.ciapp_webservice serverUpdateService;

        TaskCompletionSource<bool> SubmitTaskUpdateComplete = null;
        TaskCompletionSource<bool> GetTaskUpdateListComplete = null;
        TaskCompletionSource<bool> GetTaskUpdateDetailsComplete = null;
        TaskCompletionSource<bool> GetTaskUpdateDetailsByCommandComplete = null;


        public List<TaskUpdate> DownloadTaskUpdateListResult { get; private set; } = new List<TaskUpdate>();
        public List<TaskUpdate> DownloadTaskUpdateDetailsResult { get; private set; } = new List<TaskUpdate>();
        public List<TaskUpdate> DownloadTaskUpdateDetailsByCommandResult { get; private set; } = new List<TaskUpdate>();
        public bool SubmitTaskUpdateResult { get; private set; }

        public TaskUpdateService()
        {
            serverUpdateService = new ca.icscanada.ciapp.ciapp_webservice();

            serverUpdateService.GetTaskUpdateListCompleted += GetTaskUpdateListCompleted;
            serverUpdateService.SubmitTaskUpdateCompleted += SubmitTaskUpdateCompleted;
            serverUpdateService.GetTaskUpdateDetailsCompleted += GetTaskUpdateDetailsCompleted;
            serverUpdateService.GetTaskUpdateDetailByCommandCompleted += GetTaskUpdateDetailsByCommandCompleted;
        }


        public async Task<List<TaskUpdate>> DownloadTaskDetailsByCommandName(Guid TaskID, string CommandName)
        {
            GetTaskUpdateDetailsByCommandComplete = new TaskCompletionSource<bool>();
            serverUpdateService.GetTaskUpdateDetailByCommandAsync(TaskID, CommandName);
            await GetTaskUpdateDetailsByCommandComplete.Task;
            return DownloadTaskUpdateDetailsByCommandResult;

        }

        public async Task<List<TaskUpdate>> DownloadTaskUpdateDetailsAsync(Guid TaskID, Guid machineID, DateTime cutoffDate)
        {
            GetTaskUpdateDetailsComplete = new TaskCompletionSource<bool>();
            serverUpdateService.GetTaskUpdateDetailsAsync(TaskID, machineID, cutoffDate);
            await GetTaskUpdateDetailsComplete.Task;
            return DownloadTaskUpdateDetailsResult;

        }

        public async Task<List<TaskUpdate>> DownloadTaskUpdateList(Guid TaskID)
        {
            GetTaskUpdateListComplete = new TaskCompletionSource<bool>();
            serverUpdateService.GetTaskUpdateListAsync(TaskID);
            await GetTaskUpdateListComplete.Task;
            return DownloadTaskUpdateListResult;

        }

   

        public async Task<bool> InitialTaskUpdateExists(Guid TaskID, string EncryiptionKey)
        {
            List<TaskUpdate> taskUpdates = new List<TaskUpdate>();
            taskUpdates = await DownloadTaskUpdateDetails(TaskID, Guid.Empty, DateTime.MinValue);
            if (taskUpdates.Any(o => o.CommandName.Equals("INITIAL")))
            {
                TaskUpdate update = taskUpdates.First(o => o.CommandName.Equals("INITIAL"));
                if (!string.IsNullOrEmpty(update.DataEnc))
                {
                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, EncryiptionKey);
                    if (update.Data != null)
                    {
                        return true;
                    }
                }
            }
            else { return false; }

            return false;
        }



        private void SubmitTaskUpdateCompleted(object sender, ca.icscanada.ciapp.SubmitTaskUpdateCompletedEventArgs e)
        {
            try
            {
                SubmitTaskUpdateComplete = SubmitTaskUpdateComplete ?? new TaskCompletionSource<bool>();

                SubmitTaskUpdateResult = e.Result;
                SubmitTaskUpdateComplete?.TrySetResult(true);
            }
            catch (Exception)
            {
                //Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }


        private void GetTaskUpdateListCompleted(object sender, ca.icscanada.ciapp.GetTaskUpdateListCompletedEventArgs e)
        {
            try
            {
                DownloadTaskUpdateListResult = new List<TaskUpdate>();

                GetTaskUpdateListComplete = GetTaskUpdateListComplete ?? new TaskCompletionSource<bool>();
                foreach (var item in e.Result)
                {
                    DownloadTaskUpdateListResult.Add(TaskUpdateWebServiceTools.taskUpdateFromWebServiceItem(item));
                }
                GetTaskUpdateListComplete?.TrySetResult(true);


            }
            catch (Exception)
            {

            }
        }

        private void GetTaskUpdateDetailsCompleted(object sender, ca.icscanada.ciapp.GetTaskUpdateDetailsCompletedEventArgs e)
        {
            try
            {
                DownloadTaskUpdateDetailsResult = new List<TaskUpdate>();

                GetTaskUpdateDetailsComplete = GetTaskUpdateDetailsComplete ?? new TaskCompletionSource<bool>();
                foreach (var item in e.Result)
                {
                    DownloadTaskUpdateDetailsResult.Add(TaskUpdateWebServiceTools.taskUpdateFromWebServiceItem(item));
                }
                GetTaskUpdateDetailsComplete?.TrySetResult(true);


            }
            catch (Exception)
            {

            }
        }

        private void GetTaskUpdateDetailsByCommandCompleted(object sender, ca.icscanada.ciapp.GetTaskUpdateDetailByCommandCompletedEventArgs e)
        {
            try
            {
                DownloadTaskUpdateDetailsByCommandResult = new List<TaskUpdate>();

                GetTaskUpdateDetailsByCommandComplete = GetTaskUpdateDetailsByCommandComplete ?? new TaskCompletionSource<bool>();
                foreach (var item in e.Result)
                {
                    DownloadTaskUpdateDetailsByCommandResult.Add(TaskUpdateWebServiceTools.taskUpdateFromWebServiceItem(item));
                }
                GetTaskUpdateDetailsByCommandComplete?.TrySetResult(true);


            }
            catch (Exception)
            {

            }
        }
    }
}
