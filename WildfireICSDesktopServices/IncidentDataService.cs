using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;

namespace WildfireICSDesktopServices
{
    public class IncidentDataService : IIncidentDataService
    {
        #region Change Events

        public event CommsEventHandler CommsChanged;
        public event CheckInEventHandler MemberSignInChanged;
        public event BriefingEventHandler BriefingChanged;
        public event CommsPlanEventHandler CommsPlanChanged;
        public event CommsPlanItemEventHandler CommsPlanItemChanged;
        //public event CommsPlanItemLinkEventHandler CommsPlanItemLinkChanged;
        public event ContactEventHandler ContactChanged;
        public event HospitalEventHandler HospitalChanged;
        public event AmbulanceServiceEventHandler AmbulanceServiceChanged;
        public event MedicalAidStationEventHandler MedicalAidStationChanged;

        public event IncidentObjectiveEventHandler IncidentObjectiveChanged;
        public event IncidentObjectivesSheetEventHandler IncidentObjectivesSheetChanged;
        public event MedicalPlanEventHandler MedicalPlanChanged;
        public event NoteEventHandler NoteChanged;
        public event OperationalPeriodEventHandler OperationalPeriodDetailsChanged;
        public event OrganizationalChartEventHandler OrganizationalChartChanged;
        public event ICSRoleEventHandler ICSRoleChanged;
        public event SafetyMessageEventHandler SafetyMessageChanged;
        public event TimelineEventHandler TimelineChanged;
        public event TimelineEventEventHandler TimelineEventChanged;
        public event VehicleEventHandler VehicleChanged;
        public event PositionLogEventHandler PositionLogChanged;
        public event CommsPlanItemListEventHandler CommsPlanItemListChanged;
        public event TaskEquipmentEventHandler TaskEquipmentChanged;
        public event EquipmentIssueEventHandler EquipmentIssueChanged;
        public event WFIncidentEventHandler WfIncidentChanged;
        public event TaskUpdateEventHandler TaskUpdateChanged;
        public event TaskBasicsEventHandler TaskBasicsChanged;
        public event GeneralMessageEventHandler GeneralMessageChanged;
        public event AircraftEventHandler AircraftChanged;
        public event AircraftsOperationsSummaryEventHandler AircraftsOperationsSummaryChanged;
        //public event TeamAssignmentEventHandler TeamAssignmentChanged;
        public event DemobEventHandler DemobilizatoinRecordChanged;
        public event ResourceReplacementEventHandler ResourceReplacementChanged;
        public event IncidentSummaryEventHandler IncidentSummaryChanged;


        public event OperationalGroupEventHandler OperationalGroupChanged;
        public event OperationalSubGroupEventHandler OperationalSubGroupChanged;

        public event CurrentICSRoleEventHandler CurrentICSRoleChanged;
        public event IncidenOpPeriodChangedEventHandler CurrentOpPeriodChanged;
        #endregion

        public IncidentDataService(Incident currentTask) { _currentIncident = currentTask;  }
        public IncidentDataService() {  }

        private Incident _currentIncident;
        public Incident CurrentIncident { get => _currentIncident; set => _currentIncident = value; }
        public List<TaskUpdate> allTaskUpdates { get => _currentIncident.allTaskUpdates; set => _currentIncident.allTaskUpdates = value; }
        private Guid _MachineID;
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }

        private ICSRole _CurrentRole;
        public ICSRole CurrentRole { get => _CurrentRole; set { _CurrentRole = value; OnCurrentRoleChanged(new ICSRoleEventArgs(value)); } }



        public virtual void OnCurrentRoleChanged(ICSRoleEventArgs e)
        {
            CurrentICSRoleEventHandler handler = this.CurrentICSRoleChanged;
            if (handler != null) { handler(e); }
        }

        public void UpsertObject(object obj, string source)
        {
            //string dataClassName = obj.GetType().Name;
            var objType = obj.GetType();
            if (objType == typeof(Briefing))
            {
                UpsertBriefing(((Briefing)obj).Clone(), source);
            }
            else if (objType == typeof(CommsLogEntry))
            {
                UpsertComms(((CommsLogEntry)obj).Clone(), source);
            }
            else if (objType == typeof(CommsPlanItem))
            {
                UpsertCommsPlanItem(((CommsPlanItem)obj).Clone(), null, source);
            }
            else if (objType == typeof(CommsPlan))
            {
                UpsertCommsPlan(((CommsPlan)obj).Clone(), source);
            }
            else if (objType == typeof(Contact))
            {
                UpsertContact(((Contact)obj).Clone(), source);
            }
            else if (objType == typeof(IncidentGear))
            {
                UpsertTaskEquipment(((IncidentGear)obj).Clone(), source);
            }
            else if (objType == typeof(GearIssue))
            {
                UpsertEquipmentIssue(((GearIssue)obj).Clone(), source);
            }
            else if (objType == typeof(Hospital))
            {
                UpsertHospital(((Hospital)obj).Clone(), source);
            }
            else if (objType == typeof(AmbulanceService))
            {
                UpsertAmbulance(((AmbulanceService)obj).Clone(), source);
            }
            else if (objType == typeof(MedicalPlan))
            {
                UpsertMedicalPlan(((MedicalPlan)obj).Clone(), source);
            }
            else if (objType == typeof(Note))
            {
                UpsertNote(((Note)obj).Clone(), source);
            }
            else if (objType == typeof(OperationalPeriod))
            {
                UpsertOperationalPeriod(((OperationalPeriod)obj).Clone(), source);
            }
            else if (objType == typeof(OrganizationChart))
            {
                UpsertOrganizationalChart(((OrganizationChart)obj).Clone(), source);
            }

            else if (objType == typeof(ICSRole))
            {
                UpsertICSRole(((ICSRole)obj).Clone(), source);
            }
            else if (objType == typeof(PositionLogEntry))
            {
                UpsertPositionLogEntry(((PositionLogEntry)obj).Clone(), source);
            }
            else if (objType == typeof(SafetyMessage))
            {
                UpsertSafetyMessage(((SafetyMessage)obj).Clone(), source);
            }
            else if (objType == typeof(TaskBasics))
            {
                UpdateTaskBasics(((TaskBasics)obj), source);
            }

            /*else if (dataClassName.Equals(new Timeline().GetType().Name))
            {
                UpsertTimeline(((Timeline)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TimelineEvent().GetType().Name))
            {
                UpsertTimelineEvent(((TimelineEvent)obj).Clone(), source);
            }*/
            else if (objType == typeof(Vehicle))
            {
                UpsertVehicle(((Vehicle)obj).Clone(), source);
            }
            else if (objType == typeof(CheckInRecord))
            {
                UpsertCheckInRecord(((CheckInRecord)obj).Clone(), false, source);
            }
            else if (objType == typeof(Personnel))
            {
                UpsertPersonnel(((Personnel)obj).Clone(), source);
            }



            else if (objType == typeof(AirOperationsSummary))
            {
                UpsertAirOperationsSummary(((AirOperationsSummary)obj).Clone(), source);
            }
            else if (objType == typeof(Aircraft))
            {
                UpsertAircraft(((Aircraft)obj).Clone(), source);
            }

            else if (objType == typeof(IncidentObjectivesSheet))
            {
                UpsertIncidentObjectivesSheet(((IncidentObjectivesSheet)obj).Clone(), source);
            }
            else if (objType == typeof(IncidentObjective))
            {
                UpsertIncidentObjective(((IncidentObjective)obj).Clone(), source);
            }


            else if (objType == typeof(MedicalPlan))
            {
                UpsertMedicalPlan(((MedicalPlan)obj).Clone(), source);
            }

            else if (objType == typeof(MedicalAidStation))
            {
                UpsertMedicalAidStation(((MedicalAidStation)obj).Clone(), source);
            }
            else if (objType == typeof(Hospital))
            {
                UpsertHospital(((Hospital)obj).Clone(), source);
            }



            else if (objType == typeof(GeneralMessage))
            {
                UpsertGeneralMessage(((GeneralMessage)obj).Clone(), source);
            }

            else if (objType == typeof(OperationalGroup))
            {
                UpsertOperationalGroup(((OperationalGroup)obj).Clone(), source);
            }
            else if (objType == typeof(Crew))
            {
                UpsertCrew(((Crew)obj).Clone(), source);
            }
            else if (objType == typeof(DemobilizationRecord))
            {
                UpsertDemobRecord(((DemobilizationRecord)obj).Clone(), source);
            }
            else if (objType == typeof(ResourceReplacementPlan))
            {
                UpsertResourceReplacementPlan(((ResourceReplacementPlan)obj).Clone(), source);
            }
        }


