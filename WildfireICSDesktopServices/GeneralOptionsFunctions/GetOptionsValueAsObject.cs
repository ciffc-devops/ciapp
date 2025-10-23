
using System;
using System.Collections.Generic;
using System.Linq;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices.GeneralFunctions;

namespace SARAssistDesktopServices.GeneralOptionsFunctions.Queries
{
    public static class GetOptionsValueAsObjectHandler
    {
        public static object GetOptionsValueAsObject(this GeneralOptions _options, string ValueName)
        {
            if (_options.HasProperty(ValueName))
            {
                return _options.GetProperty(ValueName);
            }

            //these ones do something fancy, keep them
            switch (ValueName)
            {
                case "Equipment":
                    return _options.AllEquipment.OrderBy(o => o.Category.CategoryName).ThenBy(o => o.EquipmentName).ToList();
                case "EquipmentWithBarcodes":
                    return _options.AllEquipment.Where(o => !string.IsNullOrEmpty(o.EquipmentBarcodeID)).OrderBy(o => o.Category.CategoryName).ThenBy(o => o.EquipmentName).ToList();
                case "EquipmentCategories":
                    return _options.AllEquipmentCategories.OrderBy(o => o.CategoryName).ToList();
               
                case "DefaultICSRole":
                    if (_options.DefaultICSRole != null) { return _options.DefaultICSRole; }
                    else { return OrganizationalChartTools.GetGenericRoleByID(Globals.IncidentCommanderGenericID); }
               
                case "Objectives":
                    return _options.allPresetObjectives.Where(o => !string.IsNullOrEmpty(o.Objective)).ToList();
             
            }




            switch (ValueName)
            {
                case "BriefingTemplate":
                    return _options.BriefingTemplate;

            
                case "CommsPlanItems":
                    return _options.allCommsPlanItems;


                case "DefaultPort":
                    return _options.DefaultPortNumber;
                case "TeamMembers":
                    return _options.AllTeamMembers;
                case "CannedCommsItems":
                    return _options.AllCannedCommsLogEntries;
                case "IncludeExecutionIn204Briefings":
                    return _options.IncludeExecutionIn204Briefings;
                case "Contacts":
                    return _options.AllContacts;
                case "Position Format":
                    return _options.PositionFormat;

                case "DebriefPOD":
                    return _options.DebriefPOD;
                case "ShortcutButtons":
                    return _options.ShortcutButtons;
                case "AutoBackupInterval":
                    return _options.AutoBackupIntervalMinutes;
                case "LastIpUsedWhenMachineIsServer":
                    return _options.LastIpUsedWhenMachineIsServer;
                case "AutomaticSubFolders":
                    return _options.AutomaticSubFolders;
            


                case "Aircrafts":
                    return _options.AircraftList;
                case "SavedNetworkDeviceList":
                    return _options.SavedNetworkDeviceList;
                case "SavedHospitals":
                    return _options.AllHospitals;
                case "SavedAmbulances":
                    return _options.AllAmbulanceServices;
                default:
                    return null;
            }
        }
    }
}
