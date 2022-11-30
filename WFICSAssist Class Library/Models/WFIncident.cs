using NetworkCommsDotNet.Tools;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFICSAssist_Class_Library.Utilities;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract, 
        /*
        ProtoInclude(101, typeof(Assignment)), 
        ProtoInclude(102, typeof(AssignmentDebrief)), ProtoInclude(104, typeof(Clue)), ProtoInclude(110, typeof(TaskEquipment)),
 ProtoInclude(111, typeof(EquipmentIssue)),
         ProtoInclude(113, typeof(MattsonEvaluation)),
 ProtoInclude(114, typeof(MattsonScore)),
 ProtoInclude(115, typeof(MapSegment)),
         ProtoInclude(126, typeof(ShiftBriefing)),
 ProtoInclude(127, typeof(SubjectProfile)),
         ProtoInclude(131, typeof(UrgencyCalculation)),
         ProtoInclude(133, typeof(WhiteboardItem))*/


    ProtoInclude(103, typeof(Briefing)),
 ProtoInclude(105, typeof(CommsLogEntry)),
 ProtoInclude(106, typeof(CommsPlan)),
 ProtoInclude(107, typeof(CommsPlanItem)),
 ProtoInclude(108, typeof(CommsPlanItemLink)),
 ProtoInclude(109, typeof(Contact)),
 ProtoInclude(112, typeof(IncidentObjective)),
 ProtoInclude(116, typeof(MedicalPlan)),
 ProtoInclude(117, typeof(TeamMember)),
 ProtoInclude(118, typeof(MemberStatus)),
 ProtoInclude(119, typeof(SignInRecord)),
 ProtoInclude(120, typeof(Note)),
 ProtoInclude(121, typeof(OperationalPeriod)),
 ProtoInclude(122, typeof(OrganizationChart)),
 ProtoInclude(123, typeof(ICSRole)),
 ProtoInclude(124, typeof(PositionLogEntry)),
 ProtoInclude(125, typeof(SafetyPlan)),
 ProtoInclude(128, typeof(TaskBasics)),
 ProtoInclude(129, typeof(Timeline)),
 ProtoInclude(130, typeof(TimelineEvent)),
 ProtoInclude(132, typeof(Vehicle))]
    [Serializable]


    public class WFIncident
    {
        public WFIncident()
        {
            TaskID = System.Guid.NewGuid();
            allSafetyPlans = new List<SafetyPlan>();
            allObjectives = new List<IncidentObjective>();
           

           
            allBriefings = new List<Briefing>();
            DocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DocumentPath = System.IO.Path.Combine(DocumentPath, "SAR ICS Form Helper");
            allOrgCharts = new List<OrganizationChart>();
           
            allMedicalPlans = new List<MedicalPlan>();
            allCommsPlans = new List<CommsPlan>();
            additionalCommsItems = new List<CommsPlanItem>();
           
            allCommsLogEntries = new List<CommsLogEntry>();
            AllOperationalPeriods = new List<OperationalPeriod>();
           
           
            taskTimeline = new Timeline();
           // allEquipment = new List<TaskEquipment>();
           // allLogisticalNeeds = new List<LogisticalNeed>();
           // allLogisticalNeedsLists = new List<LogisticalNeedsList>();
            allVehicles = new List<Vehicle>();
            allTaskUpdates = new List<TaskUpdate>();
            TaskEncryptionKey = Utilities.RandomPasswordGenerator.GeneratePassword();
        }

        [ProtoMember(1)] private Guid _TaskID;
        [ProtoMember(2)] private string _TaskName;
        [ProtoMember(3)] private string _TaskNumber;
        [ProtoMember(4)] private string _AgencyFileNumber;
        [ProtoMember(5)] private string _FileName;
        [ProtoMember(6)] private string _ICPCallsign;
       //[ProtoMember(7)] private string _SubjectCategory;
      //  [ProtoMember(8)] public Mattson _Mattson;
      //  [ProtoMember(9)] private double _subjectVisibility;
      //  [ProtoMember(10)] private double _generalRangeOfDetection;
        [ProtoMember(11)] private string _currentFilePath;
       // [ProtoMember(12)] private List<Assignment> _allAssignments;
        [ProtoMember(13)] private List<SafetyPlan> _allSafetyPlans;
        [ProtoMember(14)] private List<Briefing> _allBriefings;
        [ProtoMember(15)] private List<IncidentObjective> _allObjectives;
        [ProtoMember(16)] private List<OrganizationChart> _allOrgCharts;
      //  [ProtoMember(17)] private List<UrgencyCalculation> _allUrgencyCalculations;
        [ProtoMember(18)] private List<MedicalPlan> _allMedicalPlans;
        [ProtoMember(19)] private List<CommsPlan> _allCommsPlans;
        [ProtoMember(20)] private List<CommsPlanItem> _additionalCommsItems;
      //  [ProtoMember(21)] private List<SubjectProfile> _allSubjectProfiles;
        [ProtoMember(22)] private List<CommsLogEntry> _allCommsLogEntries;
        [ProtoMember(23)] private string _DocumentPath;
        [ProtoMember(24)] private string _sourceIdentifier;
        [ProtoMember(25)] private int _RelayCount;
        [ProtoMember(26)] private Guid _RequestID;
      //  [ProtoMember(27)] private List<WhiteboardItem> _whiteboardItems = new List<WhiteboardItem>();
        [ProtoMember(28)] private List<SignInRecord> _signInRecords = new List<SignInRecord>();
        [ProtoMember(29)] private List<TeamMember> _taskTeamMembers = new List<TeamMember>();
        [ProtoMember(30)] private Organization _taskOrganization = new Organization();
        [ProtoMember(31)] private DateTime _DateCreatedUTC;
        [ProtoMember(32)] private DateTime _DateUpdatedUTC;
       // [ProtoMember(33)] private List<TaskUserAccess> _taskUsers;
        [ProtoMember(34)] private List<OperationalPeriod> _AllOperationalPeriods;
        [ProtoMember(35)] private bool _IsTraining;
       // [ProtoMember(36)] private List<AssignmentDebrief> _allAssignmentDebriefs = new List<AssignmentDebrief>();
       // [ProtoMember(37)] private List<Clue> _allClues = new List<Clue>();
       // [ProtoMember(38)] private List<MapSegment> _allMapSegments = new List<MapSegment>();
       // [ProtoMember(39)] private List<MattsonEvaluation> _allMattsonEvaluations = new List<MattsonEvaluation>();
        [ProtoMember(40)] private List<Contact> _allContacts = new List<Contact>();
        [ProtoMember(41)] private Timeline _taskTimeline;
        [ProtoMember(42)] private List<Note> _allNotes = new List<Note>();
        [ProtoMember(43)] private List<Vehicle> _allVehicles = new List<Vehicle>();
        /*
        [ProtoMember(44)] private List<ShiftBriefing> _allShiftBriefings = new List<ShiftBriefing>();
        [ProtoMember(45)] private List<TaskEquipment> _allEquipment = new List<TaskEquipment>();
        [ProtoMember(46)] private List<EquipmentIssue> _allEquipmentIssues = new List<EquipmentIssue>();
        [ProtoMember(47)] private List<LogisticalNeed> _allLogisticalNeeds = new List<LogisticalNeed>();
        [ProtoMember(48)] private List<LogisticalNeedsList> _allLogisticalNeedsLists = new List<LogisticalNeedsList>();
        */
        [ProtoMember(49)] private List<PositionLogEntry> _allPositionLogEntries = new List<PositionLogEntry>();
        [ProtoMember(50)] private string _taskEncryptionKey;
        [ProtoMember(51)] private List<TaskUpdate> _allTaskUpdates = new List<TaskUpdate>();


        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public string TaskName { get => _TaskName; set { if (!string.IsNullOrEmpty(value)) { _TaskName = value.Trim(); } else { _TaskName = null; } } }
        public string TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public string AgencyFileNumber { get => _AgencyFileNumber; set => _AgencyFileNumber = value; }
        public string FileName { get => _FileName; set => _FileName = value; }
        public CommsPlanItem PrimaryChannel(int Ops)
        {
            this.createCommsPlanAsNeeded(Ops);
            return allCommsPlans.Where(o => o.OpsPeriod == Ops).First().getItemByFunction("OPERATIONS");

        }
        public CommsPlanItem SecondaryChannel(int Ops)
        {
            this.createCommsPlanAsNeeded(Ops);
            return allCommsPlans.Where(o => o.OpsPeriod == Ops).First().getItemByFunction("SUPPORT NET");
        }
        public CommsPlanItem EmergencyChannel(int Ops)
        {
            this.createCommsPlanAsNeeded(Ops);
            return allCommsPlans.Where(o => o.OpsPeriod == Ops).First().getItemByFunction("EMERGENCY CHANNEL");
        }
        public CommsPlanItem Repeater(int Ops)
        {
            this.createCommsPlanAsNeeded(Ops);
            return allCommsPlans.Where(o => o.OpsPeriod == Ops).First().getItemByFunction("REPEATER");
        }

        public string ICPCallSign { get => _ICPCallsign; set => _ICPCallsign = value; }


        /*
        public string SubjectCategory { get => _SubjectCategory; set => _SubjectCategory = value; }
        public Mattson mattson { get => _Mattson; set => _Mattson = value; }
        public double SubjectVisibility { get => _subjectVisibility; set => _subjectVisibility = value; } //used for calculating POD / Spacing
        public double GeneralRangeOfDetection { get => _generalRangeOfDetection; set => _generalRangeOfDetection = value; }
        public List<Assignment> allAssignments { get => _allAssignments; set => _allAssignments = value; }
        public List<AssignmentDebrief> allAssignmentDebriefs { get => _allAssignmentDebriefs; set => _allAssignmentDebriefs = value; }
        public List<Clue> allClues { get => _allClues; set => _allClues = value; }
        public List<UrgencyCalculation> allUrgencyCalculations { get => _allUrgencyCalculations; set => _allUrgencyCalculations = value; }
        public List<SubjectProfile> allSubjectProfiles { get => _allSubjectProfiles; set => _allSubjectProfiles = value; }
        public List<MapSegment> allMapSegments { get => _allMapSegments; set => _allMapSegments = value; }
        public List<MattsonEvaluation> allMattsonEvaluations { get => _allMattsonEvaluations; set => _allMattsonEvaluations = value; }
        public List<ShiftBriefing> allShiftBriefings { get => _allShiftBriefings; set => _allShiftBriefings = value; }
        public List<TaskEquipment> allEquipment { get => _allEquipment; set => _allEquipment = value; }
        public List<EquipmentIssue> allEquipmentIssues { get => _allEquipmentIssues; set => _allEquipmentIssues = value; }
        public List<LogisticalNeed> allLogisticalNeeds { get => _allLogisticalNeeds; set => _allLogisticalNeeds = value; }
        public List<LogisticalNeedsList> allLogisticalNeedsLists { get => _allLogisticalNeedsLists; set => _allLogisticalNeedsLists = value; }
        public List<WhiteboardItem> whiteboardItems { get { return _whiteboardItems; } set { _whiteboardItems = value; } }
        */



        public string currentFilePath { get => _currentFilePath; set => _currentFilePath = value; }


        public string SARManager(int Ops) { return this.getNameByRoleName(Ops, "SAR Manager"); }
        public string PlansChief(int Ops) { return this.getNameByRoleName(Ops, "Planning Section Chief"); }
        public string OpsChief(int Ops) { return this.getNameByRoleName(Ops, "Operations Section Chief"); }
        public string LogisticsChief(int Ops) { return this.getNameByRoleName(Ops, "Logistics Section Chief"); }
        public string SafetyOfficer(int Ops) { return this.getNameByRoleName(Ops, "Safety Officer"); }





        public List<SafetyPlan> allSafetyPlans { get => _allSafetyPlans; set => _allSafetyPlans = value; }
        public List<Briefing> allBriefings { get => _allBriefings; set => _allBriefings = value; }
        public List<IncidentObjective> allObjectives { get => _allObjectives; set => _allObjectives = value; }
        public List<OrganizationChart> allOrgCharts { get => _allOrgCharts; set => _allOrgCharts = value; }
        public List<MedicalPlan> allMedicalPlans { get => _allMedicalPlans; set => _allMedicalPlans = value; }
        public List<CommsPlan> allCommsPlans { get => _allCommsPlans; set => _allCommsPlans = value; }
        public List<CommsPlanItem> additionalCommsItems { get => _additionalCommsItems; set => _additionalCommsItems = value; }
        public List<CommsLogEntry> allCommsLogEntries { get => _allCommsLogEntries; set => _allCommsLogEntries = value; }
        public string DocumentPath { get => _DocumentPath; set => _DocumentPath = value; }
        public List<Contact> allContacts { get => _allContacts; set => _allContacts = value; }
        public Timeline taskTimeline { get => _taskTimeline; set => _taskTimeline = value; }
        public List<Note> allNotes { get => _allNotes; set => _allNotes = value; }
        public List<Vehicle> allVehicles { get { if (_allVehicles == null) { _allVehicles = new List<Vehicle>(); } return _allVehicles; } set => _allVehicles = value; }
        public List<PositionLogEntry> allPositionLogEntries { get => _allPositionLogEntries; set => _allPositionLogEntries = value; }
        public List<TaskUpdate> allTaskUpdates { get => _allTaskUpdates; set => _allTaskUpdates = value; }





        //for network reasons

        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        public int RelayCount { get => _RelayCount; set => _RelayCount = value; }
        public Guid RequestID { get => _RequestID; set => _RequestID = value; }

        public List<OperationalPeriod> AllOperationalPeriods { get => _AllOperationalPeriods; set => _AllOperationalPeriods = value; }
        public List<OperationalPeriod> AllOperationalPeriodsWithContent
        {
            get
            {
                List<OperationalPeriod> periods = new List<OperationalPeriod>();
                foreach (OperationalPeriod ops in _AllOperationalPeriods)
                {
                    if (OpPeriodHasContent(ops.PeriodNumber))
                    {
                        periods.Add(ops);
                    }
                }

                return periods;
            }
        }

        public DateTime getOpPeriodStart(int opPeriod)
        {
            if (AllOperationalPeriods.Where(o => o.PeriodNumber == opPeriod).Any()) { return AllOperationalPeriods.Where(o => o.PeriodNumber == opPeriod).First().PeriodStart; }
            else { return DateTime.MinValue; }
        }
        public DateTime getOpPeriodEnd(int opPeriod)
        {
            if (AllOperationalPeriods.Any(o => o.PeriodNumber == opPeriod)) { return AllOperationalPeriods.Where(o => o.PeriodNumber == opPeriod).First().PeriodEnd; }
            else { return DateTime.MaxValue; }
        }


        public List<SignInRecord> AllSignInRecords { get { return _signInRecords; } set { _signInRecords = value; } }


        public int totalItemsInLists
        {
            get
            {
                return
                    //allAssignmentDebriefs.Count + allAssignments.Count + allClues.Count + 
                    allSafetyPlans.Count + allBriefings.Count + allObjectives.Count + allOrgCharts.Count 
                    // + allUrgencyCalculations.Count 
                    + allMedicalPlans.Count + allCommsPlans.Count 
                   // + allSubjectProfiles.Count 
                    + allCommsLogEntries.Count + AllSignInRecords.Count;
            }
        }



        public List<TeamMember> TaskTeamMembers { get { return _taskTeamMembers; } set { _taskTeamMembers = value; } }
        public Organization TaskOrganization { get => _taskOrganization; set => _taskOrganization = value; }
        public Guid OrganizationID { get => TaskOrganization.OrganizationID; set => TaskOrganization.OrganizationID = value; }
        public string OrganizationName { get => TaskOrganization.OrganizationName; set => TaskOrganization.OrganizationName = value; }

        public string TaskRelativeURL { get { return "/Tasks/TaskDetails/" + TaskNumber; } }

        public DateTime DateCreatedUTC { get => _DateCreatedUTC; set => _DateCreatedUTC = value; }
        public DateTime DateUpdatedUTC { get => _DateUpdatedUTC; set => _DateUpdatedUTC = value; }
        public DateTime DateCreatedLocal { get { return DateCreatedUTC.ToLocalTime(); } }
        public DateTime DateUpdatedLocal { get { return DateUpdatedUTC.ToLocalTime(); } }

       // public List<TaskUserAccess> TaskUsers { get => _taskUsers; set => _taskUsers = value; }
        private DateTime _lastCheckDBUTC;
        public DateTime LastCheckDBUTC { get => _lastCheckDBUTC; set => _lastCheckDBUTC = value; }
        public bool IsTraining { get => _IsTraining; set => _IsTraining = value; }

        public string TaskEncryptionKey { get => _taskEncryptionKey; set => _taskEncryptionKey = value; }


        /*
        public List<Assignment> TeamsActive(DateTime date)
        {
            List<Assignment> teams = new List<Assignment>();
            foreach (Assignment assignment in allAssignments.Where(o => o.LastRadioLogTime > DateTime.MinValue))
            {
                CommsLogEntry entry = GetLastCommsEntry(assignment.AssignmentID, date);
                if (entry.status.Active) { teams.Add(assignment); }
            }
            return teams;
        }
        */

        public CommsLogEntry GetLastCommsEntry(Guid TeamID, DateTime date)
        {
            //gets the most recent entry as of the date entered
            List<CommsLogEntry> allEntries = allCommsLogEntries.Where(o => o.Active && (o.FromTeamID == TeamID || o.ToTeamID == TeamID) && o.LogDate <= date).OrderByDescending(o => o.LogDate).ToList();
            if (allEntries.Count > 0) { return allEntries.First(); }
            else { CommsLogEntry entry = new CommsLogEntry(); return entry; }
        }

        private int _savedHighestOpsPeriod; //to be used when getting a list of these from the database without loading everything.
        public int SavedHighestOpsPeriod { get => _savedHighestOpsPeriod; set => _savedHighestOpsPeriod = value; }

        public int highestOpsPeriod
        {
            get
            {
                int ops = 0;
                if (allOrgCharts.Count > 0) { int orgOps = allOrgCharts.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (orgOps > ops) { ops = orgOps; } }
                //if (allAssignments.Count > 0) { int asigOps = allAssignments.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (asigOps > ops) { ops = asigOps; } }
                if (allSafetyPlans.Count > 0) { int safeOps = allSafetyPlans.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (safeOps > ops) { ops = safeOps; } }
                if (allBriefings.Count > 0) { int briefOps = allBriefings.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (briefOps > ops) { ops = briefOps; } }
                if (allObjectives.Count > 0) { int objOps = allObjectives.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (objOps > ops) { ops = objOps; } }
                if (allMedicalPlans.Count > 0) { int objOps = allMedicalPlans.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (objOps > ops) { ops = objOps; } }
                //if (allSubjectProfiles.Count > 0) { int subOps = allSubjectProfiles.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (subOps > ops) { ops = subOps; } }
                if (allCommsLogEntries.Count > 0) { int commsOps = allCommsLogEntries.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (commsOps > ops) { ops = commsOps; } }
                if (AllSignInRecords.Count > 0) { int signInOps = AllSignInRecords.OrderByDescending(o => o.OpPeriod).First().OpPeriod; if (signInOps > ops) { ops = signInOps; } }
                if (ops <= 0 && _savedHighestOpsPeriod > 0) { ops = _savedHighestOpsPeriod; }
                if (ops == 0) { ops = 1; }
                return ops;
            }
        }

        public int lowestOpsPeriod
        {
            get
            {
                int ops = 1000;
                if (allOrgCharts.Count > 0) { int orgOps = allOrgCharts.OrderBy(o => o.OpPeriod).First().OpPeriod; if (orgOps < ops) { ops = orgOps; } }
                //if (allAssignments.Count > 0) { int asigOps = allAssignments.OrderBy(o => o.OpPeriod).First().OpPeriod; if (asigOps < ops) { ops = asigOps; } }
                if (allSafetyPlans.Count > 0) { int safeOps = allSafetyPlans.OrderBy(o => o.OpPeriod).First().OpPeriod; if (safeOps < ops) { ops = safeOps; } }
                if (allBriefings.Count > 0) { int briefOps = allBriefings.OrderBy(o => o.OpPeriod).First().OpPeriod; if (briefOps < ops) { ops = briefOps; } }
                if (allObjectives.Count > 0) { int objOps = allObjectives.OrderBy(o => o.OpPeriod).First().OpPeriod; if (objOps < ops) { ops = objOps; } }
                if (allMedicalPlans.Count > 0) { int objOps = allMedicalPlans.OrderBy(o => o.OpPeriod).First().OpPeriod; if (objOps < ops) { ops = objOps; } }
                //if (allSubjectProfiles.Count > 0) { int subOps = allSubjectProfiles.OrderBy(o => o.OpPeriod).First().OpPeriod; if (subOps < ops) { ops = subOps; } }
                if (allCommsLogEntries.Count > 0) { int commsOps = allCommsLogEntries.OrderBy(o => o.OpPeriod).First().OpPeriod; if (commsOps < ops) { ops = commsOps; } }
                if (AllSignInRecords.Count > 0) { int signInOps = AllSignInRecords.OrderBy(o => o.OpPeriod).First().OpPeriod; if (signInOps < ops) { ops = signInOps; } }
                if (ops <= 0 && _savedHighestOpsPeriod > 0) { ops = _savedHighestOpsPeriod; }
                if (ops == 0) { ops = 1; }
                return ops;
            }
        }

        public bool OpPeriodHasContent(int opPeriod)
        {
            bool hasContent = false;
            //if (allAssignments.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            if (allSafetyPlans.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            else if (allBriefings.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            else if (allObjectives.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            //else if (allSubjectProfiles.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            else if (allCommsLogEntries.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            else if (AllSignInRecords.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
          //  else if (whiteboardItems.Where(o => o.OpPeriod == opPeriod).Any()) { hasContent = true; }
            // else if (hasMeangfulCommsPlan(opPeriod)) { hasContent = true; }
            else if (hasMeaningfulMedicalPlan(opPeriod)) { hasContent = true; }
            else if (hasMeaningfulOrgChart(opPeriod)) { hasContent = true; }
            return hasContent;
        }

        public bool AnyOpPeriodHasMeanginfulContent
        {
            get
            {
                foreach (OperationalPeriod period in AllOperationalPeriods)
                {
                    if (OpPeriodHasContent(period.PeriodNumber)) { return true; }
                }
                return false;
            }
        }

        public List<DateTime> inferOpStartEnd(int opPeriod)
        {
            DateTime start = DateTime.MinValue;
            DateTime end = DateTime.MinValue;

            DateTime thisStart;
            DateTime thisEnd;
            //assignments
            /*
            if (allAssignments.Where(o => o.OpPeriod == opPeriod).Any())
            {
                thisStart = allAssignments.Where(o => o.OpPeriod == opPeriod).Min(o => o.DatePrepared);
                thisEnd = allAssignments.Where(o => o.OpPeriod == opPeriod).Max(o => o.DatePrepared);
                if (thisStart < start || (start == DateTime.MinValue && thisStart > DateTime.MinValue)) { start = thisStart; }
                if (thisEnd > end) { end = thisEnd; }
            }*/


            //safety plans
            if (allSafetyPlans.Where(o => o.OpPeriod == opPeriod).Any())
            {

                thisStart = allSafetyPlans.Where(o => o.OpPeriod == opPeriod).Min(o => o.DatePrepared);
                thisEnd = allSafetyPlans.Where(o => o.OpPeriod == opPeriod).Max(o => o.DatePrepared);
                if (thisStart < start || (start == DateTime.MinValue && thisStart > DateTime.MinValue)) { start = thisStart; }
                if (thisEnd > end) { end = thisEnd; }
            }

            //comms log
            if (allCommsLogEntries.Where(o => o.OpPeriod == opPeriod).Any())
            {
                thisStart = allCommsLogEntries.Where(o => o.OpPeriod == opPeriod).Min(o => o.LogDate);
                thisEnd = allCommsLogEntries.Where(o => o.OpPeriod == opPeriod).Max(o => o.LogDate);
                if (thisStart < start || (start == DateTime.MinValue && thisStart > DateTime.MinValue)) { start = thisStart; }
                if (thisEnd > end) { end = thisEnd; }
            }


            //Sign in
            if (AllSignInRecords.Where(o => o.OpPeriod == opPeriod).Any())
            {
                thisStart = AllSignInRecords.Where(o => o.OpPeriod == opPeriod).Min(o => o.SignInTime);
                thisEnd = AllSignInRecords.Where(o => o.OpPeriod == opPeriod).Max(o => o.SignOutTime);
                if (thisStart < start || (start == DateTime.MinValue && thisStart > DateTime.MinValue)) { start = thisStart; }
                if (thisEnd > end) { end = thisEnd; }
            }


            List<DateTime> dates = new List<DateTime>();
            dates.Add(start);
            dates.Add(end);
            return dates;
        }



        public bool hasMeaningfulOrgChart(int ops)
        {
            if (allOrgCharts.Where(o => o.OpPeriod == ops).Count() <= 0) { return false; }
            else if (allOrgCharts.Where(o => o.OpPeriod == ops).First().AllRoles.Where(o => o.IndividualName != null && o.IndividualName != "").Count() > 0) { return true; }
            else { return false; }
        }
        public bool hasMeangfulCommsPlan(int ops)
        {
            if (allCommsPlans.Where(o => o.OpsPeriod == ops).Count() <= 0) { return false; }
            else if (allCommsPlans.Where(o => o.OpsPeriod == ops).First().allCommsItems.Where(o => o.ChannelID != null && o.ChannelID != "").Count() > 0) { return true; }
            else { return false; }
        }
        public bool hasMeaningfulMedicalPlan(int ops)
        {
            if (allMedicalPlans.Where(o => o.OpPeriod == ops).Count() <= 0) { return false; }
            else if (allMedicalPlans.Where(o => o.OpPeriod == ops).First().ambulanceServices.Count() > 0 || allMedicalPlans.Where(o => o.OpPeriod == ops).First().hospitals.Count() > 0) { return true; }
            else { return false; }
        }
        public bool hasMeaningfulObjectives(int ops) { return (allObjectives.Where(o => o.OpPeriod == ops).Count() > 0); }
       // public bool hasAnyAssignments(int ops) { return allAssignments.Where(o => o.OpPeriod == ops).Count() > 0; }
        public bool hasAnySafetyPlans(int ops) { return allSafetyPlans.Where(o => o.OpPeriod == ops).Count() > 0; }
        // public bool hasAnySubjectProfiles(int ops) { return allSubjectProfiles.Where(o => o.OpPeriod == ops).Count() > 0; }



        public List<CommsPlanItem> getCommsPlanItemsUsedToDate()
        {
            List<CommsPlanItem> items = new List<CommsPlanItem>();
            items.AddRange(additionalCommsItems);
            foreach (CommsPlan cp in allCommsPlans)
            {
                foreach (CommsPlanItem item in cp.allCommsItems)
                {
                    if (!string.IsNullOrEmpty(item.ChannelID) && items.Where(o => o.ChannelID == item.ChannelID).Count() <= 0) { items.Add(item); }
                }
            }

            return items;
        }




        public List<OperationalPeriod> InferOperationalPeriods()
        {
            List<OperationalPeriod> ops = new List<OperationalPeriod>();
            int highest = highestOpsPeriod;
            int lowest = lowestOpsPeriod;

            for (int x = lowest; x <= highest; x++)
            {

                if (OpPeriodHasContent(x))
                {
                    OperationalPeriod period = new OperationalPeriod();
                    period.PeriodNumber = x;


                    List<DateTime> dates = inferOpStartEnd(x);
                    period.PeriodStart = dates[0];
                    period.PeriodEnd = dates[1];

                    ops.Add(period);

                }
            }

            return ops;
        }





    }

    
}
