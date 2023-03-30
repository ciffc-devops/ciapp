using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class SummaryStat
    {
        public string Category { get; set; }
        public string Text { get; set; }
        public int OpTotal { get; set; }
        public int IncidentToDate { get; set; }
        public string IncidentToDateStr {  get { if(IncidentToDate >= 0) { return IncidentToDate.ToString(); } return string.Empty; } }
        public string MoreInfo { get; set; }
        public string MoreInfoTitle { get { if (string.IsNullOrEmpty(MoreInfo)) { return string.Empty; } else { return "Info"; } } }

        public SummaryStat() { }
        public SummaryStat(string cat, string txt, string mi, int optotal = 0, int incidenttodate = 0)
        {
            Category = cat; Text = txt; OpTotal = optotal; IncidentToDate = incidenttodate; MoreInfo = mi;
        }
    }

    public static class SummaryStatTools
    {
        public static List<SummaryStat> GetSummaryPersonHours(this WFIncident incident, int OpPeriod)
        {
            List<SummaryStat> stats = new List<SummaryStat>();
            OperationalPeriod period = incident.AllOperationalPeriods.First(o=>o.PeriodNumber == OpPeriod); 

            stats.Add(new SummaryStat("Person Hours", period.PeriodStart.ToString(Globals.DateFormat) + " - " + period.PeriodEnd.ToString(Globals.DateFormat), "This assumes everyone was working during the operational periods during which they were checked in.  If tere are times of reduced activity, or operational periods where not all chcecked in resources are used this number will be inaccurate."));

            List<OperationalPeriod> periodsToDate = incident.AllOperationalPeriods.Where(o => o.PeriodNumber <= OpPeriod).ToList();
            foreach(CheckInRecord rec in incident.AllCheckInRecords.Where(o=>o.CheckInDate < period.PeriodEnd && o.IsPerson))
            {
                stats[0].OpTotal += rec.TotalHoursOnIncident(period);
                stats[0].IncidentToDate += rec.TotalHoursOnIncident(periodsToDate);
            }
            return stats;
        }

        public static int TotalHoursOnIncident(this CheckInRecord rec, List<OperationalPeriod> periods)
        {
            int hours = 0;

            foreach(OperationalPeriod p in periods)
            {
                DateTime start = p.PeriodStart;
                DateTime end = p.PeriodEnd;
                if(rec.CheckInDate > start) { start = rec.CheckInDate; }
                if(rec.CheckOutDate < end) { end = rec.CheckOutDate; }
                TimeSpan ts = end - start;
                hours += Convert.ToInt32(ts.TotalHours);
            }

            return hours;
        }
        public static int TotalHoursOnIncident(this CheckInRecord rec, OperationalPeriod p)
        {
            int hours = 0;


            DateTime start = p.PeriodStart;
            DateTime end = p.PeriodEnd;
            if (rec.CheckInDate > start) { start = rec.CheckInDate; }
            if (rec.CheckOutDate < end) { end = rec.CheckOutDate; }
            TimeSpan ts = end - start;
            hours += Convert.ToInt32(ts.TotalHours);


            return hours;
        }

        public static List<SummaryStat> GetSummaryPersonnelPerSection(this WFIncident incident, int OpPeriod)
        {
            List<SummaryStat> stats = new List<SummaryStat>();

            stats.Add(new SummaryStat("Personnel by Section", "Incident Command", "Includes people filling command, officer, and other roles outside the other sections."));
            stats.Add(new SummaryStat("Personnel by Section", "Operations Section", "Includes operational personnel such as crew members"));
            stats.Add(new SummaryStat("Personnel by Section", "Planning Section", ""));
            stats.Add(new SummaryStat("Personnel by Section", "Logistics Section", ""));
            stats.Add(new SummaryStat("Personnel by Section", "Finance Admin Section", ""));

            OrganizationChart currentOrg = incident.allOrgCharts.First(o=>o.OpPeriod == OpPeriod);

            stats[0].OpTotal = currentOrg.ActiveRoles.Count(o => o.IndividualID != Guid.Empty && o.SectionID == Globals.IncidentCommanderID);
            stats[1].OpTotal = currentOrg.ActiveRoles.Count(o => o.IndividualID != Guid.Empty && o.SectionID == Globals.OpsChiefID);
            List<OperationalGroup> opsGroups = incident.ActiveOperationalGroups.Where(o => o.ActiveResourceListing.Any()).ToList();
            foreach (OperationalGroup op in opsGroups) { stats[1].OpTotal += op.ActiveResourceListing.Sum(o => o.NumberOfPeople); }
            stats[2].OpTotal = currentOrg.ActiveRoles.Count(o => o.IndividualID != Guid.Empty && o.SectionID == Globals.PlanningChiefID);
            stats[3].OpTotal = currentOrg.ActiveRoles.Count(o => o.IndividualID != Guid.Empty && o.SectionID == Globals.LogisticsChiefID);
            stats[4].OpTotal = currentOrg.ActiveRoles.Count(o => o.IndividualID != Guid.Empty && o.SectionID == Globals.FinanceChiefID);

            stats[0].IncidentToDate = -1;
            stats[1].IncidentToDate = -1;
            stats[2].IncidentToDate = -1;
            stats[3].IncidentToDate = -1;
            stats[4].IncidentToDate = -1;



            return stats;

        }

        public static List<SummaryStat> GetSummaryResourceCounts(this WFIncident incident, int opPeriod)
        {
            List<SummaryStat> stats = new List<SummaryStat>();

            OperationalPeriod operationalPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == opPeriod);

            List<CheckInRecordWithResource> resources = incident.GetAllCheckInWithResources(opPeriod);

            foreach (CheckInRecordWithResource rec in resources)
            {

                string variety = rec.ResourceType;
                if (!stats.Any(o => o.Text.Equals(variety, StringComparison.OrdinalIgnoreCase)))
                {
                    stats.Add(new SummaryStat("Resource Varieties", variety, "Includes resources contained within crews / heavy equipment crews"));
                }
                stats.First(o => o.Text.Equals(variety, StringComparison.InvariantCultureIgnoreCase)).IncidentToDate += 1;
                if (rec.Record.CheckedInThisTime(operationalPeriod.PeriodMid))
                {
                    stats.First(o => o.Text.Equals(variety, StringComparison.InvariantCultureIgnoreCase)).OpTotal += 1;
                }

                if(rec.Record.ParentRecordID == Guid.Empty && rec.ResourceType.Equals("Personnel"))
                {
                    string subvariety = rec.ResourceType + " (excluding people in crews)";
                    if (!stats.Any(o => o.Text.Equals(subvariety, StringComparison.OrdinalIgnoreCase)))
                    {
                        stats.Add(new SummaryStat("Resource Varieties", subvariety, ""));
                    }
                    stats.First(o => o.Text.Equals(subvariety, StringComparison.InvariantCultureIgnoreCase)).IncidentToDate += 1;
                    if (rec.Record.CheckedInThisTime(operationalPeriod.PeriodMid))
                    {
                        stats.First(o => o.Text.Equals(subvariety, StringComparison.InvariantCultureIgnoreCase)).OpTotal += 1;
                    }
                }

            }
            stats = stats.OrderBy(o => o.Text).ToList();
            return stats;
        }


    }
}
