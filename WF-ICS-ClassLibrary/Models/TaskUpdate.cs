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

    [XmlInclude(typeof(TeamAssignment))]
    [XmlInclude(typeof(Briefing))]
    [XmlInclude(typeof(CommsLogEntry))]
    [XmlInclude(typeof(CommsPlan))]
    [XmlInclude(typeof(CommsPlanItem))]
    [XmlInclude(typeof(Contact))]
    [XmlInclude(typeof(TaskEquipment))]
    [XmlInclude(typeof(EquipmentIssue))]
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
    [XmlInclude(typeof(OperationalSubGroup))]

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
        [ProtoMember(9)] private string _ObjcetType;
        [ProtoMember(10)] private string _DataEnc;
        [ProtoMember(11)] private string _DataAsJSONString;
        [ProtoMember(12)] private string _Source;

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
        public string ObjectType { get => _ObjcetType; set => _ObjcetType = value; }
        public string DataEnc { get => _DataEnc; set => _DataEnc = value; }
        public string Source { get => _Source; set => _Source = value; }
        public void SetEncData(string key)
        {
            DataEnc = StringCipher.Encrypt(_DataAsJSONString, key);
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

    public static class TaskUpdateTools
    {

        public static object DecryptTaskUpdateData(this TaskUpdate update, string encryptKey)
        {
            object objDecrypted = null;

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


        public static object ObjectFromJSONData(this string jsonData, string ObjectType)
        {
            object objDecrypted = null;

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
            else if (ObjectType.Equals(new WFIncident().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<WFIncident>(jsonData);
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

            else if (ObjectType.Equals(new TeamAssignment().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<TeamAssignment>(jsonData);
            }

            else if (ObjectType.Equals(new OperationalGroup().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<OperationalGroup>(jsonData);
            }

            else if (ObjectType.Equals(new OperationalSubGroup().GetType().Name))
            {
                objDecrypted = JsonConvert.DeserializeObject<OperationalSubGroup>(jsonData);
            }



            return objDecrypted;
        }
    }
}
