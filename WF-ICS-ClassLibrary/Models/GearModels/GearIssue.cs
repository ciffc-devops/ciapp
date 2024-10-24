using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GearIssue : ICloneable
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
                if (ReturnDate < DateTime.MaxValue && ReturnDate > DateTime.MinValue) { return ReturnDate.ToString(Globals.DateFormat + " HH:mm"); }
                else { return null; }
            }
        }
        public string AssigneeName { get => _AssigneeName; set => _AssigneeName = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public GearIssue() { IssueID = Guid.NewGuid(); IssueDate = DateTime.Now; ReturnDate = DateTime.MaxValue; }
        public GearIssue(Guid id, Guid equipmentit_id, Guid member_id, Guid assignment_id, string name, int op)
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

        public GearIssue Clone()
        {
            return this.MemberwiseClone() as GearIssue;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }


}
