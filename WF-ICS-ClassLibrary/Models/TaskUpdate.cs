using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract,
      // ProtoInclude(101, typeof(Assignment)),
      // ProtoInclude(102, typeof(AssignmentDebrief)),
       ProtoInclude(103, typeof(Briefing)),
      // ProtoInclude(104, typeof(Clue)),
       ProtoInclude(105, typeof(CommsLogEntry)),
       ProtoInclude(106, typeof(CommsPlan)),
       ProtoInclude(107, typeof(CommsPlanItem)),
       ProtoInclude(109, typeof(Contact)),
       //ProtoInclude(110, typeof(TaskEquipment)),
       //ProtoInclude(111, typeof(EquipmentIssue)),
       ProtoInclude(112, typeof(IncidentObjective)),
       //ProtoInclude(113, typeof(MattsonEvaluation)),
       //ProtoInclude(114, typeof(MattsonScore)),
       //ProtoInclude(115, typeof(MapSegment)),
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
       //ProtoInclude(126, typeof(ShiftBriefing)),
       //ProtoInclude(127, typeof(SubjectProfile)),
       ProtoInclude(128, typeof(TaskBasics)),
       ProtoInclude(129, typeof(Timeline)),
       ProtoInclude(130, typeof(TimelineEvent)),
       //ProtoInclude(131, typeof(UrgencyCalculation)),
       ProtoInclude(132, typeof(Vehicle)),
       //ProtoInclude(133, typeof(WhiteboardItem))
       ]


  //[XmlInclude(typeof(Assignment))]
    //[XmlInclude(typeof(AssignmentDebrief))]
    [XmlInclude(typeof(Briefing))]
    //[XmlInclude(typeof(Clue))]
    [XmlInclude(typeof(CommsLogEntry))]
    [XmlInclude(typeof(CommsPlan))]
    [XmlInclude(typeof(CommsPlanItem))]
    [XmlInclude(typeof(Contact))]
   // [XmlInclude(typeof(TaskEquipment))]
   // [XmlInclude(typeof(EquipmentIssue))]
    [XmlInclude(typeof(IncidentObjective))]
   // [XmlInclude(typeof(MattsonEvaluation))]
   // [XmlInclude(typeof(MattsonScore))]
   // [XmlInclude(typeof(MapSegment))]
    [XmlInclude(typeof(MedicalPlan))]
    [XmlInclude(typeof(TeamMember))]
    [XmlInclude(typeof(MemberStatus))]
    [XmlInclude(typeof(SignInRecord))]
    [XmlInclude(typeof(Note))]
    [XmlInclude(typeof(OperationalPeriod))]
    [XmlInclude(typeof(OrganizationChart))]
    [XmlInclude(typeof(ICSRole))]
    [XmlInclude(typeof(PositionLogEntry))]
    [XmlInclude(typeof(SafetyPlan))]
  //  [XmlInclude(typeof(ShiftBriefing))]
   // [XmlInclude(typeof(SubjectProfile))]
    [XmlInclude(typeof(TaskBasics))]
    [XmlInclude(typeof(Timeline))]
    [XmlInclude(typeof(TimelineEvent))]
   // [XmlInclude(typeof(UrgencyCalculation))]
    [XmlInclude(typeof(Vehicle))]
  //  [XmlInclude(typeof(WhiteboardItem))]

    public class TaskUpdate : ICloneable
    {
        [ProtoMember(1)] private Guid _UpdateID;
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(3)] private DateTime _LastUpdatedUTC;
        [ProtoMember(4)] private string _CommandName;
        [ProtoIgnore] private object _Data;
        [ProtoMember(6)] private bool _ProcessedLocally;
        [ProtoMember(7)] private bool _UploadedSuccessfully;
        [ProtoMember(8)] private Guid _MachineID;
        [ProtoMember(9)] private string _ObjcetType;
        [ProtoMember(10)] private string _DataEnc;
        [ProtoMember(5)] private string _DataAsXMLString;

        public TaskUpdate() { UpdateID = System.Guid.NewGuid(); }

        public Guid UpdateID { get => _UpdateID; set => _UpdateID = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string CommandName { get => _CommandName; set => _CommandName = value; }
        public object Data
        {
            get
            {
                if (_Data != null) { return _Data; }
                if (!string.IsNullOrEmpty(_DataAsXMLString))
                {
                    try
                    {

                        _Data = ObjectFromXMLData(_DataAsXMLString, ObjectType);
                    }
                    catch (Exception) { _Data = null; }

                }
                return _Data;
            }

            set { _Data = value; if (value != null) { _DataAsXMLString = value.XmlSerializeToString(); } }
        }
        public bool ProcessedLocally { get => _ProcessedLocally; set => _ProcessedLocally = value; }
        public bool UploadedSuccessfully { get => _UploadedSuccessfully; set => _UploadedSuccessfully = value; }
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }
        public string ObjectType { get => _ObjcetType; set => _ObjcetType = value; }
        public string DataEnc { get => _DataEnc; set => _DataEnc = value; }

        public TaskUpdate Clone()
        {
            return this.MemberwiseClone() as TaskUpdate;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public object ObjectFromXMLData(string xmlData, string ObjectType)
        {
            object objDecrypted = null;

            /* if (ObjectType.Equals(new Assignment().GetType().Name))
             {
                 objDecrypted = xmlData.XmlDeserializeFromString<Assignment>();
                 string desc = ((Assignment)objDecrypted).Description;
                 desc = desc.Replace("\r\n", Environment.NewLine);
                 ((Assignment)objDecrypted).Description = desc.Replace("\n", Environment.NewLine);
             }
             else if (ObjectType.Equals(new AssignmentDebrief().GetType().Name))
             {
                 objDecrypted = xmlData.XmlDeserializeFromString<AssignmentDebrief>();
             }
               else if (ObjectType.Equals(new Clue().GetType().Name))
             {
                 objDecrypted = xmlData.XmlDeserializeFromString<Clue>();
             }
              else if (ObjectType.Equals(new TaskEquipment().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<TaskEquipment>();
            }
            else if (ObjectType.Equals(new EquipmentIssue().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<EquipmentIssue>();
            }
             else if (ObjectType.Equals(new MapSegment().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<MapSegment>();
            }
            else if (ObjectType.Equals(new MattsonEvaluation().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<MattsonEvaluation>();
            }
            else if (ObjectType.Equals(new MattsonScore().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<MattsonScore>();
            }
            else if (ObjectType.Equals(new ShiftBriefing().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<ShiftBriefing>();
            }
            else if (ObjectType.Equals(new SubjectProfile().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<SubjectProfile>();
            }
                  else if (ObjectType.Equals(new WhiteboardItem().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<WhiteboardItem>();
            }
            else if (ObjectType.Equals(new UrgencyCalculation().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<UrgencyCalculation>();
            }
            */
            if (ObjectType.Equals(new Briefing().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Briefing>();
            }
            else if (ObjectType.Equals(new CommsLogEntry().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<CommsLogEntry>();
            }
            else if (ObjectType.Equals(new CommsPlanItem().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<CommsPlanItem>();
            }
           
            else if (ObjectType.Equals(new CommsPlan().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<CommsPlan>();
            }
         
            else if (ObjectType.Equals(new Contact().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Contact>();
            }
          
            else if (ObjectType.Equals(new Hospital().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Hospital>();
            }
            else if (ObjectType.Equals(new AmbulanceService().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<AmbulanceService>();
            }
            else if (ObjectType.Equals(new IncidentObjective().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<IncidentObjective>();
            }
           
            else if (ObjectType.Equals(new MedicalPlan().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<MedicalPlan>();
            }
            else if (ObjectType.Equals(new Note().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Note>();
            }
            else if (ObjectType.Equals(new OperationalPeriod().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<OperationalPeriod>();
            }
            else if (ObjectType.Equals(new OrganizationChart().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<OrganizationChart>();
            }
            else if (ObjectType.Equals(new ICSRole().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<ICSRole>();
            }
            else if (ObjectType.Equals(new PositionLogEntry().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<PositionLogEntry>();
            }
            else if (ObjectType.Equals(new SafetyPlan().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<SafetyPlan>();
            }
            
            else if (ObjectType.Equals(new TaskBasics().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<TaskBasics>();
            }
            else if (ObjectType.Equals(new Timeline().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Timeline>();
            }
            else if (ObjectType.Equals(new TimelineEvent().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<TimelineEvent>();
            }
            
            else if (ObjectType.Equals(new Vehicle().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<Vehicle>();
            }
      

            else if (ObjectType.Equals(new SignInRecord().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<SignInRecord>();
            }
            else if (ObjectType.Equals(new TeamMember().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<TeamMember>();
            }
            else if (ObjectType.Equals(new WFIncident().GetType().Name))
            {
                objDecrypted = xmlData.XmlDeserializeFromString<WFIncident>();
            }
            return objDecrypted;
        }
    }
}
