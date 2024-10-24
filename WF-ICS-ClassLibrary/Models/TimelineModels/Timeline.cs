using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
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
}
