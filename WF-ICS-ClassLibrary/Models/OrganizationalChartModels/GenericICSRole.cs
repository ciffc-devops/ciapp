using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.OrganizationalChartModels
{
    public class GenericICSRole : IGenericICSRole
    {
        public GenericICSRole()
        {

        }

        [ProtoMember(1)] private Guid _GenericRoleID;
        [ProtoMember(2)] private string _RoleName;
        [ProtoMember(3)] private string _RoleNameWithPlaceholder;
        [ProtoMember(4)] private Guid _ReportsToGenericRoleID;
        [ProtoMember(5)] private Guid _SectionID;
        [ProtoMember(6)] private string _MnemonicAbrv;
        [ProtoMember(7)] private string _RoleDescription;
        [ProtoMember(8)] private bool _OnInitialOrgChart;
        [ProtoMember(9)] private bool _RequiresOperationalGroup;
        [ProtoMember(10)] private int _Depth;
        [ProtoMember(11)] private int _ManualSortOrder;
        public Guid GenericRoleID { get => _GenericRoleID; set => _GenericRoleID = value; }
        public string RoleName { get => _RoleName; set => _RoleName = value; }
        public string RoleNameWithPlaceholder { get => _RoleNameWithPlaceholder; set => _RoleNameWithPlaceholder = value; }
        public Guid ReportsToGenericRoleID { get => _ReportsToGenericRoleID; set => _ReportsToGenericRoleID = value; }
        public Guid SectionID { get => _SectionID; set => _SectionID = value; }
        public string MnemonicAbrv { get => _MnemonicAbrv; set => _MnemonicAbrv = value; }
        public string RoleDescription { get => _RoleDescription; set => _RoleDescription = value; }
        public bool OnInitialOrgChart { get => _OnInitialOrgChart; set => _OnInitialOrgChart = value; }
        public bool RequiresOperationalGroup { get => _RequiresOperationalGroup; set => _RequiresOperationalGroup = value; }
        public int Depth { get => _Depth; set => _Depth = value; }
        public int ManualSortOrder { get => _ManualSortOrder; set => _ManualSortOrder = value; }
    }
}
