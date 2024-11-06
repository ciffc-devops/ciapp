using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class NotesListViewNoteForm : BaseForm
    {
        Note _currentNote = null;
        public Note CurrentNote { get => _currentNote; private set => _currentNote = value; }

        public NotesListViewNoteForm(Note note)
        {
            InitializeComponent(); SetControlColors(this.Controls);
            CurrentNote = note;
        }

        private void NotesListViewNoteForm_Load(object sender, EventArgs e)
        {
            rtxtNoteTExt.Text = CurrentNote.NoteText;
            this.Text = CurrentNote.NoteTitle;
            Program.incidentDataService.NoteChanged += Program_NoteChanged;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (NotesListEditNoteForm editNote = new NotesListEditNoteForm(CurrentNote))
            {
                DialogResult dr = editNote.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertNote(editNote.CurrentNote);
                }
            }
        }

        private void Program_NoteChanged(NoteEventArgs e)
        {
            if(e.item.NoteID == CurrentNote.NoteID)
            {
                rtxtNoteTExt.Text = CurrentNote.NoteText;
                this.Text = CurrentNote.NoteTitle;

            }
        }
    }
}
