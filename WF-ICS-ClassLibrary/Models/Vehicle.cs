﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class Vehicle : IncidentResource,  ICloneable
    {
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(4)] private string _OrderRequestNo;
        
        [ProtoMember(6)] private string _Classification;
        [ProtoMember(7)] private string _Make;
        [ProtoMember(8)] private string _CategoryKindCapacity;
        [ProtoMember(9)] private string _Features;
        [ProtoMember(10)] private string _AgencyOrOwner;
        [ProtoMember(11)] private string _OperatorName;
        [ProtoMember(12)] private string _LicenseOrID;
        [ProtoMember(13)] private string _IncidentAssignment;
        [ProtoMember(14)] private DateTime _StartTime;
        [ProtoMember(15)] private DateTime _MustBeOutTime;
        [ProtoMember(16)] private string _Notes;
        [ProtoMember(17)] private Guid _OperatorID;
        [ProtoMember(18)] private string _ASE;
        [ProtoMember(19)] private bool _IsEquipment;
        [ProtoMember(20)] private string _UnitNumber;
        [ProtoMember(21)] private string _SerialNumber;


        public Vehicle()
        {

            ID = Guid.NewGuid();
            Active = true;
            NumberOfVehicles = 1;
            NumberOfPeople = 0;
        }

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public string OrderRequestNo { get => _OrderRequestNo; set => _OrderRequestNo = value; }
        public string IncidentIDNo { get => ResourceIdentifier; set { ResourceIdentifier = value; SetResourceName(); } }
        public string Classification { get => _Classification; set => _Classification = value; }
        public string Make { get => _Make; set { _Make = value; SetResourceName(); } }
        public string CategoryKindCapacity { get => _CategoryKindCapacity; set => _CategoryKindCapacity = value; }
        public string Features { get => _Features; set => _Features = value; }
        public string AgencyOrOwner { get => _AgencyOrOwner; set { _AgencyOrOwner = value; SetResourceName(); } }
        public string OperatorName { get => _OperatorName; set => _OperatorName = value; }
        public Guid OperatorID { get => _OperatorID; set => _OperatorID = value; }
        public string LicenseOrID { get => _LicenseOrID; set => _LicenseOrID = value; }
        public string IncidentAssignment { get => _IncidentAssignment; set => _IncidentAssignment = value; }
        public DateTime StartTime { get => _StartTime; set => _StartTime = value; }
        public DateTime MustBeOutTime { get => _MustBeOutTime; set => _MustBeOutTime = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        public string ASE { get => _ASE; set => _ASE = value; }
        public bool IsEquipment { get => _IsEquipment; set { _IsEquipment = value; if (IsEquipment) { this.ResourceType = "Equipment"; } else { this.ResourceType = "Vehicle"; } } }
        public string UnitNumber { get => _UnitNumber; set => _UnitNumber = value; }
        public string SerialNumber { get => _SerialNumber; set => _SerialNumber = value; }

        private void SetResourceName() { ResourceName = IDWithMakeOwner; }
        public string IDWithMakeOwner
        {
            get
            {

                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(IncidentIDNo)) { sb.Append(IncidentIDNo); }
                if (!string.IsNullOrEmpty(Make))
                {
                    if (sb.Length > 0) { sb.Append(" ("); sb.Append(Make); sb.Append(")"); }
                    else { sb.Append(Make); }
                }
                if (!string.IsNullOrEmpty(AgencyOrOwner))
                {
                    if (sb.Length > 0) { sb.Append(" ("); sb.Append(AgencyOrOwner); sb.Append(")"); }
                    else { sb.Append(AgencyOrOwner); }
                }

                if (!string.IsNullOrEmpty(UnitNumber))
                {
                    if (sb.Length > 0) { sb.Append(" ("); sb.Append(UnitNumber); sb.Append(")"); }
                    else { sb.Append(UnitNumber); }
                }
                if (!string.IsNullOrEmpty(SerialNumber))
                {
                    if (sb.Length > 0) { sb.Append(" ("); sb.Append(SerialNumber); sb.Append(")"); }
                    else { sb.Append(SerialNumber); }
                }


                return sb.ToString();
            }
        }

        public new Vehicle Clone()
        {
            return this.MemberwiseClone() as Vehicle;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
