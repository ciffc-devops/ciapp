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
        [ProtoMember(4)] public List<ICSRole> AllRoles { get; set; }
        [ProtoMember(5)] private DateTime _LastUpdatedUTC;
        [ProtoMember(6)] private Guid _OrganizationalChartID;
        [ProtoMember(7)] private Guid _PreparedByUserID;
        [ProtoMember(8)] private bool _Active;
        [ProtoMember(9)] private Guid _TaskID;
        [ProtoMember(10)] private string _PreparedByRole;

        public Guid TaskID { get => _TaskID; set => _TaskID = value; }
        public bool Active { get => _Active; set => _Active = value; }
        public Guid PreparedByUserID { get => _PreparedByUserID; set => _PreparedByUserID = value; }
        public string PreparedByRole { get => _PreparedByRole; set => _PreparedByRole= value; }
        public Guid OrganizationalChartID { get => _OrganizationalChartID; set => _OrganizationalChartID = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }
        public DateTime DatePrepared { get => _DatePreparedUTC.ToLocalTime(); set => _DatePreparedUTC = value.ToUniversalTime(); }
        public DateTime DatePreparedUTC { get => _DatePreparedUTC; set => _DatePreparedUTC = value; }
      

        
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
                else { return RoleName + " - unassigned"; }
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
        }
        public ICSRole(Guid id, string name, Guid reports, Guid Branch, string pdfname, string pdftitle, TeamMember member, int maualSortOrder = 99, int initial_depth = 0)
        {
            RoleID = id; RoleName = name; ReportsTo = reports; PDFFieldName = pdfname; teamMember = member; BranchID = Branch; _OrgChartRoleID = System.Guid.NewGuid();
            PDFTitleName = pdftitle;
            MaualSortOrder = maualSortOrder; Depth = initial_depth;
        }

        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public int Depth { get => _Depth; set => _Depth = value; }


        
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
        public static List<Guid> ProtectedRoleIDs
        {
            get
            {
                List<Guid> ids = new List<Guid>();
                ids.Add(Globals.IncidentCommanderID);
                ids.Add(Globals.DeputyIncidentCommanderID);
                ids.Add(Globals.OpsChiefID);
                ids.Add(Globals.PlanningChiefID);
                ids.Add(Globals.LogisticsChiefID);
                ids.Add(Globals.AdminChiefID);
                ids.Add(Globals.SafetyOfficerID);
                return ids;
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

        public static List<ICSRole> GetChildRoles(this OrganizationChart orgChart, Guid ParentRoleID, bool getAllDecendants = true)
        {
            List<ICSRole> roles = new List<ICSRole>();
            roles.AddRange(orgChart.AllRoles.Where(o => o.ReportsTo == ParentRoleID).ToList());
            if (getAllDecendants)
            {
                List<ICSRole> directChildren = new List<ICSRole>();
                foreach (ICSRole role in roles)
                {
                    directChildren.AddRange(orgChart.GetChildRoles(role.RoleID));
                }
                roles.AddRange(directChildren);
            }
            return roles;
        }

        public static List<ICSRole> GetBlankPrimaryRoles()
        {
            TeamMember blankMember = new TeamMember();
            blankMember.PersonID = Guid.Empty;

            List<ICSRole> AllRoles = new List<ICSRole>();
            //AllRoles.Add(new ICSRole(new Guid("98649093-2C0D-4D23-9EC1-2AF16ED83B2A"), "SAR Commander", Guid.Empty, "Text1", blankMember));
            AllRoles.Add(new ICSRole(Globals.IncidentCommanderID, "Incident Commander", Guid.Empty, Globals.IncidentCommanderID, "IncidentCommander", blankMember, 0, 0));
            AllRoles.Add(new ICSRole(new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA"), "Deputy Incident Commander", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "DeputyIC", blankMember, 1, 1));
            AllRoles.Add(new ICSRole(Globals.SafetyOfficerID, "Safety Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "SafetyOfficer", blankMember, 2, 1));
            AllRoles.Add(new ICSRole(new Guid("ECAEA544-95E6-4177-B954-F2A8D4027642"), "Liaison Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "LiaisonOfficer", blankMember, 3, 1));
            AllRoles.Add(new ICSRole(new Guid("91C6C1B6-92F2-4959-8A01-198240340571"), "Information Officer", Globals.IncidentCommanderID, Globals.IncidentCommanderID, "Text2", blankMember, 4, 1));

            //Ops
            AllRoles.Add(new ICSRole(Globals.OpsChiefID, "Operations Section Chief", Globals.IncidentCommanderID, Globals.OpsChiefID, "Text3", blankMember, 5, 1));
            AllRoles.Add(new ICSRole(new Guid("3A79ED80-9B06-4923-95F7-BE1B8B554FFD"), "Staging Area Manager", Globals.OpsChiefID, Globals.OpsChiefID, "Text4", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("b01ea351-0578-4eb0-b8ca-d319efa74b7c"), "Branch/Division/Group1", Globals.OpsChiefID, Globals.OpsChiefID, "Text5", "Title5", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9727f016-aed9-4f34-99db-910a06b97f2e"), "Branch/Division/Group2", Globals.OpsChiefID, Globals.OpsChiefID, "Text6", "Title6", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9e75f813-cab4-4a6c-87b7-0fc141f06df9"), "Branch/Division/Group3", Globals.OpsChiefID, Globals.OpsChiefID, "Text7", "Title7", blankMember, 99, 2));


            //Planning
            AllRoles.Add(new ICSRole(Globals.PlanningChiefID, "Planning Section Chief", Globals.IncidentCommanderID, Globals.PlanningChiefID, "Text8", blankMember, 6, 1));
            AllRoles.Add(new ICSRole(new Guid("A3891929-6FA4-4A21-BE33-F37DE24B779E"), "Situation Unit", Globals.PlanningChiefID, Globals.PlanningChiefID, "Text12", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("A7C2F2FB-3C96-4E60-83A1-3E97A6FE8BAA"), "Resources Unit", Globals.PlanningChiefID, Globals.PlanningChiefID, "Text11", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("3CB459EC-2C6B-40F8-9C5A-E59A393BA632"), "Demobilization Unit", Globals.PlanningChiefID, Globals.PlanningChiefID, "Text14", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("B87A1F9C-FDE8-4671-BF06-4E275C62099F"), "Documentation Unit", Globals.PlanningChiefID, Globals.PlanningChiefID, "Text13", blankMember, 99, 2));

            //Logistics
            AllRoles.Add(new ICSRole(Globals.LogisticsChiefID, "Logistics Section Chief", Globals.IncidentCommanderID, Globals.LogisticsChiefID, "Text9", blankMember, 7, 1));
            AllRoles.Add(new ICSRole(new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), "Service Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "Text19", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("04FB00EB-97BA-4744-AB00-54D4D224ABAD"), "Communications Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "Text20", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("F214D2B3-9268-432F-84BF-848E80C53635"), "Medical Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "Text21", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("83BB316B-42A7-4238-A647-1B9C94EA6B5A"), "Food Unit Leader", new Guid("C2056D86-8E28-4D7B-B773-8560BAA1E772"), Globals.LogisticsChiefID, "Text22", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), "Support Branch Director", Globals.LogisticsChiefID, Globals.LogisticsChiefID, "Text23", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9ABA549D-BA86-46D3-9C62-EC2F3FEC36F8"), "Facilities Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "Text24", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("CC4CC189-B92B-4DD6-87CC-5CD3200F600D"), "Supply Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "Text25", blankMember, 99, 3));
            AllRoles.Add(new ICSRole(new Guid("EDF0C322-76EE-448A-8D58-0820AAB9791B"), "Gr. Support Unit Leader", new Guid("90334664-BFFF-463A-9F60-8683E2C07AA9"), Globals.LogisticsChiefID, "Text26", blankMember, 99, 3));

            //Admin
            AllRoles.Add(new ICSRole(Globals.AdminChiefID, "Admin/Finance Section Chief", Globals.IncidentCommanderID, Globals.AdminChiefID, "Text10", blankMember, 8, 1));
            AllRoles.Add(new ICSRole(new Guid("2AD6BDAC-1AE2-47EF-AEE5-B8820B674C90"), "Procurement Unit", Globals.AdminChiefID, Globals.AdminChiefID, "Text17", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("E2B66759-A290-459A-B96F-3B8FE7B3D883"), "Time Unit", Globals.AdminChiefID, Globals.AdminChiefID, "Text15", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Cost Unit", Globals.AdminChiefID, Globals.AdminChiefID, "Text16", blankMember, 99, 2));
            AllRoles.Add(new ICSRole(new Guid("9277DB39-D6E3-4E6C-8932-D810F7313AC9"), "Compensation / Claims Unit", Globals.AdminChiefID, Globals.AdminChiefID, "Text18", blankMember, 99, 2));

            foreach(ICSRole role in AllRoles)
            {
                if(AllRoles.Any(o=>o.RoleID == role.ReportsTo))
                {
                    role.ReportsToRoleName = AllRoles.First(o => o.RoleID == role.ReportsTo).RoleName;
                }
            }

            return AllRoles;
        }

        public static ICSRole GetRoleByName (this OrganizationChart orgChart, string rolename, bool defaultUpChain = true)
        {
            ICSRole role = orgChart.GetRoleByName(rolename);
            TeamMember member = role.teamMember;

            if (defaultUpChain && string.IsNullOrEmpty(member.Name))
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
                if(defaultUpChain && (role.teamMember == null || string.IsNullOrEmpty(role.teamMember.Name)))
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
    }
}