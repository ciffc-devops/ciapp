using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
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
        [ProtoMember(7)] private Guid _ID;
        [ProtoMember(8)] private DateTime _lastUpdatedUTC;
        [ProtoMember(9)] private string _PreparedByPosition;
        public int OpsPeriod { get => _OpsPeriod; set => _OpsPeriod = value; }

        public int TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public List<CommsPlanItem> allCommsItems { get => _allCommsItems; set => _allCommsItems = value; }
        public List<CommsPlanItem> ActiveCommsItems { get => _allCommsItems.Where(o=>o.Active).OrderBy(o=>o.ChannelID).ThenBy(o=>o.CommsFunction).ToList(); }
        public List<CommsPlanItem> ActiveAirCommsItems { get => _allCommsItems.Where(o => o.Active && o.UsedForAircraft).OrderBy(o => o.ChannelID).ThenBy(o => o.CommsFunction).ToList(); }
        //public List<CommsPlanItemLink> allItemLinks { get => _allItemLinks; set => _allItemLinks = value; }
        public Guid ID { get => _ID; set => _ID = value; }
        public DateTime LastUpdatedUTC { get => _lastUpdatedUTC; set => _lastUpdatedUTC = value; }

        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }

        public CommsPlan() { ID = Guid.NewGuid(); allCommsItems = new List<CommsPlanItem>(); LastUpdatedUTC = DateTime.UtcNow; }


      

        public CommsPlanItem getItemByFunction(string function)
        {
            if (allCommsItems.Any(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase)))
            {
                return allCommsItems.First(o => o.CommsFunction.Equals(function, StringComparison.InvariantCultureIgnoreCase));
            }
            else { return null; }
        }

        public CommsPlan CopyToNewPlan(int newOpsPeriod)
        {
            CommsPlan newPlan = new CommsPlan();

            newPlan.OpsPeriod = newOpsPeriod;
            newPlan.TaskNumber = TaskNumber;
            newPlan.DatePrepared = DateTime.Now;
            newPlan.PreparedBy = PreparedBy;
            newPlan.PreparedByPosition = PreparedByPosition;
            newPlan.allCommsItems.AddRange(allCommsItems);
            //newPlan.allItemLinks.AddRange(allItemLinks);
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
            /*
            cloneto.allItemLinks = new List<CommsPlanItemLink>();
            foreach (CommsPlanItemLink item in this.allItemLinks)
            {
                cloneto.allItemLinks.Add(item.Clone());
            }
            */
            return cloneto;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
    }
