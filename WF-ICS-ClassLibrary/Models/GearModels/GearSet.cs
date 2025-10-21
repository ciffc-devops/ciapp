using ProtoBuf;
using System;
using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GearSet : ICloneable
    {
        /****************************
         * Equipment sets are used to group and easily add equipment items to a task
         * Suggested uses include sets for each vehicle, trailer, or storage container
         ***************************/

        [ProtoMember(1)] private Guid _SetID;
        [ProtoMember(2)] private string _SetName;
        [ProtoMember(3)] private List<GearSetMembership> _AllItems;
        [ProtoMember(4)] private bool _AutoAdd;

        public Guid SetID { get => _SetID; set => _SetID = value; }
        public string SetName { get => _SetName; set => _SetName = value; }
        public List<GearSetMembership> AllItems { get => _AllItems; set => _AllItems = value; }
        public int ItemCount { get => AllItems.Count; }
        public bool AutoAdd { get => _AutoAdd; set => _AutoAdd = value; }
        public GearSet() { SetID = Guid.NewGuid(); AllItems = new List<GearSetMembership>(); }
        public GearSet(Guid id, string name) { SetID = id; SetName = name; AllItems = new List<GearSetMembership>(); }

        public GearSet Clone()
        {
            GearSet cloneTo = this.MemberwiseClone() as GearSet;
            cloneTo.AllItems = new List<GearSetMembership>();
            foreach (GearSetMembership mem in this.AllItems) { cloneTo.AllItems.Add(mem.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }


}
