using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract]
    [Serializable]
    public class TaskBasics
    {
        [ProtoMember(1)] private Guid _TaskID;
        [ProtoMember(2)] private string _TaskName;
        [ProtoMember(3)] private string _TaskNumber;
        [ProtoMember(4)] private string _AgencyFileNumber;
        [ProtoMember(6)] private string _ICPCallsign;
        [ProtoMember(7)] private string _SubjectCategory;
        [ProtoMember(9)] private double _subjectVisibility;
        [ProtoMember(10)] private double _generalRangeOfDetection;
        [ProtoMember(11)] private DateTime _LastUpdatedUTC;

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public string TaskName { get => _TaskName; set { if (!string.IsNullOrEmpty(value)) { _TaskName = value.Trim(); } else { _TaskName = null; } } }
        public string TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public string AgencyFileNumber { get => _AgencyFileNumber; set => _AgencyFileNumber = value; }
        public string ICPCallSign { get => _ICPCallsign; set => _ICPCallsign = value; }

        public string SubjectCategory { get => _SubjectCategory; set => _SubjectCategory = value; }
        public double SubjectVisibility { get => _subjectVisibility; set => _subjectVisibility = value; } //used for calculating POD / Spacing
        public double GeneralRangeOfDetection { get => _generalRangeOfDetection; set => _generalRangeOfDetection = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

        public TaskBasics() { LastUpdatedUTC = DateTime.UtcNow; }
        public TaskBasics(WFIncident task)
        {
            TaskID = task.TaskID;
            TaskName = task.TaskName;
            TaskNumber = task.TaskNumber;
            AgencyFileNumber = task.AgencyFileNumber;
            ICPCallSign = task.ICPCallSign;
            SubjectCategory = task.SubjectCategory;
            SubjectVisibility = task.SubjectVisibility;
            GeneralRangeOfDetection = task.GeneralRangeOfDetection;
            LastUpdatedUTC = DateTime.UtcNow;

        }
    }
