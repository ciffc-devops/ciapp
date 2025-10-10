
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;
using Wildfire_ICS_Assist.CustomControls;
using Wildfire_ICS_Assist.OptionsForms;
using Wildfire_ICS_Assist.Properties;
using Wildfire_ICS_Assist.UtilityForms;
using WildfireICSDesktopServices;

namespace Wildfire_ICS_Assist
{
    public partial class CheckedInResourcesForm : BaseForm
    {
        bool keepListBuilt = false;


        public CheckedInResourcesForm()
        {
            InitializeComponent();
            this.menuStrip1.BackColor = Program.AccentColor;
        }

        private void CheckedInResourcesForm_Load(object sender, EventArgs e)
        {
            keepListBuilt = false;
            _bw.DoWork += bw_DoWork;
            _bw.ProgressChanged += backgroundWorker_ProgressChanged;
            _bw.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;


            cpFilters.Collapsed = false;
            cpPNumbers.Collapsed = true;
            this.dgvResources.DoubleBuffered(true);

            dgvResources.AutoGenerateColumns = false;
            cboExpandCrews.SelectedIndex = 0;
            cboResourceVariety.SelectedIndex = 0;
            BuildLastDayOnIncidentFilterOptions();
            LoadResourcesList();
            LoadPNumbers();
            cboAssignedFilter.SelectedIndex = 0;
            Program.incidentDataService.MemberSignInChanged += Program_CheckInChanged;
            Program.incidentDataService.VehicleChanged += Program_VehicleChanged;
            Program.incidentDataService.OperationalSubGroupChanged += Program_OperationalSubGroupChanged;
            Program.incidentDataService.AircraftChanged += WfIncidentService_AircraftChanged;
            Program.incidentDataService.CurrentOpPeriodChanged += Program_OperationalPeriodChanged;

            keepListBuilt = true;
            BuildCheckInListViaWorker();


        }

        private void WfIncidentService_AircraftChanged(AircraftEventArgs e)
        {
            LoadResourcesList();
        }

        public static int PNumMin { get => Program.PNumMin; set => Program.PNumMin = value; }
        public static int PNumMax { get => Program.PNumMax; set => Program.PNumMax = value; }
        public static int VNumMin { get => Program.VNumMin; set => Program.VNumMin = value; }
        public static int VNumMax { get => Program.VNumMax; set => Program.VNumMax = value; }
        public static int ENumMin { get => Program.ENumMin; set => Program.ENumMin = value; }
        public static int ENumMax { get => Program.ENumMax; set => Program.ENumMax = value; }
        public static int CNumMin { get => Program.CNumMin; set => Program.CNumMin = value; }
        public static int CNumMax { get => Program.CNumMax; set => Program.CNumMax = value; }


        private void LoadPNumbers()
        {
            numPNumMin.Value = PNumMin; numPNumMax.Value = PNumMax;
            numVNumMin.Value = VNumMin; numVNumMax.Value = VNumMax;
            numENumMin.Value = ENumMin; numENumMax.Value = ENumMax;
            numCNumMin.Value = CNumMin; numCNumMax.Value = CNumMax;

            //ConfirmResourceNumberAvailability();
        }

        private void Program_OperationalPeriodChanged(IncidentOpPeriodChangedEventArgs e)
        {
            LoadResourcesList();
        }

        private void Program_CheckInChanged(CheckInEventArgs e)
        {

            LoadResourcesList();
            //ConfirmResourceNumberAvailability();

        }
        private void Program_VehicleChanged(VehicleEventArgs e)
        {
            LoadResourcesList();
            //ConfirmResourceNumberAvailability();
        }

        private void Program_OperationalSubGroupChanged(CrewEventArgs e)
        {
            LoadResourcesList();
            //ConfirmResourceNumberAvailability();

        }

        private void ConfirmResourceNumberAvailability()
        {
            /*
            StringBuilder note = new StringBuilder();

            int nextP = Program.CurrentIncident.GetNextUniqueNum("Personnel", PNumMin, PNumMax);
            int nextV = Program.CurrentIncident.GetNextUniqueNum("Vehicle", VNumMin, VNumMax);
            int nextE = Program.CurrentIncident.GetNextUniqueNum("Equipment", ENumMin, ENumMax);
            int nextC = Program.CurrentIncident.GetNextUniqueNum("Crew", CNumMin, CNumMax);

            if (nextP > (PNumMax - 20)) { note.Append("You are running low on Personnel (P) numbers, please add more before continuing to check resources in"); note.Append(Environment.NewLine); lblPNumTitle.ForeColor = Program.ErrorColor; }
            else if (nextP < 0) { note.Append("You do not have any available Personnel (P) numbers"); note.Append(Environment.NewLine); lblPNumTitle.ForeColor = Program.ErrorColor; }
            else { lblPNumTitle.ForeColor = label1.ForeColor; }

            if (nextV > (VNumMax - 20)) { note.Append("You are running low on Vehicle (V) numbers, please add more before continuing to check resources in"); note.Append(Environment.NewLine); lblVNumTitle.ForeColor = Program.ErrorColor; }
            else if (nextV < 0) { note.Append("You do not have any available Vehicle (V) numbers"); note.Append(Environment.NewLine); lblVNumTitle.ForeColor = Program.ErrorColor; }
            else { lblVNumTitle.ForeColor = label1.ForeColor; }


            if (nextE > (ENumMax - 20)) { note.Append("You are running low on Equipment (E) numbers, please add more before continuing to check resources in"); note.Append(Environment.NewLine); lblENumTitle.ForeColor = Program.ErrorColor; }
            else if (nextE < 0) { note.Append("You do not have any available Equipment (E) numbers"); note.Append(Environment.NewLine); lblENumTitle.ForeColor = Program.ErrorColor; }
            else { lblENumTitle.ForeColor = label1.ForeColor; }


            if (nextC > (CNumMax - 20)) { note.Append("You are running low on Crew (C) numbers, please add more before continuing to check resources in"); note.Append(Environment.NewLine); lblCNumTitle.ForeColor = Program.ErrorColor; }
            else if (nextC < 0) { note.Append("You do not have any available Crew (C) numbers"); note.Append(Environment.NewLine); lblCNumTitle.ForeColor = Program.ErrorColor; }
            else { lblCNumTitle.ForeColor = label1.ForeColor; }

            if (note.Length > 0)
            {
                LgMessageBox.Show(note.ToString());
                btnStartCheckIn.Enabled = false;
            }
            else
            {
                btnStartCheckIn.Enabled = true;
            }
            */
        }

