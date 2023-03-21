using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CheckInRecord : ICloneable
    {
        [ProtoMember(1)] private DateTime _CheckInDate;
        [ProtoMember(2)] private DateTime _CheckOutDate;
        [ProtoMember(3)] private Guid _SignInRecordID;
        [ProtoMember(4)] private DateTime _LastUpdatedUTC;
        [ProtoMember(5)] private DateTime _LastDayOnIncident;
        [ProtoMember(6)] private int _PersonalIncidentNumber;
        [ProtoMember(7)] private Guid _ResourceID;
        [ProtoMember(8)] private string _ResourceName;
        [ProtoMember(9)] private List<CheckInInfoField> _InfoFields;
        [ProtoMember(10)] private bool _Active;
        [ProtoMember(11)] private int _OpPeriod;
        [ProtoMember(12)] private string _ResourceType;
        [ProtoMember(13)] private Guid _ParentRecordID;
        [ProtoMember(14)] private DateTime _LastDayOfRest;
        public CheckInRecord() { SignInRecordID = Guid.NewGuid(); InfoFields = new List<CheckInInfoField>(); CheckOutDate = DateTime.MaxValue; Active = true; }


        public DateTime CheckInDate { get => _CheckInDate; set => _CheckInDate = value; }
        public DateTime CheckOutDate { get => _CheckOutDate; set => _CheckOutDate = value; }
        public Guid SignInRecordID { get => _SignInRecordID; set => _SignInRecordID = value; }
        public Guid ParentRecordID { get => _ParentRecordID; set => _ParentRecordID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public DateTime LastDayOnIncident { get => _LastDayOnIncident; set => _LastDayOnIncident = value; }
        public int PersonalIncidentNumber { get => _PersonalIncidentNumber; set => _PersonalIncidentNumber = value; }
        public Guid ResourceID { get => _ResourceID; set => _ResourceID = value; }
        public string ResourceName { get => _ResourceName; set => _ResourceName = value; }
        public List<CheckInInfoField> InfoFields { get => _InfoFields; set => _InfoFields = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string ResourceType { get => _ResourceType; set => _ResourceType = value; }
        public bool IsPerson { get { return ResourceType.EqualsWithNull("Person") || ResourceType.Equals("Personnel"); } }
        public bool IsOperator { get { return ResourceType.EqualsWithNull("Operator") || ResourceType.Equals("Operator"); } }
        public bool IsVehicle { get { return ResourceType.EqualsWithNull("Vehicle") || ResourceType.Equals("Vehicle"); } }
        public bool IsEquipment { get { return ResourceType.EqualsWithNull("Equipment") || ResourceType.Equals("Equipment"); } }
        public bool IsVisitor { get { return ResourceType.EqualsWithNull("Visitor"); } }
        public bool IsCrew { get { return ResourceType.EqualsWithNull("Crew"); } }
        public bool HasCheckOutTime { get => CheckOutDate < DateTime.MaxValue; }
        public DateTime LastDayOfRest { get => _LastDayOfRest; set => _LastDayOfRest = value; }

        public CheckInRecord Clone()
        {
            CheckInRecord cloneTo = this.MemberwiseClone() as CheckInRecord;
            cloneTo.InfoFields = new List<CheckInInfoField>();
            foreach (CheckInInfoField field in InfoFields) { cloneTo.InfoFields.Add(field.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }

    [ProtoContract]
    [Serializable]
    public class CheckInInfoField : ICloneable
    {
        public CheckInInfoField() { ID = Guid.NewGuid(); }
        public CheckInInfoField(Guid id, string name, string type, string group, bool visitor, bool person, bool vehicle, bool crew, bool equip, bool op, bool reqd, string tooltip)
        {
            ID = id; Name = name; FieldType = type; FieldGroup = group;  IsRequired = reqd;ToolTipText = tooltip;
            UseForVisitor = visitor; UseForPersonnel = person; UseForVehicle = vehicle; UseForCrew = crew; UseForEquipment = equip; UseForOperator = op;
        }

        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private string _FieldType;
        [ProtoMember(4)] private string _FieldGroup;
        [ProtoMember(5)] private int _SortOrder;
        [ProtoMember(6)] private string _StringValue;
        [ProtoMember(7)] private bool _BoolValue;
        [ProtoMember(8)] private int _IntValue;
        [ProtoMember(9)] private bool _UseForVisitor;
        [ProtoMember(10)] private bool _UseForPersonnel;
        [ProtoMember(11)] private bool _UseForVehicle;
        [ProtoMember(12)] private bool _UseForCrew;
        [ProtoMember(13)] private DateTime _DateValue;
        [ProtoMember(14)] private bool _IsRequired;
        [ProtoMember(15)] private string _ToolTipText;
        [ProtoMember(10)] private bool _UseForEquipment; 
        [ProtoMember(10)] private bool _UseForOperator;

        public Guid ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string FieldType { get => _FieldType; set => _FieldType = value; }
        public string FieldGroup { get => _FieldGroup; set => _FieldGroup = value; }
        public int SortOrder { get => _SortOrder; set => _SortOrder = value; }
        public string StringValue { get => _StringValue; set => _StringValue = value; }
        public bool BoolValue { get => _BoolValue; set => _BoolValue = value; }
        public int IntValue { get => _IntValue; set => _IntValue = value; }
        public bool UseForVisitor { get => _UseForVisitor; set => _UseForVisitor = value; }
        public bool UseForPersonnel { get => _UseForPersonnel; set => _UseForPersonnel = value; }
        public bool UseForVehicle { get => _UseForVehicle; set => _UseForVehicle = value; }
        public bool UseForCrew { get => _UseForCrew; set => _UseForCrew = value; }
        public DateTime DateValue { get => _DateValue; set => _DateValue = value; }
        public bool IsRequired { get => _IsRequired; set => _IsRequired = value; }
        public string ToolTipText { get => _ToolTipText; set => _ToolTipText = value; }
        public bool UseForEquipment { get => _UseForEquipment; set => _UseForEquipment = value; }
        public bool UseForOperator { get => _UseForOperator; set => _UseForOperator = value; }


        public CheckInInfoField Clone()
        {
            CheckInInfoField cloneTo = this.MemberwiseClone() as CheckInInfoField;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    public class CheckInRecordWithResource 
    {
        private Guid _ID;

        private CheckInRecord _Record = new CheckInRecord();
        private IncidentResource _Resource = new IncidentResource();
        private string _StatusText;

        public IncidentResource Resource { get => _Resource; }
        public CheckInRecord Record { get => _Record; }
        public Guid ID { get => _ID; }
        public string ResourceType { get => _Record.ResourceType; }
        public string Kind { get => Resource.Kind; }
        public string Type { get => Resource.Type; }
        public int NumberOfPeople { get => Resource.NumberOfPeople; }
        public int NumberOfVehicles { get => Resource.NumberOfVehicles; }
        public DateTime CheckInDate { get => Record.CheckInDate; }
        public DateTime CheckOutDate { get => Record.CheckOutDate;}
        public DateTime LastDayOnIncident { get { if (Record.LastDayOnIncident < Record.CheckOutDate) { return Record.LastDayOnIncident; } else { return Record.CheckOutDate; } } }
        public string ResourceName { get => Resource.ResourceName; }
        public string LeaderName { get => Resource.LeaderName; }
        public string Status { get => _StatusText; set => _StatusText = value; }
        public int DaysTillTimeOut { get; set; }


        public CheckInRecordWithResource() { _ID = Guid.NewGuid(); }
        public CheckInRecordWithResource(CheckInRecord rec, IncidentResource res, DateTime EndOfOp)
        {
            _ID = Guid.NewGuid();
            _Record = rec;
            _Resource = res;
            TimeSpan ts = LastDayOnIncident - EndOfOp;
            DaysTillTimeOut = Convert.ToInt32( Math.Round(ts.TotalDays, 0));
            if(Record.CheckOutDate < EndOfOp) { _StatusText = "Checked-Out"; } else { _StatusText = "Actvie"; }
        }
    }

    public static class CheckInTools
    {
        public static bool ResourceIsCheckedIn(this WFIncident incident, Guid ResourceID, DateTime AtThisTime)
        {
            if (incident.AllCheckInRecords.Any(o => o.Active && o.ResourceID == ResourceID))
            {

                return incident.AllCheckInRecords.Any(o => o.ResourceID == ResourceID && o.Active && o.CheckInDate <= AtThisTime && o.CheckOutDate >= AtThisTime && o.LastDayOnIncident.Date >= AtThisTime.Date);

            }
            return false;
        }

        public static List<Personnel> GetCurrentlySignedInPersonnel(this WFIncident incident, int OpPeriod)
        {
            OperationalPeriod per = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
            DateTime atNow = per.PeriodEnd.AddMinutes(-5);
            return incident.IncidentPersonnel.Where(o => o.Active && incident.ResourceIsCheckedIn(o.ID, atNow)).OrderBy(o=>o.Name).ToList();
        }

        public static List<CheckInInfoField> GetInfoFields(string CheckInType)
        {
            List<CheckInInfoField> fields = GetAllInfoFields();
            switch (CheckInType)
            {
                case "Visitor": return fields.Where(o => o.UseForVisitor).ToList();
                case "Crew": return fields.Where(o => o.UseForCrew).ToList();
                case "Personnel": return fields.Where(o => o.UseForPersonnel).ToList();
                case "Vehicle": return fields.Where(o => o.UseForVehicle).ToList();
                case "Equipment": return fields.Where(o => o.UseForVehicle).ToList();
                case "Operator": return fields.Where(o => o.UseForVehicle).ToList();
            }
            return new List<CheckInInfoField>();
        }

        private static List<CheckInInfoField> GetAllInfoFields()
        {
            List<CheckInInfoField> fields = new List<CheckInInfoField>
            {
                new CheckInInfoField(new Guid("10a107d2-4bec-43af-bedf-87837fbcb447"), "Individuals weight ", "String", "Individual Info", false, true, false,true,false,true,false, "Enter the individuals seat weight. "),
                new CheckInInfoField(new Guid("1d50d619-bfbe-4c1a-ae9b-13cfe66ac654"), "Unique Crew Identifier", "String", "Crew Info", false, false, false,true,false,false,true, "Enter the crews unique agency identifer i.e. RU01, Flathead Unit crew, Dryden IA, etc. "),
                new CheckInInfoField(new Guid("b496b1a3-3efa-4714-b15d-d17d311a919d"), "CIFFC Crew Identifier", "String", "Crew Info", false, false, false,true,false,false,false, "Enter the CIFFC crew identifier if the crew is imported through CIFFC i.e C-30"),
                new CheckInInfoField(new Guid("538d4802-cd56-49d1-aa06-f1fbf269f6f5"), "Contact Info i.e. cell and email", "String", "Crew Info", false, false, false,true,false,false,true, "0"),
                new CheckInInfoField(new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d"), "Resource Order Number", "String", "Deployment Information", false, true, true,true,true,true,false, "Enter agency specific order number or order identifier. "),
                new CheckInInfoField(new Guid("3ac1684c-f882-484b-b31e-e9cd6c21c1f9"), "Position On Incident", "String", "Deployment Information", false, true, true,false,true,true,true, "0"),
                new CheckInInfoField(new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe"), "Check-In Location", "List", "Check In Information", true, true, true,true,true,true,true, "0"),
                new CheckInInfoField(new Guid("c62a8935-7413-41f1-a2b2-682d4064b08a"), "Check-In Date", "String", "Check In Information", true, true, true,true,true,true,true, "0"),
                new CheckInInfoField(new Guid("4836ad52-a6a8-4faa-b6f4-39ef941476b1"), "Check-In Time", "String", "Check In Information", true, true, true,true,true,true,true, "0"),
                new CheckInInfoField(new Guid("eacbe40c-d674-40d6-a5eb-3f807e13277a"), "Last Day of Rest", "String", "Check In Information", false, true, false,true,false,true,true, "Enter the resources last day of rest/day off. "),
                new CheckInInfoField(new Guid("9afc627f-bdad-4076-8d9a-3511759ea2bf"), "First Day on Incident", "String", "Check In Information", true, true, true,true,true,true,true, "0"),
                new CheckInInfoField(new Guid("49602e27-8603-4d24-8228-83a3ed4d81d4"), "Last Day on Incident", "String", "Check In Information", true, true, true,true,true,true,true, "0"),
                new CheckInInfoField(new Guid("cb7f504c-6233-4c4d-aa67-780b8c90baa7"), "Agency i.e. Parks Canada, Alberta, Town Of Banff, City of Ft.McMurray, Canada Task Force 2, etc", "String", "Check In Information", true, true, true,true,true,true,true, "Enter the resources home agency. "),
                new CheckInInfoField(new Guid("7a39df77-cb16-463c-812b-573bfa97de5d"), "Accomodation Location", "List", "Logistics", true, true, false,true,false,true,false, "Enter where the resource is staying. "),
                new CheckInInfoField(new Guid("09e8e520-a82e-491f-a82e-ed108e809392"), "Breakfast", "Bool", "Logistics", true, true, false,true,false,true,false, "0"),
                new CheckInInfoField(new Guid("8355bc4b-238c-4992-9ded-0cff32f1bbf4"), "Lunch", "Bool", "Logistics", true, true, false,true,false,true,false, "0"),
                new CheckInInfoField(new Guid("dd5a2327-bfdc-42fb-a3b4-e6e68fd1d488"), "Dinner", "Bool", "Logistics", true, true, false,true,false,true,false, "0"),
                new CheckInInfoField(new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89"), "Method of Travel to Incident", "List", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("2e69adbd-126b-4ae1-abc0-919dca191f68"), "Vehicle License #", "String", "Logistics", false, false, true,false,false,false,false, "0"),
                new CheckInInfoField(new Guid("ec82d677-a731-4a31-8bb8-452cbafaa58b"), "Year / Make / Model", "String", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("8c78ca45-d18d-4bc4-8993-848f6b088e7f"), "Agency Owned Vehicle", "Bool", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("c1399559-2ac8-49da-8ce8-cd711365417d"), "Rental Vehicle ", "Bool", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("f9aa8b53-d619-422c-8825-bc3da2a4d67d"), "Contractor Vehicle(s)", "Bool", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("c8adde5b-cb21-4b31-8a90-e5b46f192368"), "Private Vehicle ", "Bool", "Logistics", true, true, true,true,true,true,false, "0"),
                new CheckInInfoField(new Guid("3208d48d-eaf2-4f9e-b526-3d3437610d16"), "Mobile Equip - Incident Identification Number ('V' numbers)", "String", "Logistics", true, true, false,true,false,false,false, "0"),
                new CheckInInfoField(new Guid("40718587-d6ee-480a-8451-6c7f02d272a5"), "Fireline equipment/gear needed from supply unit", "String", "Logistics", true, true, false,true,false,false,false, "0"),
                new CheckInInfoField(new Guid("99c4d8c6-3b39-42f1-af6f-33525b2da4e7"), "Reason for visit", "List", "Visitor Info", true, false, false,false,false,false,true, "0"),
                new CheckInInfoField(new Guid("c3704eab-5c8e-4619-91f0-4df014560c7a"), "Incident contact", "String", "Visitor Info", true, false, false,false,false,false,true, "Enter the IMT individual who the visitor is to report to."),
                new CheckInInfoField(new Guid("ad5b511a-a99f-4310-ba66-4eeb41ec6ab9"), "Duration of Visit", "String", "Visitor Info", true, false, false,false,false,false,true, "Enter the duration of visit down to the nearest day. If the visit is only for 2 hours then enter 1 day. "),


            };


            return fields;
        }

        public static List<string> GetInfoFieldListOptions(Guid FieldID)
        {
            switch (FieldID.ToString())
            {
                case "b4c8332b-ddf3-4d4c-9c83-2c62328061fe": return new List<string> { "", "ICP", "Base", "Camp", "Staging", "Heli-Base", "free text" };
                case "7a39df77-cb16-463c-812b-573bfa97de5d": return new List<string> { "", "Incident Camp", "Other" };
                case "a4f1cb0e-9774-4bdc-aeac-96976aceba89": return new List<string> { "", "Aircraft", "Bus", "Vehicle" };
                case "99c4d8c6-3b39-42f1-af6f-33525b2da4e7": return new List<string> { "", "Research", "maintenance", "servicing equipment", "servicing facilities", "observing", "free text" };
                default:
                    return new List<string>();
            }



        }
    }

    [Serializable]
    [ProtoContract]
    public class DemobilizationRecord : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private Guid _SignInRecordID;
        [ProtoMember(3)] private Guid _ResourceID;
        [ProtoMember(4)] private DateTime _DemobDate;
        [ProtoMember(5)] private string _DemobLocation;
        [ProtoMember(6)] private DateTime _DebriefDate;
        [ProtoMember(7)] private string _DebriefLocation;
        [ProtoMember(8)] private bool _InventoryReconciled;
        [ProtoMember(9)] private bool _DiscrepanciesWithSupply;
        [ProtoMember(10)] private bool _DiscrepanciesWithFacilities;
        [ProtoMember(11)] private bool _DiscrepanciesWithFinance;
        [ProtoMember(12)] private bool _ICS211Completed;
        [ProtoMember(13)] private string _TravelTimeToHomeUnit;
        [ProtoMember(14)] private bool _Active;
        [ProtoMember(15)] private int _OpPeriod;
        [ProtoMember(16)] private DateTime _LastUpdatedUTC;
        [ProtoMember(17)] private bool _PerformanceRatingCompleted;


        public DemobilizationRecord() { ID = Guid.NewGuid(); Active = true; }


        public Guid ID { get => _ID; set => _ID = value; }
        public Guid SignInRecordID { get => _SignInRecordID; set => _SignInRecordID = value; }
        public Guid ResourceID { get => _ResourceID; set => _ResourceID = value; }
        public DateTime DemobDate { get => _DemobDate; set => _DemobDate = value; }
        public string DemobLocation { get => _DemobLocation; set => _DemobLocation = value; }
        public DateTime DebriefDate { get => _DebriefDate; set => _DebriefDate = value; }
        public string DebriefLocation { get => _DebriefLocation; set => _DebriefLocation = value; }
        public bool InventoryReconciled { get => _InventoryReconciled; set => _InventoryReconciled = value; }
        public bool DiscrepanciesWithSupply { get => _DiscrepanciesWithSupply; set => _DiscrepanciesWithSupply = value; }
        public bool DiscrepanciesWithFacilities { get => _DiscrepanciesWithFacilities; set => _DiscrepanciesWithFacilities = value; }
        public bool DiscrepanciesWithFinance { get => _DiscrepanciesWithFinance; set => _DiscrepanciesWithFinance = value; }
        public bool ICS211Completed { get => _ICS211Completed; set => _ICS211Completed = value; }
        public string TravelTimeToHomeUnit { get => _TravelTimeToHomeUnit; set => _TravelTimeToHomeUnit = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool PerformanceRatingCompleted { get => _PerformanceRatingCompleted; set => _PerformanceRatingCompleted = value; }


        public DemobilizationRecord Clone()
        {
            DemobilizationRecord cloneTo = this.MemberwiseClone() as DemobilizationRecord;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

}
