using System;
using System.Collections.Generic;
using System.Linq;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    public class TeamTotal
    {
        public string TeamName { get; set; }
        public int MemberCount { get; set; }
        public TeamTotal()
        {

        }
        public TeamTotal(string name)
        {
            TeamName = name; MemberCount = 0;
        }

        public List<TeamTotal> getTeamTotals(Incident task, int CurrentOpPeriod)
        {
            List<TeamTotal> teamTotals = new List<TeamTotal>();
            List<MemberStatus> allStatuses = task.getAllMemberStatus(CurrentOpPeriod, DateTime.MinValue);
            int totalOverall = 0;
            foreach (MemberStatus status in allStatuses)
            {
                if (!teamTotals.Where(o => o.TeamName == status.OrganizationName).Any())
                {
                    teamTotals.Add(new TeamTotal(status.OrganizationName));
                }
                teamTotals.Where(o => o.TeamName == status.OrganizationName).First().MemberCount += 1;
                totalOverall += 1;
            }
            return teamTotals;
        }
    }

}
