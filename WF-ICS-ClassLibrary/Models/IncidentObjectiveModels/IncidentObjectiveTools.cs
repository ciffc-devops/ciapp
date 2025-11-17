using System;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class IncidentObjectiveTools
    {
        public static int GetObjectiveDepth(this IncidentObjective objective)
        {
            int depth = 0;
            IncidentObjectivesSheet sheet = Globals.incidentService.CurrentIncident.ActiveIncidentObjectiveSheets.FirstOrDefault(o => o.ID == objective.SheetId);
            if (sheet == null) { return 0; }
            IncidentObjective parentObjective = objective.Clone();
            while(parentObjective != null && parentObjective.ParentObjectiveID != Guid.Empty)
            {
                depth++;
                parentObjective = sheet.ActiveObjectives.FirstOrDefault(o=>o.ID == parentObjective.ParentObjectiveID);
            }
            return depth;
        }

        public static string ObjectiveTypeNameByDepth(int depth)
        {
            switch (depth)
            {
                case 0: return "Objective";
                case 1: return "Strategy";
                default: return "Tactic";

            }
        }
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
