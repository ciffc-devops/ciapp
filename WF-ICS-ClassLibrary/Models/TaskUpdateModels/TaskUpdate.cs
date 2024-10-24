using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary.Utilities;
using Newtonsoft.Json;


namespace WF_ICS_ClassLibrary.Models
{

    //[XmlInclude(typeof(TeamAssignment))]
    [XmlInclude(typeof(Briefing))]
    [XmlInclude(typeof(CommsLogEntry))]
    [XmlInclude(typeof(CommsPlan))]
    [XmlInclude(typeof(CommsPlanItem))]
    [XmlInclude(typeof(Contact))]
    [XmlInclude(typeof(IncidentGear))]
    [XmlInclude(typeof(GearIssue))]
    [XmlInclude(typeof(IncidentObjective))]
    [XmlInclude(typeof(MedicalPlan))]
    [XmlInclude(typeof(Personnel))]
    [XmlInclude(typeof(MemberStatus))]
    [XmlInclude(typeof(CheckInRecord))]
    [XmlInclude(typeof(Note))]
    [XmlInclude(typeof(OperationalPeriod))]
    [XmlInclude(typeof(OrganizationChart))]
    [XmlInclude(typeof(ICSRole))]
    [XmlInclude(typeof(PositionLogEntry))]
    [XmlInclude(typeof(TaskBasics))]
    [XmlInclude(typeof(Timeline))]
    [XmlInclude(typeof(TimelineEvent))]
    [XmlInclude(typeof(Vehicle))]
    [XmlInclude(typeof(Aircraft))]
    [XmlInclude(typeof(AirOperationsSummary))]
    [XmlInclude(typeof(NOTAM))]
    [XmlInclude(typeof(GeneralMessage))]
    [XmlInclude(typeof(AmbulanceService))]
    [XmlInclude(typeof(Hospital))]
    [XmlInclude(typeof(MedicalPlan))]
    [XmlInclude(typeof(MedicalAidStation))]
    [XmlInclude(typeof(SafetyMessage))]
    [XmlInclude(typeof(WFIncident))]
    [XmlInclude(typeof(OperationalGroup))]
    [XmlInclude(typeof(Crew))]
    [XmlInclude(typeof(ResourceReplacementPlan))]

    [Serializable]
    [ProtoContract]

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
        [ProtoMember(9)] private string _ObjectType;
        [ProtoMember(10)] private string _DataEnc;
        [ProtoMember(11)] private string _DataAsJSONString;
        [ProtoMember(12)] private string _Source;
        [ProtoMember(13)] private Guid _ItemID;

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
                if (!string.IsNullOrEmpty(_DataAsJSONString))
                {
                    try
                    {
                        _Data = CompressionUtilities.Decompress(_DataAsJSONString);
                        _Data = _DataAsJSONString.ObjectFromJSONData(ObjectType);
                    }
                    catch (Exception) { _Data = null; }
                }
               
                return _Data;
            }

            set
            {
                _Data = value; if (value != null)
                {
                    //_DataAsXMLString = value.XmlSerializeToString();
                    _DataAsJSONString = JsonConvert.SerializeObject(value);
                    int len = _DataAsJSONString.Length;
                    _DataAsJSONString = CompressionUtilities.Compress(_DataAsJSONString);
                    int len2 = _DataAsJSONString.Length;
                }
            }
        }
        public bool ProcessedLocally { get => _ProcessedLocally; set => _ProcessedLocally = value; }
        public bool UploadedSuccessfully { get => _UploadedSuccessfully; set => _UploadedSuccessfully = value; }
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }
        public string ObjectType { get => _ObjectType; set => _ObjectType = value; }
        public string DataEnc { get => _DataEnc; set => _DataEnc = value; }
        public string Source { get => _Source; set => _Source = value; }
        public void SetEncData(string key)
        {
            DataEnc = StringCipher.Encrypt(_DataAsJSONString, key);
        }
        public Guid ItemID
        {
            get
            {
                if (_ItemID == Guid.Empty) { _ItemID = this.GetItemID(); }
                return _ItemID;
            }
            set { _ItemID = value; }
        }

        public TaskUpdate Clone()
        {
            return this.MemberwiseClone() as TaskUpdate;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }





        


        
    }
}
