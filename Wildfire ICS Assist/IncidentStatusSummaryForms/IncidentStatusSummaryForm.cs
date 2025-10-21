using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.IncidentStatusSummaryForms
{
    public partial class IncidentStatusSummaryForm : BaseForm
    {
        private IncidentStatusSummary _incidentStatusSummary = new IncidentStatusSummary();
        public IncidentStatusSummary incidentStatusSummary { get => _incidentStatusSummary; set => _incidentStatusSummary = value; }
        private Coordinate _coordinate = null;

        private bool _PageInWildfireMode = true;
        public bool PageInWildfireMode { get => _PageInWildfireMode; set => _PageInWildfireMode = value; }
        public IncidentStatusSummaryForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);


            cbo16.DataSource = ProvinceTools.GetProvinces(false);


        }

        public void SetIncidentSummary(IncidentStatusSummary summary)
        {
            if (summary == null) return;
            incidentStatusSummary = summary;
            _coordinate = new Coordinate(summary.Latitude, summary.Longitude);
            LoadFormFromObject();
        }




        private void IncidentStatusSummaryForm_Load(object sender, EventArgs e)
        {
            cboDefinition.Visible = PageInWildfireMode;
            txt9.Visible = !PageInWildfireMode;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SaveCurrentPageToObject();
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SaveCurrentPageToObject();
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                btnPrev.Visible = true;
            }
            else
            {
                btnPrev.Visible = false;
            }

            if (tabControl1.SelectedIndex == tabControl1.TabCount - 1)
            {
                btnNext.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
            }
        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void LoadFormFromObject()
        {
            SetPageOneControlsFromObject();
            SetPageTwoControlsFromObject();
            SetPageThreeControlsFromObject();
            SetPageFourControlsFromObject();
        }


        private void SaveFormToObject()
        {
            SavePageOneToObject();
            SavePageTwoToObject();
            SavePageThreeToObject();
            SavePageFourToObject();

        }

        private void SaveCurrentPageToObject()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    SavePageOneToObject();
                    break;
                case 1:
                    SavePageTwoToObject();
                    break;
                case 2:
                    SavePageThreeToObject();
                    break;
                case 4:
                    SavePageFourToObject();
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFormToObject();

        }

        #region Page 1

       
           private void SetPageOneControlsFromObject()
        {
            // 3
            num3.Value = incidentStatusSummary.ReportNumber;
            rb3a.Checked = incidentStatusSummary.ReportVersion == 0;
            rb3b.Checked = incidentStatusSummary.ReportVersion == 1;
            rb3c.Checked = incidentStatusSummary.ReportVersion == 2;

            // 4
            txt4.SetText( incidentStatusSummary.ICAndOrganization ?? "");

            // 5
            txt5.Text = incidentStatusSummary.IMOrganization ?? "";

            // 6
            if (incidentStatusSummary.IncidentStart != DateTime.MinValue)
            {
                dat6Date.Value = incidentStatusSummary.IncidentStart.Date;
                dat6Time.Value = incidentStatusSummary.IncidentStart;
            }

            // 7
            txt7.Text = incidentStatusSummary.IncidentSize ?? "";

            // 8
            num8Contained.Value = (decimal)incidentStatusSummary.PercentContained;
            num8Complete.Value = (decimal)incidentStatusSummary.PercentCompleted;

            // 9
            if (PageInWildfireMode)
                cboDefinition.Text = incidentStatusSummary.IncidentDefinition ?? "";
            else
                txt9.Text = incidentStatusSummary.IncidentDefinition ?? "";

            // 10
            txt10.Text = incidentStatusSummary.ComplexityLevel ?? "";

            // 11
            if (incidentStatusSummary.ReportFromTimePeriod != DateTime.MinValue)
            {
                dat11FromDate.Value = incidentStatusSummary.ReportFromTimePeriod.Date;
                dat11FromTime.Value = incidentStatusSummary.ReportFromTimePeriod;
            }
            if (incidentStatusSummary.ReportToTimePeriod != DateTime.MinValue)
            {
                dat11ToDate.Value = incidentStatusSummary.ReportToTimePeriod.Date;
                dat11ToTime.Value = incidentStatusSummary.ReportToTimePeriod;
            }

            // 12-14
            if (incidentStatusSummary.PreparedByRoleID != Guid.Empty)
                prepAndApprovePanel1.SetPreparedBy(incidentStatusSummary.PreparedByRoleID, incidentStatusSummary.DatePrepared);
            else
                prepAndApprovePanel1.SetPreparedBy(Guid.Empty, DateTime.MinValue);

            if (incidentStatusSummary.ApprovedByRoleID != Guid.Empty)
                prepAndApprovePanel1.SetApprovedBy(incidentStatusSummary.ApprovedByRoleID, incidentStatusSummary.DateApproved);
            else
                prepAndApprovePanel1.SetApprovedBy(Guid.Empty, DateTime.MinValue);

            //13
            datDateSubmitted.Value = incidentStatusSummary.DateSubmitted.Date;
            datTimeSubmitted.Value = incidentStatusSummary.DateSubmitted;

            // 15
            txt15.Text = incidentStatusSummary.PrimarySendTo ?? "";

            // 16
            if (cbo16.DataSource is IEnumerable<Province> provinces)
            {
                var province = provinces.FirstOrDefault(p => p.ProvinceID == incidentStatusSummary.ProvinceID);
                if (province != null)
                    cbo16.SelectedItem = province;
            }

            // 17
            txt17.Text = incidentStatusSummary.District ?? "";

            // 18
            txt18.Text = incidentStatusSummary.City ?? "";

            // 19
            txt19.Text = incidentStatusSummary.Unit ?? "";

            // 20
            txt20.SetText( incidentStatusSummary.Jurisdiction ?? "");

            // 21
            txt21.Text = incidentStatusSummary.LocationOwnership ?? "";

            // 23
            cbo23.Text = incidentStatusSummary.LocationDatum ?? "";

            // 24
            txt24.Text = incidentStatusSummary.LocationLegalDescription ?? "";

            // 25
            txt25.Text = incidentStatusSummary.ShortLocationDescription ?? "";

            // 26
            if (incidentStatusSummary.Latitude != 0 || incidentStatusSummary.Longitude != 0)
            {
                _coordinate = new Coordinate(incidentStatusSummary.Latitude, incidentStatusSummary.Longitude);
                txtCoordinates.Text = _coordinate.CoordinateOutput("Decimal Degrees");
            }
            else
                _coordinate = null;

            // 27
            txt27.Text = incidentStatusSummary.GeoDataNote ?? "";

            // 28
            txt28.Text = incidentStatusSummary.SignificantEvents ?? "";

            // 29
            txt29.Text = incidentStatusSummary.PrimaryMaterialsOrHazards ?? "";

            // 30
            txt30.Text = incidentStatusSummary.DamageAssessmentInfo ?? "";

            if (incidentStatusSummary.StructureSummarySingleResidence != null && incidentStatusSummary.StructureSummarySingleResidence.Length >= 3)
            {
                num30be.Value = incidentStatusSummary.StructureSummarySingleResidence[0];
                num30ce.Value = incidentStatusSummary.StructureSummarySingleResidence[1];
                num30de.Value = incidentStatusSummary.StructureSummarySingleResidence[2];
            }
            if (incidentStatusSummary.StructureSummaryCommercial != null && incidentStatusSummary.StructureSummaryCommercial.Length >= 3)
            {
                num30bf.Value = incidentStatusSummary.StructureSummaryCommercial[0];
                num30cf.Value = incidentStatusSummary.StructureSummaryCommercial[1];
                num30df.Value = incidentStatusSummary.StructureSummaryCommercial[2];
            }
            if (incidentStatusSummary.StructureSummaryMinor != null && incidentStatusSummary.StructureSummaryMinor.Length >= 3)
            {
                num30bg.Value = incidentStatusSummary.StructureSummaryMinor[0];
                num30cg.Value = incidentStatusSummary.StructureSummaryMinor[1];
                num30dg.Value = incidentStatusSummary.StructureSummaryMinor[2];
            }
            txt30OtherLabel.Text = incidentStatusSummary.StructureSummaryOtherLabel ?? "";
            if (incidentStatusSummary.StructureSummaryOther != null && incidentStatusSummary.StructureSummaryOther.Length >= 3)
            {
                num30bOther.Value = incidentStatusSummary.StructureSummaryOther[0];
                num30COther.Value = incidentStatusSummary.StructureSummaryOther[1];
                num30DOther.Value = incidentStatusSummary.StructureSummaryOther[2];
            }
        }
        


        private void SavePageOneToObject()
        {
            //3
            incidentStatusSummary.ReportNumber = Convert.ToInt32(num3.Value);
            if (rb3a.Checked) { incidentStatusSummary.ReportVersion = 0; }
            else if (rb3b.Checked) { incidentStatusSummary.ReportVersion = 1; }
            else if (rb3c.Checked) { incidentStatusSummary.ReportVersion = 2; }

            //4
            incidentStatusSummary.ICAndOrganization = txt4.Text.Trim();

            //5
            incidentStatusSummary.IMOrganization = txt5.Text.Trim();

            //6 
            incidentStatusSummary.IncidentStart = dat6Date.Value.Date.AddHours(dat6Time.Value.Hour).AddMinutes(dat6Time.Value.Minute).AddSeconds(dat6Time.Value.Second);

            //7
            incidentStatusSummary.IncidentSize = txt7.Text.Trim();

            //8
            incidentStatusSummary.PercentContained = Convert.ToDouble(num8Contained.Value);
            incidentStatusSummary.PercentCompleted = Convert.ToDouble(num8Complete.Value);

            //9
            if (PageInWildfireMode) { incidentStatusSummary.IncidentDefinition = cboDefinition.Text.Trim(); }
            // If not in wildfire mode, use the text box value  
            else { incidentStatusSummary.IncidentDefinition = txt9.Text.Trim(); }

            //10
            incidentStatusSummary.ComplexityLevel = txt10.Text.Trim();

            //11
            incidentStatusSummary.ReportFromTimePeriod = dat11FromDate.Value.Date.AddHours(dat11FromTime.Value.Hour).AddMinutes(dat11FromTime.Value.Minute).AddSeconds(dat11FromTime.Value.Second);
            incidentStatusSummary.ReportToTimePeriod = dat11ToDate.Value.Date.AddHours(dat11ToTime.Value.Hour).AddMinutes(dat11ToTime.Value.Minute).AddSeconds(dat11ToTime.Value.Second);

            //12-14
            if (prepAndApprovePanel1.PreparedByRole != null)
            {
                incidentStatusSummary.PreparedByRoleID = prepAndApprovePanel1.PreparedByRole.RoleID;
                incidentStatusSummary.PreparedByRoleName = prepAndApprovePanel1.PreparedByRole.RoleName;
                incidentStatusSummary.PreparedByResourceName = prepAndApprovePanel1.PreparedByRole.IndividualName;
            }
            else
            {
                incidentStatusSummary.PreparedByRoleID = Guid.Empty;
                incidentStatusSummary.PreparedByRoleName = string.Empty;
                incidentStatusSummary.PreparedByResourceName = string.Empty;
            }
            incidentStatusSummary.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;
            incidentStatusSummary.DateSubmitted = datDateSubmitted.Value.Date.AddHours(datTimeSubmitted.Value.Hour).AddMinutes(datTimeSubmitted.Value.Minute).AddSeconds(datTimeSubmitted.Value.Second);

            if (prepAndApprovePanel1.ApprovedByDateTime > DateTime.MinValue && prepAndApprovePanel1.ApprovedByRole != null)
            {
                incidentStatusSummary.ApprovedByRoleID = prepAndApprovePanel1.ApprovedByRole.RoleID;
                incidentStatusSummary.ApprovedByRoleName = prepAndApprovePanel1.ApprovedByRole.RoleName;
                incidentStatusSummary.ApprovedByResourceName = prepAndApprovePanel1.ApprovedByRole.IndividualName;
                incidentStatusSummary.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;
            }
            else
            {
                incidentStatusSummary.ApprovedByRoleID = Guid.Empty;
                incidentStatusSummary.ApprovedByRoleName = string.Empty;
                incidentStatusSummary.ApprovedByResourceName = string.Empty;
                incidentStatusSummary.DateApproved = DateTime.MinValue;

            }


            //15
            incidentStatusSummary.PrimarySendTo = txt15.Text.Trim();

            //16
            incidentStatusSummary.ProvinceID = ((Province)cbo16.SelectedItem).ProvinceID;

            //17
            incidentStatusSummary.District = txt17.Text.Trim();

            //18
            incidentStatusSummary.City = txt18.Text.Trim();

            //19
            incidentStatusSummary.Unit = txt19.Text.Trim();

            //20
            incidentStatusSummary.Jurisdiction = txt20.Text.Trim();

            //21
            incidentStatusSummary.LocationOwnership = txt21.Text.Trim();

            //23
            incidentStatusSummary.LocationDatum = cbo23.Text;

            //24
            incidentStatusSummary.LocationLegalDescription = txt24.Text.Trim();

            //25
            incidentStatusSummary.ShortLocationDescription = txt25.Text.Trim();

            //26
            if (_coordinate == null)
            {
                incidentStatusSummary.Latitude = 0;
                incidentStatusSummary.Longitude = 0;
                incidentStatusSummary.UTM = string.Empty;

            }
            else
            {
                incidentStatusSummary.Latitude = _coordinate.Latitude;
                incidentStatusSummary.Longitude = _coordinate.Longitude;
                incidentStatusSummary.UTM = _coordinate.UTM;
            }

            //27
            incidentStatusSummary.GeoDataNote = txt27.Text.Trim();

            //28
            incidentStatusSummary.SignificantEvents = txt28.Text.Trim();

            //29
            incidentStatusSummary.PrimaryMaterialsOrHazards = txt29.Text.Trim();

            //30
            incidentStatusSummary.DamageAssessmentInfo = txt30.Text.Trim();
            incidentStatusSummary.StructureSummarySingleResidence[0] = (int)num30be.Value;
            incidentStatusSummary.StructureSummarySingleResidence[1] = (int)num30ce.Value;
            incidentStatusSummary.StructureSummarySingleResidence[2] = (int)num30de.Value;

            incidentStatusSummary.StructureSummaryCommercial[0] = (int)num30bf.Value;
            incidentStatusSummary.StructureSummaryCommercial[1] = (int)num30cf.Value;
            incidentStatusSummary.StructureSummaryCommercial[2] = (int)num30df.Value;

            incidentStatusSummary.StructureSummaryMinor[0] = (int)num30bg.Value;
            incidentStatusSummary.StructureSummaryMinor[1] = (int)num30cg.Value;
            incidentStatusSummary.StructureSummaryMinor[2] = (int)num30dg.Value;


            incidentStatusSummary.StructureSummaryOtherLabel = txt30OtherLabel.Text.Trim();
            incidentStatusSummary.StructureSummaryOther[0] = (int)num30bOther.Value;
            incidentStatusSummary.StructureSummaryOther[1] = (int)num30COther.Value;
            incidentStatusSummary.StructureSummaryOther[2] = (int)num30DOther.Value;
        }




        private void numPercentContained_ValueChanged(object sender, EventArgs e)
        {
            progPercentContained.Value = (int)num8Contained.Value;
        }

        private void txtRadiusCoordinates_TextChanged(object sender, EventArgs e)
        {
            Coordinate c = new Coordinate();
            _coordinate = null;
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                c = CheckCoordinates(txtCoordinates, lblCoordinateResultMessage);

                //Coordinate c  = CheckCoordinates(txtRadiusCoordinates, lblCoordinateStatus);
                if (c != null)
                {
                    _coordinate = c;
                    StringBuilder mapURL = new StringBuilder();
                    //?mlat=49.52112&mlon=-125.52069#map=12/49.5211/-125.5207
                    mapURL.Append("https://www.openstreetmap.org/?mlat=");
                    mapURL.Append(c.Latitude);
                    mapURL.Append("&mlon=");
                    mapURL.Append(c.Longitude);
                    mapURL.Append("#map=12/");
                    mapURL.Append(c.Latitude);
                    mapURL.Append("/");
                    mapURL.Append(c.Longitude);
                    try
                    {
                        Uri mapUri = new Uri(mapURL.ToString());
                        webView22.Source = mapUri;
                        webView22.Visible = true;
                        //LgMessageBox.Show(mapURL.ToString());
                    }
                    catch
                    {
                        webView22.Visible = false;
                    }

                }
                else { webView22.Visible = false; }

            }
            else
            {
                webView22.Visible = false;
            }
        }
        private Coordinate CheckCoordinates(TextBox txtCoordinates, Label lblResultMessage)
        {
            Coordinate temp = new Coordinate();
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                if (temp.TryParseCoordinate(txtCoordinates.Text, out temp))
                {
                    lblResultMessage.Text = "Coordinate OK";
                    lblResultMessage.ForeColor = SystemColors.ControlText;
                    txtCoordinates.BackColor = Program.GoodColor;
                    _coordinate = temp; // Store the valid coordinate for later use
                }
                else
                {
                    lblResultMessage.Text = "Coordinate Error!";
                    lblResultMessage.ForeColor = Color.Red;
                    txtCoordinates.BackColor = Program.ErrorColor;
                }
            }
            else
            {
                lblResultMessage.Text = "";
                lblResultMessage.ForeColor = Color.Black;
                txtCoordinates.BackColor = SystemColors.Window;
                _coordinate = null; // Clear the coordinate if the text is empty
            }
            return temp;
        }
        #endregion


        #region Page 2

        private void SavePageTwoToObject()
        {
            //31
            for (int x = 0; x < Field31ColumnA.Count; x++)
            {
                incidentStatusSummary.CiviliansImpactedEstimate[x] = (Field31Estimate[x].Checked);
                incidentStatusSummary.CiviliansImpactedThisPeriod[x] = (int)Field31ColumnA[x].Value;
                incidentStatusSummary.CiviliansImpactedToDate[x] = (int)Field31ColumnB[x].Value;
            }
            incidentStatusSummary.CiviliansImpactedThisPeriod[incidentStatusSummary.CiviliansImpactedThisPeriod.Length - 1] = (int)numTotalCivilizansThisReport.Value;
            incidentStatusSummary.CiviliansImpactedToDate[incidentStatusSummary.CiviliansImpactedToDate.Length - 1] = (int)numTotalCiviliansToDate.Value;


            //32
            for (int x = 0; x < Field32ColumnA.Count; x++)
            {
                incidentStatusSummary.RespondersImpactedEstimate[x] = (Field32Estimate[x].Checked);
                incidentStatusSummary.RespondersImpactedThisPeriod[x] = (int)Field32ColumnA[x].Value;
                incidentStatusSummary.RespondersImpactedToDate[x] = (int)Field32ColumnB[x].Value;
            }
            incidentStatusSummary.RespondersImpactedThisPeriod[incidentStatusSummary.RespondersImpactedThisPeriod.Length - 1] = (int)num32an.Value;
            incidentStatusSummary.RespondersImpactedToDate[incidentStatusSummary.RespondersImpactedToDate.Length - 1] = (int)num32bn.Value;


            //33
            incidentStatusSummary.LifeSafetyHealthRemarks = txt33.Text.Trim();

            //34
            for (int x = 0; x < Field34.Count; x++)
            {
                incidentStatusSummary.HealthThreatManagementActive[x] = Field34[x].Checked;
            }
            incidentStatusSummary.HealthThreatManagementOtherLabels[0] = txt34Other1.Text.Trim();
            incidentStatusSummary.HealthThreatManagementOtherLabels[1] = txt34Other2.Text.Trim();
            incidentStatusSummary.HealthThreatManagementOtherLabels[2] = txt34Other3.Text.Trim();
            incidentStatusSummary.HealthThreatManagementOtherLabels[3] = txt34Other4.Text.Trim();

            //35
            incidentStatusSummary.WeatherConcerns = txt35.Text.Trim();

            //36
            for (int x = 0; x < Field36.Count; x++)
            {
                incidentStatusSummary.ProjectedEscalation[x] = Field36[x].Text.Trim();
            }

            //37
            incidentStatusSummary.Objectives = txt37.Text.Trim();
        }

        private void SetPageTwoControlsFromObject()
        {
            // 31
            for (int x = 0; x < Field31ColumnA.Count; x++)
            {
                if (incidentStatusSummary.CiviliansImpactedEstimate != null && x < incidentStatusSummary.CiviliansImpactedEstimate.Length)
                    Field31Estimate[x].Checked = incidentStatusSummary.CiviliansImpactedEstimate[x];
                if (incidentStatusSummary.CiviliansImpactedThisPeriod != null && x < incidentStatusSummary.CiviliansImpactedThisPeriod.Length)
                    Field31ColumnA[x].Value = incidentStatusSummary.CiviliansImpactedThisPeriod[x];
                if (incidentStatusSummary.CiviliansImpactedToDate != null && x < incidentStatusSummary.CiviliansImpactedToDate.Length)
                    Field31ColumnB[x].Value = incidentStatusSummary.CiviliansImpactedToDate[x];
            }

            // 32
            for (int x = 0; x < Field32ColumnA.Count; x++)
            {
                if (incidentStatusSummary.RespondersImpactedEstimate != null && x < incidentStatusSummary.RespondersImpactedEstimate.Length)
                    Field32Estimate[x].Checked = incidentStatusSummary.RespondersImpactedEstimate[x];
                if (incidentStatusSummary.RespondersImpactedThisPeriod != null && x < incidentStatusSummary.RespondersImpactedThisPeriod.Length)
                    Field32ColumnA[x].Value = incidentStatusSummary.RespondersImpactedThisPeriod[x];
                if (incidentStatusSummary.RespondersImpactedToDate != null && x < incidentStatusSummary.RespondersImpactedToDate.Length)
                    Field32ColumnB[x].Value = incidentStatusSummary.RespondersImpactedToDate[x];
            }

            // 33
            txt33.Text = incidentStatusSummary.LifeSafetyHealthRemarks ?? "";

            // 34
            for (int x = 0; x < Field34.Count; x++)
            {
                if (incidentStatusSummary.HealthThreatManagementActive != null && x < incidentStatusSummary.HealthThreatManagementActive.Length)
                    Field34[x].Checked = incidentStatusSummary.HealthThreatManagementActive[x];
            }
            if (incidentStatusSummary.HealthThreatManagementOtherLabels != null && incidentStatusSummary.HealthThreatManagementOtherLabels.Length >= 4)
            {
                txt34Other1.Text = incidentStatusSummary.HealthThreatManagementOtherLabels[0] ?? "";
                txt34Other2.Text = incidentStatusSummary.HealthThreatManagementOtherLabels[1] ?? "";
                txt34Other3.Text = incidentStatusSummary.HealthThreatManagementOtherLabels[2] ?? "";
                txt34Other4.Text = incidentStatusSummary.HealthThreatManagementOtherLabels[3] ?? "";
            }

            // 35
            txt35.Text = incidentStatusSummary.WeatherConcerns ?? "";

            // 36
            for (int x = 0; x < Field36.Count; x++)
            {
                if (incidentStatusSummary.ProjectedEscalation != null && x < incidentStatusSummary.ProjectedEscalation.Length)
                    Field36[x].Text = incidentStatusSummary.ProjectedEscalation[x] ?? "";
            }

            // 37
            txt37.Text = incidentStatusSummary.Objectives ?? "";
        }
        private List<NumericUpDown> Field31ColumnA
        {
            get
            {
                List<NumericUpDown> numericUpDowns = new List<NumericUpDown>
                {
                    num31ad, num31ae, num31af, num31ag, num31ah, num31ai, num31aj, num31ak, num31al, num31am
                };
                return numericUpDowns;
            }
        }
        private List<NumericUpDown> Field31ColumnB
        {
            get
            {
                List<NumericUpDown> numericUpDowns = new List<NumericUpDown>
                {
                    num31bd, num31be, num31bf, num31bg, num31bh, num31bi, num31bj, num31bk, num31bl, num31bm
                };
                return numericUpDowns;
            }
        }
        private List<CheckBox> Field31Estimate
        {
            get
            {
                List<CheckBox> checkBoxes = new List<CheckBox>
                {
                    chk31d, chk31e, chk31f, chk31g, chk31h, chk31i, chk31j, chk31k, chk31l, chk31m
                };
                return checkBoxes;
            }
        }

        private List<NumericUpDown> Field32ColumnA
        {
            get
            {
                List<NumericUpDown> numericUpDowns = new List<NumericUpDown>
                {
                    num32ad, num32ae, num32af, num32ag, num32ah, num32ai, num32aj, num32ak, num32al, num32am
                };
                return numericUpDowns;
            }
        }
        private List<NumericUpDown> Field32ColumnB
        {
            get
            {
                List<NumericUpDown> numericUpDowns = new List<NumericUpDown>
                {
                    num32bd, num32be, num32bf, num32bg, num32bh, num32bi, num32bj, num32bk, num32bl, num32bm
                };
                return numericUpDowns;
            }
        }
        private List<CheckBox> Field32Estimate
        {
            get
            {
                List<CheckBox> checkBoxes = new List<CheckBox>
                {
                    chk32d, chk32e, chk32f, chk32g, chk32h, chk32i, chk32j, chk32k, chk32l, chk32m
                };
                return checkBoxes;
            }
        }

        private List<CheckBox> Field34
        {
            get
            {
                List<CheckBox> checkBoxes = new List<CheckBox>
                {
                   chk34a, chk34b, chk34c, chk34d, chk34e, chk34f, chk34g, chk34h, chk34i, chk34j, chk34k, chk34l, chk34m, chk34n, chk34o, chk34p, chk34q, chk34r
                };
                return checkBoxes;
            }
        }
        private List<SpellBox> Field36
        {
            get
            {
                List<SpellBox> spellBoxes = new List<SpellBox>
                {
                    txt36a, txt36b, txt36c, txt36d, txt36e
                };
                return spellBoxes;
            }
        }

        private void numField31ColumnA_ValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int x = 0; x < Field31ColumnA.Count; x++)
            {
                total += (int)Field31ColumnA[x].Value;
            }
            numTotalCivilizansThisReport.Value = total;
        }
        private void numField31ColumnB_ValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int x = 0; x < Field31ColumnB.Count; x++)
            {
                total += (int)Field31ColumnB[x].Value;
            }
            numTotalCiviliansToDate.Value = total;
        }

        private void chk31_CheckedChanged(object sender, EventArgs e)
        {
            chk31n.Checked = false; // Uncheck the "Other" checkbox when any of the main checkboxes are checked
            for (int x = 0; x < Field31Estimate.Count; x++)
            {
                if (Field31Estimate[x].Checked)
                {
                    chk31n.Checked = true;
                    break;
                }
            }
        }

        private void numField32ColumnA_ValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int x = 0; x < Field32ColumnA.Count; x++)
            {
                total += (int)Field32ColumnA[x].Value;
            }
            num32an.Value = total;
        }
        private void numField32ColumnB_ValueChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int x = 0; x < Field32ColumnB.Count; x++)
            {
                total += (int)Field32ColumnB[x].Value;
            }
            num32bn.Value = total;
        }

        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            chk32n.Checked = false; // Uncheck the "Other" checkbox when any of the main checkboxes are checked
            for (int x = 0; x < Field32Estimate.Count; x++)
            {
                if (Field32Estimate[x].Checked)
                {
                    chk32n.Checked = true;
                    break;
                }
            }
        }

        private void btnFill37From202_Click(object sender, EventArgs e)
        {
            IncidentObjectivesSheet sheet = Program.CurrentIncident.ActiveIncidentObjectiveSheets.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod);
            if (sheet != null)
            {
                StringBuilder objectives = new StringBuilder();
                foreach (IncidentObjective objective in sheet.Objectives)
                {
                    if (objective != null && !string.IsNullOrEmpty(objective.Objective))
                    {
                        objectives.AppendLine(objective.Objective);
                    }
                }
                txt37.Text = objectives.ToString().TrimEnd(); // Remove the last newline character
            }
        }

        #endregion

        #region Page 3
        private List<SpellBox> Field38
        {
            get
            {
                List<SpellBox> spellBoxes = new List<SpellBox>
                {
                    txt38a, txt38b, txt38c, txt38d, txt38e
                };
                return spellBoxes;
            }
        }
        private List<SpellBox> Field39
        {
            get
            {
                List<SpellBox> spellBoxes = new List<SpellBox>
                {
                    txt39a, txt39b, txt39c, txt39d, txt39e
                };
                return spellBoxes;
            }
        }


        private void SavePageThreeToObject()
        {
            //38
            for (int x = 0; x < Field38.Count; x++)
            {
                incidentStatusSummary.CurrentThreatSummary[x] = Field38[x].Text.Trim();
            }
            //39
            for (int x = 0; x < Field39.Count; x++)
            {
                incidentStatusSummary.CriticalResourcesNeeded[x] = Field39[x].Text.Trim();
            }

            //40
            incidentStatusSummary.StrategicDiscussion = txt40.Text.Trim();

            //41
            incidentStatusSummary.PlannedActions = txt41.Text.Trim();

            //42
            incidentStatusSummary.ProjectedFinalSize = txt42.Text.Trim();

            //43
            incidentStatusSummary.AnticipatedIMCompleteDate = dat43.Value;

            //44
            incidentStatusSummary.ProjectedResourceDemobDate = dat44.Value;

            //45
            incidentStatusSummary.EstimatedCostsToDate = (double)num45.Value;

            //46
            incidentStatusSummary.ProjectedFinalCost = (double)num46.Value;

            //47
            incidentStatusSummary.Remarks = txt47.Text.Trim();

        }

        private void SetPageThreeControlsFromObject()
        {
            // 38
            for (int x = 0; x < Field38.Count; x++)
            {
                if (incidentStatusSummary.CurrentThreatSummary != null && x < incidentStatusSummary.CurrentThreatSummary.Length)
                    Field38[x].Text = incidentStatusSummary.CurrentThreatSummary[x] ?? "";
            }
          

            // 39
            for (int x = 0; x < Field39.Count; x++)
            {
                if (incidentStatusSummary.CriticalResourcesNeeded != null && x < incidentStatusSummary.CriticalResourcesNeeded.Length)
                    Field39[x].Text = incidentStatusSummary.CriticalResourcesNeeded[x] ?? "";
            }

            // 40
            txt40.Text = incidentStatusSummary.StrategicDiscussion ?? "";

            // 41
            txt41.Text = incidentStatusSummary.PlannedActions ?? "";

            // 42
            txt42.Text = incidentStatusSummary.ProjectedFinalSize ?? "";

            // 43
            if (incidentStatusSummary.AnticipatedIMCompleteDate != DateTime.MinValue)
                dat43.Value = incidentStatusSummary.AnticipatedIMCompleteDate;

            // 44
            if (incidentStatusSummary.ProjectedResourceDemobDate != DateTime.MinValue)
                dat44.Value = incidentStatusSummary.ProjectedResourceDemobDate;

            // 45
            num45.Value = (decimal)incidentStatusSummary.EstimatedCostsToDate;

            // 46
            num46.Value = (decimal)incidentStatusSummary.ProjectedFinalCost;

            // 47
            txt47.Text = incidentStatusSummary.Remarks ?? "";
        }

        #endregion

        #region Page 4

        private void SavePageFourToObject()
        {

            incidentStatusSummary.AdditionalAssistingOrganizations = txt53.Text.Trim();
        }

        private void SetPageFourControlsFromObject()
        {

            txt53.Text = incidentStatusSummary.AdditionalAssistingOrganizations ?? "";
            SetResourceCaptureTime(incidentStatusSummary.ResourceCaptureDateTime);
            SetResourceSummary();
        }


        private void btnCaptureResources_Click(object sender, EventArgs e)
        {
            //lots to do here

            List<SummaryAgencyEntry> agencyEntries = Program.CurrentIncident.GetAgencyEntries(DateTime.Now);
            incidentStatusSummary.SummaryAgencyEntries = agencyEntries;

            SetResourceCaptureTime(DateTime.Now);
            SetResourceSummary();
        }

        private void SetResourceSummary()
        {
            List<SummaryResourceTotal> summaryResourceTotals = incidentStatusSummary.GetResourceTotals();
            dgvResourceSummary.DataSource = summaryResourceTotals.OrderBy(o => o.ResourceKindTypeName).ToList();
        }

        private void SetResourceCaptureTime(DateTime time)
        {
            incidentStatusSummary.ResourceCaptureDateTime = time;
            if (time > DateTime.MinValue)
            {
                datResourceCaptureDate.Value = time;
                datResourceCaptureDate.Visible = true;
                lblResourceCaptureNote.Text = "Resource counts captured at:";
            }
            else
            {
                datResourceCaptureDate.Value = datResourceCaptureDate.MinDate;
                datResourceCaptureDate.Visible = false;
                lblResourceCaptureNote.Text = "Resource data has not yet been captured";
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFormToObject();
            LgMessageBox.Show("Incident Status Summary saved successfully.", "Save Successful", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;
        }

        private void num8Complete_ValueChanged(object sender, EventArgs e)
        {
            progPercentComplete.Value = (int)num8Complete.Value;
        }
    }
}
