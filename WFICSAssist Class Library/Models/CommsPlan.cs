using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFICSAssist_Class_Library.Utilities;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract]
    [Serializable]
    public class CommsPlan : ICloneable
    {
        [ProtoMember(1)] private int _OpsPeriod;
        [ProtoMember(2)] private int _TaskNumber;
        [ProtoMember(3)] private DateTime _DatePrepared;
        [ProtoMember(4)] private string _PreparedBy;
        [ProtoMember(5)] private List<CommsPlanItem> _allCommsItems;
        [ProtoMember(6)] private List<CommsPlanItemLink> _allItemLinks;
        [ProtoMember(7)] private Guid _ID;
        [ProtoMember(8)] private DateTime _lastUpdatedUTC;

        public int OpsPeriod { get => _OpsPeriod; set => _OpsPeriod = value; }

        public int TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public List<CommsPlanItem> allCommsItems { get => _allCommsItems; set => _allCommsItems = value; }
        public List<CommsPlanItemLink> allItemLinks { get => _allItemLinks; set => _allItemLinks = value; }
        public Guid ID { get => _ID; set => _ID = value; }
        public DateTime LastUpdatedUTC { get => _lastUpdatedUTC; set => _lastUpdatedUTC = value; }


        public CommsPlan() { ID = Guid.NewGuid(); allCommsItems = new List<CommsPlanItem>(); allItemLinks = new List<CommsPlanItemLink>(); LastUpdatedUTC = DateTime.UtcNow; }
        public CommsPlan(bool generateBlankItems) { ID = Guid.NewGuid(); allCommsItems = new List<CommsPlanItem>(); allItemLinks = new List<CommsPlanItemLink>(); if (generateBlankItems) { buildInitialText(); } LastUpdatedUTC = DateTime.UtcNow; }


        private void buildInitialText()
        {
            List<string> templateFunctions = new List<string>();
            templateFunctions.Add("COMMAND NET");
            templateFunctions.Add("OPERATIONS");
            templateFunctions.Add("SUPPORT NET");
            templateFunctions.Add("TACTICAL");
            templateFunctions.Add("AIR NET");
            templateFunctions.Add("EMERGENCY CHANNEL");



            if (!allItemLinks.Any())
            {
                CommsPlanItem blankItem = new CommsPlanItem();
                if (allCommsItems.Where(o => o.ItemID == Guid.Empty).Any())
                {
                    blankItem = allCommsItems.Where(o => o.ItemID == Guid.Empty).First();
                }
                else
                {
                    blankItem = new CommsPlanItem();
                    blankItem.ItemID = Guid.Empty;
                    blankItem.Active = true;
                    allCommsItems.Add(blankItem);
                }

                foreach (string s in templateFunctions)
                {
                    allItemLinks.Add(new CommsPlanItemLink(blankItem.ItemID, s, 0));
                }
            }

            /*
            if (allCommsItems.Where(o => o.CommsFunction == "COMMAND NET").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("COMMAND NET", new Guid("a0663432-2644-4716-b469-72ef1aaecab6"))); }
            if (allCommsItems.Where(o => o.CommsFunction == "OPERATIONS").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("OPERATIONS", new Guid("74aff6c5-d300-4e92-bb92-08b9782c2d47"))); }
            if (allCommsItems.Where(o => o.CommsFunction == "SUPPORT NET").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("SUPPORT NET", new Guid("aa39d773-8f7a-4a2e-8cf2-29d9bce94309"))); }
            if (allCommsItems.Where(o => o.CommsFunction == "TACTICAL").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("TACTICAL", new Guid("a57c8372-f231-42f0-bd53-b99799122435"))); }
            if (allCommsItems.Where(o => o.CommsFunction == "AIR NET").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("AIR NET", new Guid("603def75-f48e-42f2-b810-904b85082f30"))); }
            if (allCommsItems.Where(o => o.CommsFunction == "EMERGENCY CHANNEL").Count() <= 0) { allCommsItems.Add(new CommsPlanItem("EMERGENCY CHANNEL", new Guid("5a326469-6572-4236-8b68-f3ba596ff980"))); }
            */
        }

        public CommsPlanItem getItemByFunction(string function)
        {
            if (allItemLinks.Any(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)))
            {
                CommsPlanItemLink link = allItemLinks.First(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase));
                if (allCommsItems.Any(o => o.ItemID == link.ItemID))
                {
                    return allCommsItems.First(o => o.ItemID == link.ItemID);
                }
                else { return new CommsPlanItem(); }
            }
            else { return new CommsPlanItem(); }
            /*
            if (allCommsItems.Where(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)).Count() == 1) { return allCommsItems.Where(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)).First(); }
            else if (function == "REPEATER" && allCommsItems.Where(o=>o.IsRepeater).Any()) { return allCommsItems.Where(o => o.IsRepeater).First(); }
            else { return new CommsPlanItem(); }
            */
        }

        public CommsPlan CopyToNewPlan(int newOpsPeriod)
        {
            CommsPlan newPlan = new CommsPlan();

            newPlan.OpsPeriod = newOpsPeriod;
            newPlan.TaskNumber = TaskNumber;
            newPlan.DatePrepared = DateTime.Now;
            newPlan.PreparedBy = PreparedBy;
            newPlan.allCommsItems.AddRange(allCommsItems);
            newPlan.allItemLinks.AddRange(allItemLinks);
            newPlan._lastUpdatedUTC = DateTime.UtcNow;
            return newPlan;
        }


        public CommsPlan Clone()
        {
            CommsPlan cloneto = this.MemberwiseClone() as CommsPlan;
            cloneto.allCommsItems = new List<CommsPlanItem>();
            foreach (CommsPlanItem item in this.allCommsItems)
            {
                cloneto.allCommsItems.Add(item.Clone());
            }
            cloneto.allItemLinks = new List<CommsPlanItemLink>();
            foreach (CommsPlanItemLink item in this.allItemLinks)
            {
                cloneto.allItemLinks.Add(item.Clone());
            }
            return cloneto;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    [ProtoContract]
    [Serializable]
    public class CommsPlanItem : ICloneable, IEquatable<CommsPlanItem>
    {
        public CommsPlanItem() { ItemID = System.Guid.NewGuid(); }
        public CommsPlanItem(string function, Guid id = new Guid())
        {
            if (id == Guid.Empty) { ItemID = System.Guid.NewGuid(); } else { ItemID = id; }
            CommsFunction = function;
        }


        [ProtoMember(1)] private Guid _ItemID;
        [ProtoMember(2)] private string _CommsSystem;
        [ProtoMember(3)] private string _CallSign;
        [ProtoMember(4)] private string _CommsFunction;
        [ProtoMember(5)] private string _ChannelID;
        [ProtoMember(6)] private string _ChannelNumber;
        [ProtoMember(7)] private string _Frequency;
        [ProtoMember(8)] private string _Comments;
        [ProtoMember(9)] private bool _IsRepeater;
        [ProtoMember(10)] private DateTime _LastUpdatedUTC;
        [ProtoMember(11)] private bool _isUniversal;
        [ProtoMember(12)] private bool _Active;
        [ProtoMember(13)] private Guid _OrganizationID;
        [ProtoMember(14)] private int _OpsPeriod;

        public Guid ItemID { get => _ItemID; set => _ItemID = value; }
        public string CommsSystem { get => _CommsSystem; set => _CommsSystem = value; }
        public string CallSign { get => _CallSign; set => _CallSign = value; }
        public string CommsFunction { get => _CommsFunction; set => _CommsFunction = value; }
        public string ChannelID { get => _ChannelID; set => _ChannelID = value; }
        public string ChannelNumber { get => _ChannelNumber; set => _ChannelNumber = value; }
        public string Frequency { get => _Frequency; set => _Frequency = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public bool IsRepeater { get => _IsRepeater; set => _IsRepeater = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public int OpsPeriod { get => _OpsPeriod; set => _OpsPeriod = value; }

        /*[ProtoMember(13)]
        private Guid _userID;
        public Guid UserID { get { return _userID; } set { _userID = value; } }*/






        public string IDWithFrequency { get { return ChannelID + " " + Frequency; } }
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

            if (this.ItemID != other.ItemID) { isEqual = false; }
            if (isEqual && this.Active != other.Active) { isEqual = false; }
            if (isEqual && !this.CommsSystem.EqualsWithNull(other.CommsSystem)) { isEqual = false; }
            if (isEqual && !this.CallSign.EqualsWithNull(other.CallSign)) { isEqual = false; }
            if (isEqual && !this.ChannelID.EqualsWithNull(other.ChannelID)) { isEqual = false; }
            if (isEqual && !this.ChannelNumber.EqualsWithNull(other.ChannelNumber)) { isEqual = false; }
            if (isEqual && !this.Frequency.EqualsWithNull(other.Frequency)) { isEqual = false; }
            if (isEqual && this.IsRepeater != other.IsRepeater) { isEqual = false; }
            return isEqual;
        }

        /******************
         * Data access classes for sync or write to db
         *******************/

    }

    [ProtoContract]
    [Serializable]
    public class CommsPlanItemLink : ICloneable
    {
        [ProtoMember(1)] private Guid _ItemID;
        [ProtoMember(2)] private string _CommsFunction;
        [ProtoMember(3)] private int _OpsPeriod;

        public Guid ItemID { get => _ItemID; set => _ItemID = value; }
        public string CommsFunction { get => _CommsFunction; set => _CommsFunction = value; }
        public int OpsPeriod { get => _OpsPeriod; set => _OpsPeriod = value; }

        public CommsPlanItemLink() { }
        public CommsPlanItemLink(Guid id, string function, int ops)
        {
            ItemID = id; CommsFunction = function; OpsPeriod = ops;
        }
        public CommsPlanItemLink Clone()
        {
            return this.MemberwiseClone() as CommsPlanItemLink;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }

    }
}
