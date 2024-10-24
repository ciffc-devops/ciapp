using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using WF_ICS_ClassLibrary.Models.GeneralModels;

namespace WF_ICS_ClassLibrary.Models
{


    [ProtoContract]
    [Serializable]
    public class OrganizationChart : ICSFormData, ICloneable
    {
        public OrganizationChart()
        {
            AllRoles = new List<ICSRole>();
        }

        [ProtoMember(4)] private List<ICSRole> _AllRoles;
        [ProtoMember(11)] private bool _IsUnifiedCommand;
       



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