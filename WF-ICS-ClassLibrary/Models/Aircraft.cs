using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class AirOperationsSummary
    {
        private Guid _ID;
        private string _Remarks;
        private DateTime _Sunrise;
        private DateTime _Sunset;
        private string _MedivacAircraft;
        private NOTAM _notam;
        private List<ICSRole> _personnel;
        private List<CommsPlanItem> _Frequencies;
        private List<Aircraft> _aircrafts;
        private string _PreparedByName;
        private string _PreparedByPosition;
        private Guid _PreparedByPositionID;

        public AirOperationsSummary()
        {
            _ID = Guid.NewGuid();
            _notam = new NOTAM();
            _personnel = new List<ICSRole>();
            _Frequencies = new List<CommsPlanItem>();
            _aircrafts = new List<Aircraft>();
        }

        public Guid ID { get => _ID; set => _ID = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public DateTime Sunrise { get => _Sunrise; set => _Sunrise = value; }
        public DateTime Sunset { get => _Sunset; set => _Sunset = value; }
        public string MedivacAircraft { get => _MedivacAircraft; set => _MedivacAircraft = value; }
        public NOTAM notam { get => _notam; set => _notam = value; }
        public List<ICSRole> personnel { get => _personnel; set => _personnel = value; }
        public List<CommsPlanItem> Frequencies { get => _Frequencies; set => _Frequencies = value; }
        public List<Aircraft> aircrafts { get => _aircrafts; set => _aircrafts = value; }
        public string PreparedByName { get => _PreparedByName; set => _PreparedByName = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public Guid PreparedByPositionID { get => _PreparedByPositionID; set => _PreparedByPositionID = value; }
    }


    [Serializable]
    [ProtoContract]
    public class Aircraft
    {
        private Guid _ID;
        private string _Registration;
        private string _MakeModel;
        private string _Base;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private string _Remarks;
        private string _Pilot;
        private string _ContactNumber;

        public Aircraft() { ID = Guid.NewGuid(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public string Registration { get => _Registration; set => _Registration = value; }
        public string MakeModel { get => _MakeModel; set => _MakeModel = value; }
        public string Base { get => _Base; set => _Base = value; }
        public DateTime StartTime { get => _StartTime; set => _StartTime = value; }
        public DateTime EndTime { get => _EndTime; set => _EndTime = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public string Pilot { get => _Pilot; set => _Pilot = value; }
        public string ContactNumber { get => _ContactNumber; set => _ContactNumber = value; }

    }

    [Serializable]
    [ProtoContract]
    public class NOTAM
    {
        private Guid _ID;
        private double _Latitude;
        private double _Longitude;
        private double _RadiusNM;
        private double _AltitudeASL;
        private string _CenterPoint;

        public NOTAM() { _ID = Guid.NewGuid(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public double Latitude { get => _Latitude; set => _Latitude= value; }
        public double Longitude { get => _Longitude; set => _Longitude= value; }
        public double RadiusNM { get => _RadiusNM; set => _RadiusNM= value; }
        public double AltitudeASL { get => _AltitudeASL; set => _AltitudeASL= value; }  
        public string CenterPoint { get => _CenterPoint; set => _CenterPoint = value; }

    }
}
