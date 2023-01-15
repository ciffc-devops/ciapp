using Microsoft.VisualBasic.FileIO;
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

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class ImportSavedTeamMembersForm : Form
    {
        public ImportSavedTeamMembersForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void ImportSavedTeamMembersForm_Load(object sender, EventArgs e)
        {
            setExcelColumnNames();
            PopulateDefaultAgency();
            PopulateProvinces();
        }

        private void PopulateProvinces()
        {
            List<Province> provinces = ProvinceTools.GetProvinces();
            cboDefaultProvince.DataSource = provinces;
            cboDefaultProvince.DisplayMember = "ProvinceName";
            cboDefaultProvince.ValueMember = "ProvinceGUID";
            Province defaultProvince = Program.generalOptionsService.GetOptionsValue("Province") as Province;
            if(defaultProvince != null && provinces.Any(o=>o.ProvinceGUID == defaultProvince.ProvinceGUID)) { cboDefaultProvince.SelectedValue = defaultProvince.ProvinceGUID; }
        }

        private void PopulateDefaultAgency()
        {
            List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
            List<string> incidentAgencies = Program.CurrentIncident.TaskTeamMembers.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();
            incidentAgencies.AddRange(Program.CurrentIncident.TaskTeamMembers.Where(o => !string.IsNullOrEmpty(o.HomeAgency)).GroupBy(o => o.HomeAgency).Select(o => o.First().HomeAgency));
            agencies.AddRange(incidentAgencies.Distinct());
            agencies = agencies.OrderBy(o => o).ToList();
            agencies.Insert(0, string.Empty);

            cboDefaultAgency.DataSource = agencies;

        }

        private void setExcelColumnNames()
        {
            List<string> columns = WF_ICS_ClassLibrary.Utilities.ExcelColumns.getExcelColumns();
            cboName.DataSource = new List<string>(columns);
            cboAgency.DataSource = new List<string>(columns);
            cboEmail.DataSource = new List<string>(columns);
            cboPhone.DataSource = new List<string>(columns);
                cboProvince.DataSource = new List<string>(columns); 
            cboOtherQualifications.DataSource = new List<string>(columns);
            cboHomeAgency.DataSource = new List<string>(columns);   
            cboVegetarian.DataSource = new List<string>(columns);
            cboNoGluten.DataSource = new List<string>(columns);
            cboOtherDietary.DataSource = new List<string>(columns);

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                txtFilePath.Text = openFileDialog1.FileName;
                guessAtColumns(openFileDialog1.FileName);
                btnSave.Enabled = true;
            } 
        }

        private void guessAtColumns(string filePath)
        {
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                try
                {
                    string[] fields = parser.ReadFields();
                    for (int x = 0; x < fields.Length; x++)
                    {
                        string lower = fields[x].ToLower();

                        if (lower.Equals("Name", StringComparison.InvariantCultureIgnoreCase)) { cboName.SelectedIndex = x; }
                        else if (lower.Equals("Full Name", StringComparison.InvariantCultureIgnoreCase)) { cboName.SelectedIndex = x; }

                        else if (lower.Equals("Agency", StringComparison.InvariantCultureIgnoreCase)) { cboAgency.SelectedIndex = x; }
                        else if (lower.Equals("Organization", StringComparison.InvariantCultureIgnoreCase)) { cboAgency.SelectedIndex = x; }

                        else if (lower.Contains("email")) { cboEmail.SelectedIndex = x; }
                        
                        else if (lower.Contains("phone")) { cboPhone.SelectedIndex = x; }

                        else if (lower.Contains("province")) { cboProvince.SelectedIndex = x; }
                        else if (lower.Contains("territory")) { cboProvince.SelectedIndex = x; }

                        else if (lower.Contains("qualification")) { cboOtherQualifications.SelectedIndex = x; }
                        else if (lower.Contains("skills")) { cboOtherQualifications.SelectedIndex = x; }

                        else if (lower.Equals("home unit", StringComparison.InvariantCultureIgnoreCase)) { cboHomeAgency.SelectedIndex = x; }
                        else if (lower.Contains("home unit")) { cboHomeAgency.SelectedIndex = x; }
                        else if (lower.Equals("home agency", StringComparison.InvariantCultureIgnoreCase)) { cboHomeAgency.SelectedIndex = x; }

                        else if (lower.Contains("vegetarian")) { cboVegetarian.SelectedIndex = x; }
                        else if (lower.Contains("gluten")) { cboNoGluten.SelectedIndex = x; }
                        else if (lower.Contains("dietary")) { cboOtherDietary.SelectedIndex = x; }


                    }

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

