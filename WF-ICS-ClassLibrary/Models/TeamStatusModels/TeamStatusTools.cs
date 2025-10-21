using System;
using System.Collections.Generic;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class TeamStatusTools
    {
        public static TeamStatus GetStatusByID(int id)
        {
            List<TeamStatus> allStatuses = GetAllTeamStatuses();
            if (allStatuses.Where(o => o.StatusID == id).Any())
            {
                return allStatuses.Where(o => o.StatusID == id).First();
            }
            else { return new TeamStatus(); }
        }

        public static List<TeamStatus> GetAllTeamStatuses()
        {
            List<TeamStatus> statuses = new List<TeamStatus>();
            statuses.Add(new TeamStatus(0, "Planned", false));
            statuses.Add(new TeamStatus(1, "Pre-mission prep", true));
            statuses.Add(new TeamStatus(2, "Travel to assignment", true));
            statuses.Add(new TeamStatus(3, "Execution", true));
            statuses.Add(new TeamStatus(4, "Returning from assignment", true));
            statuses.Add(new TeamStatus(5, "Post-mission procedures", true));
            statuses.Add(new TeamStatus(6, "Needs Transport", true));
            statuses.Add(new TeamStatus(8, "Needs Attention", true));
            statuses.Add(new TeamStatus(7, "Complete", false));

            return statuses;
        }

        public static List<TeamStatus> GetMemberAvailableStatuses()
        {
            int[] ids = { 4, 5, 7 };
            List<TeamStatus> statuses = GetAllTeamStatuses();
            statuses = statuses.Where(o => ids.Contains(o.StatusID)).ToList();

            return statuses;
        }

    }
}
