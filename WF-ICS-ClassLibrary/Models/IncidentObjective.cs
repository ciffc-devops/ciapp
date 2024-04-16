using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

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
        public string CopyNextOpText { get; set; } = "Copy to selected op";

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

    [ProtoContract]
    [Serializable]
    public class IncidentObjectivesSheet : ICloneable
    {
        [ProtoMember(1)] private Guid _SheetID;
        [ProtoMember(2)] private DateTime _DatePrepared;
        [ProtoMember(3)] private int _OpPeriod;
        [ProtoMember(4)] private string _FireSize;
        [ProtoMember(5)] private string _FireStatus;
        [ProtoMember(6)] private string _WeatherForcast;
        [ProtoMember(7)] private string _GeneralSafety;
        [ProtoMember(8)] private string _PreparedBy;
        [ProtoMember(9)] private string _PreparedByRole;
        
        [ProtoMember(10)] private string _ApprovedBy;
        [ProtoMember(11)] private string _ApprovedByRole;

        [ProtoMember(12)] private List<IncidentObjective> _Objectives;
        [ProtoMember(13)] private Guid _TaskID;
        [ProtoMember(14)] private DateTime _LastUpdatedUTC;
        [ProtoMember(15)] private Guid _PreparedByRoleID;
        [ProtoMember(16)] private Guid _ApprovedByRoleID;

        public IncidentObjectivesSheet() { _SheetID = Guid.NewGuid(); _Objectives = new List<IncidentObjective>(); }

        public Guid SheetID { get => _SheetID; set { _SheetID = value; } }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string FireSize { get => _FireSize; set => _FireSize = value; }
        public string FireStatus { get => _FireStatus; set => _FireStatus = value; }
        public string WeatherForcast { get => _WeatherForcast; set => _WeatherForcast = value; }
        public string GeneralSafety { get => _GeneralSafety; set => _GeneralSafety = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public string PreparedByRole { get => _PreparedByRole; set => _PreparedByRole = value; }
        public Guid PreparedByRoleID { get => _PreparedByRoleID; set { _PreparedByRoleID = value; } }

        public string ApprovedBy { get => _ApprovedBy; set => _ApprovedBy = value; }
        public string ApprovedByRole { get => _ApprovedByRole; set => _ApprovedByRole = value; }
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set { _ApprovedByRoleID = value; } }

        public List<IncidentObjective> Objectives { get => _Objectives; set => _Objectives = value; }
        public List<IncidentObjective> ActiveObjectives { get => _Objectives.Where(o=>o.Active).ToList(); }

        public string ActiveObjectivesAsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                
                foreach (IncidentObjective obj in ActiveObjectives.OrderBy(o=>o.Priority))
                {
                    sb.Append(obj.Priority); sb.Append(") ");
                    sb.Append(obj.Objective);
                    sb.Append(Environment.NewLine);
                }

                return sb.ToString();
            }
        }

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public IncidentObjectivesSheet Clone()
        {
            IncidentObjectivesSheet newSheet = this.MemberwiseClone() as IncidentObjectivesSheet;
            newSheet.Objectives = new List<IncidentObjective>();
            newSheet.LastUpdatedUTC = DateTime.UtcNow;
            foreach (IncidentObjective objective in Objectives) { newSheet.Objectives.Add(objective.Clone()); }
            return newSheet;
        }
    }

    public static class IncidentObjectiveTools
    {
        public static void RenumberObjectives(this IncidentObjectivesSheet sheet)
        {
            int priority = 1;
            

            foreach (IncidentObjective objective in sheet.ActiveObjectives.OrderBy(o => o.Priority))
            {
                objective.Priority = priority;
                priority += 1;
            }

        }

        public static int GetNextPriorityNumber(this IncidentObjectivesSheet sheet)
        {
            if (sheet.ActiveObjectives.Any())
            {
                return sheet.ActiveObjectives.Max(o => o.Priority) + 1;
            } else { return 1; }
        }
    }
}
