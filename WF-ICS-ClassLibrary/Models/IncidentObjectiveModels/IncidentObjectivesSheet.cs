using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WF_ICS_ClassLibrary.Models.GeneralModels;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class IncidentObjectivesSheet : ICSFormData, ICloneable
    {
        //Used for wildfire version
        [ProtoMember(4)] private string _FireSize;
        [ProtoMember(5)] private string _FireStatus;
        [ProtoMember(6)] private string _WeatherForecast;
        [ProtoMember(7)] private string _GeneralSafety;

        //Used for all hazards version
        [ProtoMember(8)] private string _CommandEmphasis;
        [ProtoMember(9)] private string _SituationalAwareness;
        [ProtoMember(10)] private bool _SiteSafetyPlanRequired;
        [ProtoMember(11)] private string _SafetyPlanLocation;


        [ProtoMember(12)] private List<IncidentObjective> _Objectives;

        public IncidentObjectivesSheet() {  _Objectives = new List<IncidentObjective>(); }

        public Guid SheetID { get => ID; set { ID = value; } }
        public string FireSize { get => _FireSize; set => _FireSize = value; }
        public string FireStatus { get => _FireStatus; set => _FireStatus = value; }
        public string WeatherForecast { get => _WeatherForecast; set => _WeatherForecast = value; }
        public string GeneralSafety { get => _GeneralSafety; set => _GeneralSafety = value; }
        public string CommandEmphasis { get => _CommandEmphasis; set => _CommandEmphasis = value; }
        public string SituationalAwareness { get => _SituationalAwareness; set => _SituationalAwareness = value; }
        public bool SiteSafetyPlanRequired { get => _SiteSafetyPlanRequired; set => _SiteSafetyPlanRequired = value; }
        public string SafetyPlanLocation { get => _SafetyPlanLocation; set => _SafetyPlanLocation = value; }


        public List<IncidentObjective> Objectives { get => _Objectives; set => _Objectives = value; }
        public List<IncidentObjective> ActiveObjectives { get => _Objectives.Where(o=>o.Active).ToList(); }

        public string ActiveObjectivesAsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetObjectivesAsString(Guid.Empty, 0));


                return sb.ToString();
            }
        }
        private StringBuilder GetObjectivesAsString(Guid ParentId, int depth)
        {
            StringBuilder sb = new StringBuilder();
            foreach (IncidentObjective obj in ActiveObjectives.Where(o => o.ParentObjectiveID == ParentId).OrderBy(o => o.Priority))
            {
                for(int x = 0; x < depth; x++) { sb.Append("      "); }

                switch (depth) {                     case 0:
                        sb.Append(obj.Priority);
                        break;
                    case 1:
                        sb.Append((char)(96 + obj.Priority));
                        break;
                    case 2:
                        sb.Append(obj.Priority.ToRoman());
                        break;
                    default:
                        sb.Append(obj.Priority);
                        break;
                }
                sb.Append(") "); 
                
                    sb.Append(obj.Objective);
                sb.Append(Environment.NewLine);
                sb.Append(GetObjectivesAsString(obj.ID, depth + 1));
            }
            return sb;
        }

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
