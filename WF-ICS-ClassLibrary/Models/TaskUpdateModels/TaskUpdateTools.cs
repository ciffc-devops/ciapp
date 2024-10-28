using System;
using WF_ICS_ClassLibrary.Utilities;
using Newtonsoft.Json;


namespace WF_ICS_ClassLibrary.Models
{
    public static class TaskUpdateTools
    {
        public static Guid GetItemID(this TaskUpdate update)
        {
            if (update.Data != null)
            {
                try
                {
                    return  ((SyncableItem)update.Data).ID;
                }
                catch
                {
                    return  Guid.Empty;
                }

                if (update.ObjectType.Equals(new Contact().GetType().Name)) { return (update.Data as Contact).ContactID; }
                //else if (update.ObjectType.Equals(new TeamAssignment().GetType().Name)) { return (update.Data as TeamAssignment).ID; }
                else if (update.ObjectType.Equals(new Briefing().GetType().Name)) { return (update.Data as Briefing).BriefingID; }
                else if (update.ObjectType.Equals(new CommsLogEntry().GetType().Name)) { return (update.Data as CommsLogEntry).EntryID; }
                else if (update.ObjectType.Equals(new CommsPlan().GetType().Name)) { return (update.Data as CommsPlan).ID; }
                else if (update.ObjectType.Equals(new CommsPlanItem().GetType().Name)) { return (update.Data as CommsPlanItem).ItemID; }
                else if (update.ObjectType.Equals(new IncidentGear().GetType().Name)) { return (update.Data as IncidentGear).EquipmentID; }
                else if (update.ObjectType.Equals(new GearIssue().GetType().Name)) { return (update.Data as GearIssue).IssueID; }
                else if (update.ObjectType.Equals(new IncidentObjective().GetType().Name)) { return (update.Data as IncidentObjective).ObjectiveID; }
                else if (update.ObjectType.Equals(new IncidentObjectivesSheet().GetType().Name)) { return (update.Data as IncidentObjectivesSheet).SheetID; }
                else if (update.ObjectType.Equals(new MedicalPlan().GetType().Name)) { return (update.Data as MedicalPlan).ID; }
                else if (update.ObjectType.Equals(new Personnel().GetType().Name)) { return (update.Data as Personnel).ID; }
                else if (update.ObjectType.Equals(new CheckInRecord().GetType().Name)) { return (update.Data as CheckInRecord).SignInRecordID; }
                else if (update.ObjectType.Equals(new Note().GetType().Name)) { return (update.Data as Note).NoteID; }
                else if (update.ObjectType.Equals(new OperationalPeriod().GetType().Name)) { return (update.Data as OperationalPeriod).OperationalPeriodID; }
                else if (update.ObjectType.Equals(new OrganizationChart().GetType().Name)) { return (update.Data as OrganizationChart).ID; }
                else if (update.ObjectType.Equals(new ICSRole().GetType().Name)) { return (update.Data as ICSRole).OrgChartRoleID; }
                else if (update.ObjectType.Equals(new PositionLogEntry().GetType().Name)) { return (update.Data as PositionLogEntry).LogID; }
                else if (update.ObjectType.Equals(new Timeline().GetType().Name)) { return (update.Data as Timeline).ID; }
                else if (update.ObjectType.Equals(new TimelineEvent().GetType().Name)) { return (update.Data as TimelineEvent).ID; }
                else if (update.ObjectType.Equals(new Vehicle().GetType().Name)) { return (update.Data as Vehicle).ID; }
                else if (update.ObjectType.Equals(new Aircraft().GetType().Name)) { return (update.Data as Aircraft).ID; }
                else if (update.ObjectType.Equals(new AirOperationsSummary().GetType().Name)) { return (update.Data as AirOperationsSummary).ID; }
                else if (update.ObjectType.Equals(new NOTAM().GetType().Name)) { return (update.Data as NOTAM).ID; }
                else if (update.ObjectType.Equals(new GeneralMessage().GetType().Name)) { return (update.Data as GeneralMessage).MessageID; }
                else if (update.ObjectType.Equals(new AmbulanceService().GetType().Name)) { return (update.Data as AmbulanceService).AmbulanceID; }
                else if (update.ObjectType.Equals(new Hospital().GetType().Name)) { return (update.Data as Hospital).HospitalID; }
                else if (update.ObjectType.Equals(new MedicalPlan().GetType().Name)) { return (update.Data as MedicalPlan).ID; }
                else if (update.ObjectType.Equals(new MedicalAidStation().GetType().Name)) { return (update.Data as MedicalAidStation).AidStationID; }
                else if (update.ObjectType.Equals(new SafetyMessage().GetType().Name)) { return (update.Data as SafetyMessage).ID; }
                else if (update.ObjectType.Equals(new Incident().GetType().Name)) { return (update.Data as Incident).ID; }
                else if (update.ObjectType.Equals(new OperationalGroup().GetType().Name)) { return (update.Data as OperationalGroup).ID; }
                else if (update.ObjectType.Equals(new Crew().GetType().Name)) { return (update.Data as Crew).ID; }
                else if (update.ObjectType.Equals(new ResourceReplacementPlan().GetType().Name)) { return (update.Data as ResourceReplacementPlan).ID; }
            }
            return Guid.Empty;

        }


