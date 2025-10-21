using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class IncidentObjectiveTools
    {
        public static void RenumberObjectives(this IncidentObjectivesSheet sheet)
        {
            int priority = 1;
            

            foreach (IncidentObjective objective in sheet.ActiveObjectives.OrderBy(o => o.Priority))
            {
                objective.Priority = priority;
                priority += 1;
            }

        }

        public static int GetNextPriorityNumber(this IncidentObjectivesSheet sheet)
        {
            if (sheet.ActiveObjectives.Any())
            {
                return sheet.ActiveObjectives.Max(o => o.Priority) + 1;
            } else { return 1; }
        }
    }
}
