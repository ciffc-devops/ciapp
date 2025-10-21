using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Tests
{
    [TestClass]

    public class InternetSyncTests
    {
        [TestMethod]
        public async Task TestSendInternetSyncData()
        {
            Progress<Tuple<int, int, int>> prog = new Progress<Tuple<int, int, int>>();
            Incident testIncident = CreateTestIncident();
            prog.ProgressChanged += (s, e) => { Console.WriteLine($"Progress step {e.Item1} item {e.Item2} of {e.Item3}"); };
            try
            {
                await Globals.incidentService.SendInitialTaskUpdate(prog);
                Assert.IsTrue(true);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        [TestMethod]
        public async Task TestSendAndReceiveInternetSyncData()
        {
            Progress<Tuple<int, int, int>> prog = new Progress<Tuple<int, int, int>>();
            Incident testIncident = CreateTestIncident();
            prog.ProgressChanged += (s, e) => { Console.WriteLine($"Progress step {e.Item1} item {e.Item2} of {e.Item3}"); };
            try
            {
                await Globals.incidentService.SendInitialTaskUpdate(prog);
                Assert.IsTrue(true);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Guid taskID = Globals.incidentService.CurrentIncident.ID;
            string passphrase = Globals.incidentService.CurrentIncident.TaskEncryptionKey;

            Progress<Tuple<int, int, int>> prog2 = new Progress<Tuple<int, int, int>>();

            
            Globals.incidentService = new IncidentDataService(new Incident());
            try
            {
                await Globals.incidentService.LoadNewTaskFromServer(taskID, passphrase, prog2);
                Assert.AreEqual(Globals.incidentService.CurrentIncident.ID, taskID);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.IsTrue(false);
            }
        }

        private Incident CreateTestIncident()
        {
            Incident currentIncident = new Incident();
            IncidentDataService dataService = new IncidentDataService(currentIncident);
            Globals.incidentService = dataService;
            Globals.incidentService.MachineID = Guid.NewGuid();
            dataService.CurrentRole = new ICSRole(OrganizationalChartTools.GetGenericRoleByID(Globals.IncidentCommanderGenericID));

            currentIncident.createOrgChartAsNeeded(1);

            currentIncident.createObjectivesSheetAsNeeded(1);

            currentIncident.AllIncidentObjectiveSheets.First().Objectives.Add(TestTools.createTestIncidentObjective(0));

            return currentIncident;
        }
    }
}
