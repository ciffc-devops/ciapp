using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GearSetMembership : ICloneable
    {
        [ProtoMember(1)] private Guid _SetID;
        [ProtoMember(2)] private Guid _EquipmentID;
        public Guid SetID { get => _SetID; set => _SetID = value; }
        public Guid EquipmentID { get => _EquipmentID; set => _EquipmentID = value; }

        public GearSetMembership() { }
        public GearSetMembership(Guid setid, Guid equip_id)
        {
            SetID = setid; EquipmentID = equip_id;
        }

        public GearSetMembership Clone()
        {
            return this.MemberwiseClone() as GearSetMembership;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
