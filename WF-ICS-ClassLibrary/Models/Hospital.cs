using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class Hospital : ICloneable
    {
        [ProtoMember(1)] private Guid _HospitalID;
        [ProtoMember(2)] private string _HospitalName;
        [ProtoMember(3)] private string _Location;
        [ProtoMember(4)] private decimal _TravelTimeAir;
        [ProtoMember(5)] private decimal _TravelTimeGround;
        [ProtoMember(6)] private string _Phone; //Contact may be phone or frequency
        [ProtoMember(7)] private bool _TraumaUnit; //not used
        [ProtoMember(8)] private bool _BurnUnit;
        [ProtoMember(9)] private bool _Hypothermia; //Not used
        [ProtoMember(10)] private bool _Helipad;
        [ProtoMember(11)] private bool _IsUniversal;
        [ProtoMember(12)] private DateTime _LastUpatedUTC;
        [ProtoMember(13)] private double _Latitude;
        [ProtoMember(14)] private double _Longitude;
        [ProtoMember(15)] private bool _active;
        [ProtoMember(16)] private Guid _OrganizationID;
        [ProtoMember(17)] private int _OpPeriod;

        public Guid HospitalID { get => _HospitalID; set => _HospitalID = value; }
        public string name { get => _HospitalName; set => _HospitalName = value; }
        public string location { get => _Location; set => _Location = value; }
        public string nameWithLocation { get { return name + " " + location; } }
        public decimal travelTimeAir { get => _TravelTimeAir; set => _TravelTimeAir = value; }
        public decimal travelTimeGround { get => _TravelTimeGround; set => _TravelTimeGround = value; }
        public string phone { get => _Phone; set => _Phone = value; }
        public bool traumaUnit { get => _TraumaUnit; set => _TraumaUnit = value; }
        public bool burnUnit { get => _BurnUnit; set => _BurnUnit = value; }
        public bool hypothermia { get => _Hypothermia; set => _Hypothermia = value; }
        public bool helipad { get => _Helipad; set => _Helipad = value; }
        public bool isUniversal { get => _IsUniversal; set => _IsUniversal = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }
        public double Latitude { get => _Latitude; set => _Latitude = value; }
        public double Longitude { get => _Longitude; set => _Longitude = value; }
        public bool Active { get { return _active; } set { _active = value; } } //hospitals used once but not "saved for later" will be marked inactive, as will "deleted" hospitals
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; } 


        public Hospital() { HospitalID = System.Guid.NewGuid(); Active = true; }
        public Hospital(string hospitalName) { name = hospitalName; HospitalID = Guid.Empty; Active = true; }


        public Hospital Clone()
        {
            return this.MemberwiseClone() as Hospital;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }
}
