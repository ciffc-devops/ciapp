using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{

    /// <summary>
    /// This class will be used as the basis for all ICS form data to make sure everything has the same key fields
    /// </summary>
    public class ICSFormData : SyncableItem, ICloneable
    {
        [ProtoMember(1)] private Guid _PreparedByRoleID;
        [ProtoMember(2)] private Guid _PreparedByResourceID;
        [ProtoMember(3)] private string _PreparedByResourceName;
        [ProtoMember(4)] private string _PreparedByRoleName;
        [ProtoMember(5)] private Guid _ApprovedByRoleID;
        [ProtoMember(6)] private Guid _ApprovedByResourceID;
        [ProtoMember(7)] private string _ApprovedByResourceName;
        [ProtoMember(8)] private string _ApprovedByRoleName;
        [ProtoMember(9)] private DateTime _DatePrepared;
        [ProtoMember(10)] private DateTime _DateApproved;



        public Guid PreparedByRoleID { get => _PreparedByRoleID; set => _PreparedByRoleID = value; }
        public Guid PreparedByResourceID { get => _PreparedByResourceID; set => _PreparedByResourceID = value; }
        public string PreparedByResourceName { get => _PreparedByResourceName; set => _PreparedByResourceName = value; }
        public string PreparedByRoleName { get => _PreparedByRoleName; set => _PreparedByRoleName = value; }
        public string PreparedByNameWithRole
        {
            get
            {
                StringBuilder from = new StringBuilder();
                if (!string.IsNullOrEmpty(PreparedByResourceName))
                {
                    from.Append(PreparedByResourceName);

                    if (!string.IsNullOrEmpty(PreparedByRoleName))
                    {
                        from.Append(" - ");
                    }
                }
                if (!string.IsNullOrEmpty(PreparedByRoleName))
                {
                    from.Append(PreparedByRoleName);
                }
                return from.ToString();
            }
        }

        public Guid ApprovedByRoleID { get => _ApprovedByRoleID; set => _ApprovedByRoleID = value; }
        public Guid ApprovedByResourceID { get => _ApprovedByResourceID; set => _ApprovedByResourceID = value; }
        public string ApprovedByResourceName { get => _ApprovedByResourceName; set => _ApprovedByResourceName = value; }
        public string ApprovedByRoleName { get => _ApprovedByRoleName; set => _ApprovedByRoleName = value; }

        public string ApprovedByNameWithRole
        {
            get
            {
                StringBuilder from = new StringBuilder();
                if (!string.IsNullOrEmpty(ApprovedByResourceName))
                {
                    from.Append(ApprovedByResourceName);

                    if (!string.IsNullOrEmpty(ApprovedByRoleName))
                    {
                        from.Append(" - ");
                    }
                }
                if (!string.IsNullOrEmpty(ApprovedByRoleName))
                {
                    from.Append(ApprovedByRoleName);
                }
                return from.ToString();
            }
        }

        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public DateTime DateApproved { get => _DateApproved; set => _DateApproved = value; }


        public void SetApprovedBy(ICSRole role)
        {
            if (role != null)
            {
                ApprovedByRoleID = role.ID;
                ApprovedByResourceID = role.IndividualID;
                ApprovedByResourceName = role.IndividualName;
                ApprovedByRoleName = role.RoleName;
            }
        }

        public void SetPreparedBy(ICSRole role)
        {
            if (role != null)
            {
                PreparedByRoleID = role.ID;
                PreparedByResourceID = role.IndividualID;
                PreparedByResourceName = role.IndividualName;
                PreparedByRoleName = role.RoleName;
            }
        }

        public ICSFormData Clone()
        {
            return this.MemberwiseClone() as ICSFormData;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
