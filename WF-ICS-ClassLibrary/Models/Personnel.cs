using Microsoft.VisualBasic.FileIO;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class Personnel : IncidentResource, IEquatable<Personnel>, ICloneable
    {
        public Personnel()
        {
            ResourceType = this.GetType().Name;
            PersonID = Guid.NewGuid();
            MemberActive = true;
            CurrentStatus = null;
            HomeCountry = "Canada";
            NumberOfPeople = 1;
            NumberOfVehicles = 0;
        }
        public Personnel(Guid id)
        {
            ResourceType = this.GetType().Name;
            PersonID = id;
            MemberActive = true;
            CurrentStatus = null;
            HomeCountry = "Canada";
            NumberOfPeople = 1;
            NumberOfVehicles = 0;
        }

        [ProtoMember(1)] private string _FirstName;
        [ProtoMember(2)] private string _LastName;
        [ProtoMember(3)] private string _MiddleInitial;
        [ProtoMember(4)] private string _Gender;
        [ProtoMember(5)] private bool _HasDietaryRestrictions;
        [ProtoMember(6)] private bool _HasAllergies;
        [ProtoMember(7)] private string _Weight;
        [ProtoMember(8)] private string _CellphoneNumber;
        [ProtoMember(9)] private string _Email;
        [ProtoMember(10)] private string _HomeUnit;
        [ProtoMember(11)] private Guid _HomeProvince;
        [ProtoMember(12)] private string _HomeCountry;
        [ProtoMember(13)] private string _EmergencyContact;
        [ProtoMember(14)] private string _Agency;
        [ProtoMember(15)] private bool _IsContractor;
        [ProtoMember(16)] private string _CallSign;
        [ProtoMember(17)] private string _Pronouns; 
        [ProtoMember(18)] private string _AccomodationPreference;
        [ProtoMember(19)] private string _InitialRoleName;
        [ProtoMember(20)] private string _InitialRoleAcronym;










        [ProtoMember(28)] private MemberStatus _currentStatus;




        public string FirstName { get => _FirstName; set { _FirstName = value; SetName(); } }
        public string LastName { get => _LastName; set { _LastName = value; SetName(); } }
        public string MiddleInitial { get => _MiddleInitial; set { _MiddleInitial = value; SetName(); } }
        public string Gender { get => _Gender; set => _Gender = value; }
        public bool HasDietaryRestrictions { get => _HasDietaryRestrictions; set => _HasDietaryRestrictions = value; }
        public bool HasAllergies { get => _HasAllergies; set => _HasAllergies = value; }
        public string Weight { get => _Weight; set => _Weight = value; }
        public string CellphoneNumber { get => _CellphoneNumber; set => _CellphoneNumber = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string HomeUnit { get => _HomeUnit; set => _HomeUnit = value; }
        public Guid HomeProvinceID { get => _HomeProvince; set => _HomeProvince = value; }
        public string HomeCountry { get => _HomeCountry; set => _HomeCountry = value; }
        public string EmergencyContact { get => _EmergencyContact; set => _EmergencyContact = value; }
        public string Agency { get => _Agency; set => _Agency = value; }
        public bool IsContractor { get => _IsContractor; set => _IsContractor = value; }
        public string CallSign { get => _CallSign; set => _CallSign = value; }
        public string Pronouns { get => _Pronouns; set => _Pronouns = value; }
        public string AccomodationPreference { get => _AccomodationPreference; set => _AccomodationPreference = value; }
        public int PNum { get => UniqueIDNum; set => UniqueIDNum = value; }
        public string InitialRoleName { get => _InitialRoleName; set => _InitialRoleName = value; }
        public string InitialRoleAcronym { get => _InitialRoleAcronym; set => _InitialRoleAcronym = value; }
        public string NameWithInitialRoleAcronym
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Name);
                if (!string.IsNullOrEmpty(InitialRoleAcronym)) { sb.Append(" (initial: "); sb.Append(InitialRoleAcronym); sb.Append(")"); }
                return sb.ToString();
            }
        }

        private void SetName()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(FirstName)) { sb.Append(FirstName); }
            if (!string.IsNullOrEmpty(MiddleInitial))
            {
                if(sb.Length > 0) { sb.Append(" "); }
                sb.Append(MiddleInitial);
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                if (sb.Length > 0) { sb.Append(" "); }
                sb.Append(LastName);
            }
            ResourceName = sb.ToString();
            LeaderName = sb.ToString();
        }







        public Guid PersonID { get => ID; set => ID = value; }

        public string Name { get => ResourceName; set => ResourceName = value; }
        public string NameWithAgency { get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Agency)) {  sb.Append(Agency); sb.Append(" > "); }
                sb.Append(Name);
                
                return sb.ToString();

            }
        }


        public bool MemberActive { get => Active; set => Active = value; }
        public MemberStatus CurrentStatus { get => _currentStatus; set => _currentStatus = value; }
        public string ProvinceName
        {
            get
            {
                if (HomeProvinceID != Guid.Empty) { Province p = new Province(HomeProvinceID); return p.ProvinceName; }
                else { return string.Empty; }
            }
        }
        public string ProvinceNameShort
        {
            get
            {
                if (HomeProvinceID != Guid.Empty) { Province p = new Province(HomeProvinceID); return p.ProvinceShort; }
                else { return string.Empty; }
            }
        }




        

        public Personnel Clone()
        {
            Personnel cloneTo = this.MemberwiseClone() as Personnel;
            if (this.CurrentStatus != null) { cloneTo.CurrentStatus = CurrentStatus.Clone(); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    

        public bool Equals(Personnel other)
        {
            // Would still want to check for null etc. first.
            return this.PersonID == other.PersonID;
        }


      

        public List<Personnel> getMembersFromCSV(string filename, int callsignColumn = -1)
        {
            List<Personnel> members = new List<Personnel>();

            int nameField = 0;
            int RefField = 2;
            int phoneField = 5;
            int emailField = 3;
            int addressField = 9;
            int d4hstatusfield = 12;
            int nokfield = 20;
            int nokrelationfield = 21;
            int nokphoenfield = 22;




            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();

                    if (fields[0] == "Name")
                    {
                        for (int x = 0; x < fields.Length; x++)
                        {
                            switch (fields[x])
                            {
                                case "Address":
                                    addressField = x;
                                    break;
                                case "Emergency Contact 1 Name":
                                    nokfield = x;
                                    break;
                                case "Emergency Contact 1 Relation":
                                    nokrelationfield = x;
                                    break;
                                case "Emergency Contact 1 Phone":
                                    nokphoenfield = x;
                                    break;
                                case "Email":
                                    emailField = x;
                                    break;
                                case "Reference":
                                    RefField = x;
                                    break;
                                case "Mobile Phone":
                                    phoneField = x;
                                    break;
                                case "Status":
                                    d4hstatusfield = x;
                                    break;
                            }
                        }


                    }
                    else
                    {
                        Personnel member = new Personnel();
                        member.Name = fields[nameField];
                        member.CellphoneNumber = fields[phoneField];
                        member.MemberActive = true;
                        member.Email = fields[emailField];
                       
                        if (callsignColumn >= 0) { member.CallSign = fields[callsignColumn]; }
                        members.Add(member);
                    }
                    /*
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                        string hi = field;
                    }*/
                }
            }
            return members;

        }


       

    }

    

    [Serializable]
    [ProtoContract]
    public class MemberStatus : ICloneable
    {
        public MemberStatus()
        {
        }
        [ProtoMember(1)] private Guid _AssignmentID;
        // [ProtoMember(2)]
        //private ICSRole _icsrole = new ICSRole();
        [ProtoMember(3)] private DateTime _signInTime;
        [ProtoMember(4)] private DateTime _signOutTime;
        [ProtoMember(5)] private decimal _kms;

        [ProtoMember(6)] private string _MemberName;
        [ProtoMember(7)] private Guid _MemberID;
        [ProtoMember(8)] private Guid _OrganizationID;
        [ProtoMember(9)] private string _OrganizationName;
        [ProtoMember(10)] private int _AssignmentNumber;
        [ProtoMember(11)] private string _AssignmentName;
        [ProtoMember(12)] private string _CurrentAssignmentStatus;

        [ProtoMember(13)] private string _ICSRoleName;
        [ProtoMember(14)] private Guid _ICSRoleID;
        [ProtoMember(15)] private DateTime _LastDayWorked;
        [ProtoMember(16)] private string _Callsign;
        [ProtoMember(17)] private Guid _CheckInRecordID;
        [ProtoMember(18)] private Guid _CheckOutRecordID;
        [ProtoMember(19)] private string _InitialRoleName;

        public Guid AssignmentID { get => _AssignmentID; set => _AssignmentID = value; }

        public DateTime SignInTime { get { return _signInTime; } set { _signInTime = value; } }
        public string SignInTimeAsText
        {
            get
            {
                if (_signInTime > DateTime.MinValue) { return _signInTime.ToString(Globals.DateFormat + " HH:mm"); }
                else { return "Not checked in"; }
            }
        }
        public DateTime SignOutTime { get { return _signOutTime; } set { _signOutTime = value; } }
        public string SignOutTimeOrBlank
        {
            get
            {
                if (_signOutTime < DateTime.MaxValue)
                {
                    return string.Format("{0:" + Globals.DateFormat + " HH:mm}", _signOutTime);
                }
                else
                {
                    return null;
                }
            }
        }
        public bool IsSignedOut
        {
            get
            {
                return _signOutTime < DateTime.MaxValue;
            }
        }
        public double HoursOnTask
        {
            get
            {
                if (IsSignedOut && SignInTime > DateTime.MinValue && SignInTime < DateTime.MaxValue && SignOutTime > DateTime.MinValue && SignOutTime < DateTime.MaxValue)
                {
                    TimeSpan ts = SignOutTime - SignInTime;
                    return ts.TotalHours;
                }
                else { return 0; }
            }
        }

        public int AssignmentNumber { get => _AssignmentNumber; set => _AssignmentNumber = value; }
        public string AssignmentName { get => _AssignmentName; set => _AssignmentName = value; }
        public string AssignmentNameWthNumber { get { if (_AssignmentNumber > 0) { return _AssignmentNumber + " " + _AssignmentName; } else { return _AssignmentName; } } }
        public string AssignmentStatus { get => _CurrentAssignmentStatus; set => _CurrentAssignmentStatus = value; }


        //public ICSRole currentICSRole { get { return _icsrole; } set { _icsrole = value; } }
        public string ICSRoleName { get => _ICSRoleName; set => _ICSRoleName = value; }
        public Guid ICSRoleID { get => _ICSRoleID; set => _ICSRoleID = value; }

        //public string ICSRoleName { get { return currentICSRole.RoleName; } }
        public string getCurrentActivityName { get { if (ICSRoleID != Guid.Empty && AssignmentNameWthNumber != "Signed Out") { return ICSRoleName; } else { return AssignmentNameWthNumber; } } }
        public bool IsAssigned
        {
            get
            {
                if (ICSRoleID != Guid.Empty) { return true; }
                if(AssignmentID != Guid.Empty) { return true; }
                return false;
            }
        }

        public decimal KMs { get => _kms; set => _kms = value; }

        public string MemberName { get => _MemberName; set => _MemberName = value; }
        public Guid MemberID { get => _MemberID; set => _MemberID = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public string OrganizationName { get => _OrganizationName; set => _OrganizationName = value; }
        public DateTime LastDayWorked { get => _LastDayWorked; set => _LastDayWorked = value; }
        public string LastDayWorkedAsStr
        {
            get
            {
                if (LastDayWorked > DateTime.MinValue) { return LastDayWorked.ToString(Globals.DateFormat); }
                else { return null; }
            }
        }

        public Guid CheckInRecordID { get => _CheckInRecordID; set => _CheckInRecordID = value; }

        public Guid CheckOutRecordID { get => _CheckOutRecordID; set => _CheckOutRecordID = value; }

        public string Callsign { get => _Callsign; set => _Callsign = value; }

        public string InitialRoleName { get => _InitialRoleName; set => _InitialRoleName = value; }



        public void setTeamMember(Personnel member)
        {
            MemberName = member.Name;
            MemberID = member.PersonID;
            _OrganizationName = member.Agency;
            Callsign = member.CallSign;

        }
        public MemberStatus Clone()
        {
            return this.MemberwiseClone() as MemberStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    public class AgencyPersonnelCount
    {
        public int Count { get; set; }
        public string AgencyName { get; set; }
    }


   public static class PersonnelTools
    {
        public static string ExportSignInRecordsToCSV(this WFIncident incident, List<MemberStatus> records, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            //header row
            csv.Append("NAME"); csv.Append(delimiter);
            csv.Append("PROVINCE OR TERRITORY"); csv.Append(delimiter);
            csv.Append("AGENCY"); csv.Append(delimiter);
            
            csv.Append("CHECK IN"); csv.Append(delimiter);
            csv.Append("LDW"); csv.Append(delimiter);
            csv.Append("DEPARTURE POINT"); csv.Append(delimiter);
            csv.Append("METHOD OF TRAVEL"); csv.Append(delimiter);
            csv.Append("CHECK OUT"); csv.Append(delimiter);
           

            csv.Append(Environment.NewLine);
            foreach (MemberStatus status in records.OrderBy(o => o.MemberName))
            {
                CheckInRecord rec  = new CheckInRecord();
                if (incident.AllCheckInRecords.Any(o => o.ResourceID == status.MemberID))
                {
                   rec = incident.AllCheckInRecords.Where(o => o.ResourceID == status.MemberID).First();
                }

                /*
                csv.Append("\""); csv.Append(status.MemberName.EscapeQuotes()); csv.Append("\"");
                csv.Append(delimiter);
                if (rec != null) { csv.Append(rec.teamMember.ProvinceNameShort.EscapeQuotes()); }
                csv.Append(delimiter);
                csv.Append("\""); csv.Append(status.OrganizationName.EscapeQuotes()); csv.Append("\"");
                csv.Append(delimiter);
               
                csv.Append(status.SignInTime.ToString(Globals.DateFormat + " HH:mm"));
                csv.Append(delimiter);
                csv.Append(status.LastDayWorked.ToString(Globals.DateFormat + " HH:mm"));
                csv.Append(delimiter);
                if (rec != null) { csv.Append("\""); csv.Append(rec.DeparturePoint.EscapeQuotes()); csv.Append("\""); }
                csv.Append(delimiter);
                if (rec != null) { csv.Append("\""); csv.Append(rec.MethodOfTravel.EscapeQuotes()); csv.Append("\""); }
                csv.Append(delimiter);
                */

                csv.Append(status.SignOutTimeOrBlank);
               
                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

        public static List<AgencyPersonnelCount> GetAgencyPersonnelCount(this WFIncident incident, int OpPeriod)
        {
            List<AgencyPersonnelCount> counts = new List<AgencyPersonnelCount>();

            foreach (CheckInRecord record in incident.AllCheckInRecords.Where(o => o.OpPeriod == OpPeriod && o.Active && (o.IsPerson || o.IsVisitor)))
            {
                if (incident.IncidentPersonnel.Any(o => o.ID == record.ResourceID))
                {
                    Personnel per = incident.IncidentPersonnel.First(o => o.ID == record.ResourceID);
                    if (!counts.Any(o => o.AgencyName.Equals(per.Agency)))
                    {
                        AgencyPersonnelCount c = new AgencyPersonnelCount();
                        c.AgencyName = per.Agency;
                        c.Count = 0;
                        counts.Add(c);
                    }
                    counts.First(o => o.AgencyName.Equals(per.Agency)).Count++;
                }
            }
            return counts;
        }


        public static string ToCSV(this List<Personnel> members, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("First Name"); csv.Append(delimiter);
            csv.Append("Middle Initial"); csv.Append(delimiter);
            csv.Append("Last Name"); csv.Append(delimiter);
            csv.Append("Pronouns"); csv.Append(delimiter);
            csv.Append("Kind"); csv.Append(delimiter);
            csv.Append("Type"); csv.Append(delimiter);
            csv.Append("Accomodatoin Preference"); csv.Append(delimiter);
            csv.Append("Province or Territory"); csv.Append(delimiter);
            csv.Append("Country"); csv.Append(delimiter);
            csv.Append("Agency"); csv.Append(delimiter);
            csv.Append("Phone"); csv.Append(delimiter);
            csv.Append("Callsign"); csv.Append(delimiter);
            csv.Append("Email"); csv.Append(delimiter);
            csv.Append("Home Unit / Agency"); csv.Append(delimiter);
            csv.Append("Dietary Restrictions"); csv.Append(delimiter);
            csv.Append("Allergies"); csv.Append(delimiter);
            csv.Append("Employer Emergency Contact"); csv.Append(delimiter);
            
            csv.Append(Environment.NewLine);

            foreach (Personnel item in members)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 

                csv.Append("\""); csv.Append(item.FirstName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.MiddleInitial.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.LastName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Pronouns.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Kind.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Type.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.AccomodationPreference.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                if (item.HomeProvinceID != Guid.Empty) { Province p = new Province(item.HomeProvinceID); csv.Append("\""); csv.Append(p.ProvinceName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter); }
                else { csv.Append("\"");  csv.Append("\""); csv.Append(delimiter); }

                csv.Append("\""); csv.Append(item.HomeCountry.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.Agency.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.CellphoneNumber.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.CallSign.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Email.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HomeUnit.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HasDietaryRestrictions.ToString()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HasAllergies.ToString()); csv.Append("\""); csv.Append(delimiter);

                csv.Append("\""); csv.Append(item.EmergencyContact.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);


                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }

    }

    public class TeamTotal
    {
        public string TeamName { get; set; }
        public int MemberCount { get; set; }
        public TeamTotal()
        {

        }
        public TeamTotal(string name)
        {
            TeamName = name; MemberCount = 0;
        }

        public List<TeamTotal> getTeamTotals(WFIncident task, int CurrentOpPeriod)
        {
            List<TeamTotal> teamTotals = new List<TeamTotal>();
            List<MemberStatus> allStatuses = task.getAllMemberStatus(CurrentOpPeriod, DateTime.MinValue);
            int totalOverall = 0;
            foreach (MemberStatus status in allStatuses)
            {
                if (!teamTotals.Where(o => o.TeamName == status.OrganizationName).Any())
                {
                    teamTotals.Add(new TeamTotal(status.OrganizationName));
                }
                teamTotals.Where(o => o.TeamName == status.OrganizationName).First().MemberCount += 1;
                totalOverall += 1;
            }
            return teamTotals;
        }
    }

    public class GroupSignInRecords
    {
        public string GroupName { get; set; }
        public List<MemberStatus> MemberStatuses { get; set; }
        public int totalPages
        {
            get
            {
                decimal divResult = Convert.ToDecimal(MemberStatuses.Count) / 6m;
                int totalPages = Convert.ToInt32(Math.Ceiling(divResult));
                //if (OpAssignments.Count() % 7 > 0) { totalPages += 1; }
                if (totalPages == 0) { totalPages = 1; }
                return totalPages;
            }
        }

        public GroupSignInRecords() { MemberStatuses = new List<MemberStatus>(); }
        public GroupSignInRecords(string name) { GroupName = name; MemberStatuses = new List<MemberStatus>(); }
    }

}
