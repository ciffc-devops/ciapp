using ProtoBuf;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{

    [ProtoContract]
    [ProtoInclude(500, typeof(IncidentGear))]
    public class Gear : SyncableItem, ICloneable
    {
        [ProtoMember(2)] private GearCategory _Category;
        [ProtoMember(3)] private string _EquipmentName;
        [ProtoMember(4)] private string _ReferenceID;
        [ProtoMember(5)] private string _EquipmentBarcodeID;
        [ProtoMember(6)] private string _EquipmentStorageLocation;
        [ProtoMember(7)] private string _EquipmentNotes;
        [ProtoMember(8)] private string _D4HReferenceID;
        [ProtoMember(9)] private bool _InService;
        public Gear()
        {
            EquipmentID = Guid.NewGuid();
            InService = true;
        }



        public Guid EquipmentID { get => ID; set => ID = value; }
        public GearCategory Category { get => _Category; set => _Category = value; }
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

        public Gear Clone()
        {
            Gear cloneTo = this.MemberwiseClone() as Gear;
            cloneTo.Category = this.Category.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
