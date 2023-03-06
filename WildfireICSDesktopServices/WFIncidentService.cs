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
using static iTextSharp.text.pdf.AcroFields;
using System.Text.Json;
using System.Data;
using WF_ICS_ClassLibrary;

namespace WildfireICSDesktopServices
{
    public class WFIncidentService : IWFIncidentService
    {
        public event CommsEventHandler CommsChanged;
        public event MemberEventHandler MemberSignInChanged;
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
        public event OperationalPeriodEventHandler OperationalPeriodChanged;
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
        public event TeamAssignmentEventHandler TeamAssignmentChanged;

       

        public event IncidenOpPeriodChangedEventHandler OpPeriodChanged;
        public event OperationalGroupEventHandler OperationalGroupChanged;
        public event OperationalSubGroupEventHandler OperationalSubGroupChanged;


        private WFIncident _currentIncident;
        public WFIncident CurrentIncident { get => _currentIncident; set => _currentIncident = value; }
        public List<TaskUpdate> allTaskUpdates { get => _currentIncident.allTaskUpdates; set => _currentIncident.allTaskUpdates = value; }
        private Guid _MachineID;
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }


        public WFIncidentService(WFIncident currentTask)
        {
            _currentIncident = currentTask;
            allTaskUpdates = new List<TaskUpdate>();
        }
        public WFIncidentService()
        {

        }

        public string TestWrite(string path)
        {
            if (string.IsNullOrEmpty(path)) { path = System.IO.Path.GetTempPath(); }

            if (FileAccessClasses.checkWriteAccess(path, true))
            {
                return "Success: " + path;
            }
            else
            {
                return "NO Can't write to " + path;
            }
        }
       

        public TaskUpdate UpsertTaskUpdate(object obj, string command, bool processed_locally, bool uploaded)
        {
            TaskUpdate update = new TaskUpdate();
            update.TaskID = _currentIncident.TaskID;
            update.LastUpdatedUTC = DateTime.UtcNow;
            update.CommandName = command;
            update.Data = obj;
            update.DataEnc = JsonSerializer.Serialize(update.Data);
            update.DataEnc = StringCipher.Encrypt(update.DataEnc, _currentIncident.TaskEncryptionKey);
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

                    update.Data = TaskUpdateTools.DecryptTaskUpdateData(update, CurrentIncident.TaskEncryptionKey);

                }
                ApplyTaskUpdate(update);
                UpsertTaskUpdate(update);

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
                string source = update.Source;
                
                if (update.CommandName.Equals("UPSERT"))
                {
                    update.ProcessedLocally = true;
                    UpsertObject(update.Data, source);
                }
               
