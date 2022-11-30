using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract]
    public class Timeline : ICloneable
    {
        [ProtoMember(1)] private Guid _TimelineID;
        [ProtoMember(2)] private string _TimelineName;
        [ProtoMember(3)] private string _RelatedToSubject;
        [ProtoMember(4)] private DateTime _DateCreated;
        [ProtoMember(5)] private DateTime _DateUpdated;
        [ProtoMember(6)] private List<TimelineEvent> _AllTimelineEvents;
        [ProtoMember(7)] private DateTime _LastUpdatedUTC;
        public Guid TimeLineID { get => _TimelineID; set => _TimelineID = value; }
        public string TimelineName { get => _TimelineName; set => _TimelineName = value; }
        public string RelatedToSubject { get => _RelatedToSubject; set => _RelatedToSubject = value; }
        public DateTime DateCreated { get => _DateCreated; set => _DateCreated = value; }
        public DateTime DateUpdated { get => _DateUpdated; set { _DateUpdated = value; _LastUpdatedUTC = value.ToUniversalTime(); } }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set { _LastUpdatedUTC = value; } }
        public List<TimelineEvent> AllTimelineEvents { get => _AllTimelineEvents; set => _AllTimelineEvents = value; }

        public Timeline()
        {
            TimeLineID = Guid.NewGuid();
            _AllTimelineEvents = new List<TimelineEvent>();
        }

        public Timeline Clone()
        {
            Timeline cloneTo = this.MemberwiseClone() as Timeline;
            cloneTo.AllTimelineEvents = new List<TimelineEvent>();
            foreach (TimelineEvent te in this.AllTimelineEvents)
            {
                cloneTo.AllTimelineEvents.Add(te.Clone());
            }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }

    [ProtoContract]
    public class TimelineEvent : ICloneable
    {
        [ProtoMember(1)] private Guid _TimelineEventID;
        [ProtoMember(2)] private Guid _TimelineID;
        [ProtoMember(3)] private string _EventName;
        [ProtoMember(4)] private string _EventText;
        [ProtoMember(5)] private DateTime _EventDateTime;
        [ProtoMember(6)] private bool _TimeUnsure;
        [ProtoMember(7)] private bool _DateUnsure;
        [ProtoMember(8)] private bool _SubjectEvent;
        [ProtoMember(9)] private bool _SAREvent;
        [ProtoMember(10)] private Guid _ExternalID; //if this timeline event references an external item like a comms log entry, operational period, etc. this will let it find its way back
        [ProtoMember(11)] private string _EventType;
        [ProtoMember(12)] private bool _Active;
        [ProtoMember(13)] private DateTime _LastUpdatedUTC;
        [ProtoMember(14)] private bool _IsAuto;
        /*
         * Event Type Options (so far)
         * CommsEntry
         * OpPeriodStart
         * OpPeriodEnd
         * GeneralSAR
         * GeneralSubject
         */


        public Guid TimelineEventID { get => _TimelineEventID; set => _TimelineEventID = value; }
        public Guid TimelineID { get => _TimelineID; set => _TimelineID = value; }
        public string EventName { get => _EventName; set => _EventName = value; }
        public string EventText { get => _EventText; set => _EventText = value; }
        public DateTime EventDateTime { get => _EventDateTime; set => _EventDateTime = value; }
        public bool TimeUnsure { get => _TimeUnsure; set => _TimeUnsure = value; }
        public bool DateUnsure { get => _DateUnsure; set => _DateUnsure = value; }
        public bool SubjectEvent { get => _SubjectEvent; set => _SubjectEvent = value; }
        public bool SAREvent { get => _SAREvent; set => _SAREvent = value; }

        public string EventType { get => _EventType; set => _EventType = value; }
        public string FriendlyEventType
        {
            get
            {
                switch (EventType)
                {
                    case "CommsEntry":
                        return "Comms Entry";
                    case "OpPeriodStart":
                        return "Start of Op Period";
                    case "OpPeriodEnd":
                        return "End of Op Period";
                    case "GeneralSAR":
                        return "SAR";
                    case "GeneralSubject":
                        return "Subject";
                    case "TeamStatus":
                        return "Team Status";
                    default:
                        return null;
                }
            }
        }

        public Guid ExternalID { get => _ExternalID; set => _ExternalID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set { _LastUpdatedUTC = value; } }
        public bool IsAuto { get => _IsAuto; set => _IsAuto = value; }

        /* constructors to automate a lot of the work */
        public TimelineEvent() { TimelineEventID = Guid.NewGuid(); _LastUpdatedUTC = DateTime.UtcNow; }
        public TimelineEvent(OperationalPeriod ops, bool start, bool end)
        {
            TimelineEventID = Guid.NewGuid();
            ExternalID = ops.OperationalPeriodID;
            _LastUpdatedUTC = DateTime.UtcNow;
            TimeUnsure = false;
            DateUnsure = false;
            SAREvent = true;
            SubjectEvent = false;
            if (start)
            {
                EventName = "Start of Op" + ops.PeriodNumber;
                EventText = "Start of Operational Period #" + ops.PeriodNumber;
                EventDateTime = ops.PeriodStart;
                EventType = "OpPeriodStart";
            }
            if (end)
            {
                EventName = "End of Op" + ops.PeriodNumber;
                EventText = "End of Operational Period #" + ops.PeriodNumber;
                EventDateTime = ops.PeriodEnd;
                EventType = "OpPeriodEnd";
            }
        }

        public TimelineEvent(CommsLogEntry entry)
        {
            TimelineEventID = Guid.NewGuid();
            ExternalID = entry.EntryID;
            TimeUnsure = false;
            DateUnsure = false;
            SAREvent = true;
            SubjectEvent = false;
            _LastUpdatedUTC = DateTime.UtcNow;
            EventName = "Critical Comms from " + entry.FromName + " to " + entry.ToName;
            StringBuilder sb = new StringBuilder();
            sb.Append(entry.Message);
            EventText = sb.ToString();

            EventDateTime = entry.LogDate;
            EventType = "CommsEntry";
        }

        public TimelineEvent Clone()
        {
            return this.MemberwiseClone() as TimelineEvent;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
