using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class MedicalAidStation
    {
        [ProtoMember(1)] private Guid _AidStationID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private string _Location;
        [ProtoMember(4)] private string _ContactNumber;
        [ProtoMember(5)] private bool _ParamedicsAvailable;
        [ProtoMember(6)] private bool _OFA1;
        [ProtoMember(7)] private bool _OFA2;
        [ProtoMember(8)] private bool _OFA3;
        [ProtoMember(9)] private bool _ALS;
        [ProtoMember(10)] private bool _FirstResponder;


        public MedicalAidStation()
        {
            _AidStationID = Guid.NewGuid();

        }

        public Guid AidStationID { get => _AidStationID; set => _AidStationID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Location { get => _Location; set => _Location = value; }
        public string ContactNumber { get => _ContactNumber; set => _ContactNumber = value; }
        public bool ParamedicsAvailable { get => _ParamedicsAvailable; set => _ParamedicsAvailable = value; }
        public bool OFA1 { get => _OFA1; set => _OFA1 = value; }
        public bool OFA2 { get => _OFA2; set => _OFA2 = value; }
        public bool OFA3 { get => _OFA3; set => _OFA3 = value; }
        public bool ALS { get => _ALS; set => _ALS = value; }
        public bool FirstResponder { get => _FirstResponder; set => _FirstResponder = value; }

    }
}
