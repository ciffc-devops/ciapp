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
using WF_ICS_ClassLibrary.Utilities;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.UtilityForms;

namespace Wildfire_ICS_Assist.IncidentObjectiveForms
{
    public partial class IncidentObjectivesListForm : BaseForm
    {
        private Incident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private IncidentObjectivesSheet objectivesSheet { get => Program.CurrentIncident.AllIncidentObjectiveSheets.FirstOrDefault(o => o.OpPeriod == CurrentOpPeriod); }
        private List<CollapsiblePanel> allHazardsCollapsiblePanels = new List<CollapsiblePanel>();
        private List<CollapsiblePanel> wfCollapsiblePanels = new List<CollapsiblePanel>();
        bool anyChanges = false;
        private List<CollapsiblePanel> collapsiblePanelControls
        {
            get
            {
                List<CollapsiblePanel> panels = new List<CollapsiblePanel>();
                panels.AddRange(allHazardsCollapsiblePanels);
                panels.AddRange(wfCollapsiblePanels);
                panels.Add(prepAndApprovePanel1);
                return panels;
            }
        }


        public IncidentObjectivesListForm()
        {
            InitializeComponent();
            SetControlColors(this.Controls);

        }

        private void IncidentObjectivesListForm_Load(object sender, EventArgs e)
        {
            CurrentIncident.createObjectivesSheetAsNeeded(CurrentOpPeriod);
            ConfigureUXForFormSet();
            ConfigureEvents();

            LoadSheet();
        }

        private void ConfigureEvents()
        {
            Program.incidentDataService.IncidentObjectiveChanged += IncidentDataService_IncidentObjectiveChanged;
            Program.incidentDataService.IncidentObjectivesSheetChanged += IncidentDataService_IncidentObjectivesSheetChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += IncidentDataService_CurrentOpPeriodChanged;

            txtCommandEmphasis.Validated += (s, ev) => { if (objectivesSheet != null && txtCommandEmphasis.Text != objectivesSheet.CommandEmphasis) { objectivesSheet.CommandEmphasis = txtCommandEmphasis.Text; anyChanges = true; } };
            txtFireSize.Validated += (s, ev) => { if (objectivesSheet != null && txtFireSize.Text != objectivesSheet.FireSize) { objectivesSheet.FireSize = txtFireSize.Text; anyChanges = true; } };
            txtGeneralSafetyMessage.Validated += (s, ev) => { if (objectivesSheet != null && txtGeneralSafetyMessage.Text != objectivesSheet.GeneralSafety) { objectivesSheet.GeneralSafety = txtGeneralSafetyMessage.Text; anyChanges = true; } };
            txtSafetyPlanLocation.Validated += (s, ev) => { if (objectivesSheet != null && txtSafetyPlanLocation.Text != objectivesSheet.SafetyPlanLocation) { objectivesSheet.SafetyPlanLocation = txtSafetyPlanLocation.Text; anyChanges = true; } };
            txtSituationalAwareness.Validated += (s, ev) => { if (objectivesSheet != null && txtSituationalAwareness.Text != objectivesSheet.SituationalAwareness) { objectivesSheet.SituationalAwareness = txtSituationalAwareness.Text; anyChanges = true; } };
            txtWeatherForcast.Validated += (s, ev) => { if (objectivesSheet != null && txtWeatherForcast.Text != objectivesSheet.WeatherForecast) { objectivesSheet.WeatherForecast = txtWeatherForcast.Text; anyChanges = true; } };
            cboFireStatus.SelectedIndexChanged += (s, ev) => { if (objectivesSheet != null && cboFireStatus.Text != objectivesSheet.FireStatus) { objectivesSheet.FireStatus = cboFireStatus.Text; anyChanges = true; } };
            chkSafetyPlanRequired.CheckedChanged += (s, ev) => { if (objectivesSheet != null && chkSafetyPlanRequired.Checked != objectivesSheet.SiteSafetyPlanRequired) { objectivesSheet.SiteSafetyPlanRequired = chkSafetyPlanRequired.Checked; anyChanges = true; } };

            foreach(CollapsiblePanel cp in collapsiblePanelControls)
            {
                cp.PanelExpanded += HandlePanelExpanded;
                cp.PanelCollapsed += HandlePanelCollapsed;
            }

        }

