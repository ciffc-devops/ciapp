using ProtoBuf;
using System;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class TeamStatus : ICloneable
    {

        [ProtoMember(1)] private int _StatusID;
        [ProtoMember(2)] private string _StatusName;
        [ProtoMember(3)] private bool _Active;

        public int StatusID { get => _StatusID; set => _StatusID = value; }
        public string StatusName { get => _StatusName; set => _StatusName = value; }
        public bool Active { get => _Active; set => _Active = value; }


        public TeamStatus() { }
        public TeamStatus(int id, string name, bool active) { StatusID = id; StatusName = name; Active = active; }


       

        public TeamStatus Clone()
        {
            return this.MemberwiseClone() as TeamStatus;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
