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
       
        List<EquipmentStatus> GetEquipmentStatuses();
        EquipmentStatus GetEquipmentStatus(string name);
        List<EquipmentCategory> GetStartingCategories();
        string CreatePDF(WFIncident task, int OpPeriod, bool useTempPath, bool flattenPDF);
       
    }
}
