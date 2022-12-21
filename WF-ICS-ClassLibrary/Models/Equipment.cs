using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class EquipmentCategory : ICloneable
    {
        [ProtoMember(1)] private Guid _CategoryID;
        [ProtoMember(2)] private string _CategoryName;
        [ProtoMember(3)] private Guid _ParentCategoryID;
        [ProtoMember(4)] private string _CategoryNotes;

        public EquipmentCategory()
        {
            CategoryID = Guid.NewGuid();
        }
        public EquipmentCategory(Guid category_id, Guid parent_id, string name)
        {
            CategoryID = category_id;
            ParentCategoryID = parent_id;
            CategoryName = name;
        }

        public Guid CategoryID { get => _CategoryID; set => _CategoryID = value; }
        public string CategoryName { get => _CategoryName; set => _CategoryName = value; }
        public string CategoryNameWithDash { get { if (ParentCategoryID == Guid.Empty) { return CategoryName; } else { return "--" + CategoryName; } } }

        public Guid ParentCategoryID { get => _ParentCategoryID; set => _ParentCategoryID = value; }
        public string CategoryNotes { get => _CategoryNotes; set => _CategoryNotes = value; }

        public EquipmentCategory Clone()
        {
            return this.MemberwiseClone() as EquipmentCategory;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    [ProtoContract]
    [ProtoInclude(500, typeof(TaskEquipment))]
    public class Equipment : ICloneable
    {
        [ProtoMember(1)] private Guid _EquipmentID;
        [ProtoMember(2)] private EquipmentCategory _Category;
        [ProtoMember(3)] private string _EquipmentName;
        [ProtoMember(4)] private string _ReferenceID;
        [ProtoMember(5)] private string _EquipmentBarcodeID;
        [ProtoMember(6)] private string _EquipmentStorageLocation;
        [ProtoMember(7)] private string _EquipmentNotes;
        [ProtoMember(8)] private string _D4HReferenceID;
        [ProtoMember(9)] private bool _InService;
        public Equipment()
        {
            EquipmentID = Guid.NewGuid();
            InService = true;
        }



        public Guid EquipmentID { get => _EquipmentID; set => _EquipmentID = value; }
        public EquipmentCategory Category { get => _Category; set => _Category = value; }
        public string CategoryName { get { if (_Category != null) { return _Category.CategoryName; } else { return null; } } }
        public string EquipmentName { get => _EquipmentName; set => _EquipmentName = value; }
        public string ReferenceID { get => _ReferenceID; set => _ReferenceID = value; }

        public string EquipmentBarcodeID { get => _EquipmentBarcodeID; set => _EquipmentBarcodeID = value; }
        public string EquipmentStorageLocation { get => _EquipmentStorageLocation; set => _EquipmentStorageLocation = value; }
        public string EquipmentNotes { get => _EquipmentNotes; set => _EquipmentNotes = value; }
        public string D4HReferenceID { get => _D4HReferenceID; set => _D4HReferenceID = value; }
        public bool InService { get => _InService; set => _InService = value; }
        public string EquipmentNameWithReference
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(EquipmentName);
                if (!string.IsNullOrEmpty(ReferenceID))
                {
                    sb.Append(" (");
                    sb.Append(ReferenceID);
                    sb.Append(")");
                }
                return sb.ToString();
            }
        }
        public bool BarcodeIsAMatch(string barcode)
        {
            //checks a given barcode against this item.  It will look at the barcode field, and the GUID assigned to the item.

            if (barcode.Equals(EquipmentBarcodeID, StringComparison.InvariantCultureIgnoreCase)) { return true; }
            if (barcode.Equals(EquipmentID.ToString(), StringComparison.InvariantCultureIgnoreCase)) { return true; }
            else { return false; }
        }

        public Equipment Clone()
        {
            Equipment cloneTo = this.MemberwiseClone() as Equipment;
            cloneTo.Category = this.Category.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

    [ProtoContract]
    public class TaskEquipment : Equipment, ICloneable
    {
        [ProtoMember(1)] private int _OpPeriod;
        [ProtoMember(2)] private EquipmentStatus _CurrentStatus;
        [ProtoMember(3)] private EquipmentIssue _CurrentIssue;
        [ProtoMember(4)] private Guid _TaskID;
        [ProtoMember(5)] private string _ParentCategoryName;
        [ProtoMember(6)] private Guid _TaskEquipmentID; //This will be unique each time a piece of equipment is added to the task, say for different op periods. this will be used in the network delete order.
        [ProtoMember(7)] private DateTime _LastUpdatedUTC;

        public TaskEquipment()
        {
            _CurrentIssue = new EquipmentIssue();
            _CurrentStatus = new EquipmentStatus();
            InService = true;
            TaskEquipmentID = Guid.NewGuid();
        }
        public TaskEquipment(Equipment eq, Guid task_id, int op_period)
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
            CurrentIssue = new EquipmentIssue();
            if (InService) { CurrentStatus = Globals._equipmentService.GetEquipmentStatus("Available"); }
            else { CurrentStatus = Globals._equipmentService.GetEquipmentStatus("Not in service"); }
            if (Category.ParentCategoryID != Guid.Empty)
            {
                List<EquipmentCategory> categories = (List<EquipmentCategory>)Globals._generalOptionsService.GetOptionsValue("EquipmentCategories");
                if (categories.Any(o => o.CategoryID == Category.ParentCategoryID)) { ParentCategoryName = categories.Where(o => o.CategoryID == Category.ParentCategoryID).First().CategoryName; }
            }
            else
            {
                ParentCategoryName = CategoryName;
            }
        }


        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }

        public EquipmentStatus CurrentStatus { get => _CurrentStatus; set => _CurrentStatus = value; }

        public EquipmentIssue CurrentIssue { get => _CurrentIssue; set => _CurrentIssue = value; }
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

        public new TaskEquipment Clone()
        {
            TaskEquipment cloneTo = this.MemberwiseClone() as TaskEquipment;
            cloneTo.CurrentStatus = this.CurrentStatus.Clone();
            if (this.CurrentIssue != null) { cloneTo.CurrentIssue = this.CurrentIssue.Clone(); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }

    [ProtoContract]
    public class EquipmentSet : ICloneable
    {
        /****************************
         * Equipment sets are used to group and easily add equipment items to a task
         * Suggested uses include sets for each vehicle, trailer, or storage container
         ***************************/

        [ProtoMember(1)] private Guid _SetID;
        [ProtoMember(2)] private string _SetName;
        [ProtoMember(3)] private List<EquipmentSetMembership> _AllItems;
        [ProtoMember(4)] private bool _AutoAdd;

        public Guid SetID { get => _SetID; set => _SetID = value; }
        public string SetName { get => _SetName; set => _SetName = value; }
        public List<EquipmentSetMembership> AllItems { get => _AllItems; set => _AllItems = value; }
        public int ItemCount { get => AllItems.Count; }
        public bool AutoAdd { get => _AutoAdd; set => _AutoAdd = value; }
        public EquipmentSet() { SetID = Guid.NewGuid(); AllItems = new List<EquipmentSetMembership>(); }
        public EquipmentSet(Guid id, string name) { SetID = id; SetName = name; AllItems = new List<EquipmentSetMembership>(); }

        public EquipmentSet Clone()
        {
            EquipmentSet cloneTo = this.MemberwiseClone() as EquipmentSet;
            cloneTo.AllItems = new List<EquipmentSetMembership>();
            foreach (EquipmentSetMembership mem in this.AllItems) { cloneTo.AllItems.Add(mem.Clone()); }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }

    [ProtoContract]
    public class EquipmentSetMembership : ICloneable
    {
        [ProtoMember(1)] private Guid _SetID;
        [ProtoMember(2)] private Guid _EquipmentID;
        public Guid SetID { get => _SetID; set => _SetID = value; }
        public Guid EquipmentID { get => _EquipmentID; set => _EquipmentID = value; }

        public EquipmentSetMembership() { }
        public EquipmentSetMembership(Guid setid, Guid equip_id)
        {
            SetID = setid; EquipmentID = equip_id;
        }

        public EquipmentSetMembership Clone()
        {
            return this.MemberwiseClone() as EquipmentSetMembership;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


    [ProtoContract]
    public class EquipmentStatus : ICloneable
    {
        [ProtoMember(1)] private Guid _StatusID;
        [ProtoMember(2)] private string _StatusName;
        [ProtoMember(3)] private bool _IsActive;
        [ProtoMember(4)] private int[] _StatusColorRGB;


        public Guid StatusID { get => _StatusID; set => _StatusID = value; }
        public string StatusName { get => _StatusName; set => _StatusName = value; }
        public bool IsActive { get => _IsActive; set => _IsActive = value; }
        public int[] StatusColorRGB { get => _StatusColorRGB; set => _StatusColorRGB = value; }

        public EquipmentStatus() { StatusID = Guid.NewGuid(); }
        public EquipmentStatus(Guid id, string name, bool active = true, int red = 0, int green = 0, int blue = 0)
        {
            StatusID = id; StatusName = name; IsActive = active;
            StatusColorRGB = new int[3];
            StatusColorRGB[0] = red;
            StatusColorRGB[1] = green;
            StatusColorRGB[2] = blue;
        }

        public EquipmentStatus Clone()
        {
            return this.MemberwiseClone() as EquipmentStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


    [ProtoContract]
    public class EquipmentIssue : ICloneable
    {
        [ProtoMember(1)] private Guid _IssueID;
        [ProtoMember(2)] private Guid _EquipmentID;
        [ProtoMember(3)] private Guid _MemberID;
        [ProtoMember(4)] private Guid _AssignmentID;
        [ProtoMember(5)] private DateTime _IssueDate;
        [ProtoMember(6)] private string _AssigneeName;
        [ProtoMember(7)] private DateTime _ReturnDate;
        [ProtoMember(8)] private int _OpPeriod;
        [ProtoMember(9)] private DateTime _LastUpdatedUTC;

        public Guid IssueID { get => _IssueID; set => _IssueID = value; }
        public Guid EquipmentID { get => _EquipmentID; set => _EquipmentID = value; }
        public Guid MemberID { get => _MemberID; set => _MemberID = value; }
        public Guid AssignmentID { get => _AssignmentID; set => _AssignmentID = value; }
        public DateTime IssueDate { get => _IssueDate; set => _IssueDate = value; }
        public DateTime ReturnDate { get => _ReturnDate; set => _ReturnDate = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string ReturnDateAsString
        {
            get
            {
                if (ReturnDate < DateTime.MaxValue && ReturnDate > DateTime.MinValue) { return ReturnDate.ToString("yyyy-MMM-dd HH:mm"); }
                else { return null; }
            }
        }
        public string AssigneeName { get => _AssigneeName; set => _AssigneeName = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public EquipmentIssue() { IssueID = Guid.NewGuid(); IssueDate = DateTime.Now; ReturnDate = DateTime.MaxValue; }
        public EquipmentIssue(Guid id, Guid equipmentit_id, Guid member_id, Guid assignment_id, string name, int op)
        {
            IssueID = id; if (id == Guid.Empty) { IssueID = Guid.NewGuid(); }
            EquipmentID = equipmentit_id;
            MemberID = member_id;
            AssignmentID = assignment_id;
            IssueDate = DateTime.Now;
            AssigneeName = name;
            ReturnDate = DateTime.MaxValue;
            OpPeriod = op;
        }

        public EquipmentIssue Clone()
        {
            return this.MemberwiseClone() as EquipmentIssue;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }


}