        protected virtual void OnIncidentChanged(IncidentEventArgs e)
        {
            WFIncidentEventHandler handler = this.WfIncidentChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public virtual void OnCurrentOpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            IncidenOpPeriodChangedEventHandler handler = this.CurrentOpPeriodChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        #region Task Updates
        public TaskUpdate CreateTaskUpdateForItem(SyncableItem obj, string command)
        {
            TaskUpdate update = new TaskUpdate();
            update.TaskID = _currentIncident.ID;
            update.LastUpdatedUTC = DateTime.UtcNow;
            update.CommandName = command;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);


            update.SoftwareVersionMajor = fileVersionInfo.ProductMajorPart;
            update.SoftwareVersionMinor = fileVersionInfo.FileMinorPart;
            update.SoftwareVersionBuild = fileVersionInfo.FileBuildPart;

            if (obj is ICloneable) { update.Data = obj.Clone(); }
            else { update.Data = obj; }
            update.CreatedByRoleName = CurrentRole.RoleName;
            //update.DataEnc = update.Data.XmlSerializeToString();
            //update.DataEnc = StringCipher.Encrypt(update.DataEnc, _currentIncident.TaskEncryptionKey);
            update.SetEncData(_currentIncident.TaskEncryptionKey);
            update.ProcessedLocally = false;
            update.MachineID = MachineID;
            update.UploadedSuccessfully = false;
            update.ObjectType = obj.GetType().Name.ToString();
            var type = obj.GetType();
            if (typeof(SyncableItem).IsAssignableFrom(obj.GetType()))
            {
                update.ItemID = ((SyncableItem)obj).ID;
            }

            return update;
        }

        public TaskUpdate UpsertTaskUpdate(SyncableItem obj, string command, bool processed_locally, bool uploaded)
        {
            TaskUpdate update = new TaskUpdate();
            update.TaskID = _currentIncident.ID;
            update.LastUpdatedUTC = DateTime.UtcNow;
            update.CommandName = command;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);


            update.SoftwareVersionMajor = fileVersionInfo.ProductMajorPart;
            update.SoftwareVersionMinor = fileVersionInfo.FileMinorPart;
            update.SoftwareVersionBuild = fileVersionInfo.FileBuildPart;

            if (obj is ICloneable) { update.Data = obj.Clone(); }
            else { update.Data = obj; }
            if (CurrentRole == null || string.IsNullOrEmpty(CurrentRole.RoleName)) { update.CreatedByRoleName = string.Empty; }
            else { update.CreatedByRoleName = CurrentRole.RoleName; }
            //update.DataEnc = update.Data.XmlSerializeToString();
            //update.DataEnc = StringCipher.Encrypt(update.DataEnc, _currentIncident.TaskEncryptionKey);
            update.SetEncData(_currentIncident.TaskEncryptionKey);
            update.ProcessedLocally = processed_locally;
            update.MachineID = MachineID;
            update.UploadedSuccessfully = uploaded;
            update.ObjectType = obj.GetType().Name.ToString();
            var type = obj.GetType();
            if (typeof(SyncableItem).IsAssignableFrom(obj.GetType()))
            {
                update.ItemID = ((SyncableItem)obj).ID;
            }
            //Remove it in case it is a duplicate
            allTaskUpdates = allTaskUpdates.Where(o => o.UpdateID != update.UpdateID).ToList();
            allTaskUpdates.Add(update);
            allTaskUpdates = allTaskUpdates.OrderBy(o => o.LastUpdatedUTC).ToList();
            CurrentIncident.LastUpdatedUTC = DateTime.UtcNow;
            OnTaskUpdateChanged(new TaskUpdateEventArgs(update));

