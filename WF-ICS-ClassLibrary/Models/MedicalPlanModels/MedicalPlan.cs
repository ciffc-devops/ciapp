using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class MedicalPlan : ICSFormData, ICloneable
    {
        [ProtoMember(4)] private List<AmbulanceService> _Ambulances;
        [ProtoMember(5)] private List<Hospital> _Hospitals;
        [ProtoMember(6)] private List<MedicalAidStation> _MedicalAidStations;
        [ProtoMember(9)] private string _EmergencyProcedures;

        public List<AmbulanceService> Ambulances { get => _Ambulances; set => _Ambulances = value; }
        public List<AmbulanceService> ActiveAmbulances { get { if (Ambulances != null) { return Ambulances.Where(o => o.Active).OrderBy(o => o.Organization).ToList(); } else { return null; } } }
        public List<Hospital> Hospitals { get => _Hospitals; set => _Hospitals = value; }
        public List<Hospital> ActiveHospitals { get { if (Hospitals != null) { return Hospitals.Where(o => o.Active).OrderBy(o => o.name).ToList(); } else { return null; } } }
        public string EmergencyProcedures { get => _EmergencyProcedures; set => _EmergencyProcedures = value; }



        public List<MedicalAidStation> MedicalAidStations { get => _MedicalAidStations; set => _MedicalAidStations = value; }
        public List<MedicalAidStation> ActiveAidStations { get { if (MedicalAidStations != null) { return MedicalAidStations.Where(o => o.Active).OrderBy(o => o.Name).ToList(); } else { return null; } } }

        public MedicalPlan() {  Ambulances = new List<AmbulanceService>(); Hospitals = new List<Hospital>(); DatePrepared = DateTime.Now; MedicalAidStations = new List<MedicalAidStation>(); }

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
