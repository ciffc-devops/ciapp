using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WF_ICS_ClassLibrary.Models
{
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
}
