using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Interfaces
{
    public interface IGeneralOptionsService
    {
        GeneralOptions GetGeneralOptions(Guid OrganizationID);
        GeneralOptions GetGeneralOptions(string fileName);
        bool SaveGeneralOptions(GeneralOptions options, string filename);
        bool SaveGeneralOptions();
        bool DeleteGeneralOptions(GeneralOptions options);

        object GetOptionsValue(string ValueName);
        bool GetOptionsBoolValue(string ValueName);
        Guid GetGuidOptionValue(string ValueName);
        string GetStringOptionValue(string ValueName);
        void UpserOptionValue(object newValue, string property_name = null);
        void RemoveOptionValue(object removeValue, string property_name);


    }
}