                else if (update.CommandName.Equals("INITIAL"))
                {
                    TaskBasics basics = update.Data as TaskBasics;

                    if (update.TaskID != CurrentIncident.TaskID)
                    {
                        _currentIncident = new WFIncident();

                        _currentIncident.TaskID = basics.TaskID;
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, source);

                    }
                    else
                    {
                        update.ProcessedLocally = true;
                        UpdateTaskBasics(basics, source);
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

            TaskBasics basics = new TaskBasics(CurrentIncident);
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
                CurrentIncident.TaskEncryptionKey = EncryptionKey;
            }
            foreach (TaskUpdate update in updates)
            {
                ProcessTaskUpdate(update);
            }
            OnWFIncidentChanged(new WFIncidentEventArgs(_currentIncident));
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
            OnWFIncidentChanged(new WFIncidentEventArgs(_currentIncident));
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
                UpsertHospital(((Hospital)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new AmbulanceService().GetType().Name))
            {
                UpsertAmbulance(((AmbulanceService)obj).Clone(), source);
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
            else if (dataClassName.Equals(new SafetyMessage().GetType().Name))
            {
                UpsertSafetyMessage(((SafetyMessage)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new TaskBasics().GetType().Name))
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
            else if (dataClassName.Equals(new Vehicle().GetType().Name))
            {
                UpsertVehicle(((Vehicle)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new CheckInRecord().GetType().Name))
            {
                UpsertMemberStatus(((CheckInRecord)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Personnel().GetType().Name))
            {
                UpsertMemberStatus(((Personnel)obj).Clone(), source);
            }



            else if (dataClassName.Equals(new AirOperationsSummary().GetType().Name))
            {
                UpsertAirOperationsSummary(((AirOperationsSummary)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Aircraft().GetType().Name))
            {
                UpsertAircraft(((Aircraft)obj).Clone(), source);
            }

            else if (dataClassName.Equals(new IncidentObjectivesSheet().GetType().Name))
            {
                UpsertIncidentObjectivesSheet(((IncidentObjectivesSheet)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new IncidentObjective().GetType().Name))
            {
                UpsertIncidentObjective(((IncidentObjective)obj).Clone(), source);
            }


            else if (dataClassName.Equals(new MedicalPlan().GetType().Name))
            {
                UpsertMedicalPlan(((MedicalPlan)obj).Clone(), source);
            }

            else if (dataClassName.Equals(new MedicalAidStation().GetType().Name))
            {
                UpsertMedicalAidStation(((MedicalAidStation)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Hospital().GetType().Name))
            {
                UpsertHospital(((Hospital)obj).Clone(), source);
            }


            else if (dataClassName.Equals(new TeamAssignment().GetType().Name))
            {
                UpsertTeamAssignment(((TeamAssignment)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new GeneralMessage().GetType().Name))
            {
                UpsertGeneralMessage(((GeneralMessage)obj).Clone(), source);
            }

            else if (dataClassName.Equals(new OperationalGroup().GetType().Name))
            {
                UpsertOperationalGroup(((OperationalGroup)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new OperationalSubGroup().GetType().Name))
            {
                UpsertOperationalSubGroup(((OperationalSubGroup)obj).Clone(), source);
            }
        }


        /*
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
           
            else if (dataClassName.Equals(new TimelineEvent().GetType().Name))
            {
                DeleteTimelineEvent(((TimelineEvent)obj).Clone(), source);
            }
            else if (dataClassName.Equals(new Vehicle().GetType().Name))
            {
                DeleteVehicle(((Vehicle)obj).Clone(), source);
            }
        }
        */



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

            List<CommsPlanItem> usedItems = _currentIncident.getCommsPlanItemsUsedToDate();
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
            if (_currentIncident.allCommsPlans.Any(o => o.ID == record.ID || o.OpsPeriod == record.OpsPeriod))
            {
                _currentIncident.allCommsPlans = _currentIncident.allCommsPlans.Where(o => o.ID != record.ID && o.OpsPeriod != record.OpsPeriod).ToList();
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
            CurrentIncident.createCommsPlanAsNeeded(item.OpsPeriod);
            CommsPlan plan = CurrentIncident.allCommsPlans.FirstOrDefault(o=>o.OpsPeriod == item.OpsPeriod);
            if(plan != null)
            {
                if (string.IsNullOrEmpty(function)) { function = item.CommsFunction; }

                plan.allCommsItems = plan.allCommsItems.Where(o => o.ItemID != item.ItemID).ToList();
                plan.allCommsItems.Add(item);
                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(item, "UPSERT", true, false);
                }
                OnCommsPlanItemChanged(new CommsPlanItemEventArgs(item));

            }
        }


        /*
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
            if (_currentIncident.allCommsPlans.Any(o => o.OpsPeriod == link.OpsPeriod))
            {
                CommsPlan thisPlan = _currentIncident.allCommsPlans.First(o => o.OpsPeriod == link.OpsPeriod);
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

        */


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

        /*
        public void DeleteContact(Contact contact, string source = "local")
        {
            if (_currentIncident.allContacts.Any(o => o.ContactID == contact.ContactID))
            {
                _currentIncident.allContacts = _currentIncident.allContacts.Where(o => o.ContactID != contact.ContactID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(contact, "DELETE", true, false); }
                OnContactChanged(new ContactEventArgs(contact));
            }

        }
        public void DeleteContact(Guid contactID, string source = "local")
        {
            if (_currentIncident.allContacts.Any(o => o.ContactID == contactID))
            {
                Contact contactToDelete = _currentIncident.allContacts.FirstOrDefault(o => o.ContactID == contactID);
                DeleteContact(contactToDelete, source);
                //_currentTask.allContacts = _currentTask.allContacts.Where(o => o.ContactID != contactID).ToList();
                //OnContactChanged(new ContactEventArgs(contactToDelete));
            }

        }
        */
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
            if (_currentIncident.allIncidentObjectives.Any(o => o.SheetID == record.SheetID))
            {
                _currentIncident.allIncidentObjectives = _currentIncident.allIncidentObjectives.Where(o => o.SheetID != record.SheetID).ToList();
            }
            record.RenumberObjectives();
            _currentIncident.allIncidentObjectives.Add(record.Clone());
         

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

            if(!_currentIncident.allIncidentObjectives.Any(o=>o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.createObjectivesSheetAsNeeded(record.OpPeriod);
                sheet = _currentIncident.allIncidentObjectives.First(o => o.OpPeriod == record.OpPeriod);
                UpsertIncidentObjectivesSheet(sheet);
            } else { sheet = _currentIncident.allIncidentObjectives.First(o => o.OpPeriod == record.OpPeriod); }



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

        /*
        public void DeleteIncidentObjective(IncidentObjective record, string source = "local")
        {
            IncidentObjectivesSheet sheet = null;

            if (!_currentIncident.allIncidentObjectives.Any(o => o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.createObjectivesSheetAsNeeded(record.OpPeriod);
                sheet = _currentIncident.allIncidentObjectives.First(o => o.OpPeriod == record.OpPeriod);
                UpsertIncidentObjectivesSheet(sheet);
            }
            else { sheet = _currentIncident.allIncidentObjectives.First(o => o.OpPeriod == record.OpPeriod); }

            record.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
            
            if (sheet.Objectives.Any(o => o.IncidentObjectiveID == record.IncidentObjectiveID))
            {
                sheet.Objectives = sheet.Objectives.Where(o => o.IncidentObjectiveID != record.IncidentObjectiveID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                _currentIncident.renumberObjectives(record.OpPeriod);
                OnIncidentObjectiveChanged(new IncidentObjectiveEventArgs(record));
            }

        }
        public void DeleteIncidentObjective(Guid IncidentObjectiveID, string source = "local")
        {
            IncidentObjectivesSheet sheet = null;
            if(_currentIncident.allIncidentObjectives.Any(o=>o.Objectives.Any(i => i.IncidentObjectiveID == IncidentObjectiveID)))
            {
                sheet = _currentIncident.allIncidentObjectives.First(o => o.Objectives.Any(i => i.IncidentObjectiveID == IncidentObjectiveID));

                IncidentObjective toDelete = sheet.Objectives.First(o => o.IncidentObjectiveID == IncidentObjectiveID);
                DeleteIncidentObjective(toDelete, source);

            }



        }
        */







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
            plan.Ambulances = plan.Ambulances.Where(o=>o.AmbulanceID != record.AmbulanceID).ToList();
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

        // Org Chart
        protected virtual void OnOrganizationalChartChanged(OrganizationChartEventArgs e)
        {
            OrganizationalChartEventHandler handler = this.OrganizationalChartChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

        public void UpsertOrganizationalChart(OrganizationChart record,  string source = "local")
        {
            UpsertOrganizationalChart(record, true, source);
        }

        public void UpsertOrganizationalChart(OrganizationChart record, bool UpsertRoles, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allOrgCharts.Any(o => o.OrganizationalChartID == record.OrganizationalChartID || o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.allOrgCharts = _currentIncident.allOrgCharts.Where(o => o.OrganizationalChartID != record.OrganizationalChartID && o.OpPeriod != record.OpPeriod).ToList();
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
            if (!_currentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod))
            {
                _currentIncident.createOrgChartAsNeeded(record.OpPeriod);
                OrganizationChart chart = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == record.OpPeriod).First();
                UpsertOrganizationalChart(chart);
            }
            else if (!_currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any())
            {
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles = OrgChartTools.GetBlankPrimaryRoles();
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).SortRoles();
                UpsertOrganizationalChart(_currentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).Clone());
            }

            if (_currentIncident.allOrgCharts.Any(o => o.OrganizationalChartID == record.OrganizationalChartID))
            {
                OrganizationChart chart = _currentIncident.allOrgCharts.First(o => o.OrganizationalChartID == record.OrganizationalChartID);
                if (chart.AllRoles.Any(o => o.RoleID == record.RoleID))
                {

                    chart.AllRoles = chart.AllRoles.Where(o => o.RoleID != record.RoleID).ToList();
                }
                chart.AllRoles.Add(record);
                if (record.IncludeReportsToInName)
                {
                    chart.UpdateRoleName(record, false);
                }
                foreach(ICSRole role in chart.AllRoles.Where(o=>o.ReportsTo == record.RoleID && o.IncludeReportsToInName))
                {
                    chart.UpdateRoleName(role, true);
                }

                //chart.AllRoles = chart.AllRoles.OrderBy(o=>o.MaualSortOrder).ThenBy(o=>o.RoleName).ToList();
                chart.SortRoles();
                //UpsertOrganizationalChart(chart.Clone());

                if (source.Equals("local") || source.Equals("networkNoInternet"))
                {
                    UpsertTaskUpdate(record, "UPSERT", true, false);
                }

                OnICSRoleChanged(new ICSRoleEventArgs(record));

                if (record.teamMember != null && record.teamMember.PersonID != Guid.Empty)
                {
                    record.teamMember.CurrentStatus = _currentIncident.getMemberStatus(record.teamMember, record.OpPeriod, DateTime.Now);
                    UpsertMemberStatus(record.teamMember);
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
                _currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod).AllRoles = OrgChartTools.GetBlankPrimaryRoles();
                UpsertOrganizationalChart(_currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod));
            }

            ICSRole role = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().GetRoleByName(roleName).Clone();
            role.teamMember = member;
            role.OpPeriod = opsPeriod;
            role.OrganizationalChartID = _currentIncident.allOrgCharts.Where(o => o.OpPeriod == opsPeriod).First().OrganizationalChartID;
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
            /*
            if(_currentIncident.allOrgCharts.Any(o=>o.OpPeriod == opsPeriod))
            {
                OrganizationChart org = _currentIncident.allOrgCharts.First(o => o.OpPeriod == opsPeriod);
                if(org.AllRoles.Any(o=>o.RoleID == roleToDelete.RoleID))
                {
                    org.AllRoles = org.AllRoles.Where(o => o.RoleID != roleToDelete.RoleID).ToList();

                    if (roleToDelete.teamMember != null && roleToDelete.teamMember.PersonID != Guid.Empty)
                    {
                        roleToDelete.teamMember.CurrentStatus = _currentIncident.getMemberStatus(roleToDelete.teamMember, opsPeriod, DateTime.Now);
                        UpsertMemberStatus(roleToDelete.teamMember);
                    }
                    OnICSRoleChanged(new ICSRoleEventArgs(roleToDelete));
                    if (source.Equals("local") || source.Equals("networkNoInternet"))
                    {
                        UpsertTaskUpdate(roleToDelete, "DELETE", true, false);
                    }

                }
                if (org.AllRoles.Any(o=>o.ReportsTo == roleToDelete.RoleID))
                {
                    foreach(ICSRole role in org.AllRoles.Where(o => o.ReportsTo == roleToDelete.RoleID))
                    {
                        role.ReportsTo = roleToDelete.ReportsTo;
                        role.ReportsToRoleName = roleToDelete.ReportsToRoleName;
                        UpsertICSRole(role);

                    }
                }
            }*/
        }



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



        /*
        // Timeline
        public void RefreshAutomatedTimelineEvents()
        {
            List<TimelineEvent> autoEvents = _currentIncident.GetAutomatedTimelineEvents();
            foreach (TimelineEvent ev in _currentIncident.taskTimeline.AllTimelineEvents.Where(o => o.IsAuto)) { DeleteTimelineEvent(ev); }
            foreach (TimelineEvent ev in autoEvents) { UpsertTimelineEvent(ev); }
            _currentIncident.taskTimeline.AllTimelineEvents = _currentIncident.taskTimeline.AllTimelineEvents.OrderBy(o => o.EventDateTime).ToList();

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
            _currentIncident.taskTimeline = record;
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
            if (_currentIncident.taskTimeline == null) { _currentIncident.taskTimeline = new Timeline(); }
            if (_currentIncident.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == record.TimelineEventID))
            {
                _currentIncident.taskTimeline.AllTimelineEvents = _currentIncident.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != record.TimelineEventID).ToList();
            }
            _currentIncident.taskTimeline.AllTimelineEvents.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnTimelineEventChanged(new TimelineEventEventArgs(record));
        }
        public void DeleteTimelineEvent(TimelineEvent record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == record.TimelineEventID))
            {
                _currentIncident.taskTimeline.AllTimelineEvents = _currentIncident.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != record.TimelineEventID).ToList();

                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                OnTimelineEventChanged(new TimelineEventEventArgs(record));
            }

        }
        public void DeleteTimelineEvent(Guid RecordID, string source = "local")
        {
            if (_currentIncident.taskTimeline.AllTimelineEvents.Any(o => o.TimelineEventID == RecordID))
            {
                TimelineEvent toDelete = _currentIncident.taskTimeline.AllTimelineEvents.First(o => o.TimelineEventID == RecordID);
                //_currentTask.taskTimeline.AllTimelineEvents = _currentTask.taskTimeline.AllTimelineEvents.Where(o => o.TimelineEventID != RecordID).ToList();
                //OnTimelineEventChanged(new TimelineEventEventArgs(toDelete));
                DeleteTimelineEvent(toDelete, source);

            }
        }
        */


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


        //Aircraft
        protected virtual void OnAircrafteChanged(AircraftEventArgs e)
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
            _currentIncident.createAirOpsSummaryAsNeeded(record.OpPeriod);
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
                    UpsertTaskUpdate(record, "UPSERT", true, false);
                }
                OnAircrafteChanged(new AircraftEventArgs(record));

            }

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
            if (_currentIncident.allAirOperationsSummaries.Any(o => o.ID == record.ID))
            {
                _currentIncident.allAirOperationsSummaries = _currentIncident.allAirOperationsSummaries.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.allAirOperationsSummaries.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnAirOperationsSummaryChanged(new AirOperationsSummaryEventArgs(record));
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
            if (_currentIncident.allVehicles.Any(o => o.ID == record.ID))
            {
                _currentIncident.allVehicles = _currentIncident.allVehicles.Where(o => o.ID != record.ID).ToList();
            }
            _currentIncident.allVehicles.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet"))
            {
                UpsertTaskUpdate(record, "UPSERT", true, false);
            }
            OnVehicleChanged(new VehicleEventArgs(record));
        }

        /*
        public void DeleteVehicle(Vehicle record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if (_currentIncident.allVehicles.Any(o => o.ID == record.ID))
            {
                _currentIncident.allVehicles = _currentIncident.allVehicles.Where(o => o.ID != record.ID).ToList();
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "DELETE", true, false); }
                OnVehicleChanged(new VehicleEventArgs(record));
            }

        }

        public void DeleteVehicle(Guid RecordID, string source = "local")
        {

            if (_currentIncident.allVehicles.Any(o => o.ID == RecordID))
            {
                Vehicle toDelete = _currentIncident.allVehicles.First(o => o.ID == RecordID);
                DeleteVehicle(toDelete, source);

            }

        }
*/

        //Member Status
        public void UpsertMemberStatus(CheckInRecord signIn, string source = "local")
        {
            if (_currentIncident.AllSignInRecords.Any(o => o.SignInRecordID == signIn.SignInRecordID))
            {
                _currentIncident.AllSignInRecords = _currentIncident.AllSignInRecords.Where(o => o.SignInRecordID != signIn.SignInRecordID).ToList();
            }
            _currentIncident.AllSignInRecords.Add(signIn);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(signIn, "UPSERT", true, false); }
            OnMemberSignInChanged(new MemberEventArgs(signIn));
        }
        public void UpsertMemberStatus(Personnel member, string source = "local")
        {
            if (member != null)
            {
                _currentIncident.UpsertTaskTeamMember(member);
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
            if (note.TaskID == Guid.Empty) { note.TaskID = CurrentIncident.TaskID; }

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




        // Equipment Stuff


        public void UpsertTaskEquipment(TaskEquipment te, string source = "local")
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

        public void UpsertEquipmentIssue(EquipmentIssue issue, string source = "local")
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
            if (_currentIncident.allCommsLogEntries.Any(o => o.EntryID == entry.EntryID)) { _currentIncident.allCommsLogEntries = _currentIncident.allCommsLogEntries.Where(o => o.EntryID != entry.EntryID).ToList(); }
            _currentIncident.allCommsLogEntries.Add(entry);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(entry, "UPSERT", true, false); }
            OnCommsChanged(new CommsEventArgs(entry));

        }
        /*
        public void DeleteCommsLogEntry(Guid EntryID, string source = "local")
        {
            if (_currentIncident.allCommsLogEntries.Any(o => o.EntryID == EntryID))
            {
                CommsLogEntry toDelete = _currentIncident.allCommsLogEntries.First(o => o.EntryID == EntryID);
                DeleteCommsLogEntry(toDelete, source);
               
            }
        }
        public void DeleteCommsLogEntry(CommsLogEntry toDelete, string source = "local")
        {
            if (_currentIncident.allCommsLogEntries.Any(o => o.EntryID == toDelete.EntryID))
            {

                _currentIncident.allCommsLogEntries = _currentIncident.allCommsLogEntries.Where(o => o.EntryID != toDelete.EntryID).ToList();
                toDelete.LastUpdatedUTC = DateTime.UtcNow;
                if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(toDelete, "DELETE", true, false); }
                OnCommsChanged(new CommsEventArgs(toDelete));
            }
        }*/

        protected virtual void OnCommsChanged(CommsEventArgs e)
        {
            CommsEventHandler handler = this.CommsChanged;
            if (handler != null)
            {
                handler(e);
            }
        }



        // Team Assignment
        public void UpsertTeamAssignment(TeamAssignment item, string source = "local")
        {

            item.LastUpdatedUTC = DateTime.UtcNow;

            
            if (CurrentIncident.AllAssignments.Any(o => o.ID == item.ID))
            {
                CurrentIncident.AllAssignments = CurrentIncident.AllAssignments.Where(o => o.ID != item.ID).ToList();
            }
            CurrentIncident.AllAssignments.Add(item);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(item, "UPSERT", true, false); }
            OnTeamAssignmentChanged(new TeamAssignmentEventArgs(item));
        }
        protected virtual void OnTeamAssignmentChanged(TeamAssignmentEventArgs e)
        {
            TeamAssignmentEventHandler handler = this.TeamAssignmentChanged;
            if (handler != null)
            {
                handler(e);
            }
        }



        public void UpsertOperationalSubGroup(OperationalSubGroup record, string source = "local")
        {
            record.LastUpdatedUTC = DateTime.UtcNow;
            if(CurrentIncident.AllOperationalSubGroups.Any(o=>o.ID == record.ID)) { CurrentIncident.AllOperationalSubGroups = CurrentIncident.AllOperationalSubGroups.Where(o=>o.ID != record.ID).ToList();}
            CurrentIncident.AllOperationalSubGroups.Add(record);
            if (source.Equals("local") || source.Equals("networkNoInternet")) { UpsertTaskUpdate(record, "UPSERT", true, false); }
            CurrentIncident.SetOpGroupDepths(record.OpPeriod);
            OnOperationalSubGroupChanged(new OperationalSubGroupEventArgs(record));

        }
        protected virtual void OnOperationalSubGroupChanged(OperationalSubGroupEventArgs e)
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
            CurrentIncident.AllOperationalGroups.Add(record);


            //Add new entries to the Org Chart if needed
           // if (record.IsBranchOrDiv)
           // {
                if (CurrentIncident.allOrgCharts.Any(o=>o.OpPeriod == record.OpPeriod) && !CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any(o => o.OperationalGroupID == record.ID))
                {
                    OrganizationChart CurrentOrgChart = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod);
                    //are any of the generic branch thingies available?
                    Guid potential1 = new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c");
                    Guid potential2 = new Guid("9727f016-aed9-4f34-99db-910a06b97f2e");
                    Guid potential3 = new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9");
                    ICSRole NewRole = new ICSRole();


                   
                   if (record.GroupType.Equals("Branch"))
                    {
                        NewRole = OrgChartTools.getGenericRoleByName("Operations Branch Director");
                    }
                    else if (record.GroupType.Equals("Division"))
                    {
                        NewRole = OrgChartTools.getGenericRoleByName("Division Supervisor");
                    }
                    else if (record.GroupType.Equals("Strike Team"))
                    {
                        NewRole = OrgChartTools.getGenericRoleByName("Strike Team Leader");
                    }
                    else if (record.GroupType.Equals("Task Force"))
                    {
                        NewRole = OrgChartTools.getGenericRoleByName("Task Force Leader");
                    }
                    else
                    {
                        NewRole.BaseRoleName = "Group Supervisor";
                        NewRole.RoleName = "Group Supervisor";
                        NewRole.SectionID = Globals.OpsChiefID;

                    }

                    if (record.GroupType.Equals("Branch") && CurrentOrgChart.ActiveRoles.Any(o => (o.RoleID == potential1 || o.RoleID == potential2 || o.RoleID == potential3) && o.RoleName.Contains("Branch/Division/Group") && o.IndividualID == Guid.Empty))
                    {
                        ICSRole toReplace = CurrentOrgChart.ActiveRoles.First(o => (o.RoleID == potential1 || o.RoleID == potential2 || o.RoleID == potential3) && o.RoleName.Contains("Branch/Division/Group") && o.IndividualID == Guid.Empty);
                        NewRole.RoleID = toReplace.RoleID;
                        NewRole.PDFFieldName = toReplace.PDFFieldName;
                        NewRole.PDFTitleName = toReplace.PDFTitleName;
                        NewRole.ManualSortOrder = toReplace.ManualSortOrder;
                        NewRole.IncludeReportsToInName = toReplace.IncludeReportsToInName;
                    }


                    NewRole.OperationalGroupID = record.ID;
                    NewRole.OrganizationalChartID = CurrentOrgChart.OrganizationalChartID;
                    NewRole.OpPeriod = CurrentOrgChart.OpPeriod;
                    NewRole.Active = true;
                    NewRole.ReportsTo = record.ParentID;
                    NewRole.ReportsToRoleName = CurrentOrgChart.GetRoleByID(record.ParentID, false).RoleName;

                    //if not, make a new one
                    switch (record.GroupType)
                    {
                        case "Branch":
                            NewRole.RoleName = NewRole.BaseRoleName.Replace("Branch", record.ResourceName);
                            NewRole.IsOpGroupSup = true;
                            break;
                        case "Division":
                            NewRole.RoleName = NewRole.BaseRoleName.Replace("Division", record.ResourceName);
                            NewRole.IsOpGroupSup = true;
                            break;
                        case "Task Force":
                            NewRole.RoleName = NewRole.BaseRoleName.Replace("Task Force", record.ResourceName);
                            NewRole.IsOpGroupSup = true;
                            break;
                        case "Strike Team":
                            NewRole.RoleName = NewRole.BaseRoleName.Replace("Strike Team", record.ResourceName);
                            NewRole.IsOpGroupSup = true;
                            break;
                        default:
                            NewRole.RoleName = record.ResourceName + " Supervisor";
                            break;
                    }

                    UpsertICSRole(NewRole);
                    record.LeaderICSRoleID = NewRole.RoleID; record.LeaderICSRoleName = NewRole.RoleName;
                }

