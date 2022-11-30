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
    public class MedicalPlan : ICloneable
    {
        [ProtoMember(1)]
        public int OpPeriod { get; set; }
        [ProtoMember(2)]
        public string PreparedBy { get; set; }
        [ProtoMember(3)]
        public DateTime DatePrepared { get; set; }
        [ProtoMember(4)]
        public List<AmbulanceService> ambulanceServices { get; set; }
        [ProtoMember(5)]
        public List<Hospital> hospitals { get; set; }
        [ProtoMember(6)]
        public Guid RITTeamAssignmentID { get; set; }


        [ProtoMember(7)]
        public Guid ID { get; set; } = Guid.NewGuid();
        [ProtoMember(8)] public DateTime LastUpdatedUTC { get; set; } = DateTime.UtcNow;


        public MedicalPlan() { ambulanceServices = new List<AmbulanceService>(); hospitals = new List<Hospital>(); DatePrepared = DateTime.Now; }

        public MedicalPlan Clone()
        {
            MedicalPlan cloneTo = this.MemberwiseClone() as MedicalPlan;
            cloneTo.ambulanceServices = new List<AmbulanceService>();
            cloneTo.hospitals = new List<Hospital>();
            foreach (AmbulanceService serv in this.ambulanceServices) { cloneTo.ambulanceServices.Add(serv.Clone()); }
            foreach (Hospital serv in this.hospitals) { cloneTo.hospitals.Add(serv.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
