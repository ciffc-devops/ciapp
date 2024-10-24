using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class MedicalPlan : ICloneable
    {
        [ProtoMember(1)] private int _OpPeriod;
        [ProtoMember(2)] private string _PreparedBy;
        [ProtoMember(3)] private DateTime _DatePrepared;
        [ProtoMember(4)] private List<AmbulanceService> _Ambulances;
        [ProtoMember(5)] private List<Hospital> _Hospitals;
        [ProtoMember(6)] private List<MedicalAidStation> _MedicalAidStations;
        [ProtoMember(7)] private Guid _ID;
        [ProtoMember(8)] private DateTime _LastUpdatedUTC;
        [ProtoMember(9)] private string _EmergencyProcedures;
        [ProtoMember(10)] private string _PreparedByPosition;
        [ProtoMember(11)] private string _ApprovedByPosition;
        [ProtoMember(12)] private string _ApprovedBy;
        [ProtoMember(13)] private Guid _PreparedByRoleID;
        [ProtoMember(14)] private Guid _ApprovedByRoleID;

        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public List<AmbulanceService> Ambulances { get => _Ambulances; set => _Ambulances = value; }
        public List<AmbulanceService> ActiveAmbulances { get { if (Ambulances != null) { return Ambulances.Where(o => o.Active).OrderBy(o => o.Organization).ToList(); } else { return null; } } }
        public List<Hospital> Hospitals { get => _Hospitals; set => _Hospitals = value; }
        public List<Hospital> ActiveHospitals { get { if (Hospitals != null) { return Hospitals.Where(o => o.Active).OrderBy(o => o.name).ToList(); } else { return null; } } }
        public Guid ID { get => _ID; set => _ID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string EmergencyProcedures { get => _EmergencyProcedures; set => _EmergencyProcedures = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public string ApprovedByPosition { get => _ApprovedByPosition; set => _ApprovedByPosition = value; }
        public string ApprovedBy { get => _ApprovedBy; set => _ApprovedBy = value; }
        public Guid PreparedByRoleID { get => _PreparedByRoleID; set => _PreparedByRoleID = value; }
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }



        public List<MedicalAidStation> MedicalAidStations { get => _MedicalAidStations; set => _MedicalAidStations = value; }
        public List<MedicalAidStation> ActiveAidStations { get { if (MedicalAidStations != null) { return MedicalAidStations.Where(o => o.Active).OrderBy(o => o.Name).ToList(); } else { return null; } } }

        public MedicalPlan() { ID = Guid.NewGuid(); LastUpdatedUTC = DateTime.UtcNow; Ambulances = new List<AmbulanceService>(); Hospitals = new List<Hospital>(); DatePrepared = DateTime.Now; MedicalAidStations = new List<MedicalAidStation>(); }

        public MedicalPlan Clone()
        {
            MedicalPlan cloneTo = this.MemberwiseClone() as MedicalPlan;
            cloneTo.Ambulances = new List<AmbulanceService>();
            cloneTo.Hospitals = new List<Hospital>();
            cloneTo.MedicalAidStations = new List<MedicalAidStation>();
            foreach (AmbulanceService serv in this.Ambulances) { cloneTo.Ambulances.Add(serv.Clone()); }
            foreach (Hospital serv in this.Hospitals) { cloneTo.Hospitals.Add(serv.Clone()); }
            foreach (MedicalAidStation aid in this.MedicalAidStations) { cloneTo.MedicalAidStations.Add(aid.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
