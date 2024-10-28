using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class Timeline : SyncableItem, ICloneable
    {
        [ProtoMember(2)] private string _TimelineName;
        [ProtoMember(3)] private string _RelatedToSubject;
        [ProtoMember(4)] private DateTime _DateCreated;
        [ProtoMember(5)] private DateTime _DateUpdated;
        [ProtoMember(6)] private List<TimelineEvent> _AllTimelineEvents;
        public string TimelineName { get => _TimelineName; set => _TimelineName = value; }
        public string RelatedToSubject { get => _RelatedToSubject; set => _RelatedToSubject = value; }
        public DateTime DateCreated { get => _DateCreated; set => _DateCreated = value; }
        public DateTime DateUpdated { get => _DateUpdated; set { _DateUpdated = value; LastUpdatedUTC = value.ToUniversalTime(); } }
        public List<TimelineEvent> AllTimelineEvents { get => _AllTimelineEvents; set => _AllTimelineEvents = value; }

        public Timeline()
        {
            ID = Guid.NewGuid();
            _AllTimelineEvents = new List<TimelineEvent>();
        }

        public new Timeline Clone()
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
