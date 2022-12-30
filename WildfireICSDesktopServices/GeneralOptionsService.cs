using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Interfaces;
using WF_ICS_ClassLibrary.Models;

namespace WildfireICSDesktopServices
{
    public class GeneralOptionsService : IGeneralOptionsService
    {
        private GeneralOptions _options;
        private string _SaveFileName = "myCIAPPOptions.xml";
        private bool _LoadSettingsFromFile;


        public GeneralOptionsService() { _options = new GeneralOptions(); _options.OptionsLoadedSuccessfully = false; }
        public GeneralOptionsService(string fileName)
        {
            _SaveFileName = fileName;
            _LoadSettingsFromFile = true;
            _options = new GeneralOptions(); _options.OptionsLoadedSuccessfully = false;
            GetGeneralOptions();
        }
        public GeneralOptionsService(bool loadSettingsFromFile)
        {
            _options = new GeneralOptions(); _options.OptionsLoadedSuccessfully = false;
            _LoadSettingsFromFile = loadSettingsFromFile;
            GetGeneralOptions();
        }

        public bool DeleteGeneralOptions(GeneralOptions options)
        {
            throw new NotImplementedException();
        }

        public GeneralOptions GetGeneralOptions(Guid OrganizationID)
        {
            throw new NotImplementedException();
        }

        public GeneralOptions GetGeneralOptions(string fileName = null)
        {

            if (string.IsNullOrEmpty(fileName)) { fileName = "myCIAPPOptions.xml"; }

            _options = loadGeneralOptionsByFilename(fileName);

            return _options;
        }

        public GeneralOptions GetGeneralOptions()
        {
            if (_LoadSettingsFromFile && !string.IsNullOrEmpty(_SaveFileName))
            {
                _options = loadGeneralOptionsByFilename(_SaveFileName);
            }
            return _options;
        }

