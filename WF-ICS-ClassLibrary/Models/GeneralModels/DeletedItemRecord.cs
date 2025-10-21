using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models.GeneralModels
{
    [ProtoContract]
    public class DeletedItemRecord
    {
        [ProtoMember(1)] private Guid _Id;
        [ProtoMember(2)] private string _ItemType;
        [ProtoMember(3)] private DateTime _DateDeleted;
        [ProtoMember(4)] private string _DeletedByName;
        [ProtoMember(5)] private string _ItemDescription;

        public Guid Id { get => _Id; set => _Id = value; }
        public string ItemType { get => _ItemType; set => _ItemType = value; }
        public DateTime DateDeleted { get => _DateDeleted; set => _DateDeleted = value; }
        public string DeletedByName { get => _DeletedByName; set => _DeletedByName = value; }
        public string ItemDescription { get => _ItemDescription; set => _ItemDescription = value; }


        public DeletedItemRecord()
        {
            Id = Guid.NewGuid();
            DateDeleted = DateTime.UtcNow;
        }

        public DeletedItemRecord(TaskUpdate update)
        {
            Id = update.ItemID;
            ItemType = update.ObjectType;
            DateDeleted = update.LastUpdateLocal;
            DeletedByName = update.CreatedByRoleName; 
            ItemDescription = update.Data.ItemDescription;

        }

    }
}
