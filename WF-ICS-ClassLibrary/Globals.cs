using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_ICS_ClassLibrary.Interfaces;
using WildfireICSDesktopServices;

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
        public static IIncidentDataService incidentService { get; set; }
        public static string DateFormat { get; set; }
        public static string DefaultFolderName { get; set; }

        static Globals()
        {
            //Gets the connection string from the calling website and uses it throughout the class library
            ProgramName = "Canadian Incident Action Plan Program";
            ProgramURL = "https://www.icscanada.ca";
            DefaultFolderName = "CIAPP";

        }



        //Key Generic ICS roles
        public static Guid IncidentCommanderGenericID { get;  } = new Guid("1096905E-A726-41D8-A8BC-2EAD61CCB2F7");
        public static Guid UnifiedCommand1GenericID { get; } = IncidentCommanderGenericID; //= new Guid("e3667668-4d58-459e-9fb5-5205296994e7");
        public static Guid UnifiedCommand2GenericID { get; } = new Guid("32a04cd8-5d24-46da-9a09-1a5e8685b39e");
        public static Guid UnifiedCommand3GenericID { get; } = new Guid("2d94c4a4-c7f2-4893-a3ec-cc4cd3dfc78a");

        public static Guid DeputyIncidentCommanderGenericID { get; } = new Guid("450EA00E-636A-4F44-9B6D-50A8EC03F4EA");
        public static Guid PlanningChiefGenericID { get; } = new Guid("A0B226FA-33FA-45C7-91AE-7D4F498FD31B");
        public static Guid OpsChiefGenericID { get; } = new Guid("CFE4C7DE-BD61-421C-8167-1B55E4151CFC");
        public static Guid LogisticsChiefGenericID { get; } = new Guid("B641C5D6-91FE-41DA-962E-9FEB7A7300A2");
        public static Guid FinanceChiefGenericID { get; } = new Guid("33805F34-CD3A-49AF-94FA-DA4058577B9B");
        public static Guid SafetyOfficerGenericID { get; } = new Guid("CE7166AF-9432-4F7A-B942-1250AF0B7C31");


        //Operations
        public static Guid AirOpsDirectorGenericID { get; } = new Guid("b97d020e-608e-4ea0-9df7-63b2b7680f0e");
        public static Guid BranchDirectorGenericID { get; } = new Guid("2b6670c1-1252-44ab-b6c7-2d095c7dddc0");
        public static Guid TaskForceLeaderGenericID { get; } = new Guid("5f427013-15d9-480b-9cdf-31247af0451e");
        public static Guid StrikeTeamLeaderGenericID { get; } = new Guid("fe51d017-0be6-4547-b38c-3851492cbf9e");
        public static Guid GroupSupervisorGenericID { get; } = new Guid("504b6131-411b-451d-a92a-2ed59d27b492");
        public static Guid DivisionSupervisorGenericID { get; } = new Guid("738957c1-1214-43aa-aa63-d74639397aad");




    }
}