                if (CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == record.OpPeriod) &&  CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.Any(o => o.OperationalGroupID == record.ID) && CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.First(o => o.OperationalGroupID == record.ID).IndividualID != record.LeaderID)
                {
                    ICSRole role = CurrentIncident.allOrgCharts.First(o => o.OpPeriod == record.OpPeriod).AllRoles.First(o => o.OperationalGroupID == record.ID);
                    if (CurrentIncident.TaskTeamMembers.Any(o => o.PersonID == record.LeaderID))
                    {
                        Personnel per = CurrentIncident.TaskTeamMembers.First(o => o.PersonID == record.LeaderID);
                        role.teamMember = per.Clone();
                        role.IndividualID = record.LeaderID;
                        role.IndividualName = record.LeaderName;
                        UpsertICSRole(role);
                    }
                }
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


        public void DeleteCommsLogEntry(CommsLogEntry toDelete, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteCommsLogEntry(Guid EntryID, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contact, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Guid contactID, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteIncidentObjective(Guid IncidentObjectiveID, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteIncidentObjective(IncidentObjective record, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteObject(object obj, string source)
        {
            throw new NotImplementedException();
        }

        public void DeleteTaskEquipment(TaskEquipment te, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteTimelineEvent(Guid RecordID, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteTimelineEvent(TimelineEvent record, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(Guid RecordID, string source = "local")
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicle(Vehicle record, string source = "local")
        {
            throw new NotImplementedException();
        }

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


        
        public virtual void OnOpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            IncidenOpPeriodChangedEventHandler handler = this.OpPeriodChanged;
            if (handler != null)
            {
                handler(e);
            }
        }

      
    }

}