        public static SyncableItem DecryptTaskUpdateData(this TaskUpdate update, string encryptKey)
        {
            SyncableItem objDecrypted = null;

            try
            {
                string dataDecrypt = StringCipher.Decrypt(update.DataEnc, encryptKey);
                dataDecrypt = CompressionUtilities.Decompress(dataDecrypt);

                objDecrypted = dataDecrypt.ObjectFromJSONData(update.ObjectType);

            }
            catch (Exception)
            {

            }
            return objDecrypted;
        }


        public static SyncableItem ObjectFromJSONData(this string jsonData, string ObjectType)
        {
            SyncableItem objDecrypted = null;

            if (ObjectType.Equals(new Contact().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Contact>(jsonData);

            }
            else if (ObjectType.Equals(new Briefing().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Briefing>(jsonData);
            }
            else if (ObjectType.Equals(new CommsLogEntry().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<CommsLogEntry>(jsonData);
            }
            else if (ObjectType.Equals(new CommsPlanItem().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<CommsPlanItem>(jsonData);
            }

            else if (ObjectType.Equals(new CommsPlan().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<CommsPlan>(jsonData);
            }
            else if (ObjectType.Equals(new Hospital().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Hospital>(jsonData);
            }
            else if (ObjectType.Equals(new AmbulanceService().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<AmbulanceService>(jsonData);
            }
            else if (ObjectType.Equals(new IncidentObjective().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<IncidentObjective>(jsonData);
            }

            else if (ObjectType.Equals(new MedicalPlan().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<MedicalPlan>(jsonData);
            }
            else if (ObjectType.Equals(new Note().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Note>(jsonData);
            }
            else if (ObjectType.Equals(new OperationalPeriod().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<OperationalPeriod>(jsonData);
            }
            else if (ObjectType.Equals(new OrganizationChart().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<OrganizationChart>(jsonData);
            }
            else if (ObjectType.Equals(new ICSRole().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<ICSRole>(jsonData);
            }
            else if (ObjectType.Equals(new PositionLogEntry().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<PositionLogEntry>(jsonData);
            }

            else if (ObjectType.Equals(new TaskBasics().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<TaskBasics>(jsonData);
            }
            else if (ObjectType.Equals(new Timeline().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Timeline>(jsonData);
            }
            else if (ObjectType.Equals(new TimelineEvent().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<TimelineEvent>(jsonData);
            }

            else if (ObjectType.Equals(new Vehicle().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Vehicle>(jsonData);
            }


            else if (ObjectType.Equals(new CheckInRecord().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<CheckInRecord>(jsonData);
            }
            else if (ObjectType.Equals(new Personnel().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Personnel>(jsonData);
            }
            else if (ObjectType.Equals(new Incident().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Incident>(jsonData);
            }
            else if (ObjectType.Equals(new AirOperationsSummary().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<AirOperationsSummary>(jsonData);
            }
            else if (ObjectType.Equals(new Aircraft().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Aircraft>(jsonData);
            }
            else if (ObjectType.Equals(new NOTAM().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<NOTAM>(jsonData);
            }
            else if (ObjectType.Equals(new GeneralMessage().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<GeneralMessage>(jsonData);
            }
            else if (ObjectType.Equals(new IncidentObjectivesSheet().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<IncidentObjectivesSheet>(jsonData);
            }
            else if (ObjectType.Equals(new MedicalAidStation().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<MedicalAidStation>(jsonData);
            }
            else if (ObjectType.Equals(new SafetyMessage().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<SafetyMessage>(jsonData);
            }

        

            else if (ObjectType.Equals(new OperationalGroup().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<OperationalGroup>(jsonData);
            }

            else if (ObjectType.Equals(new Crew().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<Crew>(jsonData);
            }
            else if (ObjectType.Equals(new ResourceReplacementPlan().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<ResourceReplacementPlan>(jsonData);
            }


            return objDecrypted;
        }
    }
}
