using Microsoft.VisualBasic;
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

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class CheckInInfoFieldControl : UserControl
    {
        private CheckInInfoField _infoField = new CheckInInfoField();
        public CheckInInfoField infoField { get => _infoField; }
        public void SetInfoField(CheckInInfoField field) { _infoField = field; loadInfoField(); }
        public CheckInInfoFieldControl()
        {
            InitializeComponent();
            foreach (var cb in Controls.OfType<ComboBox>())
            {
                cb.Resize += (sender, e) => {
                    if (!cb.Focused)
                        cb.SelectionLength = 0;
                };
            }
        }

        private void CheckInInfoFieldControl_Load(object sender, EventArgs e)
        {

        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int durationMilliseconds = 10000;
            toolTip1.Show(toolTip1.GetToolTip(btn), btn, durationMilliseconds);

        }

        public bool IsComplete
        {
            get
            {
                if (infoField.IsRequired)
                {
                    switch (infoField.FieldType)
                    {
                        case "Bool":
                            return true;
                        case "DateTime":
                            if (datDateValue.Value > DateTime.MinValue && datDateValue.Value < DateTime.MaxValue) { errorProvider1.SetError(datDateValue, ""); } else { errorProvider1.SetError(datDateValue, Properties.Resources.RequiredNote); }
                            return datDateValue.Value > DateTime.MinValue && datDateValue.Value < DateTime.MaxValue;
                        case "Time":
                            if (datDateValue.Value > DateTime.MinValue && datDateValue.Value < DateTime.MaxValue) { errorProvider1.SetError(datDateValue, ""); } else { errorProvider1.SetError(datDateValue, Properties.Resources.RequiredNote); }
                            return datDateValue.Value > DateTime.MinValue && datDateValue.Value < DateTime.MaxValue;
                        case "List":
                            if (string.IsNullOrEmpty(cboListValue.Text)) { errorProvider1.SetError(cboListValue, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(cboListValue, ""); }
                            return !string.IsNullOrEmpty(cboListValue.Text);

                        case "Weight":
                            if (string.IsNullOrEmpty(txtStringValue.Text)) { errorProvider1.SetError(txtStringValue, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(txtStringValue, ""); }
                            return WeightInKG > 0;
                        case "Int":
                            return numNumberValue.Value > 0;
                        default:
                            if (string.IsNullOrEmpty(txtStringValue.Text)) { errorProvider1.SetError(txtStringValue, Properties.Resources.RequiredNote); } else { errorProvider1.SetError(txtStringValue, ""); }
                            return !string.IsNullOrEmpty(txtStringValue.Text);
                    }
                }
                return true;
            }
        }

        private decimal WeightInKG
        {
            get
            {
                if (rbKG.Checked) { return numNumberValue.Value; }
                else
                {
                    return numNumberValue.Value * 0.4535924m;
                }
            }
        }

        private void loadInfoField()
        {
            if (infoField != null)
            {
                lblFieldName.Text = infoField.Name;
                if (infoField.IsRequired) { lblFieldName.Text += "*"; }
                toolTip1.SetToolTip(btnHelp, infoField.ToolTipText);
                btnHelp.Visible = (!string.IsNullOrEmpty(infoField.ToolTipText));

                Point startPoint = new Point();
                startPoint.Y = lblFieldName.Location.Y;
                startPoint.X = lblFieldName.Location.X + 5 + lblFieldName.Width;

                int width = 0;
                if (btnHelp.Visible) { width = btnHelp.Location.X - 15 - startPoint.X; }
                else { width = this.Width - 15 - startPoint.X; }

                chkBoolValue.Visible = false;
                datDateValue.Visible = false;
                txtStringValue.Visible = false;
                cboListValue.Visible = false;
                pnlWeight.Visible = false;
                numNumberValue.Visible = false;

                switch (infoField.FieldType)
                {
                    case "Bool":
                        chkBoolValue.Checked = infoField.BoolValue;
                        chkBoolValue.Visible = true;
                        chkBoolValue.Location = startPoint;
                        btnHelp.Location = new Point(chkBoolValue.Left + chkBoolValue.Width + 5, btnHelp.Location.Y);
                        break;
                    case "DateTime":
                        if (infoField.DateValue > datDateValue.MinDate && infoField.DateValue < datDateValue.MaxDate)
                        {
                            datDateValue.Value = infoField.DateValue;
                        }
                        datDateValue.Visible = true;
                        datDateValue.Location = startPoint;
                        datDateValue.Width = width;
                        datDateValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        datDateValue.CustomFormat = Program.DateFormat;
                        break;
                    case "Time":
                        if (infoField.DateValue > datDateValue.MinDate && infoField.DateValue < datDateValue.MaxDate)
                        {
                            datDateValue.Value = infoField.DateValue;
                        }
                        datDateValue.Visible = true;
                        datDateValue.Location = startPoint;
                        datDateValue.Width = width;
                        datDateValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        datDateValue.CustomFormat = "HH:mm";

                        break;

                    case "List":

                        cboListValue.Visible = true;
                        cboListValue.Width = width;
                        cboListValue.Location = startPoint;
                        cboListValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        cboListValue.DataSource = CheckInTools.GetInfoFieldListOptions(infoField.ID);
                        if (string.IsNullOrEmpty(infoField.StringValue) && cboListValue.Items.Count > 0)
                        {
                            for (int x = 0; x < cboListValue.Items.Count; x++)
                            {
                                if (!string.IsNullOrEmpty(cboListValue.Items[x].ToString()))
                                {
                                    cboListValue.SelectedIndex = x;
                                    infoField.StringValue = cboListValue.Items[x].ToString();
                                    break;
                                }
                            }
                        }
                        else { cboListValue.Text = infoField.StringValue; }

                        break;
                    case "Weight":
                        numNumberValue.Visible = true;
                        pnlWeight.Visible = true;
                        numNumberValue.Location = startPoint;
                        numNumberValue.Width = pnlWeight.Location.X - 5 - startPoint.X;
                        numNumberValue.Value = infoField.DecimalValue;
                        rbKG.Checked = true;
                        break;
                    case "Int":
                        numNumberValue.Visible = true;
                        numNumberValue.Location = startPoint;
                        numNumberValue.Width = pnlWeight.Location.X - 5 - startPoint.X;
                        numNumberValue.Value = infoField.IntValue;

                        break;
                    default:
                        txtStringValue.Visible = true;
                        txtStringValue.Width = width;
                        txtStringValue.Location = startPoint;
                        txtStringValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        txtStringValue.Text = infoField.StringValue;
                        break;

                }
            }
            SetColors();
        }

        private void datDateValue_ValueChanged(object sender, EventArgs e)
        {
            infoField.DateValue = datDateValue.Value; SetColors();
        }

        private void txtStringValue_TextChanged(object sender, EventArgs e)
        {
            infoField.StringValue = txtStringValue.Text; SetColors();

        }

        private void chkBoolValue_CheckedChanged(object sender, EventArgs e)
        {
            infoField.BoolValue = chkBoolValue.Checked; SetColors();
        }

        private void cboListValue_Leave(object sender, EventArgs e)
        {
            infoField.StringValue = cboListValue.Text;
            SetColors();
        }

        private void SetColors()
        {
            if (!IsComplete)
            {
                lblFieldName.ForeColor = Program.ErrorColor;
                txtStringValue.BackColor = Program.ErrorColor;
            }
            else { lblFieldName.ForeColor = SystemColors.ControlText; txtStringValue.BackColor = SystemColors.Window; }
        }

        private void numNumberValue_ValueChanged(object sender, EventArgs e)
        {
            infoField.DecimalValue = WeightInKG;
            infoField.IntValue = Convert.ToInt32(numNumberValue.Value);
        }

        private void rbKG_CheckedChanged(object sender, EventArgs e)
        {
            infoField.DecimalValue = WeightInKG;

        }

        private void rbLBS_CheckedChanged(object sender, EventArgs e)
        {
            infoField.DecimalValue = WeightInKG;

        }
    }
}
