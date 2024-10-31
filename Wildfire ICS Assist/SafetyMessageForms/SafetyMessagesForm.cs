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
    public partial class SafetyMessagesForm : BaseForm
    {
        public SafetyMessagesForm()
        {
            InitializeComponent(); 
        }

        private void SafetyMessagesForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }
            BuildDataList();
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OpPeriodChanged;

            Program.incidentDataService.SafetyMessageChanged += Program_SafetyMessageChanged;
        }

        private void Program_SafetyMessageChanged(SafetyMessageEventArgs e)
        {
            if(e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildDataList();
            }
        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            BuildDataList();
        }


        private void BuildDataList()
        {
            dgvSafetyNotes.AutoGenerateColumns = false;
            dgvSafetyNotes.DataSource = null;
            dgvSafetyNotes.DataSource = Program.CurrentIncident.allSafetyMessages.Where(o => o.OpPeriod == Program.CurrentOpPeriod && o.Active).ToList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (SafetyMessageEntryForm entryForm = new SafetyMessageEntryForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    entryForm.selectedMessage.ApprovedByResourceName = Program.CurrentRole.IndividualName;
                    entryForm.selectedMessage.ApprovedByRoleID = Program.CurrentRole.RoleID; 
                    entryForm.selectedMessage.ApprovedByRoleName = Program.CurrentRole.RoleName;
                    Program.incidentDataService.UpsertSafetyMessage(entryForm.selectedMessage);

                    if (entryForm.SaveForLater)
                    {
                        SafetyMessage msg = entryForm.selectedMessage.Clone();
                        msg.SafetyTemplateID = Guid.NewGuid();
                        Program.generalOptionsService.UpsertOptionValue(msg, "SafetyMessage");
                    }
                }
            }
        }

        private void OpenForEdit(SafetyMessage msg)
        {
            using (SafetyMessageEditForm editForm = new SafetyMessageEditForm())
            {
                editForm.selectedMessage = msg.Clone();
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    editForm.selectedMessage.ApprovedByResourceName = Program.CurrentRole.IndividualName;
                    editForm.selectedMessage.ApprovedByRoleID = Program.CurrentRole.RoleID;
                    editForm.selectedMessage.ApprovedByRoleName = Program.CurrentRole.RoleName;
                    Program.incidentDataService.UpsertSafetyMessage(editForm.selectedMessage);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvSafetyNotes.SelectedRows.Count == 1)
            {
                SafetyMessage msg = (SafetyMessage)dgvSafetyNotes.SelectedRows[0].DataBoundItem;
                OpenForEdit(msg);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvSafetyNotes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    List<SafetyMessage> list = new List<SafetyMessage>();
                    foreach (DataGridViewRow row in dgvSafetyNotes.SelectedRows)
                    {
                        list.Add((SafetyMessage)row.DataBoundItem);
                    }

                    foreach (SafetyMessage sm in list)
                    {
                        sm.Active = false;
                        Program.incidentDataService.UpsertSafetyMessage(sm);

                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(dgvSafetyNotes.SelectedRows.Count  > 0)
            {
                List<SafetyMessage> toPrint = new List<SafetyMessage>();
                foreach (DataGridViewRow row in dgvSafetyNotes.SelectedRows)
                {
                    toPrint.Add((SafetyMessage)row.DataBoundItem);
                }


                List<byte[]> allPDFs = Program.pdfExportService.exportSafetyMessagesToPDF(Program.CurrentTask, toPrint, false);




                string fullFilepath = "";
                //int end = CurrentTask.FileName.LastIndexOf("\\");
                fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

                string fullOutputFilename = "ICS 208 - Task " + Program.CurrentIncident.IncidentIdentifier + " - Safety Messages";
                //fullFilepath = System.IO.Path.Combine(fullFilepath, outputFileName);
                fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

                byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
                try
                {
                    File.WriteAllBytes(fullFilepath, fullFile);

                    System.Diagnostics.Process.Start(fullFilepath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
                }

            }
        }

        private void dgvSafetyNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                SafetyMessage msg = (SafetyMessage)dgvSafetyNotes.Rows[e.RowIndex].DataBoundItem;
                OpenForEdit(msg);
            }
        }

        private void dgvSafetyNotes_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = ((DataGridView)sender).SelectedRows.Count > 0;
            btnEdit.Enabled = ((DataGridView)sender).SelectedRows.Count == 1;

        }
    }
}
