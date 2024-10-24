using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Tests
{
    [TestClass]
    public class AddObjectTets
    {
        static WFIncident incident = new WFIncident();
        static WFIncidentService wFIncidentService = new WFIncidentService(incident);

        [TestMethod]
        public void TestMedicalPlan()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allMedicalPlans.Count;

            MedicalPlan medPlan = TestTools.createTestMedicalPlan(seed);
            medPlan.OpPeriod = seed;
            wFIncidentService.UpsertMedicalPlan(medPlan);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allMedicalPlans.Count, countBefore, 0, "Medical Plan not added");
        }

        [TestMethod]
        public void TestAirOps()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allAirOperationsSummaries.Count;
            AirOperationsSummary item = TestTools.CreateAirOpsTest(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertAirOperationsSummary(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allAirOperationsSummaries.Count, countBefore, 0, "Air Ops not added");
        }

        [TestMethod]
        public void TesContacts()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allContacts.Count;
            Contact item = TestTools.createContactTest(seed);
            wFIncidentService.UpsertContact(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allContacts.Count, countBefore, 0, "Contact not added");
        }

        [TestMethod]
        public void TestNotes()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allNotes.Count;
            Note item = TestTools.createTestNote(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertNote(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allNotes.Count, countBefore, 0, "Note not added");
        }

        [TestMethod]
        public void TestPositionLogEntry()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allPositionLogEntries.Count;
            PositionLogEntry item = TestTools.createTestPositionLogEntry(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertPositionLogEntry(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allPositionLogEntries.Count, countBefore, 0, "Position Log not added");
        }

        [TestMethod]
        public void TestSafetyMessage()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allSafetyMessages.Count;
            SafetyMessage item = TestTools.createTestSafetyMessage(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertSafetyMessage(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allSafetyMessages.Count, countBefore, 0, "Safety Message not added");
        }

        [TestMethod]
        public void TestCommsPlan()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allCommsPlans.Count;
            CommsPlan item = TestTools.createTestCommsPlan(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertCommsPlan(item);
            Assert.AreEqual(item.allCommsItems.Count, 5, "Comms plan items not added correctly");
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allCommsPlans.Count, countBefore, 0, "Comms Plan not added");
        }

        [TestMethod]
        public void TestGeneralMessage()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.AllGeneralMessages.Count;
            GeneralMessage item = TestTools.createTestGeneralMessage(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertGeneralMessage(item);
            Assert.AreNotEqual(wFIncidentService.CurrentIncident.AllGeneralMessages.Count, countBefore, 0, "General Message not added");
        }

        [TestMethod]
        public void TestIncidentObjectives()
        {
            int seed = 1;
            int countBefore = wFIncidentService.CurrentIncident.allIncidentObjectives.Count;
            IncidentObjectivesSheet item = TestTools.createTestObjectiveSheet(seed);
            item.OpPeriod = seed;
            wFIncidentService.UpsertIncidentObjectivesSheet(item);
            Assert.AreEqual(item.Objectives.Count, 5, "Objectives not added correctly");

            Assert.AreNotEqual(wFIncidentService.CurrentIncident.allIncidentObjectives.Count, countBefore, 0, "Incident Objectives Sheet not added");
        }
    }
}
