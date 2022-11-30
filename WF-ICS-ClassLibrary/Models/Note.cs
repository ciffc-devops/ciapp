using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class Note : ICloneable
    {
        [ProtoMember(1)] private Guid _NoteID;
        [ProtoMember(2)] private Guid _CategoryID;
        [ProtoMember(3)] private string _CategoryName;
        [ProtoMember(4)] private string _NoteTitle;
        [ProtoMember(5)] private string _NoteText;
        [ProtoMember(6)] private DateTime _DateCreated;
        [ProtoMember(7)] private DateTime _DateUpdated;
        [ProtoMember(8)] private bool _Active;
        [ProtoMember(9)] private Guid _TaskID;
        [ProtoMember(10)] private int _OpPeriod;
        [ProtoMember(11)] private DateTime _DateUpdatedUTC;

        public Note() { NoteID = Guid.NewGuid(); }


        public Guid NoteID { get => _NoteID; set => _NoteID = value; }
        public Guid CategoryID { get => _CategoryID; set => _CategoryID = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }
        public string NoteTitle { get => _NoteTitle; set => _NoteTitle = value; }
        public string NoteText { get => _NoteText; set => _NoteText = value; }
        public DateTime DateCreated { get => _DateCreated; set => _DateCreated = value; }
        public DateTime DateUpdated { get => _DateUpdated; set { _DateUpdated = value; _DateUpdatedUTC = value.ToUniversalTime(); } }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime DateUpdatedUTC { get => _DateUpdatedUTC; set => _DateUpdatedUTC = value; }

        public Note Clone()
        {
            return this.MemberwiseClone() as Note;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    public class NoteCategory
    {
        private Guid _CategoryID;
        private string _CategoryName;

        public NoteCategory() { CategoryID = Guid.NewGuid(); }
        public NoteCategory(string category_name)
        {
            CategoryID = Guid.NewGuid();
            CategoryName = category_name;
        }

        public NoteCategory(Guid Id, string category_name)
        {
            CategoryID = Id;
            CategoryName = category_name;
        }


        public Guid CategoryID { get => _CategoryID; set => _CategoryID = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }

        public List<NoteCategory> NoteCategories
        {
            get
            {
                List<NoteCategory> categories = new List<NoteCategory>();
                categories.Add(new NoteCategory(new Guid("c735237b-f252-431b-81c9-c1c650c068c4"), "Interview Note"));
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Food and Shelter Note"));
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Note from Tasking Agency"));
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Note from EMBC/ECC"));
                categories.Add(new NoteCategory(new Guid("dfc44802-5107-4238-b438-36c172afb78f"), "Other"));
                return categories;
            }
        }


    }
}
