using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Interfaces;
using WF_ICS_ClassLibrary.Models;
using WF_ICS_ClassLibrary.Networking;
using System.Globalization;
using System.Threading;
using WildfireICSDesktopServices;
using WF_ICS_ClassLibrary;
using WF_ICS_ClassLibrary.Utilities;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Utilities;

namespace Wildfire_ICS_Assist
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDpiAwarenessContext(DpiAwarenessContext.Unaware);

       

            generalOptionsService = new GeneralOptionsService(true);
            WF_ICS_ClassLibrary.Globals._generalOptionsService = generalOptionsService;
            
            pdfExportService = new PDFExportService();
            pdfExportService.SetDateFormat(generalOptionsService.GetStringOptionValue("DateFormat"));
            WF_ICS_ClassLibrary.Globals.DateFormat = generalOptionsService.GetStringOptionValue("DateFormat");
            incidentDataService = new IncidentDataService();
            WF_ICS_ClassLibrary.Globals.incidentService = incidentDataService;
            positionLogService = new PositionLogService();
            networkService = new NetworkService();

            CurrentTask = new Incident();
            CurrentOpPeriod = 1;
            CurrentRole = OrgChartTools.GetGenericRoleByID(Globals.IncidentCommanderID);
           

            MachineID = Properties.Settings.Default.MachineID;
            if (MachineID == Guid.Empty)
            {
                MachineID = Guid.NewGuid();
                Properties.Settings.Default.MachineID = _MachineID;
                Properties.Settings.Default.Save();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IncidentDetailsForm());
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int SetProcessDpiAwarenessContext(DpiAwarenessContext value);


        /*
       
        private static PositionLogService _positionLogService = null;
        private static EquipmentService _equipmentService = null;
      
        */
        private static IGeneralOptionsService _generalOptionsService = null;
        private static IPDFExportService _pdfExportService = null;
        private static IWFIncidentService _incidentDataService = null;
        private static IPositionLogService _positionLogService= null;
        private static Icon _programIcon = Properties.Resources.P_icon;
        private static int _CurrentOpPeriod;
        private static NetworkSendLog _networkSendLog;
        private static bool _InternetSyncEnabled;
        private static Guid _MachineID;
        private static CultureInfo _cultureInfo;
        private static NetworkService _networkService = null;

        private static int _PNumMin = 1;
        private static int _PNumMax = 10000;
        private static int _VNumMin = 1;
        private static int _VNumMax = 10000;
        private static int _ENumMin = 1;
        private static int _ENumMax = 10000;
        private static int _CNumMin = 1;
        private static int _CNumMax = 10000;


        public static IGeneralOptionsService generalOptionsService { get => _generalOptionsService; private set => _generalOptionsService = value; }

        public static IPDFExportService pdfExportService { get => _pdfExportService; private set => _pdfExportService = value; }
        public static IWFIncidentService incidentDataService { get => _incidentDataService; private set => _incidentDataService = value; }


        public static Incident CurrentIncident
        {
            get { if (incidentDataService != null && incidentDataService.CurrentIncident != null) { return incidentDataService.CurrentIncident; } else { return new Incident(); } }
            set { incidentDataService.CurrentIncident = value; networkService.CurrentIncidentID = value.ID; }
        }
        public static OrganizationChart CurrentOrgChart
        {
            get
            {
                if (CurrentIncident == null) { return null; }
                if(CurrentIncident != null)
                {
                    CurrentIncident.createOrgChartAsNeeded(CurrentOpPeriod);
                }
                if (CurrentIncident != null && CurrentIncident.allOrgCharts != null) { return CurrentIncident.allOrgCharts.FirstOrDefault(o => o.OpPeriod == CurrentOpPeriod); }
                return null;
            }
        }
        /*
        public static EquipmentService equipmentService { get => _equipmentService; private set => _equipmentService = value; }
        
        public static NetworkSendLog networkSendLog { get => _networkSendLog; set => _networkSendLog = value; }
        */
        public static IPositionLogService positionLogService { get => _positionLogService; private set => _positionLogService = value; }
        public static Icon programIcon { get => _programIcon; private set => _programIcon = value; }
        public static Incident CurrentTask { get => incidentDataService.CurrentIncident; set { incidentDataService.CurrentIncident = value; } }
        public static ICSRole CurrentRole { get => incidentDataService.CurrentRole; set { incidentDataService.CurrentRole = value; } }
        public static int CurrentOpPeriod { get => _CurrentOpPeriod; set => _CurrentOpPeriod = value; }
        public static OperationalPeriod CurrentOpPeriodDetails { get { if (CurrentIncident != null && CurrentIncident.AllOperationalPeriods.Any(o => o.PeriodNumber == CurrentOpPeriod)) { return CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod); } else { return null; } } }
        public static bool InternetSyncEnabled { get => _InternetSyncEnabled; set => _InternetSyncEnabled = value; }
        public static Guid MachineID { get => _MachineID; set { _MachineID = value; incidentDataService.MachineID = value; } }
        public static NetworkService networkService { get => _networkService; private set => _networkService = value; }
        public static string DateFormat { get { return generalOptionsService.GetStringOptionValue("DateFormat"); } }
        public static CultureInfo cultureInfo
        {
            get => _cultureInfo; set
            {
                _cultureInfo = value;
                Thread.CurrentThread.CurrentUICulture = _cultureInfo;
                Thread.CurrentThread.CurrentCulture = _cultureInfo;
                CultureInfo.DefaultThreadCurrentCulture = _cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = _cultureInfo;
            }
        }



        //Colours used throughout the program
        private static Color _FormBackground = Color.FromArgb(246, 245, 229);
        public static Color FormBackground { get => _FormBackground; set => _FormBackground = value; }
        public static Color FormAccent { get => Color.FromArgb(219, 218, 204); }
        public static Color ErrorColor { get => Color.LightCoral; }
        public static Color GoodColor { get => Color.LightSkyBlue; }
        public static Color StandardTextboxColor { get => System.Drawing.SystemColors.Window; }
        public static Color DarkColor { get => Color.FromArgb(35, 31, 32); }

        //this is a particular pallet based off the ivory form background color
        public static Color HelpColor { get => Color.FromArgb(122, 139, 153); }
        public static Color DarkBlueColor { get => Color.FromArgb(11, 19, 43); }
        public static Color MidBlueColor { get => Color.FromArgb(28, 37, 56); }
        public static Color LightBlueColor { get => Color.FromArgb(58, 80, 107); }

        public static Color ViewPDFColor { get => Color.FromArgb(168, 118, 62); }


        public static int PNumMin { get => _PNumMin; set => _PNumMin = value; }
        public static int PNumMax { get => _PNumMax; set => _PNumMax = value; }
        public static int VNumMin { get => _VNumMin; set => _VNumMin = value; }
        public static int VNumMax { get => _VNumMax; set => _VNumMax = value; }
        public static int ENumMin { get => _ENumMin; set => _ENumMin = value; }
        public static int ENumMax { get => _ENumMax; set => _ENumMax = value; }
        public static int CNumMin { get => _CNumMin; set => _CNumMin = value; }
        public static int CNumMax { get => _CNumMax; set => _CNumMax = value; }


     

    }
}
