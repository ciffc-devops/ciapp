using Microsoft.VisualBasic;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models.IncidentStatusSummaryModels
{
 
    public class IncidentStatusSummary : ICSFormData, ICloneable
    {
        //Fields for the standard form

        //Page 1
        [ProtoMember(1)] private int _ReportVersion;
        [ProtoMember(2)] private int _ReportNumber;
        [ProtoMember(3)] private string _ICAndOrganization;
        [ProtoMember(4)] private string _IMOrganization;
        [ProtoMember(5)] private DateTime _IncidentStart;
        [ProtoMember(6)] private string _IncidentSize;
        [ProtoMember(7)] private double _PercentContained;
        [ProtoMember(8)] private double _PercentCompleted;
        [ProtoMember(9)] private string _IncidentDefinition;
        [ProtoMember(10)] private string _ComplexityLevel;
        [ProtoMember(11)] private DateTime _ReportFromTimePeriod;
        [ProtoMember(56)] private DateTime _ReportToTimePeriod;
        [ProtoMember(12)] private DateTime _DateSubmitted;
        [ProtoMember(13)] private string _PrimarySendTo;
        [ProtoMember(14)] private int _ProvinceID;
        [ProtoMember(15)] private string _District;
        [ProtoMember(16)] private string _City;
        [ProtoMember(17)] private string _Unit;
        [ProtoMember(18)] private string _Jurisdiction;
        [ProtoMember(19)] private string _LocationOwnership;
        [ProtoMember(20)] private double _Longitude;
        [ProtoMember(21)] private double _Latitude;
        [ProtoMember(22)] private string _LocationDatum;
        [ProtoMember(23)] private string _LocationLegalDescription;
        [ProtoMember(24)] private string _ShortLocationDescription;
        [ProtoMember(25)] private string _UTM;
        [ProtoMember(26)] private string _GeoDataNote;
        [ProtoMember(27)] private string _SignificantEvents;
        [ProtoMember(28)] private string _PrimaryMaterialsOrHazards;
        [ProtoMember(29)] private string _DamageAssessmentInfo;
        [ProtoMember(30)] private int[] _StructureSummarySingleResidence = new int[3];
        [ProtoMember(31)] private int[] _StructureSummaryCommercial = new int[3];
        [ProtoMember(32)] private int[] _StructureSummaryMinor = new int[3];
        [ProtoMember(33)] private int[] _StructureSummaryOther = new int[3];
        [ProtoMember(34)] private string _StructureSummaryOtherLabel;

        //Page 2
        [ProtoMember(35)] private int[] _CiviliansImpactedThisPeriod = new int[11];
        [ProtoMember(36)] private int[] _CiviliansImpactedToDate = new int[11];
        [ProtoMember(57)] private bool[] _CiviliansImpactedEstimate = new bool[12];

        [ProtoMember(37)] private int[] _RespondersImpactedThisPeriod = new int[11];
        [ProtoMember(38)] private int[] _RespondersImpactedToDate = new int[11];
        [ProtoMember(58)] private bool[] _RespondersImpactedEstimate = new bool[12];

        [ProtoMember(39)] private string _LifeSafetyHealthRemarks;
        [ProtoMember(40)] private bool[] _HealthThreatManagementActive = new bool[18];
        [ProtoMember(41)] private string[] _HealthThreatManagementOtherLabels = new string[4];
        [ProtoMember(42)] private string _WeatherConcerns;
        [ProtoMember(43)] private string[] _ProjectedEscalation = new string[5];
        [ProtoMember(44)] private string _Objectives;

        //Page 3
        [ProtoMember(45)] private string[] _CurrentThreatSummary = new string[5];
        [ProtoMember(46)] private string[] _CriticalResourcesNeeded = new string[5];
        [ProtoMember(47)] private string _StrategicDiscussion;
        [ProtoMember(48)] private string _PlannedActions;
        [ProtoMember(49)] private string _ProjectedFinalSize;
        [ProtoMember(50)] private DateTime _AnticipatedIMCompleteDate;
        [ProtoMember(51)] private DateTime _ProjectedResourceDemobDate;
        [ProtoMember(52)] private double _EstimatedCostsToDate;
        [ProtoMember(53)] private double _ProjectedFinalCost;
        [ProtoMember(54)] private string _Remarks;

        //Page 4
        [ProtoMember(55)] private string _AdditionalAssistingOrganizations;
        [ProtoMember(59)] private DateTime _ResourceCaptureDateTime;
        [ProtoMember(60)] private List<SummaryAgencyEntry> _SummaryAgencyEntries = new List<SummaryAgencyEntry>();

        public int ReportVersion { get => _ReportVersion; set => _ReportVersion = value; }
        public string ReportVersionName
        {
            get
            {
                switch (ReportVersion)
                {
                    case 0: return "Initial";
                    case 1: return "Update";
                    case 2: return "Final";
                    default: return "Update";
                }
            }
        }
        public int ReportNumber { get => _ReportNumber; set => _ReportNumber = value; }
        public string ReportVersionFull
        {
            get
            {
                if (ReportNumber > 0) { return $"{ReportNumber} - {ReportVersionName}"; }
                else { return $"{ReportVersionName}"; }
            }
        }
        public string ICAndOrganization { get => _ICAndOrganization; set => _ICAndOrganization = value; }
        public string IMOrganization { get => _IMOrganization; set => _IMOrganization = value; }
        public DateTime IncidentStart { get => _IncidentStart; set => _IncidentStart = value; }
        public string IncidentSize { get => _IncidentSize; set => _IncidentSize = value; }
        public double PercentContained { get => _PercentContained; set => _PercentContained = value; }
        public double PercentCompleted { get => _PercentCompleted; set => _PercentCompleted = value; }
        public string IncidentDefinition { get => _IncidentDefinition; set => _IncidentDefinition = value; }
        public string ComplexityLevel { get => _ComplexityLevel; set => _ComplexityLevel = value; }
        public DateTime ReportFromTimePeriod { get => _ReportFromTimePeriod; set => _ReportFromTimePeriod = value; }
        public DateTime ReportToTimePeriod { get => _ReportToTimePeriod; set => _ReportToTimePeriod = value; }
        public DateTime DateSubmitted { get => _DateSubmitted; set => _DateSubmitted = value; }
        public string PrimarySendTo { get => _PrimarySendTo; set => _PrimarySendTo = value; }
        public int ProvinceID { get => _ProvinceID; set => _ProvinceID = value; }
        public string District { get => _District; set => _District = value; }
        public string City { get => _City; set => _City = value; }
        public string Unit { get => _Unit; set => _Unit = value; }
        public string Jurisdiction { get => _Jurisdiction; set => _Jurisdiction = value; }
        public string LocationOwnership { get => _LocationOwnership; set => _LocationOwnership = value; }
        public double Longitude { get => _Longitude; set => _Longitude = value; }
        public double Latitude { get => _Latitude; set => _Latitude = value; }
        public string LocationDatum { get => _LocationDatum; set => _LocationDatum = value; }
        public string LocationLegalDescription { get => _LocationLegalDescription; set => _LocationLegalDescription = value; }
        public string ShortLocationDescription { get => _ShortLocationDescription; set => _ShortLocationDescription = value; }
        public string UTM { get => _UTM; set => _UTM = value; }
        public string GeoDataNote { get => _GeoDataNote; set => _GeoDataNote = value; }
        public string SignificantEvents { get => _SignificantEvents; set => _SignificantEvents = value; }
        public string PrimaryMaterialsOrHazards { get => _PrimaryMaterialsOrHazards; set => _PrimaryMaterialsOrHazards = value; }
        public string DamageAssessmentInfo { get => _DamageAssessmentInfo; set => _DamageAssessmentInfo = value; }
        public int[] StructureSummarySingleResidence { get => _StructureSummarySingleResidence; set => _StructureSummarySingleResidence = value; }
        public int[] StructureSummaryCommercial { get => _StructureSummaryCommercial; set => _StructureSummaryCommercial = value; }
        public int[] StructureSummaryMinor { get => _StructureSummaryMinor; set => _StructureSummaryMinor = value; }
        public int[] StructureSummaryOther { get => _StructureSummaryOther; set => _StructureSummaryOther = value; }
        public string StructureSummaryOtherLabel { get => _StructureSummaryOtherLabel; set => _StructureSummaryOtherLabel = value; }
        public int[] CiviliansImpactedThisPeriod { get => _CiviliansImpactedThisPeriod; set => _CiviliansImpactedThisPeriod = value; }
        public int[] CiviliansImpactedToDate { get => _CiviliansImpactedToDate; set => _CiviliansImpactedToDate = value; }
        public int[] RespondersImpactedThisPeriod { get => _RespondersImpactedThisPeriod; set => _RespondersImpactedThisPeriod = value; }
        public int[] RespondersImpactedToDate { get => _RespondersImpactedToDate; set => _RespondersImpactedToDate = value; }
        public string LifeSafetyHealthRemarks { get => _LifeSafetyHealthRemarks; set => _LifeSafetyHealthRemarks = value; }
        public bool[] HealthThreatManagementActive { get => _HealthThreatManagementActive; set => _HealthThreatManagementActive = value; }
        public string[] HealthThreatManagementOtherLabels { get => _HealthThreatManagementOtherLabels; set => _HealthThreatManagementOtherLabels = value; }
        public string WeatherConcerns { get => _WeatherConcerns; set => _WeatherConcerns = value; }
        public string[] ProjectedEscalation { get => _ProjectedEscalation; set => _ProjectedEscalation = value; }
        public string Objectives { get => _Objectives; set => _Objectives = value; }
        public string[] CurrentThreatSummary { get => _CurrentThreatSummary; set => _CurrentThreatSummary = value; }
        public string[] CriticalResourcesNeeded { get => _CriticalResourcesNeeded; set => _CriticalResourcesNeeded = value; }
        public string StrategicDiscussion { get => _StrategicDiscussion; set => _StrategicDiscussion = value; }
        public string PlannedActions { get => _PlannedActions; set => _PlannedActions = value; }
        public string ProjectedFinalSize { get => _ProjectedFinalSize; set => _ProjectedFinalSize = value; }
        public DateTime AnticipatedIMCompleteDate { get => _AnticipatedIMCompleteDate; set => _AnticipatedIMCompleteDate = value; }
        public DateTime ProjectedResourceDemobDate { get => _ProjectedResourceDemobDate; set => _ProjectedResourceDemobDate = value; }
        public double EstimatedCostsToDate { get => _EstimatedCostsToDate; set => _EstimatedCostsToDate = value; }
        public double ProjectedFinalCost { get => _ProjectedFinalCost; set => _ProjectedFinalCost = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public string AdditionalAssistingOrganizations { get => _AdditionalAssistingOrganizations; set => _AdditionalAssistingOrganizations = value; }
        public bool[] CiviliansImpactedEstimate { get => _CiviliansImpactedEstimate; set => _CiviliansImpactedEstimate = value; }
        public bool[] RespondersImpactedEstimate { get => _RespondersImpactedEstimate; set => _RespondersImpactedEstimate = value; }
        public DateTime ResourceCaptureDateTime { get => _ResourceCaptureDateTime; set => _ResourceCaptureDateTime = value; }
        public List<SummaryAgencyEntry> SummaryAgencyEntries { get => _SummaryAgencyEntries; set => _SummaryAgencyEntries = value; }

        public List<string> GetAllTypes()
        {
            List<string> types = new List<string>();
            foreach (var agency in SummaryAgencyEntries)
            {
                foreach (var resource in agency.Resources)
                {
                    if (!types.Contains(resource.ResourceTypeName))
                    {
                        types.Add(resource.ResourceTypeName);
                    }
                }
            }
            return types.OrderBy(o=>o).ToList();
        }

        public int GetTotalTypes()
        {
            List<string> types = GetAllTypes();
            return types.Count;
        }

        public List<SummaryResourceTotal> GetResourceTotals()
        {
            List<SummaryResourceTotal> totals = new List<SummaryResourceTotal>();
            foreach (var agency in SummaryAgencyEntries)
            {
                foreach (var resource in agency.Resources)
                {
                    var existing = totals.FirstOrDefault(t => t.ResourceKindTypeName == resource.ResourceDisplayName);
                    if (existing == null)
                    {
                        existing = new SummaryResourceTotal
                        {
                            ResourceKindTypeName = resource.ResourceDisplayName,
                            ResourceCount = 0,
                            PersonnelCount = 0
                        };
                        totals.Add(existing);
                    }
                    existing.ResourceCount += resource.ResourceCount;
                    existing.PersonnelCount += resource.PersonnelCount;
                }
            }
            return totals;
        }

        public new IncidentStatusSummary Clone()
        {
            return this.MemberwiseClone() as IncidentStatusSummary;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
