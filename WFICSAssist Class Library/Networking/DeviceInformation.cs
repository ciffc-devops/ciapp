using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Networking
{
    [ProtoContract]
    public class DeviceInformation
    {
        [ProtoMember(1)] private Guid _DeviceID;
        [ProtoMember(2)] private string _DeviceName;
        [ProtoMember(3)] private string _DeviceIP;
        [ProtoMember(4)] private bool _TrustDevice;


        public Guid DeviceID { get => _DeviceID; set => _DeviceID = value; }
        public string DeviceName { get => _DeviceName; set => _DeviceName = value; }
        public string DeviceIP { get => _DeviceIP; set => _DeviceIP = value; }
        public bool TrustDevice { get => _TrustDevice; set => _TrustDevice = value; }
        public string DeviceNameAndIP { get { return DeviceName + "(" + DeviceIP + ")"; } }
        public DeviceInformation() { DeviceID = Guid.NewGuid(); }
    }
}
