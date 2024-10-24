﻿using ProtoBuf;
using System;
using System.Text;
using WF_ICS_ClassLibrary.Utilities;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CommsPlanItem : ICloneable, IEquatable<CommsPlanItem>
    {
        public CommsPlanItem() { ItemID = System.Guid.NewGuid(); TemplateItemID = Guid.NewGuid(); Active = true; }
        public CommsPlanItem(string function, Guid id = new Guid())
        {
            if (id == Guid.Empty) { ItemID = System.Guid.NewGuid(); } else { ItemID = id; }
            CommsFunction = function;
            TemplateItemID = Guid.NewGuid();
            Active = true;
        }


        [ProtoMember(1)] private Guid _ItemID; //This is a unique identifier for each instance of an item in a specific comms plan
        [ProtoMember(2)] private string _CommsSystem;
        [ProtoMember(3)] private string _CallSign;
        [ProtoMember(4)] private string _CommsFunction;
        [ProtoMember(5)] private string _ChannelID;
        [ProtoMember(6)] private string _ChannelNumber;
        [ProtoMember(7)] private string _RxFrequency;
        [ProtoMember(8)] private string _Comments;
        [ProtoMember(9)] private bool _IsRepeater;
        [ProtoMember(10)] private DateTime _LastUpdatedUTC;
        [ProtoMember(11)] private bool _isUniversal;
        [ProtoMember(12)] private bool _Active;
        [ProtoMember(13)] private Guid _OrganizationID;
        [ProtoMember(14)] private int _OpsPeriod;
        [ProtoMember(15)] private string _RxTone;
        [ProtoMember(16)] private string _Assignment;
        [ProtoMember(17)] private Guid _TemplateItemID; //This is a unique identifier for the item as saved in Options.
        [ProtoMember(18)] private bool _Aircraft;
        [ProtoMember(19)] private string _TxFrequency;
        [ProtoMember(20)] private string _TxTone;

        public Guid ItemID { get => _ItemID; set => _ItemID = value; }
        public string CommsSystem { get => _CommsSystem; set => _CommsSystem = value; }
        public string CallSign { get => _CallSign; set => _CallSign = value; }
        public string CommsFunction { get => _CommsFunction; set => _CommsFunction = value; }
        public string ChannelID { get => _ChannelID; set => _ChannelID = value; }
        public string ChannelNumber { get => _ChannelNumber; set => _ChannelNumber = value; }
        public string RxFrequency { get => _RxFrequency; set => _RxFrequency = value; }
        public string TxFrequency { get => _TxFrequency; set => _TxFrequency = value; }
        public string FullFrequency
        {
            get
            {
                if (!string.IsNullOrEmpty(RxFrequency) && !string.IsNullOrEmpty(TxFrequency) && !RxFrequency.Equals(TxFrequency)) { return "(Rx) "+   RxFrequency + " / (Tx) " + TxFrequency; }
                else { return RxFrequency; }
            }
        }
        public string Comments { get => _Comments; set => _Comments = value; }
        public bool IsRepeater { get => _IsRepeater; set => _IsRepeater = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public int OpsPeriod { get => _OpsPeriod; set => _OpsPeriod = value; }
        public string RxTone { get => _RxTone; set => _RxTone = value; }
        public string TxTone { get => _TxTone; set => _TxTone = value; }
        public string FullTone
        {
            get
            {
                if (!string.IsNullOrEmpty(RxTone) && !string.IsNullOrEmpty(TxTone) && !RxTone.Equals(TxTone)) { return "(Rx) " + RxTone + " / (Tx) "  + TxTone; }
                else { return RxTone; }
            }
        }

        public string FullRx
        {
            get
            {
                return RxFrequency + " / " + RxTone;
            }
        }

        public string FullTx
        {
            get
            {
                return TxFrequency + " / " + TxTone;
            }
        }

        public string Assignment { get => _Assignment; set => _Assignment = value; }
        public bool UsedForAircraft { get => _Aircraft; set => _Aircraft = value; }

        public string IDWithFrequency { get { return ChannelID + " " + RxFrequency; } }
        public string SystemWithID
        {
            get
            {
                if (CommsSystem != null && ChannelID != null) { return ChannelID + " (" + CommsSystem + ")"; }
                else { return ""; }
            }
        }

        public string SystemWithIDAndChannelNumber
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ChannelID);
                sb.Append(" ");
                if (!string.IsNullOrEmpty(ChannelNumber)) { sb.Append("#"); sb.Append(ChannelNumber); sb.Append(" "); }
                if (!string.IsNullOrEmpty(CommsSystem)) { sb.Append("("); sb.Append(CommsSystem); sb.Append(")"); }
                return sb.ToString();
            }
        }
        public string SystemIDChannelFunction
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ChannelID);
                sb.Append(" ");
                if (!string.IsNullOrEmpty(ChannelNumber)) { sb.Append("#"); sb.Append(ChannelNumber); sb.Append(" "); }
                if (!string.IsNullOrEmpty(CommsSystem)) { sb.Append("("); sb.Append(CommsSystem); sb.Append(")"); }
                if (!string.IsNullOrEmpty(CommsFunction)) { sb.Append(" - "); sb.Append(CommsFunction); }
                return sb.ToString();
            }
        }


        public Guid TemplateItemID { get => _TemplateItemID; set => _TemplateItemID = value; }


        public CommsPlanItem Clone()
        {
            return this.MemberwiseClone() as CommsPlanItem;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


        public bool Equals(CommsPlanItem other)
        {
            bool isEqual = true;

            if (isEqual && this.Active != other.Active) { return false; }
            if (isEqual && !this.CommsSystem.EqualsWithNull(other.CommsSystem)) { return false; }
            if (isEqual && !this.CallSign.EqualsWithNull(other.CallSign)) { return false; }
            if (isEqual && !this.ChannelID.EqualsWithNull(other.ChannelID)) { return false; }
            if (isEqual && !this.ChannelNumber.EqualsWithNull(other.ChannelNumber)) { return false; }
            if (isEqual && !this.RxFrequency.EqualsWithNull(other.RxFrequency)) { return false; }
            if (isEqual && !this.TxFrequency.EqualsWithNull(other.TxFrequency)) { return false; }
            if (isEqual && !this.RxTone.EqualsWithNull(other.RxTone)) { return false; }
            if (isEqual && !this.TxTone.EqualsWithNull(other.TxTone)) { return false; }
            if (isEqual && this.IsRepeater != other.IsRepeater) { return false; }
            if (isEqual && !this.RxTone.EqualsWithNull(other.RxTone)) { return false; }
            if (isEqual && !this.Assignment.EqualsWithNull(other.Assignment)) { return false; }

            if(isEqual && this.TemplateItemID != other.TemplateItemID) { return false; }
            return isEqual;
        }

        /******************
         * Data access classes for sync or write to db
         *******************/

    }
    }
