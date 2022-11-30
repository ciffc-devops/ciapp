using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFICSAssist_Class_Library.Models;

namespace WFICSAssist_Class_Library.Interfaces
{
    public interface IGeneralOptionsService
    {
        GeneralOptions GetGeneralOptions(Guid OrganizationID);
        GeneralOptions GetGeneralOptions(string fileName);
        bool SaveGeneralOptions(GeneralOptions options, string filename);
        bool SaveGeneralOptions();
        bool DeleteGeneralOptions(GeneralOptions options);

        object GetOptionsValue(string ValueName);
        void UpserOptionValue(object newValue, string property_name = null);
        void RemoveOptionValue(object removeValue, string property_name);


    }
}
