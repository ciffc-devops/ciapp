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
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;


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
    [XmlInclude(typeof(Incident))]
    [XmlInclude(typeof(OperationalGroup))]
    [XmlInclude(typeof(Crew))]
    [XmlInclude(typeof(ResourceReplacementPlan))]
    [XmlInclude(typeof(IncidentStatusSummary))]
    [Serializable]
    [ProtoContract]

    public class TaskUpdate : ICloneable
    {
        [ProtoMember(1)] private Guid _UpdateID;
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(3)] private DateTime _LastUpdatedUTC;
        [ProtoMember(4)] private string _CommandName;
        [ProtoIgnore] private SyncableItem _Data;
        [ProtoMember(6)] private bool _ProcessedLocally;
        [ProtoMember(7)] private bool _UploadedSuccessfully;
        [ProtoMember(8)] private Guid _MachineID;
        [ProtoMember(9)] private string _ObjectType;
        [ProtoMember(10)] private string _DataEnc;
        [ProtoMember(11)] private string _DataAsJSONString;
        [ProtoMember(12)] private string _Source;
        [ProtoMember(13)] private Guid _ItemID;
        [ProtoMember(14)] private string _CreatedByRoleName;
        [ProtoMember(15)] private int _SoftwareVersionMajor;
        [ProtoMember(16)] private int _SoftwareVersionMinor;
        [ProtoMember(17)] private int _SoftwareVersionBuild;

        public TaskUpdate() { UpdateID = System.Guid.NewGuid(); }

        public Guid UpdateID { get => _UpdateID; set => _UpdateID = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public DateTime LastUpdateLocal { get => LastUpdatedUTC.ToLocalTime(); }

        public string CommandName { get => _CommandName; set => _CommandName = value; }
        public SyncableItem Data
        {
            get
            {
                if (_Data != null) { return _Data; }
                if (!string.IsNullOrEmpty(_DataAsJSONString))
                {
                    try
                    {
                        _DataAsJSONString = CompressionUtilities.Decompress(_DataAsJSONString);

                        _Data = _DataAsJSONString.ObjectFromJSONData(ObjectType);
                    }
                    catch (Exception) { _Data = null; }

                }
                return _Data;
            }

            set { _Data = value; }
        }
        public string DataAsJSON
        {
            get
            {
                //if (string.IsNullOrEmpty(_DataAsJSONString) && Data != null) { SerializeDataAsJSON(); }
                return _DataAsJSONString;
            }
            set { _DataAsJSONString = value; }
        }
        public bool ProcessedLocally { get => _ProcessedLocally; set => _ProcessedLocally = value; }
        public bool UploadedSuccessfully { get => _UploadedSuccessfully; set => _UploadedSuccessfully = value; }
        public Guid MachineID { get => _MachineID; set => _MachineID = value; }
        public string ObjectType { get => _ObjectType; set => _ObjectType = value; }
        public string DataEnc { get => _DataEnc; set => _DataEnc = value; }
        public string Source { get => _Source; set => _Source = value; }
        public string CreatedByRoleName { get => _CreatedByRoleName; set => _CreatedByRoleName = value; }

        public void SetEncData(string key)
        {
            if (string.IsNullOrEmpty(_DataAsJSONString) && Data != null)
            {
                _DataAsJSONString = Data.SerializeDataAsJSON();
            }
            DataEnc = StringCipher.Encrypt(_DataAsJSONString, key);
        }
        public Guid ItemID
        {
            get
            {
                try
                {
                    if (Data != null) { ItemID = ((SyncableItem)Data).ID; }

                }
                catch { ItemID = Guid.Empty; }
                return _ItemID;
            }
            set { _ItemID = value; }
        }

        public int SoftwareVersionMajor { get => _SoftwareVersionMajor; set => _SoftwareVersionMajor = value; }
        public int SoftwareVersionMinor { get => _SoftwareVersionMinor; set => _SoftwareVersionMinor = value; }
        public int SoftwareVersionBuild { get => _SoftwareVersionBuild; set => _SoftwareVersionBuild = value; }
        public string SoftwareVersionText { get => SoftwareVersionMajor.ToString() + "." + SoftwareVersionMinor.ToString() + "." + SoftwareVersionBuild.ToString(); }

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
