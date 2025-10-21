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
    public class CopyItemsToNewOPTests
    {
        static Incident incident = new Incident();
        static IncidentDataService wFIncidentService = new IncidentDataService(incident);

        [TestMethod]
        public void CopySafetyMessagesTest()
        {
            if (Globals.incidentService == null) { Globals.incidentService = wFIncidentService; }

            int seed = 1;
            AddOpPeriods(2);


            int countBefore = wFIncidentService.CurrentIncident.allSafetyMessages.Count(o=>o.OpPeriod == 1);
            for (int x = 0; x < 5; x++)
            {
                SafetyMessage item = TestTools.createTestSafetyMessage(seed + x);
                item.OpPeriod = 1;
                wFIncidentService.UpsertSafetyMessage(item);
            }


            
            Assert.AreEqual(wFIncidentService.CurrentIncident.allSafetyMessages.Count(o => o.OpPeriod == 1), 5, "initial item not added correctly");

            List<SafetyMessage> op2List = wFIncidentService.CurrentIncident.CopySafetyMessages(1, 2);
            Assert.IsTrue(wFIncidentService.CurrentIncident.allSafetyMessages.Any(o => o.OpPeriod == 2), "item not created for new OP");


            Assert.AreEqual(wFIncidentService.CurrentIncident.allSafetyMessages.Count(o => o.OpPeriod == 1 && o.Active), wFIncidentService.CurrentIncident.allSafetyMessages.Count(o => o.OpPeriod == 2 && o.Active), "Items not copied correctly");
        }


        [TestMethod]
        public void CopyAirOpsTest()
        {
            if (Globals.incidentService == null) { Globals.incidentService = wFIncidentService; }

            int seed = 1;
            AddOpPeriods(2);


            int countBefore = wFIncidentService.CurrentIncident.allAirOperationsSummaries.Count;
            var item = TestTools.CreateAirOpsTest(seed);
            item.OpPeriod = 1;
            wFIncidentService.UpsertAirOperationsSummary(item);
           
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allAirOperationsSummaries.Count, countBefore, 0, "initial item not added");



            var newSheet = wFIncidentService.CurrentIncident.CopyAirOperationsSummary(1, 2);
            Assert.IsTrue(wFIncidentService.CurrentIncident.allAirOperationsSummaries.Any(o => o.OpPeriod == 2), "item not created for new OP");


            Assert.AreEqual(wFIncidentService.CurrentIncident.allAirOperationsSummaries.First(o => o.OpPeriod == 1).notam.AltitudeASL, wFIncidentService.CurrentIncident.allAirOperationsSummaries.First(o => o.OpPeriod == 2).notam.AltitudeASL, "Items not copied correctly");
        }


        [TestMethod]
        public void CopyIncidentObjectivesTest()
        {
            if (Globals.incidentService == null) { Globals.incidentService = wFIncidentService; }

            int seed = 1;
            AddOpPeriods(2);


            int countBefore = wFIncidentService.CurrentIncident.AllIncidentObjectiveSheets.Count;
            IncidentObjectivesSheet item = TestTools.createTestObjectiveSheet(seed);
            wFIncidentService.UpsertIncidentObjectivesSheet(item);
            Assert.AreEqual(item.ActiveObjectives.Count, 5, "initial item not added correctly");
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.AllIncidentObjectiveSheets.Count, countBefore, 0, "initial item not added");



            IncidentObjectivesSheet newSheet = wFIncidentService.CurrentIncident.CopyIncidentObjectivesSheet(1, 2);
            Assert.IsTrue(wFIncidentService.CurrentIncident.AllIncidentObjectiveSheets.Any(o => o.OpPeriod == 2), "item not created for new OP");


            Assert.AreEqual(wFIncidentService.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == 1).ActiveObjectives.Count, wFIncidentService.CurrentIncident.AllIncidentObjectiveSheets.First(o => o.OpPeriod == 2).ActiveObjectives.Count, "Items not copied correctly");
        }


        [TestMethod]
        public void CopyCommsPlanTest()
        {
            if(Globals.incidentService == null) { Globals.incidentService = wFIncidentService; }

            int seed = 1;
            AddOpPeriods(2);


            int countBefore = wFIncidentService.CurrentIncident.allCommsPlans.Count;
            CommsPlan item = TestTools.createTestCommsPlan(seed);
            wFIncidentService.UpsertCommsPlan(item);
            Assert.AreEqual(item.allCommsItems.Count, 5, "Comms plan items not added correctly");
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allCommsPlans.Count, countBefore, 0, "Comms Plan not added");

            

            List<CommsPlanItem> itemsForNewOP = wFIncidentService.CurrentIncident.CopyCommunicationsPlan(1, 2);
            Assert.IsTrue(wFIncidentService.CurrentIncident.allCommsPlans.Any(o => o.OpPeriod == 2), "Comms Plan not created for new OP");
            
            
            Assert.AreEqual(wFIncidentService.CurrentIncident.allCommsPlans.First(o=>o.OpPeriod == 1).ActiveCommsItems.Count, wFIncidentService.CurrentIncident.allCommsPlans.First(o => o.OpPeriod == 2).ActiveCommsItems.Count, "Items not copied correctly");
        }

        [TestMethod]
        public void CopyMedicalPlanTest()
        {
            if (Globals.incidentService == null) { Globals.incidentService = wFIncidentService; }

            int seed = 1;
            AddOpPeriods(2);


            int countBefore = wFIncidentService.CurrentIncident.allCommsPlans.Count;
            MedicalPlan item = TestTools.createTestMedicalPlan(seed);
            wFIncidentService.UpsertMedicalPlan(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allMedicalPlans.Count, countBefore, 0, "Medical Plan not added");


            var newMedPlan = wFIncidentService.CurrentIncident.CopyMedicalPlan(1, 2);
            Assert.IsTrue(wFIncidentService.CurrentIncident.allMedicalPlans.Any(o => o.OpPeriod == 2), "Plan not created for new OP");


            Assert.AreEqual(wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 1).MedicalAidStations.Count, wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 2).MedicalAidStations.Count, "Medical aid  not copied correctly");
            Assert.AreEqual(wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 1).Hospitals.Count, wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 2).Hospitals.Count, "hospitals  not copied correctly");
            Assert.AreEqual(wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 1).Ambulances.Count, wFIncidentService.CurrentIncident.allMedicalPlans.First(o => o.OpPeriod == 2).Ambulances.Count, "ambulances  not copied correctly");
        }

        private void AddOpPeriods(int qtyToAdd)
        {
            DateTime lastEndDate = DateTime.Now;

            for (int x = 1; x <= qtyToAdd; x++)
            {
                OperationalPeriod op1 = new OperationalPeriod();
                op1.PeriodNumber = x; op1.PeriodStart = lastEndDate; op1.PeriodEnd = op1.PeriodStart.AddHours(12);
                wFIncidentService.UpsertOperationalPeriod(op1);
                lastEndDate = op1.PeriodEnd;
            }
        }
    }
}
