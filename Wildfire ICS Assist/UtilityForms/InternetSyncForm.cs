using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Networking;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class InternetSyncForm : Form
    {
        public InternetSyncForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void InternetSyncForm_Load(object sender, EventArgs e)
        {
            automaticallySettingRadios = true;

            if (Program.InternetSyncEnabled) { rbOngoingSync.Checked = true; }
            else { rbDoNotSync.Checked = true; }
            setPanelStatus();
            automaticallySettingRadios = false;

            if (Program.CurrentTask.AnyOpPeriodHasMeanginfulContent && !string.IsNullOrEmpty(Program.CurrentTask.FileName))
            {
                txtJoinSyncEncryptionKey.Text = Program.CurrentTask.TaskID.ToString() + Program.CurrentTask.TaskEncryptionKey;
            }
            if (Program.InternetSyncEnabled)
            {
                automaticallySettingRadios = true;
                rbOngoingSync.Checked = true;
                rbDoNotSync.Checked = !(rbOngoingSync).Checked;
                rbNewSync.Checked = !(rbOngoingSync).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
                txtJoinSyncEncryptionKey.Text = Program.CurrentTask.TaskID.ToString() + Program.CurrentTask.TaskEncryptionKey;
            }
        }

        bool automaticallySettingRadios = false;
        public bool InternetSyncEnabled
        {
            get
            {
                if (rbNewSync.Checked) { return true; }
                if (rbDoNotSync.Checked) { return false; }
                else
                {
                    return rbOngoingSync.Checked;
                }
            }
        }
        public bool CreateNewSync { get => rbNewSync.Checked; }

        public string JoinTaskID { get => GetGuidFromJoinString(txtJoinSyncEncryptionKey.Text).ToString(); }
        public string JoinEncryptionKey
        {
            get
            {
                string fullText = txtJoinSyncEncryptionKey.Text;
                Guid ID = GetGuidFromJoinString(fullText);
                if (ID != Guid.Empty && fullText.Length > 36)
                {
                    return fullText.Substring(36);
                }
                else
                {
                    return null;
                }

            }
        }


        private void rbDoNotSync_CheckedChanged(object sender, EventArgs e)
        {
            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbOngoingSync.Checked = !((RadioButton)sender).Checked;
                rbNewSync.Checked = !((RadioButton)sender).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }

        }

        private void rbOngoingSync_CheckedChanged(object sender, EventArgs e)
        {

            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbDoNotSync.Checked = !((RadioButton)sender).Checked;
                rbNewSync.Checked = !((RadioButton)sender).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }

        }

        private void rbNewSync_CheckedChanged(object sender, EventArgs e)
        {
            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbOngoingSync.Checked = !((RadioButton)sender).Checked;
                rbDoNotSync.Checked = !((RadioButton)sender).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }

        }

        private void setPanelStatus()
        {
            if (rbDoNotSync.Checked)
            {
                pnlNoSync.BackColor = Color.White;
            }
            else
            {
                pnlNoSync.BackColor = Color.LightGray;
            }

            if (rbOngoingSync.Checked)
            {
                txtJoinSyncEncryptionKey.Enabled = true;
                txtJoinSyncEncryptionKey.Focus();
                pnlJoinSync.BackColor = Color.White;
            }
            else
            {
                txtJoinSyncEncryptionKey.Enabled = false;
                pnlJoinSync.BackColor = Color.LightGray;
            }


            //new sync
            if (rbNewSync.Checked)
            {
                txtNewSyncEncryptionKey.Text = Program.CurrentTask.TaskID.ToString() + Program.CurrentTask.TaskEncryptionKey;
                btnCopyExistingEncryptionKey.Enabled = true;
                btnCopySharingInfo.Enabled = true;
                pnlNewSync.BackColor = Color.White;

            }
            else
            {
                txtNewSyncEncryptionKey.Text = null;
                btnCopyExistingEncryptionKey.Enabled = false;
                btnCopySharingInfo.Enabled = false;
                pnlNewSync.BackColor = Color.LightGray;
            }
        }



        private void btnCopyExistingEncryptionKey_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtNewSyncEncryptionKey.Text); System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error copying to the clipboard.");
            }
        }

        private void btnCopySharingInfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, I would like you to join an incident I'm currently working on.  You'll need the most recent version of "); sb.Append(Globals.ProgramName); sb.Append(" (www.ciffc.ca/applications) and the information shown below. Please keep this information confidential and do not share it.");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append("Encryption Key: "); sb.Append(txtNewSyncEncryptionKey.Text); sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Open "); sb.Append(Globals.ProgramName); sb.Append(", click on 'Network' on the top menu, then click on 'Internet Sharing'. Select 'Join an Ongoing Sync' and enter the information above.");
            try
            {
                Clipboard.SetText(sb.ToString());
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error copying to the clipboard.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool testOK = false;

            if (rbDoNotSync.Checked) { testOK = true; }
            else if (rbNewSync.Checked)
            {
                bool internet = PingTool.TestPing();
                if (!internet)
                {
                    MessageBox.Show("You must be connected to the internet in order to initiate a new task sync.");
                }
                else
                {
                    //check if there is already a task synced with this ID
                    try
                    {
                        Guid TaskID = Program.CurrentTask.TaskID;
                        TaskUpdateService service = new TaskUpdateService();
                        bool initialEntryExists = await service.InitialTaskUpdateExists(TaskID, Program.CurrentTask.TaskEncryptionKey);

                        if (initialEntryExists)
                        {
                            MessageBox.Show("It looks like this task has already been synced to the server.  Please use the 'Join an Ongoing Sync' option and provide the correct encryption key.");
                        }
                        else
                        {
                            testOK = true;

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There was an error checking the server for this task id.  Please verify your internet connection and try agian.");

                    }


                }
            }
            else if (rbOngoingSync.Checked)
            {
                try
                {
                    //is this a real task number?
                    Guid TaskID = GetGuidFromJoinString(txtJoinSyncEncryptionKey.Text);

                    if (TaskID != Guid.Empty && !string.IsNullOrEmpty(txtJoinSyncEncryptionKey.Text))
                    {

                        bool internet = PingTool.TestPing();
                        if (!internet) { MessageBox.Show("You must be connected to the internet to join an internet sync task."); }
                        else
                        {
                            TaskUpdateService service = new TaskUpdateService();
                            bool initialEntryExists = await service.InitialTaskUpdateExists(TaskID, JoinEncryptionKey);

                            if (initialEntryExists)
                            {
                                testOK = true;
                            }
                            else
                            {
                                MessageBox.Show("The task either hasn't been posted to the server yet, or your encryption key was incorrect.");
                            }
                        }


                    }
                    else { MessageBox.Show("There is an error in your encryption key, please confirm it has been entered correctly with no extra characters or spaces."); }
                }
                catch (Exception)
                {
                    testOK = false;
                }
            }

            if (testOK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }


        private Guid GetGuidFromJoinString(string str)
        {
            Guid id;

            if (str.Length >= 36)
            {
                try
                {
                    string sub = str.Substring(0, 36);
                    id = new Guid(sub);
                }
                catch (Exception)
                {
                    id = Guid.Empty;
                }

            }
            else { id = Guid.Empty; }

            return id;
        }



        private void pnlJoinSync_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlNoSync_Click(object sender, EventArgs e)
        {
            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbDoNotSync.Checked = true;
                rbOngoingSync.Checked = !(rbDoNotSync).Checked;
                rbNewSync.Checked = !(rbDoNotSync).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }
        }

        private void pnlJoinSync_Click(object sender, EventArgs e)
        {
            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbOngoingSync.Checked = true;
                rbDoNotSync.Checked = !(rbOngoingSync).Checked;
                rbNewSync.Checked = !(rbOngoingSync).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }
        }

        private void pnlNewSync_Click(object sender, EventArgs e)
        {
            if (!automaticallySettingRadios)
            {
                automaticallySettingRadios = true;
                rbNewSync.Checked = true;
                rbOngoingSync.Checked = !(rbNewSync).Checked;
                rbDoNotSync.Checked = !(rbNewSync).Checked;
                setPanelStatus();
                automaticallySettingRadios = false;
            }
        }

        private void btnCopyJoinShareInfo_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hi, I would like you to join an incident I'm currently working on.  You'll need the most recent version of "); sb.Append(Globals.ProgramName); sb.Append(" (www.ciffc.ca/applications) and the information shown below. Please keep this information confidential and do not share it.");
            sb.Append(Environment.NewLine); sb.Append(Environment.NewLine);
            sb.Append("Encryption Key: "); sb.Append(txtJoinSyncEncryptionKey.Text); sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Open "); sb.Append(Globals.ProgramName); sb.Append(", click on 'Network' on the top menu, then click on 'Internet Sharing'. Select 'Join an Ongoing Sync' and enter the information above.");
            try
            {
                Clipboard.SetText(sb.ToString());
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error copying to the clipboard.");
            }
        }



        private void btnCopyJoinEncryiptionKey_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtJoinSyncEncryptionKey.Text);
                System.Media.SystemSounds.Beep.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error copying to the clipboard.");
            }
        }

        private void btnLearnMore_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("InternetSync"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;

                    help.ShowDialog();
                }
            }
        }

        private void txtJoinSyncEncryptionKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJoinSyncEncryptionKey_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim();
        }
    }
}