        private void ConfigureUXForFormSet()
        {
            allHazardsCollapsiblePanels.Add(cpCommandEmphasis);
            allHazardsCollapsiblePanels.Add(cpSituationalAwareness);
                        allHazardsCollapsiblePanels.Add(cpSafetyPlanRequired);

            wfCollapsiblePanels.Add(cpWeather);
            wfCollapsiblePanels.Add(cpGeneralSafety);
            wfCollapsiblePanels.Add(cpFireStatus);

            foreach (CollapsiblePanel cp in collapsiblePanelControls) { cp.Collapse(); }

            Point firstPanel = new Point(9, 67);

            int formSet = Program.generalOptionsService.GetIntOptionsValue("FormSet");
            if (formSet == 1)
            {
                // Wildfire
                foreach (var panel in wfCollapsiblePanels)
                {
                    panel.Visible = true;
                }
                foreach (var panel in allHazardsCollapsiblePanels)
                {
                    if (!wfCollapsiblePanels.Contains(panel))
                    {
                        panel.Visible = false;
                    }
                }

                for (int x = 0; x < wfCollapsiblePanels.Count; x++)
                {
                    wfCollapsiblePanels[x].Location = new Point(firstPanel.X, firstPanel.Y + (x * (wfCollapsiblePanels[x].SizeWhenCollapsed.Height+10 )));
                }

            }
            else
            {
                // All Hazards
                foreach (var panel in allHazardsCollapsiblePanels)
                {
                    panel.Visible = true;
                }
                foreach (var panel in wfCollapsiblePanels)
                {
                    if (!allHazardsCollapsiblePanels.Contains(panel))
                    {
                        panel.Visible = false;
                    }
                }

                for (int x = 0; x < allHazardsCollapsiblePanels.Count; x++)
                {
                    allHazardsCollapsiblePanels[x].Location = new Point(firstPanel.X, firstPanel.Y + (x * (allHazardsCollapsiblePanels[x].SizeWhenCollapsed.Height+10)));
                }

            }


        }

        private void LoadSheet()
        {
            //LoadPreparedBy();
            //LoadApprovedBy();

            prepAndApprovePanel1.SetPreparedBy(objectivesSheet.PreparedByRoleID, objectivesSheet.DatePrepared);
            prepAndApprovePanel1.SetApprovedBy(objectivesSheet.ApprovedByRoleID, objectivesSheet.DateApproved);


            BuildSafetyMessageList();
            PopulateTree();
            txtCommandEmphasis.Text = objectivesSheet.CommandEmphasis;
            txtFireSize.Text = objectivesSheet.FireSize;
            txtGeneralSafetyMessage.Text = objectivesSheet.GeneralSafety;
            txtSafetyPlanLocation.Text = objectivesSheet.SafetyPlanLocation;
            chkSafetyPlanRequired.Checked = objectivesSheet.SiteSafetyPlanRequired;
            txtSituationalAwareness.Text = objectivesSheet.SituationalAwareness;
            txtWeatherForcast.Text = objectivesSheet.WeatherForecast;


            if (!string.IsNullOrEmpty(objectivesSheet.WeatherForecast)) { txtWeatherForcast.Text = objectivesSheet.WeatherForecast.Replace("\n", Environment.NewLine); ; }
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



        #region Event Handling
        private void HandlePanelExpanded(object sender, EventArgs e)
        {
            if (sender != null)
            {

                CollapsiblePanel c = (CollapsiblePanel)sender;
                int baseX = c.Left;
                int shiftX = baseX - 10; if (shiftX < 0) { shiftX = 0; }

                c.Location = new Point(shiftX, c.Location.Y);
                foreach (CollapsiblePanel cp in collapsiblePanelControls)
                {
                    if (!cp.Name.Equals(c.Name))
                    {
                        if (!cp.Collapsed)
                        {
                            cp.Collapse();
                            //cp.Location = new Point(10, cp.Location.Y);
                        }
                    }
                }
            }
        }
        private void HandlePanelCollapsed(object sender, EventArgs e)
        {
            if (sender != null)
            {
                CollapsiblePanel c = (CollapsiblePanel)sender;
                int baseX = c.Left;
                int shiftX = baseX + 10; if (shiftX < 0) { shiftX = 0; }

                c.Location = new Point(shiftX, c.Location.Y);
            }
        }
        private void IncidentObjectivesListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save any changes that have occurred
            if (anyChanges)
            {
                Program.incidentDataService.UpsertIncidentObjectivesSheet(objectivesSheet);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            IncidentObjective obj = new IncidentObjective();
            obj.OpPeriod = CurrentOpPeriod;
            obj.Active = true;
            obj.Priority = objectivesSheet.GetNextPriorityNumber();
            obj.ParentObjectiveID = Guid.Empty;
            EditObjective(obj, true);
        }

        private void EditObjective(IncidentObjective objective, bool IsNew)
        {
            using (IncidentObjectiveEntryForm editForm = new IncidentObjectiveEntryForm())
            {
                editForm.Objective = objective;
                editForm.EditMode = !IsNew;
                var result = editForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertIncidentObjective(editForm.Objective);
                   
                    if (IsNew && editForm.SaveForLater)
                    {
                        Program.generalOptionsService.UpsertOptionValue(editForm.Objective, "Objective");
                    }

                }
            }
        }

        private void IncidentDataService_CurrentOpPeriodChanged(WF_ICS_ClassLibrary.EventHandling.IncidentOpPeriodChangedEventArgs e)
        {
            PopulateTree();
        }

        private void IncidentDataService_IncidentObjectivesSheetChanged(WF_ICS_ClassLibrary.EventHandling.IncidentObjectivesSheetEventArgs e)
        {
            if(e.item != null && e.item.ID == objectivesSheet.ID)
            {
                PopulateTree();
            }
        }

