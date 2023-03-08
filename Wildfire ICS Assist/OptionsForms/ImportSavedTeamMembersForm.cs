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
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class ImportSavedTeamMembersForm : Form
    {
        private int _ImportedCount = 0;
        public int ImportedCount { get => _ImportedCount; set => _ImportedCount = value; }
        private int _UpdatedCount = 0;
        public int UpdatedCount { get => _UpdatedCount; set => _UpdatedCount = value; }

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
            if (defaultProvince != null && provinces.Any(o => o.ProvinceGUID == defaultProvince.ProvinceGUID)) { cboDefaultProvince.SelectedValue = defaultProvince.ProvinceGUID; }
        }

        private void PopulateDefaultAgency()
        {
            List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
            List<string> incidentAgencies = Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.Agency)).GroupBy(o => o.Agency).Select(o => o.First().Agency).ToList();
            incidentAgencies.AddRange(Program.CurrentIncident.IncidentPersonnel.Where(o => !string.IsNullOrEmpty(o.HomeUnit)).GroupBy(o => o.HomeUnit).Select(o => o.First().HomeUnit));
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
            try
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
                    catch (Exception ex) { }
                }
            }
            catch (Exception) { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFilePath.Text))
            {
                if (ImportMemberFromFile(txtFilePath.Text))
                {
                    string importMessage = Properties.Resources.MembersImported;
                    importMessage = importMessage.Replace("[IMPORT]", ImportedCount.ToString()).Replace("[UPDATE]", UpdatedCount.ToString());
                    MessageBox.Show(importMessage);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.NoMembersImported);
                    
                }

            }
        }

        private bool ImportMemberFromFile(string path)
        {
            List<Personnel> importedMembers = new List<Personnel>();
            int nameCol = cboName.SelectedIndex;
            int agencyCol = cboAgency.SelectedIndex;
            int emailCol = cboEmail.SelectedIndex;
            int phoneCol = cboPhone.SelectedIndex;
            int provinceCol = cboProvince.SelectedIndex;
            int qualCol = cboOtherQualifications.SelectedIndex;
            int homeCol = cboHomeAgency.SelectedIndex;
            int vegCol = cboVegetarian.SelectedIndex;
            int noglutenCol = cboNoGluten.SelectedIndex;
            int dietaryCol = cboOtherDietary.SelectedIndex;

            List<string> agencies = (List<string>)Program.generalOptionsService.GetOptionsValue("Agencies");
            agencies = agencies.OrderBy(o => o).ToList();


            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool firstLine = true;

                while (!parser.EndOfData)
                {

                    string[] fields = parser.ReadFields();
                    if (firstLine)
                    {
                        firstLine = false;
                        continue;
                    }

                    //Need a check for the header row

                    Personnel member = new Personnel();
                    member.Name = fields[nameCol];
                    member.CellphoneNumber = fields[phoneCol];
                    member.MemberActive = true;
                    member.Email = fields[emailCol];
                    //member.Dietary = fields[dietaryCol];

                    string xlProvince = fields[provinceCol];
                    if (string.IsNullOrEmpty(xlProvince)) { member.HomeProvinceID = new Guid(cboDefaultProvince.SelectedValue.ToString()); }
                    else
                    {
                        List<Province> provinces = ProvinceTools.GetProvinces();
                        if (provinces.Any(o => o.ProvinceName.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase) || o.ProvinceShort.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            member.HomeProvinceID = provinces.First(o => o.ProvinceName.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase) || o.ProvinceShort.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase)).ProvinceGUID;
                        }
                        else { member.HomeProvinceID = new Guid(cboDefaultProvince.SelectedValue.ToString()); }

                    }


                    string xlAgency = fields[agencyCol];
                    if (string.IsNullOrEmpty(xlAgency)) { member.Agency = cboDefaultAgency.SelectedValue.ToString(); }
                    else
                    {
                        //this will use an existing agency if there's a case-insensitive match. that way we don't have duplciates with different capitalization.
                        if (agencies.Any(o => xlAgency.Equals(o, StringComparison.InvariantCultureIgnoreCase))) { member.Agency = agencies.First(o => xlAgency.Equals(o, StringComparison.InvariantCultureIgnoreCase)); }
                        else { member.Agency = xlAgency; }
                    }
                    string xlHome = fields[homeCol];
                    if (string.IsNullOrEmpty(xlHome)) { member.HomeUnit = cboDefaultAgency.SelectedValue.ToString(); }
                    else
                    {
                        //this will use an existing agency if there's a case-insensitive match. that way we don't have duplciates with different capitalization.
                        if (agencies.Any(o => xlHome.Equals(o, StringComparison.InvariantCultureIgnoreCase))) { member.HomeUnit = agencies.First(o => xlHome.Equals(o, StringComparison.InvariantCultureIgnoreCase)); }
                        else { member.HomeUnit = xlHome; }
                    }


                    /*
                    string xlVeg = fields[vegCol];
                    if (xlVeg.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || xlVeg.Equals("y", StringComparison.InvariantCultureIgnoreCase) || xlVeg.Equals("1", StringComparison.InvariantCultureIgnoreCase) || xlVeg.Equals("true", StringComparison.InvariantCultureIgnoreCase)) { member.Vegetarian = true; }
                    else { member.Vegetarian = false; }

                    string xNoGl = fields[noglutenCol];
                    if (xNoGl.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || xNoGl.Equals("y", StringComparison.InvariantCultureIgnoreCase) || xNoGl.Equals("1", StringComparison.InvariantCultureIgnoreCase) || xNoGl.Equals("true", StringComparison.InvariantCultureIgnoreCase)) { member.NoGluten = true; }
                    else { member.NoGluten = false; }
                    */
                    if (!string.IsNullOrEmpty(member.Name)) { importedMembers.Add(member); }
                }



            }//end of parser


            List<Personnel> savedMembers = (List<Personnel>)Program.generalOptionsService.GetOptionsValue("TeamMembers");

            foreach (Personnel member in importedMembers)
            {
                if (chkUpdateWhenPossible.Checked)
                {
                    List<Personnel> possibleDuplicates = savedMembers.Where(o => ((!string.IsNullOrEmpty(member.Email) && !string.IsNullOrEmpty(o.Email) && o.Email.Equals(member.Email, StringComparison.InvariantCultureIgnoreCase)) || (!string.IsNullOrEmpty(member.CellphoneNumber) && !string.IsNullOrEmpty(o.CellphoneNumber) && o.CellphoneNumber.Equals(member.CellphoneNumber, StringComparison.InvariantCultureIgnoreCase)) || ((o.Agency == null && member.Agency == null) || (!string.IsNullOrEmpty(member.Agency) && !string.IsNullOrEmpty(o.Agency) && o.Agency.Equals(member.Agency, StringComparison.InvariantCultureIgnoreCase)))) && (o.Name.Equals(member.Name, StringComparison.InvariantCultureIgnoreCase))).ToList();
                    //If there is more than one duplicate, best to just import this as new rather than trying to decide which one to replace
                    if (possibleDuplicates.Count == 1 || possibleDuplicates.Where(o=>o.MemberActive).Count() == 1)
                    {
                        Personnel dup = null;
                        if (possibleDuplicates.Count == 1) { dup = possibleDuplicates[0]; }
                        else { dup = possibleDuplicates.First(o => o.MemberActive); }
                        dup.MemberActive = true;
                        dup.Name = member.Name;
                        dup.CellphoneNumber = member.CellphoneNumber;

                        dup.Email = member.Email;
                        
                        dup.Agency = member.Agency;
                        dup.HomeUnit = member.HomeUnit;
                        dup.HomeProvinceID = member.HomeProvinceID;
                        Program.generalOptionsService.UpserOptionValue(dup, "TeamMember");
                        UpdatedCount++;

                    }
                    else
                    {
                        Program.generalOptionsService.UpserOptionValue(member, "TeamMember");
                        ImportedCount += 1;

                    }
                }
                else
                {
                    Program.generalOptionsService.UpserOptionValue(member, "TeamMember");
                    ImportedCount += 1;
                }
            }

            if(ImportedCount + UpdatedCount > 0) { return true; }
            else { return false; }
        }

        private void btnCSVHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("CSV"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnColumnHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("MemberImportColumns"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }

        }

        private void btnUpdateExistingHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("UpdateExisting"))
            {

                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void btnDefaultHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("DefaultProvAgency"))
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

