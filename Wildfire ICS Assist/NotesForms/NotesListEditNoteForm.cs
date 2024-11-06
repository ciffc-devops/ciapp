using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class NotesListEditNoteForm : BaseForm
    {
        Note _currentNote = null;
        public Note CurrentNote { get => _currentNote; private set => _currentNote = value; }


        public NotesListEditNoteForm(Note note)
        {
            InitializeComponent(); SetControlColors(this.Controls);
            CurrentNote = note;
        }

        private void NotesListEditNoteForm_Load(object sender, EventArgs e)
        {
            cboNoteCategory.DataSource = NoteTools.NoteCategories;
            if (CurrentNote != null)
            {
                txtNoteTitle.Text = CurrentNote.NoteTitle;
                rtxtNoteText.Text = CurrentNote.NoteText;
                if (CurrentNote.CategoryID != Guid.Empty)
                {
                    cboNoteCategory.SelectedValue = CurrentNote.CategoryID;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoteTitle.Text))
            {
                CurrentNote.NoteTitle = txtNoteTitle.Text;
                CurrentNote.NoteText = rtxtNoteText.Text;
                CurrentNote.Active = true;
                NoteCategory category = (NoteCategory)cboNoteCategory.SelectedItem;
                CurrentNote.CategoryID = category.CategoryID;
                CurrentNote.CategoryName = category.CategoryName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txtNoteTitle.BackColor = Program.ErrorColor;
            }

        }

        private void txtNoteTitle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoteTitle.Text.Trim())) { txtNoteTitle.BackColor = Program.ErrorColor; }
            else { txtNoteTitle.BackColor = Program.GoodColor; }
        }
    }
}
