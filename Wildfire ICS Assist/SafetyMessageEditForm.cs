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
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class SafetyMessageEditForm : Form
    {
        private SafetyMessage _selectedMessage = null;
        public SafetyMessage selectedMessage { get => _selectedMessage; set { _selectedMessage = value; LoadMessage(); } }

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
        }
        public SafetyMessageEditForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground;

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

        private void txtSummaryLine_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSummaryLine.Text.Trim())) { txtSummaryLine.BackColor = Program.ErrorColor; }
            else { txtSummaryLine.BackColor = Program.GoodColor; }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text.Trim())) { txtMessage.BackColor = Program.ErrorColor; }
            else { txtMessage.BackColor = Program.GoodColor; }

        }

        private void SafetyMessageEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            selectPhoto();
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureRemoveImage, Properties.Resources.SureRemoveImageTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                selectedMessage.ImageBytes = string.Empty;


            }
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
                        newFileName = Program.CurrentIncident.IncidentIdentifier;

                        newFileName += "-" + uniqueNumber;
                        newFilePath = Path.Combine(FileAccessClasses.getWritablePath(Program.CurrentIncident), newFileName);
                    }

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
                    MessageBox.Show("There was an error selecting that image, please report the following to technical support: " + ex.ToString());
                }
            }
        }
    }
}
