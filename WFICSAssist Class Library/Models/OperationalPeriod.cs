using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
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
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public Guid OperationalPeriodID { get => _OperationalPeriodID; set => _OperationalPeriodID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public OperationalPeriod()
        {
            OperationalPeriodID = Guid.NewGuid();
        }

        public OperationalPeriod? Clone()
        {
            return this.MemberwiseClone() as OperationalPeriod;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
