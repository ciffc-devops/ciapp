using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.TabStop;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Interfaces;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace WildfireICSDesktopServices
{
    public class WFIncidentService : IWFIncidentService
    {
        public event CommsEventHandler CommsChanged;
        public event MemberEventHandler MemberSignInChanged;
        public event BriefingEventHandler BriefingChanged;
        public event CommsPlanEventHandler CommsPlanChanged;
        public event CommsPlanItemEventHandler CommsPlanItemChanged;
        public event CommsPlanItemLinkEventHandler CommsPlanItemLinkChanged;
        public event ContactEventHandler ContactChanged;
        public event HospitalEventHandler HospitalChanged;
        public event AmbulanceServiceEventHandler AmbulanceServiceChanged;
        public event IncidentObjectiveEventHandler IncidentObjectiveChanged;
        public event MedicalPlanEventHandler MedicalPlanChanged;
        public event NoteEventHandler NoteChanged;
        public event OperationalPeriodEventHandler OperationalPeriodChanged;
        public event OrganizationalChartEventHandler OrganizationalChartChanged;
        public event ICSRoleEventHandler ICSRoleChanged;
        public event SafetyPlanEventHandler SafetyPlanChanged;
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

        private WFIncident _currentTask;
        public WFIncident CurrentTask { get => _currentTask; set => _currentTask = value; }
        public List<TaskUpdate> allTaskUpdates { get => _currentTask.allTaskUpdates; set => _currentTask.allTaskUpdates = value; }
        private Guid _MachineID;
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }


        public WFIncidentService(WFIncident currentTask)
        {
            _currentTask = currentTask;
            allTaskUpdates = new List<TaskUpdate>();
        }
        public WFIncidentService()
        {

        }

        public TaskUpdate UpsertTaskUpdate(object obj, string command, bool processed_locally, bool uploaded)
        {
            TaskUpdate update = new TaskUpdate();
            update.TaskID = _currentTask.TaskID;
            update.LastUpdatedUTC = DateTime.UtcNow;
            update.CommandName = command;
            update.Data = obj;
            update.DataEnc = update.Data.XmlSerializeToString();
            update.DataEnc = StringCipher.Encrypt(update.DataEnc, _currentTask.TaskEncryptionKey);
            update.ProcessedLocally = processed_locally;
            update.MachineID = MachineID;
            update.UploadedSuccessfully = uploaded;
            update.ObjectType = obj.GetType().Name.ToString();
            //Remove it in case it is a duplicate
            allTaskUpdates = allTaskUpdates.Where(o => o.UpdateID != update.UpdateID).ToList();
            allTaskUpdates.Add(update);
            allTaskUpdates = allTaskUpdates.OrderBy(o => o.LastUpdatedUTC).ToList();
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

        //This is called when a new task update is received by some means
        public void ProcessTaskUpdate(TaskUpdate update)
        {
            bool alreadyIn = allTaskUpdates.Any(o => o.UpdateID == update.UpdateID);
            if (!alreadyIn)
            {
                if (update.Data == null && !string.IsNullOrEmpty(update.DataEnc))
                {

                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentTask.TaskEncryptionKey);

                }
                ApplyTaskUpdate(update);
                UpsertTaskUpdate(update);

            }
        }



        public void ApplyTaskUpdate(TaskUpdate update, bool applyAllSubsequent = false)
        {
            if (update.Data == null && !string.IsNullOrEmpty(update.DataEnc))
            {
                update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentTask.TaskEncryptionKey);
            }

            if (!update.ProcessedLocally && update.Data != null)
            {
                string source = "internet";

                if (update.CommandName.Equals("UPSERT"))
                {
                    update.ProcessedLocally = true;
                    UpsertObject(update.Data, source);
                }
                else if (update.CommandName.Equals("DELETE"))
                {
                    update.ProcessedLocally = true;
                    DeleteObject(update.Data, source);
                }
                else if (update.CommandName.Equals("INITIAL"))
                {
                    TaskBasics basics = update.Data as TaskBasics;

                    if (update.TaskID != CurrentTask.TaskID)
                    {
                        _currentTask = new WFIncident();

                        _currentTask.TaskID = basics.TaskID;
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, "internet");

                    }
                    else
                    {
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, "internet");
                    }
                }


            }

            if (applyAllSubsequent)
            {
                List<TaskUpdate> subsequent = allTaskUpdates.Where(o => o.LastUpdatedUTC > update.LastUpdatedUTC && o.ObjectType.Equals(update.ObjectType)).ToList();

                foreach (TaskUpdate subUpdate in subsequent)
                {
                    ApplyTaskUpdate(subUpdate, false);
                }
            }
        }


        public void SendInitialTaskUpdate()
        {
            //This sends the "Initial" record, and all updates saved locally to this point.
            //It also means we need to save those updates persistently from now on

            TaskBasics basics = new TaskBasics(CurrentTask);
            TaskUpdate update = UpsertTaskUpdate(basics, "INITIAL", true, false);
            _ = uploadTaskUpdateToServer(update);

            //No need to process the other task basics updates, since a current one has already been generated.
            foreach (TaskUpdate up in allTaskUpdates.Where(o => o.ObjectType == "TaskBasics")) { up.UploadedSuccessfully = true; }


            foreach (TaskUpdate up in allTaskUpdates.Where(o => !o.UploadedSuccessfully))
            {
                _ = uploadTaskUpdateToServer(up);
            }
        }


        public async void LoadNewTaskFromServer(Guid TaskID, string EncryptionKey)
        {
            TaskUpdateService service = new TaskUpdateService();
            List<TaskUpdate> updates = await service.DownloadTaskUpdateDetails(TaskID, Guid.Empty, DateTime.MinValue);

            foreach (TaskUpdate update in updates)
            {
                if (!string.IsNullOrEmpty(update.DataEnc))
                {
                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, EncryptionKey);
                }
                update.UploadedSuccessfully = true;
            }


            if (updates.Any(o => o.CommandName.Equals("INITIAL")))
            {
                ApplyTaskUpdate(updates.First(o => o.CommandName.Equals("INITIAL")));
                CurrentTask.TaskEncryptionKey = EncryptionKey;
            }
            foreach (TaskUpdate update in updates)
            {
                ProcessTaskUpdate(update);
            }
            OnWFIncidentChanged(new WFIncidentEventArgs(_currentTask));
        }

        public async void ConnectToServerTask(Guid TaskID, string EncryptionKey)
        {
            TaskUpdateService service = new TaskUpdateService();

            List<TaskUpdate> localUpdates = allTaskUpdates.Where(o => !o.UploadedSuccessfully).ToList();

            foreach (TaskUpdate update in localUpdates)
            {
                _ = uploadTaskUpdateToServer(update);
            }

            List<TaskUpdate> updates = await service.DownloadTaskUpdateDetails(TaskID, MachineID, DateTime.MinValue);

            foreach (TaskUpdate update in updates)
            {
                update.UploadedSuccessfully = true;
                if (!string.IsNullOrEmpty(update.DataEnc))
                {
                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, EncryptionKey);
                }

                if (update.Data != null)
                {
                    ProcessTaskUpdate(update);
                }

            }
            OnWFIncidentChanged(new WFIncidentEventArgs(_currentTask));
        }

        public void UpsertObject(object obj, string source)
        {
            string dataClassName = obj.GetType().Name;
            if (dataClassName.Equals(new Briefing().GetType().Name))
            {
                UpsertBriefing(((Briefing)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new CommsLogEntry().GetType().Name))
            {
                UpsertComms(((CommsLogEntry)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new CommsPlanItem().GetType().Name))
            {
                UpsertCommsPlanItem(((CommsPlanItem)obj).Clone(), null, source);
            }
            else if (dataClassName.Equals(new CommsPlan().GetType().Name))
            {
                UpsertCommsPlan(((CommsPlan)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Contact().GetType().Name))
            {
                UpsertContact(((Contact)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TaskEquipment().GetType().Name))
            {
                UpsertTaskEquipment(((TaskEquipment)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new EquipmentIssue().GetType().Name))
            {
                UpsertEquipmentIssue(((EquipmentIssue)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Hospital().GetType().Name))
            {
                //UpsertTaskEquipment(((Hospital)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new AmbulanceService().GetType().Name))
            {
                //upsert(((AmbulanceService)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new IncidentObjective().GetType().Name))
            {
                UpsertIncidentObjective(((IncidentObjective)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new MedicalPlan().GetType().Name))
            {
                UpsertMedicalPlan(((MedicalPlan)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Note().GetType().Name))
            {
                UpsertNote(((Note)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new OperationalPeriod().GetType().Name))
            {
                UpsertOperationalPeriod(((OperationalPeriod)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new OrganizationChart().GetType().Name))
            {
                UpsertOrganizationalChart(((OrganizationChart)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new ICSRole().GetType().Name))
            {
                UpsertICSRole(((ICSRole)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new PositionLogEntry().GetType().Name))
            {
                UpsertPositionLogEntry(((PositionLogEntry)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new SafetyPlan().GetType().Name))
            {
                UpsertSafetyPlan(((SafetyPlan)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TaskBasics().GetType().Name))
            {
                UpdateTaskBasics(((TaskBasics)obj), source);
            }
            else if (dataClassName.Equals(new Timeline().GetType().Name))
            {
                UpsertTimeline(((Timeline)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TimelineEvent().GetType().Name))
            {
                UpsertTimelineEvent(((TimelineEvent)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Vehicle().GetType().Name))
            {
                UpsertVehicle(((Vehicle)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new SignInRecord().GetType().Name))
            {
                UpsertMemberStatus(((SignInRecord)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TeamMember().GetType().Name))
            {
                UpsertMemberStatus(((TeamMember)obj).Clone(), source);
            }
        }

        public void DeleteObject(object obj, string source)
        {
            string dataClassName = obj.GetType().Name;
            if (dataClassName.Equals(new CommsLogEntry().GetType().Name))
            {
                DeleteCommsLogEntry(((CommsLogEntry)obj).Clone(), source);
            }

            else if (dataClassName.Equals(new Contact().GetType().Name))
            {
                DeleteContact(((Contact)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TaskEquipment().GetType().Name))
            {
                DeleteTaskEquipment(((TaskEquipment)obj).Clone(), source);
            }


            else if (dataClassName.Equals(new IncidentObjective().GetType().Name))
            {
                DeleteIncidentObjective(((IncidentObjective)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new SafetyPlan().GetType().Name))
            {
                DeleteSafetyPlan(((SafetyPlan)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TimelineEvent().GetType().Name))
            {
                DeleteTimelineEvent(((TimelineEvent)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Vehicle().GetType().Name))
            {
                DeleteVehicle(((Vehicle)obj).Clone(), source);
            }
        }



        protected virtual void OnWFIncidentChanged(WFIncidentEventArgs e)
        {
            WFIncidentEventHandler handler = this.WfIncidentChanged;
            if (handler != null)
            {
                handler(e);
            }
        }




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

            List<CommsPlanItem> usedItems = _currentTask.getCommsPlanItemsUsedToDate();
            foreach (CommsPlanItem item in usedItems.Where(o => o.Active))
            {
                if (!string.IsNullOrEmpty(item.ChannelID) && !_CommsSystemsAvailable.Where(o => o.ItemID == item.ItemID || o.ChannelID == item.ChannelID).Any()) { _CommsSystemsAvailable.Add(item); }
            }

            _CommsSystemsAvailable = _CommsSystemsAvailable.OrderBy(o => o.CommsSystem).ThenBy(o => o.ChannelID).ToList();
            return _CommsSystemsAvailable;
        }



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
            if (_currentTask.allBriefings.Any(o => o.BriefingID == record.BriefingID))
            {
                _currentTask.allBriefings = _currentTask.allBriefings.Where(o => o.BriefingID != record.BriefingID).ToList();
            }
            _currentTask.allBriefings.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnBriefingChanged(new BriefingEventArgs(record));
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
            if (_currentTask.allCommsPlans.Any(o => o.ID == record.ID || o.OpsPeriod == record.OpsPeriod))
            {
                _currentTask.allCommsPlans = _currentTask.allCommsPlans.Where(o => o.ID != record.ID && o.OpsPeriod != record.OpsPeriod).ToList();
            }
            _currentTask.allCommsPlans.Add(record);
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
            if (string.IsNullOrEmpty(function)) { function = item.CommsFunction; }
            if (!_currentTask.allCommsPlans.Any(o => o.OpsPeriod == item.OpsPeriod))
            {
                _currentTask.createCommsPlanAsNeeded(item.OpsPeriod);
                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(_currentTask.allCommsPlans.First(o => o.OpsPeriod == item.OpsPeriod), "UPSERT", true, false);
                }
                OnCommsPlanChanged(new CommsPlanEventArgs(_currentTask.allCommsPlans.First(o => o.OpsPeriod == item.OpsPeriod)));
            }
            CommsPlan thisPlan = _currentTask.allCommsPlans.First(o => o.OpsPeriod == item.OpsPeriod);
            if (!thisPlan.allCommsItems.Any(o => o.ItemID == item.ItemID)) //its new!
            {
                thisPlan.allCommsItems.Add(item);

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(item, "UPSERT", true, false);
                }
                OnCommsPlanItemListChanged(new CommsPlanItemEventArgs(item));
                OnCommsPlanItemChanged(new CommsPlanItemEventArgs(item));
            }
            else if (thisPlan.allCommsItems.Any(o => o.ItemID == item.ItemID && !o.Equals(item)))
            {
                CommsPlanItem oldItem = thisPlan.allCommsItems.First(o => o.ItemID == item.ItemID);
                bool isEqual = oldItem.Equals(item);
                thisPlan.allCommsItems = thisPlan.allCommsItems.Where(o => o.ItemID != item.ItemID).ToList();
                thisPlan.allCommsItems.Add(item);

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(item, "UPSERT", true, false);
                }
                OnCommsPlanItemListChanged(new CommsPlanItemEventArgs(item));
                OnCommsPlanItemChanged(new CommsPlanItemEventArgs(item));
            }
            else
            {
                thisPlan.allCommsItems = thisPlan.allCommsItems.Where(o => o.ItemID != item.ItemID).ToList();
                thisPlan.allCommsItems.Add(item);

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(item, "UPSERT", true, false);
                }
                OnCommsPlanItemChanged(new CommsPlanItemEventArgs(item));
            }

            if (!string.IsNullOrEmpty(function))
            {
                UpsertCommsPlanItemLink(new CommsPlanItemLink(item.ItemID, function, item.OpsPeriod), source);
            }

        }


        protected virtual void OnCommsPlanItemLinkChanged(CommsPlanItemLinkEventArgs e)
        {
            CommsPlanItemLinkEventHandler handler = this.CommsPlanItemLinkChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertCommsPlanItemLink(CommsPlanItemLink link, string source = "local")
        {
            if (_currentTask.allCommsPlans.Any(o => o.OpsPeriod == link.OpsPeriod))
            {
                CommsPlan thisPlan = _currentTask.allCommsPlans.First(o => o.OpsPeriod == link.OpsPeriod);
                if (thisPlan.allItemLinks.Where(o => o.CommsFunction.Equals(link.CommsFunction, StringComparison.InvariantCultureIgnoreCase)).Any())
                {
                    thisPlan.allItemLinks = thisPlan.allItemLinks.Where(o => !o.CommsFunction.Equals(link.CommsFunction, StringComparison.InvariantCultureIgnoreCase)).ToList();
                }
                thisPlan.allItemLinks.Add(link);
                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(link, "UPSERT", true, false);
                }
                OnCommsPlanItemLinkChanged(new CommsPlanItemLinkEventArgs(link));
            }
        }




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
            if (_currentTask.allContacts.Any(o => o.ContactID == record.ContactID))
            {
                _currentTask.allContacts = _currentTask.allContacts.Where(o => o.ContactID != record.ContactID).ToList();
            }
            _currentTask.allContacts.Add(record);
            _currentTask.allContacts = CurrentTask.allContacts.OrderBy(o => o.ContactName).ToList();

            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnContactChanged(new ContactEventArgs(record));
        }
        public void DeleteContact(Contact contact, string source = "local")
        {
            if (_currentTask.allContacts.Any(o => o.ContactID == contact.ContactID))
            {
                _currentTask.allContacts = _currentTask.allContacts.Where(o => o.ContactID != contact.ContactID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(contact, "DELETE", true, false); }
                OnContactChanged(new ContactEventArgs(contact));
            }

        }
        public void DeleteContact(Guid contactID, string source = "local")
        {
            if (_currentTask.allContacts.Any(o => o.ContactID == contactID))
            {
                Contact contactToDelete = _currentTask.allContacts.FirstOrDefault(o => o.ContactID == contactID);
                DeleteContact(contactToDelete, source);
                //_currentTask.allContacts = _currentTask.allContacts.Where(o => o.ContactID != contactID).ToList();
                //OnContactChanged(new ContactEventArgs(contactToDelete));
            }

        }

        // Incident Objectives
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
            if (_currentTask.allObjectives.Any(o => o.IncidentObjectiveID == record.IncidentObjectiveID))
            {
                _currentTask.allObjectives = _currentTask.allObjectives.Where(o => o.IncidentObjectiveID != record.IncidentObjectiveID).ToList();
            }
            _currentTask.allObjectives.Add(record.Clone());
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnIncidentObjectiveChanged(new IncidentObjectiveEventArgs(record));
        }
        public void DeleteIncidentObjective(IncidentObjective record, string source = "local")
        {
            record.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allObjectives.Any(o => o.IncidentObjectiveID == record.IncidentObjectiveID))
            {
                _currentTask.allObjectives = _currentTask.allObjectives.Where(o => o.IncidentObjectiveID != record.IncidentObjectiveID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                _currentTask.renumberObjectives(record.OpPeriod);
                OnIncidentObjectiveChanged(new IncidentObjectiveEventArgs(record));
            }

        }
        public void DeleteIncidentObjective(Guid IncidentObjectiveID, string source = "local")
        {

            if (_currentTask.allObjectives.Any(o => o.IncidentObjectiveID == IncidentObjectiveID))
            {
                IncidentObjective toDelete = _currentTask.allObjectives.First(o => o.IncidentObjectiveID == IncidentObjectiveID);
                DeleteIncidentObjective(toDelete, source);
                /*
                _currentTask.allObjectives = _currentTask.allObjectives.Where(o => o.IncidentObjectiveID != IncidentObjectiveID).ToList();
                _currentTask.renumberObjectives(toDelete.OpPeriod);
                OnIncidentObjectiveChanged(new IncidentObjectiveEventArgs(toDelete));
                */
            }
        }








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
            if (_currentTask.allMedicalPlans.Any(o => o.ID == record.ID || o.OpPeriod == record.OpPeriod))
            {
                _currentTask.allMedicalPlans = _currentTask.allMedicalPlans.Where(o => o.ID != record.ID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentTask.allMedicalPlans.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnMedicalPlanChanged(new MedicalPlanEventArgs(record));
        }

        // Operational Period
        protected virtual void OnOperationalPeriodChanged(OperationalPeriodEventArgs e)
        {
            OperationalPeriodEventHandler handler = this.OperationalPeriodChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertOperationalPeriod(OperationalPeriod record, string source = "local")
        {

            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.AllOperationalPeriods.Any(o => o.OperationalPeriodID == record.OperationalPeriodID || o.PeriodNumber == record.PeriodNumber))
            {
                _currentTask.AllOperationalPeriods = _currentTask.AllOperationalPeriods.Where(o => o.OperationalPeriodID != record.OperationalPeriodID && o.PeriodNumber != record.PeriodNumber).ToList();
            }
            _currentTask.AllOperationalPeriods.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnOperationalPeriodChanged(new OperationalPeriodEventArgs(record));
        }

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
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allOrgCharts.Any(o => o.OrganizationalChartID == record.OrganizationalChartID || o.OpPeriod == record.OpPeriod))
            {
                _currentTask.allOrgCharts = _currentTask.allOrgCharts.Where(o => o.OrganizationalChartID != record.OrganizationalChartID && o.OpPeriod != record.OpPeriod).ToList();
            }
            _currentTask.allOrgCharts.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnOrganizationalChartChanged(new OrganizationChartEventArgs(record));
        }




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
            if (_currentTask.allPositionLogEntries.Any(o => o.LogID == record.LogID))
            {
                _currentTask.allPositionLogEntries = _currentTask.allPositionLogEntries.Where(o => o.LogID != record.LogID).ToList();
            }
            _currentTask.allPositionLogEntries.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnPositionLogEntryChanged(new PositionLogEventArgs(record));
        }


        /*
        public void DeletePositionLogEntry(PositionLogEntry record)
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allPositionLogEntries.Any(o => o.LogID == record.LogID))
            {
                _currentTask.allPositionLogEntries = _currentTask.allPositionLogEntries.Where(o => o.LogID != record.LogID).ToList();
            }
            OnPositionLogEntryChanged(new PositionLogEventArgs(record));
        }
        public void DeletePositionLogEntry(Guid RecordID)
        {

            if (_currentTask.allPositionLogEntries.Any(o => o.LogID == RecordID))
            {
                PositionLogEntry toDelete = _currentTask.allPositionLogEntries.First(o => o.LogID == RecordID);
                _currentTask.allPositionLogEntries = _currentTask.allPositionLogEntries.Where(o => o.LogID != RecordID).ToList();
                toDelete.LastUpdatedUTC = DateTime.UtcNow;
                OnPositionLogEntryChanged(new PositionLogEventArgs(toDelete));
            }

        }
        */


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
            if (!_currentTask.allOrgCharts.Where(o => o.OpPeriod == record.OpPeriod).Any())
            {
                _currentTask.createOrgChartAsNeeded(record.OpPeriod);
                OrganizationChart chart = _currentTask.allOrgCharts.Where(o => o.OpPeriod == record.OpPeriod).First();
                UpsertOrganizationalChart(chart);
            }
            else if (!_currentTask.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any())
            {
                _currentTask.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).loadRoles();
                UpsertOrganizationalChart(_currentTask.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).Clone());
            }

            if (_currentTask.allOrgCharts.Any(o => o.OrganizationalChartID == record.OrganizationalChartID))
            {
                OrganizationChart chart = _currentTask.allOrgCharts.First(o => o.OrganizationalChartID == record.OrganizationalChartID);
                if (_currentTask.allOrgCharts.First(o => o.OrganizationalChartID == record.OrganizationalChartID).AllRoles.Any(o => o.RoleID == record.RoleID))
                {

                    chart.AllRoles = chart.AllRoles.Where(o => o.RoleID != record.RoleID).ToList();
                }
                chart.AllRoles.Add(record);

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(record, "UPSERT", true, false);
                }

                OnICSRoleChanged(new ICSRoleEventArgs(record));

                if (record.teamMember != null && record.teamMember.PersonID != Guid.Empty)
                {
                    record.teamMember.CurrentStatus = _currentTask.getMemberStatus(record.teamMember, record.OpPeriod, DateTime.Now);
                    UpsertMemberStatus(record.teamMember);
                }
                //OnOrganizationalChartChanged(new OrganizationChartEventArgs(chart));
            }

        }


        public void UpsertICSRole(string roleName, int opsPeriod, TeamMember member, string source = "local")
        {

            if (!_currentTask.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).Any())
            {
                _currentTask.createOrgChartAsNeeded(opsPeriod);
                OrganizationChart chart = _currentTask.allOrgCharts.First(o => o.OpPeriod == opsPeriod);
                UpsertOrganizationalChart(chart);
            }
            else if (_currentTask.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().AllRoles.Count <= 0)
            {
                _currentTask.allOrgCharts.First(o => o.OpPeriod == opsPeriod).loadRoles();
                UpsertOrganizationalChart(_currentTask.allOrgCharts.First(o => o.OpPeriod == opsPeriod));
            }

            ICSRole role = _currentTask.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().getRoleByName(roleName).Clone();
            role.teamMember = member;
            role.OpPeriod = opsPeriod;
            role.OrganizationalChartID = _currentTask.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().OrganizationalChartID;
            UpsertICSRole(role);

            /*
            if (saveToDatabase)
            {
                role.saveOrgChartRoleToDB();
            }
            */
        }



        // Safety Plan
        protected virtual void OnSafetyPlanChanged(SafetyPlanEventArgs e)
        {
            SafetyPlanEventHandler handler = this.SafetyPlanChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertSafetyPlan(SafetyPlan record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allSafetyPlans.Any(o => o.PlanID == record.PlanID))
            {
                _currentTask.allSafetyPlans = _currentTask.allSafetyPlans.Where(o => o.PlanID != record.PlanID).ToList();
            }
            _currentTask.allSafetyPlans.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnSafetyPlanChanged(new SafetyPlanEventArgs(record));
        }


        public void DeleteSafetyPlan(SafetyPlan record, string source = "local")
        {
            if (_currentTask.allSafetyPlans.Any(o => o.PlanID == record.PlanID))
            {
                _currentTask.allSafetyPlans = _currentTask.allSafetyPlans.Where(o => o.PlanID != record.PlanID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                OnSafetyPlanChanged(new SafetyPlanEventArgs(record));
            }


        }

        public void DeleteSafetyPlan(Guid PlanID, string source = "local")
        {
            if (_currentTask.allSafetyPlans.Any(o => o.PlanID == PlanID))
            {
                SafetyPlan toDelete = _currentTask.allSafetyPlans.First(o => o.PlanID == PlanID);
                // _currentTask.allSafetyPlans = _currentTask.allSafetyPlans.Where(o => o.PlanID != toDelete.PlanID).ToList();
                // OnSafetyPlanChanged(new SafetyPlanEventArgs(toDelete));
                DeleteSafetyPlan(toDelete, source);
            }


        }




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
            _currentTask.TaskName = basics.TaskName;
            _currentTask.TaskNumber = basics.TaskNumber;
            _currentTask.AgencyFileNumber = basics.AgencyFileNumber;
            _currentTask.ICPCallSign = basics.ICPCallSign;
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(basics, "UPSERT", true, false);
            }

            OnTaskBasicsChanged(new TaskBasicsEventArgs(basics));
        }




        // Timeline
        public void RefreshAutomatedTimelineEvents()
        {
            List<TimelineEvent> autoEvents = _currentTask.GetAutomatedTimelineEvents();
            foreach (TimelineEvent ev in _currentTask.taskTimeline.AllTimelineEvents.Where(o => o.IsAuto)) { DeleteTimelineEvent(ev); }
            foreach (TimelineEvent ev in autoEvents) { UpsertTimelineEvent(ev); }
            _currentTask.taskTimeline.AllTimelineEvents = _currentTask.taskTimeline.AllTimelineEvents.OrderBy(o => o.EventDateTime).ToList();

        }

        protected virtual void OnTimelineChanged(TimelineEventArgs e)
        {
            TimelineEventHandler handler = this.TimelineChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertTimeline(Timeline record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            _currentTask.taskTimeline = record;
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnTimelineChanged(new TimelineEventArgs(record));
        }



        // Timeline Event
        protected virtual void OnTimelineEventChanged(TimelineEventEventArgs e)
        {
            TimelineEventEventHandler handler = this.TimelineEventChanged;
            if (handler != null)
            {
                handler(e);
            }
        }
        public void UpsertTimelineEvent(TimelineEvent record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.taskTimeline == null) { _currentTask.taskTimeline = new Timeline(); }
            if (_currentTask.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == record.TimelineEventID))
            {
                _currentTask.taskTimeline.AllTimelineEvents = _currentTask.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != record.TimelineEventID).ToList();
            }
            _currentTask.taskTimeline.AllTimelineEvents.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnTimelineEventChanged(new TimelineEventEventArgs(record));
        }
        public void DeleteTimelineEvent(TimelineEvent record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == record.TimelineEventID))
            {
                _currentTask.taskTimeline.AllTimelineEvents = _currentTask.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != record.TimelineEventID).ToList();

                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                OnTimelineEventChanged(new TimelineEventEventArgs(record));
            }

        }
        public void DeleteTimelineEvent(Guid RecordID, string source = "local")
        {
            if (_currentTask.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == RecordID))
            {
                TimelineEvent toDelete = _currentTask.taskTimeline.AllTimelineEvents.First(o => o.TimelineEventID == RecordID);
                //_currentTask.taskTimeline.AllTimelineEvents = _currentTask.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != RecordID).ToList();
                //OnTimelineEventChanged(new TimelineEventEventArgs(toDelete));
                DeleteTimelineEvent(toDelete, source);

            }
        }








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
            if (_currentTask.allVehicles.Any(o => o.VehicleID == record.VehicleID))
            {
                _currentTask.allVehicles = _currentTask.allVehicles.Where(o => o.VehicleID != record.VehicleID).ToList();
            }
            _currentTask.allVehicles.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnVehicleChanged(new VehicleEventArgs(record));
        }
        public void DeleteVehicle(Vehicle record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allVehicles.Any(o => o.VehicleID == record.VehicleID))
            {
                _currentTask.allVehicles = _currentTask.allVehicles.Where(o => o.VehicleID != record.VehicleID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                OnVehicleChanged(new VehicleEventArgs(record));
            }

        }

        public void DeleteVehicle(Guid RecordID, string source = "local")
        {

            if (_currentTask.allVehicles.Any(o => o.VehicleID == RecordID))
            {
                Vehicle toDelete = _currentTask.allVehicles.First(o => o.VehicleID == RecordID);
                DeleteVehicle(toDelete, source);
                /*
                _currentTask.allVehicles = _currentTask.allVehicles.Where(o => o.VehicleID != RecordID).ToList();
                toDelete.LastUpdatedUTC = DateTime.UtcNow;
                OnVehicleChanged(new VehicleEventArgs(toDelete));*/
            }

        }


        //Member Status
        public void UpsertMemberStatus(SignInRecord signIn, string source = "local")
        {
            if (_currentTask.AllSignInRecords.Any(o => o.SignInRecordID == signIn.SignInRecordID))
            {
                _currentTask.AllSignInRecords = _currentTask.AllSignInRecords.Where(o => o.SignInRecordID != signIn.SignInRecordID).ToList();
            }
            _currentTask.AllSignInRecords.Add(signIn);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(signIn, "UPSERT", true, false); }
            OnMemberSignInChanged(new MemberEventArgs(signIn));
        }
        public void UpsertMemberStatus(TeamMember member, string source = "local")
        {
            if (member != null)
            {
                _currentTask.UpsertTaskTeamMember(member);
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(member, "UPSERT", true, false); }
            }
            OnMemberSignInChanged(new MemberEventArgs(member));
        }

        protected virtual void OnMemberSignInChanged(MemberEventArgs e)
        {
            MemberEventHandler handler = this.MemberSignInChanged;
            if (handler != null)
            {
                handler(e);
            }
        }


        //Note
        public void UpsertNote(Note note, string source = "local")
        {

            note.DateUpdated = DateTime.Now;
            if (note.DateCreated == DateTime.MinValue) { note.DateCreated = note.DateUpdated; }
            if (note.TaskID == Guid.Empty) { note.TaskID = CurrentTask.TaskID; }

            if (CurrentTask.allNotes.Any(o => o.NoteID == note.NoteID))
            {
                CurrentTask.allNotes = CurrentTask.allNotes.Where(o => o.NoteID != note.NoteID).ToList();
            }
            CurrentTask.allNotes.Add(note);
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




        // Equipment Stuff


        public void UpsertTaskEquipment(TaskEquipment te, string source = "local")
        {

            te.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allEquipment.Any(o => o.EquipmentID == te.EquipmentID && o.OpPeriod == te.OpPeriod))
            {
                _currentTask.allEquipment = _currentTask.allEquipment.Where(o => o.EquipmentID != te.EquipmentID || o.OpPeriod != te.OpPeriod).ToList();
            }
            _currentTask.allEquipment.Add(te);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(te, "UPSERT", true, false); }
            OnTaskEquipmentChanged(new TaskEquipmentEventArgs(te));
        }
        public void DeleteTaskEquipment(TaskEquipment te, string source = "local")
        {

            te.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allEquipment.Any(o => o.EquipmentID == te.EquipmentID && o.OpPeriod == te.OpPeriod))
            {
                _currentTask.allEquipment = _currentTask.allEquipment.Where(o => o.EquipmentID != te.EquipmentID || o.OpPeriod != te.OpPeriod).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(te, "DELETE", true, false); }
                OnTaskEquipmentChanged(new TaskEquipmentEventArgs(te));
            }

        }

        protected virtual void OnTaskEquipmentChanged(TaskEquipmentEventArgs e)
        {
            TaskEquipmentEventHandler handler = this.TaskEquipmentChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertEquipmentIssue(EquipmentIssue issue, string source = "local")
        {

            issue.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allEquipmentIssues.Any(o => o.IssueID != issue.IssueID))
            {
                _currentTask.allEquipmentIssues = _currentTask.allEquipmentIssues.Where(o => o.IssueID != issue.IssueID).ToList();
            }
            _currentTask.allEquipmentIssues.Add(issue);
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

        protected virtual void OnTaskUpdateChanged(TaskUpdateEventArgs e)
        {
            TaskUpdateEventHandler handler = this.TaskUpdateChanged;
            if (handler != null)
            {
                handler(e);
            }
        }



        //Communications Log Entry
        public void UpsertComms(CommsLogEntry entry, string source = "local")
        {
            entry.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentTask.allCommsLogEntries.Any(o => o.EntryID == entry.EntryID)) { _currentTask.allCommsLogEntries = _currentTask.allCommsLogEntries.Where(o => o.EntryID != entry.EntryID).ToList(); }
            _currentTask.allCommsLogEntries.Add(entry);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(entry, "UPSERT", true, false); }
            OnCommsChanged(new CommsEventArgs(entry));

        }
        public void DeleteCommsLogEntry(Guid EntryID, string source = "local")
        {
            if (_currentTask.allCommsLogEntries.Any(o => o.EntryID == EntryID))
            {
                CommsLogEntry toDelete = _currentTask.allCommsLogEntries.First(o => o.EntryID == EntryID);
                DeleteCommsLogEntry(toDelete, source);
                /*
                _currentTask.allCommsLogEntries = _currentTask.allCommsLogEntries.Where(o => o.EntryID != EntryID).ToList();
                toDelete.LastUpdatedUTC = DateTime.UtcNow;
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(toDelete, "DELETE", true, false); }
                OnCommsChanged(new CommsEventArgs(toDelete));
                */
            }
        }
        public void DeleteCommsLogEntry(CommsLogEntry toDelete, string source = "local")
        {
            if (_currentTask.allCommsLogEntries.Any(o => o.EntryID == toDelete.EntryID))
            {

                _currentTask.allCommsLogEntries = _currentTask.allCommsLogEntries.Where(o => o.EntryID != toDelete.EntryID).ToList();
                toDelete.LastUpdatedUTC = DateTime.UtcNow;
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(toDelete, "DELETE", true, false); }
                OnCommsChanged(new CommsEventArgs(toDelete));
            }
        }

        protected virtual void OnCommsChanged(CommsEventArgs e)
        {
            CommsEventHandler handler = this.CommsChanged;
            if (handler != null)
            {
                handler(e);
            }
        }








    }

}
