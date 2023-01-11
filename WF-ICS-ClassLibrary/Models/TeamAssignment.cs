using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    public class TeamAssignment
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _ResourceIdentifier;
        [ProtoMember(3)] private string _LeaderName;
        [ProtoMember(4)] private Guid _LeaderPersonID;
        [ProtoMember(5)] private int _NumberOfPersons;
        [ProtoMember(6)] private List<TeamMember> _Members;
        [ProtoMember(7)] private string _Contact;
        [ProtoMember(8)] private string _ReportingLocation;
        [ProtoMember(9)] private string _SpecialEquipment;
        [ProtoMember(10)] private string _Remarks;
        [ProtoMember(11)] private string _TacticalAssignment;
        [ProtoMember(12)] private string _SpecialInstructions;
        [ProtoMember(13)] private Guid _ReportsToRoleID;

        public TeamAssignment() { ID = Guid.NewGuid(); Members = new List<TeamMember>(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public string ResourceIdentifier { get => _ResourceIdentifier; set => _ResourceIdentifier = value; }
        public string LeaderName { get => _LeaderName; set => _LeaderName = value; }
        public Guid LeaderPersonID { get => _LeaderPersonID; set => _LeaderPersonID = value; }
        public int NumberOfPersons { get => _NumberOfPersons; set => _NumberOfPersons = value; }
        public List<TeamMember> Members { get => _Members; set => _Members = value; }
        public string Contact { get => _Contact; set => _Contact = value; }
        public string ReportingLocation { get => _ReportingLocation; set => _ReportingLocation = value; }
        public string SpecialEquipment { get => _SpecialEquipment; set => _SpecialEquipment = value; }
        public string Remarks { get => _Remarks; set => _Remarks = value; }
        public string TacticalAssignment { get => _TacticalAssignment; set => _TacticalAssignment = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public Guid ReportsToRoleID { get => _ReportsToRoleID; set => _ReportsToRoleID = value; }


    }
}
