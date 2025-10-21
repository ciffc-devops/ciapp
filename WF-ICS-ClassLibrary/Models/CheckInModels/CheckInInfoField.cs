using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class CheckInInfoField : ICloneable
    {
        public CheckInInfoField() { ID = Guid.NewGuid(); DateValue = DateTime.Now; }
        public CheckInInfoField(Guid id, string name, string type, string group, bool visitor, bool person, bool vehicle, bool crew, bool equip, bool op, bool reqd, string tooltip)
        {
            ID = id; Name = name; FieldType = type; FieldGroup = group; IsRequired = reqd; ToolTipText = tooltip;
            UseForVisitor = visitor; UseForPersonnel = person; UseForVehicle = vehicle; UseForCrew = crew; UseForEquipment = equip; UseForOperator = op; DateValue = DateTime.Now;
        }
        public CheckInInfoField(Guid id, string name, string type, string group, string tooltip = null, bool reqd = false)
        {
            ID = id; Name = name; FieldType = type; FieldGroup = group; IsRequired = reqd; ToolTipText = tooltip; DateValue = DateTime.Now;
        }



        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private string _FieldType;
        [ProtoMember(4)] private string _FieldGroup;
        [ProtoMember(5)] private int _SortOrder;
        [ProtoMember(6)] private string _StringValue;
        [ProtoMember(7)] private bool _BoolValue;
        [ProtoMember(8)] private int _IntValue;
        [ProtoMember(9)] private bool _UseForVisitor;
        [ProtoMember(10)] private bool _UseForPersonnel;
        //[ProtoMember(11)] private bool _UseForVehicle;
        [ProtoMember(12)] private bool _UseForCrew;
        [ProtoMember(13)] private DateTime _DateValue;
        [ProtoMember(14)] private bool _IsRequired;
        [ProtoMember(15)] private string _ToolTipText;
        [ProtoMember(16)] private bool _UseForEquipment;
        [ProtoMember(17)] private bool _UseForOperator;
        [ProtoMember(18)] private decimal _DecimalValue;
        [ProtoMember(19)] private bool _UseForAircraft;

        public Guid ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string FieldType { get => _FieldType; set => _FieldType = value; }
        public string FieldGroup { get => _FieldGroup; set => _FieldGroup = value; }
        public int SortOrder { get => _SortOrder; set => _SortOrder = value; }
        public string StringValue { get => _StringValue; set => _StringValue = value; }
        public bool BoolValue { get => _BoolValue; set => _BoolValue = value; }
        public int IntValue { get => _IntValue; set => _IntValue = value; }
        public decimal DecimalValue { get => _DecimalValue; set => _DecimalValue = value; }
        public bool UseForVisitor { get => _UseForVisitor; set => _UseForVisitor = value; }
        public bool UseForPersonnel { get => _UseForPersonnel; set => _UseForPersonnel = value; }
        public bool UseForVehicle { get => _UseForEquipment; set => _UseForEquipment = value; }
        public bool UseForCrew { get => _UseForCrew; set => _UseForCrew = value; }
        public DateTime DateValue { get => _DateValue; set => _DateValue = value; }
        public bool IsRequired { get => _IsRequired; set => _IsRequired = value; }
        public string ToolTipText { get => _ToolTipText; set => _ToolTipText = value; }
        public bool UseForEquipment { get => _UseForEquipment; set => _UseForEquipment = value; }
        public bool UseForOperator { get => _UseForOperator; set => _UseForOperator = value; }
        public bool UseForAircraft { get => _UseForAircraft; set => _UseForAircraft = value; }


        public object GetValue()
        {
            switch (FieldType)
            {
                case "Bool": return BoolValue;
                case "DateTime": return DateValue;
                case "Int": return IntValue;
                case "Decimal": return DecimalValue;
                case "Time": return DateValue;
                default: return StringValue;
            }
        }


        public CheckInInfoField Clone()
        {
            CheckInInfoField cloneTo = this.MemberwiseClone() as CheckInInfoField;
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
