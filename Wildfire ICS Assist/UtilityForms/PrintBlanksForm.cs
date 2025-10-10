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
using WF_ICS_ClassLibrary.Models.GeneralModels;
using WildfireICSDesktopServices;
using WildfireICSDesktopServices.PDFExportServiceClasses;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class PrintBlanksForm : BaseForm
    {
        public PrintBlanksForm()
        {
            InitializeComponent();
            dgvForms.AutoGenerateColumns = false;
        }

        private void PrintBlanksForm_Load(object sender, EventArgs e)
        {
            List<ICSFormInformation> forms = ICSFormTools.GetAllForms();
            dgvForms.DataSource = forms.OrderBy(f => f.FormNumber).ThenBy(f => f.FormName).ToList();
            int maxPerForm = 20;
            foreach (DataGridViewRow row in dgvForms.Rows)
            {
                int[] qty = new int[maxPerForm];
                for (int i = 0; i < maxPerForm; i++) { qty[i] = i; }
                DataGridViewComboBoxCell cell = row.Cells["colQty"] as DataGridViewComboBoxCell;
                cell.DataSource = qty;
                cell.ValueType = typeof(int);
                cell.Value = 0;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //set the default folder for savefiledialog1 to downloads
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filepath = saveFileDialog1.FileName;
                

                List<Tuple<string, int>> formsToPrint = new List<Tuple<string, int>>();
                foreach (DataGridViewRow row in dgvForms.Rows)
                {
                    int qty = 0;
                    if (row.Cells["colQty"].Value != null)
                    {
                        int.TryParse(row.Cells["colQty"].Value.ToString(), out qty);
                    }
                    if (qty > 0)
                    {
                        string formName = row.Cells["colFormNumber"].Value.ToString();
                        formsToPrint.Add(new Tuple<string, int>(formName, qty));
                    }
                }

                string incidentName = null; string incidentNumber = null;
                OperationalPeriod period = null;

                if (chkAddIncidentInfoToForms.Checked) { incidentName = Program.CurrentIncident.TaskName; incidentNumber = Program.CurrentIncident.TaskNumber; }
                if (chkAddOpInfo.Checked) { period = Program.CurrentOpPeriodDetails.Clone(); }

                List<byte[]> pdfBytes = BlankFormExportService.createBlankFormPDFs(formsToPrint, period, incidentName, incidentNumber);

                if (pdfBytes != null && pdfBytes.Count > 0)
                {
                    byte[] fullFile = FileAccessClasses.concatAndAddContent(pdfBytes);
                    try
                    {
                        File.WriteAllBytes(filepath, fullFile);
                        try
                        {

                            System.Diagnostics.Process.Start(filepath);
                        }
                        catch (Exception ex)
                        {
                            LgMessageBox.Show("There was an error trying to save " + filepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString());
                        }
                    }
                    catch (Exception)
                    {
                        LgMessageBox.Show("There was an error trying to save " + filepath + " please verify the path is accessible.");
                    }
                }
            }
        }
    }
}
