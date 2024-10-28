using ProtoBuf;
using System;
using System.Linq;
using System.Text;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class ICSRole : SyncableItem, ICloneable
    {
        [ProtoMember(1)] private Guid _RoleID;
        [ProtoMember(2)] private string _RoleName;
        [ProtoMember(3)] private Guid _ReportsTo;
        [ProtoMember(4)] private string _PDFFieldName;
        [ProtoMember(5)] private Guid _OrganizationalChartID;
        [ProtoMember(6)] private Guid _OrgChartRoleID;
        //[ProtoMember(7)] private Personnel _teamMember;
        [ProtoMember(10)] private Guid _SectionID;
        [ProtoMember(11)] private string _ReportsToRoleName;
        [ProtoMember(12)] private int _ManualSortOrder;
        [ProtoMember(13)] private string _PDFTitleName;
        [ProtoMember(14)] private int _Depth;
        [ProtoMember(15)] private string _RoleDescription;
        [ProtoMember(16)] private string _Mnemonic;
        [ProtoMember(17)] private bool _IncludeReportsToInName;
        [ProtoMember(18)] private string _BaseRoleName;


        [ProtoMember(22)] private Guid _OperationalGroupID;
       // [ProtoMember(23)] private Guid _DivisionID;
        [ProtoMember(24)] private string _SectionName;
        [ProtoMember(25)] private bool _IsOpGroupSup;
        [ProtoMember(26)] private bool _IsPlaceholder;
        [ProtoMember(27)] private Guid _IndividualID;

        [ProtoMember(28)] private string _IndividualName;


        public Guid RoleID { get => _RoleID; set => _RoleID = value; }
        public string RoleName { get => _RoleName; set => _RoleName = value; }
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
        public Guid SectionID { get => _SectionID; set { _SectionID = value; _SectionName = OrgChartTools.GetSectionName(value); } }
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
                else if (RoleID == Globals.IncidentCommanderID && !RoleName.Equals("Incident Commander")) { return RoleName; }
                else { return RoleName + " - unassigned"; }
            }
        }
        public string RoleNameWithIndividualAssigned
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleName + " - " + IndividualName; }
                else if (RoleID == Globals.IncidentCommanderID && !RoleName.Equals("Incident Commander")) { return RoleName; }
                else { return RoleName; }
            }
        }
        public string RoleNameWithIndividualAndDepth
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleNameForDropdown + " - " + IndividualName; }
                if (string.IsNullOrEmpty(IndividualName) && string.IsNullOrEmpty(RoleName)) { return string.Empty; }
                else if (RoleID == Globals.IncidentCommanderID && !RoleName.Equals("Incident Commander")) { return RoleNameForDropdown; }
                else { return RoleNameForDropdown + " - unassigned"; }
            }
        }


        public Guid IndividualID        { get => _IndividualID; set => _IndividualID = value; }


        public Guid OrganizationalChartID { get => _OrganizationalChartID; set => _OrganizationalChartID = value; }

        public Guid OrgChartRoleID { get => _OrgChartRoleID; set => _OrgChartRoleID = value; }
        public string ReportsToRoleName { get => _ReportsToRoleName; set => _ReportsToRoleName = value; }
        public int ManualSortOrder { get => _ManualSortOrder; set => _ManualSortOrder = value; }
        public bool IncludeReportsToInName { get => _IncludeReportsToInName; set => _IncludeReportsToInName = value; }
        public string BaseRoleName { get => _BaseRoleName; set => _BaseRoleName = value; }
        public bool IsPlaceholder { get => _IsPlaceholder; set => _IsPlaceholder = value; }
        public bool IsTFST
        {
            get
            {
                if (string.IsNullOrEmpty(Mnemonic)) { return false; }
                else if (Mnemonic.Equals("STLD") || Mnemonic.Equals("TFLD")) { return true; }
                return false;
            }
        }
        public bool IsBranch
        {
            get
            {
                if (string.IsNullOrEmpty(Mnemonic) || !IsOpGroupSup || string.IsNullOrEmpty(RoleName)) { return false; }
                else if (RoleName.Contains("Branch")) { return true; }
                return false;

            }
        }


        public ICSRole() {  OrgChartRoleID = System.Guid.NewGuid(); RoleID = System.Guid.NewGuid(); _ManualSortOrder = 99; Depth = 0; Active = true; }
        /*
        public ICSRole(Guid id, string name, Guid reports, string pdfname, string person_name = "", Guid person_id = new Guid())
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; IndividualName = person_name; IndividualID = person_id;
        }*/
        public ICSRole(Guid id, string name, Guid reports, Guid Section_ID, string pdfname, Personnel member, int maualSortOrder = 99, int initial_depth = 0, bool includeReportsToInName = false)
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; IndividualID = member.ID; IndividualName = member.Name; SectionID = Section_ID; _OrgChartRoleID = System.Guid.NewGuid();
            ManualSortOrder = maualSortOrder; Depth = initial_depth; Active = true;
            _BaseRoleName = name; _IncludeReportsToInName = includeReportsToInName;
            FillInfoFromStaticRole();
        }
        public ICSRole(Guid id, string name, Guid reports, Guid Section_ID, string pdfname, string pdftitle, Personnel member, int maualSortOrder = 99, int initial_depth = 0, bool includeReportsToInName = false)
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; IndividualID = member.ID; IndividualName = member.Name; SectionID = Section_ID; _OrgChartRoleID = System.Guid.NewGuid();
            PDFTitleName = pdftitle; Active = true;
            _BaseRoleName = name; _IncludeReportsToInName = includeReportsToInName;
            ManualSortOrder = maualSortOrder; Depth = initial_depth;

            FillInfoFromStaticRole();
            
        }

        private void FillInfoFromStaticRole()
        {
            if (OrgChartTools.staticRoles.Any(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase) || o.BaseRoleName.Equals(BaseRoleName, StringComparison.InvariantCultureIgnoreCase)))
            {
                ICSRole staticRole = OrgChartTools.staticRoles.FirstOrDefault(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase) || o.BaseRoleName.Equals(BaseRoleName, StringComparison.InvariantCultureIgnoreCase));
                Mnemonic = staticRole.Mnemonic;
                RoleDescription = staticRole.RoleDescription;
                _IncludeReportsToInName = staticRole.IncludeReportsToInName;
            }
        }

        public ICSRole(string name, Guid Section, string mnemonic, string description, bool includeReportsToInName = false)
        {
            RoleID = Guid.NewGuid();
            RoleName = name;
            _BaseRoleName = name;
            SectionID = Section;
            RoleDescription = description;
            Mnemonic = mnemonic;
            _IncludeReportsToInName = includeReportsToInName;
            IndividualName = string.Empty;
            IndividualID = Guid.Empty;
        }



        public int Depth { get => _Depth; set => _Depth = value; }

        public string RoleDescription { get => _RoleDescription; set => _RoleDescription = value; }
        public string Mnemonic { get => _Mnemonic; set => _Mnemonic = value; }


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

        public bool IsOpGroupSup { get => _IsOpGroupSup; set => _IsOpGroupSup = value; }

        public Guid OperationalGroupID { get => _OperationalGroupID; set => _OperationalGroupID = value; }
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