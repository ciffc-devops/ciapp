using NetworkCommsDotNet;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Utilities;

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
        [ProtoMember(15)] private DateTime _LastUpdatedUTC;


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
        //public List<Aircraft> aircrafts { get => _aircrafts; set => _aircrafts = value; }
        //public List<Aircraft> activeAircraft { get => _aircrafts.Where(o => o.Active).OrderBy(o => o.Registration).ToList(); }
        //public List<Aircraft> medivacAircraftList { get => activeAircraft.Where(o => o.IsMedivac).OrderBy(o => o.Registration).ToList(); }
        public string MedivacTextBlock(List<Aircraft> medivacAircraftList)
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
        public string PreparedByName { get => _PreparedByName; set => _PreparedByName = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public Guid PreparedByPositionID { get => _PreparedByPositionID; set => _PreparedByPositionID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

        public AirOperationsSummary Clone()
        {
            AirOperationsSummary cloneTo = this.MemberwiseClone() as AirOperationsSummary;
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
                if (!string.IsNullOrEmpty(MedivacAircraftText)) { return true; }
                if (!string.IsNullOrEmpty(Remarks)) { return true; }
                if (notam.AnyContent) { return true; }
                return false;
            }
        }

    }


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

    [Serializable]
    [ProtoContract]
    public class NOTAM : ICloneable
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private bool _UseRadius;
        //[ProtoMember(2)] private double _Latitude;
        //[ProtoMember(3)] private double _Longitude;
        [ProtoMember(4)] private decimal _RadiusNM;
        [ProtoMember(5)] private decimal _AltitudeASL;
        [ProtoMember(6)] private string _CenterPoint;
        [ProtoMember(7)] private Coordinate _RadiusCentre;
        [ProtoMember(8)] private Coordinate _PolygonNE;
        [ProtoMember(9)] private Coordinate _PolygonNW;
        [ProtoMember(10)] private Coordinate _PolygonSE;
        [ProtoMember(11)] private Coordinate _PolygonSW;


        public NOTAM() { _ID = Guid.NewGuid(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public bool UseRadius { get => _UseRadius; set => _UseRadius = value; }
        // public double Latitude { get => _Latitude; set => _Latitude = value; }
        //public double Longitude { get => _Longitude; set => _Longitude = value; }
        public decimal RadiusNM { get => _RadiusNM; set => _RadiusNM = value; }
        public decimal AltitudeASL { get => _AltitudeASL; set => _AltitudeASL = value; }
        public string CenterPoint { get => _CenterPoint; set => _CenterPoint = value; }

        public Coordinate RadiusCentre { get => _RadiusCentre; set => _RadiusCentre = value; }
        public Coordinate PolygonNE { get => _PolygonNE; set => _PolygonNE = value; }
        public Coordinate PolygonNW { get => _PolygonNW; set => _PolygonNW = value; }
        public Coordinate PolygonSE { get => _PolygonSE; set => _PolygonSE = value; }
        public Coordinate PolygonSW { get => _PolygonSW; set => _PolygonSW = value; }


        public bool AnyContent
        {
            get
            {
                // if (Latitude != 0 || Longitude != 0) { return true; }
                if (AnyCoordinates) { return true; }
                if (RadiusNM != 0) { return true; }
                if (AltitudeASL != 0) { return true; }
                if (!string.IsNullOrEmpty(CenterPoint)) { return true; }
                return false;
            }
        }

        public bool AnyCoordinates
        {
            get
            {
                if (RadiusCentre != null) { return true; }
                if (PolygonNE != null) { return true; }
                if (PolygonNW != null) { return true; }
                if (PolygonSE != null) { return true; }
                if (PolygonSW != null) { return true; }
                return false;
            }

        }

        public NOTAM Clone()
        {
            NOTAM cloneTo = this.MemberwiseClone() as NOTAM;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


    public static class AircraftTools
    {
        public static List<string> GetFixedWingTypes(bool includeBlank = false)
        {
            List<string> types = new List<string>();
            types.Add("C177B");
            types.Add("C206");
            types.Add("C208");
            types.Add("BE 1900D");
            types.Add("C 210 T");
            types.Add("C185");
            types.Add("C215");
            types.Add("C215T");
            types.Add("C415T");
            types.Add("C210");
            types.Add("BAE31");
            types.Add("BE100");
            types.Add("BE99");
            types.Add("BN2");
            types.Add("C185");
            types.Add("C207");
            types.Add("DHC2");
            types.Add("PA31");
            types.Add("PA31-300");
            types.Add("B26");
            types.Add("C310");
            types.Add("C130");
            types.Add("C172");
            types.Add("C182");
            types.Add("C180");
            types.Add("C205");
            types.Add("C208");
            types.Add("C207");
            types.Add("C560");
            types.Add("C501");
            types.Add("C414");
            types.Add("C177");
            types.Add("C 210 T");
            types.Add("C500");
            types.Add("CL-215");
            types.Add("L-188");
            types.Add("TC690A");
            types.Add("TS600");
            types.Add("BE20");
            types.Add("BE99");
            types.Add("C185");
            types.Add("C208B");
            types.Add("DCH8-300");
            types.Add("DC8");
            types.Add("DHC3T");
            types.Add("DCHC6");
            types.Add("DHC7");
            types.Add("BE 1900D");
            types.Add("BE100");
            types.Add("BE35");
            types.Add("C441");
            types.Add("DC3");
            types.Add("DC10");
            types.Add("DC4");
            types.Add("TC690B");
            types.Add("340");
            types.Add("A320");
            types.Add("737");
            types.Add("AT401");
            types.Add("AT402");
            types.Add("228-202");
            types.Add("BE20");
            types.Add("AT502B");
            types.Add("AT502A");
            types.Add("AT802");
            types.Add("CL-215T");
            types.Add("TC690A");
            types.Add("DHC5");
            types.Add("C550");
            types.Add("CV58T");
            types.Add("L100");
            types.Add("TC695A");
            types.Add("TC695B");
            types.Add("TC600");
            types.Add("PA35");
            types.Add("P68");
            types.Add("PA18");
            types.Add("PA28");
            types.Add("PA30");
            types.Add("PA34");
            types.Add("PA31");
            types.Add("ATR42");
            types.Add("ATR72");
            types.Add("ATR72CARGO");
            types.Add("DC3T");
            types.Add("SRS60");
            types.Add("S2R");
            types.Add("Q400MR");
            types.Add("RJ100");
            types.Add("RJ85AT");
            types.Add("E-175");
            types.Add("F-CAT");
            types.Add("HS748");
            types.Add("LR55");
            types.Add("PA46");
            types.Add("PA60");
            types.Add("PBY-5A");
            types.Add("PC-12");
            types.Add("BN-2A");
            types.Add("JRM 3");
            types.Add("CV44");
            types.Add("CV58T");

            types = types.OrderBy(o => o).ToList();
            types.Insert(0, string.Empty);

            return types;
        }


        public static List<string> GetHelicopterTypes(bool includeBlank)
        {
            return GetHelicopterTypes(null, includeBlank);
        }

        public static List<string> GetHelicopterTypes(string size = null, bool includeBlank = false)
        {
            List<string> types = new List<string>();
            if (size == null || size.Equals("Light"))
            {

                types.Add("Bell 206B (I-III)");
                types.Add("Bell 206L (C20B)");
                types.Add("Bell 206L (C20R)");
                types.Add("Bell 206L1 (C28)");
                types.Add("Bell 206L1 (C30)");
                types.Add("Bell 206 L3");
                types.Add("EC 120 Colibri");
                types.Add("Hughes 500 D");
                types.Add("MD 520 N");
                types.Add("Robinson R-44 II (RH44)");
                types.Add("Robinson R-66");
                types.Add("SA 341 Gazelle");
            }
            if (size == null || size.Equals("Intermediate"))
            {
                types.Add("A119 Koala");
                types.Add("AS350B");
                types.Add("AS350BA");
                types.Add("AS350 B1");
                types.Add("AS350 B2");
                types.Add("AS350B3");
                types.Add("AS350B3DH");
                types.Add("AS350D");
                types.Add("AS350SD2");
                types.Add("AS350 FX2");
                types.Add("AS355Twin Star");
                types.Add("AS355N");
                types.Add("AS355NP");
                types.Add("Bell 206 L4");
                types.Add("Bell 222");
                types.Add("Bell 407");
                types.Add("Bell 427");
                types.Add("Bell 429");
                types.Add("EC130 B4");
                types.Add("SA315B Lama");
            }
            if (size == null || size.Equals("Medium"))
            {
                types.Add("Bell 204C");
                types.Add("Bell204C (BLR)");
                types.Add("Bell 205A1-17++");
                types.Add("Bell 205B");
                types.Add("Bell 205B (BLR)");
                types.Add("Bell 212HP (BLR)");
                types.Add("Bell 212S");
                types.Add("Bell 412C");
                types.Add("Bell 412C (BLR)");
                types.Add("Bell 412SP");
                types.Add("Bell 412EP");
                types.Add("BK117B");
                types.Add("BK117C");
                types.Add("BK117");
                types.Add("EC135");
                types.Add("EC 135 P2+/T2+, DP, IFR, NVIS");
                types.Add("MD 900");
                types.Add("MD 902");
            }
            if (size == null || size.Equals("Heavy"))
            {
                types.Add("Bell 214B");
                types.Add("Bell 214ST");
                types.Add("Kaman KMax");
                types.Add("Vertol 107");
                types.Add("Sikorsky S-61");
                types.Add("Kamov Ka-32");
                types.Add("Sikorsky S-64E");
            }



            types = types.OrderBy(o => o).ToList();
            types.Insert(0, string.Empty);
            return types;
        }
    }
}
