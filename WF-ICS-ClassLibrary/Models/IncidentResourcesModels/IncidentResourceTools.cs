using System.Collections.Generic;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public static class IncidentResourceTools
    {
        public static List<IncidentResource> GetAllResources(this WFIncident incident, int OpPeriod)
        {
            List<IncidentResource> resources = new List<IncidentResource>();
            resources.AddRange(incident.GetCurrentlySignedInPersonnel(OpPeriod));
            resources.AddRange(incident.allVehicles.Where(o=>o.Active && o.OpPeriod == OpPeriod));
            resources.AddRange(incident.AllOperationalSubGroups.Where(o => o.Active && o.OpPeriod == OpPeriod));
            return resources;
        }
    }
}
