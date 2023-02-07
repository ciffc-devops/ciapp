using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices
{
    public interface IWFIncidentService
    {
        List<TaskUpdate> allTaskUpdates { get; set; }
        WFIncident CurrentIncident { get; set; }
        Guid MachineID { get; set; }

        event AmbulanceServiceEventHandler AmbulanceServiceChanged;
        event BriefingEventHandler BriefingChanged;
        event CommsEventHandler CommsChanged;
        event CommsPlanEventHandler CommsPlanChanged;
        event CommsPlanItemEventHandler CommsPlanItemChanged;
        //event CommsPlanItemLinkEventHandler CommsPlanItemLinkChanged;
        event CommsPlanItemListEventHandler CommsPlanItemListChanged;
        event ContactEventHandler ContactChanged;
        event EquipmentIssueEventHandler EquipmentIssueChanged;
        event HospitalEventHandler HospitalChanged;
        event ICSRoleEventHandler ICSRoleChanged;
        event IncidentObjectiveEventHandler IncidentObjectiveChanged;
        event IncidentObjectivesSheetEventHandler IncidentObjectivesSheetChanged;
        event MedicalAidStationEventHandler MedicalAidStationChanged;

        event MedicalPlanEventHandler MedicalPlanChanged;
        event MemberEventHandler MemberSignInChanged;
        event NoteEventHandler NoteChanged;
        event OperationalPeriodEventHandler OperationalPeriodChanged;
        event OrganizationalChartEventHandler OrganizationalChartChanged;
        event PositionLogEventHandler PositionLogChanged;
        event SafetyMessageEventHandler SafetyMessageChanged;
        event TaskBasicsEventHandler TaskBasicsChanged;
        event TaskEquipmentEventHandler TaskEquipmentChanged;
        event TaskUpdateEventHandler TaskUpdateChanged;
        event TimelineEventHandler TimelineChanged;
        event TimelineEventEventHandler TimelineEventChanged;
        event VehicleEventHandler VehicleChanged;
        event WFIncidentEventHandler WfIncidentChanged;
        event GeneralMessageEventHandler GeneralMessageChanged;
        event AircraftEventHandler AircraftChanged;
        event AircraftsOperationsSummaryEventHandler AircraftsOperationsSummaryChanged;
        event TeamAssignmentEventHandler TeamAssignmentChanged;

        event IncidenOpPeriodChangedEventHandler OpPeriodChanged;

        void ApplyTaskUpdate(TaskUpdate update, bool applyAllSubsequent = false);
        void ConnectToServerTask(Guid TaskID, string EncryptionKey);
        void DeleteCommsLogEntry(CommsLogEntry toDelete, string source = "local");
        void DeleteCommsLogEntry(Guid EntryID, string source = "local");
        void DeleteContact(Contact contact, string source = "local");
        void DeleteContact(Guid contactID, string source = "local");
        void DeleteIncidentObjective(Guid IncidentObjectiveID, string source = "local");
        void DeleteIncidentObjective(IncidentObjective record, string source = "local");
        void DeleteObject(object obj, string source);
        void DeleteTaskEquipment(TaskEquipment te, string source = "local");
        void DeleteTimelineEvent(Guid RecordID, string source = "local");
        void DeleteTimelineEvent(TimelineEvent record, string source = "local");
        void DeleteVehicle(Guid RecordID, string source = "local");
        void DeleteVehicle(Vehicle record, string source = "local");
        List<CommsPlanItem> GetCommsPlanItems(bool includeBlank, bool ActiveOnly = true);
        TaskUpdate InsertIfUniqueTaskUpdate(TaskUpdate update);
        void LoadNewTaskFromServer(Guid TaskID, string EncryptionKey);
        void ProcessTaskUpdate(TaskUpdate update);
        void RefreshAutomatedTimelineEvents();
        void SendInitialTaskUpdate();
        void UpdateTaskBasics(TaskBasics basics, string source);
        Task<bool> uploadTaskUpdateToServer(TaskUpdate update);
        void UpsertBriefing(Briefing record, string source = "local");
        void UpsertComms(CommsLogEntry entry, string source = "local");
        void UpsertCommsPlan(CommsPlan record, string source = "local");
        void UpsertCommsPlanItem(CommsPlanItem item, string function = null, string source = "local");
        // void UpsertCommsPlanItemLink(CommsPlanItemLink link, string source = "local");
        void UpsertContact(Contact record, string source = "local");
        void UpsertEquipmentIssue(EquipmentIssue issue, string source = "local");
        void UpsertICSRole(ICSRole record, string source = "local");
        void UpsertICSRole(string roleName, int opsPeriod, TeamMember member, string source = "local");
        void DeleteICSRole(ICSRole roleToDelete, int opsPeriod, string source = "local");
        void UpsertIncidentObjectivesSheet(IncidentObjectivesSheet record, string source = "local");
        void UpsertIncidentObjective(IncidentObjective record, string source = "local");
        void UpsertMedicalPlan(MedicalPlan record, string source = "local");
        void UpsertMedicalAidStation(MedicalAidStation record, string source = "local");
        void UpsertHospital(Hospital record, string source = "local");
        void UpsertAmbulance(AmbulanceService record, string source = "local");

        void UpsertMemberStatus(SignInRecord signIn, string source = "local");
        void UpsertMemberStatus(TeamMember member, string source = "local");
        void UpsertNote(Note note, string source = "local");
        void UpsertObject(object obj, string source);
        void UpsertOperationalPeriod(OperationalPeriod record, string source = "local");
        void UpsertOrganizationalChart(OrganizationChart record, string source = "local");
        void UpsertOrganizationalChart(OrganizationChart record, bool UpsertRoles, string source = "local");
        void UpsertPositionLogEntry(PositionLogEntry record, string source = "local");
        void UpsertSafetyMessage(SafetyMessage record, string source = "local");
        void UpsertTaskEquipment(TaskEquipment te, string source = "local");
        TaskUpdate UpsertTaskUpdate(object obj, string command, bool processed_locally, bool uploaded);
        TaskUpdate UpsertTaskUpdate(TaskUpdate update);
        void UpsertTimeline(Timeline record, string source = "local");
        void UpsertTimelineEvent(TimelineEvent record, string source = "local");
        void UpsertVehicle(Vehicle record, string source = "local");
        void UpsertGeneralMessage(GeneralMessage record, string source = "local");

        void UpsertAircraft(Aircraft record, string source = "local");
        void UpsertAirOperationsSummary(AirOperationsSummary record, string source = "local");
        void UpsertTeamAssignment(TeamAssignment item, string source = "local");
        void OnOpPeriodChanged(IncidentOpPeriodChangedEventArgs e);
    }
}