        private Aircraft UpdateAircraftFromCheckinInfo(CheckInRecord record, Aircraft air)
        {
            if (record.GetInfoFieldValue(new Guid("2747c124-5f49-4594-b33c-27914cf639c1")) != null) { air.Pilot = record.GetInfoFieldValue(new Guid("2747c124-5f49-4594-b33c-27914cf639c1")).ToString(); }
            air.LeaderName = air.Pilot;
            //if (record.GetInfoFieldValue(new Guid("4d85520b-e0a7-4667-be82-9dbfe8c85f8d")) != null) { air.IsMedivac = Convert.ToBoolean(record.GetInfoFieldValue(new Guid("4d85520b-e0a7-4667-be82-9dbfe8c85f8d"))); }
            air.IsMedivac = false;
            if (record.GetInfoFieldValue(new Guid("f61cd676-dba8-4ca3-a26a-ae47ffb5fe2f")) != null) { air.NumberOfPeople = Convert.ToInt32(record.GetInfoFieldValue(new Guid("f61cd676-dba8-4ca3-a26a-ae47ffb5fe2f"))); }
            air.Type = air.AircraftTypeText;
            air.Kind = air.MakeModel;
            air.OpPeriod = Program.CurrentOpPeriod;
            if (record.GetInfoFieldValue(new Guid("52e0b701-0f1b-445c-855a-dd7354b3078e")) != null) { air.Base = record.GetInfoFieldValue(new Guid("52e0b701-0f1b-445c-855a-dd7354b3078e")).ToString(); }

            //if (record.GetInfoFieldValue(new Guid("41ABBEA0-5995-4F23-883E-8F2C311A922D")) != null) { air.StartTime = Convert.ToDateTime(record.GetInfoFieldValue(new Guid("41ABBEA0-5995-4F23-883E-8F2C311A922D"))); }
            
            //Program.wfIncidentService.UpsertAircraft(air);
            return air;
        }
        private bool StartCheckIn(bool autoStart, CheckInRecord existingRecord = null)
        {
            bool autoStartNextCheckin = false;
            using (CheckInForm signInForm = new CheckInForm())
            {
                if (existingRecord != null) { signInForm.SetCheckIn(existingRecord); }

                signInForm.AutoStartNextCheckin = autoStart;
                DialogResult dr = signInForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //get the resource and add it to the appropriate place
                    CheckInRecord record = signInForm.checkInRecord;
                    IncidentResource resource = signInForm.selectedResource;






                    switch (record.ResourceType)
                    {
                        case "Personnel":
                            Personnel p = resource as Personnel;
                            p.ParentResourceID = Guid.Empty;
                            if (string.IsNullOrEmpty(p.LeaderName)) { p.LeaderName = p.Name; }
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, PNumMin, PNumMax); }
                            Program.incidentDataService.UpsertPersonnel(p);

                            if (signInForm.SavePersonForLater)
                            {
                                Program.generalOptionsService.UpsertOptionValue(p.Clone(), "TeamMember");
                            }

                            break;
                        case "Operator":
                            Personnel op = resource as Personnel;
                            if (string.IsNullOrEmpty(op.LeaderName)) { op.LeaderName = op.Name; }
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, PNumMin, PNumMax); }
                            Program.incidentDataService.UpsertPersonnel(op);
                            break;
                        case "Visitor":
                            Personnel vis = resource as Personnel;
                            vis.ParentResourceID = Guid.Empty;
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, PNumMin, PNumMax); }
                            Program.incidentDataService.UpsertPersonnel(vis);

                            break;
                        case "Vehicle":
                            Vehicle v = resource as Vehicle;
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, VNumMin, VNumMax); }
                            if (v.OperatorID != Guid.Empty) { v.NumberOfPeople = 1; }
                            Program.incidentDataService.UpsertVehicle(v);

                            if (v.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == v.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == v.OperatorID) as Personnel;
                                eqop.ParentResourceID = v.ID;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            }

                            break;
                        case "Equipment":
                            Vehicle ve = resource as Vehicle;
                            if (ve.OperatorID != Guid.Empty) { ve.NumberOfPeople = 1; }
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, ENumMin, ENumMax); }
                            Program.incidentDataService.UpsertVehicle(ve);
                            if (ve.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == ve.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == ve.OperatorID) as Personnel;
                                eqop.ParentResourceID = ve.ID;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            }
                            break;
                        case "Aircraft":
                            Aircraft air = resource as Aircraft;
                            air.NumberOfPeople = 1;
                            air.StartTime = Program.CurrentOpPeriodDetails.PeriodStart;
                            air.EndTime = Program.CurrentOpPeriodDetails.PeriodEnd;
                           air =  UpdateAircraftFromCheckinInfo(record, air);
                            Program.incidentDataService.UpsertAircraft(air);
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, ENumMin, ENumMax); }

                            break;


                        case "Crew":
                            Crew group = resource as Crew;
                            if (resource.UniqueIDNum <= 0) { resource.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(record.ResourceType, CNumMin, CNumMax); }
                            if (group.IsEquipmentCrew) { group.Kind = "Heavy Equipment Crew"; }
                            else { group.Kind = "Crew"; }

                            if (group.ActiveResourceListing.Any(o => o.IsLeader)) { group.LeaderID = group.ActiveResourceListing.First(o => o.IsLeader).ResourceID; group.LeaderName = group.ActiveResourceListing.First(o => o.IsLeader).ResourceName; }
                            List<OperationalGroupResourceListing> toRemoveFromCrew = signInForm.resourcesToRemoveFromCrew;
                            foreach (OperationalGroupResourceListing l in toRemoveFromCrew)
                            {
                                if (Program.CurrentIncident.AllOperationalSubGroups.Any(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod))
                                {
                                    Crew sub = Program.CurrentIncident.AllOperationalSubGroups.First(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod);
                                    sub.ResourceListing = sub.ResourceListing.Where(o => o.ResourceID != l.ResourceID).ToList();
                                    Program.incidentDataService.UpsertCrew(sub);
                                }


                                if (Program.CurrentIncident.AllCheckInRecords.Any(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod))
                                {
                                    Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod).ParentRecordID = Guid.Empty;
                                    Program.incidentDataService.UpsertCheckInRecord(Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod));
                                }



                            }


                            Program.incidentDataService.UpsertCrew(group);
                            foreach (IncidentResource subres in signInForm.SubResources)
                            {
                                if (subres.GetType().Name.Equals("Personnel"))
                                {
                                    subres.OpPeriod = Program.CurrentOpPeriod;
                                    if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, PNumMin, PNumMax); }
                                    subres.ParentResourceID = group.ID;
                                    Program.incidentDataService.UpsertPersonnel(subres as Personnel);
                                    CheckInRecord prec = signInForm.checkInRecord.Clone();
                                    prec.ResourceID = subres.ID;
                                    prec.ResourceName = subres.ResourceName;
                                    prec.SignInRecordID = Guid.NewGuid();
                                    prec.ParentRecordID = record.SignInRecordID;
                                    prec.ResourceType = "Personnel";
                                    Program.incidentDataService.UpsertCheckInRecord(prec);
                                }
                                else if (subres.GetType().Name.Equals("Vehicle"))
                                {
                                    Vehicle vh = subres as Vehicle;
                                    vh.OperatorName = group.ResourceName;
                                    if (vh.IsEquipment)
                                    {
                                        if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, ENumMin, ENumMax); }
                                    }
                                    else
                                    {
                                        if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, VNumMin, VNumMax); }
                                    }
                                    subres.ParentResourceID = group.ID;
                                    Program.incidentDataService.UpsertVehicle(vh);
                                    CheckInRecord vrec = signInForm.checkInRecord.Clone();
                                    vrec.ResourceID = subres.ID;
                                    vrec.SignInRecordID = Guid.NewGuid();
                                    vrec.ParentRecordID = record.SignInRecordID;
                                    if (vrec.IsEquipment) { vrec.ResourceType = "Equipment"; }
                                    else { vrec.ResourceType = "Vehicle"; }
                                    Program.incidentDataService.UpsertCheckInRecord(vrec);
                                }
                            }
                            break;
                    }


                    Program.incidentDataService.UpsertCheckInRecord(record);

                    if (signInForm.AssignIfPossible && !string.IsNullOrEmpty(record.InitialRoleAcronym))
                    {
                        if (Program.CurrentOrgChart.ActiveRoles.Any(o => !string.IsNullOrEmpty(o.MnemonicAbrv) && o.MnemonicAbrv.Equals(record.InitialRoleAcronym) && o.IndividualID == Guid.Empty) && Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == record.ResourceID))
                        {
                            ICSRole role = Program.CurrentOrgChart.ActiveRoles.First(o => !string.IsNullOrEmpty(o.MnemonicAbrv) && o.MnemonicAbrv.Equals(record.InitialRoleAcronym) && o.IndividualID == Guid.Empty);
                            Personnel p = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == record.ResourceID);
                            role.IndividualID = p.ID;
                            role.IndividualName = p.Name;
                            //role.teamMember = p.Clone();
                            Program.incidentDataService.UpsertICSRole(role);
                        }
                    }


                    autoStartNextCheckin = signInForm.AutoStartNextCheckin;
                }
            }
            return autoStartNextCheckin;
        }

        private class FilterSettings
        {
            public bool ShowCrewDetails { get; set; } = false;
            public int CheckInStatus { get; set; } = 0;
            public int ResourceVariety { get; set; } = 0;
            public string ResourceVarietyName { get; set; } = string.Empty;
            public int TimeOut { get; set; } = 0;
            public int Assigned { get; set; } = 0;
            public DateTime MidPoint { get; set; }
        }


        private void LoadResourcesList()
        {
            if (keepListBuilt)
            {
                BuildCheckInListViaWorker();

            }

            /*
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            bool showCrewDetails = cboExpandCrews.SelectedIndex == 1;
            DateTime mid = Program.CurrentOpPeriodDetails.PeriodMid;
            if (showCrewDetails)
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }
            else
            {
                foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod && o.ParentRecordID == Guid.Empty))
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null && resource.ParentResourceID == Guid.Empty)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }


            checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();



            if (cboResourceVariety.SelectedIndex > 0)
            {
                string variety = cboResourceVariety.Text;
                checkInRecords = checkInRecords.Where(o => o.ResourceType.Equals(variety)).ToList(); ;
            }


            DateTime EndOfOp = Program.CurrentOpPeriodDetails.PeriodEnd;

            switch (cboTimeOutFilter.SelectedIndex)
            {
                case 0:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid)).ToList(); break;
                case 2:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= YellowNumber).ToList();
                    break;
                case 3:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= YellowNumber && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) > RedNumber).ToList();
                    break;
                case 4:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(mid) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= RedNumber).ToList();
                    break;
            }


            if (cboAssignedFilter.SelectedIndex == 1)
            {
                checkInRecords = checkInRecords.Where(o => !Program.CurrentIncident.GetIsResourceCurrentlyAssigned(Program.CurrentOpPeriod, o.Resource.ID)).ToList();

            }

            if (_previousIndex >= 0 && dgvResources.Columns.Count > _previousIndex) { checkInRecords = GetSortedList(checkInRecords, dgvResources.Columns[_previousIndex].Name, _sortDirection); }
            dgvResources.DataSource = checkInRecords;
            */
        }


        static BackgroundWorker _bw = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        static bool RunBWAgain = false;
        private void BuildCheckInListViaWorker()
        {

            FilterSettings filters = new FilterSettings();
            filters.ShowCrewDetails = cboExpandCrews.SelectedIndex == 1;
            //filters.CheckInStatus = cboCheckInStatus.SelectedIndex;
            filters.ResourceVariety = cboResourceVariety.SelectedIndex;
            filters.TimeOut = cboTimeOutFilter.SelectedIndex;
            filters.Assigned = cboAssignedFilter.SelectedIndex;
            filters.MidPoint = Program.CurrentOpPeriodDetails.PeriodMid;
            filters.ResourceVarietyName = cboResourceVariety.Text;
            
            if (_bw.IsBusy == false)
            {
                dgvResources.Visible = false;
                progBuildList.Visible = true;
                _bw.RunWorkerAsync(filters);
            }
            else { RunBWAgain = true; }
        }

        static void bw_DoWork(object sender, DoWorkEventArgs e)
        {


            DateTime today = DateTime.Now;


            FilterSettings filters = (FilterSettings)e.Argument;

            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            List<CheckInRecord> allRecords = new List<CheckInRecord>(Program.CurrentIncident.AllCheckInRecords.Where(o => o.Active && o.OpPeriod <= Program.CurrentOpPeriod));

            _bw.ReportProgress(0);


            if (filters.ShowCrewDetails)
            {
                foreach (CheckInRecord rec in allRecords)
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }
            else
            {
                foreach (CheckInRecord rec in allRecords)
                {
                    IncidentResource resource = new IncidentResource();
                    if (Program.CurrentIncident.AllIncidentResources.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.AllIncidentResources.First(o => o.ID == rec.ResourceID);
                    }

                    if (resource != null && resource.ParentResourceID == Guid.Empty)
                    {
                        checkInRecords.Add(new CheckInRecordWithResource(rec, resource, Program.CurrentOpPeriodDetails.PeriodEnd));
                    }
                }
            }


            //checkInRecords = checkInRecords.OrderBy(o => o.ResourceName).ToList();
            _bw.ReportProgress(30);



            if (filters.ResourceVariety > 0)
            {
                checkInRecords = checkInRecords.Where(o => o.ResourceType.Equals(filters.ResourceVarietyName)).ToList(); ;
            }
            _bw.ReportProgress(50);


            DateTime EndOfOp = Program.CurrentOpPeriodDetails.PeriodEnd;


            switch (filters.TimeOut)
            {
                case 0:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(filters.MidPoint)).ToList(); break;
                case 2:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(filters.MidPoint) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= YellowNumber).ToList();
                    break;
                case 3:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(filters.MidPoint) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= YellowNumber && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) > RedNumber).ToList();
                    break;
                case 4:
                    checkInRecords = checkInRecords.Where(o => o.Record.CheckedInThisTime(filters.MidPoint) && Math.Round(((TimeSpan)(o.LastDayOnIncident - EndOfOp)).TotalDays, 0) <= RedNumber).ToList();
                    break;
            }
            _bw.ReportProgress(80);


            if (filters.Assigned == 1)
            {
                checkInRecords = checkInRecords.Where(o => !Program.CurrentIncident.GetIsResourceCurrentlyAssigned(Program.CurrentOpPeriod, o.Resource.ID)).ToList();

            }

            _bw.ReportProgress(100);


            e.Result = checkInRecords;
        }
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progBuildList.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<CheckInRecordWithResource> checkInRecords = (List<CheckInRecordWithResource>)e.Result;
            if (_previousIndex >= 0 && dgvResources.Columns.Count > _previousIndex) { checkInRecords = GetSortedList(checkInRecords, dgvResources.Columns[_previousIndex].Name, _sortDirection); }
            //progBuildList.Visible = false;
            //progressBar1.Visible = false;
            dgvResources.DataSource = checkInRecords;
            dgvResources.Visible = true;
            if (dgvResources.Columns.Count >= 3)
            {
                dgvResources.Columns[0].Frozen = true;
                dgvResources.Columns[1].Frozen = true;
                dgvResources.Columns[2].Frozen = true;
            }
            if (RunBWAgain || e.Cancelled)
            {
                RunBWAgain = false;
                BuildCheckInListViaWorker();
            }
        }




        private void btnStartCheckIn_Click(object sender, EventArgs e)
        {

            bool autoStartCheckin = false;
            do
            {
                autoStartCheckin = StartCheckIn(autoStartCheckin);
            } while (autoStartCheckin);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                StartCheckIn(false, rec.Record);
            }
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            cpFilters.Width = splitContainer2.Panel2.Width - 10;
            cpFilters.SizeWhenCollapsed = new Size(cpFilters.Width, cpFilters.SizeWhenCollapsed.Height);
            cpFilters.SizeWhenExpanded = new Size(cpFilters.Width, cpFilters.SizeWhenExpanded.Height);

        }

        private void splitContainer2_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
        }

        private void cboResourceVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResourcesList();

        }


        static int YellowNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("YellowResourceTimeoutDays"));
        static int RedNumber = Convert.ToInt32(Program.generalOptionsService.GetOptionsValue("RedResourceTimeoutDays"));

        private void BuildLastDayOnIncidentFilterOptions()
        {
            List<string> options = new List<string>();
            options.Add("Checked-In Resources");
            options.Add("All Resources");
            options.Add("Yellow (" + YellowNumber + ") and Red (" + RedNumber + ")");
            options.Add("Yellow (" + YellowNumber + ") only");
            options.Add("Red (" + RedNumber + ") only");
            cboTimeOutFilter.DataSource = options;
            cboTimeOutFilter.SelectedIndex = 0;
        }

        private void dgvResources_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvResources.Rows.Count > 0 && e.RowIndex <= dgvResources.Rows.Count && dgvResources.Rows[e.RowIndex] != null)
            {


                DataGridViewRow row = dgvResources.Rows[e.RowIndex];
                CheckInRecordWithResource item = (CheckInRecordWithResource)row.DataBoundItem;
                DateTime mid = Program.CurrentOpPeriodDetails.PeriodMid;

                if (!item.Record.CheckedInThisTime(mid))
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.Font = new Font(dgvResources.DefaultCellStyle.Font.Name, dgvResources.DefaultCellStyle.Font.Size, FontStyle.Italic);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.Font = new Font(dgvResources.DefaultCellStyle.Font.Name, dgvResources.DefaultCellStyle.Font.Size, FontStyle.Regular);

                }

                if (item.DaysTillTimeOut <= RedNumber)
                {
                    row.Cells["colLastDay"].Style.BackColor = Color.Red;
                }
                else if (item.DaysTillTimeOut <= YellowNumber)
                {
                    row.Cells["colLastDay"].Style.BackColor = Color.Yellow;
                }
                else
                {
                    row.Cells["colLastDay"].Style.BackColor = Color.White;

                }

            }
        }

        private void cboTimeOutFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResourcesList();
        }


        private void cboAssignedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResourcesList();

        }

        private void dgvResources_SelectionChanged(object sender, EventArgs e)
        {
            btnEditCheckIn.Enabled = dgvResources.SelectedRows.Count == 1;
            btnEditResource.Enabled = dgvResources.SelectedRows.Count == 1;
            btnDemob.Enabled = dgvResources.SelectedRows.Count == 1;
            btnChangeID.Enabled = btnEditCheckIn.Enabled;
        }

        private void btnDemob_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource item = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenDemobForEdit(item);
            }
        }

        private void OpenDemobForEdit(CheckInRecordWithResource res)
        {
            DemobilizationRecord demob = new DemobilizationRecord();
            if (Program.CurrentIncident.ActiveDemobilizationRecords.Any(o => o.SignInRecordID == res.Record.SignInRecordID))
            {
                demob = Program.CurrentIncident.ActiveDemobilizationRecords.First(o => o.SignInRecordID == res.Record.SignInRecordID);
            }
            else
            {
                demob.SignInRecordID = res.Record.SignInRecordID;
                demob.ResourceID = res.Resource.ID;
                demob.DebriefDate = DateTime.Now;
                demob.DemobDate = DateTime.Now;
                demob.OpPeriod = Program.CurrentOpPeriod;

            }

            using (DemobilizeResourceForm demobForm = new DemobilizeResourceForm())
            {
                demobForm.SetRecord(res.Resource, res.Record, demob);
                DialogResult dr = demobForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Program.incidentDataService.UpsertDemobRecord(demob);



                }
            }

        }

        private void dgvResources_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dgvResources.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.None)
                {
                    dgvResources.ClearSelection();
                    dgvResources.CurrentCell = null;
                }
            }*/
        }

        private void btnPNumHelp_Click(object sender, EventArgs e)
        {
            HelpInfo info = new HelpInfo();
            if (info.loadByTopic("UniqueResourceNumbers"))
            {
                using (HelpInfoForm help = new HelpInfoForm())
                {
                    help.Title = info.Title;
                    help.Body = info.Body;
                    help.ShowDialog();
                }
            }
        }

        private void numPNumMin_ValueChanged(object sender, EventArgs e)
        {
            PNumMin = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();


        }

        private void numPNumMax_ValueChanged(object sender, EventArgs e)
        {
            PNumMax = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numVNumMin_ValueChanged(object sender, EventArgs e)
        {
            VNumMin = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numVNumMax_ValueChanged(object sender, EventArgs e)
        {
            VNumMax = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numENumMin_ValueChanged(object sender, EventArgs e)
        {
            ENumMin = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numENumMax_ValueChanged(object sender, EventArgs e)
        {
            ENumMax = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numCNumMin_ValueChanged(object sender, EventArgs e)
        {
            CNumMax = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void numCNumMax_ValueChanged(object sender, EventArgs e)
        {
            CNumMax = Convert.ToInt32(((NumericUpDown)sender).Value); ConfirmResourceNumberAvailability();
        }

        private void cboExpandCrews_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResourcesList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenResourceForEdit(rec);
            }
        }

        private void changeUniqueIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                UpdateUniqueID(rec);
            }
        }

        private void UpdateUniqueID(CheckInRecordWithResource rec)
        {
            if (rec != null)
            {
                using (ResourcesEditUniqueNumberForm editForm = new ResourcesEditUniqueNumberForm())
                {
                    editForm.SetResource(rec.Resource);
                    DialogResult dr = editForm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        rec.Resource.UniqueIDNum = editForm.newNumber;
                        Program.incidentDataService.UpsertIncidentResource(rec.Resource);
                    }
                }
            }
        }

        private void demobilizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource item = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenDemobForEdit(item);
            }
        }

        private void btnLogisticsOverview_Click(object sender, EventArgs e)
        {
            PrintLogisticsOverview();

        }

        private void PrintLogisticsOverview()
        {

            ICSRole role = null;
            List<byte[]> allPDFs = Program.pdfExportService.exportLogisticsSummaryToPDF(Program.CurrentTask, Program.CurrentOpPeriod, role, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Logistics Overview " + Program.CurrentIncident.IncidentNameAndNumberForPath;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { LgMessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
        }

        private void btnExportSignInToCSV_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void ExportToCSV()
        {
            svdExport.FileName = "Check In Records-" + Program.CurrentIncident.IncidentNameAndNumberForPath + "-OP-" + Program.CurrentOpPeriod + ".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";

                List<CheckInRecordWithResource> resources = Program.CurrentIncident.GetAllCheckInWithResources(Program.CurrentOpPeriod);




                string csv = resources.ExportCheckInRecordsToCSV(Program.CurrentIncident.ActiveDemobilizationRecords.Where(o => o.OpPeriod <= Program.CurrentOpPeriod).ToList(), delimiter);
                try
                {
                    System.IO.File.WriteAllText(exportPath, csv);

                    DialogResult openNow = LgMessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                    if (openNow == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(exportPath);
                    }

                }
                catch (Exception ex)
                {
                    LgMessageBox.Show("Sorry, there was a problem writing to the file.  It is likely the file was already open elsewhere.  Please check for open copies and try again.");
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            System.Drawing.Point ptLowerLeft = new System.Drawing.Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsPrint211.Show(ptLowerLeft);




        }

        private void PrintNew211s()
        {
            List<byte[]> allPDFs = Program.pdfExportService.exportCheckInSheetsToPDF(Program.CurrentTask, Program.CurrentOpPeriod, true, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS-211 " + Program.CurrentIncident.IncidentNameAndNumberForPath;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { LgMessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
        }

        private void PrintAll211s()
        {
            List<byte[]> allPDFs = Program.pdfExportService.exportCheckInSheetsToPDF(Program.CurrentTask, Program.CurrentOpPeriod, false, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "ICS-211 " + Program.CurrentIncident.IncidentNameAndNumberForPath;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { LgMessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }

        }

        private void btnPrinttAll211sToDate_Click(object sender, EventArgs e)
        {
            PrintAll211s();
        }

        private int _previousIndex = 1;
        private bool _sortDirection = true;
        private void dgvResources_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // toggle direction

            List<CheckInRecordWithResource> list = (List<CheckInRecordWithResource>)dgvResources.DataSource;
            dgvResources.DataSource = GetSortedList(list, dgvResources.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;
        }

        private List<CheckInRecordWithResource> GetSortedList(List<CheckInRecordWithResource> list, string column, bool ascending)
        {
            switch (column)
            {
                case "colVariety":
                    if (ascending) { list = list.OrderBy(o => o.ResourceType).ToList(); }
                    else { list = list.OrderByDescending(o => o.ResourceType).ToList(); }
                    break;
                case "colID":
                    if (ascending) { list = list.OrderBy(o => o.UniqueIDNumWithPrefix).ToList(); }
                    else { list = list.OrderByDescending(o => o.UniqueIDNumWithPrefix).ToList(); }
                    break;
                case "colName":
                    if (ascending) { list = list.OrderBy(o => o.ResourceName).ToList(); }
                    else { list = list.OrderByDescending(o => o.ResourceName).ToList(); }
                    break;
                case "colKind":
                    if (ascending) { list = list.OrderBy(o => o.Kind).ToList(); }
                    else { list = list.OrderByDescending(o => o.Kind).ToList(); }
                    break;
                case "colType":
                    if (ascending) { list = list.OrderBy(o => o.Type).ToList(); }
                    else { list = list.OrderByDescending(o => o.Type).ToList(); }
                    break;
                case "colCheckIn":
                    if (ascending) { list = list.OrderBy(o => o.CheckInDate).ToList(); }
                    else { list = list.OrderByDescending(o => o.CheckInDate).ToList(); }
                    break;
                case "colLastDay":
                    if (ascending) { list = list.OrderBy(o => o.LastDayOnIncident).ToList(); }
                    else { list = list.OrderByDescending(o => o.LastDayOnIncident).ToList(); }
                    break;
                case "colStatus":
                    if (ascending) { list = list.OrderBy(o => o.Status).ToList(); }
                    else { list = list.OrderByDescending(o => o.Status).ToList(); }
                    break;
            }
            return list;
        }

        private void btnDietaryAndAllergy_Click(object sender, EventArgs e)
        {

            PrintDietaryAndAllergySummary();
        }

        private void PrintDietaryAndAllergySummary()
        {
            List<byte[]> allPDFs = Program.pdfExportService.exportDietaryAndAllergyToPDF(Program.CurrentTask, Program.CurrentOpPeriod, true, false);

            string fullFilepath = "";
            fullFilepath = FileAccessClasses.getWritablePath(Program.CurrentIncident);

            string fullOutputFilename = "Dietary and Allergy Details - " + Program.CurrentIncident.IncidentNameAndNumberForPath;
            fullFilepath = FileAccessClasses.getUniqueFileName(fullOutputFilename, fullFilepath);

            byte[] fullFile = FileAccessClasses.concatAndAddContent(allPDFs);
            try
            {
                File.WriteAllBytes(fullFilepath, fullFile);
                System.Diagnostics.Process.Start(fullFilepath);
            }
            catch (Exception ex) { LgMessageBox.Show("There was an error trying to save " + fullFilepath + " please verify the path is accessible.\r\n\r\nDetailed error details:\r\n" + ex.ToString()); }
        }

        private void btnEditResource_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                OpenResourceForEdit(rec);
            }
        }

        private void btnEditCheckIn_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                EditCheckInInfo(rec);
            }
        }

        private void EditCheckInInfo(CheckInRecordWithResource rec)
        {
            using (CheckInInfoEditForm editForm = new CheckInInfoEditForm())
            {
                editForm.SetRecord(rec.Clone());
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    editForm.SelectedRecord.DateReplacementRequired = editForm.SelectedRecord.LastDayOnIncident.AddDays(-1);
                    Program.incidentDataService.UpsertCheckInRecord(editForm.SelectedRecord);


                    if (editForm.SelectedRecord.ResourceType.Equals("Aircraft"))
                    {
                        if (Program.CurrentIncident.AllAircraft.Any(o => o.ID == editForm.SelectedRecord.ResourceID))
                        {
                            Aircraft air = UpdateAircraftFromCheckinInfo(editForm.SelectedRecord, Program.CurrentIncident.AllAircraft.First(o => o.ID == editForm.SelectedRecord.ResourceID).Clone());
                            Program.incidentDataService.UpsertAircraft(air);
                        }
                    }
                    


                    if (editForm.AssignIfPossible && !string.IsNullOrEmpty(editForm.SelectedRecord.InitialRoleName))
                    {
                        if (Program.CurrentOrgChart.ActiveRoles.Any(o => !string.IsNullOrEmpty(o.BaseRoleName) && o.BaseRoleName.Equals(editForm.SelectedRecord.InitialRoleName) && o.IndividualID == Guid.Empty) && Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == editForm.SelectedRecord.ResourceID))
                        {
                            ICSRole role = Program.CurrentOrgChart.ActiveRoles.First(o => !string.IsNullOrEmpty(o.BaseRoleName) && o.BaseRoleName.Equals(editForm.SelectedRecord.InitialRoleName) && o.IndividualID == Guid.Empty);
                            Personnel p = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == editForm.SelectedRecord.ResourceID);
                            role.IndividualID = p.ID;
                            role.IndividualName = p.Name;
                            //role.teamMember = p.Clone();
                            Program.incidentDataService.UpsertICSRole(role);
                        }
                    }

                }
            }
        }
        

        private void OpenResourceForEdit(CheckInRecordWithResource rec)
        {

            switch (rec.ResourceType)
            {
                case "Personnel":
                    Personnel p = rec.Resource as Personnel;
                    using (EditSavedPersonnelForm personnelForm = new EditSavedPersonnelForm())
                    {
                        personnelForm.selectedMember = p.Clone();
                        if (personnelForm.ShowDialog() == DialogResult.OK)
                        {
                            Program.incidentDataService.UpsertPersonnel(personnelForm.selectedMember);
                        }
                    }


                    break;

                case "Visitor":
                    Personnel v = rec.Resource as Personnel;
                    using (EditVisitorForm personnelForm = new EditVisitorForm())
                    {
                        personnelForm.selectedPerson = v.Clone();
                        if (personnelForm.ShowDialog() == DialogResult.OK)
                        {
                            Program.incidentDataService.UpsertPersonnel(personnelForm.selectedPerson);
                        }
                    }


                    break;
                case "Vehicle":
                    Vehicle ve = rec.Resource as Vehicle;

                    using (EditSavedVehicleForm personnelForm = new EditSavedVehicleForm())
                    {
                        List<IncidentResource> potentialOperators = GetPossibleVehicleOperators(ve);
                        personnelForm.SetPossibleOperators(potentialOperators);
                        personnelForm.vehicle = ve.Clone();
                        personnelForm.DisplayOperator = true;
                        if (personnelForm.ShowDialog() == DialogResult.OK)
                        {

                            if (personnelForm.vehicle.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == personnelForm.vehicle.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == personnelForm.vehicle.OperatorID) as Personnel;
                                eqop.ParentResourceID = personnelForm.vehicle.ID;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            } else if (ve.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == ve.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == ve.OperatorID) as Personnel;
                                eqop.ParentResourceID = Guid.Empty;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            }

                            Program.incidentDataService.UpsertVehicle(personnelForm.vehicle);

                        }
                    }

                    break;
                case "Equipment":
                    Vehicle eq = rec.Resource as Vehicle;
                    using (EditSavedVehicleForm personnelForm = new EditSavedVehicleForm())
                    {

                        List<IncidentResource> potentialOperators = GetPossibleVehicleOperators(eq);
                        personnelForm.SetPossibleOperators(potentialOperators);


                        personnelForm.DisplayOperator = true;
                        personnelForm.vehicle = eq.Clone();
                        if (personnelForm.ShowDialog() == DialogResult.OK)
                        {
                            if (personnelForm.vehicle.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == personnelForm.vehicle.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == personnelForm.vehicle.OperatorID) as Personnel;
                                eqop.ParentResourceID = personnelForm.vehicle.ID;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            }
                            else if (eq.OperatorID != Guid.Empty && Program.CurrentIncident.ActiveIncidentResources.Any(o => o.ID == eq.OperatorID))
                            {
                                Personnel eqop = Program.CurrentIncident.ActiveIncidentResources.First(o => o.ID == eq.OperatorID) as Personnel;
                                eqop.ParentResourceID = Guid.Empty;
                                Program.incidentDataService.UpsertPersonnel(eqop);
                            }

                            Program.incidentDataService.UpsertVehicle(personnelForm.vehicle);
                        }
                    }

                    break;
                case "Crew":
                    Crew crew = rec.Resource as Crew;
                    using (CheckInEditCrewForm crewForm = new CheckInEditCrewForm())
                    {
                        crewForm.selectedCrew = crew.Clone();
                        UpdateEditedCrew(crew, crewForm);
                    }
                    break;
                case "Heavy Equipment Crew":
                    Crew hecrew = rec.Resource as Crew;
                    using (CheckInEditCrewForm crewForm = new CheckInEditCrewForm())
                    {
                        crewForm.selectedCrew = hecrew.Clone();
                        UpdateEditedCrew(hecrew, crewForm);
                    }
                    break;
                case "Aircraft":
                    Aircraft air = rec.Resource as Aircraft;

                    using (EditSavedAircraftForm personnelForm = new EditSavedAircraftForm())
                    {
                        personnelForm.SelectedAircraft = air.Clone();
                        if (personnelForm.ShowDialog() == DialogResult.OK)
                        {
                            Program.incidentDataService.UpsertAircraft(personnelForm.SelectedAircraft);
                        }
                    }

                    break;
            }



        }

        private List<IncidentResource> GetPossibleVehicleOperators(IncidentResource selectedResource)
        {
            List<IncidentResource> potentialOperators = (Program.CurrentIncident.GetUncommittedResources(Program.CurrentOpPeriod)).Where(o => o.GetType().Name.Equals("Personnel")).ToList();
            //in case we're editing, add the current operator
            if (selectedResource.GetType().Name.Equals("Vehicle"))
            {
                Vehicle v = selectedResource as Vehicle;
                if (v.OperatorID != Guid.Empty)
                {
                    potentialOperators.AddRange(Program.CurrentIncident.IncidentPersonnel.Where(o => o.ID == v.OperatorID));
                }
            }
            Personnel p = new Personnel();
            p.Name = "";
            p.ID = Guid.Empty;
            potentialOperators.Insert(0, p);

            
            List<IncidentResource> operatorsForNewEquipment = new List<IncidentResource>(); operatorsForNewEquipment.AddRange(potentialOperators);
            return operatorsForNewEquipment;
        }

        private void UpdateEditedCrew(Crew crew, CheckInEditCrewForm crewForm)
        {
            if (crewForm.ShowDialog() == DialogResult.OK)
            {

                Crew group = crewForm.selectedCrew;
                if (group.ActiveResourceListing.Any(o => o.IsLeader)) { group.LeaderID = group.ActiveResourceListing.First(o => o.IsLeader).ResourceID; group.LeaderName = group.ActiveResourceListing.First(o => o.IsLeader).ResourceName; }
                List<OperationalGroupResourceListing> toRemoveFromCrew = crewForm.resourcesToRemoveFromCrew;
                foreach (OperationalGroupResourceListing l in toRemoveFromCrew)
                {
                    if (Program.CurrentIncident.AllOperationalSubGroups.Any(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod))
                    {
                        Crew sub = Program.CurrentIncident.AllOperationalSubGroups.First(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod);
                        sub.ResourceListing = sub.ResourceListing.Where(o => o.ResourceID != l.ResourceID).ToList();
                        Program.incidentDataService.UpsertCrew(sub);
                    }


                    if (Program.CurrentIncident.AllCheckInRecords.Any(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod))
                    {
                        Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod).ParentRecordID = Guid.Empty;
                        Program.incidentDataService.UpsertCheckInRecord(Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod));
                    }



                }


                Program.incidentDataService.UpsertCrew(group);
                foreach (IncidentResource subres in crewForm.subResources)
                {
                    if (subres.GetType().Name.Equals("Personnel"))
                    {
                        subres.OpPeriod = Program.CurrentOpPeriod;
                        if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, PNumMin, PNumMax); }
                        subres.ParentResourceID = group.ID;
                        Program.incidentDataService.UpsertPersonnel(subres as Personnel);
                        /*
                        CheckInRecord prec = crewForm.checkInRecord.Clone();
                        prec.ResourceID = subres.ID;
                        prec.ResourceName = subres.ResourceName;
                        prec.SignInRecordID = Guid.NewGuid();
                        prec.ParentRecordID = record.SignInRecordID;
                        prec.ResourceType = "Personnel";
                        Program.wfIncidentService.UpsertCheckInRecord(prec);*/
                    }
                    else if (subres.GetType().Name.Equals("Vehicle"))
                    {
                        Vehicle vh = subres as Vehicle;
                        vh.OperatorName = group.ResourceName;
                        if (vh.IsEquipment)
                        {
                            if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, ENumMin, ENumMax); }
                        }
                        else
                        {
                            if (subres.UniqueIDNum <= 0) { subres.UniqueIDNum = Program.CurrentIncident.GetNextUniqueNum(subres.ResourceType, VNumMin, VNumMax); }
                        }
                        subres.ParentResourceID = group.ID;
                        Program.incidentDataService.UpsertVehicle(vh);
                        /*
                         CheckInRecord vrec = signInForm.checkInRecord.Clone();
                         vrec.ResourceID = subres.ID;
                         vrec.SignInRecordID = Guid.NewGuid();
                         vrec.ParentRecordID = record.SignInRecordID;
                         if (vrec.IsEquipment) { vrec.ResourceType = "Equipment"; }
                         else { vrec.ResourceType = "Vehicle"; }
                         Program.wfIncidentService.UpsertCheckInRecord(vrec);*/
                    }
                }
            }
        }

        private void editCheckInInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                EditCheckInInfo(rec);
            }
        }

        private void btnChangeID_Click(object sender, EventArgs e)
        {
            if (dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                UpdateUniqueID(rec);
            }
        }

        private void printNewICS211sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintNew211s();
        }

        private void printAllICS211sToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAll211s();
        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printLogisticsOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintLogisticsOverview();
        }

        private void printDietaryAndAllergySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDietaryAndAllergySummary();
        }

        private void exportCheckInDataToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void printNewICS211sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintNew211s();

        }

        private void printAllICS211sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintAll211s();

        }

        private void editSavedRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SavedPersonnelForm savedTeamMembersForm = new SavedPersonnelForm())
            {

                DialogResult dr = savedTeamMembersForm.ShowDialog(this);
                LgMessageBox.Show("The resources you have added/edited will now be available for check in.");
            }

        }

        private void importResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImportSavedTeamMembersForm importForm = new ImportSavedTeamMembersForm())
            {
                DialogResult dr = importForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LgMessageBox.Show("The resources you have added/edited will now be available for check in.");
                }
            }
        }

        private void importSavedVehiclesEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editSavedVehiclesEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SavedVehiclesForm savedTeamMembersForm = new SavedVehiclesForm())
            {

                DialogResult dr = savedTeamMembersForm.ShowDialog(this);
                LgMessageBox.Show("The resources you have added/edited will now be available for check in.");
            }


        }

        private void newCheckInToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool autoStartCheckin = false;
            do
            {
                autoStartCheckin = StartCheckIn(autoStartCheckin);
            } while (autoStartCheckin);
        }

        private void btnResourcePlanning_Click(object sender, EventArgs e)
        {
            ShowResourcePlanning();
        }

        private void ShowResourcePlanning()
        {
            ResourceReplacementPlanningForm form = new ResourceReplacementPlanningForm();
            form.Show();
        }

        private void replacementPlanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowResourcePlanning();
        }

        private void editSavedAircraftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavedAircraftsForm savedForm = new SavedAircraftsForm();
            savedForm.Show(this);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BuildCheckInListViaWorker();
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
