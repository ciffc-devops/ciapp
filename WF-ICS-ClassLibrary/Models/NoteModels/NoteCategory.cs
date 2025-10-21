using System;

namespace WF_ICS_ClassLibrary.Models
{
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
    }
}
