using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;
using WildfireICSDesktopServices.Logging;

namespace Wildfire_ICS_Assist.InternetSyncForms
{
    public partial class InternetSyncStartForm : BaseForm
    {
        bool SyncDone = false;
        public bool CreateNewSync { get; set; } = false;
        public Guid JoinTaskID { get; set; } = Guid.Empty;
        public string JoinEncryptionKey { get; set; } = string.Empty;



        public InternetSyncStartForm()
        {
            InitializeComponent();
            this.BackColor = Program.DarkAccentColor;
        }

        private void InternetSyncStartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!SyncDone)
            {
                DialogResult dr = LgMessageBox.Show("Are you sure you want to close this while it is in progress? This will disable the internet sync for the task.", "Close Sync ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else { this.DialogResult = DialogResult.Cancel; }
            }
        }

        private async void InternetSyncStartForm_Load(object sender, EventArgs e)
        {

            if (CreateNewSync)
            {
                lblStatus.Text = "Starting New Task...";
            }
            else
            {
                lblStatus.Text = "Joining Task...";
            }


            if (CreateNewSync)
            {
                await StartInternetSyncAsync(Program.CurrentTask.ID, Program.CurrentTask.TaskEncryptionKey, true);
            }
            else if (JoinTaskID != Guid.Empty && !string.IsNullOrEmpty(JoinEncryptionKey))
            {
                await StartInternetSyncAsync(JoinTaskID, JoinEncryptionKey, false);
            }
            else
            {
                lblStatus.Text = "Sorry, there was an error joining the sync.  Please contact support";
            }


        }

        private void UpdateStatusDisplay(string status, int progress, int totalprogress)
        {
            progressBar1.Maximum = totalprogress;
            progressBar1.Value = progress;
            lblStatus.Text = status;
        }

        private async Task StartInternetSyncAsync(Guid TaskID, string EncryptionKey, bool IsNewSync)
        {
            Progress<Tuple<int, int, int>> prog = new Progress<Tuple<int, int, int>>();

            //do stuff to sync the task
            if (IsNewSync)
            {
                try
                {


                    prog.ProgressChanged += Prog_ProgressChangedNewTask; ;
                    await Program.incidentDataService.SendInitialTaskUpdate(prog);
                }
                catch (Exception ex)
                {
#if DEBUG
                    new LogService().Log("ERROR:  " + ex.ToString());
#endif

                }
                finally
                {
                    SyncDone = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                try
                {
                    TaskUpdateService service = new TaskUpdateService();



                    if (TaskID != Program.CurrentTask.ID)
                    {
                        prog.ProgressChanged += Progress_ProgressChanged;

                        await Program.incidentDataService.LoadNewTaskFromServer(TaskID, EncryptionKey, prog);

                        //await CountUpAsync(1000, prog);
                    }
                    else
                    {
                        prog.ProgressChanged += Prog_ProgressChangedResync;

                        await Program.incidentDataService.ConnectToServerTaskAsync(TaskID, EncryptionKey, prog);
                    }


                }
                catch (Exception ex)
                {
#if DEBUG
                    new LogService().Log("ERROR:  " + ex.ToString());
#endif
                }
                finally
                {
                    SyncDone = true;
                    this.DialogResult = DialogResult.OK;
                    this.Close();


                }

            }
        }

        private void Prog_ProgressChangedNewTask(object sender, Tuple<int, int, int> e)
        {
            StringBuilder sb = new StringBuilder();

            switch (e.Item1)
            {


                case 1:
                    sb.Append("Sending task updates to server (" + e.Item2 + " of " + e.Item3 + ")");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);

                    break;
            }
        }

        private void Prog_ProgressChangedResync(object sender, Tuple<int, int, int> e)
        {
            StringBuilder sb = new StringBuilder();

            switch (e.Item1)
            {
                case 0:
                    sb.Append("Sending local updates to the server (" + e.Item2 + " of " + e.Item3 + ")" + " (Step 1 of 4)");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);
                    break;
                case 1:
                    sb.Append("Downloading task updates from the server " + " (Step 2 of 4)");
                    break;
                case 2:
                    sb.Append("Sorting task updates, total downloaded: " + e.Item2);
                    UpdateStatusDisplay(sb.ToString(), e.Item1, 5);

                    break;
                case 3:
                    sb.Append("Decrypting entries item " + e.Item2 + " of " + e.Item3 + " (Step 4 of 4)");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);

                    break;
                case 4:
                    sb.Append("Applying task update " + e.Item2 + " of " + e.Item3 + " (Step 4 of 4)");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);

                    break;
            }
        }

        private void Progress_ProgressChanged(object sender, Tuple<int, int, int> e)
        {
            StringBuilder sb = new StringBuilder();

            switch (e.Item1)
            {
                case 0:
                    sb.Append("Syncing Task...");
                    UpdateStatusDisplay(sb.ToString(), e.Item1, 5);
                    break;
                case 1:
                    sb.Append("Downloading task updates from the server (Step 1 of 3)");
                    break;
                case 2:
                    sb.Append("Sorting task updates, total downloaded: " + e.Item2);
                    UpdateStatusDisplay(sb.ToString(), e.Item1, 5);

                    break;
                case 3:
                    sb.Append("Decrypting entries item " + e.Item2 + " of " + e.Item3 + " (Step 2 of 3)");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);

                    break;
                case 4:
                    sb.Append("Applying task update " + e.Item2 + " of " + e.Item3 + " (Step 3 of 3)");
                    UpdateStatusDisplay(sb.ToString(), e.Item2, e.Item3);

                    break;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
