using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Models;

namespace WF_ICS_ClassLibrary.Interfaces
{
    public interface IEquipmentService
    {
       
        List<GearStatus> GetEquipmentStatuses();
        GearStatus GetEquipmentStatus(string name);
        List<GearCategory> GetStartingCategories();
        string CreatePDF(WFIncident task, int OpPeriod, bool useTempPath, bool flattenPDF);
       
    }
}
