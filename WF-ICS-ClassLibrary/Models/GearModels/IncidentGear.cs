using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class IncidentGear : Gear, ICloneable
    {
        [ProtoMember(1)] private int _OpPeriod;
        [ProtoMember(2)] private GearStatus _CurrentStatus;
        [ProtoMember(3)] private GearIssue _CurrentIssue;
        [ProtoMember(4)] private Guid _TaskID;
        [ProtoMember(5)] private string _ParentCategoryName;
        [ProtoMember(6)] private Guid _TaskEquipmentID; //This will be unique each time a piece of equipment is added to the task, say for different op periods. this will be used in the network delete order.
        [ProtoMember(7)] private DateTime _LastUpdatedUTC;

        public IncidentGear()
        {
            _CurrentIssue = new GearIssue();
            _CurrentStatus = new GearStatus();
            InService = true;
            TaskEquipmentID = Guid.NewGuid();
        }
        public IncidentGear(Gear eq, Guid task_id, int op_period)
        {
            TaskEquipmentID = Guid.NewGuid();
            EquipmentID = eq.EquipmentID;
            Category = eq.Category;
            EquipmentName = eq.EquipmentName;
            ReferenceID = eq.ReferenceID;
            EquipmentBarcodeID = eq.EquipmentBarcodeID;
            EquipmentStorageLocation = eq.EquipmentStorageLocation;
            EquipmentNotes = eq.EquipmentNotes;
            D4HReferenceID = eq.D4HReferenceID;
            InService = eq.InService;

            OpPeriod = op_period;
            TaskID = task_id;
            CurrentIssue = new GearIssue();
            if (InService) { CurrentStatus = Globals._equipmentService.GetEquipmentStatus("Available"); }
            else { CurrentStatus = Globals._equipmentService.GetEquipmentStatus("Not in service"); }
            if (Category.ParentCategoryID != Guid.Empty)
            {
                List<GearCategory> categories = (List<GearCategory>)Globals._generalOptionsService.GetOptionsValue("EquipmentCategories");
                if (categories.Any(o => o.CategoryID == Category.ParentCategoryID)) { ParentCategoryName = categories.Where(o => o.CategoryID == Category.ParentCategoryID).First().CategoryName; }
            }
            else
            {
                ParentCategoryName = CategoryName;
            }
        }


        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }

        public GearStatus CurrentStatus { get => _CurrentStatus; set => _CurrentStatus = value; }

        public GearIssue CurrentIssue { get => _CurrentIssue; set => _CurrentIssue = value; }
        public string AssigneeName { get { if (_CurrentIssue != null) { return _CurrentIssue.AssigneeName; } else { return null; } } }

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public string StatusName { get { if (CurrentStatus != null) { return CurrentStatus.StatusName; } else { return "none"; } } }
        public string ParentCategoryName { get => _ParentCategoryName; set => _ParentCategoryName = value; }
        public Guid TaskEquipmentID { get => _TaskEquipmentID; set => _TaskEquipmentID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string FullCategoryNames
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(ParentCategoryName))
                {
                    sb.Append(ParentCategoryName);
                }
                if (!string.IsNullOrEmpty(CategoryName) && !CategoryName.Equals(ParentCategoryName, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (sb.Length > 0) { sb.Append(" > "); }
                    sb.Append(CategoryName);
                }

                return sb.ToString();
            }
        }

        public new IncidentGear Clone()
        {
            IncidentGear cloneTo = this.MemberwiseClone() as IncidentGear;
            cloneTo.CurrentStatus = this.CurrentStatus.Clone();
            if (this.CurrentIssue != null) { cloneTo.CurrentIssue = this.CurrentIssue.Clone(); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }


}
