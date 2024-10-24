using ProtoBuf;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class Contact : ICloneable
    {
        public Contact() { ContactID = Guid.NewGuid(); Active = true; }

        [ProtoMember(1)] private Guid _ContactID;
        [ProtoMember(2)] private string _ContactName;
        [ProtoMember(3)] private string _Title;
        [ProtoMember(4)] private string _Organization;
        [ProtoMember(5)] private string _Phone;
        [ProtoMember(6)] private string _Email;
        [ProtoMember(7)] private string _Callsign;
        [ProtoMember(8)] private string _RadioChannel;
        [ProtoMember(9)] private string _Notes;
        [ProtoMember(10)] private DateTime _lastUpdatedUTC = DateTime.UtcNow;
        [ProtoMember(11)] private bool _Active;

        public Guid ContactID { get => _ContactID; set => _ContactID = value; }
        public string ContactName { get => _ContactName; set => _ContactName = value; }
        public string Title { get => _Title; set => _Title = value; }
        public string Organization { get => _Organization; set => _Organization = value; }
        public string Phone { get => _Phone; set => _Phone = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Callsign { get => _Callsign; set => _Callsign = value; }
        public string RadioChannel { get => _RadioChannel; set => _RadioChannel = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        public DateTime LastUpdatedUTC { get => _lastUpdatedUTC; set => _lastUpdatedUTC = value; }
        public bool Active { get => _Active; set => _Active = value; }

        public string NameAndOrg { get { if (!string.IsNullOrEmpty(Organization)) { return ContactName + " (" + Organization + ")"; } else { return ContactName; } } }

        public string AllContactMethods
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Phone)) { sb.Append("Tel: "); sb.Append(Phone); }
                if (!string.IsNullOrEmpty(Email))
                {
                    if (sb.Length > 0) { sb.Append(", "); }
                    sb.Append("Email: ");
                    sb.Append(Email);
                }
                if (!string.IsNullOrEmpty(Callsign) || !string.IsNullOrEmpty(RadioChannel))
                {
                    if (sb.Length > 0) { sb.Append(", "); }
                    sb.Append(FullRadio);

                }
                return sb.ToString();
            }
        }

        public string OrgAndTitle
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Organization))
                {
                    sb.Append(Organization);
                }
                if (!string.IsNullOrEmpty(Title))
                {
                    if (sb.Length > 0) { sb.Append(" - "); }
                    sb.Append(Title);
                }
                return sb.ToString();
            }
        }

        public string FullRadio
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Callsign))
                {
                    sb.Append(Callsign);
                }
                if (!string.IsNullOrEmpty(RadioChannel))
                {
                    if (sb.Length > 0) { sb.Append(" on "); }
                    sb.Append(RadioChannel);
                }
                return sb.ToString();
            }
        }

        public Contact Clone()
        {
            return this.MemberwiseClone() as Contact;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
