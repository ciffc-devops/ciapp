using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class QuickCommsLogEntry
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

        public QuickCommsLogEntry()
        {
            CannedID = Guid.NewGuid();
            DefaultStatusID = -1;
            Active = true;
            IsCritical = false;
        }

    }
}
