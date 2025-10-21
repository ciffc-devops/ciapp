using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models
{
   
    [ProtoContract]
    [Serializable]
    public class SafetyMessage : ICSFormData, ICloneable
    {
        [ProtoMember(4)] private string _Message;
        [ProtoMember(5)] private bool _SitePlanRequired;
        [ProtoMember(6)] private string _SitePlanLocation;
        [ProtoMember(10)] private Guid _SafetyTemplateID;
        [ProtoMember(11)] private string _SummaryLine;
        [ProtoMember(14)] private string _ImageBytes;

        public SafetyMessage() { }


        public string Message { get => _Message; set => _Message = value; }
        public bool SitePlanRequired { get => _SitePlanRequired; set => _SitePlanRequired = value; }
        public string SitePlanLocation { get => _SitePlanLocation; set => _SitePlanLocation = value; }
        public Guid SafetyTemplateID { get => _SafetyTemplateID; set => _SafetyTemplateID = value; }
        public string SummaryLine { get => _SummaryLine; set => _SummaryLine = value; }
        public string ImageBytes { get => _ImageBytes; set => _ImageBytes = value; }
        public string CopyNextOpText { get; set; } = "Copy to selected op";

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
