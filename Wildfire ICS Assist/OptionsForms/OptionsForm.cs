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
using WF_ICS_ClassLibrary.Networking;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class OptionsForm : Form
    {
        private List<DeviceInformation> allDevices = new List<DeviceInformation>();

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void LoadICSRoles()
        {
            List<ICSRole> roles = OrgChartTools.GetBlankPrimaryRoles();
            cboDefaultICSRole.DataSource = roles;
            cboDefaultICSRole.DisplayMember = "RoleNameForDropdown";
            cboDefaultICSRole.ValueMember = "RoleID";

        }
        private void LoadCommsSystems()
        {
            LoadCommsSystems(cboPrimaryChannel);
            LoadCommsSystems(cboSecondaryChannel);
            LoadCommsSystems(cboEmergencyChannel);

        }
        private void LoadCommsSystems(ComboBox cbo)
        {
            List<CommsPlanItem> items = (List<CommsPlanItem>)Program.generalOptionsService.GetOptionsValue("CommsItems");
            items = items.Where(o => o.Active).OrderBy(o => o.ChannelID).ToList();
            cbo.DataSource = items;

        }

        private void LoadSavedValues()
        {

            GeneralOptions options = Program.generalOptionsService.GetGeneralOptions(null);


            //general
            cboPositionFormat.SelectedItem = options.PositionFormat;
            if (options.DefaultICSRole != null && options.DefaultICSRole.RoleID != Guid.Empty)
            {
                cboDefaultICSRole.SelectedValue = options.DefaultICSRole.RoleID;
            }
            else { cboDefaultICSRole.SelectedIndex = 0; }

            //File Management
            chkAutoSave.Checked = options.AutoSave;
            txtSaveLocation.Text = options.DefaultSaveLocation;
            if (!string.IsNullOrEmpty(options.DefaultBackupLocation)) { txtBackupLocation.Text = options.DefaultBackupLocation; }
            else { txtBackupLocation.Text = options.DefaultSaveLocation; }


            chkPromptForInitialSave.Checked = options.PromptForInitialSave;
            chkAutomaticBackups.Checked = options.AutomaticBackups;
            switch (options.AutoBackupIntervalMinutes)
            {
                case 30:
                    cboAutoBackupFrequency.SelectedIndex = 0;
                    break;
                case 60:
                    cboAutoBackupFrequency.SelectedIndex = 1;
                    break;
                case 120:
                    cboAutoBackupFrequency.SelectedIndex = 2;
                    break;
                case 240:
                    cboAutoBackupFrequency.SelectedIndex = 3;
                    break;
                default:
                    cboAutoBackupFrequency.SelectedIndex = 2;
                    break;
            }
            txtAutomaticSubFolders.Text = options.AutomaticSubFoldersCSV;


            //Comms
            txtICPCallSign.Text = options.ICPCallSign;
            if (options.PrimaryChannelID != null && options.PrimaryChannelID != Guid.Empty) { cboPrimaryChannel.SelectedValue = options.PrimaryChannelID; }
            if (options.EmergencyChannelID != null && options.EmergencyChannelID != Guid.Empty) { cboEmergencyChannel.SelectedValue = options.EmergencyChannelID; }
            if (options.SecondaryChannelID != null && options.SecondaryChannelID != Guid.Empty) { cboSecondaryChannel.SelectedValue = options.SecondaryChannelID; }


            //Network
            foreach (DeviceInformation info in options.AllDeviceInformation.Where(o => o.TrustDevice))
            {
                allDevices.Add(info);
            }
            lbTrustedDevices.DataSource = allDevices;
            chkDefaultToServer.Checked = options.DefaultToServer;
            numDefaultPortNumber.Value = options.DefaultPortNumber;

        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            LoadICSRoles();
            LoadCommsSystems();
            LoadSavedValues();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                GeneralOptions options = Program.generalOptionsService.GetGeneralOptions(null);
                if (options != null)
                {
                    //general
                    if (cboPositionFormat.SelectedItem != null) { options.PositionFormat = cboPositionFormat.SelectedItem.ToString(); }
                    options.DefaultICSRole = (ICSRole)cboDefaultICSRole.SelectedItem;

                    //File Management
                    options.AutoSave = chkAutoSave.Checked;
                    options.DefaultSaveLocation = txtSaveLocation.Text;
                    options.DefaultBackupLocation = txtBackupLocation.Text;
                    options.PromptForInitialSave = chkPromptForInitialSave.Checked;
                    options.AutomaticBackups = chkAutomaticBackups.Checked;
                    switch (cboAutoBackupFrequency.SelectedIndex)
                    {
                        case 0:
                            options.AutoBackupIntervalMinutes = 30;
                            break;
                        case 1:
                            options.AutoBackupIntervalMinutes = 60;
                            break;
                        case 2:
                            options.AutoBackupIntervalMinutes = 120;
                            break;
                        case 3:
                            options.AutoBackupIntervalMinutes = 240;
                            break;
                        default:
                            options.AutoBackupIntervalMinutes = 120;
                            break;
                    }
                    options.AutomaticSubFolders = txtAutomaticSubFolders.Text.ListFromCSV();


                    //Comms
                    options.ICPCallSign = txtICPCallSign.Text;
                    if (cboPrimaryChannel.SelectedValue != null) { options.PrimaryChannelID = ((CommsPlanItem)cboPrimaryChannel.SelectedItem).ItemID; } else { options.PrimaryChannelID = Guid.Empty; }
                    if (cboSecondaryChannel.SelectedValue != null)
                    {
                        options.SecondaryChannelID = ((CommsPlanItem)cboSecondaryChannel.SelectedItem).ItemID;
                    }
                    else { options.SecondaryChannelID = Guid.Empty; }
                    if (cboEmergencyChannel.SelectedValue != null)
                    {
                        options.EmergencyChannelID = ((CommsPlanItem)cboEmergencyChannel.SelectedItem).ItemID;
                    }
                    else { options.EmergencyChannelID = Guid.Empty; }


                    //Network
                    options.AllDeviceInformation = allDevices;

                    options.DefaultToServer = chkDefaultToServer.Checked;
                    options.DefaultPortNumber = Convert.ToInt32(numDefaultPortNumber.Value);

                    _ = Program.generalOptionsService.SaveGeneralOptions(options);

                    this.DialogResult= DialogResult.OK;
                    this.Close();
                }

            }
        }

        private bool ValidateForm()
        {
            return true;
        }

        private void btnAutoBackupHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("AutoBackup"))
            {
                
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnAutomaticSubFoldersHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("AutoSubFolders"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnHelpDefaultToServer_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("OptionsDefaultToServer"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void btnHelpDefaultPort_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("OptionsDefaultPortNumber"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void btnTrustedDevicesHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("OptionsTrustedDevices"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void btnRemoveTrustedDevice_Click(object sender, EventArgs e)
        {
            if (lbTrustedDevices.SelectedItems.Count > 0)
            {
                foreach (DeviceInformation item in lbTrustedDevices.SelectedItems)
                {
                    item.TrustDevice = false;
                }

                lbTrustedDevices.DataSource = allDevices.Where(o => o.TrustDevice).ToList();
            }

        }

        private void btnBrowseDefaultSaveLocation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSaveLocation.Text)) { fbdDefaultSave.SelectedPath = txtSaveLocation.Text; }
            DialogResult result = fbdDefaultSave.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSaveLocation.Text = fbdDefaultSave.SelectedPath;
            }

        }

        private void btnBrowseBackupLocation_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBackupLocation.Text)) { fbdDefaultSave.SelectedPath = txtBackupLocation.Text; }
            DialogResult result = fbdDefaultSave.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtBackupLocation.Text = fbdDefaultSave.SelectedPath;
            }

        }
    }
}
