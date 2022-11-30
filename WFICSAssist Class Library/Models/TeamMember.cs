using Microsoft.VisualBasic.FileIO;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
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

        [ProtoMember(1)] private Guid _PersonID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private string _Group;
        [ProtoMember(4)] private string _Callsign;
        [ProtoMember(5)] private string _Phone;
        [ProtoMember(6)] private bool _RopeRescue;
        [ProtoMember(7)] private bool _Tracker;
        [ProtoMember(8)] private bool _FirstAid;
        [ProtoMember(9)] private bool _GSAR;
        [ProtoMember(10)] private string _SpecialSkills;
        [ProtoMember(11)] private bool _isAssignmentTeamLeader;
        [ProtoMember(12)] private string _Reference;
        [ProtoMember(13)] private bool _GSTL = false;
        [ProtoMember(14)] private bool _SARM;
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
        [ProtoMember(27)] private string _D4HStatus;
        [ProtoMember(28)] private MemberStatus _currentStatus;
        [ProtoMember(29)] private bool _Swiftwater;
        [ProtoMember(30)] private bool _MountainRescue;
        [ProtoMember(31)] private int _D4HID;
        [ProtoMember(32)] private string _Dietary;
        [ProtoMember(33)] private bool _Vegetarian;
        [ProtoMember(34)] private bool _NoGluten;

        public Guid PersonID { get => _PersonID; set => _PersonID = value; }
        public int D4HID { get => _D4HID; set => _D4HID = value; }

        public string Name { get => _Name; set => _Name = value; }

        public string Group { get => _Group; set => _Group = value; } //Use OrganizationName for this value
        public string NameWithGroup
        {
            get
            {
                if (!string.IsNullOrEmpty(Group)) { return Name + " (" + Group + ")"; }
                else { return Name; }
            }
        }
        public string NameWithTL
        {
            get
            {
                if (GSTL) { return Name + " (GSTL)"; }
                else { return Name; }
            }
        }
        public string NameWithSARM
        {
            get
            {
                if (SARM) { return Name + " (SAR Mgr)"; }
                else { return Name; }
            }
        }


        public string Callsign { get => _Callsign; set => _Callsign = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public bool RopeRescue { get => _RopeRescue; set => _RopeRescue = value; }
        public bool Tracker { get => _Tracker; set => _Tracker = value; }
        public bool FirstAid { get => _FirstAid; set => _FirstAid = value; }
        public bool GSAR { get => _GSAR; set => _GSAR = value; }
        public string SpecialSkills { get => _SpecialSkills; set => _SpecialSkills = value; }
        public bool isAssignmentTeamLeader { get => _isAssignmentTeamLeader; set => _isAssignmentTeamLeader = value; }
        public string Reference { get { return _Reference; } set { _Reference = value; } }
        public bool GSTL { get { return _GSTL; } set { _GSTL = value; } }
        public bool SARM { get { return _SARM; } set { _SARM = value; } }
        public bool Swiftwater { get => _Swiftwater; set => _Swiftwater = value; }
        public bool MountainRescue { get => _MountainRescue; set => _MountainRescue = value; }
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
        public string D4HStatus { get => _D4HStatus; set => _D4HStatus = value; }
        public MemberStatus CurrentStatus { get => _currentStatus; set => _currentStatus = value; }
        public string Dietary { get => _Dietary; set => _Dietary = value; }
        public bool Vegetarian { get => _Vegetarian; set => _Vegetarian = value; }
        public bool NoGluten { get => _NoGluten; set => _NoGluten = value; }


        public void removeTildeFromRecord()
        {
            if (Name.Contains("~")) { Name = Name.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Address) && Address.Contains("~")) { Address = Address.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Phone) && Phone.Contains("~")) { Phone = Phone.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Email) && Email.Contains("~")) { Email = Email.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Callsign) && Callsign.Contains("~")) { Callsign = Callsign.Replace("~", ""); }
            if (!string.IsNullOrEmpty(Reference) && Reference.Contains("~")) { Reference = Reference.Replace("~", ""); }
            if (!string.IsNullOrEmpty(NOKName) && NOKName.Contains("~")) { NOKName = NOKName.Replace("~", ""); }
            if (!string.IsNullOrEmpty(NOKRelation) && NOKRelation.Contains("~")) { NOKRelation = NOKRelation.Replace("~", ""); }
            if (!string.IsNullOrEmpty(NOKPhone) && NOKPhone.Contains("~")) { NOKPhone = NOKPhone.Replace("~", ""); }
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
                qr.Append(Reference); qr.Append(";"); //remove
                //qualifications
                //pretend these are characters in a binary string and convert to int?
                if (GSAR) { qr.Append("1"); } else { qr.Append("0"); }
                if (GSTL) { qr.Append("1"); } else { qr.Append("0"); }
                if (SARM) { qr.Append("1"); } else { qr.Append("0"); }
                if (FirstAid) { qr.Append("1"); } else { qr.Append("0"); }
                if (RopeRescue) { qr.Append("1"); } else { qr.Append("0"); }
                if (Tracker) { qr.Append("1"); } else { qr.Append("0"); }
                if (Swiftwater) { qr.Append("1"); } else { qr.Append("0"); }
                if (MountainRescue) { qr.Append("1"); } else { qr.Append("0"); }
                qr.Append(";");

                //nok
                qr.Append(NOKName); qr.Append(";");
                qr.Append(NOKRelation); qr.Append(";"); //remove
                qr.Append(NOKPhone); qr.Append(";");


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
                StringBuilder bin = new StringBuilder();
                if (GSAR) { bin.Append("1"); } else { bin.Append("0"); }
                if (GSTL) { bin.Append("1"); } else { bin.Append("0"); }
                if (SARM) { bin.Append("1"); } else { bin.Append("0"); }
                if (FirstAid) { bin.Append("1"); } else { bin.Append("0"); }
                if (RopeRescue) { bin.Append("1"); } else { bin.Append("0"); }
                if (Tracker) { bin.Append("1"); } else { bin.Append("0"); }
                if (Swiftwater) { bin.Append("1"); } else { bin.Append("0"); }
                if (MountainRescue) { bin.Append("1"); } else { bin.Append("0"); }
                int qualNumber = 0;
                qualNumber = Convert.ToInt32(bin.ToString(), 2);
                qr.Append(qualNumber);
                qr.Append(";");

                //nok
                qr.Append(NOKName); qr.Append(";");
                // qr.Append(NOKRelation); qr.Append(";"); //remove
                if (!string.IsNullOrEmpty(NOKPhone)) { qr.Append(NOKPhone.Replace("-", "").Replace(" ", "")); }
                qr.Append(";");


                return qr.ToString();
            }
        }

        public Bitmap MemberQRCode(char prefix, int size = 250)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                ErrorCorrection = ZXing.QrCode.Internal.ErrorCorrectionLevel.H,
                Width = size,
                Height = size,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var result = new Bitmap(writer.Write(prefix + StringForQRCompressed + prefix));
            return result;
        }

        public TeamMember getMemberFromQR(string qr)
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
                    member.Reference = bits[7];
                    //quals are 7
                    if (bits[8].Length >= 6)
                    {
                        member.GSAR = bits[8].Substring(0, 1).Equals("1");
                        member.GSTL = bits[8].Substring(1, 1).Equals("1");
                        member.SARM = bits[8].Substring(2, 1).Equals("1");
                        member.FirstAid = bits[8].Substring(3, 1).Equals("1");
                        member.RopeRescue = bits[8].Substring(4, 1).Equals("1");
                        member.Tracker = bits[8].Substring(5, 1).Equals("1");
                        if (bits[8].Length > 6) { member.Swiftwater = bits[8].Substring(6, 1).Equals("1"); }
                        if (bits[8].Length > 7) { member.MountainRescue = bits[8].Substring(7, 1).Equals("1"); }
                    }

                    member.NOKName = bits[9];
                    member.NOKRelation = bits[10];
                    member.NOKPhone = bits[11];
                }

                return member;
            }
        }

        public TeamMember getMemberFromSimplifiedQR(string qr)
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

                    //quals are 7
                    if (bits[5].Length >= 1)
                    {
                        int qualifications = 0;
                        if (int.TryParse(bits[5], out qualifications))
                        {
                            string binary = Convert.ToString(qualifications, 2);
                            while (binary.Length < 8)
                            {
                                binary = "0" + binary;
                            }

                            member.GSAR = binary.Substring(0, 1).Equals("1");
                            member.GSTL = binary.Substring(1, 1).Equals("1");
                            member.SARM = binary.Substring(2, 1).Equals("1");
                            member.FirstAid = binary.Substring(3, 1).Equals("1");
                            member.RopeRescue = binary.Substring(4, 1).Equals("1");
                            member.Tracker = binary.Substring(5, 1).Equals("1");
                            member.Swiftwater = binary.Substring(6, 1).Equals("1");
                            member.MountainRescue = binary.Substring(7, 1).Equals("1");

                        }


                    }
                    member.NOKName = bits[6];
                    member.NOKPhone = bits[7];
                }

                return member;
            }
            else { return null; }
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
            RopeRescue = teamMember.RopeRescue;
            Tracker = teamMember.Tracker;
            FirstAid = teamMember.FirstAid;
            GSAR = teamMember.GSAR;
            SpecialSkills = teamMember.SpecialSkills;
            isAssignmentTeamLeader = teamMember.isAssignmentTeamLeader;
            Reference = teamMember.Reference;
            GSTL = teamMember.GSTL;
            SARM = teamMember.SARM;
            Swiftwater = teamMember.Swiftwater;
            MountainRescue = teamMember.MountainRescue;
            Barcode = teamMember.Barcode;
            OrganizationID = teamMember.OrganizationID;
            UserID = teamMember.UserID;
            MemberActive = teamMember.MemberActive;
            LastUpdatedUTC = teamMember.LastUpdatedUTC;
            Email = teamMember.Email;
            CreatedByOrgID = teamMember.CreatedByOrgID;
            Address = teamMember.Address;
            NOKName = teamMember.NOKName;
            NOKRelation = teamMember.NOKRelation;
            NOKPhone = teamMember.NOKPhone;
            D4HStatus = teamMember.D4HStatus;
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
            if (RopeRescue != compareTo.RopeRescue) { Identical = false; }
            if (Tracker != compareTo.Tracker) { Identical = false; }
            if (FirstAid != compareTo.FirstAid) { Identical = false; }
            if (GSAR != compareTo.GSAR) { Identical = false; }
            if (Swiftwater != compareTo.Swiftwater) { Identical = false; }
            if (MountainRescue != compareTo.MountainRescue) { Identical = false; }
            if (SpecialSkills != compareTo.SpecialSkills) { Identical = false; }
            if (isAssignmentTeamLeader != compareTo.isAssignmentTeamLeader) { Identical = false; }
            if (Reference != compareTo.Reference) { Identical = false; }
            if (GSTL != compareTo.GSTL) { Identical = false; }
            if (SARM != compareTo.SARM) { Identical = false; }
            if (Barcode != compareTo.Barcode) { Identical = false; }
            if (OrganizationID != compareTo.OrganizationID) { Identical = false; }
            if (UserID != compareTo.UserID) { Identical = false; }
            if (MemberActive != compareTo.MemberActive) { Identical = false; }
            if (LastUpdatedUTC != compareTo.LastUpdatedUTC) { Identical = false; }
            if (Email != compareTo.Email) { Identical = false; }
            if (CreatedByOrgID != compareTo.CreatedByOrgID) { Identical = false; }
            if (Address != compareTo.Address) { Identical = false; }
            if (NOKName != compareTo.NOKName) { Identical = false; }
            if (NOKRelation != compareTo.NOKRelation) { Identical = false; }
            if (NOKPhone != compareTo.NOKPhone) { Identical = false; }
            if (D4HStatus != compareTo.D4HStatus) { Identical = false; }
            return Identical;
        }

        public bool Equals(TeamMember other)
        {
            // Would still want to check for null etc. first.
            return this.PersonID == other.PersonID;
        }


        public List<D4HQualifications> getD4HQualificationsFromCSV(string filename)
        {
            DateTime today = DateTime.Now;

            List<D4HQualifications> qualifications = new List<D4HQualifications>();
            int nameField = 0;
            int refField = 2;
            int gsarField = 0;
            int sarm1Field = 0;
            int sarm2Field = 0;
            int sarmOldField = 0;
            int tracker1Field = 0;
            int tracker2Field = 0;
            int signCutterField = 0;
            int ropeTech1Field = 0;
            int ropeTech2Field = 0;
            int ropeTLField = 0;
            int swTech1Field = 0;
            int swTech2Field = 0;
            int mrTech1Field = 0;
            int mrTech2Field = 0;
            int gstlField = 0;
            int firstAid1Field = 0;
            int firstAid2Field = 0;
            int firstAid3Field = 0;
            int firstAid4Field = 0;
            int firstAid5Field = 0;
            int firstAid6Field = 0;
            int firstAid7Field = 0;



            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();

                    if (fields[nameField] == "Name")
                    {
                        for (int x = 0; x < fields.Length; x++)
                        {
                            switch (fields[x])
                            {
                                case "Ref":
                                    refField = x;
                                    break;
                                case "Ground Search and Rescue (GSAR) [Search]":
                                    gsarField = x;
                                    break;
                                case "Ground Search Team Leader (GSTL) [Search]":
                                    gstlField = x;
                                    break;
                                case "Search and Rescue Manager (prior to Nov 2014) [Search]":
                                    sarmOldField = x;
                                    break;
                                case "Search and Rescue Manager 1 (post Nov 2014) [Search]":
                                    sarm1Field = x;
                                    break;
                                case "Search and Rescue Manager 2 [Search]":
                                    sarm2Field = x;
                                    break;
                                case "BCTA - 2 - Tracker [Tracking]":
                                    tracker1Field = x;
                                    break;
                                case "BCTA - 3 - Advanced Tracker [Tracking]":
                                    tracker2Field = x;
                                    break;
                                case "OTHER - Sign Cutter [Tracking]":
                                    signCutterField = x;
                                    break;
                                case "Rope Rescue Team Leader (20h annual practice) [Rope Rescue]":
                                    ropeTLField = x;
                                    break;
                                case "Rope Rescue Technician 1 (20h annual practice) [Rope Rescue]":
                                    ropeTech1Field = x;
                                    break;
                                case "Rope Rescue Technician 2 (20h annual practice) [Rope Rescue]":
                                    ropeTech2Field = x;
                                    break;
                                case "Swiftwater Rescue Technician (20h annual practice + 3y re-certification) [Swiftwater]":
                                    swTech1Field = x;
                                    break;
                                case "Swiftwater Rescue Technician - Advanced (20h annual practice + 3y re-certification) [Swiftwater]":
                                    swTech2Field = x;
                                    break;
                                case "Mountain Rescue 1 [Mountain Rescue]":
                                    mrTech1Field = x;
                                    break;
                                case "Mountain Rescue 2 [Mountain Rescue]":
                                    mrTech2Field = x;
                                    break;
                                case "07+ Hour First Aid Training or Equivalent [Medical]":
                                    firstAid1Field = x; break;

                                case "16+ Hour First Aid Training or Equivalent [Medical]":
                                    firstAid2Field = x; break;
                                case "32-50+ Hour First Aid Training or Equivalent [Medical]":
                                    firstAid3Field = x; break;
                                case "70+ Hour First Aid Training or Equivalent [Medical]":
                                    firstAid4Field = x; break;
                                case "Licensed Emergency Medical Assistant (EMR; annual licensing body continuing competency requirements) [Medical]":
                                    firstAid5Field = x; break;
                                case "Licensed Paramedic (annual licensing body continuing competency requirements) [Medical]":
                                    firstAid6Field = x; break;
                                case "Medical Doctor [Medical]":
                                    firstAid7Field = x; break;

                                    //	

                            }
                        }


                    }
                    else
                    {
                        D4HQualifications d4h = new D4HQualifications();
                        d4h.MemberName = fields[nameField];
                        if (refField > 0) { d4h.Ref = fields[refField].Replace("#", ""); }
                        if (gsarField > 0 && YesOrFuture(fields[gsarField])) { d4h.gsar = true; }
                        if (gstlField > 0 && YesOrFuture(fields[gstlField])) { d4h.gstl = true; }
                        //tracking
                        if (tracker1Field > 0 && YesOrFuture(fields[tracker1Field])) { d4h.tracker = true; }
                        if (tracker2Field > 0 && YesOrFuture(fields[tracker2Field])) { d4h.tracker = true; }
                        if (signCutterField > 0 && YesOrFuture(fields[signCutterField])) { d4h.tracker = true; }
                        //sarm
                        if (sarmOldField > 0 && YesOrFuture(fields[sarmOldField])) { d4h.sarm = true; }
                        if (sarm1Field > 0 && YesOrFuture(fields[sarm1Field])) { d4h.sarm = true; }
                        if (sarm2Field > 0 && YesOrFuture(fields[sarm2Field])) { d4h.sarm = true; }

                        //rope rescue
                        if (ropeTech1Field > 0 && YesOrFuture(fields[ropeTech1Field])) { d4h.roperescue = true; }
                        if (ropeTech2Field > 0 && YesOrFuture(fields[ropeTech2Field])) { d4h.roperescue = true; }
                        if (ropeTLField > 0 && YesOrFuture(fields[ropeTLField])) { d4h.roperescue = true; }

                        //swiftwater
                        if (swTech1Field > 0 && YesOrFuture(fields[swTech1Field])) { d4h.swiftwater = true; }
                        if (swTech2Field > 0 && YesOrFuture(fields[swTech2Field])) { d4h.swiftwater = true; }


                        /*
                        if (swTech1Field > 0 && fields[swTech1Field])) { d4h.swiftwater = true; }
                        if (swTech2Field > 0 && fields[swTech2Field])) { d4h.swiftwater = true; }
                        */


                        //Mountain Rescue
                        if (mrTech1Field > 0 && YesOrFuture(fields[mrTech1Field])) { d4h.mountainrescue = true; }
                        if (mrTech2Field > 0 && YesOrFuture(fields[mrTech2Field])) { d4h.mountainrescue = true; }

                        //First Aid
                        if (firstAid1Field > 0 && YesOrFuture(fields[firstAid1Field])) { d4h.FirstAid = true; }
                        if (firstAid2Field > 0 && YesOrFuture(fields[firstAid2Field])) { d4h.FirstAid = true; }
                        if (firstAid3Field > 0 && YesOrFuture(fields[firstAid3Field])) { d4h.FirstAid = true; }
                        if (firstAid4Field > 0 && YesOrFuture(fields[firstAid4Field])) { d4h.FirstAid = true; }
                        if (firstAid5Field > 0 && YesOrFuture(fields[firstAid5Field])) { d4h.FirstAid = true; }
                        if (firstAid6Field > 0 && YesOrFuture(fields[firstAid6Field])) { d4h.FirstAid = true; }
                        if (firstAid7Field > 0 && YesOrFuture(fields[firstAid7Field])) { d4h.FirstAid = true; }


                        qualifications.Add(d4h);
                    }
                }
            }

            return qualifications;
        }

        private bool YesOrFuture(string fieldText)
        {

            if (string.IsNullOrEmpty(fieldText)) { return false; }
            else if (fieldText.Equals("Yes")) { return true; }
            else
            {
                DateTime test = DateTime.MinValue;
                if (DateTime.TryParse(fieldText, out test))
                {
                    if (test > DateTime.Now) { return true; }
                    else { return false; }
                }
                else { return false; }
            }
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
                        member.Reference = fields[RefField];
                        member.Phone = fields[phoneField];
                        member.MemberActive = true;
                        member.Email = fields[emailField];
                        member.Address = fields[addressField];
                        member.NOKName = fields[nokfield];
                        member.NOKRelation = fields[nokrelationfield];
                        member.NOKPhone = fields[nokphoenfield];
                        member.D4HStatus = fields[d4hstatusfield];
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


        /*************************
         * DATABASE stuff
         ***********************/


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

        public Assignment currentAssignment
        {
            set
            {
                _AssignmentNumber = value.AssignmentNumber;
                _AssignmentName = value.AssignmentName;
                _AssignmentID = value.AssignmentID;
                _CurrentAssignmentStatus = value.currentStatusName;
            }
        }

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


    public class D4HQualifications
    {
        private string _MemberName;
        private string _Ref;
        private bool _gsar;
        private bool _sarm;
        private bool _gstl;
        private bool _roperescue;
        private bool _tracker;
        private bool _swiftwater;
        private bool _mountainrescue;
        private bool _firstAid;
        public string MemberName { get => _MemberName; set => _MemberName = value; }
        public string Ref { get => _Ref; set => _Ref = value; }
        public bool gsar { get => _gsar; set => _gsar = value; }
        public bool sarm { get => _sarm; set => _sarm = value; }
        public bool gstl { get => _gstl; set => _gstl = value; }
        public bool roperescue { get => _roperescue; set => _roperescue = value; }
        public bool tracker { get => _tracker; set => _tracker = value; }
        public bool swiftwater { get => _swiftwater; set => _swiftwater = value; }
        public bool mountainrescue { get => _mountainrescue; set => _mountainrescue = value; }
        public bool FirstAid { get => _firstAid; set => _firstAid = value; }
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
