﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class OperationalPeriod : ICloneable
    {
        [ProtoMember(1)] private int _PeriodNumber;
        [ProtoMember(2)] private DateTime _PeriodStart;
        [ProtoMember(3)] private DateTime _PeriodEnd;
        [ProtoMember(4)] private Guid _TaskID;
        [ProtoMember(5)] private Guid _OperationalPeriodID;
        [ProtoMember(6)] private DateTime _LastUpdatedUTC;
        [ProtoMember(7)] private string _titleImageBytes;
        [ProtoMember(8)] private string _CriticalMessage;

        private static DateTime minDate = Convert.ToDateTime("1753-01-01");




        public int PeriodNumber { get => _PeriodNumber; set => _PeriodNumber = value; }
        public DateTime PeriodStart
        {
            get
            {
                if (_PeriodStart > minDate) { return _PeriodStart; }
                else { return minDate; };
            }
            set => _PeriodStart = value;
        }
        public DateTime PeriodEnd
        {
            get
            {
                if (_PeriodEnd > minDate) { return _PeriodEnd; }
                else { return minDate; }
            }

            set => _PeriodEnd = value;
        }
        public DateTime PeriodMid
        {
            get
            {
                TimeSpan ts = PeriodEnd - PeriodStart;
                return PeriodStart.AddMinutes(ts.TotalMinutes / 2);
            }
        }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public Guid OperationalPeriodID { get => _OperationalPeriodID; set => _OperationalPeriodID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string TitleImageBytes { get => _titleImageBytes; set => _titleImageBytes = value; }
        public string CriticalMessage { get => _CriticalMessage; set => _CriticalMessage = value; }

        public OperationalPeriod()
        {
            OperationalPeriodID = Guid.NewGuid();
        }

        public OperationalPeriod Clone()
        {
            return this.MemberwiseClone() as OperationalPeriod;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
