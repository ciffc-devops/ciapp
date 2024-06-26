﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.Classes;
using Wildfire_ICS_Assist.CustomControls;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class IncidentObjectivesForm : BaseForm
    {
        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private IncidentObjectivesSheet objectivesSheet { get => Program.CurrentIncident.allIncidentObjectives.First(o => o.OpPeriod == CurrentOpPeriod); }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }


        bool anyChanges = false;

        public IncidentObjectivesForm()
        {
           
            InitializeComponent();
            txtWeatherForcast.Leave += txtWeatherForcast_Leave;
            txtGeneralSafetyMessage.Leave += txtGeneralSafetyMessage_Leave; 
        }


        private void LoadPreparedBy()
        {
            List<ICSRole> roles = CurrentOrgChart.Clone().ActiveRoles;
            ICSRole blank = new ICSRole(); blank.RoleName = string.Empty; blank.RoleID = Guid.Empty; roles.Insert(0, blank);

            cboPreparedBy.DataSource = null;
            cboPreparedBy.DataSource = roles;
            cboPreparedBy.DisplayMember = "RoleNameWithIndividualAndDepth"; cboPreparedBy.ValueMember = "RoleID";
            if (objectivesSheet.PreparedByRoleID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == objectivesSheet.PreparedByRoleID)) { cboPreparedBy.SelectedValue = objectivesSheet.PreparedByRoleID; }
            cboPreparedBy.DropDownWidth = cboPreparedBy.GetDropDownWidth();

        }


        private void LoadApprovedBy()
        {
            List<ICSRole> roles = CurrentOrgChart.Clone().ActiveRoles;
            ICSRole blank = new ICSRole(); blank.RoleName = string.Empty; blank.RoleID = Guid.Empty; roles.Insert(0, blank);


            cboApprovedBy.DataSource = null;
            cboApprovedBy.DataSource = roles;
            cboApprovedBy.DisplayMember = "RoleNameWithIndividualAndDepth"; cboApprovedBy.ValueMember = "RoleID";
            if (objectivesSheet.ApprovedByRoleID != Guid.Empty && CurrentOrgChart.ActiveRoles.Any(o => o.RoleID == objectivesSheet.ApprovedByRoleID)) { cboApprovedBy.SelectedValue = objectivesSheet.ApprovedByRoleID; }
            cboApprovedBy.DropDownWidth = cboApprovedBy.GetDropDownWidth();

            
        }



        private void IncidentObjectivesForm_Load(object sender, EventArgs e)
        {
            if (Owner != null) { Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2); }

            dgvObjectives.AutoGenerateColumns = false;
            CurrentIncident.createObjectivesSheetAsNeeded(CurrentOpPeriod);
            LoadSheet();
            panels.Add(cpFireStatus); panels.Add(cpWeather); panels.Add(cpGeneralSafety);
            
            Program.wfIncidentService.IncidentObjectiveChanged += Program_IncidentObjectiveChanged;
            Program.wfIncidentService.IncidentObjectivesSheetChanged += Program_IncidentObjectivesSheetChanged;
            Program.wfIncidentService.SafetyMessageChanged += Program_SafetyMessagesChanged;
            Program.wfIncidentService.OpPeriodChanged += Program_OpPeriodChanged;

            foreach (CollapsiblePanel p in panels)
            {
                p.Collapse();
                p.PanelExpanded += HandlePanelExpanded;
                p.PanelCollapsed += HandlePanelCollapsed;

            }
        }

        private List<CollapsiblePanel> panels = new List<CollapsiblePanel>();

        private void HandlePanelExpanded(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CollapsiblePanel c = (CollapsiblePanel)sender;
                c.Location = new Point(0, c.Location.Y);
                foreach (CollapsiblePanel cp in panels)
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
            if (sender != null)
            {
                CollapsiblePanel c = (CollapsiblePanel)sender;
                c.Location = new Point(10, c.Location.Y);
                
               
            }
        }

        private void Program_OpPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            CurrentIncident.createObjectivesSheetAsNeeded(CurrentOpPeriod);
            LoadSheet();
        }

        private void LoadSheet()
        {
            LoadPreparedBy();
            LoadApprovedBy();

            BuildSafetyMessageList();
            LoadObjectives();
            txtFireSize.Text = objectivesSheet.FireSize;
            if (!string.IsNullOrEmpty(objectivesSheet.WeatherForcast)) { txtWeatherForcast.Text = objectivesSheet.WeatherForcast.Replace("\n", Environment.NewLine); ; }
            if (!string.IsNullOrEmpty(objectivesSheet.GeneralSafety)) { txtGeneralSafetyMessage.Text = objectivesSheet.GeneralSafety.Replace("\n", Environment.NewLine); ; }
            cboFireStatus.Text = objectivesSheet.FireStatus;
            anyChanges = false;
        }

        private void BuildSafetyMessageList()
        {
            cboSafetyMessages.DataSource = null;
            List<SafetyMessage> safetyMessages = Program.CurrentIncident.allSafetyMessages.Where(o => o.OpPeriod == Program.CurrentOpPeriod && o.Active).ToList();
            cboSafetyMessages.DataSource = safetyMessages;
            btnFillSafetyFrom208.Enabled = safetyMessages.Any();
            cboSafetyMessages.Enabled = safetyMessages.Any();
            cboSafetyMessages.DisplayMember = "SummaryLine";
            cboSafetyMessages.ValueMember = "ID";
        }



        private void LoadObjectives()
        {
            if (objectivesSheet.ActiveObjectives.Any())
            {
                var bindingSource1 = new System.Windows.Forms.BindingSource { DataSource = objectivesSheet.ActiveObjectives.OrderBy(o => o.Priority) };
                dgvObjectives.DataSource = bindingSource1;
            }
            else { dgvObjectives.DataSource = null; }
        }


        private void Program_IncidentObjectivesSheetChanged(IncidentObjectivesSheetEventArgs e)
        {
            if (e.item.OpPeriod == Program.CurrentOpPeriod)
            {
                LoadSheet();
            }
        }
        private void Program_IncidentObjectiveChanged(IncidentObjectiveEventArgs e)
        {
            if (e.item.OpPeriod == CurrentOpPeriod)
            {
                LoadObjectives();
            }
        }

        private void Program_SafetyMessagesChanged(SafetyMessageEventArgs e)
        {
            if (e.item.OpPeriod == CurrentOpPeriod)
            {
                BuildSafetyMessageList();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (IncidentObjectiveEntryForm entryForm = new IncidentObjectiveEntryForm())
            {
                DialogResult dr = entryForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    IncidentObjective obj = entryForm.Objective;
                    obj.OpPeriod = CurrentOpPeriod;
                    obj.TaskID = CurrentIncident.TaskID;
                    obj.ObjectiveLastUpdatedUTC = DateTime.UtcNow;
                    obj.Priority = objectivesSheet.GetNextPriorityNumber();
                    Program.wfIncidentService.UpsertIncidentObjective(obj);

                    if (entryForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpserOptionValue(entryForm.Objective, "Objective");

                    }

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvObjectives.SelectedRows.Count == 1)
            {
                IncidentObjective obj = (IncidentObjective)dgvObjectives.SelectedRows[0].DataBoundItem;
                OpenObjectiveForEdit(obj);
            }
        }

        private void OpenObjectiveForEdit(IncidentObjective obj)
        {
            using (OptionsForms.EditSavedIncidentObjectiveForm editForm = new OptionsForms.EditSavedIncidentObjectiveForm())
            {
                editForm.objective = obj;
                DialogResult dr = editForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.wfIncidentService.UpsertIncidentObjective(editForm.objective);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<IncidentObjective> objectivesToDelete = new List<IncidentObjective>();
                foreach (DataGridViewRow row in dgvObjectives.SelectedRows)
                {
                    objectivesToDelete.Add((IncidentObjective)row.DataBoundItem);
                }
                foreach (IncidentObjective obj in objectivesToDelete)
                {
                    obj.Active = false;
                    Program.wfIncidentService.UpsertIncidentObjective(obj);
                }

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string filename = Program.pdfExportService.createObjectivesPDF(CurrentIncident, CurrentOpPeriod, false, false, false);
            if (!string.IsNullOrEmpty(filename))
            {
                try
                {
                    System.Diagnostics.Process.Start(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error opening " + filename + Environment.NewLine + Environment.NewLine + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Sorry, there was an issue creating the PDF.");
            }
        }

        private void txtWeatherForcast_Leave(object sender, EventArgs e)
        {
            objectivesSheet.WeatherForcast = txtWeatherForcast.Text;
            anyChanges = true;
        }

        private void txtGeneralSafetyMessage_Leave(object sender, EventArgs e)
        {
            objectivesSheet.GeneralSafety = txtGeneralSafetyMessage.Text;
            anyChanges = true;
        }

        private void txtFireSize_Leave(object sender, EventArgs e)
        {
            objectivesSheet.FireSize = txtFireSize.Text;
            anyChanges = true;
        }

        private void cboFireStatus_Leave(object sender, EventArgs e)
        {
            objectivesSheet.FireStatus = cboFireStatus.Text;
            anyChanges = true;
        }

        private void dgvObjectives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                IncidentObjective obj = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;

                switch (e.ColumnIndex)
                {
                    case 1: //Up

                        if (objectivesSheet.Objectives.Any(o => o.Priority < obj.Priority))
                        {
                            IncidentObjective nextUp = objectivesSheet.Objectives.Where(o => o.Priority < obj.Priority).OrderByDescending(o => o.Priority).FirstOrDefault();
                            int newHigherPriority = nextUp.Priority;
                            nextUp.Priority = obj.Priority;
                            obj.Priority = newHigherPriority;
                            Program.wfIncidentService.UpsertIncidentObjective(nextUp);
                            Program.wfIncidentService.UpsertIncidentObjective(obj);
                        }

                        break;
                    case 2: //Down
                        if (objectivesSheet.Objectives.Any(o => o.Priority > obj.Priority))
                        {
                            IncidentObjective nextDown = objectivesSheet.Objectives.Where(o => o.Priority > obj.Priority).OrderBy(o => o.Priority).FirstOrDefault();
                            int newLowerPriority = nextDown.Priority;
                            nextDown.Priority = obj.Priority;
                            obj.Priority = newLowerPriority;
                            Program.wfIncidentService.UpsertIncidentObjective(nextDown);
                            Program.wfIncidentService.UpsertIncidentObjective(obj);
                        }

                        break;
                }
            }
        }

        private void dgvObjectives_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvObjectives_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // up button
            if (e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Math.Min(Properties.Resources.glyphicons_basic_222_chevron_up_3x.Width, Math.Min(e.CellBounds.Width, e.CellBounds.Height));
                var h = Math.Min(Properties.Resources.glyphicons_basic_222_chevron_up_3x.Height, Math.Min(e.CellBounds.Width, e.CellBounds.Height));
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.glyphicons_basic_222_chevron_up_3x, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            else if (e.ColumnIndex == 2)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Math.Min(Properties.Resources.glyphicons_basic_221_chevron_down_3x.Width, Math.Min(e.CellBounds.Width, e.CellBounds.Height));
                var h = Math.Min(Properties.Resources.glyphicons_basic_221_chevron_down_3x.Height, Math.Min(e.CellBounds.Width, e.CellBounds.Height));
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.glyphicons_basic_221_chevron_down_3x, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dgvObjectives_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                IncidentObjective obj = (IncidentObjective)dgvObjectives.Rows[e.RowIndex].DataBoundItem;
                OpenObjectiveForEdit(obj);
            }
        }

        private void dgvObjectives_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dgvObjectives.SelectedRows.Count == 1;
            btnDelete.Enabled = dgvObjectives.SelectedRows.Count > 0;
        }

        private void btnFillSafetyFrom208_Click(object sender, EventArgs e)
        {
            if (cboSafetyMessages.SelectedItem != null)
            {
                SafetyMessage msg = cboSafetyMessages.SelectedItem as SafetyMessage;
                txtGeneralSafetyMessage.Text = msg.Message.Replace("\n", Environment.NewLine); ;
                objectivesSheet.GeneralSafety = txtGeneralSafetyMessage.Text;

            }
        }

        private void IncidentObjectivesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!txtFireSize.Text.Equals(objectivesSheet.FireSize)) { objectivesSheet.FireSize = txtFireSize.Text; anyChanges = true; }
            if (!txtGeneralSafetyMessage.Text.Equals(objectivesSheet.GeneralSafety)) { objectivesSheet.GeneralSafety = txtGeneralSafetyMessage.Text; anyChanges = true; }
            if (!txtWeatherForcast.Text.Equals(objectivesSheet.WeatherForcast)) { objectivesSheet.WeatherForcast = txtWeatherForcast.Text; anyChanges = true; }
            if (!cboFireStatus.Text.Equals(objectivesSheet.FireStatus)) { objectivesSheet.FireStatus = cboFireStatus.Text; anyChanges = true; }
            if (anyChanges)
            {
                Program.wfIncidentService.UpsertIncidentObjectivesSheet(objectivesSheet);

            }
        }

        private void cboPreparedBy_Leave(object sender, EventArgs e)
        {
            if(cboPreparedBy.SelectedItem != null)
            {
                ICSRole selected = (ICSRole)cboPreparedBy.SelectedItem;

                objectivesSheet.PreparedByRoleID = selected.RoleID;
                objectivesSheet.PreparedBy = selected.IndividualName;
                objectivesSheet.PreparedByRole = selected.RoleName;
            } else
            {
                cboPreparedBy.Text = string.Empty;
                objectivesSheet.PreparedByRoleID = Guid.Empty;
                objectivesSheet.PreparedBy = string.Empty;
                objectivesSheet.PreparedByRole = string.Empty;
            }
        }

        private void cboApprovedBy_Leave(object sender, EventArgs e)
        {
            if(cboApprovedBy.SelectedItem != null)
            {
                ICSRole selected = (ICSRole)cboApprovedBy.SelectedItem;

                objectivesSheet.ApprovedByRoleID = selected.RoleID;
                objectivesSheet.ApprovedBy = selected.IndividualName;
                objectivesSheet.ApprovedByRole = selected.RoleName;
            } else
            {
                cboPreparedBy.Text = string.Empty;
                objectivesSheet.ApprovedByRoleID = Guid.Empty;
                objectivesSheet.ApprovedBy = string.Empty;
                objectivesSheet.ApprovedByRole = string.Empty;
            }
        }
    }
}
