using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class OpCopyTools
    {

        public static AirOperationsSummary CopyAirOperationsSummary(this Incident incident, int CopyFromPeriodNumber, int CopyToPeriodNumber, bool insertItemsAutomatically = true)
        {
            AirOperationsSummary newAirOps = null;
            OperationalPeriod copyFromOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyFromPeriodNumber);
            OperationalPeriod copyToOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyToPeriodNumber);
            AirOperationsSummary copyFromAirOps = incident.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == CopyFromPeriodNumber && o.Active);

            if (copyFromOp != null && copyToOp != null && copyFromAirOps != null)
            {
                newAirOps = incident.allAirOperationsSummaries.FirstOrDefault(o => o.OpPeriod == CopyToPeriodNumber && o.Active);
                if(newAirOps == null)
                {
                    newAirOps = new AirOperationsSummary();
                    newAirOps.Remarks = copyFromAirOps.Remarks;
                    newAirOps.OpPeriod = CopyToPeriodNumber;
                    newAirOps.Sunrise = copyFromAirOps.Sunrise;
                    newAirOps.Sunset = copyFromAirOps.Sunset;
                    newAirOps.MedivacAircraftText = copyFromAirOps.MedivacAircraftText;
                    newAirOps.notam = copyFromAirOps.notam.Clone();
                    newAirOps.notam.OpPeriod = CopyToPeriodNumber;

                    if (insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertAirOperationsSummary(newAirOps);
                    }
                } else
                {
                    newAirOps.Remarks = copyFromAirOps.Remarks;
                    newAirOps.Sunrise = copyFromAirOps.Sunrise;
                    newAirOps.Sunset = copyFromAirOps.Sunset;
                    newAirOps.OpPeriod = CopyToPeriodNumber;
                    newAirOps.MedivacAircraftText = copyFromAirOps.MedivacAircraftText;
                    newAirOps.notam = copyFromAirOps.notam.Clone();
                    newAirOps.notam.OpPeriod = CopyToPeriodNumber;
                    if(insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertAirOperationsSummary(newAirOps);
                    }   
                }
            }

            return newAirOps;
        }


        public static List<SafetyMessage> CopySafetyMessages(this Incident incident, int CopyFromPeriodNumber, int CopyToPeriodNumber, bool insertItemsAutomatically = true)
        {
            List<SafetyMessage> items = new List<SafetyMessage>();
            OperationalPeriod copyFrom = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyFromPeriodNumber);
            OperationalPeriod copyTo = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyToPeriodNumber);
            if (copyFrom != null && copyTo != null)
            {


                foreach (SafetyMessage item in incident.allSafetyMessages.Where(o => o.OpPeriod == CopyFromPeriodNumber && o.Active))
                {
                    if (!incident.allSafetyMessages.Any(o => o.SummaryLine.Equals(item.SummaryLine) && o.Active && o.OpPeriod == CopyToPeriodNumber))
                    {
                        SafetyMessage newItem = new SafetyMessage();

                        newItem.OpPeriod = CopyToPeriodNumber;
                        newItem.ID = Guid.NewGuid();
                        newItem.Message = item.Message;
                        newItem.SitePlanLocation = item.SitePlanLocation;
                        newItem.SitePlanRequired = item.SitePlanRequired;
                        newItem.SummaryLine = item.SummaryLine;
                        newItem.SafetyTemplateID = item.SafetyTemplateID;
                        newItem.ImageBytes = item.ImageBytes;
                        newItem.DatePrepared = DateTime.Now;


                        items.Add(newItem);
                       
                    }
                }

                if (insertItemsAutomatically)
                {
                    foreach (SafetyMessage item in items)
                    {
                        Globals.incidentService.UpsertSafetyMessage(item);
                    }
                }

            }
            return items;
        }


        public static IncidentObjectivesSheet CopyIncidentObjectivesSheet(this Incident incident, int CopyFromPeriodNumber, int CopyToPeriodNumber, bool insertItemsAutomatically = true)
        {
            IncidentObjectivesSheet newObjectivesSheet = null;

            OperationalPeriod copyFromOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyFromPeriodNumber);
            OperationalPeriod copyToOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyToPeriodNumber);
            IncidentObjectivesSheet copyFromPlan = incident.AllIncidentObjectiveSheets.FirstOrDefault(o => o.OpPeriod == CopyFromPeriodNumber && o.Active);

            if (copyFromOp != null && copyToOp != null && copyFromPlan != null)
            {
                newObjectivesSheet = incident.AllIncidentObjectiveSheets.FirstOrDefault(o => o.OpPeriod == CopyToPeriodNumber && o.Active);
                if (newObjectivesSheet == null)
                {
                    newObjectivesSheet = new IncidentObjectivesSheet();
                    newObjectivesSheet.FireSize = copyFromPlan.FireSize;
                    newObjectivesSheet.FireStatus = copyFromPlan.FireStatus;
                    newObjectivesSheet.WeatherForecast = copyFromPlan.WeatherForecast;
                    newObjectivesSheet.GeneralSafety = copyFromPlan.GeneralSafety;

                    newObjectivesSheet.OpPeriod = CopyToPeriodNumber;
                    newObjectivesSheet.DatePrepared = DateTime.Now;

                    if (insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertIncidentObjectivesSheet(newObjectivesSheet);
                    }
                }
                else
                {
                    newObjectivesSheet.FireSize = copyFromPlan.FireSize;
                    newObjectivesSheet.FireStatus = copyFromPlan.FireStatus;
                    newObjectivesSheet.WeatherForecast = copyFromPlan.WeatherForecast;
                    newObjectivesSheet.GeneralSafety = copyFromPlan.GeneralSafety;

                    if (insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertIncidentObjectivesSheet(newObjectivesSheet);
                    }
                }

                
                foreach (IncidentObjective objective in copyFromPlan.ActiveObjectives)
                {
                    IncidentObjective newObjective = objective.Clone();
                    newObjective.OpPeriod = CopyToPeriodNumber;
                    newObjective.ID = Guid.NewGuid();
                    if(!newObjectivesSheet.Objectives.Any(o=>o.Objective.Equals(newObjective.Objective)))
                    {
                        newObjectivesSheet.Objectives.Add(newObjective);
                        if (insertItemsAutomatically) { Globals.incidentService.UpsertIncidentObjective(newObjective); }

                    }

                }

              
            }

            return newObjectivesSheet;
        }

        public static MedicalPlan CopyMedicalPlan(this Incident incident, int CopyFromPeriodNumber, int CopyToPeriodNumber, bool insertItemsAutomatically = true)
        {
            MedicalPlan newMedPlan = null;

            OperationalPeriod copyFromOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyFromPeriodNumber);
            OperationalPeriod copyToOp = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyToPeriodNumber);
            MedicalPlan copyFromPlan = incident.allMedicalPlans.FirstOrDefault(o => o.OpPeriod == CopyFromPeriodNumber && o.Active);


            if (copyFromOp != null && copyToOp != null && copyFromPlan != null)
            {
                newMedPlan = incident.allMedicalPlans.FirstOrDefault(o => o.OpPeriod == CopyToPeriodNumber && o.Active);
                if (newMedPlan == null)
                {
                    newMedPlan = new MedicalPlan();
                    newMedPlan.OpPeriod = CopyToPeriodNumber;
                    if (incident.activeOrgCharts.Any(o => o.OpPeriod == CopyToPeriodNumber))
                    {
                        OrganizationChart currentChart = incident.activeOrgCharts.First(o => o.OpPeriod == CopyToPeriodNumber);
                        newMedPlan.PreparedByResourceName = currentChart.getNameByRoleName("Medical Unit Leader");

                    }
                    newMedPlan.DatePrepared = DateTime.Now;
                    newMedPlan.EmergencyProcedures = copyFromPlan.EmergencyProcedures;
                    if (insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertMedicalPlan(newMedPlan);
                    }
                }
                else
                {
                    newMedPlan.EmergencyProcedures = copyFromPlan.EmergencyProcedures;
                    if (insertItemsAutomatically)
                    {
                        Globals.incidentService.UpsertMedicalPlan(newMedPlan);
                    }
                }
               

                foreach (MedicalAidStation station in copyFromPlan.MedicalAidStations)
                {
                    MedicalAidStation newStation = station.Clone();
                    newStation.ID = Guid.NewGuid();
                    newStation.OpPeriod = CopyToPeriodNumber;

                    newMedPlan.MedicalAidStations.Add(newStation);

                    if (insertItemsAutomatically) { Globals.incidentService.UpsertMedicalAidStation(newStation); }
                }

                foreach (AmbulanceService item in copyFromPlan.Ambulances)
                {
                    AmbulanceService newItem = item.Clone();
                    newItem.ID = Guid.NewGuid();
                    newItem.OpPeriod = CopyToPeriodNumber;

                    newMedPlan.Ambulances.Add(newItem);

                    if (insertItemsAutomatically) { Globals.incidentService.UpsertAmbulance(newItem); }
                }
                foreach (Hospital item in copyFromPlan.Hospitals)
                {
                    Hospital newItem = item.Clone();
                    newItem.ID = Guid.NewGuid();
                    newItem.OpPeriod = CopyToPeriodNumber;

                    newMedPlan.Hospitals.Add(newItem);

                    if (insertItemsAutomatically) { Globals.incidentService.UpsertHospital(newItem); }
                }

            }


            return newMedPlan;
        }



        //This function requires that the OP be created already, and returns the comms items.  It optionally adds those items automatically as well
        public static List<CommsPlanItem> CopyCommunicationsPlan(this Incident incident, int CopyFromPeriodNumber, int CopyToPeriodNumber, bool insertItemsAutomatically = true)
        {
            List<CommsPlanItem> items = new List<CommsPlanItem>();

            OperationalPeriod copyFrom = incident.ActiveOperationalPeriods.FirstOrDefault(o=>o.PeriodNumber == CopyFromPeriodNumber);
            OperationalPeriod copyTo = incident.ActiveOperationalPeriods.FirstOrDefault(o => o.PeriodNumber == CopyToPeriodNumber);
            if (copyFrom != null && copyTo != null)
            {
                incident.createCommsPlanAsNeeded(CopyToPeriodNumber);

                CommsPlan copyFromPlan = incident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == copyFrom.PeriodNumber && o.Active);
                CommsPlan copyToPlan = incident.allCommsPlans.FirstOrDefault(o => o.OpPeriod == copyTo.PeriodNumber && o.Active);
                if (copyFromPlan != null && copyToPlan != null)
                {
                    foreach (CommsPlanItem item in copyFromPlan.ActiveCommsItems)
                    {
                        if (!copyToPlan.ActiveCommsItems.Any(o => o.Equals(item)))
                        {

                            CommsPlanItem newItem = item.Clone();
                            newItem.OpPeriod = CopyToPeriodNumber;
                            newItem.ItemID = Guid.NewGuid();
                            items.Add(newItem);
                            
                            if(insertItemsAutomatically)
                            {
                                Globals.incidentService.UpsertCommsPlanItem(newItem);
                            }
                        }
                    }
                }
            }

            return items;
        }



    }
}
