using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{

    [Serializable]
    [ProtoContract]
    public class OperationalGroup
    {
        [ProtoMember(1)] private Guid _ID;
        [ProtoMember(2)] private string _Name;
        [ProtoMember(3)] private Guid _ParentID;
        [ProtoMember(4)] private string _ParentName;
        [ProtoMember(5)] private string _GroupType; //could be: Branch, Division, Task Force, Strike Team, Group, Single Resource    
        [ProtoMember(6)] private int _NumberOfPeople;
        [ProtoMember(7)] private Guid _LeaderICSRoleID;
        [ProtoMember(8)] private string _LeaderICSRoleName;
        [ProtoMember(9)] private Guid _LeaderID;
        [ProtoMember(10)] private string _LeaderName;
        [ProtoMember(11)] private bool _Active;
        [ProtoMember(12)] private int _OpPeriod;
        [ProtoMember(13)] private string _PreparedByName;
        [ProtoMember(14)] private string _PreparedByPosition;
        [ProtoMember(15)] private Guid _PreparedByPositionID;
        [ProtoMember(16)] private DateTime _LastUpatedUTC;
        [ProtoMember(17)] private string _Contact; //used for task forces, strike teams, groups
        [ProtoMember(18)] private string _ShortRemarks;  //used for task forces, strike teams, groups
        [ProtoMember(19)] private string _Comments; //used for task forces, strike teams, groups
        [ProtoMember(20)] private string _TacticalAssignment;//used for branches, divisions
        [ProtoMember(21)] private string _SpecialInstructions;//used for branches, divisions
        [ProtoMember(22)] private List<Guid> _CommsPlanItemIDs; //used for branches, divisions
        [ProtoMember(23)] private string _ResourceID;



        public OperationalGroup() { ID = Guid.NewGuid(); CommsPlanItemIDs = new List<Guid>(); }

        public Guid ID { get => _ID; set => _ID = value; }
        public string ResourceID { get => _ResourceID; set => _ResourceID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public Guid ParentID { get => _ParentID; set => _ParentID = value; }
        public string ParentName { get => _ParentName; set => _ParentName = value; }
        public string GroupType { get => _GroupType; set => _GroupType = value; }
        public int NumberOfPeople { get => _NumberOfPeople; set => _NumberOfPeople = value; }
        public Guid LeaderICSRoleID { get => _LeaderICSRoleID; set => _LeaderICSRoleID = value; }
        public string LeaderICSRoleName { get => _LeaderICSRoleName; set => _LeaderICSRoleName = value; }

        public Guid LeaderID { get => _LeaderID; set => _LeaderID = value; }
        public string LeaderName { get => _LeaderName; set => _LeaderName = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public string PreparedByName { get => _PreparedByName; set => _PreparedByName = value; }
        public string PreparedByPosition { get => _PreparedByPosition; set => _PreparedByPosition = value; }
        public Guid PreparedByPositionID { get => _PreparedByPositionID; set => _PreparedByPositionID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpatedUTC; set => _LastUpatedUTC = value; }
        public List<Guid> CommsPlanItemIDs { get => _CommsPlanItemIDs; set => _CommsPlanItemIDs = value; }

        public string ShortRemarks { get => _ShortRemarks; set => _ShortRemarks = value; }
        public string TacticalAssignment { get => _TacticalAssignment; set => _TacticalAssignment = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public string Comments { get => _Comments; set => _Comments = value; }
        public string Contact { get => _Contact; set => _Contact = value; }


    }



    public static class OperationalGroupTools
    {

    }
}
