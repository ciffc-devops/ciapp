using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary.Utilities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WF_ICS_ClassLibrary.Models
{
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
        [ProtoMember(5)] private string _DataAsXMLString;
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

                        _Data = ObjectFromJSONData(_DataAsJSONString, ObjectType);
                    }
                    catch (Exception) { _Data = null; }
                }
                else if (!string.IsNullOrEmpty(_DataAsXMLString))
                {
                    try
                    {

                        _Data = ObjectFromXMLData(_DataAsXMLString, ObjectType);
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
                    _DataAsJSONString = JsonSerializer.Serialize(value);
                }
            }
        }
        public bool ProcessedLocally { get => _ProcessedLocally; set => _ProcessedLocally = value; }
        public bool UploadedSuccessfully { get => _UploadedSuccessfully; set => _UploadedSuccessfully = value; }
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }
        public string ObjectType { get => _ObjcetType; set => _ObjcetType = value; }
        public string DataEnc { get => _DataEnc; set => _DataEnc = value; }
        public string Source { get => _Source; set => _Source = value; }

        public TaskUpdate Clone()
        {
            return this.MemberwiseClone() as TaskUpdate;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


      


        public object ObjectFromJSONData(string jsonData, string ObjectType)
        {
            object objDecrypted = null;

            if (ObjectType.Equals(new Contact().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Contact>(jsonData);

            }
           else if (ObjectType.Equals(new Briefing().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Briefing>(jsonData);
            }
            else if (ObjectType.Equals(new CommsLogEntry().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<CommsLogEntry>(jsonData);
            }
            else if (ObjectType.Equals(new CommsPlanItem().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<CommsPlanItem>(jsonData);
            }

            else if (ObjectType.Equals(new CommsPlan().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<CommsPlan>(jsonData);
            }
            else if (ObjectType.Equals(new Hospital().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Hospital>(jsonData);
            }
            else if (ObjectType.Equals(new AmbulanceService().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<AmbulanceService>(jsonData);
            }
            else if (ObjectType.Equals(new IncidentObjective().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<IncidentObjective>(jsonData);
            }

            else if (ObjectType.Equals(new MedicalPlan().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<MedicalPlan>(jsonData);
            }
            else if (ObjectType.Equals(new Note().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Note>(jsonData);
            }
            else if (ObjectType.Equals(new OperationalPeriod().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<OperationalPeriod>(jsonData);
            }
            else if (ObjectType.Equals(new OrganizationChart().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<OrganizationChart>(jsonData);
            }
            else if (ObjectType.Equals(new ICSRole().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<ICSRole>(jsonData);
            }
            else if (ObjectType.Equals(new PositionLogEntry().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<PositionLogEntry>(jsonData);
            }
            else if (ObjectType.Equals(new SafetyPlan().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<SafetyPlan>(jsonData);
            }

            else if (ObjectType.Equals(new TaskBasics().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<TaskBasics>(jsonData);
            }
            else if (ObjectType.Equals(new Timeline().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Timeline>(jsonData);
            }
            else if (ObjectType.Equals(new TimelineEvent().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<TimelineEvent>(jsonData);
            }

            else if (ObjectType.Equals(new Vehicle().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<Vehicle>(jsonData);
            }


            else if (ObjectType.Equals(new SignInRecord().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<SignInRecord>(jsonData);
            }
            else if (ObjectType.Equals(new TeamMember().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<TeamMember>(jsonData);
            }
            else if (ObjectType.Equals(new WFIncident().GetType().Name))
            {
                objDecrypted = JsonSerializer.Deserialize<WFIncident>(jsonData);
            }



            return objDecrypted;
        }


        public object ObjectFromXMLData(string xmlData, string ObjectType)
        {
            object objDecrypted = null;

         
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
