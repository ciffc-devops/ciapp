﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WF_ICS_ClassLibrary.Utilities;

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

    [ProtoContract]
    [Serializable]
    public class ICSRole : ICloneable
    {
        [ProtoMember(1)] private Guid _RoleID;
        [ProtoMember(2)] private string _RoleName;
        [ProtoMember(3)] private Guid _ReportsTo;
        [ProtoMember(4)] private string _PDFFieldName;
        [ProtoMember(5)] private Guid _OrganizationalChartID;
        [ProtoMember(6)] private Guid _OrgChartRoleID;
        //[ProtoMember(7)] private Personnel _teamMember;
        [ProtoMember(8)] private DateTime _LastUpdatedUTC;
        [ProtoMember(9)] private int _OpPeriod;
        [ProtoMember(10)] private Guid _SectionID;
        [ProtoMember(11)] private string _ReportsToRoleName;
        [ProtoMember(12)] private int _ManualSortOrder;
        [ProtoMember(13)] private string _PDFTitleName;
        [ProtoMember(14)] private int _Depth;
        [ProtoMember(15)] private string _RoleDescription;
        [ProtoMember(16)] private string _Mnemonic;
        [ProtoMember(17)] private bool _IncludeReportsToInName;
        [ProtoMember(18)] private string _BaseRoleName;
        [ProtoMember(19)] private bool _Active;


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
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string ReportsToRoleName { get => _ReportsToRoleName; set => _ReportsToRoleName = value; }
        public int ManualSortOrder { get => _ManualSortOrder; set => _ManualSortOrder = value; }
        public bool IncludeReportsToInName { get => _IncludeReportsToInName; set => _IncludeReportsToInName = value; }
        public string BaseRoleName { get => _BaseRoleName; set => _BaseRoleName = value; }
        public bool Active { get => _Active; set => _Active = value; }
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



        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
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

   
    public static class OrgChartTools
    {
        private static List<ICSRole> _staticRoles = null;
        public static List<ICSRole> staticRoles
        {
            get
            {
                if (_staticRoles == null) { _staticRoles = GetAllRoles(); }
                return _staticRoles;
            }
        }

        public static void UnassignThisAndSubordinateRoles(this OrganizationChart chart, ICSRole roleToClear, bool sendUpsertCommands = true)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            roleToClear.IndividualID = Guid.Empty;
           // roleToClear.teamMember = blankMember;
            roleToClear.IndividualName = null;
            if (sendUpsertCommands) { Globals.incidentService.UpsertICSRole(roleToClear); }
            foreach (ICSRole role in chart.FilledActiveRoles.Where(o => o.ReportsTo == roleToClear.RoleID))
            {
                chart.UnassignThisAndSubordinateRoles(role, sendUpsertCommands);
            }
        }

        public static bool FilledOrHasFilledChildRoles(this OrganizationChart chart, ICSRole role)
        {
            if (role.IndividualID != Guid.Empty) { return true; }
            foreach(ICSRole childRole in chart.ActiveRoles.Where(o=>o.ReportsTo == role.RoleID))
            {
                if (chart.FilledOrHasFilledChildRoles(childRole))
                {
                    return true;
                }
            }
            return false;
        }


        public static void UpdateRoleNames(this OrganizationChart chart, int OpPeriod)
        {
            foreach(ICSRole role in chart.AllRoles.Where(o => o.IncludeReportsToInName && o.OpPeriod == OpPeriod))
            {
                chart.UpdateRoleName(role, true);
            }
        }

        public static void UpdateRoleName(this OrganizationChart chart, ICSRole role, bool sendUpsertCommand)
        {
            string oldName = role.RoleName;
            string newName = role.BaseRoleName;
            if (role.ReportsTo != Guid.Empty && chart.AllRoles.Any(o => o.RoleID == role.ReportsTo))
            {
                newName += " " + chart.AllRoles.First(o => o.RoleID == role.ReportsTo).RoleName;
            }
            if (!oldName.Equals(newName))
            {
                role.RoleName = newName;
                if (sendUpsertCommand)
                {
                    Globals.incidentService.UpsertICSRole(role);
                }
            }
        }

        public static void UpdateRoleName(this OrganizationChart chart, Guid roleID, bool sendUpsertCommand)
        {
            if(chart.AllRoles.Any(o=>o.RoleID == roleID))
            {
                ICSRole role = chart.AllRoles.First(o => o.RoleID == roleID);
                chart.UpdateRoleName(role, sendUpsertCommand);
            }
        }


        public static List<ICSRole> GetRolesForAssignmentList(this OrganizationChart org, Guid BranchID, int maxDepth = 0, int MaxCount = 0)
        {

            List<ICSRole> roles = new List<ICSRole>(); 
            roles.Add( org.ActiveRoles.FirstOrDefault(o => o.RoleID == BranchID));
            foreach(ICSRole role in org.ActiveRoles.Where(o=>o.ReportsTo == BranchID && o.SectionID == BranchID))
            {
                roles.Add(role);
                List<ICSRole> childRoles = org.GetChildRoles(role.RoleID, true, true);
                if(maxDepth > 0) { childRoles = childRoles.Where(o => o.Depth <= maxDepth).ToList(); }
                roles.AddRange(childRoles);
            }

            if(MaxCount > 0 && roles.Count > MaxCount && (maxDepth > 1))
            {
                int newDepth = roles.Max(o => o.Depth) - 1;
                roles = org.GetRolesForAssignmentList(BranchID, newDepth, MaxCount);
            }


            return roles;
        }

        public static void SwitchToUnifiedCommand(this OrganizationChart org)
        {
            if (!org.IsUnifiedCommand)
            {
                _ = org.ActiveRoles.AddUnifiedCommandRoles(true);
                org.SortRoles();

                ICSRole ic = org.ActiveRoles.First(o => o.RoleID == Globals.IncidentCommanderID);
                ICSRole uc1 = org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID);
                if(ic.IndividualID != Guid.Empty && uc1.IndividualID == Guid.Empty)
                {
                    uc1.IndividualID = ic.IndividualID; uc1.IndividualName = ic.IndividualName;
                }
                /*
                if (ic.teamMember != null && ic.teamMember.PersonID != Guid.Empty && (uc1.teamMember == null || uc1.teamMember.PersonID == Guid.Empty))
                {
                    uc1.teamMember = org.ActiveRoles.First(o => o.RoleID == Globals.IncidentCommanderID).teamMember.Clone();
                   
                    ic.teamMember = new Personnel(Guid.Empty);
                    
                }*/
                ic.RoleName = "Unified Command";
                Globals.incidentService.UpsertICSRole(org.ActiveRoles.First(o => o.RoleID == Globals.IncidentCommanderID));
                


                org.IsUnifiedCommand = true;
            }
        }

        public static void SwitchToSingleIC(this OrganizationChart org)
        {
            if (org.IsUnifiedCommand)
            {
                ICSRole ic = org.ActiveRoles.First(o => o.RoleID == Globals.IncidentCommanderID);
                ICSRole uc1 = org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID);
                if (uc1.IndividualID == Guid.Empty && org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID).IndividualID != Guid.Empty) { uc1 = org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID); }
                if (uc1.IndividualID == Guid.Empty && org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID).IndividualID != Guid.Empty) { uc1 = org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID); }

                ic.RoleName = "Incident Commander";

                if (uc1.IndividualID != Guid.Empty)
                {
                    //ic.teamMember = uc1.teamMember.Clone();
                    ic.IndividualID = uc1.IndividualID;
                    ic.IndividualName = uc1.IndividualName;
                    uc1.IndividualID = Guid.Empty;
                    uc1.IndividualName = string.Empty;


                }
                Globals.incidentService.UpsertICSRole(ic);
                if (org.ActiveRoles.Any(o => o.RoleID == Globals.UnifiedCommand1ID)) { Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID), org.OpPeriod); }
                if (org.ActiveRoles.Any(o => o.RoleID == Globals.UnifiedCommand2ID))
                {
                    Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID), org.OpPeriod);
                }
                if (org.ActiveRoles.Any(o => o.RoleID == Globals.UnifiedCommand3ID))
                {
                    Globals.incidentService.DeleteICSRole(org.ActiveRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID), org.OpPeriod);
                }





                org.IsUnifiedCommand = false;
            }
        }

   

        public static List<ICSRole> GetBlankRolesBasedOnThisChart(OrganizationChart ogOrgChart, int newOpPeriod, Guid newChartID)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();

            foreach(ICSRole role in ogOrgChart.ActiveRoles)
            {
                ICSRole newRole = role.Clone();
                newRole.IndividualName = string.Empty; newRole.IndividualID = Guid.Empty;
                newRole.OrganizationalChartID = newChartID;
                newRole.OpPeriod = newOpPeriod;
                newRole.OrgChartRoleID = Guid.NewGuid();
                AllRoles.Add(newRole);
            }
            return AllRoles;
        }

        public static ICSRole GetGenericRoleByID(Guid id)
        {
            List<ICSRole> roles = GetBlankPrimaryRoles();
            if (roles.Any(o => o.RoleID == id)) { return roles.First(o => o.RoleID == id); }
            else { return null; }
        }

        public static List<ICSRole> GetChildRoles(this OrganizationChart orgChart, Guid ParentRoleID, bool getAllDecendants = true, bool ExcludeAgencyReps = true)
        {
            List<ICSRole> roles = new List<ICSRole>();
            foreach(ICSRole ro in orgChart.ActiveRoles.Where(o => o.ReportsTo == ParentRoleID))
            {
                roles.Add(ro);
                if (getAllDecendants)
                {
                    roles.AddRange(orgChart.GetChildRoles(ro.RoleID, getAllDecendants, ExcludeAgencyReps));
                }
            }

            if (ExcludeAgencyReps) { roles = roles.Where(o => !o.RoleName.Equals("Agency Representative")).ToList(); }
            return roles;
        }

        public static List<ICSRole> AddUnifiedCommandRoles(this List<ICSRole> list, bool upsertToIncident = false)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;


            if (upsertToIncident)
            {
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand1ID))
                {
                    ICSRole uc1 = new ICSRole(Globals.UnifiedCommand1ID, "Unified Command 1", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName1", "UCTitle1", blankMember, 0, 0);
                    uc1.OpPeriod = list[0].OpPeriod;
                    uc1.OrganizationalChartID = list[0].OrganizationalChartID;
                    Globals.incidentService.UpsertICSRole(uc1);
                }
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand2ID))
                {
                    ICSRole uc2 = new ICSRole(Globals.UnifiedCommand2ID, "Unified Command 2", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName2", "UCTitle2", blankMember, 0, 0);
                    uc2.OpPeriod = list[0].OpPeriod;
                    uc2.OrganizationalChartID = list[0].OrganizationalChartID;
                    Globals.incidentService.UpsertICSRole(uc2);
                }
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand3ID))
                {
                    ICSRole uc3 = new ICSRole(Globals.UnifiedCommand3ID, "Unified Command 3", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName3", "UCTitle3", blankMember, 0, 0);
                    uc3.OpPeriod = list[0].OpPeriod;
                    uc3.OrganizationalChartID = list[0].OrganizationalChartID;
                    Globals.incidentService.UpsertICSRole(uc3);
                }
            }
            else
            {
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand1ID)) { list.Add(new ICSRole(Globals.UnifiedCommand1ID, "Unified Command 1", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName1", "UCTitle1", blankMember, 0, 0)); }
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand2ID)) { list.Add(new ICSRole(Globals.UnifiedCommand2ID, "Unified Command 2", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName2", "UCTitle2", blankMember, 0, 0)); }
                if (!list.Any(o => o.RoleID == Globals.UnifiedCommand3ID)) { list.Add(new ICSRole(Globals.UnifiedCommand3ID, "Unified Command 3", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "UCName3", "UCTitle3", blankMember, 0, 0)); }

            }

            return list;
        }

        public static bool RoleIsEmpty(this ICSRole role)
        {
            if (role.IndividualID == Guid.Empty) { return true; }
            else { return false; }
        }


        public static List<ICSRole> GetBlankPrimaryRoles(bool UnifiedCommand = false)
        {
            Personnel blankMember = new Personnel();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();
            //AllRoles.Add(new ICSRole(new Guid("98649093-2C0D-4D23-9EC1-2AF16ED83B2A"), "SAR Commander", Guid.Empty, "Text1", blankMember));
            AllRoles.Add(new ICSRole(Globals.IncidentCommanderID, "Incident Commander", Guid.Empty, Globals.IncidentCommanderID, "IncidentCommander", blankMember, 0, 0));
            if (UnifiedCommand)
            {
                AllRoles = AllRoles.AddUnifiedCommandRoles();
            }

            AllRoles.Add(new ICSRole(new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA"), "Deputy", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "DeputyIC", "TitleDeputyIC", blankMember, 1, 1, true));
            AllRoles.FirstOrDefault(o => o.RoleID == new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA")).RoleName = "Deputy Incident Commander";

            AllRoles.Add(new ICSRole(Globals.SafetyOfficerID, "Safety Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "SafetyOfficer", blankMember, 2, 1));
            AllRoles.Add(new ICSRole(new Guid("8428ed1e-80de-4b5d-a7ab-ae48ad5f1bce"), "Clerk", Globals.SafetyOfficerID, Globals.IncidentCommanderID, "NameSafety1", "TitleSafety1", blankMember, 2, 1));

            AllRoles.Add(new ICSRole(new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), "Liaison Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "LiaisonOfficer", blankMember, 3, 1));
            AllRoles.Add(new ICSRole(new Guid("63394cb1-443c-4492-9e7b-d15e22226b6b"), "Clerk", new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), Globals.IncidentCommanderID, "NameLiaison1", "TitleLiaison1", blankMember, 3, 1));
            
            AllRoles.Add(new ICSRole(new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), "Information Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "Text2", blankMember, 4, 1));
            AllRoles.Add(new ICSRole(new Guid("f4975464-ed47-43ee-a229-47fd9997ebd9"), "Clerk", new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), Globals.IncidentCommanderID, "NameInfo1", "TitleInfo1", blankMember, 4, 1));

            //Ops
            AllRoles.Add(new ICSRole(Globals.OpsChiefID, "Operations Section Chief", Globals.IncidentCommanderID, Globals.OpsChiefID, "Text3", blankMember, 5, 1)); AllRoles.Where(o => o.RoleID == Globals.OpsChiefID).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(Globals.AirOpsDirector, "Air Operations Branch Director", Globals.OpsChiefID, Globals.OpsChiefID, "AirOpsDirector", blankMember, 98, 2));
            AllRoles.Where(o => o.RoleID == Globals.AirOpsDirector).First().IsOpGroupSup = true;

            AllRoles.Add(new ICSRole(new Guid("0da445fe-99d5-4cfe-b746-cbe46b20e314"), "Air Support Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3)); AllRoles.Where(o => o.RoleID == new Guid("0da445fe-99d5-4cfe-b746-cbe46b20e314")).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(new Guid("f16d6d47-a334-4c88-9bbc-8034ee9c2a32"), "Air Tactical Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3)); AllRoles.Where(o => o.RoleID == new Guid("f16d6d47-a334-4c88-9bbc-8034ee9c2a32")).First().IsOpGroupSup = true;
            AllRoles.Add(new ICSRole(new Guid("b1fd775b-7311-4d9d-a1bf-a7d32c4d7ed2"), "Helicopter Coordinator", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("803955a6-973f-470e-a8a4-bd86197700c0"), "Helibase Manager", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));


            AllRoles.Add(new ICSRole(new Guid("3A79ED80-9B06-4923-95F7-BE1B8B554FFD"), "Staging Area Manager", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps1", "TitleOps1", blankMember, 97, 2));
            AllRoles.Add(new ICSRole(new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c"), "Branch/Division/Group1", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps2", "TitleOps2", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c")).First().IsPlaceholder = true;
            AllRoles.Add(new ICSRole(new Guid("9727f016-aed9-4f34-99db-910a06b97f2e"), "Branch/Division/Group2", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps3", "TitleOps3", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("9727f016-aed9-4f34-99db-910a06b97f2e")).First().IsPlaceholder = true;
            AllRoles.Add(new ICSRole(new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9"), "Branch/Division/Group3", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps4", "TitleOps4", blankMember, 99, 2)); 
            AllRoles.Where(o => o.RoleID == new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9")).First().IsPlaceholder = true;





            //Planning
            AllRoles.Add(new ICSRole(Globals.PlanningChiefID, "Planning Section Chief", Globals.IncidentCommanderID, Globals.PlanningChiefID, "Text8", blankMember, 6, 1));
            AllRoles.Add(new ICSRole(new Guid("A3891929-6FA4-4A21-BE33-F37DE24B779E"), "Situation Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans1", "TitlePlans1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("A7C2F2FB-3C96-4E60-83A1-3E97A6FE8BAA"), "Resources Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans2", "TitlePlans2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("3CB459EC-2C6B-40F8-9C5A-E59A393BA632"), "Demobilization Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans3", "TitlePlans3", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("B87A1F9C-FDE8-4671-BF06-4E275C62099F"), "Documentation Unit Leader", Globals.PlanningChiefID, Globals.PlanningChiefID, "NamePlans4", "TitlePlans4", blankMember, 99, 2));

            //Logistics
            AllRoles.Add(new ICSRole(Globals.LogisticsChiefID, "Logistics Section Chief", Globals.IncidentCommanderID, Globals.LogisticsChiefID, "Text9", blankMember, 7, 1));

            AllRoles.Add(new ICSRole(new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), "Service Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "NameLogistics1", "TitleLogistics1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("04FB00EB-97BA-4744-AB00-54D4D224ABAD"), "Communications Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics3", "TitleLogistics3", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("F214D2B3-9268-432F-84BF-848E80C53635"), "Medical Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics4", "TitleLogistics4", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("83BB316B-42A7-4238-A647-1B9C94EA6B5A"), "Food Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "NameLogistics5", "TitleLogistics5", blankMember, 99, 3));

            AllRoles.Add(new ICSRole(new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), "Support Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "NameLogistics2", "TitleLogistics2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9ABA549D-BA86-46D3-9C62-EC2F3FEC36F8"), "Facilities Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics6", "TitleLogistics6", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("CC4CC189-B92B-4DD6-87CC-5CD3200F600D"), "Supply Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics7", "TitleLogistics7", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("EDF0C322-76EE-448A-8D58-0820AAB9791B"), "Ground Support Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "NameLogistics8", "TitleLogistics8", blankMember, 99, 3));

            //Admin
            AllRoles.Add(new ICSRole(Globals.FinanceChiefID, "Finance/Administration Section Chief", Globals.IncidentCommanderID, Globals.FinanceChiefID, "Text10", blankMember, 8, 1));
            AllRoles.Add(new ICSRole(new Guid("2AD6BDAC-1AE2-47EF-AEE5-B8820B674C90"), "Procurement Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance1", "TitleFinance1", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("E2B66759-A290-459A-B96F-3B8FE7B3D883"), "Time Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance2", "TitleFinance2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Cost Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance3", "TitleFinance3", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Compensation/Claims Unit Leader", Globals.FinanceChiefID, Globals.FinanceChiefID, "NameFinance4", "TitleFinance4", blankMember, 99, 2));

            foreach(ICSRole role in AllRoles)
            {
               

                if(AllRoles.Any(o=>o.RoleID == role.ReportsTo))
                {
                    role.ReportsToRoleName = AllRoles.First(o => o.RoleID == role.ReportsTo).RoleName;
                }
            }

            return AllRoles;
        }

        public static string GetSectionName(Guid SectionID)
        {
            if(SectionID == Globals.IncidentCommanderID) { return "Incident Command"; }
            if (SectionID == Globals.OpsChiefID) { return "Operations"; }
            if (SectionID == Globals.PlanningChiefID) { return "Planning"; }
            if (SectionID == Globals.LogisticsChiefID) { return "Logistics"; }
            if (SectionID == Globals.FinanceChiefID) { return "Finance / Admin"; }
            return null;
        }

        public static ICSRole getGenericRoleByName(string name)
        {
            List<ICSRole> roles = GetAllRoles();
            if(roles.Any(o=>o.RoleName.Equals(name, StringComparison.OrdinalIgnoreCase))) { return roles.First(o => o.RoleName.Equals(name, StringComparison.OrdinalIgnoreCase)); }
            return null;
        }

        public static List<ICSRole> GetAllRoles()
        {
            //This is an exhuastive list of all possible ics role names from CIFFC and includes mnemonic and description 
            List<ICSRole> allRoles = new List<ICSRole>();
            allRoles.Add(new ICSRole("Air Attack Officer", Globals.OpsChiefID, "AAON", "The person responsible for directing, coordinating, and supervising a fire suppression operation involving the use of aircraft to deliver retardants or suppressants on a fire."));
            allRoles.Add(new ICSRole("Area Commander", Globals.IncidentCommanderID, "ACDR", "The person responsible to manage a very large incident that has multiple IMTs assigned. These teams may be established any time the incidents are close enough that oversight direction is required."));
            allRoles.Add(new ICSRole("Assistant Area Commander, Logistics", Globals.LogisticsChiefID, "ACLC", "The person responsible for providing facilities, services, and material at the Area Command level, and for ensuring effective use of critical resources and supplies among the incident management teams."));

            allRoles.Add(new ICSRole("Agency Representative", Globals.IncidentCommanderID, "AREP", "The person assigned by a primary, assisting, or cooperating agency to an incident who has been delegated authority to make decisions affecting that agency’s participation at the incident."));
            allRoles.Add(new ICSRole("Base/Camp Manager", Globals.LogisticsChiefID, "BCMG", "The person responsible for appropriate sanitation and facility management services in the assigned Base or Camp."));
            allRoles.Add(new ICSRole("Claims Specialist", Globals.FinanceChiefID, "CLMS", "The person who is responsible to manage all claims related activities (other than injury) for an incident"));
            allRoles.Add(new ICSRole("Clerk", Guid.Empty, "CLRK", "The person who is responsible to provide administrative support to any Section as assigned."));
            allRoles.Add(new ICSRole("Communications Unit Leader", Globals.LogisticsChiefID, "COML", "The person responsible for developing plans for the effective use of incident communications equipment and facilities; installing and testing communications equipment; supervising the Incident Communications Center; distributing communications equipment to incident personnel; and maintaining and repairing communications equipment."));
            allRoles.Add(new ICSRole("Compensation/Claims Unit Leader", Globals.FinanceChiefID, "COMP", "The person responsible for the overall management and direction of all administrative matters pertaining to compensation-for-injury and claims-related activities related to an incident."));
            allRoles.Add(new ICSRole("Communications Technician", Globals.LogisticsChiefID, "COMT", "The person responsible for installing, maintaining, and tracking communications equipment."));
            allRoles.Add(new ICSRole("Cost Unit Leader", Globals.FinanceChiefID, "COST", "The person responsible for collecting all cost data, performing cost-effectiveness analyses, and providing cost estimates and cost-saving recommendations."));
            allRoles.Add(new ICSRole("Crew Leader 1 ", Globals.OpsChiefID, "CRL1", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Leader 2", Globals.OpsChiefID, "CRL2", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Leader 3", Globals.OpsChiefID, "CRL3", "The person who is the primary supervisor in command of usually 2 to 20 crew members and responsible for their performance, safety, and welfare while maintaining the span of control of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 1", Globals.OpsChiefID, "CRM1", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 2", Globals.OpsChiefID, "CRM2", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew Member 3", Globals.OpsChiefID, "CRM3", "A wildfire crewmember is used in the control or suppression of a wildfire and works as a member of a specified type of wildfire crew."));
            allRoles.Add(new ICSRole("Crew - Type 1", Globals.OpsChiefID, "CRW1", "The primary fire response force consisting of 3 to 21 persons and meet all requirements of the Interagency Exchange Standards. Defined as Initial Attack Crews (IAC) or Sustained Action Crews (SAC)."));
            allRoles.Add(new ICSRole("Crew - Type 2", Globals.OpsChiefID, "CRW2", "Crews intended for utilization on low to moderate complexity sustained action operations and meet all requirements of the Interagency Exchange Standards."));
            allRoles.Add(new ICSRole("Crew - Type 3", Globals.OpsChiefID, "CRW3", "Generally made up of temporary firefighter forces used for mop up situations that have received some type of basic agency firefighting training."));
            allRoles.Add(new ICSRole("Commissary Manager", Globals.FinanceChiefID, "CMSY", "The person responsible for commissary operations."));
            allRoles.Add(new ICSRole("Dispatcher", Globals.LogisticsChiefID, "DISP", "The person responsible for notifying resources to assigned incidents."));
         
            //these roles need expanded features 
            allRoles.Add(new ICSRole("Division Supervisor", Globals.OpsChiefID, "DIVS", "The person responsible for supervising equipment and personnel assigned to a division. Reports to a Branch Director or Operations Section Chief."));
            allRoles.Where(o => o.Mnemonic.Equals("DIVS")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Operations Branch Director", Globals.OpsChiefID, "OPBD", "The person responsible for implementing the portion of the Incident Action Plan applicable to the assigned Branch of the Operations Section."));
            allRoles.Where(o => o.Mnemonic.Equals("OPBD")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Heavy Equipment Branch Director", Globals.OpsChiefID, "HEBD", "The person responsible to supervise and manage the overall operations for all heavy equipment on an incident. This person will prioritize the need and allocation of heavy equipment for the incident."));
            allRoles.Where(o => o.Mnemonic.Equals("HEBD")).First().IsOpGroupSup = true;


            allRoles.Add(new ICSRole("Strike Team Leader", Globals.OpsChiefID, "STLD", "The individual responsible for supervising a strike team (usually dozers, engines, or crews), and reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Where(o => o.Mnemonic.Equals("STLD")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Task Force Leader", Globals.OpsChiefID, "TFLD", "The individual responsible for supervising a task force. Reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Where(o => o.Mnemonic.Equals("TFLD")).First().IsOpGroupSup = true;

            allRoles.Add(new ICSRole("Air Operations Branch Director", Globals.OpsChiefID, "AOBD", "The person primarily responsible for managing the resources within the air operations branch, as well as preparing and implementing the air operations portion of the Incident Action Plan. Also responsible for providing logistical support to helicopters operating on the incident.")); allRoles.Where(o => o.Mnemonic.Equals("AOBD")).First().IsOpGroupSup = true;


            allRoles.Add(new ICSRole("Air Support Group Supervisor", Globals.OpsChiefID, "ASGS", "The person responsible for planning and oversight of incident aircraft support functions (helibase, helispot and Fixed Wing Air Bases).")); allRoles.Where(o => o.Mnemonic.Equals("ASGS")).First().IsOpGroupSup = true;
            allRoles.Add(new ICSRole("Air Tactical Group Supervisor", Globals.OpsChiefID, "ATGS", "The person primarily responsible for the coordination of all tactical missions of fixed and/or rotary wing aircraft operating in incident airspace.")); allRoles.Where(o => o.Mnemonic.Equals("ATGS")).First().IsOpGroupSup = true;


            //Does this one need a group?
            allRoles.Add(new ICSRole("Heavy Equipment Group Supervisor", Globals.OpsChiefID, "HEGS", "The person responsible for supervising and directing operations of assigned heavy equipment, including heavy equipment strike teams/task forces or single resources."));
            allRoles.Add(new ICSRole("Sector Leader", Globals.OpsChiefID, "SCLD", "The person responsible for directing a combination of personnel, crews, or other types of equipment in performing tactical missions on a sector (specific piece of fire line)."));



            allRoles.Add(new ICSRole("Demobilization Unit Leader", Globals.PlanningChiefID, "DMOB", "The person is responsible for preparing the Demobilization Plan and schedule ensuring an orderly, safe, and efficient movement of personnel and equipment from the incident."));
            allRoles.Add(new ICSRole("Documentation Unit Leader", Globals.PlanningChiefID, "DOCL", "The person responsible for maintaining accurate and complete incident files, providing duplication services to incident personnel, and packing and storing incident files."));
            allRoles.Add(new ICSRole("Dozer Boss", Globals.OpsChiefID, "DOZB", "The person responsible to lead a single bulldozer and attached personnel and is responsible for their safety on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Engine Boss", Globals.OpsChiefID, "ENGB", "The person that leads a single fire engine and attached personnel and is responsible for their safety on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Engine Operator", Globals.OpsChiefID, "ENOP", "The person responsible for the safe and efficient use of a wildland fire engine on an incident."));
            allRoles.Add(new ICSRole("Equipment time recorder", Globals.FinanceChiefID, "EQTR", "The Equipment Time Recorder is responsible for tracking and posting equipment time on an incident"));
            allRoles.Add(new ICSRole("Facilities Unit Leader", Globals.LogisticsChiefID, "FACL", "The person responsible for laying out and operating incident facilities (Base, Camp(s), and ICP) and managing Base and Camp(s) operations."));
            allRoles.Add(new ICSRole("Faller", Globals.OpsChiefID, "FALL", "A person who is qualified under workplace regulations to fall non danger trees on an incident."));
            allRoles.Add(new ICSRole("Fire Behaviour Analyst", Globals.PlanningChiefID, "FBAN", "A specialist position under the plans function of a fire incident management team responsible for making predictions of probable fire behaviour based on an analysis of the current and forecasted state of the fire environment."));
            allRoles.Add(new ICSRole("Fire Cache Manager", Globals.LogisticsChiefID, "FCMG", "The person responsible for supervision of the supply of fire equipment assembled in planned quantities or at a strategic location."));
            allRoles.Add(new ICSRole("Food Unit Leader", Globals.LogisticsChiefID, "FDUL", "The person responsible for determining feeding requirements at all incident facilities and for menu planning, determining cooking facilities required, food preparation, serving, providing potable water, and general maintenance of the food service areas."));
            allRoles.Add(new ICSRole("Fire Investigator", Globals.PlanningChiefID, "FINV", "The person responsible to determine the origin, cause, and development of a wildland fire."));
            allRoles.Add(new ICSRole("Firing Boss", Globals.OpsChiefID, "FIRB", "The person responsible for ground and/or aerial ignition operations and coordinates with resources on wildland and prescribed fire incidents."));
            allRoles.Add(new ICSRole("Field Observer", Globals.OpsChiefID, "FOBS", "The person responsible for collecting incident status information from personal observations at the incident and providing this information to the activated function, or other resources."));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief", Globals.FinanceChiefID, "FSC", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief 1", Globals.FinanceChiefID, "FSC1", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Finance/Administration Section Chief 2", Globals.FinanceChiefID, "FSC2", "The person responsible for all financial, administrative, and cost analysis aspects of the incident and for supervising members of the Finance/Administration Section"));
            allRoles.Add(new ICSRole("Fixed Wing Base Manager", Globals.OpsChiefID, "FWBM", "The person responsible for supervision and coordination at a fixed-wing base."));
            allRoles.Add(new ICSRole("Geographic Information System Specialist", Globals.PlanningChiefID, "GISS", "The person responsible for providing timely and accurate spatial information to be used by all facets of the IMT."));
            allRoles.Add(new ICSRole("Ground Support Unit Leader", Globals.LogisticsChiefID, "GSUL", "The person responsible for the fueling, maintaining, and repairing of vehicles, and the transportation of personnel and supplies."));

            allRoles.Add(new ICSRole("Helibase Manager", Globals.OpsChiefID, "HEBM", "The person responsible for controlling helicopter take-offs and landings at a helibase, managing helibase assigned helicopters, supplies, fire retardant mixing and loading."));
            allRoles.Add(new ICSRole("Helicopter engineer", Globals.OpsChiefID, "HENG", "The person responsible for the maintenance of a helicopter."));
            allRoles.Add(new ICSRole("Heavy Equipment Operator", Globals.OpsChiefID, "HEOP", "The person responsible for the safe and efficient operation of a single piece of heavy equipment on an incident"));
            allRoles.Add(new ICSRole("Helispot Manager", Globals.OpsChiefID, "HESM", "The person responsible for managing all resources assigned to a helispot."));
            allRoles.Add(new ICSRole("Helicopter Coordinator", Globals.OpsChiefID, "HLCO", "The person responsible for coordinating tactical or logistical helicopter mission(s) at an incident."));
            allRoles.Add(new ICSRole("Helitorch Mixmaster", Globals.OpsChiefID, "HTMM", "The person responsible to supervise mixing/filling operation and manages time frames to maintain availability of helitorch fuel."));
            allRoles.Add(new ICSRole("Incident Commander", Globals.IncidentCommanderID, "ICT", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 1", Globals.IncidentCommanderID, "ICT1", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 2", Globals.IncidentCommanderID, "ICT2", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 3", Globals.IncidentCommanderID, "ICT3", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 4", Globals.IncidentCommanderID, "ICT4", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Incident Commander 5", Globals.IncidentCommanderID, "ICT5", "The person responsible for all incident activities, including the development of strategies and tactics and the ordering and release of resources. The IC has overall authority and responsibility for conducting incident operations and is responsible for the management of all incident operations at the incident site."));
            allRoles.Add(new ICSRole("Ignition Specialist", Globals.OpsChiefID, "IGSP", "The person responsible for directing and supervising all aspects of an ignition team in the performance of tactical ignition operational assignments on wildfires and prescribed burns."));
            allRoles.Add(new ICSRole("Incident Meteorologist", Globals.PlanningChiefID, "IMET", "The person responsible for on-site meteorological support to an incident."));
            allRoles.Add(new ICSRole("International Liaison Officer", Globals.IncidentCommanderID, "INLO", "The person of the Sending Participants based at the Receiving Participants’ Coordinating Authority or a Receiving Participant’s Fire Centre who has been delegated authority to make decisions on matters affecting all the Sending Participants’ resources in the Receiving Participants’ country. The INLO reports directly to the Sending Participants’ Coordinating Authority."));
            allRoles.Add(new ICSRole("Information Officer", Globals.IncidentCommanderID, "IOF", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Information Officer 1", Globals.IncidentCommanderID, "IOF1", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Information Officer 2", Globals.IncidentCommanderID, "IOF2", "A member of the Command Staff responsible for interfacing with internal clients, the public and media and/or with other agencies with incident related information requirements"));
            allRoles.Add(new ICSRole("Infrared Interpreter", Globals.PlanningChiefID, "IRIN", "The person responsible for directing infrared mapping operations when assigned."));
            allRoles.Add(new ICSRole("Infrared Operator", Globals.PlanningChiefID, "IROP", "The person responsible for infrared scanning and mapping operations when assigned to an incident."));
            allRoles.Add(new ICSRole("Loadmaster", Globals.OpsChiefID, "LOAD", "The person responsible for the safe loading and unloading of personnel and or cargo from aircraft."));
            allRoles.Add(new ICSRole("Liaison Officer", Globals.IncidentCommanderID, "LOFR", "A member of the Command Staff responsible for coordinating with representatives from cooperating and assisting agencies or organizations."));
            allRoles.Add(new ICSRole("Logistics Section Chief", Globals.LogisticsChiefID, "LSC", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Logistics Section Chief 1", Globals.LogisticsChiefID, "LSC1", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Logistics Section Chief 2", Globals.LogisticsChiefID, "LSC2", "This individual responsible for supervising the Logistic Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Line scout", Globals.OpsChiefID, "LSCT", "A person responsible to determine the location of a fire line."));
            allRoles.Add(new ICSRole("Medical Unit Leader", Globals.LogisticsChiefID, "MEDL", "The person primarily responsible for developing the Medical Plan, obtaining medical aid and transportation for injured or ill incident personnel, and preparing reports and records."));
            allRoles.Add(new ICSRole("Mixmaster", Globals.OpsChiefID, "MXMS", "The person in charge of fire retardant mixing operations, with responsibility for quantity and quality of retardant and for the loading of aircraft in land based operations."));
            
            allRoles.Add(new ICSRole("Operations Section Chief", Globals.OpsChiefID, "OSC", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Operations Section Chief 1", Globals.OpsChiefID, "OSC1", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Operations Section Chief 2", Globals.OpsChiefID, "OSC2", "The person responsible for supervising the Operations Section who reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Prescribed Fire Specialist", Globals.OpsChiefID, "PBSP", "The person responsible for creating burn plans for prescribed fire, to ensure the best ecological results in the safest procedure."));
            allRoles.Add(new ICSRole("Plastic Sphere Dispenser Operator", Globals.OpsChiefID, "PLDO", "The person responsible to utilize the Plastic Sphere Dispenser for aerial ignition operations."));
            allRoles.Add(new ICSRole("Procurement Unit Leader", Globals.FinanceChiefID, "PROC", "The person responsible for administering all financial matters pertaining to vendor contracts, leases, and fiscal agreements."));
            allRoles.Add(new ICSRole("Planning Section Chief", Globals.PlanningChiefID, "PSC", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Planning Section Chief 1", Globals.PlanningChiefID, "PSC1", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Planning Section Chief 2", Globals.PlanningChiefID, "PSC2", "The person responsible for supervising the Planning Section. Reports to the Incident Commander and is a member of the General Staff. This position may have one or more deputies assigned."));
            allRoles.Add(new ICSRole("Personnel Time Recorder", Globals.FinanceChiefID, "PTRC", "The person responsible for overseeing the recording of time for all personnel assigned to an incident."));
            allRoles.Add(new ICSRole("Radio Operator", Globals.LogisticsChiefID, "RADO", "The person responsible for passing accurate and timely information via incident radio communications. May also be required to document all communications and ensure regular check-ins by resources are completed."));
            allRoles.Add(new ICSRole("Receiving/Distribution Manager", Globals.LogisticsChiefID, "RCDM", "The person responsible for receiving and distributing all supplies and equipment (other than primary resources) and the service and repair of tools and equipment."));
            allRoles.Add(new ICSRole("Resource Clerk", Globals.PlanningChiefID, "RESC", "The person responsible for support to the Resource Unit."));
            allRoles.Add(new ICSRole("Resources Unit Leader", Globals.PlanningChiefID, "RESL", "The person responsible for establishing all incident check-in activities; preparing and processing resource status information; preparing and maintaining displays, charts, and lists that reflect the current status and location of suppression resources, transportation, and support vehicles; and maintaining a master check-in list of resources assigned to the incident."));
            allRoles.Add(new ICSRole("Status/Check-in Recorders", Globals.PlanningChiefID, "SCKN", "The person responsible, at each check in location, to ensure that all resources assigned to an incident are accounted for."));
           
            allRoles.Add(new ICSRole("Situation Unit Leader", Globals.PlanningChiefID, "SITL", "The person responsible for collecting and organizing incident status and information and evaluating, analyzing, and displaying that information."));
            allRoles.Add(new ICSRole("Small Engine Mechanic", Globals.LogisticsChiefID, "SMEC", "The person responsible for the repair and maintenance of small engines powering firefighting equipment, such as portable pumps, chainsaws etc."));
            allRoles.Add(new ICSRole("Smoke Jumper", Globals.OpsChiefID, "SMKJ", "A firefighter who travels to wildland fires by fixed wing aircraft and parachute."));
            allRoles.Add(new ICSRole("Safety Officer", Globals.IncidentCommanderID, "SOF", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Safety Officer 1", Globals.IncidentCommanderID, "SOF1", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Safety Officer 2", Globals.IncidentCommanderID, "SOF2", "A member of the command staff who is responsible for monitoring response operations and advising the Incident Commander on all matters related to the safety of operations, including the health and safety of personnel."));
            allRoles.Add(new ICSRole("Supply Unit Clerk", Globals.LogisticsChiefID, "SPUC", "The person responsible for support to the Supply Unit"));
            allRoles.Add(new ICSRole("Supply Unit Leader", Globals.LogisticsChiefID, "SPUL", "The person responsible for ordering personnel, equipment, and supplies; receiving and storing all supplies for the incident; maintaining an inventory of supplies; and servicing nonexpendable supplies and equipment."));
            allRoles.Add(new ICSRole("Senior Agency Representative", Globals.IncidentCommanderID, "SREP", "The person representative of the Sending Participant based at a Receiving Participant’s Fire Centre, who has been delegated authority to make decisions on matters affecting the Sending Participant’s resources at an incident or within that jurisdiction."));
            allRoles.Add(new ICSRole("Staging Area Manager", Globals.OpsChiefID, "STAM", "The person responsible for managing all activities within a Staging Area."));
            allRoles.Add(new ICSRole("Support Branch Director", Globals.LogisticsChiefID, "SUBD", "The person responsible for developing and implementing logistics plans in support of the Incident Action Plan. The Support Branch Director supervises the operations of the Supply, Facilities, and Ground Support Units."));
            allRoles.Add(new ICSRole("Service Branch Director", Globals.LogisticsChiefID, "SVBD", "The person responsible for managing all service activities at the incident. The Service Branch Director supervises the operations of the Communications, Medical, and Food Unit Leaders."));
            allRoles.Add(new ICSRole("Technical Specialist", Guid.Empty, "THSP", "Personnel with special skills that can be used anywhere within the Incident Command System organization."));
            allRoles.Add(new ICSRole("Time Unit Leader", Globals.FinanceChiefID, "TIME", "The person responsible for recording personnel time."));
            allRoles.Add(new ICSRole("Ordering Manager", Globals.LogisticsChiefID, "", ""));

            allRoles.Add(new ICSRole("Deputy", Guid.Empty, "", "", true));
            allRoles.Add(new ICSRole("Trainee", Guid.Empty, "", "", true));
            allRoles.Add(new ICSRole("Assistant", Guid.Empty, "", "", true));


            return allRoles;
        }
     
      

        public static ICSRole GetRoleByID(this OrganizationChart orgChart, Guid id, bool defaultUpChain = true)
        {
            if (orgChart.ActiveRoles.Any(o => o.RoleID == id))
            {
                ICSRole role = orgChart.GetAllRoles().First(o => o.RoleID == id);
                if(defaultUpChain && (role.IndividualID == Guid.Empty) && role.ReportsTo != Guid.Empty)
                {
                    role = orgChart.GetRoleByID(role.ReportsTo, true);
                }
                return role;
            }
            return null;
        }

        public static ICSRole GetRoleByName(this OrganizationChart orgChart, string name)
        {
            List<ICSRole> roles = orgChart.ActiveRoles;
            if (roles.Any(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return roles.First(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else { return null; }
        }

        public static List<ICSRole> GetAllRoles(this OrganizationChart orgChart)
        {
            return orgChart.ActiveRoles;
        }

        public static void SortRoles(this OrganizationChart orgChart)
        {
            List<ICSRole> sortedRoles = new List<ICSRole>();

            if (orgChart.AllRoles.Any(o => o.RoleID == Globals.IncidentCommanderID))
            {
                ICSRole ic = orgChart.AllRoles.First(o => o.RoleID == Globals.IncidentCommanderID);
                ic.Depth = 0;
                sortedRoles.Add(ic);
                sortedRoles = AddChildRoles(orgChart, sortedRoles, ic);
            }
            orgChart.AllRoles = sortedRoles;
        }

        private static List<ICSRole> AddChildRoles(OrganizationChart sourceChart, List<ICSRole> baseList, ICSRole parentRole)
        {
            List<ICSRole> children = sourceChart.AllRoles.Where(o => o.ReportsTo == parentRole.RoleID).ToList();
            children = children.OrderBy(o => o.ManualSortOrder).ThenBy(o => o.RoleName).ToList();
            foreach(ICSRole child in children)
            {
                child.Depth = parentRole.Depth + 1;
                baseList.Add(child);
                baseList = AddChildRoles(sourceChart, baseList, child);
            }
            return baseList;
        }


        public static int CalculateOrgChartPageCount(this OrganizationChart currentChart)
        {
            int pageCount = 1;

            foreach (ICSRole role in currentChart.ActiveRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
            {
                List<ICSRole> childRoles = currentChart.GetChildRoles(role.RoleID, false);
                if (childRoles.Any(o => string.IsNullOrEmpty(o.PDFFieldName)))
                {
                    //Every 4 of these will generate an extra page, as 4 is the number of direct children per page
                    //Within those children, there may be grand or great grand children that cause yet more pages

                    pageCount += currentChart.PagesThisBranch(role);
                }

            }

            return pageCount;
        }

        private static int PagesThisBranch(this OrganizationChart currentChart, ICSRole parentRole)
        {
            int pageCount = 0;

            int childrenPerExtPage = 4;
            int grandChildrenPerPage = 5;

            List<ICSRole> childRoles = currentChart.GetChildRoles(parentRole.RoleID, false);
            childRoles = childRoles.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();

            double pagesForChildren = Math.Ceiling((double)childRoles.Count() / (double)childrenPerExtPage);
            pageCount += Convert.ToInt32(pagesForChildren);

            foreach(ICSRole child in childRoles)
            {
                List<ICSRole> grandChildren = currentChart.GetChildRoles(child.RoleID, false);
                grandChildren = grandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();
                double pagesForGrandChildren = Math.Ceiling((double)grandChildren.Count() / (double)grandChildrenPerPage);
                if (pagesForGrandChildren >= 1) { pagesForGrandChildren = pagesForGrandChildren - 1; }
                pageCount += (Int32)pagesForGrandChildren;

                foreach(ICSRole grandChild in grandChildren)
                {
                    List<ICSRole> greatGrandChildren = currentChart.GetChildRoles(grandChild.RoleID, false);
                    greatGrandChildren = greatGrandChildren.Where(o => string.IsNullOrEmpty(o.PDFFieldName)).ToList();
                    if (greatGrandChildren.Any())
                    {
                        pageCount += currentChart.PagesThisBranch(grandChild);
                    }
                }
            }


            return pageCount;
        }

        public static string GetBranchNameFromID (Guid id)
        {
            if(id == Globals.OpsChiefID) { return "Operations"; }
            if (id == Globals.PlanningChiefID) { return "Planning"; }
            if (id == Globals.LogisticsChiefID) { return "Logistics"; }
            if (id == Globals.FinanceChiefID) { return "Finance/Admin"; }

            return "Command"; 

        }

        public static string OrgChartToCSV(List<ICSRole> roles, string delimiter = ",")
        {
            StringBuilder csv = new StringBuilder();
            csv.Append("Branch"); csv.Append(delimiter);
            csv.Append("Role Name"); csv.Append(delimiter);
            csv.Append("Reports To"); csv.Append(delimiter);
            csv.Append("Individual Name"); csv.Append(delimiter);
           // csv.Append("Phone"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);

            foreach (ICSRole item in roles)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                string branch = GetBranchNameFromID(item.SectionID);
                csv.Append("\""); csv.Append(branch.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.ReportsToRoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.IndividualName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                //csv.Append("\""); if (item.teamMember != null) { csv.Append(item.teamMember.CellphoneNumber.EscapeQuotes()); } csv.Append("\""); csv.Append(delimiter);

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }
    }
}