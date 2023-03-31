using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Networking
{
    [ProtoContract]
    [Serializable]
    public class NetworkSendObject 
    {
        public NetworkSendObject()
        {
            TaskID = Guid.Empty;
        }
        public NetworkSendObject(Guid task_id)
        {
            TaskID = task_id;
        }

        [ProtoMember(1)]
        public Guid RequestID { get; set; }

        //for network reasons
        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        [ProtoMember(2)] string _sourceIdentifier;
        [ProtoMember(3)] public int RelayCount { get; set; }
        [ProtoMember(4)] public string SourceName { get; set; }
        [ProtoMember(5)] public string objectType { get; set; }
        [ProtoMember(6)] private Guid _guidValue = Guid.Empty;
        [ProtoMember(7)] public string comment { get; set; }
        [ProtoMember(33)] private Guid _TaskID;
        [ProtoMember(32)] private GeneralOptions _generalOptions;


        [ProtoMember(43)] private TaskUpdate _taskUpdate; //[ProtoMember(43)] private TaskUpdate _taskUpdate;
        [ProtoMember(44)] private bool _UploadedToInternet;

        public Guid GuidValue { get { return _guidValue; } set { _guidValue = value; } }
        public bool UploadedToInternet { get => _UploadedToInternet; set => _UploadedToInternet = value; }



        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public GeneralOptions generalOptions { get => _generalOptions; set => _generalOptions = value; }

     
        public TaskUpdate taskUpdate { get => _taskUpdate; set => _taskUpdate = value; }


    }

    
    public static class NetworkCheck
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://sarassist.ca"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
