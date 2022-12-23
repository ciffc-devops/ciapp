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
    public class IncidentObjective : ICloneable
    {
        [ProtoMember(1)] private Guid _ObjectiveID;
        [ProtoMember(2)] private string _Objective;
        [ProtoMember(3)] private int _Priority;
        [ProtoMember(4)] private int _OpPeriod;
        [ProtoMember(5)] private bool _isUniversal;
        [ProtoMember(6)] private DateTime _PresetLastUpdatedUTC;
        [ProtoMember(7)] private List<IncidentObjective> _ChildObjectives = new List<IncidentObjective>();
        [ProtoMember(8)] private bool _active;
        [ProtoMember(9)] private Guid _TaskID;
        [ProtoMember(10)] private Guid _IncidentObjectiveID; //identifies this specific objective within the context of a task
        [ProtoMember(11)] private DateTime _ObjectiveLastUpdated;
        [ProtoMember(12)] private Guid _OrganizationID;
        [ProtoMember(13)] private bool _Completed;



        public Guid ObjectiveID { get => _ObjectiveID; set => _ObjectiveID = value; } //used for present incident objectives
        public string Objective { get => _Objective; set => _Objective = value; }
        public int Priority { get => _Priority; set => _Priority = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public DateTime PresetLastUpdatedUTC { get => _PresetLastUpdatedUTC; set => _PresetLastUpdatedUTC = value; }
        public List<IncidentObjective> ChildObjectives { get => _ChildObjectives; set => _ChildObjectives = value; }
        public bool Active { get { return _active; } set { _active = value; } }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public Guid IncidentObjectiveID { get => _IncidentObjectiveID; set => _IncidentObjectiveID = value; }
        public DateTime ObjectiveLastUpdatedUTC { get => _ObjectiveLastUpdated; set => _ObjectiveLastUpdated = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public bool Completed { get => _Completed; set => _Completed = value; }
        public string CopyNextOpText { get; set; } = "Copy to next op";

        public IncidentObjective() { ObjectiveID = System.Guid.NewGuid(); Active = true; IncidentObjectiveID = Guid.NewGuid(); }
        private IncidentObjective DeepCopy()
        {
            IncidentObjective newObj = new IncidentObjective();
            newObj.ObjectiveID = ObjectiveID;
            newObj.Active = Active;
            newObj.Objective = Objective;
            newObj.Priority = Priority;
            newObj.OpPeriod = OpPeriod;
            newObj.isUniversal = isUniversal;
            newObj.PresetLastUpdatedUTC = PresetLastUpdatedUTC;
            newObj.TaskID = TaskID;
            newObj.IncidentObjectiveID = IncidentObjectiveID;
            newObj.ObjectiveLastUpdatedUTC = ObjectiveLastUpdatedUTC;
            newObj.OrganizationID = OrganizationID;
            newObj.Completed = Completed;

            newObj.CopyNextOpText = CopyNextOpText;

            foreach (IncidentObjective child in ChildObjectives)
            {
                newObj.ChildObjectives.Add(child.DeepCopy());
            }
            return newObj;
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

    public class IncidentObjectives
    {
        private Guid _FormID;
        private DateTime _DatePrepared;
        private int _OpPeriod;
        private string _FireSize;
        private string _FireStatus;
        private string _WeatherForcast;
        private string _GeneralSafety;
        private string _PreparedBy;
        private string _PreparedByRole;
        private string _ApprovedBy;
        private string _ApprovedByRole;
        private List<IncidentObjective> _Objectives;

        public IncidentObjectives() { _FormID = Guid.NewGuid(); _Objectives = new List<IncidentObjective>(); }

        public Guid FormID { get => _FormID; set { _FormID = value; } }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string FireSize { get => _FireSize; set => _FireSize = value; }
        public string FireStatus { get => _FireStatus; set => _FireStatus = value; }
        public string WeatherForcast { get => _WeatherForcast; set => _WeatherForcast = value; }
        public string GeneralSafety { get => _GeneralSafety; set => _GeneralSafety = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public string PreparedByRole { get => _PreparedByRole; set => _PreparedByRole = value; }
        public string ApprovedBy { get => _ApprovedBy; set => _ApprovedBy = value; }
        public string ApprovedByRole { get => _ApprovedByRole; set => _ApprovedByRole = value; }
        public List<IncidentObjective> Objectives { get => _Objectives; set => _Objectives = value; }
    }
}
