using NetworkCommsDotNet;
using ProtoBuf;
using System;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{


    [Serializable]
    [ProtoContract]
    public class Aircraft : IncidentResource, ICloneable
    {
        [ProtoMember(2)] private string _CompanyName;
        [ProtoMember(3)] private string _MakeModel;
        [ProtoMember(4)] private string _Base;
        [ProtoMember(5)] private DateTime _StartTime;
        [ProtoMember(6)] private DateTime _EndTime;
        [ProtoMember(7)] private string _Remarks;
        [ProtoMember(8)] private string _Pilot;
        [ProtoMember(9)] private string _ContactNumber;
        [ProtoMember(13)] private bool _IsMedivac;
        [ProtoMember(14)] private bool _IsHeli;
        [ProtoMember(15)] private string _PointOfHire;
        [ProtoMember(21)] private decimal _FuelBurnRate;

        public Aircraft() { ID = Guid.NewGuid(); Active = true; IsHeli = true; ResourceType = "Aircraft"; }
        public string CompanyName { get => _CompanyName; set => _CompanyName = value; }
        public string Registration { get => ResourceName; set => ResourceName = value; }
        public string MakeModel { get => _MakeModel; set => _MakeModel = value; }
        public string RegAndMakeModel
        {
            get
            {
                if (!string.IsNullOrEmpty(MakeModel)) return Registration + " " + MakeModel;
                else { return Registration; }
            }
        }
        public string Base { get => _Base; set => _Base = value; }
        public DateTime StartTime { get => _StartTime; set => _StartTime = value; }
        public DateTime EndTime { get => _EndTime; set => _EndTime = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public string Pilot { get => _Pilot; set => _Pilot = value; }
        public string ContactNumber { get => _ContactNumber; set => _ContactNumber = value; }
        public bool IsMedivac { get => _IsMedivac; set => _IsMedivac = value; }
        public bool IsHeli { get => _IsHeli; set => _IsHeli = value; }
        public string AircraftTypeText
        {
            get
            {
                if (IsHeli) { return "Helicopter"; }
                return "Fixed-Wing";
            }
        }
        public string PointOfHire { get => _PointOfHire; set => _PointOfHire = value; }
        public decimal FuelBurnRate { get => _FuelBurnRate; set => _FuelBurnRate = value; }

        public Aircraft Clone()
        {
            return this.MemberwiseClone() as Aircraft;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }
}
