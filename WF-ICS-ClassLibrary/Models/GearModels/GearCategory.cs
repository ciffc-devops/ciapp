using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GearCategory : ICloneable
    {
        [ProtoMember(1)] private Guid _CategoryID;
        [ProtoMember(2)] private string _CategoryName;
        [ProtoMember(3)] private Guid _ParentCategoryID;
        [ProtoMember(4)] private string _CategoryNotes;

        public GearCategory()
        {
            CategoryID = Guid.NewGuid();
        }
        public GearCategory(Guid category_id, Guid parent_id, string name)
        {
            CategoryID = category_id;
            ParentCategoryID = parent_id;
            CategoryName = name;
        }

        public Guid CategoryID { get => _CategoryID; set => _CategoryID = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }
        public string CategoryNameWithDash { get { if (ParentCategoryID == Guid.Empty) { return CategoryName; } else { return "--" + CategoryName; } } }

        public Guid ParentCategoryID { get => _ParentCategoryID; set => _ParentCategoryID = value; }
        public string CategoryNotes { get => _CategoryNotes; set => _CategoryNotes = value; }

        public GearCategory Clone()
        {
            return this.MemberwiseClone() as GearCategory;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
