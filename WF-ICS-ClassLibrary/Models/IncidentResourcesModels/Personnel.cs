using Microsoft.VisualBasic.FileIO;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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
        [ProtoMember(18)] private string _AccommodationsPreference;
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
        public string AccommodationPreference { get => _AccommodationsPreference; set => _AccommodationsPreference = value; }
        public int PNum { get => UniqueIDNum; set => UniqueIDNum = value; }
        public string InitialRoleName { get => _InitialRoleName; set => _InitialRoleName = value; }
        public string InitialRoleAcronym { get => _InitialRoleAcronym; set => _InitialRoleAcronym = value; }
        public string NameWithInitialRoleAcronym
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Name);
                if (!string.IsNullOrEmpty(InitialRoleAcronym)) { sb.Append(" ("); sb.Append(InitialRoleAcronym); sb.Append(")"); }
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

}
