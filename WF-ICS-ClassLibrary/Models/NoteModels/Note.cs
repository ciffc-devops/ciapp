using ProtoBuf;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class Note : SyncableItem, ICloneable
    {
        [ProtoMember(2)] private Guid _CategoryID;
        [ProtoMember(3)] private string _CategoryName;
        [ProtoMember(4)] private string _NoteTitle;
        [ProtoMember(5)] private string _NoteText;
        [ProtoMember(6)] private DateTime _DateCreated;
        [ProtoMember(7)] private DateTime _DateUpdated;

        public Note() { NoteID = Guid.NewGuid(); }


        public Guid NoteID { get => ID; set => ID = value; }
        public Guid CategoryID { get => _CategoryID; set => _CategoryID = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }
        public string NoteTitle { get => _NoteTitle; set => _NoteTitle = value; }
        public string NoteText { get => _NoteText; set => _NoteText = value; }
        public DateTime DateCreated { get => _DateCreated; set => _DateCreated = value; }
        public DateTime DateUpdated { get => _DateUpdated; set { _DateUpdated = value; LastUpdatedUTC = value.ToUniversalTime(); } }
        public DateTime DateUpdatedUTC { get => LastUpdatedUTC; set => LastUpdatedUTC = value; }

        public Note Clone()
        {
            return this.MemberwiseClone() as Note;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
