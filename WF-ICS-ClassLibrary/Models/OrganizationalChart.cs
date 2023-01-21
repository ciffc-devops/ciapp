using ProtoBuf;
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
        public List<ICSRole> FilledRoles { get { return AllRoles.Where(o => o.teamMember != null && o.teamMember.PersonID != Guid.Empty).ToList(); } }
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
        public TeamMember getTeamMemberByRoleName(string rolename, bool defaultUpChain = true)
        {
            ICSRole role = this.GetRoleByName(rolename);
            TeamMember member = role.teamMember;
            if (defaultUpChain && string.IsNullOrEmpty(member.Name))
            {
                member = getTeamMemberByRoleID(role.ReportsTo);
            }

            return member;
        }


        public string getNameByRoleID(Guid id, bool defaultUpChain = true)
        {
            if (AllRoles.Any(o => o.RoleID == id))
            {
                string name = AllRoles.First(o => o.RoleID == id).IndividualName;
                if (defaultUpChain && string.IsNullOrEmpty(name) && AllRoles.First(o => o.RoleID == id).ReportsTo != Guid.Empty)
                {
                    name = getNameByRoleID(AllRoles.Where(o => o.RoleID == id).First().ReportsTo);
                }
                return name;
            }
            else { return null; }
        }

        public TeamMember getTeamMemberByRoleID(Guid id, bool defaultUpChain = true)
        {
            if (AllRoles.Any(o => o.RoleID == id))
            {
                TeamMember member = AllRoles.First(o => o.RoleID == id).teamMember;
                if (defaultUpChain && string.IsNullOrEmpty(member.Name) && AllRoles.First(o => o.RoleID == id).ReportsTo != Guid.Empty)
                {
                    member = getTeamMemberByRoleID(AllRoles.Where(o => o.RoleID == id).First().ReportsTo);
                }
                return member;
            }
            else { return null; }
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
        [ProtoMember(7)] private TeamMember _teamMember;
        [ProtoMember(8)] private DateTime _LastUpdatedUTC;
        [ProtoMember(9)] private int _OpPeriod;
        [ProtoMember(10)] private Guid _BranchID;
        [ProtoMember(11)] private string _ReportsToRoleName;
        [ProtoMember(12)] private int _ManualSortOrder;
        [ProtoMember(13)] private string _PDFTitleName;
        [ProtoMember(14)] private int _Depth;
        [ProtoMember(15)] private string _RoleDescription;
        [ProtoMember(16)] private string _Mnemonic;


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
        public Guid BranchID { get => _BranchID; set => _BranchID = value; }



        public Guid ReportsTo { get => _ReportsTo; set => _ReportsTo = value; }
        public string PDFFieldName { get => _PDFFieldName; set => _PDFFieldName = value; }
        public string PDFTitleName { get => _PDFTitleName; set => _PDFTitleName = value; }
        public string IndividualName { get { if (teamMember != null) { return teamMember.Name; } else { return null; } } set => teamMember.Name = value; }
        public string RoleNameWithIndividual
        {
            get
            {
                if (!string.IsNullOrEmpty(IndividualName)) { return RoleName + " - " + IndividualName; }
                else if (RoleID == Globals.IncidentCommanderID && !RoleName.Equals("Incident Commander")) { return RoleName; }
                else { return RoleName + " - unassigned"; }
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


        public Guid IndividualID
        {
            get
            {
                if (teamMember == null) { teamMember = new TeamMember(); }
                return teamMember.PersonID;
            }
            set
            {
                if (value == Guid.Empty)
                {
                    teamMember = new TeamMember(); teamMember.PersonID = Guid.Empty;
                }
                else { teamMember.PersonID = IndividualID; }
            }
        }


        public Guid OrganizationalChartID { get => _OrganizationalChartID; set => _OrganizationalChartID = value; }

        public Guid OrgChartRoleID { get => _OrgChartRoleID; set => _OrgChartRoleID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public string ReportsToRoleName { get => _ReportsToRoleName; set => _ReportsToRoleName = value; }
        public int MaualSortOrder { get => _ManualSortOrder; set => _ManualSortOrder = value; }
        public TeamMember teamMember
        {
            get => _teamMember;
            set
            {
                if (value != null && value.PersonID == Guid.Empty)
                {
                    _teamMember = new TeamMember();
                    _teamMember.PersonID = Guid.Empty;
                }
                else
                {
                    _teamMember = value;
                }

            }
        }


        public ICSRole() { teamMember = new TeamMember(); OrgChartRoleID = System.Guid.NewGuid(); RoleID = System.Guid.NewGuid(); _ManualSortOrder = 99; Depth = 0; }
        /*
        public ICSRole(Guid id, string name, Guid reports, string pdfname, string person_name = "", Guid person_id = new Guid())
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; IndividualName = person_name; IndividualID = person_id;
        }*/
        public ICSRole(Guid id, string name, Guid reports, Guid Branch, string pdfname, TeamMember member, int maualSortOrder = 99, int initial_depth = 0)
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; teamMember = member; BranchID = Branch; _OrgChartRoleID = System.Guid.NewGuid();
            MaualSortOrder = maualSortOrder; Depth = initial_depth;
            if (OrgChartTools.staticRoles.Any(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase)))
            {
                ICSRole staticRole = OrgChartTools.staticRoles.FirstOrDefault(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase));
                Mnemonic = staticRole.Mnemonic;
                RoleDescription = staticRole.RoleDescription;
            }
            else { string huh = "huh"; }
        }
        public ICSRole(Guid id, string name, Guid reports, Guid Branch, string pdfname, string pdftitle, TeamMember member, int maualSortOrder = 99, int initial_depth = 0)
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; teamMember = member; BranchID = Branch; _OrgChartRoleID = System.Guid.NewGuid();
            PDFTitleName = pdftitle;
            MaualSortOrder = maualSortOrder; Depth = initial_depth;
            if (OrgChartTools.staticRoles.Any(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase)))
            {
                ICSRole staticRole = OrgChartTools.staticRoles.FirstOrDefault(o => o.RoleName.Equals(RoleName, StringComparison.InvariantCultureIgnoreCase));
                Mnemonic = staticRole.Mnemonic;
                RoleDescription = staticRole.RoleDescription;
            } 
            else { string huh = "huh"; }
        }

        public ICSRole(string name, Guid Branch, string mnemonic, string description)
        {
            RoleID = Guid.NewGuid();
            RoleName = name; 
            BranchID = Branch;
            RoleDescription = description;
            Mnemonic = mnemonic;

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
        public bool AllowEditReportsTo { get => string.IsNullOrEmpty(PDFFieldName); }
        public bool AllowDelete { get => string.IsNullOrEmpty(PDFFieldName); }
        


        public ICSRole Clone()
        {
            ICSRole cloneTo = this.MemberwiseClone() as ICSRole;
            cloneTo.teamMember = this.teamMember.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }


    }

    [Serializable]
    public class ICSResponsibility
    {
        private Guid _ICSRoleID;
        private List<string> _Responsibilities;
        private List<string> _Forms;

        public Guid ICSRoleID { get => _ICSRoleID; set => _ICSRoleID = value; }
        public List<string> Responsibilities { get => _Responsibilities; set => _Responsibilities = value; }
        public List<string> Forms { get => _Forms; set => _Forms = value; }

        public ICSResponsibility() { Responsibilities = new List<string>(); Forms = new List<string>(); }

        public ICSResponsibility getResponsibilityByRoleID(Guid id)
        {
            ICSResponsibility responsibility = new ICSResponsibility();

            switch (id.ToString().ToUpper())
            {
                //COMMAND
                //SAR Commander 
                case "98649093-2C0D-4D23-9EC1-2AF16ED83B2A": responsibility.Responsibilities.Add("Requesting Agencies authorized to function in role of SAR Command:"); responsibility.Responsibilities.Add("Police - search for lost or missing persons, ground & inland waters"); responsibility.Responsibilities.Add("BCAS - pre-hospital care and transportation of injured persons"); responsibility.Responsibilities.Add("DND - search and rescue, downed or overdue aircraft"); responsibility.Responsibilities.Add("CCG - search and rescue, tidal waters"); responsibility.Responsibilities.Add("Parks Canada - search and rescue, National Parks"); responsibility.Responsibilities.Add("Coroner - Recovery of human remains"); responsibility.Responsibilities.Add("Represent Requesting Agency in Incident Command (Unified Command)"); responsibility.Responsibilities.Add("Fulfill responsibilities for Public information and Family Liaison"); responsibility.Forms.Add("ICS 202 INCIDENT OBJECTIVES (with Planning)"); responsibility.Forms.Add("ICS 207 ORGANIZATION CHART"); responsibility.Forms.Add("ICS305 SAFETY PLAN"); responsibility.Forms.Add("ICS201A RESOURCE STATUS (with Planning)"); break;
                //SAR Manager 
                case "1096905E-A726-41D8-A8BC-2EAD61CCB2F7": responsibility.Responsibilities.Add("Responsible for all SAR roles & responsibilities unless delegated:"); responsibility.Responsibilities.Add("Manage the functional aspects of the SAR task"); responsibility.Responsibilities.Add("Develop overall objectives (ICS202 INCIDENT OBJECTIVES)"); responsibility.Responsibilities.Add("Assign ICS positions (ICS207 ORGANIZATION CHART): Command, Operations, Planning, Logistics, Administration/Finance"); responsibility.Responsibilities.Add("Determine Operational Periods"); responsibility.Responsibilities.Add("Report to PEP ECC on a regular basis"); responsibility.Responsibilities.Add("Update SAR Commander & brief Media Liaison"); responsibility.Responsibilities.Add("Review team assignment debriefings & modify overall objectives accordingly"); responsibility.Responsibilities.Add("Adequately brief incoming SAR Management team at shift changes"); responsibility.Forms.Add("ICS 202 INCIDENT OBJECTIVES (with Planning)"); responsibility.Forms.Add("ICS 207 ORGANIZATION CHART"); responsibility.Forms.Add("ICS305 SAFETY PLAN"); responsibility.Forms.Add("ICS201A RESOURCE STATUS (with Planning)"); break;
                //Deputy SAR Manager 
                case "450EA00E-636A-4F44-9B6D-50A8EC03F4EA": responsibility.Responsibilities.Add("Assist SAR Mgr. with any role delegated"); responsibility.Responsibilities.Add("Able to assume role of SAR Mgr. during breaks, etc."); break;
                //Safety Officer 
                case "CE7166AF-9432-4F7A-B942-1250AF0B7C31": responsibility.Responsibilities.Add("Appointed when operating in hazardous environments, the number of agencies warrant it or at the SAR Mgr.'s discretion"); responsibility.Responsibilities.Add("Ensure safe practices are being observed"); responsibility.Responsibilities.Add("Create & maintain the Safety Plan (ICS305 SAFETY PLAN)"); responsibility.Responsibilities.Add("Check skills & equipment of personnel prior to them going in the field, especially if they come from an outside resource not familiar to the managing group"); responsibility.Responsibilities.Add("Able to overrule decisions if safe practices are being violated or there is an unacceptable level or risk involved"); responsibility.Responsibilities.Add("Positioned at ICP, Staging Area or wherever appropriate. There may also be a Site Safety Officer during high-risk operations such as rope rescue, swift water or avalanche rescue"); responsibility.Forms.Add("ICS305 SAFETY PLAN"); break;
                //Liaison Officer 
                case "ECAEA544-95E6-4177-B954-F2A8D4027642": responsibility.Responsibilities.Add("Coordinates with representatives from cooperating and assisting agencies"); responsibility.Responsibilities.Add("May contribute to ICS201A RESOURCE STATUS for mutual aid resources"); responsibility.Responsibilities.Add("May assist with briefing and liaison with family members"); responsibility.Forms.Add("ICS201A RESOURCE STATUS (with Planning)"); break;
                //Information Officer 
                case "91C6C1B6-92F2-4959-8A01-198240340571": responsibility.Responsibilities.Add("Media & family are responsibility of Requesting Agency (i.e. Police)"); responsibility.Responsibilities.Add("Interface with public and media & other agencies requiring information"); break;

                //OPS
                //Operations Section Chief 
                case "CFE4C7DE-BD61-421C-8167-1B55E4151CFC": responsibility.Responsibilities.Add("Set up the organizational structure of the section"); responsibility.Responsibilities.Add("Manage operational elements of the incident"); responsibility.Responsibilities.Add("Ensure resources are coordinated to fill assignments & dispatched to the field"); responsibility.Responsibilities.Add("Complete appropriate portions of ICS204 TEAM ASSIGNMENT SHEET for each assignment"); responsibility.Responsibilities.Add("Complete appropriate portions of ICS303 EQUIPMENT INVENTORY as equipment dispatched"); responsibility.Responsibilities.Add("Determine the resources required by the section"); responsibility.Responsibilities.Add("Establish an Accountability system for keeping track of personnel and resources"); responsibility.Responsibilities.Add("Assist the SAR Mgr. in developing objectives & strategies as part of IAP"); responsibility.Responsibilities.Add("Implement the operational portion of the Incident Action Plan"); responsibility.Responsibilities.Add("Request or release resources through the SAR Mgr."); responsibility.Responsibilities.Add("Maintain records of current assignments & assigned-team status"); responsibility.Responsibilities.Add("Keep Incident Status and Resource Status Units informed of developments within Operations"); responsibility.Forms.Add("ICS 207 ORGANIZATION CHART (In Part)"); responsibility.Forms.Add("ICS309 LOG"); responsibility.Forms.Add("ICS204 TEAM ASSIGNMENT SHEET (w/Planning)"); responsibility.Forms.Add("ICS303 EQUIPMENT INVENTORY (w/Logistics)"); responsibility.Forms.Add("ICS214 UNIT LOG"); responsibility.Forms.Add("ICS220 AIR OPERATIONS PLAN"); break;
                //Comms Op. 
                case "D2695CFD-944E-412C-B5F0-0F189B7A5D9B": responsibility.Responsibilities.Add("Operate radio(s) & maintains the log. (ICS309 LOG) May have an assistant (Recorder)."); responsibility.Forms.Add("ICS309 LOG"); break;
                //Staging Area(s) 
                case "3A79ED80-9B06-4923-95F7-BE1B8B554FFD": responsibility.Responsibilities.Add("Provide contact person for Staging Area"); responsibility.Responsibilities.Add("Coordinate supply deliveries & manage supplies at Staging Area"); responsibility.Responsibilities.Add("Manage Staging Area & safety and arrange for security of area"); responsibility.Responsibilities.Add("Log events at Staging Area (ICS214 UNIT LOG)"); responsibility.Forms.Add("ICS214 UNIT LOG"); break;
                //Ground Director 
                case "D0962ADF-DA00-4F4B-B498-3D8233442D8A": responsibility.Responsibilities.Add("Coordinate deployment of ground resources"); responsibility.Responsibilities.Add("Coordinate field team ground transport (deployment & demobilization) through Logistics"); responsibility.Responsibilities.Add("Coordinate staging of stand-by resources"); responsibility.Responsibilities.Add("Coordinate Logistics for re-supply, feeding, etc. of ground resources"); break;
                //Water Director
                case "F07862BD-35B1-4A03-9BCB-615C04239D69": responsibility.Responsibilities.Add("Coordinate deployment of water resources"); responsibility.Responsibilities.Add("Coordinate field team water transport (deployment & demobilization) through Logistics"); responsibility.Responsibilities.Add("Request fuel from Logistics (Supply Unit)."); break;
                //Air Director 
                case "C3F2C873-FEE8-42E1-A5C6-16B91D1D835B": responsibility.Responsibilities.Add("Direct aircraft (helicopter & fixed-wing) resources, communications & ground support"); responsibility.Responsibilities.Add("Determine requirements & ensure resources are requested from logistics (Transportation"); responsibility.Responsibilities.Add("Unit & Supply Unit) & made available"); responsibility.Responsibilities.Add("Establish and maintain ICS220 AIR OPERATIONS PLAN"); responsibility.Forms.Add("ICS220 AIR OPERATIONS PLAN"); break;
                //Search 
                case "C465E7D7-DB66-4BB3-94DB-7F7F6D25B73A": break;
                //Rescue Team Leader 
                case "95A08C74-354E-462A-A1B7-7E58E996BD26": break;
                //Heli Coordinator 
                case "E4CA3D52-51DA-402E-B06A-18BAB3EF8E6C": responsibility.Responsibilities.Add("Coordinate helicopter resources"); break;
                //Heli Base Manager
                case "554DCD16-7180-4D17-9CA2-392D828DDA79": responsibility.Responsibilities.Add("Establish & control helicopter landing area(s): Helispots and Helibases"); responsibility.Responsibilities.Add("Establish & maintain safety for that area"); responsibility.Responsibilities.Add("Coordinate arrival/departure of helicopters to/from Helispot"); responsibility.Responsibilities.Add("Log passenger list & cargo for each flight through the Helispot (ICS214 UNIT LOG)"); responsibility.Responsibilities.Add("Request fuel from Logistics (Supply Unit)"); responsibility.Forms.Add("ICS214 UNIT LOG"); break;
                //Fixed Wing Coord. 
                case "E9697D42-29EB-42E6-94AA-33C7AA8E1FE1": responsibility.Responsibilities.Add("Coordinate fixed-wing aircraft resources"); break;

                //PLANNING
                //Planning Section Chief 
                case "A0B226FA-33FA-45C7-91AE-7D4F498FD31B": responsibility.Responsibilities.Add("Manage planning elements of the incident"); responsibility.Responsibilities.Add("Coordinate completion of Incident Action Plan elements"); responsibility.Responsibilities.Add("Create objectives list & review & revise each operational period or as required"); responsibility.Responsibilities.Add("Determine long-range objectives"); responsibility.Responsibilities.Add("Develop assignments to accomplish objectives"); responsibility.Responsibilities.Add("Create assignment forms (ICS204 TEAM ASSIGNMENT SHEET) & issue to Operations"); responsibility.Responsibilities.Add("Ensure all relevant information appears on all copies of Assignment sheets"); responsibility.Forms.Add("ICS302 LOST PERSON QUESTIONAIRE or 302A MISSING VESSEL QUESTIONAIRE"); responsibility.Forms.Add("ICS301 SUBJECT PROFILE"); responsibility.Forms.Add("ICS202 INCIDENT OBJECTIVES (w/ the SAR Mgr.)"); responsibility.Forms.Add("ICS207 ORGANIZATION CHART (In Part)"); responsibility.Forms.Add("ICS215 OPERATIONS PLAN"); responsibility.Forms.Add("ICS204 TEAM ASSIGNMENT SHEET (w/Operations)"); responsibility.Forms.Add("ICS204C CLUE TRACKING SHEET"); responsibility.Forms.Add("ICS209 INCIDENT STATUS SUMMARY"); responsibility.Forms.Add("ICS221 DEMOBILIZATION PLAN"); responsibility.Forms.Add("ICS201A RESOURCE STATUS (w/ the SAR Mgr.)"); break;
                //Interview & Investigate
                case "CAC8C2F6-E769-427B-BCFE-1B5636C90C4B": responsibility.Responsibilities.Add("Interview informants. Complete ICS302 or ICS302A"); responsibility.Responsibilities.Add("Seek out other sources of information on the subject"); responsibility.Responsibilities.Add("Liaise w/police for credit card usage, relevant police records, etc."); responsibility.Responsibilities.Add("Make every effort to verify information through additional sources"); responsibility.Responsibilities.Add("Investigate clues &/or specific information"); responsibility.Responsibilities.Add("Ensure Documentation Unit has up-to-date subject information"); responsibility.Responsibilities.Add("Post information in designated area(s) & update when required"); responsibility.Responsibilities.Add("Ensure the SAR Mgr. is immediately aware of critical information"); responsibility.Forms.Add("ICS302 LOST PERSON QUESTIONNAIRE"); responsibility.Forms.Add("ICS302A MISSING VESSEL QUESTIONNAIRE"); break;
                //Incident Status 
                case "A3891929-6FA4-4A21-BE33-F37DE24B779E": responsibility.Responsibilities.Add("Chart progress toward objectives stated in the IAP. This includes tracking & maintaining:"); responsibility.Responsibilities.Add("Assignments: # completed, # in progress, # ready & available, # & status of subjects"); responsibility.Responsibilities.Add("Maintain Status map(s)"); responsibility.Responsibilities.Add("ICS209 INCIDENT STATUS SUMMARY, may also need to be completed"); responsibility.Forms.Add("ICS209 INCIDENT STATUS SUMMARY"); break;
                //Resource Status 
                case "A7C2F2FB-3C96-4E60-83A1-3E97A6FE8BAA": responsibility.Responsibilities.Add("Complete ICS201A RESOURCE STATUS w/Agency Liaison (Command)"); responsibility.Responsibilities.Add("Monitor the status of all resources on a task:"); responsibility.Responsibilities.Add("Total number or resources on scene: # assigned, # available & # Out-of-service"); responsibility.Responsibilities.Add("SAR members and 'Other' (non-SAR) personnel on scene"); responsibility.Responsibilities.Add("Status of major equipment"); responsibility.Forms.Add("ICS201A RESOURCE STATUS"); break;
                //Brief/Debrief 
                case "F548CC74-4264-48EE-BA1A-80B53BDEE245": responsibility.Responsibilities.Add("Brief team leaders: (Role may also be filled by the Operations Section if so delegated)"); responsibility.Responsibilities.Add("Confirm assignment objective(s), skills required, equipment required, tactics"); responsibility.Responsibilities.Add("Confirm call signs, team # & assignment #"); responsibility.Responsibilities.Add("Confirm use of Communications Plan"); responsibility.Responsibilities.Add("Give copy of ICS204 TEAM ASSIGNMENT SHEET to Team Leader, w/map, ICS301"); responsibility.Responsibilities.Add("SUBJECT PROFILE & other information"); responsibility.Responsibilities.Add("Debrief:"); responsibility.Responsibilities.Add("Document Clues, pass clues over to Interview & Investigation Unit if required"); responsibility.Responsibilities.Add("Track assignments left incomplete or which have deviated from assignment"); responsibility.Responsibilities.Add("Record any hazards encountered by field teams and forward to Safety Officer"); responsibility.Responsibilities.Add("Bring items that require further attention to Planning"); responsibility.Responsibilities.Add("Ensure the debrief report is attached to assignment for review by Planning &/or filed"); break;
                //Demobilization
                case "3CB459EC-2C6B-40F8-9C5A-E59A393BA632": responsibility.Responsibilities.Add("Plan for demobilization using ICS221 DEMOBILIZATION PLAN"); responsibility.Forms.Add("ICS221 DEMOBILIZATION PLAN"); break;
                //Documentation 
                case "B87A1F9C-FDE8-4671-BF06-4E275C62099F": responsibility.Responsibilities.Add("Publish maps for assignments showing search segments"); responsibility.Responsibilities.Add("Publish subject profile sheets for briefings (ICS301 SUBJECT PROFILE)"); responsibility.Responsibilities.Add("Maintain files of past assignments, debriefing reports, etc."); responsibility.Responsibilities.Add("Work with I.C. in production of mass flyers"); responsibility.Forms.Add("ICS301 SUBJECT PROFILE"); break;

                //LOGISTICS
                //Logistics Section Chief 
                case "B641C5D6-91FE-41DA-962E-9FEB7A7300A2": responsibility.Responsibilities.Add("Delegate & supervise various Logistics roles as needs & span of control dictate"); responsibility.Responsibilities.Add("Develop appropriate sections of the Incident Action Plan"); responsibility.Responsibilities.Add("Establish working areas for Logistics functions"); responsibility.Responsibilities.Add("Liaise with other sections to determine needs"); responsibility.Responsibilities.Add("Plan for anticipated needs: next op. period & beyond (Facilities, eqpt., comms, transport, etc.)"); responsibility.Responsibilities.Add("Meet current needs & solve logistical problems"); responsibility.Forms.Add("ICS205 COMMUNICATIONS PLAN"); responsibility.Forms.Add("ICS206 MEDICAL PLAN"); responsibility.Forms.Add("ICS207 ORGANIZATION CHART (In Part)"); responsibility.Forms.Add("ICS211 CHECK-IN LIST"); responsibility.Forms.Add("ICS308 FOOD & SHELTER PLAN"); responsibility.Forms.Add("ICS303 EQUIPMENT INVENTORY (w/Operations)"); responsibility.Forms.Add("ICS307 TRANSPORTATION PLAN"); break;
                //Service Director 
                case "C2056D86-8E28-4D7B-B773-8560BAA1E772": responsibility.Responsibilities.Add("Supervise provision of services"); responsibility.Responsibilities.Add("Maintain a Needs List"); break;
                //Support Director 
                case "90334664-BFFF-463A-9F60-8683E2C07AA9": responsibility.Responsibilities.Add("Supervise provision of support resources"); responsibility.Responsibilities.Add("Provide for support of ongoing operations"); break;
                //Check-in/out 
                case "BDCCD9DD-6912-4031-A453-8E3EDA98B253": responsibility.Responsibilities.Add("Record Check-In & Check-Out of all personnel using ICS211 CHECK-IN LIST"); responsibility.Responsibilities.Add("For convergent volunteers, check photo ID & record driver’s license #."); responsibility.Forms.Add("ICS211 CHECK-IN LIST"); break;
                //Communications 
                case "04FB00EB-97BA-4744-AB00-54D4D224ABAD": responsibility.Responsibilities.Add("Establish ICS205 COMMUNICATIONS PLAN"); responsibility.Responsibilities.Add("Advise SAR Management Team of capabilities & limitations of various comms resources"); responsibility.Responsibilities.Add("Establish & maintain communication systems utilizing directed net by setting up base, mobile &"); responsibility.Responsibilities.Add("portable radios, repeaters, relays, telephone systems, computer systems, messengers, etc."); responsibility.Responsibilities.Add("Designate frequencies where appropriate for: Command net, support net, air, ground &"); responsibility.Responsibilities.Add("water operations, tactical & emergency channels and establish a system of call signs"); responsibility.Responsibilities.Add("Establish communications facility at the ICP (may be operated by Operations)"); responsibility.Responsibilities.Add("Maintain inventory & distribution of comms equipment, logging check-out & check-in"); responsibility.Responsibilities.Add("Provide support with spare batteries, replacement of damaged equipment, etc."); responsibility.Responsibilities.Add("Return equipment & systems to service"); responsibility.Forms.Add("ICS205 COMMUNICATIONS PLAN"); break;
                //Medical 
                case "F214D2B3-9268-432F-84BF-848E80C53635": responsibility.Responsibilities.Add("Complete ICS206 MEDICAL PLAN"); responsibility.Responsibilities.Add("Establish medical response team for responding to & transporting an injured searcher"); responsibility.Responsibilities.Add("Stage medical equipment where appropriate, maintain inventory of medical supplies"); responsibility.Responsibilities.Add("Ensure first aid report is completed for SAR personnel if required"); responsibility.Forms.Add("ICS206 MEDICAL PLAN"); break;
                //Food & Shelter
                case "83BB316B-42A7-4238-A647-1B9C94EA6B5A": responsibility.Responsibilities.Add("Complete ICS308 FOOD & SHELTER PLAN"); responsibility.Responsibilities.Add("Determine needs: # people, their locations, special dietary needs, transportation, etc."); responsibility.Responsibilities.Add("Arrange transportation of food through the Transportation Unit"); responsibility.Responsibilities.Add("Provide bottled water & other drinks, snacks & refreshments"); responsibility.Responsibilities.Add("Arrange lodgings for personnel"); responsibility.Forms.Add("ICS308 FOOD & SHELTER PLAN"); break;
                //Facilities 
                case "9ABA549D-BA86-46D3-9C62-EC2F3FEC36F8": responsibility.Responsibilities.Add("Setup & activate incident facilities: ICP, camps, shelters, sanitation, helispot at ICP"); responsibility.Responsibilities.Add("Provide separate facilities for family & for the media if required"); responsibility.Responsibilities.Add("Arrange for buildings, tents, trailers, etc. Arrange for heat, light, power, tables & chairs, etc."); responsibility.Responsibilities.Add("Determine support requirements for each facility"); responsibility.Responsibilities.Add("Post signs identifying & directing people to facilities"); break;
                //Supplies 
                case "CC4CC189-B92B-4DD6-87CC-5CD3200F600D": responsibility.Responsibilities.Add("Liaise with OPERATIONS & PLANNING to ensure supply needs are anticipated & met"); responsibility.Responsibilities.Add("Procure, store & distribute needed supplies & special equipment"); responsibility.Responsibilities.Add("Maintain records & inventory control. Complete ICS303 EQUIPMENT INVENTORY"); responsibility.Forms.Add("ICS303 EQUIPMENT INVENTORY"); break;
                //Transport 
                case "EDF0C322-76EE-448A-8D58-0820AAB9791B": responsibility.Responsibilities.Add("Arrange transportation, providing vehicles, operators, refueling & maintenance"); responsibility.Responsibilities.Add("Arrange long distance transportation for mutual aid & special resources when required"); break;
                //Security 
                case "E6273DAF-4F91-45A7-A6E8-59DDFDE06C72": responsibility.Responsibilities.Add("Provide security for the ICP or any other facility where necessary"); responsibility.Responsibilities.Add("Manage the assembly point to ensure that personnel arriving do not obstruct operations"); responsibility.Responsibilities.Add("Establish & monitor parking areas, control foot traffic through the ICP"); responsibility.Responsibilities.Add("Monitor the site & observe/report suspicious activity"); break;

                //ADMIN FINANCE
                //Admin/Finance Section Chief 
                case "33805F34-CD3A-49AF-94FA-DA4058577B9B": responsibility.Responsibilities.Add("Determine needs & roles of Administration/Finance Section"); responsibility.Responsibilities.Add("Establish work area(s)"); responsibility.Responsibilities.Add("Supervise Administration/Finance Section staff"); responsibility.Responsibilities.Add("Record activities of Admin/Finance Section (ICS214 UNIT LOG)"); responsibility.Responsibilities.Add("For searcher injury or fatality: ensure WCB paperwork completed, working with Logistics’"); responsibility.Responsibilities.Add("Medical Unit. Provide information for notification of next of kin"); responsibility.Responsibilities.Add("Ensure proper documentation is being prepared for the task"); responsibility.Responsibilities.Add("Participate in demobilization planning"); responsibility.Responsibilities.Add("Ensure documentation is completed & properly filed upon completion or suspension"); responsibility.Responsibilities.Add("Ensure security of all records"); responsibility.Responsibilities.Add("Collect information & documents for completion of the Task Report"); responsibility.Responsibilities.Add("Turn over complete documentation to I.C."); responsibility.Responsibilities.Add("For non-PEP operations, such as evidence searches, submit invoicing to I.C. authority"); responsibility.Forms.Add("ICS 207 ORGANIZATION CHART (In Part)"); responsibility.Forms.Add("ICS214 UNIT LOG"); break;
                //Procurement
                case "2AD6BDAC-1AE2-47EF-AEE5-B8820B674C90": responsibility.Responsibilities.Add("Maintain list of vendors"); responsibility.Responsibilities.Add("Liaise with other functions for sources of specialized equipment & materials"); responsibility.Responsibilities.Add("Take orders from Supply"); responsibility.Responsibilities.Add("Authorize & order consumables & replacement goods"); responsibility.Responsibilities.Add("Arrange delivery or pickup of goods"); responsibility.Responsibilities.Add("Collect receipts for purchases"); responsibility.Responsibilities.Add("Maintain records of orders & purchases"); responsibility.Responsibilities.Add("Issue receipts or thank-you letters for donations"); break;
                //Task Claims 
                case "E2B66759-A290-459A-B96F-3B8FE7B3D883": responsibility.Responsibilities.Add("Receive individual task claims for repair/replacement of equipment"); responsibility.Responsibilities.Add("Verify claim, ensure loss/damage is logged"); responsibility.Responsibilities.Add("Tabulate claims for meals & mileage for all personnel"); break;
                //Operation Expenses 
                case "9277DB39-D6E3-4E6C-8932-D810F7313AC9": responsibility.Responsibilities.Add("Collect bills from contractors (if not directly submitted to PEP)"); responsibility.Responsibilities.Add("Collect & tabulate receipts"); responsibility.Responsibilities.Add("Track costs for aircraft for Air Services Emergency (ASE) number"); responsibility.Responsibilities.Add("Track operational costs of vehicles (time, mileage)"); responsibility.Responsibilities.Add("Maintain totals for expenses & ensure documentation supports all expenditures"); break;

            }

            return responsibility;
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


        public static List<ICSRole> GetRolesForAssignmentList(this OrganizationChart org, Guid BranchID, int maxDepth = 0, int MaxCount = 0)
        {

            List<ICSRole> roles = new List<ICSRole>(); 
            roles.Add( org.AllRoles.FirstOrDefault(o => o.RoleID == BranchID));
            foreach(ICSRole role in org.AllRoles.Where(o=>o.ReportsTo == BranchID && o.BranchID == BranchID))
            {
                roles.Add(role);
                List<ICSRole> childRoles = org.GetChildRoles(role.RoleID, true, true);
                if(maxDepth > 0) { childRoles = childRoles.Where(o => o.Depth <= maxDepth).ToList(); }
                roles.AddRange(childRoles);
            }

            if(MaxCount > 0 && roles.Count > MaxCount && (maxDepth != 1))
            {
                roles = org.GetRolesForAssignmentList(BranchID, roles.Max(o => o.Depth) - 1, MaxCount);
            }


            return roles;
        }

        public static void SwitchToUnifiedCommand(this OrganizationChart org)
        {
            if (!org.IsUnifiedCommand)
            {
                _ = org.AllRoles.AddUnifiedCommandRoles(true);
                org.SortRoles();

                ICSRole ic = org.AllRoles.First(o => o.RoleID == Globals.IncidentCommanderID);
                ICSRole uc1 = org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID);
                if (ic.teamMember != null && ic.teamMember.PersonID != Guid.Empty && (uc1.teamMember == null || uc1.teamMember.PersonID == Guid.Empty))
                {
                    uc1.teamMember = org.AllRoles.First(o => o.RoleID == Globals.IncidentCommanderID).teamMember.Clone();
                   
                    ic.teamMember = new TeamMember(Guid.Empty);
                    
                }
                ic.RoleName = "Unified Command";
                Globals.incidentService.UpsertICSRole(org.AllRoles.First(o => o.RoleID == Globals.IncidentCommanderID));
                


                org.IsUnifiedCommand = true;
            }
        }

        public static void SwitchToSingleIC(this OrganizationChart org)
        {
            if (org.IsUnifiedCommand)
            {
                ICSRole ic = org.AllRoles.First(o => o.RoleID == Globals.IncidentCommanderID);
                ICSRole uc1 = org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID);
                if (uc1.teamMember == null && org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID).teamMember != null) { uc1 = org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID); }
                if (uc1.teamMember == null && org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID).teamMember != null) { uc1 = org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID); }

                ic.RoleName = "Incident Commander";

                if (uc1.teamMember != null)
                {
                    ic.teamMember = uc1.teamMember.Clone();
                    uc1.teamMember = null;


                }
                Globals.incidentService.UpsertICSRole(ic);
                if (org.AllRoles.Any(o => o.RoleID == Globals.UnifiedCommand1ID)) { Globals.incidentService.DeleteICSRole(org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand1ID), org.OpPeriod); }
                if (org.AllRoles.Any(o => o.RoleID == Globals.UnifiedCommand2ID))
                {
                    Globals.incidentService.DeleteICSRole(org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand2ID), org.OpPeriod);
                }
                if (org.AllRoles.Any(o => o.RoleID == Globals.UnifiedCommand3ID))
                {
                    Globals.incidentService.DeleteICSRole(org.AllRoles.First(o => o.RoleID == Globals.UnifiedCommand3ID), org.OpPeriod);
                }





                org.IsUnifiedCommand = false;
            }
        }

   

        public static List<ICSRole> GetBlankRolesBasedOnThisChart(OrganizationChart ogOrgChart, int newOpPeriod, Guid newChartID)
        {
            TeamMember blankMember = new TeamMember();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();

            foreach(ICSRole role in ogOrgChart.AllRoles)
            {
                ICSRole newRole = role.Clone();
                newRole.teamMember = blankMember;
                newRole.OrganizationalChartID = newChartID;
                newRole.OpPeriod = newOpPeriod;
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
            roles.AddRange(orgChart.AllRoles.Where(o => o.ReportsTo == ParentRoleID).ToList());
            if (ExcludeAgencyReps) { roles = roles.Where(o => !o.RoleName.Equals("Agency Representative")).ToList(); }
            if (getAllDecendants)
            {
                List<ICSRole> directChildren = new List<ICSRole>();
                foreach (ICSRole role in roles)
                {
                    directChildren.AddRange(orgChart.GetChildRoles(role.RoleID, getAllDecendants, ExcludeAgencyReps));
                }
                roles.AddRange(directChildren);
            }
            return roles;
        }

        public static List<ICSRole> AddUnifiedCommandRoles(this List<ICSRole> list, bool upsertToIncident = false)
        {
            TeamMember blankMember = new TeamMember();
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
            if (role.teamMember == null) { return true; }
            if (role.teamMember.PersonID == Guid.Empty) { return true; }
            else { return false; }
        }


        public static List<ICSRole> GetBlankPrimaryRoles(bool UnifiedCommand = false)
        {
            TeamMember blankMember = new TeamMember();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();
            //AllRoles.Add(new ICSRole(new Guid("98649093-2C0D-4D23-9EC1-2AF16ED83B2A"), "SAR Commander", Guid.Empty, "Text1", blankMember));
            AllRoles.Add(new ICSRole(Globals.IncidentCommanderID, "Incident Commander", Guid.Empty, Globals.IncidentCommanderID, "IncidentCommander", blankMember, 0, 0));
            if (UnifiedCommand)
            {
                AllRoles = AllRoles.AddUnifiedCommandRoles();
            }

            AllRoles.Add(new ICSRole(new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA"), "Deputy Incident Commander", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "DeputyIC", blankMember, 1, 1));
            AllRoles.Add(new ICSRole(Globals.SafetyOfficerID, "Safety Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "SafetyOfficer", blankMember, 2, 1));
            AllRoles.Add(new ICSRole(new Guid("8428ed1e-80de-4b5d-a7ab-ae48ad5f1bce"), "Clerk", Globals.SafetyOfficerID, Globals.IncidentCommanderID, "NameSafety1", "TitleSafety1", blankMember, 2, 1));

            AllRoles.Add(new ICSRole(new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), "Liaison Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "LiaisonOfficer", blankMember, 3, 1));
            AllRoles.Add(new ICSRole(new Guid("63394cb1-443c-4492-9e7b-d15e22226b6b"), "Clerk", new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), Globals.IncidentCommanderID, "NameLiaison1", "TitleLiaison1", blankMember, 3, 1));
            
            AllRoles.Add(new ICSRole(new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), "Information Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "Text2", blankMember, 4, 1));
            AllRoles.Add(new ICSRole(new Guid("f4975464-ed47-43ee-a229-47fd9997ebd9"), "Clerk", new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), Globals.IncidentCommanderID, "NameInfo1", "TitleInfo1", blankMember, 4, 1));

            //Ops
            AllRoles.Add(new ICSRole(Globals.OpsChiefID, "Operations Section Chief", Globals.IncidentCommanderID, Globals.OpsChiefID, "Text3", blankMember, 5, 1));
            AllRoles.Add(new ICSRole(Globals.AirOpsDirector, "Air Operations Branch Director", Globals.OpsChiefID, Globals.OpsChiefID, "AirOpsDirector", blankMember, 98, 2));
            AllRoles.Add(new ICSRole(new Guid("0da445fe-99d5-4cfe-b746-cbe46b20e314"), "Air Support Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("f16d6d47-a334-4c88-9bbc-8034ee9c2a32"), "Air Tactical Group Supervisor", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("b1fd775b-7311-4d9d-a1bf-a7d32c4d7ed2"), "Helicopter Coordinator", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("803955a6-973f-470e-a8a4-bd86197700c0"), "Helibase Manager", Globals.AirOpsDirector, Globals.OpsChiefID, null, blankMember, 99, 3));


            AllRoles.Add(new ICSRole(new Guid("3A79ED80-9B06-4923-95F7-BE1B8B554FFD"), "Staging Area Manager", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps1", "TitleOps1", blankMember, 97, 2));
            AllRoles.Add(new ICSRole(new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c"), "Branch/Division/Group1", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps2", "TitleOps2", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9727f016-aed9-4f34-99db-910a06b97f2e"), "Branch/Division/Group2", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps3", "TitleOps3", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9"), "Branch/Division/Group3", Globals.OpsChiefID, Globals.OpsChiefID, "NameOps4", "TitleOps4", blankMember, 99, 2));
            




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


        public static List<ICSRole> GetAllRoles()
        {
            //This is an exhuastive list of all possible ics role names from CIFFC and includes mnemonic and description 
            List<ICSRole> allRoles = new List<ICSRole>();
            allRoles.Add(new ICSRole("Air Attack Officer", Globals.OpsChiefID, "AAON", "The person responsible for directing, coordinating, and supervising a fire suppression operation involving the use of aircraft to deliver retardants or suppressants on a fire."));
            allRoles.Add(new ICSRole("Area Commander", Globals.IncidentCommanderID, "ACDR", "The person responsible to manage a very large incident that has multiple IMTs assigned. These teams may be established any time the incidents are close enough that oversight direction is required."));
            allRoles.Add(new ICSRole("Assistant Area Commander, Logistics", Globals.LogisticsChiefID, "ACLC", "The person responsible for providing facilities, services, and material at the Area Command level, and for ensuring effective use of critical resources and supplies among the incident management teams."));
            allRoles.Add(new ICSRole("Air Operations Branch Director", Globals.OpsChiefID, "AOBD", "The person primarily responsible for managing the resources within the air operations branch, as well as preparing and implementing the air operations portion of the Incident Action Plan. Also responsible for providing logistical support to helicopters operating on the incident."));
            allRoles.Add(new ICSRole("Agency Representative", Globals.IncidentCommanderID, "AREP", "The person assigned by a primary, assisting, or cooperating agency to an incident who has been delegated authority to make decisions affecting that agency’s participation at the incident."));
            allRoles.Add(new ICSRole("Air Support Group Supervisor", Globals.OpsChiefID, "ASGS", "The person responsible for planning and oversight of incident aircraft support functions (helibase, helispot and Fixed Wing Air Bases)."));
            allRoles.Add(new ICSRole("Air Tactical Group Supervisor", Globals.OpsChiefID, "ATGS", "The person primarily responsible for the coordination of all tactical missions of fixed and/or rotary wing aircraft operating in incident airspace."));
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
            allRoles.Add(new ICSRole("Division Supervisor", Globals.OpsChiefID, "DIVS", "The person responsible for supervising equipment and personnel assigned to a division. Reports to a Branch Director or Operations Section Chief."));
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
            allRoles.Add(new ICSRole("Heavy Equipment Branch Director", Globals.OpsChiefID, "HEBD", "The person responsible to supervise and manage the overall operations for all heavy equipment on an incident. This person will prioritize the need and allocation of heavy equipment for the incident."));
            allRoles.Add(new ICSRole("Helibase Manager", Globals.OpsChiefID, "HEBM", "The person responsible for controlling helicopter take-offs and landings at a helibase, managing helibase assigned helicopters, supplies, fire retardant mixing and loading."));
            allRoles.Add(new ICSRole("Heavy Equipment Group Supervisor", Globals.OpsChiefID, "HEGS", "The person responsible for supervising and directing operations of assigned heavy equipment, including heavy equipment strike teams/task forces or single resources."));
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
            allRoles.Add(new ICSRole("Operations Branch Director", Globals.OpsChiefID, "OPBD", "The person responsible for implementing the portion of the Incident Action Plan applicable to the assigned Branch of the Operations Section."));
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
            allRoles.Add(new ICSRole("Sector Leader", Globals.OpsChiefID, "SCLD", "The person responsible for directing a combination of personnel, crews, or other types of equipment in performing tactical missions on a sector (specific piece of fire line)."));
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
            allRoles.Add(new ICSRole("Strike Team Leader", Globals.OpsChiefID, "STLD", "The individual responsible for supervising a strike team (usually dozers, engines, or crews), and reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Add(new ICSRole("Support Branch Director", Globals.LogisticsChiefID, "SUBD", "The person responsible for developing and implementing logistics plans in support of the Incident Action Plan. The Support Branch Director supervises the operations of the Supply, Facilities, and Ground Support Units."));
            allRoles.Add(new ICSRole("Service Branch Director", Globals.LogisticsChiefID, "SVBD", "The person responsible for managing all service activities at the incident. The Service Branch Director supervises the operations of the Communications, Medical, and Food Unit Leaders."));
            allRoles.Add(new ICSRole("Task Force Leader", Globals.OpsChiefID, "TFLD", "The individual responsible for supervising a task force. Reports to a Division/Group Supervisor or Operations Section Chief."));
            allRoles.Add(new ICSRole("Technical Specialist", Guid.Empty, "THSP", "Personnel with special skills that can be used anywhere within the Incident Command System organization."));
            allRoles.Add(new ICSRole("Time Unit Leader", Globals.FinanceChiefID, "TIME", "The person responsible for recording personnel time."));


            return allRoles;
        }
     
        public static ICSRole GetRoleByName (this OrganizationChart orgChart, string rolename, bool defaultUpChain = true)
        {
            ICSRole role = orgChart.GetRoleByName(rolename);
            TeamMember member = role.teamMember;

            if (defaultUpChain && string.IsNullOrEmpty(member.Name) && role.ReportsTo != Guid.Empty)
            {
                role = orgChart.GetRoleByID(role.ReportsTo, true);


            }

            return role;
        }

        public static ICSRole GetRoleByID(this OrganizationChart orgChart, Guid id, bool defaultUpChain = true)
        {
            if (orgChart.AllRoles.Any(o => o.RoleID == id))
            {
                ICSRole role = orgChart.GetAllRoles().First(o => o.RoleID == id);
                if(defaultUpChain && (role.teamMember == null || string.IsNullOrEmpty(role.teamMember.Name)) && role.ReportsTo != Guid.Empty)
                {
                    role = orgChart.GetRoleByID(role.ReportsTo, true);
                }
                return role;
            }
            return null;
        }

        public static ICSRole GetRoleByName(this OrganizationChart orgChart, string name)
        {
            List<ICSRole> roles = orgChart.AllRoles;
            if (roles.Any(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
            {
                return roles.First(o => o.RoleName.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            }
            else { return null; }
        }

        public static List<ICSRole> GetAllRoles(this OrganizationChart orgChart)
        {
            return orgChart.AllRoles;
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
            children = children.OrderBy(o => o.MaualSortOrder).ThenBy(o => o.RoleName).ToList();
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

            foreach (ICSRole role in currentChart.AllRoles.Where(o => !string.IsNullOrEmpty(o.PDFFieldName)))
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
            csv.Append("Phone"); csv.Append(delimiter);
            csv.Append(Environment.NewLine);

            foreach (ICSRole item in roles)
            {

                //csv.Append("\"");  csv.Append(member.StringForQR.EscapeQuotes()); csv.Append("\""); 
                string branch = GetBranchNameFromID(item.BranchID);
                csv.Append("\""); csv.Append(branch.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.RoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.ReportsToRoleName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); csv.Append(item.IndividualName.EscapeQuotes()); csv.Append("\""); csv.Append(delimiter);
                csv.Append("\""); if (item.teamMember != null) { csv.Append(item.teamMember.Phone.EscapeQuotes()); }                csv.Append("\""); csv.Append(delimiter);

                csv.Append(Environment.NewLine);
            }
            return csv.ToString();
        }
    }
}