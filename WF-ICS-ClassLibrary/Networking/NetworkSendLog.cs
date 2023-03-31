using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Networking
{
    public class NetworkSendLog
    {
        public NetworkSendLog() { objectsSent = new List<NetworkSendLogEntry>(); objectsReceived = new List<NetworkSendLogEntry>(); }
        private DateTime _LastUpdated;
        private List<NetworkSendLogEntry> _objectsSent;
        private List<NetworkSendLogEntry> _objectsReceived;

        public List<NetworkSendLogEntry> objectsSent { get => _objectsSent; private set { _objectsSent = value; _LastUpdated = DateTime.UtcNow; } }
        public List<NetworkSendLogEntry> objectsReceived { get => _objectsReceived; private set { _objectsReceived = value; _LastUpdated = DateTime.UtcNow; } }
        public void AddToSent(NetworkSendObject obj, DateTime dateSent = new DateTime(), bool successful = true)
        {
            NetworkSendLogEntry entry = new NetworkSendLogEntry(obj, dateSent, successful, true);
            if (dateSent == DateTime.MinValue) { entry.SendReceiveDateUTC = DateTime.UtcNow; }
            objectsSent.Add(entry); _LastUpdated = DateTime.UtcNow;
        }
        public void AddToReceived(NetworkSendObject obj, DateTime dateSent = new DateTime(), bool successful = true)
        {
            NetworkSendLogEntry entry = new NetworkSendLogEntry(obj, dateSent, successful, false);
            if (dateSent == DateTime.MinValue) { entry.SendReceiveDateUTC = DateTime.UtcNow; }
            objectsReceived.Add(entry); _LastUpdated = DateTime.UtcNow;

        }

        public bool ObjectAlreadySentOrReceived(NetworkSendObject objectToCheck)
        {
            if (objectsSent.Any(o => o.sendObject.RequestID == objectToCheck.RequestID)) { return true; }
            if (objectsReceived.Any(o => o.sendObject.RequestID == objectToCheck.RequestID)) { return true; }

            else { return false; }
        }

        public bool ObjectAlreadySent(object objToCheck)
        {

            if (objToCheck != null)
            {
                switch (objToCheck)
                {
                    case TaskUpdate tu:
                        if (objectsSent.Any(o => o.sendObject.taskUpdate.UpdateID == tu.UpdateID)) { return true; }
                        if (objectsReceived.Any(o => o.sendObject.taskUpdate.UpdateID == tu.UpdateID)) { return true; }
                        return false;
                        /*
                    case TeamMember tm:
                        if (objectsSent.Any(o => o.sendObject.teamMember != null && o.sendObject.teamMember.PersonID == tm.PersonID && o.sendObject.teamMember.LastUpdatedUTC == tm.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.teamMember != null && o.sendObject.teamMember.PersonID == tm.PersonID && o.sendObject.teamMember.LastUpdatedUTC == tm.LastUpdatedUTC)) { return true; }
                        return false;
                    case SignInRecord sr:
                        if (objectsSent.Any(o => o.sendObject.signInRecord != null && o.sendObject.signInRecord.SignInRecordID == sr.SignInRecordID && o.sendObject.signInRecord.RecordUpdatedUTC == sr.RecordUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.signInRecord != null && o.sendObject.signInRecord.SignInRecordID == sr.SignInRecordID && o.sendObject.signInRecord.RecordUpdatedUTC == sr.RecordUpdatedUTC)) { return true; }
                        return false;
                    case CommsLogEntry cle:
                        if (objectsSent.Any(o => o.sendObject.commsLogEntry != null && o.sendObject.commsLogEntry.EntryID == cle.EntryID && o.sendObject.commsLogEntry.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.commsLogEntry != null && o.sendObject.commsLogEntry.EntryID == cle.EntryID && o.sendObject.commsLogEntry.LastUpdated == cle.LastUpdated)) { return true; }
                        return false;


                    case Briefing cle:
                        if (objectsSent.Any(o => o.sendObject.briefing != null && o.sendObject.briefing.BriefingID == cle.BriefingID && o.sendObject.briefing.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.briefing != null && o.sendObject.briefing.BriefingID == cle.BriefingID && o.sendObject.briefing.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        return false;
                    case CommsPlan cle:
                        if (objectsSent.Any(o => o.sendObject.commsPlan != null && o.sendObject.commsPlan.ID == cle.ID && o.sendObject.commsPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.commsPlan != null && o.sendObject.commsPlan.ID == cle.ID && o.sendObject.commsPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case CommsPlanItem cle:
                        if (objectsSent.Any(o => o.sendObject.commsPlanItem != null && o.sendObject.commsPlanItem.ItemID == cle.ItemID && o.sendObject.commsPlanItem.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.commsPlanItem != null && o.sendObject.commsPlanItem.ItemID == cle.ItemID && o.sendObject.commsPlanItem.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case Contact cle:
                        if (objectsSent.Any(o => o.sendObject.contact != null && o.sendObject.contact.ContactID == cle.ContactID && o.sendObject.contact.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.contact != null && o.sendObject.contact.ContactID == cle.ContactID && o.sendObject.contact.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case MedicalPlan cle:
                        if (objectsSent.Any(o => o.sendObject.medicalPlan != null && o.sendObject.medicalPlan.ID == cle.ID && o.sendObject.medicalPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.medicalPlan != null && o.sendObject.medicalPlan.ID == cle.ID && o.sendObject.medicalPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case IncidentObjective cle:
                        if (objectsSent.Any(o => o.sendObject.objective != null && o.sendObject.objective.IncidentObjectiveID == cle.IncidentObjectiveID && o.sendObject.objective.ObjectiveLastUpdatedUTC == cle.ObjectiveLastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.objective != null && o.sendObject.objective.IncidentObjectiveID == cle.IncidentObjectiveID && o.sendObject.objective.ObjectiveLastUpdatedUTC == cle.ObjectiveLastUpdatedUTC)) { return true; }
                        return false;
                    case Note cle:
                        if (objectsSent.Any(o => o.sendObject.note != null && o.sendObject.note.NoteID == cle.NoteID && o.sendObject.note.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.note != null && o.sendObject.note.NoteID == cle.NoteID && o.sendObject.note.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        return false;
                    case OrganizationChart cle:
                        if (objectsSent.Any(o => o.sendObject.organizationChart != null && o.sendObject.organizationChart.OrganizationalChartID == cle.OrganizationalChartID && o.sendObject.organizationChart.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.organizationChart != null && o.sendObject.organizationChart.OrganizationalChartID == cle.OrganizationalChartID && o.sendObject.organizationChart.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case SafetyPlan cle:
                        if (objectsSent.Any(o => o.sendObject.safetyPlan != null && o.sendObject.safetyPlan.PlanID == cle.PlanID && o.sendObject.safetyPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.safetyPlan != null && o.sendObject.safetyPlan.PlanID == cle.PlanID && o.sendObject.safetyPlan.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case Timeline cle:
                        if (objectsSent.Any(o => o.sendObject.timeline != null && o.sendObject.timeline.TimeLineID == cle.TimeLineID && o.sendObject.timeline.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.timeline != null && o.sendObject.timeline.TimeLineID == cle.TimeLineID && o.sendObject.timeline.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case TimelineEvent cle:
                        if (objectsSent.Any(o => o.sendObject.timelineEvent != null && o.sendObject.timelineEvent.TimelineEventID == cle.TimelineEventID && o.sendObject.timelineEvent.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.timelineEvent != null && o.sendObject.timelineEvent.TimelineEventID == cle.TimelineEventID && o.sendObject.timelineEvent.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case Vehicle cle:
                        if (objectsSent.Any(o => o.sendObject.vehicle != null && o.sendObject.vehicle.ID == cle.ID && o.sendObject.vehicle.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.vehicle != null && o.sendObject.vehicle.ID == cle.ID && o.sendObject.vehicle.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case TaskBasics cle:
                        if (objectsSent.Any(o => o.sendObject.taskBasics != null && o.sendObject.taskBasics.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.taskBasics != null && o.sendObject.taskBasics.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case OperationalPeriod cle:
                        if (objectsSent.Any(o => o.sendObject.operationalPeriod != null && o.sendObject.operationalPeriod.OperationalPeriodID == cle.OperationalPeriodID && o.sendObject.operationalPeriod.PeriodStart == cle.PeriodStart && o.sendObject.operationalPeriod.PeriodEnd == cle.PeriodEnd)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.operationalPeriod != null && o.sendObject.operationalPeriod.OperationalPeriodID == cle.OperationalPeriodID && o.sendObject.operationalPeriod.PeriodStart == cle.PeriodStart && o.sendObject.operationalPeriod.PeriodEnd == cle.PeriodEnd)) { return true; }
                        return false;
                    case PositionLogEntry cle:
                        if (objectsSent.Any(o => o.sendObject.positionLogEntry != null && o.sendObject.positionLogEntry.LogID == cle.LogID && o.sendObject.positionLogEntry.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.positionLogEntry != null && o.sendObject.positionLogEntry.LogID == cle.LogID && o.sendObject.positionLogEntry.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case ICSRole cle:
                        if (objectsSent.Any(o => o.sendObject.icsRole != null && o.sendObject.icsRole.OrgChartRoleID == cle.OrgChartRoleID && o.sendObject.icsRole.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.icsRole != null && o.sendObject.icsRole.OrgChartRoleID == cle.OrgChartRoleID && o.sendObject.icsRole.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                        */
                        /*
                    case Assignment a:
                        if (objectsSent.Any(o => o.sendObject.assignment != null && o.sendObject.assignment.AssignmentID == a.AssignmentID && o.sendObject.assignment.LastUpdated == a.LastUpdated)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.assignment != null && o.sendObject.assignment.AssignmentID == a.AssignmentID && o.sendObject.assignment.LastUpdated == a.LastUpdated)) { return true; }
                        return false;
                    case AssignmentDebrief ad:
                        if (objectsSent.Any(o => o.sendObject.assignmentDebrief != null && o.sendObject.assignmentDebrief.AssignmentID == ad.AssignmentID && o.sendObject.assignmentDebrief.LastUpdatedUTC == ad.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.assignmentDebrief != null && o.sendObject.assignmentDebrief.AssignmentID == ad.AssignmentID && o.sendObject.assignmentDebrief.LastUpdatedUTC == ad.LastUpdatedUTC)) { return true; }
                        return false;
                    case Clue cle:
                        if (objectsSent.Any(o => o.sendObject.clue != null && o.sendObject.clue.ClueID == cle.ClueID && o.sendObject.clue.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.clue != null && o.sendObject.clue.ClueID == cle.ClueID && o.sendObject.clue.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case ShiftBriefing cle:
                        if (objectsSent.Any(o => o.sendObject.shiftBriefing != null && o.sendObject.shiftBriefing.BriefingID == cle.BriefingID && o.sendObject.shiftBriefing.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.shiftBriefing != null && o.sendObject.shiftBriefing.BriefingID == cle.BriefingID && o.sendObject.shiftBriefing.DateUpdatedUTC == cle.DateUpdatedUTC)) { return true; }
                        return false;
                    case SubjectProfile cle:
                        if (objectsSent.Any(o => o.sendObject.subjectProfile != null && o.sendObject.subjectProfile.SubjectProfileID == cle.SubjectProfileID && o.sendObject.subjectProfile.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.subjectProfile != null && o.sendObject.subjectProfile.SubjectProfileID == cle.SubjectProfileID && o.sendObject.subjectProfile.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;

                    case WhiteboardItem cle:
                        if (objectsSent.Any(o => o.sendObject.whiteboardItem != null && o.sendObject.whiteboardItem.ItemID == cle.ItemID && o.sendObject.whiteboardItem.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.whiteboardItem != null && o.sendObject.whiteboardItem.ItemID == cle.ItemID && o.sendObject.whiteboardItem.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;

                    case UrgencyCalculation cle:
                        if (objectsSent.Any(o => o.sendObject.urgencyCalculation != null && o.sendObject.urgencyCalculation.UrgencyID == cle.UrgencyID && o.sendObject.urgencyCalculation.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.urgencyCalculation != null && o.sendObject.urgencyCalculation.UrgencyID == cle.UrgencyID && o.sendObject.urgencyCalculation.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;

                    case MattsonEvaluation cle:
                        if (objectsSent.Any(o => o.sendObject.mattsonEvaluation != null && o.sendObject.mattsonEvaluation.MattsonID == cle.MattsonID && o.sendObject.mattsonEvaluation.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.mattsonEvaluation != null && o.sendObject.mattsonEvaluation.MattsonID == cle.MattsonID && o.sendObject.mattsonEvaluation.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case MapSegment cle:
                        if (objectsSent.Any(o => o.sendObject.mapSegment != null && o.sendObject.mapSegment.SegmentID == cle.SegmentID && o.sendObject.mapSegment.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.mapSegment != null && o.sendObject.mapSegment.SegmentID == cle.SegmentID && o.sendObject.mapSegment.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case MattsonScore cle:
                        if (objectsSent.Any(o => o.sendObject.mattsonScore != null && o.sendObject.mattsonScore.ScoreID == cle.ScoreID && o.sendObject.mattsonScore.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.mattsonScore != null && o.sendObject.mattsonScore.ScoreID == cle.ScoreID && o.sendObject.mattsonScore.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;

                    case TaskEquipment cle:
                        if (objectsSent.Any(o => o.sendObject.taskEquipment != null && o.sendObject.taskEquipment.EquipmentID == cle.EquipmentID && o.sendObject.taskEquipment.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.taskEquipment != null && o.sendObject.taskEquipment.EquipmentID == cle.EquipmentID && o.sendObject.taskEquipment.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                    case EquipmentIssue cle:
                        if (objectsSent.Any(o => o.sendObject.equipmentIssue != null && o.sendObject.equipmentIssue.IssueID == cle.IssueID && o.sendObject.equipmentIssue.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        else if (objectsReceived.Any(o => o.sendObject.equipmentIssue != null && o.sendObject.equipmentIssue.IssueID == cle.IssueID && o.sendObject.equipmentIssue.LastUpdatedUTC == cle.LastUpdatedUTC)) { return true; }
                        return false;
                        */
                }
            }


            return false;
        }

    }

    public class NetworkSendLogEntry
    {
        public Guid LogEntryID { get; set; }
        public NetworkSendObject sendObject { get; set; }
        public DateTime SendReceiveDateUTC { get; set; }
        public bool SentSuccessfully { get; set; }
        public bool IsSend { get; set; } //if this is false, the item was received rather than sent.

        public NetworkSendLogEntry(NetworkSendObject obj, DateTime dat, bool successful, bool isSend)
        {
            LogEntryID = Guid.NewGuid();
            sendObject = obj; SendReceiveDateUTC = dat; SentSuccessfully = successful; IsSend = isSend;
        }
    }

    public class NetworkSendResults
    {
        public List<string> Errors { get; set; }
        public NetworkSendObject ObjectSent { get; set; }
        public bool SentSuccessfully { get; set; }
    }
}
