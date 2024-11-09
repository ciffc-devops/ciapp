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
using Microsoft.VisualStudio.PlatformUI;
using WildfireICSDesktopServices.NewsServices;

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
            newsService = new NewsService();

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

            LoadColors(2);

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
        private static NewsService _newsService = null;
        private static IWFIncidentService _incidentDataService = null;
        private static IPositionLogService _positionLogService= null;
        private static Icon _programIcon = Properties.Resources.P_icon;
        private static int _CurrentOpPeriod;
        private static NetworkSendLog _networkSendLog;
        private static bool _InternetSyncEnabled;
        private static Guid _MachineID;
        private static CultureInfo _cultureInfo;
        private static NetworkService _networkService = null;



        public static IGeneralOptionsService generalOptionsService { get => _generalOptionsService; private set => _generalOptionsService = value; }

        public static IPDFExportService pdfExportService { get => _pdfExportService; private set => _pdfExportService = value; }
        public static IWFIncidentService incidentDataService { get => _incidentDataService; private set => _incidentDataService = value; }
        public static NewsService newsService { get => _newsService; private set => _newsService = value; }


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
        private static void LoadColors(int colorPalletId)
        {
            List<ProgramColor> colors = ColourUtilities.GetColourSetById(colorPalletId);
            FormBackgroundColor = colors.FirstOrDefault(o => o.Name.Equals("Background")).Color;
            AccentColor = colors.FirstOrDefault(o => o.Name.Equals("Accent")).Color;
            DarkAccentColor = colors.FirstOrDefault(o => o.Name.Equals("DarkAccent")).Color;
            HelpColor = colors.FirstOrDefault(o => o.Name.Equals("Help")).Color;
            PrimaryColor = colors.FirstOrDefault(o => o.Name.Equals("Primary")).Color;
            ErrorColor = colors.FirstOrDefault(o => o.Name.Equals("BadInput")).Color;
            GoodColor = colors.FirstOrDefault(o => o.Name.Equals("GoodInput")).Color;
        }



        private static Color _FormBackgroundColor = Color.FromArgb(255, 248, 222);
        private static Color _AccentColor = Color.FromArgb(219, 218, 204);
        private static Color _DarkAccentColor = Color.FromArgb(35, 31, 32);
        private static Color _PrimaryColor = Color.FromArgb(168, 118, 62);
        private static Color _HelpColor = Color.FromArgb(122, 139, 153);
        private static Color _GoodInputColor = Color.LightSkyBlue;
        private static Color _BadInputColor = Color.LightCoral;

        public static Color FormBackgroundColor { get => _FormBackgroundColor; set => _FormBackgroundColor = value; }
        public static Color AccentColor { get => _AccentColor; set => _AccentColor = value; }
        public static Color StandardTextboxColor { get => System.Drawing.SystemColors.Window; }
        public static Color DarkAccentColor { get => _DarkAccentColor; set => _DarkAccentColor = value; }
        public static Color HelpColor { get => _HelpColor; set => _HelpColor = value; }
        public static Color PrimaryColor { get => _PrimaryColor; set => _PrimaryColor = value; }
        public static Color ErrorColor { get => _GoodInputColor; set => _GoodInputColor = value; }
        public static Color GoodColor { get => _BadInputColor; set => _BadInputColor = value; }


        //P-num controls, are these still needed?
        private static int _PNumMin = 1;
        private static int _PNumMax = 10000;
        private static int _VNumMin = 1;
        private static int _VNumMax = 10000;
        private static int _ENumMin = 1;
        private static int _ENumMax = 10000;
        private static int _CNumMin = 1;
        private static int _CNumMax = 10000;

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
