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
            /*
             

             equipmentService = new EquipmentService();
             ICAClassLibrary.Globals._equipmentService = equipmentService;
             
             
             networkSendLog = new NetworkSendLog();
            */

            generalOptionsService = new GeneralOptionsService(true);
            WF_ICS_ClassLibrary.Globals._generalOptionsService = generalOptionsService;
            
            pdfExportService = new PDFExportService();
            pdfExportService.SetDateFormat(generalOptionsService.GetStringOptionValue("DateFormat"));
            WF_ICS_ClassLibrary.Globals.DateFormat = generalOptionsService.GetStringOptionValue("DateFormat");
            wfIncidentService = new WFIncidentService();
            WF_ICS_ClassLibrary.Globals.incidentService = wfIncidentService;
            positionLogService = new PositionLogService();
            networkService = new NetworkService();

            CurrentTask = new WFIncident();
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
        /*
       
        private static PositionLogService _positionLogService = null;
        private static EquipmentService _equipmentService = null;
      
        */
        private static IGeneralOptionsService _generalOptionsService = null;
        private static IPDFExportService _pdfExportService = null;
        private static IWFIncidentService _wfIncidentService = null;
        private static IPositionLogService _positionLogService= null;
        private static Icon _programIcon = Properties.Resources.ics_ca_sq_white;
        private static ICSRole _CurrentRole;
        private static int _CurrentOpPeriod;
        private static NetworkSendLog _networkSendLog;
        private static bool _InternetSyncEnabled;
        private static Guid _MachineID;
        private static CultureInfo _cultureInfo;
        private static NetworkService _networkService = null;

        public static IGeneralOptionsService generalOptionsService { get => _generalOptionsService; private set => _generalOptionsService = value; }

        public static IPDFExportService pdfExportService { get => _pdfExportService; private set => _pdfExportService = value; }
        public static IWFIncidentService wfIncidentService { get => _wfIncidentService; private set => _wfIncidentService = value; }


        public static WFIncident CurrentIncident
        {
            get { if (wfIncidentService != null && wfIncidentService.CurrentIncident != null) { return wfIncidentService.CurrentIncident; } else { return new WFIncident(); } }
            set { wfIncidentService.CurrentIncident = value; networkService.CurrentIncidentID = value.TaskID; }
        }
        public static OrganizationChart CurrentOrgChart
        {
            get
            {
                if(CurrentIncident != null)
                {
                    CurrentIncident.createOrgChartAsNeeded(CurrentOpPeriod);
                }
                return CurrentIncident.allOrgCharts.First(o=>o.OpPeriod== CurrentOpPeriod);
            }
        }
        /*
        public static EquipmentService equipmentService { get => _equipmentService; private set => _equipmentService = value; }
        
        public static NetworkSendLog networkSendLog { get => _networkSendLog; set => _networkSendLog = value; }
        */
        public static IPositionLogService positionLogService { get => _positionLogService; private set => _positionLogService = value; }
        public static Icon programIcon { get => _programIcon; private set => _programIcon = value; }
        public static WFIncident CurrentTask { get => wfIncidentService.CurrentIncident; set { wfIncidentService.CurrentIncident = value; } }
        public static ICSRole CurrentRole { get => _CurrentRole; set => _CurrentRole = value; }
        public static int CurrentOpPeriod { get => _CurrentOpPeriod; set => _CurrentOpPeriod = value; }
        public static OperationalPeriod CurrentOpPeriodDetails { get { if (CurrentIncident != null && CurrentIncident.AllOperationalPeriods.Any(o => o.PeriodNumber == CurrentOpPeriod)) { return CurrentIncident.AllOperationalPeriods.First(o => o.PeriodNumber == CurrentOpPeriod); } else { return null; } } }
        public static bool InternetSyncEnabled { get => _InternetSyncEnabled; set => _InternetSyncEnabled = value; }
        public static Guid MachineID { get => _MachineID; set { _MachineID = value; wfIncidentService.MachineID = value; } }
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
        public static Color FormBackground { get => Color.FromArgb(246, 245, 229); }
        public static Color FormAccent { get => Color.FromArgb(219, 218, 204); }
        public static Color ErrorColor { get => Color.LightCoral; }
        public static Color GoodColor { get => Color.LightSkyBlue; }
        public static Color StandardControLColor { get => System.Drawing.SystemColors.Window; }





    }
}
