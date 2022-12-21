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


        public Guid AmbulanceID { get => _AmbulanceID; set => _AmbulanceID = value; }
        public string Organization { get => _Organization; set => _Organization = value; }
        public string Contact { get => _Contact; set => _Contact = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string RadioFrequency { get => _RadioFrequency; set => _RadioFrequency = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public bool IsUniversal { get => _IsUniversal; set => _IsUniversal = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

        public AmbulanceService() { AmbulanceID = System.Guid.NewGuid(); }
        public AmbulanceService(string organization) { Organization = organization; AmbulanceID = Guid.Empty; }

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
