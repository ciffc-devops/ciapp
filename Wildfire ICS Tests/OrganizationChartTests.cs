using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Tests
{
    [TestClass]
    public class OrganizationChartTests
    {
        [TestMethod]
        public void BuildInitialOrganizationChart()
        {
            // Arrange
            OrganizationChart orgChart = new OrganizationChart();
            // Act
            orgChart.AllRoles.AddRange(OrganizationalChartTools.GetBlankPrimaryRoles());
            // Assert
            Assert.IsNotNull(orgChart);
            Assert.AreNotEqual(0, orgChart.ActiveRoles.Count);
            Assert.AreEqual(9, orgChart.ActiveRoles.Count);
            Assert.IsTrue(orgChart.ActiveRoles.Any(o => o.GenericRoleID == Globals.SafetyOfficerGenericID));
        }

        [TestMethod]
        public void CopyOrgChartToNewOPTest()
        {

            Globals.incidentService = new IncidentDataService();
            Globals.incidentService.CurrentIncident = new Incident();


            // Arrange
            OrganizationChart orgChart = new OrganizationChart();
            orgChart.OpPeriod = 1;
            orgChart.AllRoles.AddRange(OrganizationalChartTools.GetBlankPrimaryRoles());

            Globals.incidentService.UpsertOrganizationalChart(orgChart);
            // Act

            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(2, true);

            // Assert
            Assert.IsNotNull(Globals.incidentService.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == 2));
            Assert.AreNotEqual(0, Globals.incidentService.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == 2).ActiveRoles.Count);
            Assert.AreEqual(9, Globals.incidentService.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == 2).ActiveRoles.Count);
            Assert.IsTrue(Globals.incidentService.CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == 2).ActiveRoles.Any(o => o.GenericRoleID == Globals.SafetyOfficerGenericID));

        }

        [TestMethod]
        public void TestAutoAddBranchName()
        {
            // Arrange
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }

            OrganizationChart orgChart = new OrganizationChart();
            orgChart.OpPeriod = 1;
            orgChart.AllRoles.AddRange(OrganizationalChartTools.GetBlankPrimaryRoles());
            Globals.incidentService.UpsertOrganizationalChart(orgChart);
            // Act
            ICSRole role = new ICSRole(OrganizationalChartTools.GetGenericICSRoles().FirstOrDefault(o => o.MnemonicAbrv.Equals("OPBD")));
            role.OpPeriod = 1;


            // Assert
            Assert.IsNotNull(orgChart);
            Assert.AreNotEqual(0, orgChart.ActiveRoles.Count);
            Assert.AreEqual(9, orgChart.ActiveRoles.Count);
            Assert.IsTrue(orgChart.ActiveRoles.Any(o => o.GenericRoleID == Globals.SafetyOfficerGenericID));
            Assert.IsTrue(orgChart.ActiveRoles.Any(o => o.RoleName.Contains("Branch")));
        }

        [TestMethod]
        public void TestAutomaticallyAddOperationalGroup()
        {
            // Arrange
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }
            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(1, false);

            ICSRole OPBD = new ICSRole(OrganizationalChartTools.GetGenericICSRoles().FirstOrDefault(o => o.MnemonicAbrv.Equals("OPBD")));


            OPBD.OrganizationalChartID = Globals.incidentService.CurrentIncident.activeOrgCharts.First().ID;
            OPBD.OpPeriod = Globals.incidentService.CurrentIncident.activeOrgCharts.First().OpPeriod;
            OPBD.ReportsTo = Globals.incidentService.CurrentIncident.activeOrgCharts.First().ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.OpsChiefGenericID).ID;
            OPBD.ReportsToGenericRoleID = Globals.OpsChiefGenericID;
            OPBD.ReportsToRoleName = Globals.incidentService.CurrentIncident.activeOrgCharts.First().ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.OpsChiefGenericID).RoleName;
            if (OPBD.RequiresOperationalGroup)
            {
                OPBD.OperationalGroupName = "1";
            }
            Globals.incidentService.UpsertICSRole(OPBD);


            if (OPBD.RequiresOperationalGroup && !Globals.incidentService.CurrentIncident.ActiveOperationalGroups.Any(o => o.ID == OPBD.OperationalGroupID))
            {
                OperationalGroup group = OPBD.CreateOpGroupFromRole(OPBD.OperationalGroupName);
                group.ParentID = Globals.incidentService.CurrentIncident.GetOpGroupParentIDThroughOrgChart(group);
                group.ParentName = Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.ID == group.ParentID)?.Name;
                Globals.incidentService.UpsertOperationalGroup(group);
                OPBD.OperationalGroupID = group.ID;
                Globals.incidentService.UpsertICSRole(OPBD);

            }

            //asserts
            Assert.AreNotEqual(Guid.Empty, Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.Name == "1").ParentID);
            Assert.IsNotNull(Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.Name == "1"));
            Assert.IsNotNull(Globals.incidentService.CurrentIncident.activeOrgCharts.First().ActiveRoles.FirstOrDefault(o=>o.OperationalGroupID == Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(g => g.Name == "1").ID));


        }

        [TestMethod]
        public void TestSwitchToUnifiedCommand()
        {
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }

            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(1, false);
            OrganizationChart orgChart = Globals.incidentService.CurrentIncident.activeOrgCharts.First();

            //orgChart.AllRoles = orgChart.AllRoles.GetUnifiedCommandRoles();
            orgChart.SwitchToUnifiedCommand();

            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o=>o.GenericRoleID == Globals.UnifiedCommand1GenericID));
            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID));
            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID));
            int brokenReportsTo = 0;
            foreach(ICSRole role in orgChart.ActiveRoles.Where(o=>o.GenericRoleID != Globals.UnifiedCommand1GenericID && o.GenericRoleID != Globals.UnifiedCommand2GenericID && o.GenericRoleID != Globals.UnifiedCommand3GenericID))
            {
                if (!orgChart.ActiveRoles.Any(o=>o.ID == role.ReportsTo)) {
                    
                    brokenReportsTo++; }
            }
            Assert.AreEqual(0, brokenReportsTo);
        }

        [TestMethod]
        public void TestSwitchToIC()
        {
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }

            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(1, false);
            OrganizationChart orgChart = Globals.incidentService.CurrentIncident.activeOrgCharts.First();

            //Switch the org chart to unified command
            orgChart.SwitchToUnifiedCommand();

            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand1GenericID));
            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID));
            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID));


            //Switch it back to incident commander
            orgChart.SwitchToSingleIC();
            Assert.IsNotNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.IncidentCommanderGenericID));
            Assert.IsNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand2GenericID));
            Assert.IsNull(orgChart.ActiveRoles.FirstOrDefault(o => o.GenericRoleID == Globals.UnifiedCommand3GenericID));


            int brokenReportsTo = 0;
            foreach (ICSRole role in orgChart.ActiveRoles.Where(o => o.GenericRoleID != Globals.UnifiedCommand1GenericID && o.GenericRoleID != Globals.UnifiedCommand2GenericID && o.GenericRoleID != Globals.UnifiedCommand3GenericID))
            {
                if (!orgChart.ActiveRoles.Any(o => o.ID == role.ReportsTo)) { brokenReportsTo++; }
            }
            Assert.AreEqual(0, brokenReportsTo);


        }
    }
}
