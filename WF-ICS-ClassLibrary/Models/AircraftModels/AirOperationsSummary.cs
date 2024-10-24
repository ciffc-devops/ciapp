﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class AirOperationsSummary : ICSFormData, ICloneable
    {
        [ProtoMember(2)] private string _Remarks;
        [ProtoMember(3)] private DateTime _Sunrise;
        [ProtoMember(4)] private DateTime _Sunset;
        [ProtoMember(5)] private string _MedivacAircraftText;
        [ProtoMember(6)] private NOTAM _notam;

        //[ProtoMember(7)] private List<ICSRole> _personnel;
        //[ProtoMember(8)] private List<CommsPlanItem> _Frequencies;
        [ProtoMember(9)] private List<Aircraft> _aircrafts;


        public AirOperationsSummary()
        {
            ID = Guid.NewGuid();
            _notam = new NOTAM();
            // _personnel = new List<ICSRole>();
            // _Frequencies = new List<CommsPlanItem>();
            _aircrafts = new List<Aircraft>();
            Active = true;
        }

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
}