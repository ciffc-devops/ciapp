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
    public class AirOperationsSummary : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _Remarks;
        [ProtoMember(3)] private DateTime _Sunrise;
        [ProtoMember(4)] private DateTime _Sunset;
        [ProtoMember(5)] private string _MedivacAircraftText;
        [ProtoMember(6)] private NOTAM _notam;

        //[ProtoMember(7)] private List<ICSRole> _personnel;
        //[ProtoMember(8)] private List<CommsPlanItem> _Frequencies;
        [ProtoMember(9)] private List<Aircraft> _aircrafts;
        [ProtoMember(10)] private string _PreparedByName;
        [ProtoMember(11)] private string _PreparedByPosition;
        [ProtoMember(12)] private Guid _PreparedByPositionID;
        [ProtoMember(13)] private bool _Active;
        [ProtoMember(14)] private int _OpPeriod;
        [ProtoMember(15)] private DateTime _LastUpatedUTC;


        public AirOperationsSummary()
        {
            _ID = Guid.NewGuid();
            _notam = new NOTAM();
            // _personnel = new List<ICSRole>();
            // _Frequencies = new List<CommsPlanItem>();
            _aircrafts = new List<Aircraft>();
            Active = true;
        }

        public Guid ID { get => _ID; set => _ID = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public DateTime Sunrise { get => _Sunrise; set => _Sunrise = value; }
        public DateTime Sunset { get => _Sunset; set => _Sunset = value; }
        public string MedivacAircraftText { get => _MedivacAircraftText; set => _MedivacAircraftText = value; }
        public NOTAM notam { get => _notam; set => _notam = value; }
        //public List<ICSRole> personnel { get => _personnel; set => _personnel = value; }
        //public List<CommsPlanItem> Frequencies { get => _Frequencies; set => _Frequencies = value; }
        public List<Aircraft> aircrafts { get => _aircrafts; set => _aircrafts = value; }
        public List<Aircraft> activeAircraft { get => _aircrafts.Where(o => o.Active).OrderBy(o => o.Registration).ToList(); }
        public List<Aircraft> medivacAircraftList { get => activeAircraft.Where(o => o.IsMedivac).OrderBy(o => o.Registration).ToList(); }
        public string MedivacTextBlock
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (Aircraft a in medivacAircraftList)
                {
                    sb.Append(a.Registration); sb.Append(" | "); sb.Append(a.MakeModel);
                    if (!string.IsNullOrEmpty(a.Pilot)) { sb.Append(" | "); sb.Append(a.Pilot); }
                    sb.Append(Environment.NewLine);
                }
                sb.Append(Environment.NewLine);
                sb.Append(MedivacAircraftText);
                return sb.ToString();
            }
        }
        public string PreparedByName { get => _PreparedByName; set => _PreparedByName = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public Guid PreparedByPositionID { get => _PreparedByPositionID; set => _PreparedByPositionID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }

        public AirOperationsSummary Clone()
        {
            AirOperationsSummary cloneTo = this.MemberwiseClone() as AirOperationsSummary;
            cloneTo.aircrafts = new List<Aircraft>();
            foreach (Aircraft a in aircrafts) { cloneTo.aircrafts.Add(a.Clone()); }
            cloneTo.notam = this.notam.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public bool HasContent
        {
            get
            {
                if (activeAircraft.Any()) { return true; }
                if(!string.IsNullOrEmpty(MedivacAircraftText)) { return true; }
                if (!string.IsNullOrEmpty(Remarks)) { return true; }
                if (notam.AnyContent) { return true; }
                return false;
            }
        }

    }


    [Serializable]
    [ProtoContract]
    public class Aircraft : IncidentTool, ICloneable
    {
        [ProtoMember(2)] private string _Registration;
        [ProtoMember(3)] private string _MakeModel;
        [ProtoMember(4)] private string _Base;
        [ProtoMember(5)] private DateTime _StartTime;
        [ProtoMember(6)] private DateTime _EndTime;
        [ProtoMember(7)] private string _Remarks;
        [ProtoMember(8)] private string _Pilot;
        [ProtoMember(9)] private string _ContactNumber;
        [ProtoMember(13)] private bool _IsMedivac;

        public Aircraft() { ID = Guid.NewGuid(); Active = true; }

        public string Registration { get => _Registration; set => _Registration = value; }
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

        public Aircraft Clone()
        {
            return this.MemberwiseClone() as Aircraft;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        
    }

    [Serializable]
    [ProtoContract]
    public class NOTAM : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private double _Latitude;
        [ProtoMember(3)] private double _Longitude;
        [ProtoMember(4)] private decimal _RadiusNM;
        [ProtoMember(5)] private decimal _AltitudeASL;
        [ProtoMember(6)] private string _CenterPoint;


        public NOTAM() { _ID = Guid.NewGuid(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public double Latitude { get => _Latitude; set => _Latitude = value; }
        public double Longitude { get => _Longitude; set => _Longitude = value; }
        public decimal RadiusNM { get => _RadiusNM; set => _RadiusNM = value; }
        public decimal AltitudeASL { get => _AltitudeASL; set => _AltitudeASL = value; }
        public string CenterPoint { get => _CenterPoint; set => _CenterPoint = value; }
        public bool AnyContent
        {
            get
            {
                if (Latitude != 0 || Longitude != 0) { return true; }
                if (RadiusNM != 0) { return true; }
                if (AltitudeASL != 0) { return true; }
                if (!string.IsNullOrEmpty(CenterPoint)) { return true; }
                return false;
            }
        }

        public NOTAM Clone()
        {
            return this.MemberwiseClone() as NOTAM;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
