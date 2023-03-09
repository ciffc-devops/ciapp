using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool IsVehicle { get { return ResourceType.EqualsWithNull("Vehicle") || ResourceType.Equals("Vehicle/Equipment"); } }
        public bool IsVisitor { get { return ResourceType.EqualsWithNull("Visitor"); } }
        public bool IsCrew { get { return ResourceType.EqualsWithNull("Crew"); } }
        public bool HasCheckOutTime { get => CheckOutDate < DateTime.MaxValue; }


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
        public CheckInInfoField(Guid id, string name, string type, string group, bool visitor, bool person, bool vehicle, bool crew, bool reqd, string tooltip)
        {
            ID = id; Name = name; FieldType = type; FieldGroup = group; UseForVisitor = visitor; UseForPersonnel = person; UseForVehicle = vehicle; UseForCrew = crew; IsRequired = reqd;ToolTipText = tooltip;
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
        public DateTime LastDayOnIncident { get => Record.LastDayOnIncident; }
        public string ResourceName { get => Resource.ResourceName; }
        public string LeaderName { get => Resource.LeaderName; }
        public string Status { get
            {
                if(CheckOutDate < DateTime.MaxValue) { return "Checked Out"; }
                else { return "Active"; }
            } }

        public CheckInRecordWithResource() { _ID = Guid.NewGuid(); }
        public CheckInRecordWithResource(CheckInRecord rec, IncidentResource res)
        {
            _ID = Guid.NewGuid();
            _Record = rec;
            _Resource = res;   
        }
    }

    public static class CheckInTools
    {
        public static bool ResourceIsCheckedIn(this WFIncident incident, Guid ResourceID, DateTime AtThisTime)
        {
            if (incident.AllCheckInRecords.Any(o => o.Active && o.ResourceID == ResourceID))
            {
                return incident.AllCheckInRecords.Any(o => o.Active && o.CheckInDate <= AtThisTime && o.CheckOutDate >= AtThisTime);

            }
            return false;
        }

        public static List<Personnel> GetCurrentlySignedInPersonnel(this WFIncident incident, int OpPeriod)
        {
            OperationalPeriod per = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
            DateTime atNow = per.PeriodEnd.AddMinutes(-5);
            return incident.IncidentPersonnel.Where(o => o.Active && incident.ResourceIsCheckedIn(o.ID, atNow)).ToList();
        }

        public static List<CheckInInfoField> GetInfoFields(string CheckInType)
        {
            List<CheckInInfoField> fields = GetAllInfoFields();
            switch (CheckInType)
            {
                case "Visitor": return fields.Where(o => o.UseForVisitor).ToList();
                case "Crew": return fields.Where(o => o.UseForCrew).ToList();
                case "Personnel": return fields.Where(o => o.UseForPersonnel).ToList();
                case "Vehicle/Equipment": return fields.Where(o => o.UseForVehicle).ToList();
            }
            return new List<CheckInInfoField>();
        }

        private static List<CheckInInfoField> GetAllInfoFields()
        {
            List<CheckInInfoField> fields = new List<CheckInInfoField>
            {
new CheckInInfoField(new Guid("ffdc56b0-f36e-43ff-b412-813c0435ba0d"), "Individuals weight ", "String", "Individual Info", false, true, false,false,false, ""),
new CheckInInfoField(new Guid("5e1e518c-73db-43a2-8621-779e3e10ae88"), "Resource Order Number", "String", "Deployment Information", false, true, true,false,false, ""),
new CheckInInfoField(new Guid("172791a7-2fe9-4e0a-9ac8-46d3efedf133"), "Position On Incident", "String", "Deployment Information", false, true, true,false,false, ""),
new CheckInInfoField(new Guid("3aefed78-eaf9-4f52-a222-43fc389933ce"), "Check-In Location", "List", "Check In Information", false, true, true,true,false, ""),
new CheckInInfoField(new Guid("c6755f41-2073-474e-9e40-7fb73447aa69"), "Last Day of Rest", "DateTime", "Check In Information", false, true, false,true,false, ""),
new CheckInInfoField(new Guid("17fe99e1-4a2c-4e15-9ae0-cc3258444b65"), "First Day on Incident", "DateTime", "Check In Information", false, true, true,true,false, ""),
new CheckInInfoField(new Guid("10a107d2-4bec-43af-bedf-87837fbcb447"), "In-briefing location & time", "String", "Check In Information", false, true, false,true,false, ""),
new CheckInInfoField(new Guid("c9f49654-b5e5-4291-886b-8d24aaef5045"), "Accomodation Location", "List", "Logistics", true, true, false,true,false, ""),
new CheckInInfoField(new Guid("43fe7e33-4d3d-4866-8401-2ffeaf6fc234"), "Breakfast", "Bool", "Logistics", true, true, false,true,false, "This person will need a meal provided"),
new CheckInInfoField(new Guid("dcb8f7d2-7904-40d9-8cec-74fce2735ba1"), "Lunch", "Bool", "", true, true, false,true,false, "This person will need a meal provided"),
new CheckInInfoField(new Guid("3ef2e4a5-fa43-49e9-b69b-00e86a7e62cc"), "Dinner", "Bool", "", true, true, false,true,false, "This person will need a meal provided"),
new CheckInInfoField(new Guid("9369c50e-3b39-40b8-8557-c25af007ab74"), "Method of Travel", "List", "Logistics", true, true, true,true,false, "Method of Travel to Incident"),
new CheckInInfoField(new Guid("3458d7d5-a5a5-4104-8488-949ff64c4d31"), "Vehicle License #", "String", "Logistics", true, true, true,true,false, ""),
new CheckInInfoField(new Guid("1d50d619-bfbe-4c1a-ae9b-13cfe66ac654"), "Year / Make / Model", "String", "Logistics", true, true, false,true,false, ""),
new CheckInInfoField(new Guid("b496b1a3-3efa-4714-b15d-d17d311a919d"), "Agency Owned Vehicle", "Bool", "Logistics", true, true, true,true,false, ""),
new CheckInInfoField(new Guid("1934af9e-58ea-4a62-ae4a-16bbb3dbf522"), "Rental Vehicle ", "Bool", "Logistics", true, true, true,true,false, ""),
new CheckInInfoField(new Guid("538d4802-cd56-49d1-aa06-f1fbf269f6f5"), "Contractor Vehicle(s)", "Bool", "Logistics", true, true, true,true,false, ""),
new CheckInInfoField(new Guid("2631596d-1429-4477-99af-e8459377056a"), "Private Vehicle ", "Bool", "Logistics", true, true, true,true,false, ""),
new CheckInInfoField(new Guid("63c0e3e2-f8d0-447e-a03e-a30eafa003ad"), "Mobile Equip", "String", "Logistics", true, true, false,true,false, "Incident Identification Number ('V' numbers)"),
new CheckInInfoField(new Guid("940174cc-3c4a-4fbe-99c6-42676f1b5d5e"), "Gear Required", "String", "Logistics", true, true, false,true,false, "Fireline equipment/gear needed from supply unit"),
new CheckInInfoField(new Guid("e4b5c369-6cb6-4773-aebe-acec8a206ca1"), "Reason for visit", "string", "Visitor Info", true, false, false,false,true, ""),
new CheckInInfoField(new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d"), "Incident contact", "string", "Visitor Info", true, false, false,false,true, ""),
new CheckInInfoField(new Guid("3ac1684c-f882-484b-b31e-e9cd6c21c1f9"), "Duration of Visit", "string", "Visitor Info", true, false, false,false,true, "")

            };


            return fields;
        }

        public static List<string> GetInfoFieldListOptions(Guid FieldID)
        {
            switch (FieldID.ToString())
            {
                case "3aefed78-eaf9-4f52-a222-43fc389933ce": return new List<string> { "", "ICP", "Base", "Camp", "Staging", "Heli-Base" };
                case "c9f49654-b5e5-4291-886b-8d24aaef5045": return new List<string> { "", "Incident Camp", "Other" };
                case "9369c50e-3b39-40b8-8557-c25af007ab74": return new List<string> { "", "Aircraft", "Bus", "Other Vehicle" };
                default:
                    return new List<string>();
            }



        }
    }
}
