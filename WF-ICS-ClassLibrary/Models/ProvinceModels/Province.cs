using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [Serializable]
    [ProtoContract]
    public class Province
    {
        [ProtoMember(1)] private int _ProvinceID;
        [ProtoMember(2)] private string _ProvinceName;
        [ProtoMember(3)] private string _ProvinceShort;
        [ProtoMember(4)] private Guid _ProvinceGUID;

        public int ProvinceID { get => _ProvinceID; set => _ProvinceID = value; }
        public string ProvinceName { get => _ProvinceName; set => _ProvinceName = value; }
        public string ProvinceShort { get => _ProvinceShort; set => _ProvinceShort = value; }
        public Guid ProvinceGUID { get => _ProvinceGUID; set => _ProvinceGUID = value; }

        public Province() { }
        public Province(int id, string name, string shortname, Guid guid_id = new Guid()) { ProvinceID = id; ProvinceName = name; ProvinceShort = shortname; ProvinceGUID = guid_id; }
        public Province(int id)
        {
            List<Province> provinces = ProvinceTools.GetProvinces(false);
            if (provinces.Where(o => o.ProvinceID == id).Any()) { Province p = provinces.Where(o => o.ProvinceID == id).First(); ProvinceID = p.ProvinceID; ProvinceName = p.ProvinceName; ProvinceShort = p.ProvinceShort; ProvinceGUID = p.ProvinceGUID; }
        }

        public Province(Guid id)
        {
            List<Province> provinces = ProvinceTools.GetProvinces(false);
            if (provinces.Where(o => o.ProvinceGUID == id).Any()) { Province p = provinces.Where(o => o.ProvinceGUID == id).First(); ProvinceID = p.ProvinceID; ProvinceName = p.ProvinceName; ProvinceShort = p.ProvinceShort; ProvinceGUID = p.ProvinceGUID; }
        }


        

    }
}
