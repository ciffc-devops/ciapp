using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFICSAssist_Class_Library.Models
{
    [Serializable]
    [ProtoContract]
    public class Organization
    {
        public Organization() { }
        public Organization(Guid id, string name, string logo = null)
        {
            OrganizationID = id; OrganizationName = name;
            if (!string.IsNullOrEmpty(logo))
            {
                LogoFileName = logo;
            }
            else { LogoFileName = "BCSARA-Logo-960.png"; }
        }
        public Organization(Guid id, Guid parentid, string name, string logo = null)
        {
            OrganizationID = id; OrganizationName = name;
            ParentOrganizationID = parentid;

            if (!string.IsNullOrEmpty(logo))
            {
                LogoFileName = logo;
            }
            else if (ParentOrganizationID == new Guid("14CC75FE-75D3-44EE-B622-0C0727160675")) { LogoFileName = "saralberta-logo.png"; }
            else { LogoFileName = "BCSARA -Logo-960.png"; }
        }

        [ProtoMember(1)] private Guid _organizationID;
        [ProtoMember(2)] private string _organizationName;
        [ProtoMember(3)] private string _primaryEmail;
        [ProtoMember(4)] private string _primaryPassword;
        [ProtoMember(5)] private int _userCount = 0;
        [ProtoMember(6)] private string _logoFlieName;
        [ProtoMember(7)] private Guid _ParentOrganizationID;






        public Guid OrganizationID { get => _organizationID; set => _organizationID = value; }
        public Guid ParentOrganizationID { get => _ParentOrganizationID; set => _ParentOrganizationID = value; }
        public string ShortOrganizationID
        {
            get
            {
                return Convert.ToBase64String(OrganizationID.ToByteArray());

            }
        }


        public string OrganizationName { get => _organizationName; set => _organizationName = value; }

        public string PrimaryEmail { get => _primaryEmail; set => _primaryEmail = value; }


        public string PrimaryPassword { get => _primaryPassword; set => _primaryPassword = value; }

        public int UserCount { get => _userCount; set => _userCount = value; }


        public string LogoFileName { get => _logoFlieName; set => _logoFlieName = value; }

    }

    public static class OrganizationTools
    {
        public static Organization GetOrganization(Guid orgID)
        {
            List<Organization> orgs = GetOrganizations(Guid.Empty, false);
            if (orgs.Any(o => o.OrganizationID == orgID)) { return orgs.First(o => o.OrganizationID == orgID); }
            else { return null; }
        }

        public static List<Organization> GetParentOrganizations()
        {
            List<Organization> organizations = new List<Organization>();
            Guid ABSAR = new Guid("14CC75FE-75D3-44EE-B622-0C0727160675");
            Guid BCSARA = new Guid("CC3A9DC9-01A3-4D39-B806-2128B51120BC");
            Guid OtherOrgs = new Guid("D2BB4ADB-13FE-4941-AB4A-1A5020C3DC8C");

            organizations.Add(new Organization(ABSAR, Guid.Empty, "AB Search and Rescue", "saralberta-logo.png"));
            organizations.Add(new Organization(BCSARA, Guid.Empty, "BC Search and Rescue", "BCSARA -Logo-960.png"));
            organizations.Add(new Organization(OtherOrgs, Guid.Empty, "Other Organizations", "BCSARA -Logo-960.png"));

            return organizations;
        }

        public static List<Organization> GetOrganizations(Guid ParentID, bool addBlankRecord = false)
        {
            //to be used when the org list is needed and internet is not avilable;
            List<Organization> organizations = new List<Organization>();
            Guid BCSARA = new Guid("CC3A9DC9-01A3-4D39-B806-2128B51120BC");
            Guid ABSAR = new Guid("14CC75FE-75D3-44EE-B622-0C0727160675");
            Guid OtherOrgs = new Guid("D2BB4ADB-13FE-4941-AB4A-1A5020C3DC8C");



            //BCSARA Teams
            organizations.Add(new Organization(new Guid("46698CE0-B146-40E2-B834-0089DECE3896"), BCSARA, "Mackenzie SAR", "MackenzieSAR.png"));
            organizations.Add(new Organization(new Guid("9202836C-DC5C-4C62-8190-022A03769098"), BCSARA, "Revelstoke SAR", "RevelstokeSAR.png"));
            organizations.Add(new Organization(new Guid("BE921E46-2521-4B8C-9438-0645CCB19DE8"), BCSARA, "Arrowsmith SAR", "ArrowsmithSAR.png"));
            organizations.Add(new Organization(new Guid("2F07BE02-EC9F-435D-B8E2-0B31799879BC"), BCSARA, "Quesnel SAR", "QuesnelSAR.png"));
            organizations.Add(new Organization(new Guid("C111498E-74F0-46B3-8442-0B38D435C854"), BCSARA, "Juan De Fuca SAR", "JdF.png"));
            organizations.Add(new Organization(new Guid("16FAD27A-76E6-471E-A3FA-146CCB740DBC"), BCSARA, "Kent Harrison SAR", "KentHarrisonSAR.png"));
            organizations.Add(new Organization(new Guid("4A2BA222-3766-4F38-86E4-1724FDE94AF3"), BCSARA, "Logan Lake SAR", "Logan-Lake.png"));
            organizations.Add(new Organization(new Guid("5C8A48A2-62F6-44E8-93CC-18ECAAE7E2ED"), BCSARA, "Arrow Lakes SAR"));
            organizations.Add(new Organization(new Guid("DBCE7252-92D1-481F-ADD0-1923F1F7FD39"), BCSARA, "Castlegar SAR", "CastlegarSAR.png"));
            organizations.Add(new Organization(new Guid("F2874DE5-0066-45A5-A3F8-1A38A64D67EC"), BCSARA, "Cowichan SAR", "CowichanSAR.png"));
            organizations.Add(new Organization(new Guid("499A9B5C-E712-4968-8B9F-1DEB9D402915"), BCSARA, "Campbell River SAR", "CRSAR.png"));
            organizations.Add(new Organization(new Guid("0EBB892E-F241-466A-B1E1-1E05F01EF0C7"), BCSARA, "North Shore SAR", "NorthShoreRescue.png"));
            organizations.Add(new Organization(new Guid("52078C4B-4A25-4103-A7EA-224B68AB5C55"), BCSARA, "West Chilcotin SAR", "WestChilcotinSAR.png"));
            organizations.Add(new Organization(new Guid("BFDAB6B8-BEE2-4157-A144-23965C166BD8"), BCSARA, "Stewart SAR", "StewartSAR.png"));
            organizations.Add(new Organization(new Guid("E05BB4DE-8786-4289-B39B-2574C41E2777"), BCSARA, "Houston SAR", "HoustonSAR.png"));
            organizations.Add(new Organization(new Guid("76A1101B-464D-4D12-ABBC-266599F2F5DD"), BCSARA, "Robson Valley SAR", "RobsonValleySAR.png"));
            organizations.Add(new Organization(new Guid("D44C628D-E9AD-43CE-9671-2965C64FF0E5"), BCSARA, "Fernie SAR", "FernieSAR.png"));
            organizations.Add(new Organization(new Guid("F964C5E1-2337-4761-AB36-2965F57E7DC4"), BCSARA, "Atlin SAR", "AtlinSAR.png"));
            organizations.Add(new Organization(new Guid("62231DA2-DCB8-413E-8C60-2A0B2E8DC214"), BCSARA, "Parkland SAR"));
            organizations.Add(new Organization(new Guid("37F43ECF-9CD5-4EB5-9699-2C0DBB7974F3"), BCSARA, "Ladysmith SAR", "LadysmithSARlogo.jpg"));
            organizations.Add(new Organization(new Guid("5B2C5A11-07DC-4104-99A5-364C204D4B32"), BCSARA, "Nicola Valley SAR", "NicolaValleySAR.png"));
            organizations.Add(new Organization(new Guid("937148E6-72FD-456B-9DD9-38E975492D5F"), BCSARA, "Nanaimo SAR", "NanaimoSAR.png"));
            organizations.Add(new Organization(new Guid("124CA510-0BD2-4F53-82BE-3A5F4960BFCC"), BCSARA, "Penticton SAR", "PenSAR.jpg"));
            organizations.Add(new Organization(new Guid("0B0DC8D4-9A62-4987-8EFA-43FC2A31D598"), BCSARA, "Whistler SAR", "WhistlerSAR.png"));
            organizations.Add(new Organization(new Guid("87756CEF-01AC-493A-89BE-464CADAE7EE1"), BCSARA, "Kimberley SAR", "KimberleySAR.png"));
            organizations.Add(new Organization(new Guid("74E5E639-A831-427F-8494-4DCD0A55BF37"), BCSARA, "Creston Valley SAR", "CrestonValleySAR.png"));
            organizations.Add(new Organization(new Guid("6A39C786-4C74-4B1E-91A6-4E1FCFE7584D"), BCSARA, "Kitimat SAR", "KitimatSAR.png"));
            organizations.Add(new Organization(new Guid("7AF5AD55-2655-4218-B693-56F48353E190"), BCSARA, "South Columbia SAR", "SouthColumbiaSAR.png"));
            organizations.Add(new Organization(new Guid("11A311E6-6768-46AA-9F3C-571AA95E3726"), BCSARA, "Nakusp SAR"));
            organizations.Add(new Organization(new Guid("65D6C93C-63F9-476F-8A63-5C8A968F4E11"), BCSARA, "PEMO SAR", "PeninsulaSAR.png"));
            organizations.Add(new Organization(new Guid("D83B66D5-C697-448F-9E4F-5DA7828A66A5"), BCSARA, "Metchosin SAR", "MetchosinSAR.png"));
            organizations.Add(new Organization(new Guid("9893E045-D590-44E4-8AF4-5DBB1F1661A4"), BCSARA, "Prince Rupert SAR", "PrinceRupertSAR.png"));
            organizations.Add(new Organization(new Guid("B3AE6204-9E95-452A-9C10-5EB4178E0ABE"), BCSARA, "Pemberton SAR", "PembertonSAR.png"));
            organizations.Add(new Organization(new Guid("2207EB6C-E292-47E8-AE3D-68855B846109"), BCSARA, "Powell River SAR", "PowellRiverSAR.png"));
            organizations.Add(new Organization(new Guid("A1C1A217-4AE3-462C-A7D4-68FFAA8C0210"), BCSARA, "Rossland SAR", "RosslandSAR.png"));
            organizations.Add(new Organization(new Guid("98851139-E736-4974-A672-6972F3A8965F"), BCSARA, "South Peace SAR", "SouthPeaceSAR.png"));
            organizations.Add(new Organization(new Guid("AB67B6D4-F795-43AD-9506-69880F7BEAFD"), BCSARA, "Alberni Valley Rescue Squad", "AlberniValleySAR.png"));
            organizations.Add(new Organization(new Guid("8940A059-6A5A-4004-9D1E-758C4D576C2E"), BCSARA, "Bulkley Valley SAR", "BulkleyValleySAR.png"));
            organizations.Add(new Organization(new Guid("169C529D-792A-4615-ABE9-78203A6A70A4"), BCSARA, "Grand Forks SAR", "GrandForksSAR.png"));
            organizations.Add(new Organization(new Guid("88B20B0B-04BC-4596-A2F5-7CCCB317A4A0"), BCSARA, "Ridge Meadows SAR", "RidgeMeadowsSAR.png"));
            organizations.Add(new Organization(new Guid("FEC27732-35F1-43D6-9597-7E0D2FEEDD65"), BCSARA, "Mission SAR", "MissionSAR.png"));
            organizations.Add(new Organization(new Guid("CDA9B3A3-FC65-4803-8685-813BCE298DEF"), BCSARA, "Bella Coola Valley SAR", "BellaCoolaSAR.png"));
            organizations.Add(new Organization(new Guid("2EFA81F4-3E9B-4E45-BE94-8166AAA9298C"), BCSARA, "Keremeos SAR", "KeremeosSAR.png"));
            organizations.Add(new Organization(new Guid("FF7F03D5-E414-443F-8315-82BB378ABBD8"), BCSARA, "Comox Valley SAR", "CVGSAR2020Logo.png"));
            organizations.Add(new Organization(new Guid("4643747E-FB2A-4230-B4B8-8506F9951DFF"), BCSARA, "Chetwynd SAR", "ChetwyndSAR.png"));
            organizations.Add(new Organization(new Guid("B865EDF6-F0A7-4241-8CD4-8A5942C7B18A"), BCSARA, "Tumbler Ridge SAR", "TumblerRidgeSAR.png"));
            organizations.Add(new Organization(new Guid("589F720D-A304-49CF-B40C-8E944D7C9D2F"), BCSARA, "Fort St. James SAR", "FortStJamesJSAR.png"));
            organizations.Add(new Organization(new Guid("893B590C-A159-4A89-9CA4-A3DF24D6ABFE"), BCSARA, "Sunshine Coast SAR", "SunshineCoastSAR.png"));
            organizations.Add(new Organization(new Guid("B04FE1E7-979F-40CC-892C-A74EEA295ECB"), BCSARA, "Kaslo SAR", "KasloSAR.png"));
            organizations.Add(new Organization(new Guid("8B8D2A86-91D6-4606-B2D7-A9EDF3C8EE35"), BCSARA, "Burns Lake SAR", "BurnsLakeSAR.png"));
            organizations.Add(new Organization(new Guid("8FB71ABC-4C5C-43A8-8E68-AA75DD2262EB"), BCSARA, "Vernon SAR", "Vernon.png"));
            organizations.Add(new Organization(new Guid("CE558295-B9E2-41A3-88F1-AE029EC1AE0D"), BCSARA, "Kamloops SAR", "KamloopsSAR.png"));
            organizations.Add(new Organization(new Guid("DF7FBC23-17F2-41AB-8DEB-AF00D27C5B7F"), BCSARA, "Oliver Osoyoos SAR", "OOSAR.png"));
            organizations.Add(new Organization(new Guid("64B9D581-05FD-4D9B-ABFF-B24BFAFCEA2C"), BCSARA, "Lions Bay SAR", "LionsBaySAR.png"));
            organizations.Add(new Organization(new Guid("3CD654FA-8B48-4C75-BB75-B7834639990C"), BCSARA, "South Cariboo SAR", "SouthCaribooSAR.png"));
            organizations.Add(new Organization(new Guid("F7CD798B-52AD-423E-B66F-BD01D3B70D5D"), BCSARA, "Squamish SAR", "SquamishSAR.png"));
            organizations.Add(new Organization(new Guid("D0AEC6BB-EE25-437B-8A8C-BEAA284FF685"), BCSARA, "Fort Nelson SAR"));
            organizations.Add(new Organization(new Guid("890789F2-9DB1-4785-BF00-BF051676B11E"), BCSARA, "Shuswap SAR", "ShuswapSAR.png"));
            organizations.Add(new Organization(new Guid("2679596A-3D96-4E74-913E-BF273235FC6F"), BCSARA, "Nechako Valley SAR", "NechakoValleySAR.png"));
            organizations.Add(new Organization(new Guid("EA48BC49-A566-4248-A4B5-C1A6DBBEF00B"), BCSARA, "Central Fraser Valley SAR", "CFVSAR.png"));
            organizations.Add(new Organization(new Guid("12FDF8F5-4127-456E-9F6D-C6912161BE6F"), BCSARA, "Columbia Valley SAR", "ColumbiaValleySAR.png"));
            organizations.Add(new Organization(new Guid("20A1A9F3-CB11-43F8-BEFE-C8933A566764"), BCSARA, "Prince George SAR", "PGSAR-002.png"));
            organizations.Add(new Organization(new Guid("C704D0F8-AF89-4143-BD3E-CB4EAC7A7AA7"), BCSARA, "Central Okanagan SAR", "COOSAR.png"));
            organizations.Add(new Organization(new Guid("EF91565B-77F8-428B-9D15-D0EAA4043A0E"), BCSARA, "Hope SAR", "HopeSAR.png"));
            organizations.Add(new Organization(new Guid("97717FBA-977C-49CD-B105-D55FA705AA14"), BCSARA, "North Peace SAR", "NorthPeaceSAR.png"));
            organizations.Add(new Organization(new Guid("83081A8A-6C30-45A8-B9B1-D625090148D6"), BCSARA, "Elkford SAR", "ElkfordSAR.png"));
            organizations.Add(new Organization(new Guid("6C4ED3C8-18D1-4F25-BEB1-D8C3B5272267"), BCSARA, "Coquitlam SAR", "CoquitlamSAR.png"));
            organizations.Add(new Organization(new Guid("6FD79D61-ED33-46E1-A1AA-E3BC1F24A143"), BCSARA, "Chilliwack SAR", "ChilliwackSAR.png"));
            //organizations.Add(new Organization(new Guid("B8E1D50D-C5A4-4ECD-9B5A-E4DB0AEFA57C"), "Saanich SAR"));
            organizations.Add(new Organization(new Guid("C0A7C62C-8C76-43F5-9357-E65394CCA2CB"), BCSARA, "South Fraser SAR", "SFSAR_Logo_TranparentBG_1500px-1.png"));
            organizations.Add(new Organization(new Guid("452E4432-F01C-4FDB-8DB4-E7399FC09A97"), BCSARA, "Sparwood SAR", "SparwoodSAR.png"));
            organizations.Add(new Organization(new Guid("0E63E227-27A8-4B11-8043-EC2C589A4CBA"), BCSARA, "Golden SAR", "GoldenSAR.png"));
            organizations.Add(new Organization(new Guid("3642094A-274C-44DA-B379-ED42E9265FF8"), BCSARA, "Central Cariboo SAR", "CentralCaribooSAR.png"));
            organizations.Add(new Organization(new Guid("D5A57651-6C40-4A8E-A442-F0D7294FE0ED"), BCSARA, "Terrace SAR", "TerraceSAR.png"));
            organizations.Add(new Organization(new Guid("8CA3E11B-5A87-4C72-A11C-F14225AC7AAF"), BCSARA, "Princeton SAR", "1 -PGSAR.png"));
            organizations.Add(new Organization(new Guid("77F87A03-46E8-4C70-A05B-F32DAE58276B"), BCSARA, "Westcoast Inland SAR", "WestCoastSAR.png"));
            organizations.Add(new Organization(new Guid("8E824695-1EDD-49FE-BADF-F42F8A34A95F"), BCSARA, "Salt Spring Island SAR", "SSILogo1.jpg"));
            organizations.Add(new Organization(new Guid("5153C373-4B73-45F6-99B6-F4DA00D28B92"), BCSARA, "Wells Gray SAR", "WellsGreySAR.png"));
            organizations.Add(new Organization(new Guid("B2CD40D5-6ABF-4FF8-A89E-F5FE6B995C89"), BCSARA, "Nelson SAR", "NelsonSAR.png"));
            organizations.Add(new Organization(new Guid("71FFF997-108B-4DDF-914E-F81069F8EA26"), BCSARA, "Barriere SAR", "Barrier.png"));
            organizations.Add(new Organization(new Guid("A3190007-E0EA-49F8-95F8-F8FF8396A38B"), BCSARA, "Cranbrook SAR", "CranbrookSAR.png"));
            organizations.Add(new Organization(new Guid("F1B9CA16-CB19-4DD2-961F-FE3EB6CC6477"), BCSARA, "Archipelago SAR", "ArchSAR.png"));


            //Alberta SAR
            organizations.Add(new Organization(new Guid("A52F1CD3-CE79-4AA7-BEA4-EA5BCB4DBC3C"), ABSAR, "Alberta/British Columbia Cave Rescue"));
            organizations.Add(new Organization(new Guid("F18ACA88-3F15-4F94-A067-E0F7195331DE"), ABSAR, "Badlands Search and Rescue"));
            organizations.Add(new Organization(new Guid("FB594701-8FB9-49B1-AD06-9F0CE462A0B0"), ABSAR, "Bonnyville SAR"));
            organizations.Add(new Organization(new Guid("5AEA95A1-398A-4A9F-86DC-DAFFD1550E1C"), ABSAR, "Brazeau Regional Search and Rescue"));
            organizations.Add(new Organization(new Guid("2107B4FA-A818-4951-9E76-19E43FA78E10"), ABSAR, "Calgary Search and Rescue Association"));
            organizations.Add(new Organization(new Guid("EE92AA60-D987-483F-8CCB-A49A27EA251F"), ABSAR, "Calling Lake Search and Rescue"));
            organizations.Add(new Organization(new Guid("D00E558F-AABA-4C27-A791-88C55C3200AD"), ABSAR, "Canadian Search Dog Association"));
            organizations.Add(new Organization(new Guid("78CC6C91-48F2-4A8A-93B1-5B4C751FDAEE"), ABSAR, "Central Zone Search and Rescue"));
            organizations.Add(new Organization(new Guid("BE2C305E-A83F-411A-82FA-7CCC07E8C945"), ABSAR, "Cochrane Search and Rescue "));
            organizations.Add(new Organization(new Guid("1146DE80-75A9-431C-93FA-A50F2BE3D882"), ABSAR, "Cold Lake Search and Rescue"));
            organizations.Add(new Organization(new Guid("1CD64BE4-3BDB-471F-B433-2A3F5B65A426"), ABSAR, "Edmonton Regional SAR"));
            organizations.Add(new Organization(new Guid("52DE1A5C-5421-4BF3-B5A5-13F22825BDA0"), ABSAR, "Foothills Search & Rescue"));
            organizations.Add(new Organization(new Guid("C1307123-D412-4906-940D-5E8E7A65C7A2"), ABSAR, "Fort McMurray SAR"));
            organizations.Add(new Organization(new Guid("98632A6A-7984-46E9-9C20-21FD38F908CF"), ABSAR, "Grande Cache SAR"));
            organizations.Add(new Organization(new Guid("0920E8BD-F0C1-4314-B294-50689BB83ADF"), ABSAR, "Greenview Search and Rescue Association"));
            organizations.Add(new Organization(new Guid("55F762C4-594E-4716-A3A9-A7FA7C6F16D2"), ABSAR, "Hinton Search & Rescue"));
            organizations.Add(new Organization(new Guid("56DF7757-DD4E-4B03-B972-C0922ACA3272"), ABSAR, "Klondike Trail SAR"));
            organizations.Add(new Organization(new Guid("92D9089B-8B57-4BA1-A833-DA3389F97D39"), ABSAR, "LASARA"));
            organizations.Add(new Organization(new Guid("6F951735-6400-45AB-8D5B-470BEAF92397"), ABSAR, "Lesser Slave Lake Search and Rescue"));
            organizations.Add(new Organization(new Guid("02C80D21-6A55-4107-8180-AE263C77A2BA"), ABSAR, "Little Divide Search and Rescue"));
            organizations.Add(new Organization(new Guid("5BA2D51B-C5F5-4D06-BB3F-A809257F5FD7"), ABSAR, "Mountain View Search & Rescue"));
            organizations.Add(new Organization(new Guid("38F21B78-00BD-43D5-8422-9526CE6F929F"), ABSAR, "Parkland Search and Rescue"));
            organizations.Add(new Organization(new Guid("B25D8BB0-9CFE-41A9-88B9-E7DA8BBBA318"), ABSAR, "Peace Region Search and Rescue"));
            organizations.Add(new Organization(new Guid("21F36B99-445D-43F3-B7DA-843FC1B4A55C"), ABSAR, "Pincher Creek Search & Rescue"));
            organizations.Add(new Organization(new Guid("F333977A-3BF0-4780-80F5-69D070488AC0"), ABSAR, "Red Deer County SAR"));
            organizations.Add(new Organization(new Guid("83978072-06CB-45E2-8C22-61D6E93917DE"), ABSAR, "Rocky Mountain House Search & Rescue"));
            organizations.Add(new Organization(new Guid("EBAC4741-CBC7-47C3-A132-E396FC1174C6"), ABSAR, "SARDAA"));
            organizations.Add(new Organization(new Guid("E50F1F97-2E42-4CA9-8C26-704E0C23282A"), ABSAR, "South Eastern Alberta Search and Rescue"));
            organizations.Add(new Organization(new Guid("4F020A6A-5CF4-4479-A6AF-A6319DB3800F"), ABSAR, "St Paul SAR"));
            organizations.Add(new Organization(new Guid("7A5DCB28-0244-4DFF-98C1-5C6DAA46D7E8"), ABSAR, "Sundre Volunteer Search and Rescue"));
            organizations.Add(new Organization(new Guid("5347C261-0187-4044-8B58-ED494B1FF805"), ABSAR, "Technical Search and Rescue"));
            organizations.Add(new Organization(new Guid("19703F2D-4479-4D64-81E4-FA04B6144D87"), ABSAR, "Wetaskiwin Search and Rescue"));
            organizations.Add(new Organization(new Guid("E0E78144-CD98-4623-AB20-6020CBB68772"), ABSAR, "Whitecourt SAR"));




            //02035C34-CD9C-4B3D-9C22-5AF29068A0D9

            organizations = organizations.OrderBy(o => o.OrganizationName).ToList();
            organizations.Add(new Organization(new Guid("008bdd33-28a1-46b6-818d-59225f2e97df"), BCSARA, "BC Tracking Association", "BCTALogoSeal@1x.png"));
            organizations.Add(new Organization(new Guid("489f9815-808d-4f55-a17f-214d352e7661"), BCSARA, "BC Search Dog Association", "BCSDA-2016-logo_512.png"));
            organizations.Add(new Organization(new Guid("6b7e460d-2490-4a8c-b828-5c1d7d707c83"), OtherOrgs, "OPP ERT", "OPPERT.png"));


            if (ParentID != Guid.Empty)
            {
                organizations = organizations.Where(o => o.ParentOrganizationID == ParentID).ToList();
            }

            organizations.Add(new Organization(new Guid("8CBE0C6D-78B1-4600-96C0-21E3C16A444D"), OtherOrgs, "Great Hat Web Design", "GreatHatCircle.png"));
            organizations.Add(new Organization(new Guid("96BA69A4-436C-4DA1-85B1-992E84C36019"), OtherOrgs, "Unassigned", "SAR Assistant_lq.png"));
            organizations.Add(new Organization(new Guid("02035C34-CD9C-4B3D-9C22-5AF29068A0D9"), OtherOrgs, "Non-SAR", "SAR Assistant_lq.png"));


            if (addBlankRecord)
            {
                Organization blankOrg = new Organization();
                blankOrg.OrganizationID = Guid.Empty;
                blankOrg.OrganizationName = "-All Groups-";
                organizations.Insert(0, blankOrg);
            }


            return organizations;
        }
    }

    public class GroupSignInPrintRequest : Organization
    {
        private int _PrintCount;
        public int PrintCount { get => _PrintCount; set => _PrintCount = value; }

        public GroupSignInPrintRequest(Organization org, int count = 0)
        {
            OrganizationID = org.OrganizationID;
            OrganizationName = org.OrganizationName;
            PrintCount = count;
        }


    }
}
