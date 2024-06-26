﻿using Microsoft.VisualBasic.FileIO;
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
            List<string> columns = WF_ICS_ClassLibrary.Utilities.ExcelColumns.getExcelColumns(true);
            cboFirst.DataSource = new List<string>(columns);
            cboMiddle.DataSource = new List<string>(columns);
            cboLast.DataSource = new List<string>(columns);
            cboAccom.DataSource = new List<string>(columns);
            cboPronoun.DataSource = new List<string>(columns);
            cboCountry.DataSource = new List<string>(columns);
            cboProvince.DataSource = new List<string>(columns);
            cboAgency.DataSource = new List<string>(columns);
            cboContractor.DataSource = new List<string>(columns);
            cboHomeUnit.DataSource = new List<string>(columns);
            cboKind.DataSource = new List<string>(columns);
            cboType.DataSource = new List<string>(columns);
            cboCell.DataSource = new List<string>(columns);
            cboEmail.DataSource = new List<string>(columns);
            cboCallsign.DataSource = new List<string>(columns);
            cboDietary.DataSource = new List<string>(columns);
            cboAllergies.DataSource = new List<string>(columns);
            cboEmergerncy.DataSource = new List<string>(columns);
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

                            if (lower.Equals("First Name", StringComparison.InvariantCultureIgnoreCase)) { cboFirst.SelectedIndex = x; }
                            else if (lower.Equals("First", StringComparison.InvariantCultureIgnoreCase)) { cboFirst.SelectedIndex = x; }
                            else if (lower.Contains("middle")) { cboMiddle.SelectedIndex = x; }
                            else if (lower.Equals("Last Name", StringComparison.InvariantCultureIgnoreCase)) { cboLast.SelectedIndex = x; }
                            else if (lower.Equals("Last", StringComparison.InvariantCultureIgnoreCase)) { cboLast.SelectedIndex = x; }
                            else if (lower.Contains("pronoun")) { cboPronoun.SelectedIndex = x; }
                            else if (lower.Equals("Agency", StringComparison.InvariantCultureIgnoreCase)) { cboAgency.SelectedIndex = x; }
                            else if (lower.Equals("Organization", StringComparison.InvariantCultureIgnoreCase)) { cboAgency.SelectedIndex = x; }

                            else if (lower.Contains("email")) { cboEmail.SelectedIndex = x; }

                            else if (lower.Contains("phone")) { cboCell.SelectedIndex = x; }
                            else if (lower.Contains("cell")) { cboCell.SelectedIndex = x; }

                            else if (lower.Contains("country")) { cboCountry.SelectedIndex = x; }
                            else if (lower.Contains("province")) { cboProvince.SelectedIndex = x; }
                            else if (lower.Contains("territory")) { cboProvince.SelectedIndex = x; }

                            else if (lower.Contains("kind")) { cboKind.SelectedIndex = x; }
                            else if (lower.Contains("type")) { cboType.SelectedIndex = x; }

                            else if (lower.Equals("home unit", StringComparison.InvariantCultureIgnoreCase)) { cboHomeUnit.SelectedIndex = x; }
                            else if (lower.Contains("home unit")) { cboHomeUnit.SelectedIndex = x; }
                            else if (lower.Equals("home agency", StringComparison.InvariantCultureIgnoreCase)) { cboHomeUnit.SelectedIndex = x; }

                            else if (lower.Contains("call sign")) { cboCallsign.SelectedIndex = x; }
                            else if (lower.Contains("callsign")) { cboCallsign.SelectedIndex = x; }

                            else if (lower.Contains("allergies")) { cboAllergies.SelectedIndex = x; }
                            else if (lower.Contains("dietary")) { cboDietary.SelectedIndex = x; }
                            else if (lower.Contains("emergency")) { cboEmergerncy.SelectedIndex = x; }
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
            int firstCol = cboFirst.SelectedIndex > 0 ? cboFirst.SelectedIndex-1 : -1;
            int lastCol = cboLast.SelectedIndex > 0 ? cboLast.SelectedIndex - 1 : -1;
            int accomCol = cboAccom.SelectedIndex > 0 ? cboAccom.SelectedIndex - 1 : -1;
            int pronounCol = cboPronoun.SelectedIndex > 0 ? cboPronoun.SelectedIndex - 1 : -1;
            int middCol = cboMiddle.SelectedIndex > 0 ? cboMiddle.SelectedIndex - 1 : -1;
            int provCol = cboProvince.SelectedIndex > 0 ? cboProvince.SelectedIndex - 1 : -1;
            int countryCol = cboCountry.SelectedIndex > 0 ? cboCountry.SelectedIndex - 1 : -1;
            int agencyCol = cboAgency.SelectedIndex > 0 ? cboAgency.SelectedIndex - 1 : -1;
            int contractorCol = cboContractor.SelectedIndex > 0 ? cboContractor.SelectedIndex - 1 : -1;
            int homeCol = cboHomeUnit.SelectedIndex > 0 ? cboHomeUnit.SelectedIndex - 1 : -1;
            int kindCol = cboKind.SelectedIndex > 0 ? cboKind.SelectedIndex - 1 : -1;
            int typeCol = cboType.SelectedIndex > 0 ? cboType.SelectedIndex - 1 : -1;
            int cellCol = cboCell.SelectedIndex > 0 ? cboCell.SelectedIndex - 1 : -1;
            int emailCol = cboEmail.SelectedIndex > 0 ? cboEmail.SelectedIndex - 1 : -1;
            int callsignCol = cboCallsign.SelectedIndex > 0 ? cboCallsign.SelectedIndex - 1 : -1;
            int dietaryCol = cboDietary.SelectedIndex > 0 ? cboDietary.SelectedIndex - 1 : -1;
            int allergyCol = cboAllergies.SelectedIndex > 0 ? cboAllergies.SelectedIndex - 1 : -1;
            int emergCol = cboEmergerncy.SelectedIndex > 0 ? cboEmergerncy.SelectedIndex - 1 : -1;

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

                    Personnel p = new Personnel();
                    if (firstCol >= 0 && firstCol < fields.Length) { p.FirstName = fields[firstCol]; }
                    if (middCol >= 0 && middCol < fields.Length) { p.MiddleInitial = fields[middCol]; }
                    if (lastCol >= 0 && lastCol < fields.Length) { p.LastName = fields[lastCol]; }
                    if (pronounCol >= 0 && pronounCol < fields.Length) { p.Pronouns = fields[pronounCol]; }
                    if (callsignCol >= 0 && callsignCol < fields.Length) { p.CallSign = fields[callsignCol]; }

                    if (cellCol >= 0 && cellCol < fields.Length) { p.CellphoneNumber = fields[cellCol]; }

                    p.MemberActive = true;

                    if (emailCol >= 0 && emailCol < fields.Length) { p.Email = fields[emailCol]; }
                    //member.Dietary = fields[dietaryCol];

                    if (countryCol >= 0 && countryCol < fields.Length) { p.HomeCountry = fields[countryCol]; }
                    if (kindCol >= 0 && kindCol < fields.Length) { p.Kind = fields[kindCol]; }
                    if (typeCol >= 0 && typeCol < fields.Length) { p.Type = fields[typeCol]; }
                    if (emergCol >= 0 && emergCol < fields.Length) { p.EmergencyContact = fields[emergCol]; }

                    if (accomCol >= 0 && accomCol < fields.Length)
                    {
                        string xlAccom = fields[accomCol];
                        if (xlAccom != null && (xlAccom.Contains("female") || xlAccom.Contains("woman"))) { p.AccomodationPreference = "Female-Only"; }
                        else if (xlAccom != null && (xlAccom.Contains("male") || xlAccom.Contains("man"))) { p.AccomodationPreference = "Male-Only"; }
                        else { p.AccomodationPreference = "Not Gender-Restricted"; }
                    }

                    if (provCol >= 0 && provCol < fields.Length)
                    {
                        string xlProvince = fields[provCol];
                        if (string.IsNullOrEmpty(xlProvince)) { p.HomeProvinceID = new Guid(cboDefaultProvince.SelectedValue.ToString()); }
                        else
                        {
                            List<Province> provinces = ProvinceTools.GetProvinces();
                            if (provinces.Any(o => o.ProvinceName.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase) || o.ProvinceShort.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase)))
                            {
                                p.HomeProvinceID = provinces.First(o => o.ProvinceName.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase) || o.ProvinceShort.Equals(xlProvince, StringComparison.InvariantCultureIgnoreCase)).ProvinceGUID;
                            }
                            else { p.HomeProvinceID = new Guid(cboDefaultProvince.SelectedValue.ToString()); }

                        }
                    }
                    else { p.HomeProvinceID = new Guid(cboDefaultProvince.SelectedValue.ToString()); }

                    if (agencyCol >= 0 && agencyCol < fields.Length)
                    {
                        string xlAgency = fields[agencyCol];
                        if (string.IsNullOrEmpty(xlAgency)) { p.Agency = cboDefaultAgency.SelectedValue.ToString(); }
                        else
                        {
                            //this will use an existing agency if there's a case-insensitive match. that way we don't have duplciates with different capitalization.
                            if (agencies.Any(o => xlAgency.Equals(o, StringComparison.InvariantCultureIgnoreCase))) { p.Agency = agencies.First(o => xlAgency.Equals(o, StringComparison.InvariantCultureIgnoreCase)); }
                            else { p.Agency = xlAgency; }
                        }
                    }


                    if (homeCol >= 0 && homeCol < fields.Length)
                    {
                        string xlHome = fields[homeCol];
                        if (string.IsNullOrEmpty(xlHome)) { p.HomeUnit = cboDefaultAgency.SelectedValue.ToString(); }
                        else
                        {
                            //this will use an existing agency if there's a case-insensitive match. that way we don't have duplciates with different capitalization.
                            if (agencies.Any(o => xlHome.Equals(o, StringComparison.InvariantCultureIgnoreCase))) { p.HomeUnit = agencies.First(o => xlHome.Equals(o, StringComparison.InvariantCultureIgnoreCase)); }
                            else { p.HomeUnit = xlHome; }
                        }
                    }
                    if (contractorCol >= 0 && contractorCol < fields.Length)
                    {
                        string xlContract = fields[contractorCol];
                        if (xlContract.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || xlContract.Equals("y", StringComparison.InvariantCultureIgnoreCase) || xlContract.Equals("1", StringComparison.InvariantCultureIgnoreCase) || xlContract.Equals("true", StringComparison.InvariantCultureIgnoreCase)) { p.IsContractor = true; }
                        else { p.IsContractor = false; }
                    }
                    if (allergyCol >= 0 && allergyCol < fields.Length)
                    {
                        string xlAllergy = fields[allergyCol];
                        if (xlAllergy.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || xlAllergy.Equals("y", StringComparison.InvariantCultureIgnoreCase) || xlAllergy.Equals("1", StringComparison.InvariantCultureIgnoreCase) || xlAllergy.Equals("true", StringComparison.InvariantCultureIgnoreCase)) { p.HasAllergies = true; }
                        else { p.HasAllergies = false; }
                    }
                    if (dietaryCol >= 0 && dietaryCol < fields.Length)
                    {
                        string xlDietary = fields[dietaryCol];
                        if (xlDietary.Equals("yes", StringComparison.InvariantCultureIgnoreCase) || xlDietary.Equals("y", StringComparison.InvariantCultureIgnoreCase) || xlDietary.Equals("1", StringComparison.InvariantCultureIgnoreCase) || xlDietary.Equals("true", StringComparison.InvariantCultureIgnoreCase)) { p.HasAllergies = true; }
                        else { p.HasAllergies = false; }

                    }

                    if (!string.IsNullOrEmpty(p.Name)) { importedMembers.Add(p); }

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
                        dup.FirstName = member.FirstName;
                        dup.MiddleInitial = member.MiddleInitial;
                        dup.Pronouns = member.Pronouns;
                        dup.AccomodationPreference = member.AccomodationPreference;
                        dup.HomeCountry = member.HomeCountry;
                        dup.HomeProvinceID = member.HomeProvinceID;
                        dup.Agency = member.Agency;
                        dup.IsContractor = member.IsContractor;
                        dup.Kind = member.Kind;
                        dup.Type = member.Type;
                        dup.CellphoneNumber = member.CellphoneNumber;
                        dup.Email = member.Email;
                        dup.CallSign    = member.CallSign;
                        dup.HasDietaryRestrictions = member.HasDietaryRestrictions;
                        dup.HasAllergies    = member.HasAllergies;
                        dup.EmergencyContact = member.EmergencyContact;
                        dup.HomeUnit = member.HomeUnit;
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

