﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class GeneralMessage : ICloneable
    {
        [ProtoMember(1)] private Guid _MessageID;
        [ProtoMember(2)] private Guid _TaskID;
        [ProtoMember(3)] private int _OpPeriod;
        [ProtoMember(4)] private string _ToName;
        [ProtoMember(5)] private string _ToPosition;
        [ProtoMember(6)] private string _FromName;
        [ProtoMember(7)] private string _FromPosition;
        [ProtoMember(8)] private DateTime _DateSent;
        [ProtoMember(9)] private DateTime _LastUpdatedUTC;
        [ProtoMember(10)] private string _ApprovedByName;
        [ProtoMember(11)] private string _ApprovedByPosition;
        [ProtoMember(12)] private string _ReplyByPosition;
        [ProtoMember(13)] private string _ReplyByName;
        [ProtoMember(14)] private string _Subject;
        [ProtoMember(15)] private string _Message;
        [ProtoMember(16)] private string _Reply;
        [ProtoMember(17)] private bool _Active;
        [ProtoMember(18)] private DateTime _ReplyDate;
        [ProtoMember(19)] private Guid _FromRoleID;
        [ProtoMember(20)] private Guid _ApprovedByRoleID;
        public GeneralMessage() { MessageID = Guid.NewGuid(); }


        public Guid MessageID { get => _MessageID; set => _MessageID = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string ToName { get => _ToName; set => _ToName = value; }
        public string ToPosition { get => _ToPosition; set => _ToPosition = value; }
        public string To { get { StringBuilder addressee = new StringBuilder(); if (!string.IsNullOrEmpty(ToName)) { addressee.Append(ToName); if (!string.IsNullOrEmpty(ToPosition)) { addressee.Append(" - "); addressee.Append(ToPosition); } } else if (!string.IsNullOrEmpty(ToPosition)) { addressee.Append(ToPosition); } return addressee.ToString(); } }
        public string FromName { get => _FromName; set => _FromName = value; }
        public string FromPosition { get => _FromPosition; set => _FromPosition = value; }
        public string From { get { StringBuilder from = new StringBuilder(); if (!string.IsNullOrEmpty(FromName)) { from.Append(FromName); if (!string.IsNullOrEmpty(FromPosition)) { from.Append(" - "); from.Append(FromPosition); } } else if (!string.IsNullOrEmpty(FromPosition)) { from.Append(FromPosition); } return from.ToString(); } }
        public DateTime DateSent { get => _DateSent; set => _DateSent = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string ApprovedByName { get => _ApprovedByName; set => _ApprovedByName = value; }
        public string ApprovedByPosition { get => _ApprovedByPosition; set => _ApprovedByPosition = value; }
        public string ApprovedBy { get { StringBuilder from = new StringBuilder(); if (!string.IsNullOrEmpty(ApprovedByName)) { from.Append(ApprovedByName); if (!string.IsNullOrEmpty(ApprovedByPosition)) { from.Append(" - "); from.Append(ApprovedByPosition); } } else if (!string.IsNullOrEmpty(ApprovedByPosition)) { from.Append(ApprovedByPosition); } return from.ToString(); } }
        public string ReplyByPosition { get => _ReplyByPosition; set => _ReplyByPosition = value; }
        public string ReplyByName { get => _ReplyByName; set => _ReplyByName = value; }
        public string ReplyBy { get { StringBuilder from = new StringBuilder(); if (!string.IsNullOrEmpty(ReplyByName)) { from.Append(ReplyByName); if (!string.IsNullOrEmpty(ReplyByPosition)) { from.Append(" - "); from.Append(ReplyByPosition); } } else if (!string.IsNullOrEmpty(ReplyByPosition)) { from.Append(ReplyByPosition); } return from.ToString(); } }

        public string Subject { get => _Subject; set => _Subject = value; }
        public string Message { get => _Message; set => _Message = value; }
        public string Reply { get => _Reply; set => _Reply = value; }
        public bool HasReply { get => !string.IsNullOrEmpty(Reply); }
        public bool Active { get => _Active; set => _Active = value; }
        public DateTime ReplyDate { get => _ReplyDate; set => _ReplyDate = value; }
        public Guid FromRoleID { get => _FromRoleID; set => _FromRoleID = value; }
        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }


        public GeneralMessage Clone()
        {
            return this.MemberwiseClone() as GeneralMessage;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
