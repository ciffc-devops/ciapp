using ProtoBuf;
using System;
using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class BriefingSection : ICloneable
    {
        [ProtoMember(1)]
        public Guid sectionID { get; set; }
        [ProtoMember(2)]
        public string sectionName { get; set; }
        [ProtoMember(3)]
        public int sortOrder { get; set; }
        [ProtoMember(4)]
        private List<BriefingItem> l_allItems = new List<BriefingItem>();
        public List<BriefingItem> allItems { get { return l_allItems; } set { l_allItems = value; } }

        public BriefingSection Clone()
        {
            BriefingSection cloneTo = new BriefingSection();
            cloneTo.sectionID = sectionID;
            cloneTo.sectionName = sectionName;
            cloneTo.sortOrder = sortOrder;
            foreach (BriefingItem item in allItems)
            {
                cloneTo.allItems.Add(item.Clone());
            }


            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
