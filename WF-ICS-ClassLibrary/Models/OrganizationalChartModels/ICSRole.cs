using ProtoBuf;
using System;
using System.Linq;
using System.Text;
using WF_ICS_ClassLibrary.Models.OrganizationalChartModels;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class ICSRole : SyncableItem, ICloneable, IGenericICSRole
    {
        
        public ICSRole() { _ManualSortOrder = 99; Depth = 0; Active = true; }
       
        public ICSRole(Guid genericId, string name, Guid reports, Guid Section_ID, string pdfname, string pdftitle, Personnel member, int maualSortOrder = 99, int initial_depth = 0, bool includeReportsToInName = false)
        {
            GenericRoleID = genericId; ReportsTo = reports; PDFFieldName = pdfname; IndividualID = member.ID; IndividualName = member.Name; SectionID = Section_ID;  ID = Guid.NewGuid();
            PDFTitleName = pdftitle; Active = true;
            BaseRoleName = name; 
            ManualSortOrder = maualSortOrder; Depth = initial_depth;

            FillInfoFromStaticRole();

        }
        public ICSRole(GenericICSRole fromGeneric)
        {
            Active = true;
            ID = Guid.NewGuid();
            this.FillFromGenericRole(fromGeneric);
        }


        //ID uniquely identifies this role
        [ProtoMember(27)] private Guid _IndividualID; //reference to the personnel table showing the person filling this role
        [ProtoMember(10)] private Guid _SectionID; //tracks which section (ops planning, etc.) that this role is within
        [ProtoMember(5)] private Guid _OrganizationalChartID; //Points to the organization chart this role pertains to. This is used so that roles sent individual can be correctly organized
        [ProtoMember(6)] private Guid _GenericRoleID; //This identifies the role generically. e.g. Planning Section Chief will always have the same OrgChartRoleID
        [ProtoMember(3)] private Guid _ReportsTo; //The unique role id that this role reports to on the org chart
        [ProtoMember(22)] private Guid _OperationalGroupID;




        [ProtoMember(4)] private string _PDFFieldName;
        //[ProtoMember(7)] private Personnel _teamMember;
        [ProtoMember(11)] private string _ReportsToRoleName;
        [ProtoMember(12)] private int _ManualSortOrder;
        [ProtoMember(13)] private string _PDFTitleName;
        [ProtoMember(14)] private int _Depth;
        [ProtoMember(15)] private string _RoleDescription;
        [ProtoMember(16)] private string _MnemonicAbrv;
        //[ProtoMember(17)] private bool _IncludeReportsToInName;
        [ProtoMember(18)] private string _BaseRoleName;


       // [ProtoMember(23)] private Guid _DivisionID;
        [ProtoMember(24)] private string _SectionName;
        
        [ProtoMember(26)] private bool _IsPlaceholder;

        [ProtoMember(28)] private string _IndividualName;
        [ProtoMember(29)] private Guid _ReportsToGenericRoleID;
        [ProtoMember(30)] private string _RoleNameWithPlaceholder;
        [ProtoMember(31)] private bool _OnInitialOrgChart;
        [ProtoMember(32)] private bool _RequiresOperationalGroup;
        [ProtoMember(33)] private string _OperationalGroupName;

        public Guid RoleID { get => ID; set => ID = value; }
        public string RoleName
        {
            get
            {
                if (!string.IsNullOrEmpty(RoleNameWithPlaceholder))
                {
                    if (RequiresOperationalGroup && !string.IsNullOrEmpty(OperationalGroupName))
                    {
                        return RoleNameWithPlaceholder.Replace("[OpGroupName]", OperationalGroupName);
                    }
                    else if (!RequiresOperationalGroup && !string.IsNullOrEmpty(ReportsToRoleName))
                    {
                        return RoleNameWithPlaceholder.Replace("[ReportsToName]", ReportsToRoleName);
                    }
                }
                return BaseRoleName;
            }
        }


        public string RoleNameForDropdown
        {
            get
            {
                StringBuilder name = new StringBuilder();

                for(int x = 0; x < Depth; x++)
                {
                    name.Append(".. ");
                }
                name.Append(RoleName);
                return name.ToString();
            }
        }
        public string RoleNameWithSection
        {
            get { if (!string.IsNullOrEmpty(SectionName)) { return SectionName + " > " + RoleName; } else { return "General > " + RoleName; } }
        }
        public Guid SectionID { get => _SectionID; set { _SectionID = value; _SectionName = OrganizationalChartTools.GetSectionName(value); } }
        public string SectionName { get => _SectionName;}


        public Guid ReportsTo { get => _ReportsTo; set => _ReportsTo = value; }
        public string PDFFieldName { get => _PDFFieldName; set => _PDFFieldName = value; }
        public string PDFTitleName { get => _PDFTitleName; set => _PDFTitleName = value; }
        public string IndividualName { get => _IndividualName; set => _IndividualName = value; }
        public string RoleNameWithIndividual
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleName + " - " + IndividualName; }
                else if (RoleID == Globals.IncidentCommanderGenericID && !RoleName.Equals("Incident Commander")) { return RoleName; }
                else { return RoleName + " - unassigned"; }
            }
        }
        public string RoleNameWithIndividualAssigned
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleName + " - " + IndividualName; }
                else if (RoleID == Globals.IncidentCommanderGenericID && !RoleName.Equals("Incident Commander")) { return RoleName; }
                else { return RoleName; }
            }
        }
        public string RoleNameWithIndividualAndDepth
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleNameForDropdown + " - " + IndividualName; }
                if (string.IsNullOrEmpty(IndividualName) && string.IsNullOrEmpty(RoleName)) { return string.Empty; }
                else if (RoleID == Globals.IncidentCommanderGenericID && !RoleName.Equals("Incident Commander")) { return RoleNameForDropdown; }
                else { return RoleNameForDropdown + " - unassigned"; }
            }
        }


        public Guid IndividualID        { get => _IndividualID; set => _IndividualID = value; }


        public Guid OrganizationalChartID { get => _OrganizationalChartID; set => _OrganizationalChartID = value; }

        public Guid GenericRoleID { get => _GenericRoleID; set => _GenericRoleID = value; }
        public string ReportsToRoleName { get => _ReportsToRoleName; set => _ReportsToRoleName = value; }
        public int ManualSortOrder { get => _ManualSortOrder; set => _ManualSortOrder = value; }
        //public bool IncludeReportsToInName { get => _IncludeReportsToInName; set => _IncludeReportsToInName = value; }
        public string BaseRoleName { get => _BaseRoleName; set => _BaseRoleName = value; }
        public bool IsPlaceholder { get => _IsPlaceholder; set => _IsPlaceholder = value; }
        public bool IsTFST
        {
            get
            {
                if (string.IsNullOrEmpty(MnemonicAbrv)) { return false; }
                else if (MnemonicAbrv.Equals("STLD") || MnemonicAbrv.Equals("TFLD")) { return true; }
                return false;
            }
        }
        public bool IsBranch
        {
            get
            {
                if (string.IsNullOrEmpty(MnemonicAbrv) || !IsOpGroupSup || string.IsNullOrEmpty(RoleName)) { return false; }
                else if (RoleName.Contains("Branch")) { return true; }
                return false;

            }
        }


        private void FillInfoFromStaticRole()
        {
            if (OrganizationalChartTools.GenericRolesCache.Any(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase) ))
            {
                GenericICSRole staticRole = OrganizationalChartTools.GenericRolesCache.FirstOrDefault(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase) );
                MnemonicAbrv = staticRole.MnemonicAbrv;
                RoleDescription = staticRole.RoleDescription;
                if (SectionID == Guid.Empty) { SectionID = staticRole.SectionID; }
                GenericRoleID = staticRole.GenericRoleID;
                ReportsTo = staticRole.ReportsToGenericRoleID;
                RoleDescription = staticRole.RoleDescription;
                MnemonicAbrv = staticRole.MnemonicAbrv;
                RoleNameWithPlaceholder = staticRole.RoleNameWithPlaceholder;
                OnInitialOrgChart = staticRole.OnInitialOrgChart;
                RequiresOperationalGroup = staticRole.RequiresOperationalGroup;
                ManualSortOrder = staticRole.ManualSortOrder;
                BaseRoleName = staticRole.RoleName;
            }
        }

      
        



        public int Depth { get => _Depth; set => _Depth = value; }

        public string RoleDescription { get => _RoleDescription; set => _RoleDescription = value; }
        public string MnemonicAbrv { get => _MnemonicAbrv; set => _MnemonicAbrv = value; }


        public bool AllowEditName
        {
            get
            {
                if(!string.IsNullOrEmpty(PDFTitleName)) { return true; }

                return AllowEditReportsTo;
            }
        }
        public bool AllowEditReportsTo { get { if (IsOpGroupSup || !string.IsNullOrEmpty(PDFFieldName)) { return false; } else { return true; } } }
        public bool AllowDelete { get => string.IsNullOrEmpty(PDFFieldName); }

        public bool IsOpGroupSup { get => RequiresOperationalGroup; set => RequiresOperationalGroup = value; }

        public Guid OperationalGroupID { get => _OperationalGroupID; set => _OperationalGroupID = value; }
        public string RoleNameWithPlaceholder { get => _RoleNameWithPlaceholder; set => _RoleNameWithPlaceholder = value; }
        public Guid ReportsToGenericRoleID { get => _ReportsToGenericRoleID; set => _ReportsToGenericRoleID = value; }
        public bool OnInitialOrgChart { get => _OnInitialOrgChart; set => _OnInitialOrgChart = value; }
        public bool RequiresOperationalGroup { get => _RequiresOperationalGroup; set => _RequiresOperationalGroup = value; }
        public string OperationalGroupName { get => _OperationalGroupName; set => _OperationalGroupName = value; }

        //public Guid DivisionID { get => _DivisionID; set => _DivisionID = value; }


        public ICSRole Clone()
        {
            ICSRole cloneTo = this.MemberwiseClone() as ICSRole;
            //cloneTo.teamMember = this.teamMember.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }
}