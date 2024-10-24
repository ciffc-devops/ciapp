using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WF_ICS_ClassLibrary.Models
{


    [ProtoContract]
    [Serializable]
    public class OrganizationChart : ICloneable
    {
        public OrganizationChart()
        {
            OrganizationalChartID = Guid.NewGuid();
            AllRoles = new List<ICSRole>();
            Active = true;
        }

        [ProtoMember(1)] public int OpPeriod { get; set; }
        [ProtoMember(2)] private DateTime _DatePreparedUTC;
        [ProtoMember(3)] public string PreparedBy { get; set; }
        [ProtoMember(4)] private List<ICSRole> _AllRoles;
        [ProtoMember(5)] private DateTime _LastUpdatedUTC;
        [ProtoMember(6)] private Guid _OrganizationalChartID;
        [ProtoMember(7)] private Guid _PreparedByUserID;
        [ProtoMember(8)] private bool _Active;
        [ProtoMember(9)] private Guid _TaskID;
        [ProtoMember(10)] private string _PreparedByRole;
        [ProtoMember(11)] private bool _IsUnifiedCommand;
        [ProtoMember(12)] private Guid _PreparedByRoleID;
       



        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid PreparedByUserID { get => _PreparedByUserID; set => _PreparedByUserID = value; }
        public Guid PreparedByRoleID { get => _PreparedByRoleID; set => _PreparedByRoleID = value; }
        public string PreparedByRole { get => _PreparedByRole; set => _PreparedByRole = value; }
        public Guid OrganizationalChartID { get => _OrganizationalChartID; set => _OrganizationalChartID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public DateTime DatePrepared { get => _DatePreparedUTC.ToLocalTime(); set => _DatePreparedUTC = value.ToUniversalTime(); }
        public DateTime DatePreparedUTC { get => _DatePreparedUTC; set => _DatePreparedUTC = value; }
        public List<ICSRole> AllRoles { get => _AllRoles; set => _AllRoles = value; }
        public List<ICSRole> ActiveRoles { get => _AllRoles.Where(o => o.Active).ToList(); }
        public List<ICSRole> FilledRoles { get { return AllRoles.Where(o => o.IndividualID != Guid.Empty).ToList(); } }
        public List<ICSRole> FilledActiveRoles { get { return ActiveRoles.Where(o =>o.IndividualID != Guid.Empty).ToList(); } }
        public bool IsUnifiedCommand { get => _IsUnifiedCommand; set => _IsUnifiedCommand = value; }

        public string getNameByRoleName(string rolename, bool defaultUpChain = true)
        {
            ICSRole role = this.GetRoleByName(rolename);
            string name = role.IndividualName;
            if (defaultUpChain && (name == null || name == ""))
            {
                name = getNameByRoleID(role.ReportsTo);
            }

            return name;
        }
      
        public Guid getPersonnelIDByRoleName(string rolename, bool defaultUpChain = true)
        {
            ICSRole role = this.GetRoleByName(rolename);
            Guid id = role.IndividualID;

            if (defaultUpChain && id == Guid.Empty)
            {
                id = getPersonnelIDByRoleName(rolename);
            }

            return id;
        }


        public string getNameByRoleID(Guid id, bool defaultUpChain = true)
        {
            if (ActiveRoles.Any(o => o.RoleID == id))
            {
                string name = ActiveRoles.First(o => o.RoleID == id).IndividualName;
                if (defaultUpChain && string.IsNullOrEmpty(name) && ActiveRoles.First(o => o.RoleID == id).ReportsTo != Guid.Empty)
                {
                    name = getNameByRoleID(ActiveRoles.Where(o => o.RoleID == id).First().ReportsTo);
                }
                return name;
            }
            else { return null; }
        }

        /*
        public Personnel getTeamMemberByRoleID(Guid id, bool defaultUpChain = true)
        {
            if (ActiveRoles.Any(o => o.RoleID == id))
            {
                Personnel member = ActiveRoles.First(o => o.RoleID == id).teamMember;
                if (defaultUpChain && string.IsNullOrEmpty(member.Name) && ActiveRoles.First(o => o.RoleID == id).ReportsTo != Guid.Empty)
                {
                    member = getTeamMemberByRoleID(ActiveRoles.Where(o => o.RoleID == id).First().ReportsTo);
                }
                return member;
            }
            else { return null; }
        }
        */
        public bool HasFilledUnifiedCommandRoles
        {
            get
            {
                ICSRole uc2 = ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.UnifiedCommand2ID);
                if (uc2 != null && this.FilledOrHasFilledChildRoles(uc2)) { return true; }
                ICSRole uc3 = ActiveRoles.FirstOrDefault(o => o.RoleID == Globals.UnifiedCommand3ID);
                if (uc3 != null && this.FilledOrHasFilledChildRoles(uc3)) { return true; }
                return false;
            }
        }


        public OrganizationChart Clone()
        {
            OrganizationChart cloneTo = this.MemberwiseClone() as OrganizationChart;
            cloneTo.AllRoles = new List<ICSRole>();
            foreach (ICSRole role in this.AllRoles)
            {
                cloneTo.AllRoles.Add(role.Clone());
            }
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}