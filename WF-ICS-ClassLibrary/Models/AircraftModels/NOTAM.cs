using ProtoBuf;
using System;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
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
}
