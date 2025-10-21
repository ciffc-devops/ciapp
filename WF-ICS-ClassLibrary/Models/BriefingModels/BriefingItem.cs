using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class BriefingItem : ICloneable
    {
        public BriefingItem() { }
        public BriefingItem(string name, string sub_section, Guid id, int sort) { itemName = name; subSectionName = sub_section; BriefingFieldID = id; FieldSort = sort; }
        [ProtoMember(1)] public string itemName { get; set; }
        [ProtoMember(2)] public string itemValue { get; set; }
        [ProtoMember(3)] public string subSectionName { get; set; }
        [ProtoMember(4)] private Guid _BriefingValueID;

        [ProtoMember(5)] private Guid _BriefingFieldID;

        [ProtoMember(6)] private Guid _BriefingSectionID;

        [ProtoMember(7)] private int _FieldSort;

        [ProtoMember(8)] private Guid _BriefingID;


        public Guid BriefingValueID { get => _BriefingValueID; set => _BriefingValueID = value; }
        public Guid BriefingFieldID { get => _BriefingFieldID; set => _BriefingFieldID = value; }
        public Guid BriefingSectionID { get => _BriefingSectionID; set => _BriefingSectionID = value; }
        public int FieldSort { get => _FieldSort; set => _FieldSort = value; }
        public Guid BriefingID { get => _BriefingID; set => _BriefingID = value; }

        public BriefingItem Clone()
        {
            return this.MemberwiseClone() as BriefingItem;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
