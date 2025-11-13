using System;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class IncidentObjectiveTools
    {
        public static void RenumberObjectives(this IncidentObjectivesSheet sheet, Guid ParentObjectiveId = new Guid())
        {
            int priority = 1;
            

            foreach (IncidentObjective objective in sheet.ActiveObjectives.Where(o=>o.ParentObjectiveID == ParentObjectiveId).OrderBy(o => o.Priority))
            {
                objective.Priority = priority;
                priority += 1;
                if(sheet.ActiveObjectives.Any(o=> o.ParentObjectiveID == objective.ObjectiveID))
                {
                    sheet.RenumberObjectives(objective.ObjectiveID);
                }
            }

        }

        public static int GetNextPriorityNumber(this IncidentObjectivesSheet sheet, Guid ParentObjectiveId = new Guid())
        {
            if (sheet.ActiveObjectives.Any(o => o.ParentObjectiveID == ParentObjectiveId))
            {
                return sheet.ActiveObjectives.Where(o=> o.ParentObjectiveID == ParentObjectiveId).Max(o => o.Priority) + 1;
            } else { return 1; }
        }
    }
}
