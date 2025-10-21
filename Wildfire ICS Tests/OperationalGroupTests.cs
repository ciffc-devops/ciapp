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
    [TestClass] public class OperationalGroupTests
    {
        [TestMethod]
        public void TestCreateOpsSectionGroup()
        {
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }

            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(1, true);
            Assert.IsTrue(Globals.incidentService.CurrentIncident.activeOrgCharts.Any(o => o.OpPeriod == 1));
            Assert.IsTrue(Globals.incidentService.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == 1).ActiveRoles.Any(o=>o.GenericRoleID == Globals.OpsChiefGenericID));

            Globals.incidentService.CurrentIncident.CreateAllOperationalGroupsAsNeeded(1);
            ICSRole OSC = Globals.incidentService.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == 1).ActiveRoles.First(o => o.GenericRoleID == Globals.OpsChiefGenericID);
            Assert.IsTrue(Globals.incidentService.CurrentIncident.ActiveOperationalGroups.Any(o=>o.OpPeriod == 1 && o.LeaderICSRoleID == OSC.ID));



        }

        [TestMethod]
        public void TestCreateBranchAndRole()
        {
            if (Globals.incidentService == null)
            {
                Globals.incidentService = new IncidentDataService();
                Globals.incidentService.CurrentIncident = new Incident();
            }
            Globals.incidentService.CurrentIncident.createOrgChartAsNeeded(1, true);

            OperationalGroup group = new OperationalGroup();
            group.OpPeriod = 1;
            OperationalGroup OpSection = Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.ParentID == Guid.Empty && o.OpPeriod == 1);

            group.ParentID = OpSection.ID;
            group.ParentName = OpSection.ResourceName;
            group.GroupType = "Branch";
            group.Name = "1";

            Globals.incidentService.UpsertOperationalGroup(group);
            Assert.IsNotNull(Globals.incidentService.CurrentIncident.ActiveOperationalGroups.FirstOrDefault(o => o.ID == group.ID));

            ICSRole role = group.CreateRoleFromOperationalGroup(Globals.incidentService.CurrentIncident.activeOrgCharts.First(o => o.OpPeriod == 1).ID);
            Assert.IsNotNull(role);
            Assert.IsTrue(role.OperationalGroupID == group.ID);


        }
    }
}
