﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary.Networking;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    public class GeneralOptions
    {
        [ProtoMember(1)] private bool appSettingsChanged;
        [ProtoMember(2)] private Guid g_primaryChannel;
        [ProtoMember(3)] private Guid g_secondaryChannel;
        [ProtoMember(4)] private Guid g_emergencyChannel;
        [ProtoMember(5)] private Guid g_repeaterChannel;
        [ProtoMember(6)] private string s_icpCallSign;
        [ProtoMember(7)] private bool b_twoCopiesOf204;
        [ProtoMember(8)] private bool b_includeSMEAC;
        [ProtoMember(9)] private bool b_includeSubjectProfile;
        [ProtoMember(10)] private string s_positionFormat = "UTM";
        [ProtoMember(11)] private bool b_includeLostPersonQuestionnaire;
        [ProtoMember(12)] private bool b_autoSave = true;
        [ProtoMember(13)] private bool b_includeSafetyWithIAP = true;
        [ProtoMember(14)] private string s_defaultSaveLocation = null;
        // [ProtoMember(15)] private User u_sync_user = new User();
        // [ProtoMember(16)] private Guid g_sync_id = Guid.Empty;
        [ProtoMember(17)] private int i_checkinInterval = 60;
        [ProtoMember(18)] private int i_eccCheckinInterval = 120;
        [ProtoMember(19)] private string s_lastServerIP = null;
        [ProtoMember(20)] private string s_lastPort = "42999";
        [ProtoMember(21)] private DateTime d_lastUpdateCheck = DateTime.MinValue;
        [ProtoMember(22)] private Guid _OrganizationID;
        [ProtoMember(23)] private bool _ECCReminderThisDevice;
        [ProtoMember(24)] private bool _AllowStringTaskNumber;
        [ProtoMember(25)] private string _TeamNameFormat;
        [ProtoMember(26)] private bool _defaultListenForQR;
        [ProtoMember(27)] private bool _defaultCommsOpen;
        [ProtoMember(28)] private bool _includeOrgContactListInIAP;
        [ProtoMember(29)] private bool _includeWeatherInIAP;
        [ProtoMember(30)] private bool _color204ByType;
        [ProtoMember(31)] private bool _leaveSpaceIn204SMEAC;
        [ProtoMember(32)] private bool _defaultToServer;
        [ProtoMember(33)] private int _defaultPortNumber;
        [ProtoMember(34)] private bool _includeExecutionIn204Briefings;
        [ProtoMember(35)] private bool _includeOtherContactsWithIAP;
        [ProtoMember(36)] private bool _promptForInitialSave;
        [ProtoMember(37)] private List<Aircraft> _AircraftList = new List<Aircraft>();
        

        [ProtoMember(38)] private List<SafetyMessage> _safetyMessages = new List<SafetyMessage>();
        [ProtoMember(39)] private Briefing b_briefingTemplate = new Briefing(false);
        [ProtoMember(40)] private List<IncidentObjective> l_allPresetObjectives = new List<IncidentObjective>();
        [ProtoMember(41)] private List<Hospital> l_allHospitals = new List<Hospital>();
        [ProtoMember(42)] private List<AmbulanceService> l_allAmbulanceServices = new List<AmbulanceService>();
        [ProtoMember(43)] private List<CommsPlanItem> l_allCommsPlanItems = new List<CommsPlanItem>();
        [ProtoMember(44)] private List<Personnel> l_allTeamMembers = new List<Personnel>();
        [ProtoMember(45)] private List<DeviceInformation> _SavedNetworkDeviceList = new List<DeviceInformation>();
        [ProtoMember(46)] private List<CannedCommsLogEntry> l_AllCannedCommsEntries = new List<CannedCommsLogEntry>();
        [ProtoMember(47)] private List<Contact> l_AllContacts = new List<Contact>();
        [ProtoMember(48)] private List<Vehicle> l_AllVehicles = new List<Vehicle>();
        [ProtoMember(49)] private List<string> l_recentFilePaths = new List<string>();
        [ProtoMember(50)] private List<EquipmentCategory> _AllEquipmentCategories = new List<EquipmentCategory>();
        [ProtoMember(51)] private List<Equipment> _AllEquipment = new List<Equipment>();
        [ProtoMember(52)] private List<EquipmentSet> _AllEquipmentSets = new List<EquipmentSet>();
        [ProtoMember(53)] private ICSRole _defaultICSRole = new ICSRole();
        [ProtoMember(54)] private bool _debriefPOD;
        [ProtoMember(55)] private bool _useOldTeamAssignmentScreen;
        [ProtoMember(56)] private bool _useSimpleDebrief;
        [ProtoMember(57)] private ShortcutButtonOption[] _shortcutButtons;
        [ProtoMember(58)] private bool _AutomaticBackups;
        [ProtoMember(59)] private int _AutoBackupIntervalMinutes;
        [ProtoMember(60)] private string _LastIpUsedWhenMachineIsServer;
        [ProtoMember(61)] private List<string> _AutomaticSubFolders = new List<string>();
        [ProtoMember(62)] private string _DefaultBackupFolder;
        [ProtoMember(63)] private Guid _ParentOrganizationID;
        [ProtoMember(64)] private bool _AddIMTToContacts;
        [ProtoMember(65)] private Province _DefaultProvince;
        [ProtoMember(66)] private List<TeamAssignment> _AllTeamAssignmentTemplates = new List<TeamAssignment>();
        [ProtoMember(67)] private string _DateFormat;
        [ProtoMember(33)] private int _YellowResourceTimeoutDays;
        [ProtoMember(33)] private int _RedResourceTimeoutDays;

        [ProtoMember(68)] private byte[] _OrganizationLogo;
        [ProtoMember(69)] private string _OrganizationName;
        [ProtoMember(70)] private bool _ShowTestButton;


        public void setAppSettingsChanged() { appSettingsChanged = true; }
        public Guid PrimaryChannelID { get { return g_primaryChannel; } set { g_primaryChannel = value; appSettingsChanged = true; } }

        public Guid SecondaryChannelID { get { return g_secondaryChannel; } set { g_secondaryChannel = value; appSettingsChanged = true; } }

        public Guid EmergencyChannelID { get { return g_emergencyChannel; } set { g_emergencyChannel = value; appSettingsChanged = true; } }

        public Guid RepeaterChannelID { get { return g_repeaterChannel; } set { g_repeaterChannel = value; appSettingsChanged = true; } }

        public string ICPCallSign { get { return s_icpCallSign; } set { s_icpCallSign = value; appSettingsChanged = true; } }
        public bool TwoCopiesOf204 { get { return b_twoCopiesOf204; } set { b_twoCopiesOf204 = value; appSettingsChanged = true; } }
        public bool IncludeSMEAC { get { return b_includeSMEAC; } set { b_includeSMEAC = value; appSettingsChanged = true; } }
        public bool IncludeSubjectProfile { get { return b_includeSubjectProfile; } set { b_includeSubjectProfile = value; appSettingsChanged = true; } }

        public bool IncludeLostPersonQuestionnaire { get { return b_includeLostPersonQuestionnaire; } set { b_includeLostPersonQuestionnaire = value; appSettingsChanged = true; } }
        public string PositionFormat { get { return s_positionFormat; } set { s_positionFormat = value; appSettingsChanged = true; } }
        public bool AutoSave { get { return b_autoSave; } set { b_autoSave = value; appSettingsChanged = true; } }
        public bool IncludeSafetyWithIAP { get { return b_includeSafetyWithIAP; } set { b_includeSafetyWithIAP = value; appSettingsChanged = true; } }
        public string DefaultSaveLocation { get { return s_defaultSaveLocation; } set { s_defaultSaveLocation = value; appSettingsChanged = true; } }
        public string DefaultBackupLocation { get { return _DefaultBackupFolder; } set { _DefaultBackupFolder = value; appSettingsChanged = true; } }

        //  public User SyncUser { get { return u_sync_user; } set { u_sync_user = value; appSettingsChanged = true; } }
        //  public Guid SyncID { get { return g_sync_id; } set { g_sync_id = value; appSettingsChanged = true; } }
        public int CheckinInterval { get { return i_checkinInterval; } set { i_checkinInterval = value; appSettingsChanged = true; } }
        public int ECCCheckinInterval { get { return i_eccCheckinInterval; } set { i_eccCheckinInterval = value; appSettingsChanged = true; } }
        public string LastServerIP { get { return s_lastServerIP; } set { s_lastServerIP = value; appSettingsChanged = true; } }
        public string LastPort { get { return s_lastPort; } set { s_lastPort = value; appSettingsChanged = true; } }

        public bool IncludeExecutionIn204Briefings
        {
            get { return _includeExecutionIn204Briefings; }
            set { _includeExecutionIn204Briefings = value; appSettingsChanged = true; }
        }
        public ShortcutButtonOption[] ShortcutButtons { get => _shortcutButtons; set { _shortcutButtons = value; appSettingsChanged = true; } }

        public Guid OrganizationID { get => _OrganizationID; set { _OrganizationID = value; appSettingsChanged = true; } }

        public DateTime LastUpdateCheck { get { return d_lastUpdateCheck; } set { d_lastUpdateCheck = value; appSettingsChanged = true; } }
        //   public List<PresetTeamAssignment> allPresetTeamAssignments { get { return l_allPresetTeamAssignments; } set { l_allPresetTeamAssignments = value; appSettingsChanged = true; } }
        //   public List<PresetTeamAssignment> sortedAllPresetTeamAssignments { get { return l_allPresetTeamAssignments.OrderBy(o => o.AssignmentName).ToList(); } }
        public List<Hospital> AllHospitals { get { return l_allHospitals; } set { l_allHospitals = value; appSettingsChanged = true; } }
        public List<AmbulanceService> AllAmbulanceServices { get { return l_allAmbulanceServices; } set { l_allAmbulanceServices = value; appSettingsChanged = true; } }
        //public List<SafetyPlan> allPresetSafetyPlans { get { return l_allPresetSafetyPlans; } set { l_allPresetSafetyPlans = value; appSettingsChanged = true; } }
        public List<SafetyMessage> safetyMessages { get => _safetyMessages; set { _safetyMessages = value; appSettingsChanged = true; } }
        public Briefing BriefingTemplate { get { return b_briefingTemplate; } set { b_briefingTemplate = value; appSettingsChanged = true; } }
        public List<IncidentObjective> allPresetObjectives { get { return l_allPresetObjectives; } set { l_allPresetObjectives = value; appSettingsChanged = true; } }
        public List<CommsPlanItem> allCommsPlanItems { get { return l_allCommsPlanItems; } set { l_allCommsPlanItems = value; appSettingsChanged = true; } }
        public List<string> RecentFilePaths { get { return l_recentFilePaths; } set { l_recentFilePaths = value; appSettingsChanged = true; } }
        public List<Personnel> AllTeamMembers { get { return l_allTeamMembers; } set { l_allTeamMembers = value; appSettingsChanged = true; } }
        public List<DeviceInformation> SavedNetworkDeviceList { get => _SavedNetworkDeviceList; set => _SavedNetworkDeviceList = value; }
        public List<CannedCommsLogEntry> AllCannedCommsLogEntries { get => l_AllCannedCommsEntries; set => l_AllCannedCommsEntries = value; }
        public List<Contact> AllContacts { get => l_AllContacts; set => l_AllContacts = value; }
        public List<Vehicle> AllVehicles { get => l_AllVehicles; set => l_AllVehicles = value; }
        public List<EquipmentCategory> AllEquipmentCategories { get => _AllEquipmentCategories; set => _AllEquipmentCategories = value; }
        public List<Equipment> AllEquipment { get => _AllEquipment; set => _AllEquipment = value; }
        public List<EquipmentSet> AllEquipmentSets { get => _AllEquipmentSets; set => _AllEquipmentSets = value; }
        public List<Aircraft> AircraftList { get => _AircraftList; set => _AircraftList = value; }
        public List<TeamAssignment> AllTeamAssignmentTemplates { get => _AllTeamAssignmentTemplates; set => _AllTeamAssignmentTemplates = value; }
        public bool ECCReminderThisDevice { get => _ECCReminderThisDevice; set { _ECCReminderThisDevice = value; appSettingsChanged = true; } }
        public bool AllowStringTaskNumber { get => _AllowStringTaskNumber; set { _AllowStringTaskNumber = value; appSettingsChanged = true; } }
        public string TeamNameFormat { get => _TeamNameFormat; set { _TeamNameFormat = value; appSettingsChanged = true; } }
        public bool DefaultListenForQR { get => _defaultListenForQR; set { _defaultListenForQR = value; appSettingsChanged = true; } }
        public bool DefaultCommsOpen { get => _defaultCommsOpen; set { _defaultCommsOpen = value; appSettingsChanged = true; } }
        public bool IncludeOrgContactsInIAP { get => _includeOrgContactListInIAP; set { _includeOrgContactListInIAP = value; appSettingsChanged = true; } }
        public bool IncludeWeatherInIAP { get => _includeWeatherInIAP; set { _includeWeatherInIAP = value; appSettingsChanged = true; } }
        public bool Color204ByType { get => _color204ByType; set { _color204ByType = value; appSettingsChanged = true; } }
        public bool LeaveSpaceIn204SMEAC { get => _leaveSpaceIn204SMEAC; set { _leaveSpaceIn204SMEAC = value; appSettingsChanged = true; } }
        public bool DefaultToServer { get => _defaultToServer; set { _defaultToServer = value; appSettingsChanged = true; } }
        public int DefaultPortNumber { get => _defaultPortNumber; set { _defaultPortNumber = value; appSettingsChanged = true; } }
        public bool IncludeOtherContactsWithIAP { get => _includeOtherContactsWithIAP; set => _includeOtherContactsWithIAP = value; }
        public bool PromptForInitialSave { get => _promptForInitialSave; set => _promptForInitialSave = value; }
        public bool DebriefPOD { get => _debriefPOD; set => _debriefPOD = value; }
        public ICSRole DefaultICSRole { get => _defaultICSRole; set => _defaultICSRole = value; }
        public bool UseOldTeamAssignmentScreen { get => _useOldTeamAssignmentScreen; set => _useOldTeamAssignmentScreen = value; }
        public bool UseSimpleDebrief { get => _useSimpleDebrief; set => _useSimpleDebrief = value; }
        public bool OptionsLoadedSuccessfully { get; set; }
        public bool AutomaticBackups { get => _AutomaticBackups; set => _AutomaticBackups = value; }
        public int AutoBackupIntervalMinutes { get => _AutoBackupIntervalMinutes; set => _AutoBackupIntervalMinutes = value; }
        public string LastIpUsedWhenMachineIsServer { get => _LastIpUsedWhenMachineIsServer; set => _LastIpUsedWhenMachineIsServer = value; }
        public List<string> AutomaticSubFolders { get => _AutomaticSubFolders; set => _AutomaticSubFolders = value; }
        public string AutomaticSubFoldersCSV { get { StringBuilder sb = new StringBuilder(); foreach (string s in AutomaticSubFolders) { if (sb.Length > 0) { sb.Append(", "); } sb.Append(s); } return sb.ToString(); } }
        public Guid ParentOrganizationID { get => _ParentOrganizationID; set => _ParentOrganizationID = value; }
        public bool AddIMTToContacts { get => _AddIMTToContacts; set => _AddIMTToContacts = value; }
        public Province DefaultProvince { get => _DefaultProvince; set => _DefaultProvince = value; }
        public string DateFormat { get => _DateFormat; set => _DateFormat = value; }

        public int YellowResourceTimeoutDays { get { return _YellowResourceTimeoutDays; } set { _YellowResourceTimeoutDays = value; appSettingsChanged = true; } }
        public int RedResourceTimeoutDays { get { return _RedResourceTimeoutDays; } set { _RedResourceTimeoutDays = value; appSettingsChanged = true; } }

        public byte[] OrganizationLogo { get => _OrganizationLogo; set => _OrganizationLogo = value; }
        public string OrganizationName { get => _OrganizationName; set => _OrganizationName = value; }
        public bool ShowTestButton { get => _ShowTestButton; set => _ShowTestButton = value; }

        public void addDefaultOptions()
        {
            ICPCallSign = "BASE";
            AutoSave = true;
            PromptForInitialSave = true;
            TwoCopiesOf204 = true;
            IncludeSMEAC = true;
            IncludeSubjectProfile = true;
            PositionFormat = "Decimal Degrees";
            IncludeLostPersonQuestionnaire = false;
            b_includeSafetyWithIAP = true;
            CheckinInterval = 60;
            ECCCheckinInterval = 240;
            LastPort = "42999";
            ECCReminderThisDevice = true;
            AllowStringTaskNumber = true;
            DefaultListenForQR = false;
            IncludeOrgContactsInIAP = true;
            Color204ByType = true;
            LeaveSpaceIn204SMEAC = false;
            AutomaticBackups = true;
            AutoBackupIntervalMinutes = 120;
            IncludeOtherContactsWithIAP = true;
            AddIMTToContacts = true;
            DefaultICSRole = OrgChartTools.GetGenericRoleByID(Globals.IncidentCommanderID);
            AutomaticSubFolders.Add("GPS Track Backup");
            AutomaticSubFolders.Add("Maps");
            AutomaticSubFolders.Add("Other Images");
            DefaultProvince = new Province(4);
            DateFormat = "MMM-dd-yyyy";
            YellowResourceTimeoutDays = 5;
            RedResourceTimeoutDays = 2;
            OrganizationName = "Canadian Interagency Forest Fire Centre";
            ShowTestButton = false;
            //options.PrimaryChannel = "PEPSAR1 149.495";

            LastUpdateCheck = DateTime.Now;


        }
    }


}
