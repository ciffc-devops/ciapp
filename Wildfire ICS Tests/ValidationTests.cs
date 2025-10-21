using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Utilities;

namespace Wildfire_ICS_Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestValidateNewOP()
        {
            Incident incident = new Incident();

            // Create a new operational period
            OperationalPeriod op1 = new OperationalPeriod();
            DateTime today = DateTime.Now;
            op1.PeriodNumber = 1; op1.PeriodStart = today; op1.PeriodEnd = today.AddHours(12);
            incident.AllOperationalPeriods.Add(op1);

            OperationalPeriod op2 = new OperationalPeriod();
            op2.PeriodNumber = 2; op2.PeriodStart = today.AddHours(12); op2.PeriodEnd = today.AddHours(24);


            Tuple<bool, bool, bool> overlap = incident.GetDoesThisOperationalPeriodOverlap(op2);
            Assert.IsFalse(overlap.Item1);
            Assert.IsFalse(overlap.Item2);
            Assert.IsFalse(overlap.Item3);
            Console.WriteLine("Op 2 does not overlap with op 1");
            incident.AllOperationalPeriods.Add(op2);


            OperationalPeriod op3 = new OperationalPeriod();
            op3.PeriodNumber = 2; op3.PeriodStart = today.AddHours(13); op3.PeriodEnd = today.AddHours(25);

            Tuple<bool, bool, bool> overlap3 = incident.GetDoesThisOperationalPeriodOverlap(op3);
            Assert.IsTrue(overlap3.Item1);
            Assert.IsFalse(overlap3.Item2);
            Assert.IsFalse(overlap3.Item3);
            Console.WriteLine("The start of op 3 overlaps with another op");

            OperationalPeriod op4 = new OperationalPeriod();
            op4.PeriodNumber = 2; op4.PeriodStart = today.AddHours(-2); op4.PeriodEnd = today.AddHours(10);

            Tuple<bool, bool, bool> overlap4 = incident.GetDoesThisOperationalPeriodOverlap(op4);
            Assert.IsFalse(overlap4.Item1);
            Assert.IsTrue(overlap4.Item2);
            Assert.IsFalse(overlap4.Item3);
            Console.WriteLine("The end of op 4 overlaps with another op");


            //this should fall within op 1
            OperationalPeriod op5 = new OperationalPeriod();
            op5.PeriodNumber = 2; op5.PeriodStart = today.AddHours(1); op5.PeriodEnd = today.AddHours(3);

            Tuple<bool, bool, bool> overlap5 = incident.GetDoesThisOperationalPeriodOverlap(op5);
            Assert.IsTrue(overlap5.Item1);
            Assert.IsTrue(overlap5.Item2);
            Assert.IsFalse(overlap5.Item3);


            //op 1 and 2 should fall within this
            OperationalPeriod op6 = new OperationalPeriod();
            op6.PeriodNumber = 2; op6.PeriodStart = today.AddHours(-2); op6.PeriodEnd = today.AddHours(27);

            Tuple<bool, bool, bool> overlap6 = incident.GetDoesThisOperationalPeriodOverlap(op6);
            Assert.IsFalse(overlap6.Item1);
            Assert.IsFalse(overlap6.Item2);
            Assert.IsTrue(overlap6.Item3);

        }
    }
}
