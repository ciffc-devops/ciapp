using System;
using WF_ICS_ClassLibrary.Models;
using WildfireICSDesktopServices.GeneralFunctions;

namespace SARAssistDesktopServices.GeneralOptionsFunctions.Queries
{
    public static class GetOptionsValueAsGuidHandler
    {
        public static Guid GetOptionsValueAsGuid(this GeneralOptions _options, string ValueName)
        {
            if (_options.HasProperty(ValueName) && _options.GetProperty(ValueName).GetType() == typeof(Guid))
            {
                return (Guid)_options.GetProperty(ValueName);
            }

            return Guid.Empty;

        }
    }
}
