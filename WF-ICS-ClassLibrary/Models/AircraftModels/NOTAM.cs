using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class NOTAM : SyncableItem, ICloneable
    {
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
        [ProtoMember(12)] private List<Coordinate> _PolygonCoordinates;

        public NOTAM() { ID = Guid.NewGuid(); PolygonCoordinates = new List<Coordinate>();  }

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
        public List<Coordinate> PolygonCoordinates { get => _PolygonCoordinates; set => _PolygonCoordinates = value; }

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
                return PolygonCoordinates.Any();
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
