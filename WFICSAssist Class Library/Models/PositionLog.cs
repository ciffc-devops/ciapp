using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
{
    [ProtoContract]
    [Serializable]
    public class PositionLogEntry : ICloneable
    {
        [ProtoMember(1)] private Guid _LogID;
        [ProtoMember(2)] private int _OpPeriod;
        [ProtoMember(3)] private ICSRole _Role;
        [ProtoMember(4)] private DateTime _DateCreated;
        [ProtoMember(5)] private DateTime _DateUpdated;
        [ProtoMember(6)] private bool _IsComplete;
        [ProtoMember(7)] private DateTime _ReminderTime;
        [ProtoMember(8)] private DateTime _TimeDue;
        [ProtoMember(9)] private string _LogText;
        [ProtoMember(10)] private bool _IsInfoOnly;
        [ProtoMember(11)] private List<string> _LogHistory;
        [ProtoMember(12)] private DateTime _LastUpdatedUTC;
        public PositionLogEntry() { _LogID = Guid.NewGuid(); _LogHistory = new List<string>(); _DateCreated = DateTime.Now; _IsComplete = false; }
        public PositionLogEntry(ICSRole role, int op_period, string text)
        {
            _LogID = Guid.NewGuid();
            _LogHistory = new List<string>();
            _Role = role;
            _DateCreated = DateTime.Now;
            _DateUpdated = DateTime.Now;
            _IsComplete = false;
            _OpPeriod = op_period;
            _LogText = text;
        }

        public Guid LogID { get => _LogID; set => _LogID = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public ICSRole Role { get => _Role; set => _Role = value; }
        public string RoleName { get { if (Role != null) { return Role.RoleName; } else { return null; } } }
        public DateTime DateCreated
        {
            get => _DateCreated;
            set
            {
                _DateCreated = value;
            }
        }
        public void updateDateCreated(DateTime value, string individualName)
        {
            if (string.IsNullOrEmpty(individualName)) { individualName = "Unassigned"; }
            if (_DateCreated > DateTime.MinValue && value != DateCreated)
            {
                AddToHistory("Updated date/time from " + _DateCreated.ToString("yyyy-MMM-dd HH:mm") + " to " + value.ToString("yyyy-MMM-dd HH:mm") + "  - by " + individualName);
                DateUpdated = DateTime.Now;
            }
            else if (value != DateCreated) { AddToHistory("Set entry date/time as " + value.ToString("yyyy-MMM-dd HH:mm") + "  - by " + individualName); DateUpdated = DateTime.Now; }

            DateCreated = value;

        }

        public DateTime DateUpdated { get => _DateUpdated; set => _DateUpdated = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }

        public bool IsComplete
        {
            get => _IsComplete; set
            {

                _IsComplete = value;

            }
        }
        public void updateIsComplete(bool value, string individualName)
        {
            if (string.IsNullOrEmpty(individualName)) { individualName = "Unassigned"; }

            if (value && value != IsComplete) { AddToHistory("Marked as complete - by " + individualName); }
            else if (value != IsComplete) { AddToHistory("Marked as incomplete - by " + individualName); }

            _IsComplete = value; _DateUpdated = DateTime.UtcNow;

        }

        public DateTime ReminderTime { get => _ReminderTime; set => _ReminderTime = value; }
        public DateTime TimeDue
        {
            get => _TimeDue;
            set
            {
                _TimeDue = value;
                // AddToHistory("Updated Due Date to " + value.ToString("yyyy-MMM-dd HH:mm"));
            }
        }
        public string TimeDueAsString
        {
            get
            {
                if (IsInfoOnly) { return null; }
                if (IsComplete) { return null; }
                else { return TimeDue.ToString("yyyy-MMM-dd HH:mm"); }
            }
        }

        public void updateTimeDue(DateTime value, string individualName)
        {
            if (value != TimeDue)
            {
                if (string.IsNullOrEmpty(individualName)) { individualName = "Unassigned"; }
                AddToHistory("Updated Due Date to " + value.ToString("yyyy-MMM-dd HH:mm") + "  - by " + individualName);
                _TimeDue = value;
                DateUpdated = DateTime.Now;
            }
        }
        public string LogText
        {
            get => _LogText;
            set
            {
                //AddToHistory("Entry text updated to: " + value);
                _LogText = value;
            }
        }
        public void UpdateLogText(string value, string individualName)
        {
            if (string.IsNullOrEmpty(LogText) || !LogText.Equals(value, StringComparison.InvariantCulture))
            {
                if (string.IsNullOrEmpty(individualName)) { individualName = "Unassigned"; }

                AddToHistory("Entry text updated to: " + value + " - by " + individualName);
                _LogText = value;
                DateUpdated = DateTime.Now;
            }
        }

        public bool IsInfoOnly { get => _IsInfoOnly; set => _IsInfoOnly = value; }
        public List<string> LogHistory { get => _LogHistory; set => _LogHistory = value; }
        public string LogHistoryString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in LogHistory)
                {
                    sb.Append(s);
                }
                return sb.ToString();
            }
        }

        public void AddToHistory(string update)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("yyyy-MMM-dd HH:mm")); sb.Append(" - ");
            sb.Append(update);
            sb.Append(Environment.NewLine);
            LogHistory.Add(sb.ToString());
        }

        public string CopyNextOpText { get; set; } = "Copy to next op";


        public PositionLogEntry Clone()
        {
            PositionLogEntry cloneto = this.MemberwiseClone() as PositionLogEntry;
            cloneto.Role = this.Role.Clone();
            return cloneto;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