        private GeneralOptions loadGeneralOptionsByFilename(string fileName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPPO");



            XmlSerializer mySerializer = new XmlSerializer(typeof(GeneralOptions));

            try
            {
                System.IO.Directory.CreateDirectory(path);
                // Create an XmlSerializer for the ApplicationSettings type.

                FileInfo fi = new FileInfo(Path.Combine(path, fileName));
                // If the config file exists, open it.
                if (fi.Exists)
                {
                    using (FileStream myFileStream = fi.OpenRead())
                    {
                        // Create a new instance of the ApplicationSettings by
                        // deserializing the config file.
                        _options = (GeneralOptions)mySerializer.Deserialize(myFileStream);
                        // Assign the property values to this instance of 
                        // the ApplicationSettings class.
                    }
                    if (_options.DefaultPortNumber <= 0) { _options.DefaultPortNumber = 42999; }
                    _options.OptionsLoadedSuccessfully = true;
                    if (_options.ParentOrganizationID == Guid.Empty)
                    {
                        Guid BCSARA = new Guid("CC3A9DC9-01A3-4D39-B806-2128B51120BC");
                        _options.ParentOrganizationID = BCSARA;
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                _options = new GeneralOptions();
                _options.OptionsLoadedSuccessfully = false;
                throw new Exception();
            }

            return _options;
        }

        public ShortcutButtonOption[] GetDefaultShortcuts()
        {
            ShortcutButtonOption[] shortcuts = new ShortcutButtonOption[6];
            shortcuts[0] = new ShortcutButtonOption("TeamAssignments");
            shortcuts[1] = new ShortcutButtonOption("NewAssignment");

            return shortcuts;
        }

        public bool SaveGeneralOptions()
        {


            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPPO");
            Directory.CreateDirectory(path);
            bool saveSuccessful = false;


            using (StreamWriter myWriter = new StreamWriter(Path.Combine(path, _SaveFileName), false))
            {
                XmlSerializer mySerializer = null;
                try
                {
                    // Create an XmlSerializer for the 
                    // ApplicationSettings type.
                    mySerializer = new XmlSerializer(typeof(GeneralOptions));

                    // Serialize this instance of the ApplicationSettings 
                    // class to the config file.
                    mySerializer.Serialize(myWriter, _options);
                    saveSuccessful = true;
                }
                catch (Exception)
                {
                    saveSuccessful = false;
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    // If the FileStream is open, close it.
                    if (myWriter != null)
                    {
                        myWriter.Close();
                    }
                }
            }
            return saveSuccessful;
        }


        public bool SaveGeneralOptions(GeneralOptions options, string filename = null)
        {
            if (string.IsNullOrEmpty(filename)) { filename = "myCIAPPOptions.xml"; }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPPO");
            Directory.CreateDirectory(path);
            bool saveSuccessful = false;


            using (StreamWriter myWriter = new StreamWriter(Path.Combine(path, filename), false))
            {
                XmlSerializer mySerializer = null;
                try
                {
                    // Create an XmlSerializer for the 
                    // ApplicationSettings type.
                    mySerializer = new XmlSerializer(typeof(GeneralOptions));

                    // Serialize this instance of the ApplicationSettings 
                    // class to the config file.
                    mySerializer.Serialize(myWriter, options);
                    saveSuccessful = true;
                }
                catch (Exception)
                {
                    saveSuccessful = false;
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    // If the FileStream is open, close it.
                    if (myWriter != null)
                    {
                        myWriter.Close();
                    }
                }
            }
            return saveSuccessful;
        }

   
        public object GetOptionsValue(string ValueName)
        {
            switch (ValueName)
            {
                case "AllowStringTaskNumber":
                    return _options.AllowStringTaskNumber;
                case "Ambulances":
                    return _options.AllAmbulanceServices;
                case "AutoBackupInterval":
                    return _options.AutoBackupIntervalMinutes;
                case "AutomaticSubFolders":
                    return _options.AutomaticSubFolders;
                case "CannedCommsItems":
                    return _options.AllCannedCommsLogEntries;
                case "CommsItems":
                    return _options.allCommsPlanItems.OrderBy(o => o.ChannelID).ToList();
                case "Contacts":
                    return _options.AllContacts;
                case "CoordinateFormat":
                    return _options.PositionFormat;
                case "DefaultICSRole":
                    if (_options.DefaultICSRole != null) { return _options.DefaultICSRole; }
                    else { return OrgChartTools.GetGenericRoleByID(Globals.IncidentCommanderID); }
                case "DefaultPort":
                    return _options.DefaultPortNumber;
                case "DefaultSaveLocation":
                    return _options.DefaultSaveLocation;
                case "Equipment":
                    return _options.AllEquipment.OrderBy(o => o.Category.CategoryName).ThenBy(o => o.EquipmentName).ToList();
                case "EquipmentCategories":
                    return _options.AllEquipmentCategories.OrderBy(o => o.CategoryName).ToList();
                case "EquipmentCategoriesHierarchy":
                    List<EquipmentCategory> categories = new List<EquipmentCategory>();

                    foreach (EquipmentCategory parent in _options.AllEquipmentCategories.Where(o => o.ParentCategoryID == Guid.Empty).OrderBy(o => o.CategoryName).ToList())
                    {
                        categories.Add(parent);
                        categories.AddRange(_options.AllEquipmentCategories.Where(o => o.ParentCategoryID == parent.CategoryID).OrderBy(o => o.CategoryName).ToList());
                    }
                    return categories;

                case "EquipmentSets":
                    return _options.AllEquipmentSets;

                case "EquipmentWithBarcodes":
                    return _options.AllEquipment.Where(o => !string.IsNullOrEmpty(o.EquipmentBarcodeID)).OrderBy(o => o.Category.CategoryName).ThenBy(o => o.EquipmentName).ToList();
                case "Hospitals":
                    return _options.AllHospitals;
                case "LastIpUsedWhenMachineIsServer":
                    return _options.LastIpUsedWhenMachineIsServer;
                case "Objectives":
                    return _options.allPresetObjectives;
                case "Position Format":
                    return _options.PositionFormat;
                case "RecentFiles":
                    return _options.RecentFilePaths;
                case "SafetyPlans":
                    return _options.allPresetSafetyPlans;
                case "SARGroup":
                    if (_options.OrganizationID != Guid.Empty)
                    {
                        Organization org = OrganizationTools.GetOrganization(_options.OrganizationID);
                        if (org != null)
                        {
                            return org;
                        }
                        else { return new Organization(); }
                        /*
                        List<Organization> orgs = new Organization().getStaticOrganizationList(false, true);
                        if(orgs.Any(o=>o.OrganizationID == _options.OrganizationID))
                        {
                            return orgs.Where(o => o.OrganizationID == _options.OrganizationID).First();
                        } 
                        */
                    }
                    return new Organization();
                case "ShortcutButtons":
                    return _options.ShortcutButtons;
                case "TeamMembers":
                    return _options.AllTeamMembers;
                case "Vehicles":
                    return _options.AllVehicles;
                default:
                    return null;
            }
        }

        public Guid GetGuidOptionValue(string ValueName)
        {
            switch (ValueName)
            {
                case "ParentOrganizationID":
                    return _options.ParentOrganizationID;
                case "OrganizationID":
                    return _options.OrganizationID;

            }
            return Guid.Empty;
        }


        public bool GetOptionsBoolValue(string ValueName)
        {
            switch (ValueName)
            {
                case "AllowStringTaskNumber":
                    return _options.AllowStringTaskNumber;
                case "AutoSave":
                    return _options.AutoSave;
                case "AutoBackup":
                    return _options.AutomaticBackups;
                case "AddIMTToContacts":
                    return _options.AddIMTToContacts;
                case "PromptForInitialSave":
                    return _options.PromptForInitialSave;
                default:
                    return false;
            }
        }

     
        public string GetStringOptionValue(string ValueName)
        {
            switch (ValueName)
            {
                case "DefaultSaveLocation":
                    return _options.DefaultSaveLocation;

                default:
                    return null;
            }
        }


        public void UpserOptionValue(object newValue, string property_name = null)
        {
            if (_options == null || !_options.OptionsLoadedSuccessfully)
            {
                GetGeneralOptions();
            }

            var type = newValue.GetType();
            if (type == new List<CannedCommsLogEntry>().GetType())
            {
                _options.AllCannedCommsLogEntries = newValue as List<CannedCommsLogEntry>;
            }
            else if (type == new ShortcutButtonOption().GetType())
            {
                int nextBlank = -1;
                if (_options.ShortcutButtons != null)
                {
                    for (int x = 0; x < _options.ShortcutButtons.Length; x++)
                    {
                        if (_options.ShortcutButtons[x] == null || string.IsNullOrEmpty(_options.ShortcutButtons[x].CommandName)) { nextBlank = x; }
                    }
                }
                else { _options.ShortcutButtons = new ShortcutButtonOption[6]; nextBlank = 0; }
                if (nextBlank >= 0)
                {
                    _options.ShortcutButtons[nextBlank] = (ShortcutButtonOption)newValue;
                }
            }

            switch (property_name)
            {
                case "AddIMTToContacts":
                    _options.AddIMTToContacts = Convert.ToBoolean(newValue); break;
                case "ShortcutButtons":
                    _options.ShortcutButtons = (ShortcutButtonOption[])newValue;
                    break;
                case "DefaultICSRole":
                    _options.DefaultICSRole = (ICSRole)newValue;
                    break;
                case "TeamMember":
                    TeamMember member = (TeamMember)newValue;
                    _options.AllTeamMembers = _options.AllTeamMembers.Where(o => o.PersonID != member.PersonID).ToList();
                    _options.AllTeamMembers.Add(member);
                    break;
                case "IncludeExecutionIn204Briefings":
                    _options.IncludeExecutionIn204Briefings = (bool)newValue;
                    break;
                case "Contact":
                    Contact c = (Contact)newValue;
                    _options.AllContacts = _options.AllContacts.Where(o => o.ContactID != c.ContactID).ToList();
                    _options.AllContacts.Add(c);
                    break;
                case "Vehicle":
                    Vehicle v = (Vehicle)newValue;
                    _options.AllVehicles = _options.AllVehicles.Where(o => o.VehicleID != v.VehicleID).ToList();
                    _options.AllVehicles.Add(v);
                    break;
                case "CommsItem":
                    CommsPlanItem comms = (CommsPlanItem)newValue;  
                    _options.allCommsPlanItems = _options.allCommsPlanItems.Where(o=>o.ItemID!= comms.ItemID).ToList();
                    _options.allCommsPlanItems.Add(comms);
                    break;
                case "Hospital":
                    Hospital hospital = (Hospital)newValue;
                    _options.AllHospitals = _options.AllHospitals.Where(o=>o.HospitalID != hospital.HospitalID).ToList();
                    _options.AllHospitals.Add(hospital);
                    break;
                case "Ambulance":
                    AmbulanceService amb = (AmbulanceService)newValue;  
                    _options.AllAmbulanceServices = _options.AllAmbulanceServices.Where(o=> o.AmbulanceID != amb.AmbulanceID).ToList();
                    _options.AllAmbulanceServices.Add(amb);
                    break;
               
                case "Equipment":
                    Equipment eq = (Equipment)newValue;
                    _options.AllEquipment = _options.AllEquipment.Where(o => o.EquipmentID != eq.EquipmentID).ToList();
                    _options.AllEquipment.Add(eq);
                    break;
                case "EquipmentCategory":
                    EquipmentCategory ec = (EquipmentCategory)newValue;
                    _options.AllEquipmentCategories = _options.AllEquipmentCategories.Where(o => o.CategoryID != ec.CategoryID).ToList();
                    _options.AllEquipmentCategories.Add(ec);
                    if (_options.AllEquipment.Any(o => o.Category.CategoryID == ec.CategoryID))
                    {
                        foreach (Equipment e in _options.AllEquipment.Where(o => o.Category.CategoryID == ec.CategoryID))
                        {
                            e.Category = ec;
                        }
                    }
                    break;
                case "EquipmentSet":
                    EquipmentSet es = (EquipmentSet)newValue;
                    _options.AllEquipmentSets = _options.AllEquipmentSets.Where(o => o.SetID != es.SetID).ToList();
                    _options.AllEquipmentSets.Add(es);
                    break;
                case "EquipmentSetMembership":
                    EquipmentSetMembership esm = (EquipmentSetMembership)newValue;
                    if (_options.AllEquipmentSets.Any(o => o.SetID == esm.SetID))
                    {
                        _options.AllEquipmentSets.Where(o => o.SetID == esm.SetID).First().AllItems = _options.AllEquipmentSets.Where(o => o.SetID == esm.SetID).First().AllItems.Where(o => o.EquipmentID != esm.EquipmentID).ToList();
                        _options.AllEquipmentSets.Where(o => o.SetID == esm.SetID).First().AllItems.Add(esm);
                    }
                    break;
                case "LastIpUsedWhenMachineIsServer":
                    _options.LastIpUsedWhenMachineIsServer = newValue.ToString();
                    break;
                case "Objective":
                    IncidentObjective obj = (IncidentObjective)newValue;
                    _options.allPresetObjectives = _options.allPresetObjectives.Where(o => o.ObjectiveID != obj.ObjectiveID).ToList();
                    _options.allPresetObjectives.Add(obj);
                    break;
                case "SafetyPlan":
                    SafetyPlan sp = (SafetyPlan)newValue;
                    _options.allPresetSafetyPlans = _options.allPresetSafetyPlans.Where(o => o.SafetyPlanTemplateID != sp.SafetyPlanTemplateID).ToList();
                    _options.allPresetSafetyPlans.Add(sp);
                    break;
                case "RecentFileName":
                    string recentFileName = newValue.ToString();
                    _options.RecentFilePaths = _options.RecentFilePaths.Where(o=> !o.Equals(recentFileName)).ToList();
                    _options.RecentFilePaths.Insert(0, recentFileName);
                    if(_options.RecentFilePaths.Count > 5) { _options.RecentFilePaths = _options.RecentFilePaths.Take(5).ToList(); }
                    break;
            }
            SaveGeneralOptions();
        }

        public void RemoveOptionValue(object removeValue, string property_name)
        {
            var type = removeValue.GetType();

            if (type == new ShortcutButtonOption().GetType())
            {
                ShortcutButtonOption toRemove = (ShortcutButtonOption)removeValue;

                for (int x = 0; x < _options.ShortcutButtons.Length; x++)
                {
                    if (_options.ShortcutButtons[x] != null && _options.ShortcutButtons[x].ShortcutID == toRemove.ShortcutID)
                    {
                        _options.ShortcutButtons[x] = null;
                    }
                }
            }
            else
            {
                switch (property_name)
                {
                    case "Contact":
                        Contact c = (Contact)removeValue;
                        _options.AllContacts = _options.AllContacts.Where(o => o.ContactID != c.ContactID).ToList();
                        break;
                    case "Equipment":
                        Equipment eq = (Equipment)removeValue;
                        _options.AllEquipment = _options.AllEquipment.Where(o => o.EquipmentID != eq.EquipmentID).ToList();
                        break;
                    case "EquipmentCategory":
                        EquipmentCategory ec = (EquipmentCategory)removeValue;
                        _options.AllEquipmentCategories = _options.AllEquipmentCategories.Where(o => o.CategoryID != ec.CategoryID).ToList();
                        break;
                    case "EquipmentSet":
                        EquipmentSet es = (EquipmentSet)removeValue;
                        _options.AllEquipmentSets = _options.AllEquipmentSets.Where(o => o.SetID != es.SetID).ToList();
                        break;
                    case "EquipmentSetMembership":
                        EquipmentSetMembership esm = (EquipmentSetMembership)removeValue;

                        if (_options.AllEquipmentSets.Any(o => o.SetID == esm.SetID))
                        {
                            _options.AllEquipmentSets.Where(o => o.SetID == esm.SetID).First().AllItems = _options.AllEquipmentSets.Where(o => o.SetID == esm.SetID).First().AllItems.Where(o => o.EquipmentID != esm.EquipmentID).ToList();
                        }
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            SaveGeneralOptions();

        }

        
    }
}
