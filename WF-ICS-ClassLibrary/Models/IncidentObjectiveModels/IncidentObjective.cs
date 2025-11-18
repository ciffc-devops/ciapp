using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class IncidentObjective : SyncableItem, ICloneable
    {
        [ProtoMember(1)] private Guid _ObjectiveID;
        [ProtoMember(2)] private string _Objective;
        [ProtoMember(3)] private int _Priority;
        [ProtoMember(5)] private bool _isUniversal;
        [ProtoMember(6)] private DateTime _PresetLastUpdatedUTC;
        [ProtoMember(12)] private Guid _OrganizationID;
        [ProtoMember(13)] private bool _Completed;
        [ProtoMember(14)] private Guid _ParentObjectiveID;
        [ProtoMember(15)] private List<string> _TemplateStrategies;
        [ProtoMember(16)] private Guid _SheetId;


        public Guid ObjectiveID { get => _ObjectiveID; set => _ObjectiveID = value; } //used for present incident objectives
        public string Objective { get => _Objective; set => _Objective = value; }
        [XmlIgnore]
        public string ObjectiveWithPriority { get => Priority + ") " + Objective; }

        public int Priority { get => _Priority; set => _Priority = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public DateTime PresetLastUpdatedUTC { get => _PresetLastUpdatedUTC; set => _PresetLastUpdatedUTC = value; }
        public Guid IncidentObjectiveID { get => ID; set => ID = value; }
        public DateTime ObjectiveLastUpdatedUTC { get => LastUpdatedUTC; set => LastUpdatedUTC = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public bool Completed { get => _Completed; set => _Completed = value; }
        public string CopyNextOpText { get; set; } = "Copy to selected op";
        public Guid ParentObjectiveID { get => _ParentObjectiveID; set => _ParentObjectiveID = value; }
        public List<string> TemplateStrategies
        {
            get { if (_TemplateStrategies == null) { _TemplateStrategies = new List<string>(); } return _TemplateStrategies; }
            set => _TemplateStrategies = value;
        }
        public int TemplateStrategyCount { get => TemplateStrategies.Count; }
        public Guid SheetId { get => _SheetId; set => _SheetId = value; }

        public IncidentObjective() { ObjectiveID = System.Guid.NewGuid(); Active = true; IncidentObjectiveID = Guid.NewGuid(); TemplateStrategies = new List<string>(); }
        private IncidentObjective DeepCopy()
        {
            IncidentObjective newItem = this.MemberwiseClone() as IncidentObjective;
            return newItem;

        }

        public IncidentObjective Clone()
        {
            return this.DeepCopy() as IncidentObjective;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }
}
