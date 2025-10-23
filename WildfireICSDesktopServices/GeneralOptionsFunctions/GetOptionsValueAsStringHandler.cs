

using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices.GeneralFunctions;

namespace SARAssistDesktopServices.GeneralOptionsFunctions.Queries
{
    public static class GetOptionsValueAsStringHandler
    {
        public static string GetOptionsValueAsString(this GeneralOptions _options, string ValueName)
        {
            if (_options.HasProperty(ValueName) && _options.GetProperty(ValueName) != null)
            {
                return _options.GetProperty(ValueName).ToString();
            }
            return null;
        }
    }
}
