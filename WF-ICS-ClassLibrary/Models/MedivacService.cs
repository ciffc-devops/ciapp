using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class AmbulanceService : ICloneable
    {


        [ProtoMember(1)] private Guid _AmbulanceID;
        [ProtoMember(2)] private string _Organization;
        [ProtoMember(3)] private string _Contact;
        [ProtoMember(4)] private string _Phone;
        [ProtoMember(5)] private string _RadioFrequency;
        [ProtoMember(6)] private Guid _OrganizationID;
        [ProtoMember(7)] private bool _Active;
        [ProtoMember(8)] private bool _IsUniversal;
        [ProtoMember(9)] private DateTime _LastUpdatedUTC;
        [ProtoMember(10)] private bool _IsALS;
        [ProtoMember(11)] private bool _IsBLS;
        [ProtoMember(12)] private string _Location;
        [ProtoMember(13)] private double _Latitude;
        [ProtoMember(14)] private double _Longitude;
        [ProtoMember(15)] private int _OpPeriod;

        public Guid AmbulanceID { get => _AmbulanceID; set => _AmbulanceID = value; }
        public string Organization { get => _Organization; set => _Organization = value; }
        public string Contact { get => _Contact; set => _Contact = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string RadioFrequency { get => _RadioFrequency; set => _RadioFrequency = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public bool IsUniversal { get => _IsUniversal; set => _IsUniversal = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool IsALS { get => _IsALS; set => _IsALS = value; }
        public bool IsBLS { get => _IsBLS; set => _IsBLS = value; }
        public string Location { get => _Location; set => _Location = value; }
        public double Latitude { get => _Latitude; set => _Latitude = value; }  
        public double Longitude { get => _Longitude;set => _Longitude = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }

        public string ParamedicsAvailable
        {
            get
            {
                if (IsALS) { return "ALS"; }
                else { return "BLS"; }
            }
        }

        public AmbulanceService() { AmbulanceID = System.Guid.NewGuid(); Active = true; }
        public AmbulanceService(string organization) { Organization = organization; AmbulanceID = Guid.Empty; Active = true; }

        public AmbulanceService Clone()
        {
            return this.MemberwiseClone() as AmbulanceService;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }
}
