using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class TestTools
    {
        private static readonly Random random = new Random();
        public static Aircraft CreateAircraftTest(int seed)
        {
            Aircraft a = new Aircraft();
            a.MakeModel = "MakeModel" + seed;
            a.CompanyName = "Company Name " + seed;
            List<string> models = AircraftTools.GetHelicopterTypes();
            a.MakeModel = models[random.Next(models.Count)];
            a.Registration = "Reg " + seed;
            a.Base = "Base" + seed;
            a.StartTime = DateTime.Now;
            
            a.EndTime = a.StartTime.AddHours(seed);
            a.Remarks = "Remarks" + seed;
            a.Pilot = "Pilot" + seed;
            a.Contact = "Contact" + seed;
            a.ContactNumber = "ContactNumber" + seed;
            a.FuelBurnRate = random.Next(10000);
            a.PointOfHire = "Point of Hire " + seed;
            a.IsMedivac = RandomBooleanGenerator.GetRandomBoolean();
            return a;
        }

        public static NOTAM CreateNOTAMTest(int seed)
        {
            NOTAM n = new NOTAM();
            n.UseRadius = true;
            n.RadiusNM = seed;
            n.AltitudeASL = seed * 10;
            n.CenterPoint = "CentrePoint" + seed;
            n.RadiusCentre = new Coordinate(49.680970519364024, -124.98624040207191);
            return n;
        }

        public static AirOperationsSummary CreateAirOpsTest(int seed)
        {
            AirOperationsSummary test = new AirOperationsSummary();
            test.Remarks = "Remarks" + seed;
            test.Sunrise = DateTime.Now;
            test.Sunset = DateTime.Now.AddHours(seed);
            test.MedivacAircraftText = "Medivac Test" + seed;
            test.notam = CreateNOTAMTest(seed);
            //test.aircrafts.Add(CreateAircraftTest(seed));
            test.PreparedByRoleID = Globals.PlanningChiefGenericID;
            test.PreparedByResourceName = "Name" + seed;
            return test;
        }
        public static Contact createContactTest(int seed)
        {
            Contact test = new Contact();
            test.ContactName = "ContactName" + seed;
            test.Title = "Title" + seed;
            test.Organization = "Organization" + seed;
            test.Phone = "(" + seed.ToString() + seed.ToString() + seed.ToString() + ") " + seed.ToString() + seed.ToString() + seed.ToString() + "-" + seed.ToString() + seed.ToString() + seed.ToString() + seed.ToString();
            test.Email = seed + "@test.test";
            test.Callsign = "Callsign" + seed;
            test.RadioChannel = "Radio" + seed;
            test.Notes = "Notes" + seed;
            return test;
        }

        public static Hospital createTestHospital(int seed)
        {
            Hospital test = new Hospital();
            test.name = "Name" + seed;
            test.location = "Location" + seed;
            test.travelTimeAir = random.Next(100);
            test.travelTimeGround = random.Next(100);
            test.phone = "Phone" + seed;
            test.traumaUnit = RandomBooleanGenerator.GetRandomBoolean();
            test.burnUnit = RandomBooleanGenerator.GetRandomBoolean();
            test.hypothermia = RandomBooleanGenerator.GetRandomBoolean();
            test.helipad = RandomBooleanGenerator.GetRandomBoolean();
            test.isUniversal = false;
            return test;
        }
        public static AmbulanceService createTestAmbulanceService(int seed)
        {
            AmbulanceService test = new AmbulanceService();
            test.Organization = "Organization" + seed;
            test.Contact = "Contact" + seed;
            test.Phone = "PHone" + seed;
            test.RadioFrequency = "Radio" + seed;
            test.IsALS = RandomBooleanGenerator.GetRandomBoolean();
            test.IsBLS = RandomBooleanGenerator.GetRandomBoolean();
            test.Location = "Location" + seed;
            return test;
        }

        public static MedicalAidStation createTestMedicalAidStation(int seed)
        {
            MedicalAidStation test = new MedicalAidStation();
            test.Name = "Name" + seed;
            test.Location = "Location" + seed;
            test.ContactNumber = "ContactNumber" + seed;
            test.ParamedicsAvailable = RandomBooleanGenerator.GetRandomBoolean();
            test.OFA1 = RandomBooleanGenerator.GetRandomBoolean();
            test.OFA2 = RandomBooleanGenerator.GetRandomBoolean();
            test.OFA3 = RandomBooleanGenerator.GetRandomBoolean();
            test.ALS = RandomBooleanGenerator.GetRandomBoolean();
            test.FirstResponder = RandomBooleanGenerator.GetRandomBoolean();
            return test;
        }

        public static MedicalPlan createTestMedicalPlan(int seed)
        {
            MedicalPlan test = new MedicalPlan();
            test.PreparedByResourceName = "PrepBy" + seed;
            test.DatePrepared = DateTime.Now.AddHours(seed);
            for (int x = 0; x < 3; x++)
            {
                test.Ambulances.Add(createTestAmbulanceService(x));
                test.Hospitals.Add(createTestHospital(x));
                test.MedicalAidStations.Add(createTestMedicalAidStation(x));
            }
            test.EmergencyProcedures = "EmergencyProcedures" + seed;
            test.PreparedByRoleName = "Operations Section Chief";
            test.PreparedByRoleID = Globals.OpsChiefGenericID;
            test.PreparedByResourceName = "Tim " + seed;
            test.ApprovedByRoleID = Globals.IncidentCommanderGenericID;
            test.OpPeriod = seed;
            return test;
        }

        public static Note createTestNote(int seed)
        {
            Note test = new Note();
            List<NoteCategory> noteCategories = NoteTools.NoteCategories;
            test.CategoryID = noteCategories[random.Next(noteCategories.Count)].CategoryID;
            test.CategoryName = noteCategories.First(o => o.CategoryID == test.CategoryID).CategoryName;
            test.NoteTitle = StringExt.LoremIpsum(1, 3, 1, 1, 1);
            test.NoteText = StringExt.LoremIpsum(1, 100, 1, seed, 1);
            test.DateCreated = DateTime.Now;
            test.DateUpdated = DateTime.Now.AddHours(seed);
            return test;
        }

        public static PositionLogEntry createTestPositionLogEntry(int seed)
        {
            PositionLogEntry test = new PositionLogEntry();
            test.Role = new ICSRole(OrganizationalChartTools.GetGenericRoleByID(Globals.IncidentCommanderGenericID));
            test.DateCreated = DateTime.Now;
            test.DateUpdated = DateTime.Now.AddHours(seed);
            test.IsComplete = RandomBooleanGenerator.GetRandomBoolean();
            test.ReminderTime = test.DateUpdated.AddHours(seed);
            test.TimeDue = test.ReminderTime;
            test.LogText = StringExt.LoremIpsum(1, seed, 1, 1, 1);
            test.IsInfoOnly = RandomBooleanGenerator.GetRandomBoolean();

            return test;

        }
        public static SafetyMessage createTestSafetyMessage(int seed)
        {
            SafetyMessage test = new SafetyMessage();
            test.Message = "Message" + seed;
            test.SitePlanRequired = RandomBooleanGenerator.GetRandomBoolean();
            test.SitePlanLocation = "Location" + seed;
            test.ApprovedByResourceName = "Tim " + seed;
            test.ApprovedByRoleName = "Planning Section Chief";
            test.ApprovedByRoleID = Globals.PlanningChiefGenericID;
            test.SummaryLine = "Hazard " + seed;
            return test;
        }

        public static Personnel createTestPerson(int seed)
        {
            Personnel test = new Personnel();
            test.FirstName = RandomNameGenerator.FirstName;
            test.LastName = RandomNameGenerator.LastName;
            test.MiddleInitial = RandomLetterGenerator.GetRandomLetter().ToString();
            test.Gender = "Gender" + seed;
            test.HasDietaryRestrictions =
            test.HasAllergies = RandomBooleanGenerator.GetRandomBoolean();
            test.Weight = "Weight" + seed;
            test.CellphoneNumber = "CellphoneNumber" + seed;
            test.Email = "Email" + seed;
            test.HomeUnit = "HomeUnit" + seed;
            test.HomeProvinceID = ProvinceTools.GetProvinces().First().ProvinceGUID;
            test.HomeCountry = "HomeCountry" + seed;
            test.EmergencyContact = "EmergencyContact" + seed;
            test.Agency = "Agency" + seed;
            test.IsContractor = RandomBooleanGenerator.GetRandomBoolean();
            test.CallSign = "CallSign" + seed;
            test.Pronouns = "Pronouns" + seed;
            test.AccommodationPreference = "AccommodationPreference" + seed;
            List<string> kinds = PersonnelTools.GetPersonnelKinds();

            test.Kind = kinds[random.Next(kinds.Count)];
            test.Type = "Type" + random.Next(1, 8);
            return test;
        }
        public static Vehicle createTestVehicle(int seed)
        {
            Vehicle test = new Vehicle();
            test.IncidentIDNo = "Name " + seed;
            test.OrderRequestNo = "OrderRequestNo" + seed;
            test.Classification = "Classification" + seed;
            test.Make = "Make" + seed;
            test.CategoryKindCapacity = "CategoryKindCapacity" + seed;
            test.Features = "Features" + seed;
            test.AgencyOrOwner = "AgencyOrOwner" + seed;
            test.OperatorName = "OperatorName" + seed;
            test.LicenseOrID = "LicenseOrID" + seed;
            test.IncidentAssignment = "IncidentAssignment" + seed;
            test.StartTime = DateTime.Now;
            test.MustBeOutTime = DateTime.Now.AddHours(seed);
            test.Notes = "Notes" + seed;
            test.OperatorID = Guid.Empty;
            test.ASE = "ASE" + seed;
            test.Kind = "Kind" + seed;
            test.Type = "Type" + random.Next(1, 4);
            test.IsEquipment = RandomBooleanGenerator.GetRandomBoolean();
            return test;

        }

        public static Crew createTestCrew(int seed, List<IncidentResource> childResources)
        {
            Crew test = new Crew();
            test.Active = true;
            test.ResourceName = "Crew " + seed;
            test.Transport = "Transport " + seed;
            test.Email = "email" + seed + "@test.com";
            test.Phone = "(" + seed.ToString() + seed.ToString() + seed.ToString() + ") " + seed.ToString() + seed.ToString() + seed.ToString() + "-" + seed.ToString() + seed.ToString() + seed.ToString() + seed.ToString();
            test.IsEquipmentCrew = false;
            test.UniqueIDNum = seed;
            test.Kind = "Crew";
            test.Type = "Type " + random.Next(1, 4);
            
            foreach(IncidentResource resource in childResources)
            {
                if(resource.GetType().Name .Equals( new Vehicle().GetType().Name))
                {
                    test.IsEquipmentCrew = true;
                    test.Kind = "Heavy Equipment Crew";
                }
                OperationalGroupResourceListing listing = new OperationalGroupResourceListing();
                listing.SubGroupID = test.ID;
                listing.OperationalGroupID = test.OperationalGroupID;
                listing.Kind = resource.Kind;
                listing.Type = resource.Type;
                listing.ResourceIdentifier = "Crew " + seed;
                listing.ResourceID = resource.ID;
                listing.ResourceName = resource.ResourceName;

                if (resource.GetType().Name.Equals(new Personnel().GetType().Name))
                {
                    listing.ResourceType = "Personnel";

                    if (test.LeaderID == Guid.Empty)
                    {
                        test.LeaderID = resource.ID;
                        test.LeaderName = resource.ResourceName;
                       
                        listing.Role = "Crew Leader";
                        listing.LeaderName = resource.LeaderName;
                    }
                    else { listing.Role = "Crew Member"; }
                }
                else { listing.ResourceType = "Equipment"; }

                test.UpsertResourceListing(listing);

            }

            return test;
        }

        public static CheckInRecord createTestCheckInRecord(int seed)
        {
            CheckInRecord test = new CheckInRecord();
            test.CheckInDate = DateTime.Now;
            //test.CheckOutDate = DateTime.Now.AddDays(1);
            //GenerateSecureRandomInteger(0,15)
            test.LastDayOnIncident = DateTime.Now.AddDays(random.Next(0, 15));
            test.PersonalIncidentNumber = seed;
            test.ResourceID = Guid.Empty;
            test.ResourceName = "ResourceName" + seed;
            test.InfoFields = new List<CheckInInfoField>();
            test.ResourceType = "ResourceType" + seed;
            test.ParentRecordID = Guid.Empty;
            test.LastDayOfRest = DateTime.Now.AddDays(-1);

            
            List<ICSRole> roles = OrganizationalChartTools.GetBlankPrimaryRoles().OrderBy(o=>Guid.NewGuid()).ToList();
            test.InitialRoleName = roles.First().RoleName;
            test.InitialRoleAcronym = roles.First().MnemonicAbrv;
            int rnd = random.Next(4);
            test.ReplacementRequired = rnd < 3;
             test.DateReplacementRequired = test.LastDayOnIncident.AddDays(-1); 
            return test;
        }

        public static CheckInRecordWithResource createTestCheckIn(int seed, string type, List<IncidentResource> childResources = null)
        {

            IncidentResource resource = new IncidentResource();
            CheckInRecord record = createTestCheckInRecord(seed);

            switch (type)
            {
                case "Personnel":
                    resource = createTestPerson(seed);
                    int rnd = random.Next(4);
                    if(rnd == 3)
                    {
                        record.InitialRoleAcronym = string.Empty;
                        record.InitialRoleName = string.Empty;
                    }

                    (resource as Personnel).InitialRoleName = record.InitialRoleName;
                    (resource as Personnel).InitialRoleAcronym = record.InitialRoleAcronym;
                    break;
                case "Operator":
                    break;
                case "Visitor":
                    resource = createTestPerson(seed);
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;
                    break;
                case "Vehicle":
                    resource = createTestVehicle(seed);
                    (resource as Vehicle).IsEquipment = false;
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;
                    break;
                case "Equipment":
                    resource = createTestVehicle(seed);
                    (resource as Vehicle).IsEquipment = true;
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;
                    break;
                case "Crew":
                    resource = createTestCrew(seed, childResources);
                    (resource as Crew).IsEquipmentCrew = false;
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;
                    break;
                case "Heavy Equipment Crew":
                    resource = createTestCrew(seed, childResources);
                    (resource as Crew).IsEquipmentCrew = true;
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;
                    break;
                case "Aircraft":
                    resource = CreateAircraftTest(seed);
                    record.InitialRoleAcronym = string.Empty;
                    record.InitialRoleName = string.Empty;

                    break;
            }
            record.ResourceID = resource.ID;
            record.ResourceName = resource.ResourceName;
            record.ResourceType = type;



            record.InfoFields.Clear();
            record.InfoFields = CheckInTools.GetInfoFields(record.ResourceType);
            Guid checkInLocationID = new Guid("b4c8332b-ddf3-4d4c-9c83-2c62328061fe");
            List<string> checkInLocations = CheckInTools.GetInfoFieldListOptions(checkInLocationID);
            if (record.InfoFields.Any(o => o.ID == checkInLocationID))
            {
                record.InfoFields.First(o => o.ID == checkInLocationID).StringValue = checkInLocations.First();
            }

            foreach (CheckInInfoField field in record.InfoFields)
            {
                field.StringValue = "String " + seed;
                field.BoolValue = RandomBooleanGenerator.GetRandomBoolean();
                field.IntValue = seed;
                field.DateValue = DateTime.Now.AddHours(seed);

            }




            CheckInRecordWithResource test = new CheckInRecordWithResource(record, resource, DateTime.Now.AddHours(12));
            return test;

        }

        public static CommsPlanItem createTestCommsPlanItem(int seed)
        {
            CommsPlanItem test = new CommsPlanItem();
            test.CommsSystem = "CommsSystem" + seed;
            test.CallSign = "CallSign" + seed;
            test.CommsFunction = "CommsFunction" + seed;
            test.ChannelID = "ChannelID" + seed;
            test.ChannelNumber = "ChannelNumber" + seed;
            test.RxFrequency = "RxFrequency" + seed;
            test.Comments = "Comments" + seed;
            test.IsRepeater = RandomBooleanGenerator.GetRandomBoolean();
            test.LastUpdatedUTC = DateTime.Now;
            test.Active = true;
            test.OrganizationID = Guid.Empty;
            test.OpPeriod = 1;
            test.RxTone = "RxTone" + seed;
            test.Assignment = "Aassignment" + seed;
            test.TemplateItemID = Guid.Empty;
            test.UsedForAircraft = RandomBooleanGenerator.GetRandomBoolean();
            test.TxFrequency = "TxFrequency" + seed;
            test.TxTone = "TxTone" + seed;
            return test;
        }

        public static CommsPlan createTestCommsPlan(int seed)
        {
            CommsPlan test = new CommsPlan();

            test.OpPeriod = seed;
            test.DatePrepared = DateTime.Now.AddHours(seed);
            test.PreparedByResourceName = RandomNameGenerator.FirstName + " " + RandomNameGenerator.LastName;
            test.allCommsItems = new List<CommsPlanItem>();
            for (int x = 0; x < 5; x++)
            {
                CommsPlanItem item = createTestCommsPlanItem(x);
                test.allCommsItems.Add(item);
            }


            test.LastUpdatedUTC = DateTime.Now;
            return test;
        }

      

        public static GeneralMessage createTestGeneralMessage(int seed)
        {
            GeneralMessage test = new GeneralMessage();

            test.OpPeriod = 1;
            test.ToName = "ToName" + seed;
            test.ToPosition = "ToPosition" + seed;
            test.FromName = "FromName" + seed;
            test.FromPosition = "FromPosition" + seed;
            test.DateSent = DateTime.Now.AddHours(seed);
            test.LastUpdatedUTC = DateTime.UtcNow;
            test.ApprovedByResourceName = "ApprovedByName" + seed;
            test.ReplyByPosition = "ReplyByPosition" + seed;
            test.ReplyByName = "ReplyByName" + seed;
            test.Subject = "Subject" + seed;
            test.Message = StringExt.LoremIpsum(5, 100, 5, 10, 2);
            test.Reply = StringExt.LoremIpsum(5, 100, 5, 10, 2);
            test.Active = true;
            test.ReplyDate = DateTime.Now.AddHours(seed * 2);
            test.FromRoleID = Globals.OpsChiefGenericID;
            test.ApprovedByRoleID = Globals.UnifiedCommand1GenericID;

            return test;
        }

        public static IncidentObjective createTestIncidentObjective(int seed, int opPeriod = 0)
        {
            IncidentObjective test = new IncidentObjective();
            test.Objective = "Objective " + seed;
            test.Priority = seed;
            test.OpPeriod = opPeriod;
            test.Completed = RandomBooleanGenerator.GetRandomBoolean();
           

            return test;
        }

        public static IncidentObjectivesSheet createTestObjectiveSheet(int seed)
        {
            IncidentObjectivesSheet sheet = new IncidentObjectivesSheet();
            sheet.OpPeriod = seed;
            sheet.DatePrepared = DateTime.Now;
            sheet.WeatherForecast = "WeatherForcast " + seed;
            sheet.GeneralSafety = "General Safety" + seed;
            sheet.FireSize = random.Next(100).ToString();
            sheet.FireStatus = "Status" + seed;
            sheet.PreparedByResourceName = "Tim " + seed;
            sheet.PreparedByRoleName = "Planning Section Chief";
            sheet.ApprovedByResourceName = "Jim " + seed;
            sheet.ApprovedByRoleName = "EOC Director";
            for (int x = 0; x < 5; x++)
            {
                sheet.Objectives.Add(createTestIncidentObjective(x, sheet.OpPeriod));
            }
            

            return sheet;
        }
    }
}
