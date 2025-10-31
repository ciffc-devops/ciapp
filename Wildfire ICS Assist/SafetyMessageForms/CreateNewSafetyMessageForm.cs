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
using System.Windows.Interop;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist.SafetyMessageForms
{
    public partial class CreateNewSafetyMessageForm : BaseForm
    {
        private SafetyMessage _selectedMessage = null;
        public SafetyMessage selectedMessage { get => _selectedMessage; set { _selectedMessage = value; LoadMessage(); } }
        public bool SaveForLater { get => chkSaveForLater.Checked; }
        List<CollapsiblePanel> collapsiblePanelList;
        public CreateNewSafetyMessageForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);
            collapsiblePanelList = new List<CollapsiblePanel>();
            collapsiblePanelList.Add(collapsiblePanel1);
            collapsiblePanelList.Add(prepAndApprovePanel1);
            foreach(TabPage tp in wizardPages1.TabPages)
            {
                tp.BackColor = Program.FormBackgroundColor;
            }
            pnlTemplatePreview.BackColor = Program.AccentColor;
            pnlPrevOpPreview.BackColor = Program.AccentColor;

        }

        private void CreateNewSafetyMessageForm_Load(object sender, EventArgs e)
        {
            prepAndApprovePanel1.ApprovedByChanged += PrepAndApprovePanel1_ApprovedByChanged; ;
            prepAndApprovePanel1.PreparedByChanged += PrepAndApprovePanel1_PreparedByChanged; ; ;

            foreach (CollapsiblePanel p in collapsiblePanelList)
            {
                p.Collapse();
                p.PanelExpanded += HandlePanelExpanded;
                p.PanelCollapsed += HandlePanelCollapsed;

            }
            BuildOpPeriodComboBox();
            BuildDataList();

        }

        private void BuildDataList()
        {
            cboSaved.DataSource = null;
            List<SafetyMessage> list = (List<SafetyMessage>)Program.generalOptionsService.GetOptionsValue("safetyMessages");
            list = list.Where(o => o.Active).ToList();
            if(Program.CurrentTask.allSafetyMessages.Any(o=>o.Active && o.OpPeriod == Program.CurrentOpPeriod))
            {
                list = list.Where(o => !Program.CurrentIncident.allSafetyMessages.Any(m => m.OpPeriod == Program.CurrentOpPeriod && m.SafetyTemplateID == o.SafetyTemplateID && m.Active)).ToList();
            }

            list = list.OrderBy(o => o.SummaryLine).ToList();
            cboSaved.DataSource = list;
            cboSaved.DropDownWidth = cboSaved.GetDropDownWidth();

            if (list.Count <= 0) {  btnFromTemplate.Enabled = false; }
        }

        private void BuildOpPeriodComboBox()
        {
            cboOpPeriod.DisplayMember = "DisplayName";
            cboOpPeriod.ValueMember = "PeriodNumber";

            List<OperationalPeriod> periods = Program.CurrentIncident.AllOperationalPeriods.Where(o => o.Active && o.PeriodNumber != Program.CurrentOpPeriod).OrderBy(o => o.PeriodStart).ToList();
            cboOpPeriod.DataSource = periods;
            cboOpPeriod.DropDownWidth = cboOpPeriod.GetDropDownWidth();
            if(cboOpPeriod.SelectedItem != null)
            {
                BuildPrevOpMessageList((cboOpPeriod.SelectedItem as OperationalPeriod).PeriodNumber);
            }
        }

        private void BuildPrevOpMessageList(int OpPeriodNumber)
        {
            

            cboCopyFromOpPlan.DataSource = null;
            List<SafetyMessage> list = Program.CurrentIncident.allSafetyMessages.Where(o=>o.OpPeriod == OpPeriodNumber && o.Active).OrderBy(o => o.SummaryLine).ToList();
            list = list.Where(o => o.Active && !Program.CurrentIncident.allSafetyMessages.Any(m => m.OpPeriod == Program.CurrentOpPeriod && m.SafetyTemplateID == o.SafetyTemplateID && m.Active)).OrderBy(o => o.SummaryLine).ToList();
            cboCopyFromOpPlan.DataSource = list;
            cboCopyFromOpPlan.DisplayMember = "SummaryLine";
            cboCopyFromOpPlan.ValueMember = "ID";
            cboCopyFromOpPlan.DropDownWidth = cboCopyFromOpPlan.GetDropDownWidth();

            if (list.Count <= 0) { btnSelectPrevOpPlan.Enabled = false; }
        }

        private void LoadMessage()
        {
            txtSummaryLine.Text = selectedMessage.SummaryLine;
            if (!string.IsNullOrEmpty(selectedMessage.Message)) { txtMessage.Text = selectedMessage.Message.Replace("\n", Environment.NewLine); }
            else { txtMessage.Text = string.Empty; }
            txtNewSitePlanLocation.Text = selectedMessage.SitePlanLocation;
            chkNewSitePlanRequired.Checked = selectedMessage.SitePlanRequired;
            if (!string.IsNullOrEmpty(selectedMessage.ImageBytes))
            {
                Image img = selectedMessage.ImageBytes.getImageFromBytes();
                if (img != null) { picTitleImage.Image = img; }
            }
            prepAndApprovePanel1.SetPreparedBy(selectedMessage.PreparedByRoleID, selectedMessage.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(selectedMessage.ApprovedByRoleID, selectedMessage.DateApproved);
        }


        private void PrepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            selectedMessage.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
            selectedMessage.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;
        }

        private void PrepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            selectedMessage.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
            selectedMessage.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;
        }

        private void HandlePanelExpanded(object sender, EventArgs e)
        {
            if (sender != null && sender is CollapsiblePanel)
            {
                CollapsiblePanel c = (CollapsiblePanel)sender;
                c.Location = new Point(0, c.Location.Y);
                foreach (CollapsiblePanel cp in collapsiblePanelList)
                {
                    if (!cp.Name.Equals(c.Name))
                    {
                        cp.Collapse();
                        cp.Location = new Point(10, cp.Location.Y);
                    }
                }
            }
        }


        private void HandlePanelCollapsed(object sender, EventArgs e)
        {
            if (sender != null && sender is CollapsiblePanel)
            {
                CollapsiblePanel c = (CollapsiblePanel)sender;
                c.Location = new Point(10, c.Location.Y);


            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            selectedMessage.Message = string.Empty;
            selectedMessage.SummaryLine = string.Empty;
            selectedMessage.SitePlanRequired = false;
            selectedMessage.SitePlanLocation = string.Empty;
            selectedMessage.SafetyTemplateID = Guid.Empty;
            LoadMessage();

            wizardPages1.SelectedIndex = 3;
        }

        private void btnFromTemplate_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 1;
        }

       

        private void btnCopyFromPreviousOP_Click(object sender, EventArgs e)
        {
            wizardPages1.SelectedIndex = 2;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(wizardPages1.SelectedIndex == 0)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                wizardPages1.SelectedIndex = 0;
            }
        }

        private void wizardPages1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = wizardPages1.SelectedIndex == wizardPages1.TabPages.Count - 1;
            chkSaveForLater.Visible = btnSave.Visible;
            if (wizardPages1.SelectedIndex == 0) { btnCancel.Text = "Cancel"; }
            else { btnCancel.Text = "Back"; }
        }

        private void cboSaved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem != null)
            {
                SafetyMessage msg = (SafetyMessage)cboSaved.SelectedItem;
                txtTemplatePreviewMessage.Text = msg.Message;
                txtTemplatePreviewName.Text = msg.SummaryLine;
            }
        }

        private void btnUseTemplate_Click(object sender, EventArgs e)
        {
            if(cboSaved.SelectedItem != null)
            {
                SafetyMessage msg = (SafetyMessage)cboSaved.SelectedItem;
                selectedMessage.Message = msg.Message;
                selectedMessage.SummaryLine = msg.SummaryLine;
                selectedMessage.SitePlanRequired = msg.SitePlanRequired;
                selectedMessage.SitePlanLocation = msg.SitePlanLocation;
                selectedMessage.SafetyTemplateID = msg.SafetyTemplateID;
                wizardPages1.SelectedIndex = 3;
                LoadMessage();
            }
        }

        private void cboCopyFromOpPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCopyFromOpPlan.SelectedItem != null)
            {
                SafetyMessage msg = (SafetyMessage)cboCopyFromOpPlan.SelectedItem;
                txtPreviewPrevOpMessage.Text = msg.Message;
                txtPreviewPrevOpSubject.Text = msg.SummaryLine;
            }


        }

        private void btnSelectPrevOpPlan_Click(object sender, EventArgs e)
        {
            if (cboCopyFromOpPlan.SelectedItem != null)
            {
                SafetyMessage msg = (SafetyMessage)cboCopyFromOpPlan.SelectedItem;
                selectedMessage.Message = msg.Message;
                selectedMessage.SummaryLine = msg.SummaryLine;
                selectedMessage.SitePlanRequired = msg.SitePlanRequired;
                selectedMessage.SitePlanLocation = msg.SitePlanLocation;
                selectedMessage.SafetyTemplateID = msg.SafetyTemplateID;
                wizardPages1.SelectedIndex = 3;
                LoadMessage();
            }
        }

        private void cboOpPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOpPeriod.SelectedItem != null)
            {
                BuildPrevOpMessageList(((OperationalPeriod)cboOpPeriod.SelectedItem).PeriodNumber);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                selectedMessage.SummaryLine = txtSummaryLine.Text;

                selectedMessage.Message = txtMessage.Text;

                selectedMessage.SitePlanLocation = txtNewSitePlanLocation.Text;
                selectedMessage.SitePlanRequired = chkNewSitePlanRequired.Checked;
                //selectedMessage.Message = Regex.Replace(selectedMessage.Message, "(?<!\r)\n", "\r\n");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            bool isGood = true;
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; isGood = false; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }

            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; isGood = false; }
            else { txtMessage.BackColor = Program.GoodColor; }
            return isGood;
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            selectPhoto();
        }

        private void selectPhoto()
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            openFileDialog1.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                //they've chosen a file, try to open it.
                try
                {
                    FileInfo file = new FileInfo(openFileDialog1.FileName);

                    string newFileName = selectedMessage.SummaryLine;
                    if (string.IsNullOrEmpty(newFileName)) { newFileName = txtSummaryLine.Text; }
                    if (string.IsNullOrEmpty(newFileName)) { newFileName = selectedMessage.ID.ToString(); }
                    newFileName = newFileName.Sanitize();



                    string newFilePath = Program.CurrentIncident.FileName;
                    newFilePath = Path.Combine(FileAccessClasses.getWritablePath(Program.CurrentIncident), newFileName);

                    int uniqueNumber = 0;
                    while (File.Exists(newFilePath + file.Extension))
                    {
                        uniqueNumber += 1;
                        newFileName = Program.CurrentIncident.IncidentNameAndNumberForPath;

                        newFileName += "-" + uniqueNumber;
                        newFilePath = Path.Combine(FileAccessClasses.getWritablePath(Program.CurrentIncident), newFileName);
                    }
                    newFilePath = newFilePath + file.Extension;

                    System.Drawing.Image image = System.Drawing.Image.FromFile(file.FullName);
                    Bitmap newImage = new Bitmap(image);
                    long maxFileSize = 200000;
                    if (file.Length > maxFileSize)
                    {
                        long factor = (file.Length + (maxFileSize - 1)) / maxFileSize;

                        int newh = image.Height / (int)factor;
                        int neww = image.Width / (int)factor;
                        newImage = image.ResizeImage(neww, newh);
                        newImage.Save(newFilePath);
                    }
                    else
                    {
                        file.CopyTo(newFilePath);
                    }


                    image.Dispose();
                    selectedMessage.ImageBytes = newImage.BytesStringFromImage();
                    picTitleImage.Image = newImage;

                }
                catch (Exception ex)
                {
                    LgMessageBox.Show("There was an error selecting that image, please report the following to technical support: " + ex.ToString());
                }
            }
        }
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (LgMessageBox.Show(Properties.Resources.SureRemoveImage, Properties.Resources.SureRemoveImageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                selectedMessage.ImageBytes = string.Empty;
                picTitleImage.Image = null;

            }
        }

        private void txtSummaryLine_TextChanged(object sender, EventArgs e)
        {
            selectedMessage.SummaryLine = txtSummaryLine.Text;
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            selectedMessage.Message = txtMessage.Text;
        }

        private void chkNewSitePlanRequired_CheckedChanged(object sender, EventArgs e)
        {
            selectedMessage.SitePlanRequired = chkNewSitePlanRequired.Checked;
        }

        private void txtNewSitePlanLocation_TextChanged(object sender, EventArgs e)
        {
            selectedMessage.SitePlanLocation = txtNewSitePlanLocation.Text;
        }
    }
}
