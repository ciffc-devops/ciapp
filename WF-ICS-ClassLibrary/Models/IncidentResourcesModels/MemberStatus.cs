using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class MemberStatus : ICloneable
    {
        public MemberStatus()
        {
        }
        [ProtoMember(1)] private Guid _AssignmentID;
        // [ProtoMember(2)]
        //private ICSRole _icsrole = new ICSRole();
        [ProtoMember(3)] private DateTime _signInTime;
        [ProtoMember(4)] private DateTime _signOutTime;
        [ProtoMember(5)] private decimal _kms;

        [ProtoMember(6)] private string _MemberName;
        [ProtoMember(7)] private Guid _MemberID;
        [ProtoMember(8)] private Guid _OrganizationID;
        [ProtoMember(9)] private string _OrganizationName;
        [ProtoMember(10)] private int _AssignmentNumber;
        [ProtoMember(11)] private string _AssignmentName;
        [ProtoMember(12)] private string _CurrentAssignmentStatus;

        [ProtoMember(13)] private string _ICSRoleName;
        [ProtoMember(14)] private Guid _ICSRoleID;
        [ProtoMember(15)] private DateTime _LastDayWorked;
        [ProtoMember(16)] private string _Callsign;
        [ProtoMember(17)] private Guid _CheckInRecordID;
        [ProtoMember(18)] private Guid _CheckOutRecordID;
        [ProtoMember(19)] private string _InitialRoleName;

        public Guid AssignmentID { get => _AssignmentID; set => _AssignmentID = value; }

        public DateTime SignInTime { get { return _signInTime; } set { _signInTime = value; } }
        public string SignInTimeAsText
        {
            get
            {
                if (_signInTime > DateTime.MinValue) { return _signInTime.ToString(Globals.DateFormat + " HH:mm"); }
                else { return "Not checked in"; }
            }
        }
        public DateTime SignOutTime { get { return _signOutTime; } set { _signOutTime = value; } }
        public string SignOutTimeOrBlank
        {
            get
            {
                if (_signOutTime < DateTime.MaxValue)
                {
                    return string.Format("{0:" + Globals.DateFormat + " HH:mm}", _signOutTime);
                }
                else
                {
                    return null;
                }
            }
        }
        public bool IsSignedOut
        {
            get
            {
                return _signOutTime < DateTime.MaxValue;
            }
        }
        public double HoursOnTask
        {
            get
            {
                if (IsSignedOut && SignInTime > DateTime.MinValue && SignInTime < DateTime.MaxValue && SignOutTime > DateTime.MinValue && SignOutTime < DateTime.MaxValue)
                {
                    TimeSpan ts = SignOutTime - SignInTime;
                    return ts.TotalHours;
                }
                else { return 0; }
            }
        }

        public int AssignmentNumber { get => _AssignmentNumber; set => _AssignmentNumber = value; }
        public string AssignmentName { get => _AssignmentName; set => _AssignmentName = value; }
        public string AssignmentNameWthNumber { get { if (_AssignmentNumber > 0) { return _AssignmentNumber + " " + _AssignmentName; } else { return _AssignmentName; } } }
        public string AssignmentStatus { get => _CurrentAssignmentStatus; set => _CurrentAssignmentStatus = value; }


        //public ICSRole currentICSRole { get { return _icsrole; } set { _icsrole = value; } }
        public string ICSRoleName { get => _ICSRoleName; set => _ICSRoleName = value; }
        public Guid ICSRoleID { get => _ICSRoleID; set => _ICSRoleID = value; }

        //public string ICSRoleName { get { return currentICSRole.RoleName; } }
        public string getCurrentActivityName { get { if (ICSRoleID != Guid.Empty && AssignmentNameWthNumber != "Signed Out") { return ICSRoleName; } else { return AssignmentNameWthNumber; } } }
        public bool IsAssigned
        {
            get
            {
                if (ICSRoleID != Guid.Empty) { return true; }
                if(AssignmentID != Guid.Empty) { return true; }
                return false;
            }
        }

        public decimal KMs { get => _kms; set => _kms = value; }

        public string MemberName { get => _MemberName; set => _MemberName = value; }
        public Guid MemberID { get => _MemberID; set => _MemberID = value; }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }
        public string OrganizationName { get => _OrganizationName; set => _OrganizationName = value; }
        public DateTime LastDayWorked { get => _LastDayWorked; set => _LastDayWorked = value; }
        public string LastDayWorkedAsStr
        {
            get
            {
                if (LastDayWorked > DateTime.MinValue) { return LastDayWorked.ToString(Globals.DateFormat); }
                else { return null; }
            }
        }

        public Guid CheckInRecordID { get => _CheckInRecordID; set => _CheckInRecordID = value; }

        public Guid CheckOutRecordID { get => _CheckOutRecordID; set => _CheckOutRecordID = value; }

        public string Callsign { get => _Callsign; set => _Callsign = value; }

        public string InitialRoleName { get => _InitialRoleName; set => _InitialRoleName = value; }



        public void setTeamMember(Personnel member)
        {
            MemberName = member.Name;
            MemberID = member.PersonID;
            _OrganizationName = member.Agency;
            Callsign = member.CallSign;

        }
        public MemberStatus Clone()
        {
            return this.MemberwiseClone() as MemberStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }

}
