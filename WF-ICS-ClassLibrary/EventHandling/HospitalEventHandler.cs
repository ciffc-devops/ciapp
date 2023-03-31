using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.EventHandling
{
    public delegate void HospitalEventHandler(HospitalEventArgs e);

    public class HospitalEventArgs
    {
        public Hospital item { get; set; }

        public HospitalEventArgs(Hospital _item) { item = _item; }
    }

    public delegate void AmbulanceServiceEventHandler(AmbulanceServiceEventArgs e);

    public class AmbulanceServiceEventArgs
    {
        public AmbulanceService item { get; set; }

        public AmbulanceServiceEventArgs(AmbulanceService _item) { item = _item; }
    }

    public delegate void MedicalAidStationEventHandler(MedicalAidStationEventArgs e);

    public class MedicalAidStationEventArgs
    {
        public MedicalAidStation item { get; set; }

        public MedicalAidStationEventArgs(MedicalAidStation _item) { item = _item; }
    }
}
