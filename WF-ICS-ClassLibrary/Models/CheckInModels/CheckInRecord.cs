using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [ProtoMember(15)] private string _InitialRoleName;
        [ProtoMember(16)] private string _InitialRoleAcronym;

        //These are used for demob planning
        [ProtoMember(17)] private bool _ReplacementRequired;
        [ProtoMember(18)] private DateTime _DateReplacementRequired;
        [ProtoMember(19)] private Guid _ReplacementRecordID;
        [ProtoMember(20)] private string _ReplacementComment;

        [ProtoMember(21)] private DateTime _FirstDayOnIncident;


        public CheckInRecord() { SignInRecordID = Guid.NewGuid(); InfoFields = new List<CheckInInfoField>(); CheckOutDate = DateTime.MaxValue; Active = true; ReplacementRequired = true; }




        public DateTime LastDayOfRest { get => _LastDayOfRest; set => _LastDayOfRest = value; }
        public DateTime FirstDayOnIncident { get => _FirstDayOnIncident; set => _FirstDayOnIncident = value; }
        public DateTime CheckInDate { get => _CheckInDate; set => _CheckInDate = value; }
        public DateTime CheckOutDate { get => _CheckOutDate; set => _CheckOutDate = value; }
        public DateTime LastDayOnIncident { get => _LastDayOnIncident; set => _LastDayOnIncident = value; }

        public Guid SignInRecordID { get => _SignInRecordID; set => _SignInRecordID = value; }
        public Guid ParentRecordID { get => _ParentRecordID; set => _ParentRecordID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
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
        public bool IsAircraft { get { return ResourceType.EqualsWithNull("Aircraft"); } }
        public bool HasCheckOutTime { get => CheckOutDate < DateTime.MaxValue; }
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



        public bool ReplacementRequired { get => _ReplacementRequired; set => _ReplacementRequired = value; }
        public DateTime DateReplacementRequired { get => _DateReplacementRequired; set => _DateReplacementRequired = value; }
        public Guid ReplacementRecordID { get => _ReplacementRecordID; set => _ReplacementRecordID = value; }
        public string ReplacementComment { get => _ReplacementComment; set => _ReplacementComment = value; }




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


}
