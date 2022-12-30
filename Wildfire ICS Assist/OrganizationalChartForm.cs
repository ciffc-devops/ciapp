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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Wildfire_ICS_Assist
{
    public partial class OrganizationalChartForm : Form
    {
        private WFIncident CurrentIncident { get => Program.CurrentIncident; set => Program.CurrentIncident = value; }
        private int CurrentOpPeriod { get => Program.CurrentOpPeriod; set => Program.CurrentOpPeriod = value; }
        private OrganizationChart CurrentOrgChart { get => Program.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == Program.CurrentOpPeriod); }

        public OrganizationalChartForm()
        {
            InitializeComponent();
        }


        private void OrganizationalChartForm_Load(object sender, EventArgs e)
        {
            PopulateTree();
            if (treeOrgChart.Nodes.Count > 0)
            {
                treeOrgChart.Nodes[0].ExpandAll();
                treeOrgChart.SelectedNode = treeOrgChart.Nodes[0];
                if (treeOrgChart.SelectedNode != null) treeOrgChart.SelectedNode.EnsureVisible();
                
            }
        }


        private void PopulateTree()
        {
            if (!Program.CurrentIncident.allOrgCharts.Any(o => o.OpPeriod == Program.CurrentOpPeriod))
            {
                Program.CurrentIncident.createOrgChartAsNeeded(Program.CurrentOpPeriod);
            }

            // call recursive function
            AddCurrentChild(Guid.Empty, treeOrgChart.Nodes);

        }

        private void AddCurrentChild(Guid parentId, TreeNodeCollection nodes)
        {
            var rows = CurrentOrgChart.AllRoles.Where(o => o.ReportsTo == parentId).ToList();

            foreach (var row in rows)
            {
                var roleID = row.RoleID;
                string name = row.RoleNameWithIndividual;

                var node = nodes.Add(roleID.ToString(), name);
                if (row.IndividualID == Guid.Empty) { node.NodeFont = GetNodeFont(true); }
                else { node.NodeFont = GetNodeFont(false); }
                node.Tag = row; // if you need to keep a row reference on the node
                AddCurrentChild(row.RoleID, node.Nodes);
            }
        }


        private Font GetNodeFont(bool italic)
        {
            if (italic)
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16, FontStyle.Italic, GraphicsUnit.Pixel);
                return MyFont;
            } else
            {
                System.Drawing.Font MyFont = new System.Drawing.Font(this.Font.FontFamily, 16,  GraphicsUnit.Pixel);
                return MyFont;
            }
        }

        private void treeOrgChart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeOrgChart.SelectedNode != null)
            {
               
            }
        }
    }
}
