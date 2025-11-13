

using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices.GeneralFunctions;

namespace WildfireICSDesktopServices.GeneralOptionsFunctions.Queries
{
    public static class GetOptionsValueAsBooleanHandler
    {
        public static bool GetOptionsValueAsBoolean(this GeneralOptions _options, string ValueName)
        {
            //Determine if an object has a property with a specific name
            if (_options.HasProperty(ValueName) && _options.GetProperty(ValueName).GetType() == typeof(bool))
            {
                return (bool)_options.GetProperty(ValueName);
            }

            return false;
        
        }
    }
}
