using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CommsPlan : ICSFormData, ICloneable
    {
        [ProtoMember(5)] private List<CommsPlanItem> _allCommsItems;

        public List<CommsPlanItem> allCommsItems { get => _allCommsItems; set => _allCommsItems = value; }
        public List<CommsPlanItem> ActiveCommsItems { get => _allCommsItems.Where(o=>o.Active).OrderBy(o=>o.SortOrder).ThenBy(o => o.ChannelID).ThenBy(o=>o.CommsFunction).ToList(); }
        public List<CommsPlanItem> ActiveAirCommsItems { get => _allCommsItems.Where(o => o.Active && o.UsedForAircraft).OrderBy(o => o.SortOrder).ThenBy(o => o.ChannelID).ThenBy(o => o.CommsFunction).ToList(); }
        //public List<CommsPlanItemLink> allItemLinks { get => _allItemLinks; set => _allItemLinks = value; }

        public CommsPlan() { ID = Guid.NewGuid(); allCommsItems = new List<CommsPlanItem>(); LastUpdatedUTC = DateTime.UtcNow; }

        public void AddCommsItem(CommsPlanItem item)
        {
            if (item.SortOrder == 0)
            {
                if (ActiveCommsItems.Any()) { item.SortOrder = ActiveCommsItems.Max(o => o.SortOrder) + 1; }
                else { item.SortOrder = 1; }
            }
            allCommsItems.Add(item);
            
        }
      
        private void UpdateCommsPlanSortOrders()
        {

        }

        public void MoveItemUp (CommsPlanItem itemToMoveUp)
        {
            int newSortOrder = ActiveCommsItems.Where(o => o.SortOrder < itemToMoveUp.SortOrder).Max(o => o.SortOrder);
            
        }

        public void MoveItemDown(CommsPlanItem itemToMoveDown)
        {
        }   

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
            CommsPlan newPlan = this.Clone();

            newPlan.OpPeriod = newOpsPeriod;
            newPlan.DatePrepared = DateTime.Now;
            newPlan.allCommsItems.Clear();
            foreach(CommsPlanItem item in allCommsItems)
            {
                newPlan.allCommsItems.Add(item.Clone());
            }
            newPlan.LastUpdatedUTC = DateTime.UtcNow;
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
            return cloneto;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
    }
