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
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class GeneralMessagesForm : Form
    {
        public GeneralMessagesForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent(); this.BackColor = Program.FormBackground;
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GeneralMessagesForm_Load(object sender, EventArgs e)
        {
            dgvLog.AutoGenerateColumns = false;
            BuildMessageList();
            Program.wfIncidentService.GeneralMessageChanged += Program_GeneralMessageChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

        }
        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            BuildMessageList();
        }


        private void BuildMessageList()
        {
            List<GeneralMessage> messages = Program.CurrentIncident.ActiveGeneralMessages.OrderBy(o=>o.DateSent).ToList();
            if (rbOutstandingMessages.Checked) { messages = messages.Where(o => !o.HasReply).ToList(); }
            if (rbThisOpOnly.Checked) { messages = messages.Where(o => o.OpPeriod == Program.CurrentOpPeriod).ToList(); }
            dgvLog.DataSource = messages;

        }

        private void Program_GeneralMessageChanged(GeneralMessageEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                BuildMessageList();

            }
        }

        private void OpenForEdit(GeneralMessage msg)
        {
            using (GeneralMessageEditForm editForm = new GeneralMessageEditForm())
            {
                editForm.generalMessage = msg;
                DialogResult dr = editForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertGeneralMessage(editForm.generalMessage);
                }
            }
        }

        private void OpenForView(GeneralMessage msg)
        {
            using (GeneralMessageViewForm viewForm = new GeneralMessageViewForm())
            {
                viewForm.generalMessage = msg;
                viewForm.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GeneralMessage gm = new GeneralMessage();
            gm.TaskID = Program.CurrentIncident.TaskID;
            gm.OpPeriod = Program.CurrentOpPeriod;
            gm.FromRoleID = Program.CurrentRole.RoleID;
            gm.FromName = Program.CurrentRole.IndividualName;
            gm.FromPosition = Program.CurrentRole.RoleName;


            gm.ApprovedByRoleID = Program.CurrentRole.RoleID;
            gm.ApprovedByName = Program.CurrentRole.IndividualName;
            gm.ApprovedByPosition = Program.CurrentRole.RoleName;
            gm.DateSent = DateTime.Now;
            gm.Active = true;
            OpenForEdit(gm);
        }

        private void rbAllMessages_CheckedChanged(object sender, EventArgs e)
        {
            BuildMessageList();
        }

        private void rbOutstandingMessages_CheckedChanged(object sender, EventArgs e)
        {
            BuildMessageList();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if(dgvLog.SelectedRows.Count == 1)
            {
                GeneralMessage gm = (GeneralMessage)dgvLog.SelectedRows[0].DataBoundItem;
                OpenForView(gm);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvLog.SelectedRows.Count == 1)
            {
                GeneralMessage gm = (GeneralMessage)dgvLog.SelectedRows[0].DataBoundItem;
                OpenForEdit(gm);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLog.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    List<GeneralMessage> toDelete = new List<GeneralMessage>();
                    foreach (DataGridViewRow row in dgvLog.SelectedRows)
                    {
                        toDelete.Add((GeneralMessage)row.DataBoundItem);

                    }

                    foreach (GeneralMessage gm in toDelete) { gm.Active = false; Program.wfIncidentService.UpsertGeneralMessage(gm); }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<GeneralMessage> messagesToPrint = new List<GeneralMessage>();
            foreach(DataGridViewRow row in dgvLog.SelectedRows)
            {
                messagesToPrint.Add((GeneralMessage)row.DataBoundItem);
            }
            messagesToPrint = messagesToPrint.OrderBy(o => o.DateSent).ToList();

            List<byte[]> allPDFs = Program.pdfExportService.exportGeneralMessagesToPDF(Program.CurrentTask, messagesToPrint, false);


         

            string fullFilepath = "";
            //int end = CurrentTask.FileName.LastIndexOf("\\");
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS 213 - Task " + Program.CurrentIncident.IncidentIdentifier + " - General Messages";
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

        private void rbAllOps_CheckedChanged(object sender, EventArgs e)
        {
            BuildMessageList();
        }

        private void rbThisOpOnly_CheckedChanged(object sender, EventArgs e)
        {
            BuildMessageList();
        }

        private void dgvLog_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvLog.SelectedRows.Count == 1;
            btnViewDetails.Enabled = btnEdit.Enabled;
            btnDelete.Enabled = dgvLog.SelectedRows.Count > 0;
            btnPrint.Enabled = dgvLog.SelectedRows.Count > 0;
        }

        private void dgvLog_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                GeneralMessage gm = (GeneralMessage)dgvLog.Rows[e.RowIndex].DataBoundItem;
                OpenForView(gm);
            }
        }

        private void btnFormInfo_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("GeneralMessage"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }
    }
}
