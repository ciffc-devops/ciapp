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

    public static class ProvinceTools
    {
        public static List<Province> GetProvinces(bool includeAll = false)
        {
            List<Province> provinces = new List<Province>();
            provinces.Add(new Province(1, "Ontario", "ON", new Guid("92A48AE7-DE46-4109-AF54-764DE9506B7F")));
            provinces.Add(new Province(2, "Quebec", "QC", new Guid("78B8CC10-EB9F-4C6B-B5A7-BBC059637426")));
            provinces.Add(new Province(3, "British Columbia", "BC", new Guid("16C6A8DF-F5C4-4D69-9740-7B35379A61E6")));
            provinces.Add(new Province(4, "Alberta", "AB", new Guid("7F9BE9A8-2ED2-41C0-843A-D124BCF0CF29")));
            provinces.Add(new Province(5, "Manitoba", "MB", new Guid("05E0825B-3AC6-4F82-93BA-BC266CCD6022")));
            provinces.Add(new Province(6, "Saskatchewan", "SK", new Guid("73785E72-33AC-4785-BF25-ACB7D94FB05C")));
            provinces.Add(new Province(7, "Nova Scotia", "NS", new Guid("9CE0D5E8-EEF1-422C-950C-9879E1C47781")));
            provinces.Add(new Province(8, "New Brunswick", "NB", new Guid("E74EEB6D-2492-4139-87CB-A05195D7431B")));
            provinces.Add(new Province(9, "Newfoundland and Labrador", "NL", new Guid("64132AE8-1645-4ED3-A4E2-0298C29528BB")));
            provinces.Add(new Province(10, "Prince Edward Island", "PE", new Guid("CE053D27-35AE-49EF-92B2-F979284308E7")));
            provinces.Add(new Province(11, "Northwest Territories", "NT", new Guid("7F94C1CE-14D9-4CD8-8EF7-D4F2950C3AB2")));
            provinces.Add(new Province(12, "Nunavut", "NU", new Guid("DAD488CF-91CB-4223-B540-6828904002CC")));
            provinces.Add(new Province(13, "Yukon", "YT", new Guid("E7A3A509-D244-4C2A-92C9-8F798377BB22")));
            provinces = provinces.OrderBy(o => o.ProvinceName).ToList();
            if (includeAll)
            {
                provinces.Insert(0, new Province(0, "-All Provinces-", "ALL"));
            }

            return provinces;
        }
    }
}
