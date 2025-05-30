using System;
using System.Collections.Generic;
using System.Linq;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels
{
    //There are 21 columns for kind or type
    public static class IncidentSummaryTools
    {
        public static int TotalResourceColumnsPerPage = 21;

        public static List<SummaryAgencyEntry> GetAgencyEntries(this Incident incident, DateTime AsOfDateTime)
        {
            OperationalPeriod opPeriod = incident.AllOperationalPeriods.FirstOrDefault(o => o.Active && AsOfDateTime >= o.PeriodStart && AsOfDateTime <= o.PeriodEnd);
            if (opPeriod == null) { return null; }
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            List<CheckInRecord> allRecords = new List<CheckInRecord>(incident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= opPeriod.PeriodNumber));
            foreach (CheckInRecord rec in allRecords)
            {
                IncidentResource resource = new IncidentResource();
                if (incident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                {
                    resource = incident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                }

                if (resource != null && resource.ParentResourceID == Guid.Empty)
                {
                    checkInRecords.Add(new CheckInRecordWithResource(rec, resource, opPeriod.PeriodEnd));
                }
            }


            List<SummaryAgencyEntry> agencyEntries = new List<SummaryAgencyEntry>();
            List<SummaryResourceEntry> resourceEntries = new List<SummaryResourceEntry>();

            foreach (CheckInRecordWithResource record in checkInRecords)
            {
                if (!string.IsNullOrEmpty(record.Resource.AgencyName) && !agencyEntries.Any(o => o.AgencyName.EqualsWithNull(record.Resource.AgencyName)))
                {

                    SummaryAgencyEntry agencyEntry = new SummaryAgencyEntry
                    {
                        AgencyName = record.Resource.AgencyName,
                        Resources = new List<SummaryResourceEntry>()
                    };
                    agencyEntries.Add(agencyEntry);
                }
                SummaryAgencyEntry currentAgency = agencyEntries.FirstOrDefault(o => o.AgencyName == record.Resource.AgencyName);
                if (currentAgency == null) { continue; }

                if (record.Resource.ResourceType == "Personnel")
                {
                    currentAgency.AdditionalPersonnel += record.Resource.NumberOfPeople;
                }
                else
                {
                    if (resourceEntries.Any(o => o.ResourceKindName.EqualsWithNull(record.Resource.Kind) && o.ResourceTypeName.EqualsWithNull(record.Resource.Type) && o.AgencyName.EqualsWithNull(record.Resource.AgencyName)))
                    {
                        SummaryResourceEntry existingEntry = resourceEntries.First(o => o.ResourceKindName.EqualsWithNull(record.Resource.Kind) && o.ResourceTypeName.EqualsWithNull(record.Resource.Type) && o.AgencyName.EqualsWithNull(record.Resource.AgencyName));
                        existingEntry.ResourceCount += record.Resource.NumberOfVehicles;
                        existingEntry.PersonnelCount += record.Resource.NumberOfPeople;
                    }
                    else
                    {
                        SummaryResourceEntry resourceEntry = new SummaryResourceEntry
                        {
                            ResourceKindName = record.Resource.Kind,
                            ResourceTypeName = record.Resource.Type,
                            AgencyName = record.Resource.AgencyName,
                            ResourceCount = record.Resource.NumberOfVehicles,
                            PersonnelCount = record.Resource.NumberOfPeople
                        };
                        resourceEntries.Add(resourceEntry);
                    }
                }


            }

            //Okay, now we have a list of all the agencies, and all teh resources by agency, kind, and type
            //how many unique kind and type combinations do we have?
            
            int totalTypes = resourceEntries.GroupBy(x => new { x.ResourceKindName, x.ResourceTypeName }).Count();
            int totalKinds = resourceEntries.GroupBy(o => o.ResourceKindName).Count();

            bool useTypes = totalTypes <= TotalResourceColumnsPerPage;

            if (useTypes)
            {
                foreach (SummaryAgencyEntry agency in agencyEntries)
                {
                    agency.Resources.AddRange(resourceEntries.Where(o => o.AgencyName.Equals(agency.AgencyName)));
                    foreach(SummaryResourceEntry resource in agency.Resources)
                    {
                        resource.ResourceDisplayName = $"{resource.ResourceKindName} {resource.ResourceTypeName}";
                    }
                }
            } else
            {
                foreach (SummaryAgencyEntry agency in agencyEntries)
                {
                    agency.Resources = resourceEntries
                        .Where(o => o.AgencyName.Equals(agency.AgencyName))
                        .GroupBy(o => o.ResourceTypeName)
                        .Select(g => new SummaryResourceEntry
                        {
                            ResourceKindName = g.Key,
                            ResourceTypeName = string.Join(", ", g.Select(r => r.ResourceTypeName).Distinct()),
                            AgencyName = agency.AgencyName,
                            ResourceDisplayName = g.Key,
                            ResourceCount = g.Sum(r => r.ResourceCount),
                            PersonnelCount = g.Sum(r => r.PersonnelCount)
                        }).ToList();
                }
            }

            return agencyEntries;
        }
    }
}
