using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Assist.IncidentStatusSummaryForms
{
    public partial class IncidentStatusSummaryForm : BaseForm
    {
        private IncidentStatusSummary _incidentStatusSummary;
        public IncidentStatusSummary incidentStatusSummary { get => _incidentStatusSummary; set => _incidentStatusSummary = value; }

        private bool _PageInWildfireMode = true;
        public bool PageInWildfireMode { get => _PageInWildfireMode; set => _PageInWildfireMode = value; }
        public IncidentStatusSummaryForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);


            cboProvince.DataSource = ProvinceTools.GetProvinces(false);

            BuildResourceGrid();
        }


        private BindingSource bindingSource1 = new BindingSource();


        private void BuildResourceGrid()
        {
            //ResourceGridView.DataSource = null;
            //ResourceGridView.AutoGenerateColumns = false;
            //ResourceGridView.Columns.Clear();
            //ResourceGridView.DataSource = _incidentStatusSummary.Resources;
            //ResourceGridView.Refresh();

            dgvResources.Columns.Clear();

            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            List<CheckInRecord> allRecords = new List<CheckInRecord>(Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod));

            foreach (CheckInRecord rec in allRecords)
            {
                IncidentResource resource = new IncidentResource();
                if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                {
                    resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                }

                if (resource != null && resource.ParentResourceID == Guid.Empty)
                {
                    checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                }
            }

            List<string> resourceTypes = new List<string>();
            List<string> agencies = new List<string>();
            foreach (CheckInRecordWithResource rec in checkInRecords)
            {
                if (!resourceTypes.Contains(rec.Type))
                {
                    resourceTypes.Add(rec.Type);
                }

                if (!agencies.Contains(rec.Resource.AgencyName))
                {
                    agencies.Add(rec.Resource.AgencyName);
                }
            }
            agencies = agencies.OrderBy(o => o).ToList();
            resourceTypes = resourceTypes.OrderBy(o => o).ToList();


            List < object[]> rows = new List<object[]>();
            object[] headerRow = new object[resourceTypes.Count + 1];
            headerRow[0] = "Agency Name";
            for(int x = 0; x < resourceTypes.Count; x++)
            {
                headerRow[x + 1] = resourceTypes[x];
            }
            
            //rows.Add(headerRow);



            foreach (CheckInRecordWithResource rec in checkInRecords)
            {
                string agency = rec.Resource.AgencyName;
                if (!rows.Any(o => o[0].Equals(agency)))
                {

                    object[] row = new object[resourceTypes.Count + 1];
                    row[0] = agency;
                    for (int x = 0; x < resourceTypes.Count; x++)
                    {
                        row[x + 1] = checkInRecords.Count(o => o.Resource.AgencyName.EqualsWithNull(agency) && o.Resource.Type.EqualsWithNull(resourceTypes[x]));
                    }
                    rows.Add(row);
                }
            }



            //dgvResources.DataSource = rows;
        }


        private void numPercentContained_ValueChanged(object sender, EventArgs e)
        {
            progPercentContained.Value = (int)numPercentContained.Value;
        }

        private void txtRadiusCoordinates_TextChanged(object sender, EventArgs e)
        {
            Coordinate c = new Coordinate();
            if (!string.IsNullOrEmpty(txtCoordinates.Text))
            {
                if (c.TryParseCoordinate(txtCoordinates.Text, out c))
                {
                    //Coordinate c  = CheckCoordinates(txtRadiusCoordinates, lblCoordinateStatus);
                    if (c != null)
                    {
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
            }
            return temp;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void IncidentStatusSummaryForm_Load(object sender, EventArgs e)
        {
            cboDefinition.Visible = PageInWildfireMode;
            txtDefinition.Visible = !PageInWildfireMode;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex--;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex > 0)
            {
                btnPrev.Visible = true;
            }
            else
            {
                btnPrev.Visible = false;
            }

            if(tabControl1.SelectedIndex == tabControl1.TabCount - 1)
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
    }
}
