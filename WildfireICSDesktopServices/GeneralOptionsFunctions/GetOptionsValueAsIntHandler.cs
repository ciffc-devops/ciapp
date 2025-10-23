using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices.GeneralFunctions;

namespace SARAssistDesktopServices.GeneralOptionsFunctions.Queries
{
   
    public static class GetOptionsValueAsIntHandler
    {
        public static int GetOptionsValueAsInt(this GeneralOptions _options, string ValueName)
        {
            if (_options.HasProperty(ValueName) && _options.GetProperty(ValueName) != null)
            {
                int.TryParse(_options.GetProperty(ValueName).ToString(), out int value);
                return value;
            }
            return 0;
        }
    }
}
