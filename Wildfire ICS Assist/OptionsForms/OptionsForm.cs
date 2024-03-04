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
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Networking;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class OptionsForm : Form
    {
        private List<DeviceInformation> allDevices = new List<DeviceInformation>();
        byte[] NewOrgLogo = null;

        public OptionsForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void LoadICSRoles()
        {
            List<ICSRole> roles = OrgChartTools.GetBlankPrimaryRoles();
            cboDefaultICSRole.DataSource = roles;
            cboDefaultICSRole.DisplayMember = "RoleNameForDropdown";
            cboDefaultICSRole.ValueMember = "RoleID";

        }

        private void LoadProvinces()
        {
            cboDefaultProvince.DataSource = ProvinceTools.GetProvinces();
            cboDefaultProvince.DisplayMember = "ProvinceName";
            cboDefaultProvince.ValueMember = "ProvinceGUID";
        }
        
      
        private void LoadDateOptions()
        {
            List<DateFormatOption> options = DateTools.GetDateFormatOptions();
            cboDateFormat.DataSource = options;
            cboDateFormat.DisplayMember = "DisplayNameWithExample";
            cboDateFormat.ValueMember = "Format";
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
            rbNumbersOnly.Checked = !options.AllowStringTaskNumber; rbNumbersOrLetters.Checked = !rbNumbersOnly.Checked;
            if(options.DefaultProvince != null && options.DefaultProvince.ProvinceGUID != Guid.Empty) { cboDefaultProvince.SelectedValue = options.DefaultProvince.ProvinceGUID; }
            if (!string.IsNullOrEmpty(options.DateFormat)) { cboDateFormat.SelectedValue = options.DateFormat; }
            numRedResourceTimeoutDays.Value = options.RedResourceTimeoutDays;
            numYellowResourceTimeoutDays.Value = options.YellowResourceTimeoutDays;
            if (options.OrganizationLogo != null)
            {
                Image img = options.OrganizationLogo.getImageFromBytes();
                picReportLogo.Image = img;
            } else
            {
                Image img = Properties.Resources.CIAPP_LOGO_v3;
                picReportLogo.Image = img;
            }
            if (string.IsNullOrEmpty(options.OrganizationName)) { txtOrganizationName.SetText("Canadian Interagency Forest Fire Centre"); }
            else { txtOrganizationName.SetText(options.OrganizationName); }


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



            //Network
            foreach (DeviceInformation info in options.SavedNetworkDeviceList.Where(o => o.TrustDevice))
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
            LoadProvinces();
            LoadDateOptions();
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
                    options.AllowStringTaskNumber = !rbNumbersOnly.Checked;
                    Province p = new Province(new Guid(cboDefaultProvince.SelectedValue.ToString())); ;
                    options.DefaultProvince = p;
                    options.DateFormat = cboDateFormat.SelectedValue.ToString();
                    Globals.DateFormat = options.DateFormat;
                    options.YellowResourceTimeoutDays = Convert.ToInt32( numYellowResourceTimeoutDays.Value);
                    options.RedResourceTimeoutDays = Convert.ToInt32(numRedResourceTimeoutDays.Value);
                    if (NewOrgLogo != null) { Program.generalOptionsService.UpserOptionValue(NewOrgLogo, "OrganizationLogo"); }
                    options.OrganizationName = txtOrganizationName.Text;


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




                    //Network
                    options.SavedNetworkDeviceList = allDevices;

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
            if (!txtOrganizationName.IsValid) { return false; }

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

        private void tbGeneral_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControlExt.tabControlCustomColor_DrawItem(sender, e);

        }

        private void btnChangeLogo_Click(object sender, EventArgs e)
        {
            selectPhoto();

        }

        private void selectPhoto()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                //they've chosen a file, try to open it.
                try
                {
                    FileInfo file = new FileInfo(openFileDialog1.FileName);



                    System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
                    Bitmap newImage = new Bitmap(image);
                    long maxFileSize = 200000;
                    if (file.Length > maxFileSize)
                    {
                        long factor = (file.Length + (maxFileSize - 1)) / maxFileSize;

                        int newh = image.Height / (int)factor;
                        int neww = image.Width / (int)factor;
                        newImage = image.ResizeImage(neww, newh);

                    }



                    image.Dispose();
                    NewOrgLogo = newImage.BytesFromImage();

                    picReportLogo.Image = newImage;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error selecting that image, please report the following to technical support: " + ex.ToString());
                }
            }
        }

        private void btnRemoveLogo_Click(object sender, EventArgs e)
        {
            System.Drawing.Image img = Properties.Resources.CIAPP_LOGO_v3;
            NewOrgLogo = img.BytesFromImage();
            picReportLogo.Image = img;

        }
    }
}
