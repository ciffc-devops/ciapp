using Org.BouncyCastle.Asn1.Crmf;
using SARAssistDesktopServices.GeneralOptionsFunctions.Queries;
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
using WF_ICS_ClassLibrary.Networking;
using WF_ICS_ClassLibrary.Utilities;
using WildfireICSDesktopServices.GeneralOptionsFunctions.Queries;

namespace WildfireICSDesktopServices
{
    public class GeneralOptionsService : IGeneralOptionsService
    {
        private GeneralOptions _options;
        private string _SaveFileName = "myCIAPP_Options.xml";
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

            if (string.IsNullOrEmpty(fileName)) { fileName = "myCIAPP_Options.xml"; }

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
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPP");



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
                } else
                {
                    _options = new GeneralOptions();
                    _options.addDefaultOptions();
                    _options.OptionsLoadedSuccessfully = false;
                }
            }
            catch (Exception)
            {
                //LgMessageBox.Show(ex.Message);
                _options = new GeneralOptions();
                _options.addDefaultOptions();
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


        #region Change and Save Values
        public bool SaveGeneralOptions()
        {


            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPP");
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
                    //LgMessageBox.Show(ex.Message);
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
            if (string.IsNullOrEmpty(filename)) { filename = "myCIAPP_Options.xml"; }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CIAPP");
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
                    //LgMessageBox.Show(ex.Message);
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
        public void UpsertOptionValue(object newValue, string property_name = null)
        {
            if (_options == null || !_options.OptionsLoadedSuccessfully)
            {
                GetGeneralOptions();
            }

            var type = newValue.GetType();
            if (type == typeof(QuickCommsLogEntry))
            {
                _options.AllCannedCommsLogEntries = newValue as List<QuickCommsLogEntry>;
            }
            else if (type == typeof(ShortcutButtonOption))
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
                case "Aircraft":
                    Aircraft air = (Aircraft)newValue;
                    _options.AircraftList = _options.AircraftList.Where(o => o.ID != air.ID).ToList();
                    _options.AircraftList.Add(air);
                    _options.AircraftList = _options.AircraftList.OrderBy(o => o.Registration).ToList();
                    break;
                case "AddIMTToContacts":
                    _options.AddIMTToContacts = Convert.ToBoolean(newValue); break;
                case "ShortcutButtons":
                    _options.ShortcutButtons = (ShortcutButtonOption[])newValue;
                    break;
                case "DefaultICSRole":
                    _options.DefaultICSRole = (ICSRole)newValue;
                    break;
                case "DefaultPortNumber":
                    _options.DefaultPortNumber = Convert.ToInt32(newValue); break;
                case "TeamMember":
                    Personnel member = (Personnel)newValue;
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
                    _options.AllVehicles = _options.AllVehicles.Where(o => o.ID != v.ID).ToList();
                    _options.AllVehicles.Add(v);
                    break;
                case "CommsItem":
                    CommsPlanItem comms = (CommsPlanItem)newValue;
                    _options.allCommsPlanItems = _options.allCommsPlanItems.Where(o => o.TemplateItemID != comms.TemplateItemID).ToList();
                    _options.allCommsPlanItems.Add(comms);
                    break;
                case "Hospital":
                    Hospital hospital = (Hospital)newValue;
                    _options.AllHospitals = _options.AllHospitals.Where(o => o.HospitalID != hospital.HospitalID).ToList();
                    _options.AllHospitals.Add(hospital);
                    break;
                case "Ambulance":
                    AmbulanceService amb = (AmbulanceService)newValue;
                    _options.AllAmbulanceServices = _options.AllAmbulanceServices.Where(o => o.AmbulanceID != amb.AmbulanceID).ToList();
                    _options.AllAmbulanceServices.Add(amb);
                    break;

                case "Equipment":
                    Gear eq = (Gear)newValue;
                    _options.AllEquipment = _options.AllEquipment.Where(o => o.EquipmentID != eq.EquipmentID).ToList();
                    _options.AllEquipment.Add(eq);
                    break;
                case "EquipmentCategory":
                    GearCategory ec = (GearCategory)newValue;
                    _options.AllEquipmentCategories = _options.AllEquipmentCategories.Where(o => o.CategoryID != ec.CategoryID).ToList();
                    _options.AllEquipmentCategories.Add(ec);
                    if (_options.AllEquipment.Any(o => o.Category.CategoryID == ec.CategoryID))
                    {
                        foreach (Gear e in _options.AllEquipment.Where(o => o.Category.CategoryID == ec.CategoryID))
                        {
                            e.Category = ec;
                        }
                    }
                    break;
                case "EquipmentSet":
                    GearSet es = (GearSet)newValue;
                    _options.AllEquipmentSets = _options.AllEquipmentSets.Where(o => o.SetID != es.SetID).ToList();
                    _options.AllEquipmentSets.Add(es);
                    break;
                case "EquipmentSetMembership":
                    GearSetMembership esm = (GearSetMembership)newValue;
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
                case "SafetyMessage":
                    SafetyMessage sp = (SafetyMessage)newValue;
                    _options.safetyMessages = _options.safetyMessages.Where(o => o.SafetyTemplateID != sp.SafetyTemplateID).ToList();
                    _options.safetyMessages.Add(sp);
                    break;
                case "RecentFileName":
                    string recentFileName = newValue.ToString();
                    _options.RecentFilePaths = _options.RecentFilePaths.Where(o => !o.Equals(recentFileName)).ToList();
                    _options.RecentFilePaths.Insert(0, recentFileName);
                    if (_options.RecentFilePaths.Count > 5) { _options.RecentFilePaths = _options.RecentFilePaths.Take(5).ToList(); }
                    break;
                case "NetworkDevice":
                    DeviceInformation info = (DeviceInformation)newValue;
                    _options.SavedNetworkDeviceList = _options.SavedNetworkDeviceList.Where(o => o.DeviceID != info.DeviceID).ToList();
                    _options.SavedNetworkDeviceList.Add(info);
                    break;
                case "LastServerIP":
                    _options.LastServerIP = newValue.ToString();
                    break;
                case "LastPort":
                    _options.LastPort = newValue.ToString();
                    break;
                case "RedResourceTimeoutDays":
                    _options.RedResourceTimeoutDays = Convert.ToInt32(newValue);
                    break;
                case "YellowResourceTimeoutDays":
                    _options.YellowResourceTimeoutDays = Convert.ToInt32(newValue);
                    break;
                case "OrganizationName":
                    _options.OrganizationName = newValue.ToString();
                    break;
                case "OrganizationLogo":
                    _options.OrganizationLogo = (byte[])newValue; break;
                case "IncludeLogoOnTitlePageByDefault":
                    _options.IncludeLogoOnTitlePageByDefault = Convert.ToBoolean(newValue);
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
                        Gear eq = (Gear)removeValue;
                        _options.AllEquipment = _options.AllEquipment.Where(o => o.EquipmentID != eq.EquipmentID).ToList();
                        break;
                    case "EquipmentCategory":
                        GearCategory ec = (GearCategory)removeValue;
                        _options.AllEquipmentCategories = _options.AllEquipmentCategories.Where(o => o.CategoryID != ec.CategoryID).ToList();
                        break;
                    case "EquipmentSet":
                        GearSet es = (GearSet)removeValue;
                        _options.AllEquipmentSets = _options.AllEquipmentSets.Where(o => o.SetID != es.SetID).ToList();
                        break;
                    case "EquipmentSetMembership":
                        GearSetMembership esm = (GearSetMembership)removeValue;

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
        #endregion

        #region Retrieve Values

        public Guid GetGuidOptionValue(string ValueName)
        {
            return _options.GetOptionsValueAsGuid(ValueName);
        }

        public string GetStringOptionValue(string ValueName)
        {
            return _options.GetOptionsValueAsString(ValueName);
        }
        public int GetIntOptionValue(string ValueName)
        {
            return _options.GetOptionsValueAsInt(ValueName);
        }
        public object GetOptionsValue(string ValueName)
        {
            return _options.GetOptionsValueAsObject(ValueName);
        }

        public bool GetOptionsBoolValue(string ValueName)
        {
            return _options.GetOptionsValueAsBoolean(ValueName);
        }

        public int GetIntOptionsValue(string ValueName)
        {
            return _options.GetOptionsValueAsInt(ValueName);
        }
        #endregion



    }
}