            return update;
        }
        public TaskUpdate UpsertTaskUpdate(TaskUpdate update)
        {
            //Remove it in case it is a duplicate
            bool existsAlready = allTaskUpdates.Any(o => o.UpdateID == update.UpdateID);
            allTaskUpdates = allTaskUpdates.Where(o => o.UpdateID != update.UpdateID).ToList();
            allTaskUpdates.Add(update);
            allTaskUpdates = allTaskUpdates.OrderBy(o => o.LastUpdatedUTC).ToList();
            if (!existsAlready)
            {
                OnTaskUpdateChanged(new TaskUpdateEventArgs(update));
            }
            return update;
        }
        public TaskUpdate InsertIfUniqueTaskUpdate(TaskUpdate update)
        {
            //Remove it in case it is a duplicate
            bool existsAlready = allTaskUpdates.Any(o => o.UpdateID == update.UpdateID);
            if (!existsAlready)
            {
                allTaskUpdates.Add(update);
                allTaskUpdates = allTaskUpdates.OrderBy(o => o.LastUpdatedUTC).ToList();

                OnTaskUpdateChanged(new TaskUpdateEventArgs(update));

            }
            return update;
        }


        //This is called when a new task update is received by some means
        public void ProcessTaskUpdate(TaskUpdate update)
        {
            bool alreadyIn = allTaskUpdates.Any(o => o.UpdateID == update.UpdateID);
            if (!alreadyIn)
            {
                if (update.Data == null && !string.IsNullOrEmpty(update.DataEnc))
                {

                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentIncident.TaskEncryptionKey);

                }
                ApplyTaskUpdate(update);
                UpsertTaskUpdate(update);

            }
        }
        protected virtual void OnTaskUpdateChanged(TaskUpdateEventArgs e)
        {
            TaskUpdateEventHandler handler = this.TaskUpdateChanged;
            if (handler != null)
            {
                handler(e);
            }
        }



        public void ApplyTaskUpdate(TaskUpdate update, bool applyAllSubsequent = false)
        {
            if (update.Data == null && !string.IsNullOrEmpty(update.DataEnc))
            {
                update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentIncident.TaskEncryptionKey);
            }



            if (!update.ProcessedLocally && update.Data != null)
            {
                string source = "internet";
                if (!string.IsNullOrEmpty(update.Source)) { source = update.Source; }

                if (update.CommandName.Equals("UPSERT"))
                {
                    update.ProcessedLocally = true;
                    UpsertObject(update.Data, source);
                }
                else if (update.CommandName.Equals("DELETE"))
                {
                    update.ProcessedLocally = true;
                    //DeleteObject(update.Data, source);
                }
                else if (update.CommandName.Equals("INITIAL"))
                {
                    TaskBasics basics = update.Data as TaskBasics;

                    if (update.TaskID != CurrentIncident.ID)
                    {

                        _currentIncident.ID = basics.ID;
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, "internet");

                    }
                    else
                    {
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, "internet");
                    }
                }

                if (CurrentIncident.allTaskUpdates.Any(o => o.UpdateID == update.UpdateID))
                {
                    CurrentIncident.allTaskUpdates.First(o => o.UpdateID == update.UpdateID).ProcessedLocally = true;
                }


            }
            else if (update.Data == null)
            {
                //this prevents a nasty loop
                update.ProcessedLocally = true;
            }

            if (applyAllSubsequent)
            {
                List<TaskUpdate> subsequent = allTaskUpdates.Where(o => o.LastUpdatedUTC > update.LastUpdatedUTC && o.ObjectType.Equals(update.ObjectType) && o.ItemID == update.ItemID).ToList();

                foreach (TaskUpdate subUpdate in subsequent)
                {
                    ApplyTaskUpdate(subUpdate, false);
                }


            }
        }
        #endregion

        #region Internet Sync Methods
        public async Task<bool> uploadTaskUpdateToServer(TaskUpdate update)
        {
            try
            {
                TaskUpdateService service = new TaskUpdateService();

                var result = await service.SubmitTaskUpdate(update);

                if (result)
                {
                    update.UploadedSuccessfully = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task SendInitialTaskUpdate(IProgress<Tuple<int, int, int>> progress)
        {
            //This sends the "Initial" record, and all updates saved locally to this point.
            //It also means we need to save those updates persistently from now on
            try
            {
                TaskBasics basics = new TaskBasics(CurrentIncident);
                TaskUpdate update = UpsertTaskUpdate(basics, "INITIAL", true, false);
                _ = await uploadTaskUpdateToServer(update);

                //No need to process the other task basics updates, since a current one has already been generated.
                foreach (TaskUpdate up in allTaskUpdates.Where(o => o.ObjectType == "TaskBasics")) { up.UploadedSuccessfully = true; }

                int totalUpdates = allTaskUpdates.Count(o => !o.UploadedSuccessfully);
                int completedUpdates = 0;
                foreach (TaskUpdate up in allTaskUpdates.Where(o => !o.UploadedSuccessfully))
                {
                    _ = await uploadTaskUpdateToServer(up);
                    completedUpdates++;
                    progress.Report(new Tuple<int, int, int>(1, completedUpdates, totalUpdates));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> LoadOutstandingTaskUpdatesFromServer(Guid TaskID, string EncryptionKey, DateTime CutoffTime, IProgress<Tuple<int, int, int>> progress)
        {
            TaskUpdateService service = new TaskUpdateService();
            progress.Report(new Tuple<int, int, int>(1, 0, 100));
            List<TaskUpdate> updates = await service.DownloadTaskUpdateDetails(TaskID, Guid.Empty, CutoffTime);

            List<TaskUpdate> MostRecentForEach = updates.GroupBy(o => o.ItemID).Select(g => g.OrderByDescending(y => y.LastUpdatedUTC).FirstOrDefault()).ToList();

            int totalUpdates = MostRecentForEach.Count;
            int completedUpdates = 0;

            progress.Report(new Tuple<int, int, int>(2, 0, totalUpdates));

            await Task.Run(() =>
            {
                int decryptCount = 0;
                foreach (TaskUpdate update in MostRecentForEach)
                {
                    if (!CurrentIncident.allTaskUpdates.Any(o => o.UpdateID == update.UpdateID) && update.Data == null && !string.IsNullOrEmpty(update.DataEnc))
                    {
                        update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentIncident.TaskEncryptionKey);
                    }
                    update.UploadedSuccessfully = true;
                    decryptCount++;
                    progress.Report(new Tuple<int, int, int>(3, decryptCount, totalUpdates));
                }

            });

            progress.Report(new Tuple<int, int, int>(4, 0, totalUpdates));
            await Task.Delay(100);

            foreach (TaskUpdate update in MostRecentForEach)
            {
                ProcessTaskUpdate(update);
                completedUpdates++;
                //InternetSyncEventArgs args = new InternetSyncEventArgs(completedUpdates, totalUpdates);
                //OnInternetSyncProgressUpdated(args);
                progress.Report(new Tuple<int, int, int>(4, completedUpdates, totalUpdates));
                await Task.Delay(10);

            }

            return true;
        }

        public async Task<bool> LoadNewTaskFromServer(Guid TaskID, string EncryptionKey, IProgress<Tuple<int, int, int>> progress)
        {
            CurrentIncident = new Incident();
            CurrentIncident.allTaskUpdates.Clear();
            CurrentIncident.TaskEncryptionKey = EncryptionKey;

            TaskUpdateService service = new TaskUpdateService();
            progress.Report(new Tuple<int, int, int>(1, 0, 100));
            List<TaskUpdate> updates = await service.DownloadTaskUpdateDetails(TaskID, Guid.Empty, DateTime.MinValue);



            if (updates.Any(o => o.CommandName.Equals("INITIAL")))
            {
                ApplyTaskUpdate(updates.First(o => o.CommandName.Equals("INITIAL")));

            }

            await LoadOutstandingTaskUpdatesFromServer(TaskID, EncryptionKey, DateTime.MinValue, progress);

            OnIncidentChanged(new IncidentEventArgs(_currentIncident));
            return true;
        }

        public async Task ConnectToServerTaskAsync(Guid TaskID, string EncryptionKey, IProgress<Tuple<int, int, int>> progress)
        {
            TaskUpdateService service = new TaskUpdateService();

            DateTime LastGoodSend = DateTime.MinValue;
            if (allTaskUpdates.Any(o => o.UploadedSuccessfully))
            {
                LastGoodSend = allTaskUpdates.Where(o => o.UploadedSuccessfully).Max(o => o.LastUpdatedUTC);
            }

            List<TaskUpdate> localUpdates = allTaskUpdates.Where(o => !o.UploadedSuccessfully).ToList();
            int uploadCount = 0;

            foreach (TaskUpdate update in localUpdates)
            {
                _ = await uploadTaskUpdateToServer(update);
                uploadCount++;
                progress.Report(new Tuple<int, int, int>(0, uploadCount, localUpdates.Count));
            }



            await LoadOutstandingTaskUpdatesFromServer(TaskID, EncryptionKey, LastGoodSend, progress);



            OnIncidentChanged(new IncidentEventArgs(_currentIncident));

        }


        #endregion

        #region Communications Plan
        public List<CommsPlanItem> GetCommsPlanItems(bool includeBlank, bool ActiveOnly = true)
        {
            List<CommsPlanItem> canonicalItems = BuildAllCommsOptions();
            List<CommsPlanItem> items = new List<CommsPlanItem>();
            foreach (CommsPlanItem item in canonicalItems) { items.Add(item.Clone()); }
            items = items.OrderBy(o => o.CommsSystem).ThenBy(o => o.ChannelID).ToList();
            if (includeBlank)
            {
                CommsPlanItem blankrepeater = new CommsPlanItem();
                blankrepeater.IsRepeater = true;
                blankrepeater.Active = true;
                blankrepeater.ItemID = Guid.Empty;
                items.Insert(0, blankrepeater);
            }
            if (ActiveOnly) { return items.Where(o => o.Active).ToList(); }
            return items;
        }

        private List<CommsPlanItem> BuildAllCommsOptions()
        {
            List<CommsPlanItem> _CommsSystemsAvailable = new List<CommsPlanItem>();
            GeneralOptionsService service = new GeneralOptionsService(true);
            GeneralOptions options = service.GetGeneralOptions();
            _CommsSystemsAvailable.AddRange(options.allCommsPlanItems.Where(o => o.Active));

            List<CommsPlanItem> usedItems = _currentIncident.getCommsPlanItemsUsedToDate();
            foreach (CommsPlanItem item in usedItems.Where(o => o.Active))
            {
                if (!string.IsNullOrEmpty(item.ChannelID) && !_CommsSystemsAvailable.Where(o => o.ItemID == item.ItemID || o.ChannelID == item.ChannelID).Any()) { _CommsSystemsAvailable.Add(item); }
            }

            _CommsSystemsAvailable = _CommsSystemsAvailable.OrderBy(o => o.CommsSystem).ThenBy(o => o.ChannelID).ToList();
            return _CommsSystemsAvailable;
        }

        // Comms Plan 
        protected virtual void OnCommsPlanChanged(CommsPlanEventArgs e)
        {
            CommsPlanEventHandler handler = this.CommsPlanChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertCommsPlan(CommsPlan record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allCommsPlans.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.allCommsPlans = _currentIncident.allCommsPlans.Where(o => o.ID != record.ID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentIncident.allCommsPlans.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnCommsPlanChanged(new CommsPlanEventArgs(record));
        }

        // Comms Plan item
        protected virtual void OnCommsPlanItemChanged(CommsPlanItemEventArgs e)
        {
            CommsPlanItemEventHandler handler = this.CommsPlanItemChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        protected virtual void OnCommsPlanItemListChanged(CommsPlanItemEventArgs e)
        {
            CommsPlanItemListEventHandler handler = this.CommsPlanItemListChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertCommsPlanItem(CommsPlanItem item, string function = null, string source = "local")
        {
            CurrentIncident.createCommsPlanAsNeeded(item.OpPeriod);
            CommsPlan plan = CurrentIncident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == item.OpPeriod);
            if (plan != null)
            {
                if (string.IsNullOrEmpty(function)) { function = item.CommsFunction; }

                plan.allCommsItems = plan.allCommsItems.Where(o => o.ItemID != item.ItemID).ToList();
                plan.AddCommsItem(item);
                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(item, "UPSERT", true, false);
                }
                OnCommsPlanItemChanged(new CommsPlanItemEventArgs(item));

            }
        }

        public void UpsertComms(CommsLogEntry entry, string source = "local")
        {
            entry.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allCommsLogEntries.Any(o => o.EntryID == entry.EntryID)) { _currentIncident.allCommsLogEntries = _currentIncident.allCommsLogEntries.Where(o => o.EntryID != entry.EntryID).ToList(); }
            _currentIncident.allCommsLogEntries.Add(entry);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(entry, "UPSERT", true, false); }
            OnCommsChanged(new CommsEventArgs(entry));

        }
        protected virtual void OnCommsChanged(CommsEventArgs e)
        {
            CommsEventHandler handler = this.CommsChanged;
            if (handler != null)
            {
                handler(e);
            }
        }


        #endregion

        #region Briefing (not currently in use)
        // Briefing Changed
        protected virtual void OnBriefingChanged(BriefingEventArgs e)
        {
            BriefingEventHandler handler = this.BriefingChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertBriefing(Briefing record, string source = "local")
        {
            record.DateUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allBriefings.Any(o => o.BriefingID == record.BriefingID))
            {
                _currentIncident.allBriefings = _currentIncident.allBriefings.Where(o => o.BriefingID != record.BriefingID).ToList();
            }
            _currentIncident.allBriefings.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnBriefingChanged(new BriefingEventArgs(record));
        }
        #endregion

        #region Contacts
        // Contact
        protected virtual void OnContactChanged(ContactEventArgs e)
        {
            ContactEventHandler handler = this.ContactChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertContact(Contact record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allContacts.Any(o => o.ContactID == record.ContactID))
            {
                _currentIncident.allContacts = _currentIncident.allContacts.Where(o => o.ContactID != record.ContactID).ToList();
            }
            _currentIncident.allContacts.Add(record);
            _currentIncident.allContacts = CurrentIncident.allContacts.OrderBy(o => o.ContactName).ToList();

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnContactChanged(new ContactEventArgs(record));
        }
        #endregion

        #region Objectives
        // Incident Objectives
        protected virtual void OnIncidentObjectivesSheetChanged(IncidentObjectivesSheetEventArgs e)
        {
            IncidentObjectivesSheetEventHandler handler = this.IncidentObjectivesSheetChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertIncidentObjectivesSheet(IncidentObjectivesSheet record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllIncidentObjectiveSheets.Any(o => o.SheetID == record.SheetID))
            {
                _currentIncident.AllIncidentObjectiveSheets = _currentIncident.AllIncidentObjectiveSheets.Where(o => o.SheetID != record.SheetID).ToList();
            }
            record.RenumberObjectives();
            _currentIncident.AllIncidentObjectiveSheets.Add(record.Clone());


            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnIncidentObjectivesSheetChanged(new IncidentObjectivesSheetEventArgs(record));
        }








        protected virtual void OnIncidentObjectiveChanged(IncidentObjectiveEventArgs e)
        {
            IncidentObjectiveEventHandler handler = this.IncidentObjectiveChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertIncidentObjective(IncidentObjective record, string source = "local")
        {
            record.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
            IncidentObjectivesSheet sheet = null;

            if (!_currentIncident.AllIncidentObjectiveSheets.Any(o => o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.createObjectivesSheetAsNeeded(record.OpPeriod);
                sheet = _currentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == record.OpPeriod);
                UpsertIncidentObjectivesSheet(sheet);
            }
            else { sheet = _currentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == record.OpPeriod); }



            if (sheet.Objectives.Any(o => o.IncidentObjectiveID == record.IncidentObjectiveID))
            {
                sheet.Objectives = sheet.Objectives.Where(o => o.IncidentObjectiveID != record.IncidentObjectiveID).ToList();
            }
            sheet.Objectives.Add(record.Clone());
            sheet.RenumberObjectives();

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnIncidentObjectiveChanged(new IncidentObjectiveEventArgs(record));
        }
        #endregion

        #region Medical Plan
        // Medical Plans
        protected virtual void OnMedicalPlanChanged(MedicalPlanEventArgs e)
        {
            MedicalPlanEventHandler handler = this.MedicalPlanChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertMedicalPlan(MedicalPlan record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allMedicalPlans.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.allMedicalPlans = _currentIncident.allMedicalPlans.Where(o => o.ID != record.ID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentIncident.allMedicalPlans.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnMedicalPlanChanged(new MedicalPlanEventArgs(record));
        }


        // Ambulance
        protected virtual void OnAmbulanceChanged(AmbulanceServiceEventArgs e)
        {
            AmbulanceServiceEventHandler handler = this.AmbulanceServiceChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertAmbulance(AmbulanceService record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            _currentIncident.createMedicalPlanAsNeeded(record.OpPeriod);
            MedicalPlan plan = _currentIncident.allMedicalPlans.FirstOrDefault(o => o.OpPeriod == record.OpPeriod);
            plan.Ambulances = plan.Ambulances.Where(o => o.AmbulanceID != record.AmbulanceID).ToList();
            plan.Ambulances.Add(record);

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnAmbulanceChanged(new AmbulanceServiceEventArgs(record));
        }
        // Aid Station
        protected virtual void OnMedicalAidStationChanged(MedicalAidStationEventArgs e)
        {
            MedicalAidStationEventHandler handler = this.MedicalAidStationChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertMedicalAidStation(MedicalAidStation record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            _currentIncident.createMedicalPlanAsNeeded(record.OpPeriod);
            MedicalPlan plan = _currentIncident.allMedicalPlans.FirstOrDefault(o => o.OpPeriod == record.OpPeriod);
            plan.MedicalAidStations = plan.MedicalAidStations.Where(o => o.AidStationID != record.AidStationID).ToList();
            plan.MedicalAidStations.Add(record);

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnMedicalAidStationChanged(new MedicalAidStationEventArgs(record));
        }
        // Hospital
        protected virtual void OnHospitalChanged(HospitalEventArgs e)
        {
            HospitalEventHandler handler = this.HospitalChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertHospital(Hospital record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            _currentIncident.createMedicalPlanAsNeeded(record.OpPeriod);
            MedicalPlan plan = _currentIncident.allMedicalPlans.FirstOrDefault(o => o.OpPeriod == record.OpPeriod);
            plan.Hospitals = plan.Hospitals.Where(o => o.HospitalID != record.HospitalID).ToList();
            plan.Hospitals.Add(record);

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnHospitalChanged(new HospitalEventArgs(record));
        }

        #endregion

        #region Operational Periods
        // Operational Period
        protected virtual void OnOperationalPeriodChanged(OperationalPeriodEventArgs e)
        {
            OperationalPeriodEventHandler handler = this.OperationalPeriodDetailsChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertOperationalPeriod(OperationalPeriod record, string source = "local")
        {

            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllOperationalPeriods.Any(o => o.OperationalPeriodID == record.OperationalPeriodID || o.PeriodNumber == record.PeriodNumber))
            {
                _currentIncident.AllOperationalPeriods = _currentIncident.AllOperationalPeriods.Where(o => o.OperationalPeriodID != record.OperationalPeriodID && o.PeriodNumber != record.PeriodNumber).ToList();
            }
            _currentIncident.AllOperationalPeriods.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnOperationalPeriodChanged(new OperationalPeriodEventArgs(record));
        }
        #endregion

        #region Organization Chart

        // Org Chart
        protected virtual void OnOrganizationalChartChanged(OrganizationChartEventArgs e)
        {
            OrganizationalChartEventHandler handler = this.OrganizationalChartChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertOrganizationalChart(OrganizationChart record, string source = "local")
        {
            UpsertOrganizationalChart(record, true, source);
        }

        public void UpsertOrganizationalChart(OrganizationChart record, bool UpsertRoles, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allOrgCharts.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.allOrgCharts = _currentIncident.allOrgCharts.Where(o => o.ID != record.ID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentIncident.allOrgCharts.Add(record);


            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }

            /*
            if (UpsertRoles)
            {
                foreach(ICSRole role in record.AllRoles) { UpsertICSRole(role); }
            }
            */
            OnOrganizationalChartChanged(new OrganizationChartEventArgs(record));
        }
        // ICSRole
        protected virtual void OnICSRoleChanged(ICSRoleEventArgs e)
        {
            ICSRoleEventHandler handler = this.ICSRoleChanged;
            if (handler != null)
            {
                handler(e);
            }
        }


        public void UpsertICSRole(ICSRole record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (!_currentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.createOrgChartAsNeeded(record.OpPeriod);
                OrganizationChart chart = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == record.OpPeriod).First();
                UpsertOrganizationalChart(chart);
            }
            else if (!_currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any())
            {
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles = OrganizationalChartTools.GetBlankPrimaryRoles();
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).SortRoles();
                UpsertOrganizationalChart(_currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).Clone());
            }

            if (_currentIncident.allOrgCharts.Any(o => o.ID == record.OrganizationalChartID))
            {
                OrganizationChart chart = _currentIncident.allOrgCharts.First(o => o.ID == record.OrganizationalChartID);
                if (chart.AllRoles.Any(o => o.RoleID == record.RoleID))
                {

                    chart.AllRoles = chart.AllRoles.Where(o => o.RoleID != record.RoleID).ToList();
                }
                chart.AllRoles.Add(record);


                //chart.AllRoles = chart.AllRoles.OrderBy(o=>o.MaualSortOrder).ThenBy(o=>o.RoleName).ToList();
                chart.SortRoles();
                //UpsertOrganizationalChart(chart.Clone());

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(record, "UPSERT", true, false);
                }

                OnICSRoleChanged(new ICSRoleEventArgs(record));

                if (record.IndividualID != Guid.Empty && _currentIncident.IncidentPersonnel.Any(o => o.ID == record.IndividualID))
                {
                    Personnel p = _currentIncident.IncidentPersonnel.First(o => o.ID == record.IndividualID);

                    p.CurrentStatus = _currentIncident.getMemberStatus(p, record.OpPeriod, DateTime.Now);
                    UpsertPersonnel(p);
                }


                if(record.OperationalGroupID != Guid.Empty && _currentIncident.ActiveOperationalGroups.Any(o=>o.ID == record.OperationalGroupID))
                {
                    OperationalGroup group = _currentIncident.ActiveOperationalGroups.First(o => o.ID == record.OperationalGroupID);
                    if(!group.LeaderName.EqualsWithNull(record.IndividualName) || group.LeaderICSRoleID != record.RoleID || group.LeaderID != record.IndividualID)
                    {
                        group.LeaderICSRoleID = record.RoleID;
                        group.LeaderID = record.IndividualID;
                        group.LeaderName = record.IndividualName;
                        UpsertOperationalGroup(group);
                    }
                }

                //OnOrganizationalChartChanged(new OrganizationChartEventArgs(chart));
            }

        }


        public void UpsertICSRole(string roleName, int opsPeriod, Personnel member, string source = "local")
        {

            if (!_currentIncident.allOrgCharts.Any(o => o.OpPeriod == opsPeriod))
            {
                _currentIncident.createOrgChartAsNeeded(opsPeriod);
                OrganizationChart chart = _currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod);
                UpsertOrganizationalChart(chart);
            }
            else if (_currentIncident.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().AllRoles.Any())
            {
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod).AllRoles = OrganizationalChartTools.GetBlankPrimaryRoles();
                UpsertOrganizationalChart(_currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod));
            }

            ICSRole role = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().GetRoleByName(roleName).Clone();
            //role.teamMember = member;
            role.IndividualID = member.ID;
            role.IndividualName = member.Name;
            role.OpPeriod = opsPeriod;
            role.OrganizationalChartID = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().ID;
            UpsertICSRole(role);

            /*
            if (saveToDatabase)
            {
                role.saveOrgChartRoleToDB();
            }
            */
        }

        public void DeleteICSRole(ICSRole roleToDelete, int opsPeriod, string source = "local")
        {
            roleToDelete.Active = false;
            UpsertICSRole(roleToDelete, source);
            if (CurrentIncident.AllOperationalGroups.Any(o => o.LeaderICSRoleID == roleToDelete.RoleID))
            {
                foreach (OperationalGroup group in CurrentIncident.AllOperationalGroups.Where(o => o.LeaderICSRoleID == roleToDelete.RoleID))
                {
                    group.Active = false;
                    UpsertOperationalGroup(group);
                }
            }
        }

        #endregion

        #region Operational Groups
        public void UpsertCrew(Crew record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (CurrentIncident.AllIncidentResources.Any(o => o.ID == record.ID)) { CurrentIncident.AllIncidentResources = CurrentIncident.AllIncidentResources.Where(o => o.ID != record.ID).ToList(); }
            CurrentIncident.AllIncidentResources.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "UPSERT", true, false); }
            CurrentIncident.SetOpGroupDepths(record.OpPeriod);
            CurrentIncident.UpdateThisGroupCount(record);
            OnCrewChanged(new CrewEventArgs(record));

        }
        protected virtual void OnCrewChanged(CrewEventArgs e)
        {
            OperationalSubGroupEventHandler handler = this.OperationalSubGroupChanged;
            if (handler != null)
            {
                handler(e);
            }
        }



        public void UpsertOperationalGroup(OperationalGroup record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;


            if (CurrentIncident.AllOperationalGroups.Any(o => o.ID == record.ID))
            {
                CurrentIncident.AllOperationalGroups = CurrentIncident.AllOperationalGroups.Where(o => o.ID != record.ID).ToList();
            }
            record.GetOpGroupDepth(CurrentIncident);
            CurrentIncident.UpdateThisGroupCount(record);
            CurrentIncident.AllOperationalGroups.Add(record);


            if (CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod))
            {
                OrganizationChart CurrentOrgChart = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod);
                ICSRole leader = CurrentOrgChart.AllRoles.FirstOrDefault(o=>o.RoleID == record.LeaderICSRoleID);
                
                if(leader != null && (leader.IndividualID != record.LeaderID || leader.OperationalGroupName != record.Name))
                {
                    leader.IndividualID = record.LeaderID;
                    leader.IndividualName = record.LeaderName;
                    leader.OperationalGroupName = record.Name;
                    UpsertICSRole(leader);
                }

            }
                /*
                 if (CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod))
                 {
                     OrganizationChart CurrentOrgChart = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod);

                     //Add new entries to the Org Chart if needed
                     // if (record.IsBranchOrDiv)
                     // {
                     if (!CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any(o => o.OperationalGroupID == record.ID))
                     {

                         //are any of the generic branch thingies available?
                         Guid potential1 = new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c");
                         Guid potential2 = new Guid("9727f016-aed9-4f34-99db-910a06b97f2e");
                         Guid potential3 = new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9");
                         ICSRole NewRole = new ICSRole();
                         NewRole.IndividualID = Guid.Empty;


                         if (record.GroupType.Equals("Branch"))
                         {
                             if (!string.IsNullOrEmpty(record.Name) && record.Name.Equals("Heavy Equipment"))
                             {
                                 NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Heavy Equipment Branch Director"));
                             }
                             else
                             {
                                 NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Operations Branch Director"));

                             }
                         }
                         else if (record.GroupType.Equals("Division"))
                         {
                             NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Division Supervisor"));
                         }
                         else if (record.GroupType.Equals("Strike Team"))
                         {
                             NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Strike Team Leader"));
                         }
                         else if (record.GroupType.Equals("Task Force"))
                         {
                             NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Task Force Leader"));
                         }
                         else
                         {
                             NewRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByName("Operational Group Supervisor"));
                             NewRole.IsOpGroupSup = true;
                         }

                         if (record.GroupType.Equals("Branch") && CurrentOrgChart.ActiveRoles.Any(o => (o.RoleID == potential1 || o.RoleID == potential2 || o.RoleID == potential3) && o.RoleName.Contains("Branch/Division/Group") && o.IndividualID == Guid.Empty))
                         {
                             ICSRole toReplace = CurrentOrgChart.ActiveRoles.First(o => (o.RoleID == potential1 || o.RoleID == potential2 || o.RoleID == potential3) && o.RoleName.Contains("Branch/Division/Group") && o.IndividualID == Guid.Empty);
                             NewRole.RoleID = toReplace.RoleID;
                             NewRole.PDFFieldName = toReplace.PDFFieldName;
                             NewRole.PDFTitleName = toReplace.PDFTitleName;
                             NewRole.ManualSortOrder = toReplace.ManualSortOrder;
                         }


                         NewRole.OperationalGroupID = record.ID;
                         NewRole.OrganizationalChartID = CurrentOrgChart.ID;
                         NewRole.OpPeriod = CurrentOrgChart.OpPeriod;
                         NewRole.Active = true;
                         NewRole.ReportsTo = record.ParentID;
                         NewRole.ReportsToRoleName = CurrentOrgChart.GetRoleByID(record.ParentID, false).RoleName;

                         if (!string.IsNullOrEmpty(NewRole.RoleNameWithPlaceholder))
                         {
                             NewRole.OperationalGroupName = record.ResourceName;

                         }

                         UpsertICSRole(NewRole);
                         record.LeaderICSRoleID = NewRole.RoleID; record.LeaderICSRoleName = NewRole.RoleName;
                     }
                     else if (CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any(o => o.OperationalGroupID == record.ID))
                     {
                         //may need to change who the role reports to
                         ICSRole role = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.First(o => o.OperationalGroupID == record.ID);
                         if (role.ReportsTo != record.ParentID && CurrentOrgChart.GetRoleByID(record.ParentID, false) != null)
                         {
                             role.ReportsTo = record.ParentID;
                             role.ReportsToRoleName = CurrentOrgChart.GetRoleByID(record.ParentID, false).RoleName;
                             UpsertICSRole(role);
                         }

                     }
                 }

                 if (CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod) && CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any(o => o.OperationalGroupID == record.ID) && CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.First(o => o.OperationalGroupID == record.ID).IndividualID != record.LeaderID)
                 {
                     ICSRole role = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.First(o => o.OperationalGroupID == record.ID);
                     if (CurrentIncident.IncidentPersonnel.Any(o => o.PersonID == record.LeaderID))
                     {
                         Personnel per = CurrentIncident.IncidentPersonnel.First(o => o.PersonID == record.LeaderID);

                         role.IndividualID = record.LeaderID;
                         role.IndividualName = record.LeaderName;
                         UpsertICSRole(role);
                     }
                 }
                */
                // }
                CurrentIncident.SetOpGroupDepths(record.OpPeriod);

            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "UPSERT", true, false); }
            OnOperationalGroupChanged(new OperationalGroupEventArgs(record));
        }
        protected virtual void OnOperationalGroupChanged(OperationalGroupEventArgs e)
        {
            OperationalGroupEventHandler handler = this.OperationalGroupChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        #endregion


        #region Position Log
        // Position Log
        protected virtual void OnPositionLogEntryChanged(PositionLogEventArgs e)
        {
            PositionLogEventHandler handler = this.PositionLogChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertPositionLogEntry(PositionLogEntry record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allPositionLogEntries.Any(o => o.LogID == record.LogID))
            {
                _currentIncident.allPositionLogEntries = _currentIncident.allPositionLogEntries.Where(o => o.LogID != record.LogID).ToList();
            }
            _currentIncident.allPositionLogEntries.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnPositionLogEntryChanged(new PositionLogEventArgs(record));
        }

        #endregion

        #region Safety Message

        // Safety Plan
        protected virtual void OnSafetyMessageChanged(SafetyMessageEventArgs e)
        {
            SafetyMessageEventHandler handler = this.SafetyMessageChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertSafetyMessage(SafetyMessage record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allSafetyMessages.Any(o => o.ID == record.ID))
            {
                _currentIncident.allSafetyMessages = _currentIncident.allSafetyMessages.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.allSafetyMessages.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnSafetyMessageChanged(new SafetyMessageEventArgs(record));
        }
        #endregion

        #region Task Basics
        // Task Basics
        protected virtual void OnTaskBasicsChanged(TaskBasicsEventArgs e)
        {
            TaskBasicsEventHandler handler = this.TaskBasicsChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpdateTaskBasics(TaskBasics basics, string source)
        {
            _currentIncident.TaskName = basics.TaskName;
            _currentIncident.TaskNumber = basics.TaskNumber;
            _currentIncident.AgencyFileNumber = basics.AgencyFileNumber;
            _currentIncident.ICPCallSign = basics.ICPCallSign;
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(basics, "UPSERT", true, false);
            }

            OnTaskBasicsChanged(new TaskBasicsEventArgs(basics));
        }
        #endregion

        #region General Message

        // General Message
        protected virtual void OnGeneralMessageChanged(GeneralMessageEventArgs e)
        {
            GeneralMessageEventHandler handler = this.GeneralMessageChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertGeneralMessage(GeneralMessage record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllGeneralMessages.Any(o => o.MessageID == record.MessageID))
            {
                _currentIncident.AllGeneralMessages = _currentIncident.AllGeneralMessages.Where(o => o.MessageID != record.MessageID).ToList();
            }
            _currentIncident.AllGeneralMessages.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnGeneralMessageChanged(new GeneralMessageEventArgs(record));
        }
        #endregion

        #region Air Ops Plan

        //Aircraft
        protected virtual void OnAircraftChanged(AircraftEventArgs e)
        {
            AircraftEventHandler handler = this.AircraftChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertAircraft(Aircraft record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;

            if (_currentIncident.AllIncidentResources.Any(o => o.ID == record.ID))
            {
                _currentIncident.AllIncidentResources = _currentIncident.AllIncidentResources.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllIncidentResources.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnAircraftChanged(new AircraftEventArgs(record));

            //Also, add it to the air ops summary automagically



            _currentIncident.createAirOpsSummaryAsNeeded(record.OpPeriod);
            /*
            AirOperationsSummary sum = _currentIncident.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == record.OpPeriod);
            if (sum != null)
            {
                if (sum.aircrafts.Any(o => o.ID == record.ID))
                {
                    sum.aircrafts = sum.aircrafts.Where(o => o.ID != record.ID).ToList();
                }
                sum.aircrafts.Add(record);
                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(sum, "UPSERT", true, false);
                }
                OnAircraftChanged(new AircraftEventArgs(record));

            }
            */
        }

        protected virtual void OnAirOperationsSummaryChanged(AirOperationsSummaryEventArgs e)
        {
            AircraftsOperationsSummaryEventHandler handler = this.AircraftsOperationsSummaryChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertAirOperationsSummary(AirOperationsSummary record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allAirOperationsSummaries.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.allAirOperationsSummaries = _currentIncident.allAirOperationsSummaries.Where(o => o.ID != record.ID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentIncident.allAirOperationsSummaries.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnAirOperationsSummaryChanged(new AirOperationsSummaryEventArgs(record));
        }

        #endregion

        #region Vehicles
        // Vehicle
        protected virtual void OnVehicleChanged(VehicleEventArgs e)
        {
            VehicleEventHandler handler = this.VehicleChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertVehicle(Vehicle record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllIncidentResources.Any(o => o.ID == record.ID))
            {
                _currentIncident.AllIncidentResources = _currentIncident.AllIncidentResources.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllIncidentResources.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnVehicleChanged(new VehicleEventArgs(record));
        }

        #endregion

        #region Personnel
        public void UpsertIncidentResource(IncidentResource record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllIncidentResources.Any(o => o.ID == record.ID))
            {
                _currentIncident.AllIncidentResources = _currentIncident.AllIncidentResources.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllIncidentResources.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            if (record.GetType().Name.Equals("Vehicle")) { OnVehicleChanged(new VehicleEventArgs(record as Vehicle)); }
            else if (record.GetType().Name.Equals("Personnel")) { OnMemberSignInChanged(new CheckInEventArgs(record as Personnel)); }
            else if (record.GetType().Name.Equals("OperationalSubGroup")) { OnCrewChanged(new CrewEventArgs(record as Crew)); }
        }


        //Personnel Status
        public void UpsertCheckInRecord(CheckInRecord signIn, bool autoAssignToOrgIfPossible = false, string source = "local")
        {
            if (_currentIncident.AllCheckInRecords.Any(o => o.SignInRecordID == signIn.SignInRecordID))
            {
                _currentIncident.AllCheckInRecords = _currentIncident.AllCheckInRecords.Where(o => o.SignInRecordID != signIn.SignInRecordID).ToList();
            }
            _currentIncident.AllCheckInRecords.Add(signIn);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(signIn, "UPSERT", true, false); }




            OnMemberSignInChanged(new CheckInEventArgs(signIn));
        }
        public void UpsertPersonnel(Personnel member, string source = "local")
        {
            if (member != null)
            {
                if (member.UniqueIDNum == 0)
                {
                    ;
                }

                _currentIncident.UpsertTaskTeamMember(member);
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(member, "UPSERT", true, false); }

                foreach (OrganizationChart chart in _currentIncident.allOrgCharts)
                {
                    if (chart.ActiveRoles.Any(o => o.IndividualID == member.ID && !o.IndividualName.EqualsWithNull(member.Name)))
                    {
                        ICSRole role = chart.ActiveRoles.First(o => o.IndividualID == member.ID && !o.IndividualName.EqualsWithNull(member.Name));
                        role.IndividualName = member.Name;
                        UpsertICSRole(role);
                    }
                }
            }
            OnMemberSignInChanged(new CheckInEventArgs(member));
        }

        protected virtual void OnMemberSignInChanged(CheckInEventArgs e)
        {
            CheckInEventHandler handler = this.MemberSignInChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        #endregion

        #region Notes

        //Note
        public void UpsertNote(Note note, string source = "local")
        {

            note.DateUpdated = DateTime.Now;
            if (note.DateCreated == DateTime.MinValue) { note.DateCreated = note.DateUpdated; }

            if (CurrentIncident.allNotes.Any(o => o.NoteID == note.NoteID))
            {
                CurrentIncident.allNotes = CurrentIncident.allNotes.Where(o => o.NoteID != note.NoteID).ToList();
            }
            CurrentIncident.allNotes.Add(note);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(note, "UPSERT", true, false); }
            OnNoteChanged(new NoteEventArgs(note));
        }
        protected virtual void OnNoteChanged(NoteEventArgs e)
        {
            NoteEventHandler handler = this.NoteChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        #endregion

        #region Gear
        // Equipment Stuff
        public void UpsertTaskEquipment(IncidentGear te, string source = "local")
        {

            te.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allEquipment.Any(o => o.EquipmentID == te.EquipmentID && o.OpPeriod == te.OpPeriod))
            {
                _currentIncident.allEquipment = _currentIncident.allEquipment.Where(o => o.EquipmentID != te.EquipmentID || o.OpPeriod != te.OpPeriod).ToList();
            }
            _currentIncident.allEquipment.Add(te);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(te, "UPSERT", true, false); }
            OnTaskEquipmentChanged(new TaskEquipmentEventArgs(te));
        }
        /*
        public void DeleteTaskEquipment(TaskEquipment te, string source = "local")
        {

            te.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allEquipment.Any(o => o.EquipmentID == te.EquipmentID && o.OpPeriod == te.OpPeriod))
            {
                _currentIncident.allEquipment = _currentIncident.allEquipment.Where(o => o.EquipmentID != te.EquipmentID || o.OpPeriod != te.OpPeriod).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(te, "DELETE", true, false); }
                OnTaskEquipmentChanged(new TaskEquipmentEventArgs(te));
            }

        }*/

        protected virtual void OnTaskEquipmentChanged(TaskEquipmentEventArgs e)
        {
            TaskEquipmentEventHandler handler = this.TaskEquipmentChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertEquipmentIssue(GearIssue issue, string source = "local")
        {

            issue.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allEquipmentIssues.Any(o => o.IssueID != issue.IssueID))
            {
                _currentIncident.allEquipmentIssues = _currentIncident.allEquipmentIssues.Where(o => o.IssueID != issue.IssueID).ToList();
            }
            _currentIncident.allEquipmentIssues.Add(issue);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(issue, "UPSERT", true, false); }
            OnEquipmentIssueChanged(new EquipmentIssueEventArgs(issue));
        }
        protected virtual void OnEquipmentIssueChanged(EquipmentIssueEventArgs e)
        {
            EquipmentIssueEventHandler handler = this.EquipmentIssueChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        #endregion


        #region Demobilizations
        // Demob Records
        protected virtual void OnDemobChanged(DemobEventArgs e)
        {
            DemobEventHandler handler = this.DemobilizatoinRecordChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertDemobRecord(DemobilizationRecord record, string source = "local")
        {
            if (record.SignInRecordID == Guid.Empty)
            {

            }
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllDemobilizationRecords.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.AllDemobilizationRecords = _currentIncident.AllDemobilizationRecords.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllDemobilizationRecords.Add(record);

            if (record.SignInRecordID != Guid.Empty && _currentIncident.AllCheckInRecords.Any(o => o.SignInRecordID == record.SignInRecordID))
            {
                _currentIncident.AllCheckInRecords.First(o => o.SignInRecordID == record.SignInRecordID).CheckOutDate = record.DemobDate;
                UpsertCheckInRecord(_currentIncident.AllCheckInRecords.First(o => o.SignInRecordID == record.SignInRecordID));
            }
            else
            {

            }

            //If this is a crew, demob everyone in it with the same values
            if (_currentIncident.AllOperationalSubGroups.Any(o => o.ID == record.ResourceID))
            {
                Crew crew = _currentIncident.AllOperationalSubGroups.First(o => o.ID == record.ResourceID);
                foreach (OperationalGroupResourceListing res in crew.ResourceListing)
                {
                    DemobilizationRecord demobRec = record.Clone();
                    demobRec.ResourceID = res.ResourceID;
                    demobRec.ID = Guid.NewGuid();
                    if (_currentIncident.AllCheckInRecords.Any(o => o.ResourceID == res.ResourceID && o.ParentRecordID == record.SignInRecordID))
                    {
                        demobRec.SignInRecordID = _currentIncident.AllCheckInRecords.First(o => o.ResourceID == res.ResourceID && o.ParentRecordID == record.SignInRecordID).SignInRecordID;
                    }
                    else
                    {
                        demobRec.SignInRecordID = Guid.Empty;
                    }

                    UpsertDemobRecord(demobRec);
                }
            }

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnDemobChanged(new DemobEventArgs(record));
        }


        // Resource Replacement Plan
        protected virtual void OnResourceReplacementPlanChanged(ResourceReplacementPlanEventArgs e)
        {
            ResourceReplacementEventHandler handler = this.ResourceReplacementChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertResourceReplacementPlan(ResourceReplacementPlan record, string source = "local")
        {

            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllResourceReplacementPlans.Any(o => o.ID == record.ID))
            {
                _currentIncident.AllResourceReplacementPlans = _currentIncident.AllResourceReplacementPlans.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllResourceReplacementPlans.Add(record);



            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnResourceReplacementPlanChanged(new ResourceReplacementPlanEventArgs(record));
        }
        #endregion

        #region Incident Summaries

        //Incident Summary
        protected virtual void OnIncidentSummaryChanged(IncidentSummaryEventArgs e)
        {
            IncidentSummaryEventHandler handler = this.IncidentSummaryChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertIncidentSummary(IncidentStatusSummary record, string source = "local")
        {

            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.AllIncidentStatusSummaries.Any(o => o.ID == record.ID))
            {
                _currentIncident.AllIncidentStatusSummaries = _currentIncident.AllIncidentStatusSummaries.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.AllIncidentStatusSummaries.Add(record);



            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnIncidentSummaryChanged(new IncidentSummaryEventArgs(record));
        }
        #endregion


        #region Timeline (not in use)
        public void RefreshAutomatedTimelineEvents()
        {
            throw new NotImplementedException();
        }

        public void UpsertTimeline(Timeline record, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void UpsertTimelineEvent(TimelineEvent record, string source = "local")
        {
            throw new NotImplementedException();
        }
        #endregion





    }

}
