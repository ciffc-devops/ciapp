using ProtoBuf;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CommsLogEntry : SyncableItem, ICloneable
    {
        [ProtoMember(3)] private string _LogKeeper;
        [ProtoMember(4)] private DateTime _LogDate;
        [ProtoMember(5)] private DateTime _Created;
        [ProtoMember(6)] private DateTime _LastUpdated;
        [ProtoMember(7)] private Guid _FromTeamID;
        [ProtoMember(8)] private Guid _ToTeamID;
        [ProtoMember(9)] private string _FromName;
        [ProtoMember(10)] private string _ToName;
        [ProtoMember(11)] private string _Message;
        [ProtoMember(12)] private bool _Starred;
        [ProtoMember(13)] private TeamStatus _status;

        public Guid EntryID { get => ID; set => ID = value; }
        public string LogKeeper { get => _LogKeeper; set => _LogKeeper = value; }
        public DateTime LogDate { get => _LogDate; set => _LogDate = value; }
        public DateTime Created { get => _Created; set => _Created = value; }
        public DateTime LastUpdated { get => _LastUpdated; set => _LastUpdated = value; }
        public Guid FromTeamID { get => _FromTeamID; set => _FromTeamID = value; }
        public Guid ToTeamID { get => _ToTeamID; set => _ToTeamID = value; }
        public string FromName { get => _FromName; set => _FromName = value; }
        public string ToName { get => _ToName; set => _ToName = value; }
        public string Message { get => _Message; set => _Message = value; }
        public bool Starred { get => _Starred; set => _Starred = value; }
        public TeamStatus status { get => _status; set => _status = value; }

        //for network reasons
        /*
        public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } set { _sourceIdentifier = value; } }
        [ProtoMember(15)]
        string _sourceIdentifier;
        [ProtoMember(16)]
        public int RelayCount { get; set; }*/

        public CommsLogEntry() { EntryID = Guid.NewGuid(); status = new TeamStatus(); }


        public CommsLogEntry Clone()
        {
            CommsLogEntry cloneTo = this.MemberwiseClone() as CommsLogEntry;
            cloneTo.status = this.status.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }
}
