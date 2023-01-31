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
    public class TeamMember : IEquatable<TeamMember>, ICloneable
    {
        public TeamMember()
        {
            PersonID = Guid.NewGuid();
            MemberActive = true;
            CurrentStatus = null;
        }
        public TeamMember(Guid id)
        {
            PersonID = id;
            MemberActive = true;
            CurrentStatus = null;
        }

        [ProtoMember(1)] private Guid _PersonID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private string _Group;
        [ProtoMember(4)] private string _Callsign;
        [ProtoMember(5)] private string _Phone;
        [ProtoMember(6)] private Guid _ProvinceID;



        [ProtoMember(10)] private string _SpecialSkills;
        [ProtoMember(11)] private bool _isAssignmentTeamLeader;


        [ProtoMember(13)] private string _Agency;
        [ProtoMember(14)] private string _HomeBase;



        [ProtoMember(15)] private string _barcode;
        [ProtoMember(16)] private bool _signedIn;
        [ProtoMember(17)] private Guid _organizationID;
        [ProtoMember(18)] private Guid _userID;
        [ProtoMember(19)] private bool _memberActive;
        [ProtoMember(20)] private DateTime _lastUpdatedUTC;
        [ProtoMember(21)] private string _Email;
        [ProtoMember(22)] private Guid _CreatedByOrgID;
        [ProtoMember(23)] private string _Address;
        [ProtoMember(24)] private string _NOKName;
        [ProtoMember(25)] private string _NOKRelation;
        [ProtoMember(26)] private string _NOKPhone;

        [ProtoMember(28)] private MemberStatus _currentStatus;

        [ProtoMember(32)] private string _Dietary;
        [ProtoMember(33)] private bool _Vegetarian;
        [ProtoMember(34)] private bool _NoGluten;

        public Guid PersonID { get => _PersonID; set => _PersonID = value; }

        public string Name { get => _Name; set => _Name = value; }

        public string Group { get => _Group; set => _Group = value; } //Use OrganizationName for this value
        public string NameWithAgency { get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Agency)) {  sb.Append(Agency); sb.Append(" > "); }
                sb.Append(Name);
                
                return sb.ToString();

            }
        }
        public string NameWithGroup
        {
            get
            {
                if (!string.IsNullOrEmpty(Group)) { return Name + " (" + Group + ")"; }
                else { return Name; }
            }
        }
        public string NameAndContact { get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Name);
                if (!string.IsNullOrEmpty(Phone)) { sb.Append(" "); sb.Append(Phone.FormatPhone()); }
                return sb.ToString();
            } }

        public string Callsign { get => _Callsign; set => _Callsign = value; }
        public string Phone { get => _Phone.FormatPhone(); set => _Phone = value; }
        public string SpecialSkills { get => _SpecialSkills; set => _SpecialSkills = value; }
        public bool isAssignmentTeamLeader { get => _isAssignmentTeamLeader; set => _isAssignmentTeamLeader = value; }
        public string Barcode { get { return _barcode; } set { _barcode = value; } }
        public bool SignedInToTask { get { return _signedIn; } set { _signedIn = value; } }
        public Guid OrganizationID { get => _organizationID; set => _organizationID = value; }
        public Guid UserID { get => _userID; set => _userID = value; }
        public bool MemberActive { get => _memberActive; set => _memberActive = value; }
        public DateTime LastUpdatedUTC { get => _lastUpdatedUTC; set => _lastUpdatedUTC = value; }
        public string Email { get => _Email; set => _Email = value; }
        public Guid CreatedByOrgID { get => _CreatedByOrgID; set => _CreatedByOrgID = value; } //used when a team creates members from outside their group for a task.
        public string Address { get => _Address; set => _Address = value; }
        public string AddressWithPhone
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Address))
                {
                    sb.Append(Address.Replace("\r\n", " "));
                    if (!string.IsNullOrEmpty(Phone)) { sb.Append("\n"); }
                }
                if (!string.IsNullOrEmpty(Phone)) { sb.Append(Phone); }

                return sb.ToString();
            }
        }
        public MemberStatus CurrentStatus { get => _currentStatus; set => _currentStatus = value; }
        public string Dietary { get => _Dietary; set => _Dietary = value; }
        public bool Vegetarian { get => _Vegetarian; set => _Vegetarian = value; }
        public bool NoGluten { get => _NoGluten; set => _NoGluten = value; }

        public Guid ProvinceID { get => _ProvinceID; set => _ProvinceID = value; }
        public string ProvinceName
        {
            get
            {
                if (ProvinceID != Guid.Empty) { Province p = new Province(ProvinceID); return p.ProvinceName; }
                else { return string.Empty; }
            }
        }
        public string ProvinceNameShort
        {
            get
            {
                if (ProvinceID != Guid.Empty) { Province p = new Province(ProvinceID); return p.ProvinceShort; }
                else { return string.Empty; }
            }
        }


        public string Agency { get => _Agency; set => _Agency = value; }
        public string HomeBase { get => _HomeBase; set => _HomeBase = value; }

        public string NOKName { get => _NOKName; set => _NOKName = value; }
        public string NOKRelation { get => _NOKRelation; set => _NOKRelation = value; }
        public string NOKPhone { get => _NOKPhone; set => _NOKPhone = value; }
        public string NOKOneLine
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(NOKName)) { sb.Append(NOKName); sb.Append(" "); }
                if (!string.IsNullOrEmpty(NOKRelation)) { sb.Append("("); sb.Append(NOKRelation); sb.Append(") "); }
                if (!string.IsNullOrEmpty(NOKPhone)) { sb.Append(NOKPhone); }
                return sb.ToString();
            }
        }


        public void removeTildeFromRecord()
        {
            if (Name.Contains("~")) { Name = Name.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Address) && Address.Contains("~")) { Address = Address.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Phone) && Phone.Contains("~")) { Phone = Phone.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Email) && Email.Contains("~")) { Email = Email.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Callsign) && Callsign.Contains("~")) { Callsign = Callsign.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Dietary) && Dietary.Contains("~")) { Dietary = Dietary.Replace("~", ""); }

        }


        public string StringForQR
        {
            get
            {
                StringBuilder qr = new StringBuilder();
                qr.Append(PersonID.ToString()); qr.Append(";"); //remove?

                qr.Append(Name); qr.Append(";");
                qr.Append(OrganizationID); qr.Append(";");
                if (!string.IsNullOrEmpty(Address)) { qr.Append(Address.Replace(Environment.NewLine, " ")); } else { qr.Append(""); }
                qr.Append(";");
                qr.Append(Phone); qr.Append(";");
                qr.Append(Email); qr.Append(";");
                qr.Append(Callsign); qr.Append(";"); //remove
                //qualifications
                //pretend these are characters in a binary string and convert to int?

                //nok


                return qr.ToString();
            }
        }

        public string StringForQRCompressed
        {
            get
            {
                StringBuilder qr = new StringBuilder();
                // qr.Append(PersonID.ToString()); qr.Append(";"); //remove?

                qr.Append(Name); qr.Append(";");
                if (OrganizationID != Guid.Empty)
                {
                    Organization org = OrganizationTools.GetOrganization(OrganizationID);

                    if (org != null)
                    {
                        qr.Append(org.ShortOrganizationID); qr.Append(";");
                    }
                    else { qr.Append(""); qr.Append(";"); }
                }
                else { qr.Append(""); qr.Append(";"); }
                if (!string.IsNullOrEmpty(Address)) { qr.Append(Address.Replace(Environment.NewLine, " ")); } else { qr.Append(""); }
                qr.Append(";");
                if (!string.IsNullOrEmpty(Phone)) { qr.Append(Phone.Replace("-", "").Replace(" ", "")); } else { qr.Append(""); }
                qr.Append(";");
                qr.Append(Email); qr.Append(";");
                // qr.Append(Callsign); qr.Append(";"); //remove
                // qr.Append(Reference); qr.Append(";"); //remove
                //qualifications
                //pretend these are characters in a binary string and convert to int?


                return qr.ToString();
            }
        }

        

        public TeamMember Clone()
        {
            TeamMember cloneTo = this.MemberwiseClone() as TeamMember;
            if (this.CurrentStatus != null) { cloneTo.CurrentStatus = CurrentStatus.Clone(); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public void createClone(TeamMember teamMember)
        {
            PersonID = teamMember.PersonID;
            Name = teamMember.Name;
            Group = teamMember.Group;
            Callsign = teamMember.Callsign;
            Phone = teamMember.Phone;
            SpecialSkills = teamMember.SpecialSkills;
            isAssignmentTeamLeader = teamMember.isAssignmentTeamLeader;
            Barcode = teamMember.Barcode;
            OrganizationID = teamMember.OrganizationID;
            UserID = teamMember.UserID;
            MemberActive = teamMember.MemberActive;
            LastUpdatedUTC = teamMember.LastUpdatedUTC;
            Email = teamMember.Email;
            CreatedByOrgID = teamMember.CreatedByOrgID;
            Address = teamMember.Address;
            CurrentStatus = teamMember.CurrentStatus;
            Dietary = teamMember.Dietary;
            Vegetarian = teamMember.Vegetarian;
            NoGluten = teamMember.NoGluten;
        }

        public bool IsIdentical(TeamMember compareTo)
        {
            bool Identical = true;

            if (PersonID != compareTo.PersonID) { Identical = false; }
            if (Name != compareTo.Name) { Identical = false; }
            if (Group != compareTo.Group) { Identical = false; }
            if (Callsign != compareTo.Callsign) { Identical = false; }
            if (Phone != compareTo.Phone) { Identical = false; }
            if (SpecialSkills != compareTo.SpecialSkills) { Identical = false; }
            if (isAssignmentTeamLeader != compareTo.isAssignmentTeamLeader) { Identical = false; }
            if (Barcode != compareTo.Barcode) { Identical = false; }
            if (OrganizationID != compareTo.OrganizationID) { Identical = false; }
            if (UserID != compareTo.UserID) { Identical = false; }
            if (MemberActive != compareTo.MemberActive) { Identical = false; }
            if (LastUpdatedUTC != compareTo.LastUpdatedUTC) { Identical = false; }
            if (Email != compareTo.Email) { Identical = false; }
            if (CreatedByOrgID != compareTo.CreatedByOrgID) { Identical = false; }
            if (Address != compareTo.Address) { Identical = false; }
            return Identical;
        }

        public bool Equals(TeamMember other)
        {
            // Would still want to check for null etc. first.
            return this.PersonID == other.PersonID;
        }


      

        public List<TeamMember> getMembersFromCSV(string filename, int callsignColumn = -1)
        {
            List<TeamMember> members = new List<TeamMember>();

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
                        TeamMember member = new TeamMember();
                        member.Name = fields[nameField];
                        member.Phone = fields[phoneField];
                        member.MemberActive = true;
                        member.Email = fields[emailField];
                        member.Address = fields[addressField];
                        if (callsignColumn >= 0) { member.Callsign = fields[callsignColumn]; }
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

    [ProtoContract]
    [Serializable]
    public class SignInRecord : ICloneable
    {
        [ProtoMember(1)] private DateTime _statusChangeTime = DateTime.MinValue;
        /*[ProtoMember(2)]
        private DateTime _signOutTime = DateTime.MaxValue;*/
        /*
        [ProtoMember(3)]
        private Guid _memberID;*/
        [ProtoMember(4)] private int _opPeriod;
        [ProtoMember(5)] private Guid _signInRecordID;
        [ProtoMember(6)] private TeamMember _teamMember;
        [ProtoMember(7)] private bool _isSignIn;
        [ProtoMember(8)] private decimal _KMs;
        [ProtoMember(9)] private DateTime _TimeOutRequest;
        [ProtoMember(10)] private DateTime _RecordUpdatedUTC;
        [ProtoMember(11)] private DateTime _LastDayWorked;
        [ProtoMember(12)] private string _DeparturePoint;
        [ProtoMember(13)] private DateTime _DepartureTime;
        [ProtoMember(14)] private string _MethodOfTravel;

        public DateTime StatusChangeTime { get { return _statusChangeTime; } set { _statusChangeTime = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        /*public DateTime SignOutTime { get { return _signOutTime; } set { _signOutTime = value; } }*/
        public Guid MemberID { get { return _teamMember.PersonID; } set { _teamMember.PersonID = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public int OpPeriod { get { return _opPeriod; } set { _opPeriod = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public Guid SignInRecordID { get { return _signInRecordID; } set { _signInRecordID = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public TeamMember teamMember { get => _teamMember; set { _teamMember = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public bool IsSignIn { get => _isSignIn; set { _isSignIn = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public decimal KMs { get => _KMs; set { _KMs = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public DateTime TimeOutRequest { get => _TimeOutRequest; set { _TimeOutRequest = value; RecordUpdatedUTC = DateTime.UtcNow; } }

        public SignInRecord() { SignInRecordID = Guid.NewGuid(); _teamMember = new TeamMember(); }
        public DateTime RecordUpdatedUTC { get => _RecordUpdatedUTC; set => _RecordUpdatedUTC = value; }


        public DateTime SignInTime { get => _statusChangeTime; set { _statusChangeTime = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public DateTime SignOutTime { get => _statusChangeTime; set { _statusChangeTime = value; RecordUpdatedUTC = DateTime.UtcNow; } }
        public string InOrOut { get { if (IsSignIn) { return "Sign In"; } else { return "Sign Out"; } } }


        public DateTime LastDayWorked { get => _LastDayWorked; set => _LastDayWorked = value; }
        public string DeparturePoint { get => _DeparturePoint; set => _DeparturePoint = value; }
        public DateTime DepartureTime { get => _DepartureTime; set => _DepartureTime = value; }
        public string MethodOfTravel { get => _MethodOfTravel; set => _MethodOfTravel = value; }

        public SignInRecord Clone()
        {
            SignInRecord cloneTo = this.MemberwiseClone() as SignInRecord;
            cloneTo.teamMember = this.teamMember.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
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
        [ProtoMember(15)] private DateTime _TimeOutRequest;
        [ProtoMember(16)] private string _Callsign;

      
        public Guid AssignmentID { get => _AssignmentID; set => _AssignmentID = value; }

        public DateTime SignInTime { get { return _signInTime; } set { _signInTime = value; } }
        public string SignInTimeAsText
        {
            get
            {
                if (_signInTime > DateTime.MinValue) { return _signInTime.ToString("HH:mm yyyy-MMM-dd"); }
                else { return "Not signed in"; }
            }
        }
        public DateTime SignOutTime { get { return _signOutTime; } set { _signOutTime = value; } }
        public string SignOutTimeOrBlank
        {
            get
            {
                if (_signOutTime < DateTime.MaxValue)
                {
                    return string.Format("{0:HH:mm}", _signOutTime);
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
        public decimal KMs { get => _kms; set => _kms = value; }

        public string MemberName { get => _MemberName; set => _MemberName = value; }
        public Guid MemberID { get => _MemberID; set => _MemberID = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public string OrganizationName { get => _OrganizationName; set => _OrganizationName = value; }
        public DateTime TimeOutRequest { get => _TimeOutRequest; set => _TimeOutRequest = value; }
        public string TimeOutRequestAsStr
        {
            get
            {
                if (TimeOutRequest > DateTime.MinValue) { return TimeOutRequest.ToString("HH:mm"); }
                else { return null; }
            }
        }
        public string Callsign { get => _Callsign; set => _Callsign = value; }
        public void setTeamMember(TeamMember member)
        {
            MemberName = member.Name;
            MemberID = member.PersonID;
            OrganizationID = member.OrganizationID;
            _OrganizationName = member.Group;
            Callsign = member.Callsign;
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


   public static class TeamMemberTools
    {
        public static List<AgencyPersonnelCount> GetAgencyPersonnelCount(this WFIncident incident, int OpPeriod)
        {
            List<AgencyPersonnelCount> counts = new List<AgencyPersonnelCount>();

            foreach (SignInRecord record in incident.AllSignInRecords.Where(o => o.OpPeriod == OpPeriod))
            {
                if (!counts.Any(o => o.AgencyName.Equals(record.teamMember.Agency)))
                {
                    AgencyPersonnelCount c = new AgencyPersonnelCount();
                    c.AgencyName = record.teamMember.Agency;
                    c.Count = 0;
                    counts.Add(c);
                }
                counts.First(o => o.AgencyName.Equals(record.teamMember.Agency)).Count++;
            }
            return counts;
        }

        public static TeamMember getMemberFromQR(string qr)
        {
            TeamMember member = new TeamMember();
            string[] bits = qr.Split(';');
            if (bits.Length < 11)
            {
                return getMemberFromSimplifiedQR(qr);
            }
            else
            {
                if (bits.Length > 0)
                {
                    member.PersonID = new Guid(bits[0]);
                    member.Name = bits[1];
                    try
                    {
                        member.OrganizationID = new Guid(bits[2]);
                        Organization org = OrganizationTools.GetOrganization(member.OrganizationID);
                        if (org != null) { member.Group = org.OrganizationName; }
                    }
                    catch (Exception) { }

                    member.Address = bits[3];
                    member.Phone = bits[4];
                    member.Email = bits[5];
                    member.Callsign = bits[6];
                }

                return member;
            }
        }

        public static TeamMember getMemberFromSimplifiedQR(string qr)
        {
            if (!string.IsNullOrEmpty(qr))
            {
                TeamMember member = new TeamMember();
                string[] bits = qr.Split(';');
                if (bits.Length > 0)
                {
                    // member.PersonID = new Guid(bits[0]);
                    member.Name = bits[0];
                    try
                    {
                        string shortOrgID = bits[1];
                        List<Organization> allOrgs = OrganizationTools.GetOrganizations(Guid.Empty);// new Organization().getStaticOrganizationList();
                        if (allOrgs.Any(o => o.ShortOrganizationID == shortOrgID))
                        {
                            Organization org = allOrgs.First(o => o.ShortOrganizationID == shortOrgID);
                            member.OrganizationID = org.OrganizationID;
                            member.Group = org.OrganizationName;
                        }
                    }
                    catch (Exception) { }

                    member.Address = bits[2];
                    member.Phone = bits[3];
                    member.Email = bits[4];

                }

                return member;
            }
            else { return null; }
        }

        public static string ToCSV(this List<TeamMember> members, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("Name"); csv.Append(delimiter);
            csv.Append("Province or Territory"); csv.Append(delimiter);
            csv.Append("Agency"); csv.Append(delimiter);
            csv.Append("Phone"); csv.Append(delimiter);
            csv.Append("Email"); csv.Append(delimiter);
            csv.Append("Home Unit / Agency"); csv.Append(delimiter);
            csv.Append("Other Qualifications"); csv.Append(delimiter);
            csv.Append("Vegetarian"); csv.Append(delimiter);
            csv.Append("No Gluten"); csv.Append(delimiter);
            csv.Append("Other Dietary"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);

            foreach (TeamMember item in members)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 

                csv.Append("\""); csv.Append(item.Name.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                if(item.ProvinceID != Guid.Empty) { Province p = new Province(item.ProvinceID); csv.Append("\""); csv.Append(p.ProvinceName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter); }
                else { csv.Append("\"");  csv.Append("\""); csv.Append(delimiter); }
                
                csv.Append("\""); csv.Append(item.Agency.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Phone.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.Email.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.HomeBase.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.SpecialSkills.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                if (item.Vegetarian) { csv.Append("\"YES\""); csv.Append(delimiter); } else { csv.Append("\"NO\""); csv.Append(delimiter); }
                if (item.NoGluten) { csv.Append("\"YES\""); csv.Append(delimiter); } else { csv.Append("\"NO\""); csv.Append(delimiter); }
                csv.Append("\""); csv.Append(item.Dietary.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
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
