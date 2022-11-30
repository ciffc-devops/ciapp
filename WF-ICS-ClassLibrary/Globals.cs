using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Interfaces;

namespace WF_ICS_ClassLibrary
{
    public static class Globals
    {
        //public static string GreathatConnectionStr { get; set; }
        public static string ProgramName { get; set; }
        public static string ProgramURL { get; set; }

        //public static string SARICSConnectionStr { get; set; }
        public static CultureInfo cultureInfo { get { return System.Globalization.CultureInfo.CurrentCulture; } }
        public static IGeneralOptionsService _generalOptionsService { get; set; }
        public static IEquipmentService _equipmentService { get; set; }

        static Globals()
        {
            //Gets the connection string from the calling website and uses it throughout the class library
            ProgramName = "Canadian Incident Action Plan Producer";
            ProgramURL = "https://www.icscanada.ca";
        }


    }
}
