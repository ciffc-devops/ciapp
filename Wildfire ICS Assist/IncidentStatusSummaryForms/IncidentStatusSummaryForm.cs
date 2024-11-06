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
                            webView21.Source = mapUri;
                            webView21.Visible = true;
                            //MessageBox.Show(mapURL.ToString());
                        }
                        catch
                        {
                            webView21.Visible = false;
                        }

                    }
                    else { webView21.Visible = false; }
                }
                else { webView21.Visible = false; }
            }
            else
            {
                webView21.Visible = false;
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
    }
}