        private void IncidentDataService_IncidentObjectiveChanged(WF_ICS_ClassLibrary.EventHandling.IncidentObjectiveEventArgs e)
        {
            if (e.item != null && objectivesSheet.ActiveObjectives.Any(o => o.ID == e.item.ID))
            {
                PopulateTree(e.item);

            }
            else
            {
                PopulateTree();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tvObjectives.SelectedNode.Tag != null)
            {
                IncidentObjective obj = (IncidentObjective)tvObjectives.SelectedNode.Tag;
                EditObjective(obj, false);
            }
        }

        private void btnAddStrategy_Click(object sender, EventArgs e)
        {
            if (tvObjectives.SelectedNode != null && tvObjectives.SelectedNode.Tag != null)
            {
                IncidentObjective parent = (IncidentObjective)tvObjectives.SelectedNode.Tag;

                IncidentObjective objective = new IncidentObjective();
                objective.Active = true;
                objective.OpPeriod = Program.CurrentOpPeriod;
                objective.Priority = objectivesSheet.GetNextPriorityNumber(parent.ID);
                objective.ParentObjectiveID = parent.ID;
                EditObjective(objective, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (LgMessageBox.Show("Are you sure you want to delete this objective?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                IncidentObjective objective = (IncidentObjective)tvObjectives.SelectedNode.Tag;
                deleteObjective(objective);
            }
        }

        private void deleteObjective(IncidentObjective objective)
        {
            objective.Active = false;
            objectivesSheet.RenumberObjectives();
            Program.incidentDataService.UpsertIncidentObjective(objective);


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
                    LgMessageBox.Show("There was an error opening " + filename + Environment.NewLine + Environment.NewLine + ex.ToString());
                }
            }
            else
            {
                LgMessageBox.Show("Sorry, there was an issue creating the PDF.");
            }
        }

        #endregion

        #region Tree Stuff

        private void PopulateTree(IncidentObjective currentlySelectedItem = null)
        {


            tvObjectives.Nodes.Clear();
            // call recursive function
            AddCurrentChild(Guid.Empty, tvObjectives.Nodes);

            if (tvObjectives.Nodes.Count > 0)
            {
                tvObjectives.Nodes[0].ExpandAll();
                if (currentlySelectedItem == null)
                {
                    tvObjectives.SelectedNode = tvObjectives.Nodes[0];
                }
                else
                {
                    TreeNode selectedNode = GetSelectedByItemID(currentlySelectedItem.ID);
                    if (selectedNode != null)
                    {
                        tvObjectives.SelectedNode = selectedNode;
                    }
                    else { tvObjectives.SelectedNode = tvObjectives.Nodes[0]; }
                }
                if (tvObjectives.SelectedNode != null) tvObjectives.SelectedNode.EnsureVisible();

            }
            tvObjectives.ExpandAll();
            tvObjectives.Focus();
        }

        private TreeNode GetSelectedByItemID(Guid itemID)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in tvObjectives.Nodes)
            {
                itemNode = FromID(itemID, node);
                if (itemNode != null) break;
            }

            return itemNode;
        }

        private TreeNode FromID(Guid itemId, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (((IncidentObjective)node.Tag).ID == itemId) return node;
                TreeNode next = FromID(itemId, node);
                if (next != null) return next;
            }
            return null;
        }

        private void AddCurrentChild(Guid parentId, TreeNodeCollection nodes)
        {

            var rows = objectivesSheet.ActiveObjectives.Where(o => o.OpPeriod == Program.CurrentOpPeriod && o.ParentObjectiveID == parentId).OrderBy(o => o.Priority).ToList();//  CurrentOrgChart.ActiveRoles.Where(o => o.ReportsTo == parentId).ToList();

            foreach (var row in rows)
            {
                var id = row.ID;
                string name = row.ObjectiveWithPriority;

                var node = nodes.Add(id.ToString(), name);
                if (row.ParentObjectiveID == Guid.Empty) { node.NodeFont = GetNodeFont(false); }
                else { node.NodeFont = GetNodeFont(true); }

                node.Tag = row; // if you need to keep a row reference on the node
                AddCurrentChild(row.ID, node.Nodes);
            }
        }


        private Font GetNodeFont(bool italic)
        {
            if (italic)
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16, FontStyle.Italic, GraphicsUnit.Pixel);
                return MyFont;
            }
            else
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16, FontStyle.Bold, GraphicsUnit.Pixel);
                return MyFont;
            }
        }

        private void tvObjectives_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }




        #endregion

        private void prepAndApprovePanel1_ApprovedByChanged(object sender, EventArgs e)
        {
            objectivesSheet.SetApprovedBy(prepAndApprovePanel1.ApprovedByRole);
            objectivesSheet.DateApproved = prepAndApprovePanel1.ApprovedByDateTime;

        }

        private void prepAndApprovePanel1_PreparedByChanged(object sender, EventArgs e)
        {
            objectivesSheet.SetPreparedBy(prepAndApprovePanel1.PreparedByRole);
            objectivesSheet.DatePrepared = prepAndApprovePanel1.PreparedByDateTime;

        }
    }
}
