using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;
using static System.Net.Mime.MediaTypeNames;

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
        [ProtoMember(15)] private string _InitialRoleName;
        [ProtoMember(16)] private string _InitialRoleAcronym;

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
        public bool IsHECrew { get { return ResourceType.EqualsWithNull("Heavy Equipment Crew"); } }
        public bool HasCheckOutTime { get => CheckOutDate < DateTime.MaxValue; }
        public DateTime LastDayOfRest { get => _LastDayOfRest; set => _LastDayOfRest = value; }
        public string InitialRoleName { get => _InitialRoleName; set => _InitialRoleName = value; }
        public string InitialRoleAcronym { get => _InitialRoleAcronym; set => _InitialRoleAcronym = value; }

        public string CheckInLocation
        {
            get
            {
                if (InfoFields.Any(o => o.ID == new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe")))
                {
                    return InfoFields.First(o => o.ID == new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe")).StringValue;
                }
                else { return string.Empty; }
            }
        }
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
        [ProtoMember(16)] private bool _UseForEquipment; 
        [ProtoMember(17)] private bool _UseForOperator;

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
        public string UniqueIDNumWithPrefix { get => _Resource.UniqueIDNumWithPrefix; }
        public string InitialRoleAcronym { get => _Record.InitialRoleAcronym; }
        public string CheckInLocation { get => _Record.CheckInLocation; }

        public CheckInRecordWithResource() { _ID = Guid.NewGuid(); }
        public CheckInRecordWithResource(CheckInRecord rec, IncidentResource res, DateTime EndOfOp)
        {
            _ID = Guid.NewGuid();
            _Record = rec;
            _Resource = res;
            TimeSpan ts = LastDayOnIncident - EndOfOp;
            DaysTillTimeOut = Convert.ToInt32( Math.Round(ts.TotalDays, 0));
            if(Record.CheckOutDate.Date < EndOfOp.Date || Record.LastDayOnIncident.Date < EndOfOp.Date) { _StatusText = "Checked-Out"; } 
            else if (Record.CheckOutDate.Date == EndOfOp.Date) { _StatusText = "Demobilizing"; }
            else { _StatusText = "Active"; }
        }
    }



    public static class CheckInTools
    {
        public static string ExportCheckInRecordsToCSV(this List<CheckInRecordWithResource> records, List<DemobilizationRecord> demobRecords, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("Unique Incident Number"); csv.Append(delimiter);
            csv.Append("First Name"); csv.Append(delimiter);
            csv.Append("Middle Initial"); csv.Append(delimiter);
            csv.Append("Last Name"); csv.Append(delimiter);
            csv.Append("Dietary Requirements"); csv.Append(delimiter);
            csv.Append("Allergies"); csv.Append(delimiter);
            csv.Append("Cellular Ph. Number Primary contact number"); csv.Append(delimiter);
            csv.Append("Email address"); csv.Append(delimiter);
            csv.Append("Home Unit / Base"); csv.Append(delimiter);
            csv.Append("Home Province / Territory"); csv.Append(delimiter);
            csv.Append("Home Country"); csv.Append(delimiter);
            csv.Append("Employer emergency contact Information "); csv.Append(delimiter);
            csv.Append("Agency"); csv.Append(delimiter);
            csv.Append("Individual's weight"); csv.Append(delimiter);
            csv.Append("Accomodation Preference"); csv.Append(delimiter);
            csv.Append("Unique Crew Identifier"); csv.Append(delimiter);
            csv.Append("CIFFC Crew Identifier"); csv.Append(delimiter);
            csv.Append("Leaders Name"); csv.Append(delimiter);
            csv.Append("Contact Info (cell/email)"); csv.Append(delimiter);
            csv.Append("Total number of personell"); csv.Append(delimiter);
            csv.Append("Resource Order Number"); csv.Append(delimiter);
            csv.Append("Position On Incident"); csv.Append(delimiter);
            csv.Append("Resource Kind"); csv.Append(delimiter);
            csv.Append("Resource Type"); csv.Append(delimiter);
            csv.Append("Check-In Location"); csv.Append(delimiter);
            csv.Append("Check-In Date"); csv.Append(delimiter);
            csv.Append("Check-In Time"); csv.Append(delimiter);
            csv.Append("Last Day of Rest"); csv.Append(delimiter);
            csv.Append("First Day on Incident"); csv.Append(delimiter);
            csv.Append("Last Day on Incident"); csv.Append(delimiter);
            csv.Append("Accomodation Location"); csv.Append(delimiter);
            csv.Append("Breakfast"); csv.Append(delimiter);
            csv.Append("Lunch"); csv.Append(delimiter);
            csv.Append("Dinner"); csv.Append(delimiter);
            csv.Append("Method of Travel to Incident"); csv.Append(delimiter);
            csv.Append("Vehicle License #"); csv.Append(delimiter);
            csv.Append("Year / Make / Model"); csv.Append(delimiter);
            csv.Append("Agency Owned Vehicle"); csv.Append(delimiter);
            csv.Append("Rental Vehicle "); csv.Append(delimiter);
            csv.Append("Contractor Vehicle(s)"); csv.Append(delimiter);
            csv.Append("Private Vehicle "); csv.Append(delimiter);
            csv.Append("Mobile Equip - Incident Identification Number ('V' numbers)"); csv.Append(delimiter);
            csv.Append("Fireline equipment/gear needed from supply unit"); csv.Append(delimiter);
            csv.Append("Reason for visit"); csv.Append(delimiter);
            csv.Append("Incident contact"); csv.Append(delimiter);
            csv.Append("Duration of Visit"); csv.Append(delimiter);

            //debrief
            csv.Append("Check out date"); csv.Append(delimiter);
            csv.Append("Demob location"); csv.Append(delimiter);
            csv.Append("Travel time to home unit"); csv.Append(delimiter);
            csv.Append("Debrief date/time"); csv.Append(delimiter);
            csv.Append("Debrief location"); csv.Append(delimiter);
            csv.Append("Inventory reconciled with supply unit"); csv.Append(delimiter);
            csv.Append("Any discrepincies with Supply Uint"); csv.Append(delimiter);
            csv.Append("Any discrepincies with Facilities Unit"); csv.Append(delimiter);
            csv.Append("Any discrepincies with Finance Unit"); csv.Append(delimiter);
            csv.Append("ICS211 completed"); csv.Append(delimiter);
            csv.Append("Performance Rating Completed"); csv.Append(delimiter);


            csv.Append(Environment.NewLine);



            foreach (CheckInRecordWithResource item in records)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                Personnel p = null; if (item.Resource.GetType().Name.Equals("Personnel")) { p = (Personnel)item.Resource; }
                Vehicle v = null; if (item.Resource.GetType().Name.Equals("Vehicle")) { v = (Vehicle)item.Resource; }
                OperationalSubGroup c = null; 
                if (item.Resource.GetType().Name.Equals("OperationalSubGroup")) { c = (OperationalSubGroup)item.Resource; }
                else if (item.Resource.ParentResourceID != Guid.Empty && records.Any(o=>o.Resource.ID == item.Resource.ParentResourceID)) { c = records.First(o => o.Resource.ID == item.Resource.ParentResourceID).Resource as OperationalSubGroup; }


                csv.Append("\""); csv.Append(item.Resource.UniqueIDNumWithPrefix); csv.Append("\""); csv.Append(delimiter);
                if (p != null)
                {
                    csv.Append("\""); csv.Append(p.FirstName); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.MiddleInitial); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.LastName); csv.Append("\""); csv.Append(delimiter);
                    if (p.HasDietaryRestrictions) { csv.Append("\""); csv.Append("YES"); csv.Append("\""); csv.Append(delimiter); } else { csv.Append("\""); csv.Append("NO"); csv.Append("\""); csv.Append(delimiter); }
                    if (p.HasAllergies) { csv.Append("\""); csv.Append("YES"); csv.Append("\""); csv.Append(delimiter); } else { csv.Append("\""); csv.Append("NO"); csv.Append("\""); csv.Append(delimiter); }
                    csv.Append("\""); csv.Append(p.CellphoneNumber); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.Email); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.HomeUnit); csv.Append("\""); csv.Append(delimiter);
                    if (p.HomeProvinceID != Guid.Empty)
                    {
                        Province prov = new Province(p.HomeProvinceID);
                        csv.Append("\""); csv.Append(prov.ProvinceName); csv.Append("\""); csv.Append(delimiter);
                    }
                    else
                    {
                        csv.Append("\""); csv.Append("\""); csv.Append(delimiter);

                    }

                    csv.Append("\""); csv.Append(p.HomeCountry); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.EmergencyContact); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(p.Agency); csv.Append("\""); csv.Append(delimiter);
                    csv.Append(AddToCSVIfPossible(item, new Guid("10a107d2-4bec-43af-bedf-87837fbcb447"), delimiter));
                    csv.Append("\""); csv.Append(p.AccomodationPreference); csv.Append("\""); csv.Append(delimiter);
                }
                else
                {
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                }


                if (c != null)
                {
                    csv.Append(AddToCSVIfPossible(item, new Guid("1d50d619-bfbe-4c1a-ae9b-13cfe66ac654"), delimiter));
                    csv.Append(AddToCSVIfPossible(item, new Guid("b496b1a3-3efa-4714-b15d-d17d311a919d"), delimiter));
                    csv.Append("\""); csv.Append(c.LeaderName); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(c.Contact); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(c.NumberOfPeople); csv.Append("\""); csv.Append(delimiter);
                }
                else
                {
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);

                }



                csv.Append(AddToCSVIfPossible(item, new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d"), delimiter));
                csv.Append("\""); csv.Append(item.Record.InitialRoleName); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Resource.Kind); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Resource.Type); csv.Append("\""); csv.Append(delimiter);
                csv.Append(AddToCSVIfPossible(item, new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe"), delimiter));

                csv.Append("\""); csv.Append(item.Record.CheckInDate.ToString(Globals.DateFormat)); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Record.CheckInDate.ToString("HH:mm")); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Record.LastDayOfRest.ToString(Globals.DateFormat)); csv.Append("\""); csv.Append(delimiter);
                csv.Append(AddToCSVIfPossible(item, new Guid("9afc627f-bdad-4076-8d9a-3511759ea2bf"), delimiter));
                csv.Append("\""); csv.Append(item.Record.LastDayOnIncident.ToString(Globals.DateFormat)); csv.Append("\""); csv.Append(delimiter);
                csv.Append(AddToCSVIfPossible(item, new Guid("7a39df77-cb16-463c-812b-573bfa97de5d"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("09e8e520-a82e-491f-a82e-ed108e809392"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("8355bc4b-238c-4992-9ded-0cff32f1bbf4"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("dd5a2327-bfdc-42fb-a3b4-e6e68fd1d488"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("2e69adbd-126b-4ae1-abc0-919dca191f68"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("ec82d677-a731-4a31-8bb8-452cbafaa58b"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("8c78ca45-d18d-4bc4-8993-848f6b088e7f"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("c1399559-2ac8-49da-8ce8-cd711365417d"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("f9aa8b53-d619-422c-8825-bc3da2a4d67d"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("c8adde5b-cb21-4b31-8a90-e5b46f192368"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("3208d48d-eaf2-4f9e-b526-3d3437610d16"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("40718587-d6ee-480a-8451-6c7f02d272a5"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("99c4d8c6-3b39-42f1-af6f-33525b2da4e7"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("c3704eab-5c8e-4619-91f0-4df014560c7a"), delimiter));
                csv.Append(AddToCSVIfPossible(item, new Guid("ad5b511a-a99f-4310-ba66-4eeb41ec6ab9"), delimiter));

                //Demob
                if (demobRecords.Any(o => o.ResourceID == item.Resource.ID))
                {
                    DemobilizationRecord demob = demobRecords.First(o => o.ResourceID == item.Resource.ID);
                    csv.Append("\""); csv.Append(demob.DemobDate.ToString(Globals.DateFormat + " HH:mm")); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(demob.DemobLocation); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(demob.TravelTimeToHomeUnit); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(demob.DebriefDate.ToString(Globals.DateFormat + " HH:mm")); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append(demob.DebriefLocation); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.InventoryReconciled) { csv.Append("YES"); } else { csv.Append("NO"); } csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.DiscrepanciesWithSupply) { csv.Append("YES"); } else { csv.Append("NO"); }
                    csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.DiscrepanciesWithFacilities) { csv.Append("YES"); } else { csv.Append("NO"); }
                    csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.DiscrepanciesWithFinance) { csv.Append("YES"); } else { csv.Append("NO"); }
                    csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.ICS211Completed) { csv.Append("YES"); } else { csv.Append("NO"); }
                    csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); if (demob.PerformanceRatingCompleted) { csv.Append("YES"); } else { csv.Append("NO"); }
                    csv.Append("\""); csv.Append(delimiter);
                }
                else
                {
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                    csv.Append("\""); csv.Append("\""); csv.Append(delimiter);
                }



                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

        private static StringBuilder AddToCSVIfPossible(CheckInRecordWithResource item, Guid id, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            if (item.Record.InfoFields.Any(o => o.ID == id))
            {
                csv.Append("\"");
                CheckInInfoField field = item.Record.InfoFields.First(o => o.ID == id);
                switch (field.FieldType)
                {
                    case "Bool":
                        if (field.BoolValue) { csv.Append("YES"); } else { csv.Append("NO"); } break;
                    case "DateTime":
                        csv.Append(field.DateValue.ToString(Globals.DateFormat)); break;
                    case "Int":
                        csv.Append(field.IntValue.ToString()); break;
                    default:
                        csv.Append(field.StringValue); break;
                }
                
                csv.Append("\"");
            }
            else { csv.Append("\""); csv.Append("\""); }
            csv.Append(delimiter);
            return csv;
        }


        public static int[] GetAccomodationPreferences(this List<CheckInRecordWithResource> list)
        {
            int[] accomodation = new int[4];
            /*  0 = not incident camp
             *  1 = male only
             *  2 = female only
             *  3 = not gender restricted
             */
            Guid accomodationID = new Guid("7a39df77-cb16-463c-812b-573bfa97de5d");

            List<CheckInRecordWithResource> personnel = list.Where(o => o.Resource.GetType().Name.Equals("Personnel")).ToList();
            List<CheckInRecordWithResource> campPersonnel = personnel.Where(o => o.Record.InfoFields.Any(i => i.ID == accomodationID && i.StringValue.EqualsWithNull("Incident Camp"))).ToList();

            accomodation[0] = personnel.Count - campPersonnel.Count;
            accomodation[1] = campPersonnel.Count(o => (o.Resource as Personnel).AccomodationPreference.EqualsWithNull("Male-Only"));
            accomodation[2] = campPersonnel.Count(o => (o.Resource as Personnel).AccomodationPreference.EqualsWithNull("Female-Only"));
            accomodation[3] = campPersonnel.Count(o => (o.Resource as Personnel).AccomodationPreference.EqualsWithNull("Not Gender-Restricted"));

            //accomodation[1] = personnel.Count(o => (o.Resource as Personnel).AccomodationPreference.EqualsWithNull("Female-Only") && o.Record.InfoFields.Any(i => i.ID == accomodationID && i.StringValue.EqualsWithNull("Incident Camp")));
            //accomodation[1] = personnel.Count(o => (o.Resource as Personnel).AccomodationPreference.EqualsWithNull("Not Gender-Restricted") && o.Record.InfoFields.Any(i => i.ID == accomodationID && i.StringValue.EqualsWithNull("Incident Camp")));
            return accomodation;
        }

        public static int[] GetVehicleTypes (this List<CheckInRecordWithResource> list)
        {
            int[] vehicleTypes = new int[4];
            vehicleTypes[0] = list.Count(o => o.Record.InfoFields.Any(f => f.ID == new Guid("8c78ca45-d18d-4bc4-8993-848f6b088e7f") && f.BoolValue));
            vehicleTypes[1] = list.Count(o => o.Record.InfoFields.Any(f => f.ID == new Guid("c1399559-2ac8-49da-8ce8-cd711365417d") && f.BoolValue));
            vehicleTypes[2] = list.Count(o => o.Record.InfoFields.Any(f => f.ID == new Guid("f9aa8b53-d619-422c-8825-bc3da2a4d67d") && f.BoolValue));
            vehicleTypes[3] = list.Count(o => o.Record.InfoFields.Any(f => f.ID == new Guid("c8adde5b-cb21-4b31-8a90-e5b46f192368") && f.BoolValue));
            return vehicleTypes;
        }

        public static int[,] GetMealRequirements(this List<CheckInRecordWithResource> list)
        {
            Guid breakfastID = new Guid("09e8e520-a82e-491f-a82e-ed108e809392");
            Guid lunchID = new Guid("8355bc4b-238c-4992-9ded-0cff32f1bbf4");
            Guid dinnerID = new Guid("dd5a2327-bfdc-42fb-a3b4-e6e68fd1d488");
            List<CheckInRecordWithResource> personnel = list.Where(o => o.Resource.GetType().Name.Equals("Personnel")).ToList();

            int[,] food = new int[3, 2];


            foreach (CheckInRecordWithResource rec in personnel)
            {

                if (rec.Record.InfoFields.Any(o => o.ID == breakfastID && o.BoolValue))
                {
                    if ((rec.Resource as Personnel).HasDietaryRestrictions) { food[0, 1]++; }
                    else { food[0, 0]++; }
                }
                if (rec.Record.InfoFields.Any(o => o.ID == lunchID && o.BoolValue))
                {
                    if ((rec.Resource as Personnel).HasDietaryRestrictions) { food[1, 1]++; }
                    else { food[1, 0]++; }
                }
                if (rec.Record.InfoFields.Any(o => o.ID == dinnerID && o.BoolValue))
                {
                    if ((rec.Resource as Personnel).HasDietaryRestrictions) { food[2, 1]++; }
                    else { food[2, 0]++; }
                }
            }
            return food;
        }

        public static List<CheckInRecordWithResource> GetAllCheckInWithResources(this WFIncident incident, int OpPeriod)
        {
            List<CheckInRecordWithResource> list = new List<CheckInRecordWithResource>();


            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);


            List<IncidentResource> allResources = new List<IncidentResource>();
            List<CheckInRecord> checkInRecords = new List<CheckInRecord>();

            allResources.AddRange(incident.ActiveIncidentResources);

            foreach (IncidentResource res in allResources)
            {
                if (!list.Any(o => o.Resource.ID == res.ID) && incident.AllCheckInRecords.Any(o => o.ResourceID == res.ID))
                {
                    CheckInRecord rec = incident.AllCheckInRecords.First(o => o.ResourceID == res.ID);
                    if (rec.CheckInDate <= currentPeriod.PeriodEnd)
                    {
                        CheckInRecordWithResource resrec = new CheckInRecordWithResource(rec, res, currentPeriod.PeriodEnd);

                        list.Add(resrec);
                    }
                }

            }


            return list;
        }

        public static List<CheckInRecordWithResource> GetCheckInWithResources(this WFIncident incident, int OpPeriod)
        {
            List<CheckInRecordWithResource> list = new List<CheckInRecordWithResource>();


            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
           

            List<IncidentResource> allResources = new List<IncidentResource>();
            List<CheckInRecord> checkInRecords = new List<CheckInRecord>();

            allResources.AddRange(incident.ActiveIncidentResources);

            foreach (IncidentResource res in allResources)
            {
                if (!list.Any(o => o.Resource.ID == res.ID) && incident.AllCheckInRecords.Any(o => o.ResourceID == res.ID))
                {
                    CheckInRecord rec = incident.AllCheckInRecords.First(o => o.ResourceID == res.ID);
                    if (rec.CheckedInThisTime(currentPeriod.PeriodMid))
                    {
                        CheckInRecordWithResource resrec = new CheckInRecordWithResource(rec, res, currentPeriod.PeriodEnd);

                        list.Add(resrec);
                    }
                }

            }


            return list;
        }

        public static List<CheckInRecordWithResource> GetCheckInWithResources(this WFIncident incident, int OpPeriod, ICSRole ParentRole)
        {
            List<CheckInRecordWithResource> list = new List<CheckInRecordWithResource>();


            OperationalPeriod currentPeriod = incident.AllOperationalPeriods.First(o => o.PeriodNumber == OpPeriod);
            OrganizationChart currentOrgChart = incident.allOrgCharts.First(o => o.OpPeriod == OpPeriod);



           
            List<ICSRole> childRoles =  currentOrgChart.GetChildRoles(ParentRole.RoleID, true, false);

            List<IncidentResource> allResources = new List<IncidentResource>();
            List<CheckInRecord> checkInRecords = new List<CheckInRecord>();
            if (ParentRole.IndividualID != Guid.Empty && !allResources.Any(o => o.ID == ParentRole.IndividualID) && incident.ActiveIncidentResources.Any(o => o.ID == ParentRole.IndividualID))
            {
                allResources.Add(incident.ActiveIncidentResources.First(o => o.ID == ParentRole.IndividualID));
            }

            foreach (ICSRole role in childRoles)
            {
                if (role.IndividualID != Guid.Empty && !allResources.Any(o => o.ID == role.IndividualID) && incident.ActiveIncidentResources.Any(o => o.ID == role.IndividualID)) { allResources.Add(incident.ActiveIncidentResources.First(o => o.ID == role.IndividualID)); }
            }

            if(incident.ActiveOperationalGroups.Any(o=>o.LeaderICSRoleID == ParentRole.RoleID))
            {
                OperationalGroup opgr = incident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == ParentRole.RoleID);
                allResources.AddRange(incident.GetReportingResources(opgr.ID, true));
            }
            foreach (ICSRole role in childRoles)
            {
                if (incident.ActiveOperationalGroups.Any(o => o.LeaderICSRoleID == role.RoleID))
                {
                    OperationalGroup opgr = incident.ActiveOperationalGroups.First(o => o.LeaderICSRoleID == role.RoleID);
                    allResources.AddRange(incident.GetReportingResources(opgr.ID, true));
                }
            }



            //convert OperationalGroupResourceListing into normal resources
            if (allResources.Any(o => o.GetType().Name.Equals("OperationalGroupResourceListing")))
            {
                List<IncidentResource> newResources = new List<IncidentResource>();
                foreach (OperationalGroupResourceListing listing in allResources.OfType<OperationalGroupResourceListing>())
                {
                    if (incident.ActiveIncidentResources.Any(o => o.ID == listing.ResourceID)) { newResources.Add(incident.ActiveIncidentResources.First(o => o.ID == listing.ResourceID)); }
                }
                allResources.AddRange(newResources);
            }



            foreach (IncidentResource res in allResources)
            {
                if (!list.Any(o=>o.Resource.ID == res.ID) && incident.AllCheckInRecords.Any(o => o.ResourceID == res.ID))
                {
                    CheckInRecordWithResource rec = new CheckInRecordWithResource(incident.AllCheckInRecords.First(o => o.ResourceID == res.ID), res, currentPeriod.PeriodEnd);
                    list.Add(rec);
                }
                    
            }


            return list;
        }


        public static bool CheckedInThisTime(this CheckInRecord rec, DateTime timeToCheck)
        {
            if (rec.CheckInDate <= timeToCheck && rec.CheckOutDate >= timeToCheck && rec.LastDayOnIncident.Date >= timeToCheck.Date) { return true; }
            return false;
        }

        public static bool ConfirmResourceNumUnique(this WFIncident incident, string ResourceType, int pNum, Guid excludeID = new Guid())
        {
            if (ResourceType.Equals("Personnel") || ResourceType.Equals("Operator") || ResourceType.Equals("Visitor"))
            {
                return !incident.IncidentPersonnel.Any(o => o.UniqueIDNum == pNum && o.ID != excludeID);
            }
            else if (ResourceType.Equals("Vehicle"))
            {
                return !incident.allVehicles.Any(o => !o.IsEquipment && o.UniqueIDNum == pNum && o.ID != excludeID);
            }
            else if (ResourceType.Equals("Equipment"))
            {
                return !incident.allVehicles.Any(o => o.IsEquipment && o.UniqueIDNum == pNum && o.ID != excludeID);

            }
            else if (ResourceType.Equals("Crew") || ResourceType.Equals("Heavy Equipment Crew"))
            {
                return !incident.AllOperationalSubGroups.Any(o => o.UniqueIDNum == pNum && o.ID != excludeID);
            }
            else return false;
           
        }
        public static int GetNextUniqueNum(this WFIncident incident, string ResourceType, int lowerBound = 1, int upperBound = 10000)
        {
            int next = lowerBound;
            List<IncidentResource> resList = new List<IncidentResource>();

            if (ResourceType.Equals("Personnel") || ResourceType.Equals("Operator") || ResourceType.Equals("Visitor"))
            {
                resList.AddRange(incident.IncidentPersonnel.Where(o => o.PNum >= lowerBound && o.PNum <= upperBound).OrderBy(o=>o.UniqueIDNum));

            }
            else if (ResourceType.Equals("Vehicle"))
            {
                resList.AddRange(incident.allVehicles.Where(o => !o.IsEquipment && o.UniqueIDNum >= lowerBound && o.UniqueIDNum <= upperBound).OrderBy(o => o.UniqueIDNum));

            }
            else if (ResourceType.Equals("Equipment"))
            {
                resList.AddRange(incident.allVehicles.Where(o => o.IsEquipment && o.UniqueIDNum >= lowerBound && o.UniqueIDNum <= upperBound).OrderBy(o => o.UniqueIDNum));


            }
            else if (ResourceType.Equals("Crew") || ResourceType.Equals("Heavy Equipment Crew"))
            {
                resList.AddRange(incident.AllOperationalSubGroups.Where(o => o.UniqueIDNum >= lowerBound && o.UniqueIDNum <= upperBound).OrderBy(o => o.UniqueIDNum));
            }

            foreach (IncidentResource res in resList)
            {
                if (res.UniqueIDNum == next && (next + 1) < upperBound) { next++; } 
                else { break; }
            }

            if (next >= lowerBound && next <= upperBound && incident.ConfirmResourceNumUnique(ResourceType, next)) { return next; }
            else { return -1; }
        }

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
                new CheckInInfoField(new Guid("10a107d2-4bec-43af-bedf-87837fbcb447"), "Individual's weight ", "String", "Individual Info", false, true, false,false,false,true,false, "Enter the individuals seat weight. "),
                
                new CheckInInfoField(new Guid("1d50d619-bfbe-4c1a-ae9b-13cfe66ac654"), "Unique Crew Identifier", "String", "Crew Info", false, false, false,true,false,false,true, "Enter the crews unique agency identifer i.e. RU01, Flathead Unit crew, Dryden IA, etc. "),
                new CheckInInfoField(new Guid("b496b1a3-3efa-4714-b15d-d17d311a919d"), "CIFFC Crew Identifier", "String", "Crew Info", false, false, false,true,false,false,false, "Enter the CIFFC crew identifier if the crew is imported through CIFFC i.e C-30"),
                //new CheckInInfoField(new Guid("538d4802-cd56-49d1-aa06-f1fbf269f6f5"), "Contact Info (cell/email)", "String", "Crew Info", false, false, false,true,false,false,true, ""),
                new CheckInInfoField(new Guid("cdc5b7ef-4e82-4611-9ceb-39fdb52a2c5d"), "Resource Order Number", "String", "Deployment Information", false, true, true,true,true,true,false, "Enter agency specific order number or order identifier. "),
                new CheckInInfoField(new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe"), "Check-In Location", "List", "Check In Information", true, true, true,true,true,true,true, ""),
                new CheckInInfoField(new Guid("9afc627f-bdad-4076-8d9a-3511759ea2bf"), "First Day on Incident", "DateTime", "Check In Information", true, true, true,true,true,true,true, ""),
                new CheckInInfoField(new Guid("7a39df77-cb16-463c-812b-573bfa97de5d"), "Accomodation Location", "List", "Logistics", true, true, false,true,false,true,false, "Enter where the resource is staying. "),
                new CheckInInfoField(new Guid("09e8e520-a82e-491f-a82e-ed108e809392"), "Breakfast", "Bool", "Logistics", true, true, false,true,false,true,false, ""),
                new CheckInInfoField(new Guid("8355bc4b-238c-4992-9ded-0cff32f1bbf4"), "Lunch", "Bool", "Logistics", true, true, false,true,false,true,false, ""),
                new CheckInInfoField(new Guid("dd5a2327-bfdc-42fb-a3b4-e6e68fd1d488"), "Dinner", "Bool", "Logistics", true, true, false,true,false,true,false, ""),
                new CheckInInfoField(new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89"), "Method of Travel to Incident", "List", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("2e69adbd-126b-4ae1-abc0-919dca191f68"), "Vehicle License #", "String", "Logistics", false, false, true,false,false,false,false, ""),
                new CheckInInfoField(new Guid("ec82d677-a731-4a31-8bb8-452cbafaa58b"), "Year / Make / Model", "String", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("8c78ca45-d18d-4bc4-8993-848f6b088e7f"), "Agency Owned Vehicle", "Bool", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("c1399559-2ac8-49da-8ce8-cd711365417d"), "Rental Vehicle ", "Bool", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("f9aa8b53-d619-422c-8825-bc3da2a4d67d"), "Contractor Vehicle(s)", "Bool", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("c8adde5b-cb21-4b31-8a90-e5b46f192368"), "Private Vehicle ", "Bool", "Logistics", true, true, true,true,true,true,false, ""),
                new CheckInInfoField(new Guid("3208d48d-eaf2-4f9e-b526-3d3437610d16"), "Mobile Equip", "String", "Logistics", true, true, false,true,false,false,false, "Incident Identification Number ('V' numbers)"),
                new CheckInInfoField(new Guid("40718587-d6ee-480a-8451-6c7f02d272a5"), "Fireline equipment", "String", "Logistics", true, true, false,true,false,false,false, "Fireline equipment/gear needed from supply unit"),
                new CheckInInfoField(new Guid("99c4d8c6-3b39-42f1-af6f-33525b2da4e7"), "Reason for visit", "List", "Visitor Info", true, false, false,false,false,false,true, ""),
                new CheckInInfoField(new Guid("c3704eab-5c8e-4619-91f0-4df014560c7a"), "Incident contact", "String", "Visitor Info", true, false, false,false,false,false,true, "Enter the IMT individual who the visitor is to report to."),
                new CheckInInfoField(new Guid("ad5b511a-a99f-4310-ba66-4eeb41ec6ab9"), "Duration of Visit", "String", "Visitor Info", true, false, false,false,false,false,true, "Enter the duration of visit down to the nearest day. If the visit is only for 2 hours then enter 1 day. ")
            };


            return fields;
        }

        public static List<string> GetInfoFieldListOptions(Guid FieldID)
        {
            switch (FieldID.ToString())
            {
                case "b4c8332b-ddf3-4d4c-9c83-2c62328061fe": return new List<string> { "", "ICP", "Base", "Camp", "Staging", "Heli-Base" };
                case "7a39df77-cb16-463c-812b-573bfa97de5d": return new List<string> { "", "Incident Camp", "Other" };
                case "a4f1cb0e-9774-4bdc-aeac-96976aceba89": return new List<string> { "", "Aircraft", "Bus", "Vehicle" };
                case "99c4d8c6-3b39-42f1-af6f-33525b2da4e7": return new List<string> { "", "Research", "Maintenance", "Servicing equipment", "Servicing facilities", "Observing" };
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
