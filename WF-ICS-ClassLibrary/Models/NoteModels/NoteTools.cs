using System;
using System.Collections.Generic;

namespace WF_ICS_ClassLibrary.Models
{
    public static class NoteTools {

        public static List<NoteCategory> NoteCategories
        {
            get
            {
                List<NoteCategory> categories = new List<NoteCategory>();
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Food and Shelter Note"));
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Note from AHJ"));
                categories.Add(new NoteCategory(new Guid("14b17ad2-4f35-440e-9e5e-ac2fd667c536"), "Note from SME"));
                categories.Add(new NoteCategory(new Guid("dfc44802-5107-4238-b438-36c172afb78f"), "Other"));
                return categories;
            }
        }
    }
}
