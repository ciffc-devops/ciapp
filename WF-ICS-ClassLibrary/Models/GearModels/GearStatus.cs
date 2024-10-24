using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GearStatus : ICloneable
    {
        [ProtoMember(1)] private Guid _StatusID;
        [ProtoMember(2)] private string _StatusName;
        [ProtoMember(3)] private bool _IsActive;
        [ProtoMember(4)] private int[] _StatusColorRGB;


        public Guid StatusID { get => _StatusID; set => _StatusID = value; }
        public string StatusName { get => _StatusName; set => _StatusName = value; }
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public int[] StatusColorRGB { get => _StatusColorRGB; set => _StatusColorRGB = value; }

        public GearStatus() { StatusID = Guid.NewGuid(); }
        public GearStatus(Guid id, string name, bool active = true, int red = 0, int green = 0, int blue = 0)
        {
            StatusID = id; StatusName = name; IsActive = active;
            StatusColorRGB = new int[3];
            StatusColorRGB[0] = red;
            StatusColorRGB[1] = green;
            StatusColorRGB[2] = blue;
        }

        public GearStatus Clone()
        {
            return this.MemberwiseClone() as GearStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
