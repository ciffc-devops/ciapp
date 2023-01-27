using NetworkCommsDotNet.Tools;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Networking
{
    [ProtoContract]
    [Serializable]
    public class NetworkSendObject
    {
        public NetworkSendObject()
        {
            TaskID = Guid.Empty;
        }
        public NetworkSendObject(Guid task_id)
        {
            TaskID = task_id;
        }

        [ProtoMember(1)]
        public Guid RequestID { get; set; }

        //for network reasons
        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        [ProtoMember(2)] string _sourceIdentifier;
        [ProtoMember(3)] public int RelayCount { get; set; }
        [ProtoMember(4)] public string SourceName { get; set; }
        [ProtoMember(5)] public string objectType { get; set; }
        [ProtoMember(6)] private Guid _guidValue = Guid.Empty;
        [ProtoMember(7)] public string comment { get; set; }
        [ProtoMember(33)] private Guid _TaskID;
        [ProtoMember(32)] private GeneralOptions _generalOptions;

        /*
        //[ProtoMember(8)] private Assignment _assignment = new Assignment();
        [ProtoMember(9)] private Briefing _briefing = new Briefing(false);
        [ProtoMember(10)] private IncidentObjective _objective = new IncidentObjective();
        [ProtoMember(11)] private SafetyPlan _safetyPlan = new SafetyPlan();
        //[ProtoMember(12)] private SubjectProfile _subjectProfile = new SubjectProfile();
        [ProtoMember(13)] private CommsPlanItem _commsPlanItem = new CommsPlanItem();
        [ProtoMember(14)] private OrganizationChart _organizationChart = new OrganizationChart();
        //[ProtoMember(15)] private UrgencyCalculation _urgencyCalculation = new UrgencyCalculation();
        [ProtoMember(16)] private MedicalPlan _medicalPlan = new MedicalPlan();
        [ProtoMember(17)] private CommsPlan _commsPlan = new CommsPlan();
        //[ProtoMember(18)] private WhiteboardItem _whiteboardItem = new WhiteboardItem();
        [ProtoMember(19)] private SignInRecord _signInRecord = new SignInRecord();
        [ProtoMember(20)] private TeamMember _teamMember = new TeamMember();
        [ProtoMember(21)] private CommsLogEntry _commsLogEntry = new CommsLogEntry();
        //[ProtoMember(22)] private Clue _clue;
        //[ProtoMember(23)] private AssignmentDebrief _assignmentDebrief;
        [ProtoMember(24)] private List<TeamMember> _memberList;
        //[ProtoMember(25)] private MattsonEvaluation _mattsonEvaluation;
        //[ProtoMember(26)] private MapSegment _mapSegment;
        [ProtoMember(27)] private Contact _contact;
        [ProtoMember(28)] private Timeline _timeline;
        [ProtoMember(29)] private Note _note;
        [ProtoMember(30)] private Vehicle _vehicle;
        //[ProtoMember(31)] private ShiftBriefing _shiftBriefing;
        //[ProtoMember(34)] private TaskEquipment _taskEquipment;
        //[ProtoMember(35)] private EquipmentIssue _equipmentIssue;
        [ProtoMember(36)] private PositionLogEntry _positionLogEntry;
        [ProtoMember(37)] private TaskBasics _taskBasics;
        [ProtoMember(38)] private OperationalPeriod _opsPeriod;
        //[ProtoMember(39)] private MattsonScore _mattsonScore;
        [ProtoMember(40)] private TimelineEvent _timelineEvent;
        [ProtoMember(41)] private ICSRole _icsRole;
//        [ProtoMember(42)] private CommsPlanItemLink _commsPlanItemLink;
        */
        [ProtoMember(43)] private TaskUpdate _taskUpdate;
        [ProtoMember(44)] private bool _UploadedToInternet;

        public Guid GuidValue { get { return _guidValue; } set { _guidValue = value; } }
        public bool UploadedToInternet { get => _UploadedToInternet; set => _UploadedToInternet = value; }



        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public GeneralOptions generalOptions { get => _generalOptions; set => _generalOptions = value; }

        /*
        public Briefing briefing { get { return _briefing; } set { _briefing = value; } }
        public IncidentObjective objective { get { return _objective; } set { _objective = value; } }
        public SafetyPlan safetyPlan { get { return _safetyPlan; } set { _safetyPlan = value; } }
        public CommsPlanItem commsPlanItem { get { return _commsPlanItem; } set { _commsPlanItem = value; } }
        public OrganizationChart organizationChart { get { return _organizationChart; } set { _organizationChart = value; } }
        public MedicalPlan medicalPlan { get { return _medicalPlan; } set { _medicalPlan = value; } }
        public CommsPlan commsPlan { get { return _commsPlan; } set { _commsPlan = value; } }
        public SignInRecord signInRecord { get => _signInRecord; set => _signInRecord = value; }
        public TeamMember teamMember { get => _teamMember; set => _teamMember = value; }
        public CommsLogEntry commsLogEntry { get => _commsLogEntry; set => _commsLogEntry = value; }
        public List<TeamMember> memberList { get => _memberList; set => _memberList = value; }
        public Contact contact { get => _contact; set => _contact = value; }
        public Timeline timeline { get => _timeline; set => _timeline = value; }
        public Note note { get => _note; set => _note = value; }
        public Vehicle vehicle { get => _vehicle; set => _vehicle = value; }
        public PositionLogEntry positionLogEntry { get => _positionLogEntry; set => _positionLogEntry = value; }
        public TaskBasics taskBasics { get => _taskBasics; set => _taskBasics = value; }
        public OperationalPeriod operationalPeriod { get => _opsPeriod; set => _opsPeriod = value; }
        public TimelineEvent timelineEvent { get => _timelineEvent; set => _timelineEvent = value; }
        public ICSRole icsRole { get => _icsRole; set => _icsRole = value; }
        //public CommsPlanItemLink commsPlanItemLink { get => _commsPlanItemLink; set => _commsPlanItemLink = value; }
        */
        public TaskUpdate taskUpdate { get => _taskUpdate; set => _taskUpdate = value; }


        /*
        public Assignment assignment { get { return _assignment; } set { _assignment = value; } }
        public MattsonScore mattsonScore { get => _mattsonScore; set => _mattsonScore = value; }
        public TaskEquipment taskEquipment { get => _taskEquipment; set => _taskEquipment = value; }
        public EquipmentIssue equipmentIssue { get => _equipmentIssue; set => _equipmentIssue = value; }
        public ShiftBriefing shiftBriefing { get => _shiftBriefing; set => _shiftBriefing = value; }
        public MattsonEvaluation mattsonEvaluation { get => _mattsonEvaluation; set => _mattsonEvaluation = value; }
        public MapSegment mapSegment { get => _mapSegment; set => _mapSegment = value; }
        public Clue clue { get => _clue; set => _clue = value; }
        public AssignmentDebrief assignmentDebrief { get => _assignmentDebrief; set => _assignmentDebrief = value; }
        public WhiteboardItem whiteboardItem { get { return _whiteboardItem; } set { _whiteboardItem = value; } }
        public UrgencyCalculation urgencyCalculation { get { return _urgencyCalculation; } set { _urgencyCalculation = value; } }
        public SubjectProfile subjectProfile { get { return _subjectProfile; } set { _subjectProfile = value; } }
        */
    }

    [ProtoContract]
    public class NetworkDeleteOrder
    {
        public NetworkDeleteOrder(Guid task_id) { OrderID = Guid.NewGuid(); TaskID = task_id; }
        public NetworkDeleteOrder() { OrderID = Guid.NewGuid(); TaskID = Guid.Empty; }

        [ProtoMember(1)]
        public Guid OrderID { get; set; }

        //for network reasons
        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        [ProtoMember(2)]
        string _sourceIdentifier;
        [ProtoMember(3)]
        public int RelayCount { get; set; }
        [ProtoMember(4)]
        public string SourceName { get; set; }

        [ProtoMember(5)]
        public string objectType { get; set; }

        [ProtoMember(6)]
        private Guid _guidValue = Guid.Empty;

        public Guid GuidValue { get { return _guidValue; } set { _guidValue = value; } }

        [ProtoMember(7)] private Guid _TaskID;
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
    }

    public static class NetworkCheck
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://sarassist.ca"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
