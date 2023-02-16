using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class NotesForm : Form
    {
        int CurrentOpPeriod { get => Program.CurrentOpPeriod; }

        public List<Note> TaskNotes(Guid CategoryID = new Guid(), int OpPeriod = 0)
        {
            if (CategoryID != Guid.Empty) { return Program.CurrentIncident.allNotes.Where(o => o.Active && o.CategoryID == CategoryID && (OpPeriod == 0 || OpPeriod == o.OpPeriod)).OrderBy(o => o.DateCreated).ToList(); }
            else { return Program.CurrentIncident.allNotes.Where(o => o.Active && (OpPeriod == 0 || OpPeriod == o.OpPeriod)).OrderBy(o => o.DateCreated).ToList(); }

        }

        public NotesForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            cboCategory.DataSource = NoteCategoriesWithAll;

            dgvNotes.AutoGenerateColumns = false;
            buildNoteList();
            Program.wfIncidentService.NoteChanged += Program_NoteChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            buildNoteList();
        }

        private void Program_NoteChanged(NoteEventArgs e)
        {
            buildNoteList();
        }

        public List<NoteCategory> NoteCategories { get { return NoteTools.NoteCategories; } }

        private void buildNoteList()
        {
            dgvNotes.AutoGenerateColumns = false;
            dgvNotes.DataSource = null;
            NoteCategory category = (NoteCategory)cboCategory.SelectedItem;
            int Op = 0;
            if (!chkAllOpPeriods.Checked) { Op = CurrentOpPeriod; }
            dgvNotes.DataSource = TaskNotes(category.CategoryID, Op);
        }

        public List<NoteCategory> NoteCategoriesWithAll
        {
            get
            {
                List<NoteCategory> categories = NoteCategories;
                categories.Insert(0, new NoteCategory(Guid.Empty, "-All Types-"));
                return categories;
            }
        }

        public List<NoteCategory> GetNoteCategories(bool includeAll = false)
        {
            if (includeAll) { return NoteCategoriesWithAll; }
            return NoteCategories;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Note newNote = new Note();
            newNote.OpPeriod = CurrentOpPeriod;
            using (NotesListEditNoteForm editNote = new NotesListEditNoteForm(newNote))
            {
                DialogResult dr = editNote.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertNote(editNote.CurrentNote);




                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedRows.Count == 1)
            {
                Note note = (Note)dgvNotes.SelectedRows[0].DataBoundItem;
                using (NotesListViewNoteForm viewNote = new NotesListViewNoteForm(note))
                {
                    viewNote.ShowDialog();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedRows.Count == 1)
            {
                Note note = (Note)dgvNotes.SelectedRows[0].DataBoundItem;
                using (NotesListEditNoteForm editNote = new NotesListEditNoteForm(note))
                {
                    DialogResult dr = editNote.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        Program.wfIncidentService.UpsertNote(editNote.CurrentNote);
                    }
                }
            }
            else
            {
                MessageBox.Show("Sorry, you can only edit one note at a time, please select just one to conitnue.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the selected note(s)?", "Are you sure?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                List<Note> notesToDelete = new List<Note>();
                foreach (DataGridViewRow row in dgvNotes.SelectedRows)
                {
                    Note note = (Note)row.DataBoundItem;
                    notesToDelete.Add(note);

                }
                foreach (Note note in notesToDelete)
                {
                    note.Active = false;
                    Program.wfIncidentService.UpsertNote(note);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            List<byte[]> allPDFs = new List<byte[]>();


            string fullFilepath = "";
            //int end = Program.CurrentIncident.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Task " + Program.CurrentIncident.TaskNumber + " Op " + CurrentOpPeriod + " Notes";    // + ".pdf";
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            allPDFs.AddRange(exportNotesToPDF());


            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);

            }
            catch (Exception)
            {
                MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.");
            }
        }

        public List<byte[]> exportNotesToPDF()
        {
            List<byte[]> allPDFs = new List<byte[]>();

            List<Note> notes = new List<Note>();
            foreach (DataGridViewRow row in dgvNotes.SelectedRows)
            {
                Note note = (Note)row.DataBoundItem;
                notes.Add(note);
            }


            foreach (Note note in notes)
            {
                string path = Program.pdfExportService.createNotePDF(Program.CurrentIncident, note, false, true);
                using (FileStream stream = File.OpenRead(path))
                {
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();
                    allPDFs.Add(fileBytes);
                }

            }
            return allPDFs;
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildNoteList();

        }

        private void chkAllOpPeriods_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked) { chk.ImageIndex = 1; }
            else { chk.ImageIndex = 0; }
            buildNoteList();
        }

        private void dgvNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Note note = (Note)dgvNotes.Rows[e.RowIndex].DataBoundItem;
                using (NotesListViewNoteForm viewNote = new NotesListViewNoteForm(note))
                {
                    viewNote.ShowDialog();
                }
            }

        }

        private void dgvNotes_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = (dgvNotes.SelectedRows.Count == 1);
            btnView.Enabled = (dgvNotes.SelectedRows.Count == 1);
            btnDelete.Enabled = dgvNotes.SelectedRows.Count > 0;
            btnPrint.Enabled = dgvNotes.SelectedRows.Count > 0;

        }
    }
}
