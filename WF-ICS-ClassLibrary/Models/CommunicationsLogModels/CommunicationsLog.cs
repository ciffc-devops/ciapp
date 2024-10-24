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
    public class CommsLogEntry : ICloneable
    {
        [ProtoMember(1)] private Guid _EntryID;
        [ProtoMember(2)] private int _OpPeriod;
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
        [ProtoMember(14)] private bool _Active;
        [ProtoMember(15)] private Guid _TaskID;
        [ProtoMember(16)] private DateTime _LastUpdatedUTC;
        public Guid EntryID { get => _EntryID; set => _EntryID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
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
        public int OperationalPeriod { get => OpPeriod; set => OpPeriod = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

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

   



    [ProtoContract]
    [Serializable]
    public class CommsRecipient
    {
        [ProtoMember(1)]
        public Guid RecipientID { get; set; }
        [ProtoMember(2)]
        public string RecipientName { get; set; }
        public CommsRecipient() { }
        public CommsRecipient(Guid id, string name) { RecipientID = id; RecipientName = name; }
    }

    [Serializable]
    [ProtoContract]
    public class CannedCommsLogEntry
    {
        [ProtoMember(1)]
        private Guid _CannedID;
        [ProtoMember(2)]
        private string _CannedComment;
        [ProtoMember(3)]
        private bool _Active;
        [ProtoMember(4)]
        private int _DefaultStatusID;
        [ProtoMember(5)]
        private bool _IsCritical;

        public Guid CannedID { get => _CannedID; set => _CannedID = value; }
        public string CannedComment { get => _CannedComment; set => _CannedComment = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int DefaultStatusID { get => _DefaultStatusID; set => _DefaultStatusID = value; }
        public string DefaultStatusName
        {
            get
            {
                if (DefaultStatusID >= 0)
                {
                    List<TeamStatus> statuses = TeamStatusTools.GetAllTeamStatuses();
                    if (statuses.Any(o => o.StatusID == DefaultStatusID)) { return statuses.Where(o => o.StatusID == DefaultStatusID).First().StatusName; }
                    else { return "No default status"; ; }
                }
                else { return "No default status"; }
            }
        }
        public bool IsCritical { get => _IsCritical; set => _IsCritical = value; }

        public CannedCommsLogEntry()
        {
            CannedID = Guid.NewGuid();
            DefaultStatusID = -1;
            Active = true;
            IsCritical = false;
        }

    }
}
