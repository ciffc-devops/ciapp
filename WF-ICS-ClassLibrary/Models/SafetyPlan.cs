using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
   
    [ProtoContract]
    [Serializable]
    public class SafetyMessage : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(3)] private int _OpPeriod;
        [ProtoMember(4)] private string _Message;
        [ProtoMember(5)] private bool _SitePlanRequired;
        [ProtoMember(6)] private string _SitePlanLocation;
        [ProtoMember(7)] private string _ApprovedByName;
        [ProtoMember(8)] private string _ApprovedByRoleName;
        [ProtoMember(9)] private Guid _ApprovedByRoleID;
        [ProtoMember(10)] private Guid _SafetyTemplateID;
        [ProtoMember(11)] private string _SummaryLine;
        [ProtoMember(12)] private DateTime _LastUpdatedUTC;
        [ProtoMember(13)] private bool _Active;
        [ProtoMember(14)] private string _ImageBytes;

        public SafetyMessage() { ID = Guid.NewGuid(); Active = true; }


        public Guid ID { get => _ID; set => _ID = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string Message { get => _Message; set => _Message = value; }
        public bool SitePlanRequired { get => _SitePlanRequired; set => _SitePlanRequired = value; }
        public string SitePlanLocation { get => _SitePlanLocation; set => _SitePlanLocation = value; }
        public string ApprovedByName { get => _ApprovedByName; set => _ApprovedByName = value; }
        public string ApprovedByRoleName { get => _ApprovedByRoleName; set => _ApprovedByRoleName = value; }
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }
        public Guid SafetyTemplateID { get => _SafetyTemplateID; set => _SafetyTemplateID = value; }
        public string SummaryLine { get => _SummaryLine; set => _SummaryLine = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public string ImageBytes { get => _ImageBytes; set => _ImageBytes = value; }

        public SafetyMessage Clone()
        {
            return this.MemberwiseClone() as SafetyMessage;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
