using System;
using System.Linq;

namespace WF_ICS_ClassLibrary.Models
{
    public class CheckInRecordWithResource : ICloneable
    {
        private Guid _ID;

        private CheckInRecord _Record = new CheckInRecord();
        private IncidentResource _Resource = new IncidentResource();
        private string _StatusText;

        public IncidentResource Resource { get => _Resource; private set => _Resource = value; }
        public CheckInRecord Record { get => _Record; private set => _Record = value; }
        public Guid ID { get => _ID; }
        public Guid SignInRecordID { get => _Record.SignInRecordID; }
        public string ResourceType { get => _Record.ResourceType; }
        public string Kind { get => Resource.Kind; }
        public string Type { get => Resource.Type; }
        public int NumberOfPeople { get => Resource.NumberOfPeople; }
        public int NumberOfVehicles { get => Resource.NumberOfVehicles; }
        public DateTime CheckInDate { get => Record.CheckInDate; }
        public DateTime CheckOutDate { get => Record.CheckOutDate; }
        public DateTime LastDayOnIncident
        {
            get
            {
                if (Record.LastDayOnIncident < Record.CheckOutDate) { return Record.LastDayOnIncident; }
                else { return Record.CheckOutDate; }
            }

        }
        public string LastDayOnIncidentStr
        {
            get
            {
                if (Record.LastDayOnIncident == DateTime.MaxValue && Record.CheckOutDate == DateTime.MaxValue) { return string.Empty; }
                return LastDayOnIncident.ToString(Globals.DateFormat);

            }
        }

        public string ResourceName { get => Resource.ResourceName; }
        public string LeaderName { get => Resource.LeaderName; }
        public string Status { get => _StatusText; set => _StatusText = value; }
        public int DaysTillTimeOut { get; set; }
        public string UniqueIDNumWithPrefix { get => _Resource.UniqueIDNumWithPrefix; }
        public string InitialRoleAcronym { get => _Record.InitialRoleAcronym; }
        public string CheckInLocation { get => _Record.CheckInLocation; }


        //Used for the resource planning section
        public bool ReplacementRequired { get => _Record.ReplacementRequired; set => _Record.ReplacementRequired = value; }
        public DateTime DateReplacementRequired { get => _Record.DateReplacementRequired; set => _Record.DateReplacementRequired = value; }
        public Guid ReplacementRecordID { get => _Record.ReplacementRecordID; set => _Record.ReplacementRecordID = value; }
        public string ReplacementComment { get => _Record.ReplacementComment; set => _Record.ReplacementComment = value; }
        public string HomeUnit
        {
            get
            {
                if (_Resource.GetType().Name.Equals(new Personnel().GetType().Name))
                {
                    return ((Personnel)_Resource).HomeUnit;
                }
                else { return string.Empty; }
            }
        }
        public string Transport
        {
            get
            {
                Guid fieldid = new Guid("a4f1cb0e-9774-4bdc-aeac-96976aceba89");
                if (_Record.InfoFields.Any(o => o.ID == fieldid))
                {
                    return _Record.InfoFields.First(o => o.ID == fieldid).StringValue;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string ResourceReplacementEditButtonText
        {
            get
            {
                
                if (ReplacementRecordID != Guid.Empty) { return "Edit"; }
                else { return "Create"; }
            }
        }
        public string Assignment { get; set; }
        public string NameWithAssignment { get => ResourceName + " - " + Assignment; }
        public string ReplacementOrderNumber { get; set; }
        public string ReplacementResourceName { get; set; }

        public CheckInRecordWithResource() { _ID = Guid.NewGuid(); }
        public CheckInRecordWithResource(CheckInRecord rec, IncidentResource res, DateTime EndOfOp)
        {
            _ID = Guid.NewGuid();
            _Record = rec;
            _Resource = res;
            TimeSpan ts = LastDayOnIncident - EndOfOp;
            DaysTillTimeOut = Convert.ToInt32(Math.Round(ts.TotalDays, 0));
            if (Record.CheckOutDate.Date < EndOfOp.Date || Record.LastDayOnIncident.Date < EndOfOp.Date) { _StatusText = "Checked-Out"; }
            else if (Record.CheckOutDate.Date == EndOfOp.Date) { _StatusText = "Demobilizing"; }
            else { _StatusText = "Active"; }

        }

        public CheckInRecordWithResource Clone()
        {
            CheckInRecordWithResource cloneTo = this.MemberwiseClone() as CheckInRecordWithResource;
            cloneTo.Record = this.Record.Clone();
            cloneTo.Resource = this.Resource.Clone();
            return cloneTo;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }


}
